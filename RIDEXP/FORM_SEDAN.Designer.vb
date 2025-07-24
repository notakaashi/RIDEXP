<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FORM_SEDAN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FORM_SEDAN))
        Panel1 = New Panel()
        Panel4 = New Panel()
        Label8 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Label7 = New Label()
        Button7 = New Button()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        PictureBox4 = New PictureBox()
        Label2 = New Label()
        Label3 = New Label()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        PictureBox3 = New PictureBox()
        TextBox1 = New TextBox()
        Label37 = New Label()
        Panel6 = New Panel()
        FadeTimer = New Timer(components)
        Panel7 = New Panel()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Panel7)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(Button5)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(TextBox1)
        Panel1.Location = New Point(5, 47)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1138, 381)
        Panel1.TabIndex = 42
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(Label10)
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(Button7)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(PictureBox4)
        Panel4.Controls.Add(Label2)
        Panel4.Controls.Add(Label3)
        Panel4.Location = New Point(10, 163)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1115, 252)
        Panel4.TabIndex = 39
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Microsoft Sans Serif", 28.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label8.Location = New Point(333, 133)
        Label8.Name = "Label8"
        Label8.Size = New Size(91, 54)
        Label8.TabIndex = 21
        Label8.Text = "red"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label10.Location = New Point(642, 151)
        Label10.Name = "Label10"
        Label10.Size = New Size(146, 36)
        Label10.TabIndex = 20
        Label10.Text = "11,456km"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Microsoft Sans Serif", 28.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label9.Location = New Point(529, 133)
        Label9.Name = "Label9"
        Label9.Size = New Size(49, 54)
        Label9.TabIndex = 19
        Label9.Text = "5"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Futura Bk BT", 12F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label7.Location = New Point(333, 35)
        Label7.Name = "Label7"
        Label7.Size = New Size(62, 24)
        Label7.TabIndex = 17
        Label7.Text = "MAKE"
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Reesha", 16.1999989F)
        Button7.ForeColor = Color.White
        Button7.Location = New Point(855, 133)
        Button7.Name = "Button7"
        Button7.Size = New Size(230, 45)
        Button7.TabIndex = 16
        Button7.Text = "BOOK NOW"
        Button7.TextAlign = ContentAlignment.TopCenter
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label6.Location = New Point(685, 195)
        Label6.Name = "Label6"
        Label6.Size = New Size(90, 24)
        Label6.TabIndex = 5
        Label6.Text = "MILEAGE"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label5.Location = New Point(485, 195)
        Label5.Name = "Label5"
        Label5.Size = New Size(151, 24)
        Label5.TabIndex = 4
        Label5.Text = "SEAT CAPACITY"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Futura Bk BT", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label4.Location = New Point(358, 195)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 24)
        Label4.TabIndex = 3
        Label4.Text = "COLOR"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.RideX
        PictureBox4.Location = New Point(33, 96)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(264, 123)
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox4.TabIndex = 2
        PictureBox4.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Reesha", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(22, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(303, 41)
        Label2.TabIndex = 0
        Label2.Text = "CAR NUMBER 1"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Futura Bk BT", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label3.Location = New Point(22, 35)
        Label3.Name = "Label3"
        Label3.Size = New Size(1072, 41)
        Label3.TabIndex = 1
        Label3.Text = "______________________________________________________________"
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.Transparent
        Button6.Cursor = Cursors.Hand
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button6.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button6.Location = New Point(816, 27)
        Button6.Name = "Button6"
        Button6.Size = New Size(176, 45)
        Button6.TabIndex = 38
        Button6.Text = "HYBRID"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Transparent
        Button5.Cursor = Cursors.Hand
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button5.Location = New Point(545, 27)
        Button5.Name = "Button5"
        Button5.Size = New Size(255, 45)
        Button5.TabIndex = 37
        Button5.Text = "HATCHBACK"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Transparent
        Button4.Cursor = Cursors.Hand
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button4.Location = New Point(363, 27)
        Button4.Name = "Button4"
        Button4.Size = New Size(163, 45)
        Button4.TabIndex = 34
        Button4.Text = "mpv"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Transparent
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button3.Location = New Point(177, 27)
        Button3.Name = "Button3"
        Button3.Size = New Size(163, 45)
        Button3.TabIndex = 33
        Button3.Text = "SEDAN"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.Cursor = Cursors.Hand
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Reesha", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button2.Location = New Point(22, 27)
        Button2.Name = "Button2"
        Button2.Size = New Size(133, 45)
        Button2.TabIndex = 31
        Button2.Text = "SUV"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(25, 93)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(51, 43)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 29
        PictureBox3.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Futura Bk BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(82, 95)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(201, 40)
        TextBox1.TabIndex = 22
        ' 
        ' Label37
        ' 
        Label37.AutoSize = True
        Label37.BackColor = Color.Transparent
        Label37.Font = New Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label37.ForeColor = Color.White
        Label37.Location = New Point(11, 9)
        Label37.Name = "Label37"
        Label37.Size = New Size(31, 29)
        Label37.TabIndex = 42
        Label37.Text = "X"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Panel6.Controls.Add(Label37)
        Panel6.Dock = DockStyle.Top
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1145, 45)
        Panel6.TabIndex = 43
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 25
        ' 
        ' Panel7
        ' 
        Panel7.Location = New Point(6, 388)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(50, 78)
        Panel7.TabIndex = 43
        ' 
        ' FORM_SEDAN
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1145, 413)
        Controls.Add(Panel1)
        Controls.Add(Panel6)
        FormBorderStyle = FormBorderStyle.None
        Name = "FORM_SEDAN"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SUVFORMS"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents FadeTimer As Timer
    Friend WithEvents Panel7 As Panel
End Class
