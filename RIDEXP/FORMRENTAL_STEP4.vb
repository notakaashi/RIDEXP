Public Class FORMRENTAL_STEP4
    Private Sub Label24_Click(sender As Object, e As EventArgs)
        ' Your logic here
    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        FORM_PRIVACYPOLICY.Show()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        FORM_TERMSPOLICIES.Show()
    End Sub
End Class