Public Class TransporteAereo
    Private _permSCT As String = ""
    Private _numPermisoSCT As String = ""
    Private _matriculaAeronave As String = ""
    Private _nombreAseg As String = ""
    Private _numPolizaSeguro As String = ""
    Private _numeroGuia As String = ""
    Private _lugarContrato As String = ""
    Private _codigoTransportista As String = ""
    Private _rFCEmbarcador As String = ""
    Private _numRegIdTribEmbarc As String = ""
    Private _residenciaFiscalEmbarc As String = ""
    Private _nombreEmbarcador As String = ""

    Public Property PermSCT As String
        Get
            Return _permSCT
        End Get
        Set(value As String)
            _permSCT = value
        End Set
    End Property

    Public Property NumPermisoSCT As String
        Get
            Return _numPermisoSCT
        End Get
        Set(value As String)
            _numPermisoSCT = value
        End Set
    End Property

    Public Property MatriculaAeronave As String
        Get
            Return _matriculaAeronave
        End Get
        Set(value As String)
            _matriculaAeronave = value
        End Set
    End Property

    Public Property NombreAseg As String
        Get
            Return _nombreAseg
        End Get
        Set(value As String)
            _nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro As String
        Get
            Return _numPolizaSeguro
        End Get
        Set(value As String)
            _numPolizaSeguro = value
        End Set
    End Property

    Public Property NumeroGuia As String
        Get
            Return _numeroGuia
        End Get
        Set(value As String)
            _numeroGuia = value
        End Set
    End Property

    Public Property LugarContrato As String
        Get
            Return _lugarContrato
        End Get
        Set(value As String)
            _lugarContrato = value
        End Set
    End Property

    Public Property CodigoTransportista As String
        Get
            Return _codigoTransportista
        End Get
        Set(value As String)
            _codigoTransportista = value
        End Set
    End Property

    Public Property RFCEmbarcador As String
        Get
            Return _rFCEmbarcador
        End Get
        Set(value As String)
            _rFCEmbarcador = value
        End Set
    End Property

    Public Property NumRegIdTribEmbarc As String
        Get
            Return _numRegIdTribEmbarc
        End Get
        Set(value As String)
            _numRegIdTribEmbarc = value
        End Set
    End Property

    Public Property ResidenciaFiscalEmbarc As String
        Get
            Return _residenciaFiscalEmbarc
        End Get
        Set(value As String)
            _residenciaFiscalEmbarc = value
        End Set
    End Property

    Public Property NombreEmbarcador As String
        Get
            Return _nombreEmbarcador
        End Get
        Set(value As String)
            _nombreEmbarcador = value
        End Set
    End Property
End Class
