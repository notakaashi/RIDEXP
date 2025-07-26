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
        cbVehicle.Items.Add("ALL")
        cbVehicle.SelectedIndex = 0
        LoadTotalRentals(lblDashRentals)
        LoadTotalUsers(lblDashUsers)
        LoadTotalIncome(lblDashIncome)
        LoadTotalAvailableCars(lblDashAvailableCars)
        txtbxRental.PlaceholderText = "Search Rental ID"
        txtbxSales.PlaceholderText = "Search Report ID"
        txtbxInventory.PlaceholderText = "Search Vehicle ID"
        txtbxMaintenance.PlaceholderText = "Search Maintenance ID"
        txtbxUsers.PlaceholderText = "Search User ID"

    End Sub

    Private Sub LoadTotalCompletedRentals(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(rental_id) AS total_completed FROM rentals WHERE rental_status_id = 2"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total completed rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalCancelledRentals(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(rental_id) AS total_cancelled FROM rentals WHERE rental_status_id = 3"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total canceled rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub LoadTotalEarnings(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT SUM(earnings) AS total_earnings FROM sales_report"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString("N2")
                Else
                    lblPlaceholder.Text = "0.00"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total earnings: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalPenalties(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT SUM(penalties) AS total_penalties FROM sales_report"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString("N2")
                Else
                    lblPlaceholder.Text = "0.00"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total penalties: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalCost(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT SUM(cost) AS total_cost FROM maintenance"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString("N2")
                Else
                    lblPlaceholder.Text = "0.00"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total penalties: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalPaid(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(penalty_id) AS total_paid FROM penalty WHERE is_paid = 1"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total paid rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub LoadTotalUnpaid(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(penalty_id) AS total_unpaid FROM penalty WHERE is_paid = 0"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total unpaid rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub LoadTotalOngoing(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(maintenance_id) AS total_ongoing FROM maintenance WHERE maintenance_status_id = 2"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total ongoing rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalCompleted(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(maintenance_id) AS total_completed FROM maintenance WHERE maintenance_status_id = 3"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total ongoing rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalScheduled(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(maintenance_id) AS total_scheduled FROM maintenance WHERE maintenance_status_id = 3"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total ongoing rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalDamaged(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(vehicle_id) AS total_damaged FROM vehicles WHERE status_id = 6"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total damaged vehicles: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalMaintenance(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(vehicle_id) AS total_maintenance FROM vehicles where status_id = 3"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total maintenance: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalAvailableCars(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(vehicle_id) AS total_cars FROM vehicles WHERE status_id = 1"
            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total available cars: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalIncome(lblPlaceholder As Label)
        Dim earnings As Integer = 0
        Dim maintenance_cost As Integer = 0
        Dim total_income As Integer = 0

        Try
            conn.Open()

            Dim query1 As String = "SELECT SUM(earnings) AS total_earnings FROM sales_report"
            Using cmd1 As New MySqlCommand(query1, conn)
                Dim result1 = cmd1.ExecuteScalar()
                If result1 IsNot Nothing AndAlso Not IsDBNull(result1) Then
                    earnings = Convert.ToInt32(result1)
                End If
            End Using

            Dim query2 As String = "SELECT SUM(cost) AS total_cost FROM maintenance"
            Using cmd2 As New MySqlCommand(query2, conn)
                Dim result2 = cmd2.ExecuteScalar()
                If result2 IsNot Nothing AndAlso Not IsDBNull(result2) Then
                    maintenance_cost = Convert.ToInt32(result2)
                End If
            End Using

            total_income = earnings - maintenance_cost
            If total_income < 0 Then total_income = 0

            lblPlaceholder.Text = total_income.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error loading total income: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub LoadTotalUsers(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(customer_id) AS total_users FROM customers"

            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading total rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTotalRentals(lblPlaceholder As Label)
        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(rental_id) AS total_rentals FROM rentals"

            Using cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    lblPlaceholder.Text = result.ToString()
                Else
                    lblPlaceholder.Text = "0"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading total rentals: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVehicle.SelectedIndexChanged
        Dim selectedTable = cbVehicle.SelectedItem.ToString
        Dim query = ""

        If selectedTable = "CARS" Then
            query = "SELECT * FROM cars"
        ElseIf selectedTable = "MOTORCYCLES" Then
            query = "SELECT * FROM motors"
        ElseIf selectedTable = "ALL" Then
            query = "SELECT  v.vehicle_id,
                    v.vehicle_type,
                    v.status_id,
                    CASE WHEN v.vehicle_type = 'car' THEN c.make ELSE m.make END AS make,
                    CASE WHEN v.vehicle_type = 'car' THEN c.model_name ELSE m.model END AS model_name,
                    CASE WHEN v.vehicle_type = 'car' THEN c.year ELSE m.year END AS year,
                    CASE WHEN v.vehicle_type = 'car' THEN c.license_plate ELSE m.license_plate END AS license_plate,
                    CASE WHEN v.vehicle_type = 'car' THEN c.color ELSE m.color END AS color,
                    CASE WHEN v.vehicle_type = 'car' THEN c.mileage ELSE m.mileage END AS mileage
                    FROM vehicles v
                    LEFT JOIN cars c 
                        ON v.vehicle_type = 'car' AND v.item_id = c.car_id
                    LEFT JOIN motors m 
                        ON v.vehicle_type = 'motor' AND v.item_id = m.motor_id;"
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
        LoadTotalRentals(lblDashRentals)
        LoadTotalUsers(lblDashUsers)
        LoadTotalIncome(lblDashIncome)
        LoadTotalAvailableCars(lblDashAvailableCars)
    End Sub

    Private Sub pnlInventory_Click(sender As Object, e As EventArgs) Handles pnlInventory.Click
        ClickInventory()
        LoadTotalRentals(lblInventoryRentals)
        LoadTotalAvailableCars(lblInventoryAvailable)
        LoadTotalMaintenance(lblInventoryMaintenance)
        LoadTotalDamaged(lblInventoryDamaged)
    End Sub

    Private Sub pnlRentals_Click(sender As Object, e As EventArgs) Handles pnlRentals.Click
        ClickRentals()
        LoadTableRentals(dgvRentals2)
        LoadTotalRentals(lblRentalRentals)
        LoadTotalCompleted(lblRentalCompleted)
        LoadTotalCancelledRentals(lblRentalCancelled)
    End Sub
    Private Sub pnlSales_Click(sender As Object, e As EventArgs) Handles pnlSales.Click
        ClickSales()
        LoadTableSales()
        LoadTotalEarnings(lblSalesEarnings)
        LoadTotalPenalties(lblSalesPenalties)
        LoadTotalCost(lblSalesCost)
        LoadTotalIncome(lblSalesIncome)
    End Sub
    Private Sub pnlMaintenance_Click(sender As Object, e As EventArgs) Handles pnlMaintenance.Click
        ClickMaintenance()
        LoadTableMaintenance()
        LoadTotalDamaged(lblMaintenanceDamaged)
        LoadTotalOngoing(lblMaintenanceOngoing)
        LoadTotalCompleted(lblMaintenanceGoods)
        LoadTotalScheduled(lblMaintenanceScheduled)
    End Sub
    Private Sub pnlUsers_Click(sender As Object, e As EventArgs) Handles pnlUsers.Click
        ClickUsers()
        LoadTabUsers()
        LoadTotalUsers(lblUserUsers)
        LoadTotalUnpaid(lblUserUnpaid)
        LoadTotalPaid(lblUserPaid)
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub txtbxRental_TextChanged(sender As Object, e As EventArgs) Handles txtbxRental.TextChanged
        Dim searchText As String = txtbxRental.Text

        dgvRentals2.ClearSelection()

        If searchText = "" Then Exit Sub

        For Each row As DataGridViewRow In dgvRentals2.Rows
            If row.IsNewRow Then Continue For

            Dim cellValue As String = row.Cells("rental_id").Value.ToString()

            If cellValue.Contains(searchText) Then
                row.Selected = True
                dgvRentals2.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtbxSales.TextChanged
        Dim searchText As String = txtbxSales.Text

        dgvRentals2.ClearSelection()

        If searchText = "" Then Exit Sub

        For Each row As DataGridViewRow In dgvRentals2.Rows
            If row.IsNewRow Then Continue For

            Dim cellValue As String = row.Cells("report_id").Value.ToString()

            If cellValue.Contains(searchText) Then
                row.Selected = True
                dgvRentals2.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtbxInventory.TextChanged
        Dim searchText As String = txtbxInventory.Text.ToLower

        dgvRentals2.ClearSelection()

        If searchText = "" Then Exit Sub

        If cbVehicle.SelectedItem.ToString() = "ALL" Then
            For Each row As DataGridViewRow In dgvVehicles.Rows
                If row.IsNewRow Then Continue For
                Dim cellValue As String = row.Cells("vehicle_id").Value.ToString()
                If cellValue.Contains(searchText) Then
                    row.Selected = True
                    dgvVehicles.FirstDisplayedScrollingRowIndex = row.Index
                    Exit For
                End If
            Next
        ElseIf cbVehicle.SelectedItem.ToString() = "CARS" Then
            For Each row As DataGridViewRow In dgvVehicles.Rows
                If row.IsNewRow Then Continue For
                Dim cellValue As String = row.Cells("car_id").Value.ToString()
                If cellValue.Contains(searchText) Then
                    row.Selected = True
                    dgvVehicles.FirstDisplayedScrollingRowIndex = row.Index
                    Exit For
                End If
            Next
        ElseIf cbVehicle.SelectedItem.ToString() = "MOTORCYCLES" Then
            For Each row As DataGridViewRow In dgvVehicles.Rows
                If row.IsNewRow Then Continue For
                Dim cellValue As String = row.Cells("motor_id").Value.ToString()
                If cellValue.Contains(searchText) Then
                    row.Selected = True
                    dgvVehicles.FirstDisplayedScrollingRowIndex = row.Index
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub txtbxMaintenance_TextChanged(sender As Object, e As EventArgs) Handles txtbxMaintenance.TextChanged
        Dim searchText As String = txtbxMaintenance.Text

        dgvRentals2.ClearSelection()

        If searchText = "" Then Exit Sub

        For Each row As DataGridViewRow In dgvRentals2.Rows
            If row.IsNewRow Then Continue For

            Dim cellValue As String = row.Cells("maintenance_id").Value.ToString()

            If cellValue.Contains(searchText) Then
                row.Selected = True
                dgvRentals2.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtbxUsers.TextChanged
        Dim searchText As String = txtbxUsers.Text

        dgvRentals2.ClearSelection()

        If searchText = "" Then Exit Sub

        For Each row As DataGridViewRow In dgvRentals2.Rows
            If row.IsNewRow Then Continue For

            Dim cellValue As String = row.Cells("customer_id").Value.ToString()

            If cellValue.Contains(searchText) Then
                row.Selected = True
                dgvRentals2.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub
End Class