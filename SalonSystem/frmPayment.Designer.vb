<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayment
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCompleteSale = New System.Windows.Forms.Button()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdoCash = New System.Windows.Forms.RadioButton()
        Me.rdoGCash = New System.Windows.Forms.RadioButton()
        Me.rdoCard = New System.Windows.Forms.RadioButton()
        Me.lblTotalDue = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtTendered = New System.Windows.Forms.TextBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancel.Location = New System.Drawing.Point(37, 594)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(297, 66)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnCompleteSale
        '
        Me.btnCompleteSale.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCompleteSale.FlatAppearance.BorderSize = 0
        Me.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompleteSale.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompleteSale.ForeColor = System.Drawing.Color.White
        Me.btnCompleteSale.Location = New System.Drawing.Point(356, 594)
        Me.btnCompleteSale.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCompleteSale.Name = "btnCompleteSale"
        Me.btnCompleteSale.Size = New System.Drawing.Size(297, 66)
        Me.btnCompleteSale.TabIndex = 4
        Me.btnCompleteSale.Text = "Complete Sale"
        Me.btnCompleteSale.UseVisualStyleBackColor = False
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.SlateGray
        Me.lblExit.Location = New System.Drawing.Point(676, 18)
        Me.lblExit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(40, 42)
        Me.lblExit.TabIndex = 60
        Me.lblExit.Text = "×"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("DM Sans", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(202, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(285, 43)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Process Payment"
        '
        'rdoCash
        '
        Me.rdoCash.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCash.BackColor = System.Drawing.Color.White
        Me.rdoCash.FlatAppearance.BorderSize = 0
        Me.rdoCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoCash.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCash.Location = New System.Drawing.Point(72, 162)
        Me.rdoCash.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.Size = New System.Drawing.Size(541, 59)
        Me.rdoCash.TabIndex = 64
        Me.rdoCash.TabStop = True
        Me.rdoCash.Text = "Pay with Cash"
        Me.rdoCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCash.UseVisualStyleBackColor = False
        '
        'rdoGCash
        '
        Me.rdoGCash.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoGCash.BackColor = System.Drawing.Color.White
        Me.rdoGCash.FlatAppearance.BorderSize = 0
        Me.rdoGCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoGCash.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoGCash.Location = New System.Drawing.Point(72, 236)
        Me.rdoGCash.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoGCash.Name = "rdoGCash"
        Me.rdoGCash.Size = New System.Drawing.Size(541, 59)
        Me.rdoGCash.TabIndex = 65
        Me.rdoGCash.TabStop = True
        Me.rdoGCash.Text = "Pay with GCash"
        Me.rdoGCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoGCash.UseVisualStyleBackColor = False
        '
        'rdoCard
        '
        Me.rdoCard.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCard.BackColor = System.Drawing.Color.White
        Me.rdoCard.FlatAppearance.BorderSize = 0
        Me.rdoCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoCard.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCard.Location = New System.Drawing.Point(72, 309)
        Me.rdoCard.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoCard.Name = "rdoCard"
        Me.rdoCard.Size = New System.Drawing.Size(541, 59)
        Me.rdoCard.TabIndex = 66
        Me.rdoCard.TabStop = True
        Me.rdoCard.Text = "Pay with Card"
        Me.rdoCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCard.UseVisualStyleBackColor = False
        '
        'lblTotalDue
        '
        Me.lblTotalDue.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDue.Location = New System.Drawing.Point(67, 120)
        Me.lblTotalDue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalDue.Name = "lblTotalDue"
        Me.lblTotalDue.Size = New System.Drawing.Size(541, 38)
        Me.lblTotalDue.TabIndex = 67
        Me.lblTotalDue.Text = "Amount Due:"
        Me.lblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChange
        '
        Me.lblChange.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(72, 459)
        Me.lblChange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(541, 38)
        Me.lblChange.TabIndex = 68
        Me.lblChange.Text = "Change"
        Me.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTendered
        '
        Me.txtTendered.Location = New System.Drawing.Point(127, 398)
        Me.txtTendered.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTendered.Multiline = True
        Me.txtTendered.Name = "txtTendered"
        Me.txtTendered.Size = New System.Drawing.Size(408, 41)
        Me.txtTendered.TabIndex = 69
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(148, 512)
        Me.txtReference.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReference.Multiline = True
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(387, 41)
        Me.txtReference.TabIndex = 70
        '
        'frmPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(684, 690)
        Me.Controls.Add(Me.txtReference)
        Me.Controls.Add(Me.txtTendered)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblTotalDue)
        Me.Controls.Add(Me.rdoCard)
        Me.Controls.Add(Me.rdoGCash)
        Me.Controls.Add(Me.rdoCash)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCompleteSale)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCompleteSale As Button
    Friend WithEvents lblExit As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rdoCash As RadioButton
    Friend WithEvents rdoGCash As RadioButton
    Friend WithEvents rdoCard As RadioButton
    Friend WithEvents lblTotalDue As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents txtTendered As TextBox
    Friend WithEvents txtReference As TextBox
End Class
