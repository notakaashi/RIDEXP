Public Class allcars
    Private Sub allcars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlAllCarsContent.BringToFront()
        pnlAllCarsContent.Location = New Point(54, 185)
        Me.Opacity = 0
        FadeTimer.Start()

    End Sub

    Private Sub ShowOnlyPanel(targetPanel As Panel)
        pnlAllCarsContent.Location = New Point(1300, 167)
        pnlSuvContent.Location = New Point(1300, 167)
        pnlSedan.Location = New Point(1300, 167)
        pnlMpv.Location = New Point(1300, 167)
        pnlHatchback.Location = New Point(1300, 167)
        pnlHybrid.Location = New Point(1300, 167)

        targetPanel.Location = New Point(54, 185)
        targetPanel.BringToFront()
    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub btnSuv_Click(sender As Object, e As EventArgs) Handles btnSuv.Click
        ShowOnlyPanel(pnlSuvContent)
    End Sub

    Private Sub btnSedan_Click(sender As Object, e As EventArgs) Handles btnSedan.Click
        ShowOnlyPanel(pnlSedan)
    End Sub

    Private Sub btnMPV_Click(sender As Object, e As EventArgs) Handles btnMPV.Click
        ShowOnlyPanel(pnlMpv)
    End Sub

    Private Sub btnHatch_Click(sender As Object, e As EventArgs) Handles btnHatch.Click
        ShowOnlyPanel(pnlHatchback)
    End Sub

    Private Sub btnHybrid_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        ShowOnlyPanel(pnlHybrid)
    End Sub


End Class