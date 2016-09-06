Imports Microsoft.Office.Interop
Imports System.IO
Public Class ImportSTO
    Private DSSTO As New DataSet
    Private DateTime1 As DateTime = System.DateTime.Now




    Private Sub SaveToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton2.Click
        If lvIMD.Items.Count = 0 Then Exit Sub
        SFD.ShowDialog()


        Using objWriter As New StreamWriter(SFD.FileName)
            objWriter.Write(lvIMD.Items(1).SubItems(4).Text)
            objWriter.Write("  ;  ")
            objWriter.Write(DateTime1)
        End Using

        Dim iCount As Integer
        Dim iLoop As Integer
        iCount = lvIMD.Items.Count
        Dim lvitem
        If Not lvIMD.Items.Count = 1 Then
            Do Until iLoop = lvIMD.Items.Count
                lvitem = lvIMD.Items.Item(iLoop)
                With lvitem
                    SaveSTO(lvitem.subitems(0).text, lvitem.subitems(1).text, lvitem.subitems(2).Text, _
                         lvitem.subitems(3).Text, lvitem.subitems(4).Text, lvitem.SUBITEMS(5).TEXT)
                End With

                iLoop = iLoop + 1
                lvitem = Nothing
            Loop
            MsgBox("Successfully Saved", MsgBoxStyle.Information)
            lvIMD.Items.Clear()
        End If

    End Sub
   
    Private Sub ImportToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripButton3.Click

        ofdOpen.ShowDialog()

        If lvIMD.Items.Count = 0 Then
            lOADEXCEL(lblPath.Text)
        Else
            MsgBox("Contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If

        ItemCountToolStripStatusLabel1.Text = "Item Count " & lvIMD.Items.Count
    End Sub

    Private Sub CloseToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton1.Click
        Me.Hide()
        frmPOSMain.Show()
    End Sub

    Private Sub ofdOpen_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpen.FileOk
        lblPath.Text = ofdOpen.FileName
    End Sub

    Friend Sub lOADEXCEL(ByVal SRC As String)

        Dim ItemMasterData As Excel.Application
        Dim MaxEntries As Integer
        If lblPath.Text = "Path" Then Exit Sub
        ItemMasterData = OpenExcel(lblPath.Text)
        DSSTO.Tables.Add(tbl_STO)

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
            dsNewRow = DSSTO.Tables(0).NewRow
            With dsNewRow
                .Item("ItemCode") = Trim(imdSheet.Cells(rowIdx, 1).value)
                .Item("Description") = Trim(imdSheet.Cells(rowIdx, 2).value)
                .Item("Quantity") = Trim(imdSheet.Cells(rowIdx, 3).value)
                .Item("WhsCode") = Trim(imdSheet.Cells(rowIdx, 4).value)
                .Item("STONo") = Trim(imdSheet.Cells(rowIdx, 5).value)
                .Item("STODate") = Trim(imdSheet.Cells(rowIdx, 6).value)
            End With
            DSSTO.Tables(0).Rows.Add(dsNewRow)
        Next

        Console.WriteLine("Database Records: " & DSSTO.Tables(0).Rows.Count)

        For i As Integer = 0 To DSSTO.Tables(0).Rows.Count - 1
            Dim listRow As New ListViewItem
            listRow.Text = DSSTO.Tables(0).Rows(i)(0).ToString()
            For j As Integer = 1 To DSSTO.Tables(0).Columns.Count - 1
                listRow.SubItems.Add(DSSTO.Tables(0).Rows(i)(j).ToString())
            Next
            lvIMD.Items.Add(listRow)

        Next
        CloseExcel(ItemMasterData)
        Console.WriteLine("Database Records: " & DSSTO.Tables(0).Rows.Count)
        DSSTO.Tables.Clear()
    End Sub

    Private Sub ImportSTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvIMD.Columns(3).Width = 0
        lvIMD.Columns(4).Width = 0
        lvIMD.Columns(5).Width = 0

    End Sub

    Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD.FileOk

    End Sub

  
    
    
  
    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub
End Class