Public Class Vehicle_type
    Private Sub Vehicle_type_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.ResetRentalsLabelColor()
    End Sub
    Private Sub Vehicle_type_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Opacity = 0
        FadeTimer.Start()
    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        allcars.Show()
        Me.Close()

    End Sub

    Private Sub Vehicle_type_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        allmotors.Show()
        Me.Close()
    End Sub
End Class
