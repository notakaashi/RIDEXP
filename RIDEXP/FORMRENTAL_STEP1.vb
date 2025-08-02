Public Class FORMRENTAL_STEP1

    Private Sub FORMRENTAL_STEP1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub PictureBo3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Panel6.Visible = Not Panel6.Visible
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Logjn.Show()
    End Sub

    Private Sub contactslbl_Click(sender As Object, e As EventArgs) Handles contactslbl.Click
        contactslbl.ForeColor = Color.DarkRed
        pnlContactUs.Visible = True
    End Sub
    Private Sub contactlbl_MouseEnter(sender As Object, e As EventArgs) Handles contactslbl.MouseEnter
        contactslbl.BackColor = Color.LightGray
    End Sub

    Private Sub contactlbl_MouseLeave(sender As Object, e As EventArgs) Handles contactslbl.MouseLeave
        contactslbl.BackColor = Color.Transparent
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        pnlContactUs.Visible = False
        contactslbl.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Panel2.Visible = Not Panel2.Visible
    End Sub
End Class
