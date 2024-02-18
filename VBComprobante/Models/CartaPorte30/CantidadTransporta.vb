

Public Class CantidadTransporta
    Public _cantidad As Double = 0
    Public _iDOrigen As String = ""
    Public _iDDestino As String = ""
    Public _cvesTransporte As String = ""

    Public Property Cantidad As Double
        Get
            Return _cantidad
        End Get
        Set(value As Double)
            _cantidad = value
        End Set
    End Property

    Public Property IDOrigen As String
        Get
            Return _iDOrigen
        End Get
        Set(value As String)
            _iDOrigen = value
        End Set
    End Property

    Public Property IDDestino As String
        Get
            Return _iDDestino
        End Get
        Set(value As String)
            _iDDestino = value
        End Set
    End Property

    Public Property CvesTransporte As String
        Get
            Return _cvesTransporte
        End Get
        Set(value As String)
            _cvesTransporte = value
        End Set
    End Property
End Class
