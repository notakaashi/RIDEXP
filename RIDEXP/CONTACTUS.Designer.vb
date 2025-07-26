<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONTACTUS
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
        PictureBox2 = New PictureBox()
        contactslbl = New Label()
        PictureBox1 = New PictureBox()
        homelbl = New Label()
        rentalslbl = New Label()
        Button1 = New Button()
        Panel2 = New Panel()
        PictureBox3 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Panel3 = New Panel()
        Label5 = New Label()
        Label6 = New Label()
        PictureBox4 = New PictureBox()
        Panel4 = New Panel()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        PictureBox5 = New PictureBox()
        pnlVehicleType = New Panel()
        btnMotor = New Button()
        btnCar = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        pnlVehicleType.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(rentalslbl)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(contactslbl)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(homelbl)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1262, 77)
        Panel1.TabIndex = 2
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(1181, 17)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(48, 41)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 24
        PictureBox2.TabStop = False
        ' 
        ' contactslbl
        ' 
        contactslbl.AutoSize = True
        contactslbl.BackColor = Color.White
        contactslbl.Cursor = Cursors.Hand
        contactslbl.Font = New Font("Reesha", 16.1999989F)
        contactslbl.ForeColor = Color.Black
        contactslbl.Location = New Point(610, 22)
        contactslbl.Name = "contactslbl"
        contactslbl.Size = New Size(220, 32)
        contactslbl.TabIndex = 25
        contactslbl.Text = "CONTACT US"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.RideX
        PictureBox1.Location = New Point(0, -35)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(149, 147)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' homelbl
        ' 
        homelbl.AutoSize = True
        homelbl.BackColor = Color.White
        homelbl.Cursor = Cursors.Hand
        homelbl.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        homelbl.ForeColor = Color.Black
        homelbl.Location = New Point(165, 21)
        homelbl.Name = "homelbl"
        homelbl.Size = New Size(107, 32)
        homelbl.TabIndex = 23
        homelbl.Text = "HOME"
        ' 
        ' rentalslbl
        ' 
        rentalslbl.AutoSize = True
        rentalslbl.BackColor = Color.White
        rentalslbl.Cursor = Cursors.Hand
        rentalslbl.Font = New Font("Reesha", 16.1999989F)
        rentalslbl.ForeColor = Color.Black
        rentalslbl.Location = New Point(316, 22)
        rentalslbl.Name = "rentalslbl"
        rentalslbl.Size = New Size(242, 32)
        rentalslbl.TabIndex = 27
        rentalslbl.Text = "OUR RENTALS"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Reesha", 16.1999989F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(935, 17)
        Button1.Name = "Button1"
        Button1.Size = New Size(230, 45)
        Button1.TabIndex = 26
        Button1.Text = "BOOK NOW"
        Button1.TextAlign = ContentAlignment.TopCenter
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Location = New Point(62, 175)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(315, 312)
        Panel2.TabIndex = 3
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.icon_call
        PictureBox3.Location = New Point(73, 34)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(159, 146)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 0
        PictureBox3.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Cursor = Cursors.Hand
        Label1.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(73, 194)
        Label1.Name = "Label1"
        Label1.Size = New Size(154, 32)
        Label1.TabIndex = 28
        Label1.Text = "CALL US"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(88, 238)
        Label2.Name = "Label2"
        Label2.Size = New Size(119, 20)
        Label2.TabIndex = 29
        Label2.Text = "09123456789"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(81, 262)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 20)
        Label3.TabIndex = 30
        Label3.Text = "(02) 7791 - 1234"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Location = New Point(458, 175)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(315, 312)
        Panel3.TabIndex = 31
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(77, 238)
        Label5.Name = "Label5"
        Label5.Size = New Size(158, 20)
        Label5.TabIndex = 29
        Label5.Text = "rentals@ridexp.com"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Cursor = Cursors.Hand
        Label6.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label6.Location = New Point(73, 194)
        Label6.Name = "Label6"
        Label6.Size = New Size(164, 32)
        Label6.TabIndex = 28
        Label6.Text = "EMAIL US"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.icon_email
        PictureBox4.Location = New Point(81, 34)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(154, 146)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 0
        PictureBox4.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(PictureBox5)
        Panel4.Location = New Point(850, 175)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(315, 312)
        Panel4.TabIndex = 32
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(81, 262)
        Label7.Name = "Label7"
        Label7.Size = New Size(129, 20)
        Label7.TabIndex = 30
        Label7.Text = "@ridexpress_ph"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Futura Bk BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(101, 238)
        Label8.Name = "Label8"
        Label8.Size = New Size(89, 20)
        Label8.TabIndex = 29
        Label8.Text = "RideXpress"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Cursor = Cursors.Hand
        Label9.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label9.Location = New Point(92, 194)
        Label9.Name = "Label9"
        Label9.Size = New Size(115, 32)
        Label9.TabIndex = 28
        Label9.Text = "DM US"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.users_logo
        PictureBox5.Location = New Point(50, 34)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(206, 146)
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.TabIndex = 0
        PictureBox5.TabStop = False
        ' 
        ' pnlVehicleType
        ' 
        pnlVehicleType.BackColor = Color.White
        pnlVehicleType.Controls.Add(btnMotor)
        pnlVehicleType.Controls.Add(btnCar)
        pnlVehicleType.Location = New Point(316, 77)
        pnlVehicleType.Margin = New Padding(3, 4, 3, 4)
        pnlVehicleType.Name = "pnlVehicleType"
        pnlVehicleType.Size = New Size(242, 125)
        pnlVehicleType.TabIndex = 28
        pnlVehicleType.Visible = False
        ' 
        ' btnMotor
        ' 
        btnMotor.Cursor = Cursors.Hand
        btnMotor.Font = New Font("Reesha", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnMotor.Location = New Point(18, 64)
        btnMotor.Name = "btnMotor"
        btnMotor.Size = New Size(203, 44)
        btnMotor.TabIndex = 1
        btnMotor.Text = "MOTORCYCLES"
        btnMotor.UseVisualStyleBackColor = True
        ' 
        ' btnCar
        ' 
        btnCar.Cursor = Cursors.Hand
        btnCar.Font = New Font("Reesha", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCar.Location = New Point(18, 13)
        btnCar.Name = "btnCar"
        btnCar.Size = New Size(203, 44)
        btnCar.TabIndex = 0
        btnCar.Text = "CARS"
        btnCar.TextAlign = ContentAlignment.TopCenter
        btnCar.UseVisualStyleBackColor = True
        ' 
        ' CONTACTUS
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.RIDEXPRESS__5_
        ClientSize = New Size(1262, 673)
        Controls.Add(pnlVehicleType)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "CONTACTUS"
        StartPosition = FormStartPosition.CenterScreen
        Text = "CONTACTUS"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        pnlVehicleType.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents contactslbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents homelbl As Label
    Friend WithEvents rentalslbl As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents pnlVehicleType As Panel
    Friend WithEvents btnMotor As Button
    Friend WithEvents btnCar As Button
End Class
