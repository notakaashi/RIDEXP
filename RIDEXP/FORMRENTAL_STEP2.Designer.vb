﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FORMRENTAL_STEP2
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
        DateTimePicker1 = New DateTimePicker()
        Panel2 = New Panel()
        cbxPickup = New ComboBox()
        pickupdate = New DateTimePicker()
        Panel5 = New Panel()
        deliverbtn = New RadioButton()
        pickupbtn = New RadioButton()
        pickuptxtbox = New TextBox()
        Label12 = New Label()
        Label11 = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        PictureBox3 = New PictureBox()
        contactslbl = New Label()
        PictureBox1 = New PictureBox()
        homelbl = New Label()
        PictureBox2 = New PictureBox()
        Label3 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Panel3 = New Panel()
        Label8 = New Label()
        Label9 = New Label()
        Label2 = New Label()
        Label7 = New Label()
        Panel4 = New Panel()
        returndated = New DateTimePicker()
        cbxReturn = New ComboBox()
        Panel6 = New Panel()
        collectbtn = New RadioButton()
        returnbtn = New RadioButton()
        returntxtbox = New TextBox()
        Label13 = New Label()
        Label14 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Panel7 = New Panel()
        Button3 = New Button()
        Label10 = New Label()
        user = New Label()
        PictureBox4 = New PictureBox()
        Panel2.SuspendLayout()
        Panel5.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(170, 40)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(0, 23)
        DateTimePicker1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(cbxPickup)
        Panel2.Controls.Add(pickupdate)
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(pickuptxtbox)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label11)
        Panel2.Location = New Point(52, 211)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(965, 80)
        Panel2.TabIndex = 2
        ' 
        ' cbxPickup
        ' 
        cbxPickup.Font = New Font("Futura Bk BT", 12F)
        cbxPickup.FormattingEnabled = True
        cbxPickup.Items.AddRange(New Object() {"8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM"})
        cbxPickup.Location = New Point(767, 36)
        cbxPickup.Margin = New Padding(3, 2, 3, 2)
        cbxPickup.Name = "cbxPickup"
        cbxPickup.Size = New Size(168, 27)
        cbxPickup.TabIndex = 24
        ' 
        ' pickupdate
        ' 
        pickupdate.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        pickupdate.Location = New Point(471, 37)
        pickupdate.MinDate = New Date(2025, 7, 26, 0, 0, 0, 0)
        pickupdate.Name = "pickupdate"
        pickupdate.Size = New Size(248, 29)
        pickupdate.TabIndex = 25
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(deliverbtn)
        Panel5.Controls.Add(pickupbtn)
        Panel5.Location = New Point(30, 14)
        Panel5.Margin = New Padding(3, 2, 3, 2)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(396, 25)
        Panel5.TabIndex = 22
        ' 
        ' deliverbtn
        ' 
        deliverbtn.AutoSize = True
        deliverbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        deliverbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        deliverbtn.Location = New Point(185, 3)
        deliverbtn.Margin = New Padding(3, 2, 3, 2)
        deliverbtn.Name = "deliverbtn"
        deliverbtn.Size = New Size(174, 19)
        deliverbtn.TabIndex = 1
        deliverbtn.TabStop = True
        deliverbtn.Text = "DELIVERED AT YOUR PLACE"
        deliverbtn.UseVisualStyleBackColor = True
        ' 
        ' pickupbtn
        ' 
        pickupbtn.AutoSize = True
        pickupbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pickupbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        pickupbtn.Location = New Point(11, 3)
        pickupbtn.Margin = New Padding(3, 2, 3, 2)
        pickupbtn.Name = "pickupbtn"
        pickupbtn.Size = New Size(139, 19)
        pickupbtn.TabIndex = 0
        pickupbtn.TabStop = True
        pickupbtn.Text = "PICK-UP AT STATION"
        pickupbtn.UseVisualStyleBackColor = True
        ' 
        ' pickuptxtbox
        ' 
        pickuptxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pickuptxtbox.Location = New Point(30, 42)
        pickuptxtbox.Margin = New Padding(3, 2, 3, 2)
        pickuptxtbox.Name = "pickuptxtbox"
        pickuptxtbox.Size = New Size(397, 27)
        pickuptxtbox.TabIndex = 19
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Futura Hv BT", 10.2F)
        Label12.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label12.Location = New Point(767, 18)
        Label12.Name = "Label12"
        Label12.Size = New Size(99, 16)
        Label12.TabIndex = 18
        Label12.Text = "PICK-UP TIME"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Futura Hv BT", 10.2F)
        Label11.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label11.Location = New Point(471, 18)
        Label11.Name = "Label11"
        Label11.Size = New Size(104, 16)
        Label11.TabIndex = 17
        Label11.Text = "PICK-UP DATE"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Reesha", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(56, 161)
        Label1.Name = "Label1"
        Label1.Size = New Size(316, 42)
        Label1.TabIndex = 0
        Label1.Text = "RENTAL FORM"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PictureBox4)
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(contactslbl)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(homelbl)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1104, 58)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(1026, 10)
        PictureBox3.Margin = New Padding(3, 2, 3, 2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(42, 31)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 30
        PictureBox3.TabStop = False
        ' 
        ' contactslbl
        ' 
        contactslbl.AutoSize = True
        contactslbl.BackColor = Color.White
        contactslbl.Cursor = Cursors.Hand
        contactslbl.Font = New Font("Reesha", 16.1999989F)
        contactslbl.ForeColor = Color.Black
        contactslbl.Location = New Point(262, 17)
        contactslbl.Name = "contactslbl"
        contactslbl.Size = New Size(181, 26)
        contactslbl.TabIndex = 25
        contactslbl.Text = "CONTACT US"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.RideX
        PictureBox1.Location = New Point(0, -26)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(130, 110)
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
        homelbl.Location = New Point(144, 16)
        homelbl.Name = "homelbl"
        homelbl.Size = New Size(88, 26)
        homelbl.TabIndex = 23
        homelbl.Text = "HOME"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(1026, 10)
        PictureBox2.Margin = New Padding(3, 2, 3, 2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(42, 31)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 31
        PictureBox2.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Futura Hv BT", 10.2F)
        Label3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label3.Location = New Point(37, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(185, 16)
        Label3.TabIndex = 4
        Label3.Text = "STEP 1: SELECT A VEHICLE"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label5.Location = New Point(25, 16)
        Label5.Name = "Label5"
        Label5.Size = New Size(205, 29)
        Label5.TabIndex = 9
        Label5.Text = "________________"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Futura Hv BT", 10.2F)
        Label4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label4.Location = New Point(293, 16)
        Label4.Name = "Label4"
        Label4.Size = New Size(135, 16)
        Label4.TabIndex = 10
        Label4.Text = "STEP 2: ITENERARY"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label6.Location = New Point(256, 16)
        Label6.Name = "Label6"
        Label6.Size = New Size(205, 29)
        Label6.TabIndex = 11
        Label6.Text = "________________"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(DateTimePicker1)
        Panel3.Controls.Add(Label5)
        Panel3.Location = New Point(56, 74)
        Panel3.Margin = New Padding(3, 2, 3, 2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(965, 63)
        Panel3.TabIndex = 12
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Futura Hv BT", 10.2F)
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(760, 16)
        Label8.Name = "Label8"
        Label8.Size = New Size(127, 16)
        Label8.TabIndex = 14
        Label8.Text = "STEP 4: PAYMENT"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(724, 16)
        Label9.Name = "Label9"
        Label9.Size = New Size(205, 29)
        Label9.TabIndex = 15
        Label9.Text = "________________"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Futura Hv BT", 10.2F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(526, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 16)
        Label2.TabIndex = 12
        Label2.Text = "STEP 3: REVIEW"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(491, 16)
        Label7.Name = "Label7"
        Label7.Size = New Size(205, 29)
        Label7.TabIndex = 13
        Label7.Text = "________________"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(returndated)
        Panel4.Controls.Add(cbxReturn)
        Panel4.Controls.Add(Panel6)
        Panel4.Controls.Add(returntxtbox)
        Panel4.Controls.Add(Label13)
        Panel4.Controls.Add(Label14)
        Panel4.Location = New Point(52, 302)
        Panel4.Margin = New Padding(3, 2, 3, 2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(965, 80)
        Panel4.TabIndex = 22
        ' 
        ' returndated
        ' 
        returndated.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        returndated.Location = New Point(471, 37)
        returndated.MinDate = New Date(2025, 7, 26, 0, 0, 0, 0)
        returndated.Name = "returndated"
        returndated.Size = New Size(248, 29)
        returndated.TabIndex = 26
        ' 
        ' cbxReturn
        ' 
        cbxReturn.Font = New Font("Futura Bk BT", 12F)
        cbxReturn.FormattingEnabled = True
        cbxReturn.Items.AddRange(New Object() {"8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM"})
        cbxReturn.Location = New Point(767, 35)
        cbxReturn.Margin = New Padding(3, 2, 3, 2)
        cbxReturn.Name = "cbxReturn"
        cbxReturn.Size = New Size(168, 27)
        cbxReturn.TabIndex = 25
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(collectbtn)
        Panel6.Controls.Add(returnbtn)
        Panel6.Location = New Point(30, 18)
        Panel6.Margin = New Padding(3, 2, 3, 2)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(396, 25)
        Panel6.TabIndex = 23
        ' 
        ' collectbtn
        ' 
        collectbtn.AutoSize = True
        collectbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        collectbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        collectbtn.Location = New Point(185, 3)
        collectbtn.Margin = New Padding(3, 2, 3, 2)
        collectbtn.Name = "collectbtn"
        collectbtn.Size = New Size(182, 19)
        collectbtn.TabIndex = 1
        collectbtn.TabStop = True
        collectbtn.Text = "COLLECTED AT YOUR PLACE"
        collectbtn.UseVisualStyleBackColor = True
        ' 
        ' returnbtn
        ' 
        returnbtn.AutoSize = True
        returnbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        returnbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        returnbtn.Location = New Point(11, 3)
        returnbtn.Margin = New Padding(3, 2, 3, 2)
        returnbtn.Name = "returnbtn"
        returnbtn.Size = New Size(137, 19)
        returnbtn.TabIndex = 0
        returnbtn.TabStop = True
        returnbtn.Text = "RETURN AT STATION"
        returnbtn.UseVisualStyleBackColor = True
        ' 
        ' returntxtbox
        ' 
        returntxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        returntxtbox.Location = New Point(30, 42)
        returntxtbox.Margin = New Padding(3, 2, 3, 2)
        returntxtbox.Name = "returntxtbox"
        returntxtbox.Size = New Size(397, 27)
        returntxtbox.TabIndex = 19
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Futura Hv BT", 10.2F)
        Label13.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label13.Location = New Point(767, 18)
        Label13.Name = "Label13"
        Label13.Size = New Size(98, 16)
        Label13.TabIndex = 18
        Label13.Text = "RETURN TIME"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Futura Hv BT", 10.2F)
        Label14.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label14.Location = New Point(471, 18)
        Label14.Name = "Label14"
        Label14.Size = New Size(103, 16)
        Label14.TabIndex = 17
        Label14.Text = "RETURN DATE"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Reesha", 25.8000011F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(816, 403)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(201, 50)
        Button1.TabIndex = 23
        Button1.Text = "NEXT"
        Button1.TextAlign = ContentAlignment.TopCenter
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Reesha", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(52, 403)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(203, 35)
        Button2.TabIndex = 24
        Button2.Text = "CHANGE CAR"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.White
        Panel7.Controls.Add(Button3)
        Panel7.Controls.Add(Label10)
        Panel7.Controls.Add(user)
        Panel7.Location = New Point(932, 57)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(172, 94)
        Panel7.TabIndex = 31
        Panel7.Visible = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Reesha", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.White
        Button3.Location = New Point(30, 56)
        Button3.Margin = New Padding(3, 2, 3, 2)
        Button3.Name = "Button3"
        Button3.Size = New Size(107, 23)
        Button3.TabIndex = 18
        Button3.Text = "LOGOUT"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Futura Hv BT", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label10.Location = New Point(30, 10)
        Label10.Name = "Label10"
        Label10.Size = New Size(119, 18)
        Label10.TabIndex = 16
        Label10.Text = "LOGGED IN AS"
        ' 
        ' user
        ' 
        user.AutoSize = True
        user.BackColor = Color.Transparent
        user.Font = New Font("Reesha", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        user.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        user.Location = New Point(49, 32)
        user.Name = "user"
        user.Size = New Size(80, 18)
        user.TabIndex = 17
        user.Text = "AAAAAA"
        user.TextAlign = ContentAlignment.TopCenter
        user.Visible = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.Location = New Point(1026, 10)
        PictureBox4.Margin = New Padding(3, 2, 3, 2)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(42, 31)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 32
        PictureBox4.TabStop = False
        PictureBox4.Visible = False
        ' 
        ' FORMRENTAL_STEP2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.RIDEXPRESS__5_
        ClientSize = New Size(1104, 505)
        Controls.Add(Panel7)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FORMRENTAL_STEP2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FORM_RENTAL"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents contactslbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents homelbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pickuptxtbox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pickuptimetxtbox As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents returntimetxtbox As TextBox
    Friend WithEvents returntxtbox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents deliverbtn As RadioButton
    Friend WithEvents pickupbtn As RadioButton
    Friend WithEvents Panel6 As Panel
    Friend WithEvents collectbtn As RadioButton
    Friend WithEvents returnbtn As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents cbxPickup As ComboBox
    Friend WithEvents cbxReturn As ComboBox
    Friend WithEvents pickupdate As DateTimePicker
    Friend WithEvents returndated As DateTimePicker
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents user As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
