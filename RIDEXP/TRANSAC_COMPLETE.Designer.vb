<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TRANSAC_COMPLETE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label4 = New Label()
        Label3 = New Label()
        Panel3 = New Panel()
        Label5 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.Font = New Font("Futura Hv BT", 13.8F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(411, 306)
        Button1.Name = "Button1"
        Button1.Size = New Size(174, 34)
        Button1.TabIndex = 0
        Button1.Text = "DOWNLOAD"
        Button1.UseVisualStyleBackColor = False
        Button1.UseWaitCursor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Futura Hv BT", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(89, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(481, 39)
        Label1.TabIndex = 1
        Label1.Text = "THANK YOU FOR CHOOSING"
        Label1.TextAlign = ContentAlignment.TopCenter
        Label1.UseWaitCursor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Reesha", 48F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(75, 48)
        Label2.Name = "Label2"
        Label2.Size = New Size(519, 77)
        Label2.TabIndex = 2
        Label2.Text = "RIDEXPRESS!"
        Label2.TextAlign = ContentAlignment.TopCenter
        Label2.UseWaitCursor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(191, 55)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(642, 148)
        Panel1.TabIndex = 3
        Panel1.UseWaitCursor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(191, 215)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(642, 78)
        Panel2.TabIndex = 4
        Panel2.UseWaitCursor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(69, 17)
        Label4.Name = "Label4"
        Label4.Size = New Size(526, 22)
        Label4.TabIndex = 2
        Label4.Text = "Drive safely, and we look forward to serving you again!"
        Label4.TextAlign = ContentAlignment.TopCenter
        Label4.UseWaitCursor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(185, 50)
        Label3.Name = "Label3"
        Label3.Size = New Size(282, 16)
        Label3.TabIndex = 1
        Label3.Text = "CLICK HERE TO DOWNLOAD YOUR RECEIPT"
        Label3.TextAlign = ContentAlignment.TopCenter
        Label3.UseWaitCursor = True
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel3.Controls.Add(Label5)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Margin = New Padding(3, 2, 3, 2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1025, 33)
        Panel3.TabIndex = 5
        Panel3.UseWaitCursor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Futura XBlk BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(8, 4)
        Label5.Name = "Label5"
        Label5.Size = New Size(28, 26)
        Label5.TabIndex = 3
        Label5.Text = "X"
        Label5.TextAlign = ContentAlignment.TopCenter
        Label5.UseWaitCursor = True
        ' 
        ' TRANSAC_COMPLETE
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1025, 359)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.None
        Name = "TRANSAC_COMPLETE"
        StartPosition = FormStartPosition.CenterScreen
        Text = "RIDEXPRESS!"
        UseWaitCursor = True
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
End Class
