Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Notice
Imports Windows.Win32.System
Public Class FORM_ADMIN

    Dim connStr As String = "server=localhost;user=root;password=;database=ridexp"
    Dim conn As New MySqlConnection(connStr)

    Dim categories() As String = {"Minor", "Major", "Total Loss", "Other"}

    Dim minorPenalties As (Description As String, Penalty As Integer)() = {
    ("Light surface scratches (door/key marks)", 1500),
    ("Small dent (no paint damage)", 2500),
    ("Interior stains", 4000)
}

    Dim majorPenalties As (Description As String, Penalty As Integer)() = {
    ("Deep dent with paint removal", 15000),
    ("Broken windshield or windows", 30000)
}

    Dim totalLossPenalties As (Description As String, Penalty As Integer)() = {
    ("Totaled vehicle", 500000),
    ("Theft with negligence", 650000)
}

    Dim otherPenalties As (Description As String, Penalty As Integer)() = {
    ("Unreported accident", 8000),
    ("Smoking in vehicle", 3000)
}

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
        pnlUsersEditUser.Location = New Point(1300, 97)
        cbPenaltyType.Items.AddRange(categories)
        pnlAddPenalty.Location = New Point(1300, 97)

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
        cbVehicle.SelectedItem = "ALL"
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
        cbVehicle.SelectedItem = "ALL"
        pnlAddCars.Location = New Point(1300, 97)
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

        txtEditID.PlaceholderText = "Input User ID"
        txtEditFirst.PlaceholderText = "Input First Name"
        txtEditLast.PlaceholderText = "Input Last Name"
        txtEditBirth.PlaceholderText = "Input Birthdate (YYYY-MM-DD)"
        txtEditEmail.PlaceholderText = "Input Email"
        txtEditPhone.PlaceholderText = "Input Phone Number"
        txtEditAddress.PlaceholderText = "Input Address"
        txtEditLicense.PlaceholderText = "Input License Number"
        txtEditExpiry.PlaceholderText = "Input License Expiry (YYYY-MM-DD)"


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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        If txtEditID.Text.Trim = "" Then
            MessageBox.Show("User ID is required.")
            Exit Sub
        End If

        Dim userId = Integer.Parse(txtEditID.Text.Trim)

        Dim updates = ""
        Dim cmdParams As New List(Of MySqlParameter)

        If txtEditFirst.Text.Trim <> "" Then
            updates &= "first_name = @fname, "
            cmdParams.Add(New MySqlParameter("@fname", txtEditFirst.Text.Trim))
        End If

        If txtEditLast.Text.Trim <> "" Then
            updates &= "last_name = @lname, "
            cmdParams.Add(New MySqlParameter("@lname", txtEditLast.Text.Trim))
        End If

        If txtEditEmail.Text.Trim <> "" Then
            updates &= "email = @email, "
            cmdParams.Add(New MySqlParameter("@email", txtEditEmail.Text.Trim))
        End If

        If txtEditBirth.Text.Trim <> "" Then
            Try
                Dim birthDate = Date.Parse(txtEditBirth.Text.Trim)
                updates &= "date_of_birth = @bdate, "
                cmdParams.Add(New MySqlParameter("@bdate", birthDate))
            Catch ex As Exception
                MessageBox.Show("Invalid birth date format.")
                Exit Sub
            End Try
        End If

        If txtEditPhone.Text.Trim <> "" Then
            updates &= "phone = @phone, "
            cmdParams.Add(New MySqlParameter("@phone", txtEditPhone.Text.Trim))
        End If

        If txtEditAddress.Text.Trim <> "" Then
            updates &= "address = @addr, "
            cmdParams.Add(New MySqlParameter("@addr", txtEditAddress.Text.Trim))
        End If

        If txtEditLicense.Text.Trim <> "" Then
            updates &= "license_number = @licno, "
            cmdParams.Add(New MySqlParameter("@licno", txtEditLicense.Text.Trim))
        End If

        If txtEditExpiry.Text.Trim <> "" Then
            Try
                Dim expiryDate = Date.Parse(txtEditExpiry.Text.Trim)
                updates &= "license_expiry = @licexp, "
                cmdParams.Add(New MySqlParameter("@licexp", expiryDate))
            Catch ex As Exception
                MessageBox.Show("Invalid license expiry date format.")
                Exit Sub
            End Try
        End If

        If updates.EndsWith(", ") Then
            updates = updates.Substring(0, updates.Length - 2)
        End If

        If updates = "" Then
            MessageBox.Show("Please fill in at least one field to update.")
            Exit Sub
        End If

        Dim query = "UPDATE customers SET " & updates & " WHERE customer_id = @id"

        Try
            Using conn As New MySqlConnection("server=localhost;user=root;password=;database=ridexp")
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)

                    For Each p In cmdParams
                        cmd.Parameters.Add(p)
                    Next
                    cmd.Parameters.AddWithValue("@id", userId)

                    Dim rowsAffected = cmd.ExecuteNonQuery
                    If rowsAffected > 0 Then
                        MessageBox.Show("User updated successfully.")
                        pnlUsersEditUser.Location = New Point(1300, 97)
                        LoadTabUsers()
                    Else
                        MessageBox.Show("No records updated. Check the User ID.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        pnlUsersEditUser.Location = New Point(1300, 97)
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        pnlUsersEditUser.Location = New Point(442, 175)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If dgvAllUSERS.SelectedRows.Count > 0 Then
            Dim selectedRow = dgvAllUSERS.SelectedRows(0)
            Dim userId = Convert.ToInt32(selectedRow.Cells(0).Value)

            Dim confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirm = DialogResult.Yes Then
                Dim connStr = "server=localhost;user=root;password=;database=ridexp"
                Using conn As New MySqlConnection(connStr)
                    conn.Open()
                    Dim query = "DELETE FROM customers WHERE customer_id = @id"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", userId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("User deleted successfully.")
                LoadTabUsers()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub cbPenaltyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPenaltyType.SelectedIndexChanged
        cbPenaltyDescription.Items.Clear()
        cbPenaltyDescription.SelectedIndex = -1

        If cbPenaltyType.SelectedItem Is Nothing Then Exit Sub

        Select Case cbPenaltyType.SelectedItem.ToString
            Case "Minor"
                For Each item In minorPenalties
                    cbPenaltyDescription.Items.Add(item.Description)
                Next
            Case "Major"
                For Each item In majorPenalties
                    cbPenaltyDescription.Items.Add(item.Description)
                Next
            Case "Total Loss"
                For Each item In totalLossPenalties
                    cbPenaltyDescription.Items.Add(item.Description)
                Next
            Case "Other"
                For Each item In otherPenalties
                    cbPenaltyDescription.Items.Add(item.Description)
                Next
        End Select
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPenaltyDescription.SelectedIndexChanged
        Dim selectedCategory As String = cbPenaltyType.SelectedItem.ToString()
        Dim index As Integer = cbPenaltyDescription.SelectedIndex
        Dim penaltyAmount As Integer = 0

        Select Case selectedCategory
            Case "Minor"
                penaltyAmount = minorPenalties(index).Penalty
            Case "Major"
                penaltyAmount = majorPenalties(index).Penalty
            Case "Total Loss"
                penaltyAmount = totalLossPenalties(index).Penalty
            Case "Other"
                penaltyAmount = otherPenalties(index).Penalty
        End Select

        txtPenaltyAmount.Text = "₱ " & penaltyAmount.ToString("N2")
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        pnlAddPenalty.Location = New Point(1300, 97)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        pnlAddPenalty.Location = New Point(122, 92)
        txtPenaltyRentalID.PlaceholderText = "Input Rental ID"
        cbPenaltyType.Text = "Penalty Type"
        cbPenaltyDescription.Text = "Penalty Description"
        txtPenaltyAmount.Text = "₱ 0.00"
        txtPenaltyAmount.Enabled = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "PENALTIES" Then
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM penalty"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvAllUSERS.DataSource = table
            Catch ex As Exception
                MessageBox.Show("Error loading data: " & ex.Message)
            Finally
                conn.Close()
            End Try
        ElseIf ComboBox2.SelectedItem = "USERS" Then
            LoadTabUsers()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim selectedCategory As String = cbPenaltyType.SelectedItem.ToString()
        Dim index As Integer = cbPenaltyDescription.SelectedIndex
        Dim penaltyAmount As Integer = 0

        Select Case selectedCategory
            Case "Minor"
                penaltyAmount = minorPenalties(index).Penalty
            Case "Major"
                penaltyAmount = majorPenalties(index).Penalty
            Case "Total Loss"
                penaltyAmount = totalLossPenalties(index).Penalty
            Case "Other"
                penaltyAmount = otherPenalties(index).Penalty
        End Select

        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO penalty (rental_id, description, amount) VALUES (@rental_id, @description, @amount)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@rental_id", txtPenaltyRentalID.Text)
                    cmd.Parameters.AddWithValue("@description", cbPenaltyDescription.SelectedItem)
                    cmd.Parameters.AddWithValue("@amount", penaltyAmount)

                    Dim result = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("Penalty inserted successfully!")
                    Else
                        MessageBox.Show("Failed to insert penalty.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub

    Dim carCategory() As String = {"Compact Sedan CVT", "MPV Automatic", "SUV Diesel Automatic", "SUV Gasoline Automatic", "Hatchback CVT", "Hybrid CVT"}
    Dim motorcycleCategory() As String = {"Scooter CVT", "Underbone Semi-Auto", "Adventure CVT"}
    Dim valueCarCategory As Integer = 0
    Dim valueMotorcycleCategory As Integer = 0

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        cbVehicleCategory.Items.Clear()

        If cbCategory.SelectedItem IsNot Nothing Then
            If cbCategory.SelectedItem.ToString() = "CARS" Then
                For Each item In carCategory
                    cbVehicleCategory.Items.Add(item)
                Next
                cbVehicleCategory.Enabled = True
            ElseIf cbCategory.SelectedItem.ToString() = "MOTORCYCLES" Then
                For Each item In motorcycleCategory
                    cbVehicleCategory.Items.Add(item)
                Next
                cbVehicleCategory.Enabled = True
                txtAddSeatCapacity.Enabled = False
                txtAddSeatCapacity.Clear()
            End If
        Else
            cbVehicleCategory.Enabled = False
        End If

        cbVehicleCategory.SelectedIndex = -1
        cbVehicleCategory.Text = "Select Category"

    End Sub

    Private Sub cbVehicleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVehicleCategory.SelectedIndexChanged
        If cbVehicleCategory.SelectedItem IsNot Nothing Then
            If cbCategory.SelectedItem = "CARS" Then
                txtAddSeatCapacity.Enabled = True
            ElseIf cbCategory.SelectedItem = "MOTORCYCLES" Then
                txtAddSeatCapacity.Enabled = False
                txtAddSeatCapacity.Clear()
            End If
        End If
    End Sub

    Dim carId As Integer
    Dim motorId As Integer ' Fixed typo: was "motorid"
    Dim imagePath As String = ""
    Dim imageBytes() As Byte
    Dim imageName As String
    Dim hasImageSelected As Boolean = False

    Private Sub btnAddCars_Click(sender As Object, e As EventArgs) Handles btnAddCars.Click
        txtAddSeatCapacity.Enabled = False
        pnlAddCars.Location = New Point(127, 92)

        txtAddMake.PlaceholderText = "Input Make"
        txtAddModel.PlaceholderText = "Input Model"
        txtAddYear.PlaceholderText = "Input Year"
        txtAddPlate.PlaceholderText = "Input License Plate"
        txtAddColor.PlaceholderText = "Input Color"
        txtRentalRate.PlaceholderText = "Input Rental Rate"
        addMileage.PlaceholderText = "Input Mileage"
        txtAddSeatCapacity.PlaceholderText = "Input Seat Capacity"

        cbCategory.Text = "Vehicle Type"
        cbVehicleCategory.Text = "Vehicle Category"

        cbCategory.SelectedIndex = -1
        cbVehicleCategory.SelectedIndex = -1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If cbCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vehicle type.")
            Exit Sub
        End If

        If cbVehicleCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vehicle category.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtAddMake.Text) OrElse
       String.IsNullOrWhiteSpace(txtAddModel.Text) OrElse
       String.IsNullOrWhiteSpace(txtAddYear.Text) OrElse
       String.IsNullOrWhiteSpace(txtAddPlate.Text) OrElse
       String.IsNullOrWhiteSpace(txtAddColor.Text) OrElse
       String.IsNullOrWhiteSpace(addMileage.Text) OrElse
       String.IsNullOrWhiteSpace(txtRentalRate.Text) Then
            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If

        Dim year As Integer
        Dim mileage As Decimal
        Dim rentalRate As Decimal

        If Not Integer.TryParse(txtAddYear.Text, year) Then
            MessageBox.Show("Please enter a valid year.")
            Exit Sub
        End If

        If Not Decimal.TryParse(addMileage.Text, mileage) Then
            MessageBox.Show("Please enter a valid mileage.")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtRentalRate.Text, rentalRate) Then
            MessageBox.Show("Please enter a valid rental rate.")
            Exit Sub
        End If

        Try
            If cbCategory.SelectedItem = "CARS" Then
                Dim seatCapacity As Integer
                If Not Integer.TryParse(txtAddSeatCapacity.Text, seatCapacity) Then
                    MessageBox.Show("Please enter a valid seat capacity.")
                    Exit Sub
                End If

                Dim comm = "INSERT INTO cars (car_category_id, make, model_name, year, license_plate, color, mileage, seating_capacity) 
              VALUES (@car_category, @make, @model, @year, @license_plate, @color, @mileage, @seating_capacity)"
                Using conn As New MySqlConnection(connStr)
                    conn.Open()

                    Using cmd As New MySqlCommand(comm, conn)
                        cmd.Parameters.AddWithValue("@car_category", cbVehicleCategory.SelectedIndex + 1)
                        cmd.Parameters.AddWithValue("@make", txtAddMake.Text.Trim)
                        cmd.Parameters.AddWithValue("@model", txtAddModel.Text.Trim)
                        cmd.Parameters.AddWithValue("@year", txtAddYear.Text.Trim)
                        cmd.Parameters.AddWithValue("@license_plate", txtAddPlate.Text.Trim.ToUpper)
                        cmd.Parameters.AddWithValue("@color", txtAddColor.Text.Trim)
                        cmd.Parameters.AddWithValue("@mileage", addMileage.Text.Trim)
                        cmd.Parameters.AddWithValue("@seating_capacity", txtAddSeatCapacity.Text.Trim)

                        Dim result = cmd.ExecuteNonQuery

                        If result > 0 Then
                            cmd.CommandText = "SELECT LAST_INSERT_ID()"
                            carId = Convert.ToInt32(cmd.ExecuteScalar) ' Set the class-level variable

                            Dim comm2 = "INSERT INTO vehicles (vehicle_type, item_id, status_id) 
                            VALUES (@vehicle_type, @item_id, @status_id)"
                            Using cmd2 As New MySqlCommand(comm2, conn)
                                Dim vehicleTypeId = If(cbCategory.SelectedItem = "CARS", 1, 2)
                                cmd2.Parameters.AddWithValue("@vehicle_type", vehicleTypeId)
                                cmd2.Parameters.AddWithValue("@item_id", carId)

                                If cbStatus IsNot Nothing AndAlso cbStatus.SelectedIndex >= 0 Then
                                    cmd2.Parameters.AddWithValue("@status_id", cbStatus.SelectedIndex + 1)
                                Else
                                    cmd2.Parameters.AddWithValue("@status_id", 1)
                                End If

                                Dim result2 = cmd2.ExecuteNonQuery
                            End Using

                            ' Only save image if one was selected
                            If hasImageSelected Then
                                Dim comm5 As String = "INSERT INTO cars_pic (car_id, image) VALUES (@car_id, @image)"
                                Using cmd5 As New MySqlCommand(comm5, conn)
                                    Try
                                        cmd5.Parameters.AddWithValue("@car_id", carId)
                                        cmd5.Parameters.AddWithValue("@image", imageName) ' Use imageBytes for consistency

                                        Dim imageResult = cmd5.ExecuteNonQuery()
                                        If imageResult > 0 Then
                                            MessageBox.Show("Image saved successfully!")
                                        Else
                                            MessageBox.Show("Image not saved - no rows affected!")
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show($"Image save error: {ex.Message}")
                                    End Try
                                End Using
                            End If

                            Dim vehicleId As Integer
                            cmd.CommandText = "SELECT LAST_INSERT_ID()"
                            vehicleId = Convert.ToInt32(cmd.ExecuteScalar)

                            Dim comm3 = "INSERT INTO rental_rate (vehicle_id, rate_per_day, effective_date) 
                            VALUES (@vehicle_id, @rate_per_day, CURDATE())"

                            Using cmd3 As New MySqlCommand(comm3, conn)
                                cmd3.Parameters.AddWithValue("@vehicle_id", vehicleId)
                                cmd3.Parameters.AddWithValue("@rate_per_day", rentalRate)

                                Dim result3 = cmd3.ExecuteNonQuery
                                If result3 > 0 Then
                                    MessageBox.Show("Car added successfully!")
                                    pnlInventory_Click(pnlInventory, EventArgs.Empty)
                                    ClearForm()
                                Else
                                    MessageBox.Show("Failed to add rental rate.")
                                End If
                            End Using
                        Else
                            MessageBox.Show("Failed to add car.")
                        End If
                    End Using
                End Using

            ElseIf cbCategory.SelectedItem = "MOTORCYCLES" Then
                Dim comm = "INSERT INTO motors (motor_category_id, make, model, year, license_plate, color, mileage) 
              VALUES (@motorcycle_category, @make, @model, @year, @license_plate, @color, @mileage)"
                Using conn As New MySqlConnection(connStr)
                    conn.Open()

                    Using cmd As New MySqlCommand(comm, conn)
                        cmd.Parameters.AddWithValue("@motorcycle_category", cbVehicleCategory.SelectedIndex + 1)
                        cmd.Parameters.AddWithValue("@make", txtAddMake.Text.Trim)
                        cmd.Parameters.AddWithValue("@model", txtAddModel.Text.Trim)
                        cmd.Parameters.AddWithValue("@year", txtAddYear.Text.Trim)
                        cmd.Parameters.AddWithValue("@license_plate", txtAddPlate.Text.Trim.ToUpper)
                        cmd.Parameters.AddWithValue("@color", txtAddColor.Text.Trim)
                        cmd.Parameters.AddWithValue("@mileage", addMileage.Text.Trim)

                        Dim result = cmd.ExecuteNonQuery
                        If result > 0 Then
                            cmd.CommandText = "SELECT LAST_INSERT_ID()"
                            motorId = Convert.ToInt32(cmd.ExecuteScalar) ' Set the class-level variable

                            Dim comm2 = "INSERT INTO vehicles (vehicle_type, item_id, status_id) 
                            VALUES (@vehicle_type, @item_id, @status_id)"
                            Using cmd2 As New MySqlCommand(comm2, conn)
                                Dim vehicleTypeId = If(cbCategory.SelectedItem = "CARS", 1, 2)
                                cmd2.Parameters.AddWithValue("@vehicle_type", vehicleTypeId)
                                cmd2.Parameters.AddWithValue("@item_id", motorId)

                                If cbStatus IsNot Nothing AndAlso cbStatus.SelectedIndex >= 0 Then
                                    cmd2.Parameters.AddWithValue("@status_id", cbStatus.SelectedIndex + 1)
                                Else
                                    cmd2.Parameters.AddWithValue("@status_id", 1)
                                End If

                                Dim result2 = cmd2.ExecuteNonQuery
                            End Using

                            If hasImageSelected Then
                                Dim comm5 As String = "INSERT INTO motors_pic (motor_id, image) VALUES (@motor_id, @image)"
                                Using cmd5 As New MySqlCommand(comm5, conn)
                                    Try
                                        cmd5.Parameters.AddWithValue("@motor_id", motorId)
                                        cmd5.Parameters.AddWithValue("@image", imageName)

                                        Dim imageResult = cmd5.ExecuteNonQuery()
                                        If imageResult > 0 Then
                                            MessageBox.Show("Image saved successfully!")
                                        Else
                                            MessageBox.Show("Image not saved - no rows affected!")
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show($"Image save error: {ex.Message}")
                                    End Try
                                End Using
                            End If

                            Dim vehicleId As Integer
                            cmd.CommandText = "SELECT LAST_INSERT_ID()"
                            vehicleId = Convert.ToInt32(cmd.ExecuteScalar)

                            Dim comm3 = "INSERT INTO rental_rate (vehicle_id, rate_per_day, effective_date) 
                            VALUES (@vehicle_id, @rate_per_day, CURDATE())"

                            Using cmd3 As New MySqlCommand(comm3, conn)
                                cmd3.Parameters.AddWithValue("@vehicle_id", vehicleId)
                                cmd3.Parameters.AddWithValue("@rate_per_day", rentalRate)

                                Dim result3 = cmd3.ExecuteNonQuery
                                If result3 > 0 Then
                                    MessageBox.Show("Motorcycle added successfully!")
                                    pnlInventory_Click(pnlInventory, EventArgs.Empty)
                                    ClearForm()
                                Else
                                    MessageBox.Show("Failed to add rental rate.")
                                End If
                            End Using
                        Else
                            MessageBox.Show("Failed to add motorcycle.")
                        End If
                    End Using
                End Using
            End If

        Catch ex As MySqlException
            MessageBox.Show($"Database error: {ex.Message}")
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}")
        End Try
    End Sub

    Private Sub ClearForm()
        cbCategory.SelectedIndex = -1
        cbVehicleCategory.SelectedIndex = -1
        If cbVehicleCategory IsNot Nothing Then cbVehicleCategory.SelectedIndex = -1

        txtAddMake.Clear()
        txtAddModel.Clear()
        txtAddYear.Clear()
        txtAddPlate.Clear()
        txtAddColor.Clear()
        addMileage.Clear()
        txtAddSeatCapacity.Clear()
        txtRentalRate.Clear()

        ' Clear image data
        pbxAddImage.Image = Nothing
        imagePath = ""
        imageBytes = Nothing
        imageName = ""
        hasImageSelected = False
        carId = 0
        motorId = 0

        pnlAddCars.Location = New Point(1300, 81)
        cbCategory.Text = "Vehicle Type"
        cbVehicleCategory.Text = "Vehicle Category"
    End Sub
    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click
        pnlAddCars.Location = New Point(1300, 81)
    End Sub

    ' FIXED: Image upload button - just prepare the image, don't save to DB
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"

        If ofd.ShowDialog() = DialogResult.OK Then
            Try
                Dim selectedFilePath As String = ofd.FileName

                ' Ensure Resources folder exists
                Dim resourcesFolder As String = "C:\Users\Admin\Desktop\3RD SEM\FUNDAMENTALS\VBNET\RIDEXP\RIDEXP\Resources"
                If Not Directory.Exists(resourcesFolder) Then
                    Directory.CreateDirectory(resourcesFolder)
                End If

                ' Copy the selected image to Resources folder
                Dim fileName As String = Path.GetFileName(selectedFilePath)
                Dim destPath As String = Path.Combine(resourcesFolder, fileName)
                File.Copy(selectedFilePath, destPath, True)

                ' Set image data for database storage
                imagePath = destPath ' Use the copied file path
                pbxAddImage.Image = Image.FromFile(destPath)
                imageName = fileName
                imageBytes = File.ReadAllBytes(destPath)
                hasImageSelected = True

                MessageBox.Show("Image copied to Resources folder and selected successfully! It will be saved when you add the vehicle.")
            Catch ex As Exception
                MessageBox.Show($"Error loading/copying image: {ex.Message}")
                hasImageSelected = False
            End Try
        End If


    End Sub


    Private Sub putanginamo_Click(sender As Object, e As EventArgs) Handles putanginamo.Click
        ' First test - just show a simple message to confirm the event fires
        MessageBox.Show("Button clicked! Event is working.")

        Try
            Dim possibleExtensions As String() = {".jpg", ".jpeg", ".png", ".gif", ".bmp"}
            Dim serviceImage As Image = Nothing
            Dim imageName As String = "AdobeStock_656858801"

            MessageBox.Show("Starting image search...")

            For Each ext In possibleExtensions
                Dim imagePath As String = Path.Combine("C:\Users\Admin\Desktop\3RD SEM\FUNDAMENTALS\VBNET\RIDEXP\RIDEXP\Resources", imageName & ext)
                MessageBox.Show($"Checking path: {imagePath}")

                If File.Exists(imagePath) Then
                    MessageBox.Show("File exists! Attempting to load...")
                    serviceImage = Image.FromFile(imagePath)
                    MessageBox.Show("Image loaded from file!")
                    Exit For
                Else
                    MessageBox.Show("File does not exist at this path.")
                End If
            Next

            If serviceImage IsNot Nothing Then
                MessageBox.Show("Setting image to PictureBox...")
                picpicbox.Image = serviceImage
                MessageBox.Show("Image set successfully!")
            Else
                MessageBox.Show("No image was loaded - serviceImage is Nothing")
            End If

        Catch ex As Exception
            MessageBox.Show($"Error occurred: {ex.Message}")
        End Try
    End Sub
End Class