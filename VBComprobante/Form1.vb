Imports System.IO
Imports System.Drawing.Printing
Imports System.Xml
Public Class Form1
    Dim rutaImagen As String = String.Empty
    Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
        Dim open = New System.Windows.Forms.OpenFileDialog()
        open.Filter = "Imagen JPG (*.jpg;*.jpeg;*.jpe)|*.jpg;*.jpeg;*.jpe |PNG (*.png)|*.png |Archivo de mapa de bits(*.bmp)|*.bmp | Todos los formatos |*.jpg;*.jpeg;*.jpe;*.png;*.bmp"
        open.FilterIndex = 4
        If (open.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        rutaImagen = open.FileName
        pbLogo.BackgroundImage = Image.FromFile(open.FileName)
        btnQuitarImagen.Visible = True
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim open = New OpenFileDialog()
        open.Filter = "Archivo XML (*.xml)|*.xml"
        open.FilterIndex = 4
        If (open.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        tbRutaXML.Text = open.FileName
        tbDireccionPDF.Text = Path.ChangeExtension(open.FileName, ".pdf")
    End Sub

    Private Sub btnGuardarEn_BindingContextChanged(sender As Object, e As EventArgs) Handles btnGuardarEn.BindingContextChanged

    End Sub

    Private Sub btnGuardarEn_Click(sender As Object, e As EventArgs) Handles btnGuardarEn.Click
        Dim guardar = New SaveFileDialog()
        guardar.Filter = "Archivo XML (*.pdf)|*.pdf"
        guardar.FilterIndex = 4
        If (guardar.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        tbDireccionPDF.Text = guardar.FileName
    End Sub

    Private Sub btnCrearPDF_Click(sender As Object, e As EventArgs) Handles btnCrearPDF.Click
        If (tabControl1.SelectedTab.Name = "tabPage1") Then
            'DocumentoPDF.CreaPDF crearPDF = new DocumentoPDF.CreaPDF(tbRutaXML.Text, Path.GetTempFileName() + ".pdf",pictureBox1.Image);  
            GenerarPDF.Generar(tbRutaXML.Text.Trim(), tbDireccionPDF.Text.Trim(), rutaImagen, checkAbrir.Checked)
        ElseIf (tabControl1.SelectedTab.Name = "tabPage2") Then
            Cursor = Cursors.WaitCursor
            Dim di As DirectoryInfo = New DirectoryInfo(tbRutaCarpetaXML.Text)
            Dim nuevaRuta As String
            For Each fi In di.GetFiles("*.xml")
                nuevaRuta = tbRutaCarpetaPDF.Text + "\\" + fi.Name.Replace(".xml", ".pdf")
                GenerarPDF.Generar(fi.FullName, nuevaRuta, rutaImagen, checkAbrir.Checked)
            Next
            Cursor = Cursors.Arrow
        ElseIf (tabControl1.SelectedTab.Name = "tabPage3") Then
            PrintTicket.Print(LeerXML.ObtenerComprobante(tbTicketRutaXML.Text.Trim()), ComboBox1.Text, rutaImagen)
        Else
            MessageBox.Show("No se ha seleccionado una pestaña")
        End If
    End Sub

    Private Sub btnCarpetaXML_Click(sender As Object, e As EventArgs) Handles btnCarpetaXML.Click
        Dim guardar = New FolderBrowserDialog()
        guardar.RootFolder = System.Environment.SpecialFolder.Desktop
        guardar.ShowNewFolderButton = False
        guardar.Description = "Selecciona la carpeta contenedora de archivos en formato XML"
        If (guardar.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        tbRutaCarpetaXML.Text = guardar.SelectedPath
        tbRutaCarpetaXML.Focus()
    End Sub

    Private Sub btnCarpetaPDF_Click(sender As Object, e As EventArgs) Handles btnCarpetaPDF.Click
        Dim guardar = New FolderBrowserDialog()
        guardar.RootFolder = System.Environment.SpecialFolder.Desktop
        guardar.ShowNewFolderButton = False
        guardar.Description = "Selecciona la carpeta donde se almacenarán los nuevos archivos en formato PDF"
        If (guardar.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        tbRutaCarpetaPDF.Text = guardar.SelectedPath
    End Sub

    Private Sub btnQuitarImagen_Click(sender As Object, e As EventArgs) Handles btnQuitarImagen.Click
        rutaImagen = String.Empty
        pbLogo.BackgroundImage = Nothing
        btnQuitarImagen.Visible = False
    End Sub

    Private Sub btnTicketBuscarXML_Click(sender As Object, e As EventArgs) Handles btnTicketBuscarXML.Click
        Dim open = New OpenFileDialog()
        open.Filter = "Archivo XML (*.xml)|*.xml"
        open.FilterIndex = 4
        If (open.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        tbTicketRutaXML.Text = open.FileName
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        For i As Integer = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            Dim printer = System.Drawing.Printing.PrinterSettings.InstalledPrinters(i)
            ComboBox1.Items.Add(printer)
            Dim printDoc As PrintDocument = New PrintDocument()
            If (printDoc.PrinterSettings.IsDefaultPrinter) Then
                ComboBox1.Text = printDoc.PrinterSettings.PrinterName
            End If
        Next

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
