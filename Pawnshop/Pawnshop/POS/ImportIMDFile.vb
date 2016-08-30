Imports Microsoft.Office.Interop

Public Class ImportIMDFile

    Dim filldata As String = "TBL_ITEMMASTERDATA"
    Private DSIMD As New DataSet

    Private Sub ImportIMDFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Sub ImportToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripButton3.Click

        ofdOpen.ShowDialog()
        If lvIMD.Items.Count = 0 Then
            lOADEXCEL(lblPath.Text)
        Else
            MsgBox("Contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If

        ItemCountToolStripStatusLabel1.Text = "Item Count " & lvIMD.Items.Count

    End Sub

    Friend Sub lOADEXCEL(ByVal SRC As String)
        Dim ItemMasterData As Excel.Application
        Dim MaxEntries As Integer

        ItemMasterData = OpenExcel(lblPath.Text)
        DSIMD.Tables.Add(tbl_IMD)

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
            dsNewRow = DSIMD.Tables(0).NewRow
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
            DSIMD.Tables(0).Rows.Add(dsNewRow)
        Next

        Console.WriteLine("Database Records: " & DSIMD.Tables(0).Rows.Count)

        For i As Integer = 0 To DSIMD.Tables(0).Rows.Count - 1
            Dim listRow As New ListViewItem
            listRow.Text = DSIMD.Tables(0).Rows(i)(0).ToString()
            For j As Integer = 1 To DSIMD.Tables(0).Columns.Count - 1
                listRow.SubItems.Add(DSIMD.Tables(0).Rows(i)(j).ToString())
            Next
            lvIMD.Items.Add(listRow)
        Next

        CloseExcel(ItemMasterData)
        Console.WriteLine("Database Records: " & DSIMD.Tables(0).Rows.Count)

    End Sub

    Private Sub ofdOpen_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpen.FileOk
        lblPath.Text = ofdOpen.FileName
    End Sub

    Private Sub CloseToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton1.Click
        Me.Hide()
        frmPOSMain.Show()
    End Sub

    Private Sub SaveItemMaster(ByVal itemcode As String, ByVal description As String, ByVal UnitOfMeasure As String, ByVal Price As String,
                               ByVal OnHold As String, ByVal IsINV As String, ByVal IsSale As String, ByVal HasSerial As String)


        Try
            Dim mySql As String = "SELECT * FROM " & filldata & " WHERE ITEMCODE = '" & itemcode & "'"
            Dim ds As DataSet
            ds = LoadSQL(mySql, filldata)

            If ds.Tables(0).Rows.Count >= 1 Then
                With ds.Tables(0).Rows(0)
                    .Item("DESCRIPTION") = description
                    .Item("UNITOFMEASURE") = UnitOfMeasure
                    .Item("PRICE") = Price
                    .Item("ONHOLDYN") = OnHold
                    .Item("INVENTORIABLE") = IsINV
                    .Item("SALABLE") = IsSale
                    .Item("HASSERIAL") = HasSerial
                End With
                database.SaveEntry(ds, False)
            Else
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(filldata).NewRow
                With dsNewRow
                    .Item("ITEMCODE") = itemcode
                    .Item("DESCRIPTION") = description
                    .Item("UNITOFMEASURE") = UnitOfMeasure
                    .Item("PRICE") = Price
                    .Item("ONHOLDYN") = OnHold
                    .Item("INVENTORIABLE") = IsINV
                    .Item("SALABLE") = IsSale
                    .Item("HASSERIAL") = HasSerial
                End With
                ds.Tables(filldata).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton2.Click
        Dim iCount As Integer
        Dim iLoop As Integer
        iCount = lvIMD.Items.Count
        Dim lvitem
        If Not lvIMD.Items.Count = 1 Then
            Do Until iLoop = lvIMD.Items.Count
                lvitem = lvIMD.Items.Item(iLoop)
                With lvitem
                    SaveItemMaster(lvitem.subitems(0).text, lvitem.subitems(1).text, lvitem.subitems(2).Text, _
                                   lvitem.subitems(3).Text, lvitem.subitems(4).Text, lvitem.subitems(5).Text, _
                                   lvitem.subitems(6).Text, lvitem.subitems(7).Text)
                End With
                iLoop = iLoop + 1
                lvitem = Nothing
            Loop
            MsgBox("Successfully Saved", MsgBoxStyle.Information)
        End If

    End Sub

   
End Class