Public Class DerechosDePaso

    Private _tipoDerechoDePaso As String = ""
    Private _kilometrajePagado As Double

    Public Property TipoDerechoDePaso As String
        Get
            Return _tipoDerechoDePaso
        End Get
        Set(value As String)
            _tipoDerechoDePaso = value
        End Set
    End Property

    Public Property KilometrajePagado As Double
        Get
            Return _kilometrajePagado
        End Get
        Set(value As Double)
            _kilometrajePagado = value
        End Set
    End Property

End Class