
Public Class Autotransporte
    Private _permSCT As String = ""
    Private _numPermisoSCT As String = ""
    Private _identificacionVehicular As IdentificacionVehicular
    Private _seguros As Seguros
    Private _remolques As Remolques

    Public Property PermSCT As String
        Get
            Return _permSCT
        End Get

        Set(ByVal value As String)
            _permSCT = value
        End Set
    End Property

    Public Property NumPermisoSCT As String
        Get
            Return _numPermisoSCT
        End Get
        Set(value As String)
            _numPermisoSCT = value
        End Set
    End Property

    Public Property IdentificacionVehicular As IdentificacionVehicular
        Get
            Return _identificacionVehicular
        End Get
        Set(value As IdentificacionVehicular)
            _identificacionVehicular = value
        End Set
    End Property

    Public Property Seguros As Seguros
        Get
            Return _seguros
        End Get
        Set(value As Seguros)
            _seguros = value
        End Set
    End Property

    Public Property Remolques As Remolques
        Get
            Return _remolques
        End Get
        Set(value As Remolques)
            _remolques = value
        End Set
    End Property

End Class