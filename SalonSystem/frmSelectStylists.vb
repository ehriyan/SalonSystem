Public Class frmSelectStylists

    Public SelectedStylistNames As String = ""

    Private Sub frmSelectStylists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flpStylists.Controls.Clear()

        Dim staffList As String() = {"Stylist 1", "Stylist 2", "Stylist 3", "Stylist 4"}

        For Each staffName In staffList
            Dim chk As New CheckBox()
            chk.Text = staffName
            chk.Name = staffName

            chk.Appearance = Appearance.Button
            chk.TextAlign = ContentAlignment.MiddleCenter

            chk.Size = New Size(flpStylists.Width - 25, 50)
            chk.Margin = New Padding(5, 5, 5, 5)

            chk.FlatStyle = FlatStyle.Flat
            chk.FlatAppearance.BorderSize = 1
            chk.FlatAppearance.BorderColor = Color.SlateGray
            chk.BackColor = Color.WhiteSmoke
            chk.ForeColor = Color.SlateGray
            chk.Font = New Font("DM Sans", 12, FontStyle.Regular)
            chk.Cursor = Cursors.Hand

            AddHandler chk.CheckedChanged, AddressOf StylistToggle_CheckedChanged

            flpStylists.Controls.Add(chk)
        Next
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
        Dim names As New List(Of String)

        For Each ctrl As Control In flpStylists.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked Then
                    names.Add(chk.Text)
                End If
            End If
        Next

        If names.Count = 0 Then
            MessageBox.Show("Select at least one stylist.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        SelectedStylistNames = String.Join(", ", names)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class