Imports System.IO
Imports Microsoft.Web.WebView2.Core

Public Class frmLogin_2

    Private Async Sub frmLogin_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await WebView21.EnsureCoreWebView2Async(Nothing)

        Dim htmlPath As String = Path.Combine(Application.StartupPath, "UI", "login.html")

        If File.Exists(htmlPath) Then
            WebView21.CoreWebView2.Navigate(htmlPath)
        Else
            MessageBox.Show("Could not find the HTML UI file at: " & htmlPath, "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived

        Dim incomingData As String = e.TryGetWebMessageAsString().Trim(""""c)

        Dim credentials() As String = incomingData.Split("|"c)

        If credentials.Length = 2 Then
            Dim attemptedUsername As String = credentials(0)
            Dim attemptedPassword As String = credentials(1)

            If attemptedUsername = "admin" And attemptedPassword = "password" Then
                Dim mainScreen As New frmPOS()
                mainScreen.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        End If

    End Sub

End Class