Public Class RemolquesCCP
    Private remolqueCCPField As List(Of RemolqueCCP) = New List(Of RemolqueCCP)

    Public Property RemolqueCCP() As List(Of RemolqueCCP)
        Get
            Return remolqueCCPField
        End Get
        Set(value As List(Of RemolqueCCP))
            remolqueCCPField = value
        End Set
    End Property
End Class
