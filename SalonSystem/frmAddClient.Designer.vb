<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddClient
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.dtpBirthday = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpInitialVisit = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCustomerType = New System.Windows.Forms.ComboBox()
        Me.chkReturning = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(44, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Contact No.:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(148, 197)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(305, 27)
        Me.txtContact.TabIndex = 42
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("DM Sans", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(42, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(246, 39)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Add New Client"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Last Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(148, 153)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(305, 27)
        Me.txtLastName.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 20)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "First Name:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(148, 110)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(305, 27)
        Me.txtFirstName.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 248)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Email:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(148, 241)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(305, 27)
        Me.txtEmail.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Address:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(148, 284)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(305, 27)
        Me.txtAddress.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(70, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Remarks:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(148, 330)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(305, 109)
        Me.txtRemarks.TabIndex = 46
        '
        'dtpBirthday
        '
        Me.dtpBirthday.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBirthday.Location = New System.Drawing.Point(622, 147)
        Me.dtpBirthday.Name = "dtpBirthday"
        Me.dtpBirthday.Size = New System.Drawing.Size(166, 27)
        Me.dtpBirthday.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(546, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Birthday:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInitialVisit
        '
        Me.dtpInitialVisit.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInitialVisit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInitialVisit.Location = New System.Drawing.Point(622, 188)
        Me.dtpInitialVisit.Name = "dtpInitialVisit"
        Me.dtpInitialVisit.Size = New System.Drawing.Size(166, 27)
        Me.dtpInitialVisit.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(531, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Initial Visit:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(496, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 20)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Customer Type:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomerType
        '
        Me.cmbCustomerType.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomerType.FormattingEnabled = True
        Me.cmbCustomerType.Items.AddRange(New Object() {"Regular", "Walk-in"})
        Me.cmbCustomerType.Location = New System.Drawing.Point(622, 228)
        Me.cmbCustomerType.Name = "cmbCustomerType"
        Me.cmbCustomerType.Size = New System.Drawing.Size(166, 25)
        Me.cmbCustomerType.TabIndex = 52
        '
        'chkReturning
        '
        Me.chkReturning.AutoSize = True
        Me.chkReturning.Font = New System.Drawing.Font("DM Sans", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReturning.Location = New System.Drawing.Point(626, 268)
        Me.chkReturning.Name = "chkReturning"
        Me.chkReturning.Size = New System.Drawing.Size(61, 29)
        Me.chkReturning.TabIndex = 54
        Me.chkReturning.Text = "Yes"
        Me.chkReturning.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(531, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 20)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Returning"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(520, 284)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 20)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Customer?"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancel.Location = New System.Drawing.Point(524, 397)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(266, 46)
        Me.btnCancel.TabIndex = 58
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("DM Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(524, 337)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(266, 46)
        Me.btnSave.TabIndex = 57
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.SlateGray
        Me.lblExit.Location = New System.Drawing.Point(824, 6)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(32, 33)
        Me.lblExit.TabIndex = 59
        Me.lblExit.Text = "×"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("DM Sans", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Silver
        Me.Label13.Location = New System.Drawing.Point(497, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 18)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Additional Information"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(496, 131)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(316, 1)
        Me.Panel1.TabIndex = 61
        '
        'frmAddClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(862, 476)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkReturning)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbCustomerType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpInitialVisit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpBirthday)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As Label
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents dtpBirthday As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpInitialVisit As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbCustomerType As ComboBox
    Friend WithEvents chkReturning As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblExit As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
End Class
