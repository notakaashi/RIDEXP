Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class FORMRENTAL_STEP4
    Private Sub Label24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Try
            ' Ask for confirmation before cancelling
            If MessageBox.Show("Are you sure you want to cancel this booking? All data will be lost.",
                              "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' Rollback transaction
                RentalTransactionModule.RollbackTransaction()

                ' Go to home
                Form1.Show()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error cancelling booking: " & ex.Message)
        End Try
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        FORM_PRIVACYPOLICY.Show()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        FORM_TERMSPOLICIES.Show()
    End Sub

    Private Sub FORMRENTAL_STEP4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim td = RentalTransactionModule.TransactionData

        ' Recalculate fractional days just in case
        Dim pickupDateTime As DateTime = td.PickupDate.Add(DateTime.Parse(td.PickupTime).TimeOfDay)
        Dim returnDateTime As DateTime = td.ReturnDate.Add(DateTime.Parse(td.ReturnTime).TimeOfDay)

        td.RentalDurationDays = CDec((returnDateTime - pickupDateTime).TotalHours / 24)
        If td.RentalDurationDays < 1D Then td.RentalDurationDays = 1D
        td.TotalAmount = td.DailyRate * td.RentalDurationDays

        ' Display vehicle name
        If Not String.IsNullOrEmpty(td.SelectedCarName) Then
            vehicletxt.Text = td.SelectedCarName
        ElseIf Not String.IsNullOrEmpty(td.SelectedMotorName) Then
            vehicletxt.Text = td.SelectedMotorName
        Else
            vehicletxt.Text = "No vehicle selected"
        End If

        totalrentalratetxt.Text = "₱" & td.TotalAmount.ToString("N2")
        renteddaystxt.Text = td.RentalDurationDays & " day(s)"
        rentalratetxt.Text = "₱" & td.DailyRate.ToString("N2")

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
            If Not ValidatePaymentForm() Then
                Return
            End If

            Dim paymentMethod As String = If(RadioButton1.Checked, "Cash", "Card")
            Dim paymentReference As String = If(RadioButton3.Checked, TextBox1.Text, "CASH-" & DateTime.Now.ToString("yyyyMMddHHmmss"))

            With RentalTransactionModule.TransactionData
                .PaymentMethod = paymentMethod
                .PaymentStatus = "Paid"
                .PaymentReference = paymentReference
                .CustomerConfirmed = True

                If .CustomerId <= 0 Then
                    .CustomerId = RentalTransactionModule.GetCustomerIdForCurrentUser()
                    If .CustomerId <= 0 Then
                        MessageBox.Show("Unable to identify customer. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If

                .RentalStatusId = 1
            End With


            If Not RentalTransactionModule.ValidateTransactionData() Then
                Return
            End If

            ' Use the transaction module to insert data
            Dim rentalId As Integer = RentalTransactionModule.InsertRentalData()

            If rentalId > 0 Then
                InsertPaymentRecord(rentalId)
                InsertInitialChecklist(rentalId)
                UpdateVehicleStatus()

                ' 🔹 Insert the sales report record
                InsertSalesReportRecord(rentalId)

                GenerateRideExpressInvoice(rentalId)

                If RentalTransactionModule.CommitTransaction() Then
                    MessageBox.Show("Rental placed successfully!" & vbCrLf & "Rental ID: " & rentalId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    RentalTransactionModule.ClearTransactionData()

                    Dim transacCompleteForm As New TRANSAC_COMPLETE()
                    transacCompleteForm.RentalId = rentalId
                    transacCompleteForm.Show()
                    Me.Close()
                Else
                    MessageBox.Show("Failed to complete the rental transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Failed to create rental record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RentalTransactionModule.RollbackTransaction()
            End If

        Catch ex As Exception
            MessageBox.Show($"Checkout failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RentalTransactionModule.RollbackTransaction()
        End Try
    End Sub

    Private Function ValidatePaymentForm() As Boolean
        If Not RadioButton1.Checked AndAlso Not RadioButton3.Checked Then
            MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If RadioButton3.Checked Then
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse TextBox1.Text.Length < 16 Then
                MessageBox.Show("Please enter a valid card number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Please enter cardholder name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse TextBox3.Text.Length < 3 Then
                MessageBox.Show("Please enter a valid expiry date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(TextBox4.Text) OrElse TextBox4.Text.Length < 3 Then
                MessageBox.Show("Please enter a valid CVV.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox4.Focus()
                Return False
            End If
        End If

        If Not CheckBox1.Checked OrElse Not CheckBox2.Checked Then
            MessageBox.Show("Please accept the terms and conditions and privacy policy.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function GetCurrentCustomerId() As Integer
        Return RentalTransactionModule.GetCustomerIdForCurrentUser()
    End Function

    Private Sub InsertPaymentRecord(rentalId As Integer)
        Try
            Dim paymentQuery As String = "
                INSERT INTO payment (rental_id, amount, payment_status_id, method_id, paid_at)
                VALUES (@rental_id, @amount, @status_id, @method_id, NOW())
            "

            Using cmd As New MySqlCommand(paymentQuery, RentalTransactionModule.conn, RentalTransactionModule.transaction)
                With cmd.Parameters
                    .AddWithValue("@rental_id", rentalId)
                    .AddWithValue("@amount", RentalTransactionModule.TransactionData.TotalAmount)
                    .AddWithValue("@status_id", 1) ' 1 = Paid
                    .AddWithValue("@method_id", If(RentalTransactionModule.TransactionData.PaymentMethod = "Cash", 1, 2)) ' 1 = Cash, 2 = Card   
                End With
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error inserting payment record: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertInitialChecklist(rentalId As Integer)
        Try
            Dim checklistQuery As String = "
                INSERT INTO checklist (rental_id, inspection_date, inspection_type_id, windows_condition, 
                                     tires_condition, lights_condition, engine_condition, notes, vehicle_id)
                VALUES (@rental_id, NOW(), 1, 1, 1, 1, 1, 
                       'Initial inspection before rental', @vehicle_id)
            "

            Using cmd As New MySqlCommand(checklistQuery, RentalTransactionModule.conn, RentalTransactionModule.transaction)
                With cmd.Parameters
                    .AddWithValue("@rental_id", rentalId)
                    .AddWithValue("@vehicle_id", RentalTransactionModule.TransactionData.SelectedVehicleId)
                End With
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error inserting checklist: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateVehicleStatus()
        Try
            Dim updateQuery As String = "UPDATE vehicles SET status_id = 2 WHERE vehicle_id = @vehicle_id"

            Using cmd As New MySqlCommand(updateQuery, RentalTransactionModule.conn, RentalTransactionModule.transaction)
                cmd.Parameters.AddWithValue("@vehicle_id", RentalTransactionModule.TransactionData.SelectedVehicleId)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error updating vehicle status: " & ex.Message)
        End Try
    End Sub
    Private Sub InsertSalesReportRecord(rentalId As Integer)
        Try
            Dim query As String = "
            INSERT INTO sales_report (report_date, earnings, rental_id, penalties, generated_by)
            VALUES (CURDATE(), @earnings, @rental_id, 0, @generated_by)
        "

            Using cmd As New MySqlCommand(query, RentalTransactionModule.conn, RentalTransactionModule.transaction)
                With cmd.Parameters
                    .AddWithValue("@earnings", RentalTransactionModule.TransactionData.TotalAmount)
                    .AddWithValue("@rental_id", rentalId)
                    .AddWithValue("@generated_by", RentalTransactionModule.TransactionData.CustomerId)
                End With
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception("Error inserting sales report record: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub



End Class