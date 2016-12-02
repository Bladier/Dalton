﻿Public Class frmPLU

    Private qtyItm As Double = 1
    Private queued_IMD As New CollectionItemData

    Private fromSales As Boolean = True
    Private fromInventory As Boolean = False
    Private isRedeem As Boolean = False

    Friend Sub From_Sales()
        Me.fromSales = True
        Me.fromInventory = False

        txtCode.Select()
    End Sub

    Friend Sub From_Inventories()
        Me.fromSales = False
        Me.fromInventory = True

        txtCode.Select()
    End Sub

    Friend Sub isAuctionRedeem()
        Me.isRedeem = True
        txtCode.Select()
    End Sub

    Private Sub frmPLU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
    End Sub

    Friend Sub RefreshList(Optional ByVal ItemCode As String = "")
        If ItemCode = "" Then
            Load_PLU()
            Exit Sub
        End If

        Dim loadITEM As New cItemData
        loadITEM.Load_Item(ItemCode)
        Dim lv As ListViewItem = lvItem.FindItemWithText(ItemCode)
        lv.SubItems(1).Text = loadITEM.Description
        lv.SubItems(2).Text = loadITEM.Category
        lv.SubItems(3).Text = loadITEM.UnitOfMeasure
        lv.SubItems(4).Text = loadITEM.onHand
        If fromSales Then lv.SubItems(5).Text = ToCurrency(loadITEM.SalePrice)
        If fromInventory Then lv.SubItems(5).Text = ToCurrency(loadITEM.UnitPrice)
    End Sub

    Private Function ToCurrency(ByVal money As Double) As String
        Return money.ToString("#,##0.00")
    End Function

    Private Sub ClearFields()
        txtCode.Text = ""
        lvItem.Items.Clear()
    End Sub

#Region "ProgressBar"
    Private Sub PG_Init(ByVal st As Boolean, Optional ByVal max As Integer = 0)
        pb_itm.Visible = st
        pb_itm.Value = 0
        pb_itm.Maximum = max

        Me.Enabled = Not st
    End Sub

    Private Sub pgValue(ByVal val As Integer)
        pb_itm.Value = val
    End Sub
#End Region

    Friend Sub Load_PLU(Optional ByVal src As String = "")
        Dim quickLoader As Integer = 0
        Dim mySql As String
        Dim ds As DataSet

        If isRedeem Then
            mySql = "SELECT PT.*,ITEM.ITEMCLASS,CL.SALESID,CL.COSTID "
            mySql &= vbCrLf & "FROM OPT PT "
            mySql &= vbCrLf & "INNER JOIN OPI ITEM "
            mySql &= vbCrLf & "ON ITEM.PAWNITEMID = PT.PAWNITEMID "
            mySql &= vbCrLf & "INNER JOIN TBLITEM CL "
            mySql &= vbCrLf & "ON CL.ITEMID = ITEM.ITEMID "
            mySql &= vbCrLf & "WHERE PT.STATUS = 'S'"

            ds = LoadSQL("SELECT COUNT(*) FROM OPT WHERE STATUS = 'S'")
        Else
            mySql = "SELECT * FROM ITEMMASTER WHERE onHold = 0 AND ItemCode <> 'RECALL00' ORDER BY ITEMCODE ASC"
            ds = LoadSQL("SELECT COUNT(*) FROM ITEMMASTER WHERE onHold = 0 AND ItemCode <> 'RECALL00'")
        End If

        Dim MaxResult As Integer = ds.Tables(0).Rows(0).Item(0)
        If MaxResult = 0 Then Exit Sub

        If DEV_MODE Then Console.WriteLine("SQL: " & mySql)

        If Not txtCode.Text = "" Then Exit Sub
        dbReaderOpen()
        Dim dsR = LoadSQL_byDataReader(mySql)
        PG_Init(True, MaxResult)
        While dsR.Read

            Dim itmReader As New cItemData
            If isRedeem Then
                With itmReader
                    .ItemCode = "RECALL00"
                    .Load_ItemCode()

                    .Description = String.Format("PT#{0:000000} {1}", dsR("PAWNTICKET"), dsR("DESCRIPTION"))
                    .Category = dsR("ITEMCLASS")
                    .UnitofMeasure = "PIECE"
                    .UnitPrice = dsR("PRINCIPAL")
                    .SalePrice = dsR("PRINCIPAL")
                    .Tags = dsR("PAWNTICKET")
                    .AuctionID = dsR("SALESID")
                    .CostID = dsR("COSTID")
                End With
            Else
                itmReader.LoadReader_Item(dsR)
            End If
            queued_IMD.Add(itmReader)
            AddItem(itmReader)

            quickLoader += 1
            pgValue(quickLoader)
            If quickLoader Mod 10 = 0 Then Application.DoEvents()
        End While
        dbReaderClose()

        PG_Init(False)
    End Sub

    Friend Sub SearchSelect(ByVal unsecured_String As String)
        Dim qty As String = ""

        If Not unsecured_String.Contains("*") Then
            txtCode.Text = unsecured_String
        Else
            qty = unsecured_String.Split("*")(0)
            qtyItm = If(IsNumeric(qty), qty, 0)
            txtCode.Text = unsecured_String.Split("*")(1)
        End If

        btnSearch.PerformClick()
    End Sub

#Region "GUI"
    Private Sub AddItem(ByVal itm As cItemData)
        Dim lv As ListViewItem = lvItem.Items.Add(itm.ItemCode)
        If itm.onHold Then lv.BackColor = Color.Red : lv.ForeColor = Color.White : lv.ToolTipText = String.Format("{0} is ON HOLD", itm.ItemCode)

        lv.SubItems.Add(itm.Description)
        lv.SubItems.Add(itm.Category)
        lv.SubItems.Add(itm.UnitofMeasure)
        lv.SubItems.Add(IIf(isRedeem, 1, itm.onHand))
        lv.SubItems.Add(ToCurrency(itm.SalePrice))
    End Sub

    Private Sub ClearField()
        txtCode.Text = ""
        lvItem.Items.Clear()
    End Sub

    Private Sub AutoSelect()
        lvItem.Focus()
        If lvItem.Items.Count = 0 Then Exit Sub

        lvItem.Items(0).Selected = True
    End Sub
#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim unsec_src As String = txtCode.Text

        Load_PLU(DreadKnight(unsec_src))

        Exit Sub

        Dim mySql As String = "SELECT * FROM ITEMMASTER "
        mySql &= String.Format("WHERE (LOWER(ITEMCODE) LIKE '%{0}%' OR LOWER(DESCRIPTION) LIKE '%{0}%' OR LOWER(CATEGORIES) LIKE '%{0}%' OR LOWER(SUBCAT) LIKE '%{0}%' OR LOWER(BARCODE) LIKE '%{0}%') AND ItemCode <> 'RECALL00' ", DreadKnight(unsec_src).ToLower)

        If isRedeem Then
            Dim src_str As String
            src_str = DreadKnight(unsec_src)

            mySql = "SELECT PT.*,ITEM.SALESID,ITEM.COSTID,ITEM.ITEMCLASS "
            mySql &= vbCrLf & "FROM OPT PT "
            mySql &= vbCrLf & "INNER JOIN OPI ITEM "
            mySql &= vbCrLf & "ON ITEM.PAWNITEMID = PT.PAWNITEMID "
            mySql &= vbCrLf & "WHERE PT.STATUS = 'S' AND ("

            If IsNumeric(src_str) Then
                mySql &= String.Format("PT.PAWNTICKET = {0} OR ", DreadKnight(unsec_src).ToLower)
            End If
            mySql &= String.Format("LOWER(PT.DESCRIPTION) LIKE '%{0}%'", DreadKnight(unsec_src).ToLower)
            mySql &= ") AND ItemCode <> 'RECALL00'"
        End If

        Console.WriteLine(mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("ITEM NOT FOUND", MsgBoxStyle.Information) : Exit Sub

        ' Clear in Collections
        lvItem.Items.Clear()
        queued_IMD.Clear()

        dbReaderOpen()

        If DEV_MODE Then Console.WriteLine(mySql)
        Dim dsR = LoadSQL_byDataReader(mySql)
        While dsR.Read

            Dim tmpItm As New cItemData

            If isRedeem Then
                With tmpItm
                    .ItemCode = "RECALL00"
                    .Load_ItemCode()

                    .Description = String.Format("PT#{0:000000} {1}", dsR("PAWNTICKET"), dsR("DESCRIPTION"))
                    .Category = dsR("ITEMCLASS")
                    .UnitofMeasure = "PIECE"
                    .UnitPrice = dsR("PRINCIPAL")
                    .SalePrice = dsR("PRINCIPAL")
                    .Tags = dsR("PAWNTICKET")
                    .AuctionID = dsR("SALESID")
                    .CostID = dsR("COSTID")
                End With
            Else
                tmpItm.LoadReader_Item(dsR)
            End If

            queued_IMD.Add(tmpItm)
            AddItem(tmpItm)

        End While

        dbReaderClose()
        AutoSelect()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Console.WriteLine(lvItem.SelectedItems(0).Index)
        Dim idx As Integer = lvItem.SelectedItems(0).Index


        Dim selected_Itm As New cItemData
        selected_Itm = queued_IMD.Item(idx)
        If selected_Itm.onHold Then
            MsgBox("ITEM IS CURRENTLY ONHOLD", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If selected_Itm.SalePrice = 0 Or isRedeem Then
            Dim tmp As String = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
            While Not IsNumeric(tmp)
                tmp = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
                If tmp = "" Then Exit Sub
            End While
            
            Dim customPrice As Double = CDbl(tmp)
            selected_Itm.SalePrice = customPrice
        End If

        Dim UnitPrice As Double = 0
        If fromInventory Then
            UnitPrice = InputBox("Price: ", "Custom Unit Price", selected_Itm.UnitPrice)
        End If

        If fromSales Then
            If isRedeem Then qtyItm = 1
            selected_Itm.Quantity = qtyItm

            frmSales.AddItem(selected_Itm)
            frmSales.ClearSearch()
        Else
            ' Inventory IN
            'frmInventoryIn.AddItem(selected_Itm, qtyItm, UnitPrice)
            'frmInventoryIn.ClearSearch()
        End If
        
        Me.Close()
    End Sub

    Private Sub lvItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvItem.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then btnSearch.PerformClick()
    End Sub

    Private Sub txtCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.LostFocus
        AutoSelect()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As String = lvItem.FocusedItem.Index
        Dim selectedITM As New cItemData
        selectedITM = queued_IMD.Item(idx)

        frmIMD.Show()
        frmIMD.Load_ItemData(selectedITM)
    End Sub
End Class