Public Class FORMRENTAL_STEP2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FORMRENTAL_STEP3.Show()
        Me.Close()

    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class