
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Threading.Tasks

#Region "Clase Comprobante"
Public Class Comprobante
    Private _version As String = "4.0"
    Private _serie As String = String.Empty
    Private _folio As String = String.Empty
    Private _fecha As DateTime
    Private _sello As String = String.Empty
    Private _formaPago As String = String.Empty
    Private _noCertificado As String = String.Empty
    Private _certificado As String = String.Empty
    Private _condicionesDePago As String = String.Empty
    Private _subtotal As Decimal = 0
    Private _descuento As Decimal = 0
    Private _moneda As String = String.Empty
    Private _tipoCambio As Decimal = 0
    Private _total As Decimal = 0
    Private _tipoDeComprobante As String = String.Empty
    Private _exportacion As String = String.Empty
    Private _metodoPago As String = String.Empty
    Private _lugarExpedicion As String = String.Empty
    Private _confirmacion As String = String.Empty
    Private _informacionGlobal As InformacionGlobal
    Private _cfdiRelacionados As CfdiRelacionados
    Private _emisor As Emisor = New Emisor
    Private _receptor As Receptor = New Receptor
    Private _conceptos As Conceptos = New Conceptos
    Private _impuestos As Impuestos = New Impuestos
    'ADDENDA
    Private _complemento As Complemento
    Private _addenda As Addenda
    Public _totalLetra As String = String.Empty
    Public AcuseCancelacion As Acuse
    Public xml As String

    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <remarks> Atributo requerido con valor prefijo a 3.3 que indica la versión del estándar bajo el que se encuentra expresado el comprobante.</remarks>
    ''' </summary>
    Public Property Version As String
        Get
            Return _version
        End Get

        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Este atributo acepta una cadena de caracteres.</remarks>
    Public Property Serie As String
        Get
            Return _serie
        End Get

        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Este atributo acepta una cadena de caracteres.</remarks>
    ''' </summary>
    Public Property Folio As String
        Get
            Return _folio
        End Get

        Set(ByVal value As String)
            _folio = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Se expresa en la forma AAAA-MM-DD:Thh:mm:ss</remarks>
    ''' </summary>
    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get

        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Debe ser expresado como una cadeba de texto en formato Base 64.</remarks>
    ''' </summary>
    Public Property Sello As String
        Get
            Return _sello
        End Get

        Set(ByVal value As String)
            _sello = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa la clave de la forma de pago.</remarks>
    ''' </summary>
    Public Property FormaPago As String
        Get
            Return _formaPago
        End Get

        Set(ByVal value As String)
            _formaPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Expresa el numero de serie del certificado de sello digital que amremarks al comprobante de acuerdo con el acuse correspondiente a 20 posiciones otorgadas por el sistema del SAT.</remarks>
    ''' </summary>
    Public Property NoCertificado As String
        Get
            Return _noCertificado
        End Get

        Set(ByVal value As String)
            _noCertificado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>El certificado del sello digital que amremarks al comprobante, como texto en formato base 64.</remarks>
    ''' </summary>
    Public Property Certificado As String
        Get
            Return _certificado
        End Get

        Set(ByVal value As String)
            _certificado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar las condiciones comerciales aplicables para el pago del CFDI. Este atributo puede ser condicionado mediante atributos o complementos.</remarks>
    ''' </summary>
    Public Property CondicionesDePago As String
        Get
            Return _condicionesDePago
        End Get

        Set(ByVal value As String)
            _condicionesDePago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Representa la suma de los conceptos antes de descuentos e impuestos. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property SubTotal As Decimal
        Get
            Return _subtotal
        End Get

        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Representa el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe aplicar cuando existan conceptos con descuento.</remarks>
    ''' </summary>
    Public Property Descuento As Decimal
        Get
            Return _descuento
        End Get

        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Requerido para identificar la clave de la moneda utilizada para expresar los montos. Cuando se usa moneda nacional se registra MXN.</remarks>
    ''' </summary>
    Public Property Moneda As String
        Get
            Return _moneda
        End Get

        Set(ByVal value As String)
            _moneda = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando la clave de moneda es distinta de MXN y de XXX. </remarks>
    ''' </summary>
    Public Property TipoCambio As Decimal
        Get
            Return _tipoCambio
        End Get

        Set(ByVal value As Decimal)
            _tipoCambio = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Representa la suma del subtotal, menos los descuentos aplicables, mas las contribuciones recibidas(impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos.No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Total As Decimal
        Get
            Return _total
        End Get

        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>La clave del efecto del comprobante fiscal para el contribuyente emisor.</remarks>
    ''' </summary>
    Public Property TipoDeComprobante As String
        Get
            Return _tipoDeComprobante
        End Get

        Set(ByVal value As String)
            _tipoDeComprobante = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar si el comprobante ampara una operación de exportación.</remarks>
    ''' </summary>
    Public Property Exportacion As String
        Get
            Return _exportacion
        End Get

        Set(ByVal value As String)
            _exportacion = value
        End Set
    End Property

    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributos condicional para precisar la clave del metodo de pago que aplica para este CFDI.</remarks>
    ''' </summary>
    Public Property MetodoPago As String
        Get
            Return _metodoPago
        End Get

        Set(ByVal value As String)
            _metodoPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Incorpora el código postal del lugar de expedición del comprobante. (Domicilio de la matriz o de la sucursal)</remarks>
    ''' </summary>
    Public Property LugarExpedicion As String
        Get
            Return _lugarExpedicion
        End Get

        Set(ByVal value As String)
            _lugarExpedicion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para registrar la clave de confirmación que entrege el PAC para expedir el comprobante con importes grandes.</remarks>
    ''' </summary>
    Public Property Confirmacion As String
        Get
            Return _confirmacion
        End Get

        Set(ByVal value As String)
            _confirmacion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para precisar la informacion de los comprobante relacionados.</remarks>
    ''' </summary>
    Public Property InformacionGlobal As InformacionGlobal
        Get
            Return _informacionGlobal
        End Get

        Set(ByVal value As InformacionGlobal)
            _informacionGlobal = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para precisar la informacion de los comprobante relacionados.</remarks>
    ''' </summary>
    Public Property CfdiRelacionados As CfdiRelacionados
        Get
            Return _cfdiRelacionados
        End Get

        Set(ByVal value As CfdiRelacionados)
            _cfdiRelacionados = value
        End Set
    End Property

    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para expresar la informacion del contribuyente emisor del comprobante.</remarks>
    ''' </summary>
    Public Property Emisor As Emisor
        Get
            Return _emisor
        End Get

        Set(ByVal value As Emisor)
            _emisor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para precisar la información del contribuyente receptor del comprobante.</remarks>
    ''' </summary>
    Public Property Receptor As Receptor
        Get
            Return _receptor
        End Get

        Set(ByVal value As Receptor)
            _receptor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para listar los conceptos cubiertos por el comprobante.</remarks>
    ''' </summary>
    Public Property Conceptos As Conceptos
        Get
            Return _conceptos
        End Get

        Set(ByVal value As Conceptos)
            _conceptos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para expresar el resumen de los impuestos aplicables.</remarks>
    ''' </summary>
    Public Property Impuestos As Impuestos
        Get
            Return _impuestos
        End Get

        Set(ByVal value As Impuestos)
            _impuestos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' <remarks>Nodo opcional donde se incluye el complemento TImbre Fiscal Digital de manera obligatoria y los nodos complementarios determinados por el SAT.</remarks>
    ''' </summary>
    Public Property Complemento As Complemento
        Get
            Return _complemento
        End Get

        Set(ByVal value As Complemento)
            _complemento = value
        End Set
    End Property
    Public Property Addenda As Addenda
        Get
            Return _addenda
        End Get
        Set(ByVal value As Addenda)
            _addenda = value
        End Set
    End Property
    Public Property TotalLetra As String
        Get
            Return _totalLetra
        End Get

        Set(ByVal value As String)
            _totalLetra = value
        End Set
    End Property

End Class
Public Class InformacionGlobal
    Private _periodicidad As String = String.Empty
    Private _meses As String = String.Empty
    Private _ano As Integer = 0
    '''// <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el período al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Periodicidad As String
        Get
            Return _periodicidad
        End Get
        Set(ByVal value As String)
            _periodicidad = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el mes o los meses al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Meses As String
        Get
            Return _meses
        End Get
        Set(ByVal value As String)
            _meses = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el año al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Ano As Integer
        Get
            Return _ano
        End Get
        Set(ByVal value As Integer)
            _ano = value
        End Set
    End Property
End Class
Public Class CfdiRelacionados
    Public _tipoRelacion As String = String.Empty
    Public _cfdiRelacionado As List(Of CfdiRelacionado) = New List(Of CfdiRelacionado)()
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para indicar la clave de la relación que existe entre este que se esta generando y el o los CFDI previos.</remarks>
    ''' </summary>
    Public Property TipoRelacion As String
        Get
            Return _tipoRelacion
        End Get

        Set(ByVal value As String)
            _tipoRelacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para precisar la información de los comprobantes relacionados.</remarks>
    ''' </summary>
    Public Property CfdiRelacionado As List(Of CfdiRelacionado)
        Get
            Return _cfdiRelacionado
        End Get

        Set(ByVal value As List(Of CfdiRelacionado))
            _cfdiRelacionado = value
        End Set
    End Property
End Class
Public Class CfdiRelacionado
    Private _uuid As String
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributos requerido remarks registrar el folio fiscal (UUID) de un CFDI relacionado con el presente comprobante.</remarks>
    ''' </summary>
    Public Property UUID As String
        Get
            Return _uuid
        End Get
        Set(value As String)
            _uuid = value
        End Set
    End Property

End Class
Public Class Emisor
    Private _rfc As String = String.Empty
    Private _nombre As String = String.Empty
    Private _regimenFiscal As String = String.Empty
    Private _facAtrAdquirente As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo para precisar la clave del Registro Federal de Contribuyentes.</remarks>
    ''' </summary>
    Public Property Rfc As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para registrar el nombre, denominación o razón social del contribuyente emisor del comprobante.</remarks>
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get

        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' <remarks>Atributo requerido para incorporar la clave del régimen del contribuyente emisor al que aplicara el efecto fiscal de este comprobante.</remarks>
    ''' </summary>
    Public Property RegimenFiscal As String
        Get
            Return _regimenFiscal
        End Get

        Set(ByVal value As String)
            _regimenFiscal = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido</value>
    ''' <para>Atributo condicional para expresar el número de operación proporcionado por el SAT cuando se trate de un comprobante a través de un PCECFDI o un PCGCFDISP.</para>
    ''' </summary>
    Public Property FacAtrAdquirente As String
        Get
            Return _facAtrAdquirente
        End Get

        Set(ByVal value As String)
            _facAtrAdquirente = value
        End Set
    End Property
End Class
Public Class Receptor
    Private _rfc As String = String.Empty
    Private _nombre As String = String.Empty
    Private _domicilioFiscalReceptor As String = String.Empty
    Private _residenciaFiscal As String = String.Empty
    Private _numRegIdTrib As String = String.Empty
    Private _regimenFiscalReceptor As String = String.Empty
    Private _usoCFDI As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo para precisar la clave del Registro Federal de Contribuyentes.</remarks>
    ''' </summary>
    Public Property Rfc As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para registrar el nombre, denominación o razón social del contribuyente receptor del comprobante.</remarks>
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get

        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para registrar el código postal del domicilio fiscal del receptor del comprobante.</remarks>
    ''' </summary>
    Public Property DomicilioFiscalReceptor As String
        Get
            Return _domicilioFiscalReceptor
        End Get

        Set(ByVal value As String)
            _domicilioFiscalReceptor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando se incluye el complemento de comercio exterior o se registre el atributo NumRegIdTrib.</remarks>
    ''' </summary>
    Public Property ResidenciaFiscal As String
        Get
            Return _residenciaFiscal
        End Get

        Set(ByVal value As String)
            _residenciaFiscal = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para incorporar la clave del régimen fiscal del contribuyente receptor al que aplicará el efecto fiscal de este comprobante.</remarks>
    ''' </summary>
    Public Property RegimenFiscalReceptor As String
        Get
            Return _regimenFiscalReceptor
        End Get

        Set(ByVal value As String)
            _regimenFiscalReceptor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando se incluye el complemento de comercio exterior.</remarks>
    ''' </summary>
    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get

        Set(ByVal value As String)
            _numRegIdTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la clave del uso que dará a esta factura el receptor del CFDI.</remarks>
    ''' </summary>
    Public Property UsoCFDI As String
        Get
            Return _usoCFDI
        End Get

        Set(ByVal value As String)
            _usoCFDI = value
        End Set
    End Property
End Class
Public Class Conceptos
    Private _concepto As List(Of Concepto) = New List(Of Concepto)()
    '''<summary>
    ''' <value>Requerido.</value>
    ''' <para>Nodo requerido para expresar la informacion detallada de un bien o servicio amparado en el comprobante.</para>
    ''' </summary>
    Public Property Concepto As List(Of Concepto)
        Get
            Return _concepto
        End Get
        Set(ByVal value As List(Of Concepto))
            _concepto = value
        End Set
    End Property
End Class
Public Class Concepto
    Private _claveProdServ As String = String.Empty
    Private _noIdentificacion As String = String.Empty
    Private _cantidad As Decimal = 0
    Private _claveUnidad As String = String.Empty
    Private _unidad As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _valorUnitario As Decimal = 0
    Private _importe As Decimal = 0
    Private _descuento As Decimal = 0
    Private _objetoImp As String = String.Empty
    Private _impuestos As ImpuestosC = New ImpuestosC()
    Private _aCuentaTercerosC As ACuentaTercerosC
    Private _informacionAduanera As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
    Private _cuentaPredial As List(Of CuentaPredialC) = New List(Of CuentaPredialC)
    Private _complemento As ComplementoConcepto
    Private _parte As List(Of ParteC) = New List(Of ParteC)()

    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Expresa la clave del producto o del servicio amparado por el presente concepto. Se deben utilizar las claves del catalogo de productos y servicios.</remarks>
    ''' </summary>
    Public Property ClaveProdServ As String
        Get
            Return _claveProdServ
        End Get

        Set(ByVal value As String)
            _claveProdServ = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa el número de parte, identificador del producto o del servicio, SKU o equivalente.</remarks>
    ''' </summary>
    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get

        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa la cantidad de bienes o servicios del tipo particular definido por el presente concepto.</remarks>
    ''' </summary>
    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get

        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Se debe utilizar la clave del catalogo de unidades. La unidad debe corresponder con la descripción del concepto.</remarks>
    ''' </summary>
    Public Property ClaveUnidad As String
        Get
            Return _claveUnidad
        End Get

        Set(ByVal value As String)
            _claveUnidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Precisa la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto.</remarks>
    ''' </summary>
    Public Property Unidad As String
        Get
            Return _unidad
        End Get

        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa la descripción del bien o servicio cubierto por el presente concepto.</remarks>
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa el valor o precio unitario del bien o servicio cubierto por el presente concepto.</remarks>
    ''' </summary>
    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get

        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Representa el importe de los descuentos aplicables al concepto. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Descuento As Decimal
        Get
            Return _descuento
        End Get

        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>
    ''' <para>Atributo requerido para expresar si la operación comercial es objeto o no de impuesto.</para>
    ''' </summary>
    Public Property ObjetoImp As String
        Get
            Return _objetoImp
        End Get

        Set(ByVal value As String)
            _objetoImp = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Opcional.</value> 
    ''' <para>Nodo opcional para registrar información del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property ACuentaTerceros As ACuentaTercerosC
        Get
            Return _aCuentaTercerosC
        End Get

        Set(ByVal value As ACuentaTercerosC)
            _aCuentaTercerosC = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para capturar los impuestos aplicables al presente concepto. Cuando un concepto no registra un impuesto, implica que no es objeto del mismo.</remarks>
    ''' </summary>
    Public Property Impuestos As ImpuestosC
        Get
            Return _impuestos
        End Get

        Set(ByVal value As ImpuestosC)
            _impuestos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para introducir la información aduanera cuando se trate de ventas de primera mano de mercancias importadas o se trate de operaciones de comercion exterior con bienes o servicios.</remarks>
    ''' </summary>
    Public Property InformacionAduanera As List(Of InformacionAduaneraC)
        Get
            Return _informacionAduanera
        End Get

        Set(ByVal value As List(Of InformacionAduaneraC))
            _informacionAduanera = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para asentar el número de cuenta predial  con el que fue registrado el inmueble, en el sistema catastra de la entidad federativa de que trate. </remarks>
    ''' </summary>
    Public Property CuentaPredial As List(Of CuentaPredialC)
        Get
            Return _cuentaPredial
        End Get

        Set(ByVal value As List(Of CuentaPredialC))
            _cuentaPredial = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para expresar las partes o componentes que integran la totalidad del concepto expresado en el CFDI.</remarks>
    ''' </summary>
    Public Property Parte As List(Of ParteC)
        Get
            Return _parte
        End Get

        Set(ByVal value As List(Of ParteC))
            _parte = value
        End Set
    End Property

    '************************* Falta agregar la clase ComplementoConcepto *************************************/
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento concepto que permite incorporar a los fabricantes, ensambladores o distribuidores autorizados de automóviles nuevos, así como aquéllos que importen automóviles para permanecer en forma definitiva en la franja fronteriza norte del país y en los Estados de Baja California, Baja California Sur y la región parcial del Estado de Sonora, a un Comprobante Fiscal Digital a través de Internet (CFDI) la clave vehicular que corresponda a la versión enajenada y el número de identificación vehicular que corresponda al vehículo enajenado.</remarks>
    Public Property Complemento As ComplementoConcepto
        Get
            Return _complemento
        End Get
        Set(value As ComplementoConcepto)
            _complemento = value
        End Set
    End Property
End Class
Public Class ACuentaTercerosC
    Private _rfcACuentaTerceros As String = String.Empty
    Private _nombreACuentaTerceros As String = String.Empty
    Private _regimenFiscalACuentaTerceros As String = String.Empty
    Private _domicilioFiscalACuentaTerceros As String = String.Empty
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para registrar la Clave del Registro Federal de Contribuyentes del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property RfcACuentaTerceros As String
        Get
            Return _rfcACuentaTerceros
        End Get
        Set(ByVal value As String)
            _rfcACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Opcional. </value>
    ''' <para>Atributo requerido para registrar el nombre, denominación o razón social del contribuyente Tercero correspondiente con el Rfc, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property NombreACuentaTerceros As String
        Get
            Return _nombreACuentaTerceros
        End Get
        Set(ByVal value As String)
            _nombreACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para incorporar la clave del régimen del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property RegimenFiscalACuentaTerceros As String
        Get
            Return _regimenFiscalACuentaTerceros
        End Get
        Set(ByVal value As String)
            _regimenFiscalACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para incorporar el código postal del domicilio fiscal del Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property DomicilioFiscalACuentaTerceros As String
        Get
            Return _domicilioFiscalACuentaTerceros
        End Get
        Set(ByVal value As String)
            _domicilioFiscalACuentaTerceros = value
        End Set
    End Property
End Class
Public Class ComplementoConcepto

End Class
Public Class ImpuestosC
    Private _traslados As List(Of TrasladoC) = New List(Of TrasladoC)()
    Private _retenciones As List(Of RetencionC) = New List(Of RetencionC)()
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para asentar los impuestos trasladados aplicables al presente concepto.</remarks>
    ''' </summary>
    Public Property Traslados As List(Of TrasladoC)
        Get
            Return _traslados
        End Get

        Set(ByVal value As List(Of TrasladoC))
            _traslados = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    '''  <remarks>Nodo opcional para asentar los impuestos retenidos aplicables al presente concepto.</remarks>
    ''' </summary>
    Public Property Retenciones As List(Of RetencionC)
        Get
            Return _retenciones
        End Get

        Set(ByVal value As List(Of RetencionC))
            _retenciones = value
        End Set
    End Property
End Class
Public Class TrasladoC
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la base para el calculo del impuesto, la determinación de la base se realiza de acuerdo con las disposiciones vigentes. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto traslado aplicable al concepto.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' <remarks>Atributo condicional para señalar el valor de la tasa o cuota del impuesto que se traslada para el presente concepto. Es requerido cuando el atributo TipoFactor tenga una clava que corresponte a TasaOCuota.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para señalar el importe del impuesto trasladado que aplica al concepto. No se permiten valore negativos. Es requerido cuado TipoFactor sea TasaOCuota.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class RetencionC
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la base para el calculo de la retención, la determinación de la base se realiza de acuerdo con las disposiciones fiscales vigentes. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto retenido aplicable al concepto.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' <remarks>Atributo requerido para señalar la tasa o cuota del impuesto que se retiene para el presente concepto.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el importe del impuesto retenido que aplica al concepto. No se permiten valore negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class InformacionAduaneraC
    Private _numeroPedimento As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el número del pedimento que ampara la importación del bien que se expresa en el siguiente formato: últimos 2 dígitos del año de validación seguidos por dos espacios, 2 dígitos de la aduana de despacho seguidos por dos espacios, 4 dígitos del número de la patente seguidos por dos espacios, 1 dígito que corresponde al último dígito del año en curso, salvo que se trate de un pedimento consolidado iniciado en el año inmediato anterior o del pedimento original de una rectificación, seguido de 6 dígitos de la numeración progresiva por aduana.</remarks>
    ''' </summary>
    Public Property NumeroPedimento As String
        Get
            Return _numeroPedimento
        End Get

        Set(ByVal value As String)
            _numeroPedimento = value
        End Set
    End Property
End Class
Public Class CuentaPredialC
    Private _numero As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar el número de la cuenta predial del inmueble cubierto por el presente concepto, o bien para incorporar los datos de identificación del certificado de participación inmobiliaria no amortizable, tratándose de arrendamiento.</remarks>
    ''' </summary>
    Public Property Numero As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property
End Class
Public Class ParteC
    Private _claveProdServ As String = String.Empty
    Private _noIdentificacion As String = String.Empty
    Private _cantidad As Decimal = 0
    Private _unidad As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _valorUnitario As Decimal = 0
    Private _importe As Decimal = 0
    Private _informacionAduanera As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Expresa la clave del producto o del servicio amparado por la presente parte. Es requerido y deben utilizar las claves del cátalogo de productos y servicios, cuando los conceptos que registren por sus actividades corresponden con dichos conceptos.</remarks>
    ''' </summary>
    Public Property ClaveProdServ As String
        Get
            Return _claveProdServ
        End Get

        Set(ByVal value As String)
            _claveProdServ = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa el número de serie, número de parte del bien o identificador del producto o del servicio amparado por la presente parte.</remarks>
    ''' </summary>
    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get

        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por la presente parte.</remarks>
    ''' </summary>
    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get

        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en la parte. La unidad debe corresponder con la descripción de la parte.</remarks>
    ''' </summary>
    Public Property Unidad As String
        Get
            Return _unidad
        End Get

        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte.</remarks>
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get

        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para introducir la información aduanera aplicable cuando se trate de ventas de primera mano de mercancías importadas o se trate de operaciones de comercio exterior con bienes o servicios.</remarks>
    ''' </summary>
    Public Property InformacionAduanera As List(Of InformacionAduaneraC)
        Get
            Return _informacionAduanera
        End Get

        Set(ByVal value As List(Of InformacionAduaneraC))
            _informacionAduanera = value
        End Set
    End Property
End Class
Public Class Impuestos
    Private _totalImpuestosRetenidos As Decimal = 0
    Private _totalImpuestosTrasladados As Decimal = 0
    Private _retenciones As List(Of Retencion) = New List(Of Retencion)()
    Private _traslados As List(Of Traslado) = New List(Of Traslado)()
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar el total de los impuestos retenidos que se desprenden de los conceptos expresados en el comprobante fiscal digital por Internet. No se permiten valores negativos. Es requerido cuando en los conceptos se registren impuestos retenidos.</remarks>
    ''' </summary>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return _totalImpuestosRetenidos
        End Get

        Set(ByVal value As Decimal)
            _totalImpuestosRetenidos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar el total de los impuestos trasladados que se desprenden de los conceptos expresados en el comprobante fiscal digital por Internet. No se permiten valores negativos. Es requerido cuando en los conceptos se registren impuestos trasladados.</remarks>
    ''' </summary>
    Public Property TotalImpuestosTrasladados As Decimal
        Get
            Return _totalImpuestosTrasladados
        End Get

        Set(ByVal value As Decimal)
            _totalImpuestosTrasladados = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para capturar los impuestos retenidos aplicables. Es requerido cuando en los conceptos se registre algún impuesto retenido.</remarks>
    ''' </summary>
    Public Property Retenciones As List(Of Retencion)
        Get
            Return _retenciones
        End Get

        Set(ByVal value As List(Of Retencion))
            _retenciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para capturar los impuestos trasladados aplicables. Es requerido cuando en los conceptos se registre un impuesto trasladado.</remarks>
    ''' </summary>
    Public Property Traslados As List(Of Traslado)
        Get
            Return _traslados
        End Get

        Set(ByVal value As List(Of Traslado))
            _traslados = value
        End Set
    End Property
End Class
Public Class Retencion
    Private _impuesto As String = String.Empty
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto retenido.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el monto del impuesto retenido. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class Traslado
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' <value>Requerido.</value> 
    ''' <para>Atributo requerido para señalar la suma de los atributos Base de los conceptos del impuesto trasladado. No se permiten valores negativos.</para>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto traslado.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el valor de la tasa o cuota del impuesto que se traslada por los conceptos amparados en el comprobante.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la suma del importe del impuesto trasladado, agrupado por impuesto, TipoFactor y TasaOCuota. No se permiten valores negativos.</remarks>  
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class

Public Class Complemento
    Private _timbreFiscalDigital As TimbreFiscalDigital = New TimbreFiscalDigital()
    Private _pagos10 As Pagos10
    Private _pagos20 As Pagos20
    Private _nomina As Nomina
    Private _cartarPorte20 As CartaPorte20
    Private _cartarPorte30 As CartaPorte30
    Public Property TimbreFiscalDigital As TimbreFiscalDigital
        Get
            Return _timbreFiscalDigital
        End Get
        Set(value As TimbreFiscalDigital)
            _timbreFiscalDigital = value
        End Set
    End Property

    Public Property Pagos10 As Pagos10
        Get
            Return _pagos10
        End Get
        Set(value As Pagos10)
            _pagos10 = value
        End Set
    End Property
    Public Property Pagos20 As Pagos20
        Get
            Return _pagos20
        End Get
        Set(value As Pagos20)
            _pagos20 = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI) la información que ampara conceptos de ingresos por salarios, la prestación de un servicio personal subordinado o conceptos asimilados a salarios (Nómina).</remarks>
    Public Property Nomina As Nomina
        Get
            Return _nomina
        End Get
        Set(value As Nomina)
            _nomina = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI), la información relacionada a los bienes y/o mercancías, ubicaciones de origen, puntos intermedios y destinos, así como lo referente al medio por el que se transportan; ya sea por vía terrestre (autotransporte y férrea), marítima y/o aérea; además de incluir el traslado de hidrocarburos y petrolíferos.</remarks>
    Public Property CartaPorte20 As CartaPorte20
        Get
            Return _cartarPorte20
        End Get
        Set(value As CartaPorte20)
            _cartarPorte20 = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI), la información relacionada a los bienes y/o mercancías, ubicaciones de origen, puntos intermedios y destinos, así como lo referente al medio por el que se transportan; ya sea por vía terrestre (autotransporte y férrea), marítima y/o aérea; además de incluir el traslado de hidrocarburos y petrolíferos.</remarks>
    Public Property CartaPorte30 As CartaPorte30
        Get
            Return _cartarPorte30
        End Get
        Set(value As CartaPorte30)
            _cartarPorte30 = value
        End Set
    End Property
End Class
Public Class TimbreFiscalDigital
    Private _version As String = "1.1"
    Private _UUID As String = String.Empty
    Private _fechaTimbrado As DateTime
    Private _rfcProvCertif As String = String.Empty
    Private _leyenda As String = String.Empty
    Private _selloCFD As String = String.Empty
    Private _noCertificadoSAT As String = String.Empty
    Private _selloSAT As String = String.Empty
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para la expresión de la versión del estándar del Timbre Fiscal Digital.</para>
    '''</summary>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para expresar los 36 caracteres del folio fiscal (UUID) de la transacción de timbrado conforme al estándar RFC 4122.</para>
    '''</summary>
    Public Property UUID As String
        Get
            Return _UUID
        End Get
        Set(ByVal value As String)
            _UUID = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para expresar la fecha y hora, de la generación del timbre por la certificación digital del SAT. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora de la Zona Centro del Sistema de Horario en México.</para>
    '''</summary>
    Public Property FechaTimbrado As DateTime
        Get
            Return _fechaTimbrado
        End Get
        Set(ByVal value As DateTime)
            _fechaTimbrado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para expresar el RFC del proveedor de certificación de comprobantes fiscales digitales que genera el timbre fiscal digital.</para>
    '''</summary>
    Public Property RfcProvCertif As String
        Get
            Return _rfcProvCertif
        End Get
        Set(ByVal value As String)
            _rfcProvCertif = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Atributo opcional para registrar información que el SAT comunique a los usuarios del CFDI.</para>
    '''</summary>
    Public Property Leyenda As String
        Get
            Return _leyenda
        End Get
        Set(ByVal value As String)
            _leyenda = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para contener el sello digital del comprobante fiscal o del comprobante de retenciones, que se ha timbrado. El sello debe ser expresado como una cadena de texto en formato Base 64.</para>
    '''</summary>
    Public Property SelloCFD As String
        Get
            Return _selloCFD
        End Get
        Set(ByVal value As String)
            _selloCFD = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para expresar el número de serie del certificado del SAT usado para generar el sello digital del Timbre Fiscal Digital.</para>
    ''' </summary>
    Public Property NoCertificadoSAT As String
        Get
            Return _noCertificadoSAT
        End Get
        Set(ByVal value As String)
            _noCertificadoSAT = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para contener el sello digital del Timbre Fiscal Digital, al que hacen referencia las reglas de la Resolución Miscelánea vigente. El sello debe ser expresado como una cadena de texto en formato Base 64.</para>
    ''' </summary>
    Public Property SelloSAT As String
        Get
            Return _selloSAT
        End Get
        Set(ByVal value As String)
            _selloSAT = value
        End Set
    End Property
End Class
#End Region
#Region "Clase AcuseCancelacion"
Public Class Folios
    Private _UUID As String
    Private _estatusUUID As String
    Public Property UUID As String
        Get
            Return _UUID
        End Get
        Set(ByVal value As String)
            _UUID = value
        End Set
    End Property
    Public Property EstatusUUID As String
        Get
            Return _estatusUUID
        End Get
        Set(ByVal value As String)
            _estatusUUID = value
        End Set
    End Property
End Class
Public Class Acuse
    Private _fecha As DateTime
    Private _rfcEmisor As String = String.Empty
    Private _selloDigitalSat As String = String.Empty
    Private _folios As Folios = New Folios()
    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    Public Property SelloDigitalSAT As String
        Get
            Return _selloDigitalSat
        End Get
        Set(ByVal value As String)
            _selloDigitalSat = value
        End Set
    End Property
    Public Property RfcEmisor As String
        Get
            Return _rfcEmisor
        End Get
        Set(ByVal value As String)
            _rfcEmisor = value
        End Set
    End Property
    Public Property Folios As Folios
        Get
            Return _folios
        End Get
        Set(ByVal value As Folios)
            _folios = value
        End Set
    End Property

End Class
#End Region
#Region "Complementos"
#Region "CartaPorte2.0"
Public Class CartaPorte20
    Private _ubicaciones As CP20Ubicaciones
    Private _mercancias As CP20Mercancias
    Private _figuraTransporte As CP20FiguraTransporte
    Private _version As String
    Private _transpInternac As String
    Private _entradaSalidaMerc As String
    Private _paisOrigenDestino As String
    Private _viaEntradaSalida As String
    Private _totalDistRec As Decimal

    Public Sub New()
        Me._version = "2.0"
    End Sub

    Public Property Ubicaciones As CP20Ubicaciones
        Get
            Return Me._ubicaciones
        End Get
        Set(ByVal value As CP20Ubicaciones)
            Me._ubicaciones = value
        End Set
    End Property

    Public Property Mercancias As CP20Mercancias
        Get
            Return Me._mercancias
        End Get
        Set(ByVal value As CP20Mercancias)
            Me._mercancias = value
        End Set
    End Property

    Public Property FiguraTransporte As CP20FiguraTransporte
        Get
            Return Me._figuraTransporte
        End Get
        Set(ByVal value As CP20FiguraTransporte)
            Me._figuraTransporte = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return Me._version
        End Get
        Set(ByVal value As String)
            Me._version = value
        End Set
    End Property

    Public Property TranspInternac As String
        Get
            Return Me._transpInternac
        End Get
        Set(ByVal value As String)
            Me._transpInternac = value
        End Set
    End Property

    Public Property EntradaSalidaMerc As String
        Get
            Return Me._entradaSalidaMerc
        End Get
        Set(ByVal value As String)
            Me._entradaSalidaMerc = value
        End Set
    End Property

    Public Property PaisOrigenDestino As String
        Get
            Return Me._paisOrigenDestino
        End Get
        Set(ByVal value As String)
            Me._paisOrigenDestino = value
        End Set
    End Property

    Public Property ViaEntradaSalida As String
        Get
            Return Me._viaEntradaSalida
        End Get
        Set(ByVal value As String)
            Me._viaEntradaSalida = value
        End Set
    End Property

    Public Property TotalDistRec As Decimal
        Get
            Return Me._totalDistRec
        End Get
        Set(ByVal value As Decimal)
            Me._totalDistRec = value
        End Set
    End Property
End Class

Partial Public Class CP20Ubicaciones
    Private _ubicacion As List(Of CP20Ubicacion) = New List(Of CP20Ubicacion)()

    Public Property Ubicacion As List(Of CP20Ubicacion)
        Get
            Return Me._ubicacion
        End Get
        Set(ByVal value As List(Of CP20Ubicacion))
            Me._ubicacion = value
        End Set
    End Property
End Class

Partial Public Class CP20Ubicacion
    Private _domicilio As CP20Domicilio
    Private _tipoUbicacion As String
    Private _iDUbicacion As String
    Private _rFCRemitenteDestinatario As String
    Private _nombreRemitenteDestinatario As String
    Private _numRegIdTrib As String
    Private _residenciaFiscal As String
    Private _numEstacion As String
    Private _nombreEstacion As String
    Private _navegacionTrafico As String
    Private _fechaHoraSalidaLlegada As DateTime
    Private _tipoEstacion As String
    Private _distanciaRecorrida As Decimal

    Public Property Domicilio As CP20Domicilio
        Get
            Return Me._domicilio
        End Get
        Set(ByVal value As CP20Domicilio)
            Me._domicilio = value
        End Set
    End Property

    Public Property TipoUbicacion As String
        Get
            Return Me._tipoUbicacion
        End Get
        Set(ByVal value As String)
            Me._tipoUbicacion = value
        End Set
    End Property

    Public Property IDUbicacion As String
        Get
            Return Me._iDUbicacion
        End Get
        Set(ByVal value As String)
            Me._iDUbicacion = value
        End Set
    End Property

    Public Property RFCRemitenteDestinatario As String
        Get
            Return Me._rFCRemitenteDestinatario
        End Get
        Set(ByVal value As String)
            Me._rFCRemitenteDestinatario = value
        End Set
    End Property

    Public Property NombreRemitenteDestinatario As String
        Get
            Return Me._nombreRemitenteDestinatario
        End Get
        Set(ByVal value As String)
            Me._nombreRemitenteDestinatario = value
        End Set
    End Property

    Public Property NumRegIdTrib As String
        Get
            Return Me._numRegIdTrib
        End Get
        Set(ByVal value As String)
            Me._numRegIdTrib = value
        End Set
    End Property

    Public Property ResidenciaFiscal As String
        Get
            Return Me._residenciaFiscal
        End Get
        Set(ByVal value As String)
            Me._residenciaFiscal = value
        End Set
    End Property

    Public Property NumEstacion As String
        Get
            Return Me._numEstacion
        End Get
        Set(ByVal value As String)
            Me._numEstacion = value
        End Set
    End Property

    Public Property NombreEstacion As String
        Get
            Return Me._nombreEstacion
        End Get
        Set(ByVal value As String)
            Me._nombreEstacion = value
        End Set
    End Property

    Public Property NavegacionTrafico As String
        Get
            Return Me._navegacionTrafico
        End Get
        Set(ByVal value As String)
            Me._navegacionTrafico = value
        End Set
    End Property

    Public Property FechaHoraSalidaLlegada As DateTime
        Get
            Return Me._fechaHoraSalidaLlegada
        End Get
        Set(ByVal value As DateTime)
            Me._fechaHoraSalidaLlegada = value
        End Set
    End Property

    Public Property TipoEstacion As String
        Get
            Return Me._tipoEstacion
        End Get
        Set(ByVal value As String)
            Me._tipoEstacion = value
        End Set
    End Property

    Public Property DistanciaRecorrida As Decimal
        Get
            Return Me._distanciaRecorrida
        End Get
        Set(ByVal value As Decimal)
            Me._distanciaRecorrida = value
        End Set
    End Property
End Class

Partial Public Class CP20Domicilio
    Private _calle As String
    Private _numeroExterior As String
    Private _numeroInterior As String
    Private _colonia As String
    Private _localidad As String
    Private _referencia As String
    Private _municipio As String
    Private _estado As String
    Private _pais As String
    Private _codigoPostal As String

    Public Property Calle As String
        Get
            Return Me._calle
        End Get
        Set(ByVal value As String)
            Me._calle = value
        End Set
    End Property

    Public Property NumeroExterior As String
        Get
            Return Me._numeroExterior
        End Get
        Set(ByVal value As String)
            Me._numeroExterior = value
        End Set
    End Property

    Public Property NumeroInterior As String
        Get
            Return Me._numeroInterior
        End Get
        Set(ByVal value As String)
            Me._numeroInterior = value
        End Set
    End Property

    Public Property Colonia As String
        Get
            Return Me._colonia
        End Get
        Set(ByVal value As String)
            Me._colonia = value
        End Set
    End Property

    Public Property Localidad As String
        Get
            Return Me._localidad
        End Get
        Set(ByVal value As String)
            Me._localidad = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return Me._referencia
        End Get
        Set(ByVal value As String)
            Me._referencia = value
        End Set
    End Property

    Public Property Municipio As String
        Get
            Return Me._municipio
        End Get
        Set(ByVal value As String)
            Me._municipio = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return Me._estado
        End Get
        Set(ByVal value As String)
            Me._estado = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return Me._pais
        End Get
        Set(ByVal value As String)
            Me._pais = value
        End Set
    End Property

    Public Property CodigoPostal As String
        Get
            Return Me._codigoPostal
        End Get
        Set(ByVal value As String)
            Me._codigoPostal = value
        End Set
    End Property
End Class

Partial Public Class CP20Mercancias
    Private _mercancia As List(Of CP20Mercancia) = New List(Of CP20Mercancia)()
    Private _autotransporte As CP20Autotransporte
    Private _transporteMaritimo As CP20TransporteMaritimo
    Private _transporteAereo As CP20TransporteAereo
    Private _transporteFerroviario As CP20TransporteFerroviario
    Private _pesoBrutoTotal As Decimal
    Private _unidadPeso As String
    Private _pesoNetoTotal As Decimal
    Private _numTotalMercancias As Integer
    Private _cargoPorTasacion As Decimal

    Public Property Mercancia As List(Of CP20Mercancia)
        Get
            Return Me._mercancia
        End Get
        Set(ByVal value As List(Of CP20Mercancia))
            Me._mercancia = value
        End Set
    End Property

    Public Property Autotransporte As CP20Autotransporte
        Get
            Return Me._autotransporte
        End Get
        Set(ByVal value As CP20Autotransporte)
            Me._autotransporte = value
        End Set
    End Property

    Public Property TransporteMaritimo As CP20TransporteMaritimo
        Get
            Return Me._transporteMaritimo
        End Get
        Set(ByVal value As CP20TransporteMaritimo)
            Me._transporteMaritimo = value
        End Set
    End Property

    Public Property TransporteAereo As CP20TransporteAereo
        Get
            Return Me._transporteAereo
        End Get
        Set(ByVal value As CP20TransporteAereo)
            Me._transporteAereo = value
        End Set
    End Property

    Public Property TransporteFerroviario As CP20TransporteFerroviario
        Get
            Return Me._transporteFerroviario
        End Get
        Set(ByVal value As CP20TransporteFerroviario)
            Me._transporteFerroviario = value
        End Set
    End Property

    Public Property PesoBrutoTotal As Decimal
        Get
            Return Me._pesoBrutoTotal
        End Get
        Set(ByVal value As Decimal)
            Me._pesoBrutoTotal = value
        End Set
    End Property

    Public Property UnidadPeso As String
        Get
            Return Me._unidadPeso
        End Get
        Set(ByVal value As String)
            Me._unidadPeso = value
        End Set
    End Property

    Public Property PesoNetoTotal As Decimal
        Get
            Return Me._pesoNetoTotal
        End Get
        Set(ByVal value As Decimal)
            Me._pesoNetoTotal = value
        End Set
    End Property

    Public Property NumTotalMercancias As Integer
        Get
            Return Me._numTotalMercancias
        End Get
        Set(ByVal value As Integer)
            Me._numTotalMercancias = value
        End Set
    End Property

    Public Property CargoPorTasacion As Decimal
        Get
            Return Me._cargoPorTasacion
        End Get
        Set(ByVal value As Decimal)
            Me._cargoPorTasacion = value
        End Set
    End Property
End Class

Partial Public Class CP20Mercancia
    Private _pedimentos As List(Of CP20Pedimentos) = New List(Of CP20Pedimentos)()
    Private _guiasIdentificacion As List(Of CP20GuiasIdentificacion) = New List(Of CP20GuiasIdentificacion)()
    Private _cantidadTransporta As List(Of CP20CantidadTransporta) = New List(Of CP20CantidadTransporta)()
    Private _detalleMercancia As CP20DetalleMercancia
    Private _bienesTransp As String
    Private _claveSTCC As String
    Private _descripcion As String
    Private _cantidad As Decimal
    Private _claveUnidad As String
    Private _unidad As String
    Private _dimensiones As String
    Private _materialPeligroso As String
    Private _cveMaterialPeligroso As String
    Private _embalaje As String
    Private _descripEmbalaje As String
    Private _pesoEnKg As Decimal
    Private _valorMercancia As Decimal
    Private _moneda As String
    Private _fraccionArancelaria As String
    Private _uUIDComercioExt As String

    Public Property Pedimentos As List(Of CP20Pedimentos)
        Get
            Return Me._pedimentos
        End Get
        Set(ByVal value As List(Of CP20Pedimentos))
            Me._pedimentos = value
        End Set
    End Property

    Public Property GuiasIdentificacion As List(Of CP20GuiasIdentificacion)
        Get
            Return Me._guiasIdentificacion
        End Get
        Set(ByVal value As List(Of CP20GuiasIdentificacion))
            Me._guiasIdentificacion = value
        End Set
    End Property

    Public Property CantidadTransporta As List(Of CP20CantidadTransporta)
        Get
            Return Me._cantidadTransporta
        End Get
        Set(ByVal value As List(Of CP20CantidadTransporta))
            Me._cantidadTransporta = value
        End Set
    End Property

    Public Property DetalleMercancia As CP20DetalleMercancia
        Get
            Return Me._detalleMercancia
        End Get
        Set(ByVal value As CP20DetalleMercancia)
            Me._detalleMercancia = value
        End Set
    End Property

    Public Property BienesTransp As String
        Get
            Return Me._bienesTransp
        End Get
        Set(ByVal value As String)
            Me._bienesTransp = value
        End Set
    End Property

    Public Property ClaveSTCC As String
        Get
            Return Me._claveSTCC
        End Get
        Set(ByVal value As String)
            Me._claveSTCC = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)
            Me._descripcion = value
        End Set
    End Property

    Public Property Cantidad As Decimal
        Get
            Return Me._cantidad
        End Get
        Set(ByVal value As Decimal)
            Me._cantidad = value
        End Set
    End Property

    Public Property ClaveUnidad As String
        Get
            Return Me._claveUnidad
        End Get
        Set(ByVal value As String)
            Me._claveUnidad = value
        End Set
    End Property

    Public Property Unidad As String
        Get
            Return Me._unidad
        End Get
        Set(ByVal value As String)
            Me._unidad = value
        End Set
    End Property

    Public Property Dimensiones As String
        Get
            Return Me._dimensiones
        End Get
        Set(ByVal value As String)
            Me._dimensiones = value
        End Set
    End Property

    Public Property MaterialPeligroso As String
        Get
            Return Me._materialPeligroso
        End Get
        Set(ByVal value As String)
            Me._materialPeligroso = value
        End Set
    End Property

    Public Property CveMaterialPeligroso As String
        Get
            Return Me._cveMaterialPeligroso
        End Get
        Set(ByVal value As String)
            Me._cveMaterialPeligroso = value
        End Set
    End Property

    Public Property Embalaje As String
        Get
            Return Me._embalaje
        End Get
        Set(ByVal value As String)
            Me._embalaje = value
        End Set
    End Property

    Public Property DescripEmbalaje As String
        Get
            Return Me._descripEmbalaje
        End Get
        Set(ByVal value As String)
            Me._descripEmbalaje = value
        End Set
    End Property

    Public Property PesoEnKg As Decimal
        Get
            Return Me._pesoEnKg
        End Get
        Set(ByVal value As Decimal)
            Me._pesoEnKg = value
        End Set
    End Property

    Public Property ValorMercancia As Decimal
        Get
            Return Me._valorMercancia
        End Get
        Set(ByVal value As Decimal)
            Me._valorMercancia = value
        End Set
    End Property

    Public Property Moneda As String
        Get
            Return Me._moneda
        End Get
        Set(ByVal value As String)
            Me._moneda = value
        End Set
    End Property

    Public Property FraccionArancelaria As String
        Get
            Return Me._fraccionArancelaria
        End Get
        Set(ByVal value As String)
            Me._fraccionArancelaria = value
        End Set
    End Property

    Public Property UUIDComercioExt As String
        Get
            Return Me._uUIDComercioExt
        End Get
        Set(ByVal value As String)
            Me._uUIDComercioExt = value
        End Set
    End Property
End Class

Partial Public Class CP20Pedimentos
    Private _pedimento As String

    Public Property Pedimento As String
        Get
            Return Me._pedimento
        End Get
        Set(ByVal value As String)
            Me._pedimento = value
        End Set
    End Property
End Class

Partial Public Class CP20GuiasIdentificacion
    Private _numeroGuiaIdentificacion As String
    Private _descripGuiaIdentificacion As String
    Private _pesoGuiaIdentificacion As Decimal

    Public Property NumeroGuiaIdentificacion As String
        Get
            Return Me._numeroGuiaIdentificacion
        End Get
        Set(ByVal value As String)
            Me._numeroGuiaIdentificacion = value
        End Set
    End Property

    Public Property DescripGuiaIdentificacion As String
        Get
            Return Me._descripGuiaIdentificacion
        End Get
        Set(ByVal value As String)
            Me._descripGuiaIdentificacion = value
        End Set
    End Property

    Public Property PesoGuiaIdentificacion As Decimal
        Get
            Return Me._pesoGuiaIdentificacion
        End Get
        Set(ByVal value As Decimal)
            Me._pesoGuiaIdentificacion = value
        End Set
    End Property
End Class

Partial Public Class CP20CantidadTransporta
    Private _cantidad As Decimal
    Private _iDOrigen As String
    Private _iDDestino As String
    Private _cvesTransporte As String

    Public Property Cantidad As Decimal
        Get
            Return Me._cantidad
        End Get
        Set(ByVal value As Decimal)
            Me._cantidad = value
        End Set
    End Property

    Public Property IDOrigen As String
        Get
            Return Me._iDOrigen
        End Get
        Set(ByVal value As String)
            Me._iDOrigen = value
        End Set
    End Property

    Public Property IDDestino As String
        Get
            Return Me._iDDestino
        End Get
        Set(ByVal value As String)
            Me._iDDestino = value
        End Set
    End Property

    Public Property CvesTransporte As String
        Get
            Return Me._cvesTransporte
        End Get
        Set(ByVal value As String)
            Me._cvesTransporte = value
        End Set
    End Property
End Class

Partial Public Class CP20DetalleMercancia
    Private _unidadPesoMerc As String
    Private _pesoBruto As Decimal
    Private _pesoNeto As Decimal
    Private _pesoTara As Decimal
    Private _numPiezas As Integer

    Public Property UnidadPesoMerc As String
        Get
            Return Me._unidadPesoMerc
        End Get
        Set(ByVal value As String)
            Me._unidadPesoMerc = value
        End Set
    End Property

    Public Property PesoBruto As Decimal
        Get
            Return Me._pesoBruto
        End Get
        Set(ByVal value As Decimal)
            Me._pesoBruto = value
        End Set
    End Property

    Public Property PesoNeto As Decimal
        Get
            Return Me._pesoNeto
        End Get
        Set(ByVal value As Decimal)
            Me._pesoNeto = value
        End Set
    End Property

    Public Property PesoTara As Decimal
        Get
            Return Me._pesoTara
        End Get
        Set(ByVal value As Decimal)
            Me._pesoTara = value
        End Set
    End Property

    Public Property NumPiezas As Integer
        Get
            Return Me._numPiezas
        End Get
        Set(ByVal value As Integer)
            Me._numPiezas = value
        End Set
    End Property
End Class

Partial Public Class CP20Autotransporte
    Private _identificacionVehicular As CP20IdentificacionVehicular
    Private _seguros As CP20Seguros
    Private _remolques As CP20Remolques
    Private _permSCT As String
    Private _numPermisoSCT As String

    Public Property IdentificacionVehicular As CP20IdentificacionVehicular
        Get
            Return Me._identificacionVehicular
        End Get
        Set(ByVal value As CP20IdentificacionVehicular)
            Me._identificacionVehicular = value
        End Set
    End Property

    Public Property Seguros As CP20Seguros
        Get
            Return Me._seguros
        End Get
        Set(ByVal value As CP20Seguros)
            Me._seguros = value
        End Set
    End Property

    Public Property Remolques As CP20Remolques
        Get
            Return Me._remolques
        End Get
        Set(ByVal value As CP20Remolques)
            Me._remolques = value
        End Set
    End Property

    Public Property PermSCT As String
        Get
            Return Me._permSCT
        End Get
        Set(ByVal value As String)
            Me._permSCT = value
        End Set
    End Property

    Public Property NumPermisoSCT As String
        Get
            Return Me._numPermisoSCT
        End Get
        Set(ByVal value As String)
            Me._numPermisoSCT = value
        End Set
    End Property
End Class

Partial Public Class CP20IdentificacionVehicular
    Private _configVehicular As String
    Private _placaVM As String
    Private _anioModeloVM As Integer

    Public Property ConfigVehicular As String
        Get
            Return Me._configVehicular
        End Get
        Set(ByVal value As String)
            Me._configVehicular = value
        End Set
    End Property

    Public Property PlacaVM As String
        Get
            Return Me._placaVM
        End Get
        Set(ByVal value As String)
            Me._placaVM = value
        End Set
    End Property

    Public Property AnioModeloVM As Integer
        Get
            Return Me._anioModeloVM
        End Get
        Set(ByVal value As Integer)
            Me._anioModeloVM = value
        End Set
    End Property
End Class

Partial Public Class CP20Seguros
    Private _aseguraRespCivil As String
    Private _polizaRespCivil As String
    Private _aseguraMedAmbiente As String
    Private _polizaMedAmbiente As String
    Private _aseguraCarga As String
    Private _polizaCarga As String
    Private _primaSeguro As Decimal = -1

    Public Property AseguraRespCivil As String
        Get
            Return Me._aseguraRespCivil
        End Get
        Set(ByVal value As String)
            Me._aseguraRespCivil = value
        End Set
    End Property

    Public Property PolizaRespCivil As String
        Get
            Return Me._polizaRespCivil
        End Get
        Set(ByVal value As String)
            Me._polizaRespCivil = value
        End Set
    End Property

    Public Property AseguraMedAmbiente As String
        Get
            Return Me._aseguraMedAmbiente
        End Get
        Set(ByVal value As String)
            Me._aseguraMedAmbiente = value
        End Set
    End Property

    Public Property PolizaMedAmbiente As String
        Get
            Return Me._polizaMedAmbiente
        End Get
        Set(ByVal value As String)
            Me._polizaMedAmbiente = value
        End Set
    End Property

    Public Property AseguraCarga As String
        Get
            Return Me._aseguraCarga
        End Get
        Set(ByVal value As String)
            Me._aseguraCarga = value
        End Set
    End Property

    Public Property PolizaCarga As String
        Get
            Return Me._polizaCarga
        End Get
        Set(ByVal value As String)
            Me._polizaCarga = value
        End Set
    End Property

    Public Property PrimaSeguro As Decimal
        Get
            Return Me._primaSeguro
        End Get
        Set(ByVal value As Decimal)
            Me._primaSeguro = value
        End Set
    End Property
End Class

Partial Public Class CP20Remolques
    Private _remolque As List(Of CP20Remolque) = New List(Of CP20Remolque)()

    Public Property Remolque As List(Of CP20Remolque)
        Get
            Return Me._remolque
        End Get
        Set(ByVal value As List(Of CP20Remolque))
            Me._remolque = value
        End Set
    End Property
End Class

Partial Public Class CP20Remolque
    Private _subTipoRem As String
    Private _placa As String

    Public Property SubTipoRem As String
        Get
            Return Me._subTipoRem
        End Get
        Set(ByVal value As String)
            Me._subTipoRem = value
        End Set
    End Property

    Public Property Placa As String
        Get
            Return Me._placa
        End Get
        Set(ByVal value As String)
            Me._placa = value
        End Set
    End Property
End Class

Partial Public Class CP20TransporteMaritimo
    Private _contenedor As List(Of CP20Contenedor) = New List(Of CP20Contenedor)()
    Private _permSCT As String
    Private _numPermisoSCT As String
    Private _nombreAseg As String
    Private _numPolizaSeguro As String
    Private _tipoEmbarcacion As String
    Private _matricula As String
    Private _numeroOMI As String
    Private _anioEmbarcacion As Integer
    Private _nombreEmbarc As String
    Private _nacionalidadEmbarc As String
    Private _unidadesDeArqBruto As Decimal
    Private _tipoCarga As String
    Private _numCertITC As String
    Private _eslora As Decimal = -1
    Private _manga As Decimal = -1
    Private _calado As Decimal = -1
    Private _lineaNaviera As String
    Private _nombreAgenteNaviero As String
    Private _numAutorizacionNaviero As String
    Private _numViaje As String
    Private _numConocEmbarc As String

    Public Property Contenedor As List(Of CP20Contenedor)
        Get
            Return Me._contenedor
        End Get
        Set(ByVal value As List(Of CP20Contenedor))
            Me._contenedor = value
        End Set
    End Property

    Public Property PermSCT As String
        Get
            Return Me._permSCT
        End Get
        Set(ByVal value As String)
            Me._permSCT = value
        End Set
    End Property

    Public Property NumPermisoSCT As String
        Get
            Return Me._numPermisoSCT
        End Get
        Set(ByVal value As String)
            Me._numPermisoSCT = value
        End Set
    End Property

    Public Property NombreAseg As String
        Get
            Return Me._nombreAseg
        End Get
        Set(ByVal value As String)
            Me._nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro As String
        Get
            Return Me._numPolizaSeguro
        End Get
        Set(ByVal value As String)
            Me._numPolizaSeguro = value
        End Set
    End Property

    Public Property TipoEmbarcacion As String
        Get
            Return Me._tipoEmbarcacion
        End Get
        Set(ByVal value As String)
            Me._tipoEmbarcacion = value
        End Set
    End Property

    Public Property Matricula As String
        Get
            Return Me._matricula
        End Get
        Set(ByVal value As String)
            Me._matricula = value
        End Set
    End Property

    Public Property NumeroOMI As String
        Get
            Return Me._numeroOMI
        End Get
        Set(ByVal value As String)
            Me._numeroOMI = value
        End Set
    End Property

    Public Property AnioEmbarcacion As Integer
        Get
            Return Me._anioEmbarcacion
        End Get
        Set(ByVal value As Integer)
            Me._anioEmbarcacion = value
        End Set
    End Property

    Public Property NombreEmbarc As String
        Get
            Return Me._nombreEmbarc
        End Get
        Set(ByVal value As String)
            Me._nombreEmbarc = value
        End Set
    End Property

    Public Property NacionalidadEmbarc As String
        Get
            Return Me._nacionalidadEmbarc
        End Get
        Set(ByVal value As String)
            Me._nacionalidadEmbarc = value
        End Set
    End Property

    Public Property UnidadesDeArqBruto As Decimal
        Get
            Return Me._unidadesDeArqBruto
        End Get
        Set(ByVal value As Decimal)
            Me._unidadesDeArqBruto = value
        End Set
    End Property

    Public Property TipoCarga As String
        Get
            Return Me._tipoCarga
        End Get
        Set(ByVal value As String)
            Me._tipoCarga = value
        End Set
    End Property

    Public Property NumCertITC As String
        Get
            Return Me._numCertITC
        End Get
        Set(ByVal value As String)
            Me._numCertITC = value
        End Set
    End Property

    Public Property Eslora As Decimal
        Get
            Return Me._eslora
        End Get
        Set(ByVal value As Decimal)
            Me._eslora = value
        End Set
    End Property

    Public Property Manga As Decimal
        Get
            Return Me._manga
        End Get
        Set(ByVal value As Decimal)
            Me._manga = value
        End Set
    End Property

    Public Property Calado As Decimal
        Get
            Return Me._calado
        End Get
        Set(ByVal value As Decimal)
            Me._calado = value
        End Set
    End Property

    Public Property LineaNaviera As String
        Get
            Return Me._lineaNaviera
        End Get
        Set(ByVal value As String)
            Me._lineaNaviera = value
        End Set
    End Property

    Public Property NombreAgenteNaviero As String
        Get
            Return Me._nombreAgenteNaviero
        End Get
        Set(ByVal value As String)
            Me._nombreAgenteNaviero = value
        End Set
    End Property

    Public Property NumAutorizacionNaviero As String
        Get
            Return Me._numAutorizacionNaviero
        End Get
        Set(ByVal value As String)
            Me._numAutorizacionNaviero = value
        End Set
    End Property

    Public Property NumViaje As String
        Get
            Return Me._numViaje
        End Get
        Set(ByVal value As String)
            Me._numViaje = value
        End Set
    End Property

    Public Property NumConocEmbarc As String
        Get
            Return Me._numConocEmbarc
        End Get
        Set(ByVal value As String)
            Me._numConocEmbarc = value
        End Set
    End Property
End Class

Partial Public Class CP20Contenedor
    Private _matriculaContenedor As String
    Private _tipoContenedor As String
    Private _numPrecinto As String

    Public Property MatriculaContenedor As String
        Get
            Return Me._matriculaContenedor
        End Get
        Set(ByVal value As String)
            Me._matriculaContenedor = value
        End Set
    End Property

    Public Property TipoContenedor As String
        Get
            Return Me._tipoContenedor
        End Get
        Set(ByVal value As String)
            Me._tipoContenedor = value
        End Set
    End Property

    Public Property NumPrecinto As String
        Get
            Return Me._numPrecinto
        End Get
        Set(ByVal value As String)
            Me._numPrecinto = value
        End Set
    End Property
End Class

Partial Public Class CP20TransporteAereo
    Private _permSCT As String
    Private _numPermisoSCT As String
    Private _matriculaAeronave As String
    Private _nombreAseg As String
    Private _numPolizaSeguro As String
    Private _numeroGuia As String
    Private _lugarContrato As String
    Private _codigoTransportista As String
    Private _rFCEmbarcador As String
    Private _numRegIdTribEmbarc As String
    Private _residenciaFiscalEmbarc As String
    Private _nombreEmbarcador As String

    Public Property PermSCT As String
        Get
            Return Me._permSCT
        End Get
        Set(ByVal value As String)
            Me._permSCT = value
        End Set
    End Property

    Public Property NumPermisoSCT As String
        Get
            Return Me._numPermisoSCT
        End Get
        Set(ByVal value As String)
            Me._numPermisoSCT = value
        End Set
    End Property

    Public Property MatriculaAeronave As String
        Get
            Return Me._matriculaAeronave
        End Get
        Set(ByVal value As String)
            Me._matriculaAeronave = value
        End Set
    End Property

    Public Property NombreAseg As String
        Get
            Return Me._nombreAseg
        End Get
        Set(ByVal value As String)
            Me._nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro As String
        Get
            Return Me._numPolizaSeguro
        End Get
        Set(ByVal value As String)
            Me._numPolizaSeguro = value
        End Set
    End Property

    Public Property NumeroGuia As String
        Get
            Return Me._numeroGuia
        End Get
        Set(ByVal value As String)
            Me._numeroGuia = value
        End Set
    End Property

    Public Property LugarContrato As String
        Get
            Return Me._lugarContrato
        End Get
        Set(ByVal value As String)
            Me._lugarContrato = value
        End Set
    End Property

    Public Property CodigoTransportista As String
        Get
            Return Me._codigoTransportista
        End Get
        Set(ByVal value As String)
            Me._codigoTransportista = value
        End Set
    End Property

    Public Property RFCEmbarcador As String
        Get
            Return Me._rFCEmbarcador
        End Get
        Set(ByVal value As String)
            Me._rFCEmbarcador = value
        End Set
    End Property

    Public Property NumRegIdTribEmbarc As String
        Get
            Return Me._numRegIdTribEmbarc
        End Get
        Set(ByVal value As String)
            Me._numRegIdTribEmbarc = value
        End Set
    End Property

    Public Property ResidenciaFiscalEmbarc As String
        Get
            Return Me._residenciaFiscalEmbarc
        End Get
        Set(ByVal value As String)
            Me._residenciaFiscalEmbarc = value
        End Set
    End Property

    Public Property NombreEmbarcador As String
        Get
            Return Me._nombreEmbarcador
        End Get
        Set(ByVal value As String)
            Me._nombreEmbarcador = value
        End Set
    End Property
End Class

Partial Public Class CP20TransporteFerroviario
    Private _derechosDePaso As List(Of CP20DerechosDePaso) = New List(Of CP20DerechosDePaso)()
    Private _carro As List(Of CP20Carro)
    Private _tipoDeServicio As String
    Private _tipoDeTrafico As String
    Private _nombreAseg As String
    Private _numPolizaSeguro As String

    Public Property DerechosDePaso As List(Of CP20DerechosDePaso)
        Get
            Return Me._derechosDePaso
        End Get
        Set(ByVal value As List(Of CP20DerechosDePaso))
            Me._derechosDePaso = value
        End Set
    End Property

    Public Property Carro As List(Of CP20Carro)
        Get
            Return Me._carro
        End Get
        Set(ByVal value As List(Of CP20Carro))
            Me._carro = value
        End Set
    End Property

    Public Property TipoDeServicio As String
        Get
            Return Me._tipoDeServicio
        End Get
        Set(ByVal value As String)
            Me._tipoDeServicio = value
        End Set
    End Property

    Public Property TipoDeTrafico As String
        Get
            Return Me._tipoDeTrafico
        End Get
        Set(ByVal value As String)
            Me._tipoDeTrafico = value
        End Set
    End Property

    Public Property NombreAseg As String
        Get
            Return Me._nombreAseg
        End Get
        Set(ByVal value As String)
            Me._nombreAseg = value
        End Set
    End Property

    Public Property NumPolizaSeguro As String
        Get
            Return Me._numPolizaSeguro
        End Get
        Set(ByVal value As String)
            Me._numPolizaSeguro = value
        End Set
    End Property
End Class

Partial Public Class CP20DerechosDePaso
    Private _tipoDerechoDePaso As String
    Private _kilometrajePagado As Decimal

    Public Property TipoDerechoDePaso As String
        Get
            Return Me._tipoDerechoDePaso
        End Get
        Set(ByVal value As String)
            Me._tipoDerechoDePaso = value
        End Set
    End Property

    Public Property KilometrajePagado As Decimal
        Get
            Return Me._kilometrajePagado
        End Get
        Set(ByVal value As Decimal)
            Me._kilometrajePagado = value
        End Set
    End Property
End Class

Partial Public Class CP20Carro
    Private _contenedor As List(Of CP20CarroContenedor) = New List(Of CP20CarroContenedor)()
    Private _tipoCarro As String
    Private _matriculaCarro As String
    Private _guiaCarro As String
    Private _toneladasNetasCarro As Decimal

    Public Property Contenedor As List(Of CP20CarroContenedor)
        Get
            Return Me._contenedor
        End Get
        Set(ByVal value As List(Of CP20CarroContenedor))
            Me._contenedor = value
        End Set
    End Property

    Public Property TipoCarro As String
        Get
            Return Me._tipoCarro
        End Get
        Set(ByVal value As String)
            Me._tipoCarro = value
        End Set
    End Property

    Public Property MatriculaCarro As String
        Get
            Return Me._matriculaCarro
        End Get
        Set(ByVal value As String)
            Me._matriculaCarro = value
        End Set
    End Property

    Public Property GuiaCarro As String
        Get
            Return Me._guiaCarro
        End Get
        Set(ByVal value As String)
            Me._guiaCarro = value
        End Set
    End Property

    Public Property ToneladasNetasCarro As Decimal
        Get
            Return Me._toneladasNetasCarro
        End Get
        Set(ByVal value As Decimal)
            Me._toneladasNetasCarro = value
        End Set
    End Property
End Class

Partial Public Class CP20CarroContenedor
    Private _tipoContenedor As String
    Private _pesoContenedorVacio As Decimal
    Private _pesoNetoMercancia As Decimal

    Public Property TipoContenedor As String
        Get
            Return Me._tipoContenedor
        End Get
        Set(ByVal value As String)
            Me._tipoContenedor = value
        End Set
    End Property

    Public Property PesoContenedorVacio As Decimal
        Get
            Return Me._pesoContenedorVacio
        End Get
        Set(ByVal value As Decimal)
            Me._pesoContenedorVacio = value
        End Set
    End Property

    Public Property PesoNetoMercancia As Decimal
        Get
            Return Me._pesoNetoMercancia
        End Get
        Set(ByVal value As Decimal)
            Me._pesoNetoMercancia = value
        End Set
    End Property
End Class

Partial Public Class CP20FiguraTransporte
    Private _tiposFigura As List(Of CP20TiposFigura) = New List(Of CP20TiposFigura)()

    Public Property TiposFigura As List(Of CP20TiposFigura)
        Get
            Return Me._tiposFigura
        End Get
        Set(ByVal value As List(Of CP20TiposFigura))
            Me._tiposFigura = value
        End Set
    End Property
End Class

Partial Public Class CP20TiposFigura
    Private _partesTransporte As List(Of CP20PartesTransporte) = New List(Of CP20PartesTransporte)()
    Private _domicilio As CP20Domicilio
    Private _tipoFigura As String
    Private _rFCFigura As String
    Private _numLicencia As String
    Private _nombreFigura As String
    Private _numRegIdTribFigura As String
    Private _residenciaFiscalFigura As String

    Public Property PartesTransporte As List(Of CP20PartesTransporte)
        Get
            Return Me._partesTransporte
        End Get
        Set(ByVal value As List(Of CP20PartesTransporte))
            Me._partesTransporte = value
        End Set
    End Property
    Public Property Domicilio As CP20Domicilio
        Get
            Return Me._domicilio
        End Get
        Set(ByVal value As CP20Domicilio)
            Me._domicilio = value
        End Set
    End Property

    Public Property TipoFigura As String
        Get
            Return Me._tipoFigura
        End Get
        Set(ByVal value As String)
            Me._tipoFigura = value
        End Set
    End Property

    Public Property RFCFigura As String
        Get
            Return Me._rFCFigura
        End Get
        Set(ByVal value As String)
            Me._rFCFigura = value
        End Set
    End Property

    Public Property NumLicencia As String
        Get
            Return Me._numLicencia
        End Get
        Set(ByVal value As String)
            Me._numLicencia = value
        End Set
    End Property

    Public Property NombreFigura As String
        Get
            Return Me._nombreFigura
        End Get
        Set(ByVal value As String)
            Me._nombreFigura = value
        End Set
    End Property

    Public Property NumRegIdTribFigura As String
        Get
            Return Me._numRegIdTribFigura
        End Get
        Set(ByVal value As String)
            Me._numRegIdTribFigura = value
        End Set
    End Property

    Public Property ResidenciaFiscalFigura As String
        Get
            Return Me._residenciaFiscalFigura
        End Get
        Set(ByVal value As String)
            Me._residenciaFiscalFigura = value
        End Set
    End Property
End Class

Partial Public Class CP20PartesTransporte

    Private _parteTransporte As String



    Public Property ParteTransporte As String
        Get
            Return Me._parteTransporte
        End Get
        Set(ByVal value As String)
            Me._parteTransporte = value
        End Set
    End Property
End Class
#End Region
#Region "Pagos 1.0"
Public Class P10Traslado
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>Señalar la clave del tipo de impuesto trasladado.</para>
    '''</summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get
        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para> señalar la clave del tipo de factor que se aplica a la base del impuesto.</para>
    '''</summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get
        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>Señalar el valor de la tasa o cuota del impuesto que se traslada.</para>
    '''</summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>Señalar el importe del impuesto trasladado. No se permiten valores negativos.</para>
    '''</summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class P10Traslados
    Private _traslado As List(Of P10Traslado)
    '''<summary>
    '''<para>Nodo condicional para capturar los impuestos trasladados aplicables.</para> 
    '''</summary>
    Public Property Traslado As List(Of P10Traslado)
        Get
            Return _traslado
        End Get
        Set(ByVal value As List(Of P10Traslado))
            _traslado = value
        End Set
    End Property
End Class
Public Class P10Retencion
    Private _impuesto As String = String.Empty
    Private _importe As Decimal = 0
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>señalar la clave del tipo de impuesto retenido.</para>
    '''</summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get
        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>señalar el importe o monto del impuesto retenido. No se permiten valores negativos.</para>
    '''</summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class P10Retenciones
    Private _pretencion As List(Of P10Retencion)
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>Nodo requerido para registrar la información detallada de una retención de impuesto específico.</para>
    '''</summary>
    Public Property Retencion As List(Of P10Retencion)
        Get
            Return _pretencion
        End Get
        Set(ByVal value As List(Of P10Retencion))
            _pretencion = value
        End Set
    End Property
End Class
Public Class P10Impuestos
    Private _TotalImpuestosRetenidos As Decimal = 0
    Private _TotalImpuestosTrasladados As Decimal = 0
    Private _retenciones As P10Retenciones
    Private _traslados As P10Traslados
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar el total de los impuestos retenidos que se desprenden del pago. No se permiten valores negativos.</para>
    '''</summary>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return _TotalImpuestosRetenidos
        End Get
        Set(ByVal value As Decimal)
            _TotalImpuestosRetenidos = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar el total de los impuestos trasladados que se desprenden del pago. No se permiten valores negativos.</para>
    '''</summary>
    Public Property TotalImpuestosTrasladados As Decimal
        Get
            Return _TotalImpuestosTrasladados
        End Get
        Set(ByVal value As Decimal)
            _TotalImpuestosTrasladados = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Nodo condicional para capturar los impuestos retenidos aplicables.</para>
    '''</summary>
    Public Property Retenciones As P10Retenciones
        Get
            Return _retenciones
        End Get
        Set(ByVal value As P10Retenciones)
            _retenciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Nodo condicional para capturar los impuestos trasladados aplicables.</para>
    '''</summary>
    Public Property Traslados As P10Traslados
        Get
            Return _traslados
        End Get
        Set(ByVal value As P10Traslados)
            _traslados = value
        End Set
    End Property
End Class
Public Class P10DoctoRelacionado
    Private _idDocumento As String = String.Empty
    Private _serie As String = String.Empty
    Private _folio As String = String.Empty
    Private _monedaDR As String = String.Empty
    Private _tipoCambioDR As Decimal = 0
    Private _metodoDePagoDR As String = String.Empty
    Private _numParcialidad As String = String.Empty
    Private _impSaldoAnt As Decimal = 0
    Private _impPagado As Decimal = 0
    Private _impSaldoInsoluto As Decimal = 0
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>expresar el identificador del documento relacionado con el pago. Este dato puede ser un Folio Fiscal de la Factura Electrónica o bien el número de operación de un documento digital.</para>
    '''</summary>
    Public Property IdDocumento As String
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As String)
            _idDocumento = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> precisar la serie del comprobante para control interno del contribuyente, acepta una cadena de caracteres.</para>
    '''</summary>
    Public Property Serie As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>precisar el folio del comprobante para control interno del contribuyente, acepta una cadena de caracteres.   </para>
    '''</summary>
    Public Property Folio As String
        Get
            Return _folio
        End Get
        Set(ByVal value As String)
            _folio = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> identificar la clave de la moneda utilizada en los importes del documento relacionado, cuando se usa moneda nacional o el documento relacionado no especifica la moneda se registra MXN. Los importes registrados en los atributos “ImpSaldoAnt”, “ImpPagado” e “ImpSaldoInsoluto” de éste nodo, deben corresponder a esta moneda. Conforme con la especificación ISO 4217. </para>
    '''</summary>
    Public Property MonedaDR As String
        Get
            Return _monedaDR
        End Get
        Set(ByVal value As String)
            _monedaDR = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el tipo de cambio conforme con la moneda registrada en el documento relacionado. Es requerido cuando la moneda del documento relacionado es distinta de la moneda de pago. Se debe registrar el número de unidades de la moneda señalada en el documento relacionado que equivalen a una unidad de la moneda del pago. Por ejemplo: El documento relacionado se registra en USD El pago se realiza por 100 EUR. Este atributo se registra como 1.114700 USD/EUR. El importe pagado equivale a 100 EUR * 1.114700 USD/EUR = 111.47 USD.</para>
    '''</summary>
    Public Property TipoCambioDR As Decimal
        Get
            Return _tipoCambioDR
        End Get
        Set(ByVal value As Decimal)
            _tipoCambioDR = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar la clave del método de pago que se registró en el documento relacionado.</para>   
    '''</summary>
    Public Property MetodoDePagoDR As String
        Get
            Return _metodoDePagoDR
        End Get
        Set(ByVal value As String)
            _metodoDePagoDR = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el número de parcialidad que corresponde al pago. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.</para>
    '''</summary>
    Public Property NumParcialidad As String
        Get
            Return _numParcialidad
        End Get
        Set(ByVal value As String)
            _numParcialidad = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el monto del saldo insoluto de la parcialidad anterior. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.En el caso de que sea la primer parcialidad este campo debe contener el importe total del documento relacionado.</para>  
    '''</summary>
    Public Property ImpSaldoAnt As Decimal
        Get
            Return _impSaldoAnt
        End Get
        Set(ByVal value As Decimal)
            _impSaldoAnt = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> expresar el importe pagado para el documento relacionado. Es obligatorio cuando exista más de un documento relacionado o cuando existe un documento relacionado y el TipoCambioDR tiene un valor.</para>  
    '''</summary>
    Public Property ImpPagado As Decimal
        Get
            Return _impPagado
        End Get
        Set(ByVal value As Decimal)
            _impPagado = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar la diferencia entre el importe del saldo anterior y el monto del pago. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.</para> 
    '''</summary>
    Public Property ImpSaldoInsoluto As Decimal
        Get
            Return _impSaldoInsoluto
        End Get
        Set(ByVal value As Decimal)
            _impSaldoInsoluto = value
        End Set
    End Property
End Class
Public Class P10Pago
    Private _fechaPago As DateTime
    Private _formaDePagoP As String = String.Empty
    Private _monedaP As String = String.Empty
    Private _tipoCambioP As Decimal = 0
    Private _monto As Decimal = 0
    Private _numOperacion As String = String.Empty
    Private _rfcEmisorCtaOrd As String = String.Empty
    Private _nomBancoOrdExt As String = String.Empty
    Private _ctaOrdenante As String = String.Empty
    Private _rfcEmisorCtaBen As String = String.Empty
    Private _ctaBeneficiario As String = String.Empty
    Private _tipoCadPago As String = String.Empty
    Private _certPago As String = String.Empty
    Private _cadPago As String = String.Empty
    Private _selloPago As String = String.Empty
    Private _doctoRelacionado As List(Of P10DoctoRelacionado)
    Private _impuestos As List(Of P10Impuestos)
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar la fecha y hora en la que el beneficiario recibe el pago. Se expresa en la forma aaaa-mm-ddThh:mm:ss, de acuerdo con la especificación ISO 8601.En caso de no contar con la hora se debe registrar 12:00:00.</para>
    '''</summary>
    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As DateTime)
            _fechaPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar la clave de la forma en que se realiza el pago.</para> 
    '''</summary>
    Public Property FormaDePagoP As String
        Get
            Return _formaDePagoP
        End Get
        Set(ByVal value As String)
            _formaDePagoP = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Identificar la clave de la moneda utilizada para realizar el pago, cuando se usa moneda nacional se registra MXN. El atributo Pagos:Pago:Monto y los atributos TotalImpuestosRetenidos, TotalImpuestosTrasladados, Traslados:Traslado:Importe y Retenciones:Retencion:Importe del nodo Pago:Impuestos deben ser expresados en esta moneda. Conforme con la especificación ISO 4217.</para> 
    '''</summary>
    Public Property MonedaP As String
        Get
            Return _monedaP
        End Get
        Set(ByVal value As String)
            _monedaP = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value> 
    '''<para>expresar el tipo de cambio de la moneda a la fecha en que se realizó el pago. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo MonedaP. Es requerido cuando el atributo MonedaP es diferente a MXN.</para> 
    '''</summary>
    Public Property TipoCambioP As Decimal
        Get
            Return _tipoCambioP
        End Get
        Set(ByVal value As Decimal)
            _tipoCambioP = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el importe del pago. </para> 
    '''</summary>
    Public Property Monto As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> expresar el número de cheque, número de autorización, número de referencia, clave de rastreo en caso de ser SPEI, línea de captura o algún número de referencia análogo que identifique la operación que ampara el pago efectuado.</para> 
    '''</summary>
    Public Property NumOperacion As String
        Get
            Return _numOperacion
        End Get
        Set(ByVal value As String)
            _numOperacion = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar la clave RFC de la entidad emisora de la cuenta origen, es decir, la operadora, el banco, la institución financiera, emisor de monedero electrónico, etc., en caso de ser extranjero colocar XEXX010101000, considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.</para> 
    '''</summary>
    Public Property RfcEmisorCtaOrd As String
        Get
            Return _rfcEmisorCtaOrd
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaOrd = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el nombre del banco ordenante, es requerido en caso de ser extranjero. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.</para> 
    '''</summary>
    Public Property NomBancoOrdExt As String
        Get
            Return _nomBancoOrdExt
        End Get
        Set(ByVal value As String)
            _nomBancoOrdExt = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> incorporar el número de la cuenta con la que se realizó el pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago</para> 
    '''</summary>
    Public Property CtaOrdenante As String
        Get
            Return _ctaOrdenante
        End Get
        Set(ByVal value As String)
            _ctaOrdenante = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar la clave RFC de la entidad operadora de la cuenta destino, es decir, la operadora, el banco, la institución financiera, emisor de monedero electrónico, etc. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.</para> 
    '''</summary>
    Public Property RfcEmisorCtaBen As String
        Get
            Return _rfcEmisorCtaBen
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaBen = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>incorporar el número de cuenta en donde se recibió el pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.</para>   
    '''</summary>
    Public Property CtaBeneficiario As String
        Get
            Return _ctaBeneficiario
        End Get
        Set(ByVal value As String)
            _ctaBeneficiario = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> identificar la clave del tipo de cadena de pago que genera la entidad receptora del pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.</para> 
    '''</summary>
    Public Property TipoCadPago As String
        Get
            Return _tipoCadPago
        End Get
        Set(ByVal value As String)
            _tipoCadPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Incorporar el certificado que ampara al pago, como una cadena de texto en formato base 64. Es requerido en caso de que el atributo TipoCadPago contenga información.</para> 
    '''</summary>
    Public Property CertPago As String
        Get
            Return _certPago
        End Get
        Set(ByVal value As String)
            _certPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar la cadena original del comprobante de pago generado por la entidad emisora de la cuenta beneficiaria. Es requerido en caso de que el atributo TipoCadPago contenga información.</para> 
    '''</summary>
    Public Property CadPago As String
        Get
            Return _cadPago
        End Get
        Set(ByVal value As String)
            _cadPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Integrar el sello digital que se asocie al pago. La entidad que emite el comprobante de pago, ingresa una cadena original y el sello digital en una sección de dicho comprobante, este sello digital es el que se debe registrar en este campo. Debe ser expresado como una cadena de texto en formato base 64. Es requerido en caso de que el atributo TipoCadPago contenga información.</para> 
    '''</summary>
    Public Property SelloPago As String
        Get
            Return _selloPago
        End Get
        Set(ByVal value As String)
            _selloPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>DoctoRelacionado (0, Ilimitado)  Impuestos (0, Ilimitado)</para> 
    '''</summary>
    Public Property DoctoRelacionado As List(Of P10DoctoRelacionado)
        Get
            Return _doctoRelacionado
        End Get
        Set(ByVal value As List(Of P10DoctoRelacionado))
            _doctoRelacionado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Nodo condicional para expresar el resumen de los impuestos aplicables cuando este documento sea un anticipo.</para> 
    '''</summary>
    Public Property Impuestos As List(Of P10Impuestos)
        Get
            Return _impuestos
        End Get
        Set(ByVal value As List(Of P10Impuestos))
            _impuestos = value
        End Set
    End Property
End Class
Public Class Pagos10
    Private _version As String = "1.0"
    Private _pago As List(Of P10Pago) = New List(Of P10Pago)()
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Indica la versión del complemento para recepción de pagos.</para> 
    '''</summary>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Indica la versión del complemento para recepción de pagos.</para> 
    '''</summary>
    Public Property Pago As List(Of P10Pago)
        Get
            Return _pago
        End Get
        Set(ByVal value As List(Of P10Pago))
            _pago = value
        End Set
    End Property
End Class
#End Region
#Region "Pagos 2.0"
#Region "Complemento Pagos 2.0"
Public Class Pagos20
    Private _totales As P20Totales = New P20Totales()
    Private _pago As List(Of P20Pago) = New List(Of P20Pago)()
    Private _version As String = "2.0"

    Public Property Totales As P20Totales
        Get
            Return _totales
        End Get
        Set(ByVal value As P20Totales)
            _totales = value
        End Set
    End Property

    Public Property Pago As List(Of P20Pago)
        Get
            Return _pago
        End Get
        Set(ByVal value As List(Of P20Pago))
            _pago = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
End Class
Public Class P20Totales
    Private _totalRetencionesIVA As Decimal = 0D
    Private _totalRetencionesISR As Decimal = 0D
    Private _totalRetencionesIEPS As Decimal = 0D
    Private _totalTrasladosBaseIVA16 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA16 As Decimal = 0D
    Private _totalTrasladosBaseIVA8 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA8 As Decimal = 0D
    Private _totalTrasladosBaseIVA0 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA0 As Decimal = 0D
    Private _totalTrasladosBaseIVAExento As Decimal = 0D
    Private _montoTotalPagos As Decimal = 0D

    Public Property TotalRetencionesIVA As Decimal
        Get
            Return _totalRetencionesIVA
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesIVA = value
        End Set
    End Property

    Public Property TotalRetencionesISR As Decimal
        Get
            Return _totalRetencionesISR
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesISR = value
        End Set
    End Property

    Public Property TotalRetencionesIEPS As Decimal
        Get
            Return _totalRetencionesIEPS
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesIEPS = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA16 As Decimal
        Get
            Return _totalTrasladosBaseIVA16
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA16 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA16 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA16
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA16 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA8 As Decimal
        Get
            Return _totalTrasladosBaseIVA8
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA8 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA8 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA8
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA8 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA0 As Decimal
        Get
            Return _totalTrasladosBaseIVA0
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA0 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA0 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA0
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA0 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVAExento As Decimal
        Get
            Return _totalTrasladosBaseIVAExento
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVAExento = value
        End Set
    End Property

    Public Property MontoTotalPagos As Decimal
        Get
            Return _montoTotalPagos
        End Get
        Set(ByVal value As Decimal)
            _montoTotalPagos = value
        End Set
    End Property
End Class
Public Class P20Pago
    Private _fechaPago As DateTime
    Private _formaDePagoP As String = String.Empty
    Private _monedaP As String = String.Empty
    Private _tipoCambioP As Decimal = 0
    Private _monto As Decimal = 0
    Private _numOperacion As String = String.Empty
    Private _rfcEmisorCtaOrd As String = String.Empty
    Private _nomBancoOrdExt As String = String.Empty
    Private _ctaOrdenante As String = String.Empty
    Private _rfcEmisorCtaBen As String = String.Empty
    Private _ctaBeneficiario As String = String.Empty
    Private _tipoCadPago As String = String.Empty
    Private _certPago As String = String.Empty
    Private _cadPago As String = String.Empty
    Private _selloPago As String = String.Empty
    Private _doctoRelacionado As List(Of P20DoctoRelacionado) = New List(Of P20DoctoRelacionado)()
    Private _impuestos As P20Impuestos

    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As DateTime)
            _fechaPago = value
        End Set
    End Property

    Public Property FormaDePagoP As String
        Get
            Return _formaDePagoP
        End Get
        Set(ByVal value As String)
            _formaDePagoP = value
        End Set
    End Property

    Public Property MonedaP As String
        Get
            Return _monedaP
        End Get
        Set(ByVal value As String)
            _monedaP = value
        End Set
    End Property

    Public Property TipoCambioP As Decimal
        Get
            Return _tipoCambioP
        End Get
        Set(ByVal value As Decimal)
            _tipoCambioP = value
        End Set
    End Property

    Public Property Monto As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property

    Public Property NumOperacion As String
        Get
            Return _numOperacion
        End Get
        Set(ByVal value As String)
            _numOperacion = value
        End Set
    End Property

    Public Property RfcEmisorCtaOrd As String
        Get
            Return _rfcEmisorCtaOrd
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaOrd = value
        End Set
    End Property

    Public Property NomBancoOrdExt As String
        Get
            Return _nomBancoOrdExt
        End Get
        Set(ByVal value As String)
            _nomBancoOrdExt = value
        End Set
    End Property

    Public Property CtaOrdenante As String
        Get
            Return _ctaOrdenante
        End Get
        Set(ByVal value As String)
            _ctaOrdenante = value
        End Set
    End Property

    Public Property RfcEmisorCtaBen As String
        Get
            Return _rfcEmisorCtaBen
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaBen = value
        End Set
    End Property

    Public Property CtaBeneficiario As String
        Get
            Return _ctaBeneficiario
        End Get
        Set(ByVal value As String)
            _ctaBeneficiario = value
        End Set
    End Property

    Public Property TipoCadPago As String
        Get
            Return _tipoCadPago
        End Get
        Set(ByVal value As String)
            _tipoCadPago = value
        End Set
    End Property

    Public Property CertPago As String
        Get
            Return _certPago
        End Get
        Set(ByVal value As String)
            _certPago = value
        End Set
    End Property

    Public Property CadPago As String
        Get
            Return _cadPago
        End Get
        Set(ByVal value As String)
            _cadPago = value
        End Set
    End Property

    Public Property SelloPago As String
        Get
            Return _selloPago
        End Get
        Set(ByVal value As String)
            _selloPago = value
        End Set
    End Property

    Public Property DoctoRelacionado As List(Of P20DoctoRelacionado)
        Get
            Return _doctoRelacionado
        End Get
        Set(ByVal value As List(Of P20DoctoRelacionado))
            _doctoRelacionado = value
        End Set
    End Property

    Public Property Impuestos As P20Impuestos
        Get
            Return _impuestos
        End Get
        Set(ByVal value As P20Impuestos)
            _impuestos = value
        End Set
    End Property
End Class
Public Class P20DoctoRelacionado
    Private _idDocumento As String = String.Empty
    Private _serie As String = String.Empty
    Private _folio As String = String.Empty
    Private _monedaDR As String = String.Empty
    Private _equivalenciaDR As Decimal = 0
    Private _numParcialidad As String = String.Empty
    Private _impSaldoAnt As Decimal = 0
    Private _impPagado As Decimal = 0
    Private _impSaldoInsoluto As Decimal = 0
    Private _objetoImpDR As String = String.Empty
    Private _impuestosDR As P20ImpuestosDR

    Public Property IdDocumento As String
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As String)
            _idDocumento = value
        End Set
    End Property

    Public Property Serie As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property

    Public Property Folio As String
        Get
            Return _folio
        End Get
        Set(ByVal value As String)
            _folio = value
        End Set
    End Property

    Public Property MonedaDR As String
        Get
            Return _monedaDR
        End Get
        Set(ByVal value As String)
            _monedaDR = value
        End Set
    End Property

    Public Property EquivalenciaDR As Decimal
        Get
            Return _equivalenciaDR
        End Get
        Set(ByVal value As Decimal)
            _equivalenciaDR = value
        End Set
    End Property

    Public Property NumParcialidad As String
        Get
            Return _numParcialidad
        End Get
        Set(ByVal value As String)
            _numParcialidad = value
        End Set
    End Property

    Public Property ImpSaldoAnt As Decimal
        Get
            Return _impSaldoAnt
        End Get
        Set(ByVal value As Decimal)
            _impSaldoAnt = value
        End Set
    End Property

    Public Property ImpPagado As Decimal
        Get
            Return _impPagado
        End Get
        Set(ByVal value As Decimal)
            _impPagado = value
        End Set
    End Property

    Public Property ImpSaldoInsoluto As Decimal
        Get
            Return _impSaldoInsoluto
        End Get
        Set(ByVal value As Decimal)
            _impSaldoInsoluto = value
        End Set
    End Property

    Public Property ObjetoImpDR As String
        Get
            Return _objetoImpDR
        End Get
        Set(ByVal value As String)
            _objetoImpDR = value
        End Set
    End Property

    Public Property ImpuestosDR As P20ImpuestosDR
        Get
            Return _impuestosDR
        End Get
        Set(ByVal value As P20ImpuestosDR)
            _impuestosDR = value
        End Set
    End Property
End Class
Public Class P20ImpuestosDR
    Private _retencionesDR As P20RetencionesDR
    Private _trasladosDR As P20TrasladosDR

    Public Property RetencionesDR As P20RetencionesDR
        Get
            Return _retencionesDR
        End Get
        Set(ByVal value As P20RetencionesDR)
            _retencionesDR = value
        End Set
    End Property

    Public Property TrasladosDR As P20TrasladosDR
        Get
            Return _trasladosDR
        End Get
        Set(ByVal value As P20TrasladosDR)
            _trasladosDR = value
        End Set
    End Property
End Class
Public Class P20RetencionesDR
    Private _retencionDR As List(Of P20RetencionDR)

    Public Property RetencionDR As List(Of P20RetencionDR)
        Get
            Return _retencionDR
        End Get
        Set(ByVal value As List(Of P20RetencionDR))
            _retencionDR = value
        End Set
    End Property
End Class
Public Class P20RetencionDR
    Private _baseDR As Decimal = 0
    Private _impuestoDR As String = String.Empty
    Private _tipoFactorDR As String = String.Empty
    Private _tasaOCuotaDR As Decimal = 0
    Private _importeDR As Decimal = 0

    Public Property BaseDR As Decimal
        Get
            Return _baseDR
        End Get
        Set(ByVal value As Decimal)
            _baseDR = value
        End Set
    End Property

    Public Property ImpuestoDR As String
        Get
            Return _impuestoDR
        End Get
        Set(ByVal value As String)
            _impuestoDR = value
        End Set
    End Property

    Public Property TipoFactorDR As String
        Get
            Return _tipoFactorDR
        End Get
        Set(ByVal value As String)
            _tipoFactorDR = value
        End Set
    End Property

    Public Property TasaOCuotaDR As Decimal
        Get
            Return _tasaOCuotaDR
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaDR = value
        End Set
    End Property

    Public Property ImporteDR As Decimal
        Get
            Return _importeDR
        End Get
        Set(ByVal value As Decimal)
            _importeDR = value
        End Set
    End Property
End Class
Public Class P20TrasladosDR
    Private _trasladoDR As List(Of P20TrasladoDR)

    Public Property TrasladoDR As List(Of P20TrasladoDR)
        Get
            Return _trasladoDR
        End Get
        Set(ByVal value As List(Of P20TrasladoDR))
            _trasladoDR = value
        End Set
    End Property
End Class
Public Class P20TrasladoDR
    Private _baseDR As Decimal = 0
    Private _impuestoDR As String = String.Empty
    Private _tipoFactorDR As String = String.Empty
    Private _tasaOCuotaDR As Decimal = 0
    Private _importeDR As Decimal = 0

    Public Property BaseDR As Decimal
        Get
            Return _baseDR
        End Get
        Set(ByVal value As Decimal)
            _baseDR = value
        End Set
    End Property

    Public Property ImpuestoDR As String
        Get
            Return _impuestoDR
        End Get
        Set(ByVal value As String)
            _impuestoDR = value
        End Set
    End Property

    Public Property TipoFactorDR As String
        Get
            Return _tipoFactorDR
        End Get
        Set(ByVal value As String)
            _tipoFactorDR = value
        End Set
    End Property

    Public Property TasaOCuotaDR As Decimal
        Get
            Return _tasaOCuotaDR
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaDR = value
        End Set
    End Property

    Public Property ImporteDR As Decimal
        Get
            Return _importeDR
        End Get
        Set(ByVal value As Decimal)
            _importeDR = value
        End Set
    End Property
End Class
Public Class P20Impuestos
    Private _retencionesP As P20Retenciones
    Private _trasladosP As P20Traslados

    Public Property RetencionesP As P20Retenciones
        Get
            Return _retencionesP
        End Get
        Set(ByVal value As P20Retenciones)
            _retencionesP = value
        End Set
    End Property

    Public Property TrasladosP As P20Traslados
        Get
            Return _trasladosP
        End Get
        Set(ByVal value As P20Traslados)
            _trasladosP = value
        End Set
    End Property
End Class
Public Class P20Retenciones
    Private _retencionP As List(Of P20Retencion) = New List(Of P20Retencion)()

    Public Property RetencionP As List(Of P20Retencion)
        Get
            Return _retencionP
        End Get
        Set(ByVal value As List(Of P20Retencion))
            _retencionP = value
        End Set
    End Property
End Class
Public Class P20Traslados
    Private _trasladoP As List(Of P20Traslado)

    Public Property TrasladoP As List(Of P20Traslado)
        Get
            Return _trasladoP
        End Get
        Set(ByVal value As List(Of P20Traslado))
            _trasladoP = value
        End Set
    End Property
End Class
Public Class P20Retencion
    Private _impuestoP As String = String.Empty
    Private _importeP As Decimal = 0

    Public Property ImpuestoP As String
        Get
            Return _impuestoP
        End Get
        Set(ByVal value As String)
            _impuestoP = value
        End Set
    End Property

    Public Property ImporteP As Decimal
        Get
            Return _importeP
        End Get
        Set(ByVal value As Decimal)
            _importeP = value
        End Set
    End Property
End Class
Public Class P20Traslado
    Private _baseP As Decimal = 0
    Private _impuestoP As String = String.Empty
    Private _tipoFactorP As String = String.Empty
    Private _tasaOCuotaP As Decimal = 0
    Private _importeP As Decimal = 0

    Public Property BaseP As Decimal
        Get
            Return _baseP
        End Get
        Set(ByVal value As Decimal)
            _baseP = value
        End Set
    End Property

    Public Property ImpuestoP As String
        Get
            Return _impuestoP
        End Get
        Set(ByVal value As String)
            _impuestoP = value
        End Set
    End Property

    Public Property TipoFactorP As String
        Get
            Return _tipoFactorP
        End Get
        Set(ByVal value As String)
            _tipoFactorP = value
        End Set
    End Property

    Public Property TasaOCuotaP As Decimal
        Get
            Return _tasaOCuotaP
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaP = value
        End Set
    End Property

    Public Property ImporteP As Decimal
        Get
            Return _importeP
        End Get
        Set(ByVal value As Decimal)
            _importeP = value
        End Set
    End Property
End Class

#End Region
#End Region
#Region "Nomina 1.2"
#Region "Clase Nomina"
Public Class Nomina
    Private _version As String = "1.2"
    Private _tipoNomina As String = String.Empty
    Private _fechaPago As DateTime
    Private _fechaInicialPago As DateTime
    Private _fechaFinalPago As DateTime
    Private _numDiasPagados As Decimal = 0
    Private _totalPercepciones As Decimal = 0
    Private _totalDeducciones As Decimal = 0
    Private _totalOtrosPagos As Decimal = 0
    Private _emisor As NEmisor
    Private _receptor As NReceptor
    Private _percepciones As NPercepciones
    Private _deducciones As NDeducciones
    Private _otrosPagos As NOtrosPagos
    Private _incapacidades As NIncapacidades
    Private _horasExtra As List(Of NHorasExtra)
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para la expresión de la versión del complemento. Valor prefijado a 1.2. </para>
    '''</summary>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para indicar el tipo de nómina, puede ser O= Nómina ordinaria o E= Nómina extraordinaria. </para>
    '''</summary>
    Public Property TipoNomina As String
        Get
            Return _tipoNomina
        End Get
        Set(ByVal value As String)
            _tipoNomina = value
        End Set
    End Property
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para la expresión de la fecha efectiva de erogación del gasto. Se expresa en la forma aaaa-mm-dd.</para>
    '''</summary>
    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As DateTime)
            _fechaPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para la expresión de la fecha efectiva de erogación del gasto. Se expresa en la forma aaaa-mm-dd.</para>
    '''</summary>
    Public Property FechaInicialPago As DateTime
        Get
            Return _fechaInicialPago
        End Get
        Set(ByVal value As DateTime)
            _fechaInicialPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para la expresión de la fecha final del período de pago. Se expresa en la forma aaaa-mm-dd.</para>
    ''' </summary>
    Public Property FechaFinalPago As DateTime
        Get
            Return _fechaFinalPago
        End Get
        Set(ByVal value As DateTime)
            _fechaFinalPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Obligatorio.</value>
    '''<para> Atributo requerido para la expresión del número o la fracción de días pagados. Posiciones decimales 3</para>
    '''</summary>
    Public Property NumDiasPagados As Decimal
        Get
            Return _numDiasPagados
        End Get
        Set(ByVal value As Decimal)
            _numDiasPagados = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para> Atributo condicional para representar la suma de las percepciones.</para>
    '''</summary>
    Public Property TotalPercepciones As Decimal
        Get
            Return _totalPercepciones
        End Get
        Set(ByVal value As Decimal)
            _totalPercepciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para> Atributo condicional para representar la suma de las deducciones aplicables.</para>
    '''</summary>
    Public Property TotalDeducciones As Decimal
        Get
            Return _totalDeducciones
        End Get
        Set(ByVal value As Decimal)
            _totalDeducciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para> Atributo condicional para representar la suma de otros pagos.</para>
    '''</summary>
    Public Property TotalOtrosPagos As Decimal
        Get
            Return _totalOtrosPagos
        End Get
        Set(ByVal value As Decimal)
            _totalOtrosPagos = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para> Nodo condicional para expresar la información del contribuyente emisor del comprobante de nómina.</para>
    '''</summary>
    Public Property Emisor As NEmisor
        Get
            Return _emisor
        End Get
        Set(ByVal value As NEmisor)
            _emisor = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido.</value>
    '''<para>Nodo requerido para precisar la información del contribuyente receptor del comprobante de nómina.</para>
    '''</summary>
    Public Property Receptor As NReceptor
        Get
            Return _receptor
        End Get
        Set(ByVal value As NReceptor)
            _receptor = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Nodo condicional para expresar las percepciones aplicables.</para>
    '''</summary>
    Public Property Percepciones As NPercepciones
        Get
            Return _percepciones
        End Get
        Set(ByVal value As NPercepciones)
            _percepciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Nodo condicional para expresar las deducciones aplicables.</para>
    '''</summary>
    Public Property Deducciones As NDeducciones
        Get
            Return _deducciones
        End Get
        Set(ByVal value As NDeducciones)
            _deducciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Nodo condicional para expresar otros pagos aplicables.</para>
    '''</summary>
    Public Property OtrosPagos As NOtrosPagos
        Get
            Return _otrosPagos
        End Get
        Set(ByVal value As NOtrosPagos)
            _otrosPagos = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Nodo condicional para expresar información de las incapacidades.</para>
    '''</summary>
    Public Property Incapacidades As NIncapacidades
        Get
            Return _incapacidades
        End Get
        Set(ByVal value As NIncapacidades)
            _incapacidades = value
        End Set
    End Property
    '''<sumary>
    ''' <value>Opcional</value>
    ''' <para> Nodo condicional para expresar las horas extra aplicables. </para>
    ''' </sumary>
    Public Property HorasExtra As List(Of NHorasExtra)
        Get
            Return _horasExtra
        End Get
        Set(ByVal value As List(Of NHorasExtra))
            _horasExtra = value
        End Set
    End Property

    Friend Function Count() As Integer
        Throw New NotImplementedException()
    End Function
End Class
Public Class NEmisor
    Private _curp As String = String.Empty
    Private _registroPatronal As String = String.Empty
    Private _rfcPatronOrigen As String = String.Empty
    Private _entidadSNCF As NEntidadSNCF
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Atributo condicional para expresar la CURP del emisor del comprobante de nómina cuando es una persona física.</para>
    '''</summary>
    Public Property Curp As String
        Get
            Return _curp
        End Get
        Set(ByVal value As String)
            _curp = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Atributo condicional para expresar el registro patronal, clave de ramo - pagaduría o la que le asigne la institución de seguridad social al patrón, a 20 posiciones máximo. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales.</para>
    '''</summary>
    Public Property RegistroPatronal As String
        Get
            Return _registroPatronal
        End Get
        Set(ByVal value As String)
            _registroPatronal = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para> Atributo opcional para expresar el RFC de la persona que fungió como patrón cuando el pago al trabajador se realice a través de un tercero como vehículo o herramienta de pago.</para>
    '''</summary>
    Public Property RfcPatronOrigen As String
        Get
            Return _rfcPatronOrigen
        End Get
        Set(ByVal value As String)
            _rfcPatronOrigen = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Nodo condicional para que las entidades adheridas al Sistema Nacional de Coordinación Fiscal realicen la identificación del origen de los recursos utilizados en el pago de nómina del personal que presta o desempeña un servicio personal subordinado en las dependencias de la entidad federativa, del municipio o demarcación territorial de la Ciudad de México, así como en sus respectivos organismos autónomos y entidades paraestatales y paramunicipales.</para>
    '''</summary>
    Public Property EntidadSNCF As NEntidadSNCF
        Get
            Return _entidadSNCF
        End Get
        Set(ByVal value As NEntidadSNCF)
            _entidadSNCF = value
        End Set
    End Property
End Class
Public Class NEntidadSNCF
    Private _origenRecurso As String = String.Empty
    Private _montoRecursoPropio As Decimal = 0
    '''<summary>
    '''<value>Requerido.</value>
    '''<para>Atributo requerido para identificar el origen del recurso utilizado para el pago de nómina del personal que presta o desempeña un servicio personal subordinado o asimilado a salarios en las dependencias.</para>
    '''</summary>
    Public Property OrigenRecurso As String
        Get
            Return _origenRecurso
        End Get
        Set(ByVal value As String)
            _origenRecurso = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>Atributo condicional para expresar el monto del recurso pagado con cargo a sus participaciones u otros ingresos locales (importe bruto de los ingresos propios, es decir total de gravados y exentos), cuando el origen es mixto.</para>
    '''</summary>
    Public Property MontoRecursoPropio As Decimal
        Get
            Return _montoRecursoPropio
        End Get
        Set(ByVal value As Decimal)
            _montoRecursoPropio = value
        End Set
    End Property
End Class
Public Class NReceptor
    Private _curp As String = String.Empty
    Private _numSeguridadSocial As String = String.Empty
    Private _fechaInicioRelLaboral As DateTime
    Private _antiguedad As String = String.Empty
    Private _tipoContrato As String = String.Empty
    Private _sindicalizado As String = String.Empty
    Private _tipoJornada As String = String.Empty
    Private _tipoRegimen As String = String.Empty
    Private _numEmpleado As String = String.Empty
    Private _departamento As String = String.Empty
    Private _puesto As String = String.Empty
    Private _riesgoPuesto As String = String.Empty
    Private _periodicidadPago As String = String.Empty
    Private _banco As String = String.Empty
    Private _cuentaBancaria As String = String.Empty
    Private _salarioBaseCotApor As Decimal = 0
    Private _salarioDiarioIntegrado As Decimal = 0
    Private _claveEntFed As String = String.Empty
    Private _subContratacion As List(Of NSubContratacion)
    '''<summary>
    '''<value>Requerido.</value> 
    '''<para>Atributo requerido para expresar la CURP del receptor del comprobante de nómina. </para>
    '''</summary>
    Public Property Curp As String
        Get
            Return _curp
        End Get
        Set(ByVal value As String)
            _curp = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para expresar el número de seguridad social del trabajador. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales.</para>
    '''</summary>
    Public Property NumSeguridadSocial As String
        Get
            Return _numSeguridadSocial
        End Get
        Set(ByVal value As String)
            _numSeguridadSocial = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para expresar la fecha de inicio de la relación laboral entre el empleador y el empleado. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales.   </para>
    '''</summary>
    Public Property FechaInicioRelLaboral As DateTime
        Get
            Return _fechaInicioRelLaboral
        End Get
        Set(ByVal value As DateTime)
            _fechaInicioRelLaboral = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para expresar la fecha de inicio de la relación laboral entre el empleador y el empleado. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales. </para>
    '''</summary>
    Public Property Antiguedad As String
        Get
            Return _antiguedad
        End Get
        Set(ByVal value As String)
            _antiguedad = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Atributo requerido para expresar el tipo de contrato que tiene el trabajador. </para>
    '''</summary>
    Public Property TipoContrato As String
        Get
            Return _tipoContrato
        End Get
        Set(ByVal value As String)
            _tipoContrato = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para indicar si el trabajador está asociado a un sindicato. Si se omite se asume que no está asociado a algún sindicato </para>
    '''</summary>
    Public Property Sindicalizado As String
        Get
            Return _sindicalizado
        End Get
        Set(ByVal value As String)
            _sindicalizado = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para expresar el tipo de jornada que cubre el trabajador. Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales.</para>
    '''</summary>
    Public Property TipoJornada As String
        Get
            Return _tipoJornada
        End Get
        Set(ByVal value As String)
            _tipoJornada = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Atributo requerido para la expresión de la clave del régimen por el cual se tiene contratado al trabajador</para>
    '''</summary>
    Public Property TipoRegimen As String
        Get
            Return _tipoRegimen
        End Get
        Set(ByVal value As String)
            _tipoRegimen = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Atributo requerido para expresar el número de empleado de 1 a 15 posiciones. </para>
    '''</summary>
    Public Property NumEmpleado As String
        Get
            Return _numEmpleado
        End Get
        Set(ByVal value As String)
            _numEmpleado = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para la expresión del departamento o área a la que pertenece el trabajador </para>  
    '''</summary>
    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(ByVal value As String)
            _departamento = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para la expresión del puesto asignado al empleado o actividad que realiza.</para>  
    '''</summary>
    Public Property Puesto As String
        Get
            Return _puesto
        End Get
        Set(ByVal value As String)
            _puesto = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para expresar la clave conforme a la Clase en que deben inscribirse los patrones, de acuerdo con las actividades que desempeñan sus trabajadores, según lo previsto en el artículo 196 del Reglamento en Materia de Afiliación Clasificación de Empresas, Recaudación y Fiscalización, o conforme con la normatividad del Instituto de Seguridad Social del trabajador. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales</para>
    '''</summary>
    Public Property RiesgoPuesto As String
        Get
            Return _riesgoPuesto
        End Get
        Set(ByVal value As String)
            _riesgoPuesto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Atributo requerido para la forma en que se establece el pago del salario.</para>
    '''</summary>
    Public Property PeriodicidadPago As String
        Get
            Return _periodicidadPago
        End Get
        Set(ByVal value As String)
            _periodicidadPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para la expresión de la clave del Banco conforme al catálogo, donde se realiza el depósito de nómina.</para>
    '''</summary>
    Public Property Banco As String
        Get
            Return _banco
        End Get
        Set(ByVal value As String)
            _banco = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo condicional para la expresión de la cuenta bancaria a 11 posiciones o número de teléfono celular a 10 posiciones o número de tarjeta de crédito, débito o servicios a 15 ó 16 posiciones o la CLABE a 18 posiciones o número de monedero electrónico, donde se realiza el depósito de nómina.   </para>
    '''</summary>
    Public Property CuentaBancaria As String
        Get
            Return _cuentaBancaria
        End Get
        Set(ByVal value As String)
            _cuentaBancaria = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para expresar la retribución otorgada al trabajador, que se integra por los pagos hechos en efectivo por cuota diaria, gratificaciones, percepciones, alimentación, habitación, primas, comisiones, prestaciones en especie y cualquiera otra cantidad o prestación que se entregue al trabajador por su trabajo, sin considerar los conceptos que se excluyen de conformidad con el Artículo 27 de la Ley del Seguro Social, o la integración de los pagos conforme la normatividad del Instituto de Seguridad Social del trabajador. (Se emplea para pagar las cuotas y aportaciones de Seguridad Social). Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales.</para>
    '''</summary>
    Public Property SalarioBaseCotApor As Decimal
        Get
            Return _salarioBaseCotApor
        End Get
        Set(ByVal value As Decimal)
            _salarioBaseCotApor = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Atributo opcional para expresar el salario que se integra con los pagos hechos en efectivo por cuota diaria, gratificaciones, percepciones, habitación, primas, comisiones, prestaciones en especie y cualquier otra cantidad o prestación que se entregue al trabajador por su trabajo, de conformidad con el Art. 84 de la Ley Federal del Trabajo. (Se utiliza para el cálculo de las indemnizaciones). Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales. </para>
    '''</summary>
    Public Property SalarioDiarioIntegrado As Decimal
        Get
            Return _salarioDiarioIntegrado
        End Get
        Set(ByVal value As Decimal)
            _salarioDiarioIntegrado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Atributo requerido para expresar la clave de la entidad federativa en donde el receptor del recibo prestó el servicio.</para>
    '''</summary>
    Public Property ClaveEntFed As String
        Get
            Return _claveEntFed
        End Get
        Set(ByVal value As String)
            _claveEntFed = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Nodo condicional para expresar la lista de las personas que los subcontrataron</para>
    '''</summary>
    Public Property SubContratacion As List(Of NSubContratacion)
        Get
            Return _subContratacion
        End Get
        Set(ByVal value As List(Of NSubContratacion))
            _subContratacion = value
        End Set
    End Property
End Class
Public Class NSubContratacion
    Private _rfcLabora As String = String.Empty
    Private _porcentajeTiempo As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>el RFC de la persona que subcontrata</para>
    '''</summary>
    Public Property RfcLabora As String
        Get
            Return _rfcLabora
        End Get
        Set(ByVal value As String)
            _rfcLabora = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar el porcentaje del tiempo que prestó sus servicios con el RFC que lo subcontrata</para>
    '''</summary>
    Public Property PorcentajeTiempo As Decimal
        Get
            Return _porcentajeTiempo
        End Get
        Set(ByVal value As Decimal)
            _porcentajeTiempo = value
        End Set
    End Property
End Class
Public Class NPercepciones
    Private _totalSueldos As Decimal = 0
    Private _totalSeparacionIndemnizacion As Decimal = 0
    Private _totalJubilacionPensionRetiro As Decimal = 0
    Private _totalGravado As Decimal = 0
    Private _totalExento As Decimal = 0
    Private _percepcion As List(Of NPercepcion)
    Private _jubilacionPensionRetiro As NJubilacionPensionRetiro
    Private _separacionIndeminzacion As NSeparacionIndemnizacion
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Expresar el total de percepciones brutas (gravadas y exentas) por sueldos y salarios y conceptos asimilados a salarios</para>
    '''</summary>
    Public Property TotalSueldos As Decimal
        Get
            Return _totalSueldos
        End Get
        Set(ByVal value As Decimal)
            _totalSueldos = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el importe exento y gravado de las claves tipo percepción 022 Prima por Antigüedad, 023 Pagos por separación y 025 Indemnizaciones.</para>
    '''</summary>
    Public Property TotalSeparacionIndemnizacion As Decimal
        Get
            Return _totalSeparacionIndemnizacion
        End Get
        Set(ByVal value As Decimal)
            _totalSeparacionIndemnizacion = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> expresar el importe exento y gravado de las claves tipo percepción 039 Jubilaciones, pensiones o haberes de retiro en una exhibición y 044 Jubilaciones, pensiones o haberes de retiro en parcialidades.</para>
    '''</summary>
    Public Property TotalJubilacionPensionRetiro As Decimal
        Get
            Return _totalJubilacionPensionRetiro
        End Get
        Set(ByVal value As Decimal)
            _totalJubilacionPensionRetiro = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar el total de percepciones gravadas que se relacionan en el comprobante.</para>
    '''</summary> 
    Public Property TotalGravado As Decimal
        Get
            Return _totalGravado
        End Get
        Set(ByVal value As Decimal)
            _totalGravado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el total de percepciones exentas que se relacionan en el comprobante</para>
    '''</summary>
    Public Property TotalExento As Decimal
        Get
            Return _totalExento
        End Get
        Set(ByVal value As Decimal)
            _totalExento = value
        End Set
    End Property
    '''<summary>
    '''<para>Nodo condicional para expresar la informacion detallada de pagos por jubilacion, pensiones o haberes de retiro</para>
    '''</summary>
    Public Property Percepcion As List(Of NPercepcion)
        Get
            Return _percepcion
        End Get
        Set(ByVal value As List(Of NPercepcion))
            _percepcion = value
        End Set
    End Property
    '''<summary>
    '''JubilacionPensionRetiro(minimo, maximo)
    '''JubilacionPensionRetiro(0,1)
    '''</summary>
    Public Property JubilacionPensionRetiro As NJubilacionPensionRetiro
        Get
            Return _jubilacionPensionRetiro
        End Get
        Set(ByVal value As NJubilacionPensionRetiro)
            _jubilacionPensionRetiro = value
        End Set
    End Property
    '''<summary>
    '''SeparacionIndeminzacion(minimo, maximo)
    '''SeparacionIndeminzacion(0, 1)
    '''</summary>
    Public Property SeparacionIndeminzacion As NSeparacionIndemnizacion
        Get
            Return _separacionIndeminzacion
        End Get
        Set(ByVal value As NSeparacionIndemnizacion)
            _separacionIndeminzacion = value
        End Set
    End Property
End Class
Public Class NPercepcion
    Private _tipoPercepcion As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importeGravado As Decimal = 0
    Private _importeExento As Decimal = 0
    Private _accionesOTitulos As NAccionesOTitulos
    Private _horasExtra As List(Of NHorasExtra)
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar la Clave agrupadora bajo la cual se clasifica la percepción. </para>
    '''</summary>
    Public Property TipoPercepcion As String
        Get
            Return _tipoPercepcion
        End Get
        Set(ByVal value As String)
            _tipoPercepcion = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar la clave de percepción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres. </para> 
    '''</summary>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Requerido para la descripción del concepto de percepción </para>
    '''</summary>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Representa el importe gravado de un concepto de percepción.</para>
    '''</summary>
    Public Property ImporteGravado As Decimal
        Get
            Return _importeGravado
        End Get
        Set(ByVal value As Decimal)
            _importeGravado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> representa el importe exento de un concepto de percepción.</para>
    '''</summary>
    Public Property ImporteExento As Decimal
        Get
            Return _importeExento
        End Get
        Set(ByVal value As Decimal)
            _importeExento = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Nodo condicional para expresar ingresos por acciones o títulos valor que representan bienes. Se vuelve requerido cuando existan ingresos por sueldos derivados de adquisición de acciones o títulos (Art. 94, fracción VII LISR). </para>
    '''</summary>
    Public Property AccionesOTitulos As NAccionesOTitulos
        Get
            Return _accionesOTitulos
        End Get
        Set(ByVal value As NAccionesOTitulos)
            _accionesOTitulos = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>Nodo condicional para expresar las horas extra aplicables. </para>
    '''</summary>
    Public Property HorasExtras As List(Of NHorasExtra)
        Get
            Return _horasExtra
        End Get
        Set(ByVal value As List(Of NHorasExtra))
            _horasExtra = value
        End Set
    End Property
End Class
Public Class NAccionesOTitulos
    Private _valorMercado As String = String.Empty
    Private _precioAlOtorgarse As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar el valor de mercado de las Acciones o Títulos valor al ejercer la opción. </para>
    '''</summary>
    Public Property ValorMercado As String
        Get
            Return _valorMercado
        End Get
        Set(ByVal value As String)
            _valorMercado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar el precio establecido al otorgarse la opción de ingresos en acciones o títulos valor. </para>
    '''</summary>
    Public Property PrecioAlOtorgarse As Decimal
        Get
            Return _precioAlOtorgarse
        End Get
        Set(ByVal value As Decimal)
            _precioAlOtorgarse = value
        End Set
    End Property
End Class
Public Class NHorasExtra
    Private _dias As Integer = 0
    Private _tipoHoras As Integer = -1
    Private _horasExtra As Integer = -1
    Private _importePagado As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el número de días en que el trabajador realizó horas extra en el periodo.</para>
    '''</summary>
    Public Property Dias As Integer
        Get
            Return _dias
        End Get
        Set(ByVal value As Integer)
            _dias = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el tipo de pago de las horas extra.</para>
    '''</summary>
    Public Property TipoHoras As Integer
        Get
            Return _tipoHoras
        End Get
        Set(ByVal value As Integer)
            _tipoHoras = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar el número de horas extra trabajadas en el periodo.</para>
    '''</summary>
    Public Property HorasExtra As Integer
        Get
            Return _horasExtra
        End Get
        Set(ByVal value As Integer)
            _horasExtra = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar el importe pagado por las horas extra</para>
    '''</summary>
    Public Property ImportePagado As Decimal
        Get
            Return _importePagado
        End Get
        Set(ByVal value As Decimal)
            _importePagado = value
        End Set
    End Property
End Class
Public Class NJubilacionPensionRetiro
    Private _totalUnaExhibicion As Decimal = 0
    Private _totalParcialidad As Decimal = 0
    Private _montoDiario As Decimal = 0
    Private _ingresoAcumulable As Decimal = 0
    Private _ingresoNoAcumulable As Decimal = 0
    '<summary>
    '<value>Opcional</value>
    '<para>Indica el monto total del pago cuando se realiza en una sola exhibición.   </para>
    '</summary>
    Public Property TotalUnaExhibicion As Decimal
        Get
            Return _totalUnaExhibicion
        End Get
        Set(ByVal value As Decimal)
            _totalUnaExhibicion = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> expresar los ingresos totales por pago cuando se hace en parcialidades.</para>
    '''</summary>
    Public Property TotalParcialidad As Decimal
        Get
            Return _totalParcialidad
        End Get
        Set(ByVal value As Decimal)
            _totalParcialidad = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para> expresar el monto diario percibido por jubilación, pensiones o haberes de retiro cuando se realiza en parcialidades.</para>
    '''</summary>
    Public Property MontoDiario As Decimal
        Get
            Return _montoDiario
        End Get
        Set(ByVal value As Decimal)
            _montoDiario = value
        End Set
    End Property
    '''<summary>  
    '''<value>Requerido</value>
    '''<para>expresar los ingresos acumulables. </para>
    '''</summary>
    Public Property IngresoAcumulable As Decimal
        Get
            Return _ingresoAcumulable
        End Get
        Set(ByVal value As Decimal)
            _ingresoAcumulable = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar los ingresos no acumulables.</para>
    '''</summary>
    Public Property IngresoNoAcumulable As Decimal
        Get
            Return _ingresoNoAcumulable
        End Get
        Set(ByVal value As Decimal)
            _ingresoNoAcumulable = value
        End Set
    End Property
End Class
Public Class NSeparacionIndemnizacion
    Private _totalPagado As Decimal = 0
    Private _numAnosServicio As Integer = -1
    Private _ultimoSueldoMensOrd As Decimal = 0
    Private _ingresoAcumulable As Decimal = 0
    Private _ingresoNoAcumulable As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>indica el monto total del pago.</para>
    '''</summary>
    Public Property TotalPagado As Decimal
        Get
            Return _totalPagado
        End Get
        Set(ByVal value As Decimal)
            _totalPagado = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar el número de años de servicio del trabajador. Se redondea al entero superior si la cifra contiene años y meses y hay más de 6 meses.</para>
    '''</summary>
    Public Property NumAnosServicio As Integer
        Get
            Return _numAnosServicio
        End Get
        Set(ByVal value As Integer)
            _numAnosServicio = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>e indica el último sueldo mensual ordinario.</para>
    '''</summary>
    Public Property UltimoSueldoMensOrd As Decimal
        Get
            Return _ultimoSueldoMensOrd
        End Get
        Set(ByVal value As Decimal)
            _ultimoSueldoMensOrd = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar los ingresos acumulables.</para>
    '''</summary>
    Public Property IngresoAcumulable As Decimal
        Get
            Return _ingresoAcumulable
        End Get
        Set(ByVal value As Decimal)
            _ingresoAcumulable = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>indica los ingresos no acumulables.</para>
    '''</summary>
    Public Property IngresoNoAcumulable As Decimal
        Get
            Return _ingresoNoAcumulable
        End Get
        Set(ByVal value As Decimal)
            _ingresoNoAcumulable = value
        End Set
    End Property
End Class
Public Class NDeducciones
    Private _totalOtrasDeducciones As Decimal = 0
    Private _totalImpuestosRetenidos As Decimal = 0
    Private _deduccion As List(Of NDeduccion)
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el total de deducciones que se relacionan en el comprobante, donde la clave de tipo de deducción sea distinta a la 002 correspondiente a ISR. </para>
    '''</summary>
    Public Property TotalOtrasDeducciones As Decimal
        Get
            Return _totalOtrasDeducciones
        End Get
        Set(ByVal value As Decimal)
            _totalOtrasDeducciones = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional</value>
    '''<para>expresar el total de los impuestos federales retenidos, es decir, donde la clave de tipo de deducción sea 002 correspondiente a ISR.</para>
    '''</summary>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return _totalImpuestosRetenidos
        End Get
        Set(ByVal value As Decimal)
            _totalImpuestosRetenidos = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Nodo requerido para expresar la información detallada de una deducción. </para>
    '''</summary>
    Public Property Deduccion As List(Of NDeduccion)
        Get
            Return _deduccion
        End Get
        Set(ByVal value As List(Of NDeduccion))
            _deduccion = value
        End Set
    End Property
End Class
Public Class NDeduccion
    Private _tipoDeduccion As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importe As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>registrar la clave agrupadora que clasifica la deducción.   </para>
    '''</summary>
    Public Property TipoDeduccion As String
        Get
            Return _tipoDeduccion
        End Get
        Set(ByVal value As String)
            _tipoDeduccion = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> la clave de deducción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres.</para>
    '''</summary>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>la descripción del concepto de deducción.</para>
    '''</summary>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>registrar el importe del concepto de deducción.   </para>
    '''</summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class NOtrosPagos
    Private _otroPago As List(Of NOtroPago)
    '''<summary>
    '''<para>Nodo condicional para expresar otros pagos aplicables.</para>
    '''</summary>
    Public Property OtroPago As List(Of NOtroPago)
        Get
            Return _otroPago
        End Get
        Set(ByVal value As List(Of NOtroPago))
            _otroPago = value
        End Set
    End Property
End Class
Public Class NOtroPago
    Private _tipoOtroPago As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importe As Decimal = 0
    Private _subsidioAlEmpleo As NSubsidioAlEmpleo
    Public _compensacionSaldosAFavor As NCompensacionSaldosAFavor
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar la clave agrupadora bajo la cual se clasifica el otro pago</para>
    '''</summary>
    Public Property TipoOtroPago As String
        Get
            Return _tipoOtroPago
        End Get
        Set(ByVal value As String)
            _tipoOtroPago = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Representa la clave de otro pago de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres.</para>
    '''</summary>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>la descripción del concepto de otro pago.</para>
    '''</summary>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar el importe del concepto de otro pago.</para>
    '''</summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    '''<summary>
    '''<para>Nodo requerido para expresar la información referente al subsidio al empleo del trabajador.</para>
    '''</summary>
    Public Property SubsidioAlEmpleo As NSubsidioAlEmpleo
        Get
            Return _subsidioAlEmpleo
        End Get
        Set(ByVal value As NSubsidioAlEmpleo)
            _subsidioAlEmpleo = value
        End Set
    End Property
    '''<summary>
    '''<para>Nodo condicional para expresar la información referente a la compensación de saldos a favor de un trabajador</para>
    '''</summary>
    Public Property CompensacionSaldosAFavor As NCompensacionSaldosAFavor
        Get
            Return _compensacionSaldosAFavor
        End Get
        Set(ByVal value As NCompensacionSaldosAFavor)
            _compensacionSaldosAFavor = value
        End Set
    End Property
End Class
Public Class NSubsidioAlEmpleo
    Private _subsidioCausado As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>Expresar el subsidio causado conforme a la tabla del subsidio para el empleo publicada en el Anexo 8 de la RMF vigente</para>
    '''</summary>
    Public Property SubsidioCausado As Decimal
        Get
            Return _subsidioCausado
        End Get
        Set(ByVal value As Decimal)
            _subsidioCausado = value
        End Set
    End Property
End Class
Public Class NCompensacionSaldosAFavor
    Private _saldoAFavor As Decimal = 0
    Private _ano As String = String.Empty
    Private _remanenteSalFav As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el saldo a favor determinado por el patrón al trabajador en periodos o ejercicios anteriores.</para>
    '''</summary>
    Public Property SaldoAFavor As Decimal
        Get
            Return _saldoAFavor
        End Get
        Set(ByVal value As Decimal)
            _saldoAFavor = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para> expresar el año en que se determinó el saldo a favor del trabajador por el patrón que se incluye en el campo “RemanenteSalFav”.</para>
    '''</summary>
    Public Property Ano As String
        Get
            Return _ano
        End Get
        Set(ByVal value As String)
            _ano = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el remanente del saldo a favor del trabajador.</para>
    '''</summary>
    Public Property RemanenteSalFav As Decimal
        Get
            Return _remanenteSalFav
        End Get
        Set(ByVal value As Decimal)
            _remanenteSalFav = value
        End Set
    End Property
End Class
Public Class NIncapacidades
    Private _incapacidad As List(Of NIncapacidad)
    '''<summary>  
    '''<para>Nodo condicional para expresar información de las incapacidades.</para>
    '''</summary>
    Public Property Incapacidad As List(Of NIncapacidad)
        Get
            Return _incapacidad
        End Get
        Set(ByVal value As List(Of NIncapacidad))
            _incapacidad = value
        End Set
    End Property
End Class
Public Class NIncapacidad
    Private _diasIncapacidad As Integer = -1
    Private _tipoIncapacidad As String = String.Empty
    Private _importeMonetario As Decimal = 0
    '''<summary>
    '''<value>Requerido</value>
    '''<para>expresar el número de días enteros que el trabajador se incapacitó en el periodo. </para>
    '''</summary>
    Public Property DiasIncapacidad As Integer
        Get
            Return _diasIncapacidad
        End Get
        Set(ByVal value As Integer)
            _diasIncapacidad = value
        End Set
    End Property
    '''<summary>
    '''<value>Requerido</value> 
    '''<para>Expresar la razón de la incapacidad.</para>
    '''</summary>
    Public Property TipoIncapacidad As String
        Get
            Return _tipoIncapacidad
        End Get
        Set(ByVal value As String)
            _tipoIncapacidad = value
        End Set
    End Property
    '''<summary>
    '''<value>Opcional.</value>
    '''<para>expresar el monto del importe monetario de la incapacidad.</para>
    '''</summary>
    Public Property ImporteMonetario As Decimal
        Get
            Return _importeMonetario
        End Get
        Set(ByVal value As Decimal)
            _importeMonetario = value
        End Set
    End Property
End Class
#End Region
#End Region
#Region "Addenda"
Public Class Addenda
    Private _direccion As String
    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
End Class
#End Region
#End Region

Namespace ComplementoRetenciones
    Public Class Retenciones
        Private _version As String = "1.0"
        Private _folioInt As String
        Private _sello As String
        Private _numCert As String
        Private _cert As String
        Private _fechaExp As DateTime
        Private _cveRetenc As String
        Private _descRetenc As String
        Private _emisor As Emisor = New Emisor
        Private _receptor As Receptor = New Receptor
        Private _periodo As Periodo = New Periodo
        Private _totales As Totales = New Totales
        Private _complemento As Complemento = New Complemento

        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del estándar bajo el que se encuentra expresada la retención y/o comprobante de información de pagos. Valor por defecto 1.0
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para control interno del contribuyente que expresa el folio del documento que ampara la retención e información de pagos. Permite números y/o letras.
        ''' </summary>
        Public Property FolioInt As String
            Get
                Return _folioInt
            End Get
            Set(value As String)
                _folioInt = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para contener el sello digital del documento de retención e información de pagos. El sello deberá ser expresado como una cadena de texto en formato base 64.
        ''' </summary>
        Public Property Sello As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el número de serie del certificado de sello digital con el que se selló digitalmente el documento de la retención e información de pagos.
        ''' </summary>
        Public Property NumCert As String
            Get
                Return _numCert
            End Get
            Set(value As String)
                _numCert = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido que sirve para incorporar el certificado de sello digital que ampara el documento de retención e información de pagos como texto, en formato base 64.
        ''' </summary>
        Public Property Cert As String
            Get
                Return _cert
            End Get
            Set(value As String)
                _cert = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para la expresión de la fecha y hora de expedición del documento de retención e información de pagos. Se expresa en la forma yyyy-mm-ddThh:mm:ssTZD-6, de acuerdo con la especificación ISO 8601.
        ''' </summary>
        Public Property FechaExp As DateTime
            Get
                Return _fechaExp
            End Get
            Set(value As DateTime)
                _fechaExp = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la clave de la retención e información de pagos de acuerdo al catálogo publicado en internet por el SAT.
        ''' </summary>
        Public Property CveRetenc As String
            Get
                Return _cveRetenc
            End Get
            Set(value As String)
                _cveRetenc = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional que expresa la descripción de la retención e información de pagos en caso de que en el atributo CveRetenc se haya elegido el valor para 'otro tipo de retenciones'
        ''' </summary>
        Public Property DescRetenc As String
            Get
                Return _descRetenc
            End Get
            Set(value As String)
                _descRetenc = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo requerido para expresar la información del contribuyente emisor del documento electrónico de retenciones e información de pagos.
        ''' </summary>
        Public Property Emisor As Emisor
            Get
                Return _emisor
            End Get
            Set(value As Emisor)
                _emisor = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo requerido para expresar la información del contribuyente receptor del documento electrónico de retenciones e información de pagos.
        ''' </summary>
        Public Property Receptor As Receptor
            Get
                Return _receptor
            End Get
            Set(value As Receptor)
                _receptor = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo requerido para expresar el periodo que ampara el documento de retenciones e información de pagos
        ''' </summary>
        Public Property Periodo As Periodo
            Get
                Return _periodo
            End Get
            Set(value As Periodo)
                _periodo = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo requerido para expresar el total de las retenciones e información de pagos efectuados en el período que ampara el documento.
        ''' </summary>
        Public Property Totales As Totales
            Get
                Return _totales
            End Get
            Set(value As Totales)
                _totales = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo opcional donde se incluirá el complemento Timbre Fiscal Digital de manera obligatoria y los nodos complementarios determinados por el SAT, de acuerdo a las disposiciones particulares a un sector o actividad específica.
        ''' </summary>
        Public Property Complemento As Complemento
            Get
                Return _complemento
            End Get
            Set(value As Complemento)
                _complemento = value
            End Set
        End Property
    End Class
    Public Class Emisor
        Private _rfcEmisor As String
        Private _nomDenRazSocE As String
        Private _curpe As String
        ''' <summary>
        ''' Atributo requerido para incorporar la clave en el Registro Federal de Contribuyentes correspondiente al contribuyente emisor del documento de retención e información de pagos, sin guiones o espacios.
        ''' </summary>
        Public Property RFCEmisor As String
            Get
                Return _rfcEmisor
            End Get
            Set(value As String)
                _rfcEmisor = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para el nombre, denominación o razón social del contribuyente emisor del documento de retención e información de pagos.
        ''' </summary>
        Public Property NomDenRazSocE As String
            Get
                Return _nomDenRazSocE
            End Get
            Set(value As String)
                _nomDenRazSocE = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para la Clave Única del Registro Poblacional del contribuyente emisor del documento de retención e información de pagos.
        ''' </summary>
        Public Property CURPE As String
            Get
                Return _curpe
            End Get
            Set(value As String)
                _curpe = value
            End Set
        End Property
    End Class

    Public Class Receptor
        Private _nacional As Nacional
        Private _extranjero As Extranjero
        Private _nacionalidad As String
        ''' <summary>
        ''' Nodo requerido para expresar la información del contribuyente receptor en caso de que sea de nacionalidad mexicana
        ''' </summary>
        Public Property Nacional As Nacional
            Get
                Return _nacional
            End Get
            Set(value As Nacional)
                _nacional = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo requerido para expresar la información del contribuyente receptor del documento cuando sea residente en el extranjero
        ''' </summary>
        Public Property Extranjero As Extranjero
            Get
                Return _extranjero
            End Get
            Set(value As Extranjero)
                _extranjero = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la nacionalidad del receptor del documento.
        ''' </summary>
        Public Property Nacionalidad As String
            Get
                Return _nacionalidad
            End Get
            Set(value As String)
                _nacionalidad = value
            End Set
        End Property
    End Class
    Public Class Nacional
        Private _rfcRecep As String
        Private _nomDenRazSocR As String
        Private _curpR As String
        ''' <summary>
        ''' Atributo requerido para la clave del Registro Federal de Contribuyentes correspondiente al contribuyente receptor del documento.
        ''' </summary>
        Public Property RFCRecep As String
            Get
                Return _rfcRecep
            End Get
            Set(value As String)
                _rfcRecep = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para el nombre, denominación o razón social del contribuyente receptor del documento.
        ''' </summary>
        Public Property NomDenRazSocR As String
            Get
                Return _nomDenRazSocR
            End Get
            Set(value As String)
                _nomDenRazSocR = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para la Clave Única del Registro Poblacional del contribuyente receptor del documento.
        ''' </summary>
        Public Property CURPR As String
            Get
                Return _curpR
            End Get
            Set(value As String)
                _curpR = value
            End Set
        End Property
    End Class
    Public Class Extranjero
        Private _numRegIdTrib As String
        Private _nomDenRazSocR As String
        ''' <summary>
        ''' Atributo opcional para expresar el número de registro de identificación fiscal del receptor del documento cuando sea residente en el extranjero
        ''' </summary>
        Public Property NumRegIdTrib As String
            Get
                Return _numRegIdTrib
            End Get
            Set(value As String)
                _numRegIdTrib = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para el nombre, denominación o razón social del contribuyente receptor del documento.
        ''' </summary>
        Public Property NomDenRazSocR As String
            Get
                Return _nomDenRazSocR
            End Get
            Set(value As String)
                _nomDenRazSocR = value
            End Set
        End Property

    End Class
    Public Class Periodo
        Private _mesIni As Integer
        Private _mesFin As Integer
        Private _ejerc As Integer
        ''' <summary>
        ''' Atributo requerido para la expresión del mes inicial del periodo de la retención e información de pagos
        ''' </summary>
        Public Property MesIni As Integer
            Get
                Return _mesIni
            End Get
            Set(value As Integer)
                _mesIni = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para la expresión del mes final del periodo de la retención e información de pagos
        ''' </summary>
        Public Property MesFin As Integer
            Get
                Return _mesFin
            End Get
            Set(value As Integer)
                _mesFin = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para la expresión del ejercicio fiscal (año)
        ''' </summary>
        Public Property Ejerc As Integer
            Get
                Return _ejerc
            End Get
            Set(value As Integer)
                _ejerc = value
            End Set
        End Property
    End Class
    Public Class Totales
        Private _impRetenidos As List(Of ImpRetenidos) = New List(Of ImpRetenidos)
        Private _montoTotOperacion As Decimal
        Private _montoTotGrav As Decimal
        Private _montoTotExent As Decimal
        Private _montoTotRet As Decimal
        ''' <summary>
        ''' Nodo opcional para expresar el total de los impuestos retenidos que se desprenden de los conceptos expresados en el documento de retenciones e información de pagos.
        ''' </summary>
        Public Property ImpRetenidos As List(Of ImpRetenidos)
            Get
                Return _impRetenidos
            End Get
            Set(value As List(Of ImpRetenidos))
                _impRetenidos = value
            End Set
        End Property
        ''' <summary>
        ''' >Atributo requerido para expresar  el total del monto de la operación  que se relaciona en el comprobante
        ''' </summary>
        Public Property montoTotOperacion As Decimal
            Get
                Return _montoTotOperacion
            End Get
            Set(value As Decimal)
                _montoTotOperacion = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el total del monto gravado de la operación  que se relaciona en el comprobante.
        ''' </summary>
        Public Property montoTotGrav As Decimal
            Get
                Return _montoTotGrav
            End Get
            Set(value As Decimal)
                _montoTotGrav = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el total del monto exento de la operación  que se relaciona en el comprobante.
        ''' </summary>
        Public Property montoTotExent As Decimal
            Get
                Return _montoTotExent
            End Get
            Set(value As Decimal)
                _montoTotExent = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el monto total de las retenciones. Sumatoria de los montos de retención del nodo ImpRetenidos.
        ''' </summary>
        Public Property montoTotRet As Decimal
            Get
                Return _montoTotRet
            End Get
            Set(value As Decimal)
                _montoTotRet = value
            End Set
        End Property
    End Class
    Public Class ImpRetenidos
        Private _baseRet As Decimal = 0
        Private _impuesto As String = String.Empty
        Private _montoRet As Decimal = 0
        Private _tipoPagoRet As String = String.Empty
        ''' <summary>
        ''' Requerido. 
        ''' <remarks>Atributo opcional para expresar la  base del impuesto, que puede ser la diferencia entre los ingresos percibidos y las deducciones autorizadas</remarks>
        ''' </summary>
        Public Property BaseRet As Decimal
            Get
                Return _baseRet
            End Get

            Set(ByVal value As Decimal)
                _baseRet = value
            End Set
        End Property
        ''' <summary>
        ''' Requerido.
        ''' <remarks>Atributo opcional para señalar el tipo de impuesto retenido del periodo o ejercicio conforme al catálogo.</remarks>
        ''' </summary>
        Public Property Impuesto As String
            Get
                Return _impuesto
            End Get

            Set(ByVal value As String)
                _impuesto = value
            End Set
        End Property
        ''' <summary>
        ''' Opcional
        ''' <remarks>Atributo requerido para expresar el importe del impuesto retenido en el periodo o ejercicio</remarks>
        ''' </summary>
        Public Property MontoRet As Decimal
            Get
                Return _montoRet
            End Get

            Set(ByVal value As Decimal)
                _montoRet = value
            End Set
        End Property
        ''' <summary>
        ''' Requerido. 
        ''' <remarks>Atributo requerido para precisar si el monto de la retención es considerado pago definitivo o pago provisional</remarks>
        ''' </summary>
        Public Property TipoPagoRet As String
            Get
                Return _tipoPagoRet
            End Get

            Set(ByVal value As String)
                _tipoPagoRet = value
            End Set
        End Property

    End Class
    Public Class Complemento
        Private _dividendos As Dividendos
        Private _intereses As Intereses
        Private _pagosaextranjeros As Pagosaextranjeros
        Private _arrendamientoEnFideicomiso As Arrendamientoenfideicomiso
        Private _enajenacionDeAcciones As EnajenaciondeAcciones
        Private _operacionesConDerivados As Operacionesconderivados
        Private _timbreFiscalDigital As TimbreFiscalDigital

        ''' <summary>
        ''' Complemento para  expresar  el total de  ganancias  y utilidades generadas por rendimientos en base a inversiones en instrumentos de inversión
        ''' </summary>
        Public Property Dividendos As Dividendos
            Get
                Return _dividendos
            End Get
            Set(value As Dividendos)
                _dividendos = value
            End Set
        End Property
        ''' <summary>
        ''' Complemento para expresar los intereses obtenidos por rendimiento en inversiones
        ''' </summary>
        Public Property Intereses As Intereses
            Get
                Return _intereses
            End Get
            Set(value As Intereses)
                _intereses = value
            End Set
        End Property
        ''' <summary>
        ''' Complemento para expresar los pagos que se realizan a residentes en el extranjero
        ''' </summary>
        Public Property Pagosaextranjeros As Pagosaextranjeros
            Get
                Return _pagosaextranjeros
            End Get
            Set(value As Pagosaextranjeros)
                _pagosaextranjeros = value
            End Set
        End Property
        ''' <summary>
        ''' Complemento para expresar el arrendamiento de bienes de un periodo o ejercicio determinado (incluye FIBRAS).
        ''' </summary>
        Public Property Arrendamientoenfideicomiso As Arrendamientoenfideicomiso
            Get
                Return _arrendamientoEnFideicomiso
            End Get
            Set(value As Arrendamientoenfideicomiso)
                _arrendamientoEnFideicomiso = value
            End Set
        End Property
        ''' <summary>
        ''' Complemento para expresar la enajenación de acciones u operaciones de valores (incluye ganancia o pérdida).
        ''' </summary>
        Public Property EnajenaciondeAcciones As EnajenaciondeAcciones
            Get
                Return _enajenacionDeAcciones
            End Get
            Set(value As EnajenaciondeAcciones)
                _enajenacionDeAcciones = value
            End Set
        End Property
        ''' <summary>
        ''' Complemento para incorporar información de las Operaciones Financieras Derivadas de Capital.
        ''' </summary>
        Public Property Operacionesconderivados As Operacionesconderivados
            Get
                Return _operacionesConDerivados
            End Get
            Set(value As Operacionesconderivados)
                _operacionesConDerivados = value
            End Set
        End Property
        Public Property TimbreFiscalDigital As TimbreFiscalDigital
            Get
                Return _timbreFiscalDigital
            End Get
            Set(value As TimbreFiscalDigital)
                _timbreFiscalDigital = value
            End Set
        End Property
    End Class
#Region "Dividendos"
    Public Class Dividendos
        Private _version As String = "1.0"
        Private _dividOUtil As DividOUtil
        Private _remanente As Remanente
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de dividendos y/o dividendos distribuidos. Valor por defecto 1.0
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo opcional que expresa los dividendos o utilidades distribuidas del periodo o ejercicio
        ''' </summary>
        Public Property DividOUtil As DividOUtil
            Get
                Return _dividOUtil
            End Get
            Set(value As DividOUtil)
                _dividOUtil = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo opcional que expresa el resultado obtenido de la diferencia entre ingresos y egresos de las personas morales que distribuyan anticipos o rendimientos o sociedades de producción, sociedades y asociaciones civiles.
        ''' </summary>
        Public Property Remanente As Remanente
            Get
                Return _remanente
            End Get
            Set(value As Remanente)
                _remanente = value
            End Set
        End Property
    End Class
    Public Class DividOUtil
        Private _cveTipDivOUtil As String
        Private _montISRAcredRetMexico As Decimal
        Private _montISRAcredRetExtranjero As Decimal
        Private _montRetExtDivExt As Decimal
        Private _tipoSocDistrDiv As String
        Private _montISRAcredNal As Decimal
        Private _montDivAcumNal As Decimal
        Private _montDivAcumExt As Decimal
        ''' <summary>
        ''' Atributo requerido para expresar la clave del tipo de dividendo o utilidad distribuida de acuerdo al catálogo.
        ''' </summary>
        Public Property CveTipDivOUtil As String
            Get
                Return _cveTipDivOUtil
            End Get
            Set(value As String)
                _cveTipDivOUtil = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe o retención  del dividendo o  utilidad en territorio nacional
        ''' </summary>
        Public Property MontISRAcredRetMexico As Decimal
            Get
                Return _montISRAcredRetMexico
            End Get
            Set(value As Decimal)
                _montISRAcredRetMexico = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe o retención  del dividendo o  utilidad en territorio extranjero
        ''' </summary>
        Public Property MontISRAcredRetExtranjero As Decimal
            Get
                Return _montISRAcredRetExtranjero
            End Get
            Set(value As Decimal)
                _montISRAcredRetExtranjero = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto de la retención en el extranjero sobre dividendos del extranjero
        ''' </summary>
        Public Property MontRetExtDivExt As Decimal
            Get
                Return _montRetExtDivExt
            End Get
            Set(value As Decimal)
                _montRetExtDivExt = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido  para expresar si el dividendo es distribuido por sociedades nacionales o extranjeras.
        ''' </summary>
        Public Property TipoSocDistrDiv As String
            Get
                Return _tipoSocDistrDiv
            End Get
            Set(value As String)
                _tipoSocDistrDiv = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto del ISR acreditable nacional
        ''' </summary>
        Public Property MontISRAcredNal As Decimal
            Get
                Return _montISRAcredNal
            End Get
            Set(value As Decimal)
                _montISRAcredNal = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto del dividendo acumulable nacional
        ''' </summary>
        Public Property MontDivAcumNal As Decimal
            Get
                Return _montDivAcumNal
            End Get
            Set(value As Decimal)
                _montDivAcumNal = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto del dividendo acumulable extranjero
        ''' </summary>
        Public Property MontDivAcumExt As Decimal
            Get
                Return _montDivAcumExt
            End Get
            Set(value As Decimal)
                _montDivAcumExt = value
            End Set
        End Property
    End Class
    Public Class Remanente
        Private _proporcionRem As Decimal
        ''' <summary>
        ''' Atributo opcional que expresa el porcentaje de participación de sus integrantes o accionistas
        ''' </summary>
        Public Property ProporcionRem As Decimal
            Get
                Return _proporcionRem
            End Get
            Set(value As Decimal)
                _proporcionRem = value
            End Set
        End Property
    End Class
#End Region
#Region "Intereses"
    Public Class Intereses
        Private _version As String = "1.0"
        Private _sistFinanciero As String
        Private _retiroAORESRetInt As String
        Private _operFinancDerivad As String
        Private _montIntNominal As Decimal
        Private _montIntReal As Decimal
        Private _perdida As Decimal
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de intereses obtenidos en el periodo o ejercicio
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar si los interés obtenidos en el periodo o ejercicio provienen del sistema financiero
        ''' </summary>
        Public Property SistFinanciero As String
            Get
                Return _sistFinanciero
            End Get
            Set(value As String)
                _sistFinanciero = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar si los intereses obtenidos fueron retirados en el periodo o ejercicio
        ''' </summary>
        Public Property RetiroAORESRetInt As String
            Get
                Return _retiroAORESRetInt
            End Get
            Set(value As String)
                _retiroAORESRetInt = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar si los intereses obtenidos corresponden a operaciones financieras derivadas.
        ''' </summary>
        Public Property OperFinancDerivad As String
            Get
                Return _operFinancDerivad
            End Get
            Set(value As String)
                _operFinancDerivad = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe del interés Nóminal obtenido en un periodo o ejercicio
        ''' </summary>
        Public Property MontIntNominal As Decimal
            Get
                Return _montIntNominal
            End Get
            Set(value As Decimal)
                _montIntNominal = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el monto de los intereses reales (diferencia que se obtiene restando al tipo de interés nominal y la tasa de inflación del periodo o ejercicio )
        ''' </summary>
        Public Property MontIntReal As Decimal
            Get
                Return _montIntReal
            End Get
            Set(value As Decimal)
                _montIntReal = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la pérdida por los intereses obtenidos en el periodo o ejercicio
        ''' </summary>
        Public Property Perdida As Decimal
            Get
                Return _perdida
            End Get
            Set(value As Decimal)
                _perdida = value
            End Set
        End Property
    End Class
#End Region
#Region "Pagos a extranjeros"
    Public Class Pagosaextranjeros
        Private _noBeneficiario As NoBeneficiario
        Private _beneficiario As Beneficiario
        Private _version As String = "1.0"
        Private _esBenefEfectDelCobro As String
        ''' <summary>
        ''' odo opcional para expresar la información del residente extranjero efectivo del cobro
        ''' </summary>
        Public Property NoBeneficiario As NoBeneficiario
            Get
                Return _noBeneficiario
            End Get
            Set(value As NoBeneficiario)
                _noBeneficiario = value
            End Set
        End Property
        ''' <summary>
        ''' Nodo opcional para precisar la información del representante para efectos fiscales en México
        ''' </summary>
        Public Property Beneficiario As Beneficiario
            Get
                Return _beneficiario
            End Get
            Set(value As Beneficiario)
                _beneficiario = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de pagos realizados a residentes a residentes en el extranjero
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar si el beneficiario del pago es la misma persona que retiene
        ''' </summary>
        Public Property EsBenefEfectDelCobro
            Get
                Return _esBenefEfectDelCobro
            End Get
            Set(value)
                _esBenefEfectDelCobro = value
            End Set
        End Property
    End Class
    Public Class NoBeneficiario
        Private _paisDeResidParaEfecFisc As String
        Private _conceptoPago As String
        Private _descripcionConcepto As String
        ''' <summary>
        ''' Atributo requerido para expresar la clave del país de residencia del extranjero, conforme al catálogo de países publicado en el Anexo 10 de la RMF.
        ''' </summary>
        Public Property PaisDeResidParaEfecFisc As String
            Get
                Return _paisDeResidParaEfecFisc
            End Get
            Set(value As String)
                _paisDeResidParaEfecFisc = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar  el tipo contribuyente sujeto a la retención, conforme al catálogo.
        ''' </summary>
        Public Property ConceptoPago As String
            Get
                Return _conceptoPago
            End Get
            Set(value As String)
                _conceptoPago = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la descripción de la definición del pago del residente en el extranjero
        ''' </summary>
        Public Property DescripcionConcepto As String
            Get
                Return _descripcionConcepto
            End Get
            Set(value As String)
                _descripcionConcepto = value
            End Set
        End Property
    End Class
    Public Class Beneficiario
        Private _rfc As String
        Private _curp As String
        Private _nomDenRazSocB As String
        Private _conceptoPago As String
        Private _descripcionConcepto As String
        ''' <summary>
        ''' Atributo requerido para expresar la clave del registro federal de contribuyentes del representante legal en México
        ''' </summary>
        Public Property RFC As String
            Get
                Return _rfc
            End Get
            Set(value As String)
                _rfc = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para la expresión de la CURP del representante legal
        ''' </summary>
        Public Property CURP As String
            Get
                Return _curp
            End Get
            Set(value As String)
                _curp = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el nombre, denominación o razón social del contribuyente en México
        ''' </summary>
        Public Property NomDenRazSocB As String
            Get
                Return _nomDenRazSocB
            End Get
            Set(value As String)
                _nomDenRazSocB = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el tipo de contribuyente sujeto a la retención, conforme al catálogo.
        ''' </summary>
        Public Property ConceptoPago As String
            Get
                Return _conceptoPago
            End Get
            Set(value As String)
                _conceptoPago = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la descripción de la definición del pago del residente en el extranjero
        ''' </summary>
        Public Property DescripcionConcepto As String
            Get
                Return _descripcionConcepto
            End Get
            Set(value As String)
                _descripcionConcepto = value
            End Set
        End Property
    End Class

#End Region
#Region "Arrendamientoenfideicomiso"
    Public Class Arrendamientoenfideicomiso
        Private _version As String = "1.0"
        Private _pagProvEfecPorFiduc As Decimal
        Private _rendimFideicom As Decimal
        Private _deduccCorresp As Decimal
        Private _montTotRet As Decimal
        Private _montResFiscDistFibras As Decimal
        Private _montOtrosConceptDistr As Decimal
        Private _descrMontOtrosConceptDistr As String
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de arrendamiento financiero
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe del pago efectuado por parte del fiduciario al arrendador de bienes en el periodo
        ''' </summary>
        Public Property PagProvEfecPorFiduc As Decimal
            Get
                Return _pagProvEfecPorFiduc
            End Get
            Set(value As Decimal)
                _pagProvEfecPorFiduc = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe de los rendimientos obtenidos en el periodo por el arrendamiento de bienes
        ''' </summary>
        Public Property RendimFideicom As Decimal
            Get
                Return _rendimFideicom
            End Get
            Set(value As Decimal)
                _rendimFideicom = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el importe de las deducciones correspondientes al arrendamiento de los bienes durante el periodo
        ''' </summary>
        Public Property DeduccCorresp As Decimal
            Get
                Return _deduccCorresp
            End Get
            Set(value As Decimal)
                _deduccCorresp = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto total de la retención del arrendamiento de los bienes del periodo
        ''' </summary>
        Public Property MontTotRet As Decimal
            Get
                Return _montTotRet
            End Get
            Set(value As Decimal)
                _montTotRet = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto del resultado fiscal distribuido por FIBRAS
        ''' </summary>
        Public Property MontResFiscDistFibras As Decimal
            Get
                Return _montResFiscDistFibras
            End Get
            Set(value As Decimal)
                _montResFiscDistFibras = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para expresar el monto de otros conceptos distribuidos
        ''' </summary>
        Public Property MontOtrosConceptDistr As Decimal
            Get
                Return _montOtrosConceptDistr
            End Get
            Set(value As Decimal)
                _montOtrosConceptDistr = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo opcional para describir los conceptos distribuidos cuando se señalen otros conceptos.
        ''' </summary>
        Public Property DescrMontOtrosConceptDistr As String
            Get
                Return _descrMontOtrosConceptDistr
            End Get
            Set(value As String)
                _descrMontOtrosConceptDistr = value
            End Set
        End Property
    End Class
#End Region
#Region "EnajenaciondeAcciones"
    Public Class EnajenaciondeAcciones
        Private _version As String = "1.0"
        Private _contratoIntermediacion As String
        Private _ganancia As Decimal
        Private _perdida As Decimal
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de la enajenación de acciones u operaciones de valores
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la descripción del contrato de intermediación
        ''' </summary>
        Public Property ContratoIntermediacion As String
            Get
                Return _contratoIntermediacion
            End Get
            Set(value As String)
                _contratoIntermediacion = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la ganancia obtenida por la enajenación de acciones u operación de valores
        ''' </summary>
        Public Property Ganancia As Decimal
            Get
                Return _ganancia
            End Get
            Set(value As Decimal)
                _ganancia = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar la pérdida en el contrato de intermediación
        ''' </summary>
        Public Property Perdida As Decimal
            Get
                Return _perdida
            End Get
            Set(value As Decimal)
                _perdida = value
            End Set
        End Property
    End Class
#End Region
#Region "Operacionesconderivados"
    Public Class Operacionesconderivados
        Private _version As String = "1.0"
        Private _montGanAcum As Decimal
        Private _montPerdDed As Decimal
        ''' <summary>
        ''' Atributo requerido con valor prefijado que indica la versión del complemento de las operaciones financieras derivadas de capital.
        ''' </summary>
        Public Property Version As String
            Get
                Return _version
            End Get
            Set(value As String)
                _version = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el monto de la ganancia acumulable.
        ''' </summary>
        Public Property MontGanAcum As Decimal
            Get
                Return _montGanAcum
            End Get
            Set(value As Decimal)
                _montGanAcum = value
            End Set
        End Property
        ''' <summary>
        ''' Atributo requerido para expresar el monto de la pérdida deducible.
        ''' </summary>
        Public Property MontPerdDed As Decimal
            Get
                Return _montPerdDed
            End Get
            Set(value As Decimal)
                _montPerdDed = value
            End Set
        End Property
    End Class
#End Region
End Namespace
Namespace Retenciones20
    Public Class Retenciones
        Private _cfdiRetenRelacionados As CfdiRetenRelacionados
        Private _emisor As Emisor
        Private _receptor As Receptor
        Private _periodo As Periodo
        Private _totales As Totales
        Private _complemento As Complemento
        Private _version As String = "2.0"
        Private _folioInt As String
        Private _sello As String
        Private _noCertificado As String
        Private _certificado As String
        Private _fechaExp As DateTime
        Private _lugarExpRetenc As String
        Private _cveRetenc As String
        Private _descRetenc As String

        Public Property CfdiRetenRelacionados As CfdiRetenRelacionados
            Get
                Return _cfdiRetenRelacionados
            End Get
            Set(ByVal value As CfdiRetenRelacionados)
                _cfdiRetenRelacionados = value
            End Set
        End Property

        Public Property Emisor As Emisor
            Get
                Return _emisor
            End Get
            Set(ByVal value As Emisor)
                _emisor = value
            End Set
        End Property

        Public Property Receptor As Receptor
            Get
                Return _receptor
            End Get
            Set(ByVal value As Receptor)
                _receptor = value
            End Set
        End Property

        Public Property Periodo As Periodo
            Get
                Return _periodo
            End Get
            Set(ByVal value As Periodo)
                _periodo = value
            End Set
        End Property

        Public Property Totales As Totales
            Get
                Return _totales
            End Get
            Set(ByVal value As Totales)
                _totales = value
            End Set
        End Property

        Public Property Complemento As Complemento
            Get
                Return _complemento
            End Get
            Set(ByVal value As Complemento)
                _complemento = value
            End Set
        End Property

        Public Property Version As String
            Get
                Return _version
            End Get
            Set(ByVal value As String)
                _version = value
            End Set
        End Property

        Public Property FolioInt As String
            Get
                Return _folioInt
            End Get
            Set(ByVal value As String)
                _folioInt = value
            End Set
        End Property

        Public Property Sello As String
            Get
                Return _sello
            End Get
            Set(ByVal value As String)
                _sello = value
            End Set
        End Property

        Public Property NoCertificado As String
            Get
                Return _noCertificado
            End Get
            Set(ByVal value As String)
                _noCertificado = value
            End Set
        End Property

        Public Property Certificado As String
            Get
                Return _certificado
            End Get
            Set(ByVal value As String)
                _certificado = value
            End Set
        End Property

        Public Property FechaExp As DateTime
            Get
                Return _fechaExp
            End Get
            Set(ByVal value As DateTime)
                _fechaExp = value
            End Set
        End Property

        Public Property LugarExpRetenc As String
            Get
                Return _lugarExpRetenc
            End Get
            Set(ByVal value As String)
                _lugarExpRetenc = value
            End Set
        End Property

        Public Property CveRetenc As String
            Get
                Return _cveRetenc
            End Get
            Set(ByVal value As String)
                _cveRetenc = value
            End Set
        End Property

        Public Property DescRetenc As String
            Get
                Return _descRetenc
            End Get
            Set(ByVal value As String)
                _descRetenc = value
            End Set
        End Property
    End Class

    Public Class CfdiRetenRelacionados
        Private _uuid As String
        Private _tipoRelacion As String

        Public Property UUID As String
            Get
                Return _uuid
            End Get
            Set(ByVal value As String)
                _uuid = value
            End Set
        End Property

        Public Property TipoRelacion As String
            Get
                Return _tipoRelacion
            End Get
            Set(ByVal value As String)
                _tipoRelacion = value
            End Set
        End Property
    End Class

    Public Class Emisor
        Private _rfcE As String
        Private _nomDenRazSocE As String
        Private _regimenFiscalE As String

        Public Property RfcE As String
            Get
                Return _rfcE
            End Get
            Set(ByVal value As String)
                _rfcE = value
            End Set
        End Property

        Public Property NomDenRazSocE As String
            Get
                Return _nomDenRazSocE
            End Get
            Set(ByVal value As String)
                _nomDenRazSocE = value
            End Set
        End Property

        Public Property RegimenFiscalE As String
            Get
                Return _regimenFiscalE
            End Get
            Set(ByVal value As String)
                _regimenFiscalE = value
            End Set
        End Property
    End Class

    Public Class Receptor
        Private _nacional As Nacional
        Private _extranjero As Extranjero
        Private _nacionalidadR As String

        Public Property Nacional As Nacional
            Get
                Return _nacional
            End Get
            Set(ByVal value As Nacional)
                _nacional = value
            End Set
        End Property

        Public Property Extranjero As Extranjero
            Get
                Return _extranjero
            End Get
            Set(ByVal value As Extranjero)
                _extranjero = value
            End Set
        End Property

        Public Property NacionalidadR As String
            Get
                Return _nacionalidadR
            End Get
            Set(ByVal value As String)
                _nacionalidadR = value
            End Set
        End Property
    End Class

    Public Class Nacional
        Private _rfcR As String
        Private _nomDenRazSocR As String
        Private _curpR As String
        Private _domicilioFiscalR As String

        Public Property RfcR As String
            Get
                Return _rfcR
            End Get
            Set(ByVal value As String)
                _rfcR = value
            End Set
        End Property

        Public Property NomDenRazSocR As String
            Get
                Return _nomDenRazSocR
            End Get
            Set(ByVal value As String)
                _nomDenRazSocR = value
            End Set
        End Property

        Public Property CURPR As String
            Get
                Return _curpR
            End Get
            Set(ByVal value As String)
                _curpR = value
            End Set
        End Property

        Public Property DomicilioFiscalR As String
            Get
                Return _domicilioFiscalR
            End Get
            Set(ByVal value As String)
                _domicilioFiscalR = value
            End Set
        End Property
    End Class

    Public Class Extranjero
        Private _numRegIdTribR As String
        Private _nomDenRazSocR As String

        Public Property NumRegIdTribR As String
            Get
                Return _numRegIdTribR
            End Get
            Set(ByVal value As String)
                _numRegIdTribR = value
            End Set
        End Property

        Public Property NomDenRazSocR As String
            Get
                Return _nomDenRazSocR
            End Get
            Set(ByVal value As String)
                _nomDenRazSocR = value
            End Set
        End Property
    End Class

    Public Class Periodo
        Private _mesIni As Integer
        Private _mesFin As Integer
        Private _ejercicio As Integer

        Public Property MesIni As Integer
            Get
                Return _mesIni
            End Get
            Set(ByVal value As Integer)
                _mesIni = value
            End Set
        End Property

        Public Property MesFin As Integer
            Get
                Return _mesFin
            End Get
            Set(ByVal value As Integer)
                _mesFin = value
            End Set
        End Property

        Public Property Ejercicio As Integer
            Get
                Return _ejercicio
            End Get
            Set(ByVal value As Integer)
                _ejercicio = value
            End Set
        End Property
    End Class

    Public Class Totales
        Private _impRetenidos As List(Of ImpRetenidos) = New List(Of ImpRetenidos)()
        Private _montoTotOperacion As Decimal
        Private _montoTotGrav As Decimal
        Private _montoTotExent As Decimal
        Private _montoTotRet As Decimal
        Private _unidadBimestral As Decimal
        Private _isrCorrespondiente As Decimal

        Public Property ImpRetenidos As List(Of ImpRetenidos)
            Get
                Return _impRetenidos
            End Get
            Set(ByVal value As List(Of ImpRetenidos))
                _impRetenidos = value
            End Set
        End Property

        Public Property MontoTotOperacion As Decimal
            Get
                Return _montoTotOperacion
            End Get
            Set(ByVal value As Decimal)
                _montoTotOperacion = value
            End Set
        End Property

        Public Property MontoTotGrav As Decimal
            Get
                Return _montoTotGrav
            End Get
            Set(ByVal value As Decimal)
                _montoTotGrav = value
            End Set
        End Property

        Public Property MontoTotExent As Decimal
            Get
                Return _montoTotExent
            End Get
            Set(ByVal value As Decimal)
                _montoTotExent = value
            End Set
        End Property

        Public Property MontoTotRet As Decimal
            Get
                Return _montoTotRet
            End Get
            Set(ByVal value As Decimal)
                _montoTotRet = value
            End Set
        End Property

        Public Property UtilidadBimestral As Decimal
            Get
                Return _unidadBimestral
            End Get
            Set(ByVal value As Decimal)
                _unidadBimestral = value
            End Set
        End Property

        Public Property ISRCorrespondiente As Decimal
            Get
                Return _isrCorrespondiente
            End Get
            Set(ByVal value As Decimal)
                _isrCorrespondiente = value
            End Set
        End Property
    End Class

    Public Class ImpRetenidos
        Private _baseRet As Decimal = 0
        Private _impuestoRet As String = String.Empty
        Private _montoRet As Decimal = 0
        Private _tipoPagoRet As String = String.Empty

        Public Property BaseRet As Decimal
            Get
                Return _baseRet
            End Get
            Set(ByVal value As Decimal)
                _baseRet = value
            End Set
        End Property

        Public Property ImpuestoRet As String
            Get
                Return _impuestoRet
            End Get
            Set(ByVal value As String)
                _impuestoRet = value
            End Set
        End Property

        Public Property MontoRet As Decimal
            Get
                Return _montoRet
            End Get
            Set(ByVal value As Decimal)
                _montoRet = value
            End Set
        End Property

        Public Property TipoPagoRet As String
            Get
                Return _tipoPagoRet
            End Get
            Set(ByVal value As String)
                _tipoPagoRet = value
            End Set
        End Property
    End Class

    Public Class Complemento
        Private _timbreFiscalDigital As TimbreFiscalDigital

        Public Property TimbreFiscalDigital As TimbreFiscalDigital
            Get
                Return _timbreFiscalDigital
            End Get
            Set(value As TimbreFiscalDigital)
                _timbreFiscalDigital = value
            End Set
        End Property
    End Class

    Public Class TimbreFiscalDigital
        Private _version As String = "1.1"
        Private _UUID As String = String.Empty
        Private _fechaTimbrado As DateTime
        Private _rfcProvCertif As String = String.Empty
        Private _leyenda As String = String.Empty
        Private _selloCFD As String = String.Empty
        Private _noCertificadoSAT As String = String.Empty
        Private _selloSAT As String = String.Empty

        Public Property Version As String
            Get
                Return _version
            End Get
            Set(ByVal value As String)
                _version = value
            End Set
        End Property

        Public Property UUID As String
            Get
                Return _UUID
            End Get
            Set(ByVal value As String)
                _UUID = value
            End Set
        End Property

        Public Property FechaTimbrado As DateTime
            Get
                Return _fechaTimbrado
            End Get
            Set(ByVal value As DateTime)
                _fechaTimbrado = value
            End Set
        End Property

        Public Property RfcProvCertif As String
            Get
                Return _rfcProvCertif
            End Get
            Set(ByVal value As String)
                _rfcProvCertif = value
            End Set
        End Property

        Public Property Leyenda As String
            Get
                Return _leyenda
            End Get
            Set(ByVal value As String)
                _leyenda = value
            End Set
        End Property

        Public Property SelloCFD As String
            Get
                Return _selloCFD
            End Get
            Set(ByVal value As String)
                _selloCFD = value
            End Set
        End Property

        Public Property NoCertificadoSAT As String
            Get
                Return _noCertificadoSAT
            End Get
            Set(ByVal value As String)
                _noCertificadoSAT = value
            End Set
        End Property

        Public Property SelloSAT As String
            Get
                Return _selloSAT
            End Get
            Set(ByVal value As String)
                _selloSAT = value
            End Set
        End Property
    End Class

End Namespace
#Region "CartaPorte30"

#End Region