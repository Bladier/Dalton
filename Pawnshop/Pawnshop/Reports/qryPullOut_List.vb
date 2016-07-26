﻿Public Class qryPullOut_List

    Private mySql As String, fillData As String

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Item_PullOut()
    End Sub

    Private Sub qryPullOut_List_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mySql = "SELECT DISTINCT TYPE FROM tblClass"
        fillData = "tblClass"

        Dim ds As DataSet = LoadSQL(mySql)

        cboClass.Items.Clear()
        cboClass.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboClass.Items.Add(dr.Item("Type"))
        Next
        cboClass.SelectedIndex = 0
    End Sub

    Private Sub Item_PullOut()
        Dim stDay = GetFirstDate(monCalendar.SelectionStart)
        Dim laDay = GetLastDate(monCalendar.SelectionEnd)

        Dim dsName As String = "dsPullOut", mySql As String = _
        "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
        mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
        mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, PULLOUT, APPRAISER FROM PAWNING WHERE STATUS = 'WITHDRAW' AND "
        mySql &= String.Format("PULLOUT = '{0}'", monCalendar.SelectionStart.ToShortDateString)


        'Dim dsName As String = "dsPullOut", mySql As String = _
        '"SELECT * FROM PAWNING WHERE STATUS = 'WITHDRAW' AND "
        'mySql &= String.Format("PULLOUT = '{0}'", monCalendar.SelectionStart.ToShortDateString)

        If cboClass.Text <> "ALL" Then
            mySql &= String.Format(" AND ITEMTYPE = '{0}'", cboClass.Text)
        End If
        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)
        
        addParameters.Add("txtMonthOf", "DATE: " & stDay.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ItemPullout.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class