Public Class FORM_SPORTSMOTOR
    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub FORM_SPORTSMOTOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        FadeTimer.Start()
    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FORM_SCOOTER.Show()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FORM_UNDERBONE.Show()
        Me.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FORM_ADVENTUREBIKE.Show()
        Me.Close()
    End Sub
End Class