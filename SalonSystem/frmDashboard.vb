Public Class frmDashboard
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentScreen As Screen = Screen.FromControl(Me)
        Me.MaximizedBounds = currentScreen.WorkingArea

        lblWelcome.Text = "Welcome, " & CurrentUsername & "!"

        LoadFormInPanel(New frmHome())
    End Sub

    Private Sub frmDashboard_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        Me.MaximizedBounds = Screen.FromControl(Me).WorkingArea
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            CurrentUsername = ""
            CurrentUserRole = ""

            Dim loginForm As New frmLogin()
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub LoadFormInPanel(ByVal childForm As Form)
        pnlMainContent.Controls.Clear()

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None

        childForm.Dock = DockStyle.Fill

        pnlMainContent.Controls.Add(childForm)
        childForm.Show()
    End Sub

    Private Sub SetActiveButton(ByVal activeBtn As Button)
        For Each ctrl As Control In pnlSidebar.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.FromArgb(250, 245, 242)
                ctrl.ForeColor = Color.Black
            End If
        Next
        activeBtn.BackColor = Color.LightCoral
        activeBtn.ForeColor = Color.White
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        Me.Hide()
        Dim posTerminal As New frmPOS()
        posTerminal.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        SetActiveButton(btnDashboard)
        LoadFormInPanel(New frmHome())
    End Sub

    Private Sub btnManageUsers_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        SetActiveButton(btnManageUsers)
        LoadFormInPanel(New frmManageUsers())
    End Sub

    Private Sub btnManageClients_Click(sender As Object, e As EventArgs) Handles btnManageClients.Click
        SetActiveButton(btnManageClients)
        LoadFormInPanel(New frmManageClients())
    End Sub

    Private Sub pnlMainContent_Paint(sender As Object, e As PaintEventArgs) Handles pnlMainContent.Paint

    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        SetActiveButton(btnPayroll)
        LoadFormInPanel(New frmPayroll())
    End Sub
End Class