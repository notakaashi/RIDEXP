Imports MySql.Data.MySqlClient
Imports System.IO

Public Class allcars
    Private Sub allcars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSuv_Click(btnSuv, EventArgs.Empty)
        Me.Opacity = 0
        FadeTimer.Start()

        LoadAllCarData()
    End Sub

    Private Sub LoadAllCarData()
        Try
            Dim connectionString As String = "server=localhost;database=ridexp;UserId=root;password=;"
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                For carId As Integer = 1 To 10
                    LoadSingleCar(conn, carId)
                Next
            End Using
            MessageBox.Show("Calling LoadNewCars() now...")
            LoadNewCars()

        Catch ex As Exception
            MessageBox.Show("Error loading car data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSingleCar(conn As MySqlConnection, carId As Integer)
        Try
            Dim query As String = "SELECT rr.rate_per_day, c.model_name, c.make, c.color, c.mileage, c.seating_capacity,c.year, cp.image
                                FROM cars c
                                JOIN cars_pic cp ON c.car_id = cp.car_id 
                                JOIN vehicles v ON c.car_id = v.vehicle_id
                                JOIN rental_rate rr ON rr.vehicle_id = v.vehicle_id
                                WHERE c.car_id = @carId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@carId", carId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Select Case carId
                            Case 1
                                If Not IsDBNull(reader("model_name")) Then model1txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make1txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color1txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage1txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity1txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("year")) Then year1txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car1img)
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate1txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 2
                                If Not IsDBNull(reader("model_name")) Then model2txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make2txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color2txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage2txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity2txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car2img)
                                If Not IsDBNull(reader("year")) Then year2txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate2txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 3
                                If Not IsDBNull(reader("model_name")) Then model3txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make3txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color3txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage3txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity3txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car3img)
                                If Not IsDBNull(reader("year")) Then year3txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate3txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 4
                                If Not IsDBNull(reader("model_name")) Then model4txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make4txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color4txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage4txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity4txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car4img)
                                If Not IsDBNull(reader("year")) Then year4txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate4txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 5
                                If Not IsDBNull(reader("model_name")) Then model5txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make5txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color5txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage5txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity5txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car5img)
                                If Not IsDBNull(reader("year")) Then year5txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate5txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 6
                                If Not IsDBNull(reader("model_name")) Then lblModel6.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then lblMake6.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then lblColor6.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then lblMileage6.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then lblSeat6.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), imgCar6)
                                If Not IsDBNull(reader("year")) Then year6txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate6txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 7
                                If Not IsDBNull(reader("model_name")) Then model7txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make7txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color7txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage7txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity7txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car7img)
                                If Not IsDBNull(reader("year")) Then year7txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate7txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 8
                                If Not IsDBNull(reader("model_name")) Then model8txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make8txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color8txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage8txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity8txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car8img)
                                If Not IsDBNull(reader("year")) Then year8txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate8txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 9
                                If Not IsDBNull(reader("model_name")) Then model9txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make9txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color9txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage9txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity9txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car9img)
                                If Not IsDBNull(reader("year")) Then year9txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate9txt.Text = reader("rate_per_day").ToString() & " per day"

                            Case 10
                                If Not IsDBNull(reader("model_name")) Then model10txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make10txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color10txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage10txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity10txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car10img)
                                If Not IsDBNull(reader("year")) Then year10txt.Text = reader("year").ToString()
                                If Not IsDBNull(reader("rate_per_day")) Then rentalrate10txt.Text = reader("rate_per_day").ToString() & " per day"

                        End Select
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading car {carId}: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCarImage(imageName As String, pictureBox As PictureBox)
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

    Private Sub ResetButtonStyles()
        Dim buttons As Button() = {btnSedan, btnSuv, btnMPV, btnHatch, btnHybrid}
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
        pnlAllCarsContent.Location = New Point(1300, 167)
        pnlSuvContent.Location = New Point(1300, 167)
        pnlSedan.Location = New Point(1300, 167)
        pnlMpv.Location = New Point(1300, 167)
        pnlHatchback.Location = New Point(1300, 167)
        pnlHybrid.Location = New Point(1300, 167)

        targetPanel.Location = New Point(54, 185)
        targetPanel.BringToFront()
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

    Private Sub btnSuv_Click(sender As Object, e As EventArgs) Handles btnSuv.Click
        ShowOnlyPanel(pnlSuvContent)
        HighlightButton(btnSuv)
    End Sub

    Private Sub btnSedan_Click(sender As Object, e As EventArgs) Handles btnSedan.Click
        ShowOnlyPanel(pnlSedan)
        HighlightButton(btnSedan)
    End Sub

    Private Sub btnMPV_Click(sender As Object, e As EventArgs) Handles btnMPV.Click
        ShowOnlyPanel(pnlMpv)
        HighlightButton(btnMPV)
    End Sub

    Private Sub btnHatch_Click(sender As Object, e As EventArgs) Handles btnHatch.Click
        ShowOnlyPanel(pnlHatchback)
        HighlightButton(btnHatch)
    End Sub

    Private Sub btnHybrid_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        ShowOnlyPanel(pnlHybrid)
        HighlightButton(btnHybrid)
    End Sub

    Private Sub car9_Click(sender As Object, e As EventArgs) Handles car9btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(9, "Toyota Corolla Altis", 1200, "Car", 9)
    End Sub

    Private Sub SelectCar(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        Try
            If RentalTransactionModule.transaction Is Nothing Then
                MessageBox.Show("Transaction is null in SelectCar!")
                Return
            End If

            RentalTransactionModule.SaveForm1CarData(carId, carName, dailyRate, vehicleType, vehicleId)
            MessageBox.Show("Car data saved: " & carName)

            Dim step2Form As New FORMRENTAL_STEP2()
            step2Form.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error in SelectCar: " & ex.Message)
        End Try
    End Sub


    Public Sub SaveForm1CarData(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String, vehicleId As Integer)
        With TransactionData
            .SelectedCarId = carId
            .SelectedCarName = carName
            .DailyRate = dailyRate
            .VehicleType = vehicleType

            .SelectedVehicleId = vehicleId
        End With
    End Sub


    Private Sub car6btn_Click(sender As Object, e As EventArgs)
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(6, "Toyota Fortuner", 800, "Car", 6)
    End Sub

    Private Sub car7btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub car2btn_Click(sender As Object, e As EventArgs) Handles car2btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(2, "Mitsubishi Xpander", 900, "Car", 2)
    End Sub

    Private Sub car4btn_Click(sender As Object, e As EventArgs) Handles car4btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(4, "Suzuki Ertiga", 650, "Car", 4)
    End Sub

    Private Sub car8btn_Click(sender As Object, e As EventArgs) Handles car8btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(8, "Honda Civic", 1100, "Car", 8)
    End Sub

    Private Sub car1btn_Click(sender As Object, e As EventArgs) Handles car1btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(1, "Toyota Vios", 600, "Car", 1)
    End Sub


    Private Sub btnCar6_Click(sender As Object, e As EventArgs) Handles btnCar6.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(6, "Toyota Fortuner", 800, "Car", 6)
    End Sub

    Private Sub car10btn_Click_1(sender As Object, e As EventArgs) Handles car10btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(10, "Toyota Rush", 1300, "Car", 10)
    End Sub

    Private Sub car5btn_Click_1(sender As Object, e As EventArgs) Handles car5btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(5, "Honda City", 700, "Car", 5)
    End Sub

    Private Sub car7btn_Click_1(sender As Object, e As EventArgs) Handles car7btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(7, "Suzuki Swift", 1000, "Car", 7)
    End Sub

    Private Sub car3btn_Click_1(sender As Object, e As EventArgs) Handles car3btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(3, "Toyota Innova", 750, "Car", 3)
    End Sub

    Private Sub LoadNewCars()
        MessageBox.Show("LoadNewCars() is running!")
        Dim query As String = "
        SELECT c.car_id, c.car_category_id, c.make, c.model_name, c.year, c.color,
               c.mileage, c.seating_capacity, rr.rate_per_day, cp.image
        FROM cars c
        JOIN cars_pic cp ON c.car_id = cp.car_id
        JOIN vehicles v ON c.car_id = v.item_id AND v.vehicle_type = 'car'
        JOIN rental_rate rr ON rr.vehicle_id = v.vehicle_id
        WHERE c.car_id > 10
        ORDER BY c.car_id ASC"

        Using conn As New MySqlConnection("server=localhost;database=ridexp;UserId=root;password=;")
            conn.Open()
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If Not reader.HasRows Then
                MessageBox.Show("No new cars found!")
            End If

            While reader.Read()
                Dim imgFullPath As String = Path.Combine(Application.StartupPath, reader("image").ToString())
                MessageBox.Show("Found car: " & reader("model_name").ToString())
                ShowNewCarInCategory(
    reader("car_category_id"),
    reader("car_id"),
    reader("make").ToString(),
    reader("model_name").ToString(),
    reader("year").ToString(),
    reader("color").ToString(),
    reader("mileage").ToString(),
    reader("seating_capacity").ToString(),
    reader("rate_per_day").ToString(),
    imgFullPath
)
            End While
        End Using
    End Sub

    Private Sub ShowNewCarInCategory(categoryId As Integer, carId As Integer, make As String, model As String, year As String,
                                 color As String, mileage As String, seating As String,
                                 rate As String, imgPath As String)

        Dim prefix As String = ""
        Dim parentPanel As Panel = Nothing


        Select Case categoryId
            Case 1
                prefix = "sedan"
                parentPanel = pnlSedan

            Case 2
                prefix = "mpv"
                parentPanel = pnlMpv

            Case 3, 4
                prefix = "suv"
                parentPanel = pnlSuvContent

            Case 5
                prefix = "hatch"
                parentPanel = pnlHatchback

            Case 6
                prefix = "hybrid"
                parentPanel = pnlHybrid
        End Select

        Debug.WriteLine($"[DEBUG] Loading car {make} {model} into {prefix}")

        ' Find available slot
        For i As Integer = 1 To 20
            Dim btn = Me.Controls.Find($"{prefix}{i}btn", True).FirstOrDefault()

            If btn Is Nothing Then
                Debug.WriteLine($"[DEBUG] -> Cannot find {prefix}{i}btn")
                Continue For
            End If

            If btn.Visible = False Then
                Debug.WriteLine($"[DEBUG] -> Found slot {i} for {prefix}")

                ' Set all label values
                SetLabel($"{prefix}make{i}txt", make)
                SetLabel($"{prefix}model{i}txt", model)
                SetLabel($"{prefix}year{i}txt", year)
                SetLabel($"{prefix}color{i}txt", color)
                SetLabel($"{prefix}mileage{i}txt", mileage & " km")
                SetLabel($"{prefix}seatingcapacity{i}txt", seating)
                SetLabel($"{prefix}rentalrate{i}txt", rate & " per day")

                ' Load picture
                Dim pic = CType(Me.Controls.Find($"{prefix}{i}pic", True).FirstOrDefault(), PictureBox)
                If pic IsNot Nothing AndAlso File.Exists(imgPath) Then
                    pic.Image = Image.FromFile(imgPath)
                Else
                    Debug.WriteLine($"[DEBUG] -> Image not found: {imgPath}")
                End If

                ' Show the slot
                btn.Visible = True
                btn.Tag = carId

                ' Show the main category panel
                If parentPanel IsNot Nothing Then parentPanel.Visible = True

                ' Show the correct container (panel1sedan, panel2sedan, etc.)
                Dim containerPanel = TryCast(btn.Parent, Panel)
                If containerPanel IsNot Nothing Then containerPanel.Visible = True

                ' Attach dynamic click handler
                RemoveHandler btn.Click, AddressOf DynamicCarButton_Click
                AddHandler btn.Click, AddressOf DynamicCarButton_Click

                Exit For
            End If
        Next
    End Sub


    Private Sub SetLabel(name As String, text As String)
        Dim lbl = Me.Controls.Find(name, True).FirstOrDefault()
        If lbl IsNot Nothing Then
            CType(lbl, Label).Text = text
            lbl.Visible = True
        Else
            Debug.WriteLine($"[DEBUG] -> Cannot find label {name}")
        End If
    End Sub

    Private Sub DynamicCarButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim carId As Integer = CInt(btn.Tag) ' ✅ Real carId from the DB

        ' Determine prefix (for finding labels)
        Dim prefix As String = ""
        If btn.Name.StartsWith("sedan") Then prefix = "sedan"
        If btn.Name.StartsWith("suv") Then prefix = "suv"
        If btn.Name.StartsWith("mpv") Then prefix = "mpv"
        If btn.Name.StartsWith("hatch") Then prefix = "hatch"
        If btn.Name.StartsWith("hybrid") Then prefix = "hybrid"

        ' Find labels using the slot index
        Dim numPart As String = New String(btn.Name.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim slotIndex As Integer = Integer.Parse(numPart)

        Dim makeLbl = CType(Me.Controls.Find($"{prefix}make{slotIndex}txt", True).FirstOrDefault(), Label)
        Dim modelLbl = CType(Me.Controls.Find($"{prefix}model{slotIndex}txt", True).FirstOrDefault(), Label)
        Dim rateLbl = CType(Me.Controls.Find($"{prefix}rentalrate{slotIndex}txt", True).FirstOrDefault(), Label)

        If makeLbl Is Nothing OrElse modelLbl Is Nothing OrElse rateLbl Is Nothing Then
            MessageBox.Show("Error: Missing car info for this button!")
            Exit Sub
        End If

        Dim carName As String = $"{makeLbl.Text} {modelLbl.Text}"
        Dim dailyRate As Decimal = Decimal.Parse(rateLbl.Text.Split(" "c)(0))

        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If

        ' ✅ Pass the real carId now
        SelectCar(carId, carName, dailyRate, "Car", carId)
    End Sub

End Class