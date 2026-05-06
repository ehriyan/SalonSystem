<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picShowPassword = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picShowPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsername.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtUsername.Location = New System.Drawing.Point(5, 5)
        Me.txtUsername.Multiline = True
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(290, 22)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.Text = "Enter username or email"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(420, 138)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(139, 20)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username or email"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(420, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(424, 308)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(300, 44)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("DM Sans", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(417, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 35)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Log in"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txtUsername)
        Me.Panel2.Location = New System.Drawing.Point(423, 165)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(300, 32)
        Me.Panel2.TabIndex = 7
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.lblExit.Location = New System.Drawing.Point(746, 7)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(32, 33)
        Me.lblExit.TabIndex = 10
        Me.lblExit.Text = "×"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(423, 193)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(300, 2)
        Me.Panel4.TabIndex = 11
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(423, 267)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(300, 2)
        Me.Panel5.TabIndex = 13
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.picShowPassword)
        Me.Panel6.Controls.Add(Me.txtPassword)
        Me.Panel6.Location = New System.Drawing.Point(423, 240)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(5, 5, 40, 5)
        Me.Panel6.Size = New System.Drawing.Size(300, 32)
        Me.Panel6.TabIndex = 12
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.RosyBrown
        Me.txtPassword.Location = New System.Drawing.Point(5, 5)
        Me.txtPassword.Multiline = True
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(255, 22)
        Me.txtPassword.TabIndex = 0
        Me.txtPassword.Text = "Enter password"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(346, 411)
        Me.Panel1.TabIndex = 6
        '
        'picShowPassword
        '
        Me.picShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picShowPassword.Image = Global.SalonSystem.My.Resources.Resources.visibility
        Me.picShowPassword.Location = New System.Drawing.Point(270, 3)
        Me.picShowPassword.Name = "picShowPassword"
        Me.picShowPassword.Size = New System.Drawing.Size(23, 22)
        Me.picShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picShowPassword.TabIndex = 14
        Me.picShowPassword.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SalonSystem.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(6, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(331, 244)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUsername)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picShowPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblExit As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents picShowPassword As PictureBox
    Friend WithEvents Panel1 As Panel
End Class
