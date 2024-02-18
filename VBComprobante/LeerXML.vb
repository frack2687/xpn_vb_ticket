Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Runtime.InteropServices

Public Class LeerXML
    Public Shared Function ObtenerComprobante(ByVal rutaXML As String) As Comprobante
        Dim documento As XmlDocument = New XmlDocument()
        Dim comprobante As Comprobante = New Comprobante()
        documento.Load(rutaXML)
        documento.PreserveWhitespace = True
        ObtenerNodoComprobante(documento, comprobante)
        comprobante.InformacionGlobal = ObtenerNodoInformacionGlobal(documento)
        comprobante.CfdiRelacionados = ObtenerNodoCfdisRelacionados(documento)
        comprobante.Emisor = ObtenerNodoEmisor(documento)
        comprobante.Receptor = ObtenerNodoReceptor(documento)
        comprobante.Conceptos = ObtenerNodoConceptos(documento)
        comprobante.Impuestos = ObtenerNodoImpuestos(documento)
        comprobante.Complemento = ObtenerNodoComplemento(documento)
        comprobante.Addenda = ObtenerNodoAdenda(documento)
        comprobante.AcuseCancelacion = ObtenerAcuseCancelacion(documento)
        comprobante.xml = documento.InnerXml
        Return comprobante
    End Function
    Private Shared Sub ObtenerNodoComprobante(ByVal documento As XmlDocument, ByRef comprobante As Comprobante)
        Dim fecha As DateTime
        Dim valueFloat As Decimal
        comprobante = New Comprobante()
        Dim lComprobante As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
        If lComprobante.Count = 0 Then Return
        Dim nComprobante As XmlElement = TryCast(lComprobante(0), XmlElement)
        If nComprobante.HasAttribute("Version") Then comprobante.Version = nComprobante.GetAttribute("Version")
        If nComprobante.HasAttribute("Serie") Then comprobante.Serie = nComprobante.GetAttribute("Serie")
        If nComprobante.HasAttribute("Folio") Then comprobante.Folio = nComprobante.GetAttribute("Folio")
        If nComprobante.HasAttribute("Fecha") Then comprobante.Fecha = If(DateTime.TryParse(nComprobante.GetAttribute("Fecha"), fecha), fecha, DateTime.Now)
        If nComprobante.HasAttribute("Sello") Then comprobante.Sello = nComprobante.GetAttribute("Sello")
        If nComprobante.HasAttribute("FormaPago") Then comprobante.FormaPago = nComprobante.GetAttribute("FormaPago")
        If nComprobante.HasAttribute("NoCertificado") Then comprobante.NoCertificado = nComprobante.GetAttribute("NoCertificado")
        If nComprobante.HasAttribute("Certificado") Then comprobante.Certificado = nComprobante.GetAttribute("Certificado")
        If nComprobante.HasAttribute("CondicionesDePago") Then comprobante.CondicionesDePago = nComprobante.GetAttribute("CondicionesDePago")
        If nComprobante.HasAttribute("SubTotal") Then comprobante.SubTotal = If(Decimal.TryParse(nComprobante.GetAttribute("SubTotal"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Descuento") Then comprobante.Descuento = If(Decimal.TryParse(nComprobante.GetAttribute("Descuento"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Moneda") Then comprobante.Moneda = nComprobante.GetAttribute("Moneda")
        If nComprobante.HasAttribute("TipoCambio") Then comprobante.TipoCambio = If(Decimal.TryParse(nComprobante.GetAttribute("TipoCambio"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Total") Then comprobante.Total = If(Decimal.TryParse(nComprobante.GetAttribute("Total"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("TipoDeComprobante") Then comprobante.TipoDeComprobante = nComprobante.GetAttribute("TipoDeComprobante")
        If nComprobante.HasAttribute("Exportacion") Then comprobante.Exportacion = nComprobante.GetAttribute("Exportacion")
        If nComprobante.HasAttribute("MetodoPago") Then comprobante.MetodoPago = nComprobante.GetAttribute("MetodoPago")
        If nComprobante.HasAttribute("LugarExpedicion") Then comprobante.LugarExpedicion = nComprobante.GetAttribute("LugarExpedicion")
        If nComprobante.HasAttribute("Confirmacion") Then comprobante.Confirmacion = nComprobante.GetAttribute("Confirmacion")
    End Sub
    Private Shared Function ObtenerNodoInformacionGlobal(ByVal documento As XmlDocument) As InformacionGlobal
        If documento.GetElementsByTagName("cfdi:InformacionGlobal") Is Nothing OrElse documento.GetElementsByTagName("cfdi:InformacionGlobal").Count = 0 Then Return Nothing
        Dim informacionGlobal As InformacionGlobal = New InformacionGlobal()
        Dim lInformacionGlobal As XmlNodeList = documento.GetElementsByTagName("cfdi:InformacionGlobal")
        Dim nInformacionGlobal As XmlElement = lInformacionGlobal(0)
        If (nInformacionGlobal.HasAttribute("Año")) Then informacionGlobal.Ano = nInformacionGlobal.GetAttribute("Año")
        If (nInformacionGlobal.HasAttribute("Meses")) Then informacionGlobal.Meses = nInformacionGlobal.GetAttribute("Meses")
        If (nInformacionGlobal.HasAttribute("Periodicidad")) Then informacionGlobal.Periodicidad = nInformacionGlobal.GetAttribute("Periodicidad")
        Return informacionGlobal
    End Function
    Private Shared Function ObtenerNodoCfdisRelacionados(ByVal documento As XmlDocument) As CfdiRelacionados
        If documento.GetElementsByTagName("cfdi:CfdiRelacionados") Is Nothing OrElse documento.GetElementsByTagName("cfdi:CfdiRelacionados").Count = 0 Then Return Nothing
        Dim cfdiRelacionados As CfdiRelacionados = New CfdiRelacionados()
        Dim lCfdiRelacionados As XmlNodeList = documento.GetElementsByTagName("cfdi:CfdiRelacionados")
        If (CType(lCfdiRelacionados(0), XmlElement)).GetAttribute("TipoRelacion") IsNot Nothing Then cfdiRelacionados.TipoRelacion = (CType(lCfdiRelacionados(0), XmlElement)).GetAttribute("TipoRelacion")
        If (CType(lCfdiRelacionados(0), XmlElement)).GetElementsByTagName("cfdi:Relacionado") Is Nothing Then Return cfdiRelacionados
        Dim ListaCfdiRelacionados As XmlNodeList = (CType(lCfdiRelacionados(0), XmlElement)).GetElementsByTagName("cfdi:CfdiRelacionado")

        For Each nodo As XmlElement In ListaCfdiRelacionados
            Dim c As CfdiRelacionado = New CfdiRelacionado()
            If nodo.GetAttribute("UUID") IsNot Nothing Then c.UUID = nodo.GetAttribute("UUID")
            cfdiRelacionados.CfdiRelacionado.Add(c)
        Next

        Return cfdiRelacionados
    End Function
    Private Shared Function ObtenerNodoEmisor(ByVal documento As XmlDocument) As Emisor
        Dim lEmisores As XmlNodeList = documento.GetElementsByTagName("cfdi:Emisor")
        If lEmisores.Count = 0 Then Return Nothing
        Dim nEmisor As XmlElement = TryCast(lEmisores(0), XmlElement)
        Dim emisor As Emisor = New Emisor()
        If nEmisor.HasAttribute("Rfc") Then emisor.Rfc = nEmisor.GetAttribute("Rfc")
        If nEmisor.HasAttribute("Nombre") Then emisor.Nombre = nEmisor.GetAttribute("Nombre")
        If nEmisor.HasAttribute("RegimenFiscal") Then emisor.RegimenFiscal = nEmisor.GetAttribute("RegimenFiscal")
        If nEmisor.HasAttribute("FacAtrAdquirente") Then emisor.FacAtrAdquirente = nEmisor.GetAttribute("FacAtrAdquirente")
        Return emisor
    End Function
    Private Shared Function ObtenerAcuseCancelacion(ByVal documento As XmlDocument) As Acuse
        Dim fecha As DateTime
        Dim lCancelacion As XmlNodeList = documento.GetElementsByTagName("Acuse")
        If lCancelacion.Count = 0 Then Return Nothing
        Dim nCancelacion As XmlElement = TryCast(lCancelacion(0), XmlElement)
        Dim cancelacion As Acuse = New Acuse()
        cancelacion.RfcEmisor = nCancelacion.GetAttribute("RfcEmisor")
        cancelacion.Fecha = If(DateTime.TryParse(nCancelacion.GetAttribute("Fecha"), fecha), fecha, DateTime.Now)
        Dim lFolios As XmlNodeList = nCancelacion.GetElementsByTagName("Folios")

        If lFolios.Count > 0 Then
            cancelacion.Folios = New Folios()
            Dim nFolios As XmlElement = TryCast(lFolios(0), XmlElement)
            Dim nUUID As XmlElement = TryCast((nFolios.GetElementsByTagName("UUID"))(0), XmlElement)
            Dim nEstatusUUID As XmlElement = TryCast((nFolios.GetElementsByTagName("EstatusUUID"))(0), XmlElement)
            cancelacion.Folios.EstatusUUID = nEstatusUUID.InnerText
            cancelacion.Folios.UUID = nUUID.InnerText
        End If

        Return cancelacion
    End Function
    Private Shared Function ObtenerNodoReceptor(ByVal documento As XmlDocument) As Receptor
        Dim lReceptor As XmlNodeList = documento.GetElementsByTagName("cfdi:Receptor")
        If lReceptor.Count = 0 Then Return Nothing
        Dim nReceptor As XmlElement = TryCast(lReceptor(0), XmlElement)
        Dim receptor As Receptor = New Receptor()
        If nReceptor.HasAttribute("Rfc") Then receptor.Rfc = nReceptor.GetAttribute("Rfc")
        If nReceptor.HasAttribute("Nombre") Then receptor.Nombre = nReceptor.GetAttribute("Nombre")
        If nReceptor.HasAttribute("DomicilioFiscalReceptor") Then receptor.DomicilioFiscalReceptor = nReceptor.GetAttribute("DomicilioFiscalReceptor")
        If nReceptor.HasAttribute("ResidenciaFiscal") Then receptor.ResidenciaFiscal = nReceptor.GetAttribute("ResidenciaFiscal")
        If nReceptor.HasAttribute("NumRegIdTrib") Then receptor.NumRegIdTrib = nReceptor.GetAttribute("NumRegIdTrib")
        If nReceptor.HasAttribute("RegimenFiscalReceptor") Then receptor.RegimenFiscalReceptor = nReceptor.GetAttribute("RegimenFiscalReceptor")
        If nReceptor.HasAttribute("UsoCFDI") Then receptor.UsoCFDI = nReceptor.GetAttribute("UsoCFDI")
        Return receptor
    End Function
    Private Shared Function ObtenerNodoConceptos(ByVal documento As XmlDocument) As Conceptos
        Dim valDecimal As Decimal
        Dim lConceptos As XmlNodeList = documento.GetElementsByTagName("cfdi:Conceptos")
        If lConceptos.Count = 0 Then Return Nothing
        Dim conceptos As Conceptos = New Conceptos()
        conceptos.Concepto = New List(Of Concepto)()
        Dim nConceptos As XmlElement = TryCast(lConceptos(0), XmlElement)
        Dim lConcepto As XmlNodeList = nConceptos.GetElementsByTagName("cfdi:Concepto")

        For Each nConcepto As XmlElement In lConcepto
            Dim concepto As Concepto = New Concepto()
            If nConcepto.HasAttribute("ClaveProdServ") Then concepto.ClaveProdServ = nConcepto.GetAttribute("ClaveProdServ")
            If nConcepto.HasAttribute("NoIdentificacion") Then concepto.NoIdentificacion = nConcepto.GetAttribute("NoIdentificacion")
            If nConcepto.HasAttribute("Cantidad") Then concepto.Cantidad = If(Decimal.TryParse(nConcepto.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("ClaveUnidad") Then concepto.ClaveUnidad = nConcepto.GetAttribute("ClaveUnidad")
            If nConcepto.HasAttribute("Unidad") Then concepto.Unidad = nConcepto.GetAttribute("Unidad")
            If nConcepto.HasAttribute("Descripcion") Then concepto.Descripcion = nConcepto.GetAttribute("Descripcion")
            If nConcepto.HasAttribute("ValorUnitario") Then concepto.ValorUnitario = If(Decimal.TryParse(nConcepto.GetAttribute("ValorUnitario"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("Importe") Then concepto.Importe = If(Decimal.TryParse(nConcepto.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("Descuento") Then concepto.Descuento = If(Decimal.TryParse(nConcepto.GetAttribute("Descuento"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("ObjetoImp") Then concepto.ObjetoImp = nConcepto.GetAttribute("ObjetoImp")
            concepto.ACuentaTerceros = ObtenerAcuentaTercerosConcepto(nConcepto)
            concepto.Impuestos = ObtenerImpuestosConcepto(nConcepto)
            concepto.InformacionAduanera = ObtenerInformacionAduaneraConcepto(nConcepto)
            concepto.CuentaPredial = ObtenerCuentaPredialConcepto(nConcepto)
            concepto.Parte = ObtenerParteC(nConcepto)
            conceptos.Concepto.Add(concepto)
        Next

        Return conceptos
    End Function
    Private Shared Function ObtenerImpuestosConcepto(ByVal nodoConcepto As XmlElement) As ImpuestosC
        Dim valDecimal As Decimal
        Dim lImpuestos As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:Impuestos")
        If lImpuestos.Count = 0 Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lImpuestos(0), XmlElement)
        Dim lTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Traslados")
        Dim impuestos As ImpuestosC = New ImpuestosC()

        If lTraslados.Count > 0 Then
            Dim traslados As List(Of TrasladoC) = New List(Of TrasladoC)()
            Dim nTraslados As XmlElement = TryCast(lTraslados(0), XmlElement)

            For Each nTraslado As XmlElement In nTraslados.GetElementsByTagName("cfdi:Traslado")
                Dim traslado As TrasladoC = New TrasladoC()
                If nTraslado.HasAttribute("Base") Then traslado.Base = If(Decimal.TryParse(nTraslado.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nTraslado.GetAttribute("Impuesto")
                If nTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nTraslado.GetAttribute("TipoFactor")
                If nTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                traslados.Add(traslado)
            Next

            impuestos.Traslados = traslados
        End If

        Dim lRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Retenciones")

        If lRetenciones.Count > 0 Then
            Dim retenciones As List(Of RetencionC) = New List(Of RetencionC)()
            Dim nRetenciones As XmlElement = TryCast(lRetenciones(0), XmlElement)

            For Each nRetencion As XmlElement In nRetenciones.GetElementsByTagName("cfdi:Retencion")
                Dim retencion As RetencionC = New RetencionC()
                If nRetencion.HasAttribute("Base") Then retencion.Base = If(Decimal.TryParse(nRetencion.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nRetencion.GetAttribute("Impuesto")
                If nRetencion.HasAttribute("TipoFactor") Then retencion.TipoFactor = nRetencion.GetAttribute("TipoFactor")
                If nRetencion.HasAttribute("TasaOCuota") Then retencion.TasaOCuota = If(Decimal.TryParse(nRetencion.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                retenciones.Add(retencion)
            Next

            impuestos.Retenciones = retenciones
        End If

        Return impuestos
    End Function
    Private Shared Function ObtenerAcuentaTercerosConcepto(ByVal nodoConcepto As XmlElement) As ACuentaTercerosC
        Dim lACuentaTerceros As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:ACuentaTerceros")
        If lACuentaTerceros.Count = 0 Then Return Nothing
        Dim aCuentaTerceros As ACuentaTercerosC = New ACuentaTercerosC()
        Dim nInformacionAduanera As XmlElement = TryCast(lACuentaTerceros(0), XmlElement)
        If nInformacionAduanera.HasAttribute("RfcACuentaTerceros") Then aCuentaTerceros.RfcACuentaTerceros = nInformacionAduanera.GetAttribute("RfcACuentaTerceros")
        If nInformacionAduanera.HasAttribute("NombreACuentaTerceros") Then aCuentaTerceros.NombreACuentaTerceros = nInformacionAduanera.GetAttribute("NombreACuentaTerceros")
        If nInformacionAduanera.HasAttribute("RegimenFiscalACuentaTerceros") Then aCuentaTerceros.RegimenFiscalACuentaTerceros = nInformacionAduanera.GetAttribute("RegimenFiscalACuentaTerceros")
        If nInformacionAduanera.HasAttribute("DomicilioFiscalACuentaTerceros") Then aCuentaTerceros.DomicilioFiscalACuentaTerceros = nInformacionAduanera.GetAttribute("DomicilioFiscalACuentaTerceros")
        Return aCuentaTerceros
    End Function
    Private Shared Function ObtenerInformacionAduaneraConcepto(ByVal nodoConcepto As XmlElement) As List(Of InformacionAduaneraC)
        Dim lInformacionAduanera As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:InformacionAduanera")
        If lInformacionAduanera.Count = 0 Then Return Nothing
        Dim lista As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
        Dim nInformacionAduanera As XmlElement = TryCast(lInformacionAduanera(0), XmlElement)

        For Each nInformacionA As XmlElement In lInformacionAduanera
            Dim informacionAduanera As InformacionAduaneraC = New InformacionAduaneraC()
            If nInformacionA.HasAttribute("NumeroPedimento") Then informacionAduanera.NumeroPedimento = nInformacionA.GetAttribute("NumeroPedimento")
            lista.Add(informacionAduanera)
        Next

        Return lista
    End Function
    Private Shared Function ObtenerCuentaPredialConcepto(ByVal nodoConcepto As XmlElement) As List(Of CuentaPredialC)
        Dim listaCuentaPredial As List(Of CuentaPredialC) = New List(Of CuentaPredialC)
        Dim lnCuentaPredial As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:CuentaPredial")
        If lnCuentaPredial.Count = 0 Then Return Nothing
        For Each nCuentaPredial As XmlElement In lnCuentaPredial
            Dim cuentaPredial As CuentaPredialC = New CuentaPredialC()
            If nCuentaPredial.HasAttribute("Numero") Then cuentaPredial.Numero = nCuentaPredial.GetAttribute("Numero")
            listaCuentaPredial.Add(cuentaPredial)
        Next
        'Dim nCuentaPredial As XmlElement = TryCast(lCuentaPredial(0), XmlElement)
        Return listaCuentaPredial
    End Function
    Private Shared Function ObtenerParteC(ByVal nodoConcepto As XmlElement) As List(Of ParteC)
        Dim valDecimal As Decimal
        Dim lParte As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:Parte")
        Dim lista As List(Of ParteC) = New List(Of ParteC)()
        For Each nParte As XmlElement In lParte
            Dim parte As ParteC = New ParteC()
            If nParte.HasAttribute("ClaveProdServ") Then parte.ClaveProdServ = nParte.GetAttribute("ClaveProdServ")
            If nParte.HasAttribute("NoIdentificacion") Then parte.NoIdentificacion = nParte.GetAttribute("NoIdentificacion")
            If nParte.HasAttribute("Cantidad") Then parte.Cantidad = If(Decimal.TryParse(nParte.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
            If nParte.HasAttribute("Unidad") Then parte.Unidad = nParte.GetAttribute("Unidad")
            If nParte.HasAttribute("Descripcion") Then parte.Descripcion = nParte.GetAttribute("Descripcion")
            If nParte.HasAttribute("ValorUnitario") Then parte.ValorUnitario = If(Decimal.TryParse(nParte.GetAttribute("ValorUnitario"), valDecimal), valDecimal, 0)
            If nParte.HasAttribute("Importe") Then parte.Importe = If(Decimal.TryParse(nParte.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            lista.Add(parte)
        Next

        Return lista
    End Function
    Private Shared Function ObtenerNodoImpuestos(ByVal documento As XmlDocument) As Impuestos
        Dim valDecimal As Decimal
        Dim lImpuestos As XmlNodeList = documento.GetElementsByTagName("cfdi:Impuestos")
        If lImpuestos.Count = 0 Then Return Nothing
        Dim encontrado As Boolean = False
        Dim indice As Integer = 0

        For Each item As XmlElement In lImpuestos

            If item.ParentNode.Name = "cfdi:Comprobante" Then
                encontrado = True
                Exit For
            End If

            indice += 1
        Next

        If Not encontrado Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lImpuestos(indice), XmlElement)
        Dim impuestos As Impuestos = New Impuestos()
        If nImpuestos.HasAttribute("TotalImpuestosRetenidos") Then impuestos.TotalImpuestosRetenidos = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
        If nImpuestos.HasAttribute("TotalImpuestosTrasladados") Then impuestos.TotalImpuestosTrasladados = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosTrasladados"), valDecimal), valDecimal, 0)
        Dim lRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Retenciones")

        If lRetenciones.Count > 0 Then
            Dim retenciones As List(Of Retencion) = New List(Of Retencion)()
            Dim nRetenciones As XmlElement = TryCast(lRetenciones(0), XmlElement)

            For Each nRetencion As XmlElement In nRetenciones.GetElementsByTagName("cfdi:Retencion")
                Dim retencion As Retencion = New Retencion()
                If nRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nRetencion.GetAttribute("Impuesto")
                If nRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                retenciones.Add(retencion)
            Next

            impuestos.Retenciones = retenciones
        End If

        Dim lTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Traslados")

        If lTraslados.Count > 0 Then
            Dim traslados As List(Of Traslado) = New List(Of Traslado)()
            Dim nTraslados As XmlElement = TryCast(lTraslados(0), XmlElement)

            For Each nTraslado As XmlElement In nTraslados.GetElementsByTagName("cfdi:Traslado")
                Dim traslado As Traslado = New Traslado()
                If nTraslado.HasAttribute("Base") Then traslado.Base = If(Decimal.TryParse(nTraslado.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nTraslado.GetAttribute("Impuesto")
                If nTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nTraslado.GetAttribute("TipoFactor")
                If nTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                traslados.Add(traslado)
            Next

            impuestos.Traslados = traslados
        End If

        Return impuestos
    End Function
    Private Shared Function ObtenerNodoComplemento(ByVal documento As XmlDocument) As Complemento
        Dim complemento As Complemento = New Complemento()
        Dim listaComplemento As XmlNodeList = documento.GetElementsByTagName("cfdi:Complemento")
        If listaComplemento.Count = 0 Then Return Nothing
        Dim nodoComplemento As XmlElement = TryCast(listaComplemento(0), XmlElement)
        'complemento.CartaPorte10 = Clasesfacturacion.CartaPorte10.Leer.ObtenerNodoComplementoCartaPorte(nodoComplemento)
        complemento.CartaPorte20 = ObtenerNodoComplementoCartaPorte20(nodoComplemento)
        complemento.TimbreFiscalDigital = ObtenerNodoComplementoTimbreFiscalDigital(documento)
        complemento.Nomina = ObtenerNodoComplementoNomina12(documento)
        complemento.Pagos10 = ObtenerNodoPagos10(documento)
        complemento.Pagos20 = ObtenerNodoPagos20(documento)
        complemento.CartaPorte30 = Leer.ObtenerNodoComplementoCartaPorte(documento)
        Return complemento
    End Function

#Region "Leer Complementos"
#Region "Addenda"
    Private Shared Function ObtenerNodoAdenda(ByVal documento As XmlDocument) As Addenda
        Dim lAdenda As XmlNodeList = documento.GetElementsByTagName("cfdi:Addendas")
        If lAdenda.Count = 0 Then Return Nothing
        Dim nAdenda As XmlElement = TryCast(lAdenda(0), XmlElement)
        Dim adenda As Addenda = New Addenda()
        If nAdenda.HasAttribute("Direccion1") Then adenda.Direccion = nAdenda.GetAttribute("Direccion1")
        Return adenda
    End Function
#End Region
#Region "Carta Porte 2.0"
    Public Shared Function ObtenerNodoComplementoCartaPorte20(ByVal documento As XmlElement) As CartaPorte20
        Dim valDecimal As Decimal
        Dim cartaPorte As CartaPorte20 = New CartaPorte20()
        Dim listaCartaPorte As XmlNodeList = documento.GetElementsByTagName("cartaporte20:CartaPorte")
        If listaCartaPorte.Count = 0 Then Return Nothing
        Dim nodoCartaPorte As XmlElement = TryCast(listaCartaPorte(0), XmlElement)
        If nodoCartaPorte.HasAttribute("Version") Then cartaPorte.Version = nodoCartaPorte.GetAttribute("Version")
        If cartaPorte.Version <> "2.0" Then Return Nothing
        cartaPorte.Ubicaciones = ObtenerUbicacionesCP20(nodoCartaPorte)
        cartaPorte.Mercancias = ObtenerMercanciasCP20(nodoCartaPorte)
        cartaPorte.FiguraTransporte = ObtenerFiguraTransporteCP20(nodoCartaPorte)
        If nodoCartaPorte.HasAttribute("TranspInternac") Then cartaPorte.TranspInternac = nodoCartaPorte.GetAttribute("TranspInternac")
        If nodoCartaPorte.HasAttribute("EntradaSalidaMerc") Then cartaPorte.EntradaSalidaMerc = nodoCartaPorte.GetAttribute("EntradaSalidaMerc")
        If nodoCartaPorte.HasAttribute("PaisOrigenDestino") Then cartaPorte.PaisOrigenDestino = nodoCartaPorte.GetAttribute("PaisOrigenDestino")
        If nodoCartaPorte.HasAttribute("ViaEntradaSalida") Then cartaPorte.ViaEntradaSalida = nodoCartaPorte.GetAttribute("ViaEntradaSalida")
        If nodoCartaPorte.HasAttribute("TotalDistRec") Then cartaPorte.TotalDistRec = If(Decimal.TryParse(nodoCartaPorte.GetAttribute("TotalDistRec"), valDecimal), valDecimal, 0D)
        Return cartaPorte
    End Function

    Private Shared Function ObtenerUbicacionesCP20(ByVal nodoCartaPorte As XmlElement) As CP20Ubicaciones
        Dim ubicaciones As CP20Ubicaciones = New CP20Ubicaciones()
        Dim listaUbicaciones As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:Ubicaciones")
        If listaUbicaciones.Count = 0 Then Return Nothing
        Dim nodoUbicaciones As XmlElement = TryCast(listaUbicaciones(0), XmlElement)
        ubicaciones.Ubicacion = ObtenerUbicacionCP20(nodoUbicaciones)
        Return ubicaciones
    End Function

    Private Shared Function ObtenerUbicacionCP20(ByVal nodoUbicaciones As XmlElement) As List(Of CP20Ubicacion)
        Dim valDecimal As Decimal
        Dim valDateTime As DateTime
        Dim listaUbicacion As List(Of CP20Ubicacion) = New List(Of CP20Ubicacion)()

        For Each item As XmlElement In nodoUbicaciones.GetElementsByTagName("cartaporte20:Ubicacion")
            Dim ubicacion As CP20Ubicacion = New CP20Ubicacion()
            ubicacion.Domicilio = ObtenerDomicilioCP20(item)
            If item.HasAttribute("TipoUbicacion") Then ubicacion.TipoUbicacion = item.GetAttribute("TipoUbicacion")
            If item.HasAttribute("IDUbicacion") Then ubicacion.IDUbicacion = item.GetAttribute("IDUbicacion")
            If item.HasAttribute("RFCRemitenteDestinatario") Then ubicacion.RFCRemitenteDestinatario = item.GetAttribute("RFCRemitenteDestinatario")
            If item.HasAttribute("NombreRemitenteDestinatario") Then ubicacion.NombreRemitenteDestinatario = item.GetAttribute("NombreRemitenteDestinatario")
            If item.HasAttribute("NumRegIdTrib") Then ubicacion.NumRegIdTrib = item.GetAttribute("NumRegIdTrib")
            If item.HasAttribute("ResidenciaFiscal") Then ubicacion.ResidenciaFiscal = item.GetAttribute("ResidenciaFiscal")
            If item.HasAttribute("NumEstacion") Then ubicacion.NumEstacion = item.GetAttribute("NumEstacion")
            If item.HasAttribute("NombreEstacion") Then ubicacion.NombreEstacion = item.GetAttribute("NombreEstacion")
            If item.HasAttribute("NavegacionTrafico") Then ubicacion.NavegacionTrafico = item.GetAttribute("NavegacionTrafico")
            If item.HasAttribute("FechaHoraSalidaLlegada") Then ubicacion.FechaHoraSalidaLlegada = If(DateTime.TryParse(item.GetAttribute("FechaHoraSalidaLlegada"), valDateTime), valDateTime, DateTime.Now)
            If item.HasAttribute("TipoEstacion") Then ubicacion.TipoEstacion = item.GetAttribute("TipoEstacion")
            If item.HasAttribute("DistanciaRecorrida") Then ubicacion.DistanciaRecorrida = If(Decimal.TryParse(item.GetAttribute("DistanciaRecorrida"), valDecimal), valDecimal, 0D)
            listaUbicacion.Add(ubicacion)
        Next

        Return listaUbicacion
    End Function

    Private Shared Function ObtenerDomicilioCP20(ByVal nodoUbicacion As XmlElement) As CP20Domicilio
        Dim domicilio As CP20Domicilio = New CP20Domicilio()
        Dim listaDomicilios As XmlNodeList = nodoUbicacion.GetElementsByTagName("cartaporte20:Domicilio")
        If listaDomicilios.Count = 0 Then Return Nothing
        Dim nodoDomicilio As XmlElement = TryCast(listaDomicilios(0), XmlElement)
        If nodoDomicilio.HasAttribute("Calle") Then domicilio.Calle = nodoDomicilio.GetAttribute("Calle")
        If nodoDomicilio.HasAttribute("NumeroExterior") Then domicilio.NumeroExterior = nodoDomicilio.GetAttribute("NumeroExterior")
        If nodoDomicilio.HasAttribute("NumeroInterior") Then domicilio.NumeroInterior = nodoDomicilio.GetAttribute("NumeroInterior")
        If nodoDomicilio.HasAttribute("Colonia") Then domicilio.Colonia = nodoDomicilio.GetAttribute("Colonia")
        If nodoDomicilio.HasAttribute("Localidad") Then domicilio.Localidad = nodoDomicilio.GetAttribute("Localidad")
        If nodoDomicilio.HasAttribute("Referencia") Then domicilio.Referencia = nodoDomicilio.GetAttribute("Referencia")
        If nodoDomicilio.HasAttribute("Municipio") Then domicilio.Municipio = nodoDomicilio.GetAttribute("Municipio")
        If nodoDomicilio.HasAttribute("Estado") Then domicilio.Estado = nodoDomicilio.GetAttribute("Estado")
        If nodoDomicilio.HasAttribute("Pais") Then domicilio.Pais = nodoDomicilio.GetAttribute("Pais")
        If nodoDomicilio.HasAttribute("CodigoPostal") Then domicilio.CodigoPostal = nodoDomicilio.GetAttribute("CodigoPostal")
        Return domicilio
    End Function

    Private Shared Function ObtenerMercanciasCP20(ByVal nodoCartaPorte As XmlElement) As CP20Mercancias
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim mercancias As CP20Mercancias = New CP20Mercancias()
        Dim listaMercancias As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:Mercancias")
        If listaMercancias.Count = 0 Then Return Nothing
        Dim nodoMercancias As XmlElement = TryCast(listaMercancias(0), XmlElement)
        mercancias.Mercancia = ObtenerMercanciaCP20(nodoMercancias)
        mercancias.Autotransporte = ObtenerAutoTransporteCP20(nodoMercancias)
        mercancias.TransporteMaritimo = ObtenerTransporteMaritimoCP20(nodoMercancias)
        mercancias.TransporteAereo = ObtenerTransporteAereoCP20(nodoMercancias)
        mercancias.TransporteFerroviario = ObtenerTransporteFerroviarioCP20(nodoMercancias)
        If nodoMercancias.HasAttribute("PesoBrutoTotal") Then mercancias.PesoBrutoTotal = If(Decimal.TryParse(nodoMercancias.GetAttribute("PesoBrutoTotal"), valDecimal), valDecimal, 0D)
        If nodoMercancias.HasAttribute("UnidadPeso") Then mercancias.UnidadPeso = nodoMercancias.GetAttribute("UnidadPeso")
        If nodoMercancias.HasAttribute("PesoNetoTotal") Then mercancias.PesoNetoTotal = If(Decimal.TryParse(nodoMercancias.GetAttribute("PesoNetoTotal"), valDecimal), valDecimal, 0D)
        If nodoMercancias.HasAttribute("NumTotalMercancias") Then mercancias.NumTotalMercancias = If(Integer.TryParse(nodoMercancias.GetAttribute("NumTotalMercancias"), valInt), valInt, 0)
        If nodoMercancias.HasAttribute("CargoPorTasacion") Then mercancias.CargoPorTasacion = If(Decimal.TryParse(nodoMercancias.GetAttribute("CargoPorTasacion"), valDecimal), valDecimal, 0D)
        Return mercancias
    End Function

    Private Shared Function ObtenerMercanciaCP20(ByVal nodoMercancias As XmlElement) As List(Of CP20Mercancia)
        Dim valDecimal As Decimal
        Dim listaMercancia As List(Of CP20Mercancia) = New List(Of CP20Mercancia)()

        For Each item As XmlElement In nodoMercancias.GetElementsByTagName("cartaporte20:Mercancia")
            Dim mercancia As CP20Mercancia = New CP20Mercancia()
            mercancia.Pedimentos = ObtenerPedimentosCP20(item)
            mercancia.GuiasIdentificacion = ObtenerGuiasIdentificacionCP20(item)
            mercancia.CantidadTransporta = ObtenerCantidadTransportaCP20(item)
            mercancia.DetalleMercancia = ObtenerDetalleMercanciaCP20(item)
            If item.HasAttribute("BienesTransp") Then mercancia.BienesTransp = item.GetAttribute("BienesTransp")
            If item.HasAttribute("ClaveSTCC") Then mercancia.ClaveSTCC = item.GetAttribute("ClaveSTCC")
            If item.HasAttribute("Descripcion") Then mercancia.Descripcion = item.GetAttribute("Descripcion")
            If item.HasAttribute("Cantidad") Then mercancia.Cantidad = If(Decimal.TryParse(item.GetAttribute("Cantidad"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("ClaveUnidad") Then mercancia.ClaveUnidad = item.GetAttribute("ClaveUnidad")
            If item.HasAttribute("Unidad") Then mercancia.Unidad = item.GetAttribute("Unidad")
            If item.HasAttribute("Dimensiones") Then mercancia.Dimensiones = item.GetAttribute("Dimensiones")
            If item.HasAttribute("MaterialPeligroso") Then mercancia.MaterialPeligroso = item.GetAttribute("MaterialPeligroso")
            If item.HasAttribute("CveMaterialPeligroso") Then mercancia.CveMaterialPeligroso = item.GetAttribute("CveMaterialPeligroso")
            If item.HasAttribute("Embalaje") Then mercancia.Embalaje = item.GetAttribute("Embalaje")
            If item.HasAttribute("DescripEmbalaje") Then mercancia.DescripEmbalaje = item.GetAttribute("DescripEmbalaje")
            If item.HasAttribute("PesoEnKg") Then mercancia.PesoEnKg = If(Decimal.TryParse(item.GetAttribute("PesoEnKg"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("ValorMercancia") Then mercancia.ValorMercancia = If(Decimal.TryParse(item.GetAttribute("ValorMercancia"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("Moneda") Then mercancia.Moneda = item.GetAttribute("Moneda")
            If item.HasAttribute("FraccionArancelaria") Then mercancia.FraccionArancelaria = item.GetAttribute("FraccionArancelaria")
            If item.HasAttribute("UUIDComercioExt") Then mercancia.UUIDComercioExt = item.GetAttribute("UUIDComercioExt")
            listaMercancia.Add(mercancia)
        Next

        Return listaMercancia
    End Function

    Private Shared Function ObtenerPedimentosCP20(ByVal nodoMercancia As XmlElement) As List(Of CP20Pedimentos)
        Dim listaPedimentos As List(Of CP20Pedimentos) = New List(Of CP20Pedimentos)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:Pedimentos")
            Dim pedimentos As CP20Pedimentos = New CP20Pedimentos()
            If item.HasAttribute("Pedimentos") Then pedimentos.Pedimento = item.GetAttribute("Pedimentos")
            listaPedimentos.Add(pedimentos)
        Next

        Return listaPedimentos
    End Function

    Private Shared Function ObtenerGuiasIdentificacionCP20(ByVal nodoMercancia As XmlElement) As List(Of CP20GuiasIdentificacion)
        Dim valDecimal As Decimal
        Dim listaGuiasIdentificacion As List(Of CP20GuiasIdentificacion) = New List(Of CP20GuiasIdentificacion)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:GuiasIdentificacion")
            Dim guiasIdentificacion As CP20GuiasIdentificacion = New CP20GuiasIdentificacion()
            If item.HasAttribute("DescripGuiaIdentificacion") Then guiasIdentificacion.DescripGuiaIdentificacion = item.GetAttribute("DescripGuiaIdentificacion")
            If item.HasAttribute("NumeroGuiaIdentificacion") Then guiasIdentificacion.NumeroGuiaIdentificacion = item.GetAttribute("NumeroGuiaIdentificacion")
            If item.HasAttribute("PesoGuiaIdentificacion") Then guiasIdentificacion.PesoGuiaIdentificacion = If(Decimal.TryParse(item.GetAttribute("PesoGuiaIdentificacion"), valDecimal), valDecimal, 0D)
            listaGuiasIdentificacion.Add(guiasIdentificacion)
        Next

        Return listaGuiasIdentificacion
    End Function

    Private Shared Function ObtenerCantidadTransportaCP20(ByVal nodoMercancia As XmlElement) As List(Of CP20CantidadTransporta)
        Dim valDecimal As Decimal
        Dim listaCantidadTransporta As List(Of CP20CantidadTransporta) = New List(Of CP20CantidadTransporta)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:CantidadTransporta")
            Dim cantidadTransporta As CP20CantidadTransporta = New CP20CantidadTransporta()
            If item.HasAttribute("Cantidad") Then cantidadTransporta.Cantidad = If(Decimal.TryParse(item.GetAttribute("Cantidad"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("IDOrigen") Then cantidadTransporta.IDOrigen = item.GetAttribute("IDOrigen")
            If item.HasAttribute("IDDestino") Then cantidadTransporta.IDDestino = item.GetAttribute("IDDestino")
            If item.HasAttribute("CvesTransporte") Then cantidadTransporta.CvesTransporte = item.GetAttribute("CvesTransporte")
            listaCantidadTransporta.Add(cantidadTransporta)
        Next

        Return listaCantidadTransporta
    End Function

    Private Shared Function ObtenerDetalleMercanciaCP20(ByVal nodoMercancia As XmlElement) As CP20DetalleMercancia
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim detalleMercancias As CP20DetalleMercancia = New CP20DetalleMercancia()
        Dim listaDetalleMercancias As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte20:DetalleMercancia")
        If listaDetalleMercancias.Count = 0 Then Return Nothing
        Dim nodoDetalleMercancia As XmlElement = TryCast(listaDetalleMercancias(0), XmlElement)
        If nodoDetalleMercancia.HasAttribute("UnidadPesoMerc") Then detalleMercancias.UnidadPesoMerc = nodoDetalleMercancia.HasAttribute("UnidadPesoMerc").ToString()
        If nodoDetalleMercancia.HasAttribute("PesoBruto") Then detalleMercancias.PesoBruto = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoBruto"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("PesoNeto") Then detalleMercancias.PesoNeto = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoNeto"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("PesoTara") Then detalleMercancias.PesoTara = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoTara"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("NumPiezas") Then detalleMercancias.NumPiezas = If(Integer.TryParse(nodoDetalleMercancia.GetAttribute("NumPiezas"), valInt), valInt, 0)
        Return detalleMercancias
    End Function

    Private Shared Function ObtenerAutoTransporteCP20(ByVal nodoMercancias As XmlElement) As CP20Autotransporte
        Dim autoTransporte As CP20Autotransporte = New CP20Autotransporte()
        Dim listaAutotransporte As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:Autotransporte")
        If listaAutotransporte.Count = 0 Then Return Nothing
        Dim nodoAutotransporte As XmlElement = TryCast(listaAutotransporte(0), XmlElement)
        autoTransporte.IdentificacionVehicular = ObtenerIdentificacionVehicularCP20(nodoAutotransporte)
        autoTransporte.Seguros = ObtenerSegurosCP20(nodoAutotransporte)
        autoTransporte.Remolques = ObtenerRemolquesCP20(nodoAutotransporte)
        If nodoAutotransporte.HasAttribute("PermSCT") Then autoTransporte.PermSCT = nodoAutotransporte.GetAttribute("PermSCT").ToString()
        If nodoAutotransporte.HasAttribute("NumPermisoSCT") Then autoTransporte.NumPermisoSCT = nodoAutotransporte.GetAttribute("NumPermisoSCT").ToString()
        Return autoTransporte
    End Function

    Private Shared Function ObtenerIdentificacionVehicularCP20(ByVal nodoAutotransporteFederal As XmlElement) As CP20IdentificacionVehicular
        Dim valInt As Integer
        Dim identificacionVehicular As CP20IdentificacionVehicular = New CP20IdentificacionVehicular()
        Dim listaIdentificacionVehicular As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte20:IdentificacionVehicular")
        If listaIdentificacionVehicular.Count = 0 Then Return Nothing
        Dim nodoIdentificacionVehicular As XmlElement = TryCast(listaIdentificacionVehicular(0), XmlElement)
        If nodoIdentificacionVehicular.HasAttribute("ConfigVehicular") Then identificacionVehicular.ConfigVehicular = nodoIdentificacionVehicular.GetAttribute("ConfigVehicular").ToString()
        If nodoIdentificacionVehicular.HasAttribute("PlacaVM") Then identificacionVehicular.PlacaVM = nodoIdentificacionVehicular.GetAttribute("PlacaVM").ToString()
        If nodoIdentificacionVehicular.HasAttribute("AnioModeloVM") Then identificacionVehicular.AnioModeloVM = If(Integer.TryParse(nodoIdentificacionVehicular.GetAttribute("AnioModeloVM").ToString(), valInt), valInt, 0)
        Return identificacionVehicular
    End Function

    Private Shared Function ObtenerSegurosCP20(ByVal nodoAutoTransporte As XmlElement) As CP20Seguros
        Dim valDecimal As Decimal
        Dim seguros As CP20Seguros = New CP20Seguros()
        Dim listaSeguros As XmlNodeList = nodoAutoTransporte.GetElementsByTagName("cartaporte20:Seguros")
        If listaSeguros.Count = 0 Then Return Nothing
        Dim nodoSeguros As XmlElement = TryCast(listaSeguros(0), XmlElement)
        If nodoSeguros.HasAttribute("AseguraRespCivil") Then seguros.AseguraRespCivil = nodoSeguros.GetAttribute("AseguraRespCivil")
        If nodoSeguros.HasAttribute("PolizaRespCivil") Then seguros.PolizaRespCivil = nodoSeguros.GetAttribute("PolizaRespCivil")
        If nodoSeguros.HasAttribute("AseguraMedAmbiente") Then seguros.AseguraMedAmbiente = nodoSeguros.GetAttribute("AseguraMedAmbiente")
        If nodoSeguros.HasAttribute("PolizaMedAmbiente") Then seguros.PolizaMedAmbiente = nodoSeguros.GetAttribute("PolizaMedAmbiente")
        If nodoSeguros.HasAttribute("AseguraCarga") Then seguros.AseguraCarga = nodoSeguros.GetAttribute("AseguraCarga")
        If nodoSeguros.HasAttribute("PolizaCarga") Then seguros.PolizaCarga = nodoSeguros.GetAttribute("PolizaCarga")
        If nodoSeguros.HasAttribute("PrimaSeguro") Then seguros.PrimaSeguro = If(Decimal.TryParse(nodoSeguros.GetAttribute("PrimaSeguro"), valDecimal), valDecimal, 0D)
        Return seguros
    End Function

    Private Shared Function ObtenerRemolquesCP20(ByVal nodoAutotransporteFederal As XmlElement) As CP20Remolques
        Dim remolques As CP20Remolques = New CP20Remolques()
        Dim listaRemolques As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte20:Remolques")
        If listaRemolques.Count = 0 Then Return Nothing
        Dim nodoRemolques As XmlElement = TryCast(listaRemolques(0), XmlElement)
        remolques.Remolque = ObtenerRemolqueCP20(nodoRemolques)
        Return remolques
    End Function

    Private Shared Function ObtenerRemolqueCP20(ByVal nodoRemolques As XmlElement) As List(Of CP20Remolque)
        Dim listaRemolque As List(Of CP20Remolque) = New List(Of CP20Remolque)()

        For Each item As XmlElement In nodoRemolques.GetElementsByTagName("cartaporte20:Remolque")
            Dim remolque As CP20Remolque = New CP20Remolque()
            If item.HasAttribute("Placa") Then remolque.Placa = item.GetAttribute("Placa")
            If item.HasAttribute("SubTipoRem") Then remolque.SubTipoRem = item.GetAttribute("SubTipoRem")
            listaRemolque.Add(remolque)
        Next

        Return listaRemolque
    End Function

    Private Shared Function ObtenerTransporteMaritimoCP20(ByVal nodoMercancias As XmlElement) As CP20TransporteMaritimo
        Dim valInt As Integer
        Dim valDecimal As Decimal
        Dim transporteMaritimo As CP20TransporteMaritimo = New CP20TransporteMaritimo()
        Dim listaTransporteMaritimo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteMaritimo")
        If listaTransporteMaritimo.Count = 0 Then Return Nothing
        Dim nodoTransporteMaritimo As XmlElement = TryCast(listaTransporteMaritimo(0), XmlElement)
        transporteMaritimo.Contenedor = ObtenerContenedorCP20(nodoTransporteMaritimo)
        If nodoTransporteMaritimo.HasAttribute("PermSCT") Then transporteMaritimo.PermSCT = nodoTransporteMaritimo.GetAttribute("PermSCT")
        If nodoTransporteMaritimo.HasAttribute("NumPermisoSCT") Then transporteMaritimo.NumPermisoSCT = nodoTransporteMaritimo.GetAttribute("NumPermisoSCT")
        If nodoTransporteMaritimo.HasAttribute("NombreAseg") Then transporteMaritimo.NombreAseg = nodoTransporteMaritimo.GetAttribute("NombreAseg")
        If nodoTransporteMaritimo.HasAttribute("NumPolizaSeguro") Then transporteMaritimo.NumPolizaSeguro = nodoTransporteMaritimo.GetAttribute("NumPolizaSeguro")
        If nodoTransporteMaritimo.HasAttribute("TipoEmbarcacion") Then transporteMaritimo.TipoEmbarcacion = nodoTransporteMaritimo.GetAttribute("TipoEmbarcacion")
        If nodoTransporteMaritimo.HasAttribute("Matricula") Then transporteMaritimo.Matricula = nodoTransporteMaritimo.GetAttribute("Matricula")
        If nodoTransporteMaritimo.HasAttribute("NumeroOMI") Then transporteMaritimo.NumeroOMI = nodoTransporteMaritimo.GetAttribute("NumeroOMI")
        If nodoTransporteMaritimo.HasAttribute("AnioEmbarcacion") Then transporteMaritimo.AnioEmbarcacion = If(Integer.TryParse(nodoTransporteMaritimo.GetAttribute("AnioEmbarcacion"), valInt), valInt, 0)
        If nodoTransporteMaritimo.HasAttribute("NombreEmbarc") Then transporteMaritimo.NombreEmbarc = nodoTransporteMaritimo.GetAttribute("NombreEmbarc")
        If nodoTransporteMaritimo.HasAttribute("NacionalidadEmbarc") Then transporteMaritimo.NacionalidadEmbarc = nodoTransporteMaritimo.GetAttribute("NacionalidadEmbarc")
        If nodoTransporteMaritimo.HasAttribute("UnidadesDeArqBruto") Then transporteMaritimo.UnidadesDeArqBruto = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("UnidadesDeArqBruto"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("TipoCarga") Then transporteMaritimo.TipoCarga = nodoTransporteMaritimo.GetAttribute("TipoCarga")
        If nodoTransporteMaritimo.HasAttribute("NumCertITC") Then transporteMaritimo.NumCertITC = nodoTransporteMaritimo.GetAttribute("NumCertITC")
        If nodoTransporteMaritimo.HasAttribute("Eslora") Then transporteMaritimo.Eslora = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Eslora"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("Manga") Then transporteMaritimo.Manga = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Manga"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("Calado") Then transporteMaritimo.Calado = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Calado"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("LineaNaviera") Then transporteMaritimo.LineaNaviera = nodoTransporteMaritimo.GetAttribute("LineaNaviera")
        If nodoTransporteMaritimo.HasAttribute("NombreAgenteNaviero") Then transporteMaritimo.NombreAgenteNaviero = nodoTransporteMaritimo.GetAttribute("NombreAgenteNaviero")
        If nodoTransporteMaritimo.HasAttribute("NumAutorizacionNaviero") Then transporteMaritimo.NumAutorizacionNaviero = nodoTransporteMaritimo.GetAttribute("NumAutorizacionNaviero")
        If nodoTransporteMaritimo.HasAttribute("NumViaje") Then transporteMaritimo.NumViaje = nodoTransporteMaritimo.GetAttribute("NumViaje")
        If nodoTransporteMaritimo.HasAttribute("NumConocEmbarc") Then transporteMaritimo.NumConocEmbarc = nodoTransporteMaritimo.GetAttribute("NumConocEmbarc")
        Return transporteMaritimo
    End Function

    Private Shared Function ObtenerContenedorCP20(ByVal nodoTransporteMaritimo As XmlElement) As List(Of CP20Contenedor)
        Dim listaContenedor As List(Of CP20Contenedor) = New List(Of CP20Contenedor)()

        For Each item As XmlElement In nodoTransporteMaritimo.GetElementsByTagName("cartaporte20:Contenedor")
            Dim contenedor As CP20Contenedor = New CP20Contenedor()
            If nodoTransporteMaritimo.HasAttribute("MatriculaContenedor") Then contenedor.MatriculaContenedor = nodoTransporteMaritimo.GetAttribute("MatriculaContenedor")
            If nodoTransporteMaritimo.HasAttribute("TipoContenedor") Then contenedor.TipoContenedor = nodoTransporteMaritimo.GetAttribute("TipoContenedor")
            If nodoTransporteMaritimo.HasAttribute("NumPrecinto") Then contenedor.NumPrecinto = nodoTransporteMaritimo.GetAttribute("NumPrecinto")
            listaContenedor.Add(contenedor)
        Next

        Return listaContenedor
    End Function

    Private Shared Function ObtenerTransporteAereoCP20(ByVal nodoMercancias As XmlElement) As CP20TransporteAereo
        Dim transporteAereo As CP20TransporteAereo = New CP20TransporteAereo()
        Dim listaTransporteAereo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteAereo")
        If listaTransporteAereo.Count = 0 Then Return Nothing
        Dim nodoTransporteAereo As XmlElement = TryCast(listaTransporteAereo(0), XmlElement)
        If nodoTransporteAereo.HasAttribute("PermSCT") Then transporteAereo.PermSCT = nodoTransporteAereo.GetAttribute("PermSCT")
        If nodoTransporteAereo.HasAttribute("NumPermisoSCT") Then transporteAereo.NumPermisoSCT = nodoTransporteAereo.GetAttribute("NumPermisoSCT")
        If nodoTransporteAereo.HasAttribute("MatriculaAeronave") Then transporteAereo.MatriculaAeronave = nodoTransporteAereo.GetAttribute("MatriculaAeronave")
        If nodoTransporteAereo.HasAttribute("NombreAseg") Then transporteAereo.NombreAseg = nodoTransporteAereo.GetAttribute("NombreAseg")
        If nodoTransporteAereo.HasAttribute("NumPolizaSeguro") Then transporteAereo.NumPolizaSeguro = nodoTransporteAereo.GetAttribute("NumPolizaSeguro")
        If nodoTransporteAereo.HasAttribute("NumeroGuia") Then transporteAereo.NumeroGuia = nodoTransporteAereo.GetAttribute("NumeroGuia")
        If nodoTransporteAereo.HasAttribute("LugarContrato") Then transporteAereo.LugarContrato = nodoTransporteAereo.GetAttribute("LugarContrato")
        If nodoTransporteAereo.HasAttribute("CodigoTransportista") Then transporteAereo.CodigoTransportista = nodoTransporteAereo.GetAttribute("CodigoTransportista")
        If nodoTransporteAereo.HasAttribute("RFCEmbarcador") Then transporteAereo.RFCEmbarcador = nodoTransporteAereo.GetAttribute("RFCEmbarcador")
        If nodoTransporteAereo.HasAttribute("NumRegIdTribEmbarc") Then transporteAereo.NumRegIdTribEmbarc = nodoTransporteAereo.GetAttribute("NumRegIdTribEmbarc")
        If nodoTransporteAereo.HasAttribute("ResidenciaFiscalEmbarc") Then transporteAereo.ResidenciaFiscalEmbarc = nodoTransporteAereo.GetAttribute("ResidenciaFiscalEmbarc")
        If nodoTransporteAereo.HasAttribute("NombreEmbarcador") Then transporteAereo.NombreEmbarcador = nodoTransporteAereo.GetAttribute("NombreEmbarcador")
        Return transporteAereo
    End Function

    Private Shared Function ObtenerTransporteFerroviarioCP20(ByVal nodoMercancias As XmlElement) As CP20TransporteFerroviario
        Dim transporteFerroviario As CP20TransporteFerroviario = New CP20TransporteFerroviario()
        Dim listaTransporteFerroviario As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteFerroviario")
        If listaTransporteFerroviario.Count = 0 Then Return Nothing
        Dim nodoTransporteFerroviario As XmlElement = TryCast(listaTransporteFerroviario(0), XmlElement)
        transporteFerroviario.DerechosDePaso = ObtenerDerechosDePasoCP20(nodoTransporteFerroviario)
        transporteFerroviario.Carro = ObtenerCarroCP20(nodoTransporteFerroviario)
        If nodoTransporteFerroviario.HasAttribute("TipoDeServicio") Then transporteFerroviario.TipoDeServicio = nodoTransporteFerroviario.GetAttribute("TipoDeServicio")
        If nodoTransporteFerroviario.HasAttribute("TipoDeTrafico") Then transporteFerroviario.TipoDeTrafico = nodoTransporteFerroviario.GetAttribute("TipoDeTrafico")
        If nodoTransporteFerroviario.HasAttribute("NombreAseg") Then transporteFerroviario.NombreAseg = nodoTransporteFerroviario.GetAttribute("NombreAseg")
        If nodoTransporteFerroviario.HasAttribute("NumPolizaSeguro") Then transporteFerroviario.NumPolizaSeguro = nodoTransporteFerroviario.GetAttribute("NumPolizaSeguro")
        Return transporteFerroviario
    End Function

    Private Shared Function ObtenerDerechosDePasoCP20(ByVal nodoTransporteFerroviario As XmlElement) As List(Of CP20DerechosDePaso)
        Dim valDecimal As Decimal
        Dim listaDerechosDePaso As List(Of CP20DerechosDePaso) = New List(Of CP20DerechosDePaso)()

        For Each item As XmlElement In nodoTransporteFerroviario.GetElementsByTagName("cartaporte20:DerechosDePaso")
            Dim derechosDePaso As CP20DerechosDePaso = New CP20DerechosDePaso()
            If item.HasAttribute("TipoDerechoDePaso") Then derechosDePaso.TipoDerechoDePaso = item.GetAttribute("TipoDerechoDePaso")
            If item.HasAttribute("KilometrajePagado") Then derechosDePaso.KilometrajePagado = If(Decimal.TryParse(item.GetAttribute("KilometrajePagado"), valDecimal), valDecimal, 0D)
            listaDerechosDePaso.Add(derechosDePaso)
        Next

        Return listaDerechosDePaso
    End Function

    Private Shared Function ObtenerCarroCP20(ByVal nodoTransporteFerroviario As XmlElement) As List(Of CP20Carro)
        Dim valDecimal As Decimal
        Dim listaCarro As List(Of CP20Carro) = New List(Of CP20Carro)()

        For Each item As XmlElement In nodoTransporteFerroviario.GetElementsByTagName("cartaporte20:Carro")
            Dim carro As CP20Carro = New CP20Carro()
            carro.Contenedor = ObtenerContenedorCarroCP20(item)
            If item.HasAttribute("TipoCarro") Then carro.TipoCarro = item.GetAttribute("TipoCarro")
            If item.HasAttribute("MatriculaCarro") Then carro.MatriculaCarro = item.GetAttribute("MatriculaCarro")
            If item.HasAttribute("GuiaCarro") Then carro.GuiaCarro = item.GetAttribute("GuiaCarro")
            If item.HasAttribute("ToneladasNetasCarro") Then carro.ToneladasNetasCarro = If(Decimal.TryParse(item.GetAttribute("ToneladasNetasCarro"), valDecimal), valDecimal, 0D)
        Next

        Return listaCarro
    End Function

    Private Shared Function ObtenerContenedorCarroCP20(ByVal nodoCarro As XmlElement) As List(Of CP20CarroContenedor)
        Dim valDecimal As Decimal
        Dim listaContenedor As List(Of CP20CarroContenedor) = New List(Of CP20CarroContenedor)()

        For Each item As XmlElement In nodoCarro.GetElementsByTagName("cartaporte20:Contenedor")
            Dim contenedor As CP20CarroContenedor = New CP20CarroContenedor()
            If item.HasAttribute("TipoContenedor") Then contenedor.TipoContenedor = item.GetAttribute("TipoContenedor")
            If item.HasAttribute("PesoContenedorVacio") Then contenedor.PesoContenedorVacio = If(Decimal.TryParse(item.GetAttribute("PesoContenedorVacio"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("PesoNetoMercancia") Then contenedor.PesoNetoMercancia = If(Decimal.TryParse(item.GetAttribute("PesoNetoMercancia"), valDecimal), valDecimal, 0D)
            listaContenedor.Add(contenedor)
        Next

        Return listaContenedor
    End Function

    Private Shared Function ObtenerFiguraTransporteCP20(ByVal nodoCartaPorte As XmlElement) As CP20FiguraTransporte
        Dim figuraTransporte As CP20FiguraTransporte = New CP20FiguraTransporte()
        Dim listaFiguraTransporte As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:FiguraTransporte")
        If listaFiguraTransporte.Count = 0 Then Return Nothing
        Dim nodoFiguraTransporte As XmlElement = TryCast(listaFiguraTransporte(0), XmlElement)
        figuraTransporte.TiposFigura = ObtenerTiposFiguraCP20(nodoFiguraTransporte)
        Return figuraTransporte
    End Function

    Private Shared Function ObtenerTiposFiguraCP20(ByVal nodoFiguraTransporte As XmlElement) As List(Of CP20TiposFigura)
        Dim listaTiposFigura As List(Of CP20TiposFigura) = New List(Of CP20TiposFigura)()

        For Each item As XmlElement In nodoFiguraTransporte.GetElementsByTagName("cartaporte20:TiposFigura")
            Dim tiposFigura As CP20TiposFigura = New CP20TiposFigura()
            tiposFigura.PartesTransporte = ObtenerPartesTransporteCP20(item)
            tiposFigura.Domicilio = ObtenerDomicilioCP20(item)
            If item.HasAttribute("TipoFigura") Then tiposFigura.TipoFigura = item.GetAttribute("TipoFigura")
            If item.HasAttribute("RFCFigura") Then tiposFigura.RFCFigura = item.GetAttribute("RFCFigura")
            If item.HasAttribute("NumLicencia") Then tiposFigura.NumLicencia = item.GetAttribute("NumLicencia")
            If item.HasAttribute("NombreFigura") Then tiposFigura.NombreFigura = item.GetAttribute("NombreFigura")
            If item.HasAttribute("NumRegIdTribFigura") Then tiposFigura.NumRegIdTribFigura = item.GetAttribute("NumRegIdTribFigura")
            If item.HasAttribute("ResidenciaFiscalFigura") Then tiposFigura.ResidenciaFiscalFigura = item.GetAttribute("ResidenciaFiscalFigura")
            listaTiposFigura.Add(tiposFigura)
        Next

        Return listaTiposFigura
    End Function

    Private Shared Function ObtenerPartesTransporteCP20(ByVal nodoTiposFigura As XmlElement) As List(Of CP20PartesTransporte)
        Dim listaPartesTransporte As List(Of CP20PartesTransporte) = New List(Of CP20PartesTransporte)()

        For Each item As XmlElement In nodoTiposFigura.GetElementsByTagName("cartaporte20:PartesTransporte")
            Dim partesTransporte As CP20PartesTransporte = New CP20PartesTransporte()
            If item.HasAttribute("ParteTransporte") Then partesTransporte.ParteTransporte = item.GetAttribute("ParteTransporte")
            listaPartesTransporte.Add(partesTransporte)
        Next

        Return listaPartesTransporte
    End Function
#End Region
#Region "Nomina 1.2"
    Private Shared Function ObtenerNodoComplementoNomina12(ByVal documento As XmlDocument) As Nomina
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lNomina As XmlNodeList = documento.GetElementsByTagName("nomina12:Nomina")
        If lNomina.Count <= 0 Then Return Nothing
        Dim nNomina As XmlElement = TryCast(lNomina(0), XmlElement)
        Dim nomina As Nomina = New Nomina()
        If nNomina.HasAttribute("Version") Then nomina.Version = nNomina.GetAttribute("Version")
        If nNomina.HasAttribute("TipoNomina") Then nomina.TipoNomina = nNomina.GetAttribute("TipoNomina")
        If nNomina.HasAttribute("FechaPago") Then nomina.FechaPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("FechaInicialPago") Then nomina.FechaInicialPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaInicialPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("FechaFinalPago") Then nomina.FechaFinalPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaFinalPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("NumDiasPagados") Then nomina.NumDiasPagados = If(Decimal.TryParse(nNomina.GetAttribute("NumDiasPagados"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalPercepciones") Then nomina.TotalPercepciones = If(Decimal.TryParse(nNomina.GetAttribute("TotalPercepciones"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalDeducciones") Then nomina.TotalDeducciones = If(Decimal.TryParse(nNomina.GetAttribute("TotalDeducciones"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalOtrosPagos") Then nomina.TotalOtrosPagos = If(Decimal.TryParse(nNomina.GetAttribute("TotalOtrosPagos"), valDecimal), valDecimal, 0)
        nomina.Emisor = ObtenerNodoEmisorNomina12(nNomina)
        nomina.Receptor = ObtenerNodoReceptorNomina12(nNomina)
        nomina.Percepciones = ObtenerNodoPercepcionesNomina12(nNomina)
        nomina.Deducciones = ObtenerNodoDeduccionesNomina12(nNomina)
        nomina.OtrosPagos = ObtenerNodoOtrosPagosNomina12(nNomina)
        nomina.Incapacidades = ObtenerNodoIncapacidadesNomina12(nNomina)
        nomina.HorasExtra = ObtenerNodoHorasExtraNomina12(nNomina)
        Return nomina
    End Function
    Private Shared Function ObtenerNodoEmisorNomina12(ByVal nodoNomina As XmlElement) As NEmisor
        Dim lNEmisores As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Emisor")
        If lNEmisores.Count = 0 Then Return Nothing
        Dim nNEmisor As XmlElement = TryCast(lNEmisores(0), XmlElement)
        Dim nEmisor As NEmisor = New NEmisor()
        If nNEmisor.HasAttribute("Curp") Then nEmisor.Curp = nNEmisor.GetAttribute("Curp")
        If nNEmisor.HasAttribute("RegistroPatronal") Then nEmisor.RegistroPatronal = nNEmisor.GetAttribute("RegistroPatronal")
        If nNEmisor.HasAttribute("RfcPatronOrigen") Then nEmisor.RfcPatronOrigen = nNEmisor.GetAttribute("RfcPatronOrigen")
        nEmisor.EntidadSNCF = ObtenerNodoEntidadSNCFEmisorNomina12(nNEmisor)
        Return nEmisor
    End Function
    Private Shared Function ObtenerNodoEntidadSNCFEmisorNomina12(ByVal nodoEmisorNomina As XmlElement) As NEntidadSNCF
        Dim valDecimal As Decimal
        Dim lNEntidadSNCF As XmlNodeList = nodoEmisorNomina.GetElementsByTagName("nomina12:EntidadSNCF")
        If lNEntidadSNCF.Count = 0 Then Return Nothing
        Dim nNEntidadSNCF As XmlElement = TryCast(lNEntidadSNCF(0), XmlElement)
        Dim entidadSNCF As NEntidadSNCF = New NEntidadSNCF()
        If nNEntidadSNCF.HasAttribute("OrigenRecurso") Then entidadSNCF.OrigenRecurso = nNEntidadSNCF.GetAttribute("OrigenRecurso")
        If nNEntidadSNCF.HasAttribute("MontoRecursoPropio") Then entidadSNCF.MontoRecursoPropio = If(Decimal.TryParse(nNEntidadSNCF.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
        Return entidadSNCF
    End Function
    Private Shared Function ObtenerNodoReceptorNomina12(ByVal nodoNomina As XmlElement) As NReceptor
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lNReceptor As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Receptor")
        If lNReceptor.Count = 0 Then Return Nothing
        Dim nNReceptor As XmlElement = TryCast(lNReceptor(0), XmlElement)
        Dim nReceptor As NReceptor = New NReceptor()
        If nNReceptor.HasAttribute("Curp") Then nReceptor.Curp = nNReceptor.GetAttribute("Curp")
        If nNReceptor.HasAttribute("NumSeguridadSocial") Then nReceptor.NumSeguridadSocial = nNReceptor.GetAttribute("NumSeguridadSocial")
        If nNReceptor.HasAttribute("FechaInicioRelLaboral") Then nReceptor.FechaInicioRelLaboral = If(DateTime.TryParse(nNReceptor.GetAttribute("FechaInicioRelLaboral"), fecha), fecha, DateTime.Now)
        If nNReceptor.HasAttribute("Antigüedad") Then nReceptor.Antiguedad = nNReceptor.GetAttribute("Antigüedad")
        If nNReceptor.HasAttribute("TipoContrato") Then nReceptor.TipoContrato = nNReceptor.GetAttribute("TipoContrato")
        If nNReceptor.HasAttribute("Sindicalizado") Then nReceptor.Sindicalizado = nNReceptor.GetAttribute("Sindicalizado")
        If nNReceptor.HasAttribute("TipoJornada") Then nReceptor.TipoJornada = nNReceptor.GetAttribute("TipoJornada")
        If nNReceptor.HasAttribute("TipoRegimen") Then nReceptor.TipoRegimen = nNReceptor.GetAttribute("TipoRegimen")
        If nNReceptor.HasAttribute("NumEmpleado") Then nReceptor.NumEmpleado = nNReceptor.GetAttribute("NumEmpleado")
        If nNReceptor.HasAttribute("Departamento") Then nReceptor.Departamento = nNReceptor.GetAttribute("Departamento")
        If nNReceptor.HasAttribute("Puesto") Then nReceptor.Puesto = nNReceptor.GetAttribute("Puesto")
        If nNReceptor.HasAttribute("RiesgoPuesto") Then nReceptor.RiesgoPuesto = nNReceptor.GetAttribute("RiesgoPuesto")
        If nNReceptor.HasAttribute("PeriodicidadPago") Then nReceptor.PeriodicidadPago = nNReceptor.GetAttribute("PeriodicidadPago")
        If nNReceptor.HasAttribute("Banco") Then nReceptor.Banco = nNReceptor.GetAttribute("Banco")
        If nNReceptor.HasAttribute("CuentaBancaria") Then nReceptor.CuentaBancaria = nNReceptor.GetAttribute("CuentaBancaria")
        If nNReceptor.HasAttribute("SalarioBaseCotApor") Then nReceptor.SalarioBaseCotApor = If(Decimal.TryParse(nNReceptor.GetAttribute("SalarioBaseCotApor"), valDecimal), valDecimal, 0)
        If nNReceptor.HasAttribute("SalarioDiarioIntegrado") Then nReceptor.SalarioDiarioIntegrado = If(Decimal.TryParse(nNReceptor.GetAttribute("SalarioDiarioIntegrado"), valDecimal), valDecimal, 0)
        If nNReceptor.HasAttribute("ClaveEntFed") Then nReceptor.ClaveEntFed = nNReceptor.GetAttribute("ClaveEntFed")
        nReceptor.SubContratacion = ObtenerNodoSubContratacionReceptorNomina12(nNReceptor)
        Return nReceptor
    End Function
    Private Shared Function ObtenerNodoSubContratacionReceptorNomina12(ByVal nodoReceptorNomina As XmlElement) As List(Of NSubContratacion)
        Dim valDecimal As Decimal
        Dim lNSubContratacion As XmlNodeList = nodoReceptorNomina.GetElementsByTagName("nomina12:SubContratacion")
        If lNSubContratacion.Count = 0 Then Return Nothing
        Dim lista As List(Of NSubContratacion) = New List(Of NSubContratacion)()
        Dim nNSubContratacion As XmlElement = TryCast(lNSubContratacion(0), XmlElement)

        For Each nSubContratacion As XmlElement In lNSubContratacion
            Dim SubContratacionN As XmlElement = TryCast(nNSubContratacion, XmlElement)
            Dim subcontratacion As NSubContratacion = New NSubContratacion()
            If nNSubContratacion.HasAttribute("RfcLabora") Then subcontratacion.RfcLabora = nNSubContratacion.GetAttribute("RfcLabora")
            If nNSubContratacion.HasAttribute("PorcentajeTiempo") Then subcontratacion.PorcentajeTiempo = If(Decimal.TryParse(nNSubContratacion.GetAttribute("PorcentajeTiempo"), valDecimal), valDecimal, 0)
            lista.Add(subcontratacion)
        Next

        Return lista
    End Function
    Private Shared Function ObtenerNodoPercepcionesNomina12(ByVal nodoNomina As XmlElement) As NPercepciones
        Dim valDecimal As Decimal
        Dim nPercepciones As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Percepciones")
        If nPercepciones.Count = 0 Then Return Nothing
        Dim nPercepcion As XmlElement = TryCast(nPercepciones(0), XmlElement)
        Dim percepciones As NPercepciones = New NPercepciones()
        If nPercepcion.HasAttribute("TotalSueldos") Then percepciones.TotalSueldos = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalSueldos"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalSeparacionIndemnizacion") Then percepciones.TotalSeparacionIndemnizacion = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalSeparacionIndemnizacion"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalJubilacionPensionRetiro") Then percepciones.TotalJubilacionPensionRetiro = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalJubilacionPensionRetiro"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalGravado") Then percepciones.TotalGravado = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalGravado"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalExento") Then percepciones.TotalExento = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalExento"), valDecimal), valDecimal, 0)
        percepciones.Percepcion = New List(Of NPercepcion)()

        For Each p As XmlElement In nPercepcion.GetElementsByTagName("nomina12:Percepcion")
            Dim percepcion As NPercepcion = New NPercepcion()
            If p.HasAttribute("TipoPercepcion") Then percepcion.TipoPercepcion = p.GetAttribute("TipoPercepcion")
            If p.HasAttribute("Clave") Then percepcion.Clave = p.GetAttribute("Clave")
            If p.HasAttribute("Concepto") Then percepcion.Concepto = p.GetAttribute("Concepto")
            If p.HasAttribute("ImporteGravado") Then percepcion.ImporteGravado = If(Decimal.TryParse(p.GetAttribute("ImporteGravado"), valDecimal), valDecimal, 0)
            If p.HasAttribute("ImporteExento") Then percepcion.ImporteExento = If(Decimal.TryParse(p.GetAttribute("ImporteExento"), valDecimal), valDecimal, 0)
            percepcion.AccionesOTitulos = ObtenerNodoAccionesOTitulosPercepcionNomina12(p)
            percepcion.HorasExtras = ObtenerNodoHorasExtraNomina12(p)
            percepciones.Percepcion.Add(percepcion)
        Next

        percepciones.JubilacionPensionRetiro = ObtenerNodoJubilacionPensionRetiroNomina12(nPercepcion)
        percepciones.SeparacionIndeminzacion = ObtenerNodoSeparacionIndemnizacion12(nPercepcion)
        Return percepciones
    End Function
    Private Shared Function ObtenerNodoAccionesOTitulosPercepcionNomina12(ByVal nodoPercepcionNomina As XmlElement) As NAccionesOTitulos
        Dim valDecimal As Decimal
        Dim lNAccionesOTitulos As XmlNodeList = nodoPercepcionNomina.GetElementsByTagName("nomina12:AccionesOTitulos")
        If lNAccionesOTitulos.Count = 0 Then Return Nothing
        Dim nNAccionesOTitulos As XmlElement = TryCast(lNAccionesOTitulos(0), XmlElement)
        Dim accionesOTitulos As NAccionesOTitulos = New NAccionesOTitulos()
        accionesOTitulos.ValorMercado = nNAccionesOTitulos.GetAttribute("ValorMercado")
        accionesOTitulos.PrecioAlOtorgarse = If(Decimal.TryParse(nNAccionesOTitulos.GetAttribute("PrecioAlOtorgarse"), valDecimal), valDecimal, 0)
        Return accionesOTitulos
    End Function
    Private Shared Function ObtenerNodoHorasExtraNomina12(ByVal nodoNomina As XmlElement) As List(Of NHorasExtra)
        Dim valInt As Integer
        Dim lNHorasExtra As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:HorasExtra")
        If lNHorasExtra.Count = 0 Then Return Nothing
        Dim lista As List(Of NHorasExtra) = New List(Of NHorasExtra)()
        Dim nNHoraExtra As XmlElement = TryCast(lNHorasExtra(0), XmlElement)

        For Each h As XmlElement In lNHorasExtra
            Dim nhorasextra As XmlElement = TryCast(nNHoraExtra, XmlElement)
            Dim horasExtra As NHorasExtra = New NHorasExtra()
            horasExtra.Dias = If(Integer.TryParse(h.GetAttribute("Dias"), valInt), valInt, 0)
            horasExtra.TipoHoras = If(Integer.TryParse(h.GetAttribute("TipoHoras"), valInt), valInt, 0)
            horasExtra.HorasExtra = If(Integer.TryParse(h.GetAttribute("HorasExtra"), valInt), valInt, 0)
            horasExtra.ImportePagado = Decimal.Parse(h.GetAttribute("ImportePagado"))
            lista.Add(horasExtra)
        Next

        Return lista
    End Function
    Private Shared Function ObtenerNodoJubilacionPensionRetiroNomina12(ByVal nodoPercepcionesNomina As XmlElement) As NJubilacionPensionRetiro
        Dim valDecimal As Decimal
        Dim lNJubilacionPensionRetiro As XmlNodeList = nodoPercepcionesNomina.GetElementsByTagName("nomina12:JubilacionPensionRetiro")
        If lNJubilacionPensionRetiro.Count = 0 Then Return Nothing
        Dim nNJubilacionPensionRetiro As XmlElement = TryCast(lNJubilacionPensionRetiro(0), XmlElement)
        Dim jubilacionPensionRetiro As NJubilacionPensionRetiro = New NJubilacionPensionRetiro()
        If nNJubilacionPensionRetiro.HasAttribute("TotalUnaExhibicion") Then jubilacionPensionRetiro.TotalUnaExhibicion = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("TotalUnaExhibicion"), valDecimal), valDecimal, 0)
        If nNJubilacionPensionRetiro.HasAttribute("TotalParcialidad") Then jubilacionPensionRetiro.TotalParcialidad = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("TotalParcialidad"), valDecimal), valDecimal, 0)
        If nNJubilacionPensionRetiro.HasAttribute("MontoDiario") Then jubilacionPensionRetiro.MontoDiario = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("MontoDiario"), valDecimal), valDecimal, 0)
        jubilacionPensionRetiro.IngresoAcumulable = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("IngresoAcumulable"), valDecimal), valDecimal, 0)
        jubilacionPensionRetiro.IngresoNoAcumulable = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("IngresoNoAcumulable"), valDecimal), valDecimal, 0)
        Return jubilacionPensionRetiro
    End Function
    Private Shared Function ObtenerNodoSeparacionIndemnizacion12(ByVal nodoPercepcionesNomina As XmlElement) As NSeparacionIndemnizacion
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim lNSeparacionIndeminzacion As XmlNodeList = nodoPercepcionesNomina.GetElementsByTagName("nomina12:SeparacionIndemnizacion")
        If lNSeparacionIndeminzacion.Count = 0 Then Return Nothing
        Dim nNSeparacionIndeminzacion As XmlElement = TryCast(lNSeparacionIndeminzacion(0), XmlElement)
        Dim separacionIndeminzacion As NSeparacionIndemnizacion = New NSeparacionIndemnizacion()
        separacionIndeminzacion.TotalPagado = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("TotalPagado"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.NumAnosServicio = If(Integer.TryParse(nNSeparacionIndeminzacion.GetAttribute("NumAnosServicio"), valInt), valInt, 0)
        separacionIndeminzacion.UltimoSueldoMensOrd = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("UltimoSueldoMensOrd"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.IngresoAcumulable = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("IngresoAcumulable"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.IngresoNoAcumulable = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("IngresoNoAcumulable"), valDecimal), valDecimal, 0)
        Return separacionIndeminzacion
    End Function
    Private Shared Function ObtenerNodoDeduccionesNomina12(ByVal nodoNomina As XmlElement) As NDeducciones
        Dim valDecimal As Decimal
        Dim nNDeducciones As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Deducciones")
        If nNDeducciones.Count = 0 Then Return Nothing
        Dim nNDeduccion As XmlElement = TryCast(nNDeducciones(0), XmlElement)
        Dim deducciones As NDeducciones = New NDeducciones()
        If nNDeduccion.HasAttribute("TotalOtrasDeducciones") Then deducciones.TotalOtrasDeducciones = If(Decimal.TryParse(nNDeduccion.GetAttribute("TotalOtrasDeducciones"), valDecimal), valDecimal, 0)
        If nNDeduccion.HasAttribute("TotalImpuestosRetenidos") Then deducciones.TotalImpuestosRetenidos = If(Decimal.TryParse(nNDeduccion.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
        deducciones.Deduccion = New List(Of NDeduccion)()

        For Each d As XmlElement In nNDeduccion.GetElementsByTagName("nomina12:Deduccion")
            Dim deduccion As NDeduccion = New NDeduccion()
            If d.HasAttribute("TipoDeduccion") Then deduccion.TipoDeduccion = d.GetAttribute("TipoDeduccion")
            If d.HasAttribute("Clave") Then deduccion.Clave = d.GetAttribute("Clave")
            If d.HasAttribute("Concepto") Then deduccion.Concepto = d.GetAttribute("Concepto")
            If d.HasAttribute("Importe") Then deduccion.Importe = If(Decimal.TryParse(d.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            deducciones.Deduccion.Add(deduccion)
        Next

        Return deducciones
    End Function
    Private Shared Function ObtenerNodoOtrosPagosNomina12(ByVal nodoNomina As XmlElement) As NOtrosPagos
        Dim valDecimal As Decimal
        Dim lOtrosPagos As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:OtrosPagos")
        If lOtrosPagos.Count = 0 Then Return Nothing
        Dim otrosPagos As NOtrosPagos = New NOtrosPagos()
        otrosPagos.OtroPago = New List(Of NOtroPago)()
        Dim nOtrosPagos As XmlElement = TryCast(lOtrosPagos(0), XmlElement)
        Dim lOtroPago As XmlNodeList = nOtrosPagos.GetElementsByTagName("nomina12:OtroPago")

        For Each op As XmlElement In lOtroPago
            Dim otroPago As NOtroPago = New NOtroPago()
            If op.HasAttribute("TipoOtroPago") Then otroPago.TipoOtroPago = op.GetAttribute("TipoOtroPago")
            If op.HasAttribute("Clave") Then otroPago.Clave = op.GetAttribute("Clave")
            If op.HasAttribute("Concepto") Then otroPago.Concepto = op.GetAttribute("Concepto")
            If op.HasAttribute("Importe") Then otroPago.Importe = If(Decimal.TryParse(op.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            otroPago.SubsidioAlEmpleo = ObtenerNodoSubsidioAlEmpleo12(op)
            otroPago.CompensacionSaldosAFavor = ObtenerNodoCompensacionSaldosAFavor12(op)
            otrosPagos.OtroPago.Add(otroPago)
        Next

        Return otrosPagos
    End Function
    Private Shared Function ObtenerNodoSubsidioAlEmpleo12(ByVal nodoOtroPago As XmlElement) As NSubsidioAlEmpleo
        Dim valDecimal As Decimal
        Dim lNSubsidioAlEmpleo As XmlNodeList = nodoOtroPago.GetElementsByTagName("nomina12:SubsidioAlEmpleo")
        If lNSubsidioAlEmpleo.Count = 0 Then Return Nothing
        Dim nSubsidioAlEmpleado As XmlElement = TryCast(lNSubsidioAlEmpleo(0), XmlElement)
        Dim subsidioAlEmpleo As NSubsidioAlEmpleo = New NSubsidioAlEmpleo()
        If nSubsidioAlEmpleado.HasAttribute("SubsidioCausado") Then subsidioAlEmpleo.SubsidioCausado = If(Decimal.TryParse(nSubsidioAlEmpleado.GetAttribute("SubsidioCausado"), valDecimal), valDecimal, 0)
        Return subsidioAlEmpleo
    End Function
    Private Shared Function ObtenerNodoCompensacionSaldosAFavor12(ByVal nodoOtroPagoNomina As XmlElement) As NCompensacionSaldosAFavor
        Dim valDecimal As Decimal
        Dim lNCompensacionSaldosAFavor As XmlNodeList = nodoOtroPagoNomina.GetElementsByTagName("nomina12:CompensacionSaldosAFavor")
        If lNCompensacionSaldosAFavor.Count = 0 Then Return Nothing
        Dim nNCompensacionSaldosAFavor As XmlElement = TryCast(lNCompensacionSaldosAFavor(0), XmlElement)
        Dim compensacionSaldosAFavor As NCompensacionSaldosAFavor = New NCompensacionSaldosAFavor()
        compensacionSaldosAFavor.SaldoAFavor = If(Decimal.TryParse(nNCompensacionSaldosAFavor.GetAttribute("SaldoAFavor"), valDecimal), valDecimal, 0)
        compensacionSaldosAFavor.Ano = nNCompensacionSaldosAFavor.GetAttribute("Año")
        compensacionSaldosAFavor.RemanenteSalFav = If(Decimal.TryParse(nNCompensacionSaldosAFavor.GetAttribute("RemanenteSalFav"), valDecimal), valDecimal, 0)
        Return compensacionSaldosAFavor
    End Function
    Private Shared Function ObtenerNodoIncapacidadesNomina12(ByVal nodoNomina As XmlElement) As NIncapacidades
        Dim nIncapacidades As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Incapacidades")
        If nIncapacidades.Count = 0 Then Return Nothing
        Dim nIncapacidad As XmlElement = TryCast(nIncapacidades(0), XmlElement)
        Dim incapacidades As NIncapacidades = New NIncapacidades()
        incapacidades.Incapacidad = New List(Of NIncapacidad)()

        For Each i As XmlElement In nIncapacidad.GetElementsByTagName("nomina12:Incapacidad")
            Dim incapacidad As NIncapacidad = New NIncapacidad()
            If i.HasAttribute("DiasIncapacidad") Then incapacidad.DiasIncapacidad = Integer.Parse(i.GetAttribute("DiasIncapacidad"))
            If i.HasAttribute("TipoIncapacidad") Then incapacidad.TipoIncapacidad = i.GetAttribute("Concepto")
            incapacidades.Incapacidad.Add(incapacidad)
        Next

        Return incapacidades
    End Function
#End Region
#Region "Pagos 1.0"
    Private Shared Function ObtenerNodoPagos10(ByVal documento As XmlDocument) As Pagos10
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lPagos As XmlNodeList = documento.GetElementsByTagName("pago10:Pagos")
        If lPagos.Count = 0 Then Return Nothing
        Dim pagos As Pagos10 = New Pagos10()
        pagos.Pago = New List(Of P10Pago)()
        Dim nPagos As XmlElement = TryCast(lPagos(0), XmlElement)
        If nPagos.HasAttribute("Version") Then pagos.Version = nPagos.GetAttribute("Version")
        Dim lPago As XmlNodeList = nPagos.GetElementsByTagName("pago10:Pago")

        For Each nPago As XmlElement In lPago
            Dim pago As P10Pago = New P10Pago()
            If nPago.HasAttribute("FechaPago") Then pago.FechaPago = If(DateTime.TryParse(nPago.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
            If nPago.HasAttribute("FormaDePagoP") Then pago.FormaDePagoP = nPago.GetAttribute("FormaDePagoP")
            If nPago.HasAttribute("MonedaP") Then pago.MonedaP = nPago.GetAttribute("MonedaP")
            If nPago.HasAttribute("TipoCambioP") Then pago.TipoCambioP = If(Decimal.TryParse(nPago.GetAttribute("TipoCambioP"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("Monto") Then pago.Monto = If(Decimal.TryParse(nPago.GetAttribute("Monto"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("NumOperacion") Then pago.NumOperacion = nPago.GetAttribute("NumOperacion")
            If nPago.HasAttribute("RfcEmisorCtaOrd") Then pago.RfcEmisorCtaOrd = nPago.GetAttribute("RfcEmisorCtaOrd")
            If nPago.HasAttribute("NomBancoOrdExt") Then pago.NomBancoOrdExt = nPago.GetAttribute("NomBancoOrdExt")
            If nPago.HasAttribute("CtaOrdenante") Then pago.CtaOrdenante = nPago.GetAttribute("CtaOrdenante")
            If nPago.HasAttribute("RfcEmisorCtaBen") Then pago.RfcEmisorCtaBen = nPago.GetAttribute("RfcEmisorCtaBen")
            If nPago.HasAttribute("CtaBeneficiario") Then pago.CtaBeneficiario = nPago.GetAttribute("CtaBeneficiario")
            If nPago.HasAttribute("TipoCadPago") Then pago.TipoCadPago = nPago.GetAttribute("TipoCadPago")
            If nPago.HasAttribute("CertPago") Then pago.CertPago = nPago.GetAttribute("CertPago")
            If nPago.HasAttribute("CadPago") Then pago.CadPago = nPago.GetAttribute("CadPago")
            If nPago.HasAttribute("SelloPago") Then pago.SelloPago = nPago.GetAttribute("SelloPago")
            pago.DoctoRelacionado = ObtenerDoctoRelacionadoPago10(nPago)
            pago.Impuestos = obtenerImpuestosPago10(nPago)
            pagos.Pago.Add(pago)
        Next

        Return pagos
    End Function
    Private Shared Function ObtenerDoctoRelacionadoPago10(ByVal nodoPago As XmlElement) As List(Of P10DoctoRelacionado)
        Dim lnDoctoRelacionado As XmlNodeList = nodoPago.GetElementsByTagName("pago10:DoctoRelacionado")
        If lnDoctoRelacionado.Count = 0 Then Return Nothing
        Dim listaDoctosRelacionados As List(Of P10DoctoRelacionado) = New List(Of P10DoctoRelacionado)()

        For Each nDoctoRelacionado As XmlElement In lnDoctoRelacionado
            Dim pDoctoRelacionado As P10DoctoRelacionado = New P10DoctoRelacionado()
            If nDoctoRelacionado.HasAttribute("IdDocumento") Then pDoctoRelacionado.IdDocumento = nDoctoRelacionado.GetAttribute("IdDocumento")
            If nDoctoRelacionado.HasAttribute("Serie") Then pDoctoRelacionado.Serie = nDoctoRelacionado.GetAttribute("Serie")
            If nDoctoRelacionado.HasAttribute("Folio") Then pDoctoRelacionado.Folio = nDoctoRelacionado.GetAttribute("Folio")
            If nDoctoRelacionado.HasAttribute("MonedaDR") Then pDoctoRelacionado.MonedaDR = nDoctoRelacionado.GetAttribute("MonedaDR")
            If nDoctoRelacionado.HasAttribute("TipoCambioDR") Then pDoctoRelacionado.TipoCambioDR = Decimal.Parse(nDoctoRelacionado.GetAttribute("TipoCambioDR"))
            If nDoctoRelacionado.HasAttribute("MetodoDePagoDR") Then pDoctoRelacionado.MetodoDePagoDR = nDoctoRelacionado.GetAttribute("MetodoDePagoDR")
            If nDoctoRelacionado.HasAttribute("NumParcialidad") Then pDoctoRelacionado.NumParcialidad = nDoctoRelacionado.GetAttribute("NumParcialidad")
            If nDoctoRelacionado.HasAttribute("ImpSaldoAnt") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoAnt"))
            If nDoctoRelacionado.HasAttribute("ImpPagado") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpPagado"))
            If nDoctoRelacionado.HasAttribute("ImpSaldoInsoluto") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoInsoluto"))
            listaDoctosRelacionados.Add(pDoctoRelacionado)
        Next

        Return listaDoctosRelacionados
    End Function
    Private Shared Function obtenerImpuestosPago10(ByVal nodoPago As XmlElement) As List(Of P10Impuestos)
        Dim valDecimal As Decimal
        Dim impuestos As P10Impuestos = Nothing
        Dim lnImpuestos As XmlNodeList = nodoPago.GetElementsByTagName("pago10:Impuestos")
        If lnImpuestos.Count = 0 Then Return Nothing
        Dim listaImpuestos As List(Of P10Impuestos) = New List(Of P10Impuestos)()

        For Each nImpuestos As XmlElement In lnImpuestos
            If nImpuestos.HasAttribute("TotalImpuestosRetenidos") Then impuestos.TotalImpuestosRetenidos = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
            If nImpuestos.HasAttribute("TotalImpuestosTrasladados") Then impuestos.TotalImpuestosTrasladados = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosTrasladados"), valDecimal), valDecimal, 0)
            Dim lPRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:Retenciones")

            If lPRetenciones.Count > 0 Then
                Dim retenciones As P10Retenciones = New P10Retenciones()
                retenciones.Retencion = New List(Of P10Retencion)()
                Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

                For Each nPRetencion As XmlElement In nPRetenciones.GetElementsByTagName("pago10:Retencion")
                    Dim retencion As P10Retencion = New P10Retencion()
                    If nPRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nPRetencion.GetAttribute("Impuesto")
                    If nPRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nPRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                    retenciones.Retencion.Add(retencion)
                Next

                impuestos.Retenciones = retenciones
            End If

            Dim lPTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:Traslados")

            If lPTraslados.Count > 0 Then
                Dim traslados As P10Traslados = New P10Traslados()
                traslados.Traslado = New List(Of P10Traslado)()
                Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

                For Each nPTraslado As XmlElement In nPTraslados.GetElementsByTagName("pago10:Traslado")
                    Dim traslado As P10Traslado = New P10Traslado()
                    If nPTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nPTraslado.GetAttribute("Impuesto")
                    If nPTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nPTraslado.GetAttribute("TipoFactor")
                    If nPTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nPTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                    If nPTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nPTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                    traslados.Traslado.Add(traslado)
                Next

                impuestos.Traslados = traslados
            End If

            listaImpuestos.Add(impuestos)
        Next

        Return listaImpuestos
    End Function
#End Region
#Region "Pagos 2.0"
    Private Shared Function ObtenerNodoPagos20(ByVal documento As XmlDocument) As Pagos20
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lPagos As XmlNodeList = documento.GetElementsByTagName("pago20:Pagos")
        If lPagos.Count = 0 Then Return Nothing
        Dim pagos As Pagos20 = New Pagos20()
        pagos.Pago = New List(Of P20Pago)()
        Dim nPagos As XmlElement = TryCast(lPagos(0), XmlElement)
        If nPagos.HasAttribute("Version") Then pagos.Version = nPagos.GetAttribute("Version")
        pagos.Totales = ObtenerTotalesP(nPagos)
        Dim lPago As XmlNodeList = nPagos.GetElementsByTagName("pago20:Pago")

        For Each nPago As XmlElement In lPago
            Dim pago As P20Pago = New P20Pago()
            If nPago.HasAttribute("FechaPago") Then pago.FechaPago = If(DateTime.TryParse(nPago.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
            If nPago.HasAttribute("FormaDePagoP") Then pago.FormaDePagoP = nPago.GetAttribute("FormaDePagoP")
            If nPago.HasAttribute("MonedaP") Then pago.MonedaP = nPago.GetAttribute("MonedaP")
            If nPago.HasAttribute("TipoCambioP") Then pago.TipoCambioP = If(Decimal.TryParse(nPago.GetAttribute("TipoCambioP"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("Monto") Then pago.Monto = If(Decimal.TryParse(nPago.GetAttribute("Monto"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("NumOperacion") Then pago.NumOperacion = nPago.GetAttribute("NumOperacion")
            If nPago.HasAttribute("RfcEmisorCtaOrd") Then pago.RfcEmisorCtaOrd = nPago.GetAttribute("RfcEmisorCtaOrd")
            If nPago.HasAttribute("NomBancoOrdExt") Then pago.NomBancoOrdExt = nPago.GetAttribute("NomBancoOrdExt")
            If nPago.HasAttribute("CtaOrdenante") Then pago.CtaOrdenante = nPago.GetAttribute("CtaOrdenante")
            If nPago.HasAttribute("RfcEmisorCtaBen") Then pago.RfcEmisorCtaBen = nPago.GetAttribute("RfcEmisorCtaBen")
            If nPago.HasAttribute("CtaBeneficiario") Then pago.CtaBeneficiario = nPago.GetAttribute("CtaBeneficiario")
            If nPago.HasAttribute("TipoCadPago") Then pago.TipoCadPago = nPago.GetAttribute("TipoCadPago")
            If nPago.HasAttribute("CertPago") Then pago.CertPago = nPago.GetAttribute("CertPago")
            If nPago.HasAttribute("CadPago") Then pago.CadPago = nPago.GetAttribute("CadPago")
            If nPago.HasAttribute("SelloPago") Then pago.SelloPago = nPago.GetAttribute("SelloPago")
            pago.DoctoRelacionado = ObtenerDoctoRelacionadoPago(nPago)
            pago.Impuestos = obtenerImpuestosPago(nPago)
            pagos.Pago.Add(pago)
        Next

        Return pagos
    End Function

    Private Shared Function ObtenerTotalesP(ByVal nodoPagos As XmlElement) As P20Totales
        Dim lnTotales As XmlNodeList = nodoPagos.GetElementsByTagName("pago20:Totales")
        Dim totales As P20Totales = New P20Totales()
        If lnTotales.Count = 0 Then Return totales
        Dim nTotales As XmlElement = TryCast(lnTotales(0), XmlElement)
        If nTotales.HasAttribute("MontoTotalPagos") Then totales.MontoTotalPagos = Decimal.Parse(nTotales.GetAttribute("MontoTotalPagos"))
        If nTotales.HasAttribute("TotalRetencionesIEPS") Then totales.TotalRetencionesIEPS = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesIEPS"))
        If nTotales.HasAttribute("TotalRetencionesISR") Then totales.TotalRetencionesISR = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesISR"))
        If nTotales.HasAttribute("TotalRetencionesIVA") Then totales.TotalRetencionesIVA = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesIVA"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA0") Then totales.TotalTrasladosBaseIVA0 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA0"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA16") Then totales.TotalTrasladosBaseIVA16 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA16"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA8") Then totales.TotalTrasladosBaseIVA8 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA8"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVAExento") Then totales.TotalTrasladosBaseIVAExento = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVAExento"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA0") Then totales.TotalTrasladosImpuestoIVA0 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA0"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA16") Then totales.TotalTrasladosImpuestoIVA16 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA16"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA8") Then totales.TotalTrasladosImpuestoIVA8 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA8"))
        Return totales
    End Function

    Private Shared Function ObtenerDoctoRelacionadoPago(ByVal nodoPago As XmlElement) As List(Of P20DoctoRelacionado)
        Dim lnDoctoRelacionado As XmlNodeList = nodoPago.GetElementsByTagName("pago20:DoctoRelacionado")
        Dim listaDoctosRelacionados As List(Of P20DoctoRelacionado) = New List(Of P20DoctoRelacionado)()
        If lnDoctoRelacionado.Count = 0 Then Return listaDoctosRelacionados

        For Each nDoctoRelacionado As XmlElement In lnDoctoRelacionado
            Dim pDoctoRelacionado As P20DoctoRelacionado = New P20DoctoRelacionado()
            If nDoctoRelacionado.HasAttribute("IdDocumento") Then pDoctoRelacionado.IdDocumento = nDoctoRelacionado.GetAttribute("IdDocumento")
            If nDoctoRelacionado.HasAttribute("Serie") Then pDoctoRelacionado.Serie = nDoctoRelacionado.GetAttribute("Serie")
            If nDoctoRelacionado.HasAttribute("Folio") Then pDoctoRelacionado.Folio = nDoctoRelacionado.GetAttribute("Folio")
            If nDoctoRelacionado.HasAttribute("MonedaDR") Then pDoctoRelacionado.MonedaDR = nDoctoRelacionado.GetAttribute("MonedaDR")
            If nDoctoRelacionado.HasAttribute("EquivalenciaDR") Then pDoctoRelacionado.EquivalenciaDR = Decimal.Parse(nDoctoRelacionado.GetAttribute("EquivalenciaDR"))
            If nDoctoRelacionado.HasAttribute("NumParcialidad") Then pDoctoRelacionado.NumParcialidad = nDoctoRelacionado.GetAttribute("NumParcialidad")
            If nDoctoRelacionado.HasAttribute("ImpSaldoAnt") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoAnt"))
            If nDoctoRelacionado.HasAttribute("ImpPagado") Then pDoctoRelacionado.ImpPagado = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpPagado"))
            If nDoctoRelacionado.HasAttribute("ImpSaldoInsoluto") Then pDoctoRelacionado.ImpSaldoInsoluto = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoInsoluto"))
            If nDoctoRelacionado.HasAttribute("ObjetoImpDR") Then pDoctoRelacionado.ObjetoImpDR = nDoctoRelacionado.GetAttribute("ObjetoImpDR")
            pDoctoRelacionado.ImpuestosDR = ObtenerImpuestosDR(nDoctoRelacionado)
            listaDoctosRelacionados.Add(pDoctoRelacionado)
        Next

        Return listaDoctosRelacionados
    End Function

    Private Shared Function ObtenerImpuestosDR(ByVal nodoDoctoRelacionado As XmlElement) As P20ImpuestosDR
        Dim valDecimal As Decimal
        Dim impuestos As P20ImpuestosDR = Nothing
        Dim lnImpuestosDR As XmlNodeList = nodoDoctoRelacionado.GetElementsByTagName("pago20:ImpuestosDR")
        If lnImpuestosDR.Count = 0 Then Return Nothing
        Dim nImpuestosDR As XmlElement = TryCast(lnImpuestosDR(0), XmlElement)
        impuestos = New P20ImpuestosDR()

        Dim lPRetenciones As XmlNodeList = nImpuestosDR.GetElementsByTagName("pago20:RetencionesDR")

        If lPRetenciones.Count > 0 Then
            Dim retenciones As P20RetencionesDR = New P20RetencionesDR()
            retenciones.RetencionDR = New List(Of P20RetencionDR)()
            Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

            For Each nRetencionDR As XmlElement In nPRetenciones.GetElementsByTagName("pago20:RetencionDR")
                Dim retencion As P20RetencionDR = New P20RetencionDR()
                If nRetencionDR.HasAttribute("BaseDR") Then retencion.BaseDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("BaseDR"), valDecimal), valDecimal, 0)
                If nRetencionDR.HasAttribute("ImpuestoDR") Then retencion.ImpuestoDR = nRetencionDR.GetAttribute("ImpuestoDR")
                If nRetencionDR.HasAttribute("TipoFactorDR") Then retencion.TipoFactorDR = nRetencionDR.GetAttribute("TipoFactorDR")
                If nRetencionDR.HasAttribute("TasaOCuotaDR") Then retencion.TasaOCuotaDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("TasaOCuotaDR"), valDecimal), valDecimal, 0)
                If nRetencionDR.HasAttribute("ImporteDR") Then retencion.ImporteDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("ImporteDR"), valDecimal), valDecimal, 0)
                retenciones.RetencionDR.Add(retencion)
            Next

            impuestos.RetencionesDR = retenciones
        End If

        Dim lPTraslados As XmlNodeList = nImpuestosDR.GetElementsByTagName("pago20:TrasladosDR")

        If lPTraslados.Count > 0 Then
            Dim traslados As P20TrasladosDR = New P20TrasladosDR()
            traslados.TrasladoDR = New List(Of P20TrasladoDR)()
            Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

            For Each nTrasladoDR As XmlElement In nPTraslados.GetElementsByTagName("pago20:TrasladoDR")
                Dim traslado As P20TrasladoDR = New P20TrasladoDR()
                If nTrasladoDR.HasAttribute("BaseDR") Then traslado.BaseDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("BaseDR"), valDecimal), valDecimal, 0)
                If nTrasladoDR.HasAttribute("ImpuestoDR") Then traslado.ImpuestoDR = nTrasladoDR.GetAttribute("ImpuestoDR")
                If nTrasladoDR.HasAttribute("TipoFactorDR") Then traslado.TipoFactorDR = nTrasladoDR.GetAttribute("TipoFactorDR")
                If nTrasladoDR.HasAttribute("TasaOCuotaDR") Then traslado.TasaOCuotaDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("TasaOCuotaDR"), valDecimal), valDecimal, 0)
                If nTrasladoDR.HasAttribute("ImporteDR") Then traslado.ImporteDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("ImporteDR"), valDecimal), valDecimal, 0)
                traslados.TrasladoDR.Add(traslado)
            Next

            impuestos.TrasladosDR = traslados
        End If

        Return impuestos
    End Function

    Private Shared Function obtenerImpuestosPago(ByVal nodoPago As XmlElement) As P20Impuestos
        Dim valDecimal As Decimal
        Dim impuestos As P20Impuestos = Nothing
        Dim lnImpuestos As XmlNodeList = nodoPago.GetElementsByTagName("pago20:ImpuestosP")
        If lnImpuestos.Count = 0 Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lnImpuestos(0), XmlElement)
        Dim lPRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:RetencionesP")

        If lPRetenciones.Count > 0 Then
            Dim retenciones As P20Retenciones = New P20Retenciones()
            retenciones.RetencionP = New List(Of P20Retencion)()
            Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

            For Each nPRetencion As XmlElement In nPRetenciones.GetElementsByTagName("pago10:RetencionP")
                Dim retencion As P20Retencion = New P20Retencion()
                If nPRetencion.HasAttribute("ImpuestoP") Then retencion.ImpuestoP = nPRetencion.GetAttribute("ImpuestoP")
                If nPRetencion.HasAttribute("ImporteP") Then retencion.ImporteP = If(Decimal.TryParse(nPRetencion.GetAttribute("ImporteP"), valDecimal), valDecimal, 0)
                retenciones.RetencionP.Add(retencion)
            Next

            impuestos.RetencionesP = retenciones
        End If

        Dim lPTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:TrasladosP")

        If lPTraslados.Count > 0 Then
            Dim traslados As P20Traslados = New P20Traslados()
            traslados.TrasladoP = New List(Of P20Traslado)()
            Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

            For Each nPTraslado As XmlElement In nPTraslados.GetElementsByTagName("pago10:TrasladoP")
                Dim traslado As P20Traslado = New P20Traslado()
                If nPTraslado.HasAttribute("BaseP") Then traslado.BaseP = If(Decimal.TryParse(nPTraslado.GetAttribute("BaseP"), valDecimal), valDecimal, 0)
                If nPTraslado.HasAttribute("ImpuestoP") Then traslado.ImpuestoP = nPTraslado.GetAttribute("ImpuestoP")
                If nPTraslado.HasAttribute("TipoFactorP") Then traslado.TipoFactorP = nPTraslado.GetAttribute("TipoFactorP")
                If nPTraslado.HasAttribute("TasaOCuotaP") Then traslado.TasaOCuotaP = If(Decimal.TryParse(nPTraslado.GetAttribute("TasaOCuotaP"), valDecimal), valDecimal, 0)
                If nPTraslado.HasAttribute("ImporteP") Then traslado.ImporteP = If(Decimal.TryParse(nPTraslado.GetAttribute("ImporteP"), valDecimal), valDecimal, 0)
                traslados.TrasladoP.Add(traslado)
            Next
            impuestos.TrasladosP = traslados
        End If

        Return impuestos
    End Function
#End Region
#Region "Timbre Fiscal Digital"
    Private Shared Function ObtenerNodoComplementoTimbreFiscalDigital(ByVal documento As XmlDocument) As TimbreFiscalDigital
        Dim fecha As DateTime
        Dim lTimbreFiscalDigital As XmlNodeList = documento.GetElementsByTagName("tfd:TimbreFiscalDigital")
        If lTimbreFiscalDigital.Count = 0 Then Return Nothing
        Dim nTimbreFiscalDigital As XmlElement = TryCast(lTimbreFiscalDigital(0), XmlElement)
        Dim timbreFiscalDigital As TimbreFiscalDigital = New TimbreFiscalDigital()
        If nTimbreFiscalDigital.HasAttribute("Version") Then timbreFiscalDigital.Version = nTimbreFiscalDigital.GetAttribute("Version")
        If nTimbreFiscalDigital.HasAttribute("UUID") Then timbreFiscalDigital.UUID = nTimbreFiscalDigital.GetAttribute("UUID")
        If nTimbreFiscalDigital.HasAttribute("FechaTimbrado") Then timbreFiscalDigital.FechaTimbrado = If(DateTime.TryParse(nTimbreFiscalDigital.GetAttribute("FechaTimbrado"), fecha), fecha, DateTime.Now)
        If nTimbreFiscalDigital.HasAttribute("RfcProvCertif") Then timbreFiscalDigital.RfcProvCertif = nTimbreFiscalDigital.GetAttribute("RfcProvCertif")
        If nTimbreFiscalDigital.HasAttribute("Leyenda") Then timbreFiscalDigital.Leyenda = nTimbreFiscalDigital.GetAttribute("Leyenda")
        If nTimbreFiscalDigital.HasAttribute("SelloCFD") Then timbreFiscalDigital.SelloCFD = nTimbreFiscalDigital.GetAttribute("SelloCFD")
        If nTimbreFiscalDigital.HasAttribute("NoCertificadoSAT") Then timbreFiscalDigital.NoCertificadoSAT = nTimbreFiscalDigital.GetAttribute("NoCertificadoSAT")
        If nTimbreFiscalDigital.HasAttribute("SelloSAT") Then timbreFiscalDigital.SelloSAT = nTimbreFiscalDigital.GetAttribute("SelloSAT")
        Return timbreFiscalDigital
    End Function
#End Region
#End Region

End Class

Namespace Retenciones20
    Public Class LeerXML
        Public Shared Function ObtenerRetenciones(ByVal rutaXML As String) As Retenciones
            Dim documento As XmlDocument = New XmlDocument()
            Dim retenciones As Retenciones = New Retenciones()
            documento.Load(rutaXML)
            documento.PreserveWhitespace = True
            ObtenerRetenciones(documento, retenciones)
            Return retenciones
        End Function
        Private Shared Sub ObtenerRetenciones(ByVal documento As XmlDocument, ByRef retenciones As Retenciones)
            Dim fecha As DateTime
            Dim nlRetenciones As XmlNodeList = documento.GetElementsByTagName("retenciones:Retenciones")
            If nlRetenciones.Count = 0 Then Return
            Dim nRetenciones As XmlElement = TryCast(nlRetenciones(0), XmlElement)
            retenciones.CfdiRetenRelacionados = ObtenerCfdiRetenRelacionados(nRetenciones)
            retenciones.Emisor = ObtenerEmisor(nRetenciones)
            retenciones.Receptor = ObtenerReceptor(nRetenciones)
            retenciones.Periodo = ObtenerPeriodo(nRetenciones)
            retenciones.Totales = ObtenerTotales(nRetenciones)
            retenciones.Complemento = ObtenerComplementos(nRetenciones)

            If nRetenciones.HasAttribute("Version") Then retenciones.Version = nRetenciones.GetAttribute("Version")
            If nRetenciones.HasAttribute("FolioInt") Then retenciones.FolioInt = nRetenciones.GetAttribute("FolioInt")
            If nRetenciones.HasAttribute("Sello") Then retenciones.Sello = nRetenciones.GetAttribute("Sello")
            If nRetenciones.HasAttribute("NoCertificado") Then retenciones.NoCertificado = nRetenciones.GetAttribute("NoCertificado")
            If nRetenciones.HasAttribute("Certificado") Then retenciones.Certificado = nRetenciones.GetAttribute("Certificado")
            If nRetenciones.HasAttribute("FechaExp") Then retenciones.FechaExp = If(DateTime.TryParse(nRetenciones.GetAttribute("FechaExp"), fecha), fecha, DateTime.Now)
            If nRetenciones.HasAttribute("LugarExpRetenc") Then retenciones.LugarExpRetenc = nRetenciones.GetAttribute("LugarExpRetenc")
            If nRetenciones.HasAttribute("CveRetenc") Then retenciones.CveRetenc = nRetenciones.GetAttribute("CveRetenc")
            If nRetenciones.HasAttribute("DescRetenc") Then retenciones.DescRetenc = nRetenciones.GetAttribute("DescRetenc")

        End Sub
        Private Shared Function ObtenerCfdiRetenRelacionados(ByVal nodoRetenciones As XmlElement) As CfdiRetenRelacionados
            Dim nlCfdiRelacionados As XmlNodeList = nodoRetenciones.GetElementsByTagName("cfdi:ACuentaTerceros")
            If nlCfdiRelacionados.Count = 0 Then Return Nothing
            Dim cfdiRetenRelacionados As CfdiRetenRelacionados = New CfdiRetenRelacionados()
            Dim nCfdiRetenRelacionados As XmlElement = TryCast(nlCfdiRelacionados(0), XmlElement)

            If nCfdiRetenRelacionados.HasAttribute("TipoRelacion") Then cfdiRetenRelacionados.TipoRelacion = nCfdiRetenRelacionados.GetAttribute("TipoRelacion")
            If nCfdiRetenRelacionados.HasAttribute("UUID") Then cfdiRetenRelacionados.UUID = nCfdiRetenRelacionados.GetAttribute("UUID")
            Return cfdiRetenRelacionados
        End Function
        Private Shared Function ObtenerEmisor(ByVal nodoRetenciones As XmlElement) As Emisor
            Dim nlEmisores As XmlNodeList = nodoRetenciones.GetElementsByTagName("retenciones:Emisor")
            If nlEmisores.Count = 0 Then Return Nothing
            Dim nEmisor As XmlElement = TryCast(nlEmisores(0), XmlElement)
            Dim emisor As Emisor = New Emisor()
            If nEmisor.HasAttribute("RfcE") Then emisor.RfcE = nEmisor.GetAttribute("RfcE")
            If nEmisor.HasAttribute("NomDenRazSocE") Then emisor.NomDenRazSocE = nEmisor.GetAttribute("NomDenRazSocE")
            If nEmisor.HasAttribute("RegimenFiscalE") Then emisor.RegimenFiscalE = nEmisor.GetAttribute("RegimenFiscalE")
            Return emisor
        End Function
        Private Shared Function ObtenerReceptor(ByVal nodoRetenciones As XmlElement) As Receptor
            Dim nlReceptores As XmlNodeList = nodoRetenciones.GetElementsByTagName("retenciones:Receptor")
            If nlReceptores.Count = 0 Then Return Nothing
            Dim nReceptor As XmlElement = TryCast(nlReceptores(0), XmlElement)
            Dim receptor As Receptor = New Receptor()
            receptor.Nacional = ObtenerNacional(nReceptor)
            receptor.Extranjero = ObtenerExtranjero(nReceptor)
            If nReceptor.HasAttribute("NacionalidadR") Then receptor.NacionalidadR = nReceptor.GetAttribute("NacionalidadR")
            Return receptor
        End Function
        Private Shared Function ObtenerNacional(ByVal nodoReceptor As XmlElement) As Nacional
            Dim nlNacional As XmlNodeList = nodoReceptor.GetElementsByTagName("retenciones:Nacional")
            If nlNacional.Count = 0 Then Return Nothing
            Dim nNacional As XmlElement = TryCast(nlNacional(0), XmlElement)
            Dim nacional As Nacional = New Nacional()
            If nNacional.HasAttribute("RfcR") Then nacional.RfcR = nNacional.GetAttribute("RfcR")
            If nNacional.HasAttribute("NomDenRazSocR") Then nacional.NomDenRazSocR = nNacional.GetAttribute("NomDenRazSocR")
            If nNacional.HasAttribute("CURPR") Then nacional.CURPR = nNacional.GetAttribute("CURPR")
            If nNacional.HasAttribute("DomicilioFiscalR") Then nacional.DomicilioFiscalR = nNacional.GetAttribute("DomicilioFiscalR")
            Return nacional
        End Function
        Private Shared Function ObtenerExtranjero(ByVal nodoReceptor As XmlElement) As Extranjero
            Dim nlExtranjero As XmlNodeList = nodoReceptor.GetElementsByTagName("retenciones:Extranjero")
            If nlExtranjero.Count = 0 Then Return Nothing
            Dim nExtranjero As XmlElement = TryCast(nlExtranjero(0), XmlElement)
            Dim extranjero As Extranjero = New Extranjero()
            If nExtranjero.HasAttribute("NumRegIdTribR") Then extranjero.NumRegIdTribR = nExtranjero.GetAttribute("NumRegIdTribR")
            If nExtranjero.HasAttribute("NomDenRazSocR") Then extranjero.NomDenRazSocR = nExtranjero.GetAttribute("NomDenRazSocR")
            Return extranjero
        End Function
        Private Shared Function ObtenerPeriodo(ByVal nodoRetenciones As XmlElement) As Periodo
            Dim nlPeriodo As XmlNodeList = nodoRetenciones.GetElementsByTagName("retenciones:Periodo")
            If nlPeriodo.Count = 0 Then Return Nothing
            Dim nPeriodo As XmlElement = TryCast(nlPeriodo(0), XmlElement)
            Dim periodo As Periodo = New Periodo()
            If nPeriodo.HasAttribute("MesIni") Then periodo.MesIni = nPeriodo.GetAttribute("MesIni")
            If nPeriodo.HasAttribute("MesFin") Then periodo.MesFin = nPeriodo.GetAttribute("MesFin")
            If nPeriodo.HasAttribute("Ejercicio") Then periodo.Ejercicio = nPeriodo.GetAttribute("Ejercicio")
            Return periodo
        End Function
        Private Shared Function ObtenerTotales(ByVal nodoRetenciones As XmlElement) As Totales
            Dim valDecimal As Decimal
            Dim nlTotales As XmlNodeList = nodoRetenciones.GetElementsByTagName("retenciones:Totales")
            If nlTotales.Count = 0 Then Return Nothing
            Dim nTotales As XmlElement = TryCast(nlTotales(0), XmlElement)
            Dim totales As Totales = New Totales()
            For Each nImpRetenidos As XmlElement In nTotales.GetElementsByTagName("retenciones:ImpRetenidos")
                Dim impRetenidos As ImpRetenidos = New ImpRetenidos()
                If nImpRetenidos.HasAttribute("BaseRet") Then impRetenidos.BaseRet = If(Decimal.TryParse(nImpRetenidos.GetAttribute("BaseRet"), valDecimal), valDecimal, 0)
                If nImpRetenidos.HasAttribute("ImpuestoRet") Then impRetenidos.ImpuestoRet = nImpRetenidos.GetAttribute("ImpuestoRet")
                If nImpRetenidos.HasAttribute("MontoRet") Then impRetenidos.MontoRet = If(Decimal.TryParse(nImpRetenidos.GetAttribute("MontoRet"), valDecimal), valDecimal, 0)
                If nImpRetenidos.HasAttribute("TipoPagoRet") Then impRetenidos.TipoPagoRet = nImpRetenidos.GetAttribute("TipoPagoRet")
                totales.ImpRetenidos.Add(impRetenidos)
            Next
            If nTotales.HasAttribute("MontoTotOperacion") Then totales.MontoTotOperacion = If(Decimal.TryParse(nTotales.GetAttribute("MontoTotOperacion"), valDecimal), valDecimal, 0)
            If nTotales.HasAttribute("MontoTotGrav") Then totales.MontoTotGrav = If(Decimal.TryParse(nTotales.GetAttribute("MontoTotGrav"), valDecimal), valDecimal, 0)
            If nTotales.HasAttribute("MontoTotExent") Then totales.MontoTotExent = If(Decimal.TryParse(nTotales.GetAttribute("MontoTotExent"), valDecimal), valDecimal, 0)
            If nTotales.HasAttribute("MontoTotRet") Then totales.MontoTotRet = If(Decimal.TryParse(nTotales.GetAttribute("MontoTotRet"), valDecimal), valDecimal, 0)
            If nTotales.HasAttribute("UtilidadBimestral") Then totales.UtilidadBimestral = If(Decimal.TryParse(nTotales.GetAttribute("UtilidadBimestral"), valDecimal), valDecimal, 0)
            If nTotales.HasAttribute("ISRCorrespondiente") Then totales.ISRCorrespondiente = If(Decimal.TryParse(nTotales.GetAttribute("ISRCorrespondiente"), valDecimal), valDecimal, 0)
            Return totales
        End Function
        Private Shared Function ObtenerComplementos(ByVal nodoRetenciones As XmlElement) As Complemento
            Dim nlComplemento As XmlNodeList = nodoRetenciones.GetElementsByTagName("retenciones:Complemento")
            If nlComplemento.Count = 0 Then Return Nothing
            Dim complemento As Complemento = New Complemento
            complemento.TimbreFiscalDigital = ObtenerTimbreFiscalDigital(nodoRetenciones)
            Return complemento
        End Function
        Private Shared Function ObtenerTimbreFiscalDigital(ByVal nodoRetenciones As XmlElement) As TimbreFiscalDigital
            Dim fecha As DateTime
            Dim lTimbreFiscalDigital As XmlNodeList = nodoRetenciones.GetElementsByTagName("tfd:TimbreFiscalDigital")
            If lTimbreFiscalDigital.Count = 0 Then Return Nothing
            Dim nTimbreFiscalDigital As XmlElement = TryCast(lTimbreFiscalDigital(0), XmlElement)
            Dim timbreFiscalDigital As TimbreFiscalDigital = New TimbreFiscalDigital()
            If nTimbreFiscalDigital.HasAttribute("Version") Then timbreFiscalDigital.Version = nTimbreFiscalDigital.GetAttribute("Version")
            If nTimbreFiscalDigital.HasAttribute("UUID") Then timbreFiscalDigital.UUID = nTimbreFiscalDigital.GetAttribute("UUID")
            If nTimbreFiscalDigital.HasAttribute("FechaTimbrado") Then timbreFiscalDigital.FechaTimbrado = If(DateTime.TryParse(nTimbreFiscalDigital.GetAttribute("FechaTimbrado"), fecha), fecha, DateTime.Now)
            If nTimbreFiscalDigital.HasAttribute("RfcProvCertif") Then timbreFiscalDigital.RfcProvCertif = nTimbreFiscalDigital.GetAttribute("RfcProvCertif")
            If nTimbreFiscalDigital.HasAttribute("Leyenda") Then timbreFiscalDigital.Leyenda = nTimbreFiscalDigital.GetAttribute("Leyenda")
            If nTimbreFiscalDigital.HasAttribute("SelloCFD") Then timbreFiscalDigital.SelloCFD = nTimbreFiscalDigital.GetAttribute("SelloCFD")
            If nTimbreFiscalDigital.HasAttribute("NoCertificadoSAT") Then timbreFiscalDigital.NoCertificadoSAT = nTimbreFiscalDigital.GetAttribute("NoCertificadoSAT")
            If nTimbreFiscalDigital.HasAttribute("SelloSAT") Then timbreFiscalDigital.SelloSAT = nTimbreFiscalDigital.GetAttribute("SelloSAT")
            Return timbreFiscalDigital
        End Function
    End Class
End Namespace

