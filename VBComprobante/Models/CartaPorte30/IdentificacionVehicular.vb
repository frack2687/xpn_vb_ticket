Public Class IdentificacionVehicular
    Private _configVehicular As String = ""
    Private _pesoBrutoVehicular As Double = 0
    Private _placaVM As String = ""
    Private _anioModeloVM As Integer = 0

    Public Property ConfigVehicular As String
        Get
            Return _configVehicular
        End Get
        Set(value As String)
            _configVehicular = value
        End Set
    End Property

    Public Property PesoBrutoVehicular As Double
        Get
            Return _pesoBrutoVehicular
        End Get
        Set(value As Double)
            _pesoBrutoVehicular = value
        End Set
    End Property

    Public Property PlacaVM As String
        Get
            Return _placaVM
        End Get
        Set(value As String)
            _placaVM = value
        End Set
    End Property

    Public Property AnioModeloVM As Integer
        Get
            Return _anioModeloVM
        End Get
        Set(value As Integer)
            _anioModeloVM = value
        End Set
    End Property
End Class
