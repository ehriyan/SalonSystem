Imports System.Data.OleDb
Imports FontAwesome.Sharp

Public Class frmSelectStylists

    Public SelectedStylistNames As String = ""
    Public SelectedStylistIDs As New List(Of Integer)
    Public SelectedStylistNamesList As New List(Of String)

    Private Sub frmSelectStylists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flpStylists.Controls.Clear()

        Try
            OpenConnection()

            Dim query As String = "SELECT EmployeeID, FirstName, LastName FROM tblEmployees WHERE IsActive = True AND isStylist = True"
            Dim cmd As New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim staffID As Integer = Convert.ToInt32(reader("EmployeeID"))
                Dim staffName As String = reader("FirstName").ToString() & " " & reader("LastName").ToString()

                Dim chk As New CheckBox()
                chk.AutoSize = False
                chk.Text = "   " & staffName
                chk.Tag = staffID
                chk.Name = staffName

                chk.Appearance = Appearance.Button
                chk.TextAlign = ContentAlignment.MiddleCenter
                chk.TextImageRelation = TextImageRelation.ImageBeforeText
                'chk.Image = iconInactive

                chk.Size = New Size(flpStylists.Width - 20, 60)
                chk.Margin = New Padding(5, 5, 5, 10)

                chk.FlatStyle = FlatStyle.Flat
                chk.FlatAppearance.BorderSize = 1
                chk.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220)
                chk.BackColor = Color.White
                chk.ForeColor = Color.FromArgb(64, 64, 64)
                chk.Font = New Font("DM Sans", 12, FontStyle.Regular)
                chk.Cursor = Cursors.Hand

                AddHandler chk.CheckedChanged, AddressOf StylistToggle_CheckedChanged

                flpStylists.Controls.Add(chk)
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading stylists: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub StylistToggle_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk As CheckBox = CType(sender, CheckBox)

        If chk.Checked Then
            chk.BackColor = Color.SlateGray
            chk.ForeColor = Color.White
        Else
            chk.BackColor = Color.WhiteSmoke
            chk.ForeColor = Color.SlateGray
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        SelectedStylistIDs.Clear()
        SelectedStylistNamesList.Clear()

        For Each ctrl As Control In flpStylists.Controls
            Dim chk As CheckBox = TryCast(ctrl, CheckBox)
            If chk IsNot Nothing AndAlso chk.Checked Then
                SelectedStylistIDs.Add(Convert.ToInt32(chk.Tag))
                SelectedStylistNamesList.Add(chk.Text.Trim())
            End If
        Next

        If SelectedStylistIDs.Count = 0 Then
            MessageBox.Show("Select at least one stylist.")
            Exit Sub
        End If

        SelectedStylistNames = String.Join(", ", SelectedStylistNamesList)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class