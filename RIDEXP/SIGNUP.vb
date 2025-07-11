Public Class SIGNUP
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub SIGNUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnHOME.FlatAppearance.BorderSize = 0
        btnCONTACT.FlatAppearance.BorderSize = 0
        btnRENTALS.FlatAppearance.BorderSize = 0
    End Sub
End Class