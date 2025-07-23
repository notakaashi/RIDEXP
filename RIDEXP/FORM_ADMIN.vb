Public Class FORM_ADMIN
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub FORM_ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlDashboard.BackColor = Color.White
        lblDashboard.ForeColor = Color.DarkRed
        iconDashboard.Image = My.Resources.arrow_red
    End Sub

    Private Sub pnlInventory_Click(sender As Object, e As EventArgs) Handles pnlInventory.Click
        FORMADMIN_INVENTORY.Show()
        pnlAllDashboard.Visible = False
    End Sub

End Class