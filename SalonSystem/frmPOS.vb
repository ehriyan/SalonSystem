Imports System.Data.OleDb
Imports System.IO
Imports System.Windows
Imports System.Windows.Documents
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmPOS
    Dim ActiveClientID As Integer = 0

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDatabasePath()
        LoadServices("All")
        SetupCart()
        HighlightCategory(btnAll, pnlUnderlineAll)
        CalculateGrandTotal()

        Me.AutoSize = False
        Me.WindowState = FormWindowState.Normal

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

                btn.AutoSize = False

                Dim sName As String = reader("ServiceName").ToString()
                Dim sPrice As Decimal = Convert.ToDecimal(reader("Price"))

                btn.Text = sName & vbCrLf & "₱" & sPrice.ToString("N2")
                btn.Tag = reader("ServiceID").ToString() & "|" & sName & "|" & sPrice.ToString()

                btn.Size = New System.Drawing.Size(140, 100)
                btn.BackColor = Color.Gainsboro
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Font = New System.Drawing.Font("DM Sans", 11, System.Drawing.FontStyle.Regular)
                btn.Cursor = Cursors.Hand

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
            Dim idString As String = String.Join(",", popup.SelectedStylistIDs)

            dgvCart.Rows.Add(sID, idString, sName, popup.SelectedStylistNames, sPrice)
            CalculateGrandTotal()
        End If
    End Sub

    Private Sub CalculateGrandTotal()
        Dim subtotal As Decimal = 0
        Dim totalDiscount As Decimal = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If Not row.IsNewRow Then
                Dim price As Decimal = Convert.ToDecimal(row.Cells("colPrice").Value)

                If price >= 0 Then
                    subtotal += price
                Else
                    totalDiscount += Math.Abs(price)
                End If
            End If
        Next

        Dim grandTotal As Decimal = subtotal - totalDiscount
        Dim vatableSales As Decimal = grandTotal / 1.12D
        Dim vatAmount As Decimal = grandTotal - vatableSales

        lblSubtotal.Text = "Subtotal: ₱" & subtotal.ToString("N2")
        lblDiscount.Text = "Discount: ₱" & totalDiscount.ToString("N2")

        If grandTotal > 0 Then
            Label2.Text = "VAT (12%): ₱" & vatAmount.ToString("N2")
            Label2.Visible = True
        Else
            Label2.Visible = False
        End If

        lblTotal.Text = "₱" & grandTotal.ToString("N2")
    End Sub

    Private Sub HighlightCategory(activeButton As Button, activeLine As Panel)
        pnlUnderlineAll.Visible = False
        pnlUnderlineHair.Visible = False
        pnlUnderlineGrooming.Visible = False
        pnlUnderlineCosmetics.Visible = False

        Dim normalFont As New System.Drawing.Font("DM Sans", 11, System.Drawing.FontStyle.Regular)
        Dim boldFont As New System.Drawing.Font("DM Sans", 11, System.Drawing.FontStyle.Bold)

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
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvCart.ShowCellToolTips = False

        dgvCart.BackgroundColor = Color.White
        dgvCart.BorderStyle = BorderStyle.None
        dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCart.GridColor = Color.FromArgb(220, 220, 220)
        dgvCart.EnableHeadersVisualStyles = False

        Dim headerStyle As New DataGridViewCellStyle()
        headerStyle.BackColor = Color.FromArgb(235, 235, 235)
        headerStyle.ForeColor = Color.DimGray
        headerStyle.Font = New System.Drawing.Font("DM Sans", 10, System.Drawing.FontStyle.Bold)
        headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        headerStyle.Padding = New Padding(7, 12, 7, 12)
        dgvCart.ColumnHeadersDefaultCellStyle = headerStyle
        dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvCart.ColumnHeadersHeight = 40

        Dim rowStyle As New DataGridViewCellStyle()
        rowStyle.BackColor = Color.White
        rowStyle.ForeColor = Color.Black
        rowStyle.Font = New System.Drawing.Font("DM Sans", 11, System.Drawing.FontStyle.Regular)
        rowStyle.SelectionBackColor = Color.AliceBlue
        rowStyle.SelectionForeColor = Color.Black
        rowStyle.Padding = New Padding(7, 5, 7, 5)
        dgvCart.DefaultCellStyle = rowStyle

        dgvCart.RowTemplate.Height = 45

        dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250)

        dgvCart.Columns.Add("colID", "ID")
        dgvCart.Columns("colID").Visible = False

        dgvCart.Columns.Add("colEmpIDs", "EmpIDs")
        dgvCart.Columns("colEmpIDs").Visible = False

        dgvCart.Columns.Add("colItem", "Item")
        dgvCart.Columns.Add("colStylist", "Stylist")

        dgvCart.Columns.Add("colPrice", "Price")
        dgvCart.Columns("colPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCart.Columns("colPrice").DefaultCellStyle.Format = "N2"

        For Each col As DataGridViewColumn In dgvCart.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("The cart is empty!", "Cannot Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim finalTotal As Decimal = 0
        If Not Decimal.TryParse(lblTotal.Text, Globalization.NumberStyles.Currency, Nothing, finalTotal) Then
            MessageBox.Show("Could not read the total amount correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim subtotal As Decimal = Convert.ToDecimal(lblSubtotal.Text.Replace("Subtotal: ₱", "").Replace(",", ""))
        Dim discount As Decimal = Convert.ToDecimal(lblDiscount.Text.Replace("Discount: ₱", "").Replace(",", ""))
        Dim vatableSales As Decimal = finalTotal / 1.12D
        Dim taxAmount As Decimal = finalTotal - vatableSales

        Dim paymentScreen As New frmPayment(finalTotal)

        If paymentScreen.ShowDialog() = DialogResult.OK Then
            Try
                OpenConnection()

                Dim cashierName As String = GetActiveEmployeeName()

                Dim headerQuery As String = "INSERT INTO tblTransactions (TransactionDate, ClientID, ProcessedBy, PaymentMethod, Subtotal, DiscountTotal, TaxAmount, GrandTotal, AmountTendered, ChangeAmount, ReferenceNumber) " &
                                            "VALUES (@date, @client, @cashier, @method, @subtotal, @discount, @tax, @total, @tendered, @change, @ref)"
                Dim cmd As New OleDbCommand(headerQuery, conn)
                cmd.Parameters.Add("@date", OleDbType.Date).Value = DateTime.Now
                cmd.Parameters.Add("@client", OleDbType.Integer).Value = ActiveClientID

                cmd.Parameters.Add("@cashier", OleDbType.VarChar).Value = cashierName
                cmd.Parameters.Add("@method", OleDbType.VarChar).Value = paymentScreen.PaymentMethod

                cmd.Parameters.Add("@subtotal", OleDbType.Currency).Value = subtotal
                cmd.Parameters.Add("@discount", OleDbType.Currency).Value = discount
                cmd.Parameters.Add("@tax", OleDbType.Currency).Value = taxAmount
                cmd.Parameters.Add("@total", OleDbType.Currency).Value = finalTotal
                cmd.Parameters.Add("@tendered", OleDbType.Currency).Value = paymentScreen.AmountTendered
                cmd.Parameters.Add("@change", OleDbType.Currency).Value = paymentScreen.ChangeAmount

                Dim safeRef As String = If(String.IsNullOrWhiteSpace(paymentScreen.ReferenceNumber), "None", paymentScreen.ReferenceNumber)
                cmd.Parameters.Add("@ref", OleDbType.VarChar).Value = safeRef

                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT @@IDENTITY"
                Dim generatedTransactionID As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                Dim detailQuery As String = "INSERT INTO tblTransactionDetails (TransactionID, ServiceID, EmployeeID, ItemName, StylistName, Price) " &
                            "VALUES (@tid, @sid, @eid, @iname, @sname, @price)"
                Dim cmdDetails As New OleDbCommand(detailQuery, conn)

                For Each row As DataGridViewRow In dgvCart.Rows
                    If Not row.IsNewRow Then
                        'MessageBox.Show("Now saving item: " & row.Cells("colItem").Value.ToString()) 

                        Dim empIDArray As String() = row.Cells("colEmpIDs").Value.ToString().Split(","c)
                        Dim stylistNameArray As String() = row.Cells("colStylist").Value.ToString().Split(","c)
                        Dim originalPrice As Decimal = Convert.ToDecimal(row.Cells("colPrice").Value)
                        Dim splitPrice As Decimal = originalPrice / empIDArray.Length

                        For i As Integer = 0 To empIDArray.Length - 1
                            cmdDetails.Parameters.Clear()
                            cmdDetails.Parameters.AddWithValue("@tid", generatedTransactionID)
                            cmdDetails.Parameters.AddWithValue("@sid", Convert.ToInt32(row.Cells("colID").Value))

                            cmdDetails.Parameters.AddWithValue("@eid", Convert.ToInt32(empIDArray(i).Trim()))
                            cmdDetails.Parameters.AddWithValue("@iname", row.Cells("colItem").Value.ToString())
                            cmdDetails.Parameters.AddWithValue("@sname", stylistNameArray(i).Trim())
                            cmdDetails.Parameters.AddWithValue("@price", splitPrice)

                            cmdDetails.ExecuteNonQuery()
                        Next
                    End If
                Next


                MessageBox.Show("Transaction Complete! Receipt #" & generatedTransactionID.ToString("D5"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                GenerateReceipt(generatedTransactionID)

                dgvCart.Rows.Clear()
                ActiveClientID = 0
                lblActiveClient.Text = "Walk-In Client"
                CalculateGrandTotal()

            Catch ex As Exception
                MessageBox.Show("Error saving transaction: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseConnection()
            End Try
        End If
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvCart.Rows.Count = 0 OrElse dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item from the cart to void.", "Void Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim itemName As String = dgvCart.SelectedRows(0).Cells("colItem").Value.ToString()
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to void '" & itemName & "'?", "Confirm Void", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
            CalculateGrandTotal()
        End If
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        If dgvCart.Rows.Count = 0 OrElse dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a specific service from the cart to apply a discount.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = dgvCart.SelectedRows(0)
        Dim itemName As String = selectedRow.Cells("colItem").Value.ToString()
        Dim itemPrice As Decimal = Convert.ToDecimal(selectedRow.Cells("colPrice").Value)
        Dim selectedIndex As Integer = selectedRow.Index

        If itemPrice < 0 Then
            MessageBox.Show("You cannot apply a discount to an existing discount line.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim discountModal As New frmDiscount(itemName, itemPrice)

        If discountModal.ShowDialog() = DialogResult.OK Then
            Dim negativePrice As Decimal = discountModal.FinalDiscountAmount * -1
            Dim description As String = discountModal.DiscountDescription

            dgvCart.Rows.Insert(selectedIndex + 1, 0, description, "N/A", negativePrice)

            dgvCart.ClearSelection()
            dgvCart.Rows(selectedIndex + 1).Selected = True
            CalculateGrandTotal()
        End If
    End Sub

    Private Sub btnEmptyCart_Click(sender As Object, e As EventArgs) Handles btnEmptyCart.Click
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

    Private Sub btnSelectClient_Click(sender As Object, e As EventArgs) Handles btnSelectClient.Click
        Dim clientModal As New frmSelectClient()

        If clientModal.ShowDialog() = DialogResult.OK Then
            ActiveClientID = clientModal.SelectedClientID
            lblActiveClient.Text = clientModal.SelectedClientName
        End If
    End Sub

    Private Sub btnAddNote_Click(sender As Object, e As EventArgs) Handles btnAddNote.Click
        If dgvCart.Rows.Count = 0 OrElse dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a service from the cart to attach a note.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = dgvCart.SelectedRows(0)
        Dim currentItemName As String = selectedRow.Cells("colItem").Value.ToString()
        Dim itemPrice As Decimal = Convert.ToDecimal(selectedRow.Cells("colPrice").Value)

        If itemPrice < 0 Then
            MessageBox.Show("Notes can only be added to services.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim noteInput As String = InputBox("Enter a note or formula for '" & currentItemName & "':", "Add Note", "")

        If noteInput.Trim() <> "" Then
            selectedRow.Cells("colItem").Value = currentItemName & " (*" & noteInput.Trim() & "*)"

            dgvCart.ClearSelection()
        End If
    End Sub

    Private Sub GenerateReceipt(transactionID As Integer)
        Dim receiptSize As New iTextSharp.text.Rectangle(284, 800)
        Dim doc As New iTextSharp.text.Document(receiptSize, 10, 10, 10, 10)

        Dim projectRoot As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "..\..\..\"))

        Dim folderPath As String = System.IO.Path.Combine(projectRoot, "Receipts")

        If Not System.IO.Directory.Exists(folderPath) Then
            System.IO.Directory.CreateDirectory(folderPath)
        End If

        Dim filePath As String = System.IO.Path.Combine(folderPath, "Receipt_" & transactionID.ToString("D5") & ".pdf")

        Try
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(filePath, System.IO.FileMode.Create))
            doc.Open()

            Dim fontHeader As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12)
            Dim fontBody As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9)
            Dim fontBold As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 9)

            Dim headerFormat As New iTextSharp.text.Paragraph("S&G Hair and Beauty Salon", fontHeader)
            headerFormat.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(headerFormat)

            Dim cashierName As String = GetActiveEmployeeName()

            Dim subHeader As New iTextSharp.text.Paragraph("123 Beauty Ave, Manila" & vbCrLf &
                                           "Date: " & DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") & vbCrLf &
                                           "Receipt #: " & transactionID.ToString("D5") & vbCrLf &
                                           "Cashier: " & cashierName, fontBody)
            subHeader.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(subHeader)

            doc.Add(New iTextSharp.text.Paragraph("----------------------------------------------------------------", fontBody))

            Dim itemTable As New iTextSharp.text.pdf.PdfPTable(2)
            itemTable.WidthPercentage = 100
            itemTable.SetWidths(New Single() {3.0F, 1.2F})

            For Each row As DataGridViewRow In dgvCart.Rows
                If Not row.IsNewRow Then
                    Dim itemName As String = row.Cells("colItem").Value.ToString()
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("colPrice").Value)
                    Dim stylist As String = row.Cells("colStylist").Value.ToString()

                    Dim cellName As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(itemName, fontBody))
                    cellName.Border = 0

                    Dim cellPrice As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(price.ToString("N2"), fontBody))
                    cellPrice.Border = 0
                    cellPrice.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT

                    itemTable.AddCell(cellName)
                    itemTable.AddCell(cellPrice)

                    If stylist <> "N/A" AndAlso stylist.Trim() <> "" Then
                        Dim cellSty As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("   Serviced by: " & stylist, fontBody))
                        cellSty.Border = 0
                        cellSty.Colspan = 2
                        itemTable.AddCell(cellSty)
                    End If
                End If
            Next

            doc.Add(itemTable)
            doc.Add(New iTextSharp.text.Paragraph("----------------------------------------------------------------", fontBody))

            Dim totalTable As New iTextSharp.text.pdf.PdfPTable(2)
            totalTable.WidthPercentage = 100
            totalTable.SetWidths(New Single() {2.5F, 1.0F})

            AddTotalRow(totalTable, "Subtotal:", lblSubtotal.Text.Replace("Subtotal: ₱", ""), fontBody)
            AddTotalRow(totalTable, "Discount:", lblDiscount.Text.Replace("Discount: ₱", ""), fontBody)

            If Label2.Visible Then
                AddTotalRow(totalTable, "VAT (12%):", Label2.Text.Replace("VAT (12%): ₱", ""), fontBody)
            End If

            doc.Add(totalTable)
            doc.Add(New iTextSharp.text.Paragraph(" ", fontBody))

            Dim grandTotalTable As New iTextSharp.text.pdf.PdfPTable(2)
            grandTotalTable.WidthPercentage = 100
            grandTotalTable.SetWidths(New Single() {2.5F, 1.0F})

            Dim cellGTName As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("GRAND TOTAL:", fontBold))
            cellGTName.Border = 0

            Dim cellGTVal As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(lblTotal.Text.Replace("₱", "").Trim(), fontBold))
            cellGTVal.Border = 0
            cellGTVal.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT

            grandTotalTable.AddCell(cellGTName)
            grandTotalTable.AddCell(cellGTVal)

            doc.Add(grandTotalTable)

            doc.Add(New iTextSharp.text.Paragraph("----------------------------------------------------------------", fontBody))
            Dim footer As New iTextSharp.text.Paragraph("Thank you for your visit!" & vbCrLf & "Please come again.", fontBody)
            footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(footer)

            doc.Close()

            Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Error generating receipt: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddTotalRow(table As iTextSharp.text.pdf.PdfPTable, label As String, value As String, useFont As iTextSharp.text.Font)
        Dim cellLabel As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(label, useFont))
        cellLabel.Border = 0
        cellLabel.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT

        Dim cellValue As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(value, useFont))
        cellValue.Border = 0
        cellValue.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT

        table.AddCell(cellLabel)
        table.AddCell(cellValue)
    End Sub

    Private Function GetActiveEmployeeName() As String
        Dim fullName As String = SessionManager.CurrentUsername
        Try
            Dim query As String = "SELECT FirstName, LastName FROM tblEmployees WHERE UserID = @uid"
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("@uid", SessionManager.CurrentUserID)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        fullName = reader("FirstName").ToString() & " " & reader("LastName").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return fullName
    End Function
End Class