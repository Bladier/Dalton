Imports Microsoft.Office.Interop
Public Class frmIMD
    Const MASTERDATA As String = "\Template\Template-IMD.xlsx"

    Private Sub frmIMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Function FindItem(ByVal LV As ListView, ByVal TextToFind As String) As Integer

        For i As Integer = 0 To LV.Items.Count - 1
            If Trim(LV.Items(i).Text) = Trim(TextToFind) Then
                Return (i)
            End If
            For subitem As Integer = 0 To LV.Items(i).SubItems.Count - 1
                If Trim(LV.Items(i).SubItems(subitem).Text) = Trim(TextToFind) Then
                    Return (i)
                End If
            Next
        Next
        ' If not found, then return -1.
        Return -1
    End Function

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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If lvIMD.Items.Count = 0 Then

            Dim ItemMasterData As Excel.Application
            Dim MaxEntries As Integer

            ItemMasterData = OpenExcel(Application.StartupPath & MASTERDATA)
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
            MsgBox("Listview contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If txtSearchtoolStrip.Text = "" Then Exit Sub
        lvIMD.MultiSelect = False
        lvIMD.FullRowSelect = True

        Dim checkInt As Integer = FindItem(lvIMD, txtSearchtoolStrip.Text)
        If checkInt <> -1 Then
            lvIMD.Items(checkInt).Selected = True
            lvIMD.Focus()
            lvIMD.SelectedItems(0).EnsureVisible()
        Else
            MsgBox("Search string not found", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmAddProduct.ShowDialog()
    End Sub
End Class