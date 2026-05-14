<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageServices
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
        Me.chkArchivedServices = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchService = New System.Windows.Forms.TextBox()
        Me.btnAddService = New System.Windows.Forms.Button()
        Me.dgvServices = New System.Windows.Forms.DataGridView()
        CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkArchivedServices
        '
        Me.chkArchivedServices.AutoSize = True
        Me.chkArchivedServices.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArchivedServices.Location = New System.Drawing.Point(406, 100)
        Me.chkArchivedServices.Name = "chkArchivedServices"
        Me.chkArchivedServices.Size = New System.Drawing.Size(134, 21)
        Me.chkArchivedServices.TabIndex = 17
        Me.chkArchivedServices.Text = "Archived Services"
        Me.chkArchivedServices.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Manage Services"
        '
        'txtSearchService
        '
        Me.txtSearchService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchService.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchService.Location = New System.Drawing.Point(12, 97)
        Me.txtSearchService.Name = "txtSearchService"
        Me.txtSearchService.Size = New System.Drawing.Size(376, 24)
        Me.txtSearchService.TabIndex = 15
        '
        'btnAddService
        '
        Me.btnAddService.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddService.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddService.FlatAppearance.BorderSize = 0
        Me.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddService.Font = New System.Drawing.Font("DM Sans", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddService.ForeColor = System.Drawing.Color.White
        Me.btnAddService.Location = New System.Drawing.Point(922, 92)
        Me.btnAddService.Name = "btnAddService"
        Me.btnAddService.Size = New System.Drawing.Size(161, 34)
        Me.btnAddService.TabIndex = 14
        Me.btnAddService.Text = "+  Add Service"
        Me.btnAddService.UseVisualStyleBackColor = False
        '
        'dgvServices
        '
        Me.dgvServices.AllowUserToAddRows = False
        Me.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvServices.BackgroundColor = System.Drawing.Color.White
        Me.dgvServices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvServices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServices.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvServices.EnableHeadersVisualStyles = False
        Me.dgvServices.Location = New System.Drawing.Point(0, 140)
        Me.dgvServices.Name = "dgvServices"
        Me.dgvServices.ReadOnly = True
        Me.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServices.Size = New System.Drawing.Size(1106, 431)
        Me.dgvServices.TabIndex = 13
        '
        'frmManageServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 571)
        Me.Controls.Add(Me.chkArchivedServices)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchService)
        Me.Controls.Add(Me.btnAddService)
        Me.Controls.Add(Me.dgvServices)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageServices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Services"
        CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkArchivedServices As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearchService As TextBox
    Friend WithEvents btnAddService As Button
    Friend WithEvents dgvServices As DataGridView
End Class
