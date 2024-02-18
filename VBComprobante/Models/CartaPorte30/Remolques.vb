Public Class Remolques
    Private _remolque As New List(Of Remolque)()

    Public Property Remolque() As List(Of Remolque)
        Get
            Return _remolque
        End Get
        Set(value As List(Of Remolque))
            _remolque = value
        End Set
    End Property
End Class