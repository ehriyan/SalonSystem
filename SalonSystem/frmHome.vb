Imports System.Data.OleDb
Imports Microsoft.Web.WebView2.Core

Public Class frmHome

    Private Async Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await wvDashboard.EnsureCoreWebView2Async(Nothing)
    End Sub

    Private Sub wvDashboard_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles wvDashboard.CoreWebView2InitializationCompleted
        If e.IsSuccess Then
            LoadModernDashboard()
        Else
            MessageBox.Show("Dashboard failed to load: " & e.InitializationException.Message, "WebView2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LoadModernDashboard()

        Dim todayRevenue As Decimal = 0
        Dim todayCustomers As Integer = 0
        Dim topStylist As String = "No data yet"

        Dim chartDataList As New List(Of String)()
        Dim chartLabelsList As New List(Of String)()

        Try
            SessionManager.OpenConnection()
            Dim today As DateTime = DateTime.Today

            Dim qryToday As String = "SELECT SUM([GrandTotal]), COUNT([TransactionID]) FROM tblTransactions " &
                                     "WHERE [TransactionDate] >= @start AND [TransactionDate] <= @end"
            Using cmd As New OleDbCommand(qryToday, SessionManager.conn)
                cmd.Parameters.Add("@start", OleDbType.Date).Value = today
                cmd.Parameters.Add("@end", OleDbType.Date).Value = today.AddDays(1).AddSeconds(-1)

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not IsDBNull(reader(0)) Then todayRevenue = Convert.ToDecimal(reader(0))
                        If Not IsDBNull(reader(1)) Then todayCustomers = Convert.ToInt32(reader(1))
                    End If
                End Using
            End Using


            Dim qryStylist As String = "SELECT TOP 1 (e.FirstName & ' ' & e.LastName) AS StylistName " &
                                       "FROM tblPayroll p INNER JOIN tblEmployees e ON p.EmployeeID = e.EmployeeID " &
                                       "ORDER BY p.TotalSales DESC"
            Using cmd As New OleDbCommand(qryStylist, SessionManager.conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    topStylist = result.ToString()
                End If
            End Using


            For i As Integer = 6 To 0 Step -1
                Dim targetDate As DateTime = today.AddDays(-i)

                chartLabelsList.Add("'" & targetDate.ToString("ddd") & "'")

                Dim qryChart As String = "SELECT SUM([GrandTotal]) FROM tblTransactions " &
                                         "WHERE [TransactionDate] >= @start AND [TransactionDate] <= @end"
                Using cmd As New OleDbCommand(qryChart, SessionManager.conn)
                    cmd.Parameters.Add("@start", OleDbType.Date).Value = targetDate
                    cmd.Parameters.Add("@end", OleDbType.Date).Value = targetDate.AddDays(1).AddSeconds(-1)

                    Dim revResult = cmd.ExecuteScalar()
                    If revResult IsNot Nothing AndAlso Not IsDBNull(revResult) Then
                        chartDataList.Add(Convert.ToDecimal(revResult).ToString("0.00"))
                    Else
                        chartDataList.Add("0")
                    End If
                End Using
            Next

            Dim htmlFilePath As String = System.IO.Path.Combine(Application.StartupPath, "UI", "DashboardLayout.html")

            If System.IO.File.Exists(htmlFilePath) Then
                Dim rawHtml As String = System.IO.File.ReadAllText(htmlFilePath)

                Dim finalHtml As String = rawHtml.Replace("[TODAY_REVENUE]", "₱" & todayRevenue.ToString("N2"))
                finalHtml = finalHtml.Replace("[TODAY_CUSTOMERS]", todayCustomers.ToString())
                finalHtml = finalHtml.Replace("[TOP_STYLIST]", topStylist)

                finalHtml = finalHtml.Replace("[CHART_DATA]", String.Join(",", chartDataList))
                finalHtml = finalHtml.Replace("[CHART_LABELS]", String.Join(",", chartLabelsList))

                wvDashboard.NavigateToString(finalHtml)
            Else
                MessageBox.Show("Could not find the DashboardLayout.html file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading real data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SessionManager.CloseConnection()
        End Try
    End Sub

End Class