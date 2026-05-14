Imports System.Data.OleDb

Public Class frmAddEmployee

    Private Sub frmAddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupRoleRestrictions()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstName.Text.Trim() = "" OrElse txtLastName.Text.Trim() = "" OrElse cmbRole.Text = "" Then
            MessageBox.Show("First Name, Last Name, and Role are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim fName As String = txtFirstName.Text.Trim()
        Dim lName As String = txtLastName.Text.Trim()
        Dim contact As String = txtContact.Text.Trim()
        Dim role As String = cmbRole.Text

        Dim baseSal As Decimal = 0
        Decimal.TryParse(txtBaseSalary.Text, baseSal)

        Dim commRate As Double = 0
        Double.TryParse(txtCommission.Text, commRate)

        Dim isStylist As Boolean = If(role = "Stylist", True, False)
        Dim isActive As Boolean = True

        Try
            SessionManager.OpenConnection()

            Dim query As String = "INSERT INTO tblEmployees (FirstName, LastName, ContactNumber, BaseSalary, CommissionRate, Role, isStylist, isActive) " &
                              "VALUES (@fname, @lname, @contact, @base, @comm, @role, @isSty, @isAct)"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@fname", OleDbType.VarChar).Value = fName
                cmd.Parameters.Add("@lname", OleDbType.VarChar).Value = lName
                cmd.Parameters.Add("@contact", OleDbType.VarChar).Value = contact
                cmd.Parameters.Add("@base", OleDbType.Currency).Value = baseSal
                cmd.Parameters.Add("@comm", OleDbType.Double).Value = commRate
                cmd.Parameters.Add("@role", OleDbType.VarChar).Value = role
                cmd.Parameters.Add("@isSty", OleDbType.Boolean).Value = isStylist
                cmd.Parameters.Add("@isAct", OleDbType.Boolean).Value = isActive

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("New employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving employee: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub SetupRoleRestrictions()
        cmbRole.Items.Clear()
        Dim currentRole As String = SessionManager.CurrentUserRole

        If currentRole = "Owner" Then
            cmbRole.Items.AddRange({"Manager", "Assistant Manager", "Stylist"})
        ElseIf currentRole = "Manager" Then
            cmbRole.Items.AddRange({"Assistant Manager", "Stylist"})
        Else
            btnSave.Enabled = False
            MessageBox.Show("You do not have permission to create user accounts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


End Class