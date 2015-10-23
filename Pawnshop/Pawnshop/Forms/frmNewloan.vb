Public Class frmNewloan

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKarat.SelectedIndexChanged

    End Sub
    Private Sub Expiry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Expiry.ValueChanged

    End Sub

    Private Sub Category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemtype.SelectedIndexChanged
        cboCategory.Items.Clear()
        cboCategory.Text = ""
        'Enable Grams and Karat
        If cboItemtype.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGrams.ReadOnly = True
            cboKarat.Enabled = False
        End If
        'Sub Category
        If cboItemtype.SelectedItem = "APP" Then
            cboCategory.Items.Add("CAMERA")
            cboCategory.Items.Add("CARPENTRY TOOLS")
            cboCategory.Items.Add("HOME APP-SMALL")
            cboCategory.Items.Add("LAPTOP")
            cboCategory.Items.Add("NOTEBOOK")

        ElseIf cboItemtype.SelectedItem = "BIG" Then
            cboCategory.Items.Add("BIKE")
            cboCategory.Items.Add("HOME APP-BIG")
            cboCategory.Items.Add("MOTORCYCLE")

        ElseIf cboItemtype.SelectedItem = "CEL" Then
            cboCategory.Items.Add("CELLPHONE")
            cboCategory.Items.Add("TABLET")

        ElseIf cboItemtype.SelectedItem = "JWL" Then
            cboCategory.Items.Add("ANKLET")
            cboCategory.Items.Add("BANGLE")
            cboCategory.Items.Add("BRACELET")
            cboCategory.Items.Add("BROUCH")
            cboCategory.Items.Add("EARRINGS")
            cboCategory.Items.Add("NECKLACE")
            cboCategory.Items.Add("PENDANT")
            cboCategory.Items.Add("RING")
        End If
        'Dates
        LoanDate.Value = Date.Now
        Maturity.Value = Date.Now.AddDays(30)
        If cboItemtype.SelectedItem = "CEL" Then
            Expiry.Value = Date.Now.AddDays(30)
            Auction.Value = Date.Now.AddDays(60)
        Else
            Expiry.Value = Date.Now.AddDays(90)
            Auction.Value = Date.Now.AddDays(123)
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.Show()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLoanlist.Show()
    End Sub

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Private Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub txtDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.KeyPress
        If isEnter(e) Then
            cboItemtype.Focus()
        End If
    End Sub

    Private Sub Category_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        If cboItemtype.SelectedItem = "JWL" Then
            cboCategory.Focus()
        Else
            txtAppraisal.Focus()
        End If
    End Sub

    Private Sub Maturity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maturity.ValueChanged

    End Sub

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtGrams_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrams.TextChanged

    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNet.Text = txtAppraisal.Text
        'txtPrincipal.Text = txtAppraisal.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLess.Click
        lblLess.Visible = True
        txtless.Visible = True
        txtless.ReadOnly = False
        btnLess.Enabled = False
        lblTranstype.Text = "LESS PRINCIPAL"
    End Sub

    Private Sub txtless_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtless.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub frmNewloan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
    End Sub
End Class

