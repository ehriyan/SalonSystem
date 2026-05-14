Imports System.Data.OleDb
Imports ClosedXML.Excel
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class frmViewReports

    Private Sub frmViewReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbReportType.Items.Clear()
        cmbReportType.Items.Add("Payroll & Commission Expense")
        cmbReportType.Items.Add("Daily Sales Summary")
        cmbReportType.SelectedIndex = 0

        dtpStart.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpEnd.Value = DateTime.Now

        ApplyModernGridDesign()
    End Sub

    Private Sub ApplyModernGridDesign()
        With dgvReport
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.Gainsboro
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False

            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(41, 53, 65)
                .ForeColor = Color.White
                .Font = New System.Drawing.Font("Segoe UI", 10, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionBackColor = .BackColor
            End With

            With .DefaultCellStyle
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Font = New System.Drawing.Font("Segoe UI", 9)
                .SelectionBackColor = Color.FromArgb(220, 236, 250)
                .SelectionForeColor = Color.Black
                .Padding = New Padding(5, 0, 5, 0)
            End With


            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .RowTemplate.Height = 35
        End With
    End Sub

    Private Sub btnLoadReport_Click(sender As Object, e As EventArgs) Handles btnLoadReport.Click
        If cmbReportType.SelectedItem.ToString() = "Payroll & Commission Expense" Then
            LoadPayrollReport()
        ElseIf cmbReportType.SelectedItem.ToString() = "Daily Sales Summary" Then
            LoadSalesReport()
        End If
    End Sub

    Private Sub LoadPayrollReport()
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT (e.FirstName & ' ' & e.LastName) AS StaffName, " &
                                  "COUNT(p.PayrollID) AS PaychecksIssued, " &
                                  "SUM(p.BaseSalary) AS TotalBasePay, " &
                                  "SUM(p.TotalSales) AS TotalGeneratedSales, " &
                                  "SUM(p.CommissionEarned) AS TotalCommission, " &
                                  "SUM(p.NetPayout) AS TotalPayout " &
                                  "FROM tblPayroll AS p " &
                                  "INNER JOIN tblEmployees AS e ON p.EmployeeID = e.EmployeeID " &
                                  "WHERE p.DateGenerated BETWEEN @start AND @end " &
                                  "AND p.Status = 'Approved' " &
                                  "GROUP BY (e.FirstName & ' ' & e.LastName)"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@start", OleDbType.Date).Value = dtpStart.Value.Date
                cmd.Parameters.Add("@end", OleDbType.Date).Value = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)

                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvReport.DataSource = dt
                FormatReportGrid()
                CalculateGrandTotal(dt, "TotalPayout")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub LoadSalesReport()
        Try
            SessionManager.OpenConnection()

            dgvReport.DataSource = Nothing
            dgvReport.Columns.Clear()

            Dim query As String = "SELECT Format([TransactionDate], 'Short Date') AS SalesDate, " &
                                  "COUNT([TransactionID]) AS TotalTransactions, " &
                                  "SUM([GrandTotal]) AS DailyRevenue " &
                                  "FROM tblTransactions " &
                                  "WHERE [TransactionDate] >= @start AND [TransactionDate] <= @end " &
                                  "GROUP BY Format([TransactionDate], 'Short Date') " &
                                  "ORDER BY Format([TransactionDate], 'Short Date') DESC"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@start", OleDbType.Date).Value = dtpStart.Value.Date
                cmd.Parameters.Add("@end", OleDbType.Date).Value = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)

                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvReport.DataSource = dt

                If dgvReport.Columns.Count > 0 Then
                    dgvReport.Columns("SalesDate").HeaderText = "Date"

                    dgvReport.Columns("TotalTransactions").HeaderText = "Number of Customers"

                    dgvReport.Columns("DailyRevenue").HeaderText = "Total Revenue"
                    dgvReport.Columns("DailyRevenue").DefaultCellStyle.Format = "₱#,##0.00"
                    dgvReport.Columns("DailyRevenue").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                End If

                CalculateGrandTotal(dt, "DailyRevenue")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading sales report: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub FormatReportGrid()
        If dgvReport.Columns.Count > 0 Then
            dgvReport.Columns("StaffName").HeaderText = "Stylist"
            dgvReport.Columns("PaychecksIssued").HeaderText = "Paychecks"

            Dim moneyCols() As String = {"TotalBasePay", "TotalGeneratedSales", "TotalCommission", "TotalPayout"}
            For Each col In moneyCols
                dgvReport.Columns(col).DefaultCellStyle.Format = "₱#,##0.00"
                dgvReport.Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next

            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub CalculateGrandTotal(dt As DataTable, columnToSum As String)
        Dim grandTotal As Decimal = 0
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row(columnToSum)) Then
                grandTotal += Convert.ToDecimal(row(columnToSum))
            End If
        Next
        lblReportSummary.Text = "Grand Total " & columnToSum & ": ₱" & grandTotal.ToString("N2")
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("There is no data to export. Please generate a report first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim projectFolder As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "..\..\"))

            Dim reportsFolder As String = System.IO.Path.Combine(projectFolder, "Reports")

            If Not System.IO.Directory.Exists(reportsFolder) Then
                System.IO.Directory.CreateDirectory(reportsFolder)
            End If

            Dim fileName As String = "SalonReport_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"
            Dim fullFilePath As String = System.IO.Path.Combine(reportsFolder, fileName)

            Dim dt As New DataTable()
            For Each col As DataGridViewColumn In dgvReport.Columns
                dt.Columns.Add(col.HeaderText)
            Next

            For Each row As DataGridViewRow In dgvReport.Rows
                If Not row.IsNewRow Then
                    Dim dr As DataRow = dt.NewRow()
                    For i As Integer = 0 To dgvReport.Columns.Count - 1
                        dr(i) = row.Cells(i).Value
                    Next
                    dt.Rows.Add(dr)
                End If
            Next

            Using wb As New XLWorkbook()
                Dim ws = wb.Worksheets.Add("Report Data")
                Dim table = ws.Cell(1, 1).InsertTable(dt)
                table.Theme = XLTableTheme.TableStyleLight9
                ws.Columns().AdjustToContents()

                wb.SaveAs(fullFilePath)
            End Using

            MessageBox.Show("Excel file saved successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", reportsFolder)

        Catch ex As Exception
            MessageBox.Show("Error exporting to Excel: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("There is no data to export. Please generate a report first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim projectFolder As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "..\..\"))

            Dim reportsFolder As String = System.IO.Path.Combine(projectFolder, "Reports")

            If Not System.IO.Directory.Exists(reportsFolder) Then
                System.IO.Directory.CreateDirectory(reportsFolder)
            End If

            Dim reportName As String = cmbReportType.SelectedItem.ToString().Replace(" ", "")
            Dim fileName As String = reportName & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
            Dim fullFilePath As String = System.IO.Path.Combine(reportsFolder, fileName)

            Dim pdfDoc As New Document(PageSize.A4, 25, 25, 30, 30)
            Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(fullFilePath, System.IO.FileMode.Create))
            pdfDoc.Open()

            Dim titleFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK)
            Dim subFont As Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY)

            Dim title As New Paragraph(cmbReportType.SelectedItem.ToString(), titleFont)
            title.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(title)

            Dim dateRange As New Paragraph("Date Range: " & dtpStart.Value.ToString("MMM dd, yyyy") & " to " & dtpEnd.Value.ToString("MMM dd, yyyy"), subFont)
            dateRange.Alignment = Element.ALIGN_CENTER
            dateRange.SpacingAfter = 20
            pdfDoc.Add(dateRange)

            Dim pdfTable As New PdfPTable(dgvReport.Columns.Count)
            pdfTable.WidthPercentage = 100

            Dim headerFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)
            For Each col As DataGridViewColumn In dgvReport.Columns
                Dim cell As New PdfPCell(New Phrase(col.HeaderText, headerFont))
                cell.BackgroundColor = New BaseColor(41, 53, 65)
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.Padding = 5
                pdfTable.AddCell(cell)
            Next

            Dim rowFont As Font = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK)
            For Each row As DataGridViewRow In dgvReport.Rows
                If Not row.IsNewRow Then
                    For Each cell As DataGridViewCell In row.Cells
                        Dim cellText As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")

                        If cell.OwningColumn.DefaultCellStyle.Format.Contains("₱") AndAlso IsNumeric(cell.Value) Then
                            cellText = Convert.ToDecimal(cell.Value).ToString("₱#,##0.00")
                        End If

                        Dim pdfCell As New PdfPCell(New Phrase(cellText, rowFont))
                        pdfCell.Padding = 5

                        If IsNumeric(cell.Value) OrElse cellText.Contains("₱") Then
                            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
                        Else
                            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT
                        End If

                        pdfTable.AddCell(pdfCell)
                    Next
                End If
            Next

            pdfDoc.Add(pdfTable)

            Dim totalParagraph As New Paragraph(lblReportSummary.Text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK))
            totalParagraph.Alignment = Element.ALIGN_RIGHT
            totalParagraph.SpacingBefore = 15
            pdfDoc.Add(totalParagraph)

            pdfDoc.Close()
            MessageBox.Show("PDF saved successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", reportsFolder)

        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class