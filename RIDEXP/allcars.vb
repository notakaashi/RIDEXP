Imports MySql.Data.MySqlClient
Imports System.IO

Public Class allcars
    Private Sub allcars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlAllCarsContent.BringToFront()
        pnlAllCarsContent.Location = New Point(54, 185)
        Me.Opacity = 0
        FadeTimer.Start()

        ' Load all car data
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
        Catch ex As Exception
            MessageBox.Show("Error loading car data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSingleCar(conn As MySqlConnection, carId As Integer)
        Try
            Dim query As String = "SELECT c.model_name, c.make, c.color, c.mileage, c.seating_capacity, cp.image
                                FROM cars c
                                LEFT JOIN cars_pic cp ON c.car_id = cp.car_id 
                                WHERE c.car_id = @carId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@carId", carId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Set data based on car ID
                        Select Case carId
                            Case 1
                                If Not IsDBNull(reader("model_name")) Then model1txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make1txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color1txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage1txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity1txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car1img)

                            Case 2
                                If Not IsDBNull(reader("model_name")) Then model2txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make2txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color2txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage2txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity2txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car2img)

                            Case 3
                                If Not IsDBNull(reader("model_name")) Then model3txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make3txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color3txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage3txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity3txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car3img)

                            Case 4
                                If Not IsDBNull(reader("model_name")) Then model4txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make4txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color4txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage4txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity4txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car4img)

                            'Case 5
                            '    If Not IsDBNull(reader("model_name")) Then model5txt.Text = reader("model_name").ToString()
                            '    If Not IsDBNull(reader("make")) Then make5txt.Text = reader("make").ToString()
                            '    If Not IsDBNull(reader("color")) Then color5txt.Text = reader("color").ToString()
                            '    If Not IsDBNull(reader("mileage")) Then mileage5txt.Text = reader("mileage").ToString() & " km"
                            '    If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity5txt.Text = reader("seating_capacity").ToString()
                            '    If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car5PictureBox)

                            Case 6
                                If Not IsDBNull(reader("model_name")) Then model6txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make6txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color6txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage6txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatcapacity6txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car6img)

                            Case 7
                                If Not IsDBNull(reader("model_name")) Then model7txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make7txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color7txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage7txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity7txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car7img)

                            Case 8
                                If Not IsDBNull(reader("model_name")) Then model8txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make8txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color8txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage8txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity8txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car8img)

                            Case 9
                                If Not IsDBNull(reader("model_name")) Then model9txt.Text = reader("model_name").ToString()
                                If Not IsDBNull(reader("make")) Then make9txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color9txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage9txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity9txt.Text = reader("seating_capacity").ToString()
                                If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car9img)

                                'Case 10
                                '    If Not IsDBNull(reader("model_name")) Then model10txt.Text = reader("model_name").ToString()
                                '    If Not IsDBNull(reader("make")) Then make10txt.Text = reader("make").ToString()
                                '    If Not IsDBNull(reader("color")) Then color10txt.Text = reader("color").ToString()
                                '    If Not IsDBNull(reader("mileage")) Then mileage10txt.Text = reader("mileage").ToString() & " km"
                                '    If Not IsDBNull(reader("seating_capacity")) Then seatingcapacity10txt.Text = reader("seating_capacity").ToString()
                                '    If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car10PictureBox)
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
                ' Get filename without extension from the database filepath
                Dim imageNameWithoutExt As String = IO.Path.GetFileNameWithoutExtension(imageName)
                ' Load image from resources using the filename
                Dim resImage = My.Resources.ResourceManager.GetObject(imageNameWithoutExt)

                If resImage IsNot Nothing Then
                    pictureBox.Image = CType(resImage, Image)
                Else
                    ' Set a default image or leave empty if resource not found
                    pictureBox.Image = Nothing
                End If
            End If
        Catch ex As Exception
            ' Image loading failed, set to nothing or default image
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
        Me.Opacity += 0.05
        If Me.Opacity >= 1 Then FadeTimer.Stop()
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
        SelectCar(9, "Toyota Corolla Altis", 1200, "Car")
    End Sub

    Private Sub SelectCar(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String)
        Try
            If RentalTransactionModule.transaction Is Nothing Then
                MessageBox.Show("Transaction is null in SelectCar!")
                Return
            End If

            RentalTransactionModule.SaveForm1Data(carId, carName, dailyRate, vehicleType)
            MessageBox.Show("Car data saved: " & carName)

            Dim step2Form As New FORMRENTAL_STEP2()
            step2Form.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error in SelectCar: " & ex.Message)
        End Try
    End Sub


    Public Sub SaveForm1Data(carId As Integer, carName As String, dailyRate As Decimal, vehicleType As String)
        With TransactionData
            .SelectedCarId = carId
            .SelectedCarName = carName
            .DailyRate = dailyRate
        End With
    End Sub

    Public Function ValidateTransactionData() As Boolean
        With TransactionData
            If .SelectedCarId <= 0 Then
                MessageBox.Show("Please select a car.")
                Return False
            End If

            If .CustomerId <= 0 Then
                MessageBox.Show("Customer ID is required.")
                Return False
            End If

            If .PickupDate = Nothing OrElse .ReturnDate = Nothing Then
                MessageBox.Show("Please select pickup and return dates.")
                Return False
            End If

            If .PickupDate >= .ReturnDate Then
                MessageBox.Show("Return date must be after pickup date.")
                Return False
            End If

            If String.IsNullOrWhiteSpace(.PickupPlace) OrElse String.IsNullOrWhiteSpace(.ReturnPlace) Then
                MessageBox.Show("Pickup and return places are required.")
                Return False
            End If

            If .TotalAmount <= 0 Then
                MessageBox.Show("Invalid rental amount.")
                Return False
            End If
        End With

        Return True
    End Function

    Private Sub car6btn_Click(sender As Object, e As EventArgs) Handles car6btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(6, "Toyota Fortuner", 800, "Car")
    End Sub

    Private Sub car7btn_Click(sender As Object, e As EventArgs) Handles car7btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(7, "Suzuki Swift", 1000, "Car")
    End Sub

    Private Sub car2btn_Click(sender As Object, e As EventArgs) Handles car2btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(2, "Mitsubishi Xpander", 900, "Car")
    End Sub

    Private Sub car3btn_Click(sender As Object, e As EventArgs) Handles car3btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(3, "Toyota Innova", 750, "Car")
    End Sub

    Private Sub car4btn_Click(sender As Object, e As EventArgs) Handles car4btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(4, "Suzuki Ertiga", 650, "Car")
    End Sub

    Private Sub car8btn_Click(sender As Object, e As EventArgs) Handles car8btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(8, "Honda Civic", 1100, "Car")
    End Sub

    Private Sub car1btn_Click(sender As Object, e As EventArgs) Handles car1btn.Click
        If Not StartTransaction() Then
            MessageBox.Show("Failed to start transaction. Please try again.")
            Close()
            Return
        End If
        SelectCar(1, "Toyota Vios", 600, "Car")
    End Sub
End Class