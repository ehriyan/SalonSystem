Imports System.Data.OleDb

Public Class frmEditEmployee
    Private _currentEmployeeID As Integer

    Public Sub New(ByVal empID As Integer)
        InitializeComponent()
        _currentEmployeeID = empID
    End Sub


    Private Sub frmEditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT FirstName, LastName, ContactNumber, Role, BaseSalary, CommissionRate " &
                                  "FROM tblEmployees WHERE EmployeeID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@id", _currentEmployeeID)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtFirstName.Text = reader("FirstName").ToString()
                        txtLastName.Text = reader("LastName").ToString()
                        txtContact.Text = reader("ContactNumber").ToString()
                        cmbRole.Text = reader("Role").ToString()
                        txtBaseSalary.Text = reader("BaseSalary").ToString()
                        txtCommission.Text = reader("CommissionRate").ToString()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employee details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstName.Text.Trim() = "" OrElse txtLastName.Text.Trim() = "" OrElse cmbRole.Text = "" Then
            MessageBox.Show("First Name, Last Name, and Role are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim baseSal As Decimal = 0
        Decimal.TryParse(txtBaseSalary.Text, baseSal)

        Dim commRate As Double = 0
        Double.TryParse(txtCommission.Text, commRate)

        Dim isStylist As Boolean = If(cmbRole.Text = "Stylist", True, False)

        Try
            SessionManager.OpenConnection()

            Dim updateQuery As String = "UPDATE tblEmployees SET " &
                                        "FirstName = @fname, LastName = @lname, ContactNumber = @contact, " &
                                        "Role = @role, BaseSalary = @base, CommissionRate = @comm, isStylist = @isSty " &
                                        "WHERE EmployeeID = @id"

            Using cmd As New OleDbCommand(updateQuery, SessionManager.conn)
                cmd.Parameters.Add("@fname", OleDbType.VarChar).Value = txtFirstName.Text.Trim()
                cmd.Parameters.Add("@lname", OleDbType.VarChar).Value = txtLastName.Text.Trim()
                cmd.Parameters.Add("@contact", OleDbType.VarChar).Value = txtContact.Text.Trim()
                cmd.Parameters.Add("@role", OleDbType.VarChar).Value = cmbRole.Text
                cmd.Parameters.Add("@base", OleDbType.Currency).Value = baseSal
                cmd.Parameters.Add("@comm", OleDbType.Double).Value = commRate
                cmd.Parameters.Add("@isSty", OleDbType.Boolean).Value = isStylist

                cmd.Parameters.AddWithValue("@id", _currentEmployeeID)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving employee: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class