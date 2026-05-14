Imports System.Data.OleDb

Public Class frmManageServices

    Private Sub frmManageServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        LoadServices()
    End Sub


    Private Sub txtSearchService_TextChanged(sender As Object, e As EventArgs) Handles txtSearchService.TextChanged
        LoadServices(txtSearchService.Text)
    End Sub

    Private Sub chkArchivedServices_CheckedChanged(sender As Object, e As EventArgs) Handles chkArchivedServices.CheckedChanged
        LoadServices(txtSearchService.Text)
    End Sub


    Private Sub LoadServices(Optional ByVal searchTerm As String = "")
        Try
            SessionManager.OpenConnection()

            Dim statusFilter As Boolean = Not chkArchivedServices.Checked

            Dim query As String = "SELECT ServiceID, ServiceName, Category, Price " &
                                  "FROM tblServices " &
                                  "WHERE IsActive = @status"

            Dim cmd As New OleDbCommand()
            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = statusFilter

            If searchTerm <> "" Then
                query &= " AND (ServiceName LIKE @search OR Category LIKE @search)"
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            query &= " ORDER BY Category, ServiceName"

            cmd.CommandText = query
            cmd.Connection = SessionManager.conn

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvServices.DataSource = dt

            If dgvServices.Columns.Count > 0 Then
                dgvServices.Columns("ServiceID").Visible = False
                dgvServices.Columns("ServiceName").HeaderText = "Service Name"
                dgvServices.Columns("Category").HeaderText = "Category"
                dgvServices.Columns("Price").HeaderText = "Price"
                dgvServices.Columns("Price").DefaultCellStyle.Format = "0'.00'"
            End If

            AddActionButtons()

            If chkArchivedServices.Checked Then
                dgvServices.Columns("colArchive").DefaultCellStyle.ForeColor = Color.MediumSeaGreen
                CType(dgvServices.Columns("colArchive"), DataGridViewButtonColumn).Text = "↺"
            Else
                dgvServices.Columns("colArchive").DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
                CType(dgvServices.Columns("colArchive"), DataGridViewButtonColumn).Text = "🗑"
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub dgvServices_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServices.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = dgvServices.Columns(e.ColumnIndex).Name
            Dim selectedServiceID As Integer = Convert.ToInt32(dgvServices.Rows(e.RowIndex).Cells("ServiceID").Value)
            Dim selectedServiceName As String = dgvServices.Rows(e.RowIndex).Cells("ServiceName").Value.ToString()

            If columnName = "colEdit" Then
                Dim editForm As New frmEditService(selectedServiceID)
                If editForm.ShowDialog() = DialogResult.OK Then LoadServices(txtSearchService.Text)

            ElseIf columnName = "colArchive" Then
                Dim isCurrentlyArchived As Boolean = chkArchivedServices.Checked
                Dim actionText As String = If(isCurrentlyArchived, "restore", "archive")
                Dim newStatus As Boolean = If(isCurrentlyArchived, True, False)

                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} '{selectedServiceName}'?", $"Confirm {actionText.ToUpper()}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Try
                        SessionManager.OpenConnection()
                        Dim archiveQuery As String = "UPDATE tblServices SET IsActive = @status WHERE ServiceID = @id"
                        Using cmd As New OleDbCommand(archiveQuery, SessionManager.conn)
                            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = newStatus
                            cmd.Parameters.AddWithValue("@id", selectedServiceID)
                            cmd.ExecuteNonQuery()
                        End Using

                        LoadServices(txtSearchService.Text)
                    Catch ex As Exception
                        MessageBox.Show("Error updating status: " & ex.Message)
                    Finally
                        SessionManager.CloseConnection()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SetupGridStyle()
        dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvServices.ReadOnly = True
        dgvServices.RowHeadersVisible = False
        dgvServices.AllowUserToAddRows = False
        dgvServices.BackgroundColor = Color.White
        dgvServices.BorderStyle = BorderStyle.None
        dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvServices.GridColor = Color.FromArgb(240, 240, 240)
        dgvServices.EnableHeadersVisualStyles = False

        Dim modernFont As New Font("DM Sans", 10, FontStyle.Regular)
        Dim headerFont As New Font("DM Sans", 10, FontStyle.Bold)
        dgvServices.DefaultCellStyle.Font = modernFont
        dgvServices.ColumnHeadersDefaultCellStyle.Font = headerFont
        dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvServices.RowTemplate.Height = 40
    End Sub

    Private Sub AddActionButtons()
        Dim iconFont As New Font("Segoe UI Symbol", 12, FontStyle.Regular)

        If Not dgvServices.Columns.Contains("colEdit") Then
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "colEdit" : btnEdit.HeaderText = "" : btnEdit.Text = "✎" : btnEdit.UseColumnTextForButtonValue = True
            btnEdit.Width = 40 : btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None : btnEdit.FlatStyle = FlatStyle.Flat
            btnEdit.DefaultCellStyle.Font = iconFont : btnEdit.DefaultCellStyle.ForeColor = Color.FromArgb(200, 150, 0)
            dgvServices.Columns.Add(btnEdit)
        End If

        If Not dgvServices.Columns.Contains("colArchive") Then
            Dim btnArchive As New DataGridViewButtonColumn()
            btnArchive.Name = "colArchive" : btnArchive.HeaderText = "" : btnArchive.Text = "🗑" : btnArchive.UseColumnTextForButtonValue = True
            btnArchive.Width = 40 : btnArchive.AutoSizeMode = DataGridViewAutoSizeColumnMode.None : btnArchive.FlatStyle = FlatStyle.Flat
            btnArchive.DefaultCellStyle.Font = iconFont : btnArchive.DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
            dgvServices.Columns.Add(btnArchive)
        End If
    End Sub

    Private Sub btnAddService_Click(sender As Object, e As EventArgs) Handles btnAddService.Click
        Dim addForm As New frmAddService()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadServices(txtSearchService.Text)
        End If
    End Sub
End Class