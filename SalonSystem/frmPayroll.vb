Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Imports ClosedXML.Excel
Public Class frmPayroll
    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboard()
    End Sub

    Sub LoadDashboard()

        Try
            conn.Open()

            Dim startDate As Date = dtpStart.Value
            Dim endDate As Date = dtpEnd.Value

      
            Dim totalPayrollCmd As New OleDbCommand(
                "SELECT SUM(NetPayout) FROM tblPayroll 
             WHERE PeriodStartDate >= ? AND PeriodEndDate <= ?", conn)

            totalPayrollCmd.Parameters.AddWithValue("@start", startDate)
            totalPayrollCmd.Parameters.AddWithValue("@end", endDate)

            Dim totalPayroll = totalPayrollCmd.ExecuteScalar()
            lblTotalPayroll.Text = "₱ " & If(IsDBNull(totalPayroll), 0, totalPayroll)

            Dim comCmd As New OleDbCommand(
                "SELECT SUM(CalculatedCommission) FROM tblPayroll 
             WHERE PeriodStartDate >= ? AND PeriodEndDate <= ?", conn)

            comCmd.Parameters.AddWithValue("@start", startDate)
            comCmd.Parameters.AddWithValue("@end", endDate)

            Dim totalCom = comCmd.ExecuteScalar()
            lblTotalCommission.Text = "₱ " & If(IsDBNull(totalCom), 0, totalCom)

            Dim dedCmd As New OleDbCommand(
                "SELECT SUM(TotalDeductions) FROM tblPayroll 
             WHERE PeriodStartDate >= ? AND PeriodEndDate <= ?", conn)

            dedCmd.Parameters.AddWithValue("@start", startDate)
            dedCmd.Parameters.AddWithValue("@end", endDate)

            Dim totalDed = dedCmd.ExecuteScalar()
            lblTotalDeductions.Text = "₱ " & If(IsDBNull(totalDed), 0, totalDed)

            Dim empCmd As New OleDbCommand("SELECT COUNT(*) FROM tblEmployees", conn)
            lblTotalEmployees.Text = empCmd.ExecuteScalar().ToString()

            conn.Close()

            LoadPayrollChart(startDate, endDate)
            LoadEmployeeChart(startDate, endDate)
            LoadReport(startDate, endDate)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Sub LoadPayrollChart(startDate As Date, endDate As Date)

        chartPayrollSummary.Series.Clear()
        chartPayrollSummary.Series.Add("Payroll")
        chartPayrollSummary.Series("Payroll").ChartType = SeriesChartType.Column

        Try
            conn.Open()

            Dim cmd As New OleDbCommand(
                "SELECT Format(DateGenerated,'yyyy-mm-dd') AS PayDate, SUM(NetPayout) AS Total
             FROM tblPayroll
             WHERE PeriodStartDate >= ? AND PeriodEndDate <= ?
             GROUP BY Format(DateGenerated,'yyyy-mm-dd')", conn)

            cmd.Parameters.AddWithValue("@start", startDate)
            cmd.Parameters.AddWithValue("@end", endDate)

            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                chartPayrollSummary.Series("Payroll").Points.AddXY(
                    reader("PayDate"),
                    reader("Total"))
            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Sub LoadEmployeeChart(startDate As Date, endDate As Date)

        chartEmployeeDistribution.Series.Clear()
        chartEmployeeDistribution.Series.Add("Employees")
        chartEmployeeDistribution.Series("Employees").ChartType = SeriesChartType.Pie

        Try
            conn.Open()

            Dim cmd As New OleDbCommand(
                "SELECT e.FirstName & ' ' & e.LastName AS Name, SUM(p.NetPayout) AS Total
             FROM tblPayroll p
             INNER JOIN tblEmployees e ON p.EmployeeID = e.EmployeeID
             WHERE p.PeriodStartDate >= ? AND p.PeriodEndDate <= ?
             GROUP BY e.FirstName, e.LastName", conn)

            cmd.Parameters.AddWithValue("@start", startDate)
            cmd.Parameters.AddWithValue("@end", endDate)

            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                chartEmployeeDistribution.Series("Employees").Points.AddXY(
                    reader("Name"),
                    reader("Total"))
            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Sub LoadReport(startDate As Date, endDate As Date)

        Try
            conn.Open()

            Dim cmd As New OleDbCommand(
                "SELECT p.PayrollID, 
                    e.FirstName & 
                    p.GrossPay, p.TotalDeductions, p.NetPayout, p.Status
             FROM tblPayroll p
             INNER JOIN tblEmployees e ON p.EmployeeID = e.EmployeeID
             WHERE p.PeriodStartDate >= ? AND p.PeriodEndDate <= ?", conn)

            cmd.Parameters.AddWithValue("@start", startDate)
            cmd.Parameters.AddWithValue("@end", endDate)

            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader())

            dgvReport.DataSource = dt

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub btnLoadDashboard_Click(sender As Object, e As EventArgs) Handles btnLoadDashboard.Click
        LoadDashboard()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportToExcel()
    End Sub

    Sub ExportToExcel()

        If dgvReport.Rows.Count = 0 Then
            MsgBox("No data to export!")
            Exit Sub
        End If

        Try
            Dim wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("Payroll Report")

            For col As Integer = 0 To dgvReport.Columns.Count - 1
                ws.Cell(1, col + 1).Value = dgvReport.Columns(col).HeaderText
                ws.Cell(1, col + 1).Style.Font.Bold = True
            Next

            For row As Integer = 0 To dgvReport.Rows.Count - 1
                For col As Integer = 0 To dgvReport.Columns.Count - 1
                    ws.Cell(row + 2, col + 1).Value = dgvReport.Rows(row).Cells(col).Value
                Next
            Next

            ws.Columns().AdjustToContents()

            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) &
                                 "\Payroll_Report_" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

            wb.SaveAs(path)

            MsgBox("Exported successfully to Desktop!")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
