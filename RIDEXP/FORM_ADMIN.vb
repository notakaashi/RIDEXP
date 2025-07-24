Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class FORM_ADMIN

    Dim connStr As String = "server=localhost;user=root;password=;database=ridexp"
    Dim conn As New MySqlConnection(connStr)
    Private Sub FORM_ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClickDashboard()
        LoadTableRentals(dgvRentals)
        LoadTabNewUsers()
        cbVehicle.Items.Add("CARS")
        cbVehicle.Items.Add("MOTORCYCLES")
        cbVehicle.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVehicle.SelectedIndexChanged
        Dim selectedTable = cbVehicle.SelectedItem.ToString
        Dim query = ""

        If selectedTable = "CARS" Then
            query = "SELECT * FROM cars"
        ElseIf selectedTable = "MOTORCYCLES" Then
            query = "SELECT * FROM motors"
        Else
            Exit Sub
        End If

        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable
            adapter.Fill(table)
            dgvVehicles.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTableRentals(datagrid As DataGridView)
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM rentals"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            datagrid.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTabNewUsers()
        Try
            conn.Open()
            Dim query As String = "SELECT customer_id, concat(first_name, ' ', last_name) as full_name, email, created_at 
                                    FROM customers"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvNewUsers.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTabUsers()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM customers"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvAllUSERS.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTableSales()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM sales_report"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvSales.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTableMaintenance()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM maintenance"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvMaintenance.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
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
        LoadTableRentals(dgvRentals)
    End Sub

    Private Sub pnlInventory_Click(sender As Object, e As EventArgs) Handles pnlInventory.Click
        ClickInventory()
    End Sub

    Private Sub pnlRentals_Click(sender As Object, e As EventArgs) Handles pnlRentals.Click
        ClickRentals()
        LoadTableRentals(dgvRentals2)
    End Sub
    Private Sub pnlSales_Click(sender As Object, e As EventArgs) Handles pnlSales.Click
        ClickSales()
        LoadTableSales()
    End Sub
    Private Sub pnlMaintenance_Click(sender As Object, e As EventArgs) Handles pnlMaintenance.Click
        ClickMaintenance()
        LoadTableMaintenance()
    End Sub
    Private Sub pnlUsers_Click(sender As Object, e As EventArgs) Handles pnlUsers.Click
        ClickUsers()
        LoadTabUsers()
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form1.Show()
    End Sub

End Class