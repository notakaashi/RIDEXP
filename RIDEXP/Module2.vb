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

        Public SelectedMotorId As Integer
        Public SelectedMotorName As String
        Public VehicleType As String
        Public SelectedVehicleId As Integer

        ' Form 2 - Date, Time, Location
        Public PickupDate As Date
        Public PickupTime As String
        Public ReturnDate As Date
        Public ReturnTime As String


        Public RentalDurationDays As Decimal
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

        End Try
    End Sub

    ' Clear transaction data
    Public Sub ClearTransactionData()
        TransactionData = New RentalTransactionData()
    End Sub

    ' Save Form 1 data (Car Selection)
    Public Sub SaveForm1CarData(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        With TransactionData
            .SelectedCarId = carId
            .SelectedCarName = carName
            .DailyRate = dailyRate
            .VehicleType = vehicleType
            .SelectedVehicleId = vehicleId
        End With
    End Sub

    Public Sub SaveForm1MotorData(motorId As Integer, motorName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        With TransactionData
            .SelectedMotorId = motorId
            .SelectedMotorName = motorName
            .DailyRate = dailyRate
            .SelectedVehicleId = vehicleId
            .VehicleType = vehicleType
        End With
    End Sub

    Public Sub SaveForm2Data(pickupDate As String, pickupTime As String, returnDate As String, returnTime As String,
                         pickupPlace As String, returnPlace As String, isPickupAtStation As Boolean, isReturnAtStation As Boolean)
        Dim parsedPickupDate As Date
        Dim parsedReturnDate As Date

        ' Validate date formats
        If Not Date.TryParseExact(pickupDate, "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, parsedPickupDate) Then
            Throw New Exception("Invalid Pickup Date format.")
        End If
        If Not Date.TryParseExact(returnDate, "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, parsedReturnDate) Then
            Throw New Exception("Invalid Return Date format.")
        End If

        Dim pickupTimeParsed As DateTime = DateTime.ParseExact(pickupTime, "h:mm tt", Globalization.CultureInfo.InvariantCulture)
        Dim returnTimeParsed As DateTime = DateTime.ParseExact(returnTime, "h:mm tt", Globalization.CultureInfo.InvariantCulture)

        Dim pickupDateTime As DateTime = parsedPickupDate.Add(pickupTimeParsed.TimeOfDay)
        Dim returnDateTime As DateTime = parsedReturnDate.Add(returnTimeParsed.TimeOfDay)



        Dim rentalDays As Decimal = CDec((returnDateTime - pickupDateTime).TotalHours / 24D)
        If rentalDays < 1D Then rentalDays = 1D



        With TransactionData
            .PickupDate = parsedPickupDate
            .PickupTime = pickupTime
            .ReturnDate = parsedReturnDate
            .ReturnTime = returnTime
            .PickupPlace = pickupPlace
            .ReturnPlace = returnPlace
            .IsPickupAtStation = isPickupAtStation
            .IsReturnAtStation = isReturnAtStation
            .RentalDurationDays = rentalDays
            .TotalAmount = .DailyRate * .RentalDurationDays
        End With

    End Sub




    Public Function InsertRentalData() As Integer
        Try
            Dim cmd As New MySqlCommand("
                INSERT INTO rentals (
                    pickup_date, pickup_time, return_date, return_time, 
                    customer_id, vehicle_id, amount, rental_status_id, 
                    pickup_place, return_place
                ) VALUES (
                    @pickup_date, @pickup_time, @return_date, @return_time,
                    @customer_id, @vehicle_id, @amount, @rental_status_id,
                    @pickup_place, @return_place
                )", conn, transaction)

            With cmd.Parameters

                .AddWithValue("@pickup_date", TransactionData.PickupDate.ToString("yyyy-MM-dd"))
                .AddWithValue("@pickup_time", TransactionData.PickupTime)
                .AddWithValue("@return_date", TransactionData.ReturnDate.ToString("yyyy-MM-dd"))
                .AddWithValue("@return_time", TransactionData.ReturnTime)
                .AddWithValue("@customer_id", TransactionData.CustomerId)
                .AddWithValue("@vehicle_id", TransactionData.SelectedVehicleId)
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

    ' Get rental duration from database after insert (computed by trigger)
    Public Function GetRentalDurationFromDB(rentalId As Integer) As Integer
        Try
            Dim cmd As New MySqlCommand("SELECT rental_duration_days FROM rentals WHERE rental_id = @rental_id", conn, transaction)
            cmd.Parameters.AddWithValue("@rental_id", rentalId)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
            Return 1 ' Default value
        Catch ex As Exception
            Throw New Exception("Error getting rental duration: " & ex.Message)
        End Try
    End Function

    ' Validate transaction data
    Public Function ValidateTransactionData() As Boolean
        With TransactionData
            If .SelectedVehicleId <= 0 Then

                Return False
            End If

            If .CustomerId <= 0 Then
                MessageBox.Show("Login before proceeding.")
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

            If .RentalStatusId <= 0 Then
                MessageBox.Show("Rental status is required.")
                Return False
            End If
        End With

        Return True
    End Function

    Public Function GetCustomerIdForCurrentUser() As Integer
        Try
            Using conn = New MySqlConnection("Server=localhost;Database=ridexp;User=root;Password=;")
                conn.Open()
                Dim cmd = New MySqlCommand("SELECT customer_id FROM customers WHERE user_id = @uid LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@uid", Module1.userId)

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    Dim customerId = Convert.ToInt32(result)
                    Return customerId
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting customer ID: " & ex.Message)
        End Try

        Return 0
    End Function

    Public Sub SaveForm4PaymentData(method As String, status As String, reference As String)
        With TransactionData
            .PaymentMethod = method
            .PaymentStatus = status
            .PaymentReference = reference
        End With
    End Sub



End Module