Public Class CartaPorte30

    Private _version As String = ""
    Private _idCCP As String = ""
    Private _transpInternac As String = ""
    Private _regimenAduanero As String = ""
    Private _entradaSalidaMerc As String = ""
    Private _paisOrigenDestino As String = ""
    Private _viaEntradaSalida As String = ""
    Private _totalDistRec As Double = 0
    Private _registroISTMO As String = ""
    Private _ubicacionPoloOrigen As String = ""
    Private _ubicacionPoloDestino As String = ""

    Private _ubicaciones As Ubicaciones
    Private _mercancias As Mercancias
    Private _figuraTransporte As FiguraTransporte

    Public Sub New()
        _version = "3.0"
    End Sub

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property

    Public Property IdCCP As String
        Get
            Return _idCCP
        End Get
        Set(value As String)
            _idCCP = value
        End Set
    End Property

    Public Property TranspInternac As String
        Get
            Return _transpInternac
        End Get
        Set(value As String)
            _transpInternac = value
        End Set
    End Property

    Public Property RegimenAduanero As String
        Get
            Return _regimenAduanero
        End Get
        Set(value As String)
            _regimenAduanero = value
        End Set
    End Property

    Public Property EntradaSalidaMerc As String
        Get
            Return _entradaSalidaMerc
        End Get
        Set(value As String)
            _entradaSalidaMerc = value
        End Set
    End Property

    Public Property PaisOrigenDestino As String
        Get
            Return _paisOrigenDestino
        End Get
        Set(value As String)
            _paisOrigenDestino = value
        End Set
    End Property

    Public Property ViaEntradaSalida As String
        Get
            Return _viaEntradaSalida
        End Get
        Set(value As String)
            _viaEntradaSalida = value
        End Set
    End Property

    Public Property TotalDistRec As Double
        Get
            Return _totalDistRec
        End Get
        Set(value As Double)
            _totalDistRec = value
        End Set
    End Property

    Public Property RegistroISTMO As String
        Get
            Return _registroISTMO
        End Get
        Set(value As String)
            _registroISTMO = value
        End Set
    End Property

    Public Property UbicacionPoloOrigen As String
        Get
            Return _ubicacionPoloOrigen
        End Get
        Set(value As String)
            _ubicacionPoloOrigen = value
        End Set
    End Property

    Public Property UbicacionPoloDestino As String
        Get
            Return _ubicacionPoloDestino
        End Get
        Set(value As String)
            _ubicacionPoloDestino = value
        End Set
    End Property

    Public Property Ubicaciones As Ubicaciones
        Get
            Return _ubicaciones
        End Get
        Set(value As Ubicaciones)
            _ubicaciones = value
        End Set
    End Property

    Public Property Mercancias As Mercancias
        Get
            Return _mercancias
        End Get
        Set(value As Mercancias)
            _mercancias = value
        End Set
    End Property

    Public Property FiguraTransporte As FiguraTransporte
        Get
            Return _figuraTransporte
        End Get
        Set(value As FiguraTransporte)
            _figuraTransporte = value
        End Set
    End Property

End Class