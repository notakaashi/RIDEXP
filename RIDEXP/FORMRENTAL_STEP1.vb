Public Class FORMRENTAL_STEP1

    Private Sub FORMRENTAL_STEP1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' You can initialize stuff here if needed
    End Sub

    ' Button: Go to All Cars
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Show All Cars
        allcars.Show()
        allcars.BringToFront()

    End Sub

    ' Button: Go to All Motors
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Show All Motors
        FORM_ALLMOTORS.Show()
        FORM_ALLMOTORS.BringToFront()

    End Sub

    ' Home label: Go back to main Form1
    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

End Class
