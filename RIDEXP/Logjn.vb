Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data

Public Class Logjn
    Public connectionString As String = "Server=localhost;Database=ridexp;User=root;Password=;"
    Private Sub Logjn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeTimer.Start()
    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            FadeTimer.Stop()
        End If
    End Sub


    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SIGNUP.Show()
        Me.Close()
        Me.Opacity = 0
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub signinbtn_Click(sender As Object, e As EventArgs) Handles signinbtn.Click
        If String.IsNullOrWhiteSpace(usertxt.Text) Or String.IsNullOrWhiteSpace(passwordtxt.Text) Then
            MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If AuthenticateUser(usertxt.Text, passwordtxt.Text) Then
            MessageBox.Show("Sign in successful! Welcome to RidExp!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim hashedPassword As String = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passwordtxt.Text))).Replace("-", "").ToLower()
                Dim query As String = "SELECT COUNT(*) FROM user WHERE username = @username AND password_hash = @password"

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", hashedPassword)

                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private passwordVisible As Boolean = False
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        passwordVisible = Not passwordVisible

        If passwordVisible Then
            passwordtxt.PasswordChar = ChrW(0)
            Label6.Text = "Hide"
        Else
            passwordtxt.PasswordChar = "*"c
            Label6.Text = "Show"
        End If
    End Sub
End Class