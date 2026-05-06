Imports System.Data.OleDb

Public Class frmPOS

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDatabasePath()
        LoadServices("All")
        SetupCart()
        HighlightCategory(btnAll, pnlUnderlineAll)
        CalculateGrandTotal()

        tmrClock.Interval = 1000
        tmrClock.Start()
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        lblTime.Text = DateTime.Now.ToString("hh:mm tt")
    End Sub

    Private Sub LoadServices(categoryFilter As String)
        flpServices.Controls.Clear()

        Try
            OpenConnection()

            Dim query As String = "SELECT ServiceID, ServiceName, Category, Price FROM tblServices WHERE IsActive = True"

            If categoryFilter <> "All" Then
                query &= " AND Category = @category"
            End If

            Dim cmd As New OleDbCommand(query, conn)

            If categoryFilter <> "All" Then
                cmd.Parameters.AddWithValue("@category", categoryFilter)
            End If

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim btn As New Button()

                Dim sName As String = reader("ServiceName").ToString()
                Dim sPrice As Decimal = Convert.ToDecimal(reader("Price"))

                btn.Text = sName & vbCrLf & "₱" & sPrice.ToString("N2")
                btn.Tag = reader("ServiceID").ToString() & "|" & sName & "|" & sPrice.ToString()

                btn.Size = New Size(140, 100)
                btn.BackColor = Color.Gainsboro
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New Font("DM Sans", 11, FontStyle.Regular)
                btn.Cursor = Cursors.Hand
                'btn.Margin = New Padding(15, 0, 0, 0)

                AddHandler btn.Click, AddressOf ServiceButton_Click

                flpServices.Controls.Add(btn)
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading services: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub ServiceButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        Dim tagData As String() = clickedButton.Tag.ToString().Split("|"c)

        Dim sID As Integer = Convert.ToInt32(tagData(0))
        Dim sName As String = tagData(1)
        Dim sPrice As Decimal = Convert.ToDecimal(tagData(2))

        Dim popup As New frmSelectStylists()

        If popup.ShowDialog() = DialogResult.OK Then
            dgvCart.Rows.Add(sID, sName, popup.SelectedStylistNames, sPrice)
            CalculateGrandTotal()
        End If
    End Sub

    Private Sub CalculateGrandTotal()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If Not row.IsNewRow Then
                total += Convert.ToDecimal(row.Cells("colPrice").Value)
            End If
        Next

        lblTotal.Text = "Total: ₱" & total.ToString("N2")
    End Sub

    Private Sub HighlightCategory(activeButton As Button, activeLine As Panel)
        pnlUnderlineAll.Visible = False
        pnlUnderlineHair.Visible = False
        pnlUnderlineGrooming.Visible = False
        pnlUnderlineCosmetics.Visible = False

        Dim normalFont As New Font("DM Sans", 11, FontStyle.Regular)
        Dim boldFont As New Font("DM Sans", 11, FontStyle.Bold)

        btnAll.Font = normalFont
        btnHair.Font = normalFont
        btnGrooming.Font = normalFont
        btnCosmetics.Font = normalFont

        activeLine.Visible = True
        activeButton.Font = boldFont
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        pnlUnderlineAll.Visible = True
        HighlightCategory(btnAll, pnlUnderlineAll)
        LoadServices("All")
    End Sub

    Private Sub btnHair_Click(sender As Object, e As EventArgs) Handles btnHair.Click
        HighlightCategory(btnHair, pnlUnderlineHair)
        LoadServices("Hair")
    End Sub

    Private Sub btnGrooming_Click(sender As Object, e As EventArgs) Handles btnGrooming.Click
        HighlightCategory(btnGrooming, pnlUnderlineGrooming)
        LoadServices("Grooming")
    End Sub

    Private Sub btnCosmetics_Click(sender As Object, e As EventArgs) Handles btnCosmetics.Click
        HighlightCategory(btnCosmetics, pnlUnderlineCosmetics)
        LoadServices("Cosmetics")
    End Sub

    Private Sub SetupCart()
        dgvCart.Columns.Clear()

        dgvCart.AllowUserToAddRows = False
        dgvCart.RowHeadersVisible = False
        dgvCart.BackgroundColor = Color.White
        dgvCart.BorderStyle = BorderStyle.None
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvCart.Columns.Add("colID", "ID")
        dgvCart.Columns("colID").Visible = False

        dgvCart.Columns.Add("colItem", "Item")
        dgvCart.Columns.Add("colStylist", "Stylist")

        dgvCart.Columns.Add("colPrice", "Price")
        dgvCart.Columns("colPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCart.Columns("colPrice").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("The cart is empty!", "Cannot Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim cleanTotalStr As String = lblTotal.Text.Replace("TOTAL:", "").Replace("Total:", "").Replace("₱", "").Replace(",", "").Trim()

        Dim finalTotal As Decimal

        If Decimal.TryParse(cleanTotalStr, finalTotal) Then
            Dim paymentScreen As New frmPayment(finalTotal)

            If paymentScreen.ShowDialog() = DialogResult.OK Then
                dgvCart.Rows.Clear()
                CalculateGrandTotal()
            End If

        Else
            MessageBox.Show("Error reading the total amount. The computer sees: '" & cleanTotalStr & "'", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnClearCart_Click(sender As Object, e As EventArgs) Handles btnClearCart.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("The cart is already empty.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear all items from the cart?", "Confirm Clear Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            dgvCart.Rows.Clear()
            CalculateGrandTotal()
        End If
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If dgvCart.Rows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("You currently have items in the cart. Are you sure you want to exit and cancel this transaction?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub flpServices_Paint(sender As Object, e As PaintEventArgs) Handles flpServices.Paint

    End Sub

    Private Sub pnlCart_Paint(sender As Object, e As PaintEventArgs) Handles pnlCart.Paint

    End Sub
End Class