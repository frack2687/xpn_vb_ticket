Public Class DetalleMercancia

    Private _UnidadPesoMerc As String
    Private _PesoBruto As Double
    Private _PesoNeto As Double
    Private _PesoTara As Double
    Private _NumPiezas As Integer

    Public Property UnidadPesoMerc As String
        Get
            Return _UnidadPesoMerc
        End Get
        Set(value As String)
            _UnidadPesoMerc = value
        End Set
    End Property

    Public Property PesoBruto As Double
        Get
            Return _PesoBruto
        End Get
        Set(value As Double)
            _PesoBruto = value
        End Set
    End Property

    Public Property PesoNeto As Double
        Get
            Return _PesoNeto
        End Get
        Set(value As Double)
            _PesoNeto = value
        End Set
    End Property

    Public Property PesoTara As Double
        Get
            Return _PesoTara
        End Get
        Set(value As Double)
            _PesoTara = value
        End Set
    End Property

    Public Property NumPiezas As Integer
        Get
            Return _NumPiezas
        End Get
        Set(value As Integer)
            _NumPiezas = value
        End Set
    End Property
End Class