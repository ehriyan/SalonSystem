Imports System.Data.OleDb

Public Class frmAddClient
    Private CurrentClientID As Integer = 0
    Public Sub New()
        InitializeComponent()
        CurrentClientID = 0
    End Sub

    Public Sub New(ByVal passedClientID As Integer)
        InitializeComponent()
        CurrentClientID = passedClientID
    End Sub

    Private Sub frmAddClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentClientID = 0 Then
            Me.Text = "Add New Client"
            btnSave.Text = "Save Client"
        Else
            Me.Text = "Client Profile"
            btnSave.Text = "Update Profile"
            LoadClientData()
        End If
    End Sub

    Private Sub LoadClientData()
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM tblClients WHERE ClientID = @id"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", CurrentClientID)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtFirstName.Text = reader("FirstName").ToString()
                txtLastName.Text = reader("LastName").ToString()
                txtContact.Text = reader("ContactNumber").ToString()
                txtEmail.Text = reader("Email").ToString()
                txtAddress.Text = reader("Address").ToString()
                cmbCustomerType.SelectedItem = reader("CustomerType").ToString()
                txtRemarks.Text = reader("Remarks").ToString()

                If Not IsDBNull(reader("Birthday")) Then dtpBirthday.Value = Convert.ToDateTime(reader("Birthday"))
                If Not IsDBNull(reader("InitialVisit")) Then dtpInitialVisit.Value = Convert.ToDateTime(reader("InitialVisit"))

                If Not IsDBNull(reader("ReturningCustomer")) Then
                    chkReturning.Checked = Convert.ToBoolean(reader("ReturningCustomer"))
                End If
            End If
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtContact.Text = "" Then
            MessageBox.Show("Fill out all required information.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim cmd As New OleDbCommand()
            cmd.Connection = conn

            If CurrentClientID = 0 Then
                cmd.CommandText = "INSERT INTO tblClients (LastName, FirstName, ContactNumber, Email, Address, Birthday, CustomerType, InitialVisit, ReturningCustomer, Remarks) " &
                              "VALUES (@fname, @lname, @contact, @email, @address, @bday, @type, @visit, @returning, @remarks)"
            Else
                cmd.CommandText = "UPDATE tblClients SET LastName=@lname, FirstName=@fname, ContactNumber=@contact, Email=@email, " &
                              "Address=@address, Birthday=@bday, CustomerType=@type, InitialVisit=@visit, ReturningCustomer=@returning, Remarks=@remarks " &
                              "WHERE ClientID = @id"
            End If

            cmd.Parameters.AddWithValue("@lname", txtLastName.Text)
            cmd.Parameters.AddWithValue("@fname", txtFirstName.Text)
            cmd.Parameters.AddWithValue("@contact", txtContact.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@bday", dtpBirthday.Value.Date)

            If cmbCustomerType.SelectedItem IsNot Nothing Then
                cmd.Parameters.AddWithValue("@type", cmbCustomerType.SelectedItem.ToString())
            Else
                cmd.Parameters.AddWithValue("@type", "Walk-in")
            End If

            cmd.Parameters.AddWithValue("@visit", dtpInitialVisit.Value.Date)
            cmd.Parameters.AddWithValue("@returning", chkReturning.Checked)
            cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)

            If CurrentClientID <> 0 Then
                cmd.Parameters.AddWithValue("@id", CurrentClientID)
            End If

            cmd.ExecuteNonQuery()

            MessageBox.Show("Client saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.Close()
    End Sub
End Class