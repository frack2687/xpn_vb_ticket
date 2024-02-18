Public Class Domicilio
    Private _calle As String = ""
    Private _numeroExterior As String = ""
    Private _numeroInterior As String = ""
    Private _colonia As String = ""
    Private _localidad As String = ""
    Private _referencia As String = ""
    Private _municipio As String = ""
    Private _estado As String = ""
    Private _pais As String = ""
    Private _codigoPostal As String = ""

    Public Property Calle As String
        Get
            Return _calle
        End Get
        Set(value As String)
            _calle = value
        End Set
    End Property

    Public Property NumeroExterior As String
        Get
            Return _numeroExterior
        End Get
        Set(value As String)
            _numeroExterior = value
        End Set
    End Property

    Public Property NumeroInterior As String
        Get
            Return _numeroInterior
        End Get
        Set(value As String)
            _numeroInterior = value
        End Set
    End Property

    Public Property Colonia As String
        Get
            Return _colonia
        End Get
        Set(value As String)
            _colonia = value
        End Set
    End Property

    Public Property Localidad As String
        Get
            Return _localidad
        End Get
        Set(value As String)
            _localidad = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return _referencia
        End Get
        Set(value As String)
            _referencia = value
        End Set
    End Property

    Public Property Municipio As String
        Get
            Return _municipio
        End Get
        Set(value As String)
            _municipio = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _pais
        End Get
        Set(value As String)
            _pais = value
        End Set
    End Property

    Public Property CodigoPostal As String
        Get
            Return _codigoPostal
        End Get
        Set(value As String)
            _codigoPostal = value
        End Set
    End Property
End Class
