Imports Microsoft.Office.Interop
Public Class frmAddProduct
    Const MASTERDATA As String = "\Template\Template-IMD.xlsx"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        Dim lastRow As Long
        'Dim MaxEntries As Integer

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & MASTERDATA)
        xlWorksheet = xlWorkBook.Worksheets(1)
        'xlApp.Visible = True

        'xlApp = OpenExcel(Application.StartupPath & MASTERDATA)
        'Dim dsIMD As New DataSet
        'dsIMD.Tables.Add(tbl_IMD)

        'Dim imdSheet As Excel.Worksheet
        'Dim imdBook As Excel.Workbook
        'Dim dsNewRow As DataRow
        'imdBook = xlApp.Workbooks(1)
        'imdSheet = imdBook.Worksheets(1)

        'With imdSheet
        '    MaxEntries = .Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
        'End With

        'Console.WriteLine("MaxEntries : " & MaxEntries)

        'For rowIdx As Integer = 2 To MaxEntries
        '    dsNewRow = dsIMD.Tables(0).NewRow
        '    With dsNewRow
        '        .Item("ItemCode") = Trim(imdSheet.Cells(rowIdx, 1).value)
        '        .Item("Description") = Trim(imdSheet.Cells(rowIdx, 2).value)
        '        .Item("UnitOfMeasure") = Trim(imdSheet.Cells(rowIdx, 3).value)
        '        .Item("Price") = Trim(imdSheet.Cells(rowIdx, 4).value)
        '        .Item("onHold(Y/N)") = Trim(imdSheet.Cells(rowIdx, 5).value)
        '        .Item("isInv") = Trim(imdSheet.Cells(rowIdx, 6).value)
        '        .Item("isSale") = Trim(imdSheet.Cells(rowIdx, 7).value)
        '        .Item("HasSerial") = Trim(imdSheet.Cells(rowIdx, 8).value)
        '    End With
        '    dsIMD.Tables(0).Rows.Add(dsNewRow)
        'Next

        'Dim valueToSearch As String = txtDescription.Text
        'For Each dTable As DataTable In dsIMD.Tables
        '    For Each dRow As DataRow In dTable.Rows
        '        For index As Integer = 0 To dTable.Columns.Count - 1
        '            Convert.ToString(dRow(index)).Contains(valueToSearch)
        '            If index = valueToSearch.ToString Then
        '                MsgBox("sdf")
        '            End If
        '        Next
        '    Next
        'Next


        lastRow = xlWorksheet.Range("A" & xlApp.Rows.CountLarge).End(Excel.XlDirection.xlUp).Row + 1

        With xlWorksheet
            .Range("A" & lastRow).Value = Me.txtItemCode.Text
            .Range("B" & lastRow).Value = Me.txtDescription.Text
            .Range("C" & lastRow).Value = Me.txtUnitofMeasure.Text
            .Range("D" & lastRow).Value = Me.txtPrice.Text
            .Range("E" & lastRow).Value = Me.cmbOnhold.Text
            .Range("F" & lastRow).Value = Me.cmbIsSalable.Text
            .Range("G" & lastRow).Value = Me.cmbIsSalable.Text
            .Range("H" & lastRow).Value = Me.cmbHasSerial.Text
        End With

        xlWorkBook.Save()
        xlWorkBook.Close()

        releaseObject(xlWorkBook)
        releaseObject(xlWorksheet)
        xlApp.Quit()
        releaseObject(xlApp)
    End Sub

    Private Function tbl_IMD() As DataTable
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

    Private Function OpenExcel(ByVal src As String) As Excel.Application
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook

        oWB = oXL.Workbooks.Open(src)

        Return oXL
    End Function

    Private Sub CloseExcel(ByVal OpenExcel As Excel.Application)
        OpenExcel.Quit()
        OpenExcel = Nothing

        ReleaseObject(OpenExcel)
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            Dim intRel As Integer = 0
            Do
                intRel = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            Loop While intRel > 0
            'MsgBox("Final Released obj # " & intRel)
        Catch ex As Exception
            'MsgBox("Error releasing object" & ex.ToString)
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class