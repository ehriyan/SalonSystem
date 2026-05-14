Public Class frmDiscount
    Public FinalDiscountAmount As Decimal = 0
    Public DiscountDescription As String = ""

    Dim itemPrice As Decimal
    Dim itemName As String

    Public Sub New(name As String, price As Decimal)
        InitializeComponent()
        Me.itemName = name
        Me.itemPrice = price
    End Sub

    Private Sub frmDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblItemName.Text = "Item: " & itemName
        lblOriginalPrice.Text = "Original Price: " & itemPrice.ToString("C2")
        txtInput.Text = "0"
        rdoPercentage.Checked = True

        cmbReason.Items.Clear()
        cmbReason.Items.Add("Senior Citizen / PWD")
        cmbReason.Items.Add("Promotional Code")
        cmbReason.Items.Add("Employee Discount")
        cmbReason.Items.Add("Management Comp (Free)")
        cmbReason.Items.Add("Service Recovery (Apology)")

        cmbReason.SelectedIndex = 0

        CalculateLiveMath()
    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        CalculateLiveMath()
    End Sub

    Private Sub rdoPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPercentage.CheckedChanged, rdoFixed.CheckedChanged
        CalculateLiveMath()
    End Sub

    Private Sub CalculateLiveMath()
        Dim inputValue As Decimal
        Dim deduction As Decimal = 0

        If Decimal.TryParse(txtInput.Text, inputValue) Then
            If rdoPercentage.Checked Then
                If inputValue > 100 Then inputValue = 100
                deduction = itemPrice * (inputValue / 100D)
            Else
                If inputValue > itemPrice Then inputValue = itemPrice
                deduction = inputValue
            End If
        End If

        Dim newPrice As Decimal = itemPrice - deduction

        lblDeduction.Text = "Deduction: -" & deduction.ToString("C2")
        lblDeduction.ForeColor = Color.IndianRed
        lblNewTotal.Text = "New Price: " & newPrice.ToString("C2")
        lblNewTotal.ForeColor = Color.MediumSeaGreen

        FinalDiscountAmount = deduction
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If FinalDiscountAmount <= 0 Then
            MessageBox.Show("Please enter a valid discount amount.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedReason As String = cmbReason.SelectedItem.ToString()

        If rdoPercentage.Checked Then
            DiscountDescription = "   ↳ " & txtInput.Text & "% Off (" & selectedReason & ")"
        Else
            DiscountDescription = "   ↳ ₱" & txtInput.Text & " Off (" & selectedReason & ")"
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class