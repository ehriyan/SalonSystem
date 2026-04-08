Imports System.Data.OleDb
Imports System.IO

Module Module1
    Public conn As New OleDbConnection()
    Public CurrentUsername As String = ""
    Public CurrentUserRole As String = ""

    Public Sub InitializeDatabasePath()
        Dim finalDbPath As String = ""
        Dim projectRoot As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\"))

        finalDbPath = Path.Combine(projectRoot, "database", "salon_database.accdb")

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & finalDbPath & ";"

        conn.ConnectionString = connString
    End Sub

    Public Sub OpenConnection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
End Module
