Public Class FiguraTransporte
    Private _tiposFigura As List(Of TiposFigura) = New List(Of TiposFigura)

    Public Property TiposFigura As List(Of TiposFigura)
        Get
            Return _tiposFigura
        End Get
        Set(value As List(Of TiposFigura))
            _tiposFigura = value
        End Set
    End Property
End Class