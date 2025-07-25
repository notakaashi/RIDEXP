Public Class FORMRENTAL_STEP2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If transaction Is Nothing Then
            If Not StartTransaction() Then
                MessageBox.Show("Failed to start transaction. Please try again.")
                Close()
                Return
            End If
        End If

        If ValidateForm() Then
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
        pickuptxtbox.Text = "Main Station - 123 Central Ave, Downtown"
        pickuptxtbox.BackColor = Color.LightGray

        returntxtbox.Enabled = False
        returntxtbox.Text = "Main Station - 123 Central Ave, Downtown"
        returntxtbox.BackColor = Color.LightGray

        pickupdatetxt.PlaceholderText = "YYYY-MM-DD"
        returndatetxt.PlaceholderText = "YYYY-MM-DD"
        LoadExistingData()

    End Sub



    Private Sub pickupbtn_CheckedChanged(sender As Object, e As EventArgs) Handles pickupbtn.CheckedChanged
        If pickupbtn.Checked Then
            pickuptxtbox.Enabled = False
            pickuptxtbox.Text = "Main Station - 123 Central Ave, Downtown"
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
            returntxtbox.Text = "Main Station - 123 Central Ave, Downtown"
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

        Return True
    End Function

    Private Sub SaveFormDataToModule()
        RentalTransactionModule.SaveForm2Data(
            pickupdatetxt.Text.Trim(),
            cbxPickup.SelectedItem.ToString(),
            returndatetxt.Text.Trim(),
            cbxReturn.SelectedItem.ToString(),
            pickuptxtbox.Text.Trim(),
            returntxtbox.Text.Trim(),
            pickupbtn.Checked,
            returnbtn.Checked
        )
    End Sub


    Private Sub LoadExistingData()
        With RentalTransactionModule.TransactionData
            If .PickupDate <> Nothing Then
                pickupdatetxt.Text = .PickupDate.ToString("yyyy-MM-dd")
            End If
            If .ReturnDate <> Nothing Then
                returndatetxt.Text = .ReturnDate.ToString("yyyy-MM-dd")
            End If
            If Not String.IsNullOrEmpty(.PickupTime) Then
                cbxPickup.SelectedItem = .PickupTime
            End If
            If Not String.IsNullOrEmpty(.ReturnTime) Then
                cbxReturn.SelectedItem = .ReturnDate
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


End Class