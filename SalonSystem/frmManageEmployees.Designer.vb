<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageEmployees
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
        Me.txtSearchEmployee = New System.Windows.Forms.TextBox()
        Me.btnAddEmployee = New System.Windows.Forms.Button()
        Me.dgvEmployees = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkArchivedEmployees = New System.Windows.Forms.CheckBox()
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearchEmployee
        '
        Me.txtSearchEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchEmployee.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchEmployee.Location = New System.Drawing.Point(12, 91)
        Me.txtSearchEmployee.Name = "txtSearchEmployee"
        Me.txtSearchEmployee.Size = New System.Drawing.Size(478, 24)
        Me.txtSearchEmployee.TabIndex = 10
        '
        'btnAddEmployee
        '
        Me.btnAddEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEmployee.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddEmployee.FlatAppearance.BorderSize = 0
        Me.btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddEmployee.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEmployee.ForeColor = System.Drawing.Color.White
        Me.btnAddEmployee.Location = New System.Drawing.Point(919, 81)
        Me.btnAddEmployee.Name = "btnAddEmployee"
        Me.btnAddEmployee.Size = New System.Drawing.Size(166, 34)
        Me.btnAddEmployee.TabIndex = 9
        Me.btnAddEmployee.Text = "+  Add Employee"
        Me.btnAddEmployee.UseVisualStyleBackColor = False
        '
        'dgvEmployees
        '
        Me.dgvEmployees.AllowUserToAddRows = False
        Me.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmployees.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvEmployees.EnableHeadersVisualStyles = False
        Me.dgvEmployees.Location = New System.Drawing.Point(0, 140)
        Me.dgvEmployees.Name = "dgvEmployees"
        Me.dgvEmployees.ReadOnly = True
        Me.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmployees.Size = New System.Drawing.Size(1106, 431)
        Me.dgvEmployees.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Manage Employees"
        '
        'chkArchivedEmployees
        '
        Me.chkArchivedEmployees.AutoSize = True
        Me.chkArchivedEmployees.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArchivedEmployees.Location = New System.Drawing.Point(518, 94)
        Me.chkArchivedEmployees.Name = "chkArchivedEmployees"
        Me.chkArchivedEmployees.Size = New System.Drawing.Size(147, 21)
        Me.chkArchivedEmployees.TabIndex = 12
        Me.chkArchivedEmployees.Text = "Archived Employees"
        Me.chkArchivedEmployees.UseVisualStyleBackColor = True
        '
        'frmManageEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 571)
        Me.Controls.Add(Me.chkArchivedEmployees)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchEmployee)
        Me.Controls.Add(Me.btnAddEmployee)
        Me.Controls.Add(Me.dgvEmployees)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageEmployees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Employees"
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSearchEmployee As TextBox
    Friend WithEvents btnAddEmployee As Button
    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents chkArchivedEmployees As CheckBox
End Class
