Public Class FORM_ADMIN
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ResetAllPanels()

        pnlAllDashboard.Location = New Point(1300, 81)
        pnlcarinventory.Location = New Point(1300, 81)
        pnlRentalContent.Location = New Point(1300, 81)
        pnlSaleContent.Location = New Point(1300, 81)
        pnlMaintenanceContent.Location = New Point(1300, 81)
        pnlUsersContent.Location = New Point(1300, 81)

        Dim navPanels() As Panel = {pnlDashboard, pnlInventory, pnlRentals, pnlSales, pnlMaintenance, pnlUsers}
        Dim navLabels() As Label = {lblDashboard, lblInventory, lblRentals, lblSales, lblMaintenance, lblUsers}
        Dim navIcons() As PictureBox = {iconDashboard, iconInventory, iconRentals, iconSales, iconMaintenance, iconUsers}

        For i As Integer = 0 To navPanels.Length - 1
            navPanels(i).BackColor = Color.FromArgb(192, 0, 0)
            navLabels(i).ForeColor = Color.White
            navIcons(i).Image = My.Resources.arrow_white
        Next
    End Sub

    Private Sub ClickDashboard()
        ResetAllPanels()
        pnlAllDashboard.Location = New Point(301, 97)
        pnlDashboard.BackColor = Color.White
        lblDashboard.ForeColor = Color.DarkRed
        iconDashboard.Image = My.Resources.arrow_red
    End Sub

    Private Sub ClickInventory()
        ResetAllPanels()
        pnlcarinventory.Location = New Point(301, 97)
        pnlInventory.BackColor = Color.White
        lblInventory.ForeColor = Color.DarkRed
        iconInventory.Image = My.Resources.arrow_red
    End Sub

    Private Sub ClickRentals()
        ResetAllPanels()
        pnlRentalContent.Location = New Point(301, 97)
        pnlRentals.BackColor = Color.White
        lblRentals.ForeColor = Color.DarkRed
        iconRentals.Image = My.Resources.arrow_red
    End Sub

    Private Sub ClickSales()
        ResetAllPanels()
        pnlSaleContent.Location = New Point(301, 97)
        pnlSales.BackColor = Color.White
        lblSales.ForeColor = Color.DarkRed
        iconSales.Image = My.Resources.arrow_red
    End Sub

    Private Sub ClickMaintenance()
        ResetAllPanels()
        pnlMaintenanceContent.Location = New Point(301, 97)
        pnlMaintenance.BackColor = Color.White
        lblMaintenance.ForeColor = Color.DarkRed
        iconMaintenance.Image = My.Resources.arrow_red
    End Sub

    Private Sub ClickUsers()
        ResetAllPanels()
        pnlUsersContent.Location = New Point(301, 97)
        pnlUsers.BackColor = Color.White
        lblUsers.ForeColor = Color.DarkRed
        iconUsers.Image = My.Resources.arrow_red
    End Sub


    Private Sub pnlDashboard_Click(sender As Object, e As EventArgs) Handles pnlDashboard.Click
        ClickDashboard()
    End Sub

    Private Sub pnlInventory_Click(sender As Object, e As EventArgs) Handles pnlInventory.Click
        ClickInventory()
    End Sub

    Private Sub pnlRentals_Click(sender As Object, e As EventArgs) Handles pnlRentals.Click
        ClickRentals()
    End Sub
    Private Sub pnlSales_Click(sender As Object, e As EventArgs) Handles pnlSales.Click
        ClickSales()
    End Sub
    Private Sub pnlMaintenance_Click(sender As Object, e As EventArgs) Handles pnlMaintenance.Click
        ClickMaintenance()
    End Sub
    Private Sub pnlUsers_Click(sender As Object, e As EventArgs) Handles pnlUsers.Click
        ClickUsers()
    End Sub

    Private Sub FORM_ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClickDashboard()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class