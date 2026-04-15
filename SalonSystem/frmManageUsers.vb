Imports System.Data.OleDb

Public Class frmManageUsers
    Private Sub frmManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SessionManager.CurrentUserRole = "Assistant Manager" Then
            btnAddUser.Visible = False
        Else
            btnAddUser.Visible = True
        End If

        SetupGridStyle()
        LoadUsersGrid()
    End Sub

    Private Sub LoadUsersGrid(Optional ByVal searchTerm As String = "")
        Try
            OpenConnection()

            Dim query As String = "SELECT u.UserID, e.LastName, e.FirstName, u.Username, u.Role, u.Email, e.ContactNumber " &
                                  "FROM tblUsers u INNER JOIN tblEmployees e ON u.UserID = e.UserID"

            Dim cmd As New OleDbCommand()

            If searchTerm <> "" Then
                query &= " WHERE e.FirstName LIKE @search OR e.LastName LIKE @search OR u.Username LIKE @search OR u.Role LIKE @search"
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            cmd.CommandText = query
            cmd.Connection = conn

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvUsers.DataSource = dt

            dgvUsers.Columns("UserID").HeaderText = "ID"
            dgvUsers.Columns("LastName").HeaderText = "Last Name"
            dgvUsers.Columns("FirstName").HeaderText = "First Name"
            dgvUsers.Columns("Username").HeaderText = "Username"
            dgvUsers.Columns("Role").HeaderText = "Role"
            dgvUsers.Columns("Email").HeaderText = "Email"
            dgvUsers.Columns("ContactNumber").HeaderText = "Contact"
            'dgvUsers.Columns("UserID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub SetupGridStyle()
        dgvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.RowHeadersVisible = False
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.ReadOnly = True

        dgvUsers.BackgroundColor = Color.White
        dgvUsers.BorderStyle = BorderStyle.None
        dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsers.GridColor = Color.FromArgb(230, 230, 230)
        dgvUsers.EnableHeadersVisualStyles = False

        Dim modernFont As New Font("DM Sans", 11, FontStyle.Regular)
        Dim headerFont As New Font("DM Sans", 11, FontStyle.Bold)

        dgvUsers.DefaultCellStyle.Font = modernFont
        dgvUsers.ColumnHeadersDefaultCellStyle.Font = headerFont

        dgvUsers.RowTemplate.Height = 40
        dgvUsers.ColumnHeadersHeight = 50

        dgvUsers.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvUsers.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 5, 5, 5)

        dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40)
        dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        dgvUsers.DefaultCellStyle.SelectionBackColor = Color.LightGray
        dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addUserForm As New frmAddUser()

        addUserForm.cmbRole.Items.Clear()

        If SessionManager.CurrentUserRole = "Owner" Then
            addUserForm.cmbRole.Items.Add("Manager")
            addUserForm.cmbRole.Items.Add("Assistant Manager")
        ElseIf SessionManager.CurrentUserRole = "Manager" Then
            addUserForm.cmbRole.Items.Add("Assistant Manager")
        End If

        If addUserForm.cmbRole.Items.Count > 0 Then
            addUserForm.cmbRole.SelectedIndex = 0
        End If

        addUserForm.ShowDialog()

        LoadUsersGrid()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadUsersGrid(txtSearch.Text)
    End Sub
End Class