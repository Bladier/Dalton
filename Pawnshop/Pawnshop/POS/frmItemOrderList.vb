

Public Class FrmItemOrderList

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim index As Integer

    Dim Price As Double, Quantity As Integer
    Dim rowNum1 As Integer

    Const vat As Double = 1.12

    Friend Sub LoadIMDTransaction(ByVal tmpIMD As ItemMaterData)
        With tmpIMD
            txtItemCode.Text = .ITEMCODE
            txtDescription.Text = .DESCRIPTION
            txtPrice.Text = .PRICE
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddCart.Click
        If txtQuantity.Value = 0 Or txtDescription.Text = "" Or txtItemCode.Text = "" Or txtPrice.Text = "" Then Exit Sub

        For Each row As DataGridViewRow In DGItemOrderList.Rows

            If row.Cells(0).Value.ToString().Equals(txtItemCode.Text) Then
                DGItemOrderList.MultiSelect = False

                MsgBox("Item ALready Added in the Order List", MsgBoxStyle.Information)
                DGItemOrderList.Rows(row.Index).DefaultCellStyle.BackColor = Color.Red
                Exit Sub
            Else
                DGItemOrderList.Rows(row.Index).DefaultCellStyle.BackColor = Color.White
            End If
        Next

        Dim rowNum As Integer = DGItemOrderList.Rows.Add()
        DGItemOrderList.Rows.Item(rowNum).Cells(0).Value = txtItemCode.Text
        DGItemOrderList.Rows.Item(rowNum).Cells(1).Value = txtDescription.Text
        DGItemOrderList.Rows.Item(rowNum).Cells(2).Value = txtPrice.Text
        DGItemOrderList.Rows.Item(rowNum).Cells(3).Value = txtQuantity.Text
        DGItemOrderList.Rows.Item(rowNum).Cells(4).Value = txtQuantity.Text * txtPrice.Text

        CaLcUlateTotalPrice()
        clearTextField()
        txtSearch1.Focus()
    End Sub

    Private Sub CaLcUlateTotalPrice()

        Dim sum As Double = 0
        For i As Integer = 0 To DGItemOrderList.Rows.Count - 1
            sum += Convert.ToDouble(DGItemOrderList.Rows(i).Cells(4).Value)
        Next

        txtTotalPrice.Text = sum.ToString
        'txtTotalPrice.Text = Format(Double.Parse(sum.ToString), "###,###,##0.00")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch1.Text
        secured_str = DreadKnight(secured_str)

        frmIMD.NewToolStripButton1.Visible = False
        frmIMD.UpdateToolStripButton4.Visible = False

        frmIMD.SearchSelect(secured_str, FormName.frmItemOrderList)
        frmIMD.StartPosition = FormStartPosition.CenterScreen
        frmIMD.Show()

        frmIMD.txtSearchtoolStrip.Text = Me.txtSearch1.Text.ToString
        frmIMD.SearchToolStripButton2.PerformClick()

        frmIMD.txtSearchtoolStrip.Focus()
        frmIMD.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
    End Sub

    Private Sub txtSearch1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch1.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub FrmItemOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRemove.Enabled = False
        btnUpdate.Enabled = False
        txtSearch1.Focus()
        clearTextField()
    End Sub

    Private Sub clearTextField()
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtPrice.Text = ""
        txtQuantity.Value = 1

        txtTINNo.Text = ""
        txtCustomerName.Text = ""
        txtAddress.Text = ""
    End Sub


    Private Sub pbHeader_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseUp
        drag = False
    End Sub

    Private Sub pbHeader_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub pbHeader_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub UserFieldSelected() Handles txtSearch1.GotFocus
        With txtSearch1
            .Text = ""
            .ForeColor = System.Drawing.SystemColors.WindowText
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
    End Sub


    Private Sub UserField() Handles txtCustomerCash.GotFocus
        With txtCustomerCash
            .Text = ""
            .ForeColor = System.Drawing.SystemColors.WindowText
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
    End Sub

    Private Sub txtSearch1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch1.TextChanged
        txtSearch1.ForeColor = Color.Red
    End Sub

  

    Private Sub DGItemOrderList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGItemOrderList.CellClick

        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = DGItemOrderList.Rows(index)
        txtItemCode.Text = selectedrow.Cells(0).Value.ToString
        txtDescription.Text = selectedrow.Cells(1).Value.ToString
        txtPrice.Text = selectedrow.Cells(2).Value.ToString
        txtQuantity.Text = selectedrow.Cells(3).Value.ToString
        btnUpdate.Enabled = True
        btnRemove.Enabled = True
        btnaddCart.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtQuantity.Value = 0 Or txtDescription.Text = "" Or txtItemCode.Text = "" Or txtPrice.Text = "" Then Exit Sub

        For Each row As DataGridViewRow In DGItemOrderList.Rows

            Dim result As String = MsgBox("Do you want to Update Order?", MsgBoxStyle.YesNo)

            If result = DialogResult.Yes Then

                Dim newDataRow As DataGridViewRow
                newDataRow = DGItemOrderList.Rows(index)
                newDataRow.Cells(0).Value = txtItemCode.Text
                newDataRow.Cells(1).Value = txtDescription.Text
                newDataRow.Cells(2).Value = txtPrice.Text
                newDataRow.Cells(3).Value = txtQuantity.Text
                newDataRow.Cells(4).Value = txtPrice.Text * txtQuantity.Text

                If Double.TryParse(DGItemOrderList.Rows(rowNum1).Cells(2).Value.ToString(), Price) _
                 AndAlso Integer.TryParse(DGItemOrderList.Rows(rowNum1).Cells(3).Value.ToString(), Quantity) Then

                    Dim SubTotal As Double = Price * Quantity
                    DGItemOrderList.Rows(rowNum1).Cells(4).Value = CDbl(SubTotal.ToString())

                    DGItemOrderList.Rows(row.Index).DefaultCellStyle.BackColor = Color.White

                    CaLcUlateTotalPrice()
                    btnUpdate.Enabled = False
                    btnaddCart.Enabled = True
                    clearTextField()
                    Exit Sub
                End If

            Else

                clearTextField()
                DGItemOrderList.Rows(row.Index).DefaultCellStyle.BackColor = Color.White
                btnUpdate.Enabled = False
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnaddCart.PerformClick()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each row As DataGridViewRow In DGItemOrderList.SelectedRows
            DGItemOrderList.Rows.Remove(row)
            CaLcUlateTotalPrice()
            ComputeAmountDue()
            clearTextField()
        Next
        btnRemove.Enabled = False
        btnaddCart.Enabled = True
    End Sub


    Private Sub txtCustomerCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCash.TextChanged
        If DGItemOrderList.RowCount.ToString <= 0 Then Exit Sub

        If txtCustomerCash.Text = "0.00" Then Exit Sub
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        frmPOSMain.Show()
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click

        If DGItemOrderList.RowCount.ToString <= 0 Then Exit Sub
        If txtTINNo.Text = "" Or txtCustomerName.Text = "" Or txtAddress.Text = "" Then Exit Sub

        ComputeAmountDue()


      
        frmReciept.Show()
    End Sub

    Private Sub ComputeAmountDue()
        Dim VatSales As Double = Val(txtTotalPrice.Text) / vat

        Dim change As Double = Val(txtCustomerCash.Text.ToString) - Val(txtTotalPrice.Text.ToString)
        'txtChange.Text = change ' Double.Parse(change, 2)

        txtChange.Text = Format(Double.Parse(change), "###,###,##0.00")
    End Sub

    Private Sub txtCustomerCash_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomerCash.KeyPress
        If isEnter(e) Then btnEnter.PerformClick()
        DigitOnly(e)
    End Sub

   
    Private Sub txtTINNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTINNo.KeyPress
        DigitOnly(e)
    End Sub
End Class
