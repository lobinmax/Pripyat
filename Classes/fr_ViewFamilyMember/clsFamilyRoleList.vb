Public Class clsFamilyRoleList
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
        ' Выборка семейных ролей
        SelectQueryData(
                        "FamilyRole",
                        "SELECT * FROM vPr_FamilyRoles",
                        "GetFamilyRole"
                        )
        Dim FamilyRoleList As New Collection
        ' Заполнение FamilyRoleList донными из iDataSet.Tables("FamilyRole")
        For Each r As DataRow In iDataSet.Tables("FamilyRole").Rows
            FamilyRoleList.Add(r.Item("Name"))
        Next

        iDataAdapter.Dispose()                                                  ' Освобождаем ресурсы от DataAdapter
        iDataSet.Dispose()                                                      ' Освобождаем ресурсы от DataSet
        SqlCom.Dispose()                                                        ' Освобождаем ресурсы от SqlCom
        iDataSet.Tables("FamilyRole").DataSet.Tables.Remove("FamilyRole")       ' Удаляем FamilyRole из DataSet
        Return FamilyRoleList
    End Function
End Class
