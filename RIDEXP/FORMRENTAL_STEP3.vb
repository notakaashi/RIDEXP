Imports Microsoft.VisualBasic.Logging
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FORMRENTAL_STEP3

    Private Sub LoadCarInfo(carId As Integer)
        Try

            If RentalTransactionModule.conn Is Nothing OrElse RentalTransactionModule.conn.State <> ConnectionState.Open Then
                MessageBox.Show("No active database connection.")
                Return
            End If

            Dim cmd As New MySqlCommand("
        SELECT 
            c.mileage,
            c.seating_capacity,
            ft.fuel_type,
            tt.transmission_type,
            cp.image,
c.make,
            c.model_name
        FROM 
            cars c
        JOIN car_category cc ON c.car_category_id = cc.car_category_id
        LEFT JOIN fuel_types ft ON cc.fuel_id = ft.fuel_id
        LEFT JOIN transmission_types tt ON cc.transmission_id = tt.transmission_id
        LEFT JOIN cars_pic cp ON c.car_id = cp.car_id
        WHERE c.car_id = @carId", RentalTransactionModule.conn)


            cmd.Parameters.AddWithValue("@carId", carId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()




            If reader.Read() Then
                mileagetxt.Text = If(IsDBNull(reader("mileage")), "N/A", reader("mileage").ToString())
                seatcapacitytxt.Text = If(IsDBNull(reader("seating_capacity")), "N/A", reader("seating_capacity").ToString())
                fueltxt.Text = If(IsDBNull(reader("fuel_type")), "N/A", reader("fuel_type").ToString())
                transmissiontxt.Text = If(IsDBNull(reader("transmission_type")), "N/A", reader("transmission_type").ToString())
                Dim make As String = If(IsDBNull(reader("make")), "N/A", reader("make").ToString())
                Dim model As String = If(IsDBNull(reader("model_name")), "", reader("model_name").ToString())
                Label33.Text = $"{make} {model}".Trim()
                Label26.Visible = True

                If Not IsDBNull(reader("image")) Then
                    Try
                        Dim imageVal As String = reader("image").ToString()

                        ' First check if file exists (new cars)
                        Dim fullPath As String = Path.Combine(Application.StartupPath, imageVal)
                        If File.Exists(fullPath) Then
                            PictureBox4.Image = Image.FromFile(fullPath)
                            PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
                            Debug.WriteLine($"[DEBUG] Loaded image from file: {fullPath}")
                        Else
                            ' Otherwise, try loading from My.Resources (predefined cars)
                            Dim imageName As String = IO.Path.GetFileNameWithoutExtension(imageVal)
                            Dim resImage = My.Resources.ResourceManager.GetObject(imageName)

                            If resImage IsNot Nothing AndAlso TypeOf resImage Is Image Then
                                PictureBox4.Image = CType(resImage, Image)
                                PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
                                Debug.WriteLine($"[DEBUG] Loaded image from resources: {imageName}")
                            Else
                                Debug.WriteLine($"[DEBUG] Image not found: {imageVal}")
                                PictureBox4.Image = Nothing
                            End If
                        End If

                    Catch ex As Exception
                        MessageBox.Show($"Error loading image: {ex.Message}")
                        PictureBox4.Image = Nothing
                    End Try
                Else
                    PictureBox4.Image = Nothing
                    Debug.WriteLine("[DEBUG] No image in DB for this car")
                End If

                PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
            Else
                MessageBox.Show("Car not found with ID: " & carId)
                ' Set default values
                mileagetxt.Text = "N/A"
                seatcapacitytxt.Text = "N/A"
                fueltxt.Text = "N/A"
                transmissiontxt.Text = "N/A"
                PictureBox4.Image = Nothing
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading car info: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadMotorInfo(motorId As Integer)
        Try
            If RentalTransactionModule.conn Is Nothing OrElse RentalTransactionModule.conn.State <> ConnectionState.Open Then
                MessageBox.Show("No active database connection.")
                Return
            End If

            Dim cmd As New MySqlCommand("
            SELECT 
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
              AND m.motor_id = @motorId", RentalTransactionModule.conn)

            cmd.Parameters.AddWithValue("@motorId", motorId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Show these values
                mileagetxt.Text = If(IsDBNull(reader("mileage")), "N/A", reader("mileage").ToString())
                fueltxt.Text = If(IsDBNull(reader("color")), "N/A", reader("color").ToString())
                transmissiontxt.Text = If(IsDBNull(reader("year")), "N/A", reader("year").ToString())

                Label23.Text = "Color"
                Label25.Text = "Year"
                Label26.Visible = False
                seatcapacitytxt.Visible = False

                ' Show make + model
                Dim make As String = If(IsDBNull(reader("make")), "N/A", reader("make").ToString())
                Dim model As String = If(IsDBNull(reader("model")), "", reader("model").ToString())
                Label33.Text = $"{make} {model}".Trim()

                ' Load image from resource name
                If Not IsDBNull(reader("image")) Then
                    Try
                        Dim imageVal As String = reader("image").ToString()

                        Dim fullPath As String = Path.Combine(Application.StartupPath, imageVal)
                        If File.Exists(fullPath) Then
                            PictureBox4.Image = Image.FromFile(fullPath)
                            PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
                            Debug.WriteLine($"[DEBUG] Loaded image from file: {fullPath}")
                        Else
                            Dim imageName As String = IO.Path.GetFileNameWithoutExtension(imageVal)
                            Dim resImage = My.Resources.ResourceManager.GetObject(imageName)

                            If resImage IsNot Nothing AndAlso TypeOf resImage Is Image Then
                                PictureBox4.Image = CType(resImage, Image)
                                PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
                                Debug.WriteLine($"[DEBUG] Loaded image from resources: {imageName}")
                            Else
                                Debug.WriteLine($"[DEBUG] Image not found: {imageVal}")
                                PictureBox4.Image = Nothing
                            End If
                        End If

                    Catch ex As Exception
                        MessageBox.Show($"Error loading image: {ex.Message}")
                        PictureBox4.Image = Nothing
                    End Try
                Else
                    PictureBox4.Image = Nothing
                    Debug.WriteLine("[DEBUG] No image in DB for this car")
                End If
                PictureBox4.SizeMode = PictureBoxSizeMode.Zoom

            Else
                MessageBox.Show("Motor not found with ID: " & motorId)
                ' Set defaults
                mileagetxt.Text = "N/A"
                transmissiontxt.Text = "N/A"
                seatcapacitytxt.Visible = False
                PictureBox4.Image = Nothing
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading motor info: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadTransactionDataToLabels()
        Try
            With RentalTransactionModule.TransactionData


                ' Display pickup information
                If .PickupDate <> Nothing Then
                    ' If you have a pickup date label, uncomment this:
                    pickupdatelbl.Text = .PickupDate.ToString("MMMM dd, yyyy")
                End If

                If Not String.IsNullOrEmpty(.PickupTime) Then
                    pickuptimelbl.Text = .PickupTime
                Else
                    pickuptimelbl.Text = "Not set"
                End If

                If Not String.IsNullOrEmpty(.PickupPlace) Then
                    pickuploclbl.Text = .PickupPlace
                Else
                    pickuploclbl.Text = "Not set"
                End If

                ' Display return information  
                If .ReturnDate <> Nothing Then
                    returndatelbl.Text = .ReturnDate.ToString("MMMM dd, yyyy")
                Else
                    returndatelbl.Text = "Not set"
                End If

                ' FIXED: Return time label (was returntimetxtbox.Text)
                If Not String.IsNullOrEmpty(.ReturnTime) Then
                    returntimelbl.Text = .ReturnTime
                Else
                    returntimelbl.Text = "Not set"
                End If

                If Not String.IsNullOrEmpty(.ReturnPlace) Then
                    returnloclbl.Text = .ReturnPlace
                Else
                    returnloclbl.Text = "Not set"
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Error loading transaction data: " & ex.Message)
        End Try
    End Sub

    Private Sub FORMRENTAL_STEP3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If loggedin = False Then
            RefreshLoginState()

        End If

        Try
            If RentalTransactionModule.TransactionData.SelectedCarId <= 0 AndAlso RentalTransactionModule.TransactionData.SelectedMotorId <= 0 Then
                MessageBox.Show("No vehicle selected. Please start from car or motor selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If


            ' If transaction is null but we have data, try to reconnect
            If RentalTransactionModule.transaction Is Nothing OrElse RentalTransactionModule.conn Is Nothing OrElse RentalTransactionModule.conn.State <> ConnectionState.Open Then
                MessageBox.Show("Reconnecting to database...")
                If Not RentalTransactionModule.StartTransaction() Then
                    MessageBox.Show("Failed to reconnect. Please start over.")
                    Me.Close()
                    Return
                End If
            End If

            If RentalTransactionModule.TransactionData.VehicleType = "Car" Then
                LoadCarInfo(RentalTransactionModule.TransactionData.SelectedCarId)
            ElseIf RentalTransactionModule.TransactionData.VehicleType = "Motor" Then
                LoadMotorInfo(RentalTransactionModule.TransactionData.SelectedMotorId)
            Else
                MessageBox.Show("Unknown vehicle type: " & RentalTransactionModule.TransactionData.VehicleType)
            End If
            LoadTransactionDataToLabels()

        Catch ex As Exception
            MessageBox.Show("Error in Form Load: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If loggedin = False Then
                MessageBox.Show("You need to log in before proceeding to payment.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Logjn.Show()
            Else
                FORMRENTAL_STEP4.Show()
                Me.Hide()
                TransactionData.CustomerConfirmed = True
            End If


        Catch ex As Exception
            MessageBox.Show("Error proceeding to payment: " & ex.Message)
        End Try


    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Try
            ' Ask for confirmation before cancelling
            If MessageBox.Show("Are you sure you want to cancel this booking? All data will be lost.",
                              "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' Rollback transaction
                RentalTransactionModule.RollbackTransaction()

                ' Go to home
                Form1.Show()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error cancelling booking: " & ex.Message)
        End Try
    End Sub

    ' Optional: Add a back button handler
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Try
            ' Go back to previous form (Step 2)
            Dim step2Form As New FORMRENTAL_STEP2 ' Replace with your actual step 2 form name
            step2Form.Show
            Hide
        Catch ex As Exception
            MessageBox.Show("Error going back: " & ex.Message)
        End Try
    End Sub

    Private Sub FORMRENTAL_STEP3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        FORMRENTAL_STEP2.Show()
    End Sub

    Public Sub RefreshLoginState()
        PictureBox3.Visible = loggedin
        user.Text = userlogged
        user.Visible = loggedin
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loggedin = False
        user.Visible = False
        Panel9.Visible = False
        PictureBox3.Visible = False
        MsgBox("Logout successful! See you next time.", MsgBoxStyle.Information, "Success")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Panel9.Visible = Not Panel9.Visible
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Logjn.Show()
    End Sub
End Class