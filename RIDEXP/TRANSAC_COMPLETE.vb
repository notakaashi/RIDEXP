Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw

Public Class TRANSAC_COMPLETE
    ' Store the rental ID when the form loads
    Public Property RentalId As Integer = 0

    Private Sub TRANSAC_COMPLETE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RentalId > 0 Then
            Label1.Text = $"Rental completed successfully! Rental ID: {RentalId}"
        Else
            Label1.Text = "Transaction completed successfully!"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Invoice generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class