Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class frmAddProduct

    Private IMD As ItemMaterData
    Dim fillData As String = "TBL_ITEMMASTERDATA"

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Not isValid() Then Exit Sub
        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Dim mySql As String = "SELECT * FROM " & fillData & " WHERE "
            mySql &= String.Format("ITEMCODE ='{0}' OR DESCRIPTION LIKE '%{1}%'", txtItemCode.Text, txtDescription.Text)

            Dim ds As DataSet = LoadSQL(mySql, fillData)
            If ds.Tables(fillData).Rows.Count > 0 Then
                MsgBox("Data Already Exist!", MsgBoxStyle.Exclamation, "Add New Data!")
            Else
                IMD = New ItemMaterData
                With IMD
                    .ITEMCODE = txtItemCode.Text
                    .DESCRIPTION = txtDescription.Text
                    .UnitofMeasure = txtUnitofMeasure.Text
                    .PRICE = txtPrice.Text
                    .ONHOLDYN = cmbOnhold.Text
                    .INVENTORIALBE = cmbInInven.Text
                    .SALABLE = cmbIsSalable.Text
                    .HASSERIAL = cmbHasSerial.Text
                    .SaveIMD()

                End With

                MsgBox("Transaction Saved", MsgBoxStyle.Information)
                ClearTextField()
            End If
        End If
    End Sub


    Private Function isValid() As Boolean

        If txtItemCode.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtItemCode.Focus() : Return False
        If txtDescription.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtDescription.Focus() : Return False
        If txtUnitofMeasure.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtUnitofMeasure.Focus() : Return False
        If txtPrice.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : txtPrice.Focus() : Return False
        If cmbOnhold.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : cmbOnhold.Focus() : Return False
        If cmbInInven.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : cmbInInven.Focus() : Return False
        If cmbIsSalable.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : cmbIsSalable.Focus() : Return False
        If cmbHasSerial.Text = "" Then MsgBox("Please Complete All The Requirements", MsgBoxStyle.Information) : cmbHasSerial.Focus() : Return False
        Return True

    End Function

    Private Sub frmAddProduct_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ClearTextField()
    End Sub

    Friend Sub ClearTextField()
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtUnitofMeasure.Text = ""
        txtPrice.Text = ""
        cmbOnhold.SelectedItem = Nothing
        cmbInInven.SelectedItem = Nothing
        cmbIsSalable.SelectedItem = Nothing
        cmbHasSerial.SelectedItem = Nothing
        lblTitle.Text = "Adding New Item"
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
            cmbOnhold.Items.Clear()

            cmbOnhold.SelectedItem = .ONHOLDYN
            cmbInInven.Text = .INVENTORIALBE
            cmbIsSalable.Text = .SALABLE
            cmbHasSerial.Text = .HASSERIAL
        End With
    End Sub

    
End Class