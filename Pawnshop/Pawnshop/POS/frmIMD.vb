Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.Windows.Forms.ListView
Public Class frmIMD


    Private Sub frmIMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadActive()
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
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripButton3.Click

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


            Dim ID As String = dsIMD.Tables(0).Columns.Item(0).ColumnName

            For i As Integer = 0 To dsIMD.Tables(0).Rows.Count - 1
                Dim listRow As New ListViewItem
                listRow.Text = dsIMD.Tables(0).Rows(i)(0).ToString()
                For j As Integer = 1 To dsIMD.Tables(0).Columns.Count - 1
                    listRow.SubItems.Add(dsIMD.Tables(0).Rows(i)(j).ToString())
                Next
                lvIMD.Items.Add(listRow)
            Next


            Dim iCount As Integer
            Dim iLoop As Integer
            Dim cmd As New OdbcCommand
            Dim cmd1 As New OdbcCommand
            Dim lvitem

            cmd.Connection = New OdbcConnection("DRIVER=Firebird/InterBase(r) driver;User=" & fbUser1 & ";Password=" & fbPass1 & ";Database=" & dbName1 & ";")
            cmd.Connection.Open()
            'cmd1.Connection = New OdbcConnection("DRIVER=Firebird/InterBase(r) driver;User=" & fbUser1 & ";Password=" & fbPass1 & ";Database=" & dbName1 & ";")
            ' cmd1.Connection.Open()
            iCount = lvIMD.Items.Count
            ' For iLoop = 0 To lvLogs.Items.Count - 1
            If Not lvIMD.Items.Count = 1 Then
                Do Until iLoop = lvIMD.Items.Count
                    lvitem = lvIMD.Items.Item(iLoop)
                    With lvitem
                        Dim mySql As String = "SELECT * FROM  TBL_ITEMMASTERDATA  WHERE "
                        mySql &= String.Format("ITEMCODE ='{0}' OR DESCRIPTION = '{1}'", lvitem.subitems(0).text, lvitem.subitems(1).text)

                        'Dim ds As DataSet = LoadSQL(mySql, "TBL_ITEMMASTERDATA")
                        'If ds.Tables("TBL_ITEMMASTERDATA").Rows.Count <> 0 Then

                        '    cmd1.CommandText = "UPDATE TBL_ITEMMASTERDATA SET ITEMCODE = '" & lvitem.subitems(0).text & "', DESCRIPTION = '" & lvitem.subitems(1).text & "'," _
                        '& "UNITOFMEASURE = '" & lvitem.subitems(2).text & "', PRICE = '" & lvitem.subitems(3).text & "',ONHOLDYN='" & lvitem.subitems(4).text & "'," _
                        '& "INVENTORIABLE='" & lvitem.subitems(5).text & "',SALABLE='" & lvitem.subitems(6).text & "',HASSERIAL='" & lvitem.subitems(0).text & "'" _
                        '& " WHERE DESCRIPTION = '" & lvitem.subitems(1).text & "'"
                        '    cmd1.ExecuteNonQuery()
                        'Else
                        cmd.CommandText = "insert into TBL_ITEMMASTERDATA (ITEMCODE, DESCRIPTION, UNITOFMEASURE, PRICE, ONHOLDYN,INVENTORIABLE,SALABLE,HASSERIAL) values " _
                        & "('" & lvitem.subitems(0).text & "','" & lvitem.subitems(1).text & "','" & lvitem.subitems(2).Text & "','" & lvitem.subitems(3).Text & "','" & lvitem.subitems(4).Text & "','" & lvitem.subitems(5).Text & "','" & lvitem.subitems(6).Text & "','" & lvitem.subitems(7).Text & "')"
                        cmd.ExecuteNonQuery()
                        'End If
                    End With
                    iLoop = iLoop + 1
                    lvitem = Nothing
                Loop
                MsgBox("done")
            End If


            CloseExcel(ItemMasterData)
            Console.WriteLine("Database Records: " & ID)
            Console.WriteLine("Database Records: " & dsIMD.Tables(0).Rows.Count)
        Else
            MsgBox("Contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If

        'LoadActive()
    End Sub

    Private Sub AddItem(ByVal tmpIMD As ItemMaterData)
        Dim lv As ListViewItem = lvIMD.Items.Add(tmpIMD.IMDID)
        lv.SubItems.Add(tmpIMD.ITEMCODE)
        lv.SubItems.Add(tmpIMD.DESCRIPTION)
        lv.SubItems.Add(tmpIMD.UnitofMeasure)
        lv.SubItems.Add(tmpIMD.PRICE)
        lv.SubItems.Add(tmpIMD.ONHOLDYN)
        lv.SubItems.Add(tmpIMD.INVENTORIALBE)
        lv.SubItems.Add(tmpIMD.SALABLE)
        lv.SubItems.Add(tmpIMD.HASSERIAL)
        lv.Tag = tmpIMD.IMDID

    End Sub

    Friend Sub LoadActive(Optional ByVal mySql As String = "SELECT * FROM TBL_ITEMMASTERDATA")
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        'lvMasterData.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpIMD As New ItemMaterData
            tmpIMD.LoadIMDAllRow(dr)

            AddItem(tmpIMD)
        Next
    End Sub

  

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton1.Click
        frmAddProduct.ShowDialog()
    End Sub

   

    Private Sub DisabledTextfield()
        frmAddProduct.txtItemCode.Enabled = False
        frmAddProduct.txtDescription.Enabled = False
        frmAddProduct.txtUnitofMeasure.Enabled = False
        frmAddProduct.txtPrice.Enabled = False
        frmAddProduct.txtOnHold.Enabled = False
        frmAddProduct.txtInventoriable.Enabled = False
        frmAddProduct.txtSalable.Enabled = False
        frmAddProduct.txtHasSerial.Enabled = False
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripButton4.Click

        ''If lvMasterData.SelectedItems.Count <= 0 Then Exit Sub
        'frmAddProduct.lblTitle.Text = "Updating Item"

        '' Dim id As Integer = lvMasterData.FocusedItem.Tag
        'Dim tmpLoadIMD As New ItemMaterData
        'tmpLoadIMD.LoadIMD(id)
        'frmAddProduct.txtIMDID.Text = id
        'frmAddProduct.Show()
        'frmAddProduct.LoadIMDTransaction(tmpLoadIMD)

        'DisabledTextfield()

    End Sub


    Private Sub ofdOpen_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpen.FileOk
        lblPath.Text = ofdOpen.FileName
    End Sub

    Private Sub lvMasterData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  If lvMasterData.SelectedItems.Count = 0 Then Exit Sub

        ' Dim id As Integer = lvMasterData.FocusedItem.Tag
        Dim tmpLoadIMD As New ItemMaterData
        ' tmpLoadIMD.LoadIMD(id)
        'frmAddProduct.txtIMDID.Text = id
        frmAddProduct.Show()
        frmAddProduct.LoadIMDTransaction(tmpLoadIMD)
        DisabledTextfield()
    End Sub

    Private Sub txtSearchtoolStrip_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchtoolStrip.KeyDown
        If e.KeyCode = Keys.Enter Then SearchToolStripButton2.PerformClick()
    End Sub

    Private Sub SearchToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripButton2.Click
        If txtSearchtoolStrip.Text = "" Then Exit Sub
        lvIMD.MultiSelect = False
        lvIMD.FullRowSelect = True

        Dim checkInt As Integer = FindItem(lvIMD, txtSearchtoolStrip.Text)
        If checkInt <> -1 Then
            lvIMD.Items(checkInt).Selected = True
            lvIMD.Focus()
            lvIMD.SelectedItems(0).EnsureVisible()
        Else
            MsgBox("Data not Found", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub lvIMD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIMD.SelectedIndexChanged

    End Sub
End Class