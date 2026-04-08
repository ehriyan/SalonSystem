Public Class frmDashboard
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & CurrentUsername & "!"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            CurrentUsername = ""
            CurrentUserRole = ""

            Dim loginForm As New frmLogin()
            loginForm.Show()
            Me.Close()
        End If
    End Sub
End Class