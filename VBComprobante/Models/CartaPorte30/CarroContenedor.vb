
Public Class CarroContenedor

    Private _tipoContenedor As String = ""
    Private _pesoContenedorVacio As Decimal
    Private _pesoNetoMercancia As Decimal

    Public Property TipoContenedor As String
        Get
            Return _tipoContenedor
        End Get
        Set(value As String)
            _tipoContenedor = value
        End Set
    End Property


    Public Property PesoContenedorVacio As Decimal
        Get
            Return _pesoContenedorVacio
        End Get
        Set(value As Decimal)
            _pesoContenedorVacio = value
        End Set
    End Property

    Public Property PesoNetoMercancia As Double
        Get
            Return _pesoNetoMercancia
        End Get
        Set(value As Double)
            _pesoNetoMercancia = value
        End Set
    End Property

End Class