Public Class TransporteMaritimo
    Private _permSCT As String = ""
    Private _numPermisoSCT As String = ""
    Private _nombreAseg As String = ""
    Private _numPolizaSeguro As String = ""
    Private _tipoEmbarcacion As String = ""
    Private _matricula As String = ""
    Private _numeroOMI As String = ""
    Private _anioEmbarcacion As Integer
    Private _nombreEmbarc As String = ""
    Private _nacionalidadEmbarc As String = ""
    Private _unidadesDeArqBruto As Double
    Private _tipoCarga As String = ""
    Private _eslora As Double
    Private _manga As Double
    Private _calado As Double
    Private _puntal As Double
    Private _lineaNaviera As String = ""
    Private _nombreAgenteNaviero As String = ""
    Private _numAutorizacionNaviero As String = ""
    Private _numViaje As String = ""
    Private _numConocEmbarc As String = ""
    Private _permisoTempNavegacion As String = ""
    Private _contenedor As List(Of Contenedor) = New List(Of Contenedor)
    Private _remolquesCCP As RemolquesCCP

    Public Property PermSCT As String
        Get
            Return _permSCT
        End Get
        Set(value As String)
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

    Public Property NombreAseg As String
        Get
            Return _nombreAseg
        End Get
        Set(value As String)
            _nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro As String
        Get
            Return _numPolizaSeguro
        End Get
        Set(value As String)
            _numPolizaSeguro = value
        End Set
    End Property

    Public Property TipoEmbarcacion As String
        Get
            Return _tipoEmbarcacion
        End Get
        Set(value As String)
            _tipoEmbarcacion = value
        End Set
    End Property

    Public Property Matricula As String
        Get
            Return _matricula
        End Get
        Set(value As String)
            _matricula = value
        End Set
    End Property

    Public Property NumeroOMI As String
        Get
            Return _numeroOMI
        End Get
        Set(value As String)
            _numeroOMI = value
        End Set
    End Property

    Public Property AnioEmbarcacion As Integer
        Get
            Return _anioEmbarcacion
        End Get
        Set(value As Integer)
            _anioEmbarcacion = value
        End Set
    End Property

    Public Property NombreEmbarc As String
        Get
            Return _nombreEmbarc
        End Get
        Set(value As String)
            _nombreEmbarc = value
        End Set
    End Property

    Public Property NacionalidadEmbarc As String
        Get
            Return _nacionalidadEmbarc
        End Get
        Set(value As String)
            _nacionalidadEmbarc = value
        End Set
    End Property

    Public Property UnidadesDeArqBruto As Double
        Get
            Return _unidadesDeArqBruto
        End Get
        Set(value As Double)
            _unidadesDeArqBruto = value
        End Set
    End Property

    Public Property TipoCarga As String
        Get
            Return _tipoCarga
        End Get
        Set(value As String)
            _tipoCarga = value
        End Set
    End Property

    Public Property Eslora As Double
        Get
            Return _eslora
        End Get
        Set(value As Double)
            _eslora = value
        End Set
    End Property

    Public Property Manga As Double
        Get
            Return _manga
        End Get
        Set(value As Double)
            _manga = value
        End Set
    End Property

    Public Property Calado As Double
        Get
            Return _calado
        End Get
        Set(value As Double)
            _calado = value
        End Set
    End Property

    Public Property Puntal As Double
        Get
            Return _puntal
        End Get
        Set(value As Double)
            _puntal = value
        End Set
    End Property

    Public Property LineaNaviera As String
        Get
            Return _lineaNaviera
        End Get
        Set(value As String)
            _lineaNaviera = value
        End Set
    End Property

    Public Property NombreAgenteNaviero As String
        Get
            Return _nombreAgenteNaviero
        End Get
        Set(value As String)
            _nombreAgenteNaviero = value
        End Set
    End Property

    Public Property NumAutorizacionNaviero As String
        Get
            Return _numAutorizacionNaviero
        End Get
        Set(value As String)
            _numAutorizacionNaviero = value
        End Set
    End Property

    Public Property NumViaje As String
        Get
            Return _numViaje
        End Get
        Set(value As String)
            _numViaje = value
        End Set
    End Property

    Public Property NumConocEmbarc As String
        Get
            Return _numConocEmbarc
        End Get
        Set(value As String)
            _numConocEmbarc = value
        End Set
    End Property

    Public Property PermisoTempNavegacion As String
        Get
            Return _permisoTempNavegacion
        End Get
        Set(value As String)
            _permisoTempNavegacion = value
        End Set
    End Property

    Public Property Contenedor As List(Of Contenedor)
        Get
            Return _contenedor
        End Get
        Set(value As List(Of Contenedor))
            _contenedor = value
        End Set
    End Property

    Public Property RemolquesCCP As RemolquesCCP
        Get
            Return _remolquesCCP
        End Get
        Set(value As RemolquesCCP)
            _remolquesCCP = value
        End Set
    End Property
End Class
