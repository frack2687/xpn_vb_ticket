Public Class PartesTransporte

    Private _parteTransporte As String = ""

    Public Property ParteTransporte() As String
        Get
            Return _parteTransporte
        End Get
        Set(value As String)
            _parteTransporte = value
        End Set
    End Property

End Class
