Public Class frmPayment
    Dim totalAmountDue As Decimal

    Public Sub New(ByVal cartTotal As Decimal)
        InitializeComponent()
        totalAmountDue = cartTotal
    End Sub

    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnCompleteSale.Enabled = False
        pnlCashDetails.Visible = False
        lblAmountDue.Text = totalAmountDue.ToString("C2")
    End Sub

    Private Sub PaymentMethod_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged, rdoCard.CheckedChanged, rdoGCash.CheckedChanged
        If rdoCash.Checked OrElse rdoCard.Checked OrElse rdoGCash.Checked Then
            btnCompleteSale.Enabled = True
        End If
    End Sub

    Private Sub rdoCash_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged
        If rdoCash.Checked Then
            pnlCashDetails.Visible = True
            pnlCardDetails.Visible = False
            pnlGCashDetails.Visible = False

            txtAmountReceived.Focus()

            CalculateChange()
        Else
            pnlCashDetails.Visible = False
            btnCompleteSale.Enabled = True
        End If
    End Sub

    Private Sub rdoCard_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCard.CheckedChanged
        If rdoCard.Checked Then
            pnlCardDetails.Visible = True
            pnlCashDetails.Visible = False
            pnlGCashDetails.Visible = False

            txtCardRef.Focus()
            ValidateCard()
        End If
    End Sub

    Private Sub rdoGCash_CheckedChanged(sender As Object, e As EventArgs) Handles rdoGCash.CheckedChanged
        If rdoGCash.Checked Then
            pnlGCashDetails.Visible = True
            pnlCashDetails.Visible = False
            pnlCardDetails.Visible = False

            txtGCashRef.Focus()
            ValidateGCash()
        End If
    End Sub

    Private Sub txtCardRef_TextChanged(sender As Object, e As EventArgs) Handles txtCardRef.TextChanged
        ValidateCard()
    End Sub

    Private Sub ValidateCard()
        If txtCardRef.Text.Trim() <> "" Then
            btnCompleteSale.Enabled = True
        Else
            btnCompleteSale.Enabled = False
        End If
    End Sub

    Private Sub txtGCashRef_TextChanged(sender As Object, e As EventArgs) Handles txtGCashRef.TextChanged
        ValidateGCash()
    End Sub

    Private Sub ValidateGCash()
        If txtGCashRef.Text.Trim() <> "" Then
            btnCompleteSale.Enabled = True
        Else
            btnCompleteSale.Enabled = False
        End If
    End Sub

    Private Sub btnCompleteSale_Click(sender As Object, e As EventArgs) Handles btnCompleteSale.Click
        If rdoCash.Checked Then
            ' Process Cash
        ElseIf rdoCard.Checked Then
            ' Process Card
        ElseIf rdoGCash.Checked Then
            ' Process GCash
        End If

        MessageBox.Show("Sale completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtAmountReceived_TextChanged(sender As Object, e As EventArgs) Handles txtAmountReceived.TextChanged
        CalculateChange()
    End Sub

    Private Sub CalculateChange()
        Dim amountReceived As Decimal

        If Decimal.TryParse(txtAmountReceived.Text, amountReceived) Then

            Dim change As Decimal = amountReceived - totalAmountDue

            If change >= 0 Then
                lblChangeDue.Text = change.ToString("C2")
                lblChangeDue.ForeColor = Color.Green
                btnCompleteSale.Enabled = True
            Else
                lblChangeDue.Text = "0.00"
                lblChangeDue.ForeColor = Color.Red
                btnCompleteSale.Enabled = False
            End If

        Else
            lblChangeDue.Text = "0.00"
            lblChangeDue.ForeColor = Color.Black
            btnCompleteSale.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Me.Close()
    End Sub
End Class