Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data

Public Class Logjn
    Public connectionString As String = "Server=localhost;Database=ridexp;User=root;Password=;"
    Private Sub Logjn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Logjn_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Me.Opacity = 0
            FadeTimer.Start()
        End If
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
            userlogged = usertxt.Text
            MessageBox.Show("Sign in successful! Welcome to RidExp!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loggedin = True
            Me.Close()


            If userRole = 1 Then
                MessageBox.Show("Welcome Admin! Opening admin panel...")
                FORM_ADMIN.Show()
                Form1.Hide()
                Form1.RefreshLoginState()
            Else
                Form1.RefreshLoginState()
            End If
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT user_id, role_id FROM user WHERE username = @username AND password_hash = SHA2(@password, 256)"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", password)

                    Using reader = command.ExecuteReader()
                        If reader.Read() Then
                            userId = Convert.ToInt32(reader("user_id"))
                            userRole = Convert.ToInt32(reader("role_id"))
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return False
    End Function

    Private passwordVisible As Boolean = False


    Private Sub pbxShow_Click(sender As Object, e As EventArgs) Handles pbxShow.Click
        passwordVisible = Not passwordVisible

        If passwordVisible Then
            passwordtxt.PasswordChar = ChrW(0)
            pbxShow.Image = My.Resources.Resource1.hide
        Else
            passwordtxt.PasswordChar = "*"c
            pbxShow.Image = My.Resources.Resource1.show
        End If
    End Sub
End Class