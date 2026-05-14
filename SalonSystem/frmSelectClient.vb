Imports System.Data.OleDb

Public Class frmSelectClient
    Public SelectedClientID As Integer = 0
    Public SelectedClientName As String = ""

    Private Sub frmSelectClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClients("")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadClients(txtSearch.Text.Trim())
    End Sub

    Private Sub LoadClients(searchTerm As String)
        dgvClients.Rows.Clear()

        If dgvClients.Columns.Count = 0 Then
            dgvClients.Columns.Add("colID", "ID")
            dgvClients.Columns("colID").Visible = False
            dgvClients.Columns.Add("colName", "Client Name")
            dgvClients.Columns.Add("colContact", "Contact Number")
            dgvClients.Columns.Add("colType", "Type")
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        Try
            OpenConnection()

            Dim query As String = "SELECT ClientID, FirstName, LastName, ContactNumber, CustomerType FROM tblClients"

            If searchTerm <> "" Then
                query &= " WHERE FirstName LIKE @search OR LastName LIKE @search OR ContactNumber LIKE @search"
            End If

            Dim cmd As New OleDbCommand(query, conn)

            If searchTerm <> "" Then
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim id As Integer = Convert.ToInt32(reader("ClientID"))
                Dim fullName As String = reader("FirstName").ToString() & " " & reader("LastName").ToString()
                Dim contact As String = reader("ContactNumber").ToString()
                Dim clientType As String = reader("CustomerType").ToString()

                dgvClients.Rows.Add(id, fullName, contact, clientType)
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If dgvClients.Rows.Count > 0 AndAlso dgvClients.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvClients.SelectedRows(0)

            SelectedClientID = Convert.ToInt32(selectedRow.Cells("colID").Value)
            SelectedClientName = selectedRow.Cells("colName").Value.ToString()

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please select a client from the list.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCreateClient_Click(sender As Object, e As EventArgs) Handles btnCreateClient.Click
        Dim addClientForm As New frmAddClient()

        If addClientForm.ShowDialog() = DialogResult.OK Then
            txtSearch.Text = ""
            LoadClients("")
        End If
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class