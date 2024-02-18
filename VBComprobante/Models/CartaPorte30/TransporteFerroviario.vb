Public Class TransporteFerroviario
    Private _tipoDeServicio As String = ""
    Private _tipoDeTrafico As String = ""
    Private _nombreAseg As String = ""
    Private _numPolizaSeguro As String = ""
    Private _derechosDePaso As List(Of DerechosDePaso) = New List(Of DerechosDePaso)
    Private _carro As List(Of Carro) = New List(Of Carro)

    Public Property TipoDeServicio() As String
        Get
            Return _tipoDeServicio
        End Get
        Set(value As String)
            _tipoDeServicio = value
        End Set
    End Property

    Public Property TipoDeTrafico() As String
        Get
            Return _tipoDeTrafico
        End Get
        Set(value As String)
            _tipoDeTrafico = value
        End Set
    End Property

    Public Property NombreAseg() As String
        Get
            Return _nombreAseg
        End Get
        Set(value As String)
            _nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro() As String
        Get
            Return _numPolizaSeguro
        End Get
        Set(value As String)
            _numPolizaSeguro = value
        End Set
    End Property

    Public Property DerechosDePaso() As List(Of DerechosDePaso)
        Get
            Return _derechosDePaso
        End Get
        Set(value As List(Of DerechosDePaso))
            _derechosDePaso = value
        End Set
    End Property

    Public Property Carro() As List(Of Carro)
        Get
            Return _carro
        End Get
        Set(value As List(Of Carro))
            _carro = value
        End Set
    End Property
End Class
