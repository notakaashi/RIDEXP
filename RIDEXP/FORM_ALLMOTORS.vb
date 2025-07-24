Imports MySql.Data.MySqlClient

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
            Dim query As String = "SELECT model, make, color, mileage, year
                                FROM motors 
                                WHERE motor_id = @motorId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@motorId", motorId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Set data based on car ID
                        Select Case motorId
                            Case 1
                                If Not IsDBNull(reader("model")) Then model1txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make1txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color1txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage1txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear1.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car1img)

                            Case 2
                                If Not IsDBNull(reader("model")) Then model2txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make2txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color2txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage2txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear2.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car2img)

                            Case 3
                                If Not IsDBNull(reader("model")) Then lblmodel3.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then lblmake3.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then lblcolor3.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then lblmileage3.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear3.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car3img)

                            Case 4
                                If Not IsDBNull(reader("model")) Then model4txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make4txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color4txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage4txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear4.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car4img)

                            Case 5
                                If Not IsDBNull(reader("model")) Then model5txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make5txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color5txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage5txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear5.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car5img)

                            Case 6
                                If Not IsDBNull(reader("model")) Then make6txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then model6txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color6txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage6txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear6.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), imgCar6)

                            Case 7
                                If Not IsDBNull(reader("model")) Then model7txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make7txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color7txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage7txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear7.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car7img)

                            Case 8
                                If Not IsDBNull(reader("model")) Then model8txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make8txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color8txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage8txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear8.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car8img)

                            Case 9
                                If Not IsDBNull(reader("model")) Then model9txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make9txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color9txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage9txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear9.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car9img)

                            Case 10
                                If Not IsDBNull(reader("model")) Then model10txt.Text = reader("model").ToString()
                                If Not IsDBNull(reader("make")) Then make10txt.Text = reader("make").ToString()
                                If Not IsDBNull(reader("color")) Then color10txt.Text = reader("color").ToString()
                                If Not IsDBNull(reader("mileage")) Then mileage10txt.Text = reader("mileage").ToString() & " km"
                                If Not IsDBNull(reader("year")) Then lblyear10.Text = reader("year").ToString()
                                'If Not IsDBNull(reader("image")) Then LoadCarImage(reader("image").ToString(), car10img)
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
End Class