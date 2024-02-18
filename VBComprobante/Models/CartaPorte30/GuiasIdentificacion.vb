Public Class GuiasIdentificacion
    Private _numeroGuiaIdentificacion As String = ""
    Private _descripcionGuiaIdentificacion As String = ""
    Private _pesoGuiaIdentificacion As Decimal = 0

    Public Property NumeroGuiaIdentificacion As String
        Get
            Return _numeroGuiaIdentificacion
        End Get
        Set(value As String)
            _numeroGuiaIdentificacion = value
        End Set
    End Property

    Public Property DescripcionGuiaIdentificacion As String
        Get
            Return _descripcionGuiaIdentificacion
        End Get
        Set(value As String)
            _descripcionGuiaIdentificacion = value
        End Set
    End Property

    Public Property PesoGuiaIdentificacion As Decimal
        Get
            Return _pesoGuiaIdentificacion
        End Get
        Set(value As Decimal)
            _pesoGuiaIdentificacion = value
        End Set
    End Property

End Class