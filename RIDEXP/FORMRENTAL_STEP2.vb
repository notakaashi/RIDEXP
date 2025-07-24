Public Class FORMRENTAL_STEP2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ValidateForm() Then

            FORMRENTAL_STEP3.Show()

            Me.Close()
        End If

        If RentalTransactionModule.transaction Is Nothing Then
            If Not RentalTransactionModule.StartTransaction() Then
                MessageBox.Show("Failed to start transaction. Please try again.")
                Me.Close()
                Return
            End If
        End If

        ' Load any existing data (if coming back from next form)
        LoadExistingData()
    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub FORMRENTAL_STEP2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pickupbtn.Checked = True
        returnbtn.Checked = True

        pickuptxtbox.Enabled = False
        pickuptxtbox.Text = "Main Station - 123 Central Ave, Downtown"
        pickuptxtbox.BackColor = Color.LightGray

        returntxtbox.Enabled = False
        returntxtbox.Text = "Main Station - 123 Central Ave, Downtown"
        returntxtbox.BackColor = Color.LightGray
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
End Class