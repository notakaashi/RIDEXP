Public Class Logjn

    Private Sub Logjn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeTimer.Start()
    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            FadeTimer.Stop()
        End If
    End Sub


    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SIGNUP.Show()
        Me.Close()
        Me.Opacity = 0
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class