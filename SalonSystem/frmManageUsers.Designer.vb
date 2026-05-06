<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageUsers
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
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsers.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.EnableHeadersVisualStyles = False
        Me.dgvUsers.Location = New System.Drawing.Point(16, 97)
        Me.dgvUsers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.RowHeadersWidth = 51
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(1443, 591)
        Me.dgvUsers.TabIndex = 0
        '
        'btnAddUser
        '
        Me.btnAddUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddUser.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddUser.FlatAppearance.BorderSize = 0
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.Color.White
        Me.btnAddUser.Location = New System.Drawing.Point(1263, 23)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(181, 42)
        Me.btnAddUser.TabIndex = 1
        Me.btnAddUser.Text = "+  Add User"
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(119, 31)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(863, 26)
        Me.txtSearch.TabIndex = 6
        '
        'frmManageUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1475, 703)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnAddUser)
        Me.Controls.Add(Me.dgvUsers)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Users"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents btnAddUser As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
End Class
