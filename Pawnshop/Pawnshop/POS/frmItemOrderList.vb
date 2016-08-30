Imports System.Windows.Forms.ListView
Public Class FrmItemOrderList
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
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
        If isEnter(e) Then
            btnaddCart.PerformClick()
            clearTextField()
        End If
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
        Me.Hide()
    End Sub

    Private Sub txtSearch1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch1.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub


    Private Sub txtTotalPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPrice.TextChanged

    End Sub

    Private Sub lvItemOrderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItemOrderList.SelectedIndexChanged
        Dim dblTotal As Integer = 0
        Dim dblTotal1 As Integer = 0
        Dim dblTemp As Integer

        For Each lvItem As ListViewItem In lvItemOrderList.Items
            If Integer.TryParse(lvItem.SubItems(2).Text, dblTemp) Then
                dblTotal = dblTemp
            End If
            If Integer.TryParse(lvItem.SubItems(3).Text, dblTemp) Then
                dblTotal1 = dblTemp
            End If
        Next

        txtTotalPrice.Text = dblTotal * dblTotal1
        
    End Sub

    Private Sub FrmItemOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch1.Focus()
        clearTextField()
    End Sub

    Private Sub clearTextField()
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtPrice.Text = ""
        txtQuantity.Text = ""
        txtTotalPrice.Text = ""
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

    Private Sub txtSearch1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch1.TextChanged
        txtSearch1.ForeColor = Color.Red
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
        frmPOSMain.Show()
    End Sub
End Class