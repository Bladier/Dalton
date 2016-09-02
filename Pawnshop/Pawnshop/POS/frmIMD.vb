Public Class frmIMD

    Dim fromOtherForm As Boolean = False
    Friend GetIMD As ItemMaterData
    Dim frmOriginal As formSwitch.FormName

    Private Sub frmIMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadActive()
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

    Friend Sub LoadActive(Optional ByVal mySql As String = "SELECT FIRST 50 * FROM TBL_ITEMMASTERDATA")
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvIMD.Items.Clear()
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

    Private Sub txtSearchtoolStrip_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchtoolStrip.KeyDown
        If e.KeyCode = Keys.Enter Then SearchToolStripButton2.PerformClick()
    End Sub

    Private Sub SearchToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripButton2.Click

        If txtSearchtoolStrip.Text = "Search" Then Exit Sub
        If txtSearchtoolStrip.Text = "" Then Exit Sub
        SearchIMD()
        txtSearchtoolStrip.Focus()
    End Sub

    Private Sub SearchIMD()
        Dim mysql As String
        mysql = "SELECT * FROM TBL_ITEMMASTERDATA WHERE ITEMCODE LIKE '%" & txtSearchtoolStrip.Text & "%'"
        mysql &= vbCr & "OR UPPER(DESCRIPTION) LIKE UPPER('%" & txtSearchtoolStrip.Text & "%') "

        Console.WriteLine("SQL: " & mysql)
        Dim ds As DataSet = LoadSQL(mysql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        If MaxRow <= 0 Then
            MsgBox("Item not found", MsgBoxStyle.Critical)
            lvIMD.Items.Clear()
            Exit Sub
        End If

        lvIMD.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpIMD As New ItemMaterData
            tmpIMD.LoadIMDAllRow(dr)

            AddItem(tmpIMD)
        Next

        MsgBox(MaxRow & " Result found", MsgBoxStyle.Information, "Search Item")
        If lvIMD.Items.Count > 0 Then
            lvIMD.Focus()
            lvIMD.Items(0).Selected = True
            lvIMD.Items(0).EnsureVisible()
        End If
    End Sub
    Private Sub lvIMD_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIMD.DoubleClick

        'DisabledTextfield()
        Dim id As Integer = lvIMD.FocusedItem.Tag
        Dim tmpLoadIMD As New ItemMaterData
        tmpLoadIMD.LoadIMD(id)

        FrmItemOrderList.Show()
        FrmItemOrderList.LoadIMDTransaction(tmpLoadIMD)
        FrmItemOrderList.txtQuantity.Focus()

    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True

        txtSearchtoolStrip.Text = src
        frmOriginal = frmOrigin
    End Sub

    Private Sub UpdateToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripButton4.Click
        If lvIMD.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = lvIMD.FocusedItem.Tag
        Dim tmpLoadIMD As New ItemMaterData
        tmpLoadIMD.LoadIMD(id)

        frmAddProduct.ShowDialog()
        frmAddProduct.LoadIMDTransaction(tmpLoadIMD)
        frmAddProduct.lblTitle.Text = "Updating Item"

        DisabledTextfield()
        frmAddProduct.btnSave.Text = "&Modify"
    End Sub

    Private Sub CloseToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton1.Click
        Me.Hide()
        frmPOSMain.Show()
    End Sub

End Class