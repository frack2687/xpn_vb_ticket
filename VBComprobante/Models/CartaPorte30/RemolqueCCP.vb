
Public Class RemolqueCCP

    Private _subTipoRemCCP As String = ""
    Private _placaCCP As String = ""

    Public Property SubTipoRemCCP() As String
            Get
            Return _subTipoRemCCP
        End Get
            Set(value As String)
            _subTipoRemCCP = value
        End Set
        End Property

        Public Property PlacaCCP() As String
            Get
            Return _placaCCP
        End Get
            Set(value As String)
            _placaCCP = value
        End Set
        End Property

    End Class
