<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logjn
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
        Label5 = New Label()
        Button2 = New Button()
        Label4 = New Label()
        signinbtn = New Button()
        Label3 = New Label()
        passwordtxt = New TextBox()
        Label2 = New Label()
        usertxt = New TextBox()
        Label1 = New Label()
        Label7 = New Label()
        Panel1 = New Panel()
        FadeTimer = New Timer(components)
        pbxShow = New PictureBox()
        Panel1.SuspendLayout()
        CType(pbxShow, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label5.Location = New Point(151, 409)
        Label5.Name = "Label5"
        Label5.Size = New Size(360, 36)
        Label5.TabIndex = 8
        Label5.Text = "_______________________"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Reesha", 22.1999989F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(198, 488)
        Button2.Name = "Button2"
        Button2.Size = New Size(213, 61)
        Button2.TabIndex = 7
        Button2.Text = "SIGN UP"
        Button2.TextAlign = ContentAlignment.TopCenter
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Futura Hv BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label4.Location = New Point(185, 457)
        Label4.Name = "Label4"
        Label4.Size = New Size(261, 20)
        Label4.TabIndex = 6
        Label4.Text = "Click here to create an account"
        ' 
        ' signinbtn
        ' 
        signinbtn.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        signinbtn.FlatStyle = FlatStyle.Flat
        signinbtn.Font = New Font("Reesha", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        signinbtn.ForeColor = Color.White
        signinbtn.Location = New Point(198, 371)
        signinbtn.Name = "signinbtn"
        signinbtn.Size = New Size(213, 61)
        signinbtn.TabIndex = 5
        signinbtn.Text = "SIGN IN"
        signinbtn.TextAlign = ContentAlignment.TopCenter
        signinbtn.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label3.Location = New Point(133, 273)
        Label3.Name = "Label3"
        Label3.Size = New Size(141, 27)
        Label3.TabIndex = 4
        Label3.Text = "PASSWORD"
        ' 
        ' passwordtxt
        ' 
        passwordtxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        passwordtxt.Location = New Point(133, 303)
        passwordtxt.Name = "passwordtxt"
        passwordtxt.PasswordChar = "*"c
        passwordtxt.Size = New Size(364, 40)
        passwordtxt.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(133, 169)
        Label2.Name = "Label2"
        Label2.Size = New Size(138, 27)
        Label2.TabIndex = 2
        Label2.Text = "USERNAME"
        ' 
        ' usertxt
        ' 
        usertxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        usertxt.Location = New Point(133, 212)
        usertxt.Name = "usertxt"
        usertxt.Size = New Size(364, 40)
        usertxt.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Reesha", 48F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(151, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(352, 96)
        Label1.TabIndex = 0
        Label1.Text = "SIGN IN"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(14, 12)
        Label7.Name = "Label7"
        Label7.Size = New Size(34, 32)
        Label7.TabIndex = 9
        Label7.Text = "X"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel1.Controls.Add(Label7)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(611, 64)
        Panel1.TabIndex = 10
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 25
        ' 
        ' pbxShow
        ' 
        pbxShow.Image = My.Resources.Resources.RIDEXPRESS__10_
        pbxShow.Location = New Point(506, 312)
        pbxShow.Name = "pbxShow"
        pbxShow.Size = New Size(42, 21)
        pbxShow.SizeMode = PictureBoxSizeMode.StretchImage
        pbxShow.TabIndex = 12
        pbxShow.TabStop = False
        ' 
        ' Logjn
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(611, 579)
        Controls.Add(Panel1)
        Controls.Add(Button2)
        Controls.Add(Label4)
        Controls.Add(Label1)
        Controls.Add(signinbtn)
        Controls.Add(usertxt)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(passwordtxt)
        Controls.Add(Label5)
        Controls.Add(pbxShow)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "Logjn"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = "Logjn"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(pbxShow, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents signinbtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents passwordtxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents usertxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FadeTimer As Timer
    Friend WithEvents pbxShow As PictureBox
End Class
