Imports System.Data.OleDb

Public Class frmEditService
    Private _serviceID As Integer

    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        _serviceID = id
    End Sub

    Private Sub frmEditService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SessionManager.OpenConnection()
            Dim query As String = "SELECT ServiceName, Category, Price FROM tblServices WHERE ServiceID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@id", _serviceID)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtServiceName.Text = reader("ServiceName").ToString()
                        cmbCategory.Text = reader("Category").ToString()
                        txtPrice.Text = String.Format("{0:F2}", reader("Price"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading service: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim servicePrice As Decimal = 0
        If Not Decimal.TryParse(txtPrice.Text, servicePrice) Then
            MessageBox.Show("Invalid price.")
            Exit Sub
        End If

        Try
            SessionManager.OpenConnection()
            Dim query As String = "UPDATE tblServices SET ServiceName = @name, Category = @cat, Price = @price WHERE ServiceID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.Add("@name", OleDbType.VarChar).Value = txtServiceName.Text.Trim()
                cmd.Parameters.Add("@cat", OleDbType.VarChar).Value = cmbCategory.Text.Trim()
                cmd.Parameters.Add("@price", OleDbType.Currency).Value = servicePrice
                cmd.Parameters.AddWithValue("@id", _serviceID)

                cmd.ExecuteNonQuery()
            End Using

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error updating service: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub
End Class