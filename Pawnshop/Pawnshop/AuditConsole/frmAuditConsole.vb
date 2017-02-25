﻿Imports Microsoft.Office.Interop
Public Class frmAuditConsole

    Private MEMO_MINIMUM As Double = 5000

    Private Sub btnVault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVault.Click
        Dim AMOUNT_MIN As Double
        AMOUNT_MIN = CDbl(txtPrincipal.Text)

        AuditReports.Min_Principal(AMOUNT_MIN, MonVault.SelectionRange.Start.ToShortDateString, cboType.Text)
    End Sub

    Private Sub Load_ItemType()
        Dim mySql As String = "SELECT DISTINCT ITEMCATEGORY FROM tblItem ORDER BY ITEMCATEGORY ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        cboType.Items.Clear()
        cboType.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr("ITEMCATEGORY"))
        Next

        cboType.SelectedIndex = 0
    End Sub

    Private Sub frmAuditConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPrincipal.Text = MEMO_MINIMUM.ToString("0.00")
        Load_ItemType()

        OTP_Init()
    End Sub

    Private Sub OTP_Init()
        txtEmail.Text = ""
        txtQRURL.Text = ""
        txtManual.Text = ""
    End Sub

    Private Sub btnCashCount_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashCount.Click
        frmCashCountV2.isAuditing = True
        frmCashCountV2.Show()
    End Sub

    Private Sub btnCCSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCSheet.Click
        qryDate.FormType = qryDate.ReportType.DailyCashCount
        qryDate.isAuditing = True
        qryDate.Show()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If txtEmail.Text = "" Then Exit Sub
        If Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then Exit Sub

        AuditOTP.Setup(txtEmail.Text)
        txtManual.Text = AuditOTP.ManualCode
        txtQRURL.Text = AuditOTP.QRCode_URL
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Inv_adjustment()
    End Sub

    Private Sub Inv_adjustment()
        If txtPath.Text = "" Then Exit Sub

        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(txtPath.Text)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim ImportedItem As New cItemData
            With ImportedItem
                Dim mysql As String = "SELECT * FROM ITEMMASTER WHERE ITEMCODE = '" & oSheet.Cells(cnt, 2).Value & "'"
                Dim ds As DataSet = LoadSQL(mysql, "ITEMMASTER")

                If ds.Tables(0).Rows.Count = 0 Then
                    On Error Resume Next
                Else
                    Dim ONHAND As Integer = ds.Tables(0).Rows(0).Item("ONHAND")

                    If oSheet.Cells(cnt, 5).value = "Y" Then
                        With ds.Tables(0).Rows(0)
                            .Item("ONHAND") = 0
                        End With
                        database.SaveEntry(ds, False)

                        With ds.Tables(0).Rows(0)
                            .Item("UPDATE_TIME") = Now
                            .Item("ONHAND") = oSheet.Cells(cnt, 4).value
                        End With
                        database.SaveEntry(ds, False)

                    Else
                        With ds.Tables(0).Rows(0)

                            .Item("UPDATE_TIME") = Now
                            .Item("ONHAND") = ONHAND + oSheet.Cells(cnt, 4).value
                        End With
                        database.SaveEntry(ds, False)
                    End If
                End If

            End With


        Next
        Me.Enabled = True


        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        txtPath.Text = ""

        MsgBox("Adjustments successfully executed.", MsgBoxStyle.Information, "Adjustment")

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdINV_AD.ShowDialog()

        txtPath.Text = ofdINV_AD.FileName
    End Sub
End Class