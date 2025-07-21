Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Logjn.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnHOME.FlatStyle = FlatStyle.Flat
        btnHOME.FlatAppearance.BorderSize = 0
        btnCONTACT.FlatAppearance.BorderSize = 0
        btnRENTALS.FlatAppearance.BorderSize = 0
        btnHOME.BackColor = Color.Transparent
    End Sub

    Private Sub btnHOME_Click(sender As Object, e As EventArgs) Handles btnHOME.Click
        Me.Show()
    End Sub
End Class
