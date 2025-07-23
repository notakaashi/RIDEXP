<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vehicle_type
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Button1 = New Button()
        Panel1 = New Panel()
        Label2 = New Label()
        Button2 = New Button()
        FadeTimer = New Timer(components)
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Reesha", 25.8000011F)
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(146, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(618, 53)
        Label1.TabIndex = 0
        Label1.Text = "CHOOSE VEHICLE TYPE"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Reesha", 25.8000011F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(146, 208)
        Button1.Name = "Button1"
        Button1.Size = New Size(267, 87)
        Button1.TabIndex = 1
        Button1.Text = "CARS"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel1.Controls.Add(Label2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(908, 39)
        Panel1.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Akira Expanded", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(12, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(34, 24)
        Label2.TabIndex = 6
        Label2.Text = "X"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(454, 208)
        Button2.Name = "Button2"
        Button2.Size = New Size(310, 87)
        Button2.TabIndex = 4
        Button2.Text = "MOTORCYCLES"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 25
        ' 
        ' Vehicle_type
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(908, 404)
        Controls.Add(Button2)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Vehicle_type"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = "Vehicle_type"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents FadeTimer As Timer
End Class
