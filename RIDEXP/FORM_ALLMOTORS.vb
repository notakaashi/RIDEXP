﻿Imports MySql.Data.MySqlClient

Public Class FORM_ALLMOTORS
    Private Sub LoadAllMotorData()
        Try
            Dim connectionString As String = "server=localhost;database=ridexp;UserId=root;password=;"
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                For motorId As Integer = 1 To 10
                    LoadSingleMotor(conn, motorId)
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading motor data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSingleMotor(conn As MySqlConnection, motorId As Integer)
        Try
            Dim query As String = "SELECT 
                                    m.color,
                                    tt.transmission_type,
                                    m.mileage,
                                    m.year,
                                    rr.rate_per_day,
                                    m.make,
                                    m.model,
                                    mp.image  
                                    FROM motors m
                                    JOIN vehicles v ON m.motor_id = v.item_id
                                    JOIN rental_rate rr ON rr.vehicle_id = v.vehicle_id
                                    JOIN motor_category mc ON m.motor_category_id = mc.motor_category_id
                                    JOIN transmission_types tt ON mc.transmission_id = tt.transmission_id
                                    JOIN motors_pic mp ON m.motor_id = mp.motor_id
                                    WHERE v.vehicle_type = 'motor'
                                    AND m.motor_id = @motorId;"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@motorId", motorId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Select Case motorId
                            Case 1
                                If Not IsDBNull(reader("model")) Then model1txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make1txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color1txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage1txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear1.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor1img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate1txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 2
                                If Not IsDBNull(reader("model")) Then model2txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make2txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color2txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage2txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear2.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor2img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate2txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 3
                                If Not IsDBNull(reader("model")) Then lblmodel3.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then lblmake3.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then lblcolor3.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then lblmileage3.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear3.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), imgmotor3)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate3txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 4
                                If Not IsDBNull(reader("model")) Then model4txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make4txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color4txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage4txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear4.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor4img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate4txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 5
                                If Not IsDBNull(reader("model")) Then model5txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make5txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color5txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage5txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear5.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor5img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate5txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 6
                                If Not IsDBNull(reader("model")) Then make6txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then model6txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color6txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage6txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear6.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor6img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate6txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 7
                                If Not IsDBNull(reader("model")) Then model7txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make7txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color7txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage7txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear7.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor7img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate7txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 8
                                If Not IsDBNull(reader("model")) Then model8txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make8txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color8txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage8txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear8.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor8img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate8txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 9
                                If Not IsDBNull(reader("model")) Then model9txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make9txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color9txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage9txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear9.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor9img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate9txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 10
                                If Not IsDBNull(reader("model")) Then model10txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make10txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color10txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage10txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear10.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadMotorImage(reader("image").ToString(), motor10img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate10txt.Text = reader("rate_per_day").ToString() & " per day"
                        End Select
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading car {motorId}: " & ex.Message)
        End Try
    End Sub

    Private Sub ResetButtonStyles()
        Dim buttons As Button() = {btnScooter, btnUnderbone, btnAdventure}
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

    Private Sub ShowOnlyPanel(targetPanel As Panel)
        pnlAdventure.Location = New Point(1300, 167)
        pnlScooter.Location = New Point(1300, 167)
        pnlUnderbone.Location = New Point(1300, 167)

        targetPanel.Location = New Point(54, 185)
        targetPanel.BringToFront()
    End Sub
    Private Sub LoadMotorImage(imageName As String, pictureBox As PictureBox)
        Try
            If Not String.IsNullOrEmpty(imageName) Then
                Dim imageNameWithoutExt As String = IO.Path.GetFileNameWithoutExtension(imageName)
                Dim resImage = My.Resources.ResourceManager.GetObject(imageNameWithoutExt)

                If resImage IsNot Nothing Then
                    pictureBox.Image = CType(resImage, Image)
                Else
                    pictureBox.Image = Nothing
                End If
            End If
        Catch ex As Exception
            pictureBox.Image = Nothing
        End Try
    End Sub
    Private Sub btnScooter_Click(sender As Object, e As EventArgs) Handles btnScooter.Click
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

    Private Sub FORM_ALLMOTORS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnScooter_Click(btnScooter, EventArgs.Empty)
        Me.Opacity = 0
        FadeTimer.Start()
        LoadAllMotorData()

    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            FadeTimer.Stop()
        End If
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Me.Close()
    End Sub

    Private Sub motor10btn_Click(sender As Object, e As EventArgs) Handles motor10btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(10, "Honda ADV", 2500, "Motor", 20)
    End Sub

    Private Sub motor7btn_Click(sender As Object, e As EventArgs) Handles motor7btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(7, "Suzuki Raider", 1600, "Motor", 17)
    End Sub

    Private Sub motor8btn_Click(sender As Object, e As EventArgs) Handles motor8btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(8, "Kawasaki Barako", 2400, "Motor", 18)
    End Sub

    Private Sub motor2btn_Click(sender As Object, e As EventArgs) Handles motor2btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(2, "Yamaha Mio Aerox", 2500, "Motor", 12)
    End Sub

    Private Sub btnmotor3_Click(sender As Object, e As EventArgs) Handles btnmotor3.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(3, "Honda Click125i", 3200, "Motor", 13)
    End Sub

    Private Sub motor9btn_Click(sender As Object, e As EventArgs) Handles motor9btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(9, "Yamaha NMAX", 2800, "Motor", 19)
    End Sub

    Private Sub motor6btn_Click(sender As Object, e As EventArgs) Handles motor6btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(6, "Honda PCX", 4000, "Motor", 16)
    End Sub

    Private Sub motor5btn_Click(sender As Object, e As EventArgs) Handles motor5btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(5, "Honda Genio", 2000, "Motor", 15)
    End Sub

    Private Sub motor4btn_Click(sender As Object, e As EventArgs) Handles motor4btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(4, "Honda BeAT", 2200, "Motor", 14)
    End Sub

    Private Sub motor1btn_Click(sender As Object, e As EventArgs) Handles motor1btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectMotor(1, "Yamaha Mio", 1800, "Motor", 11)
    End Sub
    Public Sub SaveForm1MotorData(motorId As Integer, motorName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        With TransactionData
            .SelectedMotorId = motorId
            .SelectedMotorName = motorName
            .DailyRate = dailyRate
            .VehicleType = vehicleType
            .SelectedVehicleId = vehicleId
        End With
    End Sub

    Private Sub SelectMotor(motorId As Integer, motorName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        Try

            RentalTransactionModule.SaveForm1MotorData(motorId, motorName, dailyRate, vehicleType, vehicleId)
            MessageBox.Show("Motor data saved: " & motorName)

            Dim step2Form As New FORMRENTAL_STEP2()
            step2Form.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error in SelectCar: " & ex.Message)
        End Try
    End Sub
End Class