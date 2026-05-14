Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Web.WebView2.Core

Public Class frmAddUser

    Private Sub frmAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Size = New Size(500, 600)
    End Sub

    Private Async Sub frmAddUser_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Dim userDataFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SalonSystem_AddUser")
            Dim env = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder)

            Await wvAddForm.EnsureCoreWebView2Async(env)

        Catch ex As Exception

            MessageBox.Show("Failed to load browser engine: " & ex.Message, "WebView2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub wvAddForm_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles wvAddForm.CoreWebView2InitializationCompleted
        If e.IsSuccess Then
            AddHandler wvAddForm.CoreWebView2.WebMessageReceived, AddressOf HandleWebMessage

            Dim htmlFilePath As String = Path.Combine(Application.StartupPath, "UI", "AddUserLayout.html")

            If File.Exists(htmlFilePath) Then
                wvAddForm.CoreWebView2.Navigate(htmlFilePath)
            Else
                MessageBox.Show("Could not find the HTML file at: " & htmlFilePath, "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub wvAddForm_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles wvAddForm.NavigationCompleted
        If e.IsSuccess Then
            LoadEligibleEmployeesIntoHTML()
        End If
    End Sub

    Private Sub LoadEligibleEmployeesIntoHTML()
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT EmployeeID, (FirstName & ' ' & LastName) AS FullName, Role " &
                                  "FROM tblEmployees " &
                                  "WHERE isStylist = False AND isActive = True AND UserID IS NULL"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                Using reader As OleDbDataReader = cmd.ExecuteReader()

                    Dim jsonBuilder As New Text.StringBuilder()
                    jsonBuilder.Append("[")
                    Dim isFirst As Boolean = True

                    While reader.Read()
                        If Not isFirst Then jsonBuilder.Append(",")

                        jsonBuilder.Append("{")
                        jsonBuilder.Append("""id"":" & reader("EmployeeID").ToString() & ",")
                        jsonBuilder.Append("""name"":""" & reader("FullName").ToString() & """,")
                        jsonBuilder.Append("""role"":""" & reader("Role").ToString() & """")
                        jsonBuilder.Append("}")

                        isFirst = False
                    End While

                    jsonBuilder.Append("]")

                    If isFirst Then
                        MessageBox.Show("All eligible managers already have system accounts!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    wvAddForm.CoreWebView2.PostWebMessageAsJson(jsonBuilder.ToString())
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading eligible employees: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub HandleWebMessage(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
        Dim message As String = e.TryGetWebMessageAsString()

        If message = "CANCEL" Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        ElseIf message.StartsWith("SAVE|||") Then
            Dim parts() As String = message.Split(New String() {"|||"}, StringSplitOptions.None)

            Dim empId As Integer = Convert.ToInt32(parts(1))
            Dim user As String = parts(2)
            Dim pass As String = parts(3)
            Dim email As String = parts(4)
            Dim role As String = parts(5)

            SaveUserToDatabase(empId, user, pass, email, role)
        End If
    End Sub

    Private Sub SaveUserToDatabase(empId As Integer, user As String, pass As String, email As String, role As String)
        Dim generatedUserID As Integer = 0

        Try
            SessionManager.OpenConnection()

            Dim insertUser As String = "INSERT INTO tblUsers (Username, [Password], Role, Email, isActive) " &
                                       "VALUES (@user, @pass, @role, @email, True)"

            Using cmd As New OleDbCommand(insertUser, SessionManager.conn)
                cmd.Parameters.Add("@user", OleDbType.VarChar).Value = user
                cmd.Parameters.Add("@pass", OleDbType.VarChar).Value = pass
                cmd.Parameters.Add("@role", OleDbType.VarChar).Value = role
                cmd.Parameters.Add("@email", OleDbType.VarChar).Value = email
                cmd.ExecuteNonQuery()
            End Using

            Using cmdID As New OleDbCommand("SELECT @@IDENTITY", SessionManager.conn)
                generatedUserID = Convert.ToInt32(cmdID.ExecuteScalar())
            End Using

            Dim updateEmp As String = "UPDATE tblEmployees SET UserID = @uid WHERE EmployeeID = @empID"
            Using cmdUpdate As New OleDbCommand(updateEmp, SessionManager.conn)
                cmdUpdate.Parameters.AddWithValue("@uid", generatedUserID)
                cmdUpdate.Parameters.AddWithValue("@empID", empId)
                cmdUpdate.ExecuteNonQuery()
            End Using

            MessageBox.Show("User account created and linked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error creating account: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

End Class



'Imports System.Data.OleDb

'Public Class frmAddUser

'    Private Sub frmAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Try
'            SessionManager.OpenConnection()

'            Dim query As String = "SELECT EmployeeID, (FirstName & ' ' & LastName) AS FullName " &
'                                  "FROM tblEmployees " &
'                                  "WHERE isStylist = False AND isActive = True AND UserID IS NULL"

'            Dim adapter As New OleDbDataAdapter(query, SessionManager.conn)
'            Dim dt As New DataTable()
'            adapter.Fill(dt)

'            cmbSelectEmployee.DataSource = dt
'            cmbSelectEmployee.DisplayMember = "FullName"
'            cmbSelectEmployee.ValueMember = "EmployeeID"

'            If dt.Rows.Count = 0 Then
'                MessageBox.Show("All eligible managers already have system accounts!", "No Employees Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                btnSave.Enabled = False
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading eligible employees: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            SessionManager.CloseConnection()
'        End Try
'    End Sub


'    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'        If cmbSelectEmployee.SelectedValue Is Nothing OrElse txtUsername.Text.Trim() = "" OrElse txtPassword.Text.Trim() = "" Then
'            MessageBox.Show("Please select an employee and fill in all login details.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        Dim selectedEmployeeID As Integer = Convert.ToInt32(cmbSelectEmployee.SelectedValue)
'        Dim generatedUserID As Integer = 0

'        Try
'            SessionManager.OpenConnection()

'            Dim insertUser As String = "INSERT INTO tblUsers (Username, [Password], Role, Email) " &
'                                       "VALUES (@user, @pass, @role, @email)"

'            Using cmd As New OleDbCommand(insertUser, SessionManager.conn)
'                cmd.Parameters.Add("@user", OleDbType.VarChar).Value = txtUsername.Text.Trim()
'                cmd.Parameters.Add("@pass", OleDbType.VarChar).Value = txtPassword.Text
'                cmd.Parameters.Add("@role", OleDbType.VarChar).Value = cmbRole.Text
'                cmd.Parameters.Add("@email", OleDbType.VarChar).Value = txtEmail.Text.Trim()

'                cmd.ExecuteNonQuery()
'            End Using

'            Using cmdID As New OleDbCommand("SELECT @@IDENTITY", SessionManager.conn)
'                generatedUserID = Convert.ToInt32(cmdID.ExecuteScalar())
'            End Using

'            Dim updateEmp As String = "UPDATE tblEmployees SET UserID = @uid WHERE EmployeeID = @empID"
'            Using cmdUpdate As New OleDbCommand(updateEmp, SessionManager.conn)
'                cmdUpdate.Parameters.AddWithValue("@uid", generatedUserID)
'                cmdUpdate.Parameters.AddWithValue("@empID", selectedEmployeeID)
'                cmdUpdate.ExecuteNonQuery()
'            End Using

'            MessageBox.Show("User account created and linked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

'            Me.DialogResult = DialogResult.OK
'            Me.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error creating account: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            SessionManager.CloseConnection()
'        End Try
'    End Sub

'    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
'        Me.DialogResult = DialogResult.Cancel
'        Me.Close()
'    End Sub

'    Private Sub cmbSelectEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelectEmployee.SelectedIndexChanged
'        If cmbSelectEmployee.SelectedIndex <> -1 AndAlso TypeOf cmbSelectEmployee.SelectedValue Is Integer Then
'            Dim selectedID As Integer = Convert.ToInt32(cmbSelectEmployee.SelectedValue)

'            Try
'                SessionManager.OpenConnection()

'                Dim query As String = "SELECT Role FROM tblEmployees WHERE EmployeeID = @id"
'                Using cmd As New OleDbCommand(query, SessionManager.conn)
'                    cmd.Parameters.AddWithValue("@id", selectedID)
'                    Dim empRole As Object = cmd.ExecuteScalar()

'                    If empRole IsNot Nothing AndAlso Not DBNull.Value.Equals(empRole) Then
'                        cmbRole.Text = empRole.ToString()
'                    End If
'                End Using

'            Catch ex As Exception

'            Finally
'                SessionManager.CloseConnection()
'            End Try
'        End If
'    End Sub

'End Class