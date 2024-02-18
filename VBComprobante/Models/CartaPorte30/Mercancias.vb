Imports System
Imports System.Collections.Generic

Public Class Mercancias

    Private _pesoBrutoTotal As Double
    Private _unidadPeso As String = ""
    Private _pesoNetoTotal As Double
    Private _numTotalMercancias As Integer
    Private _cargoPorTasacion As Double
    Private _logisticaInversaRecoleccionDevolucion As String = ""

    Private _mercancia As List(Of Mercancia) = New List(Of Mercancia)
    Private _autotransporte As Autotransporte
    Private _transporteMaritimo As TransporteMaritimo
    Private _transporteAereo As TransporteAereo
    Private _transporteFerroviario As TransporteFerroviario

    Public Property PesoBrutoTotal As Double
        Get
            Return _PesoBrutoTotal
        End Get
        Set(value As Double)
            _pesoBrutoTotal = value
        End Set
    End Property

    Public Property UnidadPeso() As String
        Get
            Return _unidadPeso
        End Get
        Set(value As String)
            _unidadPeso = value
        End Set
    End Property

    Public Property PesoNetoTotal() As Double
        Get
            Return _pesoNetoTotal
        End Get
        Set(value As Double)
            _pesoNetoTotal = value
        End Set
    End Property

    Public Property NumTotalMercancias() As Integer
        Get
            Return _numTotalMercancias
        End Get
        Set(value As Integer)
            _numTotalMercancias = value
        End Set
    End Property

    Public Property CargoPorTasacion() As Double
        Get
            Return _cargoPorTasacion
        End Get
        Set(value As Double)
            _cargoPorTasacion = value
        End Set
    End Property

    Public Property LogisticaInversaRecoleccionDevolucion() As String
        Get
            Return _logisticaInversaRecoleccionDevolucion
        End Get
        Set(value As String)
            _logisticaInversaRecoleccionDevolucion = value
        End Set
    End Property

    Public Property Mercancia() As List(Of Mercancia)
        Get
            Return _mercancia
        End Get
        Set(value As List(Of Mercancia))
            _mercancia = value
        End Set
    End Property

    Public Property Autotransporte() As Autotransporte
        Get
            Return _autotransporte
        End Get
        Set(value As Autotransporte)
            _autotransporte = value
        End Set
    End Property

    Public Property TransporteMaritimo() As TransporteMaritimo
        Get
            Return _transporteMaritimo
        End Get
        Set(value As TransporteMaritimo)
            _transporteMaritimo = value
        End Set
    End Property

    Public Property TransporteAereo() As TransporteAereo
        Get
            Return _transporteAereo
        End Get
        Set(value As TransporteAereo)
            _transporteAereo = value
        End Set
    End Property

    Public Property TransporteFerroviario() As TransporteFerroviario
        Get
            Return _transporteFerroviario
        End Get
        Set(value As TransporteFerroviario)
            _transporteFerroviario = value
        End Set
    End Property
End Class
