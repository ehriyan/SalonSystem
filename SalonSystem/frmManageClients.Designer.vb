<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageClients
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
        Me.btnAddClient = New System.Windows.Forms.Button()
        Me.dgvClients = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddClient
        '
        Me.btnAddClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddClient.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAddClient.FlatAppearance.BorderSize = 0
        Me.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddClient.ForeColor = System.Drawing.Color.White
        Me.btnAddClient.Location = New System.Drawing.Point(1257, 26)
        Me.btnAddClient.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddClient.Name = "btnAddClient"
        Me.btnAddClient.Size = New System.Drawing.Size(188, 42)
        Me.btnAddClient.TabIndex = 3
        Me.btnAddClient.Text = "+  Add Client"
        Me.btnAddClient.UseVisualStyleBackColor = False
        '
        'dgvClients
        '
        Me.dgvClients.AllowUserToAddRows = False
        Me.dgvClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClients.BackgroundColor = System.Drawing.Color.White
        Me.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClients.Location = New System.Drawing.Point(16, 96)
        Me.dgvClients.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvClients.Name = "dgvClients"
        Me.dgvClients.ReadOnly = True
        Me.dgvClients.RowHeadersWidth = 51
        Me.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClients.Size = New System.Drawing.Size(1443, 592)
        Me.dgvClients.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(119, 32)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(863, 26)
        Me.txtSearch.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Search:"
        '
        'frmManageClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1475, 703)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnAddClient)
        Me.Controls.Add(Me.dgvClients)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Clients"
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAddClient As Button
    Friend WithEvents dgvClients As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
End Class
