'Imports System.Data.OleDb
'Imports System.IO

'Module SessionManager
'    Public conn As New OleDbConnection()
'    Public CurrentUsername As String = ""
'    Public CurrentUserRole As String = ""
'    Public CurrentUserID As Integer = 0

'    'Public Sub InitializeDatabasePath()
'    '    Dim finalDbPath As String = "C:\SalonSystem\database\salon_database.accdb"
'    '    Dim projectRoot As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\"))

'    '    finalDbPath = Path.Combine(projectRoot, "database", "salon_database.accdb")

'    '    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & finalDbPath & ";"

'    '    conn.ConnectionString = connString
'    'End Sub


'    Public Sub InitializeDatabasePath()
'        Dim finalDbPath As String = "C:\SalonSystem\database\salon_database.accdb"

'        ' Check if the file actually exists at that location to prevent "File Not Found" errors
'        If Not System.IO.File.Exists(finalDbPath) Then
'            MsgBox("Database Error: The file was not found at " & finalDbPath, MsgBoxStyle.Critical)
'            Exit Sub
'        End If

'        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & finalDbPath & ";"

'        conn.ConnectionString = connString
'    End Sub

'    Public Sub OpenConnection()
'        If conn.State = ConnectionState.Closed Then
'            conn.Open()
'        End If
'    End Sub

'    Public Sub CloseConnection()
'        If conn.State = ConnectionState.Open Then
'            conn.Close()
'        End If
'    End Sub
'End Module
Imports System.Data.OleDb
Imports System.IO

Module Module1
    Public conn As New OleDbConnection()
    Public CurrentUsername As String = ""
    Public CurrentUserRole As String = ""
    Public CurrentUserID As Integer = 0

    Public Sub InitializeDatabasePath()
        Dim dbPath As String = ""
        Dim possiblePaths As String() = {
            "C:\SalonSystem\database\salon_database.accdb",
            Path.Combine(Application.StartupPath, "database", "salon_database.accdb"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "salon_database.accdb")
        }

        For Each path In possiblePaths
            If File.Exists(path) Then
                dbPath = "C:\SalonSystem\database\salon_database.accdb"
                Exit For
            End If
        Next

        If String.IsNullOrEmpty(dbPath) Then
            MessageBox.Show("Database file not found! Please ensure salon_database.accdb exists in C:\SalonSystem\database\ or the application folder.",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPath & ";"
        conn.ConnectionString = connString
    End Sub

    Public Sub OpenConnection()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Database Connection Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CloseConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
End Module
