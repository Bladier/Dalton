Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class frmAddProduct

    Private IMD As ItemMaterData
    Dim fillData As String = "TBL_ITEMMASTERDATA"
    Private isNew As Boolean = True
    Private lockFRM As Boolean = False

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is GroupBox Then
                For Each ct In ctrl.Controls
                    If TypeOf ct Is TextBox Then
                        If ct.Text = "" Then
                            ErrorProvider.SetError(ct, "Please Fill all Fields")
                            Exit Sub
                        End If
                    End If

                Next
            End If

        Next

        If btnSave.Text = "&Modify" Then
            isNew = False
            LockFields(False)
            Exit Sub
        End If

        EnabledTextField()

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else

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
                    .SaveItemMaster()

                End With

                MsgBox("Transaction Saved", MsgBoxStyle.Information)
                ClearTextField()
        End If
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

    Private Function isValid() As Boolean

        If txtItemCode.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtItemCode.Focus() : Return False
        If txtDescription.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtDescription.Focus() : Return False
        If txtUnitofMeasure.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtUnitofMeasure.Focus() : Return False
        If txtPrice.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtPrice.Focus() : Return False
        If txtOnHold.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtOnHold.Focus() : Return False
        If txtInventoriable.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtInventoriable.Focus() : Return False
        If txtSalable.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtSalable.Focus() : Return False
        If txtHasSerial.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtHasSerial.Focus() : Return False
        Return True

    End Function

    Private Sub frmAddProduct_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ClearTextField()
        btnSave.Enabled = True
        btnUpdate.Enabled = True
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

    Private Sub LockFields(ByVal st As Boolean)
        lockFRM = st

        Console.WriteLine(txtItemCode.BackColor)
        txtItemCode.ReadOnly = st
        txtDescription.ReadOnly = st
        txtUnitofMeasure.ReadOnly = st
        txtPrice.ReadOnly = st

        txtOnHold.ReadOnly = st
        txtInventoriable.ReadOnly = st
        txtSalable.ReadOnly = st
        txtHasSerial.ReadOnly = st
        GroupBox1.Enabled = Not st

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
        frmIMD.Show()
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If btnUpdate.Text = "&Edit" Then
            btnUpdate.Text = "&Update"
            LockFields(False)
            txtItemCode.ReadOnly = True
            EnabledTextField()
            Exit Sub
        End If

        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then
            MsgBox("Abort", MsgBoxStyle.Critical)
            ClearTextField()
            btnSave.Enabled = True
            Exit Sub

        Else
            IMD = New ItemMaterData
            With IMD
                .ITEMCODE = Trim(txtItemCode.Text)
                .DESCRIPTION = Trim(txtDescription.Text)
                .UnitofMeasure = Trim(txtUnitofMeasure.Text)
                .PRICE = Trim(txtPrice.Text)
                .ONHOLDYN = Trim(txtOnHold.Text)
                .INVENTORIALBE = Trim(txtInventoriable.Text)
                .SALABLE = Trim(txtSalable.Text)
                .HASSERIAL = Trim(txtHasSerial.Text)
                .UpdateIMD()
            End With

            MsgBox("Item Successfully Updated", MsgBoxStyle.Information)
            ClearTextField()
        End If
        txtItemCode.ReadOnly = False
        btnSave.Enabled = True
    End Sub

 
    Private Sub txtOnHold_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOnHold.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "YNyn"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtInventoriable_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInventoriable.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "YNyn"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSalable_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalable.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "YNyn"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtHasSerial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHasSerial.KeyPress
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

    Private Sub ErrorProvidertextfield()
        If txtItemCode.Text = "" Then
            ErrorProvider.SetError(txtItemCode, "Textbox must be filled up.")
            txtItemCode.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtItemCode, "")
        End If

        If txtDescription.Text = "" Then
            ErrorProvider.SetError(txtDescription, "Textbox must be filled up.")
            txtDescription.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtDescription, "")
        End If

        If txtUnitofMeasure.Text = "" Then
            ErrorProvider.SetError(txtUnitofMeasure, "Textbox must be filled up.")
            txtUnitofMeasure.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtUnitofMeasure, "")
        End If

        If txtPrice.Text = "" Then
            ErrorProvider.SetError(txtPrice, "Textbox must be filled up.")
            txtPrice.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtPrice, "")
        End If

        If txtOnHold.Text = "" Then
            ErrorProvider.SetError(txtOnHold, "Textbox must be filled up.")
            txtOnHold.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtOnHold, "")
        End If

        If txtInventoriable.Text = "" Then
            ErrorProvider.SetError(txtInventoriable, "Textbox must be filled up.")
            txtInventoriable.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtInventoriable, "")

        End If

        If txtSalable.Text = "" Then
            ErrorProvider.SetError(txtSalable, "Textbox must be filled up.")
            txtSalable.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtSalable, "")
        End If

        If txtHasSerial.Text = "" Then
            ErrorProvider.SetError(txtHasSerial, "Textbox must be filled up.")
            txtHasSerial.Focus()
            Exit Sub
        Else
            ErrorProvider.SetError(txtHasSerial, "")
        End If
    End Sub
End Class