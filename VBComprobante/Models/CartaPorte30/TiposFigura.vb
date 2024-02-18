Public Class TiposFigura
    Private _tipoFiguraField As String = ""
    Private _rFCFiguraField As String = ""
    Private _numLicenciaField As String = ""
    Private _nombreFiguraField As String = ""
    Private _numRegIdTribFiguraField As String = ""
    Private _residenciaFiscalFiguraField As String = ""
    Private _partesTransporteField As List(Of PartesTransporte) = New List(Of PartesTransporte)
    Private _domicilioField As Domicilio

    Public Property TipoFigura() As String
        Get
            Return _tipoFiguraField
        End Get
        Set(value As String)
            _tipoFiguraField = value
        End Set
    End Property

    Public Property RFCFigura() As String
        Get
            Return _rFCFiguraField
        End Get
        Set(value As String)
            _rFCFiguraField = value
        End Set
    End Property

    Public Property NumLicencia() As String
        Get
            Return _numLicenciaField
        End Get
        Set(value As String)
            _numLicenciaField = value
        End Set
    End Property

    Public Property NombreFigura() As String
        Get
            Return _nombreFiguraField
        End Get
        Set(value As String)
            _nombreFiguraField = value
        End Set
    End Property

    Public Property NumRegIdTribFigura() As String
        Get
            Return _numRegIdTribFiguraField
        End Get
        Set(value As String)
            _numRegIdTribFiguraField = value
        End Set
    End Property

    Public Property ResidenciaFiscalFigura() As String
        Get
            Return _residenciaFiscalFiguraField
        End Get
        Set(value As String)
            _residenciaFiscalFiguraField = value
        End Set
    End Property

    Public Property PartesTransporte() As List(Of PartesTransporte)
        Get
            Return _partesTransporteField
        End Get
        Set(value As List(Of PartesTransporte))
            _partesTransporteField = value
        End Set
    End Property

    Public Property Domicilio() As Domicilio
        Get
            Return _domicilioField
        End Get
        Set(value As Domicilio)
            _domicilioField = value
        End Set
    End Property
End Class
