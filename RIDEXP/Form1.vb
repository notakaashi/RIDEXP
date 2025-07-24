Public Class Form1

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Logjn.Visible Then
            Logjn.Hide()
        Else
            Logjn.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshLoginState()
        pnlVehicleType.Visible = False

    End Sub


    Public Sub RefreshLoginState()
        PictureBox3.Visible = loggedin
        user.Text = userlogged
        user.Visible = loggedin
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

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Me.Show()
    End Sub

    Private Sub rentalslbl_Click(sender As Object, e As EventArgs) Handles rentalslbl.Click
        pnlVehicleType.Visible = True
        rentalslbl.ForeColor = Color.DarkRed
    End Sub
    Private Sub contactslbl_Click(sender As Object, e As EventArgs) Handles contactslbl.Click
        CONTACTUS.Show()
        contactslbl.ForeColor = Color.DarkRed
    End Sub

    Private Sub rentalslbl_MouseEnter(sender As Object, e As EventArgs) Handles rentalslbl.MouseEnter
        rentalslbl.BackColor = Color.LightGray
    End Sub

    Private Sub rentalslbl_MouseLeave(sender As Object, e As EventArgs) Handles rentalslbl.MouseLeave
        rentalslbl.BackColor = Color.Transparent
    End Sub

    Private Sub homelbl_MouseEnter(sender As Object, e As EventArgs) Handles homelbl.MouseEnter
        homelbl.BackColor = Color.LightGray
    End Sub

    Private Sub homelbl_MouseLeave(sender As Object, e As EventArgs) Handles homelbl.MouseLeave
        homelbl.BackColor = Color.Transparent
    End Sub

    Private Sub contactlbl_MouseEnter(sender As Object, e As EventArgs) Handles contactslbl.MouseEnter
        contactslbl.BackColor = Color.LightGray
    End Sub

    Private Sub contactlbl_MouseLeave(sender As Object, e As EventArgs) Handles contactslbl.MouseLeave
        contactslbl.BackColor = Color.Transparent
    End Sub
    Public Sub ResetRentalsLabelColor()
        rentalslbl.ForeColor = Color.Black
    End Sub
    Public Sub ResetContactLabelColor()
        contactslbl.ForeColor = Color.Black
    End Sub

    Public Sub ResetHomeLabelColor()
        homelbl.ForeColor = Color.Black
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FORMRENTAL_STEP2.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FORM_ADMIN.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FORMRENTAL_STEP1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCar.Click
        allcars.Show()
        btnCar.BackColor = Color.FromArgb(192, 0, 0)
        btnMotor.BackColor = Color.White
        btnCar.ForeColor = Color.White
        btnMotor.ForeColor = Color.Black
        pnlVehicleType.Visible = False
        ResetRentalsLabelColor()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnMotor.Click
        allmotors.Show()
        btnMotor.BackColor = Color.FromArgb(192, 0, 0)
        btnCar.BackColor = Color.White
        btnMotor.ForeColor = Color.White
        btnCar.ForeColor = Color.Black
        pnlVehicleType.Visible = False
        ResetRentalsLabelColor()
    End Sub
End Class
