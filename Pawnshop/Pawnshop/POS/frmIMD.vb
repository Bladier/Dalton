Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.Windows.Forms.ListView
Public Class frmIMD

    Public adding As Boolean
    Public updating As Boolean

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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click


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
            Dim lvitem

            cmd.Connection = New OdbcConnection("DRIVER=Firebird/InterBase(r) driver;User=" & fbUser1 & ";Password=" & fbPass1 & ";Database=" & dbName1 & ";")
            cmd.Connection.Open()
            iCount = lvIMD.Items.Count
            ' For iLoop = 0 To lvLogs.Items.Count - 1
            If Not lvIMD.Items.Count = 1 Then
                Do Until iLoop = lvIMD.Items.Count
                    lvitem = lvIMD.Items.Item(iLoop)
                    With lvitem
                        cmd.CommandText = "insert into TBL_ITEMMASTERDATA (ITEMCODE, DESCRIPTION, UNITOFMEASURE, PRICE, ONHOLDYN,INVENTORIABLE,SALABLE,HASSERIAL) values " _
                        & "('" & lvitem.subitems(0).text & "','" & lvitem.subitems(1).text & "','" & lvitem.subitems(2).Text & "','" & lvitem.subitems(3).Text & "','" & lvitem.subitems(4).Text & "','" & lvitem.subitems(5).Text & "','" & lvitem.subitems(6).Text & "','" & lvitem.subitems(7).Text & "')"
                        cmd.ExecuteNonQuery()
                    End With
                    iLoop = iLoop + 1
                    lvitem = Nothing
                Loop
                MsgBox("done")
            End If


            CloseExcel(ItemMasterData)

            Console.WriteLine("Database Records: " & dsIMD.Tables(0).Rows.Count)
        Else
            MsgBox("Contains " & lvIMD.Items.Count & " items")
            Exit Sub
        End If

        LoadActive()
    End Sub

    Private Sub LoadActive()
        lvIMD.Items.Clear()
        Dim mySql As String = "SELECT * FROM TBL_ITEMMASTERDATA"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each IMD As DataRow In ds.Tables(0).Rows
            AddItem(IMD)
        Next
    End Sub

    Private Sub AddItem(ByVal IMD As DataRow)
        Dim tmpIMD As New ItemMaterData
        tmpIMD.LoadIMDbyRow(IMD)

        Dim lv As ListViewItem = lvMasterData.Items.Add(tmpIMD.IMDID)
        lv.SubItems.Add(tmpIMD.ITEMCODE)
        lv.SubItems.Add(tmpIMD.DESCRIPTION)
        lv.SubItems.Add(tmpIMD.UnitofMeasure)
        lv.SubItems.Add(tmpIMD.PRICE)
        lv.SubItems.Add(tmpIMD.ONHOLDYN)
        lv.SubItems.Add(tmpIMD.INVENTORIALBE)
        lv.SubItems.Add(tmpIMD.SALABLE)
        lv.SubItems.Add(tmpIMD.HASSERIAL)
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
            MsgBox("Data not Found", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmAddProduct.ShowDialog()
    End Sub



    Friend Sub ViewItem()

        With Me.lvIMD
            For i As Integer = 0 To .SelectedItems.Count - 1
                Dim myString As String = lvIMD.Items(i).SubItems(0).Text
                Dim myString1 As String = lvIMD.Items(i).SubItems(1).Text
                Dim myString2 As String = lvIMD.Items(i).SubItems(2).Text
                Dim myString3 As String = lvIMD.Items(i).SubItems(3).Text
                Dim myString4 As String = lvIMD.Items(i).SubItems(4).Text
                Dim myString5 As String = lvIMD.Items(i).SubItems(5).Text
                Dim myString6 As String = lvIMD.Items(i).SubItems(6).Text
                Dim myString7 As String = lvIMD.Items(i).SubItems(7).Text

                frmAddProduct.txtItemCode.Text = myString
                frmAddProduct.txtDescription.Text = myString1
                frmAddProduct.txtUnitofMeasure.Text = myString2
                frmAddProduct.txtPrice.Text = myString3
                frmAddProduct.cmbOnhold.Text = myString4
                frmAddProduct.cmbInInven.Text = myString5
                frmAddProduct.cmbIsSalable.Text = myString6
                frmAddProduct.cmbHasSerial.Text = myString7

            Next i
        End With
        DisabledTextfield()

        frmAddProduct.ShowDialog()

    End Sub
    Friend Sub DisabledTextfield()
        frmAddProduct.txtItemCode.Enabled = False
        frmAddProduct.txtDescription.Enabled = False
        frmAddProduct.txtUnitofMeasure.Enabled = False
        frmAddProduct.txtPrice.Enabled = False
        frmAddProduct.cmbOnhold.Enabled = False
        frmAddProduct.cmbInInven.Enabled = False
        frmAddProduct.cmbIsSalable.Enabled = False
        frmAddProduct.cmbHasSerial.Enabled = False
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmAddProduct.lblTitle.Text = "Updating Item"
        'If lvIMD.Items.Count = 0 Then
        '    MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
        '    Exit Sub
        'End If

        'Try
        '    If lvIMD.FocusedItem.Text = "" Then

        '    Else
        '        adding = False
        '        updating = True
        '        ViewItem()
        frmAddProduct.ShowDialog()
        '    End If

        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub ofdOpen_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdOpen.FileOk
        lblPath.Text = ofdOpen.FileName
    End Sub

End Class