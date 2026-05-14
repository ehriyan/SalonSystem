Imports System.Data.OleDb
Imports Org.BouncyCastle.Asn1.Cmp

Public Class frmViewClient
    Private _currentClientID As Integer

    Public Sub New(ByVal clientID As Integer)
        InitializeComponent()
        _currentClientID = clientID
    End Sub

    Private Sub frmViewClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeTextBoxesReadOnly()

        Try
            SessionManager.OpenConnection()

            Dim query As String = "SELECT * FROM tblClients WHERE ClientID = @id"

            Using cmd As New OleDbCommand(query, SessionManager.conn)
                cmd.Parameters.AddWithValue("@id", _currentClientID)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtFullName.Text = reader("FirstName").ToString() & " " & reader("LastName").ToString()

                        txtContact.Text = reader("ContactNumber").ToString()
                        txtEmail.Text = reader("Email").ToString()
                        txtAddress.Text = reader("Address").ToString()
                        txtCustomerType.Text = reader("CustomerType").ToString()

                        If Not IsDBNull(reader("Birthday")) Then
                            txtBirthday.Text = Convert.ToDateTime(reader("Birthday")).ToString("MMMM dd, yyyy")
                        Else
                            txtBirthday.Text = "No Birthday on file"
                        End If

                        If Not IsDBNull(reader("InitialVisit")) Then
                            txtInitialVisit.Text = Convert.ToDateTime(reader("InitialVisit")).ToString("D")
                        End If

                        Dim isReturning As Boolean = If(IsDBNull(reader("ReturningCustomer")), False, Convert.ToBoolean(reader("ReturningCustomer")))
                        txtReturning.Text = If(isReturning, "Yes", "No")

                        Dim isActive As Boolean = If(IsDBNull(reader("isActive")), False, Convert.ToBoolean(reader("isActive")))
                        lblStatus.Text = If(isActive, "● ACTIVE", "● ARCHIVED")
                        lblStatus.ForeColor = If(isActive, Color.SeaGreen, Color.Crimson)

                        txtRemarks.Text = reader("Remarks").ToString()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading client profile: " & ex.Message)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

    Private Sub MakeTextBoxesReadOnly()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.ReadOnly = True
                txt.BackColor = Color.FromArgb(245, 245, 245)
                txt.BorderStyle = BorderStyle.None
            End If
        Next
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class