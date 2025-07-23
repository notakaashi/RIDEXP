Public Class FORM_SUV


    Private Sub FadeTimer_tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub SUVFORMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        FadeTimer.Start()
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FORM_SEDAN.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FORM_MPV.Show()
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FORM_HATCHBACK.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FORM_HYBRID.Show()
        Me.Close()
    End Sub
End Class