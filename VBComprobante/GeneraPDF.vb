Imports System.Text
Imports System.Threading.Tasks
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Globalization
Imports System.Xml
Imports System.Drawing.Imaging
Imports Microsoft.SqlServer.Server
Imports iTextSharp.text.pdf.fonts.cmaps

Friend Class Catalogos
#Region "Catalogos SAT"
    Public Shared Function ObtenerRegimenFiscal(ByVal clave As String) As String
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
    Public Shared Function ObtenerMeses(ByVal meses As String)

        If (meses = "01") Then
            Return "Enero"
        ElseIf (meses = "02") Then
            Return "Febrero"
        ElseIf (meses = "03") Then
            Return "Marzo"
        ElseIf (meses = "04") Then
            Return "Abril"
        ElseIf (meses = "05") Then
            Return "Mayo"
        ElseIf (meses = "06") Then
            Return "Junio"
        ElseIf (meses = "07") Then
            Return "Julio"
        ElseIf (meses = "08") Then
            Return "Agosto"
        ElseIf (meses = "09") Then
            Return "Septiembre"
        ElseIf (meses = "10") Then
            Return "Octubre"
        ElseIf (meses = "11") Then
            Return "Noviembre"
        ElseIf (meses = "12") Then
            Return "Diciembre"
        ElseIf (meses = "13") Then
            Return "Enero-Febrero"
        ElseIf (meses = "14") Then
            Return "Marzo-Abril"
        ElseIf (meses = "15") Then
            Return "Mayo-Junio"
        ElseIf (meses = "16") Then
            Return "Julio-Agosto"
        ElseIf (meses = "17") Then
            Return "Septiembre-Octubre"
        ElseIf (meses = "18") Then
            Return "Noviembre-Diciembre"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerPeriodicidad(ByVal periodicidad As String)

        If (periodicidad = "01") Then
            Return "Diario"
        ElseIf (periodicidad = "02") Then
            Return "Semanal"
        ElseIf (periodicidad = "03") Then
            Return "Quincenal"
        ElseIf (periodicidad = "04") Then
            Return "Mensual"
        ElseIf (periodicidad = "05") Then
            Return "Bimestral"
        Else
            Return ""
        End If
    End Function

    Public Shared Function ObtenerTipoNomina(ByVal tipoNomina As String) As String
        tipoNomina = tipoNomina.ToUpper()

        If tipoNomina = "O" Then
            Return "Nómina ordinaria"
        ElseIf tipoNomina = "E" Then
            Return "Nómina extraordinaria"
        Else
            Return "-"
        End If
    End Function
    Public Shared Function ObtenerFormaPago(ByVal clave As String) As String
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
    Public Shared Function ObtenerImpuesto(ByVal clave As String) As String
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
    Public Shared Function ObtenerMetodoPago(ByVal clave As String) As String
        If clave = "PUE" Then
            Return "Pago en una sola exhibición"
        ElseIf clave = "PPD" Then
            Return "Pago en parcialidades o diferido"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerPais(ByVal clave As String) As String
        If clave = "MEX" Then
            Return "México"
        ElseIf clave = "USA" Then
            Return "Estados Unidos"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerTipoComprobante(ByVal clave As String) As String
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
    Public Shared Function ObtenerUsoCFDI(ByVal clave As String) As String
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
    Public Shared Function ObtenerUnidad(ByVal clave As String) As String
        clave = clave.ToUpper()

        If clave = "H87" Then
            Return "Pieza"
        ElseIf clave = "LTR" Then
            Return "Litro"
        ElseIf clave = "KGM" Then
            Return "Kilogramo"
        ElseIf clave = "E48" Then
            Return "Unidad de servicio"
        ElseIf clave = "EA" Then
            Return "Elemento"
        ElseIf clave = "PR" Then
            Return "Par"
        ElseIf clave = "ACT" Then
            Return "Actividad"
        ElseIf clave = "LUB" Then
            Return "Tonelada métrica, aceite lubricante"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerMoneda(ByVal clave As String) As String
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
    Public Shared Function ObtenerTipoRelacion(ByVal clave As String) As String
        If clave = "01" Then
            Return "Nota de crédito de los documentos relacionados"
        ElseIf clave = "02" Then
            Return "Nota de débito de los documentos relacionados"
        ElseIf clave = "03" Then
            Return "Devolución de mercancía sobre facturas o traslados previos"
        ElseIf clave = "04" Then
            Return "Sustitución de los CFDI previos"
        ElseIf clave = "05" Then
            Return "Traslados de mercancias facturados previamente"
        ElseIf clave = "06" Then
            Return "Factura generada por los traslados previos"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerTipoJornada(ByVal clave As String) As String
        If clave = "01" Then
            Return "Diurna"
        ElseIf clave = "02" Then
            Return "Nocturna"
        ElseIf clave = "03" Then
            Return "Mixta"
        ElseIf clave = "04" Then
            Return "Por hora"
        ElseIf clave = "05" Then
            Return "Reducida"
        ElseIf clave = "06" Then
            Return "Continuada"
        ElseIf clave = "07" Then
            Return "Partida"
        ElseIf clave = "08" Then
            Return "Por turnos"
        ElseIf clave = "99" Then
            Return "OtraJornada"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerTipoRegimen(ByVal clave As String) As String
        If clave = "02" Then
            Return "Sueldos"
        ElseIf clave = "07" Then
            Return "Asimilados Miembros consejos"
        ElseIf clave = "08" Then
            Return "Asimilados comisionistas"
        ElseIf clave = "09" Then
            Return "Asimilados Honorarios"
        ElseIf clave = "10" Then
            Return "Asimilados acciones"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerTipoJornada1(ByVal clave As String) As String
        If clave = "01" Then
            Return "8"
        ElseIf clave = "02" Then
            Return "7"
        ElseIf clave = "03" Then
            Return "7.3"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerPeriodicidadPago(ByVal clave As String) As String
        If clave = "02" Then
            Return "Semanal "
        ElseIf clave = "03" Then
            Return "Catorcenal "
        ElseIf clave = "04" Then
            Return "Quincenal "
        ElseIf clave = "05" Then
            Return "Mensual "
        ElseIf clave = "10" Then
            Return "Decenal "
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerRiesgoPuesto(ByVal riesgoPuesto As String) As String
        If riesgoPuesto = "1" Then
            Return "Clase I"
        ElseIf riesgoPuesto = "2" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "3" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "4" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "5" Then
            Return "Clase II"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerTipoContrato(ByVal clave As String) As String
        If clave = "01" Then
            Return "Contrato de trabajo por tiempo indeterminado"
        ElseIf clave = "02" Then
            Return "Contrato de trabajo para obra determinada"
        ElseIf clave = "03" Then
            Return "Contrato de trabajo por tiempo determinado"
        ElseIf clave = "04" Then
            Return "Contrato de trabajo por temporada"
        ElseIf clave = "05" Then
            Return "Contrato de trabajo sujeto a prueba"
        ElseIf clave = "06" Then
            Return "Contrato de trabajo con capacitación inicial"
        ElseIf clave = "07" Then
            Return "Modalidad de contratación por pago de hora laborada"
        ElseIf clave = "08" Then
            Return "Modalidad de trabajo por comisión laboral"
        ElseIf clave = "09" Then
            Return "Modalidades de contratación donde no existe relación de trabajo"
        ElseIf clave = "10" Then
            Return "Jubilación, pensión, retiro."
        ElseIf clave = "99" Then
            Return "Otro contrato"
        Else
            Return " "
        End If
    End Function
    Public Shared Function ObtenerTipoPercepcion(ByVal clave As String) As String
        If clave = "001" Then
            Return "Sueldos, Salarios  Rayas y Jornales"
        ElseIf clave = "002" Then
            Return "Gratificación Anual (Aguinaldo)"
        ElseIf clave = "003" Then
            Return "Participación de los Trabajadores en las Utilidades PTU"
        ElseIf clave = "004" Then
            Return "Reembolso de Gastos Médicos Dentales y Hospitalarios"
        ElseIf clave = "005" Then
            Return "Fondo de Ahorro"
        ElseIf clave = "006" Then
            Return "Caja de ahorro"
        ElseIf clave = "009" Then
            Return "Contribuciones a Cargo del Trabajador Pagadas por el Patrón"
        ElseIf clave = "010" Then
            Return "Premios por puntualidad"
        ElseIf clave = "011" Then
            Return "Prima de Seguro de vida"
        ElseIf clave = "012" Then
            Return "Seguro de Gastos Médicos Mayores"
        ElseIf clave = "013" Then
            Return "Cuotas Sindicales Pagadas por el Patrón"
        ElseIf clave = "014" Then
            Return "Subsidios por incapacidad"
        ElseIf clave = "015" Then
            Return "Becas para trabajadores y/o hijos"
        ElseIf clave = "019" Then
            Return "Horas extra"
        ElseIf clave = "020" Then
            Return "Prima dominical"
        ElseIf clave = "021" Then
            Return "Prima vacacional"
        ElseIf clave = "022" Then
            Return "Prima por antigüedad"
        ElseIf clave = "023" Then
            Return "Pagos por separación"
        ElseIf clave = "024" Then
            Return "Seguro de retiro"
        ElseIf clave = "025" Then
            Return "Indemnizaciones"
        ElseIf clave = "026" Then
            Return "Reembolso por funeral"
        ElseIf clave = "027" Then
            Return "Cuotas de seguridad social pagadas por el patrón"
        ElseIf clave = "028" Then
            Return "Comisiones"
        ElseIf clave = "029" Then
            Return "Vales de despensa"
        ElseIf clave = "030" Then
            Return "Vales de restaurante"
        ElseIf clave = "031" Then
            Return "Vales de gasolina"
        ElseIf clave = "032" Then
            Return "Vales de ropa"
        ElseIf clave = "033" Then
            Return "Ayuda para renta"
        ElseIf clave = "034" Then
            Return "Ayuda para artículos escolares"
        ElseIf clave = "035" Then
            Return "Ayuda para anteojos"
        ElseIf clave = "036" Then
            Return "Ayuda para transporte"
        ElseIf clave = "037" Then
            Return "Ayuda para gastos de funeral"
        ElseIf clave = "038" Then
            Return "Otros ingresos por salarios"
        ElseIf clave = "039" Then
            Return "Jubilaciones, pensiones o haberes de retiro"
        ElseIf clave = "044" Then
            Return "Jubilaciones, pensiones o haberes de retiro en parcialidades"
        ElseIf clave = "045" Then
            Return "Ingresos en acciones o títulos valor que representan bienes"
        ElseIf clave = "046" Then
            Return "Ingresos asimilados a salarios"
        ElseIf clave = "047" Then
            Return "Alimentación"
        ElseIf clave = "048" Then
            Return "Habitación"
        ElseIf clave = "049" Then
            Return "Premios por asistencia"
        ElseIf clave = "050" Then
            Return "Viáticos"
        ElseIf clave = "051" Then
            Return "Pagos por gratificaciones, primas, compensaciones, recompensas u otros a extrabajadores derivados de jubilación en parcialidades"
        ElseIf clave = "052" Then
            Return "Pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de resoluciones judicial o de un laudo"
        ElseIf clave = "053" Then
            Return "Pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de resoluciones judicial o de un laudo"
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function ObtenerTipoDeduccion(ByVal clave As String) As String
        If clave = "001" Then
            Return "Seguridad social"
        ElseIf clave = "002" Then
            Return "ISR"
        ElseIf clave = "003" Then
            Return "Aportaciones a retiro, cesantía en edad avanzada y vejez."
        ElseIf clave = "004" Then
            Return "Otros"
        ElseIf clave = "005" Then
            Return "Aportaciones a Fondo de vivienda"
        ElseIf clave = "006" Then
            Return "Descuento por incapacidad"
        ElseIf clave = "007" Then
            Return "Pensión alimenticia"
        ElseIf clave = "008" Then
            Return "Renta"
        ElseIf clave = "009" Then
            Return "Préstamos provenientes del Fondo Nacional de la Vivienda para los Trabajadores"
        ElseIf clave = "010" Then
            Return "Pago por crédito de vivienda"
        ElseIf clave = "011" Then
            Return "Pago de abonos INFONACOT"
        ElseIf clave = "012" Then
            Return "Anticipo de salarios"
        ElseIf clave = "013" Then
            Return "Pagos hechos con exceso al trabajador"
        ElseIf clave = "014" Then
            Return "Errores"
        ElseIf clave = "015" Then
            Return "Pérdidas"
        ElseIf clave = "016" Then
            Return "Averías"
        ElseIf clave = "017" Then
            Return "Adquisición de artículos producidos por la empresa o establecimiento"
        ElseIf clave = "018" Then
            Return "Cuotas para la constitución y fomento de sociedades cooperativas y de cajas de ahorro"
        ElseIf clave = "019" Then
            Return "Cuotas sindicales"
        ElseIf clave = "020" Then
            Return "Ausencia (Ausentismo)"
        ElseIf clave = "021" Then
            Return "Cuotas obrero patronales"
        ElseIf clave = "022" Then
            Return "Impuestos Locales"
        ElseIf clave = "023" Then
            Return "Aportaciones voluntarias"
        ElseIf clave = "024" Then
            Return "Ajuste en Gratificación Anual (Aguinaldo) Exento"
        ElseIf clave = "025" Then
            Return "Ajuste en Gratificación Anual (Aguinaldo) Gravado"
        ElseIf clave = "026" Then
            Return "Ajuste en Participación de los Trabajadores en las Utilidades PTU Exento"
        ElseIf clave = "027" Then
            Return "Ajuste en Participación de los Trabajadores en las Utilidades PTU Gravado"
        ElseIf clave = "028" Then
            Return "Ajuste en Reembolso de Gastos Médicos Dentales y Hospitalarios Exento"
        ElseIf clave = "029" Then
            Return "Ajuste en Fondo de ahorro Exento"
        ElseIf clave = "030" Then
            Return "Ajuste en Caja de ahorro Exento"
        ElseIf clave = "031" Then
            Return "Ajuste en Contribuciones a Cargo del Trabajador Pagadas por el Patrón Exento"
        ElseIf clave = "032" Then
            Return "Ajuste en Premios por puntualidad Gravado"
        ElseIf clave = "033" Then
            Return "Ajuste en Prima de Seguro de vida Exento"
        ElseIf clave = "034" Then
            Return "Ajuste en Seguro de Gastos Médicos Mayores Exento"
        ElseIf clave = "035" Then
            Return "Ajuste en Cuotas Sindicales Pagadas por el Patrón Exento"
        ElseIf clave = "036" Then
            Return "Ajuste en Subsidios por incapacidad Exento"
        ElseIf clave = "037" Then
            Return "Ajuste en Becas para trabajadores y/o hijos Exento"
        ElseIf clave = "038" Then
            Return "Ajuste en Horas extra Exento"
        ElseIf clave = "039" Then
            Return "Ajuste en Horas extra Gravado"
        ElseIf clave = "040" Then
            Return "Ajuste en Prima dominical Exento"
        ElseIf clave = "041" Then
            Return "Ajuste en Prima dominical Gravado"
        ElseIf clave = "042" Then
            Return "Ajuste en Prima vacacional Exento"
        ElseIf clave = "043" Then
            Return "Ajuste en Prima vacacional Gravado"
        ElseIf clave = "044" Then
            Return "Ajuste en Prima por antigüedad Exento"
        ElseIf clave = "045" Then
            Return "Ajuste en Prima por antigüedad Gravado"
        ElseIf clave = "046" Then
            Return "Ajuste en Pagos por separación Exento"
        ElseIf clave = "047" Then
            Return "Ajuste en Pagos por separación Gravado"
        ElseIf clave = "048" Then
            Return "Ajuste en Seguro de retiro Exento"
        ElseIf clave = "049" Then
            Return "Ajuste en Indemnizaciones Exento"
        ElseIf clave = "050" Then
            Return "Ajuste en Indemnizaciones Gravado"
        ElseIf clave = "051" Then
            Return "Ajuste en Reembolso por funeral Exento"
        ElseIf clave = "052" Then
            Return "Ajuste en Cuotas de seguridad social pagadas por el patrón Exento"
        ElseIf clave = "053" Then
            Return "Ajuste en Comisiones Gravado"
        ElseIf clave = "054" Then
            Return "Ajuste en Vales de despensa Exento"
        ElseIf clave = "055" Then
            Return "Ajuste en Vales de restaurante Exento"
        ElseIf clave = "056" Then
            Return "Ajuste en Vales de gasolina Exento"
        ElseIf clave = "057" Then
            Return "Ajuste en Vales de ropa Exento"
        ElseIf clave = "058" Then
            Return "Ajuste en Ayuda para renta Exento"
        ElseIf clave = "059" Then
            Return "Ajuste en Ayuda para artículos escolares Exento"
        ElseIf clave = "060" Then
            Return "Ajuste en Ayuda para anteojos Exento"
        ElseIf clave = "061" Then
            Return "Ajuste en Ayuda para transporte Exento"
        ElseIf clave = "062" Then
            Return "Ajuste en Ayuda para gastos de funeral Exento"
        ElseIf clave = "063" Then
            Return "Ajuste en Otros ingresos por salarios Exento"
        ElseIf clave = "064" Then
            Return "Ajuste en Otros ingresos por salarios Gravado"
        ElseIf clave = "065" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en una sola exhibición Exento "
        ElseIf clave = "066" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en una sola exhibición Gravado"
        ElseIf clave = "067" Then
            Return "Ajuste en Pagos por separación Acumulable"
        ElseIf clave = "068" Then
            Return "Ajuste en Pagos por separación No acumulable"
        ElseIf clave = "069" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en parcialidades Exento"
        ElseIf clave = "070" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en parcialidades Gravado"
        ElseIf clave = "071" Then
            Return "Ajuste en Subsidio para el empleo (efectivamente entregado al trabajador)"
        ElseIf clave = "072" Then
            Return "Ajuste en Ingresos en acciones o títulos valor que representan bienes Exento"
        ElseIf clave = "073" Then
            Return "Ajuste en Ingresos en acciones o títulos valor que representan bienes Gravado"
        ElseIf clave = "074" Then
            Return "Ajuste en Alimentación Exento"
        ElseIf clave = "075" Then
            Return "Ajuste en Alimentación Gravado"
        ElseIf clave = "076" Then
            Return "Ajuste en Habitación Exento"
        ElseIf clave = "077" Then
            Return "Ajuste en Habitación Gravado"
        ElseIf clave = "078" Then
            Return "Ajuste en Premios por asistencia"
        ElseIf clave = "079" Then
            Return "Ajuste en Pagos distintos a los listados y que no deben considerarse como ingreso por sueldos, salarios o ingresos asimilados."
        ElseIf clave = "080" Then
            Return "Ajuste en Viáticos gravados"
        ElseIf clave = "081" Then
            Return "Ajuste en Viáticos (entregados al trabajador)"
        ElseIf clave = "082" Then
            Return "Ajuste en Fondo de ahorro Gravado"
        ElseIf clave = "083" Then
            Return "Ajuste en Caja de ahorro Gravado"
        ElseIf clave = "084" Then
            Return "Ajuste en Prima de Seguro de vida Gravado"
        ElseIf clave = "085" Then
            Return "Ajuste en Seguro de Gastos Médicos Mayores Gravado"
        ElseIf clave = "086" Then
            Return "Ajuste en Subsidios por incapacidad Gravado"
        ElseIf clave = "087" Then
            Return "Ajuste en Becas para trabajadores y/o hijos Gravado"
        ElseIf clave = "088" Then
            Return "Ajuste en Seguro de retiro Gravado"
        ElseIf clave = "089" Then
            Return "Ajuste en Vales de despensa Gravado"
        ElseIf clave = "090" Then
            Return "Ajuste en Vales de restaurante Gravado"
        ElseIf clave = "091" Then
            Return "Ajuste en Vales de gasolina Gravado"
        ElseIf clave = "092" Then
            Return "Ajuste en Vales de ropa Gravado"
        ElseIf clave = "093" Then
            Return "Ajuste en Ayuda para renta Gravado"
        ElseIf clave = "094" Then
            Return "Ajuste en Ayuda para artículos escolares Gravado"
        ElseIf clave = "095" Then
            Return "Ajuste en Ayuda para anteojos Gravado"
        ElseIf clave = "096" Then
            Return "Ajuste en Ayuda para transporte Gravado"
        ElseIf clave = "097" Then
            Return "Ajuste en Ayuda para gastos de funeral Gravado"
        ElseIf clave = "098" Then
            Return "Ajuste a ingresos asimilados a salarios gravados"
        ElseIf clave = "099" Then
            Return "Ajuste a ingresos por sueldos y salarios gravados"
        ElseIf clave = "100" Then
            Return "Ajuste en Viáticos exentos"
        ElseIf clave = "101" Then
            Return "ISR Retenido de ejercicio anterior"
        ElseIf clave = "102" Then
            Return "Ajuste a pagos por gratificaciones, primas, compensaciones, recompensas u otros a extrabajadores derivados de jubilación en parcialidades, gravados"
        ElseIf clave = "103" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de una resolución judicial o de un laudo gravados"
        ElseIf clave = "104" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de una resolución judicial o de un laudo exentos"
        ElseIf clave = "105" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de una resolución judicial o de un laudo gravados"
        ElseIf clave = "106" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de una resolución judicial o de un laudo exentos"
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function ObtenerTipoOtroPago(ByVal clave As String) As String
        If clave = "0001" Then
            Return "Reintegro de ISR pagado en exceso (siempre que no haya sido enterado al SAT)."
        ElseIf clave = "002" Then
            Return "Subsidio para el empleo (efectivamente entregado al trabajador)."
        ElseIf clave = "003" Then
            Return "Viáticos (entregados al trabajador)."
        ElseIf clave = "004" Then
            Return "Aplicación de saldo a favor por compensación anual."
        ElseIf clave = "005" Then
            Return "Reintegro de ISR retenido en exceso de ejercicio anterior (siempre que no haya sido enterado al SAT)."
        ElseIf clave = "999" Then
            Return "Pagos distintos a los listados y que no deben considerarse como ingreso por sueldos, salarios o ingresos asimilados."
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function ObtenerEstatusUUID(ByVal clave As String) As String
        If clave = "201" Then
            Return "Cancelación aceptada"
        ElseIf clave = "202" Then
            Return "Cancelacion no aceptada"
        Else
            Return ""
        End If

    End Function
    Public Shared Function ObtenerTipoEstacion(ByVal tipoEstacion As String) As String
        If tipoEstacion = "01" Then
            Return "Origen Nacional"
        ElseIf tipoEstacion = "02" Then
            Return "Intermedia"
        ElseIf tipoEstacion = "03" Then
            Return "Destino Final Nacional"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerCveTransporte(ByVal claveTransporte As String) As String
        If claveTransporte = "01" Then
            Return "Autotransporte"
        ElseIf claveTransporte = "02" Then
            Return "Transporte Marítimo"
        ElseIf claveTransporte = "03" Then
            Return "Transporte Aéreo"
        ElseIf claveTransporte = "03" Then
            Return "Transporte Ferroviario"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerConfigVehicular(ByVal configVehicular As String) As String
        If configVehicular = "VL" Then
            Return "Vehículo ligero de carga (2 llantas en el eje delantero y 2 llantas en el eje trasero)"
        ElseIf configVehicular = "C2" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)"
        ElseIf configVehicular = "C3" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)"
        ElseIf configVehicular = "C2R2" Then
            Return "Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C3R2" Then
            Return "Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C2R3" Then
            Return "Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "C3R3" Then
            Return "Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "T2S1" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S2" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S3" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S1" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S2" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S3" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R4" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)"
        ElseIf configVehicular = "T2S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S3S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "OTROEVGP" Then
            Return "Especializado de carga Voluminosa y/o Gran Peso"
        ElseIf configVehicular = "OTROSG" Then
            Return "Servicio de Grúas"
        ElseIf configVehicular = "GPLUTA" Then
            Return "Grúa de Pluma Tipo A"
        ElseIf configVehicular = "GPLUTB" Then
            Return "Grúa de Pluma Tipo B"
        ElseIf configVehicular = "GPLUTC" Then
            Return "Grúa de Pluma Tipo C"
        ElseIf configVehicular = "GPLUTD" Then
            Return "Grúa de Pluma Tipo D"
        ElseIf configVehicular = "GPLATA" Then
            Return "Grúa de Plataforma Tipo A"
        ElseIf configVehicular = "GPLATB" Then
            Return "Grúa de Plataforma Tipo B"
        ElseIf configVehicular = "GPLATC" Then
            Return "Grúa de Plataforma Tipo C"
        ElseIf configVehicular = "GPLATD" Then
            Return "Grúa de Plataforma Tipo D"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerTipoPermiso(ByVal tipoPermiso As String) As String
        If tipoPermiso = "TPAF01" Then
            Return "Autotransporte Federal de carga general."
        ElseIf tipoPermiso = "TPAF02" Then
            Return "Transporte privado de carga."
        ElseIf tipoPermiso = "TPAF03" Then
            Return "Autotransporte Federal de Carga Especializada de materiales y residuos peligrosos."
        ElseIf tipoPermiso = "TPAF04" Then
            Return "Transporte de automóviles sin rodar en vehículo tipo góndola."
        ElseIf tipoPermiso = "TPAF05" Then
            Return "Transporte de carga de gran peso y/o volumen de hasta 90 toneladas."
        ElseIf tipoPermiso = "TPAF06" Then
            Return "Transporte de carga especializada de gran peso y/o volumen de más 90 toneladas."
        ElseIf tipoPermiso = "TPAF07" Then
            Return "Transporte Privado de materiales y residuos peligrosos."
        ElseIf tipoPermiso = "TPAF08" Then
            Return "Autotransporte internacional de carga de largo recorrido."
        ElseIf tipoPermiso = "TPAF09" Then
            Return "Autotransporte internacional de carga especializada de materiales y residuos peligrosos de largo recorrido."
        ElseIf tipoPermiso = "TPAF10" Then
            Return "Autotransporte Federal de Carga General cuyo ámbito de aplicación comprende la franja fronteriza con Estados Unidos."
        ElseIf tipoPermiso = "TPAF11" Then
            Return "Autotransporte Federal de Carga Especializada cuyo ámbito de aplicación comprende la franja fronteriza con Estados Unidos."
        ElseIf tipoPermiso = "TPAF12" Then
            Return "Servicio auxiliar de arrastre en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF13" Then
            Return "Servicio auxiliar de servicios de arrastre, arrastre y salvamento, y depósito de vehículos en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF14" Then
            Return "Servicio de paquetería y mensajería en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF15" Then
            Return "Transporte especial para el tránsito de grúas industriales con peso máximo de 90 toneladas."
        ElseIf tipoPermiso = "TPAF16" Then
            Return "Servicio federal para empresas arrendadoras servicio público federal."
        ElseIf tipoPermiso = "TPAF17" Then
            Return "Empresas trasladistas de vehículos nuevos."
        ElseIf tipoPermiso = "TPAF18" Then
            Return "Empresas fabricantes o distribuidoras de vehículos nuevos."
        ElseIf tipoPermiso = "TPAF19" Then
            Return "Autorización expresa para circular en los caminos y puentes de jurisdicción federal con configuraciones de tractocamión doblemente articulado."
        ElseIf tipoPermiso = "TPAF20" Then
            Return "Autotransporte Federal de Carga Especializada de fondos y valores."
        ElseIf tipoPermiso = "TPTM01" Then
            Return "Permiso temporal para navegación de cabotaje"
        ElseIf tipoPermiso = "TPTA01" Then
            Return "Concesión y/o autorización para el servicio regular nacional y/o internacional para empresas mexicanas"
        ElseIf tipoPermiso = "TPTA02" Then
            Return "Permiso para el servicio aéreo regular de empresas extranjeras"
        ElseIf tipoPermiso = "TPTA03" Then
            Return "Permiso para el servicio nacional e internacional no regular de fletamento"
        ElseIf tipoPermiso = "TPTA04" Then
            Return "Permiso para el servicio nacional e internacional no regular de taxi aéreo"
        ElseIf tipoPermiso = "TPXX00" Then
            Return "Permiso no contemplado en el catálogo."
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerConfigAutotransporte(ByVal configVehicular As String) As String
        If configVehicular = "VL" Then
            Return "Vehículo ligero de carga (2 llantas en el eje delantero y 2 llantas en el eje trasero)"
        ElseIf configVehicular = "C2" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)"
        ElseIf configVehicular = "C3" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)"
        ElseIf configVehicular = "C2R2" Then
            Return "Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C3R2" Then
            Return "Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C2R3" Then
            Return "Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "C3R3" Then
            Return "Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "T2S1" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S2" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S3" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S1" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S2" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S3" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R4" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)"
        ElseIf configVehicular = "T2S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S3S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "OTROEVGP" Then
            Return "Especializado de carga Voluminosa y/o Gran Peso"
        ElseIf configVehicular = "OTROSG" Then
            Return "Servicio de Grúas"
        ElseIf configVehicular = "GPLUTA" Then
            Return "Grúa de Pluma Tipo A"
        ElseIf configVehicular = "GPLUTB" Then
            Return "Grúa de Pluma Tipo B"
        ElseIf configVehicular = "GPLUTC" Then
            Return "Grúa de Pluma Tipo C"
        ElseIf configVehicular = "GPLUTD" Then
            Return "Grúa de Pluma Tipo D"
        ElseIf configVehicular = "GPLATA" Then
            Return "Grúa de Plataforma Tipo A"
        ElseIf configVehicular = "GPLATB" Then
            Return "Grúa de Plataforma Tipo B"
        ElseIf configVehicular = "GPLATC" Then
            Return "Grúa de Plataforma Tipo C"
        ElseIf configVehicular = "GPLATD" Then
            Return "Grúa de Plataforma Tipo D"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerConfigMaritima(ByVal configMaritima As String) As String
        If configMaritima = "B01" Then
            Return "Abastecedor"
        ElseIf configMaritima = "B02" Then
            Return "Barcaza"
        ElseIf configMaritima = "B03" Then
            Return "Granelero"
        ElseIf configMaritima = "B04" Then
            Return "Porta Contenedor"
        ElseIf configMaritima = "B05" Then
            Return "Draga"
        ElseIf configMaritima = "B06" Then
            Return "Pesquero"
        ElseIf configMaritima = "B07" Then
            Return "Carga General"
        ElseIf configMaritima = "B08" Then
            Return "Quimiqueros"
        ElseIf configMaritima = "B09" Then
            Return "Transbordadores"
        ElseIf configMaritima = "B10" Then
            Return "Carga RoRo"
        ElseIf configMaritima = "B11" Then
            Return "Investigación"
        ElseIf configMaritima = "B12" Then
            Return "Tanquero"
        ElseIf configMaritima = "B13" Then
            Return "Gasero"
        ElseIf configMaritima = "B14" Then
            Return "Remolcador"
        ElseIf configMaritima = "B15" Then
            Return "Extraordinaria especialización"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerTipoCarga(ByVal tipoCarga As String) As String
        If tipoCarga = "CGS" Then
            Return "Carga General Suelta"
        ElseIf tipoCarga = "CGC" Then
            Return "Carga General Contenerizada"
        ElseIf tipoCarga = "GMN" Then
            Return "Gran Mineral"
        ElseIf tipoCarga = "GAG" Then
            Return "Granel Agrícola"
        ElseIf tipoCarga = "OFL" Then
            Return "Otros Fluidos"
        ElseIf tipoCarga = "PYD" Then
            Return "Petróleo y Derivados"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerParteTransporte(ByVal parteTransporte As String) As String
        If parteTransporte = "PT01" Then
            Return "Camión unitario"
        ElseIf parteTransporte = "PT02" Then
            Return "Camión"
        ElseIf parteTransporte = "PT03" Then
            Return "Tractocamión"
        ElseIf parteTransporte = "PT04" Then
            Return "Remolque"
        ElseIf parteTransporte = "PT05" Then
            Return "Semirremolque"
        ElseIf parteTransporte = "PT06" Then
            Return "Vehículo ligero de carga"
        ElseIf parteTransporte = "PT07" Then
            Return "Grúa"
        ElseIf parteTransporte = "PT08" Then
            Return "Aeronave"
        ElseIf parteTransporte = "PT09" Then
            Return "Barco o buque"
        ElseIf parteTransporte = "PT10" Then
            Return "Carro o vagón"
        ElseIf parteTransporte = "PT11" Then
            Return "Contenedor"
        ElseIf parteTransporte = "PT12" Then
            Return "Locomotora"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerFiguraTransporte(ByVal tipoCarga As String) As String
        If tipoCarga = "01" Then
            Return "Operador"
        ElseIf tipoCarga = "02" Then
            Return "Propietario"
        ElseIf tipoCarga = "03" Then
            Return "Arrendador"
        ElseIf tipoCarga = "04" Then
            Return "Notificado"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerObjetoImpuesto(ByVal objectoImpuesto As String) As String
        If objectoImpuesto = "01" Then
            Return "No objeto de impuesto"
        ElseIf objectoImpuesto = "02" Then
            Return "Sí objeto de impuesto"
        ElseIf objectoImpuesto = "03" Then
            Return "Sí objeto de impuesto y no obligado al desglose"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerObjetoImpuestoSimple(ByVal objectoImpuesto As String) As String
        If objectoImpuesto = "01" Then
            Return "NOI"
        ElseIf objectoImpuesto = "02" Then
            Return "SOI"
        ElseIf objectoImpuesto = "03" Then
            Return "SOINOD"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerExportacion(ByVal objectoImpuesto As String) As String
        If objectoImpuesto = "01" Then
            Return "No aplica"
        ElseIf objectoImpuesto = "02" Then
            Return "Definitiva"
        ElseIf objectoImpuesto = "03" Then
            Return "Temporal"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerPeriodo(ByVal periodo As String) As String
        If periodo = "01" Then
            Return "Enero"
        ElseIf periodo = "02" Then
            Return "Febrero"
        ElseIf periodo = "03" Then
            Return "Marzo"
        ElseIf periodo = "04" Then
            Return "Abril"
        ElseIf periodo = "05" Then
            Return "Mayo"
        ElseIf periodo = "05" Then
            Return "Junio"
        ElseIf periodo = "06" Then
            Return "Julio"
        ElseIf periodo = "08" Then
            Return "Agosto"
        ElseIf periodo = "09" Then
            Return "Septiembre"
        ElseIf periodo = "10" Then
            Return "Octubre"
        ElseIf periodo = "11" Then
            Return "Noviembre"
        ElseIf periodo = "12" Then
            Return "Diciembre"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerCveRetenc(ByVal cveRetenc As String) As String
        If cveRetenc = "01" Then
            Return "Servicios profesionales."
        ElseIf cveRetenc = "02" Then
            Return "Regalías por derechos de autor."
        ElseIf cveRetenc = "03" Then
            Return "Autotransporte terrestre de carga."
        ElseIf cveRetenc = "04" Then
            Return "Servicios prestados por comisionistas."
        ElseIf cveRetenc = "05" Then
            Return "Arrendamiento."
        ElseIf cveRetenc = "06" Then
            Return "Enajenación de acciones."
        ElseIf cveRetenc = "07" Then
            Return "Enajenación de bienes objeto de la LIEPS, a través de mediadores, agentes, representantes, corredores, consignatarios o distribuidores."
        ElseIf cveRetenc = "08" Then
            Return "Enajenación de bienes inmuebles consignada en escritura pública."
        ElseIf cveRetenc = "09" Then
            Return "Enajenación de otros bienes, no consignada en escritura pública."
        ElseIf cveRetenc = "10" Then
            Return "Adquisición de desperdicios industriales."
        ElseIf cveRetenc = "11" Then
            Return "Adquisición de bienes consignada en escritura pública."
        ElseIf cveRetenc = "12" Then
            Return "Adquisición de otros bienes, no consignada en escritura pública."
        ElseIf cveRetenc = "13" Then
            Return "Otros retiros de AFORE."
        ElseIf cveRetenc = "14" Then
            Return "Dividendos o utilidades distribuidas."
        ElseIf cveRetenc = "15" Then
            Return "Remanente distribuible."
        ElseIf cveRetenc = "16" Then
            Return "Intereses."
        ElseIf cveRetenc = "17" Then
            Return "Arrendamiento en fideicomiso."
        ElseIf cveRetenc = "18" Then
            Return "Pagos realizados a favor de residentes en el extranjero."
        ElseIf cveRetenc = "19" Then
            Return "Enajenación de acciones u operaciones en bolsa de valores."
        ElseIf cveRetenc = "20" Then
            Return "Obtención de premios."
        ElseIf cveRetenc = "21" Then
            Return "Fideicomisos que no realizan actividades empresariales."
        ElseIf cveRetenc = "22" Then
            Return "Planes personales de retiro."
        ElseIf cveRetenc = "23" Then
            Return "Intereses reales deducibles por créditos hipotecarios."
        ElseIf cveRetenc = "24" Then
            Return "Operaciones Financieras Derivadas de Capital."
        ElseIf cveRetenc = "25" Then
            Return "Otro tipo de retenciones."
        ElseIf cveRetenc = "26" Then
            Return "Servicios mediante Plataformas Tecnológicas "
        ElseIf cveRetenc = "27" Then
            Return "Sector Financiero"
        ElseIf cveRetenc = "28" Then
            Return "Pagos y retenciones a Contribuyentes del RIF"
        Else
            Return ""
        End If
    End Function
    Public Shared Function ObtenerTipoPagoRet(ByVal tipoPagoRet As String) As String
        If tipoPagoRet = "01" Then
            Return "Pago definitivo IVA"
        ElseIf tipoPagoRet = "02" Then
            Return "Pago definitivo IEPS"""
        ElseIf tipoPagoRet = "03" Then
            Return "Pago definitivo ISR """
        ElseIf tipoPagoRet = "03" Then
            Return "Pago provisional ISR"
        Else
            Return ""
        End If
    End Function

#End Region
End Class


Public Class GenerarPDF
    Private Shared FUENTE_TITULO As Font = New Font(BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1250, True), 6.5)
    Private Shared FUENTE_NORMAL As Font = New Font(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, True), 5.5)
    Private Shared FUENTE_SUBTITULO As Font = New Font(Font.FontFamily.HELVETICA, 5.5, Font.BOLD)
    Private Shared FUENTE_SUBTITULO_BLANCO As Font = New Font(FontFactory.GetFont("ArialMT", 5.5, Font.BOLD, BaseColor.WHITE))
    Private Shared FUENTE_NORMAL_BOLD As Font = New Font(BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1250, True), 5.5)
    Private Shared FUENTE_MEDIANA As Font = New Font(Font.FontFamily.HELVETICA, 6)
    Private Shared FUENTE_CHICA As Font = New Font(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, True), 4.5)

    Private Shared ANCHO_TICKET = 0
    Private Shared ANCHO_COLUMNA_1 = 0
    Private Shared ANCHO_COLUMNA_2 = 0
    Private Shared ANCHO_COLUMNA_PRODUCTOS_1 = 0
    Private Shared ANCHO_COLUMNA_PRODUCTOS_2 = 0
    Private Shared ANCHO_COLUMNA_PRODUCTOS_3 = 0
    Private Shared ANCHO_COLUMNA_PRODUCTOS_4 = 0

    Enum TICKET
        A82MM
        A80MM
        A78MM
        A76MM
        A57MM
        A50MM
        A40MM
    End Enum
    Public Shared Sub CalcularAnchoTicket(ByVal TAMAÑO As TICKET)
        If TAMAÑO = TICKET.A82MM Then
            FUENTE_TITULO.Size = 7
            FUENTE_NORMAL.Size = 6
            FUENTE_NORMAL_BOLD.Size = 6
            FUENTE_CHICA.Size = 5
            ANCHO_TICKET = 8.2
            ANCHO_COLUMNA_1 = 4.0
            ANCHO_COLUMNA_2 = 4.2
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.8
            ANCHO_COLUMNA_PRODUCTOS_2 = 2.8
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.8
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.8
        ElseIf TAMAÑO = TICKET.A80MM Then
            FUENTE_TITULO.Size = 7
            FUENTE_NORMAL.Size = 6
            FUENTE_NORMAL_BOLD.Size = 6
            FUENTE_CHICA.Size = 5
            ANCHO_TICKET = 8.0
            ANCHO_COLUMNA_1 = 3.8
            ANCHO_COLUMNA_2 = 4.2
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.7
            ANCHO_COLUMNA_PRODUCTOS_2 = 2.8
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.6
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.6
        ElseIf TAMAÑO = TICKET.A78MM Then
            FUENTE_TITULO.Size = 7
            FUENTE_NORMAL.Size = 6
            FUENTE_NORMAL_BOLD.Size = 6
            FUENTE_CHICA.Size = 5
            ANCHO_TICKET = 7.8
            ANCHO_COLUMNA_1 = 3.7
            ANCHO_COLUMNA_2 = 4.1
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.7
            ANCHO_COLUMNA_PRODUCTOS_2 = 2.7
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.6
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.6
        ElseIf TAMAÑO = TICKET.A76MM Then
            FUENTE_TITULO.Size = 7
            FUENTE_NORMAL.Size = 6
            FUENTE_NORMAL_BOLD.Size = 6
            FUENTE_CHICA.Size = 5
            ANCHO_TICKET = 7.6
            ANCHO_COLUMNA_1 = 3.6
            ANCHO_COLUMNA_2 = 4.0
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.6
            ANCHO_COLUMNA_PRODUCTOS_2 = 1.8
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.6
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.6
        ElseIf TAMAÑO = TICKET.A57MM Then
            FUENTE_TITULO.Size = 6.5
            FUENTE_NORMAL.Size = 5.5
            FUENTE_NORMAL_BOLD.Size = 5.5
            FUENTE_CHICA.Size = 4.5
            ANCHO_TICKET = 5.7
            ANCHO_COLUMNA_1 = 2.5
            ANCHO_COLUMNA_2 = 3.3
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.3
            ANCHO_COLUMNA_PRODUCTOS_2 = 1.8
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.3
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.3
        ElseIf TAMAÑO = TICKET.A50MM Then
            FUENTE_TITULO.Size = 6
            FUENTE_NORMAL.Size = 5
            FUENTE_NORMAL_BOLD.Size = 5
            FUENTE_CHICA.Size = 4
            ANCHO_TICKET = 5.0
            ANCHO_COLUMNA_1 = 2
            ANCHO_COLUMNA_2 = 3
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.1
            ANCHO_COLUMNA_PRODUCTOS_2 = 1.5
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.2
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.2
        ElseIf TAMAÑO = TICKET.A40MM Then
            FUENTE_TITULO.Size = 5.5
            FUENTE_NORMAL.Size = 4.5
            FUENTE_NORMAL_BOLD.Size = 4.5
            FUENTE_CHICA.Size = 4
            ANCHO_TICKET = 4.0
            ANCHO_COLUMNA_1 = 1.5
            ANCHO_COLUMNA_2 = 2.5
            ANCHO_COLUMNA_PRODUCTOS_1 = 0.9
            ANCHO_COLUMNA_PRODUCTOS_2 = 1.3
            ANCHO_COLUMNA_PRODUCTOS_3 = 0.9
            ANCHO_COLUMNA_PRODUCTOS_4 = 0.9
        Else
            ANCHO_TICKET = 8.0
            ANCHO_COLUMNA_1 = 3.8
            ANCHO_COLUMNA_2 = 4.2
            ANCHO_COLUMNA_PRODUCTOS_1 = 1.7
            ANCHO_COLUMNA_PRODUCTOS_2 = 2.8
            ANCHO_COLUMNA_PRODUCTOS_3 = 1.6
            ANCHO_COLUMNA_PRODUCTOS_4 = 1.6
        End If
    End Sub
    Public Shared Sub Generar(ByVal rutaXML As String, ByVal rutaPDF As String, ByVal rutaLogo As String, ByVal abrir As Boolean)
        Dim version As String = ObtenerVersion(rutaXML)
        If (version = "3.3" Or version = "4.0") Then
            CrearPDF(rutaXML, rutaPDF, rutaLogo, abrir)
        Else
            MessageBox.Show("El comprobante no es una versión valida")
        End If
    End Sub
    Public Shared Function ObtenerVersion(ByVal rutaXML As String)
        Dim documento As XmlDocument = New XmlDocument()
        Dim comprobante As Comprobante = New Comprobante()
        documento.Load(rutaXML)
        documento.PreserveWhitespace = True
        Dim nlComprobante As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
        If (nlComprobante.Count > 0) Then
            Dim nComprobante As XmlElement = TryCast(nlComprobante.Item(0), XmlElement)
            If (nComprobante.HasAttribute("Version")) Then
                Return nComprobante.GetAttribute("Version")
            End If
        ElseIf documento.GetElementsByTagName("retenciones:Retenciones").Count > 0 Then
            Return "Retenciones"
        End If

        Return "-1"
    End Function

    'Public Shared Sub Generar(ByVal comprobante As Comprobante, ByVal rutaPDF As String, ByVal rutaLogo As String, ByVal abrir As Boolean)
    '    Dim documento As Document = New Document(PageSize.LETTER)
    '    Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(rutaPDF, FileMode.Create))
    '    writer.PageEvent = New EventDichiarazionePdf()
    '    documento.Open()
    '    AgregaPropiedadesDocumento(documento)
    '    SeleccionarFormato(comprobante, documento, rutaLogo)
    '    documento.Close()
    '    If abrir Then System.Diagnostics.Process.Start(rutaPDF)
    'End Sub


    Private Shared Sub CrearPDF(ByVal rutaXML As String, ByVal rutaPDF As String, ByVal rutaLogo As String, ByVal abrir As Boolean)
        CalcularAnchoTicket(TICKET.A40MM)
        Dim Comprobante As Comprobante = LeerXML.ObtenerComprobante(rutaXML)
        'Dim pageSize As Rectangle = New Rectangle(cmAFloat(5.8), cmAFloat(90))
        Dim documento As Document = New Document(PageSize.LETTER, cmAFloat(0.5F), 0, 0, 0)
        Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(rutaPDF, FileMode.Create))
        documento.Open()
        AgregaPropiedadesDocumento(documento)
        SeleccionarFormato(Comprobante, documento, rutaLogo)
        documento.Close()
        If abrir Then System.Diagnostics.Process.Start(rutaPDF)
    End Sub
    Private Shared Sub SeleccionarFormato(ByVal comprobante As Comprobante, ByVal documento As Document, ByVal rutaLogo As String)
        If comprobante.TipoDeComprobante = "N" Then
            FormatoNomina2(documento, comprobante, rutaLogo)
        ElseIf comprobante.TipoDeComprobante = "P" Then
            If comprobante.Complemento IsNot Nothing AndAlso comprobante.Complemento.Pagos20 IsNot Nothing Then FormatoPagos20(documento, comprobante, rutaLogo)
        ElseIf comprobante.Complemento IsNot Nothing AndAlso comprobante.Complemento.CartaPorte30 IsNot Nothing Then
            FormatoCartaPorte30(documento, comprobante, rutaLogo)
        Else
            FormatoNormal(documento, comprobante, rutaLogo)
        End If
    End Sub
    Private Shared Sub FormatoNormal(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        If Not comprobante.CfdiRelacionados Is Nothing Then documento.Add(AgregarCfdisRelacionados(comprobante.CfdiRelacionados))
        If Not comprobante.InformacionGlobal Is Nothing Then documento.Add(AgregarInformacionGlobal(comprobante.InformacionGlobal))
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarDetalleTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub
    Private Shared Sub FormatoPagos20(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        If Not comprobante.CfdiRelacionados Is Nothing Then documento.Add(AgregarCfdisRelacionados(comprobante.CfdiRelacionados))
        AgregarTablaPagos20(documento, comprobante)
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarDetalleTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub
    Private Shared Sub FormatoNomina2(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        N2AgregarEmisor(documento, comprobante)
        documento.Add(N2AgregarEmpleado(comprobante))
        documento.Add(N2AgregarPago(comprobante))
        N2AgregarPercepciones(documento, comprobante.Complemento.Nomina.Percepciones)
        N2AgregarDeducciones(documento, comprobante.Complemento.Nomina.Deducciones)
        N2AgregarOtroPagos(documento, comprobante.Complemento.Nomina.OtrosPagos)
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub
    Private Shared Sub FormatoCartaPorte30(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        documento.Add(AgregarConceptosCartaPorte30(comprobante))
        AgregarDatosCartaPorte30(documento, comprobante)
        AgregarUbicaciones30(documento, comprobante)
        AgregarMercancias30(documento, comprobante)
        If comprobante.Complemento.CartaPorte30.FiguraTransporte IsNot Nothing Then AgregarFiguraTransporte30(documento, comprobante)
        documento.Add(AgregarSellos(comprobante))
    End Sub
    Private Shared Sub AgregaPropiedadesDocumento(ByRef documento As Document)
        documento.AddAuthor("Advansys S.A de C.V")
        documento.AddCreator("Sample application using iTextSharp")
        documento.AddKeywords("Reporte de Hunter")
        documento.AddSubject("Document subject - Describing the steps creating a PDF document")
        documento.AddTitle("Reporte del sistema Hunter")
        documento.SetMargins(cmAFloat(0.5F), cmAFloat(0.5F), cmAFloat(0.5F), cmAFloat(0.5F))
    End Sub
    Private Shared Function AgregarInformacionGlobal(ByVal informacionGlobal As InformacionGlobal) As IElement
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {2.5F, 2.5F, 2.5F, 5.0F, 2.5F, 5.0F})
        Dim tablaInformacionGlobal As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaInformacionGlobal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaInformacionGlobal.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaInformacionGlobal.DefaultCell.Border = Rectangle.NO_BORDER
        tablaInformacionGlobal.SpacingBefore = 10
        tablaInformacionGlobal.DefaultCell.BackgroundColor = BaseColor.BLACK
        tablaInformacionGlobal.LockedWidth = True
        tablaInformacionGlobal.SetTotalWidth(tamanoColumnas)
        Dim relacion As StringBuilder = New StringBuilder()
        relacion.Append("INFORMACIÓN GLOBAL")
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase(relacion.ToString(), FUENTE_NORMAL_BOLD)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.UseAscender = True
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        ctitulo.BorderWidth = 1.0F
        ctitulo.Colspan = 6
        tablaInformacionGlobal.AddCell(ctitulo)

        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase("Año", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER
        })
        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase(informacionGlobal.Ano, FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER
        })
        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase("Meses", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER
        })
        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase(informacionGlobal.Meses & " - " & Catalogos.ObtenerMeses(informacionGlobal.Meses), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
        .Border = Rectangle.NO_BORDER
        })
        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase("Periodicidad", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER
        })
        tablaInformacionGlobal.AddCell(New PdfPCell(New Phrase(informacionGlobal.Periodicidad & " - " & Catalogos.ObtenerPeriodicidad(informacionGlobal.Periodicidad), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER
        })


        Return tablaInformacionGlobal
    End Function
    Private Shared Function AgregarCfdisRelacionados(ByVal cfdisRelacionados As CfdiRelacionados) As IElement
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {20.0F})
        Dim tablaCFDISRelacionados As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaCFDISRelacionados.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaCFDISRelacionados.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaCFDISRelacionados.DefaultCell.Border = Rectangle.NO_BORDER
        tablaCFDISRelacionados.SpacingBefore = 10
        tablaCFDISRelacionados.DefaultCell.BackgroundColor = BaseColor.BLACK
        tablaCFDISRelacionados.LockedWidth = True
        tablaCFDISRelacionados.SetTotalWidth(tamanoColumnas)
        Dim relacion As StringBuilder = New StringBuilder()
        relacion.Append("CFDI'S RELACIONADOS (")
        relacion.Append(cfdisRelacionados.TipoRelacion & "- ")
        relacion.Append(Catalogos.ObtenerTipoRelacion(cfdisRelacionados.TipoRelacion) & ")")
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase(relacion.ToString(), FUENTE_NORMAL_BOLD)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.UseAscender = True
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        ctitulo.BorderWidth = 1.0F
        ctitulo.Colspan = 6
        tablaCFDISRelacionados.AddCell(ctitulo)

        For Each cfdiRelacionado As CfdiRelacionado In cfdisRelacionados.CfdiRelacionado
            tablaCFDISRelacionados.AddCell(New PdfPCell(New Phrase(cfdiRelacionado.UUID, FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })
        Next
        Return tablaCFDISRelacionados
    End Function
#Region "Formato complemento Pagos 20"
    Private Shared Sub AgregarTablaPagos20(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.Pagos20 Is Nothing OrElse comprobante.Complemento.Pagos20.Pago.Count <= 0 Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1 + 1, ANCHO_COLUMNA_2 - 1})
        Dim tPagos As PdfPTable = New PdfPTable(anchoColumnas)
        tPagos.SetTotalWidth(anchoColumnas)
        tPagos.SpacingBefore = 5
        tPagos.DefaultCell.Border = Rectangle.NO_BORDER
        tPagos.DefaultCell.PaddingBottom = 1
        tPagos.DefaultCell.PaddingTop = 1
        tPagos.HorizontalAlignment = HorizontalAlignment.Left
        tPagos.LockedWidth = True


        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("PAGOS", FUENTE_NORMAL_BOLD))
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.Colspan = 2
        ctitulo.Padding = 0
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        tPagos.AddCell(ctitulo)

        Dim totales As P20Totales = comprobante.Complemento.Pagos20.Totales
        If totales.TotalRetencionesIEPS > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IEPS:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalRetencionesIEPS.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalRetencionesISR > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones ISR:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalRetencionesISR.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalRetencionesIVA > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IVA:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalRetencionesIVA.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalTrasladosBaseIVA0 > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IVA 0:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosBaseIVA0.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalTrasladosBaseIVA8 > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IVA 8:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosBaseIVA8.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalTrasladosBaseIVA16 > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IVA 16:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosBaseIVA16.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalTrasladosImpuestoIVA0 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuestos IVA 0:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosImpuestoIVA0.ToString("C2"), FUENTE_NORMAL)))
        End If

        If totales.TotalTrasladosImpuestoIVA16 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuestos IVA 16:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosImpuestoIVA16.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.TotalTrasladosImpuestoIVA8 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuestos IVA 8:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.TotalTrasladosImpuestoIVA8.ToString("C2"), FUENTE_NORMAL)))
        End If
        If totales.MontoTotalPagos > 0 Then
            tPagos.AddCell(New Phrase("Total monto pagos:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(totales.MontoTotalPagos.ToString("C2"), FUENTE_NORMAL)))
        End If
        tPagos.CompleteRow()
        documento.Add(tPagos)

        Dim contador As Integer = 1
        For Each pago As P20Pago In comprobante.Complemento.Pagos20.Pago
            P20AgregarPago(pago, contador, documento)
            P20AgregarDocumentoRelacionado(pago.DoctoRelacionado, documento)
            P20AgregarImpuestos(pago.Impuestos, documento)
        Next
    End Sub
    Private Shared Function P20AgregarPago(ByVal pago As P20Pago, ByVal contador As Integer, ByVal documento As Document)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tPagos As PdfPTable = New PdfPTable(anchoColumnas)
        tPagos.SetTotalWidth(anchoColumnas)
        tPagos.SpacingBefore = 5
        tPagos.DefaultCell.PaddingBottom = 0
        tPagos.DefaultCell.PaddingTop = 0
        tPagos.HorizontalAlignment = HorizontalAlignment.Left
        tPagos.DefaultCell.Border = Rectangle.NO_BORDER
        tPagos.LockedWidth = True

        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("PAGO " & contador.ToString(), FUENTE_NORMAL_BOLD))
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.Colspan = 2
        ctitulo.UseAscender = True
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        tPagos.AddCell(ctitulo)
        tPagos.AddCell(New Phrase("Fecha de pago:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell((New Phrase(pago.FechaPago.ToShortDateString(), FUENTE_NORMAL)))
        tPagos.AddCell(New Phrase("Forma de pago:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.FormaDePagoP + " - " + Catalogos.ObtenerFormaPago(pago.FormaDePagoP), FUENTE_NORMAL))
        tPagos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.MonedaP, FUENTE_NORMAL))

        If pago.TipoCambioP <> 0 Then
            tPagos.AddCell(New Phrase("Tipo de cambio:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.TipoCambioP.ToString("C2"), FUENTE_NORMAL))
        End If
        tPagos.AddCell(New Phrase("Monto:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.Monto.ToString("C2"), FUENTE_NORMAL))

        If pago.NumOperacion <> String.Empty Then tPagos.AddCell(New Phrase("Núm. de operación:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.NumOperacion, FUENTE_NORMAL))
        If pago.RfcEmisorCtaOrd <> String.Empty Then tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
        If pago.NomBancoOrdExt <> String.Empty Then tPagos.AddCell(New Phrase("NomBancoOrdExt:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.NomBancoOrdExt, FUENTE_NORMAL))
        If pago.CtaOrdenante <> String.Empty Then tPagos.AddCell(New Phrase("CtaOrdenante:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.CtaOrdenante, FUENTE_NORMAL))
        If pago.RfcEmisorCtaOrd <> String.Empty Then tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
        If pago.RfcEmisorCtaBen <> String.Empty Then tPagos.AddCell(New Phrase("RfcEmisorCtaBen:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.RfcEmisorCtaBen, FUENTE_NORMAL))
        If pago.CtaBeneficiario <> String.Empty Then tPagos.AddCell(New Phrase("CtaBeneficiario:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.CtaBeneficiario, FUENTE_NORMAL))
        If pago.TipoCadPago <> String.Empty Then tPagos.AddCell(New Phrase("TipoCadPago:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.TipoCadPago, FUENTE_NORMAL))
        If pago.CertPago <> String.Empty Then tPagos.AddCell(New Phrase("CertPago:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.CertPago, FUENTE_NORMAL))
        If pago.CadPago <> String.Empty Then tPagos.AddCell(New Phrase("CadPago:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.CadPago, FUENTE_NORMAL))
        If pago.SelloPago <> String.Empty Then tPagos.AddCell(New Phrase("SelloPago:", FUENTE_NORMAL_BOLD)) : tPagos.AddCell(New Phrase(pago.SelloPago, FUENTE_NORMAL))
        tPagos.CompleteRow()
        documento.Add(tPagos)
    End Function
    Private Shared Function P20AgregarDocumentoRelacionado(ByVal documentosRelacionados As List(Of P20DoctoRelacionado), ByVal documento As Document)
        If documentosRelacionados.Count > 0 Then
            Dim contador As Integer = 1
            For Each dr As P20DoctoRelacionado In documentosRelacionados
                Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
                Dim tDocumentos As PdfPTable = New PdfPTable(anchoColumnas)
                tDocumentos.SetTotalWidth(anchoColumnas)
                tDocumentos.SpacingBefore = 5
                tDocumentos.HorizontalAlignment = HorizontalAlignment.Left
                tDocumentos.DefaultCell.Border = Rectangle.NO_BORDER
                tDocumentos.DefaultCell.PaddingBottom = 0
                tDocumentos.DefaultCell.PaddingTop = 0
                tDocumentos.LockedWidth = True

                Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("DOCUMENTO RELACIONADO " & contador.ToString(), FUENTE_NORMAL_BOLD))
                ctitulo.Border = Rectangle.NO_BORDER
                ctitulo.Colspan = 2
                ctitulo.UseAscender = True
                ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
                ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
                tDocumentos.AddCell(ctitulo)
                tDocumentos.AddCell(New Phrase("Id documento:", FUENTE_NORMAL_BOLD))
                tDocumentos.AddCell(New Phrase(dr.IdDocumento, FUENTE_NORMAL))
                If Not String.IsNullOrEmpty(dr.Serie) Then
                    tDocumentos.AddCell(New Phrase("Serie:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.Serie, FUENTE_NORMAL))
                End If
                If Not String.IsNullOrEmpty(dr.Folio) Then
                    tDocumentos.AddCell(New Phrase("Folio:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.Folio, FUENTE_NORMAL))
                End If
                If Not String.IsNullOrEmpty(dr.MonedaDR) Then
                    tDocumentos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.Serie, FUENTE_NORMAL))
                End If
                If Not dr.EquivalenciaDR > 0 Then
                    tDocumentos.AddCell(New Phrase("Equivalencia:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.EquivalenciaDR.ToString("C2"), FUENTE_NORMAL))
                End If
                If Not String.IsNullOrEmpty(dr.NumParcialidad) Then
                    tDocumentos.AddCell(New Phrase("Núm. de parcialidad:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.NumParcialidad, FUENTE_NORMAL))
                End If
                If Not dr.ImpSaldoAnt > 0 Then
                    tDocumentos.AddCell(New Phrase("Saldo anterior:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoAnt.ToString("C2"), FUENTE_NORMAL))
                End If
                If Not dr.ImpPagado > 0 Then
                    tDocumentos.AddCell(New Phrase("Importe pagado:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpPagado.ToString("C2"), FUENTE_NORMAL))
                End If
                If Not dr.ImpSaldoInsoluto > 0 Then
                    tDocumentos.AddCell(New Phrase("Saldo insoluto:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoInsoluto.ToString("C2"), FUENTE_NORMAL))
                End If
                If Not String.IsNullOrEmpty(dr.ObjetoImpDR) Then
                    tDocumentos.AddCell(New Phrase("Objeto de impuesto:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ObjetoImpDR + " - " + Catalogos.ObtenerObjetoImpuesto(dr.ObjetoImpDR), FUENTE_NORMAL))
                End If
                tDocumentos.CompleteRow()
                documento.Add(tDocumentos)
                contador += 1
            Next
        End If
    End Function
    Private Shared Function P20AgregarImpuestos(ByVal impuestos As P20Impuestos, ByVal documento As Document)
        If impuestos IsNot Nothing Then
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tImpuestos As PdfPTable = New PdfPTable(anchoColumnas)
            tImpuestos.SetTotalWidth(anchoColumnas)
            tImpuestos.SpacingBefore = 5
            tImpuestos.HorizontalAlignment = HorizontalAlignment.Left
            tImpuestos.DefaultCell.Border = Rectangle.NO_BORDER
            tImpuestos.DefaultCell.PaddingBottom = 0
            tImpuestos.DefaultCell.PaddingTop = 0
            tImpuestos.LockedWidth = True

            Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("Impuestos ", FUENTE_NORMAL_BOLD))
            ctitulo.Border = Rectangle.NO_BORDER
            ctitulo.Colspan = 4
            ctitulo.UseAscender = True
            ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
            ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
            tImpuestos.AddCell(ctitulo)

            If impuestos.RetencionesP IsNot Nothing Then
                Dim contador As Integer = 1
                For Each retencion As P20Retencion In impuestos.RetencionesP.RetencionP
                    Dim cTituloRetencion As PdfPCell = New PdfPCell(New Phrase("Retención " + contador, FUENTE_NORMAL_BOLD))
                    cTituloRetencion.Border = Rectangle.NO_BORDER
                    cTituloRetencion.Colspan = 4
                    cTituloRetencion.PaddingBottom = 0
                    cTituloRetencion.UseAscender = True
                    cTituloRetencion.HorizontalAlignment = Element.ALIGN_CENTER
                    cTituloRetencion.VerticalAlignment = Element.ALIGN_MIDDLE
                    tImpuestos.AddCell(cTituloRetencion)

                    tImpuestos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(retencion.ImpuestoP, FUENTE_NORMAL)))
                    tImpuestos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(retencion.ImporteP.ToString("C2"), FUENTE_NORMAL)))
                    contador += 1
                Next
                tImpuestos.CompleteRow()
            End If

            If impuestos.TrasladosP IsNot Nothing Then
                Dim contador As Integer = 1
                For Each traslado As P20Traslado In impuestos.TrasladosP.TrasladoP
                    Dim cTituloTraslado As PdfPCell = New PdfPCell(New Phrase("Traslado " + contador, FUENTE_NORMAL_BOLD)) With {
                      .BackgroundColor = BaseColor.BLACK
                    }
                    cTituloTraslado.Border = Rectangle.NO_BORDER
                    cTituloTraslado.Colspan = 4
                    cTituloTraslado.UseAscender = True
                    cTituloTraslado.HorizontalAlignment = Element.ALIGN_CENTER
                    cTituloTraslado.VerticalAlignment = Element.ALIGN_MIDDLE
                    tImpuestos.AddCell(cTituloTraslado)

                    tImpuestos.AddCell(New Phrase("Base:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(traslado.BaseP.ToString("C2"), FUENTE_NORMAL)))
                    tImpuestos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(traslado.ImpuestoP, FUENTE_NORMAL)))
                    tImpuestos.AddCell(New Phrase("Tipo de factor:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(traslado.TipoFactorP, FUENTE_NORMAL)))
                    tImpuestos.AddCell(New Phrase("Tasa o couta:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(traslado.TasaOCuotaP.ToString("C2"), FUENTE_NORMAL)))
                    tImpuestos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
                    tImpuestos.AddCell((New Phrase(traslado.ImporteP.ToString("C2"), FUENTE_NORMAL)))
                    contador += 1
                Next
                tImpuestos.CompleteRow()
            End If
            documento.Add(tImpuestos)
        End If

    End Function
#End Region
#Region "Formato Normal"
    Private Shared Function AgregarLogo(ByVal rutaLogo As String) As PdfPCell
        Dim celda As PdfPCell

        If rutaLogo <> String.Empty Then
            Dim imagen As Image = Image.GetInstance(rutaLogo)
            imagen.ScaleToFit(110, 110)
            celda = New PdfPCell(imagen)
            celda.HorizontalAlignment = Rectangle.ALIGN_CENTER
            celda.Border = Rectangle.NO_BORDER
        Else
            celda = New PdfPCell(New Phrase())
            celda.Border = Rectangle.NO_BORDER
        End If

        Return celda
    End Function
    Private Shared Function AgregarEncabezado(ByVal comprobante As Comprobante, ByVal rutaLogo As String) As IElement
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_TICKET})
        Dim tablaDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tablaDatos.HorizontalAlignment = HorizontalAlignment.Left
        tablaDatos.DefaultCell.UseBorderPadding = False
        tablaDatos.SetTotalWidth(anchoColumnas)
        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaDatos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaDatos.LockedWidth = True
        tablaDatos.AddCell(AgregarLogo(rutaLogo))
        Dim prc As Paragraph = New Paragraph()
        prc.Alignment = Element.ALIGN_CENTER
        prc.Add(New Chunk(comprobante.Emisor.Nombre & vbLf, FUENTE_TITULO))
        prc.Add(New Chunk(comprobante.Emisor.Rfc & vbLf, FUENTE_NORMAL))
        prc.Add(New Chunk("RÉGIMEN FISCAL: " + vbLf, FUENTE_NORMAL))
        prc.Add(New Chunk(comprobante.Emisor.RegimenFiscal + " - " + Catalogos.ObtenerRegimenFiscal(comprobante.Emisor.RegimenFiscal) & vbLf & vbLf, FUENTE_NORMAL))
        prc.Add(New Chunk("CLIENTE" & vbLf, FUENTE_TITULO))
        prc.Add(New Chunk(comprobante.Receptor.Nombre & vbLf, FUENTE_NORMAL))
        prc.Add(New Chunk(comprobante.Receptor.Rfc & vbLf, FUENTE_NORMAL))
        If Not String.IsNullOrEmpty(comprobante.Receptor.DomicilioFiscalReceptor) Then prc.Add(New Chunk("DOMICILIO FISCAL: " + comprobante.Receptor.DomicilioFiscalReceptor + vbLf, FUENTE_NORMAL))
        If Not String.IsNullOrEmpty(comprobante.Receptor.ResidenciaFiscal) Then prc.Add(New Chunk("RESIDENCIA FISCAL: " + comprobante.Receptor.ResidenciaFiscal + vbLf, FUENTE_NORMAL))
        If Not String.IsNullOrEmpty(comprobante.Receptor.NumRegIdTrib) Then prc.Add(New Chunk("NumRegIdTrib: " + comprobante.Receptor.DomicilioFiscalReceptor + vbLf, FUENTE_NORMAL))
        If Not String.IsNullOrEmpty(comprobante.Receptor.RegimenFiscalReceptor) Then
            prc.Add(New Chunk("RÉGIMEN FISCAL: " + vbLf, FUENTE_NORMAL))
            prc.Add(New Chunk(comprobante.Receptor.RegimenFiscalReceptor + " - " + Catalogos.ObtenerRegimenFiscal(comprobante.Receptor.RegimenFiscalReceptor) + vbLf, FUENTE_NORMAL))
        End If
        If Not String.IsNullOrEmpty(comprobante.Receptor.UsoCFDI) Then
            prc.Add(New Chunk("USO CFDI: " + comprobante.Receptor.UsoCFDI + vbLf, FUENTE_NORMAL))
            prc.Add(New Chunk(Catalogos.ObtenerUsoCFDI(comprobante.Receptor.UsoCFDI) + vbLf, FUENTE_NORMAL))
        End If
        tablaDatos.AddCell(New PdfPCell(prc) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = Rectangle.NO_BORDER,
            .PaddingLeft = 12,
            .PaddingRight = 12
        })

        Dim prc1 As Paragraph = New Paragraph()
        prc1.Alignment = Element.ALIGN_CENTER
        prc1.Add(New Chunk("FACTURA: " & comprobante.Serie & " " + comprobante.Folio + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk("FOLIO FISCAL (UUID):" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.Complemento.TimbreFiscalDigital.UUID + vbLf, FUENTE_NORMAL))
        prc1.Add(New Chunk("NO. DE SERIE DEL CERTIFICADO DEL SAT:" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT + vbLf, FUENTE_NORMAL))
        prc1.Add(New Chunk("NO. DE SERIE DEL CERTIFICADO DEL EMISOR:" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.NoCertificado + vbLf, FUENTE_NORMAL))
        prc1.Add(New Chunk("FECHA Y HORA DE CERTIFICACIÓN:" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado.ToString("s") + vbLf, FUENTE_NORMAL))
        prc1.Add(New Chunk("FECHA Y HORA DE EMISIÓN DE CFDI:" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.Fecha.ToString("s") + vbLf, FUENTE_NORMAL))
        prc1.Add(New Chunk("LUGAR DE EXPEDICIÓN:" + vbLf, FUENTE_TITULO))
        prc1.Add(New Chunk(comprobante.LugarExpedicion + vbLf, FUENTE_NORMAL))
        tablaDatos.AddCell(New PdfPCell(prc1) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Border = Rectangle.NO_BORDER,
            .PaddingLeft = 12,
            .PaddingRight = 12
        })


        Return tablaDatos
    End Function
    Private Shared Function AgregarDatosProductos(ByVal comprobante As Comprobante) As IElement
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_PRODUCTOS_1, ANCHO_COLUMNA_PRODUCTOS_2, ANCHO_COLUMNA_PRODUCTOS_3, ANCHO_COLUMNA_PRODUCTOS_4})
        Dim tablaProductos As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaProductos.HorizontalAlignment = HorizontalAlignment.Left
        tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaProductos.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaProductos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaProductos.SpacingBefore = 10
        tablaProductos.LockedWidth = True
        tablaProductos.SetTotalWidth(tamanoColumnas)

        tablaProductos.AddCell(New PdfPCell(New Phrase("Cant.", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Descripción", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Precio", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Código", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Unidad", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.CompleteRow()


        For Each concepto As Concepto In comprobante.Conceptos.Concepto

            Dim descripcion As StringBuilder = New StringBuilder()

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Cantidad.ToString("F2"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Descripcion, FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ValorUnitario.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = Rectangle.NO_BORDER
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Importe.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = Rectangle.NO_BORDER
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveProdServ, FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveUnidad & "-" & Catalogos.ObtenerUnidad(concepto.ClaveUnidad), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.CompleteRow()


            ''Solo es aplicable a la versión 4.0 y es obligatorio
            If Not String.IsNullOrEmpty(concepto.ObjetoImp) Then
                tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
                })
                tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ObjetoImp & "-" & Catalogos.ObtenerObjetoImpuesto(concepto.ObjetoImp), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
                })
                tablaProductos.CompleteRow()
            End If

            If concepto.Impuestos IsNot Nothing Then
                If concepto.Impuestos.Traslados.Count > 0 Then
                    For Each t As TrasladoC In concepto.Impuestos.Traslados
                        tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .PaddingTop = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.AddCell(New PdfPCell(New Phrase(t.Impuesto & "-" & Catalogos.ObtenerImpuesto(t.Impuesto) & " " & t.TasaOCuota.ToString("P1") & " " & t.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.CompleteRow()
                    Next
                End If
                If concepto.Impuestos.Retenciones.Count > 0 Then
                    For Each r As RetencionC In concepto.Impuestos.Retenciones
                        tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .PaddingTop = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.AddCell(New PdfPCell(New Phrase(r.Impuesto & " " & Catalogos.ObtenerImpuesto(r.Impuesto) & " Base - " + r.Base.ToString("C2") & " Tasa - " & r.TasaOCuota.ToString("F6") & " Importe - " + r.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                    Next
                End If
            End If

            If concepto.ACuentaTerceros IsNot Nothing Then
                descripcion.Append(vbLf & "A cuenta terceros:")
                descripcion.Append(vbLf + "  " + concepto.ACuentaTerceros.NombreACuentaTerceros)
                descripcion.Append(vbLf + "  " + concepto.ACuentaTerceros.RfcACuentaTerceros)
                descripcion.Append(vbLf + "  Régimen fiscal: " + concepto.ACuentaTerceros.RegimenFiscalACuentaTerceros + " - " + Catalogos.ObtenerRegimenFiscal(concepto.ACuentaTerceros.RegimenFiscalACuentaTerceros))
                descripcion.Append(vbLf + "  Domicilio fiscal: " + concepto.ACuentaTerceros.DomicilioFiscalACuentaTerceros)
            End If
        Next

        Return tablaProductos
    End Function
    Private Shared Function ObtenerTotalEnLetra(ByVal total As Decimal) As String
        Dim numaLet As Numalet = New Numalet()
        numaLet.MascaraSalidaDecimal = "00/100 M.N."
        numaLet.SeparadorDecimalSalida = "pesos"
        numaLet.ApocoparUnoParteEntera = True
        numaLet.LetraCapital = True
        Return numaLet.ToCustomString(total).ToUpper()
    End Function
    Private Shared Function AgregarTotales(ByVal comprobante As Comprobante) As IElement
        Dim anchoColumasTablaTotales As Single() = cmAFloat(New Single() {ANCHO_TICKET - ANCHO_COLUMNA_PRODUCTOS_4, ANCHO_COLUMNA_PRODUCTOS_4})
        Dim tablaTotales As PdfPTable = New PdfPTable(anchoColumasTablaTotales)
        tablaTotales.HorizontalAlignment = HorizontalAlignment.Left
        tablaTotales.SetTotalWidth(anchoColumasTablaTotales)
        tablaTotales.DefaultCell.Border = Rectangle.NO_BORDER
        tablaTotales.SpacingBefore = 4
        tablaTotales.LockedWidth = True

        If comprobante.Descuento > 0 Then
            Dim subtotal As Decimal = comprobante.SubTotal + comprobante.Descuento
            tablaTotales.AddCell(New PdfPCell(New Phrase("Subtotal", FUENTE_NORMAL_BOLD)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tablaTotales.AddCell(New PdfPCell(New Phrase(comprobante.SubTotal.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tablaTotales.AddCell(New PdfPCell(New Phrase("Descuento", FUENTE_NORMAL_BOLD)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tablaTotales.AddCell(New PdfPCell(New Phrase(comprobante.Descuento.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
        End If

        tablaTotales.AddCell(New PdfPCell(New Phrase("Subtotal", FUENTE_NORMAL_BOLD)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaTotales.AddCell(New PdfPCell(New Phrase(comprobante.SubTotal.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
        })

        If comprobante.Impuestos IsNot Nothing Then

            If comprobante.Impuestos.Traslados IsNot Nothing Then

                For Each t As Traslado In comprobante.Impuestos.Traslados
                    tablaTotales.AddCell(New PdfPCell(New Phrase(Catalogos.ObtenerImpuesto(t.Impuesto) & " " & t.TasaOCuota.ToString("P1"), FUENTE_NORMAL_BOLD)) With {
                        .PaddingBottom = 0,
                        .PaddingTop = 0,
                        .Border = Rectangle.NO_BORDER,
                        .HorizontalAlignment = Element.ALIGN_RIGHT
                    })
                    tablaTotales.AddCell(New PdfPCell(New Phrase(t.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                        .PaddingBottom = 0,
                        .PaddingTop = 0,
                        .Border = Rectangle.NO_BORDER,
                        .HorizontalAlignment = Element.ALIGN_RIGHT
                    })
                Next
            End If

            If comprobante.Impuestos.Retenciones IsNot Nothing Then

                For Each r As Retencion In comprobante.Impuestos.Retenciones

                    tablaTotales.AddCell(New PdfPCell(New Phrase(Catalogos.ObtenerImpuesto(r.Impuesto), FUENTE_NORMAL_BOLD)) With {
                        .PaddingBottom = 0,
                        .PaddingTop = 0,
                        .Border = Rectangle.NO_BORDER,
                        .HorizontalAlignment = Element.ALIGN_RIGHT
                    })
                    tablaTotales.AddCell(New PdfPCell(New Phrase(r.Importe.ToString("c2"), FUENTE_NORMAL)) With {
                        .Border = Rectangle.NO_BORDER,
                        .HorizontalAlignment = Element.ALIGN_RIGHT
                    })
                Next
            End If
        End If

        tablaTotales.AddCell(New PdfPCell(New Phrase("Total", FUENTE_NORMAL_BOLD)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
        tablaTotales.AddCell(New PdfPCell(New Phrase(comprobante.Total.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .PaddingTop = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

        tablaTotales.AddCell(New PdfPCell(New Phrase(ObtenerTotalEnLetra(comprobante.Total), FUENTE_NORMAL)) With {
            .PaddingBottom = 0,
            .PaddingTop = 0,
            .Colspan = 2,
            .Border = Rectangle.NO_BORDER
        })
        Return tablaTotales
    End Function

    Private Shared Function AgregarDetalleTotales(ByVal comprobante As Comprobante) As IElement
        Dim anchoColumasTablaTotales As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tablaTotales As PdfPTable = New PdfPTable(anchoColumasTablaTotales)
        tablaTotales.HorizontalAlignment = HorizontalAlignment.Left
        tablaTotales.SetTotalWidth(anchoColumasTablaTotales)
        tablaTotales.DefaultCell.Border = Rectangle.NO_BORDER
        tablaTotales.DefaultCell.PaddingBottom = 0
        tablaTotales.SpacingBefore = 4
        tablaTotales.LockedWidth = True

        tablaTotales.AddCell(New Phrase("Tipo de comprobante:", FUENTE_NORMAL_BOLD))
        tablaTotales.AddCell(New Phrase(comprobante.TipoDeComprobante & " - " & Catalogos.ObtenerTipoComprobante(comprobante.TipoDeComprobante), FUENTE_NORMAL))

        If Not String.IsNullOrEmpty(comprobante.Exportacion) Then
            tablaTotales.AddCell(New Phrase("Exportación:", FUENTE_NORMAL_BOLD))
            tablaTotales.AddCell(New Phrase(comprobante.Exportacion & " - " & Catalogos.ObtenerExportacion(comprobante.Exportacion), FUENTE_NORMAL))
        End If
        If comprobante.FormaPago <> String.Empty Then
            tablaTotales.AddCell(New Phrase("Forma de pago:", FUENTE_NORMAL_BOLD))
            tablaTotales.AddCell(New Phrase(comprobante.FormaPago & " - " & Catalogos.ObtenerFormaPago(comprobante.FormaPago), FUENTE_NORMAL))
        End If

        If comprobante.MetodoPago <> String.Empty Then
            tablaTotales.AddCell(New Phrase("Método de pago:", FUENTE_NORMAL_BOLD))
            tablaTotales.AddCell(New Phrase(comprobante.MetodoPago & " - " & Catalogos.ObtenerMetodoPago(comprobante.MetodoPago), FUENTE_NORMAL))
        End If

        tablaTotales.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
        tablaTotales.AddCell(New Phrase(comprobante.Moneda & " - " & Catalogos.ObtenerMoneda(comprobante.Moneda), FUENTE_NORMAL))
        Return tablaTotales
    End Function

    Private Shared Function AgregarSellos(ByVal comprobante As Comprobante) As IElement
        Dim codigoQR As StringBuilder = New StringBuilder()
        codigoQR.Append("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?")
        codigoQR.Append("&id=" & comprobante.Complemento.TimbreFiscalDigital.UUID)
        codigoQR.Append("&re=" & comprobante.Emisor.Rfc)
        codigoQR.Append("&rr=" & comprobante.Receptor.Rfc)
        codigoQR.Append("&tt=" & comprobante.Total.ToString())
        codigoQR.Append("&fe=" & comprobante.Sello.Substring(comprobante.Sello.Length - 8, 8))
        Dim pdfCodigoQR As BarcodeQRCode = New BarcodeQRCode(codigoQR.ToString(), 1, 1, Nothing)
        Dim img As Image = pdfCodigoQR.GetImage()
        img.ScaleAbsolute(cmAFloat(3.4F), cmAFloat(3.4F))
        img.Alignment = Element.ALIGN_LEFT
        Dim cadenaOriginal As StringBuilder = New StringBuilder()
        cadenaOriginal.Append("||")
        cadenaOriginal.Append("1.0|")
        cadenaOriginal.Append(comprobante.Folio & "|")
        cadenaOriginal.Append(comprobante.Folio.ToString() & "|")
        cadenaOriginal.Append(comprobante.Sello & "|")
        cadenaOriginal.Append(comprobante.Serie & "||")
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_TICKET})
        Dim tablaSellos As PdfPTable = New PdfPTable(anchoColumnas)
        tablaSellos.HorizontalAlignment = HorizontalAlignment.Left
        tablaSellos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
        tablaSellos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaSellos.DefaultCell.PaddingBottom = 0
        tablaSellos.SpacingBefore = 5
        tablaSellos.SetTotalWidth(anchoColumnas)
        tablaSellos.LockedWidth = True


        Dim celdaimagen As PdfPCell = New PdfPCell()
        celdaimagen.Border = Rectangle.NO_BORDER
        celdaimagen.VerticalAlignment = Element.ALIGN_TOP
        celdaimagen.Padding = 0
        celdaimagen.HorizontalAlignment = Element.ALIGN_CENTER
        celdaimagen.AddElement(img)
        celdaimagen.FixedHeight = cmAFloat(3.5F)
        tablaSellos.AddCell(celdaimagen)

        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL CFDI:", FUENTE_NORMAL_BOLD))
        tablaSellos.AddCell(New Phrase(comprobante.Sello, FUENTE_CHICA))
        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL SAT", FUENTE_NORMAL_BOLD))
        tablaSellos.AddCell(New Phrase(comprobante.Complemento.TimbreFiscalDigital.SelloSAT, FUENTE_CHICA))
        tablaSellos.AddCell(New Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT:", FUENTE_NORMAL_BOLD))
        tablaSellos.AddCell(New Phrase(cadenaOriginal.ToString(), FUENTE_CHICA))
        Return tablaSellos
    End Function
#End Region
#Region "Nomina 2.0"
    Private Shared Sub N2AgregarEmisor(ByVal document As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.Nomina.Emisor.Curp = String.Empty And comprobante.Complemento.Nomina.Emisor.RegistroPatronal = String.Empty AndAlso comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen = String.Empty Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tEmisor As PdfPTable = New PdfPTable(anchoColumnas)
        tEmisor.SetTotalWidth(anchoColumnas)
        tEmisor.SpacingBefore = 5
        tEmisor.HorizontalAlignment = HorizontalAlignment.Left
        tEmisor.DefaultCell.Border = Rectangle.NO_BORDER
        tEmisor.DefaultCell.PaddingBottom = 1
        tEmisor.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("EMISOR", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tEmisor.AddCell(cEncabezado)

        If comprobante.Complemento.Nomina.Emisor.RegistroPatronal <> String.Empty Then
            tEmisor.AddCell(New Phrase("Registro patronal", FUENTE_NORMAL_BOLD))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.RegistroPatronal, FUENTE_NORMAL))
        End If

        If comprobante.Complemento.Nomina.Emisor.Curp <> String.Empty Then
            tEmisor.AddCell(New Phrase("CURP", FUENTE_NORMAL_BOLD))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.Curp, FUENTE_NORMAL))
        End If

        If comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen <> String.Empty Then
            tEmisor.AddCell(New Phrase("RFC patrón origen", FUENTE_NORMAL_BOLD))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen, FUENTE_NORMAL))
        End If

        tEmisor.CompleteRow()
        document.Add(tEmisor)
    End Sub
    Private Shared Function N2AgregarEmpleado(ByVal comprobante As Comprobante) As PdfPTable
        Dim Receptor = comprobante.Complemento.Nomina.Receptor
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tDatos.SetTotalWidth(anchoColumnas)
        tDatos.LockedWidth = True
        tDatos.DefaultCell.Border = Rectangle.NO_BORDER
        tDatos.DefaultCell.BorderWidth = 1
        tDatos.HorizontalAlignment = HorizontalAlignment.Left
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("EMPLEADO", FUENTE_NORMAL_BOLD))
        cEncabezado.BorderWidth = 1
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 2
        tDatos.AddCell(cEncabezado)
        tDatos.AddCell(New Phrase("Núm. de empleado", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Receptor.NumEmpleado, FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("CURP", FUENTE_NORMAL_BOLD))
        tDatos.AddCell((New Phrase(Receptor.Curp, FUENTE_NORMAL)))

        If Receptor.NumSeguridadSocial <> String.Empty Then
            tDatos.AddCell(New Phrase("Núm. Seguridad Social", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.NumSeguridadSocial, FUENTE_NORMAL))
        End If

        If Receptor.FechaInicioRelLaboral <> Nothing Then
            tDatos.AddCell(New Phrase("Fecha de inicio de la relación laboral", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.FechaInicioRelLaboral.ToShortDateString(), FUENTE_NORMAL))
        End If

        If Receptor.Antiguedad <> String.Empty Then
            tDatos.AddCell(New Phrase("Antiguedad", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.Antiguedad, FUENTE_NORMAL))
        End If

        tDatos.AddCell(New Phrase("Tipo de contrato", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Receptor.TipoContrato, FUENTE_NORMAL))

        If Receptor.Sindicalizado <> String.Empty Then
            tDatos.AddCell(New Phrase("Sindicalizado", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.Sindicalizado, FUENTE_NORMAL))
        End If

        If Receptor.TipoJornada <> String.Empty Then
            tDatos.AddCell(New Phrase("Tipo jornada", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.TipoJornada, FUENTE_NORMAL))
        End If

        If Receptor.TipoRegimen <> String.Empty Then
            tDatos.AddCell(New Phrase("Tipo de régimen", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.TipoRegimen, FUENTE_NORMAL))
        End If

        If Receptor.Departamento <> String.Empty Then
            tDatos.AddCell(New Phrase("Departamento", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.Departamento, FUENTE_NORMAL))
        End If

        If Receptor.Puesto <> String.Empty Then
            tDatos.AddCell(New Phrase("Puesto", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.Puesto, FUENTE_NORMAL))
        End If

        If Receptor.RiesgoPuesto <> String.Empty Then
            tDatos.AddCell(New Phrase("Riesgo de puesto", FUENTE_NORMAL_BOLD))
            tDatos.AddCell(New Phrase(Receptor.RiesgoPuesto & " - " & Catalogos.ObtenerRiesgoPuesto(Receptor.RiesgoPuesto), FUENTE_NORMAL))
        End If

        Return tDatos
    End Function
    Private Shared Function N2AgregarPago(ByVal comprobate As Comprobante) As PdfPTable
        Dim Nomina = comprobate.Complemento.Nomina
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tDatos.DefaultCell.Border = Rectangle.NO_BORDER
        tDatos.HorizontalAlignment = HorizontalAlignment.Left
        tDatos.SetTotalWidth(anchoColumnas)
        tDatos.LockedWidth = True
        tDatos.DefaultCell.BorderWidth = 1
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PAGOS", FUENTE_NORMAL_BOLD))
        cEncabezado.BorderWidth = 1
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 2
        tDatos.AddCell(cEncabezado)
        tDatos.AddCell(New Phrase("Tipo de nómina", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.TipoNomina & " - " & Catalogos.ObtenerTipoNomina(Nomina.TipoNomina), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Fecha de pago", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.FechaPago.ToShortDateString(), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Fecha inicial de pago", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.FechaInicialPago.ToShortDateString(), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Fecha final pago", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.FechaFinalPago.ToShortDateString(), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Núm. de dias pagados", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.NumDiasPagados.ToString("F3"), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Salario diario integrado", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.Receptor.SalarioDiarioIntegrado.ToString("C2"), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Salario base Cot. Aport.", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.Receptor.SalarioBaseCotApor.ToString("C2"), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Periodicidad de pago", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.Receptor.PeriodicidadPago & " - " & Catalogos.ObtenerPeriodicidadPago(Nomina.Receptor.PeriodicidadPago), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Total de percepciones", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.TotalPercepciones.ToString("C3"), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Total de deducciones", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.TotalDeducciones.ToString("C3"), FUENTE_NORMAL))
        tDatos.AddCell(New Phrase("Total de otros pagos", FUENTE_NORMAL_BOLD))
        tDatos.AddCell(New Phrase(Nomina.TotalOtrosPagos.ToString("C3"), FUENTE_NORMAL))
        tDatos.CompleteRow()
        Return tDatos
    End Function
    Private Shared Sub N2AgregarPercepciones(ByVal document As Document, ByVal percepciones As NPercepciones)
        If percepciones IsNot Nothing AndAlso percepciones.Percepcion IsNot Nothing AndAlso percepciones.Percepcion.Count > 0 Then
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tPercepciones As PdfPTable = New PdfPTable(anchoColumnas)
            tPercepciones.DefaultCell.BorderWidth = 1
            tPercepciones.DefaultCell.Border = Rectangle.NO_BORDER
            tPercepciones.SetTotalWidth(anchoColumnas)
            tPercepciones.SpacingBefore = 5
            tPercepciones.HorizontalAlignment = HorizontalAlignment.Left
            tPercepciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PERCEPCIONES", FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BorderWidth = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tPercepciones.AddCell(cEncabezado)
            tPercepciones.AddCell(New Phrase("Concepto", FUENTE_NORMAL_BOLD))
            tPercepciones.AddCell(New Phrase("Clave", FUENTE_NORMAL_BOLD))
            tPercepciones.AddCell(New Phrase("Tipo de percecepíon", FUENTE_NORMAL_BOLD))
            tPercepciones.AddCell(New PdfPCell(New Phrase("Importe exento", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tPercepciones.AddCell(New PdfPCell(New Phrase("Importe gravado", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each p As NPercepcion In percepciones.Percepcion
                tPercepciones.AddCell(New Phrase(p.Concepto, FUENTE_NORMAL))
                tPercepciones.AddCell(New Phrase(p.Clave, FUENTE_NORMAL))
                tPercepciones.AddCell(New Phrase(p.TipoPercepcion & " - " & Catalogos.ObtenerTipoPercepcion(p.TipoPercepcion), FUENTE_NORMAL))
                tPercepciones.AddCell(New PdfPCell(New Phrase(p.ImporteGravado.ToString("C2"), FUENTE_NORMAL)) With {
                    .BorderWidth = 1,
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
                tPercepciones.AddCell(New PdfPCell(New Phrase(p.ImporteExento.ToString("C2"), FUENTE_NORMAL)) With {
                    .BorderWidth = 1,
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            tPercepciones.AddCell("")
            tPercepciones.AddCell("")
            tPercepciones.AddCell(New Phrase("Total", FUENTE_NORMAL_BOLD))
            tPercepciones.AddCell(New PdfPCell(New Phrase(percepciones.TotalGravado.ToString("C2"), FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tPercepciones.AddCell(New PdfPCell(New Phrase(percepciones.TotalExento.ToString("C2"), FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            document.Add(tPercepciones)
        End If
    End Sub
    Private Shared Sub N2AgregarDeducciones(ByVal document As Document, ByVal deducciones As NDeducciones)
        If deducciones IsNot Nothing AndAlso deducciones.Deduccion IsNot Nothing AndAlso deducciones.Deduccion.Count > 0 Then
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tDeducciones As PdfPTable = New PdfPTable(anchoColumnas)
            tDeducciones.DefaultCell.BorderWidth = 1
            tDeducciones.DefaultCell.Border = Rectangle.NO_BORDER
            tDeducciones.SetTotalWidth(anchoColumnas)
            tDeducciones.SpacingBefore = 5
            tDeducciones.HorizontalAlignment = HorizontalAlignment.Left
            tDeducciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DEDUCCIONES", FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BorderWidth = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tDeducciones.AddCell(cEncabezado)
            tDeducciones.AddCell(New Phrase("Concepto", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New Phrase("Clave", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New Phrase("Tipo de deducción", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each d As NDeduccion In deducciones.Deduccion
                tDeducciones.AddCell(New Phrase(d.Concepto, FUENTE_NORMAL))
                tDeducciones.AddCell(New Phrase(d.Clave, FUENTE_NORMAL))
                tDeducciones.AddCell(New Phrase(d.TipoDeduccion & " - " & Catalogos.ObtenerTipoDeduccion(d.TipoDeduccion), FUENTE_NORMAL))
                tDeducciones.AddCell(New PdfPCell(New Phrase(d.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                    .BorderWidth = 1,
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            tDeducciones.AddCell("")
            tDeducciones.AddCell("")
            tDeducciones.AddCell(New Phrase("Total", FUENTE_NORMAL_BOLD))
            Dim total As Decimal = 0
            total = deducciones.TotalImpuestosRetenidos + deducciones.TotalOtrasDeducciones
            tDeducciones.AddCell(New PdfPCell(New Phrase(total.ToString("C2"), FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            document.Add(tDeducciones)
        End If
    End Sub
    Private Shared Sub N2AgregarOtroPagos(ByVal document As Document, ByVal otrosPagos As NOtrosPagos)
        If otrosPagos IsNot Nothing AndAlso otrosPagos.OtroPago IsNot Nothing AndAlso otrosPagos.OtroPago.Count > 0 Then
            If ExisteSubsidioParaElEmpleo(otrosPagos) AndAlso otrosPagos.OtroPago.Count = 1 Then Return
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tDeducciones As PdfPTable = New PdfPTable(anchoColumnas)
            tDeducciones.DefaultCell.BorderWidth = 1
            tDeducciones.DefaultCell.Border = Rectangle.NO_BORDER
            tDeducciones.SetTotalWidth(anchoColumnas)
            tDeducciones.SpacingBefore = 5
            tDeducciones.HorizontalAlignment = HorizontalAlignment.Left
            tDeducciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("OTROS PAGOS", FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BorderWidth = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tDeducciones.AddCell(cEncabezado)
            tDeducciones.AddCell(New Phrase("Concepto", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New Phrase("Clave", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New Phrase("Tipo de deducción", FUENTE_NORMAL_BOLD))
            tDeducciones.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_NORMAL_BOLD)) With {
                .BorderWidth = 1,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each d As NOtroPago In otrosPagos.OtroPago
                tDeducciones.AddCell(New Phrase(d.Concepto, FUENTE_NORMAL))
                tDeducciones.AddCell(New Phrase(d.Clave, FUENTE_NORMAL))
                tDeducciones.AddCell(New Phrase(d.TipoOtroPago & " - " & Catalogos.ObtenerTipoOtroPago(d.TipoOtroPago), FUENTE_NORMAL))
                tDeducciones.AddCell(New PdfPCell(New Phrase(d.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                    .BorderWidth = 1,
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            document.Add(tDeducciones)
        End If
    End Sub
    Private Shared Function ExisteSubsidioParaElEmpleo(ByVal otrosPagos As NOtrosPagos) As Boolean
        Dim band As Boolean = False

        If otrosPagos IsNot Nothing Then

            For Each op As NOtroPago In otrosPagos.OtroPago
                If op.Importe = 0.01D Then Return True
            Next
        End If

        Return band
    End Function
#End Region
#Region "Carta Porte 3.0"
    Private Shared Sub AgregarDatosCartaPorte30(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.CartaPorte30 Is Nothing Then Return
        Dim cartaPorte As CartaPorte30 = comprobante.Complemento.CartaPorte30
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tCartaPorte As PdfPTable = New PdfPTable(anchoColumnas)
        tCartaPorte.SetTotalWidth(anchoColumnas)
        tCartaPorte.SpacingBefore = 5
        tCartaPorte.HorizontalAlignment = HorizontalAlignment.Left
        tCartaPorte.DefaultCell.Border = Rectangle.NO_BORDER
        tCartaPorte.DefaultCell.PaddingBottom = 0
        tCartaPorte.DefaultCell.PaddingTop = 0
        tCartaPorte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CARTA PORTE " & cartaPorte.Version.ToUpper(), FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tCartaPorte.AddCell(cEncabezado)
        tCartaPorte.AddCell(New Phrase("Folo del complemento", FUENTE_NORMAL_BOLD))
        tCartaPorte.AddCell(New Phrase(cartaPorte.IdCCP, FUENTE_NORMAL))

        tCartaPorte.AddCell(New Phrase("Transporte internacional", FUENTE_NORMAL_BOLD))
        tCartaPorte.AddCell(New Phrase(cartaPorte.TranspInternac, FUENTE_NORMAL))

        If Not String.IsNullOrEmpty(cartaPorte.RegimenAduanero) Then
            tCartaPorte.AddCell(New Phrase("Regimen aduanero", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.RegimenAduanero, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.EntradaSalidaMerc) Then
            tCartaPorte.AddCell(New Phrase("Entrada-Salida mercancías", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.PaisOrigenDestino, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.PaisOrigenDestino) Then
            tCartaPorte.AddCell(New Phrase("Pais origen o destino", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.PaisOrigenDestino, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.ViaEntradaSalida) Then
            tCartaPorte.AddCell(New Phrase("Vía entrada o salida", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.ViaEntradaSalida, FUENTE_NORMAL))
        End If

        If cartaPorte.TotalDistRec > 0 Then
            tCartaPorte.AddCell(New Phrase("Total distancia recorrida", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.TotalDistRec.ToString() & " k.m.", FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.RegistroISTMO) Then
            tCartaPorte.AddCell(New Phrase("Registro ISTMO", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.RegistroISTMO, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.UbicacionPoloOrigen) Then
            tCartaPorte.AddCell(New Phrase("Ubicación Polo origen", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.UbicacionPoloOrigen, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.UbicacionPoloDestino) Then
            tCartaPorte.AddCell(New Phrase("Ubicación Polo destino", FUENTE_NORMAL_BOLD))
            tCartaPorte.AddCell(New Phrase(cartaPorte.UbicacionPoloDestino, FUENTE_NORMAL))
        End If


        tCartaPorte.CompleteRow()
        documento.Add(tCartaPorte)
    End Sub

    Private Shared Function AgregarConceptosCartaPorte30(ByVal comprobante As Comprobante) As IElement
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_PRODUCTOS_1, ANCHO_COLUMNA_PRODUCTOS_2, ANCHO_COLUMNA_PRODUCTOS_3, ANCHO_COLUMNA_PRODUCTOS_4})
        Dim tablaProductos As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaProductos.HorizontalAlignment = HorizontalAlignment.Left
        tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaProductos.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaProductos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaProductos.DefaultCell.PaddingBottom = 0
        tablaProductos.DefaultCell.PaddingTop = 0
        tablaProductos.SpacingBefore = 10
        tablaProductos.LockedWidth = True
        tablaProductos.SetTotalWidth(tamanoColumnas)

        tablaProductos.AddCell(New PdfPCell(New Phrase("Cant.", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Descripción", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Precio", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Código", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Unidad", FUENTE_NORMAL_BOLD)) With {
            .PaddingBottom = 0,
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_LEFT
        })
        tablaProductos.CompleteRow()


        For Each concepto As Concepto In comprobante.Conceptos.Concepto

            Dim descripcion As StringBuilder = New StringBuilder()

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Cantidad.ToString("F2"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Descripcion, FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ValorUnitario.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = Rectangle.NO_BORDER
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Importe.ToString("C"), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .Border = Rectangle.NO_BORDER
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveProdServ, FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveUnidad & "-" & Catalogos.ObtenerUnidad(concepto.ClaveUnidad), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            tablaProductos.CompleteRow()


            ''Solo es aplicable a la versión 4.0 y es obligatorio
            If Not String.IsNullOrEmpty(concepto.ObjetoImp) Then
                tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
                })
                tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ObjetoImp & "-" & Catalogos.ObtenerObjetoImpuesto(concepto.ObjetoImp), FUENTE_NORMAL)) With {
                .PaddingBottom = 0,
                .Border = Rectangle.NO_BORDER,
                .HorizontalAlignment = Element.ALIGN_LEFT
                })
                tablaProductos.CompleteRow()
            End If

            If concepto.Impuestos IsNot Nothing Then
                If concepto.Impuestos.Traslados.Count > 0 Then
                    For Each t As TrasladoC In concepto.Impuestos.Traslados
                        tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.AddCell(New PdfPCell(New Phrase(t.Impuesto & "-" & Catalogos.ObtenerImpuesto(t.Impuesto) & " " & t.TasaOCuota.ToString("P1") & " " & t.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.CompleteRow()
                    Next
                End If
                If concepto.Impuestos.Retenciones.Count > 0 Then
                    For Each r As RetencionC In concepto.Impuestos.Retenciones
                        tablaProductos.AddCell(New PdfPCell(New Phrase(" ", FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                        tablaProductos.AddCell(New PdfPCell(New Phrase(r.Impuesto & " " & Catalogos.ObtenerImpuesto(r.Impuesto) & " Base - " + r.Base.ToString("C2") & " Tasa - " & r.TasaOCuota.ToString("F6") & " Importe - " + r.Importe.ToString("C2"), FUENTE_NORMAL)) With {
                            .PaddingBottom = 0,
                            .Border = Rectangle.NO_BORDER,
                            .HorizontalAlignment = Element.ALIGN_LEFT
                        })
                    Next
                End If
            End If

            If concepto.ACuentaTerceros IsNot Nothing Then
                descripcion.Append(vbLf & "A cuenta terceros:")
                descripcion.Append(vbLf + "  " + concepto.ACuentaTerceros.NombreACuentaTerceros)
                descripcion.Append(vbLf + "  " + concepto.ACuentaTerceros.RfcACuentaTerceros)
                descripcion.Append(vbLf + "  Régimen fiscal: " + concepto.ACuentaTerceros.RegimenFiscalACuentaTerceros + " - " + Catalogos.ObtenerRegimenFiscal(concepto.ACuentaTerceros.RegimenFiscalACuentaTerceros))
                descripcion.Append(vbLf + "  Domicilio fiscal: " + concepto.ACuentaTerceros.DomicilioFiscalACuentaTerceros)
            End If
        Next

        Return tablaProductos
    End Function
    Private Shared Sub AgregarUbicaciones30(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.CartaPorte30.Ubicaciones Is Nothing Then Return
        Dim contador As Integer = 0

        For Each ubicacion In comprobante.Complemento.CartaPorte30.Ubicaciones.Ubicacion
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tTipoFigura As PdfPTable = New PdfPTable(anchoColumnas)
            tTipoFigura.SetTotalWidth(anchoColumnas)
            tTipoFigura.SpacingBefore = 5
            tTipoFigura.HorizontalAlignment = HorizontalAlignment.Left
            tTipoFigura.DefaultCell.Border = Rectangle.NO_BORDER
            tTipoFigura.DefaultCell.PaddingBottom = 0
            tTipoFigura.DefaultCell.PaddingTop = 0
            tTipoFigura.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("UBICACIÓN " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTipoFigura.AddCell(cEncabezado)
            tTipoFigura.AddCell(New Phrase("Tipo de ubicación", FUENTE_NORMAL_BOLD))
            tTipoFigura.AddCell(New Phrase(ubicacion.TipoUbicacion, FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(ubicacion.IDUbicacion) Then
                tTipoFigura.AddCell(New Phrase("ID ubicación", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.IDUbicacion, FUENTE_NORMAL))
            End If

            tTipoFigura.AddCell(New Phrase("R.F.C del " & (If(ubicacion.TipoUbicacion = "Origen", "remitente", "destinario")), FUENTE_NORMAL_BOLD))
            tTipoFigura.AddCell(New Phrase(ubicacion.RFCRemitenteDestinatario, FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(ubicacion.NombreRemitenteDestinatario) Then
                tTipoFigura.AddCell(New Phrase("Número del " & (If(ubicacion.TipoUbicacion = "Origen", "remitente", "destinario")), FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.NombreRemitenteDestinatario, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(ubicacion.NumRegIdTrib) Then
                tTipoFigura.AddCell(New Phrase("Núm. Reg. Id. Trib.", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.NumRegIdTrib, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(ubicacion.ResidenciaFiscal) Then
                tTipoFigura.AddCell(New Phrase("Residencia fiscal", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.ResidenciaFiscal, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(ubicacion.NumEstacion) Then
                tTipoFigura.AddCell(New Phrase("Número de estación", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.NumEstacion, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(ubicacion.NombreEstacion) Then
                tTipoFigura.AddCell(New Phrase("Nombre de estación", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.NombreEstacion, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(ubicacion.NavegacionTrafico) Then
                tTipoFigura.AddCell(New Phrase("Navegación trafico", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.NavegacionTrafico, FUENTE_NORMAL))
            End If

            tTipoFigura.AddCell(New Phrase("Fecha", FUENTE_NORMAL_BOLD))
            tTipoFigura.AddCell(New Phrase(ubicacion.FechaHoraSalidaLlegada.ToString("s"), FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(ubicacion.TipoEstacion) Then
                tTipoFigura.AddCell(New Phrase("Tipo de estación", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.TipoEstacion & " " + Catalogos.ObtenerTipoEstacion(ubicacion.TipoEstacion), FUENTE_NORMAL))
            End If

            If ubicacion.DistanciaRecorrida > 0 Then
                tTipoFigura.AddCell(New Phrase("Distancia recorrida", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(ubicacion.DistanciaRecorrida.ToString("f2"), FUENTE_NORMAL))
            End If

            tTipoFigura.CompleteRow()
            documento.Add(tTipoFigura)
            AgregarDomicilio30(documento, ubicacion.Domicilio)
        Next
    End Sub

    Private Shared Sub AgregarFiguraTransporte30(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim contador As Integer = 0

        For Each tipoFigura In comprobante.Complemento.CartaPorte30.FiguraTransporte.TiposFigura
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tTipoFigura As PdfPTable = New PdfPTable(anchoColumnas)
            tTipoFigura.SetTotalWidth(anchoColumnas)
            tTipoFigura.SpacingBefore = 5
            tTipoFigura.HorizontalAlignment = HorizontalAlignment.Left
            tTipoFigura.DefaultCell.Border = Rectangle.NO_BORDER
            tTipoFigura.DefaultCell.PaddingBottom = 0
            tTipoFigura.DefaultCell.PaddingBottom = 0
            tTipoFigura.LockedWidth = True

            If contador = 1 Then
                Dim cTiposFigura As PdfPCell = New PdfPCell(New Phrase("FIGURAS DE TRANSPORTE", FUENTE_NORMAL_BOLD))
                cTiposFigura.UseAscender = True
                cTiposFigura.Border = Rectangle.NO_BORDER
                cTiposFigura.HorizontalAlignment = Element.ALIGN_CENTER
                cTiposFigura.VerticalAlignment = Element.ALIGN_MIDDLE
                cTiposFigura.PaddingBottom = 1
                cTiposFigura.Colspan = 4
                tTipoFigura.AddCell(cTiposFigura)
            End If

            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TIPO DE FIGURA " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTipoFigura.AddCell(cEncabezado)
            tTipoFigura.AddCell(New Phrase("Tipo", FUENTE_NORMAL_BOLD))
            tTipoFigura.AddCell(New Phrase(tipoFigura.TipoFigura + " - " + Catalogos.ObtenerFiguraTransporte(tipoFigura.TipoFigura), FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(tipoFigura.RFCFigura) Then
                tTipoFigura.AddCell(New Phrase("R.F.C", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(tipoFigura.RFCFigura, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NumLicencia) Then
                tTipoFigura.AddCell(New Phrase("Número de licencia", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NumLicencia, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NombreFigura) Then
                tTipoFigura.AddCell(New Phrase("Nombre", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NombreFigura, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NumRegIdTribFigura) Then
                tTipoFigura.AddCell(New Phrase("Núm. Reg. Id. Trib.", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NumRegIdTribFigura, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.ResidenciaFiscalFigura) Then
                tTipoFigura.AddCell(New Phrase("Residencia fiscal", FUENTE_NORMAL_BOLD))
                tTipoFigura.AddCell(New Phrase(tipoFigura.ResidenciaFiscalFigura, FUENTE_NORMAL))
            End If
            tTipoFigura.CompleteRow()

            documento.Add(tTipoFigura)
            AgregarPartesTransporte30(documento, tipoFigura)
            AgregarDomicilio30(documento, tipoFigura.Domicilio)

        Next
    End Sub

    Private Shared Sub AgregarPartesTransporte30(ByVal documento As Document, ByVal tipoFigura As TiposFigura)
        Dim contador As Integer = 0

        For Each parteTransporte In tipoFigura.PartesTransporte
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tParteTransporte As PdfPTable = New PdfPTable(anchoColumnas)
            tParteTransporte.SetTotalWidth(anchoColumnas)
            tParteTransporte.SpacingBefore = 5
            tParteTransporte.HorizontalAlignment = HorizontalAlignment.Left
            tParteTransporte.DefaultCell.Border = Rectangle.NO_BORDER
            tParteTransporte.DefaultCell.PaddingBottom = 0
            tParteTransporte.DefaultCell.PaddingTop = 0
            tParteTransporte.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PARTE DE TRANSPORTE " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tParteTransporte.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(parteTransporte.ParteTransporte) Then
                tParteTransporte.AddCell(New Phrase("Parte transporte", FUENTE_NORMAL_BOLD))
                tParteTransporte.AddCell(New Phrase(parteTransporte.ParteTransporte + " - " + Catalogos.ObtenerParteTransporte(parteTransporte.ParteTransporte), FUENTE_NORMAL))
            End If
            documento.Add(tParteTransporte)
        Next
    End Sub

    Private Shared Sub AgregarMercancias30(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim mercancias As Mercancias = comprobante.Complemento.CartaPorte30.Mercancias
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tMercancias As PdfPTable = New PdfPTable(anchoColumnas)
        tMercancias.SetTotalWidth(anchoColumnas)
        tMercancias.SpacingBefore = 5
        tMercancias.HorizontalAlignment = HorizontalAlignment.Left
        tMercancias.DefaultCell.Border = Rectangle.NO_BORDER
        tMercancias.DefaultCell.PaddingBottom = 0
        tMercancias.DefaultCell.PaddingTop = 0
        tMercancias.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("MERCANCIAS", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tMercancias.AddCell(cEncabezado)
        tMercancias.AddCell(New Phrase("Peso bruto total", FUENTE_NORMAL_BOLD))
        tMercancias.AddCell(New Phrase(mercancias.PesoBrutoTotal.ToString("f3"), FUENTE_NORMAL))
        tMercancias.AddCell(New Phrase("Unidad de peso", FUENTE_NORMAL_BOLD))
        tMercancias.AddCell(New Phrase(mercancias.UnidadPeso, FUENTE_NORMAL))

        If mercancias.PesoNetoTotal > 0 Then
            tMercancias.AddCell(New Phrase("Peso neto total", FUENTE_NORMAL_BOLD))
            tMercancias.AddCell(New Phrase(mercancias.PesoNetoTotal.ToString("F3"), FUENTE_NORMAL))
        End If

        tMercancias.AddCell(New Phrase("Número total de mercancias", FUENTE_NORMAL_BOLD))
        tMercancias.AddCell(New Phrase(mercancias.NumTotalMercancias.ToString(), FUENTE_NORMAL))

        If mercancias.CargoPorTasacion > 0 Then
            tMercancias.AddCell(New Phrase("Cargo por tasacion", FUENTE_NORMAL_BOLD))
            tMercancias.AddCell(New Phrase(mercancias.CargoPorTasacion.ToString(), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(mercancias.LogisticaInversaRecoleccionDevolucion) Then
            tMercancias.AddCell(New Phrase("Servicio de logistica", FUENTE_NORMAL_BOLD))
            tMercancias.AddCell(New Phrase(mercancias.CargoPorTasacion.ToString(), FUENTE_NORMAL))
        End If

        tMercancias.CompleteRow()
        documento.Add(tMercancias)
        AgregarMercancia30(documento, mercancias)
        AgregarAutoTransporte30(documento, mercancias.Autotransporte)
        AgregarTransporteMaritimo30(documento, mercancias.TransporteMaritimo)
        AgregarTransporteAereo30(documento, mercancias.TransporteAereo)
        AgregarTransporteFerroviario30(documento, mercancias.TransporteFerroviario)
    End Sub

    Private Shared Sub AgregarMercancia30(ByVal documento As Document, ByVal mercancias As Mercancias)
        Dim contador As Integer = 0

        For Each mercancia In mercancias.Mercancia
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tMercancia As PdfPTable = New PdfPTable(anchoColumnas)
            tMercancia.SetTotalWidth(anchoColumnas)
            tMercancia.SpacingBefore = 5
            tMercancia.HorizontalAlignment = HorizontalAlignment.Left
            tMercancia.DefaultCell.Border = Rectangle.NO_BORDER
            tMercancia.DefaultCell.BorderWidth = 1
            tMercancia.DefaultCell.PaddingBottom = 0
            tMercancia.DefaultCell.PaddingTop = 0
            tMercancia.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("MERCANCIA " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.PaddingBottom = 1
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tMercancia.AddCell(cEncabezado)
            tMercancia.AddCell(New Phrase("Bienes transportados", FUENTE_NORMAL_BOLD))
            tMercancia.AddCell(New Phrase(mercancia.BienesTransp, FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(mercancia.ClaveSTCC) Then
                tMercancia.AddCell(New Phrase("Clave STTC", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.ClaveSTCC, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.Descripcion) Then
                tMercancia.AddCell(New Phrase("Descripción", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Descripcion, FUENTE_NORMAL))
            End If

            If mercancia.Cantidad > 0 Then
                tMercancia.AddCell(New Phrase("Cantidad", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Cantidad.ToString("F6"), FUENTE_NORMAL))
            End If

            tMercancia.AddCell(New Phrase("Clave de unidad", FUENTE_NORMAL_BOLD))
            tMercancia.AddCell(New Phrase(mercancia.ClaveUnidad & " - " + Catalogos.ObtenerUnidad(mercancia.ClaveUnidad), FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(mercancia.Unidad) Then
                tMercancia.AddCell(New Phrase("Unidad", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Unidad, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.Dimensiones) Then
                tMercancia.AddCell(New Phrase("Dimensiones", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Dimensiones, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.MaterialPeligroso) Then
                tMercancia.AddCell(New Phrase("Material peligroso", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.MaterialPeligroso, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.CveMaterialPeligroso) Then
                tMercancia.AddCell(New Phrase("Clave material peligroso", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.CveMaterialPeligroso, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.Embalaje) Then
                tMercancia.AddCell(New Phrase("Embalaje", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Embalaje, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DescripEmbalaje) Then
                tMercancia.AddCell(New Phrase("Descripción embalaje", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DescripEmbalaje, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.SectorCOFEPRIS) Then
                tMercancia.AddCell(New Phrase("Sector COFEPRIS", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.SectorCOFEPRIS, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.NombreIngredienteActivo) Then
                tMercancia.AddCell(New Phrase("Nombre del Ingrediente activo", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.NombreIngredienteActivo, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.NomQuimico) Then
                tMercancia.AddCell(New Phrase("Nombre quimico", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.NomQuimico, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DenominacionGenericaProd) Then
                tMercancia.AddCell(New Phrase("Denominación generica del producto", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DenominacionGenericaProd, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DenominacionDistintivaProd) Then
                tMercancia.AddCell(New Phrase("Denominación distintiva del producto", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DenominacionDistintivaProd, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.Fabricante) Then
                tMercancia.AddCell(New Phrase("Fabricante", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Fabricante, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.FechaCaducidad) Then
                tMercancia.AddCell(New Phrase("Fecha de caducidad", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.FechaCaducidad.ToString(), FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.LoteMedicamento) Then
                tMercancia.AddCell(New Phrase("Lote del medicamento", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.LoteMedicamento, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.FormaFarmaceutica) Then
                tMercancia.AddCell(New Phrase("Forma farmaceutica", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.FormaFarmaceutica, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.CondicionesEspTransp) Then
                tMercancia.AddCell(New Phrase("Condiciones especiales transporte", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.CondicionesEspTransp, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.RegistroSanitarioFolioAutorizacion) Then
                tMercancia.AddCell(New Phrase("Registro sanitario o folio de autorización", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.RegistroSanitarioFolioAutorizacion, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.PermisoImportacion) Then
                tMercancia.AddCell(New Phrase("Permiso de importación", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.PermisoImportacion, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.FolioImpoVUCEM) Then
                tMercancia.AddCell(New Phrase("Folio de importación VUCEM", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.FolioImpoVUCEM, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.NumCAS) Then
                tMercancia.AddCell(New Phrase("Número CAS", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.NumCAS, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.RazonSocialEmpImp) Then
                tMercancia.AddCell(New Phrase("Razón social empresa importadora", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.RazonSocialEmpImp, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.NumRegSanPlagCOFEPRIS) Then
                tMercancia.AddCell(New Phrase("Número registro sanitario", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.NumRegSanPlagCOFEPRIS, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DatosFabricante) Then
                tMercancia.AddCell(New Phrase("Datos fabricante", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DatosFabricante, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DatosFormulador) Then
                tMercancia.AddCell(New Phrase("Datos formulador", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DatosFormulador, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DatosMaquilador) Then
                tMercancia.AddCell(New Phrase("Datos maquilador", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DatosMaquilador, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.UsoAutorizado) Then
                tMercancia.AddCell(New Phrase("Uso autorizado", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.UsoAutorizado, FUENTE_NORMAL))
            End If


            tMercancia.AddCell(New Phrase("Peso en kg", FUENTE_NORMAL_BOLD))
            tMercancia.AddCell(New Phrase(mercancia.PesoEnKg.ToString("F3"), FUENTE_NORMAL))

            If mercancia.ValorMercancia > 0 Then
                tMercancia.AddCell(New Phrase("Valor mercancia", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.ValorMercancia.ToString("F2"), FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.Moneda) Then
                tMercancia.AddCell(New Phrase("Moneda", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.Moneda, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.FraccionArancelaria) Then
                tMercancia.AddCell(New Phrase("Fraccion arancelaria", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.FraccionArancelaria, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.UUIDComercioExt) Then
                tMercancia.AddCell(New Phrase("UUID comercio exterior", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.UUIDComercioExt, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.TipoMateria) Then
                tMercancia.AddCell(New Phrase("Tipo materia", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.TipoMateria, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(mercancia.DescripcionMateria) Then
                tMercancia.AddCell(New Phrase("Descripción materia", FUENTE_NORMAL_BOLD))
                tMercancia.AddCell(New Phrase(mercancia.DescripcionMateria, FUENTE_NORMAL))
            End If

            tMercancia.CompleteRow()
            documento.Add(tMercancia)
            AgregarDocumentacionAduanera30(documento, mercancia)
            AgregarGuiasIdentificacion30(documento, mercancia)
            AgregarCantidadTransporta30(documento, mercancia)
            AgregarDetalleMercancia30(documento, mercancia)
        Next
    End Sub

    Private Shared Sub AgregarDocumentacionAduanera30(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each documentacionAduanera In mercancia.DocumentacionAduanera
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tDocumentacionAduanera As PdfPTable = New PdfPTable(anchoColumnas)
            tDocumentacionAduanera.SetTotalWidth(anchoColumnas)
            tDocumentacionAduanera.SpacingBefore = 5
            tDocumentacionAduanera.HorizontalAlignment = HorizontalAlignment.Left
            tDocumentacionAduanera.DefaultCell.Border = Rectangle.NO_BORDER
            tDocumentacionAduanera.DefaultCell.PaddingBottom = 0
            tDocumentacionAduanera.DefaultCell.PaddingTop = 0
            tDocumentacionAduanera.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DOCUMENTACIÓN ADUANERA" & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tDocumentacionAduanera.AddCell(cEncabezado)
            tDocumentacionAduanera.AddCell(New Phrase("Tipo documento", FUENTE_NORMAL_BOLD))
            tDocumentacionAduanera.AddCell(New Phrase(documentacionAduanera.TipoDocumento, FUENTE_NORMAL))
            If Not String.IsNullOrEmpty(documentacionAduanera.NumPedimento) Then
                tDocumentacionAduanera.AddCell(New Phrase("Número de pedimento", FUENTE_NORMAL_BOLD))
                tDocumentacionAduanera.AddCell(New Phrase(documentacionAduanera.NumPedimento, FUENTE_NORMAL))
            End If
            If Not String.IsNullOrEmpty(documentacionAduanera.IdentDocAduanero) Then
                tDocumentacionAduanera.AddCell(New Phrase("Identificador del documento", FUENTE_NORMAL_BOLD))
                tDocumentacionAduanera.AddCell(New Phrase(documentacionAduanera.IdentDocAduanero, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(documentacionAduanera.RFCImpo) Then
                tDocumentacionAduanera.AddCell(New Phrase("RFC del importador", FUENTE_NORMAL_BOLD))
                tDocumentacionAduanera.AddCell(New Phrase(documentacionAduanera.IdentDocAduanero, FUENTE_NORMAL))
            End If
            documento.Add(tDocumentacionAduanera)
        Next
    End Sub

    Private Shared Sub AgregarGuiasIdentificacion30(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each guiaIdentificacion In mercancia.GuiasIdentificacion
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tPedimentos As PdfPTable = New PdfPTable(anchoColumnas)
            tPedimentos.SetTotalWidth(anchoColumnas)
            tPedimentos.SpacingBefore = 5
            tPedimentos.HorizontalAlignment = HorizontalAlignment.Left
            tPedimentos.DefaultCell.Border = Rectangle.NO_BORDER
            tPedimentos.DefaultCell.PaddingBottom = 0
            tPedimentos.DefaultCell.PaddingTop = 0
            tPedimentos.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("GUÍA IDENTIFICACIÓN" & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tPedimentos.AddCell(cEncabezado)
            tPedimentos.AddCell(New Phrase("Número de guía", FUENTE_NORMAL_BOLD))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.NumeroGuiaIdentificacion, FUENTE_NORMAL))
            tPedimentos.AddCell(New Phrase("Descripción", FUENTE_NORMAL_BOLD))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.DescripcionGuiaIdentificacion, FUENTE_NORMAL))
            tPedimentos.AddCell(New Phrase("Peso del paquete", FUENTE_NORMAL_BOLD))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.PesoGuiaIdentificacion.ToString("F3"), FUENTE_NORMAL))
            documento.Add(tPedimentos)
        Next
    End Sub

    Private Shared Sub AgregarCantidadTransporta30(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each cantidadTransporta In mercancia.CantidadTransporta
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tCantidadTransporta As PdfPTable = New PdfPTable(anchoColumnas)
            tCantidadTransporta.SetTotalWidth(anchoColumnas)
            tCantidadTransporta.SpacingBefore = 5
            tCantidadTransporta.HorizontalAlignment = HorizontalAlignment.Left
            tCantidadTransporta.DefaultCell.Border = Rectangle.NO_BORDER
            tCantidadTransporta.DefaultCell.PaddingBottom = 0
            tCantidadTransporta.DefaultCell.PaddingTop = 0
            tCantidadTransporta.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CANTIDAD TRANSPORTA " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tCantidadTransporta.AddCell(cEncabezado)
            tCantidadTransporta.AddCell(New Phrase("Cantidad", FUENTE_NORMAL_BOLD))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.Cantidad.ToString("F6"), FUENTE_NORMAL))
            tCantidadTransporta.AddCell(New Phrase("ID origen", FUENTE_NORMAL_BOLD))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.IDOrigen, FUENTE_NORMAL))
            tCantidadTransporta.AddCell(New Phrase("ID destino", FUENTE_NORMAL_BOLD))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.IDDestino, FUENTE_NORMAL))

            If Not String.IsNullOrEmpty(cantidadTransporta.CvesTransporte) Then
                tCantidadTransporta.AddCell(New Phrase("Clave transporte", FUENTE_NORMAL_BOLD))
                tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.CvesTransporte & " - " + Catalogos.ObtenerCveTransporte(cantidadTransporta.CvesTransporte), FUENTE_NORMAL))
            End If

            tCantidadTransporta.CompleteRow()
            documento.Add(tCantidadTransporta)
        Next
    End Sub

    Private Shared Sub AgregarDetalleMercancia30(ByVal documento As Document, ByVal mercancia As Mercancia)
        If mercancia.DetalleMercancia Is Nothing Then Return
        Dim detalle As DetalleMercancia = mercancia.DetalleMercancia
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tDetalleMercancia As PdfPTable = New PdfPTable(anchoColumnas)
        tDetalleMercancia.SetTotalWidth(anchoColumnas)
        tDetalleMercancia.SpacingBefore = 5
        tDetalleMercancia.HorizontalAlignment = HorizontalAlignment.Left
        tDetalleMercancia.DefaultCell.Border = Rectangle.NO_BORDER
        tDetalleMercancia.DefaultCell.PaddingBottom = 0
        tDetalleMercancia.DefaultCell.PaddingTop = 0
        tDetalleMercancia.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DETALLE MERCANCIA", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tDetalleMercancia.AddCell(cEncabezado)
        tDetalleMercancia.AddCell(New Phrase("Unidad peso", FUENTE_NORMAL_BOLD))
        tDetalleMercancia.AddCell(New Phrase(detalle.UnidadPesoMerc, FUENTE_NORMAL))
        tDetalleMercancia.AddCell(New Phrase("Peso bruto", FUENTE_NORMAL_BOLD))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoBruto.ToString("F3"), FUENTE_NORMAL))
        tDetalleMercancia.AddCell(New Phrase("Peso neto", FUENTE_NORMAL_BOLD))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoNeto.ToString("F3"), FUENTE_NORMAL))
        tDetalleMercancia.AddCell(New Phrase("Peso tara", FUENTE_NORMAL_BOLD))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoTara.ToString("F3"), FUENTE_NORMAL))

        If detalle.NumPiezas > 0 Then
            tDetalleMercancia.AddCell(New Phrase("Número de piezas", FUENTE_NORMAL_BOLD))
            tDetalleMercancia.AddCell(New Phrase(detalle.NumPiezas.ToString(), FUENTE_NORMAL))
        End If

        tDetalleMercancia.CompleteRow()
        documento.Add(tDetalleMercancia)
    End Sub

    Private Shared Sub AgregarDomicilio30(ByVal documento As Document, ByVal domicilio As Domicilio)
        If domicilio Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tDomicilio As PdfPTable = New PdfPTable(anchoColumnas)
        tDomicilio.SetTotalWidth(anchoColumnas)
        tDomicilio.SpacingBefore = 5
        tDomicilio.HorizontalAlignment = HorizontalAlignment.Left
        tDomicilio.DefaultCell.Border = Rectangle.NO_BORDER
        tDomicilio.DefaultCell.PaddingBottom = 0
        tDomicilio.DefaultCell.PaddingTop = 0
        tDomicilio.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DOMICILIO", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tDomicilio.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(domicilio.Calle) Then
            tDomicilio.AddCell(New Phrase("Calle", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Calle, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then
            tDomicilio.AddCell(New Phrase("Número exterior", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.NumeroExterior, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then
            tDomicilio.AddCell(New Phrase("Número interior", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.NumeroInterior, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Colonia) Then
            tDomicilio.AddCell(New Phrase("Colonia", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Colonia, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Localidad) Then
            tDomicilio.AddCell(New Phrase("Localidad", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Localidad, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Referencia) Then
            tDomicilio.AddCell(New Phrase("Referencia", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Referencia, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Municipio) Then
            tDomicilio.AddCell(New Phrase("Municipio", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Municipio, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Estado) Then
            tDomicilio.AddCell(New Phrase("Estado", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Estado, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.Pais) Then
            tDomicilio.AddCell(New Phrase("Pais", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.Pais, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then
            tDomicilio.AddCell(New Phrase("Código postal", FUENTE_NORMAL_BOLD))
            tDomicilio.AddCell(New Phrase(domicilio.CodigoPostal, FUENTE_NORMAL))
        End If

        tDomicilio.CompleteRow()
        documento.Add(tDomicilio)
    End Sub

    Private Shared Sub AgregarAutoTransporte30(ByVal documento As Document, ByVal autotransporte As Autotransporte)
        If autotransporte Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tAutoTransporte As PdfPTable = New PdfPTable(anchoColumnas)
        tAutoTransporte.SetTotalWidth(anchoColumnas)
        tAutoTransporte.SpacingBefore = 5
        tAutoTransporte.HorizontalAlignment = HorizontalAlignment.Left
        tAutoTransporte.DefaultCell.Border = Rectangle.NO_BORDER
        tAutoTransporte.DefaultCell.PaddingBottom = 0
        tAutoTransporte.DefaultCell.PaddingTop = 0
        tAutoTransporte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("AUTOTRANSPORTE", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tAutoTransporte.AddCell(cEncabezado)
        tAutoTransporte.AddCell(New Phrase("Permiso SCT", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(autotransporte.PermSCT & " - " + Catalogos.ObtenerTipoPermiso(autotransporte.PermSCT), FUENTE_NORMAL))
        tAutoTransporte.AddCell(New Phrase("Núm permiso SCT", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(autotransporte.NumPermisoSCT, FUENTE_NORMAL))
        documento.Add(tAutoTransporte)
        AgregarIdentificacionVehicular30(documento, autotransporte.IdentificacionVehicular)
        AgregarSeguros30(documento, autotransporte.Seguros)
        AgregarRemolques30(documento, autotransporte.Remolques)
    End Sub

    Private Shared Sub AgregarIdentificacionVehicular30(ByVal documento As Document, ByVal identificacionVehicular As IdentificacionVehicular)
        If identificacionVehicular Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tAutoTransporte As PdfPTable = New PdfPTable(anchoColumnas)
        tAutoTransporte.SetTotalWidth(anchoColumnas)
        tAutoTransporte.SpacingBefore = 5
        tAutoTransporte.HorizontalAlignment = HorizontalAlignment.Left
        tAutoTransporte.DefaultCell.Border = Rectangle.NO_BORDER
        tAutoTransporte.DefaultCell.PaddingBottom = 0
        tAutoTransporte.DefaultCell.PaddingTop = 0
        tAutoTransporte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("IDENTIFICACIÓN VEHICULAR", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tAutoTransporte.AddCell(cEncabezado)
        tAutoTransporte.AddCell(New Phrase("Clave autotransporte", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(identificacionVehicular.ConfigVehicular & " - " + Catalogos.ObtenerConfigAutotransporte(identificacionVehicular.ConfigVehicular), FUENTE_NORMAL))
        tAutoTransporte.AddCell(New Phrase("Peso bruto", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(identificacionVehicular.PesoBrutoVehicular.ToString("F2"), FUENTE_NORMAL))
        tAutoTransporte.AddCell(New Phrase("Placa", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(identificacionVehicular.PlacaVM, FUENTE_NORMAL))
        tAutoTransporte.AddCell(New Phrase("Año", FUENTE_NORMAL_BOLD))
        tAutoTransporte.AddCell(New Phrase(identificacionVehicular.AnioModeloVM.ToString(), FUENTE_NORMAL))
        tAutoTransporte.CompleteRow()
        documento.Add(tAutoTransporte)
    End Sub

    Private Shared Sub AgregarSeguros30(ByVal documento As Document, ByVal seguros As Seguros)
        If seguros Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tSeguros As PdfPTable = New PdfPTable(anchoColumnas)
        tSeguros.SetTotalWidth(anchoColumnas)
        tSeguros.SpacingBefore = 5
        tSeguros.HorizontalAlignment = HorizontalAlignment.Left
        tSeguros.DefaultCell.Border = Rectangle.NO_BORDER
        tSeguros.DefaultCell.PaddingBottom = 0
        tSeguros.DefaultCell.PaddingTop = 0
        tSeguros.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("SEGUROS", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tSeguros.AddCell(cEncabezado)
        tSeguros.AddCell(New Phrase("Nombre aseguradora civil", FUENTE_NORMAL_BOLD))
        tSeguros.AddCell(New Phrase(seguros.AseguraRespCivil, FUENTE_NORMAL))
        tSeguros.AddCell(New Phrase("Número poliza aseguradora civil", FUENTE_NORMAL_BOLD))
        tSeguros.AddCell(New Phrase(seguros.PolizaRespCivil, FUENTE_NORMAL))

        If Not String.IsNullOrEmpty(seguros.AseguraMedAmbiente) Then
            tSeguros.AddCell(New Phrase("Nombre aseguradora medio ambiente", FUENTE_NORMAL_BOLD))
            tSeguros.AddCell(New Phrase(seguros.AseguraMedAmbiente, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(seguros.PolizaMedAmbiente) Then
            tSeguros.AddCell(New Phrase("Número poliza aseguradora medio ambiente", FUENTE_NORMAL_BOLD))
            tSeguros.AddCell(New Phrase(seguros.PolizaMedAmbiente, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(seguros.AseguraCarga) Then
            tSeguros.AddCell(New Phrase("Nombre aseguradora carga", FUENTE_NORMAL_BOLD))
            tSeguros.AddCell(New Phrase(seguros.AseguraCarga, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(seguros.PolizaCarga) Then
            tSeguros.AddCell(New Phrase("Número poliza aseguradora carga", FUENTE_NORMAL_BOLD))
            tSeguros.AddCell(New Phrase(seguros.PolizaCarga, FUENTE_NORMAL))
        End If

        If seguros.PrimaSeguro > 0 Then
            tSeguros.AddCell(New Phrase("Valor importe asegurado", FUENTE_NORMAL_BOLD))
            tSeguros.AddCell(New Phrase(seguros.PrimaSeguro.ToString("C2"), FUENTE_NORMAL))
        End If
        tSeguros.CompleteRow()

        documento.Add(tSeguros)
    End Sub

    Private Shared Sub AgregarRemolques30(ByVal documento As Document, ByVal remolques As Remolques)
        If remolques Is Nothing Then Return
        Dim contador As Integer = 0

        For Each remolque In remolques.Remolque
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tRemolques As PdfPTable = New PdfPTable(anchoColumnas)
            tRemolques.SetTotalWidth(anchoColumnas)
            tRemolques.SpacingBefore = 5
            tRemolques.HorizontalAlignment = HorizontalAlignment.Left
            tRemolques.DefaultCell.Border = Rectangle.NO_BORDER
            tRemolques.DefaultCell.PaddingBottom = 0
            tRemolques.DefaultCell.PaddingTop = 0
            tRemolques.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("REMOLQUE " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tRemolques.AddCell(cEncabezado)
            tRemolques.AddCell(New Phrase("Subtipo de remolque o semiremolque", FUENTE_NORMAL_BOLD))
            tRemolques.AddCell(New Phrase(remolque.SubTipoRem, FUENTE_NORMAL))
            tRemolques.AddCell(New Phrase("Placa", FUENTE_NORMAL_BOLD))
            tRemolques.AddCell(New Phrase(remolque.Placa, FUENTE_NORMAL))
            tRemolques.CompleteRow()
            documento.Add(tRemolques)
        Next
    End Sub

    Private Shared Sub AgregarTransporteMaritimo30(ByVal documento As Document, ByVal transporteMaritimo As TransporteMaritimo)
        If transporteMaritimo Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tTransporteMaritimo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteMaritimo.SetTotalWidth(anchoColumnas)
        tTransporteMaritimo.SpacingBefore = 5
        tTransporteMaritimo.HorizontalAlignment = HorizontalAlignment.Left
        tTransporteMaritimo.DefaultCell.Border = Rectangle.NO_BORDER
        tTransporteMaritimo.DefaultCell.PaddingBottom = 0
        tTransporteMaritimo.DefaultCell.PaddingTop = 0
        tTransporteMaritimo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE MARITIMO", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteMaritimo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteMaritimo.PermSCT) Then
            tTransporteMaritimo.AddCell(New Phrase("Permiso SCT", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.PermSCT & " - " + Catalogos.ObtenerTipoPermiso(transporteMaritimo.PermSCT), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumPermisoSCT) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. de permiso SCT", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumPermisoSCT, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreAseg) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre aseguradora", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreAseg, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumPolizaSeguro) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumPolizaSeguro, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.TipoEmbarcacion) Then
            tTransporteMaritimo.AddCell(New Phrase("Tipo de embarcación", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.TipoEmbarcacion & " - " + Catalogos.ObtenerConfigMaritima(transporteMaritimo.TipoEmbarcacion), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.Matricula) Then
            tTransporteMaritimo.AddCell(New Phrase("Matricula", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Matricula, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumeroOMI) Then
            tTransporteMaritimo.AddCell(New Phrase("Número OMI", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumeroOMI, FUENTE_NORMAL))
        End If

        If transporteMaritimo.AnioEmbarcacion > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Año de embarcación", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.AnioEmbarcacion.ToString(), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreEmbarc) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre de embarcación", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreEmbarc, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NacionalidadEmbarc) Then
            tTransporteMaritimo.AddCell(New Phrase("Nacionalidad embarcación", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NacionalidadEmbarc, FUENTE_NORMAL))
        End If

        If transporteMaritimo.UnidadesDeArqBruto > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Unidades de arqueo bruto", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.UnidadesDeArqBruto.ToString("f3"), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.TipoCarga) Then
            tTransporteMaritimo.AddCell(New Phrase("Tipo de carga", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.TipoCarga & " " + Catalogos.ObtenerTipoCarga(transporteMaritimo.TipoCarga), FUENTE_NORMAL))
        End If

        If transporteMaritimo.Eslora > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud de eslora", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Eslora.ToString("f3"), FUENTE_NORMAL))
        End If

        If transporteMaritimo.Manga > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud de manga", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Manga.ToString("f3"), FUENTE_NORMAL))
        End If

        If transporteMaritimo.Calado > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud del calado", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Calado.ToString("f3"), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.LineaNaviera) Then
            tTransporteMaritimo.AddCell(New Phrase("Linea naviera", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.LineaNaviera, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreAgenteNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre del agente naviero", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreAgenteNaviero, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumAutorizacionNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. de la autorización", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumAutorizacionNaviero, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumViaje) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. del viaje", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumViaje, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumAutorizacionNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. de conocimiento de embarque", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumConocEmbarc, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.PermisoTempNavegacion) Then
            tTransporteMaritimo.AddCell(New Phrase("Permiso temporal de navegación", FUENTE_NORMAL_BOLD))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.PermisoTempNavegacion, FUENTE_NORMAL))
        End If

        tTransporteMaritimo.CompleteRow()
        documento.Add(tTransporteMaritimo)
        AgregarContenedor30(documento, transporteMaritimo.Contenedor)
        AgregarRemolquesCCP30(documento, transporteMaritimo.RemolquesCCP)
    End Sub

    Private Shared Sub AgregarContenedor30(ByVal documento As Document, ByVal contenedor As List(Of Contenedor))
        Dim contador As Integer = 0

        For Each item In contenedor
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tContenedor As PdfPTable = New PdfPTable(anchoColumnas)
            tContenedor.SetTotalWidth(anchoColumnas)
            tContenedor.SpacingBefore = 5
            tContenedor.HorizontalAlignment = HorizontalAlignment.Left
            tContenedor.DefaultCell.Border = Rectangle.NO_BORDER
            tContenedor.DefaultCell.PaddingBottom = 0
            tContenedor.DefaultCell.PaddingTop = 0
            tContenedor.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CONTENEDOR " & contador, FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tContenedor.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoContenedor) Then
                tContenedor.AddCell(New Phrase("Tipo de contenedor", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.TipoContenedor, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.MatriculaContenedor) Then
                tContenedor.AddCell(New Phrase("Matricula del contenedor", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.MatriculaContenedor, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.NumPrecinto) Then
                tContenedor.AddCell(New Phrase("Núm del sello o precinto ", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.NumPrecinto, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.IdCCPRelacionado) Then
                tContenedor.AddCell(New Phrase("Id CPP relacionado ", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.IdCCPRelacionado, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.PlacaVMCCP) Then
                tContenedor.AddCell(New Phrase("Placa VMCCP ", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.PlacaVMCCP, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.FechaCertificacionCCP) Then
                tContenedor.AddCell(New Phrase("Fecha certificación CCP ", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.FechaCertificacionCCP.ToString(), FUENTE_NORMAL))
            End If

            tContenedor.CompleteRow()
            documento.Add(tContenedor)
        Next
    End Sub

    Private Shared Sub AgregarRemolquesCCP30(ByVal documento As Document, ByVal remolques As RemolquesCCP)
        If remolques Is Nothing Then
            Return
        End If
        Dim contador As Integer = 0

        For Each item In remolques.RemolqueCCP
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tRemolque As PdfPTable = New PdfPTable(anchoColumnas)
            tRemolque.SetTotalWidth(anchoColumnas)
            tRemolque.SpacingBefore = 5
            tRemolque.HorizontalAlignment = HorizontalAlignment.Left
            tRemolque.DefaultCell.Border = Rectangle.NO_BORDER
            tRemolque.DefaultCell.PaddingBottom = 0
            tRemolque.DefaultCell.PaddingTop = 0
            tRemolque.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("REMOLQUE " & contador, FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tRemolque.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.SubTipoRemCCP) Then
                tRemolque.AddCell(New Phrase("Clave del subtipo", FUENTE_NORMAL_BOLD))
                tRemolque.AddCell(New Phrase(item.SubTipoRemCCP, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.PlacaCCP) Then
                tRemolque.AddCell(New Phrase("Placa", FUENTE_NORMAL_BOLD))
                tRemolque.AddCell(New Phrase(item.PlacaCCP, FUENTE_NORMAL))
            End If

            tRemolque.CompleteRow()
            documento.Add(tRemolque)
        Next
    End Sub

    Private Shared Sub AgregarTransporteAereo30(ByVal documento As Document, ByVal transporteAereo As TransporteAereo)
        If transporteAereo Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {2.5, 3.3F})
        Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteAereo.SetTotalWidth(anchoColumnas)
        tTransporteAereo.SpacingBefore = 5
        tTransporteAereo.HorizontalAlignment = HorizontalAlignment.Left
        tTransporteAereo.DefaultCell.Border = Rectangle.NO_BORDER
        tTransporteAereo.DefaultCell.PaddingBottom = 0
        tTransporteAereo.DefaultCell.PaddingTop = 0
        tTransporteAereo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE AEREO", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteAereo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteAereo.PermSCT) Then
            tTransporteAereo.AddCell(New Phrase("Permiso SCT", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.PermSCT & " - " + Catalogos.ObtenerTipoPermiso(transporteAereo.PermSCT), FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumPermisoSCT) Then
            tTransporteAereo.AddCell(New Phrase("Núm. Permiso SCT", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumPermisoSCT, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.MatriculaAeronave) Then
            tTransporteAereo.AddCell(New Phrase("Matricula aeronave", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.MatriculaAeronave, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NombreAseg) Then
            tTransporteAereo.AddCell(New Phrase("Nombre de la aseguradora", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NombreAseg, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumPolizaSeguro) Then
            tTransporteAereo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumPolizaSeguro, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumeroGuia) Then
            tTransporteAereo.AddCell(New Phrase("Núm de guía", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumeroGuia, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.LugarContrato) Then
            tTransporteAereo.AddCell(New Phrase("Lugar de contrato", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.LugarContrato, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.CodigoTransportista) Then
            tTransporteAereo.AddCell(New Phrase("Código transportista", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.CodigoTransportista, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.RFCEmbarcador) Then
            tTransporteAereo.AddCell(New Phrase("RFC Embarcador", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.RFCEmbarcador, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumRegIdTribEmbarc) Then
            tTransporteAereo.AddCell(New Phrase("Num. Reg. Id. Trib. Embarcador", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumRegIdTribEmbarc, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.ResidenciaFiscalEmbarc) Then
            tTransporteAereo.AddCell(New Phrase("Residencia fiscal embarcador", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.ResidenciaFiscalEmbarc, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NombreEmbarcador) Then
            tTransporteAereo.AddCell(New Phrase("Nombre embarcador", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.ResidenciaFiscalEmbarc, FUENTE_NORMAL))
        End If
    End Sub

    Private Shared Sub AgregarTransporteFerroviario30(ByVal documento As Document, ByVal transporteFerroviario As TransporteFerroviario)
        If transporteFerroviario Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
        Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteAereo.SetTotalWidth(anchoColumnas)
        tTransporteAereo.SpacingBefore = 5
        tTransporteAereo.HorizontalAlignment = HorizontalAlignment.Left
        tTransporteAereo.DefaultCell.Border = Rectangle.NO_BORDER
        tTransporteAereo.DefaultCell.PaddingBottom = 0
        tTransporteAereo.DefaultCell.PaddingTop = 0
        tTransporteAereo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE FERROVIARIO", FUENTE_NORMAL_BOLD))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.PaddingBottom = 1
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteAereo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteFerroviario.TipoDeServicio) Then
            tTransporteAereo.AddCell(New Phrase("Tipo de servicio", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.TipoDeServicio & " - ", FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.TipoDeTrafico) Then
            tTransporteAereo.AddCell(New Phrase("Tipo de trafico", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.TipoDeTrafico, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.NombreAseg) Then
            tTransporteAereo.AddCell(New Phrase("Nombre de la aseguradora", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.NombreAseg, FUENTE_NORMAL))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.NumPolizaSeguro) Then
            tTransporteAereo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_NORMAL_BOLD))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.NumPolizaSeguro, FUENTE_NORMAL))
        End If

        tTransporteAereo.CompleteRow()
        documento.Add(tTransporteAereo)
        AgregarDerechosDePaso30(documento, transporteFerroviario.DerechosDePaso)
        AgregarCarro30(documento, transporteFerroviario.Carro)
    End Sub

    Private Shared Sub AgregarDerechosDePaso30(ByVal documento As Document, ByVal derechosDePaso As List(Of DerechosDePaso))
        Dim contador As Integer = 0

        For Each item In derechosDePaso
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
            tTransporteAereo.SetTotalWidth(anchoColumnas)
            tTransporteAereo.SpacingBefore = 5
            tTransporteAereo.HorizontalAlignment = HorizontalAlignment.Left
            tTransporteAereo.DefaultCell.Border = Rectangle.NO_BORDER
            tTransporteAereo.DefaultCell.PaddingBottom = 0
            tTransporteAereo.DefaultCell.PaddingTop = 0
            tTransporteAereo.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DERECHO DE PASO " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTransporteAereo.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoDerechoDePaso) Then
                tTransporteAereo.AddCell(New Phrase("Tipo derecho de paso", FUENTE_NORMAL_BOLD))
                tTransporteAereo.AddCell(New Phrase(item.TipoDerechoDePaso & " - ", FUENTE_NORMAL))
            End If

            If item.KilometrajePagado > 0 Then
                tTransporteAereo.AddCell(New Phrase("Kilometraje pagado", FUENTE_NORMAL_BOLD))
                tTransporteAereo.AddCell(New Phrase(item.KilometrajePagado.ToString("f2"), FUENTE_NORMAL))
            End If
        Next
    End Sub

    Private Shared Sub AgregarCarro30(ByVal documento As Document, ByVal carro As List(Of Carro))
        Dim contador As Integer = 0

        For Each item In carro
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tCarro As PdfPTable = New PdfPTable(anchoColumnas)
            tCarro.SetTotalWidth(anchoColumnas)
            tCarro.SpacingBefore = 5
            tCarro.HorizontalAlignment = HorizontalAlignment.Left
            tCarro.DefaultCell.Border = Rectangle.NO_BORDER
            tCarro.DefaultCell.PaddingBottom = 0
            tCarro.DefaultCell.PaddingTop = 0
            tCarro.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CARRO " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tCarro.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoCarro) Then
                tCarro.AddCell(New Phrase("Tipo de carro", FUENTE_NORMAL_BOLD))
                tCarro.AddCell(New Phrase(item.TipoCarro & " - ", FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.MatriculaCarro) Then
                tCarro.AddCell(New Phrase("Matricula carro", FUENTE_NORMAL_BOLD))
                tCarro.AddCell(New Phrase(item.MatriculaCarro, FUENTE_NORMAL))
            End If

            If Not String.IsNullOrEmpty(item.GuiaCarro) Then
                tCarro.AddCell(New Phrase("Guia carro", FUENTE_NORMAL_BOLD))
                tCarro.AddCell(New Phrase(item.MatriculaCarro, FUENTE_NORMAL))
            End If

            If item.ToneladasNetasCarro > 0 Then
                tCarro.AddCell(New Phrase("Toneladas netas carro", FUENTE_NORMAL_BOLD))
                tCarro.AddCell(New Phrase(item.ToneladasNetasCarro.ToString("F3"), FUENTE_NORMAL))
            End If

            tCarro.CompleteRow()
            documento.Add(tCarro)
            AgregarContenedor30(documento, item.Contenedor)
        Next
    End Sub

    Private Shared Sub AgregarContenedor30(ByVal documento As Document, ByVal contenedor As List(Of CarroContenedor))
        Dim contador As Integer = 0

        For Each item In contenedor
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {ANCHO_COLUMNA_1, ANCHO_COLUMNA_2})
            Dim tContenedor As PdfPTable = New PdfPTable(anchoColumnas)
            tContenedor.SetTotalWidth(anchoColumnas)
            tContenedor.SpacingBefore = 5
            tContenedor.HorizontalAlignment = HorizontalAlignment.Left
            tContenedor.DefaultCell.Border = Rectangle.NO_BORDER
            tContenedor.DefaultCell.PaddingBottom = 0
            tContenedor.DefaultCell.PaddingTop = 0
            tContenedor.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CONTENEDOR " & contador.ToString(), FUENTE_NORMAL_BOLD))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.PaddingBottom = 1
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tContenedor.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoContenedor) Then
                tContenedor.AddCell(New Phrase("Tipo contenedor", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.TipoContenedor & " - ", FUENTE_NORMAL))
            End If

            If item.PesoContenedorVacio > 0 Then
                tContenedor.AddCell(New Phrase("PesoContenedorVacio", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.PesoContenedorVacio.ToString("F3"), FUENTE_NORMAL))
            End If

            If item.PesoNetoMercancia > 0 Then
                tContenedor.AddCell(New Phrase("Peso neto mercancia", FUENTE_NORMAL_BOLD))
                tContenedor.AddCell(New Phrase(item.PesoNetoMercancia.ToString("F3"), FUENTE_NORMAL))
            End If

            tContenedor.CompleteRow()
            documento.Add(tContenedor)
        Next
    End Sub
#End Region
    Private Shared Function cmAFloat(ByVal centimetro As Single) As Single
        Return centimetro * 28.3464565F
    End Function
    Private Shared Function cmAFloat(ByVal centimetro As Single()) As Single()
        For i As Integer = 0 To centimetro.Length - 1
            centimetro(i) = centimetro(i) * 28.3464565F
        Next

        Return centimetro
    End Function
End Class
