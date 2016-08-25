Imports System.Data.Odbc
Module Conn
    Public sqlreader As OdbcDataReader
    Public sqlcmd As OdbcCommand 
    Public sqladapter As OdbcDataAdapter

    Public connect As New OdbcConnection
    Friend dbName1 As String = "W3W1LH4CKU.FDB" 'Final
    Friend fbUser1 As String = "SYSDBA"
    Friend fbPass1 As String = "masterkey"

    Public Sub Connection()
        Try
            connect = New OdbcConnection
            connect.ConnectionString = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser1 & ";Password=" & fbPass1 & ";Database=" & dbName1 & ";"
            connect.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub ConnectDatabase()
    '    Dim connect As New OdbcConnection("DRIVER=Firebird/InterBase(r) driver;User=" & fbUser1 & ";Password=" & fbPass1 & ";Database=" & dbName1 & ";")
    '    Dim mycommand As New OdbcCommand
    '    Try
    '        connect.Open()
    '        MessageBox.Show("Connected")
    '        With mycommand
    '            .CommandText = "Select * from TBL_ITEMMASTERDATA"
    '            '.ExecuteNonQuery()
    '        End With
    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        connect.Dispose()

    '    End Try
    'End Sub
End Module
