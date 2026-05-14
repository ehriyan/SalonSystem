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
        Me.btnAddNote = New System.Windows.Forms.Button()
        Me.btnEmptyCart = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnDiscount = New System.Windows.Forms.Button()
        Me.pnlCart = New System.Windows.Forms.Panel()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSelectClient = New System.Windows.Forms.Button()
        Me.lblActiveClient = New System.Windows.Forms.Label()
        Me.btnCheckout = New System.Windows.Forms.Button()
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
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
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
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Location = New System.Drawing.Point(1081, 11)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(91, 20)
        Me.lblTime.TabIndex = 8
        Me.lblTime.Text = "Time:"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(855, 11)
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
        Me.Label3.ForeColor = System.Drawing.Color.White
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
        Me.btnReturn.Size = New System.Drawing.Size(174, 28)
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
        Me.flpServices.Size = New System.Drawing.Size(696, 585)
        Me.flpServices.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Controls.Add(Me.btnAddNote)
        Me.Panel2.Controls.Add(Me.btnEmptyCart)
        Me.Panel2.Controls.Add(Me.btnVoid)
        Me.Panel2.Controls.Add(Me.btnDiscount)
        Me.Panel2.Controls.Add(Me.btnReturn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 683)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1184, 28)
        Me.Panel2.TabIndex = 2
        '
        'btnAddNote
        '
        Me.btnAddNote.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddNote.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAddNote.FlatAppearance.BorderSize = 0
        Me.btnAddNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNote.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNote.ForeColor = System.Drawing.Color.White
        Me.btnAddNote.Location = New System.Drawing.Point(564, 0)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(130, 28)
        Me.btnAddNote.TabIndex = 7
        Me.btnAddNote.Text = "Note"
        Me.btnAddNote.UseVisualStyleBackColor = False
        '
        'btnEmptyCart
        '
        Me.btnEmptyCart.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnEmptyCart.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEmptyCart.FlatAppearance.BorderSize = 0
        Me.btnEmptyCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmptyCart.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmptyCart.ForeColor = System.Drawing.Color.White
        Me.btnEmptyCart.Location = New System.Drawing.Point(434, 0)
        Me.btnEmptyCart.Name = "btnEmptyCart"
        Me.btnEmptyCart.Size = New System.Drawing.Size(130, 28)
        Me.btnEmptyCart.TabIndex = 6
        Me.btnEmptyCart.Text = "Empty Cart"
        Me.btnEmptyCart.UseVisualStyleBackColor = False
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnVoid.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnVoid.FlatAppearance.BorderSize = 0
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoid.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.ForeColor = System.Drawing.Color.White
        Me.btnVoid.Location = New System.Drawing.Point(304, 0)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(130, 28)
        Me.btnVoid.TabIndex = 5
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'btnDiscount
        '
        Me.btnDiscount.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnDiscount.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDiscount.FlatAppearance.BorderSize = 0
        Me.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscount.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscount.ForeColor = System.Drawing.Color.White
        Me.btnDiscount.Location = New System.Drawing.Point(174, 0)
        Me.btnDiscount.Name = "btnDiscount"
        Me.btnDiscount.Size = New System.Drawing.Size(130, 28)
        Me.btnDiscount.TabIndex = 2
        Me.btnDiscount.Text = "Discount"
        Me.btnDiscount.UseVisualStyleBackColor = False
        '
        'pnlCart
        '
        Me.pnlCart.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCart.Controls.Add(Me.lblDiscount)
        Me.pnlCart.Controls.Add(Me.Panel5)
        Me.pnlCart.Controls.Add(Me.Label4)
        Me.pnlCart.Controls.Add(Me.Label2)
        Me.pnlCart.Controls.Add(Me.lblSubtotal)
        Me.pnlCart.Controls.Add(Me.lblTotal)
        Me.pnlCart.Controls.Add(Me.dgvCart)
        Me.pnlCart.Controls.Add(Me.Panel3)
        Me.pnlCart.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCart.Location = New System.Drawing.Point(696, 39)
        Me.pnlCart.Name = "pnlCart"
        Me.pnlCart.Size = New System.Drawing.Size(488, 644)
        Me.pnlCart.TabIndex = 3
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount.ForeColor = System.Drawing.Color.DimGray
        Me.lblDiscount.Location = New System.Drawing.Point(30, 444)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(76, 20)
        Me.lblDiscount.TabIndex = 8
        Me.lblDiscount.Text = "Discount:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightGray
        Me.Panel5.Location = New System.Drawing.Point(37, 498)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(420, 1)
        Me.Panel5.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(30, 464)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tax:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DimGray
        Me.lblSubtotal.Location = New System.Drawing.Point(30, 424)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(71, 20)
        Me.lblSubtotal.TabIndex = 4
        Me.lblSubtotal.Text = "Subtotal:"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(245, 513)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(220, 25)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "Total Price"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCart.GridColor = System.Drawing.Color.White
        Me.dgvCart.Location = New System.Drawing.Point(0, 0)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersVisible = False
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCart.Size = New System.Drawing.Size(488, 402)
        Me.dgvCart.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.btnSelectClient)
        Me.Panel3.Controls.Add(Me.lblActiveClient)
        Me.Panel3.Controls.Add(Me.btnCheckout)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 554)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(488, 90)
        Me.Panel3.TabIndex = 10
        '
        'btnSelectClient
        '
        Me.btnSelectClient.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnSelectClient.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSelectClient.FlatAppearance.BorderSize = 0
        Me.btnSelectClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectClient.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectClient.ForeColor = System.Drawing.Color.White
        Me.btnSelectClient.Location = New System.Drawing.Point(0, 0)
        Me.btnSelectClient.Name = "btnSelectClient"
        Me.btnSelectClient.Size = New System.Drawing.Size(171, 42)
        Me.btnSelectClient.TabIndex = 8
        Me.btnSelectClient.Text = "Select Client"
        Me.btnSelectClient.UseVisualStyleBackColor = False
        '
        'lblActiveClient
        '
        Me.lblActiveClient.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveClient.Location = New System.Drawing.Point(192, 7)
        Me.lblActiveClient.Name = "lblActiveClient"
        Me.lblActiveClient.Size = New System.Drawing.Size(288, 31)
        Me.lblActiveClient.TabIndex = 9
        Me.lblActiveClient.Text = "Client Name"
        Me.lblActiveClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCheckout
        '
        Me.btnCheckout.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCheckout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnCheckout.FlatAppearance.BorderSize = 0
        Me.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckout.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.White
        Me.btnCheckout.Location = New System.Drawing.Point(0, 42)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(488, 48)
        Me.btnCheckout.TabIndex = 2
        Me.btnCheckout.Text = "Pay"
        Me.btnCheckout.UseVisualStyleBackColor = False
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
        Me.Panel4.Size = New System.Drawing.Size(696, 59)
        Me.Panel4.TabIndex = 0
        '
        'pnlUnderlineCosmetics
        '
        Me.pnlUnderlineCosmetics.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnlUnderlineCosmetics.Location = New System.Drawing.Point(550, 47)
        Me.pnlUnderlineCosmetics.Name = "pnlUnderlineCosmetics"
        Me.pnlUnderlineCosmetics.Size = New System.Drawing.Size(120, 3)
        Me.pnlUnderlineCosmetics.TabIndex = 3
        Me.pnlUnderlineCosmetics.Visible = False
        '
        'pnlUnderlineGrooming
        '
        Me.pnlUnderlineGrooming.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnlUnderlineGrooming.Location = New System.Drawing.Point(376, 47)
        Me.pnlUnderlineGrooming.Name = "pnlUnderlineGrooming"
        Me.pnlUnderlineGrooming.Size = New System.Drawing.Size(120, 3)
        Me.pnlUnderlineGrooming.TabIndex = 3
        Me.pnlUnderlineGrooming.Visible = False
        '
        'pnlUnderlineHair
        '
        Me.pnlUnderlineHair.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnlUnderlineHair.Location = New System.Drawing.Point(202, 47)
        Me.pnlUnderlineHair.Name = "pnlUnderlineHair"
        Me.pnlUnderlineHair.Size = New System.Drawing.Size(120, 3)
        Me.pnlUnderlineHair.TabIndex = 2
        Me.pnlUnderlineHair.Visible = False
        '
        'pnlUnderlineAll
        '
        Me.pnlUnderlineAll.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnlUnderlineAll.Location = New System.Drawing.Point(28, 47)
        Me.pnlUnderlineAll.Name = "pnlUnderlineAll"
        Me.pnlUnderlineAll.Size = New System.Drawing.Size(120, 3)
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
        Me.btnCosmetics.Location = New System.Drawing.Point(522, 0)
        Me.btnCosmetics.Name = "btnCosmetics"
        Me.btnCosmetics.Size = New System.Drawing.Size(174, 59)
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
        Me.btnGrooming.Location = New System.Drawing.Point(348, 0)
        Me.btnGrooming.Name = "btnGrooming"
        Me.btnGrooming.Size = New System.Drawing.Size(174, 59)
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
        Me.btnHair.Location = New System.Drawing.Point(174, 0)
        Me.btnHair.Name = "btnHair"
        Me.btnHair.Size = New System.Drawing.Size(174, 59)
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
        Me.btnAll.Size = New System.Drawing.Size(174, 59)
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
        Me.ClientSize = New System.Drawing.Size(1184, 711)
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
        Me.Panel3.ResumeLayout(False)
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
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents btnCosmetics As Button
    Friend WithEvents btnGrooming As Button
    Friend WithEvents btnHair As Button
    Friend WithEvents btnAll As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents btnDiscount As Button
    Friend WithEvents pnlUnderlineAll As Panel
    Friend WithEvents pnlUnderlineCosmetics As Panel
    Friend WithEvents pnlUnderlineGrooming As Panel
    Friend WithEvents pnlUnderlineHair As Panel
    Friend WithEvents tmrClock As Timer
    Friend WithEvents btnVoid As Button
    Friend WithEvents lblDiscount As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddNote As Button
    Friend WithEvents btnEmptyCart As Button
    Friend WithEvents btnSelectClient As Button
    Friend WithEvents lblActiveClient As Label
    Friend WithEvents Panel3 As Panel
End Class
