Imports Microsoft.Office.Interop
Public Class frmAddProduct
    Const MASTERDATA As String = "\Template\Template-IMD.xlsx"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        Dim lastRow As Long

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & MASTERDATA)
        xlWorksheet = xlWorkBook.Worksheets(1)
        'xlApp.Visible = True

        lastRow = xlWorksheet.Range("A" & xlApp.Rows.CountLarge).End(Excel.XlDirection.xlUp).Row + 1
        MsgBox(lastRow)
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