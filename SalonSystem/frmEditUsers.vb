Imports System.Data.OleDb

Public Class frmEditUsers

    Private _currentUserID As Integer

    Public Sub New(ByVal userID As Integer)
        InitializeComponent()
        _currentUserID = userID
    End Sub

    Private Sub frmEditUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SessionManager.OpenConnection()
            Dim query As String = "SELECT u.Username, u.Email, (e.FirstName & ' ' & e.LastName) AS FullName " &
                                  "FROM tblUsers u INNER JOIN tblEmployees e ON u.UserID = e.UserID " &
                                  "WHERE u.UserID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@id", _currentUserID)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        lblEmployeeName.Text = reader("FullName").ToString()
                        txtUsername.Text = reader("Username").ToString()
                        txtEmail.Text = reader("Email").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            SessionManager.OpenConnection()

            Dim query As String
            If txtPassword.Text.Trim() <> "" Then
                query = "UPDATE tblUsers SET Username = @user, Email = @email, [Password] = @pass WHERE UserID = @id"
            Else
                query = "UPDATE tblUsers SET Username = @user, Email = @email WHERE UserID = @id"
            End If

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@user", OleDbType.VarChar).Value = txtUsername.Text.Trim()
                cmd.Parameters.Add("@email", OleDbType.VarChar).Value = txtEmail.Text.Trim()

                If txtPassword.Text.Trim() <> "" Then
                    cmd.Parameters.Add("@pass", OleDbType.VarChar).Value = txtPassword.Text.Trim()
                End If

                cmd.Parameters.AddWithValue("@id", _currentUserID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("User details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class