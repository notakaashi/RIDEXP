<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SIGNUP
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
        Panel1 = New Panel()
        Panel10 = New Panel()
        passwordtxt = New TextBox()
        Panel9 = New Panel()
        usertxt = New TextBox()
        Panel6 = New Panel()
        dobtxt = New TextBox()
        Panel5 = New Panel()
        lnametxt = New TextBox()
        Panel4 = New Panel()
        fnametxt = New TextBox()
        Label9 = New Label()
        pbxShow = New PictureBox()
        signupbtn = New Button()
        Panel2 = New Panel()
        Panel7 = New Panel()
        addresstxt = New TextBox()
        Panel11 = New Panel()
        emailtxt = New TextBox()
        Panel12 = New Panel()
        phonenumbertxt = New TextBox()
        Panel13 = New Panel()
        licensenumbertxt = New TextBox()
        Panel14 = New Panel()
        licenseexptxt = New TextBox()
        Panel3 = New Panel()
        Label1 = New Label()
        FadeTimer = New Timer(components)
        Panel1.SuspendLayout()
        Panel10.SuspendLayout()
        Panel9.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        CType(pbxShow, ComponentModel.ISupportInitialize).BeginInit()
        Panel7.SuspendLayout()
        Panel11.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        Panel14.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Panel10)
        Panel1.Controls.Add(Panel9)
        Panel1.Controls.Add(Panel6)
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(pbxShow)
        Panel1.Controls.Add(signupbtn)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel7)
        Panel1.Controls.Add(Panel11)
        Panel1.Controls.Add(Panel12)
        Panel1.Controls.Add(Panel13)
        Panel1.Controls.Add(Panel14)
        Panel1.Location = New Point(84, 91)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(873, 512)
        Panel1.TabIndex = 0
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = SystemColors.Control
        Panel10.Controls.Add(passwordtxt)
        Panel10.Location = New Point(428, 382)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(336, 58)
        Panel10.TabIndex = 33
        ' 
        ' passwordtxt
        ' 
        passwordtxt.BackColor = SystemColors.Control
        passwordtxt.BorderStyle = BorderStyle.None
        passwordtxt.Font = New Font("Futura Lt BT", 12F)
        passwordtxt.Location = New Point(22, 18)
        passwordtxt.Name = "passwordtxt"
        passwordtxt.PasswordChar = "*"c
        passwordtxt.RightToLeft = RightToLeft.No
        passwordtxt.Size = New Size(292, 24)
        passwordtxt.TabIndex = 11
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = SystemColors.Control
        Panel9.Controls.Add(usertxt)
        Panel9.Location = New Point(70, 382)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(336, 58)
        Panel9.TabIndex = 33
        ' 
        ' usertxt
        ' 
        usertxt.BackColor = SystemColors.Control
        usertxt.BorderStyle = BorderStyle.None
        usertxt.Font = New Font("Futura Lt BT", 12F)
        usertxt.Location = New Point(22, 18)
        usertxt.Name = "usertxt"
        usertxt.Size = New Size(292, 24)
        usertxt.TabIndex = 9
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.Control
        Panel6.Controls.Add(dobtxt)
        Panel6.Location = New Point(70, 211)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(336, 58)
        Panel6.TabIndex = 30
        ' 
        ' dobtxt
        ' 
        dobtxt.BackColor = SystemColors.Control
        dobtxt.BorderStyle = BorderStyle.None
        dobtxt.Font = New Font("Futura Lt BT", 12F)
        dobtxt.Location = New Point(22, 18)
        dobtxt.Name = "dobtxt"
        dobtxt.Size = New Size(292, 24)
        dobtxt.TabIndex = 25
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Control
        Panel5.Controls.Add(lnametxt)
        Panel5.Location = New Point(428, 135)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(336, 58)
        Panel5.TabIndex = 29
        ' 
        ' lnametxt
        ' 
        lnametxt.BackColor = SystemColors.Control
        lnametxt.BorderStyle = BorderStyle.None
        lnametxt.Font = New Font("Futura Lt BT", 12F)
        lnametxt.Location = New Point(22, 18)
        lnametxt.Name = "lnametxt"
        lnametxt.Size = New Size(292, 24)
        lnametxt.TabIndex = 5
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Control
        Panel4.Controls.Add(fnametxt)
        Panel4.Location = New Point(70, 135)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(336, 58)
        Panel4.TabIndex = 28
        ' 
        ' fnametxt
        ' 
        fnametxt.BackColor = SystemColors.Control
        fnametxt.BorderStyle = BorderStyle.None
        fnametxt.Font = New Font("Futura Lt BT", 12F)
        fnametxt.Location = New Point(22, 18)
        fnametxt.Name = "fnametxt"
        fnametxt.Size = New Size(292, 24)
        fnametxt.TabIndex = 3
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Reesha", 30F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label9.Location = New Point(27, 34)
        Label9.Name = "Label9"
        Label9.Size = New Size(655, 60)
        Label9.TabIndex = 3
        Label9.Text = "CREATE AN ACCOUNT"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pbxShow
        ' 
        pbxShow.Image = My.Resources.Resources.RIDEXPRESS__10_
        pbxShow.Location = New Point(779, 406)
        pbxShow.Name = "pbxShow"
        pbxShow.Size = New Size(42, 21)
        pbxShow.SizeMode = PictureBoxSizeMode.StretchImage
        pbxShow.TabIndex = 27
        pbxShow.TabStop = False
        ' 
        ' signupbtn
        ' 
        signupbtn.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        signupbtn.FlatStyle = FlatStyle.Flat
        signupbtn.Font = New Font("Reesha", 28.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        signupbtn.ForeColor = Color.White
        signupbtn.Location = New Point(213, 760)
        signupbtn.Name = "signupbtn"
        signupbtn.Size = New Size(404, 95)
        signupbtn.TabIndex = 19
        signupbtn.Text = "SIGN UP"
        signupbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(272, 925)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(250, 71)
        Panel2.TabIndex = 18
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = SystemColors.Control
        Panel7.Controls.Add(addresstxt)
        Panel7.Location = New Point(70, 297)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(694, 58)
        Panel7.TabIndex = 31
        ' 
        ' addresstxt
        ' 
        addresstxt.BackColor = SystemColors.Control
        addresstxt.BorderStyle = BorderStyle.None
        addresstxt.Font = New Font("Futura Lt BT", 12F)
        addresstxt.Location = New Point(22, 18)
        addresstxt.Name = "addresstxt"
        addresstxt.Size = New Size(650, 24)
        addresstxt.TabIndex = 15
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = SystemColors.Control
        Panel11.Controls.Add(emailtxt)
        Panel11.Location = New Point(70, 468)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(336, 58)
        Panel11.TabIndex = 33
        ' 
        ' emailtxt
        ' 
        emailtxt.BackColor = SystemColors.Control
        emailtxt.BorderStyle = BorderStyle.None
        emailtxt.Font = New Font("Futura Lt BT", 12F)
        emailtxt.Location = New Point(22, 18)
        emailtxt.Name = "emailtxt"
        emailtxt.Size = New Size(292, 24)
        emailtxt.TabIndex = 7
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = SystemColors.Control
        Panel12.Controls.Add(phonenumbertxt)
        Panel12.Location = New Point(428, 468)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(336, 58)
        Panel12.TabIndex = 34
        ' 
        ' phonenumbertxt
        ' 
        phonenumbertxt.BackColor = SystemColors.Control
        phonenumbertxt.BorderStyle = BorderStyle.None
        phonenumbertxt.Font = New Font("Futura Lt BT", 12F)
        phonenumbertxt.Location = New Point(22, 18)
        phonenumbertxt.Name = "phonenumbertxt"
        phonenumbertxt.Size = New Size(292, 24)
        phonenumbertxt.TabIndex = 13
        ' 
        ' Panel13
        ' 
        Panel13.BackColor = SystemColors.Control
        Panel13.Controls.Add(licensenumbertxt)
        Panel13.Location = New Point(70, 558)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(694, 58)
        Panel13.TabIndex = 32
        ' 
        ' licensenumbertxt
        ' 
        licensenumbertxt.BackColor = SystemColors.Control
        licensenumbertxt.BorderStyle = BorderStyle.None
        licensenumbertxt.Font = New Font("Futura Lt BT", 12F)
        licensenumbertxt.Location = New Point(22, 18)
        licensenumbertxt.Name = "licensenumbertxt"
        licensenumbertxt.Size = New Size(650, 24)
        licensenumbertxt.TabIndex = 21
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = SystemColors.Control
        Panel14.Controls.Add(licenseexptxt)
        Panel14.Location = New Point(70, 645)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(694, 58)
        Panel14.TabIndex = 33
        ' 
        ' licenseexptxt
        ' 
        licenseexptxt.BackColor = SystemColors.Control
        licenseexptxt.BorderStyle = BorderStyle.None
        licenseexptxt.Font = New Font("Futura Lt BT", 12F)
        licenseexptxt.Location = New Point(22, 18)
        licenseexptxt.Name = "licenseexptxt"
        licenseexptxt.Size = New Size(650, 24)
        licenseexptxt.TabIndex = 23
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1039, 49)
        Panel3.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(14, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(31, 29)
        Label1.TabIndex = 5
        Label1.Text = "X"
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 25
        ' 
        ' SIGNUP
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1039, 647)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "SIGNUP"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(pbxShow, ComponentModel.ISupportInitialize).EndInit()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel13.ResumeLayout(False)
        Panel13.PerformLayout()
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents usertxt As TextBox
    Friend WithEvents emailtxt As TextBox
    Friend WithEvents lnametxt As TextBox
    Friend WithEvents fnametxt As TextBox
    Friend WithEvents addresstxt As TextBox
    Friend WithEvents phonenumbertxt As TextBox
    Friend WithEvents passwordtxt As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents signupbtn As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FadeTimer As Timer
    Friend WithEvents licenseexptxt As TextBox
    Friend WithEvents licensenumbertxt As TextBox
    Friend WithEvents dobtxt As TextBox
    Friend WithEvents pbxShow As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
End Class
