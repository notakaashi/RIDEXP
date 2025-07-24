<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        pickupdatetxt = New TextBox()
        Panel5 = New Panel()
        deliverbtn = New RadioButton()
        pickupbtn = New RadioButton()
        pickuptimetxtbox = New TextBox()
        pickuptxtbox = New TextBox()
        Label12 = New Label()
        Label11 = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        PictureBox2 = New PictureBox()
        contactslbl = New Label()
        PictureBox1 = New PictureBox()
        homelbl = New Label()
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
        returndatetxt = New TextBox()
        Panel6 = New Panel()
        collectbtn = New RadioButton()
        returnbtn = New RadioButton()
        returntimetxtbox = New TextBox()
        returntxtbox = New TextBox()
        Label13 = New Label()
        Label14 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Panel2.SuspendLayout()
        Panel5.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(194, 53)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(0, 27)
        DateTimePicker1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(pickupdatetxt)
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(pickuptimetxtbox)
        Panel2.Controls.Add(pickuptxtbox)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label11)
        Panel2.Location = New Point(59, 281)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1103, 107)
        Panel2.TabIndex = 2
        ' 
        ' pickupdatetxt
        ' 
        pickupdatetxt.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pickupdatetxt.Location = New Point(538, 48)
        pickupdatetxt.Name = "pickupdatetxt"
        pickupdatetxt.Size = New Size(283, 31)
        pickupdatetxt.TabIndex = 23
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(deliverbtn)
        Panel5.Controls.Add(pickupbtn)
        Panel5.Location = New Point(34, 19)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(453, 33)
        Panel5.TabIndex = 22
        ' 
        ' deliverbtn
        ' 
        deliverbtn.AutoSize = True
        deliverbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        deliverbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        deliverbtn.Location = New Point(211, 4)
        deliverbtn.Name = "deliverbtn"
        deliverbtn.Size = New Size(216, 22)
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
        pickupbtn.Location = New Point(13, 4)
        pickupbtn.Name = "pickupbtn"
        pickupbtn.Size = New Size(172, 22)
        pickupbtn.TabIndex = 0
        pickupbtn.TabStop = True
        pickupbtn.Text = "PICK-UP AT STATION"
        pickupbtn.UseVisualStyleBackColor = True
        ' 
        ' pickuptimetxtbox
        ' 
        pickuptimetxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pickuptimetxtbox.Location = New Point(877, 56)
        pickuptimetxtbox.Name = "pickuptimetxtbox"
        pickuptimetxtbox.Size = New Size(191, 31)
        pickuptimetxtbox.TabIndex = 21
        ' 
        ' pickuptxtbox
        ' 
        pickuptxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pickuptxtbox.Location = New Point(34, 56)
        pickuptxtbox.Name = "pickuptxtbox"
        pickuptxtbox.Size = New Size(453, 31)
        pickuptxtbox.TabIndex = 19
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Futura Hv BT", 10.2F)
        Label12.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label12.Location = New Point(877, 24)
        Label12.Name = "Label12"
        Label12.Size = New Size(119, 20)
        Label12.TabIndex = 18
        Label12.Text = "PICK-UP TIME"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Futura Hv BT", 10.2F)
        Label11.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label11.Location = New Point(538, 24)
        Label11.Name = "Label11"
        Label11.Size = New Size(124, 20)
        Label11.TabIndex = 17
        Label11.Text = "PICK-UP DATE"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Reesha", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(64, 215)
        Label1.Name = "Label1"
        Label1.Size = New Size(395, 53)
        Label1.TabIndex = 0
        Label1.Text = "RENTAL FORM"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(contactslbl)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(homelbl)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1262, 77)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(1185, 13)
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
        contactslbl.Location = New Point(299, 23)
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
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Futura Hv BT", 10.2F)
        Label3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label3.Location = New Point(42, 21)
        Label3.Name = "Label3"
        Label3.Size = New Size(223, 20)
        Label3.TabIndex = 4
        Label3.Text = "STEP 1: SELECT A VEHICLE"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label5.Location = New Point(29, 21)
        Label5.Name = "Label5"
        Label5.Size = New Size(255, 36)
        Label5.TabIndex = 9
        Label5.Text = "________________"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Futura Hv BT", 10.2F)
        Label4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label4.Location = New Point(335, 21)
        Label4.Name = "Label4"
        Label4.Size = New Size(163, 20)
        Label4.TabIndex = 10
        Label4.Text = "STEP 2: ITENERARY"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label6.Location = New Point(293, 21)
        Label6.Name = "Label6"
        Label6.Size = New Size(255, 36)
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
        Panel3.Location = New Point(64, 99)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1103, 84)
        Panel3.TabIndex = 12
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Futura Hv BT", 10.2F)
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(869, 21)
        Label8.Name = "Label8"
        Label8.Size = New Size(152, 20)
        Label8.TabIndex = 14
        Label8.Text = "STEP 4: PAYMENT"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(827, 21)
        Label9.Name = "Label9"
        Label9.Size = New Size(255, 36)
        Label9.TabIndex = 15
        Label9.Text = "________________"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Futura Hv BT", 10.2F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(601, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(136, 20)
        Label2.TabIndex = 12
        Label2.Text = "STEP 3: REVIEW"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(561, 21)
        Label7.Name = "Label7"
        Label7.Size = New Size(255, 36)
        Label7.TabIndex = 13
        Label7.Text = "________________"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(returndatetxt)
        Panel4.Controls.Add(Panel6)
        Panel4.Controls.Add(returntimetxtbox)
        Panel4.Controls.Add(returntxtbox)
        Panel4.Controls.Add(Label13)
        Panel4.Controls.Add(Label14)
        Panel4.Location = New Point(59, 403)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1103, 107)
        Panel4.TabIndex = 22
        ' 
        ' returndatetxt
        ' 
        returndatetxt.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        returndatetxt.Location = New Point(538, 48)
        returndatetxt.Name = "returndatetxt"
        returndatetxt.Size = New Size(283, 31)
        returndatetxt.TabIndex = 24
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(collectbtn)
        Panel6.Controls.Add(returnbtn)
        Panel6.Location = New Point(34, 24)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(453, 33)
        Panel6.TabIndex = 23
        ' 
        ' collectbtn
        ' 
        collectbtn.AutoSize = True
        collectbtn.Font = New Font("Futura Bk BT", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        collectbtn.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        collectbtn.Location = New Point(211, 4)
        collectbtn.Name = "collectbtn"
        collectbtn.Size = New Size(226, 22)
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
        returnbtn.Location = New Point(13, 4)
        returnbtn.Name = "returnbtn"
        returnbtn.Size = New Size(171, 22)
        returnbtn.TabIndex = 0
        returnbtn.TabStop = True
        returnbtn.Text = "RETURN AT STATION"
        returnbtn.UseVisualStyleBackColor = True
        ' 
        ' returntimetxtbox
        ' 
        returntimetxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        returntimetxtbox.Location = New Point(877, 56)
        returntimetxtbox.Name = "returntimetxtbox"
        returntimetxtbox.Size = New Size(191, 31)
        returntimetxtbox.TabIndex = 21
        ' 
        ' returntxtbox
        ' 
        returntxtbox.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        returntxtbox.Location = New Point(34, 56)
        returntxtbox.Name = "returntxtbox"
        returntxtbox.Size = New Size(453, 31)
        returntxtbox.TabIndex = 19
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Futura Hv BT", 10.2F)
        Label13.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label13.Location = New Point(877, 24)
        Label13.Name = "Label13"
        Label13.Size = New Size(119, 20)
        Label13.TabIndex = 18
        Label13.Text = "RETURN TIME"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Futura Hv BT", 10.2F)
        Label14.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label14.Location = New Point(538, 24)
        Label14.Name = "Label14"
        Label14.Size = New Size(124, 20)
        Label14.TabIndex = 17
        Label14.Text = "RETURN DATE"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Reesha", 25.8000011F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(933, 537)
        Button1.Name = "Button1"
        Button1.Size = New Size(230, 67)
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
        Button2.Location = New Point(59, 537)
        Button2.Name = "Button2"
        Button2.Size = New Size(232, 47)
        Button2.TabIndex = 24
        Button2.Text = "CHANGE CAR"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' FORMRENTAL_STEP2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.RIDEXPRESS__5_
        ClientSize = New Size(1262, 673)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Name = "FORMRENTAL_STEP2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FORM_RENTAL"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
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
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents deliverbtn As RadioButton
    Friend WithEvents pickupbtn As RadioButton
    Friend WithEvents Panel6 As Panel
    Friend WithEvents collectbtn As RadioButton
    Friend WithEvents returnbtn As RadioButton
    Friend WithEvents pickupdatetxt As TextBox
    Friend WithEvents returndatetxt As TextBox
    Friend WithEvents Button2 As Button
End Class
