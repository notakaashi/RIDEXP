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
                tt.transmission_type
            FROM 
                cars c
            JOIN car_category cc ON c.car_category_id = cc.car_category_id
            LEFT JOIN fuel_types ft ON cc.fuel_id = ft.fuel_id
            LEFT JOIN transmission_types tt ON cc.transmission_id = tt.transmission_id
            WHERE c.car_id = @carId", conn)

            cmd.Parameters.AddWithValue("@carId", carId)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                mileagetxt.Text = reader("mileage").ToString()
                seatcapacitytxt.Text = reader("seating_capacity").ToString()
                fueltxt.Text = reader("fuel_type").ToString()
                transmissiontxt.Text = reader("transmission_type").ToString()
            Else
                MessageBox.Show("Car not found.")
            End If

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        PictureBox4.Image = My.Resources.vios
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub FORMRENTAL_STEP3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCarInfo(1)
    End Sub
End Class