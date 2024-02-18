Public Class Remolque

    Private _subTipoRem As String = ""
    Private _placa As String = ""

    Public Property SubTipoRem() As String
        Get
            Return _subTipoRem
        End Get
        Set(value As String)
            _subTipoRem = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _placa
        End Get
        Set(value As String)
            _placa = value
        End Set
    End Property

End Class