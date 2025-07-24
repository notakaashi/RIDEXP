Imports MySql.Data.MySqlClient

Public Module RentalTransactionModule

    ' Database connection and transaction objects
    Public conn As MySqlConnection
    Public transaction As MySqlTransaction

    ' Transaction data structure
    Public Structure RentalTransactionData
        ' Form 1 - Car Selection
        Public SelectedCarId As Integer
        Public SelectedCarName As String
        Public DailyRate As Decimal

        ' Form 2 - Date, Time, Location (Current Form)
        Public PickupDate As Date
        Public PickupTime As String
        Public ReturnDate As Date
        Public ReturnTime As String
        Public RentalDurationDays As Integer
        Public PickupPlace As String
        Public ReturnPlace As String
        Public IsPickupAtStation As Boolean
        Public IsReturnAtStation As Boolean

        ' Form 3 - Review Data
        Public TotalAmount As Decimal
        Public CustomerConfirmed As Boolean

        ' Form 4 - Payment
        Public PaymentMethod As String
        Public PaymentStatus As String
        Public PaymentReference As String

        ' Additional fields
        Public CustomerId As Integer
        Public ReservationId As Integer
        Public RentalStatusId As Integer
    End Structure

    ' Global transaction data
    Public TransactionData As RentalTransactionData

    ' Initialize transaction
    Public Function StartTransaction() As Boolean
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection("server=localhost;userid=root;password=;database=ridexp")
            End If

            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            transaction = conn.BeginTransaction()

            ' Initialize transaction data
            TransactionData = New RentalTransactionData()

            Return True
        Catch ex As Exception
            MessageBox.Show("Error starting transaction: " & ex.Message)
            CleanupTransaction()
            Return False
        End Try
    End Function

    ' Commit transaction
    Public Function CommitTransaction() As Boolean
        Try
            If transaction IsNot Nothing Then
                transaction.Commit()
                CleanupTransaction()
                ClearTransactionData()
                Return True
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show("Error committing transaction: " & ex.Message)
            RollbackTransaction()
            Return False
        End Try
    End Function

    ' Rollback transaction
    Public Function RollbackTransaction() As Boolean
        Try
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            CleanupTransaction()
            ClearTransactionData()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error rolling back transaction: " & ex.Message)
            CleanupTransaction()
            ClearTransactionData()
            Return False
        End Try
    End Function

    ' Cleanup transaction objects
    Private Sub CleanupTransaction()
        Try
            If transaction IsNot Nothing Then
                transaction.Dispose()
                transaction = Nothing
            End If
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            ' Log error but don't show to user
        End Try
    End Sub

    ' Clear transaction data
    Public Sub ClearTransactionData()
        TransactionData = New RentalTransactionData()
    End Sub

    ' Save Form 1 data (Car Selection)
    Public Sub SaveForm1Data(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String)
        With TransactionData
            .SelectedCarId = carId
            .SelectedCarName = carName
            .DailyRate = dailyRate
        End With
    End Sub

    ' Save Form 2 data (Date, Time, Location)
    Public Sub SaveForm2Data(pickupDate As Date, pickupTime As String, returnDate As Date, returnTime As String,
                           pickupPlace As String, returnPlace As String, isPickupAtStation As Boolean, isReturnAtStation As Boolean)
        With TransactionData
            ' Save only the date part (remove time component)
            .PickupDate = pickupDate.Date
            .PickupTime = pickupTime
            .ReturnDate = returnDate.Date
            .ReturnTime = returnTime
            .RentalDurationDays = CInt((returnDate.Date - pickupDate.Date).TotalDays)
            If .RentalDurationDays < 1 Then .RentalDurationDays = 1
            .PickupPlace = pickupPlace
            .ReturnPlace = returnPlace
            .IsPickupAtStation = isPickupAtStation
            .IsReturnAtStation = isReturnAtStation
            .TotalAmount = .DailyRate * .RentalDurationDays
        End With
    End Sub

    ' Insert rental data (called from final form)
    Public Function InsertRentalData() As Integer
        Try
            Dim cmd As New MySqlCommand("
                INSERT INTO rentals (
                    reservation_id, rental_duration_days, pickup_date, pickup_time, 
                    return_date, return_time, customer_id, vehicle_id, amount, 
                    rental_status_id, pickup_place, return_place
                ) VALUES (
                    @reservation_id, @rental_duration_days, @pickup_date, @pickup_time,
                    @return_date, @return_time, @customer_id, @vehicle_id, @amount,
                    @rental_status_id, @pickup_place, @return_place
                )", conn, transaction)

            With cmd.Parameters
                .AddWithValue("@reservation_id", If(TransactionData.ReservationId = 0, DBNull.Value, TransactionData.ReservationId))
                .AddWithValue("@rental_duration_days", TransactionData.RentalDurationDays)
                ' Format dates properly for MySQL (YYYY-MM-DD)
                .AddWithValue("@pickup_date", TransactionData.PickupDate.ToString("yyyy-MM-dd"))
                ' Parse time string to TimeSpan for MySQL TIME format
                .AddWithValue("@pickup_time", If(String.IsNullOrEmpty(TransactionData.PickupTime), DBNull.Value, TimeSpan.Parse(TransactionData.PickupTime)))
                .AddWithValue("@return_date", TransactionData.ReturnDate.ToString("yyyy-MM-dd"))
                .AddWithValue("@return_time", If(String.IsNullOrEmpty(TransactionData.ReturnTime), DBNull.Value, TimeSpan.Parse(TransactionData.ReturnTime)))
                .AddWithValue("@customer_id", TransactionData.CustomerId)
                .AddWithValue("@vehicle_id", TransactionData.SelectedCarId)
                .AddWithValue("@amount", TransactionData.TotalAmount)
                .AddWithValue("@rental_status_id", TransactionData.RentalStatusId)
                .AddWithValue("@pickup_place", TransactionData.PickupPlace)
                .AddWithValue("@return_place", TransactionData.ReturnPlace)
            End With

            cmd.ExecuteNonQuery()

            ' Get the inserted rental_id
            cmd.CommandText = "SELECT LAST_INSERT_ID()"
            Return Convert.ToInt32(cmd.ExecuteScalar())

        Catch ex As Exception
            Throw New Exception("Error inserting rental data: " & ex.Message)
        End Try
    End Function

    ' Validate transaction data
    Public Function ValidateTransactionData() As Boolean
        With TransactionData
            If .SelectedCarId <= 0 Then
                MessageBox.Show("Please select a car.")
                Return False
            End If

            If .CustomerId <= 0 Then
                MessageBox.Show("Customer ID is required.")
                Return False
            End If

            If .PickupDate = Nothing OrElse .ReturnDate = Nothing Then
                MessageBox.Show("Please select pickup and return dates.")
                Return False
            End If

            If .PickupDate >= .ReturnDate Then
                MessageBox.Show("Return date must be after pickup date.")
                Return False
            End If

            If String.IsNullOrWhiteSpace(.PickupPlace) OrElse String.IsNullOrWhiteSpace(.ReturnPlace) Then
                MessageBox.Show("Pickup and return places are required.")
                Return False
            End If

            If .TotalAmount <= 0 Then
                MessageBox.Show("Invalid rental amount.")
                Return False
            End If
        End With

        Return True
    End Function

End Module