Imports MySql.Data.MySqlClient

Public Class FORM_SEDAN
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FadeTimer_tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub SUVFORMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        FadeTimer.Start()
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FORM_MPV.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FORM_SUV.Show()
        Me.Close()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FORM_HATCHBACK.Show()
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Not StartTransaction Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close
            Return
        End If
        SelectCar(1, "Toyota Vios", 2500, "Car")
    End Sub

    Private Sub SelectCar(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String)
        Try
            If RentalTransactionModule.transaction Is Nothing Then
                MessageBox.Show("Transaction is null in SelectCar!")
                Return
            End If

            RentalTransactionModule.SaveForm1Data(carId, carName, dailyRate, vehicleType)

            MessageBox.Show("Car data saved: " & carName)

            Dim step2Form As New FORMRENTAL_STEP2()
            step2Form.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error in SelectCar: " & ex.Message)
        End Try
    End Sub

    Public Sub SaveForm2Data(pickupDate As Date, pickupTime As String, returnDate As Date, returnTime As String,
                          pickupPlace As String, returnPlace As String, isPickupAtStation As Boolean, isReturnAtStation As Boolean)
        With TransactionData
            .PickupDate = pickupDate
            .PickupTime = pickupTime
            .ReturnDate = returnDate
            .ReturnTime = returnTime
            .RentalDurationDays = CInt((returnDate - pickupDate).TotalDays)
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
                .AddWithValue("@pickup_date", TransactionData.PickupDate)
                .AddWithValue("@pickup_time", TransactionData.PickupTime)
                .AddWithValue("@return_date", TransactionData.ReturnDate)
                .AddWithValue("@return_time", TransactionData.ReturnTime)
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

    Public Sub SaveForm1Data(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String)
        With TransactionData
            .SelectedCarId = carId
            .SelectedCarName = carName
            .DailyRate = dailyRate

        End With
    End Sub
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

    Private Sub Button10_Click(sender As Object, e As EventArgs)

    End Sub
End Class