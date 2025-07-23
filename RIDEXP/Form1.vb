Public Class Form1

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Logjn.Visible Then
            Logjn.Hide()
        Else
            Logjn.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnHOME.FlatStyle = FlatStyle.Flat
        btnHOME.FlatAppearance.BorderSize = 0
        btnCONTACT.FlatAppearance.BorderSize = 0
        btnRENTALS.FlatAppearance.BorderSize = 0
        btnHOME.BackColor = Color.Transparent

        RefreshLoginState()
    End Sub

    Private Sub btnHOME_Click(sender As Object, e As EventArgs) Handles btnHOME.Click
        Me.Show()
    End Sub

    Public Sub RefreshLoginState()
        PictureBox3.Visible = loggedin
        user.Text = userlogged
        user.Visible = loggedin
    End Sub

    Private Sub btnRENTALS_Click(sender As Object, e As EventArgs) Handles btnRENTALS.Click
        Vehicle_type.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Panel2.Visible = Not Panel2.Visible
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loggedin = False
        user.Visible = False
        Panel2.Visible = False
        PictureBox3.Visible = False
        MsgBox("Logout successful! See you next time.", MsgBoxStyle.Information, "Success")
    End Sub
End Class
