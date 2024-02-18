Public Class Mercancia
    Private _bienesTransp As String = ""
    Private _claveSTCC As String = ""
    Private _descripcion As String = ""
    Private _cantidad As Double
    Private _claveUnidad As String = ""
    Private _unidad As String = ""
    Private _dimensiones As String = ""
    Private _materialPeligroso As String = ""
    Private _cveMaterialPeligroso As String = ""
    Private _embalaje As String = ""
    Private _descripEmbalaje As String = ""
    Private _sectorCOFEPRIS As String = ""
    Private _nombreIngredienteActivo As String = ""
    Private _nomQuimico As String = ""
    Private _denominacionGenericaProd As String = ""
    Private _denominacionDistintivaProd As String = ""
    Private _fabricante As String = ""
    Private _fechaCaducidad As DateTime
    Private _loteMedicamento As String = ""
    Private _formaFarmaceutica As String = ""
    Private _condicionesEspTransp As String = ""
    Private _registroSanitarioFolioAutorizacion As String = ""
    Private _permisoImportacion As String = ""
    Private _folioImpoVUCEM As String = ""
    Private _numCAS As String = ""
    Private _razonSocialEmpImp As String = ""
    Private _numRegSanPlagCOFEPRIS As String = ""
    Private _datosFabricante As String = ""
    Private _datosFormulador As String = ""
    Private _datosMaquilador As String = ""
    Private _usoAutorizado As String = ""
    Private _pesoEnKg As Double
    Private _valorMercancia As Double
    Private _moneda As String = ""
    Private _fraccionArancelaria As String = ""
    Private _UUIDComercioExt As String = ""
    Private _tipoMateria As String = ""
    Private _descripcionMateria As String = ""
    Private _documentacionAduanera As List(Of DocumentacionAduanera) = New List(Of DocumentacionAduanera)
    Private _guiasIdentificacion As List(Of GuiasIdentificacion) = New List(Of GuiasIdentificacion)
    Private _cantidadTransporta As List(Of CantidadTransporta) = New List(Of CantidadTransporta)
    Private _detalleMercancia As DetalleMercancia

    Public Property BienesTransp As String
        Get
            Return _bienesTransp
        End Get
        Set(value As String)
            _bienesTransp = value
        End Set
    End Property

    Public Property ClaveSTCC As String
        Get
            Return _claveSTCC
        End Get
        Set(value As String)
            _claveSTCC = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Return _cantidad
        End Get
        Set(value As Double)
            _cantidad = value
        End Set
    End Property

    Public Property ClaveUnidad As String
        Get
            Return _claveUnidad
        End Get
        Set(value As String)
            _claveUnidad = value
        End Set
    End Property

    Public Property Unidad As String
        Get
            Return _unidad
        End Get
        Set(value As String)
            _unidad = value
        End Set
    End Property

    Public Property Dimensiones As String
        Get
            Return _dimensiones
        End Get
        Set(value As String)
            _dimensiones = value
        End Set
    End Property

    Public Property MaterialPeligroso As String
        Get
            Return _materialPeligroso
        End Get
        Set(value As String)
            _materialPeligroso = value
        End Set
    End Property

    Public Property CveMaterialPeligroso As String
        Get
            Return _cveMaterialPeligroso
        End Get
        Set(value As String)
            _cveMaterialPeligroso = value
        End Set
    End Property

    Public Property Embalaje As String
        Get
            Return _embalaje
        End Get
        Set(value As String)
            _embalaje = value
        End Set
    End Property

    Public Property DescripEmbalaje As String
        Get
            Return _descripEmbalaje
        End Get
        Set(value As String)
            _descripEmbalaje = value
        End Set
    End Property

    Public Property SectorCOFEPRIS As String
        Get
            Return _sectorCOFEPRIS
        End Get
        Set(value As String)
            _sectorCOFEPRIS = value
        End Set
    End Property

    Public Property NombreIngredienteActivo As String
        Get
            Return _nombreIngredienteActivo
        End Get
        Set(value As String)
            _nombreIngredienteActivo = value
        End Set
    End Property

    Public Property NomQuimico As String
        Get
            Return _nomQuimico
        End Get
        Set(value As String)
            _nomQuimico = value
        End Set
    End Property

    Public Property DenominacionGenericaProd As String
        Get
            Return _denominacionGenericaProd
        End Get
        Set(value As String)
            _denominacionGenericaProd = value
        End Set
    End Property

    Public Property DenominacionDistintivaProd As String
        Get
            Return _denominacionDistintivaProd
        End Get
        Set(value As String)
            _denominacionDistintivaProd = value
        End Set
    End Property

    Public Property Fabricante As String
        Get
            Return _fabricante
        End Get
        Set(value As String)
            _fabricante = value
        End Set
    End Property

    Public Property FechaCaducidad As DateTime
        Get
            Return _fechaCaducidad
        End Get
        Set(value As DateTime)
            _fechaCaducidad = value
        End Set
    End Property

    Public Property LoteMedicamento As String
        Get
            Return _loteMedicamento
        End Get
        Set(value As String)
            _loteMedicamento = value
        End Set
    End Property

    Public Property FormaFarmaceutica As String
        Get
            Return _formaFarmaceutica
        End Get
        Set(value As String)
            _formaFarmaceutica = value
        End Set
    End Property

    Public Property CondicionesEspTransp As String
        Get
            Return _condicionesEspTransp
        End Get
        Set(value As String)
            _condicionesEspTransp = value
        End Set
    End Property

    Public Property RegistroSanitarioFolioAutorizacion As String
        Get
            Return _registroSanitarioFolioAutorizacion
        End Get
        Set(value As String)
            _registroSanitarioFolioAutorizacion = value
        End Set
    End Property

    Public Property PermisoImportacion As String
        Get
            Return _permisoImportacion
        End Get
        Set(value As String)
            _permisoImportacion = value
        End Set
    End Property

    Public Property FolioImpoVUCEM As String
        Get
            Return _folioImpoVUCEM
        End Get
        Set(value As String)
            _folioImpoVUCEM = value
        End Set
    End Property

    Public Property NumCAS As String
        Get
            Return _numCAS
        End Get
        Set(value As String)
            _numCAS = value
        End Set
    End Property

    Public Property RazonSocialEmpImp As String
        Get
            Return _razonSocialEmpImp
        End Get
        Set(value As String)
            _razonSocialEmpImp = value
        End Set
    End Property

    Public Property NumRegSanPlagCOFEPRIS As String
        Get
            Return _numRegSanPlagCOFEPRIS
        End Get
        Set(value As String)
            _numRegSanPlagCOFEPRIS = value
        End Set
    End Property

    Public Property DatosFabricante As String
        Get
            Return _datosFabricante
        End Get
        Set(value As String)
            _datosFabricante = value
        End Set
    End Property
    Public Property DatosFormulador As String
        Get
            Return _datosFormulador
        End Get
        Set(value As String)
            _datosFormulador = value
        End Set
    End Property

    Public Property DatosMaquilador As String
        Get
            Return _datosMaquilador
        End Get
        Set(value As String)
            _datosMaquilador = value
        End Set
    End Property

    Public Property UsoAutorizado As String
        Get
            Return _usoAutorizado
        End Get
        Set(value As String)
            _usoAutorizado = value
        End Set
    End Property

    Public Property PesoEnKg As Double
        Get
            Return _pesoEnKg
        End Get
        Set(value As Double)
            _pesoEnKg = value
        End Set
    End Property

    Public Property ValorMercancia As Double
        Get
            Return _valorMercancia
        End Get
        Set(value As Double)
            _valorMercancia = value
        End Set
    End Property

    Public Property Moneda As String
        Get
            Return _moneda
        End Get
        Set(value As String)
            _moneda = value
        End Set
    End Property

    Public Property FraccionArancelaria As String
        Get
            Return _fraccionArancelaria
        End Get
        Set(value As String)
            _fraccionArancelaria = value
        End Set
    End Property

    Public Property UUIDComercioExt As String
        Get
            Return _UUIDComercioExt
        End Get
        Set(value As String)
            _UUIDComercioExt = value
        End Set
    End Property

    Public Property TipoMateria As String
        Get
            Return _tipoMateria
        End Get
        Set(value As String)
            _tipoMateria = value
        End Set
    End Property

    Public Property DescripcionMateria As String
        Get
            Return _descripcionMateria
        End Get
        Set(value As String)
            _descripcionMateria = value
        End Set
    End Property

    Public Property DocumentacionAduanera As List(Of DocumentacionAduanera)
        Get
            Return _documentacionAduanera
        End Get
        Set(value As List(Of DocumentacionAduanera))
            _documentacionAduanera = value
        End Set
    End Property

    Public Property GuiasIdentificacion As List(Of GuiasIdentificacion)
        Get
            Return _GuiasIdentificacion
        End Get
        Set(value As List(Of GuiasIdentificacion))
            _guiasIdentificacion = value
        End Set
    End Property

    Public Property CantidadTransporta As List(Of CantidadTransporta)
        Get
            Return _CantidadTransporta
        End Get
        Set(value As List(Of CantidadTransporta))
            _cantidadTransporta = value
        End Set
    End Property

    Public Property DetalleMercancia As DetalleMercancia
        Get
            Return _DetalleMercancia
        End Get
        Set(value As DetalleMercancia)
            _detalleMercancia = value
        End Set
    End Property

End Class

