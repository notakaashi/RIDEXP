Public Class allcars
    Private Sub allcars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSedan.FlatAppearance.BorderSize = 0
        btnSuv.FlatAppearance.BorderSize = 0
        btnMPV.FlatAppearance.BorderSize = 0
        btnHatch.FlatAppearance.BorderSize = 0
        btnHybrid.FlatAppearance.BorderSize = 0
        Me.Opacity = 0
        FadeTimer.Start()

    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSuv.Click
        FORM_SUV.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSedan.Click
        FORM_SEDAN.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnMPV.Click
        FORM_MPV.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnHatch.Click
        FORM_HATCHBACK.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        FORM_HYBRID.Show()
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class