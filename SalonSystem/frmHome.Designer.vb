<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
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
        Me.wvDashboard = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.wvDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wvDashboard
        '
        Me.wvDashboard.AllowExternalDrop = True
        Me.wvDashboard.CreationProperties = Nothing
        Me.wvDashboard.DefaultBackgroundColor = System.Drawing.Color.White
        Me.wvDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wvDashboard.Location = New System.Drawing.Point(0, 0)
        Me.wvDashboard.Name = "wvDashboard"
        Me.wvDashboard.Size = New System.Drawing.Size(1323, 703)
        Me.wvDashboard.TabIndex = 58
        Me.wvDashboard.ZoomFactor = 1.0R
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1323, 703)
        Me.Controls.Add(Me.wvDashboard)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        CType(Me.wvDashboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wvDashboard As Microsoft.Web.WebView2.WinForms.WebView2
End Class
