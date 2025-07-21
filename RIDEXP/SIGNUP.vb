Public Class SIGNUP


    Private Sub SIGNUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeTimer.Start()
    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            FadeTimer.Stop()
        End If
    End Sub


    Private Sub btnHOME_Click(sender As Object, e As EventArgs)
        Form1.Show()
        Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Me.Opacity = 0
    End Sub
End Class