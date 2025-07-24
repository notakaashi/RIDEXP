Public Class allmotors
    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub


    Private Sub ShowOnlyPanel(targetPanel As Panel)

        pnlAllMotorContent.Location = New Point(1300, 190)
        pnlScooter.Location = New Point(1300, 190)
        pnlUnderbone.Location = New Point(1300, 190)
        pnlAdventure.Location = New Point(1300, 190)

        targetPanel.Location = New Point(35, 190)
        targetPanel.BringToFront()
    End Sub

    Private Sub ResetButtonStyles()
        Dim buttons As Button() = {btnAdventure, btnScooter, btnUnderbone}
        For Each btn In buttons
            btn.ForeColor = Color.Black
            btn.Font = New Font(btn.Font, FontStyle.Regular)
        Next
    End Sub

    Private Sub HighlightButton(clickedButton As Button)

        ResetButtonStyles()

        clickedButton.ForeColor = Color.FromArgb(192, 0, 0)
        clickedButton.Font = New Font(clickedButton.Font, FontStyle.Underline)
    End Sub

    Private Sub allmotors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowOnlyPanel(pnlAllMotorContent)
        Me.Opacity = 0
        FadeTimer.Start()
    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnScooter.Click
        ShowOnlyPanel(pnlScooter)
        HighlightButton(btnScooter)
    End Sub

    Private Sub btnUnderbone_Click(sender As Object, e As EventArgs) Handles btnUnderbone.Click
        ShowOnlyPanel(pnlUnderbone)
        HighlightButton(btnUnderbone)
    End Sub

    Private Sub btnAdventure_Click(sender As Object, e As EventArgs) Handles btnAdventure.Click
        ShowOnlyPanel(pnlAdventure)
        HighlightButton(btnAdventure)
    End Sub
End Class