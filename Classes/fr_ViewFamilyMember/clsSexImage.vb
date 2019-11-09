Imports System.ComponentModel
Imports System.Drawing.Design

Public Class clsSexImage
    Inherits UITypeEditor

    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True ' iDataSet.Tables("FamilyMember").Rows(My.Settings.CurrentRowDataGridView).Item("MaleAFemale")
    End Function

    Public Overloads Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)
        'Dim whatImage As String = e.Value.ToString()
        Dim bmp As Bitmap = My.Resources.ResourceManager.GetObject(e.Value.ToString())
        Dim destRect As Rectangle = e.Bounds
        bmp.MakeTransparent()
        e.Graphics.DrawImage(bmp, destRect)
    End Sub
End Class