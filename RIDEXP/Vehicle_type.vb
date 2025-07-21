Public Class Vehicle_type

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

End Class
