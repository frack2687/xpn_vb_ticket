Public Class Ubicaciones
    Private _ubicacion As List(Of Ubicacion) = New List(Of Ubicacion)

    Public Property Ubicacion As List(Of Ubicacion)
        Get
            Return _ubicacion
        End Get
        Set(value As List(Of Ubicacion))
            _ubicacion = value
        End Set
    End Property

End Class
