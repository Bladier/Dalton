Imports Microsoft.Office.Interop
Public Class ItemMaterData
    Private fillData As String = "tbl_itemmasterdata"
    Private mySql As String, ds As DataSet

#Region "Properties and Variables"
    Private _IMDID As Integer
    Public Property IMDID() As Integer
        Get
            Return _IMDID
        End Get
        Set(ByVal value As Integer)
            _IMDID = value
        End Set
    End Property

    Private _ITEMCODE As String
    Public Property ITEMCODE() As String
        Get
            Return _ITEMCODE
        End Get
        Set(ByVal value As String)
            _ITEMCODE = value
        End Set
    End Property

    Private _DESCRIPTION As String
    Public Property DESCRIPTION() As String
        Get
            Return _DESCRIPTION
        End Get
        Set(ByVal value As String)
            _DESCRIPTION = value
        End Set
    End Property

    Private _UNITOFMEASURE As String
    Public Property UnitofMeasure() As String
        Get
            Return _UNITOFMEASURE
        End Get
        Set(ByVal value As String)
            _UNITOFMEASURE = value
        End Set
    End Property

    Private _PRICE As Double
    Public Property PRICE() As Double
        Get
            Return _PRICE
        End Get
        Set(ByVal value As Double)
            _PRICE = value
        End Set
    End Property

    Private _ONHOLDYN As String
    Public Property ONHOLDYN() As String
        Get
            Return _ONHOLDYN
        End Get
        Set(ByVal value As String)
            _ONHOLDYN = value
        End Set
    End Property

    Private _INVENTORIABLE As String
    Public Property INVENTORIALBE() As String
        Get
            Return _INVENTORIABLE
        End Get
        Set(ByVal value As String)
            _INVENTORIABLE = value
        End Set
    End Property

    Private _SALABLE As String
    Public Property SALABLE() As String
        Get
            Return _SALABLE
        End Get
        Set(ByVal value As String)
            _SALABLE = value
        End Set
    End Property

    Private _HASSERIAL As String
    Public Property HASSERIAL() As String
        Get
            Return _HASSERIAL
        End Get
        Set(ByVal value As String)
            _HASSERIAL = value
        End Set
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub LoadIMD(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE IMD_ID = " & id
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadIMDbyRow(dr)
        Next
    End Sub
    Public Sub LoadIMDAllRow(ByVal dr As DataRow)
        LoadIMDbyRow(dr)
    End Sub

    Public Sub LoadIMDbyRow(ByVal dr As DataRow)
        With dr
            _IMDID = .Item("IMD_ID")
            _ITEMCODE = .Item("ITEMCODE")
            DESCRIPTION = .Item("DESCRIPTION")
            _UNITOFMEASURE = .Item("UNITOFMEASURE")
            _PRICE = .Item("PRICE")
            _ONHOLDYN = .Item("ONHOLDYN")
            _INVENTORIABLE = .Item("INVENTORIABLE")
            _SALABLE = .Item("SALABLE")
            _HASSERIAL = .Item("HASSERIAL")
        End With
    End Sub

    Public Sub UpdateIMD()
        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE ITEMCODE = " & _ITEMCODE
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If ds.Tables(0).Rows.Count >= 1 Then
            With ds.Tables(0).Rows(0)
                .Item("ITEMCODE") = _ITEMCODE
                .Item("DESCRIPTION") = DESCRIPTION
                .Item("UNITOFMEASURE") = _UNITOFMEASURE
                .Item("PRICE") = _PRICE
                .Item("ONHOLDYN") = _ONHOLDYN
                .Item("INVENTORIABLE") = _INVENTORIABLE
                .Item("SALABLE") = _SALABLE
                .Item("HASSERIAL") = _HASSERIAL
            End With
        End If
        database.SaveEntry(ds, False)
    End Sub

    Public Sub SaveIMD()

        mySql = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("IMD_ID") = LastIDNumber() + 1
            .Item("ITEMCODE") = _ITEMCODE
            .Item("DESCRIPTION") = DESCRIPTION
            .Item("UNITOFMEASURE") = _UNITOFMEASURE
            .Item("PRICE") = _PRICE
            .Item("ONHOLDYN") = _ONHOLDYN
            .Item("INVENTORIABLE") = _INVENTORIABLE
            .Item("SALABLE") = _SALABLE
            .Item("HASSERIAL") = _HASSERIAL
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

  


   
    Public Function LastIDNumber() As Single
        Dim mySql As String = "SELECT * FROM " & fillData & " ORDER BY IMD_ID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("IMD_ID")
    End Function
#End Region


    
End Class


