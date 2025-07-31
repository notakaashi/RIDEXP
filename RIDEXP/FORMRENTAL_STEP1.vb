Public Class FORMRENTAL_STEP1

    Private Sub FORMRENTAL_STEP1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Logged in as: " & userlogged)
        RefreshLoginState()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        allcars.Show()
        allcars.BringToFront()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FORM_ALLMOTORS.Show()
        FORM_ALLMOTORS.BringToFront()

    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

    Public Sub RefreshLoginState()
        PictureBox3.Visible = loggedin
        user.Text = userlogged
        user.Visible = loggedin
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loggedin = False
        user.Visible = False
        Panel6.Visible = False
        PictureBox3.Visible = False
        MsgBox("Logout successful! See you next time.", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Panel6.Visible = Not Panel6.Visible
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Logjn.Show()
    End Sub
End Class
