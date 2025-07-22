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
        Label14 = New Label()
        dobtxt = New TextBox()
        Label12 = New Label()
        licenseexptxt = New TextBox()
        Label11 = New Label()
        licensenumbertxt = New TextBox()
        Label10 = New Label()
        signupbtn = New Button()
        Panel2 = New Panel()
        addresstxt = New TextBox()
        Label8 = New Label()
        phonenumbertxt = New TextBox()
        Label7 = New Label()
        passwordtxt = New TextBox()
        Label6 = New Label()
        usertxt = New TextBox()
        Label5 = New Label()
        emailtxt = New TextBox()
        Label4 = New Label()
        lnametxt = New TextBox()
        Label3 = New Label()
        fnametxt = New TextBox()
        Label2 = New Label()
        Label9 = New Label()
        Panel3 = New Panel()
        Label1 = New Label()
        FadeTimer = New Timer(components)
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(dobtxt)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(licenseexptxt)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(licensenumbertxt)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(signupbtn)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(addresstxt)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(phonenumbertxt)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(passwordtxt)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(usertxt)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(emailtxt)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lnametxt)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(fnametxt)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(44, 131)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(426, 287)
        Panel1.TabIndex = 0
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(359, 612)
        Label14.Name = "Label14"
        Label14.Size = New Size(36, 15)
        Label14.TabIndex = 26
        Label14.Text = "Show"
        ' 
        ' dobtxt
        ' 
        dobtxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dobtxt.Location = New Point(61, 253)
        dobtxt.Margin = New Padding(3, 2, 3, 2)
        dobtxt.Name = "dobtxt"
        dobtxt.Size = New Size(291, 33)
        dobtxt.TabIndex = 25
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label12.Location = New Point(59, 229)
        Label12.Name = "Label12"
        Label12.Size = New Size(151, 22)
        Label12.TabIndex = 24
        Label12.Text = "DATE OF BIRTH"
        ' 
        ' licenseexptxt
        ' 
        licenseexptxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        licenseexptxt.Location = New Point(57, 872)
        licenseexptxt.Margin = New Padding(3, 2, 3, 2)
        licenseexptxt.Name = "licenseexptxt"
        licenseexptxt.Size = New Size(291, 33)
        licenseexptxt.TabIndex = 23
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label11.Location = New Point(60, 848)
        Label11.Name = "Label11"
        Label11.Size = New Size(212, 22)
        Label11.TabIndex = 22
        Label11.Text = "LICENSE EXPIRY DATE"
        ' 
        ' licensenumbertxt
        ' 
        licensenumbertxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        licensenumbertxt.Location = New Point(57, 784)
        licensenumbertxt.Margin = New Padding(3, 2, 3, 2)
        licensenumbertxt.Name = "licensenumbertxt"
        licensenumbertxt.Size = New Size(291, 33)
        licensenumbertxt.TabIndex = 21
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label10.Location = New Point(57, 760)
        Label10.Name = "Label10"
        Label10.Size = New Size(176, 22)
        Label10.TabIndex = 20
        Label10.Text = "LICENSE NUMBER"
        ' 
        ' signupbtn
        ' 
        signupbtn.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        signupbtn.FlatStyle = FlatStyle.Flat
        signupbtn.Font = New Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        signupbtn.ForeColor = Color.White
        signupbtn.Location = New Point(81, 941)
        signupbtn.Margin = New Padding(3, 2, 3, 2)
        signupbtn.Name = "signupbtn"
        signupbtn.Size = New Size(234, 54)
        signupbtn.TabIndex = 19
        signupbtn.Text = "SIGN UP"
        signupbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(96, 1031)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(219, 53)
        Panel2.TabIndex = 18
        ' 
        ' addresstxt
        ' 
        addresstxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        addresstxt.Location = New Point(61, 341)
        addresstxt.Margin = New Padding(3, 2, 3, 2)
        addresstxt.Name = "addresstxt"
        addresstxt.Size = New Size(291, 33)
        addresstxt.TabIndex = 15
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label8.Location = New Point(61, 317)
        Label8.Name = "Label8"
        Label8.Size = New Size(97, 22)
        Label8.TabIndex = 16
        Label8.Text = "ADDRESS"
        ' 
        ' phonenumbertxt
        ' 
        phonenumbertxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        phonenumbertxt.Location = New Point(60, 695)
        phonenumbertxt.Margin = New Padding(3, 2, 3, 2)
        phonenumbertxt.Name = "phonenumbertxt"
        phonenumbertxt.Size = New Size(293, 33)
        phonenumbertxt.TabIndex = 13
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label7.Location = New Point(57, 671)
        Label7.Name = "Label7"
        Label7.Size = New Size(167, 22)
        Label7.TabIndex = 14
        Label7.Text = "PHONE NUMBER"
        ' 
        ' passwordtxt
        ' 
        passwordtxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        passwordtxt.Location = New Point(60, 600)
        passwordtxt.Margin = New Padding(3, 2, 3, 2)
        passwordtxt.Name = "passwordtxt"
        passwordtxt.PasswordChar = "*"c
        passwordtxt.Size = New Size(293, 33)
        passwordtxt.TabIndex = 11
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label6.Location = New Point(57, 576)
        Label6.Name = "Label6"
        Label6.Size = New Size(118, 22)
        Label6.TabIndex = 12
        Label6.Text = "PASSWORD"
        ' 
        ' usertxt
        ' 
        usertxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        usertxt.Location = New Point(61, 509)
        usertxt.Margin = New Padding(3, 2, 3, 2)
        usertxt.Name = "usertxt"
        usertxt.Size = New Size(293, 33)
        usertxt.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label5.Location = New Point(57, 485)
        Label5.Name = "Label5"
        Label5.Size = New Size(117, 22)
        Label5.TabIndex = 10
        Label5.Text = "USERNAME"
        ' 
        ' emailtxt
        ' 
        emailtxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        emailtxt.Location = New Point(61, 423)
        emailtxt.Margin = New Padding(3, 2, 3, 2)
        emailtxt.Name = "emailtxt"
        emailtxt.Size = New Size(293, 33)
        emailtxt.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label4.Location = New Point(60, 399)
        Label4.Name = "Label4"
        Label4.Size = New Size(67, 22)
        Label4.TabIndex = 8
        Label4.Text = "EMAIL"
        ' 
        ' lnametxt
        ' 
        lnametxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnametxt.Location = New Point(61, 167)
        lnametxt.Margin = New Padding(3, 2, 3, 2)
        lnametxt.Name = "lnametxt"
        lnametxt.Size = New Size(293, 33)
        lnametxt.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label3.Location = New Point(59, 143)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 22)
        Label3.TabIndex = 6
        Label3.Text = "LAST NAME"
        ' 
        ' fnametxt
        ' 
        fnametxt.Font = New Font("Futura Hv BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        fnametxt.Location = New Point(61, 75)
        fnametxt.Margin = New Padding(3, 2, 3, 2)
        fnametxt.Name = "fnametxt"
        fnametxt.Size = New Size(293, 33)
        fnametxt.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Futura Hv BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(59, 51)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 22)
        Label2.TabIndex = 4
        Label2.Text = "FIRST NAME"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Reesha", 48F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label9.Location = New Point(104, 52)
        Label9.Name = "Label9"
        Label9.Size = New Size(320, 77)
        Label9.TabIndex = 3
        Label9.Text = "SIGN UP"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Margin = New Padding(3, 2, 3, 2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(535, 50)
        Panel3.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(25, 24)
        Label1.TabIndex = 5
        Label1.Text = "X"
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 25
        ' 
        ' SIGNUP
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.RIDEXPRESS__5_
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(535, 434)
        Controls.Add(Panel3)
        Controls.Add(Label9)
        Controls.Add(Panel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "SIGNUP"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents usertxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents emailtxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lnametxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents fnametxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents addresstxt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents phonenumbertxt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents passwordtxt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents signupbtn As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FadeTimer As Timer
    Friend WithEvents licenseexptxt As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents licensenumbertxt As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dobtxt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
End Class
