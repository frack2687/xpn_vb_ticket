
Imports iTextSharp.text
Imports System.Xml

Public Class Leer
    Public Shared Function ObtenerNodoComplementoCartaPorte(documento As XmlDocument) As CartaPorte30
        Dim listaCartaPorte As XmlNodeList = documento.GetElementsByTagName("cartaporte30:CartaPorte")
        If listaCartaPorte.Count = 0 Then
            Return Nothing
        End If
        Dim cartaPorte As New CartaPorte30()
        Dim nodoCartaPorte As XmlElement = CType(listaCartaPorte.Item(0), XmlElement)
        If Not cartaPorte.Version.Equals("3.0") Then
            Return Nothing
        End If
        If nodoCartaPorte.HasAttribute("Version") Then
            cartaPorte.Version = nodoCartaPorte.GetAttribute("Version")
        End If
        If nodoCartaPorte.HasAttribute("idCCP") Then
            cartaPorte.IdCCP = nodoCartaPorte.GetAttribute("idCCP")
        End If

        If nodoCartaPorte.HasAttribute("TranspInternac") Then
            cartaPorte.TranspInternac = nodoCartaPorte.GetAttribute("TranspInternac")
        End If
        If nodoCartaPorte.HasAttribute("RegimenAduanero") Then
            cartaPorte.RegimenAduanero = nodoCartaPorte.GetAttribute("RegimenAduanero")
        End If
        If nodoCartaPorte.HasAttribute("EntradaSalidaMerc") Then
            cartaPorte.EntradaSalidaMerc = nodoCartaPorte.GetAttribute("EntradaSalidaMerc")
        End If
        If nodoCartaPorte.HasAttribute("PaisOrigenDestino") Then
            cartaPorte.PaisOrigenDestino = nodoCartaPorte.GetAttribute("PaisOrigenDestino")
        End If
        If nodoCartaPorte.HasAttribute("ViaEntradaSalida") Then
            cartaPorte.ViaEntradaSalida = nodoCartaPorte.GetAttribute("ViaEntradaSalida")
        End If
        If nodoCartaPorte.HasAttribute("TotalDistRec") Then
            cartaPorte.TotalDistRec = Double.Parse(nodoCartaPorte.GetAttribute("TotalDistRec"))
        End If
        If nodoCartaPorte.HasAttribute("UbicacionPoloOrigen") Then
            cartaPorte.UbicacionPoloOrigen = nodoCartaPorte.GetAttribute("UbicacionPoloOrigen")
        End If
        If nodoCartaPorte.HasAttribute("UbicacionPoloDestino") Then
            cartaPorte.UbicacionPoloDestino = nodoCartaPorte.GetAttribute("UbicacionPoloDestino")
        End If
        cartaPorte.Ubicaciones = ObtenerUbicaciones(nodoCartaPorte)
        cartaPorte.Mercancias = ObtenerMercancias(nodoCartaPorte)
        cartaPorte.FiguraTransporte = ObtenerFiguraTransporte(nodoCartaPorte)
        Return cartaPorte
    End Function

    Private Shared Function ObtenerUbicaciones(nodoCartaPorte As XmlElement) As Ubicaciones
        Dim ubicaciones As New Ubicaciones()
        Dim listaUbicaciones As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte30:Ubicaciones")
        If listaUbicaciones.Count = 0 Then
            Return Nothing
        End If
        Dim nodoUbicaciones As XmlElement = If(TypeOf listaUbicaciones.Item(0) Is XmlElement, CType(listaUbicaciones.Item(0), XmlElement), Nothing)
        ubicaciones.Ubicacion = ObtenerUbicacion(nodoUbicaciones)
        Return ubicaciones
    End Function

    Private Shared Function ObtenerUbicacion(nodoUbicaciones As XmlElement) As List(Of Ubicacion)
        Dim listaUbicacion As New List(Of Ubicacion)()
        Dim nListaUbicacion As XmlNodeList = nodoUbicaciones.GetElementsByTagName("cartaporte30:Ubicacion")
        For i As Integer = 0 To nListaUbicacion.Count - 1
            Dim item As XmlElement = CType(nListaUbicacion.Item(i), XmlElement)
            Dim ubicacion As New Ubicacion()
            If item.HasAttribute("TipoUbicacion") Then
                ubicacion.TipoUbicacion = item.GetAttribute("TipoUbicacion")
            End If
            If item.HasAttribute("IDUbicacion") Then
                ubicacion.IDUbicacion = item.GetAttribute("IDUbicacion")
            End If
            If item.HasAttribute("RFCRemitenteDestinatario") Then
                ubicacion.RFCRemitenteDestinatario = item.GetAttribute("RFCRemitenteDestinatario")
            End If
            If item.HasAttribute("NombreRemitenteDestinatario") Then
                ubicacion.NombreRemitenteDestinatario = item.GetAttribute("NombreRemitenteDestinatario")
            End If
            If item.HasAttribute("NumRegIdTrib") Then
                ubicacion.NumRegIdTrib = item.GetAttribute("NumRegIdTrib")
            End If
            If item.HasAttribute("ResidenciaFiscal") Then
                ubicacion.ResidenciaFiscal = item.GetAttribute("ResidenciaFiscal")
            End If
            If item.HasAttribute("NumEstacion") Then
                ubicacion.NumEstacion = item.GetAttribute("NumEstacion")
            End If
            If item.HasAttribute("NombreEstacion") Then
                ubicacion.NombreEstacion = item.GetAttribute("NombreEstacion")
            End If
            If item.HasAttribute("NavegacionTrafico") Then
                ubicacion.NavegacionTrafico = item.GetAttribute("NavegacionTrafico")
            End If
            If item.HasAttribute("FechaHoraSalidaLlegada") Then
                ubicacion.FechaHoraSalidaLlegada = DateTime.Parse(item.GetAttribute("FechaHoraSalidaLlegada"))
            End If
            If item.HasAttribute("TipoEstacion") Then
                ubicacion.TipoEstacion = item.GetAttribute("TipoEstacion")
            End If
            If item.HasAttribute("DistanciaRecorrida") Then
                ubicacion.DistanciaRecorrida = Double.Parse(item.GetAttribute("DistanciaRecorrida"))
            End If
            ubicacion.Domicilio = ObtenerDomicilio(item)
            listaUbicacion.Add(ubicacion)
        Next
        Return listaUbicacion
    End Function

    Private Shared Function ObtenerDomicilio(nodoUbicacion As XmlElement) As Domicilio
        Dim domicilio As New Domicilio()
        Dim listaDomicilios As XmlNodeList = nodoUbicacion.GetElementsByTagName("cartaporte30:Domicilio")
        If listaDomicilios.Count = 0 Then
            Return Nothing
        End If
        Dim nodoDomicilio As XmlElement = CType(listaDomicilios.Item(0), XmlElement)
        If nodoDomicilio.HasAttribute("Calle") Then
            domicilio.Calle = nodoDomicilio.GetAttribute("Calle")
        End If
        If nodoDomicilio.HasAttribute("NumeroExterior") Then
            domicilio.NumeroExterior = nodoDomicilio.GetAttribute("NumeroExterior")
        End If
        If nodoDomicilio.HasAttribute("NumeroInterior") Then
            domicilio.NumeroInterior = nodoDomicilio.GetAttribute("NumeroInterior")
        End If
        If nodoDomicilio.HasAttribute("Colonia") Then
            domicilio.Colonia = nodoDomicilio.GetAttribute("Colonia")
        End If
        If nodoDomicilio.HasAttribute("Localidad") Then
            domicilio.Localidad = nodoDomicilio.GetAttribute("Localidad")
        End If
        If nodoDomicilio.HasAttribute("Referencia") Then
            domicilio.Referencia = nodoDomicilio.GetAttribute("Referencia")
        End If
        If nodoDomicilio.HasAttribute("Municipio") Then
            domicilio.Municipio = nodoDomicilio.GetAttribute("Municipio")
        End If
        If nodoDomicilio.HasAttribute("Estado") Then
            domicilio.Estado = nodoDomicilio.GetAttribute("Estado")
        End If
        If nodoDomicilio.HasAttribute("Pais") Then
            domicilio.Pais = nodoDomicilio.GetAttribute("Pais")
        End If
        If nodoDomicilio.HasAttribute("CodigoPostal") Then
            domicilio.CodigoPostal = nodoDomicilio.GetAttribute("CodigoPostal")
        End If
        Return domicilio
    End Function

    Private Shared Function ObtenerMercancias(nodoCartaPorte As XmlElement) As Mercancias
        Dim mercancias As New Mercancias()
        Dim listaMercancias As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte30:Mercancias")
        If listaMercancias.Count = 0 Then
            Return Nothing
        End If
        Dim nodoMercancias As XmlElement = CType(listaMercancias.Item(0), XmlElement)
        If nodoMercancias.HasAttribute("PesoBrutoTotal") Then
            mercancias.PesoBrutoTotal = Double.Parse(nodoMercancias.GetAttribute("PesoBrutoTotal"))
        End If
        If nodoMercancias.HasAttribute("UnidadPeso") Then
            mercancias.UnidadPeso = nodoMercancias.GetAttribute("UnidadPeso")
        End If
        If nodoMercancias.HasAttribute("PesoNetoTotal") Then
            mercancias.PesoNetoTotal = Double.Parse(nodoMercancias.GetAttribute("PesoNetoTotal"))
        End If
        If nodoMercancias.HasAttribute("NumTotalMercancias") Then
            mercancias.NumTotalMercancias = Integer.Parse(nodoMercancias.GetAttribute("NumTotalMercancias"))
        End If
        If nodoMercancias.HasAttribute("CargoPorTasacion") Then
            mercancias.CargoPorTasacion = Double.Parse(nodoMercancias.GetAttribute("CargoPorTasacion"))
        End If
        If nodoMercancias.HasAttribute("LogisticaInversaRecoleccionDevolucion") Then
            mercancias.LogisticaInversaRecoleccionDevolucion = nodoMercancias.GetAttribute("LogisticaInversaRecoleccionDevolucion")
        End If
        mercancias.Mercancia = ObtenerMercancia(nodoMercancias)
        mercancias.Autotransporte = ObtenerAutoTransporte(nodoMercancias)
        mercancias.TransporteMaritimo = ObtenerTransporteMaritimo(nodoMercancias)
        mercancias.TransporteAereo = ObtenerTransporteAereo(nodoMercancias)
        mercancias.TransporteFerroviario = ObtenerTransporteFerroviario(nodoMercancias)
        Return mercancias
    End Function
    Private Shared Function ObtenerMercancia(nodoMercancias As XmlElement) As List(Of Mercancia)
        Dim listaMercancia As New List(Of Mercancia)()
        Dim nListaMercancia As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte30:Mercancia")

        For i As Integer = 0 To nListaMercancia.Count - 1
            Dim item As XmlElement = DirectCast(nListaMercancia.Item(i), XmlElement)
            Dim mercancia As New Mercancia()

            If item.HasAttribute("BienesTransp") Then
                mercancia.BienesTransp = item.GetAttribute("BienesTransp")
            End If

            If item.HasAttribute("ClaveSTCC") Then
                mercancia.ClaveSTCC = item.GetAttribute("ClaveSTCC")
            End If

            If item.HasAttribute("Descripcion") Then
                mercancia.Descripcion = item.GetAttribute("Descripcion")
            End If

            If item.HasAttribute("Cantidad") Then
                mercancia.Cantidad = Decimal.Parse(item.GetAttribute("Cantidad"))
            End If

            If item.HasAttribute("ClaveUnidad") Then
                mercancia.ClaveUnidad = item.GetAttribute("ClaveUnidad")
            End If

            If item.HasAttribute("Unidad") Then
                mercancia.Unidad = item.GetAttribute("Unidad")
            End If

            If item.HasAttribute("Dimensiones") Then
                mercancia.Dimensiones = item.GetAttribute("Dimensiones")
            End If

            If item.HasAttribute("MaterialPeligroso") Then
                mercancia.MaterialPeligroso = item.GetAttribute("MaterialPeligroso")
            End If

            If item.HasAttribute("CveMaterialPeligroso") Then
                mercancia.CveMaterialPeligroso = item.GetAttribute("CveMaterialPeligroso")
            End If

            If item.HasAttribute("Embalaje") Then
                mercancia.Embalaje = item.GetAttribute("Embalaje")
            End If

            If item.HasAttribute("DescripEmbalaje") Then
                mercancia.DescripEmbalaje = item.GetAttribute("DescripEmbalaje")
            End If

            If item.HasAttribute("SectorCOFEPRIS") Then
                mercancia.SectorCOFEPRIS = item.GetAttribute("SectorCOFEPRIS")
            End If

            If item.HasAttribute("NombreIngredienteActivo") Then
                mercancia.NombreIngredienteActivo = item.GetAttribute("NombreIngredienteActivo")
            End If

            If item.HasAttribute("NomQuimico") Then
                mercancia.NomQuimico = item.GetAttribute("NomQuimico")
            End If

            If item.HasAttribute("DenominacionGenericaProd") Then
                mercancia.DenominacionGenericaProd = item.GetAttribute("DenominacionGenericaProd")
            End If

            If item.HasAttribute("DenominacionDistintivaProd") Then
                mercancia.DenominacionDistintivaProd = item.GetAttribute("DenominacionDistintivaProd")
            End If

            If item.HasAttribute("Fabricante") Then
                mercancia.Fabricante = item.GetAttribute("Fabricante")
            End If

            If item.HasAttribute("FechaCaducidad") Then
                mercancia.FechaCaducidad = DateTime.Parse(item.GetAttribute("FechaCaducidad"))
            End If

            If item.HasAttribute("LoteMedicamento") Then
                mercancia.LoteMedicamento = item.GetAttribute("LoteMedicamento")
            End If

            If item.HasAttribute("FormaFarmaceutica") Then
                mercancia.FormaFarmaceutica = item.GetAttribute("FormaFarmaceutica")
            End If

            If item.HasAttribute("CondicionesEspTransp") Then
                mercancia.CondicionesEspTransp = item.GetAttribute("CondicionesEspTransp")
            End If

            If item.HasAttribute("RegistroSanitarioFolioAutorizacion") Then
                mercancia.RegistroSanitarioFolioAutorizacion = item.GetAttribute("RegistroSanitarioFolioAutorizacion")
            End If

            If item.HasAttribute("PermisoImportacion") Then
                mercancia.PermisoImportacion = item.GetAttribute("PermisoImportacion")
            End If

            If item.HasAttribute("FolioImpoVUCEM") Then
                mercancia.FolioImpoVUCEM = item.GetAttribute("FolioImpoVUCEM")
            End If

            If item.HasAttribute("NumCAS") Then
                mercancia.NumCAS = item.GetAttribute("NumCAS")
            End If

            If item.HasAttribute("RazonSocialEmpImp") Then
                mercancia.RazonSocialEmpImp = item.GetAttribute("RazonSocialEmpImp")
            End If

            If item.HasAttribute("NumRegSanPlagCOFEPRIS") Then
                mercancia.NumRegSanPlagCOFEPRIS = item.GetAttribute("NumRegSanPlagCOFEPRIS")
            End If

            If item.HasAttribute("DatosFabricante") Then
                mercancia.DatosFabricante = item.GetAttribute("DatosFabricante")
            End If

            If item.HasAttribute("DatosFormulador") Then
                mercancia.DatosFormulador = item.GetAttribute("DatosFormulador")
            End If

            If item.HasAttribute("DatosMaquilador") Then
                mercancia.DatosMaquilador = item.GetAttribute("DatosMaquilador")
            End If

            If item.HasAttribute("UsoAutorizado") Then
                mercancia.UsoAutorizado = item.GetAttribute("UsoAutorizado")
            End If

            If item.HasAttribute("PesoEnKg") Then
                mercancia.PesoEnKg = Double.Parse(item.GetAttribute("PesoEnKg"))
            End If

            If item.HasAttribute("ValorMercancia") Then
                mercancia.ValorMercancia = Double.Parse(item.GetAttribute("ValorMercancia"))
            End If

            If item.HasAttribute("Moneda") Then
                mercancia.Moneda = item.GetAttribute("Moneda")
            End If

            If item.HasAttribute("FraccionArancelaria") Then
                mercancia.FraccionArancelaria = item.GetAttribute("FraccionArancelaria")
            End If

            If item.HasAttribute("UUIDComercioExt") Then
                mercancia.UUIDComercioExt = item.GetAttribute("UUIDComercioExt")
            End If

            If item.HasAttribute("TipoMateria") Then
                mercancia.TipoMateria = item.GetAttribute("TipoMateria")
            End If

            If item.HasAttribute("DescripcionMateria") Then
                mercancia.DescripcionMateria = item.GetAttribute("DescripcionMateria")
            End If


            mercancia.DocumentacionAduanera = ObtenerDocumentacionAduanera(item)
            mercancia.GuiasIdentificacion = ObtenerGuiasIdentificacion(item)
            mercancia.CantidadTransporta = ObtenerCantidadTransporta(item)
            mercancia.DetalleMercancia = ObtenerDetalleMercancia(item)

            listaMercancia.Add(mercancia)
        Next

        Return listaMercancia
    End Function

    Private Shared Function ObtenerDocumentacionAduanera(nodoMercancia As XmlElement) As List(Of DocumentacionAduanera)
        Dim listaDocumentacionAduanera As New List(Of DocumentacionAduanera)()
        Dim nListaPedimentos As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte30:DocumentacionAduanera")

        For i As Integer = 0 To nListaPedimentos.Count - 1
            Dim item As XmlElement = DirectCast(nListaPedimentos.Item(i), XmlElement)
            Dim pedimentos As New DocumentacionAduanera()

            If item.HasAttribute("TipoDocumento") Then
                pedimentos.TipoDocumento = item.GetAttribute("TipoDocumento")
            End If

            ' ... (similar assignments for other attributes)

            listaDocumentacionAduanera.Add(pedimentos)
        Next

        Return listaDocumentacionAduanera
    End Function

    Private Shared Function ObtenerGuiasIdentificacion(nodoMercancia As XmlElement) As List(Of GuiasIdentificacion)
        Dim listaGuiasIdentificacion As New List(Of GuiasIdentificacion)()
        Dim nListaGuiasIdentificacion As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte30:GuiasIdentificacion")

        For i As Integer = 0 To nListaGuiasIdentificacion.Count - 1
            Dim item As XmlElement = DirectCast(nListaGuiasIdentificacion.Item(i), XmlElement)
            Dim guiasIdentificacion As New GuiasIdentificacion()

            If item.HasAttribute("DescripGuiaIdentificacion") Then
                guiasIdentificacion.DescripcionGuiaIdentificacion = item.GetAttribute("DescripGuiaIdentificacion")
            End If

            ' ... (similar assignments for other attributes)

            listaGuiasIdentificacion.Add(guiasIdentificacion)
        Next

        Return listaGuiasIdentificacion
    End Function

    Private Shared Function ObtenerCantidadTransporta(nodoMercancia As XmlElement) As List(Of CantidadTransporta)
        Dim listaCantidadTransporta As New List(Of CantidadTransporta)()
        Dim nlistaCantidadTransporta As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte30:CantidadTransporta")

        For i As Integer = 0 To nlistaCantidadTransporta.Count - 1
            Dim item As XmlElement = DirectCast(nlistaCantidadTransporta.Item(i), XmlElement)
            Dim cantidadTransporta As New CantidadTransporta()

            If item.HasAttribute("Cantidad") Then
                cantidadTransporta.Cantidad = Double.Parse(item.GetAttribute("Cantidad"))
            End If

            ' ... (similar assignments for other attributes)

            listaCantidadTransporta.Add(cantidadTransporta)
        Next

        Return listaCantidadTransporta
    End Function
    Private Shared Function ObtenerDetalleMercancia(nodoMercancia As XmlElement) As DetalleMercancia
        Dim detalleMercancias As New DetalleMercancia()
        Dim listaDetalleMercancias As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte30:DetalleMercancia")
        If listaDetalleMercancias.Count = 0 Then
            Return Nothing
        End If
        Dim nodoDetalleMercancia As XmlElement = DirectCast(listaDetalleMercancias.Item(0), XmlElement)
        If nodoDetalleMercancia.HasAttribute("UnidadPesoMerc") Then
            detalleMercancias.UnidadPesoMerc = Convert.ToString(nodoDetalleMercancia.HasAttribute("UnidadPesoMerc"))
        End If
        If nodoDetalleMercancia.HasAttribute("PesoBruto") Then
            detalleMercancias.PesoBruto = Double.Parse(nodoDetalleMercancia.GetAttribute("PesoBruto"))
        End If
        If nodoDetalleMercancia.HasAttribute("PesoNeto") Then
            detalleMercancias.PesoNeto = Double.Parse(nodoDetalleMercancia.GetAttribute("PesoNeto"))
        End If
        If nodoDetalleMercancia.HasAttribute("PesoTara") Then
            detalleMercancias.PesoTara = Double.Parse(nodoDetalleMercancia.GetAttribute("PesoTara"))
        End If
        If nodoDetalleMercancia.HasAttribute("NumPiezas") Then
            detalleMercancias.NumPiezas = Integer.Parse(nodoDetalleMercancia.GetAttribute("NumPiezas"))
        End If
        Return detalleMercancias
    End Function

    Private Shared Function ObtenerAutoTransporte(nodoMercancias As XmlElement) As Autotransporte
        Dim autoTransporte As New Autotransporte()
        Dim listaAutotransporte As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte30:Autotransporte")
        If listaAutotransporte.Count = 0 Then
            Return Nothing
        End If
        Dim nodoAutotransporte As XmlElement = DirectCast(listaAutotransporte.Item(0), XmlElement)
        If nodoAutotransporte.HasAttribute("PermSCT") Then
            autoTransporte.PermSCT = nodoAutotransporte.GetAttribute("PermSCT")
        End If
        If nodoAutotransporte.HasAttribute("NumPermisoSCT") Then
            autoTransporte.NumPermisoSCT = nodoAutotransporte.GetAttribute("NumPermisoSCT")
        End If
        autoTransporte.IdentificacionVehicular = ObtenerIdentificacionVehicular(nodoAutotransporte)
        autoTransporte.Seguros = ObtenerSeguros(nodoAutotransporte)
        autoTransporte.Remolques = ObtenerRemolques(nodoAutotransporte)
        Return autoTransporte
    End Function

    Private Shared Function ObtenerIdentificacionVehicular(nodoAutotransporteFederal As XmlElement) As IdentificacionVehicular
        Dim identificacionVehicular As New IdentificacionVehicular()
        Dim listaIdentificacionVehicular As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte30:IdentificacionVehicular")
        If listaIdentificacionVehicular.Count = 0 Then
            Return Nothing
        End If
        Dim nodoIdentificacionVehicular As XmlElement = DirectCast(listaIdentificacionVehicular.Item(0), XmlElement)
        If nodoIdentificacionVehicular.HasAttribute("ConfigVehicular") Then
            identificacionVehicular.ConfigVehicular = nodoIdentificacionVehicular.GetAttribute("ConfigVehicular")
        End If
        If nodoIdentificacionVehicular.HasAttribute("PesoBrutoVehicular") Then
            identificacionVehicular.PesoBrutoVehicular = Double.Parse(nodoIdentificacionVehicular.GetAttribute("PesoBrutoVehicular"))
        End If
        If nodoIdentificacionVehicular.HasAttribute("PlacaVM") Then
            identificacionVehicular.PlacaVM = nodoIdentificacionVehicular.GetAttribute("PlacaVM")
        End If
        If nodoIdentificacionVehicular.HasAttribute("AnioModeloVM") Then
            identificacionVehicular.AnioModeloVM = Integer.Parse(nodoIdentificacionVehicular.GetAttribute("AnioModeloVM"))
        End If
        Return identificacionVehicular
    End Function

    Private Shared Function ObtenerSeguros(nodoAutoTransporte As XmlElement) As Seguros
        Dim seguros As New Seguros()
        Dim listaSeguros As XmlNodeList = nodoAutoTransporte.GetElementsByTagName("cartaporte30:Seguros")
        If listaSeguros.Count > 0 Then
            Return Nothing
        End If
        Dim nodoSeguros As XmlElement = DirectCast(listaSeguros.Item(0), XmlElement)
        If nodoSeguros.HasAttribute("AseguraRespCivil") Then
            seguros.AseguraRespCivil = nodoSeguros.GetAttribute("AseguraRespCivil")
        End If
        If nodoSeguros.HasAttribute("PolizaRespCivil") Then
            seguros.PolizaRespCivil = nodoSeguros.GetAttribute("PolizaRespCivil")
        End If
        If nodoSeguros.HasAttribute("AseguraMedAmbiente") Then
            seguros.AseguraMedAmbiente = nodoSeguros.GetAttribute("AseguraMedAmbiente")
        End If
        If nodoSeguros.HasAttribute("PolizaMedAmbiente") Then
            seguros.PolizaMedAmbiente = nodoSeguros.GetAttribute("PolizaMedAmbiente")
        End If
        If nodoSeguros.HasAttribute("AseguraCarga") Then
            seguros.AseguraCarga = nodoSeguros.GetAttribute("AseguraCarga")
        End If
        If nodoSeguros.HasAttribute("PolizaCarga") Then
            seguros.PolizaCarga = nodoSeguros.GetAttribute("PolizaCarga")
        End If
        If nodoSeguros.HasAttribute("PrimaSeguro") Then
            seguros.PrimaSeguro = Double.Parse(nodoSeguros.GetAttribute("PrimaSeguro"))
        End If
        Return seguros
    End Function

    Private Shared Function ObtenerRemolques(nodoAutotransporteFederal As XmlElement) As Remolques
        Dim remolques As New Remolques()
        Dim listaRemolques As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte30:Remolques")
        If listaRemolques.Count = 0 Then
            Return Nothing
        End If
        Dim nodoRemolques As XmlElement = DirectCast(listaRemolques.Item(0), XmlElement)
        remolques.Remolque = ObtenerRemolque(nodoRemolques)
        Return remolques
    End Function

    Private Shared Function ObtenerRemolque(nodoRemolques As XmlElement) As List(Of Remolque)
        Dim listaRemolque As New List(Of Remolque)()
        Dim nListaRemolque As XmlNodeList = nodoRemolques.GetElementsByTagName("cartaporte30:Remolque")
        For i As Integer = 0 To nListaRemolque.Count - 1
            Dim item As XmlElement = DirectCast(nListaRemolque.Item(i), XmlElement)
            Dim remolque As New Remolque()
            If item.HasAttribute("Placa") Then
                remolque.Placa = item.GetAttribute("Placa")
            End If
            If item.HasAttribute("SubTipoRem") Then
                remolque.SubTipoRem = item.GetAttribute("SubTipoRem")
            End If
            listaRemolque.Add(remolque)
        Next
        Return listaRemolque
    End Function

    Private Shared Function ObtenerTransporteMaritimo(nodoMercancias As XmlElement) As TransporteMaritimo
        Dim transporteMaritimo As New TransporteMaritimo()
        Dim listaTransporteMaritimo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte30:TransporteMaritimo")
        If listaTransporteMaritimo.Count = 0 Then
            Return Nothing
        End If
        Dim nodoTransporteMaritimo As XmlElement = DirectCast(listaTransporteMaritimo.Item(0), XmlElement)
        If nodoTransporteMaritimo.HasAttribute("PermSCT") Then
            transporteMaritimo.PermSCT = nodoTransporteMaritimo.GetAttribute("PermSCT")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumPermisoSCT") Then
            transporteMaritimo.NumPermisoSCT = nodoTransporteMaritimo.GetAttribute("NumPermisoSCT")
        End If
        If nodoTransporteMaritimo.HasAttribute("NombreAseg") Then
            transporteMaritimo.NombreAseg = nodoTransporteMaritimo.GetAttribute("NombreAseg")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumPolizaSeguro") Then
            transporteMaritimo.NumPolizaSeguro = nodoTransporteMaritimo.GetAttribute("NumPolizaSeguro")
        End If
        If nodoTransporteMaritimo.HasAttribute("TipoEmbarcacion") Then
            transporteMaritimo.TipoEmbarcacion = nodoTransporteMaritimo.GetAttribute("TipoEmbarcacion")
        End If
        If nodoTransporteMaritimo.HasAttribute("Matricula") Then
            transporteMaritimo.Matricula = nodoTransporteMaritimo.GetAttribute("Matricula")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumeroOMI") Then
            transporteMaritimo.NumeroOMI = nodoTransporteMaritimo.GetAttribute("NumeroOMI")
        End If
        If nodoTransporteMaritimo.HasAttribute("AnioEmbarcacion") Then
            transporteMaritimo.AnioEmbarcacion = Integer.Parse(nodoTransporteMaritimo.GetAttribute("AnioEmbarcacion"))
        End If
        If nodoTransporteMaritimo.HasAttribute("NombreEmbarc") Then
            transporteMaritimo.NombreEmbarc = nodoTransporteMaritimo.GetAttribute("NombreEmbarc")
        End If
        If nodoTransporteMaritimo.HasAttribute("NacionalidadEmbarc") Then
            transporteMaritimo.NacionalidadEmbarc = nodoTransporteMaritimo.GetAttribute("NacionalidadEmbarc")
        End If
        If nodoTransporteMaritimo.HasAttribute("UnidadesDeArqBruto") Then
            transporteMaritimo.UnidadesDeArqBruto = Double.Parse(nodoTransporteMaritimo.GetAttribute("UnidadesDeArqBruto"))
        End If
        If nodoTransporteMaritimo.HasAttribute("TipoCarga") Then
            transporteMaritimo.TipoCarga = nodoTransporteMaritimo.GetAttribute("TipoCarga")
        End If

        If nodoTransporteMaritimo.HasAttribute("Eslora") Then
            transporteMaritimo.Eslora = Double.Parse(nodoTransporteMaritimo.GetAttribute("Eslora"))
        End If
        If nodoTransporteMaritimo.HasAttribute("Manga") Then
            transporteMaritimo.Manga = Double.Parse(nodoTransporteMaritimo.GetAttribute("Manga"))
        End If
        If nodoTransporteMaritimo.HasAttribute("Calado") Then
            transporteMaritimo.Calado = Double.Parse(nodoTransporteMaritimo.GetAttribute("Calado"))
        End If
        If nodoTransporteMaritimo.HasAttribute("Puntal") Then
            transporteMaritimo.Puntal = Double.Parse(nodoTransporteMaritimo.GetAttribute("Puntal"))
        End If
        If nodoTransporteMaritimo.HasAttribute("LineaNaviera") Then
            transporteMaritimo.LineaNaviera = nodoTransporteMaritimo.GetAttribute("LineaNaviera")
        End If
        If nodoTransporteMaritimo.HasAttribute("NombreAgenteNaviero") Then
            transporteMaritimo.NombreAgenteNaviero = nodoTransporteMaritimo.GetAttribute("NombreAgenteNaviero")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumAutorizacionNaviero") Then
            transporteMaritimo.NumAutorizacionNaviero = nodoTransporteMaritimo.GetAttribute("NumAutorizacionNaviero")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumViaje") Then
            transporteMaritimo.NumViaje = nodoTransporteMaritimo.GetAttribute("NumViaje")
        End If
        If nodoTransporteMaritimo.HasAttribute("NumConocEmbarc") Then
            transporteMaritimo.NumConocEmbarc = nodoTransporteMaritimo.GetAttribute("NumConocEmbarc")
        End If
        If nodoTransporteMaritimo.HasAttribute("PermisoTempNavegacion") Then
            transporteMaritimo.PermisoTempNavegacion = nodoTransporteMaritimo.GetAttribute("PermisoTempNavegacion")
        End If
        transporteMaritimo.Contenedor = ObtenerContenedor(nodoTransporteMaritimo)
        transporteMaritimo.RemolquesCCP = ObtenerRemolquesCPP(nodoTransporteMaritimo)
        Return transporteMaritimo
    End Function
    Private Shared Function ObtenerContenedor(nodoTransporteMaritimo As XmlElement) As List(Of Contenedor)
        Dim listaContenedor As New List(Of Contenedor)()
        Dim nListaContenedor As XmlNodeList = nodoTransporteMaritimo.GetElementsByTagName("cartaporte30:Contenedor")
        For i As Integer = 0 To nListaContenedor.Count - 1
            Dim item As XmlElement = DirectCast(nListaContenedor.Item(i), XmlElement)
            Dim contenedor As New Contenedor()
            If item.HasAttribute("TipoContenedor") Then
                contenedor.TipoContenedor = item.GetAttribute("TipoContenedor")
            End If
            If item.HasAttribute("MatriculaContenedor") Then
                contenedor.MatriculaContenedor = item.GetAttribute("MatriculaContenedor")
            End If
            If item.HasAttribute("NumPrecinto") Then
                contenedor.NumPrecinto = item.GetAttribute("NumPrecinto")
            End If
            If item.HasAttribute("IdCCPRelacionado") Then
                contenedor.IdCCPRelacionado = item.GetAttribute("IdCCPRelacionado")
            End If
            If item.HasAttribute("PlacaVMCCP") Then
                contenedor.PlacaVMCCP = item.GetAttribute("PlacaVMCCP")
            End If
            If item.HasAttribute("FechaCertificacionCCP") Then
                contenedor.FechaCertificacionCCP = DateTime.Parse(item.GetAttribute("FechaCertificacionCCP"))
            End If
            listaContenedor.Add(contenedor)
        Next
        Return listaContenedor
    End Function

    Private Shared Function ObtenerRemolquesCPP(nodoTransporteMaritimo As XmlElement) As RemolquesCCP
        Dim remolques As New RemolquesCCP()
        Dim listaRemolques As XmlNodeList = nodoTransporteMaritimo.GetElementsByTagName("cartaporte30:RemolquesCPP")
        If listaRemolques.Count = 0 Then
            Return Nothing
        End If
        Dim nodoRemolques As XmlElement = DirectCast(listaRemolques.Item(0), XmlElement)
        remolques.RemolqueCCP = ObtenerRemolqueCCP(nodoRemolques)
        Return remolques
    End Function

    Private Shared Function ObtenerRemolqueCCP(nodoRemolques As XmlElement) As List(Of RemolqueCCP)
        Dim listaRemolqueCCP As New List(Of RemolqueCCP)()
        Dim nListaRemolqueCPP As XmlNodeList = nodoRemolques.GetElementsByTagName("cartaporte30:RemolqueCCP")
        For i As Integer = 0 To nListaRemolqueCPP.Count - 1
            Dim item As XmlElement = DirectCast(nListaRemolqueCPP.Item(i), XmlElement)
            Dim remolqueCPP As New RemolqueCCP()
            If item.HasAttribute("SubTipoRemCCP") Then
                remolqueCPP.SubTipoRemCCP = item.GetAttribute("SubTipoRemCCP")
            End If
            If item.HasAttribute("PlacaCCP") Then
                remolqueCPP.PlacaCCP = item.GetAttribute("PlacaCCP")
            End If
            listaRemolqueCCP.Add(remolqueCPP)
        Next
        Return listaRemolqueCCP
    End Function

    Private Shared Function ObtenerTransporteAereo(nodoMercancias As XmlElement) As TransporteAereo
        Dim transporteAereo As New TransporteAereo()
        Dim listaTransporteAereo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte30:TransporteAereo")
        If listaTransporteAereo.Count = 0 Then
            Return Nothing
        End If
        Dim nodoTransporteAereo As XmlElement = DirectCast(listaTransporteAereo.Item(0), XmlElement)
        If nodoTransporteAereo.HasAttribute("PermSCT") Then
            transporteAereo.PermSCT = nodoTransporteAereo.GetAttribute("PermSCT")
        End If
        If nodoTransporteAereo.HasAttribute("NumPermisoSCT") Then
            transporteAereo.NumPermisoSCT = nodoTransporteAereo.GetAttribute("NumPermisoSCT")
        End If
        ' ... (similar for other attributes)
        Return transporteAereo
    End Function

    Private Shared Function ObtenerTransporteFerroviario(nodoMercancias As XmlElement) As TransporteFerroviario
        Dim transporteFerroviario As New TransporteFerroviario()
        Dim listaTransporteFerroviario As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte30:TransporteFerroviario")
        If listaTransporteFerroviario.Count = 0 Then
            Return Nothing
        End If
        Dim nodoTransporteFerroviario As XmlElement = DirectCast(listaTransporteFerroviario.Item(0), XmlElement)
        If nodoTransporteFerroviario.HasAttribute("TipoDeServicio") Then
            transporteFerroviario.TipoDeServicio = nodoTransporteFerroviario.GetAttribute("TipoDeServicio")
        End If
        If nodoTransporteFerroviario.HasAttribute("TipoDeTrafico") Then
            transporteFerroviario.TipoDeTrafico = nodoTransporteFerroviario.GetAttribute("TipoDeTrafico")
        End If
        ' ... (similar for other attributes)
        Return transporteFerroviario
    End Function

    Private Shared Function ObtenerDerechosDePaso(nodoTransporteFerroviario As XmlElement) As List(Of DerechosDePaso)
        Dim listaDerechosDePaso As New List(Of DerechosDePaso)()
        Dim nlistaDerechosDePaso As XmlNodeList = nodoTransporteFerroviario.GetElementsByTagName("cartaporte30:DerechosDePaso")
        For i As Integer = 0 To nlistaDerechosDePaso.Count - 1
            Dim item As XmlElement = DirectCast(nlistaDerechosDePaso.Item(i), XmlElement)
            Dim derechosDePaso As New DerechosDePaso()
            If item.HasAttribute("TipoDerechoDePaso") Then
                derechosDePaso.TipoDerechoDePaso = item.GetAttribute("TipoDerechoDePaso")
            End If
            If item.HasAttribute("KilometrajePagado") Then
                derechosDePaso.KilometrajePagado = Double.Parse(item.GetAttribute("KilometrajePagado"))
            End If
            listaDerechosDePaso.Add(derechosDePaso)
        Next
        Return listaDerechosDePaso
    End Function

    Private Shared Function ObtenerCarro(nodoTransporteFerroviario As XmlElement) As List(Of Carro)
        Dim listaCarro As New List(Of Carro)()
        Dim nlistaCarro As XmlNodeList = nodoTransporteFerroviario.GetElementsByTagName("cartaporte30:Carro")
        For i As Integer = 0 To nlistaCarro.Count - 1
            Dim item As XmlElement = DirectCast(nlistaCarro.Item(i), XmlElement)
            Dim carro As New Carro()

            If item.HasAttribute("TipoCarro") Then
                carro.TipoCarro = item.GetAttribute("TipoCarro")
            End If
            If item.HasAttribute("MatriculaCarro") Then
                carro.MatriculaCarro = item.GetAttribute("MatriculaCarro")
            End If
            If item.HasAttribute("GuiaCarro") Then
                carro.GuiaCarro = item.GetAttribute("GuiaCarro")
            End If
            If item.HasAttribute("ToneladasNetasCarro") Then
                carro.ToneladasNetasCarro = Double.Parse(item.GetAttribute("ToneladasNetasCarro"))
            End If
            carro.Contenedor = ObtenerContenedorCarro(item)
            listaCarro.Add(carro)
        Next
        Return listaCarro
    End Function

    Private Shared Function ObtenerContenedorCarro(nodoCarro As XmlElement) As List(Of CarroContenedor)
        Dim listaContenedor As New List(Of CarroContenedor)()
        Dim nlistaContenedor As XmlNodeList = nodoCarro.GetElementsByTagName("cartaporte30:Contenedor")
        For i As Integer = 0 To nlistaContenedor.Count - 1
            Dim item As XmlElement = DirectCast(nlistaContenedor.Item(i), XmlElement)
            Dim contenedor As New CarroContenedor()
            If item.HasAttribute("TipoContenedor") Then
                contenedor.TipoContenedor = item.GetAttribute("TipoContenedor")
            End If
            If item.HasAttribute("PesoContenedorVacio") Then
                contenedor.PesoContenedorVacio = Double.Parse(item.GetAttribute("PesoContenedorVacio"))
            End If
            If item.HasAttribute("PesoNetoMercancia") Then
                contenedor.PesoNetoMercancia = Double.Parse(item.GetAttribute("PesoNetoMercancia"))
            End If
            listaContenedor.Add(contenedor)
        Next
        Return listaContenedor
    End Function

    Private Shared Function ObtenerFiguraTransporte(nodoCartaPorte As XmlElement) As FiguraTransporte
        Dim figuraTransporte As New FiguraTransporte()
        Dim listaFiguraTransporte As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte30:FiguraTransporte")
        If listaFiguraTransporte.Count = 0 Then
            Return Nothing
        End If
        Dim nodoFiguraTransporte As XmlElement = If(TypeOf listaFiguraTransporte.Item(0) Is XmlElement, DirectCast(listaFiguraTransporte.Item(0), XmlElement), Nothing)
        figuraTransporte.TiposFigura = ObtenerTiposFigura(nodoFiguraTransporte)
        Return figuraTransporte
    End Function

    Private Shared Function ObtenerTiposFigura(nodoFiguraTransporte As XmlElement) As List(Of TiposFigura)
        Dim listaTiposFigura As New List(Of TiposFigura)()
        Dim nListaTiposFigura As XmlNodeList = nodoFiguraTransporte.GetElementsByTagName("cartaporte30:TiposFigura")
        For i As Integer = 0 To nListaTiposFigura.Count - 1
            Dim item As XmlElement = DirectCast(nListaTiposFigura.Item(i), XmlElement)
            Dim tiposFigura As New TiposFigura()
            If item.HasAttribute("TipoFigura") Then
                tiposFigura.TipoFigura = item.GetAttribute("TipoFigura")
            End If
            If item.HasAttribute("RFCFigura") Then
                tiposFigura.RFCFigura = item.GetAttribute("RFCFigura")
            End If
            If item.HasAttribute("NumLicencia") Then
                tiposFigura.NumLicencia = item.GetAttribute("NumLicencia")
            End If
            If item.HasAttribute("NombreFigura") Then
                tiposFigura.NombreFigura = item.GetAttribute("NombreFigura")
            End If
            If item.HasAttribute("NumRegIdTribFigura") Then
                tiposFigura.NumRegIdTribFigura = item.GetAttribute("NumRegIdTribFigura")
            End If
            If item.HasAttribute("ResidenciaFiscalFigura") Then
                tiposFigura.ResidenciaFiscalFigura = item.GetAttribute("ResidenciaFiscalFigura")
            End If
            tiposFigura.PartesTransporte = ObtenerPartesTransporte(item)
            tiposFigura.Domicilio = ObtenerDomicilio(item)
            listaTiposFigura.Add(tiposFigura)
        Next
        Return listaTiposFigura
    End Function

    Private Shared Function ObtenerPartesTransporte(nodoTiposFigura As XmlElement) As List(Of PartesTransporte)
        Dim listaPartesTransporte As New List(Of PartesTransporte)()
        Dim nListaPartesTransporte As XmlNodeList = nodoTiposFigura.GetElementsByTagName("cartaporte30:PartesTransporte")
        For i As Integer = 0 To nListaPartesTransporte.Count - 1
            Dim item As XmlElement = DirectCast(nListaPartesTransporte.Item(i), XmlElement)
            Dim partesTransporte As New PartesTransporte()
            If item.HasAttribute("ParteTransporte") Then
                partesTransporte.ParteTransporte = item.GetAttribute("ParteTransporte")
            End If
            listaPartesTransporte.Add(partesTransporte)
        Next
        Return listaPartesTransporte
    End Function

End Class