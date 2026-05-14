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
        Me.txtSearchClient = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkArchivedClients = New System.Windows.Forms.CheckBox()
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
        Me.btnAddClient.Location = New System.Drawing.Point(939, 90)
        Me.btnAddClient.Name = "btnAddClient"
        Me.btnAddClient.Size = New System.Drawing.Size(141, 34)
        Me.btnAddClient.TabIndex = 3
        Me.btnAddClient.Text = "+  Add Client"
        Me.btnAddClient.UseVisualStyleBackColor = False
        '
        'dgvClients
        '
        Me.dgvClients.AllowUserToAddRows = False
        Me.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClients.BackgroundColor = System.Drawing.Color.White
        Me.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClients.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvClients.Location = New System.Drawing.Point(0, 140)
        Me.dgvClients.Name = "dgvClients"
        Me.dgvClients.ReadOnly = True
        Me.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClients.Size = New System.Drawing.Size(1106, 431)
        Me.dgvClients.TabIndex = 2
        '
        'txtSearchClient
        '
        Me.txtSearchClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchClient.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchClient.Location = New System.Drawing.Point(23, 100)
        Me.txtSearchClient.Name = "txtSearchClient"
        Me.txtSearchClient.Size = New System.Drawing.Size(367, 24)
        Me.txtSearchClient.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("DM Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Manage Clients"
        '
        'chkArchivedClients
        '
        Me.chkArchivedClients.AutoSize = True
        Me.chkArchivedClients.Font = New System.Drawing.Font("DM Sans", 9.749998!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArchivedClients.Location = New System.Drawing.Point(428, 102)
        Me.chkArchivedClients.Name = "chkArchivedClients"
        Me.chkArchivedClients.Size = New System.Drawing.Size(124, 21)
        Me.chkArchivedClients.TabIndex = 13
        Me.chkArchivedClients.Text = "Archived Clients"
        Me.chkArchivedClients.UseVisualStyleBackColor = True
        '
        'frmManageClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1106, 571)
        Me.Controls.Add(Me.chkArchivedClients)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchClient)
        Me.Controls.Add(Me.btnAddClient)
        Me.Controls.Add(Me.dgvClients)
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
    Friend WithEvents txtSearchClient As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkArchivedClients As CheckBox
End Class
