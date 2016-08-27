Public Class FrmItemOrderList

    Friend Sub LoadIMDTransaction(ByVal tmpIMD As ItemMaterData)

        With tmpIMD
            txtItemCode.Text = .ITEMCODE
            txtDescription.Text = .DESCRIPTION
            txtPrice.Text = .PRICE
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddCart.Click
        If txtQuantity.Text = "" Then Exit Sub

        Dim List1 As ListViewItem
        List1 = Me.lvItemOrderList.Items.Add(Me.txtItemCode.Text)
        List1.SubItems.Add(Me.txtDescription.Text)
        List1.SubItems.Add(Me.txtPrice.Text)
        List1.SubItems.Add(Me.txtQuantity.Text)
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch1.Text
        secured_str = DreadKnight(secured_str)
        frmIMD.SearchSelect(secured_str, FormName.frmItemOrderList)
        frmIMD.Show()
        frmIMD.txtSearchtoolStrip.Text = Me.txtSearch1.Text.ToString
        frmIMD.SearchToolStripButton2.PerformClick()
    End Sub

    Private Sub txtSearch1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch1.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class