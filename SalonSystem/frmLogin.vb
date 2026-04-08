Imports System.Data.OleDb

Public Class frmLogin

    Private isPasswordVisible As Boolean = False

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDatabasePath()
        ResetPlaceholders()

        txtUsername.Text = "Enter username or email"
        txtPassword.Text = "Enter password"
        txtUsername.ForeColor = Color.RosyBrown
        txtPassword.ForeColor = Color.RosyBrown

        Using f As Font = txtUsername.Font
            txtUsername.Font = New Font(f.FontFamily, 11, f.Style)
        End Using
        Using f As Font = txtPassword.Font
            txtPassword.Font = New Font(f.FontFamily, 11, f.Style)
        End Using
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Enter username or email" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
            Using f As Font = txtUsername.Font
                txtUsername.Font = New Font(f.FontFamily, 12, f.Style)
            End Using
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.Text = "Enter username or email"
            txtUsername.ForeColor = Color.RosyBrown
            Using f As Font = txtUsername.Font
                txtUsername.Font = New Font(f.FontFamily, 11, f.Style)
            End Using
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Enter password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "•"c
            Using f As Font = txtPassword.Font
                txtPassword.Font = New Font(f.FontFamily, 12, f.Style)
            End Using

            If Not isPasswordVisible Then
                txtPassword.PasswordChar = "•"c
            End If
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.Text = "Enter password"
            txtPassword.ForeColor = Color.RosyBrown
            txtPassword.PasswordChar = ControlChars.NullChar
            Using f As Font = txtPassword.Font
                txtPassword.Font = New Font(f.FontFamily, 11, f.Style)
            End Using
        End If
    End Sub

    Private Sub picShowPassword_Click(sender As Object, e As EventArgs) Handles picShowPassword.Click
        If txtPassword.Text = "Enter password" Or txtPassword.Text = "" Then Return

        isPasswordVisible = Not isPasswordVisible

        If isPasswordVisible Then
            txtPassword.PasswordChar = ControlChars.NullChar
            picShowPassword.Image = My.Resources.visibility_off
        Else
            txtPassword.PasswordChar = "•"c
            picShowPassword.Image = My.Resources.visibility
        End If
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        lblExit.ForeColor = Color.IndianRed
    End Sub

    Private Sub lblExit_MouseLeave(sender As Object, e As EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.FromArgb(140, 16, 4)
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtUsername.Text = "Enter username or email" Or
           txtPassword.Text = "" Or txtPassword.Text = "Enter password" Then
            MessageBox.Show("Please enter both username/email and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()

            Dim query As String = "SELECT Role, Username FROM tblUsers WHERE (Username = @username OR Email = @email) AND Password = @password"
            Dim cmd As New OleDbCommand(query, conn)

            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@email", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read()
                CurrentUserRole = reader("Role").ToString()
                CurrentUsername = reader("Username").ToString()

                If CurrentUserRole = "Super Admin" Then
                    Dim hub As New frmHub()
                    hub.Show()
                    Me.Hide()
                ElseIf CurrentUserRole = "Manager" Or CurrentUserRole = "Assistant Manager" Then
                    Dim dashboard As New frmDashboard()
                    dashboard.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Unrecognized Role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid credentials. Please check your username/email and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ResetPlaceholders()
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub ResetPlaceholders()
        txtUsername.Text = "Enter username or email"
        txtUsername.ForeColor = Color.RosyBrown
        Using f As Font = txtUsername.Font
            txtUsername.Font = New Font(f.FontFamily, 11, f.Style)
        End Using

        txtPassword.Text = "Enter password"
        txtPassword.ForeColor = Color.RosyBrown
        Using f As Font = txtPassword.Font
            txtPassword.Font = New Font(f.FontFamily, 11, f.Style)
        End Using

        txtPassword.PasswordChar = ControlChars.NullChar

        Me.ActiveControl = Nothing
    End Sub
End Class