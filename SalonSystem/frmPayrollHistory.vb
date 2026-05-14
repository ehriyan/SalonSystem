Imports System.Data.OleDb
Imports Org.BouncyCastle.Asn1.Cmp

Public Class frmPayrollHistory
    Private Sub frmPayrollHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbStatus.Items.Clear()
        cmbStatus.Items.AddRange({"All", "Draft", "Approved"})
        cmbStatus.SelectedIndex = 0

        dtpStart.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)

        LoadPayrollHistory()
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged, dtpEnd.ValueChanged, cmbStatus.SelectedIndexChanged
        LoadPayrollHistory()
    End Sub

    Private Sub LoadPayrollHistory()
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT p.PayrollID, (e.FirstName & ' ' & e.LastName) AS StaffName, " &
                                  "p.BaseSalary, p.TotalSales, p.CommissionEarned, p.NetPayout, " &
                                  "p.DateGenerated, p.Status, p.ProcessedBy " &
                                  "FROM tblPayroll AS p " &
                                  "INNER JOIN tblEmployees AS e ON p.EmployeeID = e.EmployeeID " &
                                  "WHERE p.DateGenerated BETWEEN @start AND @end "

            If cmbStatus.SelectedIndex > 0 Then
                query &= " AND p.Status = @status"
            End If

            query &= " ORDER BY p.DateGenerated DESC"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@start", OleDbType.Date).Value = dtpStart.Value.Date
                cmd.Parameters.Add("@end", OleDbType.Date).Value = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)

                If cmbStatus.SelectedIndex > 0 Then
                    cmd.Parameters.Add("@status", OleDbType.VarChar).Value = cmbStatus.SelectedItem.ToString()
                End If

                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvHistory.DataSource = dt
                FormatHistoryGrid()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub FormatHistoryGrid()
        If dgvHistory.Columns.Count = 0 Then Exit Sub

        With dgvHistory
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.Gainsboro
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False

            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(41, 53, 65)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 10, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionBackColor = .BackColor
            End With

            With .DefaultCellStyle
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Font = New Font("Segoe UI", 9)
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

        dgvHistory.Columns("PayrollID").Visible = False
        dgvHistory.Columns("StaffName").HeaderText = "Stylist Name"
        dgvHistory.Columns("BaseSalary").HeaderText = "Base Pay"
        dgvHistory.Columns("TotalSales").HeaderText = "Generated Sales"
        dgvHistory.Columns("CommissionEarned").HeaderText = "Commission"
        dgvHistory.Columns("NetPayout").HeaderText = "Total Payout"
        dgvHistory.Columns("DateGenerated").HeaderText = "Draft Date"
        dgvHistory.Columns("ProcessedBy").HeaderText = "Manager"

        Dim moneyCols() As String = {"BaseSalary", "TotalSales", "CommissionEarned", "NetPayout"}
        For Each colName In moneyCols
            With dgvHistory.Columns(colName).DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleRight
                .Format = "₱#,##0.00"
            End With
        Next

        dgvHistory.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvHistory.Columns("DateGenerated").DefaultCellStyle.Format = "MM/dd/yyyy"

        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvHistory.Columns("StaffName").FillWeight = 150
        dgvHistory.Columns("Status").FillWeight = 80
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payroll record to approve.")
            Exit Sub
        End If

        Dim selectedRow = dgvHistory.SelectedRows(0)
        Dim payrollID As Integer = Convert.ToInt32(selectedRow.Cells("PayrollID").Value)
        Dim currentStatus As String = selectedRow.Cells("Status").Value.ToString()

        If currentStatus = "Approved" Then
            MessageBox.Show("This payroll has already been approved and finalized.")
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to approve this payroll for " & selectedRow.Cells("StaffName").Value.ToString() & "?",
                                  "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                SessionManager.OpenConnection()
                Dim updateQuery As String = "UPDATE tblPayroll SET [Status] = 'Approved', [ApprovedBy] = @owner WHERE PayrollID = @pid"

                Using cmd As New OleDbCommand(updateQuery, SessionManager.conn)
                    cmd.Parameters.Add("@owner", OleDbType.VarChar).Value = SessionManager.CurrentUsername
                    cmd.Parameters.Add("@pid", OleDbType.Integer).Value = payrollID
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Payroll Approved Successfully!")
                LoadPayrollHistory()

            Catch ex As Exception
                MessageBox.Show("Error during approval: " & ex.Message)
            Finally
                SessionManager.CloseConnection()
            End Try
        End If
    End Sub

    Private Sub dgvHistory_SelectionChanged(sender As Object, e As EventArgs) Handles dgvHistory.SelectionChanged
        If dgvHistory.SelectedRows.Count > 0 Then
            Dim status As String = dgvHistory.SelectedRows(0).Cells("Status").Value.ToString()
            btnApprove.Enabled = (status = "Draft")
        Else
            btnApprove.Enabled = False
        End If
    End Sub

    Private Sub dgvHistory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvHistory.CellFormatting
        If dgvHistory.Columns(e.ColumnIndex).Name = "Status" AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()

            Select Case status
                Case "Draft"
                    e.CellStyle.ForeColor = Color.DarkOrange
                    e.CellStyle.SelectionForeColor = Color.Orange
                    e.CellStyle.Font = New Font(dgvHistory.Font, FontStyle.Italic)
                Case "Approved"
                    e.CellStyle.ForeColor = Color.MediumSeaGreen
                    e.CellStyle.SelectionForeColor = Color.LightGreen
                    e.CellStyle.Font = New Font(dgvHistory.Font, FontStyle.Bold)
            End Select
        End If
    End Sub
End Class