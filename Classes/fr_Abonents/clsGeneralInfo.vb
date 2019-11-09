Imports System.ComponentModel
Public Class clsGeneralInfo
    ' Данные "ПИР"
    Public _CopPerformer As String          ' Пристав - исполнитель
    Public _JudicialArea As String          ' Судебный участок
    Public _MembersCount As String          ' Количество солидарных членов семьи

    ' Данные "Квазар"
    Public _AbonentStatus As String         ' Состояние учета Абонента
    Public _AbonentStatusExt As String      ' Причина абонента
    Public _CountTY As Integer              ' Кол-во ТУ абонента
    Public _LodgersCount As Integer         ' Кол-во зарегистрированных
    Public _Controler As String             ' Линейный контролер
    Public _ChiefControler As String        ' Старший контролер
    Public _HousePropName As String         ' Тарифная группа

    ' "Коммунальная информация"
    Public _GKO As String                   ' Жилищно - коммунальная организация
    Public _ManagerHouses As String         ' Председатель совета дома
    Public _BuildTypes As String            ' Тип строения дома
    Public _HouseTypes As String            ' Тип строения дома
    Public _Floors As Integer               ' Количество этажей в доме
    Public _SquareTotal As Double           ' Общая площадь квартиры

    <Category("Данные <ПИР>"),
    DisplayName("Пристав - исполнитель"),
    Description("Пристав закрепленный по данныму адресу")>
    Public Property CopPerformer As String
        Get
            Return _CopPerformer
        End Get
        Set(ByVal value As String)
            _CopPerformer = value
        End Set
    End Property

    <Category("Данные <ПИР>"),
    DisplayName("Судебный участок"),
    Description("Судебный участок обслуживающий данную территорию")>
    Public Property JudicialArea As String
        Get
            Return _JudicialArea
        End Get
        Set(ByVal value As String)
            _JudicialArea = value
        End Set
    End Property

    <Category("Данные <ПИР>"),
    DisplayName("Количестово членов семьи"),
    Description("Члены семьи несущие солидарное бремя по уплате долгов" & Chr(10) & _
    "Может отличаться от зарегистрированных в Квазаре членов")>
    Public Property MembersCount As String
        Get
            Return _MembersCount
        End Get
        Set(ByVal value As String)
            _MembersCount = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Состояние абонента"),
    Description("Статус учета абонента"),
    [ReadOnly](True)>
    Public Property AbonentStatus As String
        Get
            Return _AbonentStatus
        End Get
        Set(ByVal value As String)
            _AbonentStatus = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Причина абонента"),
    Description("Причина статуса абонента"),
    [ReadOnly](True)>
    Public Property AbonentStatusExt As String
        Get
            Return _AbonentStatusExt
        End Get
        Set(ByVal value As String)
            _AbonentStatusExt = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Количество ТУ"),
    Description("Количество точек учета c типом Электроенергия"),
    [ReadOnly](True)>
    Public Property CountTY As Integer
        Get
            Return _CountTY
        End Get
        Set(ByVal value As Integer)
            _CountTY = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Количество зарегистрированных"),
    Description("Количество прописанных в ПК Квазар" & Chr(10) & "Может отличаться от количества солидарных членов по ПИР"),
    [ReadOnly](True)>
    Public Property LodgersCount As Integer
        Get
            Return _LodgersCount
        End Get
        Set(ByVal value As Integer)
            _LodgersCount = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Контролер"),
    Description("ФИО контролера закрепленного за абонентом"),
    [ReadOnly](True)>
    Public Property Controler As String
        Get
            Return _Controler
        End Get
        Set(ByVal value As String)
            _Controler = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Старший контролер"),
    Description("ФИО старшего контролера курирующего участок"),
    [ReadOnly](True)>
    Public Property ChiefControler As String
        Get
            Return _ChiefControler
        End Get
        Set(ByVal value As String)
            _ChiefControler = value
        End Set
    End Property

    <Category("Данные <Квазар>"),
    DisplayName("Тариф"),
    Description("Тарифная группа расчетных пареметров"),
    [ReadOnly](True)>
    Public Property HousePropName As String
        Get
            Return _HousePropName
        End Get
        Set(ByVal value As String)
            _HousePropName = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("ЖКО"),
    Description("Жилищно - коммунальная организация"),
    [ReadOnly](True)>
    Public Property GKO As String
        Get
            Return _GKO
        End Get
        Set(ByVal value As String)
            _GKO = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("Председатель дома"),
    Description("Председатель совета дома"),
    [ReadOnly](True)>
    Public Property ManagerHouses() As String
        Get
            Return _ManagerHouses
        End Get
        Set(ByVal value As String)
            _ManagerHouses = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("Строение"),
    Description("Тип строения дома"),
    [ReadOnly](True)>
    Public Property BuildTypes() As String
        Get
            Return _BuildTypes
        End Get
        Set(ByVal value As String)
            _BuildTypes = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("Жилье"),
    Description("Тип жилья"),
    [ReadOnly](True)>
    Public Property HouseTypes() As String
        Get
            Return _HouseTypes
        End Get
        Set(ByVal value As String)
            _HouseTypes = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("Этажей"),
    Description("Количество этажей в доме"),
    [ReadOnly](True)>
    Public Property Floors() As Integer
        Get
            Return _Floors
        End Get
        Set(ByVal value As Integer)
            _Floors = value
        End Set
    End Property

    <Category("Коммунальная информация"),
    DisplayName("Площадь,м2"),
    Description("Общая площадь квартиры"),
    [ReadOnly](True)>
    Public Property SquareTotal() As Double
        Get
            Return _SquareTotal
        End Get
        Set(ByVal value As Double)
            _SquareTotal = value
        End Set
    End Property
End Class
