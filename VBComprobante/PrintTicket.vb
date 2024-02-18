Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text


Public Class PrintTicket
    Public Shared Function Print(ByVal comprobante As Comprobante, ByVal impresora As String, ByVal rutaImagen As String)
        Dim Ticket As New Ticket()
        Ticket.RutaImagen = rutaImagen
        Ticket.Comprobante = comprobante
        Ticket.ImprimeTicket(impresora)
        Return Nothing

    End Function
#Region "SAT"
    Private Shared Function ObtenerRegimenFiscal(ByVal clave As String) As String
        If clave = "601" Then
            Return "General de Ley Personas Morales"
        ElseIf clave = "603" Then
            Return "Personas Morales con Fines no Lucrativos"
        ElseIf clave = "605" Then
            Return "Sueldos y Salarios e Ingresos Asimilados a Salarios"
        ElseIf clave = "606" Then
            Return "Arrendamiento"
        ElseIf clave = "608" Then
            Return "Demás ingresos"
        ElseIf clave = "609" Then
            Return "Consolidación"
        ElseIf clave = "610" Then
            Return "Residentes en el Extranjero sin Establecimiento Permanente en México"
        ElseIf clave = "611" Then
            Return "Ingresos por Dividendos (socios y accionistas)"
        ElseIf clave = "612" Then
            Return "Personas Físicas con Actividades Empresariales y Profesionales"
        ElseIf clave = "614" Then
            Return "Ingresos por intereses"
        ElseIf clave = "616" Then
            Return "Sin obligaciones fiscales"
        ElseIf clave = "620" Then
            Return "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"
        ElseIf clave = "621" Then
            Return "Incorporación Fiscal"
        ElseIf clave = "622" Then
            Return "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"
        ElseIf clave = "623" Then
            Return "Opcional para Grupos de Sociedades"
        ElseIf clave = "624" Then
            Return "Coordinados"
        ElseIf clave = "628" Then
            Return "Hidrocarburos"
        ElseIf clave = "607" Then
            Return "Régimen de Enajenación o Adquisición de Bienes"
        ElseIf clave = "629" Then
            Return "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"
        ElseIf clave = "630" Then
            Return "Enajenación de acciones en bolsa de valores"
        ElseIf clave = "615" Then
            Return "Régimen de los ingresos por obtención de premios"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerUsoCFDI(ByVal clave As String) As String
        If clave = "G01" Then
            Return "Adquisición de mercancias"
        ElseIf clave = "G02" Then
            Return "Devoluciones, descuentos o bonificaciones"
        ElseIf clave = "G03" Then
            Return "Gastos en general"
        ElseIf clave = "I01" Then
            Return "Construcciones"
        ElseIf clave = "I02" Then
            Return "Mobilario y equipo de oficina por inversiones"
        ElseIf clave = "I03" Then
            Return "Equipo de transporte"
        ElseIf clave = "I04" Then
            Return "Equipo de computo y accesorios"
        ElseIf clave = "I05" Then
            Return "Dados, troqueles, moldes, matrices y herramental"
        ElseIf clave = "I06" Then
            Return "Comunicaciones telefónicas"
        ElseIf clave = "I07" Then
            Return "Comunicaciones satelitales"
        ElseIf clave = "I08" Then
            Return "Otra maquinaria y equipo"
        ElseIf clave = "D01" Then
            Return "Honorarios médicos, dentales y gastos hospitalarios."
        ElseIf clave = "D02" Then
            Return "Gastos médicos por incapacidad o discapacidad"
        ElseIf clave = "D03" Then
            Return "Gastos funerales."
        ElseIf clave = "D04" Then
            Return "Donativos."
        ElseIf clave = "D05" Then
            Return "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."
        ElseIf clave = "D06" Then
            Return "Aportaciones voluntarias al SAR."
        ElseIf clave = "D07" Then
            Return "Primas por seguros de gastos médicos."
        ElseIf clave = "D08" Then
            Return "Gastos de transportación escolar obligatoria."
        ElseIf clave = "D09" Then
            Return "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."
        ElseIf clave = "D10" Then
            Return "Pagos por servicios educativos (colegiaturas)"
        ElseIf clave = "P01" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerImpuesto(ByVal clave As String) As String
        If clave = "001" Then
            Return "ISR"
        ElseIf clave = "002" Then
            Return "IVA"
        ElseIf clave = "003" Then
            Return "IEPS"
        Else
            Return ""
        End If
    End Function
    Private Shared Function ObtenerTipoComprobante(ByVal clave As String) As String
        If clave = "I" Then
            Return "Ingreso"
        ElseIf clave = "E" Then
            Return "Egreso"
        ElseIf clave = "T" Then
            Return "Traslado"
        ElseIf clave = "N" Then
            Return "Nómina"
        ElseIf clave = "P" Then
            Return "Pago"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerFormaPago(ByVal clave As String) As String
        If clave = "01" Then
            Return "Efectivo"
        ElseIf clave = "02" Then
            Return "Cheque nominativo"
        ElseIf clave = "03" Then
            Return "Transferencia electrónica de fondos"
        ElseIf clave = "04" Then
            Return "Tarjeta de crédito"
        ElseIf clave = "05" Then
            Return "Monedero electrónico"
        ElseIf clave = "06" Then
            Return "Dinero electrónico"
        ElseIf clave = "08" Then
            Return "Vales de despensa"
        ElseIf clave = "12" Then
            Return "Dación en pago"
        ElseIf clave = "13" Then
            Return "Pago por subrogación"
        ElseIf clave = "14" Then
            Return "Pago por consignación"
        ElseIf clave = "15" Then
            Return "Condonación"
        ElseIf clave = "17" Then
            Return "Compensación"
        ElseIf clave = "23" Then
            Return "Novación"
        ElseIf clave = "24" Then
            Return "Confusión"
        ElseIf clave = "25" Then
            Return "Remisión de deuda"
        ElseIf clave = "26" Then
            Return "Prescripción o caducidad"
        ElseIf clave = "27" Then
            Return "A satisfacción del acreedor"
        ElseIf clave = "28" Then
            Return "Tarjeta de débito"
        ElseIf clave = "29" Then
            Return "Tarjeta de servicios"
        ElseIf clave = "30" Then
            Return "Aplicación de anticipos"
        ElseIf clave = "99" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerMetodoPago(ByVal clave As String) As String
        If clave = "PUE" Then
            Return "Pago en una sola exhibición"
        ElseIf clave = "PPD" Then
            Return "Pago en parcialidades o diferido"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerMoneda(ByVal clave As String) As String
        If clave = "MXN" Then
            Return "Peso Mexicano"
        ElseIf clave = "EUR" Then
            Return "Euro"
        ElseIf clave = "USD" Then
            Return "Dolar americano"
        ElseIf clave = "XXX" Then
            Return "Los códigos asignados para las transacciones en que intervenga ninguna moneda"
        Else
            Return " "
        End If
    End Function
#End Region

End Class

Public Class Ticket
    Public Comprobante As Comprobante
    Public RutaImagen As String
    Private LineasDeLaCabeza As ArrayList = New ArrayList()
    Private LineasDeLaSubCabeza As ArrayList = New ArrayList()
    Private PosicionY As Integer = 0
    Private tamanoPapel As Single = 80 '80 milimetros
    Private imageHeight As Integer = 0
    Private NombreDeLaFuente As String = "Lucida Console"
    Private TamanoDeLaFuente As Integer = 7
    Private FUENTE_TITULO As Font = New Font(NombreDeLaFuente, TamanoDeLaFuente + 1, FontStyle.Bold)
    Private FUENTE_SELLOS As Font = New Font(NombreDeLaFuente, TamanoDeLaFuente - 2, FontStyle.Bold)
    Private FUENTE_NORMAL As Font = New Font(NombreDeLaFuente, TamanoDeLaFuente, FontStyle.Bold)
    Private FUENTE_NORMAL_BOLD As Font = New Font(NombreDeLaFuente, 8, FontStyle.Bold)
    Public MargenIzquierdo As Double = 0
    Public MargenSuperior As Double = 3

    Private ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)
    Private gfx As Graphics
    Private WithEvents DocumentoAImprimir As New PrintDocument
    Public Sub Ticket()

    End Sub
    Public Function ImpresoraExistente(ByVal impresora As String) As Boolean
        For Each strPrinter As String In PrinterSettings.InstalledPrinters
            If impresora = strPrinter Then
                Return True
            End If
        Next strPrinter
        Return False
    End Function
    Public Sub ImprimeTicket(ByVal impresora As String)
        PosicionY = MargenSuperior
        If ImpresoraExistente(impresora) Then
            DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        Else
            MessageBox.Show("La impresora no existe")
            Return
        End If
        DocumentoAImprimir.Print()
    End Sub
    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics
        DibujaImagen()
        DibujaDatosFactura(Comprobante)
        DibujaLineaDivisora()
        DibujaEmisor(Comprobante.Emisor)
        DibujaReceptor(Comprobante.Receptor)
        DibujaConceptos(Comprobante.Conceptos)
        DibujaTotales(Comprobante)
        DibujaDatosPago(Comprobante)
        DibujaDatosSellos(Comprobante)
        DibujaCodigoQR(Comprobante)
    End Sub
    Private Function GetPosicionY(ByVal fuente As Font) As Double
        PosicionY = PosicionY + fuente.GetHeight(gfx)
        Return PosicionY
    End Function
    Private Function GetPosicionY(ByVal fuente As Font, ByVal lineas As Integer) As Double
        PosicionY = PosicionY + (fuente.GetHeight(gfx) * lineas)
        Return PosicionY
    End Function
    Private Sub DibujaImagen()
        Try
            Dim imagen As Image = Image.FromFile(RutaImagen)
            gfx.DrawImage(imagen, 25 - CInt(MargenIzquierdo), PosicionY, 25, 25)
            'Dim height As Double = (imagen.Height / 58) * 15
            'imageHeight = CInt(Math.Round(height) + 3)
            PosicionY = PosicionY + 30
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DibujaDatosFactura(c As Comprobante)
        gfx.DrawString("FACTURA " + c.Serie + c.Folio, FUENTE_TITULO, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_TITULO)
        gfx.DrawString("Folio Fiscal UUID", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.Complemento.TimbreFiscalDigital.UUID, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("NO. DE SERIE DEL CERTIFICADO DEL SAT", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.Complemento.TimbreFiscalDigital.NoCertificadoSAT, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("NO. DE SERIE DEL CERTIFICADO DEL EMISOR", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.NoCertificado, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("FECHA Y HORA DE CERTIFICACIÓN", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.Complemento.TimbreFiscalDigital.FechaTimbrado, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("RFC PROVEEDOR DE CERTIFICACIÓN", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.Complemento.TimbreFiscalDigital.RfcProvCertif, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("FECHA Y HORA DE EMISIÓN DE CFDI", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.Fecha, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
        gfx.DrawString("LUGAR DE EXPEDICION", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(c.LugarExpedicion, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL)
    End Sub
    Private Sub DibujaEmisor(emisor As Emisor)
        gfx.DrawString("Emisor", FUENTE_TITULO, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_TITULO)
        Dim cadena As KeyValuePair(Of Integer, String) = AjustarATamano(emisor.Nombre, tamanoPapel - 5, FUENTE_NORMAL_BOLD)
        gfx.DrawString(cadena.Value, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD, cadena.Key)
        gfx.DrawString(emisor.Rfc, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        cadena = AjustarATamano(emisor.RegimenFiscal + "-" + ObtenerRegimenFiscal(emisor.RegimenFiscal), tamanoPapel - 5, FUENTE_NORMAL_BOLD)
        gfx.DrawString(cadena.Value, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD, cadena.Key)
        DibujaLineaDivisora()
    End Sub
    Private Sub DibujaReceptor(Receptor As Receptor)
        gfx.DrawString("Cliente", FUENTE_TITULO, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_TITULO)
        If (Comprobante.Receptor.Nombre <> String.Empty) Then gfx.DrawString(Receptor.Nombre, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY) : GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString(Receptor.Rfc, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        If (Comprobante.Receptor.NumRegIdTrib <> String.Empty) Then gfx.DrawString(Receptor.NumRegIdTrib, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY) : GetPosicionY(FUENTE_NORMAL_BOLD)
        If (Comprobante.Receptor.ResidenciaFiscal <> String.Empty) Then gfx.DrawString(Receptor.ResidenciaFiscal, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY) : GetPosicionY(FUENTE_NORMAL_BOLD)

        Dim cadena As KeyValuePair(Of Integer, String) = AjustarATamano(Receptor.UsoCFDI & "-" & ObtenerUsoCFDI(Receptor.UsoCFDI), tamanoPapel - 5, FUENTE_NORMAL_BOLD)
        gfx.DrawString(cadena.Value, FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD, cadena.Key)

        DibujaLineaDivisora()
    End Sub
    Private Sub DibujaConceptos(conceptos As Conceptos)
        gfx.DrawString("Conceptos", FUENTE_TITULO, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_TITULO)
        gfx.DrawString("Descripción", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString("Código", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString("Cantidad", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 25, PosicionY)
        gfx.DrawString("Precio", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 40, PosicionY)
        gfx.DrawString("Importe", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 60, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString("ClaveProdServ", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString("ClaveUnidad", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 25, PosicionY)
        gfx.DrawString("Impuestos", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 60, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        For Each concepto As Concepto In conceptos.Concepto
            gfx.DrawString(concepto.Descripcion, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
            GetPosicionY(FUENTE_NORMAL)
            gfx.DrawString(concepto.NoIdentificacion, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
            gfx.DrawString(concepto.Cantidad.ToString("F2"), FUENTE_NORMAL, ColorDeLaFuente, 25, PosicionY)
            gfx.DrawString(concepto.ValorUnitario.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 40, PosicionY)
            gfx.DrawString(concepto.Importe.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
            GetPosicionY(FUENTE_NORMAL)
            gfx.DrawString(concepto.ClaveProdServ, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, PosicionY)
            gfx.DrawString(concepto.ClaveUnidad, FUENTE_NORMAL, ColorDeLaFuente, 25, PosicionY)
            gfx.DrawString(ObtenerImpuesto(concepto.Impuestos).ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
            GetPosicionY(FUENTE_NORMAL)
        Next
        DibujaLineaDivisora()
    End Sub
    Private Function AjustarATamano(texto As String, tamano As Single, fuente As Font) As KeyValuePair(Of Integer, String)
        Dim texto1 As String
        Dim residuo As Integer
        Dim division As Integer
        Dim numeroCaracteres As Integer
        Dim nuevaCadena As String
        nuevaCadena = String.Empty
        texto1 = texto
        Dim size As SizeF = gfx.MeasureString(texto, fuente)
        While (size.Width > tamano)
            texto1 = texto1.Remove(texto1.Length - 1)
            size = gfx.MeasureString(texto1, fuente)
        End While
        numeroCaracteres = texto1.Length
        residuo = texto.Length Mod numeroCaracteres
        division = texto.Length \ numeroCaracteres
        Dim ini As Integer
        ini = 0
        For i As Integer = 1 To division Step 1
            nuevaCadena += texto.Substring(ini, numeroCaracteres)
            nuevaCadena += vbCrLf
            ini = nuevaCadena.Length
        Next
        If (residuo > 0) Then
            nuevaCadena += texto.Substring(numeroCaracteres * division, residuo)
            nuevaCadena += vbCr
            division = division + 1
        End If

        Dim resultado As KeyValuePair(Of Integer, String) = New KeyValuePair(Of Integer, String)(division, nuevaCadena)
        Return resultado
    End Function
    Private Function ObtenerImpuesto(impuestos As ImpuestosC) As Single
        Dim total As Single = 0.0
        If (impuestos Is Nothing) Then Return total
        If (Not impuestos.Retenciones Is Nothing) Then
            For Each retencion As RetencionC In impuestos.Retenciones
                total = retencion.Importe
            Next
        End If
        If (Not impuestos.Traslados Is Nothing) Then
            For Each traslado As TrasladoC In impuestos.Traslados
                total = traslado.Importe
            Next
        End If
        Return total
    End Function

    
    Private Sub DibujaTotales(c As Comprobante)

        If Comprobante.Descuento > 0 Then
            gfx.DrawString("DESCUENTO", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 40, PosicionY)
            gfx.DrawString(c.Descuento.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
            GetPosicionY(FUENTE_NORMAL_BOLD)
        End If
        gfx.DrawString("SUBTOTAL", FUENTE_NORMAL_BOLD, ColorDeLaFuente, 40, PosicionY)
        gfx.DrawString(c.SubTotal.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)

        If Comprobante.Impuestos IsNot Nothing Then
            If Comprobante.Impuestos.Traslados IsNot Nothing Then
                For Each t As Traslado In Comprobante.Impuestos.Traslados
                    gfx.DrawString(ObtenerImpuesto(t.Impuesto) & " " & t.TasaOCuota.ToString("F6"), FUENTE_NORMAL, ColorDeLaFuente, 40, PosicionY)
                    gfx.DrawString(t.Importe.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
                    GetPosicionY(FUENTE_NORMAL)
                Next
            End If
            If Comprobante.Impuestos.Retenciones IsNot Nothing Then
                For Each r As Retencion In Comprobante.Impuestos.Retenciones
                    gfx.DrawString(ObtenerImpuesto(r.Impuesto), FUENTE_NORMAL, ColorDeLaFuente, 40, PosicionY)
                    gfx.DrawString(r.Importe.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
                    GetPosicionY(FUENTE_NORMAL)
                Next
            End If
        End If
        gfx.DrawString("TOTAL", FUENTE_NORMAL, ColorDeLaFuente, 40, PosicionY)
        gfx.DrawString(c.Total.ToString("C2"), FUENTE_NORMAL, ColorDeLaFuente, 60, PosicionY)
        GetPosicionY(FUENTE_NORMAL)

        DibujaLineaDivisora()
    End Sub
    Private Sub DibujaDatosPago(c As Comprobante)

        gfx.DrawString("TIPO DE COMPROBANTE", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString(c.TipoDeComprobante & "-" & ObtenerTipoComprobante(c.TipoDeComprobante), FUENTE_NORMAL, ColorDeLaFuente, 38, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString("FORMA DE PAGO", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString(c.FormaPago & "-" & ObtenerFormaPago(c.FormaPago), FUENTE_NORMAL, ColorDeLaFuente, 28, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString("METODO DE PAGO", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString(c.MetodoPago & "-" & ObtenerTipoComprobante(c.MetodoPago), FUENTE_NORMAL, ColorDeLaFuente, 28, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        gfx.DrawString("MONEDA", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        gfx.DrawString(c.Moneda & "-" & ObtenerMoneda(c.Moneda), FUENTE_NORMAL, ColorDeLaFuente, 28, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)
        DibujaLineaDivisora()
    End Sub
    Private Sub DibujaDatosSellos(c As Comprobante)
        Dim cadena As KeyValuePair(Of Integer, String)
        gfx.DrawString("SELLO DIGITAL DEL CFDI", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)

        cadena = AjustarATamano(c.Complemento.TimbreFiscalDigital.SelloCFD, tamanoPapel - 5, FUENTE_SELLOS)
        gfx.DrawString(cadena.Value, FUENTE_SELLOS, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_SELLOS, cadena.Key)

        gfx.DrawString("SELLO DIGITAL DEL SAT", FUENTE_NORMAL_BOLD, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_NORMAL_BOLD)

        cadena = AjustarATamano(c.Complemento.TimbreFiscalDigital.SelloSAT, tamanoPapel - 5, FUENTE_SELLOS)
        gfx.DrawString(cadena.Value, FUENTE_SELLOS, ColorDeLaFuente, MargenIzquierdo, PosicionY)
        GetPosicionY(FUENTE_SELLOS, cadena.Key)

        DibujaLineaDivisora()
    End Sub
    Private Sub DibujaCodigoQR(comprobante As Comprobante)
        Dim codigoQR As StringBuilder = New StringBuilder()
        codigoQR.Append("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?")
        codigoQR.Append("&id=" & comprobante.Complemento.TimbreFiscalDigital.UUID)
        codigoQR.Append("&re=" & comprobante.Emisor.Rfc)
        codigoQR.Append("&rr=" & comprobante.Receptor.Rfc)
        codigoQR.Append("&tt=" & comprobante.Total.ToString())
        codigoQR.Append("&fe=" & comprobante.Sello.Substring(comprobante.Sello.Length - 8, 8))
        Dim pdfCodigoQR As BarcodeQRCode1 = New BarcodeQRCode1(codigoQR.ToString(), 1, 1, Nothing)
        Dim img As System.Drawing.Image = pdfCodigoQR.GetImage()
        'img.ScaleAbsolute(60, 60)
        'img.Alignment = iTextSharp.text.Element.ALIGN_LEFT
        gfx.DrawImage(img, CInt(MargenIzquierdo), CInt(PosicionY), 35, 35)
        'gfx.DrawImage(img, New Point(CInt(MargenIzquierdo), CInt(PosicionY)))

        'If (headerImagep.Width <> 0) Then
        '    Try
        '        gfx.DrawImage(HeaderImage, New Point(CInt(MargenIzquierdo), CInt(Renglon())))
        '        Dim height As Double = (HeaderImage.Height / 58) * 15
        '        imageHeight = CInt(Math.Round(height) + 3)
        '    Catch ex As Exception

        '    End Try
        'End If

    End Sub
    Private Sub DibujaLineaDivisora()
        Dim pen As New Pen(Brushes.Black)
        pen.Width = 0.25
        PosicionY = PosicionY + 1
        gfx.DrawLine(pen, New Point(MargenIzquierdo, PosicionY), New Point(80, PosicionY))
        PosicionY = PosicionY + 1 + 0.25
    End Sub
    Private Sub DibujaNuevaLinea()
        PosicionY = PosicionY + 1
    End Sub

    'Private Sub DibujaLaSubCabecera()
    '    For Each SubCabecera As String In LineasDeLaSubCabeza
    '        If (SubCabecera.Length > MaximoCaracter()) Then
    '            Dim CaracterActual As Integer = 0
    '            Dim LongitudSubcabecera As Integer = SubCabecera.Length
    '            While (LongitudSubcabecera > MaximoCaracter())
    '                CadenaPorEscribirEnLinea = SubCabecera
    '                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '                contador += 1
    '                CaracterActual += MaximoCaracter()
    '                LongitudSubcabecera -= MaximoCaracter()
    '            End While
    '            CadenaPorEscribirEnLinea = SubCabecera
    '            gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '            contador += 1
    '        Else
    '            CadenaPorEscribirEnLinea = SubCabecera
    '            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '            contador += 1
    '            CadenaPorEscribirEnLinea = DottedLine()
    '            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '            contador += 1
    '        End If
    '    Next SubCabecera
    '    DibujaEspacio()
    'End Sub
    'Private Sub DibujaElementos()
    '    Dim OrdenElemento As OrdenarElementos = New OrdenarElementos()
    '    gfx.DrawString("CANT DESCRIPCION IMPORTE", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '    contador += 1
    '    DibujaEspacio()
    '    For Each Elemento As String In Elementos
    '        CadenaPorEscribirEnLinea = OrdenElemento.ObtenerCantidadDeElementos(Elemento)
    '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '        CadenaPorEscribirEnLinea = OrdenElemento.ObtenerPrecioElemento(Elemento)
    '        CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
    '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '        Dim Nombre As String = OrdenElemento.ObtenerNombreElemento(Elemento)
    '        MargenIzquierdo = 10
    '        If (Nombre.Length > MaximoCaracterDescripcion) Then
    '            Dim CaracterActual As Integer = 0
    '            Dim LongitudElemento As Integer = Nombre.Length
    '            While (LongitudElemento > MaximoCaracterDescripcion)
    '                CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
    '                gfx.DrawString(" " + CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterDescripcion), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

    '                contador += 1
    '                CaracterActual += MaximoCaracterDescripcion
    '                LongitudElemento -= MaximoCaracterDescripcion
    '            End While
    '            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
    '            gfx.DrawString(" " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon() + 10, New StringFormat())
    '            contador += 1
    '        Else
    '            gfx.DrawString(" " + OrdenElemento.ObtenerNombreElemento(Elemento), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '            contador += 1
    '        End If
    '    Next Elemento

    '    MargenIzquierdo = 10
    '    DibujaEspacio()
    '    CadenaPorEscribirEnLinea = DottedLine()
    '    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '    contador += 1
    '    DibujaEspacio()
    'End Sub
    'Private Sub DibujaTotales()
    '    Dim ordTot As OrdernarTotal = New OrdernarTotal()
    '    For Each total As String In Totales
    '        CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
    '        CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
    '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '        MargenIzquierdo = 10
    '        CadenaPorEscribirEnLinea = " " + ordTot.ObtenerTotalNombre(total)
    '        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '        contador += 1
    '    Next total
    '    MargenIzquierdo = 10
    '    DibujaEspacio()
    '    DibujaEspacio()
    'End Sub
    'Private Sub DibujarPieDePagina()
    '    For Each PieDePagina As String In LineasDelPie
    '        If (PieDePagina.Length > MaximoCaracter()) Then
    '            Dim currentChar As Integer = 0
    '            Dim LongitudPieDePagina As Integer = PieDePagina.Length
    '            While (LongitudPieDePagina > MaximoCaracter())
    '                CadenaPorEscribirEnLinea = PieDePagina
    '                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

    '                contador += 1
    '                currentChar += MaximoCaracter()
    '                LongitudPieDePagina -= MaximoCaracter()
    '            End While
    '            CadenaPorEscribirEnLinea = PieDePagina
    '            gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, CadenaPorEscribirEnLinea.Length - currentChar), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '            contador += 1
    '        Else
    '            CadenaPorEscribirEnLinea = PieDePagina
    '            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

    '            contador += 1
    '        End If
    '    Next PieDePagina
    '    MargenIzquierdo = 10
    '    DibujaEspacio()
    'End Sub
    'Private Sub DibujaEspacio()
    '    CadenaPorEscribirEnLinea = " "
    '    gfx.DrawString(CadenaPorEscribirEnLinea, FUENTE_NORMAL, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
    '    contador += 1
    'End Sub

    Public Sub New()

    End Sub
#Region "SAT"
    Private Shared Function ObtenerRegimenFiscal(ByVal clave As String) As String
        If clave = "601" Then
            Return "General de Ley Personas Morales"
        ElseIf clave = "603" Then
            Return "Personas Morales con Fines no Lucrativos"
        ElseIf clave = "605" Then
            Return "Sueldos y Salarios e Ingresos Asimilados a Salarios"
        ElseIf clave = "606" Then
            Return "Arrendamiento"
        ElseIf clave = "608" Then
            Return "Demás ingresos"
        ElseIf clave = "609" Then
            Return "Consolidación"
        ElseIf clave = "610" Then
            Return "Residentes en el Extranjero sin Establecimiento Permanente en México"
        ElseIf clave = "611" Then
            Return "Ingresos por Dividendos (socios y accionistas)"
        ElseIf clave = "612" Then
            Return "Personas Físicas con Actividades Empresariales y Profesionales"
        ElseIf clave = "614" Then
            Return "Ingresos por intereses"
        ElseIf clave = "616" Then
            Return "Sin obligaciones fiscales"
        ElseIf clave = "620" Then
            Return "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"
        ElseIf clave = "621" Then
            Return "Incorporación Fiscal"
        ElseIf clave = "622" Then
            Return "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"
        ElseIf clave = "623" Then
            Return "Opcional para Grupos de Sociedades"
        ElseIf clave = "624" Then
            Return "Coordinados"
        ElseIf clave = "628" Then
            Return "Hidrocarburos"
        ElseIf clave = "607" Then
            Return "Régimen de Enajenación o Adquisición de Bienes"
        ElseIf clave = "629" Then
            Return "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"
        ElseIf clave = "630" Then
            Return "Enajenación de acciones en bolsa de valores"
        ElseIf clave = "615" Then
            Return "Régimen de los ingresos por obtención de premios"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerUsoCFDI(ByVal clave As String) As String
        If clave = "G01" Then
            Return "Adquisición de mercancias"
        ElseIf clave = "G02" Then
            Return "Devoluciones, descuentos o bonificaciones"
        ElseIf clave = "G03" Then
            Return "Gastos en general"
        ElseIf clave = "I01" Then
            Return "Construcciones"
        ElseIf clave = "I02" Then
            Return "Mobilario y equipo de oficina por inversiones"
        ElseIf clave = "I03" Then
            Return "Equipo de transporte"
        ElseIf clave = "I04" Then
            Return "Equipo de computo y accesorios"
        ElseIf clave = "I05" Then
            Return "Dados, troqueles, moldes, matrices y herramental"
        ElseIf clave = "I06" Then
            Return "Comunicaciones telefónicas"
        ElseIf clave = "I07" Then
            Return "Comunicaciones satelitales"
        ElseIf clave = "I08" Then
            Return "Otra maquinaria y equipo"
        ElseIf clave = "D01" Then
            Return "Honorarios médicos, dentales y gastos hospitalarios."
        ElseIf clave = "D02" Then
            Return "Gastos médicos por incapacidad o discapacidad"
        ElseIf clave = "D03" Then
            Return "Gastos funerales."
        ElseIf clave = "D04" Then
            Return "Donativos."
        ElseIf clave = "D05" Then
            Return "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."
        ElseIf clave = "D06" Then
            Return "Aportaciones voluntarias al SAR."
        ElseIf clave = "D07" Then
            Return "Primas por seguros de gastos médicos."
        ElseIf clave = "D08" Then
            Return "Gastos de transportación escolar obligatoria."
        ElseIf clave = "D09" Then
            Return "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."
        ElseIf clave = "D10" Then
            Return "Pagos por servicios educativos (colegiaturas)"
        ElseIf clave = "P01" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerImpuesto(ByVal clave As String) As String
        If clave = "001" Then
            Return "ISR"
        ElseIf clave = "002" Then
            Return "IVA"
        ElseIf clave = "003" Then
            Return "IEPS"
        Else
            Return ""
        End If
    End Function
    Private Shared Function ObtenerTipoComprobante(ByVal clave As String) As String
        If clave = "I" Then
            Return "Ingreso"
        ElseIf clave = "E" Then
            Return "Egreso"
        ElseIf clave = "T" Then
            Return "Traslado"
        ElseIf clave = "N" Then
            Return "Nómina"
        ElseIf clave = "P" Then
            Return "Pago"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerFormaPago(ByVal clave As String) As String
        If clave = "01" Then
            Return "Efectivo"
        ElseIf clave = "02" Then
            Return "Cheque nominativo"
        ElseIf clave = "03" Then
            Return "Transferencia electrónica de fondos"
        ElseIf clave = "04" Then
            Return "Tarjeta de crédito"
        ElseIf clave = "05" Then
            Return "Monedero electrónico"
        ElseIf clave = "06" Then
            Return "Dinero electrónico"
        ElseIf clave = "08" Then
            Return "Vales de despensa"
        ElseIf clave = "12" Then
            Return "Dación en pago"
        ElseIf clave = "13" Then
            Return "Pago por subrogación"
        ElseIf clave = "14" Then
            Return "Pago por consignación"
        ElseIf clave = "15" Then
            Return "Condonación"
        ElseIf clave = "17" Then
            Return "Compensación"
        ElseIf clave = "23" Then
            Return "Novación"
        ElseIf clave = "24" Then
            Return "Confusión"
        ElseIf clave = "25" Then
            Return "Remisión de deuda"
        ElseIf clave = "26" Then
            Return "Prescripción o caducidad"
        ElseIf clave = "27" Then
            Return "A satisfacción del acreedor"
        ElseIf clave = "28" Then
            Return "Tarjeta de débito"
        ElseIf clave = "29" Then
            Return "Tarjeta de servicios"
        ElseIf clave = "30" Then
            Return "Aplicación de anticipos"
        ElseIf clave = "99" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerMetodoPago(ByVal clave As String) As String
        If clave = "PUE" Then
            Return "Pago en una sola exhibición"
        ElseIf clave = "PPD" Then
            Return "Pago en parcialidades o diferido"
        Else
            Return " "
        End If
    End Function
    Private Shared Function ObtenerMoneda(ByVal clave As String) As String
        If clave = "MXN" Then
            Return "Peso Mexicano"
        ElseIf clave = "EUR" Then
            Return "Euro"
        ElseIf clave = "USD" Then
            Return "Dolar americano"
        ElseIf clave = "XXX" Then
            Return "Los códigos asignados para las transacciones en que intervenga ninguna moneda"
        Else
            Return " "
        End If
    End Function
#End Region

End Class

'Public Class OrdenarElementos
'    Public delimitador() As Char = " "
'    Public Sub OrdenarElementos(ByVal delimit As Char)
'        Dim delimitador As Char = delimit
'    End Sub
'    Public Function ObtenerCantidadDeElementos(ByVal orderItem As String) As String
'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(0)
'    End Function
'    Public Function ObtenerNombreElemento(ByVal orderItem As String) As String
'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(1)
'    End Function
'    Public Function ObtenerPrecioElemento(ByVal orderItem As String) As String
'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(2)
'    End Function
'    Public Function GenerarElemento(ByVal cantidad As String, ByVal NombreElemento As String, ByVal Precio As String) As String
'        Return cantidad + delimitador(0) + NombreElemento + delimitador(0) + Precio
'    End Function
'End Class

'Public Class OrdernarTotal
'    Public delimitador() As Char = " "
'    Public Sub OrdernarTotal(ByVal delimit As Char)
'        Dim delimitador As Char = delimit
'    End Sub
'    Public Function ObtenerTotalNombre(ByVal totalItem As String) As String
'        Dim delimitado() As String = totalItem.Split(delimitador)
'        Return delimitado(0)
'    End Function
'    Public Function ObtenerTotalCantidad(ByVal totalItem As String) As String
'        Dim delimitado() As String = totalItem.Split(delimitador)
'        Return delimitado(1)
'    End Function
'    Public Function GenerarTotal(ByVal totalName As String, ByVal price As String) As String
'        GenerarTotal = totalName + delimitador(0) + price
'    End Function

'End Class

