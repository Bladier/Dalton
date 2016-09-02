Module MOD_IMD

    Dim filldata As String = "TBL_ITEMMASTERDATA"

    Public Sub SaveItemMaster(ByVal itemcode As String, ByVal description As String, ByVal UnitOfMeasure As String, ByVal Price As String,
                             ByVal OnHold As String, ByVal IsINV As String, ByVal IsSale As String, ByVal HasSerial As String)


        Try
            Dim mySql As String = "SELECT * FROM " & filldata & " WHERE ITEMCODE = '" & itemcode & "'"
            Dim ds As DataSet
            ds = LoadSQL(mySql, filldata)

            If ds.Tables(0).Rows.Count >= 1 Then
                With ds.Tables(0).Rows(0)
                    .Item("DESCRIPTION") = description
                    .Item("UNITOFMEASURE") = UnitOfMeasure
                    .Item("PRICE") = Price
                    .Item("ONHOLDYN") = OnHold
                    .Item("INVENTORIABLE") = IsINV
                    .Item("SALABLE") = IsSale
                    .Item("HASSERIAL") = HasSerial
                End With
                database.SaveEntry(ds, False)
            Else
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(filldata).NewRow
                With dsNewRow
                    .Item("ITEMCODE") = itemcode
                    .Item("DESCRIPTION") = description
                    .Item("UNITOFMEASURE") = UnitOfMeasure
                    .Item("PRICE") = Price
                    .Item("ONHOLDYN") = OnHold
                    .Item("INVENTORIABLE") = IsINV
                    .Item("SALABLE") = IsSale
                    .Item("HASSERIAL") = HasSerial
                End With
                ds.Tables(filldata).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub SaveSTO(ByVal ITEMCODE As String, ByVal DESCRIPTION As String, ByVal QUANTITY As String, ByVal WSHCODE As String, ByVal STONO As String, ByVal STODATE As Date)
        Dim filldata As String = "TBL_STO_POS"
        Try
            Dim mySql As String = "SELECT * FROM " & filldata & " WHERE ITEMCODE = '" & ITEMCODE & "'"
            Dim ds As DataSet
            ds = LoadSQL(mySql, filldata)

            If ds.Tables(0).Rows.Count >= 1 Then
                With ds.Tables(0).Rows(0)
                    .Item("DESCRIPTION") = DESCRIPTION
                    .Item("QUANTITY") = QUANTITY
                    .Item("WSHCODE") = WSHCODE
                    .Item("STONO") = STONO
                    .Item("STO_DATE") = STODATE
                End With
                database.SaveEntry(ds, False)
            Else
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(filldata).NewRow
                With dsNewRow
                    .Item("ITEMCODE") = ITEMCODE
                    .Item("DESCRIPTION") = DESCRIPTION
                    .Item("QUANTITY") = QUANTITY
                    .Item("WSHCODE") = WSHCODE
                    .Item("STONO") = STONO
                    .Item("STO_DATE") = STODATE
                End With
                ds.Tables(filldata).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
