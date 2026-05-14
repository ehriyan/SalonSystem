Imports System.Data.OleDb

Public Class frmManageEmployees

    Private Sub frmManageEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGridStyle()
        LoadEmployees()
    End Sub

    Private Sub txtSearchEmployee_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEmployee.TextChanged
        LoadEmployees(txtSearchEmployee.Text)
    End Sub

    Private Sub chkArchivedEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles chkArchivedEmployees.CheckedChanged
        LoadEmployees(txtSearchEmployee.Text)
    End Sub

    Private Sub LoadEmployees(Optional ByVal searchTerm As String = "")
        Try
            SessionManager.OpenConnection()

            Dim statusFilter As Boolean = Not chkArchivedEmployees.Checked

            Dim query As String = "SELECT EmployeeID, (FirstName & ' ' & LastName) AS FullName, ContactNumber, Role, BaseSalary, CommissionRate " &
                                  "FROM tblEmployees " &
                                  "WHERE isActive = @status"

            Dim cmd As New OleDbCommand()
            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = statusFilter

            If searchTerm <> "" Then
                query &= " AND (FirstName LIKE @search OR LastName LIKE @search OR Role LIKE @search)"
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            query &= " ORDER BY Role, FirstName"

            cmd.CommandText = query
            cmd.Connection = SessionManager.conn

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvEmployees.DataSource = dt

            If dgvEmployees.Columns.Count > 0 Then
                dgvEmployees.Columns("EmployeeID").Visible = False
                dgvEmployees.Columns("FullName").HeaderText = "Employee Name"
                dgvEmployees.Columns("ContactNumber").HeaderText = "Contact"
                dgvEmployees.Columns("Role").HeaderText = "Role"

                dgvEmployees.Columns("BaseSalary").HeaderText = "Base Salary"
                dgvEmployees.Columns("BaseSalary").DefaultCellStyle.Format = "C2"

                dgvEmployees.Columns("CommissionRate").HeaderText = "Commission"
                dgvEmployees.Columns("CommissionRate").DefaultCellStyle.Format = "0'%'"
            End If

            AddActionButtons()

            If chkArchivedEmployees.Checked Then
                dgvEmployees.Columns("colArchive").DefaultCellStyle.ForeColor = Color.MediumSeaGreen
                CType(dgvEmployees.Columns("colArchive"), DataGridViewButtonColumn).Text = "↺"
            Else
                dgvEmployees.Columns("colArchive").DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
                CType(dgvEmployees.Columns("colArchive"), DataGridViewButtonColumn).Text = "🗑"
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub dgvEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = dgvEmployees.Columns(e.ColumnIndex).Name
            Dim selectedEmpID As Integer = Convert.ToInt32(dgvEmployees.Rows(e.RowIndex).Cells("EmployeeID").Value)
            Dim selectedEmpName As String = dgvEmployees.Rows(e.RowIndex).Cells("FullName").Value.ToString()

            If columnName = "colView" Then
                MessageBox.Show("Opening profile for: " & selectedEmpName, "View Employee")

            ElseIf columnName = "colEdit" Then
                Dim editForm As New frmEditEmployee(selectedEmpID)

                If editForm.ShowDialog() = DialogResult.OK Then
                    LoadEmployees(txtSearchEmployee.Text)
                End If

            ElseIf columnName = "colArchive" Then
                Dim isCurrentlyArchived As Boolean = chkArchivedEmployees.Checked
                Dim actionText As String = If(isCurrentlyArchived, "restore", "archive")
                Dim newStatus As Boolean = If(isCurrentlyArchived, True, False)

                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} the profile for {selectedEmpName}?", $"Confirm {actionText.ToUpper()}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Try
                        SessionManager.OpenConnection()
                        Dim archiveQuery As String = "UPDATE tblEmployees SET isActive = @status WHERE EmployeeID = @id"
                        Using cmd As New OleDbCommand(archiveQuery, SessionManager.conn)
                            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = newStatus
                            cmd.Parameters.AddWithValue("@id", selectedEmpID)
                            cmd.ExecuteNonQuery()
                        End Using

                        LoadEmployees(txtSearchEmployee.Text)
                    Catch ex As Exception
                        MessageBox.Show("Error updating status: " & ex.Message)
                    Finally
                        SessionManager.CloseConnection()
                    End Try
                End If
            End If
        End If
    End Sub


    Private Sub btnAddEmployee_Click(sender As Object, e As EventArgs) Handles btnAddEmployee.Click
        Dim addForm As New frmAddEmployee()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadEmployees(txtSearchEmployee.Text)
        End If
    End Sub

    Private Sub SetupGridStyle()
        dgvEmployees.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvEmployees.AllowUserToAddRows = False
        dgvEmployees.RowHeadersVisible = False
        dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEmployees.ReadOnly = True

        dgvEmployees.BackgroundColor = Color.White
        dgvEmployees.BorderStyle = BorderStyle.None
        dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvEmployees.GridColor = Color.FromArgb(240, 240, 240)
        dgvEmployees.EnableHeadersVisualStyles = False

        Dim modernFont As New Font("DM Sans", 10, FontStyle.Regular)
        Dim headerFont As New Font("DM Sans", 10, FontStyle.Bold)

        dgvEmployees.DefaultCellStyle.Font = modernFont
        dgvEmployees.ColumnHeadersDefaultCellStyle.Font = headerFont

        dgvEmployees.RowTemplate.Height = 40
        dgvEmployees.ColumnHeadersHeight = 40

        dgvEmployees.DefaultCellStyle.Padding = New Padding(5, 0, 0, 0)
        dgvEmployees.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 0, 0, 0)

        dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub AddActionButtons()
        Dim iconFont As New Font("Segoe UI Symbol", 12, FontStyle.Regular)

        'If Not dgvEmployees.Columns.Contains("colView") Then
        '    Dim btnView As New DataGridViewButtonColumn()
        '    btnView.Name = "colView"
        '    btnView.HeaderText = ""
        '    btnView.Text = "👁"
        '    btnView.UseColumnTextForButtonValue = True
        '    btnView.Width = 40
        '    btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    btnView.FlatStyle = FlatStyle.Flat
        '    btnView.DefaultCellStyle.Font = iconFont
        '    btnView.DefaultCellStyle.ForeColor = Color.FromArgb(0, 120, 215)
        '    dgvEmployees.Columns.Add(btnView)
        'End If

        If Not dgvEmployees.Columns.Contains("colEdit") Then
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "colEdit"
            btnEdit.HeaderText = ""
            btnEdit.Text = "✎"
            btnEdit.UseColumnTextForButtonValue = True
            btnEdit.Width = 40
            btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            btnEdit.FlatStyle = FlatStyle.Flat
            btnEdit.DefaultCellStyle.Font = iconFont
            btnEdit.DefaultCellStyle.ForeColor = Color.FromArgb(200, 150, 0)
            dgvEmployees.Columns.Add(btnEdit)
        End If

        If Not dgvEmployees.Columns.Contains("colArchive") Then
            Dim btnArchive As New DataGridViewButtonColumn()
            btnArchive.Name = "colArchive"
            btnArchive.HeaderText = ""
            btnArchive.Text = "🗑"
            btnArchive.UseColumnTextForButtonValue = True
            btnArchive.Width = 40
            btnArchive.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            btnArchive.FlatStyle = FlatStyle.Flat
            btnArchive.DefaultCellStyle.Font = iconFont
            btnArchive.DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
            dgvEmployees.Columns.Add(btnArchive)
        End If
    End Sub

End Class