Public Class Logjn
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        SIGNUP.Show()
    End Sub

    Private Sub Logjn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnHOME.FlatAppearance.BorderSize = 0
        btnCONTACT.FlatAppearance.BorderSize = 0
        btnRENTALS.FlatAppearance.BorderSize = 0
    End Sub
End Class