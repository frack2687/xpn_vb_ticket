Imports System

Public Class Ubicacion
    Private _tipoUbicacion As String = ""
    Private _iDUbicacion As String = ""
    Private _rFCRemitenteDestinatario As String = ""
    Private _nombreRemitenteDestinatario As String = ""
    Private _numRegIdTrib As String = ""
    Private _residenciaFiscal As String = ""
    Private _numEstacion As String = ""
    Private _nombreEstacion As String = ""
    Private _navegacionTrafico As String = ""
    Private _fechaHoraSalidaLlegada As DateTime
    Private _tipoEstacion As String = ""
    Private _distanciaRecorrida As Double = 0

    Private _domicilio As Domicilio

    Public Property Domicilio As Domicilio
        Get
            Return _domicilio
        End Get
        Set(value As Domicilio)
            _domicilio = value
        End Set
    End Property

    Public Property TipoUbicacion As String
        Get
            Return _tipoUbicacion
        End Get
        Set(value As String)
            _tipoUbicacion = value
        End Set
    End Property

    Public Property IDUbicacion As String
        Get
            Return _iDUbicacion
        End Get
        Set(value As String)
            _iDUbicacion = value
        End Set
    End Property

    Public Property RFCRemitenteDestinatario As String
        Get
            Return _rFCRemitenteDestinatario
        End Get
        Set(value As String)
            _rFCRemitenteDestinatario = value
        End Set
    End Property

    Public Property NombreRemitenteDestinatario As String
        Get
            Return _nombreRemitenteDestinatario
        End Get
        Set(value As String)
            _nombreRemitenteDestinatario = value
        End Set
    End Property

    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get
        Set(value As String)
            _numRegIdTrib = value
        End Set
    End Property

    Public Property ResidenciaFiscal As String
        Get
            Return _residenciaFiscal
        End Get
        Set(value As String)
            _residenciaFiscal = value
        End Set
    End Property

    Public Property NumEstacion As String
        Get
            Return _numEstacion
        End Get
        Set(value As String)
            _numEstacion = value
        End Set
    End Property

    Public Property NombreEstacion As String
        Get
            Return _nombreEstacion
        End Get
        Set(value As String)
            _nombreEstacion = value
        End Set
    End Property

    Public Property NavegacionTrafico As String
        Get
            Return _navegacionTrafico
        End Get
        Set(value As String)
            _navegacionTrafico = value
        End Set
    End Property

    Public Property FechaHoraSalidaLlegada As DateTime
        Get
            Return _fechaHoraSalidaLlegada
        End Get
        Set(value As DateTime)
            _fechaHoraSalidaLlegada = value
        End Set
    End Property

    Public Property TipoEstacion As String
        Get
            Return _tipoEstacion
        End Get
        Set(value As String)
            _tipoEstacion = value
        End Set
    End Property

    Public Property DistanciaRecorrida As Double
        Get
            Return _distanciaRecorrida
        End Get
        Set(value As Double)
            _distanciaRecorrida = value
        End Set
    End Property
End Class
