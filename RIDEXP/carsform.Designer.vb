<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class carsform
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
        Panel1 = New Panel()
        btnCONTACT = New Button()
        btnRENTALS = New Button()
        btnHOME = New Button()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Panel2 = New Panel()
        TextBox1 = New TextBox()
        Label1 = New Label()
        PictureBox3 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnCONTACT)
        Panel1.Controls.Add(btnHOME)
        Panel1.Controls.Add(btnRENTALS)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1262, 85)
        Panel1.TabIndex = 0
        ' 
        ' btnCONTACT
        ' 
        btnCONTACT.BackColor = Color.Transparent
        btnCONTACT.FlatStyle = FlatStyle.Flat
        btnCONTACT.Font = New Font("Reesha", 16.1999989F)
        btnCONTACT.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnCONTACT.ImageAlign = ContentAlignment.TopCenter
        btnCONTACT.Location = New Point(610, 22)
        btnCONTACT.Name = "btnCONTACT"
        btnCONTACT.Size = New Size(246, 45)
        btnCONTACT.TabIndex = 14
        btnCONTACT.Text = "CONTACT US"
        btnCONTACT.UseVisualStyleBackColor = False
        ' 
        ' btnRENTALS
        ' 
        btnRENTALS.BackColor = Color.Transparent
        btnRENTALS.FlatStyle = FlatStyle.Flat
        btnRENTALS.Font = New Font("Reesha", 16.1999989F)
        btnRENTALS.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnRENTALS.ImageAlign = ContentAlignment.TopCenter
        btnRENTALS.Location = New Point(339, 22)
        btnRENTALS.Name = "btnRENTALS"
        btnRENTALS.Size = New Size(256, 45)
        btnRENTALS.TabIndex = 13
        btnRENTALS.Text = "OUR RENTALS"
        btnRENTALS.UseVisualStyleBackColor = False
        ' 
        ' btnHOME
        ' 
        btnHOME.BackColor = Color.Transparent
        btnHOME.FlatStyle = FlatStyle.Flat
        btnHOME.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHOME.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnHOME.Location = New Point(187, 22)
        btnHOME.Name = "btnHOME"
        btnHOME.Size = New Size(133, 45)
        btnHOME.TabIndex = 12
        btnHOME.Text = "HOME"
        btnHOME.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Reesha", 16.1999989F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(911, 23)
        Button1.Name = "Button1"
        Button1.Size = New Size(230, 46)
        Button1.TabIndex = 11
        Button1.Text = "BOOK NOW"
        Button1.TextAlign = ContentAlignment.TopCenter
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(1156, 26)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(48, 41)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.RideX
        PictureBox2.Location = New Point(3, -40)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(181, 174)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 15
        PictureBox2.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(PictureBox3)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(TextBox1)
        Panel2.Location = New Point(52, 133)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1181, 507)
        Panel2.TabIndex = 1
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Futura Bk BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(109, 91)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(201, 35)
        TextBox1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Reesha", 25.8000011F)
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(46, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(163, 53)
        Label1.TabIndex = 1
        Label1.Text = "CARS"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.RideX
        PictureBox3.Location = New Point(3, 39)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(181, 174)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 16
        PictureBox3.TabStop = False
        ' 
        ' carsform
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackgroundImage = My.Resources.Resources.RIDEXPRESS__5_
        ClientSize = New Size(1262, 673)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "carsform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "carsform"
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCONTACT As Button
    Friend WithEvents btnHOME As Button
    Friend WithEvents btnRENTALS As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
