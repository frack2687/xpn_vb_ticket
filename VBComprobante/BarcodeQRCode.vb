Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports iTextSharp.text
Imports iTextSharp.text.pdf.qrcode
Imports iTextSharp.text.pdf.codec

''' <summary>
''' Class rewritted to Convert ByteMatrix to BMP image by rewritting GetImage method
'''from ITextSharp 
'''author: Luis Claudio Souza
''' </summary>
''' <remarks></remarks>


'namespace iTextSharp.text.pdf{

'''
'''A QRCode implementation based on the zxing code.
''' @author Paulo Soares
''' @since 5.0.2

Public Class BarcodeQRCode1
    Private bm As ByteMatrix

    '''
    '''* Creates the QR barcode. The barcode is always created with the smallest possible     size and is then stretched
    '''* to the width and height given. Set the width and height to 1 to get an unscaled barcode.
    '''* @param content the text to be encoded
    ''' * @param width the barcode width
    '''  * @param height the barcode height
    '''   * @param hints modifiers to change the way the barcode is create. They can be EncodeHintType.ERROR_CORRECTION
    '''   * and EncodeHintType.CHARACTER_SET. For EncodeHintType.ERROR_CORRECTION the values can be ErrorCorrectionLevel.L, M, Q, H.
    '''   * For EncodeHintType.CHARACTER_SET the values are strings and can be Cp437, Shift_JIS and ISO-8859-1 to ISO-8859-16. The default value is
    '''   * ISO-8859-1.
    '''   * @throws WriterException
    '''    */
    Public Sub New(ByVal content As String, ByVal width As Integer, ByVal height As Integer, ByVal hints As IDictionary(Of EncodeHintType, Object))
        Dim qc As QRCodeWriter = New QRCodeWriter()
        bm = qc.Encode(content, width, height, hints)
    End Sub

    Private Function GetBitMatrix() As Byte()

        Dim width As Integer = bm.GetWidth()
        Dim height As Integer = bm.GetHeight()
        Dim stride As Integer = (width + 7) / 8
        Dim b As Byte() = New Byte(stride * height - 1) {}
        Dim mt As SByte()() = bm.GetArray()
        For y As Integer = 0 To height - 1
            Dim line As SByte() = mt(y)
            For x As Integer = 0 To width - 1
                If (line(x) <> 0) Then
                    Dim offset As Integer = stride * y + x / 8
                    b(offset) = b(offset) Or Convert.ToByte("0x80") >> (x Mod 8)
                End If
            Next
        Next

        Return b
    End Function

    '''/** Gets an Image with the barcode.
    '''* @return the barcode Image
    '''* @throws BadElementException on error
    '''*/

    Public Function GetImage() As System.Drawing.Image
        Dim imgNew As SByte()() = bm.GetArray()
        Dim bmp1 As Bitmap = New Bitmap(bm.GetWidth(), bm.GetHeight())
        Dim g1 As Graphics = Graphics.FromImage(bmp1)
        g1.Clear(Color.White)
        For i As Integer = 0 To imgNew.Length - 1
            For j As Integer = 0 To imgNew(i).Length - 1
                If imgNew(j)(i) = 0 Then g1.FillRectangle(Brushes.Black, i, j, 1, 1) Else g1.FillRectangle(Brushes.White, i, j, 1, 1)
            Next
        Next
        bmp1.Save(".\QREncode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        Return bmp1

    End Function

    'Public Function GetImage() As System.Drawing.Image
    '    Dim width As Integer = bm.GetWidth()
    '    Dim height As Integer = bm.GetHeight()
    '    Dim pix(width * height) As Integer
    '    Dim mt()() As SByte = bm.GetArray()

    '    For y = 0 To height - 1
    '        Dim line As SByte() = mt(y)
    '        For x = 0 To width - 1
    '              pix(y*width + x) = If (line(x) = 0)  Then f else g
    '        Next
    '    Next

    '    Dim imgNew()() As SByte = bm.GetArray()
    '    Dim bmp1 As Bitmap = New Bitmap(bm.GetWidth(), bm.GetHeight())
    '    Dim g1 As Graphics = Graphics.FromImage(bmp1)
    '    g1.Clear(Color.White)
    '    For i = 0 To imgNew.Length - 1 Step 1
    '        For j = 0 To imgNew(i).Length - 1 Step 1
    '            If imgNew(j)(i) = 0 Then g1.FillRectangle(Brushes.Black, i, j, 1, 1) Else g1.FillRectangle(Brushes.White, i, j, 1, 1)
    '        Next
    '    Next
    '    Return bmp1
    '    'bmp1.Save("D:\\QREncode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
    'End Function


End Class
