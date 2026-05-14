Imports System.Data.OleDb

Public Class frmAddClient

    Private Sub frmAddClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpBirthday.Checked = False
        dtpInitialVisit.Value = DateTime.Now
        dtpInitialVisit.Checked = True

        If cmbCustomerType.Items.Count > 0 Then
            cmbCustomerType.SelectedIndex = 0
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstName.Text.Trim() = "" OrElse txtLastName.Text.Trim() = "" Then
            MessageBox.Show("First Name and Last Name are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            SessionManager.OpenConnection()

            Dim insertQuery As String = "INSERT INTO tblClients " &
                                        "(FirstName, LastName, ContactNumber, Email, Address, Birthday, " &
                                        "CustomerType, InitialVisit, ReturningCustomer, Remarks, isActive) " &
                                        "VALUES (@fname, @lname, @contact, @email, @address, @bday, " &
                                        "@ctype, @ivisit, @returning, @remarks, @isActive)"

            Using cmd As New OleDbCommand(insertQuery, SessionManager.conn)
                cmd.Parameters.Add("@fname", OleDbType.VarChar).Value = txtFirstName.Text.Trim()
                cmd.Parameters.Add("@lname", OleDbType.VarChar).Value = txtLastName.Text.Trim()
                cmd.Parameters.Add("@contact", OleDbType.VarChar).Value = txtContact.Text.Trim()
                cmd.Parameters.Add("@email", OleDbType.VarChar).Value = txtEmail.Text.Trim()
                cmd.Parameters.Add("@address", OleDbType.VarChar).Value = txtAddress.Text.Trim()

                If dtpBirthday.Checked Then
                    cmd.Parameters.Add("@bday", OleDbType.Date).Value = dtpBirthday.Value.Date
                Else
                    cmd.Parameters.Add("@bday", OleDbType.Date).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@ctype", OleDbType.VarChar).Value = cmbCustomerType.Text

                If dtpInitialVisit.Checked Then
                    cmd.Parameters.Add("@ivisit", OleDbType.Date).Value = dtpInitialVisit.Value.Date
                Else
                    cmd.Parameters.Add("@ivisit", OleDbType.Date).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@returning", OleDbType.Boolean).Value = chkReturning.Checked
                cmd.Parameters.Add("@remarks", OleDbType.LongVarChar).Value = txtRemarks.Text.Trim()

                cmd.Parameters.Add("@isActive", OleDbType.Boolean).Value = True

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("New client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving new client: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class