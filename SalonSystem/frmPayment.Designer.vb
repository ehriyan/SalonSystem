<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment
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
        Me.Label = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCompleteSale = New System.Windows.Forms.Button()
        Me.rdoCash = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoGCash = New System.Windows.Forms.RadioButton()
        Me.rdoCard = New System.Windows.Forms.RadioButton()
        Me.pnlCashDetails = New System.Windows.Forms.Panel()
        Me.lblChangeDue = New System.Windows.Forms.Label()
        Me.txtAmountReceived = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAmountDue = New System.Windows.Forms.Label()
        Me.pnlCardDetails = New System.Windows.Forms.Panel()
        Me.txtCardRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlGCashDetails = New System.Windows.Forms.Panel()
        Me.txtGCashRef = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCashDetails.SuspendLayout()
        Me.pnlCardDetails.SuspendLayout()
        Me.pnlGCashDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("DM Sans", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.Location = New System.Drawing.Point(105, 60)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(158, 31)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Amount Due:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancel.Location = New System.Drawing.Point(54, 408)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(201, 44)
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
        Me.btnCompleteSale.Location = New System.Drawing.Point(293, 408)
        Me.btnCompleteSale.Name = "btnCompleteSale"
        Me.btnCompleteSale.Size = New System.Drawing.Size(201, 44)
        Me.btnCompleteSale.TabIndex = 4
        Me.btnCompleteSale.Text = "Complete Sale"
        Me.btnCompleteSale.UseVisualStyleBackColor = False
        '
        'rdoCash
        '
        Me.rdoCash.AutoSize = True
        Me.rdoCash.Font = New System.Drawing.Font("DM Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCash.Location = New System.Drawing.Point(23, 23)
        Me.rdoCash.Name = "rdoCash"
        Me.rdoCash.Size = New System.Drawing.Size(167, 32)
        Me.rdoCash.TabIndex = 6
        Me.rdoCash.TabStop = True
        Me.rdoCash.Text = "Pay with Cash"
        Me.rdoCash.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoGCash)
        Me.GroupBox1.Controls.Add(Me.rdoCard)
        Me.GroupBox1.Controls.Add(Me.rdoCash)
        Me.GroupBox1.Location = New System.Drawing.Point(54, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 143)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'rdoGCash
        '
        Me.rdoGCash.AutoSize = True
        Me.rdoGCash.Font = New System.Drawing.Font("DM Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoGCash.Location = New System.Drawing.Point(23, 91)
        Me.rdoGCash.Name = "rdoGCash"
        Me.rdoGCash.Size = New System.Drawing.Size(183, 32)
        Me.rdoGCash.TabIndex = 8
        Me.rdoGCash.TabStop = True
        Me.rdoGCash.Text = "Pay with GCash"
        Me.rdoGCash.UseVisualStyleBackColor = True
        '
        'rdoCard
        '
        Me.rdoCard.AutoSize = True
        Me.rdoCard.Font = New System.Drawing.Font("DM Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCard.Location = New System.Drawing.Point(23, 56)
        Me.rdoCard.Name = "rdoCard"
        Me.rdoCard.Size = New System.Drawing.Size(165, 32)
        Me.rdoCard.TabIndex = 7
        Me.rdoCard.TabStop = True
        Me.rdoCard.Text = "Pay with Card"
        Me.rdoCard.UseVisualStyleBackColor = True
        '
        'pnlCashDetails
        '
        Me.pnlCashDetails.Controls.Add(Me.lblChangeDue)
        Me.pnlCashDetails.Controls.Add(Me.txtAmountReceived)
        Me.pnlCashDetails.Controls.Add(Me.Label2)
        Me.pnlCashDetails.Controls.Add(Me.Label1)
        Me.pnlCashDetails.Location = New System.Drawing.Point(54, 258)
        Me.pnlCashDetails.Name = "pnlCashDetails"
        Me.pnlCashDetails.Size = New System.Drawing.Size(440, 123)
        Me.pnlCashDetails.TabIndex = 8
        '
        'lblChangeDue
        '
        Me.lblChangeDue.AutoSize = True
        Me.lblChangeDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDue.Location = New System.Drawing.Point(218, 67)
        Me.lblChangeDue.Name = "lblChangeDue"
        Me.lblChangeDue.Size = New System.Drawing.Size(117, 24)
        Me.lblChangeDue.TabIndex = 12
        Me.lblChangeDue.Text = "Change Due"
        '
        'txtAmountReceived
        '
        Me.txtAmountReceived.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountReceived.Location = New System.Drawing.Point(222, 24)
        Me.txtAmountReceived.Name = "txtAmountReceived"
        Me.txtAmountReceived.Size = New System.Drawing.Size(190, 28)
        Me.txtAmountReceived.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Change Due:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 24)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Amount Received:"
        '
        'lblAmountDue
        '
        Me.lblAmountDue.AutoSize = True
        Me.lblAmountDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountDue.Location = New System.Drawing.Point(277, 57)
        Me.lblAmountDue.Name = "lblAmountDue"
        Me.lblAmountDue.Size = New System.Drawing.Size(176, 33)
        Me.lblAmountDue.TabIndex = 9
        Me.lblAmountDue.Text = "Amount Due"
        '
        'pnlCardDetails
        '
        Me.pnlCardDetails.Controls.Add(Me.txtCardRef)
        Me.pnlCardDetails.Controls.Add(Me.Label5)
        Me.pnlCardDetails.Location = New System.Drawing.Point(54, 258)
        Me.pnlCardDetails.Name = "pnlCardDetails"
        Me.pnlCardDetails.Size = New System.Drawing.Size(440, 123)
        Me.pnlCardDetails.TabIndex = 10
        Me.pnlCardDetails.Visible = False
        '
        'txtCardRef
        '
        Me.txtCardRef.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardRef.Location = New System.Drawing.Point(209, 24)
        Me.txtCardRef.Name = "txtCardRef"
        Me.txtCardRef.Size = New System.Drawing.Size(190, 28)
        Me.txtCardRef.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 24)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Ref Number:"
        '
        'pnlGCashDetails
        '
        Me.pnlGCashDetails.Controls.Add(Me.txtGCashRef)
        Me.pnlGCashDetails.Controls.Add(Me.Label3)
        Me.pnlGCashDetails.Location = New System.Drawing.Point(54, 258)
        Me.pnlGCashDetails.Name = "pnlGCashDetails"
        Me.pnlGCashDetails.Size = New System.Drawing.Size(440, 123)
        Me.pnlGCashDetails.TabIndex = 11
        Me.pnlGCashDetails.Visible = False
        '
        'txtGCashRef
        '
        Me.txtGCashRef.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGCashRef.Location = New System.Drawing.Point(212, 24)
        Me.txtGCashRef.Name = "txtGCashRef"
        Me.txtGCashRef.Size = New System.Drawing.Size(200, 28)
        Me.txtGCashRef.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 24)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "GCash Ref Number:"
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.SlateGray
        Me.lblExit.Location = New System.Drawing.Point(503, 9)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(32, 33)
        Me.lblExit.TabIndex = 60
        Me.lblExit.Text = "×"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(547, 497)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.pnlGCashDetails)
        Me.Controls.Add(Me.lblAmountDue)
        Me.Controls.Add(Me.pnlCardDetails)
        Me.Controls.Add(Me.pnlCashDetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCompleteSale)
        Me.Controls.Add(Me.Label)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process Payment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCashDetails.ResumeLayout(False)
        Me.pnlCashDetails.PerformLayout()
        Me.pnlCardDetails.ResumeLayout(False)
        Me.pnlCardDetails.PerformLayout()
        Me.pnlGCashDetails.ResumeLayout(False)
        Me.pnlGCashDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCompleteSale As Button
    Friend WithEvents rdoCash As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoGCash As RadioButton
    Friend WithEvents rdoCard As RadioButton
    Friend WithEvents pnlCashDetails As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblChangeDue As Label
    Friend WithEvents txtAmountReceived As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAmountDue As Label
    Friend WithEvents pnlCardDetails As Panel
    Friend WithEvents txtCardRef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlGCashDetails As Panel
    Friend WithEvents txtGCashRef As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblExit As Label
End Class
