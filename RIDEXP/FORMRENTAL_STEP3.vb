Imports MySql.Data.MySqlClient

Public Class FORMRENTAL_STEP3
    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=ridexp")

    Private Sub LoadCarInfo(carId As Integer)
        Try
            conn.Open()

            Dim cmd As New MySqlCommand("
            SELECT 
                c.mileage,
                c.seating_capacity,
                ft.fuel_type,
                tt.transmission_type,
                cp.image
            FROM 
                cars c
            JOIN car_category cc ON c.car_category_id = cc.car_category_id
            LEFT JOIN fuel_types ft ON cc.fuel_id = ft.fuel_id
            LEFT JOIN transmission_types tt ON cc.transmission_id = tt.transmission_id
            LEFT JOIN cars_pic cp ON c.car_id = cp.car_id
            WHERE c.car_id = @carId", conn)

            cmd.Parameters.AddWithValue("@carId", carId)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                mileagetxt.Text = reader("mileage").ToString()
                seatcapacitytxt.Text = reader("seating_capacity").ToString()
                fueltxt.Text = reader("fuel_type").ToString()
                transmissiontxt.Text = reader("transmission_type").ToString()

                ' Get image name from DB and fetch it from resources
                If Not IsDBNull(reader("image")) Then
                    Dim imageName As String = IO.Path.GetFileNameWithoutExtension(reader("image").ToString())
                    Dim resImage = My.Resources.ResourceManager.GetObject(imageName)

                    If resImage IsNot Nothing Then
                        PictureBox4.Image = CType(resImage, Image)
                    Else
                        PictureBox4.Image = Nothing
                        MessageBox.Show("Image '" & imageName & "' not found in resources.")
                    End If
                Else
                    PictureBox4.Image = Nothing
                End If

                PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
            Else
                MessageBox.Show("Car not found.")
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub



    Private Sub FORMRENTAL_STEP3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCarInfo(3)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FORMRENTAL_STEP4.Show()
        Me.Close()
    End Sub

    Private Sub homelbl_Click(sender As Object, e As EventArgs) Handles homelbl.Click
        Form1.Show()
        Me.Close()
    End Sub


End Class