Imports System.ComponentModel
Imports System.Drawing.Design

Public Class clsFamilyMember
    Public _SurName As String                   ' Фамилия
    Public _Name As String                      ' Имя
    Public _Patronymic As String                ' Отчество
    Public _MaleAFemale As String               ' Пол
    Public _DateOfBirth As New DateTime         ' Дата рождения
    Public _BirthPlace As String                ' Место рождения
    Public _RoleName As String                  ' Семейная роль
    Public _ShareOwner As Boolean               ' Участник долевой собственности
    Public _DtBegin As New DateTime             ' Прописан
    Public _RegistrAddress As String            ' Адрес прописки
    Public _DtClosed As New DateTime            ' Выписан
    Public _Passport As String                  ' Данные паспорт
    Public _PassportSeries As String            ' Серия
    Public _PassportNumber As String            ' Номер
    Public _PassportDate As New DateTime        ' Дата выдачи
    Public _PassportSubunit As String           ' Кем выдан
    Public _PassportSubunitCode As String       ' Код подразделения
    Public _DateHistoryChange As New DateTime   ' Дата изменения в истории абонента

    <Category("Данные абонента"), _
     DisplayName("Фамилия")>
    Public Property SurName() As String
        Get 
        End Get
        Set(ByVal value As String)
            _SurName = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Имя")>
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Отчество")>
    Public Property Patronymic() As String
        Get
            Return _Patronymic
        End Get
        Set(ByVal value As String)
            _Patronymic = value
        End Set
    End Property

    <TypeConverter(GetType(clsSexList)), DisplayName("Пол"),
    Category("Данные абонента"), Editor(GetType(clsSexImage),
    GetType(UITypeEditor))>
    Public Property MaleAFemale() As String
        Get
            Return _MaleAFemale
        End Get
        Set(ByVal value As String)
            _MaleAFemale = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Дата рождения")>
    Public Property DateOfBirth() As DateTime
        Get
            Return _DateOfBirth
        End Get
        Set(ByVal value As DateTime)
            _DateOfBirth = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Место рождения")>
    Public Property BirthPlace() As String
        Get
            Return _BirthPlace
        End Get
        Set(ByVal value As String)
            _BirthPlace = value
        End Set
    End Property

    <TypeConverter(GetType(clsFamilyRoleList)), _
     Category("Данные абонента"), _
     DisplayName("Семейная роль")>
    Public Property RoleName() As String
        Get
            Return _RoleName
        End Get
        Set(ByVal value As String)
            _RoleName = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Участник долевой собственности"), _
     TypeConverter(GetType(clsYesNoConverter))>
    Public Property ShareOwner() As Boolean
        Get
            Return _ShareOwner
        End Get
        Set(ByVal value As Boolean)
            _ShareOwner = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Дата регистрации")>
    Public Property DtBegin() As DateTime
        Get
            Return _DtBegin
        End Get
        Set(ByVal value As DateTime)
            _DtBegin = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Адрес регистрации")>
    Public Property RegistrAddress() As String
        Get
            Return _RegistrAddress
        End Get
        Set(ByVal value As String)
            _RegistrAddress = value
        End Set
    End Property

    <Category("Данные абонента"), _
     DisplayName("Дата снятия регистрации")>
    Public Property DtClosed() As DateTime
        Get
            Return _DtClosed
        End Get
        Set(ByVal value As DateTime)
            _DtClosed = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Паспорт")>
    Public Property Passport() As String
        Get
            Return _Passport
        End Get
        Set(ByVal value As String)
            _Passport = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Серия")>
    Public Property PassportSeries() As String
        Get
            Return _PassportSeries
        End Get
        Set(ByVal value As String)
            _PassportSeries = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Номер")>
    Public Property PassportNumber() As String
        Get
            Return _PassportNumber
        End Get
        Set(ByVal value As String)
            _PassportNumber = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Дата выдачи")>
    Public Property PassportDate() As DateTime
        Get
            Return _PassportDate
        End Get
        Set(ByVal value As DateTime)
            _PassportDate = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Кем выдан")>
    Public Property PassportSubunit() As String
        Get
            Return _PassportSubunit
        End Get
        Set(ByVal value As String)
            _PassportSubunit = value
        End Set
    End Property

    <Category("Паспортные данные абонента"), _
     DisplayName("Код подразделения")>
    Public Property PassportSubunitCode() As String
        Get
            Return _PassportSubunitCode
        End Get
        Set(ByVal value As String)
            _PassportSubunitCode = value
        End Set
    End Property

    <Category("Dата изменения собственника"), _
     DisplayName("жилья в истории абонента"), _
     [ReadOnly](True)>
    Public Property DateHistoryChange() As DateTime
        Get
            Return _DateHistoryChange
        End Get
        Set(ByVal value As DateTime)
            _DateHistoryChange = value
        End Set
    End Property
End Class
