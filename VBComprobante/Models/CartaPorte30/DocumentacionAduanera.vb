Public Class DocumentacionAduanera

    Private _tipoDocumento As String = ""
    Private _numPedimento As String = ""
    Private _identDocAduanero As String = ""
    Private _RFCImpo As String = ""

    Public Property TipoDocumento As String
        Get
            Return _tipoDocumento
        End Get
        Set(value As String)
            _tipoDocumento = value
        End Set
    End Property

    Public Property NumPedimento As String
        Get
            Return _numPedimento
        End Get
        Set(value As String)
            _numPedimento = value
        End Set
    End Property

    Public Property IdentDocAduanero As String
        Get
            Return _identDocAduanero
        End Get
        Set(value As String)
            _identDocAduanero = value
        End Set
    End Property

    Public Property RFCImpo As String
        Get
            Return _RFCImpo
        End Get
        Set(value As String)
            _RFCImpo = value
        End Set
    End Property

End Class