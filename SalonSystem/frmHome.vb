Imports System.Data.OleDb

Public Class frmHome
    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        'LoadRecentActivity()
    End Sub

    Private Sub LoadRecentActivity()
        Try
            OpenConnection()

            Dim query As String = "SELECT TOP 10 TransactionID, TransactionTime, " &
                                  "ClientName, StylistName, TotalAmount " &
                                  "FROM tblTransactions " &
                                  "WHERE TransactionDate = Date() " &
                                  "ORDER BY TransactionTime DESC"

            Dim cmd As New OleDbCommand(query, conn)
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            'dgvRecentActivity.DataSource = dt

            'dgvRecentActivity.Columns("TransactionTime").HeaderText = "Time"
            'dgvRecentActivity.Columns("ClientName").HeaderText = "Client"
            'dgvRecentActivity.Columns("StylistName").HeaderText = "Stylist"
            'dgvRecentActivity.Columns("TotalAmount").HeaderText = "Total Paid"

            'dgvRecentActivity.Columns("TotalAmount").DefaultCellStyle.Format = "C2"

            'dgvRecentActivity.Columns("TransactionID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Dashboard Data Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub SetupGridStyle()
        'dgvRecentActivity.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        'dgvRecentActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'dgvRecentActivity.AllowUserToAddRows = False
        'dgvRecentActivity.RowHeadersVisible = False
        'dgvRecentActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'dgvRecentActivity.ReadOnly = True

        'dgvRecentActivity.BackgroundColor = Color.White
        'dgvRecentActivity.BorderStyle = BorderStyle.None
        'dgvRecentActivity.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        'dgvRecentActivity.GridColor = Color.FromArgb(230, 230, 230)
        'dgvRecentActivity.EnableHeadersVisualStyles = False

        'Dim modernFont As New Font("DM Sans", 11, FontStyle.Regular)
        'Dim headerFont As New Font("DM Sans", 11, FontStyle.Bold)

        'dgvRecentActivity.DefaultCellStyle.Font = modernFont
        'dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = headerFont

        'dgvRecentActivity.RowTemplate.Height = 40
        'dgvRecentActivity.ColumnHeadersHeight = 50

        'dgvRecentActivity.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        'dgvRecentActivity.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

        'dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        'dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        'dgvRecentActivity.DefaultCellStyle.SelectionBackColor = Color.LightGray
        'dgvRecentActivity.DefaultCellStyle.SelectionForeColor = Color.Black

        'dgvRecentActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
    End Sub
End Class