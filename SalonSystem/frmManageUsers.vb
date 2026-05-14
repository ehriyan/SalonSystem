Imports Microsoft.Web.WebView2.Core
Imports System.Data.OleDb
Imports System.IO

Public Class frmManageUsers

    Private Async Sub frmManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await wvUsers.EnsureCoreWebView2Async(Nothing)
    End Sub

    Private Sub wvUsers_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles wvUsers.CoreWebView2InitializationCompleted
        If e.IsSuccess Then
            AddHandler wvUsers.CoreWebView2.WebMessageReceived, AddressOf HandleWebMessage

            Dim htmlFilePath As String = Path.Combine(Application.StartupPath, "UI", "ManageUsersLayout.html")
            If File.Exists(htmlFilePath) Then
                wvUsers.CoreWebView2.Navigate(htmlFilePath)
            End If
        End If
    End Sub

    Private Sub wvUsers_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles wvUsers.NavigationCompleted
        If e.IsSuccess Then
            LoadUsersIntoHTML()
        End If
    End Sub


    Private Sub LoadUsersIntoHTML()
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT UserID, Username, Email, Role, isActive FROM tblUsers"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                Using reader As OleDbDataReader = cmd.ExecuteReader()

                    Dim jsonBuilder As New Text.StringBuilder()
                    jsonBuilder.Append("[")

                    Dim isFirstRow As Boolean = True
                    While reader.Read()
                        If Not isFirstRow Then jsonBuilder.Append(",")

                        Dim email As String = If(IsDBNull(reader("Email")), "", reader("Email").ToString())

                        Dim isActive As Boolean = False
                        If Not IsDBNull(reader("isActive")) Then
                            isActive = Convert.ToBoolean(reader("isActive"))
                        End If
                        Dim jsonBoolean As String = isActive.ToString().ToLower()

                        jsonBuilder.Append("{")
                        jsonBuilder.Append("""id"":" & reader("UserID").ToString() & ",")
                        jsonBuilder.Append("""username"":""" & reader("Username").ToString() & """,")
                        jsonBuilder.Append("""email"":""" & email & """,")
                        jsonBuilder.Append("""role"":""" & reader("Role").ToString() & """,")
                        jsonBuilder.Append("""isActive"":" & jsonBoolean)
                        jsonBuilder.Append("}")

                        isFirstRow = False
                    End While
                    jsonBuilder.Append("]")

                    wvUsers.CoreWebView2.PostWebMessageAsJson(jsonBuilder.ToString())

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub HandleWebMessage(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
        Dim message As String = e.TryGetWebMessageAsString()

        If message = "OPEN_ADD_USER" Then
            Me.BeginInvoke(Sub()
                               Using addForm As New frmAddUser()
                                   If addForm.ShowDialog() = DialogResult.OK Then
                                       LoadUsersIntoHTML()
                                   End If
                               End Using
                           End Sub)

        ElseIf message.StartsWith("DEACTIVATE:") Then
            Dim targetID As String = message.Replace("DEACTIVATE:", "")
            ToggleUserStatus(targetID, False)

        ElseIf message.StartsWith("REACTIVATE:") Then
            Dim targetID As String = message.Replace("REACTIVATE:", "")
            ToggleUserStatus(targetID, True)
        End If
    End Sub

    Private Sub ToggleUserStatus(id As String, makeActive As Boolean)
        Try
            SessionManager.OpenConnection()

            Dim query As String = "UPDATE tblUsers SET isActive = @status WHERE UserID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@status", makeActive)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using

            LoadUsersIntoHTML()

            Dim statusText As String = If(makeActive, "reactivated", "archived")
            MessageBox.Show($"User has been {statusText} successfully.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error updating user status: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

End Class

'Public Class frmManageUsers
'    Private Sub frmManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        If SessionManager.CurrentUserRole = "Assistant Manager" Then
'            btnAddUser.Visible = False
'        Else
'            btnAddUser.Visible = True
'        End If

'        SetupGridStyle()
'        LoadUsersGrid()
'    End Sub

'    Private Sub LoadUsersGrid(Optional ByVal searchTerm As String = "")
'        Try
'            SessionManager.OpenConnection()

'            Dim statusFilter As Boolean = Not chkArchivedUsers.Checked

'            Dim query As String = "SELECT u.UserID, (e.FirstName & ' ' & e.LastName) AS FullName, u.Username, u.Role, u.Email " &
'                                  "FROM tblUsers u INNER JOIN tblEmployees e ON u.UserID = e.UserID " &
'                                  "WHERE u.isActive = @status"

'            Dim cmd As New OleDbCommand()
'            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = statusFilter

'            If searchTerm <> "" Then
'                query &= " AND (e.FirstName LIKE @search OR e.LastName LIKE @search OR u.Username LIKE @search OR u.Role LIKE @search)"
'                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
'            End If

'            query &= " ORDER BY u.Role, e.FirstName"

'            cmd.CommandText = query
'            cmd.Connection = SessionManager.conn

'            Dim adapter As New OleDbDataAdapter(cmd)
'            Dim dt As New DataTable()
'            adapter.Fill(dt)

'            dgvUsers.DataSource = dt

'            dgvUsers.Columns("UserID").Visible = False
'            dgvUsers.Columns("FullName").HeaderText = "Employee Name"
'            dgvUsers.Columns("Username").HeaderText = "Username"
'            dgvUsers.Columns("Role").HeaderText = "Role"
'            dgvUsers.Columns("Email").HeaderText = "Email"

'            AddActionButtons()

'            If chkArchivedUsers.Checked Then
'                dgvUsers.Columns("colArchive").DefaultCellStyle.ForeColor = Color.MediumSeaGreen
'                CType(dgvUsers.Columns("colArchive"), DataGridViewButtonColumn).Text = "↺"
'            Else
'                dgvUsers.Columns("colArchive").DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
'                CType(dgvUsers.Columns("colArchive"), DataGridViewButtonColumn).Text = "🗑"
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            SessionManager.CloseConnection()
'        End Try
'    End Sub

'    Private Sub AddActionButtons()
'        Dim iconFont As New Font("Segoe UI Symbol", 12, FontStyle.Regular)

'        If Not dgvUsers.Columns.Contains("colEdit") Then
'            Dim btnEdit As New DataGridViewButtonColumn()
'            btnEdit.Name = "colEdit"
'            btnEdit.HeaderText = ""
'            btnEdit.Text = "✎"
'            btnEdit.UseColumnTextForButtonValue = True
'            btnEdit.Width = 40
'            btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
'            btnEdit.FlatStyle = FlatStyle.Flat
'            btnEdit.DefaultCellStyle.Font = iconFont
'            btnEdit.DefaultCellStyle.ForeColor = Color.FromArgb(200, 150, 0)
'            dgvUsers.Columns.Add(btnEdit)
'        End If

'        If Not dgvUsers.Columns.Contains("colArchive") Then
'            Dim btnArchive As New DataGridViewButtonColumn()
'            btnArchive.Name = "colArchive"
'            btnArchive.HeaderText = ""
'            btnArchive.Text = "🗑"
'            btnArchive.UseColumnTextForButtonValue = True
'            btnArchive.Width = 40
'            btnArchive.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
'            btnArchive.FlatStyle = FlatStyle.Flat
'            btnArchive.DefaultCellStyle.Font = iconFont
'            btnArchive.DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69)
'            dgvUsers.Columns.Add(btnArchive)
'        End If
'    End Sub

'    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
'        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
'            Dim columnName As String = dgvUsers.Columns(e.ColumnIndex).Name
'            Dim selectedUserID As Integer = Convert.ToInt32(dgvUsers.Rows(e.RowIndex).Cells("UserID").Value)
'            Dim selectedUserName As String = dgvUsers.Rows(e.RowIndex).Cells("FullName").Value.ToString()

'            If columnName = "colEdit" Then
'                Dim editForm As New frmEditUsers(selectedUserID)
'                If editForm.ShowDialog() = DialogResult.OK Then
'                    LoadUsersGrid(txtSearch.Text)
'                End If

'            ElseIf columnName = "colArchive" Then
'                Dim isCurrentlyArchived As Boolean = chkArchivedUsers.Checked
'                Dim actionText As String = If(isCurrentlyArchived, "restore", "archive")
'                Dim newStatus As Boolean = If(isCurrentlyArchived, True, False)

'                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} system access for {selectedUserName}?", $"Confirm {actionText.ToUpper()}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

'                If result = DialogResult.Yes Then
'                    Try
'                        SessionManager.OpenConnection()
'                        Dim archiveQuery As String = "UPDATE tblUsers SET isActive = @status WHERE UserID = @id"
'                        Using cmd As New OleDbCommand(archiveQuery, SessionManager.conn)
'                            cmd.Parameters.Add("@status", OleDbType.Boolean).Value = newStatus
'                            cmd.Parameters.AddWithValue("@id", selectedUserID)
'                            cmd.ExecuteNonQuery()
'                        End Using

'                        LoadUsersGrid(txtSearch.Text)
'                    Catch ex As Exception
'                        MessageBox.Show("Error updating status: " & ex.Message)
'                    Finally
'                        SessionManager.CloseConnection()
'                    End Try
'                End If
'            End If
'        End If
'    End Sub

'    Private Sub SetupGridStyle()
'        dgvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
'        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

'        dgvUsers.AllowUserToAddRows = False
'        dgvUsers.RowHeadersVisible = False
'        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
'        dgvUsers.ReadOnly = True

'        dgvUsers.BackgroundColor = Color.White
'        dgvUsers.BorderStyle = BorderStyle.None
'        dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
'        dgvUsers.GridColor = Color.FromArgb(240, 240, 240)
'        dgvUsers.EnableHeadersVisualStyles = False

'        Dim modernFont As New Font("DM Sans", 10, FontStyle.Regular)
'        Dim headerFont As New Font("DM Sans", 10, FontStyle.Bold)

'        dgvUsers.DefaultCellStyle.Font = modernFont
'        dgvUsers.ColumnHeadersDefaultCellStyle.Font = headerFont

'        dgvUsers.RowTemplate.Height = 40
'        dgvUsers.ColumnHeadersHeight = 40
'        dgvUsers.DefaultCellStyle.Padding = New Padding(5, 0, 0, 0)
'        dgvUsers.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 0, 0, 0)

'        dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
'        dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

'        dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
'        dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black

'        dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.White
'    End Sub

'    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
'        Dim addUserForm As New frmAddUser()
'        If addUserForm.ShowDialog() = DialogResult.OK Then
'            LoadUsersGrid()
'        End If
'    End Sub

'    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
'        LoadUsersGrid(txtSearch.Text)
'    End Sub

'    Private Sub chkArchivedUsers_CheckedChanged(sender As Object, e As EventArgs) Handles chkArchivedUsers.CheckedChanged
'        LoadUsersGrid(txtSearch.Text)
'    End Sub
'End Class