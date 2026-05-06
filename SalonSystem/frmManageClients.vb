Imports System.Data.OleDb

Public Class frmManageClients

    Private Sub frmManageClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        LoadClientsGrid()
    End Sub

    Private Sub LoadClientsGrid(Optional ByVal searchTerm As String = "")
        Try
            OpenConnection()

            Dim query As String = "SELECT ClientID, LastName, FirstName, " &
                                  "ContactNumber, Email, CustomerType, ReturningCustomer " &
                                  "FROM tblClients"

            Dim cmd As New OleDbCommand()

            If searchTerm <> "" Then
                query &= " WHERE FirstName LIKE @search OR LastName LIKE @search OR ContactNumber LIKE @search"
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            cmd.CommandText = query
            cmd.Connection = conn

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvClients.DataSource = dt

            dgvClients.Columns("ClientID").HeaderText = "ID"
            dgvClients.Columns("LastName").HeaderText = "Last Name"
            dgvClients.Columns("FirstName").HeaderText = "First Name"
            dgvClients.Columns("ContactNumber").HeaderText = "Contact"
            dgvClients.Columns("CustomerType").HeaderText = "Type"
            dgvClients.Columns("ReturningCustomer").HeaderText = "Returning"
            'dgvClients.Columns("ClientID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadClientsGrid(txtSearch.Text)
    End Sub

    Private Sub btnAddClient_Click(sender As Object, e As EventArgs) Handles btnAddClient.Click
        Dim addClientForm As New frmAddClient()
        addClientForm.ShowDialog()
        LoadClientsGrid()
    End Sub

    Private Sub dgvClients_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellDoubleClick
        If e.RowIndex < 0 Then Return

        Dim selectedClientID As Integer = Convert.ToInt32(dgvClients.Rows(e.RowIndex).Cells("ClientID").Value)
        Dim profileForm As New frmAddClient(selectedClientID)
        profileForm.ShowDialog()

        LoadClientsGrid()
    End Sub

    Private Sub SetupGridStyle()
        dgvClients.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvClients.AllowUserToAddRows = False
        dgvClients.RowHeadersVisible = False
        dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClients.ReadOnly = True

        dgvClients.BackgroundColor = Color.White
        dgvClients.BorderStyle = BorderStyle.None
        dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvClients.GridColor = Color.FromArgb(230, 230, 230)
        dgvClients.EnableHeadersVisualStyles = False

        Dim modernFont As New Font("DM Sans", 11, FontStyle.Regular)
        Dim headerFont As New Font("DM Sans", 11, FontStyle.Bold)

        dgvClients.DefaultCellStyle.Font = modernFont
        dgvClients.ColumnHeadersDefaultCellStyle.Font = headerFont

        dgvClients.RowTemplate.Height = 40
        dgvClients.ColumnHeadersHeight = 50

        dgvClients.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvClients.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

        dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        dgvClients.DefaultCellStyle.SelectionBackColor = Color.LightGray
        dgvClients.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvClients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
    End Sub

    Private Sub dgvClients_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellContentClick

    End Sub
End Class