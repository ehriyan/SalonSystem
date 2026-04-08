<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOS
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.flpServices = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlCart = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClearCart = New System.Windows.Forms.Button()
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlUnderlineCosmetics = New System.Windows.Forms.Panel()
        Me.pnlUnderlineGrooming = New System.Windows.Forms.Panel()
        Me.pnlUnderlineHair = New System.Windows.Forms.Panel()
        Me.pnlUnderlineAll = New System.Windows.Forms.Panel()
        Me.btnCosmetics = New System.Windows.Forms.Button()
        Me.btnGrooming = New System.Windows.Forms.Button()
        Me.btnHair = New System.Windows.Forms.Button()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlCart.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 39)
        Me.Panel1.TabIndex = 0
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.Black
        Me.lblTime.Location = New System.Drawing.Point(1069, 11)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(91, 20)
        Me.lblTime.TabIndex = 8
        Me.lblTime.Text = "Time:"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(854, 11)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(195, 20)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Date:"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "POS Terminal"
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.SlateGray
        Me.btnReturn.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnReturn.FlatAppearance.BorderSize = 0
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.ForeColor = System.Drawing.Color.White
        Me.btnReturn.Location = New System.Drawing.Point(0, 0)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(125, 34)
        Me.btnReturn.TabIndex = 1
        Me.btnReturn.Text = "Exit"
        Me.btnReturn.UseVisualStyleBackColor = False
        '
        'flpServices
        '
        Me.flpServices.AutoScroll = True
        Me.flpServices.BackColor = System.Drawing.Color.WhiteSmoke
        Me.flpServices.Dock = System.Windows.Forms.DockStyle.Left
        Me.flpServices.Location = New System.Drawing.Point(0, 98)
        Me.flpServices.Name = "flpServices"
        Me.flpServices.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.flpServices.Size = New System.Drawing.Size(615, 479)
        Me.flpServices.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.btnReturn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 577)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1184, 34)
        Me.Panel2.TabIndex = 2
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(525, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(200, 34)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Void"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(325, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 34)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Qty"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(125, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 34)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Discount"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pnlCart
        '
        Me.pnlCart.BackColor = System.Drawing.Color.White
        Me.pnlCart.Controls.Add(Me.Panel3)
        Me.pnlCart.Controls.Add(Me.Label2)
        Me.pnlCart.Controls.Add(Me.Label1)
        Me.pnlCart.Controls.Add(Me.btnClearCart)
        Me.pnlCart.Controls.Add(Me.btnCheckout)
        Me.pnlCart.Controls.Add(Me.lblTotal)
        Me.pnlCart.Controls.Add(Me.dgvCart)
        Me.pnlCart.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCart.Location = New System.Drawing.Point(615, 39)
        Me.pnlCart.Name = "pnlCart"
        Me.pnlCart.Size = New System.Drawing.Size(569, 538)
        Me.pnlCart.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Location = New System.Drawing.Point(38, 318)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(500, 1)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(45, 370)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tax:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(45, 347)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Subtotal:"
        '
        'btnClearCart
        '
        Me.btnClearCart.BackColor = System.Drawing.Color.AliceBlue
        Me.btnClearCart.FlatAppearance.BorderSize = 0
        Me.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearCart.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearCart.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnClearCart.Location = New System.Drawing.Point(41, 469)
        Me.btnClearCart.Name = "btnClearCart"
        Me.btnClearCart.Size = New System.Drawing.Size(233, 44)
        Me.btnClearCart.TabIndex = 3
        Me.btnClearCart.Text = "Clear Cart"
        Me.btnClearCart.UseVisualStyleBackColor = False
        '
        'btnCheckout
        '
        Me.btnCheckout.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCheckout.FlatAppearance.BorderSize = 0
        Me.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckout.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.White
        Me.btnCheckout.Location = New System.Drawing.Point(302, 469)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(233, 44)
        Me.btnCheckout.TabIndex = 2
        Me.btnCheckout.Text = "Check Out"
        Me.btnCheckout.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(45, 409)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 25)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "Total:"
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCart.Location = New System.Drawing.Point(0, 0)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersVisible = False
        Me.dgvCart.Size = New System.Drawing.Size(569, 314)
        Me.dgvCart.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pnlUnderlineCosmetics)
        Me.Panel4.Controls.Add(Me.pnlUnderlineGrooming)
        Me.Panel4.Controls.Add(Me.pnlUnderlineHair)
        Me.Panel4.Controls.Add(Me.pnlUnderlineAll)
        Me.Panel4.Controls.Add(Me.btnCosmetics)
        Me.Panel4.Controls.Add(Me.btnGrooming)
        Me.Panel4.Controls.Add(Me.btnHair)
        Me.Panel4.Controls.Add(Me.btnAll)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(615, 59)
        Me.Panel4.TabIndex = 0
        '
        'pnlUnderlineCosmetics
        '
        Me.pnlUnderlineCosmetics.BackColor = System.Drawing.Color.DimGray
        Me.pnlUnderlineCosmetics.Location = New System.Drawing.Point(486, 47)
        Me.pnlUnderlineCosmetics.Name = "pnlUnderlineCosmetics"
        Me.pnlUnderlineCosmetics.Size = New System.Drawing.Size(100, 3)
        Me.pnlUnderlineCosmetics.TabIndex = 3
        Me.pnlUnderlineCosmetics.Visible = False
        '
        'pnlUnderlineGrooming
        '
        Me.pnlUnderlineGrooming.BackColor = System.Drawing.Color.DimGray
        Me.pnlUnderlineGrooming.Location = New System.Drawing.Point(335, 47)
        Me.pnlUnderlineGrooming.Name = "pnlUnderlineGrooming"
        Me.pnlUnderlineGrooming.Size = New System.Drawing.Size(100, 3)
        Me.pnlUnderlineGrooming.TabIndex = 3
        Me.pnlUnderlineGrooming.Visible = False
        '
        'pnlUnderlineHair
        '
        Me.pnlUnderlineHair.BackColor = System.Drawing.Color.DimGray
        Me.pnlUnderlineHair.Location = New System.Drawing.Point(180, 47)
        Me.pnlUnderlineHair.Name = "pnlUnderlineHair"
        Me.pnlUnderlineHair.Size = New System.Drawing.Size(100, 3)
        Me.pnlUnderlineHair.TabIndex = 2
        Me.pnlUnderlineHair.Visible = False
        '
        'pnlUnderlineAll
        '
        Me.pnlUnderlineAll.BackColor = System.Drawing.Color.DimGray
        Me.pnlUnderlineAll.Location = New System.Drawing.Point(28, 47)
        Me.pnlUnderlineAll.Name = "pnlUnderlineAll"
        Me.pnlUnderlineAll.Size = New System.Drawing.Size(100, 3)
        Me.pnlUnderlineAll.TabIndex = 1
        Me.pnlUnderlineAll.Visible = False
        '
        'btnCosmetics
        '
        Me.btnCosmetics.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCosmetics.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCosmetics.FlatAppearance.BorderSize = 0
        Me.btnCosmetics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCosmetics.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCosmetics.ForeColor = System.Drawing.Color.Black
        Me.btnCosmetics.Location = New System.Drawing.Point(459, 0)
        Me.btnCosmetics.Name = "btnCosmetics"
        Me.btnCosmetics.Size = New System.Drawing.Size(153, 59)
        Me.btnCosmetics.TabIndex = 3
        Me.btnCosmetics.Text = "Cosmetics"
        Me.btnCosmetics.UseVisualStyleBackColor = False
        '
        'btnGrooming
        '
        Me.btnGrooming.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnGrooming.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGrooming.FlatAppearance.BorderSize = 0
        Me.btnGrooming.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrooming.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrooming.ForeColor = System.Drawing.Color.Black
        Me.btnGrooming.Location = New System.Drawing.Point(306, 0)
        Me.btnGrooming.Name = "btnGrooming"
        Me.btnGrooming.Size = New System.Drawing.Size(153, 59)
        Me.btnGrooming.TabIndex = 2
        Me.btnGrooming.Text = "Grooming"
        Me.btnGrooming.UseVisualStyleBackColor = False
        '
        'btnHair
        '
        Me.btnHair.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnHair.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHair.FlatAppearance.BorderSize = 0
        Me.btnHair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHair.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHair.ForeColor = System.Drawing.Color.Black
        Me.btnHair.Location = New System.Drawing.Point(153, 0)
        Me.btnHair.Name = "btnHair"
        Me.btnHair.Size = New System.Drawing.Size(153, 59)
        Me.btnHair.TabIndex = 1
        Me.btnHair.Text = "Hair"
        Me.btnHair.UseVisualStyleBackColor = False
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAll.FlatAppearance.BorderSize = 0
        Me.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAll.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAll.ForeColor = System.Drawing.Color.Black
        Me.btnAll.Location = New System.Drawing.Point(0, 0)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(153, 59)
        Me.btnAll.TabIndex = 0
        Me.btnAll.Text = "All"
        Me.btnAll.UseVisualStyleBackColor = False
        '
        'tmrClock
        '
        Me.tmrClock.Interval = 1000
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1184, 611)
        Me.Controls.Add(Me.flpServices)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlCart)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sale (POS)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlCart.ResumeLayout(False)
        Me.pnlCart.PerformLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReturn As Button
    Friend WithEvents flpServices As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlCart As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents btnCheckout As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnClearCart As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCosmetics As Button
    Friend WithEvents btnGrooming As Button
    Friend WithEvents btnHair As Button
    Friend WithEvents btnAll As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents pnlUnderlineAll As Panel
    Friend WithEvents pnlUnderlineCosmetics As Panel
    Friend WithEvents pnlUnderlineGrooming As Panel
    Friend WithEvents pnlUnderlineHair As Panel
    Friend WithEvents tmrClock As Timer
    Friend WithEvents Button5 As Button
End Class
