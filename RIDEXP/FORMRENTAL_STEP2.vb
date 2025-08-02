Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class FORMRENTAL_STEP2


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If transaction Is Nothing Then
            If Not StartTransaction() Then
                MessageBox.Show("Failed to start transaction. Please try again.")
                Close()
                Return
            End If
        End If

        If returndated.Value.Date <= pickupdate.Value.Date Then
            MessageBox.Show("Return date must be AFTER the pickup date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If ValidateForm() Then
            Dim vehicleId As Integer = RentalTransactionModule.TransactionData.SelectedVehicleId

            If Not IsVehicleAvailable(vehicleId, pickupdate.Value, returndated.Value) Then
                Dim unavailableUntil = GetVehicleUnavailableUntil(vehicleId, pickupdate.Value, returndated.Value)
                If unavailableUntil.HasValue Then
                    MessageBox.Show("This vehicle is not available. It will be free after " & unavailableUntil.Value.ToString("yyyy-MM-dd"), "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("This vehicle is currently unavailable or under maintenance.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return
            End If

            SaveFormDataToModule()
            FORMRENTAL_STEP3.Show()
            Close()
        End If

    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub FORMRENTAL_STEP2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshLoginState()
        If RentalTransactionModule.transaction Is Nothing Then
            MessageBox.Show("No active transaction found. Returning to car/motor selection.")
            Dim step1Form As New FORMRENTAL_STEP1()
            step1Form.Show()
            Me.Close()
            Return
        End If

        pickupbtn.Checked = True
        returnbtn.Checked = True

        pickuptxtbox.Enabled = False
        pickuptxtbox.Text = "RDXP Ave, Taguig City"
        pickuptxtbox.BackColor = Color.LightGray

        returntxtbox.Enabled = False
        returntxtbox.Text = "RDXP Ave, Taguig City"
        returntxtbox.BackColor = Color.LightGray

        LoadExistingData()

    End Sub



    Private Sub pickupbtn_CheckedChanged(sender As Object, e As EventArgs) Handles pickupbtn.CheckedChanged
        If pickupbtn.Checked Then
            pickuptxtbox.Enabled = False
            pickuptxtbox.Text = "RDXP Ave, Taguig City"
            pickuptxtbox.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub deliverbtn_CheckedChanged(sender As Object, e As EventArgs) Handles deliverbtn.CheckedChanged
        If deliverbtn.Checked Then
            pickuptxtbox.Enabled = True
            pickuptxtbox.Text = ""
            pickuptxtbox.BackColor = Color.White
            pickuptxtbox.Focus()
        End If
    End Sub

    Private Sub returnbtn_CheckedChanged(sender As Object, e As EventArgs) Handles returnbtn.CheckedChanged
        If returnbtn.Checked Then
            returntxtbox.Enabled = False
            returntxtbox.Text = "RDXP Ave, Taguig City"
            returntxtbox.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub collectbtn_CheckedChanged(sender As Object, e As EventArgs) Handles collectbtn.CheckedChanged
        If collectbtn.Checked Then
            returntxtbox.Enabled = True
            returntxtbox.Text = ""
            returntxtbox.BackColor = Color.White
            returntxtbox.Focus()
        End If
    End Sub
    Public Function ValidateForm() As Boolean

        If deliverbtn.Checked AndAlso String.IsNullOrWhiteSpace(pickuptxtbox.Text) Then
            MessageBox.Show("Please enter a delivery address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pickuptxtbox.Focus()
            Return False
        End If

        If collectbtn.Checked AndAlso String.IsNullOrWhiteSpace(returntxtbox.Text) Then
            MessageBox.Show("Please enter a collection address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            returntxtbox.Focus()
            Return False
        End If

        If cbxPickup.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a pickup time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxPickup.Focus()
            Return False
        End If

        If cbxReturn.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a return time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbxReturn.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SaveFormDataToModule()
        Dim pickup As String = pickupdate.Value.ToString("yyyy-MM-dd")
        Dim returnDate As String = returndated.Value.ToString("yyyy-MM-dd")

        Dim pickupTimeStr As String = cbxPickup.SelectedItem.ToString()
        Dim returnTimeStr As String = cbxReturn.SelectedItem.ToString()

        If String.IsNullOrWhiteSpace(pickupTimeStr) OrElse String.IsNullOrWhiteSpace(returnTimeStr) Then
            MessageBox.Show("Please select valid pickup and return times.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        RentalTransactionModule.SaveForm2Data(
        pickup,
        pickupTimeStr,
        returnDate,
        returnTimeStr,
        pickuptxtbox.Text.Trim(),
        returntxtbox.Text.Trim(),
        pickupbtn.Checked,
        returnbtn.Checked
    )
    End Sub




    Private Sub LoadExistingData()
        With RentalTransactionModule.TransactionData
            If .PickupDate <> Date.MinValue Then
                pickupdate.Text = .PickupDate.ToString("yyyy-MM-dd")
            End If

            If .ReturnDate <> Date.MinValue Then
                returndated.Text = .ReturnDate.ToString("yyyy-MM-dd")
            End If
            If Not String.IsNullOrEmpty(.PickupTime) Then
                cbxPickup.SelectedItem = .PickupTime
            End If
            If Not String.IsNullOrEmpty(.ReturnTime) Then
                cbxReturn.SelectedItem = .ReturnTime
            End If

            If Not String.IsNullOrEmpty(.PickupPlace) Then
                If .IsPickupAtStation Then
                    pickupbtn.Checked = True
                Else
                    deliverbtn.Checked = True
                    pickuptxtbox.Text = .PickupPlace
                End If
            End If

            If Not String.IsNullOrEmpty(.ReturnPlace) Then
                If .IsReturnAtStation Then
                    returnbtn.Checked = True
                Else
                    collectbtn.Checked = True
                    returntxtbox.Text = .ReturnPlace
                End If
            End If
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(
       "Going back will discard all progress. Do you want to continue?",
       "Confirm Navigation",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning
   )

        If result = DialogResult.Yes Then
            RentalTransactionModule.RollbackTransaction()
            RentalTransactionModule.ClearTransactionData()

            FORMRENTAL_STEP1.Show()
            Me.Close()
        End If
    End Sub

    Private Function IsVehicleAvailable(vehicleId As Integer, pickup As Date, returnDate As Date) As Boolean
        Dim rentalQuery As String = "
        SELECT COUNT(*) FROM rentals 
        WHERE vehicle_id = @vehicle_id 
          AND rental_status_id = 1
          AND pickup_date <= @return_date
          AND (return_date IS NULL OR return_date >= @pickup_date)
    "
        Using cmd As New MySqlCommand(rentalQuery, RentalTransactionModule.conn, RentalTransactionModule.transaction)
            cmd.Parameters.AddWithValue("@vehicle_id", vehicleId)
            cmd.Parameters.AddWithValue("@pickup_date", pickup.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@return_date", returnDate.ToString("yyyy-MM-dd"))
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count = 0
        End Using
    End Function


    Private Function GetVehicleUnavailableUntil(vehicleId As Integer, pickup As Date, returnDate As Date) As Date?
        Dim query As String = "
        SELECT MAX(return_date) FROM rentals 
        WHERE vehicle_id = @vehicle_id 
          AND rental_status_id = 1
          AND pickup_date <= @return_date
          AND (return_date IS NULL OR return_date >= @pickup_date)
    "
        Using cmd As New MySqlCommand(query, RentalTransactionModule.conn, RentalTransactionModule.transaction)
            cmd.Parameters.AddWithValue("@vehicle_id", vehicleId)
            cmd.Parameters.AddWithValue("@pickup_date", pickup.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@return_date", returnDate.ToString("yyyy-MM-dd"))
            Dim result = cmd.ExecuteScalar()
            If result Is DBNull.Value OrElse result Is Nothing Then
                Return Nothing
            End If
            Return Convert.ToDateTime(result)
        End Using
    End Function
    Public Sub RefreshLoginState()
        PictureBox3.Visible = loggedin
        user.Text = userlogged
        user.Visible = loggedin
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loggedin = False
        user.Visible = False
        Panel7.Visible = False
        PictureBox3.Visible = False
        MsgBox("Logout successful! See you next time.", MsgBoxStyle.Information, "Success")
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Panel7.Visible = Not Panel7.Visible
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Logjn.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Panel2.Visible = Not Panel2.Visible
    End Sub
End Class