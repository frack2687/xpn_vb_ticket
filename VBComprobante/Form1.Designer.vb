<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.checkAbrir = New System.Windows.Forms.CheckBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.btnCrearPDF = New System.Windows.Forms.Button()
        Me.btnBuscarImagen = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btnQuitarImagen = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tbDireccionPDF = New System.Windows.Forms.TextBox()
        Me.btnGuardarEn = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tbRutaXML = New System.Windows.Forms.TextBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tbRutaCarpetaPDF = New System.Windows.Forms.TextBox()
        Me.btnCarpetaPDF = New System.Windows.Forms.Button()
        Me.label8 = New System.Windows.Forms.Label()
        Me.tbRutaCarpetaXML = New System.Windows.Forms.TextBox()
        Me.btnCarpetaXML = New System.Windows.Forms.Button()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbTicketRutaXML = New System.Windows.Forms.TextBox()
        Me.btnTicketBuscarXML = New System.Windows.Forms.Button()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.panel2.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'checkAbrir
        '
        Me.checkAbrir.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.checkAbrir.AutoSize = True
        Me.checkAbrir.BackColor = System.Drawing.Color.White
        Me.checkAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkAbrir.ForeColor = System.Drawing.Color.Black
        Me.checkAbrir.Location = New System.Drawing.Point(357, 541)
        Me.checkAbrir.Name = "checkAbrir"
        Me.checkAbrir.Size = New System.Drawing.Size(209, 19)
        Me.checkAbrir.TabIndex = 22
        Me.checkAbrir.Text = "Abrir archivo despues de convertir"
        Me.checkAbrir.UseVisualStyleBackColor = False
        '
        'label9
        '
        Me.label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.label9.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.ForeColor = System.Drawing.Color.White
        Me.label9.Location = New System.Drawing.Point(21, 26)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(267, 65)
        Me.label9.TabIndex = 20
        Me.label9.Text = "XAP 2022"
        Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCrearPDF
        '
        Me.btnCrearPDF.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCrearPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.btnCrearPDF.FlatAppearance.BorderSize = 0
        Me.btnCrearPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrearPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearPDF.ForeColor = System.Drawing.Color.White
        Me.btnCrearPDF.Location = New System.Drawing.Point(35, 567)
        Me.btnCrearPDF.Name = "btnCrearPDF"
        Me.btnCrearPDF.Size = New System.Drawing.Size(532, 50)
        Me.btnCrearPDF.TabIndex = 16
        Me.btnCrearPDF.Text = "&Generar archivo"
        Me.btnCrearPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnCrearPDF.UseVisualStyleBackColor = False
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBuscarImagen.FlatAppearance.BorderSize = 0
        Me.btnBuscarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarImagen.ForeColor = System.Drawing.Color.White
        Me.btnBuscarImagen.Location = New System.Drawing.Point(57, 38)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(90, 27)
        Me.btnBuscarImagen.TabIndex = 5
        Me.btnBuscarImagen.Text = "Buscar i&magen"
        Me.btnBuscarImagen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnBuscarImagen.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.White
        Me.panel2.Controls.Add(Me.btnQuitarImagen)
        Me.panel2.Controls.Add(Me.label4)
        Me.panel2.Controls.Add(Me.btnBuscarImagen)
        Me.panel2.Controls.Add(Me.pbLogo)
        Me.panel2.Location = New System.Drawing.Point(357, 26)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(209, 234)
        Me.panel2.TabIndex = 17
        '
        'btnQuitarImagen
        '
        Me.btnQuitarImagen.BackColor = System.Drawing.Color.Transparent
        Me.btnQuitarImagen.BackgroundImage = Global.XPN.My.Resources.Resources.icons8_delete_15
        Me.btnQuitarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnQuitarImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuitarImagen.FlatAppearance.BorderSize = 0
        Me.btnQuitarImagen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnQuitarImagen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.btnQuitarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitarImagen.Location = New System.Drawing.Point(146, 86)
        Me.btnQuitarImagen.Name = "btnQuitarImagen"
        Me.btnQuitarImagen.Size = New System.Drawing.Size(28, 23)
        Me.btnQuitarImagen.TabIndex = 9
        Me.btnQuitarImagen.UseVisualStyleBackColor = False
        Me.btnQuitarImagen.Visible = False
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.label4.Location = New System.Drawing.Point(17, 10)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(167, 20)
        Me.label4.TabIndex = 8
        Me.label4.Text = "Logo de la empresa"
        '
        'pbLogo
        '
        Me.pbLogo.BackgroundImage = Global.XPN.My.Resources.Resources.icons8_picture_100
        Me.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLogo.Location = New System.Drawing.Point(32, 85)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(143, 124)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl1.ItemSize = New System.Drawing.Size(118, 27)
        Me.tabControl1.Location = New System.Drawing.Point(32, 266)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(541, 269)
        Me.tabControl1.TabIndex = 19
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.panel1)
        Me.tabPage1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabPage1.Location = New System.Drawing.Point(4, 31)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(533, 234)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Conversión de un archivo"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.tbDireccionPDF)
        Me.panel1.Controls.Add(Me.btnGuardarEn)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.tbRutaXML)
        Me.panel1.Controls.Add(Me.btnExaminar)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.Location = New System.Drawing.Point(3, 3)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(527, 228)
        Me.panel1.TabIndex = 0
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.label3.Location = New System.Drawing.Point(11, 12)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(86, 15)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Ubicaciones"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(22, 137)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(227, 15)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Guardar documento en formato (.pdf) en"
        '
        'tbDireccionPDF
        '
        Me.tbDireccionPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDireccionPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDireccionPDF.Location = New System.Drawing.Point(25, 163)
        Me.tbDireccionPDF.Name = "tbDireccionPDF"
        Me.tbDireccionPDF.Size = New System.Drawing.Size(489, 21)
        Me.tbDireccionPDF.TabIndex = 5
        '
        'btnGuardarEn
        '
        Me.btnGuardarEn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarEn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardarEn.FlatAppearance.BorderSize = 0
        Me.btnGuardarEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarEn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarEn.ForeColor = System.Drawing.Color.White
        Me.btnGuardarEn.Location = New System.Drawing.Point(414, 194)
        Me.btnGuardarEn.Name = "btnGuardarEn"
        Me.btnGuardarEn.Size = New System.Drawing.Size(100, 27)
        Me.btnGuardarEn.TabIndex = 7
        Me.btnGuardarEn.Text = "Guar&dar en"
        Me.btnGuardarEn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnGuardarEn.UseVisualStyleBackColor = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(22, 40)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(338, 15)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Ruta del Comprobante Fiscal Dígital (CFDI) en formato (.xml)"
        '
        'tbRutaXML
        '
        Me.tbRutaXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRutaXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRutaXML.Location = New System.Drawing.Point(25, 69)
        Me.tbRutaXML.Name = "tbRutaXML"
        Me.tbRutaXML.Size = New System.Drawing.Size(489, 21)
        Me.tbRutaXML.TabIndex = 2
        '
        'btnExaminar
        '
        Me.btnExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExaminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnExaminar.FlatAppearance.BorderSize = 0
        Me.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExaminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar.ForeColor = System.Drawing.Color.White
        Me.btnExaminar.Location = New System.Drawing.Point(414, 100)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(100, 27)
        Me.btnExaminar.TabIndex = 4
        Me.btnExaminar.Text = "&Elegir"
        Me.btnExaminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnExaminar.UseVisualStyleBackColor = False
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.panel3)
        Me.tabPage2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPage2.Location = New System.Drawing.Point(4, 31)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(533, 234)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Conversión por carpeta"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.White
        Me.panel3.Controls.Add(Me.label6)
        Me.panel3.Controls.Add(Me.label7)
        Me.panel3.Controls.Add(Me.tbRutaCarpetaPDF)
        Me.panel3.Controls.Add(Me.btnCarpetaPDF)
        Me.panel3.Controls.Add(Me.label8)
        Me.panel3.Controls.Add(Me.tbRutaCarpetaXML)
        Me.panel3.Controls.Add(Me.btnCarpetaXML)
        Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel3.Location = New System.Drawing.Point(3, 3)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(527, 228)
        Me.panel3.TabIndex = 1
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.label6.Location = New System.Drawing.Point(11, 12)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(86, 15)
        Me.label6.TabIndex = 7
        Me.label6.Text = "Ubicaciones"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.Black
        Me.label7.Location = New System.Drawing.Point(22, 137)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(364, 15)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Ruta de la carpeta donde guardarpan los CFDI´s en formato (.pdf)"
        '
        'tbRutaCarpetaPDF
        '
        Me.tbRutaCarpetaPDF.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRutaCarpetaPDF.Location = New System.Drawing.Point(25, 163)
        Me.tbRutaCarpetaPDF.Name = "tbRutaCarpetaPDF"
        Me.tbRutaCarpetaPDF.Size = New System.Drawing.Size(483, 25)
        Me.tbRutaCarpetaPDF.TabIndex = 5
        '
        'btnCarpetaPDF
        '
        Me.btnCarpetaPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCarpetaPDF.FlatAppearance.BorderSize = 0
        Me.btnCarpetaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarpetaPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarpetaPDF.ForeColor = System.Drawing.Color.White
        Me.btnCarpetaPDF.Location = New System.Drawing.Point(408, 194)
        Me.btnCarpetaPDF.Name = "btnCarpetaPDF"
        Me.btnCarpetaPDF.Size = New System.Drawing.Size(100, 27)
        Me.btnCarpetaPDF.TabIndex = 7
        Me.btnCarpetaPDF.Text = "Guar&dar en"
        Me.btnCarpetaPDF.UseVisualStyleBackColor = False
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.Black
        Me.label8.Location = New System.Drawing.Point(22, 43)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(335, 15)
        Me.label8.TabIndex = 3
        Me.label8.Text = "Ruta de la carpeta contenedora  de CFDI´s en formato (.xml)"
        '
        'tbRutaCarpetaXML
        '
        Me.tbRutaCarpetaXML.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRutaCarpetaXML.Location = New System.Drawing.Point(25, 69)
        Me.tbRutaCarpetaXML.Name = "tbRutaCarpetaXML"
        Me.tbRutaCarpetaXML.Size = New System.Drawing.Size(483, 25)
        Me.tbRutaCarpetaXML.TabIndex = 2
        '
        'btnCarpetaXML
        '
        Me.btnCarpetaXML.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCarpetaXML.FlatAppearance.BorderSize = 0
        Me.btnCarpetaXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarpetaXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarpetaXML.ForeColor = System.Drawing.Color.White
        Me.btnCarpetaXML.Location = New System.Drawing.Point(408, 100)
        Me.btnCarpetaXML.Name = "btnCarpetaXML"
        Me.btnCarpetaXML.Size = New System.Drawing.Size(100, 27)
        Me.btnCarpetaXML.TabIndex = 4
        Me.btnCarpetaXML.Text = "&Elegir"
        Me.btnCarpetaXML.UseVisualStyleBackColor = False
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.Panel4)
        Me.tabPage3.Location = New System.Drawing.Point(4, 31)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(533, 234)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Ticket"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.ComboBox1)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.tbTicketRutaXML)
        Me.Panel4.Controls.Add(Me.btnTicketBuscarXML)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(533, 234)
        Me.Panel4.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(25, 163)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(483, 23)
        Me.ComboBox1.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(11, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Ubicaciones"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(22, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(234, 15)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Impresora en donde se imprimirá el ticket"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(22, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(338, 15)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Ruta del Comprobante Fiscal Dígital (CFDI) en formato (.xml)"
        '
        'tbTicketRutaXML
        '
        Me.tbTicketRutaXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTicketRutaXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTicketRutaXML.Location = New System.Drawing.Point(25, 72)
        Me.tbTicketRutaXML.Name = "tbTicketRutaXML"
        Me.tbTicketRutaXML.Size = New System.Drawing.Size(495, 21)
        Me.tbTicketRutaXML.TabIndex = 2
        '
        'btnTicketBuscarXML
        '
        Me.btnTicketBuscarXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTicketBuscarXML.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnTicketBuscarXML.FlatAppearance.BorderSize = 0
        Me.btnTicketBuscarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTicketBuscarXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicketBuscarXML.ForeColor = System.Drawing.Color.White
        Me.btnTicketBuscarXML.Location = New System.Drawing.Point(420, 100)
        Me.btnTicketBuscarXML.Name = "btnTicketBuscarXML"
        Me.btnTicketBuscarXML.Size = New System.Drawing.Size(100, 27)
        Me.btnTicketBuscarXML.TabIndex = 4
        Me.btnTicketBuscarXML.Text = "&Elegir"
        Me.btnTicketBuscarXML.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnTicketBuscarXML.UseVisualStyleBackColor = False
        '
        'label10
        '
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label10.Location = New System.Drawing.Point(29, 100)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(259, 84)
        Me.label10.TabIndex = 21
        Me.label10.Text = "Convertidor de archivos xml a pdf para la version 3.3 y 4.0 de Cfdis" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'label5
        '
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.DimGray
        Me.label5.Location = New System.Drawing.Point(30, 184)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(258, 61)
        Me.label5.TabIndex = 18
        Me.label5.Text = "¿Dudas o comentarios?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "frack2687@hotmail.com |  227 109 5397" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Versión 2.1-2019"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(605, 632)
        Me.Controls.Add(Me.checkAbrir)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.btnCrearPDF)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar archivo pdf"
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents checkAbrir As System.Windows.Forms.CheckBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnCrearPDF As System.Windows.Forms.Button
    Private WithEvents btnBuscarImagen As System.Windows.Forms.Button
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents btnQuitarImagen As System.Windows.Forms.Button
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents pbLogo As System.Windows.Forms.PictureBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents tbDireccionPDF As System.Windows.Forms.TextBox
    Private WithEvents btnGuardarEn As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbRutaXML As System.Windows.Forms.TextBox
    Private WithEvents btnExaminar As System.Windows.Forms.Button
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents panel3 As System.Windows.Forms.Panel
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tbRutaCarpetaPDF As System.Windows.Forms.TextBox
    Private WithEvents btnCarpetaPDF As System.Windows.Forms.Button
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents tbRutaCarpetaXML As System.Windows.Forms.TextBox
    Private WithEvents btnCarpetaXML As System.Windows.Forms.Button
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents tbTicketRutaXML As System.Windows.Forms.TextBox
    Private WithEvents btnTicketBuscarXML As System.Windows.Forms.Button

End Class
