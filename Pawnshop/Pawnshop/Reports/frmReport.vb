﻿Imports Microsoft.Reporting.WinForms
Public Class frmReport

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub withSubReport(ByVal mySql As Dictionary(Of String, String), ByVal rptUrl As String, _
                                Optional ByVal addPara As Dictionary(Of String, String) = Nothing, Optional ByVal hasUser As Boolean = True)
        Dim dsName As String
        Dim ds As New DataSet
        With rv_display
            .ProcessingMode = ProcessingMode.Local
            .LocalReport.ReportPath = rptUrl
            .LocalReport.DataSources.Clear()



        End With
    End Sub

    Friend Sub MultiDbSetReport(ByVal mySql As Dictionary(Of String, String), ByVal rptUrl As String, _
                                Optional ByVal addPara As Dictionary(Of String, String) = Nothing, Optional ByVal hasUser As Boolean = True)

        Dim dsName As String
        Dim ds As New DataSet
        With rv_display
            .ProcessingMode = ProcessingMode.Local
            .LocalReport.ReportPath = rptUrl
            .LocalReport.DataSources.Clear()

            For Each el In mySql
                ds.Clear()
                dsName = el.Key
                ds = LoadSQL(el.Value, el.Key)
                .LocalReport.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
            Next

            If hasUser Then
                Dim myPara As New ReportParameter
                myPara.Name = "txtUsername"
                If POSuser.UserName Is Nothing Then POSuser.UserName = "Sample Eskie"
                myPara.Values.Add(POSuser.UserName)
                rv_display.LocalReport.SetParameters(New ReportParameter() {myPara})
            End If

            If Not addPara Is Nothing Then
                For Each nPara In addPara
                    Dim tmpPara As New ReportParameter
                    tmpPara.Name = nPara.Key
                    tmpPara.Values.Add(nPara.Value)
                    .LocalReport.SetParameters(New ReportParameter() {tmpPara})
                Next
            End If


            .RefreshReport()
        End With
    End Sub

    Friend Sub ReportInit(ByVal mySql As String, ByVal dsName As String, ByVal rptUrl As String, _
                          Optional ByVal addPara As Dictionary(Of String, String) = Nothing, Optional ByVal hasUser As Boolean = True)
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        Console.WriteLine("SQL: " & mySql)
        Console.WriteLine("Max: " & ds.Tables(dsName).Rows.Count)
        Console.WriteLine("Report is Existing? " & System.IO.File.Exists(Application.StartupPath & "\" & rptUrl))
        With rv_display
            .ProcessingMode = ProcessingMode.Local
            .LocalReport.ReportPath = rptUrl
            .LocalReport.DataSources.Clear()

            .LocalReport.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
            If hasUser Then
                Dim myPara As New ReportParameter
                myPara.Name = "txtUsername"
                If POSuser.UserName Is Nothing Then POSuser.UserName = "Sample Eskie"
                myPara.Values.Add(POSuser.UserName)
                rv_display.LocalReport.SetParameters(New ReportParameter() {myPara})
            End If

            If Not addPara Is Nothing Then
                For Each nPara In addPara
                    Dim tmpPara As New ReportParameter
                    tmpPara.Name = nPara.Key
                    tmpPara.Values.Add(nPara.Value)
                    .LocalReport.SetParameters(New ReportParameter() {tmpPara})
                Next
            End If


            .RefreshReport()
        End With
    End Sub
End Class