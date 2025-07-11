<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        btnRENTALS = New Button()
        btnHOME = New Button()
        btnCONTACT = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.USER_LOGO
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(1784, 26)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(79, 73)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Reesha", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1435, 26)
        Button1.Name = "Button1"
        Button1.Size = New Size(328, 76)
        Button1.TabIndex = 6
        Button1.Text = "BOOK NOW"
        Button1.TextAlign = ContentAlignment.TopCenter
        Button1.UseVisualStyleBackColor = False
        ' 
        ' btnRENTALS
        ' 
        btnRENTALS.BackColor = Color.Transparent
        btnRENTALS.FlatStyle = FlatStyle.Flat
        btnRENTALS.Font = New Font("Reesha", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRENTALS.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnRENTALS.ImageAlign = ContentAlignment.TopCenter
        btnRENTALS.Location = New Point(511, 37)
        btnRENTALS.Name = "btnRENTALS"
        btnRENTALS.Size = New Size(354, 65)
        btnRENTALS.TabIndex = 8
        btnRENTALS.Text = "OUR RENTALS"
        btnRENTALS.TextAlign = ContentAlignment.TopCenter
        btnRENTALS.UseVisualStyleBackColor = False
        ' 
        ' btnHOME
        ' 
        btnHOME.BackColor = Color.Transparent
        btnHOME.FlatStyle = FlatStyle.Flat
        btnHOME.Font = New Font("Reesha", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHOME.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnHOME.Location = New Point(336, 37)
        btnHOME.Name = "btnHOME"
        btnHOME.Size = New Size(160, 65)
        btnHOME.TabIndex = 7
        btnHOME.Text = "HOME"
        btnHOME.TextAlign = ContentAlignment.TopCenter
        btnHOME.UseVisualStyleBackColor = False
        ' 
        ' btnCONTACT
        ' 
        btnCONTACT.BackColor = Color.Transparent
        btnCONTACT.FlatStyle = FlatStyle.Flat
        btnCONTACT.Font = New Font("Reesha", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCONTACT.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnCONTACT.ImageAlign = ContentAlignment.TopCenter
        btnCONTACT.Location = New Point(881, 37)
        btnCONTACT.Name = "btnCONTACT"
        btnCONTACT.Size = New Size(354, 65)
        btnCONTACT.TabIndex = 9
        btnCONTACT.Text = "CONTACT US"
        btnCONTACT.TextAlign = ContentAlignment.TopCenter
        btnCONTACT.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.RIDEXPRESS
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1902, 1033)
        Controls.Add(btnCONTACT)
        Controls.Add(btnRENTALS)
        Controls.Add(btnHOME)
        Controls.Add(Button1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        Text = " "
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnRENTALS As Button
    Friend WithEvents btnHOME As Button
    Friend WithEvents btnCONTACT As Button

End Class
