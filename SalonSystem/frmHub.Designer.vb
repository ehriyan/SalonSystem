<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHub
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHub))
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPOSCard = New System.Windows.Forms.Panel()
        Me.lblPOSDesc = New System.Windows.Forms.Label()
        Me.lblPOSTitle = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picPOS = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlPOSCard.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.Font = New System.Drawing.Font("DM Sans", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(79, 42)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(449, 31)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Welcome!"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.SlateGray
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(0, 0)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(130, 31)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.Controls.Add(Me.btnLogout)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 530)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(605, 31)
        Me.Panel1.TabIndex = 4
        '
        'pnlPOSCard
        '
        Me.pnlPOSCard.BackColor = System.Drawing.Color.White
        Me.pnlPOSCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPOSCard.Controls.Add(Me.picPOS)
        Me.pnlPOSCard.Controls.Add(Me.lblPOSDesc)
        Me.pnlPOSCard.Controls.Add(Me.lblPOSTitle)
        Me.pnlPOSCard.Location = New System.Drawing.Point(79, 103)
        Me.pnlPOSCard.Name = "pnlPOSCard"
        Me.pnlPOSCard.Size = New System.Drawing.Size(449, 118)
        Me.pnlPOSCard.TabIndex = 6
        '
        'lblPOSDesc
        '
        Me.lblPOSDesc.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOSDesc.ForeColor = System.Drawing.Color.DimGray
        Me.lblPOSDesc.Location = New System.Drawing.Point(199, 65)
        Me.lblPOSDesc.Name = "lblPOSDesc"
        Me.lblPOSDesc.Size = New System.Drawing.Size(223, 17)
        Me.lblPOSDesc.TabIndex = 4
        Me.lblPOSDesc.Text = "Process transactions and payments"
        Me.lblPOSDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPOSTitle
        '
        Me.lblPOSTitle.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOSTitle.Location = New System.Drawing.Point(256, 41)
        Me.lblPOSTitle.Name = "lblPOSTitle"
        Me.lblPOSTitle.Size = New System.Drawing.Size(166, 21)
        Me.lblPOSTitle.TabIndex = 3
        Me.lblPOSTitle.Text = "Point of Sale (POS)"
        Me.lblPOSTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(79, 234)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(449, 118)
        Me.Panel3.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(172, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(250, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Handle staff payment and commissions"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(256, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Staff Payroll"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(79, 365)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(449, 118)
        Me.Panel4.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(175, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(247, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Manage users and oversee operations"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(256, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Admin Dashboard"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SalonSystem.My.Resources.Resources.admin_dark
        Me.PictureBox2.Location = New System.Drawing.Point(29, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(105, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SalonSystem.My.Resources.Resources.pay_dark
        Me.PictureBox1.Location = New System.Drawing.Point(29, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(105, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'picPOS
        '
        Me.picPOS.Image = CType(resources.GetObject("picPOS.Image"), System.Drawing.Image)
        Me.picPOS.Location = New System.Drawing.Point(29, 26)
        Me.picPOS.Name = "picPOS"
        Me.picPOS.Size = New System.Drawing.Size(105, 69)
        Me.picPOS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPOS.TabIndex = 5
        Me.picPOS.TabStop = False
        '
        'frmHub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(605, 561)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPOSCard)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblWelcome)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hub"
        Me.Panel1.ResumeLayout(False)
        Me.pnlPOSCard.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlPOSCard As Panel
    Friend WithEvents lblPOSTitle As Label
    Friend WithEvents lblPOSDesc As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents picPOS As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
