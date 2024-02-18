Public Class Seguros
    Private _aseguraRespCivilField As String = ""
    Private _polizaRespCivilField As String = ""
    Private _aseguraMedAmbienteField As String = ""
    Private _polizaMedAmbienteField As String = ""
    Private _aseguraCargaField As String = ""
    Private _polizaCargaField As String = ""
    Private _primaSeguroField As Double = 0

    Public Property AseguraRespCivil() As String
        Get
            Return _aseguraRespCivilField
        End Get
        Set(value As String)
            _aseguraRespCivilField = value
        End Set
    End Property

    Public Property PolizaRespCivil() As String
        Get
            Return _polizaRespCivilField
        End Get
        Set(value As String)
            _polizaRespCivilField = value
        End Set
    End Property

    Public Property AseguraMedAmbiente() As String
        Get
            Return _aseguraMedAmbienteField
        End Get
        Set(value As String)
            _aseguraMedAmbienteField = value
        End Set
    End Property

    Public Property PolizaMedAmbiente() As String
        Get
            Return _polizaMedAmbienteField
        End Get
        Set(value As String)
            _polizaMedAmbienteField = value
        End Set
    End Property

    Public Property AseguraCarga() As String
        Get
            Return _aseguraCargaField
        End Get
        Set(value As String)
            _aseguraCargaField = value
        End Set
    End Property

    Public Property PolizaCarga() As String
        Get
            Return _polizaCargaField
        End Get
        Set(value As String)
            _polizaCargaField = value
        End Set
    End Property

    Public Property PrimaSeguro() As Double
        Get
            Return _primaSeguroField
        End Get
        Set(value As Double)
            _primaSeguroField = value
        End Set
    End Property
End Class
