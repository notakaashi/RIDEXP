Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class SIGNUP

    Public connectionString As String = "Server=localhost;Database=ridexp;User=root;Password=;"
    Private Sub SIGNUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeTimer.Start()
        dobtxt.PlaceholderText = "Birthdate (YYYY-MM-DD)"
        licenseexptxt.PlaceholderText = "Licence Expiry (YYYY-MM-DD)"
        fnametxt.PlaceholderText = "First Name"
        lnametxt.PlaceholderText = "Last Name"
        emailtxt.PlaceholderText = "Email Address"
        phonenumbertxt.PlaceholderText = "Phone Number"
        addresstxt.PlaceholderText = "Address"
        licensenumbertxt.PlaceholderText = "License Number"
        usertxt.PlaceholderText = "Username"
        passwordtxt.PlaceholderText = "Password"

    End Sub

    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs) Handles FadeTimer.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            FadeTimer.Stop()
        End If
    End Sub


    Private Sub btnHOME_Click(sender As Object, e As EventArgs)
        Form1.Show()
        Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
        Me.Opacity = 0
    End Sub

    Private Sub signupbtn_Click(sender As Object, e As EventArgs) Handles signupbtn.Click
        If String.IsNullOrWhiteSpace(fnametxt.Text) Or
          String.IsNullOrWhiteSpace(lnametxt.Text) Or
          String.IsNullOrWhiteSpace(emailtxt.Text) Or
          String.IsNullOrWhiteSpace(usertxt.Text) Or
          String.IsNullOrWhiteSpace(passwordtxt.Text) Then
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If InsertUserData() Then
            MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm()
        Else
            MessageBox.Show("Sign up failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function InsertUserData() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using transaction As MySqlTransaction = connection.BeginTransaction()
                    Try
                        ' 1. INSERT USER FIRST so we can get the generated user_id
                        Dim userQuery As String = "INSERT INTO user (username, password_hash, role_id) VALUES (@username, SHA2(@password_hash, 256), @role_id); SELECT LAST_INSERT_ID();"
                        Dim userId As Integer

                        Using userCmd As New MySqlCommand(userQuery, connection, transaction)
                            userCmd.Parameters.AddWithValue("@username", usertxt.Text)
                            userCmd.Parameters.AddWithValue("@password_hash", passwordtxt.Text)
                            userCmd.Parameters.AddWithValue("@role_id", 2)

                            ' 2. GET the auto-incremented user_id
                            userId = Convert.ToInt32(userCmd.ExecuteScalar())

                            ' 3. Store to global module variable if needed
                            Module1.userId = userId ' <--- You said this exists already
                        End Using

                        ' 4. INSERT CUSTOMER using retrieved user_id
                        Dim customerQuery As String = "INSERT INTO customers (first_name, last_name, date_of_birth, email, phone, address, license_number, license_expiry, created_at, user_id) VALUES (@first_name, @last_name, @date_of_birth, @email, @phone, @address, @license_number, @license_expiry, CURDATE(), @user_id)"

                        Using customerCmd As New MySqlCommand(customerQuery, connection, transaction)
                            customerCmd.Parameters.AddWithValue("@first_name", fnametxt.Text)
                            customerCmd.Parameters.AddWithValue("@last_name", lnametxt.Text)
                            customerCmd.Parameters.AddWithValue("@date_of_birth", dobtxt.Text)
                            customerCmd.Parameters.AddWithValue("@email", emailtxt.Text)
                            customerCmd.Parameters.AddWithValue("@phone", phonenumbertxt.Text)
                            customerCmd.Parameters.AddWithValue("@address", addresstxt.Text)
                            customerCmd.Parameters.AddWithValue("@license_number", licensenumbertxt.Text)
                            customerCmd.Parameters.AddWithValue("@license_expiry", licenseexptxt.Text)

                            customerCmd.Parameters.AddWithValue("@user_id", userId)

                            customerCmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        Return True

                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub ClearForm()
        fnametxt.Clear()
        lnametxt.Clear()
        emailtxt.Clear()
        usertxt.Clear()
        passwordtxt.Clear()
        phonenumbertxt.Clear()
        addresstxt.Clear()
        licensenumbertxt.Clear()
        licenseexptxt.Clear()
        dobtxt.Clear()
    End Sub
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