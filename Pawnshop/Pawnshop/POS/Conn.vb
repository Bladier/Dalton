Imports System.Data.Odbc
Imports Microsoft.Office.Interop
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

    Public Function tbl_IMD() As DataTable
        Dim tbl As New DataTable("ITEMMASTERDATA")
        With tbl.Columns
            .Add("ItemCode")
            .Add("Description")
            .Add("UnitOfMeasure")
            .Add("Price")
            .Add("onHold(Y/N)")
            .Add("isInv")
            .Add("isSale")
            .Add("HasSerial")
        End With

        Return tbl
    End Function

    Public Function OpenExcel(ByVal src As String) As Excel.Application
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook

        oWB = oXL.Workbooks.Open(src)

        Return oXL
    End Function

    Public Sub CloseExcel(ByVal OpenExcel As Excel.Application)
        OpenExcel.Quit()
        OpenExcel = Nothing

        ReleaseObject(OpenExcel)
    End Sub

    Public Sub ReleaseObject(ByVal obj As Object)
        Try
            Dim intRel As Integer = 0
            Do
                intRel = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            Loop While intRel > 0
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Module
