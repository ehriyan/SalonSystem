<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUser
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
        Me.wvAddForm = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.wvAddForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wvAddForm
        '
        Me.wvAddForm.AllowExternalDrop = True
        Me.wvAddForm.CreationProperties = Nothing
        Me.wvAddForm.DefaultBackgroundColor = System.Drawing.Color.White
        Me.wvAddForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wvAddForm.Location = New System.Drawing.Point(0, 0)
        Me.wvAddForm.Name = "wvAddForm"
        Me.wvAddForm.Size = New System.Drawing.Size(724, 492)
        Me.wvAddForm.TabIndex = 25
        Me.wvAddForm.ZoomFactor = 1.0R
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(724, 492)
        Me.Controls.Add(Me.wvAddForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add User"
        CType(Me.wvAddForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wvAddForm As Microsoft.Web.WebView2.WinForms.WebView2
End Class
