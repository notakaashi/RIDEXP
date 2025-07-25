Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient
Public Class FORMRENTAL_STEP4
    Private Sub Label24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        FORM_PRIVACYPOLICY.Show()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        FORM_TERMSPOLICIES.Show()
    End Sub

    Private Sub FORMRENTAL_STEP4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vehicletxt.Text = TransactionData.SelectedCarName & " / " & TransactionData.SelectedMotorName
        rentalratetxt.Text = "₱" & TransactionData.TotalAmount.ToString("N2")
        renteddaystxt.Text = TransactionData.RentalDurationDays & " day(s)"

        ' Initial control state
        ToggleCardInputs(False)
        checkoutbtn.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            ToggleCardInputs(False)
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            ToggleCardInputs(True)
        End If
    End Sub

    Private Sub ToggleCardInputs(enabled As Boolean)
        TextBox1.Enabled = enabled
        TextBox2.Enabled = enabled
        TextBox3.Enabled = enabled
        TextBox4.Enabled = enabled
        TextBox5.Enabled = enabled
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ValidateCheckoutState()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ValidateCheckoutState()
    End Sub

    Private Sub ValidateCheckoutState()
        checkoutbtn.Enabled = CheckBox1.Checked AndAlso CheckBox2.Checked
    End Sub

    Private Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click

        Try
            Dim method = If(RadioButton1.Checked, "Cash", "Card")
            Dim reference = If(RadioButton3.Checked, TextBox1.Text, "Cash-Payment")

            RentalTransactionModule.SaveForm4PaymentData(method, "Paid", reference)

            Dim customerId = RentalTransactionModule.GetCustomerIdForCurrentUser()
            If customerId <= 0 Then
                MessageBox.Show("Unable to link rental to a customer record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Prepare and execute rental insertion
            Using conn = New MySqlConnection("Server=localhost;Database=ridexp;User=root;Password=;")
                conn.Open()
                Dim query = "
                INSERT INTO rentals
                (customer_id, vehicle_id, pickup_date, pickup_time, return_date, return_time, pickup_place, return_place, amount, rental_status_id)
                VALUES
                (@customer_id, @vehicle_id, @pdate, @ptime, @rdate, @rtime, @pplace, @rplace, @amount, 1)
            "
                Using cmd = New MySqlCommand(query, conn)
                    With cmd.Parameters
                        .AddWithValue("@customer_id", customerId)
                        .AddWithValue("@vehicle_id", RentalTransactionModule.TransactionData.SelectedVehicleId)
                        .AddWithValue("@pdate", RentalTransactionModule.TransactionData.PickupDate.Date)
                        .AddWithValue("@ptime", RentalTransactionModule.TransactionData.PickupTime)
                        .AddWithValue("@rdate", RentalTransactionModule.TransactionData.ReturnDate.Date)
                        .AddWithValue("@rtime", RentalTransactionModule.TransactionData.ReturnTime)
                        .AddWithValue("@pplace", RentalTransactionModule.TransactionData.PickupPlace)
                        .AddWithValue("@rplace", RentalTransactionModule.TransactionData.ReturnPlace)
                        .AddWithValue("@amount", RentalTransactionModule.TransactionData.TotalAmount)
                        .AddWithValue("@reference", reference)
                    End With
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If RentalTransactionModule.CommitTransaction() Then
                MessageBox.Show("Rental placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show($"Checkout failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Current userID: " & Module1.userId)

    End Sub
End Class