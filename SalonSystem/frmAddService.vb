Imports System.Data.OleDb

Public Class frmAddService
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtServiceName.Text.Trim() = "" OrElse txtPrice.Text.Trim() = "" Then
            MessageBox.Show("Service Name and Price are required.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim servicePrice As Decimal = 0
        If Not Decimal.TryParse(txtPrice.Text, servicePrice) Then
            MessageBox.Show("Please enter a valid numeric price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            SessionManager.OpenConnection()
            Dim query As String = "INSERT INTO tblServices (ServiceName, Category, Price, IsActive) VALUES (@name, @cat, @price, @active)"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@name", OleDbType.VarChar).Value = txtServiceName.Text.Trim()
                cmd.Parameters.Add("@cat", OleDbType.VarChar).Value = cmbCategory.Text.Trim()
                cmd.Parameters.Add("@price", OleDbType.Currency).Value = servicePrice
                cmd.Parameters.Add("@active", OleDbType.Boolean).Value = True

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub
End Class