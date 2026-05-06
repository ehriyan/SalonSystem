Public Class frmHub
    Private Sub frmHub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & CurrentUsername & "!"
    End Sub

    Private Sub Card_MouseEnter(sender As Object, e As EventArgs) Handles pnlPOSCard.MouseEnter, lblPOSTitle.MouseEnter, lblPOSDesc.MouseEnter, picPOS.MouseEnter
        pnlPOSCard.BackColor = Color.SlateGray
        lblPOSTitle.ForeColor = Color.White
        lblPOSDesc.ForeColor = Color.White
        picPOS.Image = My.Resources.pos_light
        pnlPOSCard.Cursor = Cursors.Hand
    End Sub

    Private Sub Card_MouseLeave(sender As Object, e As EventArgs) Handles pnlPOSCard.MouseLeave, lblPOSTitle.MouseLeave, lblPOSDesc.MouseLeave, picPOS.MouseLeave
        pnlPOSCard.BackColor = Color.White
        lblPOSTitle.ForeColor = Color.Black
        lblPOSDesc.ForeColor = Color.DimGray
        picPOS.Image = My.Resources.pos_dark
    End Sub

    Private Sub Card_Click(sender As Object, e As EventArgs) Handles pnlPOSCard.Click, lblPOSTitle.Click, lblPOSDesc.Click
        Dim posForm As New frmPOS()
        Me.Hide()
        posForm.ShowDialog()
        Me.Show()
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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Dim payForm As New frmPayroll()
        Me.Hide()
        payForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class