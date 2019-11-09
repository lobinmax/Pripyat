Imports System.Globalization
Imports System.ComponentModel
' Конвертер True/False в Да/Нет
Public Class clsYesNoConverter
    Inherits BooleanConverter

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
        Return If(DirectCast(value, Boolean), "Да", "Нет")
    End Function

    Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Return DirectCast(value, String) = "Нет"
    End Function
End Class
