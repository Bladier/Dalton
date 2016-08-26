Imports Microsoft.Office.Interop
Public Class ImportIMDFile

    Private Sub ImportIMDFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub ImportToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripButton3.Click
        If lvIMD.Items.Count = 0 Then
            ofdOpen.ShowDialog()
            Dim ItemMasterData As Excel.Application
            Dim MaxEntries As Integer

            ItemMasterData = OpenExcel(lblPath.Text)
            Dim dsIMD As New DataSet
            dsIMD.Tables.Add(tbl_IMD)

            Dim imdSheet As Excel.Worksheet
            Dim imdBook As Excel.Workbook
            Dim dsNewRow As DataRow
            imdBook = ItemMasterData.Workbooks(1)
            imdSheet = imdBook.Worksheets(1)

            With imdSheet
                MaxEntries = .Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
            End With

            Console.WriteLine("MaxEntries : " & MaxEntries)

            For rowIdx As Integer = 2 To MaxEntries
                dsNewRow = dsIMD.Tables(0).NewRow
                With dsNewRow
                    .Item("ItemCode") = Trim(imdSheet.Cells(rowIdx, 1).value)
                    .Item("Description") = Trim(imdSheet.Cells(rowIdx, 2).value)
                    .Item("UnitOfMeasure") = Trim(imdSheet.Cells(rowIdx, 3).value)
                    .Item("Price") = Trim(imdSheet.Cells(rowIdx, 4).value)
                    .Item("onHold(Y/N)") = Trim(imdSheet.Cells(rowIdx, 5).value)
                    .Item("isInv") = Trim(imdSheet.Cells(rowIdx, 6).value)
                    .Item("isSale") = Trim(imdSheet.Cells(rowIdx, 7).value)
                    .Item("HasSerial") = Trim(imdSheet.Cells(rowIdx, 8).value)
                End With
                dsIMD.Tables(0).Rows.Add(dsNewRow)
            Next

            Console.WriteLine("Database Records: " & dsIMD.Tables(0).Rows.Count)

            For i As Integer = 0 To dsIMD.Tables(0).Rows.Count - 1
                Dim listRow As New ListViewItem
                listRow.Text = dsIMD.Tables(0).Rows(i)(0).ToString()
                For j As Integer = 1 To dsIMD.Tables(0).Columns.Count - 1
                    listRow.SubItems.Add(dsIMD.Tables(0).Rows(i)(j).ToString())
                Next
                lvIMD.Items.Add(listRow)
            Next


            CloseExcel(ItemMasterData)
            Console.WriteLine("Database Records: " & dsIMD.Tables(0).Rows.Count)
        Else
            MsgBox("Contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If
    End Sub

    Private Sub ofdOpen_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpen.FileOk
        lblPath.Text = ofdOpen.FileName
    End Sub

    Private Sub CancelToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripButton1.Click
        Me.Hide()
        frmMain.Show()
    End Sub
End Class