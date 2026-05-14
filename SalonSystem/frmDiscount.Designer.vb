<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiscount
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.lblOriginalPrice = New System.Windows.Forms.Label()
        Me.rdoPercentage = New System.Windows.Forms.RadioButton()
        Me.rdoFixed = New System.Windows.Forms.RadioButton()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.lblDeduction = New System.Windows.Forms.Label()
        Me.lblNewTotal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("DM Sans", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(168, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 35)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Add Discount"
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.SlateGray
        Me.lblExit.Location = New System.Drawing.Point(544, 9)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(32, 33)
        Me.lblExit.TabIndex = 71
        Me.lblExit.Text = "×"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblItemName
        '
        Me.lblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.Location = New System.Drawing.Point(37, 91)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(460, 33)
        Me.lblItemName.TabIndex = 68
        Me.lblItemName.Text = "Service Name"
        Me.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancel.Location = New System.Drawing.Point(35, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(223, 54)
        Me.btnCancel.TabIndex = 66
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnApply.FlatAppearance.BorderSize = 0
        Me.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApply.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.Color.White
        Me.btnApply.Location = New System.Drawing.Point(274, 412)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(223, 54)
        Me.btnApply.TabIndex = 65
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'lblOriginalPrice
        '
        Me.lblOriginalPrice.Font = New System.Drawing.Font("DM Sans", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalPrice.Location = New System.Drawing.Point(52, 124)
        Me.lblOriginalPrice.Name = "lblOriginalPrice"
        Me.lblOriginalPrice.Size = New System.Drawing.Size(422, 31)
        Me.lblOriginalPrice.TabIndex = 64
        Me.lblOriginalPrice.Text = "Service Price"
        Me.lblOriginalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoPercentage
        '
        Me.rdoPercentage.AutoSize = True
        Me.rdoPercentage.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPercentage.Location = New System.Drawing.Point(84, 183)
        Me.rdoPercentage.Name = "rdoPercentage"
        Me.rdoPercentage.Size = New System.Drawing.Size(136, 24)
        Me.rdoPercentage.TabIndex = 73
        Me.rdoPercentage.TabStop = True
        Me.rdoPercentage.Text = "Percentage (%)"
        Me.rdoPercentage.UseVisualStyleBackColor = True
        '
        'rdoFixed
        '
        Me.rdoFixed.AutoSize = True
        Me.rdoFixed.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFixed.Location = New System.Drawing.Point(307, 183)
        Me.rdoFixed.Name = "rdoFixed"
        Me.rdoFixed.Size = New System.Drawing.Size(124, 24)
        Me.rdoFixed.TabIndex = 74
        Me.rdoFixed.TabStop = True
        Me.rdoFixed.Text = "Fixed Amount"
        Me.rdoFixed.UseVisualStyleBackColor = True
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(102, 228)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(341, 43)
        Me.txtInput.TabIndex = 75
        '
        'cmbReason
        '
        Me.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Location = New System.Drawing.Point(99, 280)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(341, 21)
        Me.cmbReason.TabIndex = 76
        '
        'lblDeduction
        '
        Me.lblDeduction.Font = New System.Drawing.Font("DM Sans", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeduction.Location = New System.Drawing.Point(72, 321)
        Me.lblDeduction.Name = "lblDeduction"
        Me.lblDeduction.Size = New System.Drawing.Size(392, 31)
        Me.lblDeduction.TabIndex = 77
        Me.lblDeduction.Text = "Deduction"
        Me.lblDeduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNewTotal
        '
        Me.lblNewTotal.Font = New System.Drawing.Font("DM Sans", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewTotal.Location = New System.Drawing.Point(75, 353)
        Me.lblNewTotal.Name = "lblNewTotal"
        Me.lblNewTotal.Size = New System.Drawing.Size(382, 31)
        Me.lblNewTotal.TabIndex = 78
        Me.lblNewTotal.Text = "New Total"
        Me.lblNewTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(525, 488)
        Me.Controls.Add(Me.lblNewTotal)
        Me.Controls.Add(Me.lblDeduction)
        Me.Controls.Add(Me.cmbReason)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.rdoFixed)
        Me.Controls.Add(Me.rdoPercentage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblOriginalPrice)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Discount"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents lblExit As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnApply As Button
    Friend WithEvents lblOriginalPrice As Label
    Friend WithEvents rdoPercentage As RadioButton
    Friend WithEvents rdoFixed As RadioButton
    Friend WithEvents txtInput As TextBox
    Friend WithEvents cmbReason As ComboBox
    Friend WithEvents lblDeduction As Label
    Friend WithEvents lblNewTotal As Label
End Class
