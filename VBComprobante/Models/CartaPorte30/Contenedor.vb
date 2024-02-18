Public Class Contenedor

    Private _tipoContenedor As String = ""
    Private _matriculaContenedor As String = ""
    Private _numPrecinto As String = ""
    Private _idCCPRelacionado As String = ""
    Private _placaVMCCP As String = ""
    Private _fechaCertificacionCCP As DateTime

    Public Property TipoContenedor As String
        Get
            Return _tipoContenedor
        End Get
        Set(value As String)
            _tipoContenedor = value
        End Set
    End Property

    Public Property MatriculaContenedor As String
        Get
            Return _matriculaContenedor
        End Get
        Set(value As String)
            _matriculaContenedor = value
        End Set
    End Property

    Public Property NumPrecinto As String
        Get
            Return _numPrecinto
        End Get
        Set(value As String)
            _numPrecinto = value
        End Set
    End Property

    Public Property IdCCPRelacionado As String
        Get
            Return _idCCPRelacionado
        End Get
        Set(value As String)
            _idCCPRelacionado = value
        End Set
    End Property

    Public Property PlacaVMCCP As String
        Get
            Return _placaVMCCP
        End Get
        Set(value As String)
            _placaVMCCP = value
        End Set
    End Property

    Public Property FechaCertificacionCCP As DateTime
        Get
            Return _fechaCertificacionCCP
        End Get
        Set(value As DateTime)
            _fechaCertificacionCCP = value
        End Set
    End Property

End Class