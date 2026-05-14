Public Class frmPayment

    Public AmountTendered As Decimal = 0
    Public ChangeAmount As Decimal = 0
    Public PaymentMethod As String = "Cash"
    Public ReferenceNumber As String = ""

    Private totalDue As Decimal

    Public Sub New(total As Decimal)
        InitializeComponent()
        Me.totalDue = total
    End Sub

    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalDue.Text = "TOTAL DUE: ₱" & totalDue.ToString("N2")
        rdoCash.Checked = True
        CalculateChange()
    End Sub

    Private Sub PaymentMethod_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCash.CheckedChanged, rdoGCash.CheckedChanged, rdoCard.CheckedChanged
        Dim rdo As RadioButton = CType(sender, RadioButton)

        If rdo.Checked Then
            rdo.BackColor = Color.SlateGray
            rdo.ForeColor = Color.White

            If rdo.Name = "rdoGCash" OrElse rdo.Name = "rdoCard" Then
                PaymentMethod = If(rdo.Name = "rdoGCash", "GCash", "Card")

                txtTendered.Text = totalDue.ToString("N2")
                txtTendered.Enabled = False

                txtReference.Visible = True
                lblChange.Visible = False
            Else
                PaymentMethod = "Cash"

                txtTendered.Text = ""
                txtTendered.Enabled = True

                txtReference.Visible = False
                lblChange.Visible = True
                lblChange.Text = "CHANGE: ₱0.00"
                txtTendered.Focus()
            End If
        Else
            rdo.BackColor = Color.WhiteSmoke
            rdo.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtTendered_TextChanged(sender As Object, e As EventArgs) Handles txtTendered.TextChanged
        CalculateChange()
    End Sub

    Private Sub CalculateChange()
        Dim tendered As Decimal
        If Decimal.TryParse(txtTendered.Text, tendered) Then
            ChangeAmount = tendered - totalDue

            If ChangeAmount >= 0 Then
                lblChange.Text = "CHANGE: ₱" & ChangeAmount.ToString("N2")
                lblChange.ForeColor = Color.MediumSeaGreen
                btnCompleteSale.Enabled = True
            Else
                lblChange.Text = "INSUFFICIENT FUNDS"
                lblChange.ForeColor = Color.IndianRed
                btnCompleteSale.Enabled = False
            End If
        Else
            lblChange.Text = "CHANGE: ₱0.00"
            btnCompleteSale.Enabled = False
        End If
    End Sub

    Private Sub btnCompleteSale_Click(sender As Object, e As EventArgs) Handles btnCompleteSale.Click
        AmountTendered = Convert.ToDecimal(txtTendered.Text)
        ReferenceNumber = txtReference.Text.Trim()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class