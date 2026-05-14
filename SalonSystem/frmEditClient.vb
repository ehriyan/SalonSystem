Imports System.Data.OleDb

Public Class frmEditClient
    Private _currentClientID As Integer

    Public Sub New(ByVal clientID As Integer)
        InitializeComponent()
        _currentClientID = clientID
    End Sub


    Private Sub frmEditClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT FirstName, LastName, ContactNumber, Email, Address, Birthday, CustomerType, InitialVisit, ReturningCustomer, Remarks " &
                                  "FROM tblClients WHERE ClientID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@id", _currentClientID)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtFirstName.Text = reader("FirstName").ToString()
                        txtLastName.Text = reader("LastName").ToString()
                        txtContact.Text = reader("ContactNumber").ToString()
                        txtEmail.Text = reader("Email").ToString()
                        txtAddress.Text = reader("Address").ToString()
                        cmbCustomerType.Text = reader("CustomerType").ToString()
                        txtRemarks.Text = reader("Remarks").ToString()

                        chkReturning.Checked = If(IsDBNull(reader("ReturningCustomer")), False, Convert.ToBoolean(reader("ReturningCustomer")))

                        If Not IsDBNull(reader("Birthday")) Then
                            dtpBirthday.Value = Convert.ToDateTime(reader("Birthday"))
                            dtpBirthday.Checked = True
                        Else
                            dtpBirthday.Checked = False
                        End If

                        If Not IsDBNull(reader("InitialVisit")) Then
                            dtpInitialVisit.Value = Convert.ToDateTime(reader("InitialVisit"))
                            dtpInitialVisit.Checked = True
                        Else
                            dtpInitialVisit.Checked = False
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading client details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstName.Text.Trim() = "" OrElse txtLastName.Text.Trim() = "" Then
            MessageBox.Show("First Name and Last Name are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            SessionManager.OpenConnection()

            Dim updateQuery As String = "UPDATE tblClients SET " &
                                        "FirstName = @fname, LastName = @lname, ContactNumber = @contact, Email = @email, " &
                                        "Address = @address, Birthday = @bday, CustomerType = @ctype, InitialVisit = @ivisit, " &
                                        "ReturningCustomer = @returning, Remarks = @remarks " &
                                        "WHERE ClientID = @id"

            Using cmd As New OleDbCommand(updateQuery, SessionManager.conn)
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

                cmd.Parameters.AddWithValue("@id", _currentClientID)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving client: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class