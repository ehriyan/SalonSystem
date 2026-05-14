Imports System.Data.OleDb

Public Class frmManageClients

    Private Sub frmManageClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        LoadClients()
    End Sub


    Private Sub txtSearchClient_TextChanged(sender As Object, e As EventArgs) Handles txtSearchClient.TextChanged
        LoadClients(txtSearchClient.Text)
    End Sub

    Private Sub chkArchivedClients_CheckedChanged(sender As Object, e As EventArgs) Handles chkArchivedClients.CheckedChanged
        LoadClients(txtSearchClient.Text)
    End Sub

    Private Sub LoadClients(Optional ByVal searchTerm As String = "")
        Try
            SessionManager.OpenConnection()
            Dim statusFilter As Boolean = Not chkArchivedClients.Checked

            Dim query As String = "SELECT ClientID, (FirstName & ' ' & LastName) AS FullName, ContactNumber, Email, CustomerType, ReturningCustomer " &
                                  "FROM tblClients " &
                                  "WHERE isActive = @status"

            Dim cmd As New OleDbCommand()
            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = statusFilter

            If searchTerm <> "" Then
                query &= " AND (FirstName LIKE @search OR LastName LIKE @search OR ContactNumber LIKE @search OR CustomerType LIKE @search)"
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            query &= " ORDER BY FirstName"
            cmd.CommandText = query
            cmd.Connection = SessionManager.conn

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvClients.DataSource = dt

            If dgvClients.Columns.Count > 0 Then
                dgvClients.Columns("ClientID").Visible = False
                dgvClients.Columns("FullName").HeaderText = "Client Name"
                dgvClients.Columns("ContactNumber").HeaderText = "Contact Number"
                dgvClients.Columns("Email").HeaderText = "Email Address"
                dgvClients.Columns("CustomerType").HeaderText = "Customer Type"

                dgvClients.Columns("ReturningCustomer").HeaderText = "Returning?"
            End If

            AddActionButtons()

            If chkArchivedClients.Checked Then
                dgvClients.Columns("colArchive").DefaultCellStyle.ForeColor = Color.MediumSeaGreen
                CType(dgvClients.Columns("colArchive"), DataGridViewButtonColumn).Text = "↺"
            Else
                dgvClients.Columns("colArchive").DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
                CType(dgvClients.Columns("colArchive"), DataGridViewButtonColumn).Text = "🗑"
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub dgvClients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = dgvClients.Columns(e.ColumnIndex).Name
            Dim selectedClientID As Integer = Convert.ToInt32(dgvClients.Rows(e.RowIndex).Cells("ClientID").Value)
            Dim selectedClientName As String = dgvClients.Rows(e.RowIndex).Cells("FullName").Value.ToString()

            If columnName = "colView" Then
                Dim viewProfile As New frmViewClient(selectedClientID)
                viewProfile.ShowDialog()

            ElseIf columnName = "colEdit" Then
                Dim editForm As New frmEditClient(selectedClientID)
                If editForm.ShowDialog() = DialogResult.OK Then
                    LoadClients(txtSearchClient.Text)
                End If

            ElseIf columnName = "colArchive" Then
                Dim isCurrentlyArchived As Boolean = chkArchivedClients.Checked
                Dim actionText As String = If(isCurrentlyArchived, "restore", "archive")
                Dim newStatus As Boolean = If(isCurrentlyArchived, True, False)

                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} the profile for {selectedClientName}?", $"Confirm {actionText.ToUpper()}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Try
                        SessionManager.OpenConnection()
                        Dim archiveQuery As String = "UPDATE tblClients SET isActive = @status WHERE ClientID = @id"
                        Using cmd As New OleDbCommand(archiveQuery, SessionManager.conn)
                            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = newStatus
                            cmd.Parameters.AddWithValue("@id", selectedClientID)
                            cmd.ExecuteNonQuery()
                        End Using

                        LoadClients(txtSearchClient.Text)
                    Catch ex As Exception
                        MessageBox.Show("Error updating status: " & ex.Message)
                    Finally
                        SessionManager.CloseConnection()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btnAddClient_Click(sender As Object, e As EventArgs) Handles btnAddClient.Click
        Dim addForm As New frmAddClient()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadClients(txtSearchClient.Text)
        End If
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
        dgvClients.GridColor = Color.FromArgb(240, 240, 240)
        dgvClients.EnableHeadersVisualStyles = False

        Dim modernFont As New Font("DM Sans", 10, FontStyle.Regular)
        Dim headerFont As New Font("DM Sans", 10, FontStyle.Bold)

        dgvClients.DefaultCellStyle.Font = modernFont
        dgvClients.ColumnHeadersDefaultCellStyle.Font = headerFont

        dgvClients.RowTemplate.Height = 40
        dgvClients.ColumnHeadersHeight = 40

        dgvClients.DefaultCellStyle.Padding = New Padding(5, 0, 0, 0)
        dgvClients.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 0, 0, 0)

        dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvClients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvClients.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvClients.AlternatingRowsDefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub AddActionButtons()
        Dim iconFont As New Font("Segoe UI Symbol", 12, FontStyle.Regular)

        If Not dgvClients.Columns.Contains("colView") Then
            Dim btnView As New DataGridViewButtonColumn()
            btnView.Name = "colView" : btnView.HeaderText = "" : btnView.Text = "👁" : btnView.UseColumnTextForButtonValue = True
            btnView.Width = 40 : btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.None : btnView.FlatStyle = FlatStyle.Flat
            btnView.DefaultCellStyle.Font = iconFont : btnView.DefaultCellStyle.ForeColor = Color.FromArgb(0, 120, 215)
            dgvClients.Columns.Add(btnView)
        End If

        If Not dgvClients.Columns.Contains("colEdit") Then
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "colEdit" : btnEdit.HeaderText = "" : btnEdit.Text = "✎" : btnEdit.UseColumnTextForButtonValue = True
            btnEdit.Width = 40 : btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None : btnEdit.FlatStyle = FlatStyle.Flat
            btnEdit.DefaultCellStyle.Font = iconFont : btnEdit.DefaultCellStyle.ForeColor = Color.FromArgb(200, 150, 0)
            dgvClients.Columns.Add(btnEdit)
        End If

        If Not dgvClients.Columns.Contains("colArchive") Then
            Dim btnArchive As New DataGridViewButtonColumn()
            btnArchive.Name = "colArchive" : btnArchive.HeaderText = "" : btnArchive.Text = "🗑" : btnArchive.UseColumnTextForButtonValue = True
            btnArchive.Width = 40 : btnArchive.AutoSizeMode = DataGridViewAutoSizeColumnMode.None : btnArchive.FlatStyle = FlatStyle.Flat
            btnArchive.DefaultCellStyle.Font = iconFont : btnArchive.DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
            dgvClients.Columns.Add(btnArchive)
        End If
    End Sub
End Class