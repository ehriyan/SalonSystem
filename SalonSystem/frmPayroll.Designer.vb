<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayroll
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.btnLoadDashboard = New System.Windows.Forms.Button()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTotalPayroll = New System.Windows.Forms.Label()
        Me.lblTotalEmployees = New System.Windows.Forms.Label()
        Me.lblTotalCommission = New System.Windows.Forms.Label()
        Me.lblTotalDeductions = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.chartPayrollSummary = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartEmployeeDistribution = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartPayrollSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartEmployeeDistribution, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MistyRose
        Me.Panel1.Controls.Add(Me.btnLoadDashboard)
        Me.Panel1.Controls.Add(Me.dtpEnd)
        Me.Panel1.Controls.Add(Me.dtpStart)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1471, 100)
        Me.Panel1.TabIndex = 0
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Location = New System.Drawing.Point(1353, 879)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(93, 23)
        Me.btnExportExcel.TabIndex = 4
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'btnLoadDashboard
        '
        Me.btnLoadDashboard.Location = New System.Drawing.Point(1175, 48)
        Me.btnLoadDashboard.Name = "btnLoadDashboard"
        Me.btnLoadDashboard.Size = New System.Drawing.Size(132, 23)
        Me.btnLoadDashboard.TabIndex = 3
        Me.btnLoadDashboard.Text = "Load Dashboard"
        Me.btnLoadDashboard.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(944, 48)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(200, 22)
        Me.dtpEnd.TabIndex = 2
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(652, 47)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(200, 22)
        Me.dtpStart.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 51)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Payroll Dashboard"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalPayroll, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalEmployees, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalCommission, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalDeductions, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(552, 126)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(364, 260)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblTotalPayroll
        '
        Me.lblTotalPayroll.AutoSize = True
        Me.lblTotalPayroll.Location = New System.Drawing.Point(3, 0)
        Me.lblTotalPayroll.Name = "lblTotalPayroll"
        Me.lblTotalPayroll.Size = New System.Drawing.Size(83, 16)
        Me.lblTotalPayroll.TabIndex = 0
        Me.lblTotalPayroll.Text = "Total Payroll"
        '
        'lblTotalEmployees
        '
        Me.lblTotalEmployees.AutoSize = True
        Me.lblTotalEmployees.Location = New System.Drawing.Point(185, 0)
        Me.lblTotalEmployees.Name = "lblTotalEmployees"
        Me.lblTotalEmployees.Size = New System.Drawing.Size(76, 16)
        Me.lblTotalEmployees.TabIndex = 1
        Me.lblTotalEmployees.Text = "Employees"
        '
        'lblTotalCommission
        '
        Me.lblTotalCommission.AutoSize = True
        Me.lblTotalCommission.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTotalCommission.Location = New System.Drawing.Point(3, 130)
        Me.lblTotalCommission.Name = "lblTotalCommission"
        Me.lblTotalCommission.Size = New System.Drawing.Size(90, 19)
        Me.lblTotalCommission.TabIndex = 2
        Me.lblTotalCommission.Text = "Commissions"
        '
        'lblTotalDeductions
        '
        Me.lblTotalDeductions.AutoSize = True
        Me.lblTotalDeductions.Location = New System.Drawing.Point(185, 130)
        Me.lblTotalDeductions.Name = "lblTotalDeductions"
        Me.lblTotalDeductions.Size = New System.Drawing.Size(75, 16)
        Me.lblTotalDeductions.TabIndex = 3
        Me.lblTotalDeductions.Text = "Deductions"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvReport)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1425, 457)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 14)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.RowHeadersWidth = 51
        Me.dgvReport.RowTemplate.Height = 24
        Me.dgvReport.Size = New System.Drawing.Size(1413, 437)
        Me.dgvReport.TabIndex = 0
        '
        'chartPayrollSummary
        '
        ChartArea3.Name = "ChartArea1"
        Me.chartPayrollSummary.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chartPayrollSummary.Legends.Add(Legend3)
        Me.chartPayrollSummary.Location = New System.Drawing.Point(21, 126)
        Me.chartPayrollSummary.Name = "chartPayrollSummary"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chartPayrollSummary.Series.Add(Series3)
        Me.chartPayrollSummary.Size = New System.Drawing.Size(512, 260)
        Me.chartPayrollSummary.TabIndex = 5
        Me.chartPayrollSummary.Text = "Chart1"
        '
        'chartEmployeeDistribution
        '
        ChartArea4.Name = "ChartArea1"
        Me.chartEmployeeDistribution.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.chartEmployeeDistribution.Legends.Add(Legend4)
        Me.chartEmployeeDistribution.Location = New System.Drawing.Point(934, 126)
        Me.chartEmployeeDistribution.Name = "chartEmployeeDistribution"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.chartEmployeeDistribution.Series.Add(Series4)
        Me.chartEmployeeDistribution.Size = New System.Drawing.Size(512, 260)
        Me.chartEmployeeDistribution.TabIndex = 6
        Me.chartEmployeeDistribution.Text = "Chart1"
        '
        'frmPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1471, 953)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.chartEmployeeDistribution)
        Me.Controls.Add(Me.chartPayrollSummary)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPayroll"
        Me.Text = "frmPayroll"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartPayrollSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartEmployeeDistribution, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnLoadDashboard As Button
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblTotalPayroll As Label
    Friend WithEvents lblTotalEmployees As Label
    Friend WithEvents lblTotalCommission As Label
    Friend WithEvents lblTotalDeductions As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents chartPayrollSummary As DataVisualization.Charting.Chart
    Friend WithEvents chartEmployeeDistribution As DataVisualization.Charting.Chart
End Class
