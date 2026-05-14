Imports System.Data.OleDb

Public Class frmManagePayroll

    Private Sub frmManagePayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        dtpStart.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpEnd.Value = DateTime.Now
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        LoadPayrollCalculation()
    End Sub

    Private Sub LoadPayrollCalculation()
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT e.EmployeeID, (e.FirstName & ' ' & e.LastName) AS FullName, " &
                                  "e.BaseSalary, e.CommissionRate, " &
                                  "SUM(td.Price) AS TotalSales " &
                                  "FROM (tblEmployees e " &
                                  "INNER JOIN tblTransactionDetails td ON e.EmployeeID = td.EmployeeID) " &
                                  "INNER JOIN tblTransactions t ON td.TransactionID = t.TransactionID " &
                                  "WHERE t.TransactionDate BETWEEN @start AND @end " &
                                  "GROUP BY e.EmployeeID, e.FirstName, e.LastName, e.BaseSalary, e.CommissionRate"

            Dim cmd As New OleDbCommand(query, SessionManager.conn)
            cmd.Parameters.Add("@start", OleDbType.Date).Value = dtpStart.Value.Date
            cmd.Parameters.Add("@end", OleDbType.Date).Value = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dt.Columns.Add("CommissionEarned", GetType(Decimal))
            dt.Columns.Add("NetPayout", GetType(Decimal))

            For Each row As DataRow In dt.Rows

                Dim sales As Decimal = If(IsDBNull(row("TotalSales")), 0, row("TotalSales"))
                Dim rate As Double = If(IsDBNull(row("CommissionRate")), 0, row("CommissionRate"))
                Dim base As Decimal = If(IsDBNull(row("BaseSalary")), 0, row("BaseSalary"))

                Dim commission As Decimal = sales * (rate / 100)
                row("CommissionEarned") = commission
                row("NetPayout") = base + commission
            Next

            dgvPayroll.DataSource = dt
            FormatPayrollGrid()

        Catch ex As Exception
            MessageBox.Show("Calculation Error: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If dgvPayroll.Rows.Count = 0 Then Return

        Dim result As DialogResult = MessageBox.Show("Save these payroll records as Draft?", "Confirm Generation", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Try
                SessionManager.OpenConnection()

                For Each row As DataGridViewRow In dgvPayroll.Rows
                    If Not row.IsNewRow Then
                        Dim query As String = "INSERT INTO tblPayroll (EmployeeID, BaseSalary, TotalSales, CommissionEarned, NetPayout, DateGenerated, [Status], ProcessedBy) " &
                              "VALUES (@eid, @base, @sales, @comm, @net, @date, @status, @user)"

                        Using cmd As New OleDbCommand(query, SessionManager.conn)
                            cmd.Parameters.Add("@eid", OleDbType.Integer).Value = Convert.ToInt32(row.Cells("EmployeeID").Value)

                            cmd.Parameters.Add("@base", OleDbType.Currency).Value = Convert.ToDecimal(row.Cells("BaseSalary").Value)
                            cmd.Parameters.Add("@sales", OleDbType.Currency).Value = Convert.ToDecimal(row.Cells("TotalSales").Value)
                            cmd.Parameters.Add("@comm", OleDbType.Currency).Value = Convert.ToDecimal(row.Cells("CommissionEarned").Value)
                            cmd.Parameters.Add("@net", OleDbType.Currency).Value = Convert.ToDecimal(row.Cells("NetPayout").Value)

                            cmd.Parameters.Add("@date", OleDbType.Date).Value = DateTime.Now
                            cmd.Parameters.Add("@status", OleDbType.VarChar).Value = "Draft"
                            cmd.Parameters.Add("@user", OleDbType.VarChar).Value = SessionManager.CurrentUsername

                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next

                MessageBox.Show("Payroll records generated successfully!")
            Catch ex As Exception
                MessageBox.Show("Error saving payroll: " & ex.Message)
            Finally
                SessionManager.CloseConnection()
            End Try
        End If
    End Sub

    Private Sub FormatPayrollGrid()
        dgvPayroll.Columns("EmployeeID").Visible = False
        dgvPayroll.Columns("FullName").HeaderText = "Staff Name"
        dgvPayroll.Columns("BaseSalary").HeaderText = "Base Pay"
        dgvPayroll.Columns("TotalSales").HeaderText = "Total Sales"
        dgvPayroll.Columns("CommissionEarned").HeaderText = "Comm. Earned"
        dgvPayroll.Columns("NetPayout").HeaderText = "Net Payout"

        dgvPayroll.Columns("BaseSalary").DefaultCellStyle.Format = "C2"
        dgvPayroll.Columns("TotalSales").DefaultCellStyle.Format = "C2"
        dgvPayroll.Columns("CommissionEarned").DefaultCellStyle.Format = "C2"
        dgvPayroll.Columns("NetPayout").DefaultCellStyle.Format = "C2"
    End Sub

    Private Sub SetupGridStyle()
        dgvPayroll.AllowUserToAddRows = False
        dgvPayroll.RowHeadersVisible = False
        dgvPayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPayroll.ReadOnly = True

        dgvPayroll.BackgroundColor = Color.White
        dgvPayroll.BorderStyle = BorderStyle.None
        dgvPayroll.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvPayroll.GridColor = Color.FromArgb(235, 235, 235)
        dgvPayroll.EnableHeadersVisualStyles = False

        Dim headerStyle As New DataGridViewCellStyle()
        headerStyle.BackColor = Color.FromArgb(45, 52, 54)
        headerStyle.ForeColor = Color.White
        headerStyle.Font = New Font("DM Sans", 10, FontStyle.Bold)
        headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPayroll.ColumnHeadersDefaultCellStyle = headerStyle
        dgvPayroll.ColumnHeadersHeight = 45

        Dim rowStyle As New DataGridViewCellStyle()
        rowStyle.Font = New Font("DM Sans", 10, FontStyle.Regular)
        rowStyle.SelectionBackColor = Color.FromArgb(240, 247, 255)
        rowStyle.SelectionForeColor = Color.Black
        dgvPayroll.DefaultCellStyle = rowStyle
        dgvPayroll.RowTemplate.Height = 40

        dgvPayroll.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)
    End Sub
End Class