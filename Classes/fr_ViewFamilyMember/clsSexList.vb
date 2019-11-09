Public Class clsSexList
    Inherits System.ComponentModel.StringConverter

    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function

    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Function myList() As Collections.IList
        Dim SexList As New Collection
        With SexList
            .Add("Женский")
            .Add("Мужской")
        End With
        Return SexList
    End Function
End Class