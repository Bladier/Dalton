Module POS_SALES
    Public SALESTRANSACTIONID As String = GetOption_POS("SALESTRANSACTIONID")

    Friend Function GetOption_POS(ByVal keys As String) As String
        Dim mySql As String = "SELECT * FROM tbl_posmaintenance WHERE opt_keys = '" & keys & "'"
        Dim ret As String
        Try
            Dim ds As DataSet = LoadSQL(mySql)
            ret = ds.Tables(0).Rows(0).Item("opt_values")
        Catch ex As Exception
            ret = 0
        End Try

        Return ret
    End Function

End Module
