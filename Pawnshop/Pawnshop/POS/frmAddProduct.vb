Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class frmAddProduct

    Private IMD As ItemMaterData
    Dim fillData As String = "TBL_ITEMMASTERDATA"


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "&Modify" Then
            btnSave.Text = "&Save"
            EnabledTextField()
            txtItemCode.Enabled = False
            Exit Sub
        End If

        If Not isValid(txtItemCode) Then Exit Sub
        If Not isValid(txtDescription) Then Exit Sub
        If Not isValid(txtUnitofMeasure) Then Exit Sub
        If Not isValid(txtPrice) Then Exit Sub
        If Not isValid(txtOnHold) Then Exit Sub
        If Not isValid(txtInventoriable) Then Exit Sub
        If Not isValid(txtSalable) Then Exit Sub
        If Not isValid(txtHasSerial) Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            'If Not isValid() Then Exit Sub
           
            IMD = New ItemMaterData
            With IMD
                .ITEMCODE = txtItemCode.Text
                .DESCRIPTION = txtDescription.Text
                .UnitofMeasure = txtUnitofMeasure.Text
                .PRICE = txtPrice.Text
                .ONHOLDYN = txtOnHold.Text
                .INVENTORIALBE = txtInventoriable.Text
                .SALABLE = txtSalable.Text
                .HASSERIAL = txtHasSerial.Text
                .SaveUpdateItemMaster()

            End With

            ClearTextField()
        End If
        EnabledTextField()
        frmIMD.LoadActive()
    End Sub

    Private Sub loadIMDRow()

        Dim mySql As String, ds As DataSet
        mySql = "SELECT FIRST 50 * FROM " & fillData
        mySql &= String.Format(" WHERE ITEMCODE = '{0}'", txtItemCode.Text)
        ds = LoadSQL(mySql, fillData)

        For Each dr As DataRow In ds.Tables(fillData).Rows
            txtDescription.Text = dr("DESCRIPTION")
            txtUnitofMeasure.Text = dr("UNITOFMEASURE")
            txtPrice.Text = dr("PRICE")
            txtOnHold.Text = dr("ONHOLDYN")
            txtInventoriable.Text = dr("INVENTORIABLE")
            txtSalable.Text = dr("SALABLE")
            txtHasSerial.Text = dr("HASSERIAL")
        Next

    End Sub

    Private Function isValid(ByVal tmpTextbox As TextBox)

        Dim tmpFill As String = "Please Fill the Fields"
        If tmpTextbox.Text = "" Then
            ErrorProvider.SetError(tmpTextbox, tmpFill)
            tmpTextbox.Focus()
            Return False
        Else
            ErrorProvider.SetError(tmpTextbox, String.Empty)
        End If
        Return True

    End Function

    Private Sub frmAddProduct_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ClearTextField()
        btnSave.Enabled = True
    End Sub

    Private Sub EnabledTextField()

        txtItemCode.Enabled = True
        txtDescription.Enabled = True
        txtUnitofMeasure.Enabled = True
        txtPrice.Enabled = True
        txtOnHold.Enabled = True
        txtInventoriable.Enabled = True
        txtSalable.Enabled = True
        txtHasSerial.Enabled = True

    End Sub

    Private Sub ClearTextField()

        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtUnitofMeasure.Text = ""
        txtPrice.Text = ""
        txtOnHold.Text = Nothing
        txtInventoriable.Text = Nothing
        txtSalable.Text = Nothing
        txtHasSerial.Text = Nothing
        lblTitle.Text = "Register New Item"

    End Sub

    Private Sub DisabledTextfield()
        txtItemCode.Enabled = False
        txtDescription.Enabled = False
        txtUnitofMeasure.Enabled = False
        txtPrice.Enabled = False
        txtOnHold.Enabled = False
        txtInventoriable.Enabled = False
        txtSalable.Enabled = False
        txtHasSerial.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmPOSMain.Show()
    End Sub

    Friend Sub LoadIMDTransaction(ByVal tmpIMD As ItemMaterData)

        With tmpIMD
            txtItemCode.Text = .ITEMCODE
            txtDescription.Text = .DESCRIPTION
            txtUnitofMeasure.Text = .UnitofMeasure
            txtPrice.Text = .PRICE
            txtOnHold.Text = .ONHOLDYN
            txtInventoriable.Text = .INVENTORIALBE
            txtSalable.Text = .SALABLE
            txtHasSerial.Text = .HASSERIAL
        End With
        'LockFields(True)
        txtItemCode.Enabled = False

    End Sub

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            ClearTextField()
        Else
            loadIMDRow()
        End If
    End Sub

    Private Sub txtOnHold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOnHold.KeyPress, txtInventoriable.KeyPress,
        txtSalable.KeyPress, txtHasSerial.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "YNyn"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        DigitOnly(e)
    End Sub

End Class