Imports System.Text.RegularExpressions  ' Для проверки корректности Email адреса
Imports System.IO                       ' Для работы с каталогами
Imports Microsoft.Win32                 ' Для работы с реестром
Imports Microsoft.Office.Interop
Imports System.Reflection               ' для двойной буферизации DataGridView
Imports DevExpress.XtraSplashScreen     ' Для Формы "Подождите"
Imports DevExpress.LookAndFeel          ' Для оформления в стилях DevExpress
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.Nodes
Imports System.Threading
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.Spreadsheet
Imports DevExpress.Utils

Module Functions
    Friend iEnter As Boolean = False                        ' Переменная идентифицирующая был ли вход в текстовое поле
    Friend iClicker As Boolean = False                      ' Переменная идентифицирующая был ли клик в текстовое поле
    Friend EventChangedControl As Boolean = True            ' вкл/откл обработки изменений значений в контролах
    Friend AddOrEdit As Integer = 2                         ' Идентификация открытия диалогов (2 - Новая запись; 3 - изменение изписи)
    Friend FormLoadComplied As Boolean = False              ' Идентификация окончания загрузки формы
    Friend DecSeporator As String                           ' Разделитель десятичной доли заданный в системе пользователя
    Friend ActiveTab_Petition As Integer                    ' Разделитель десятичной доли заданный в системе пользователя
    Friend iSelectRowDGView_PetitionsDebt As Integer = 0    ' Активная строка на гриде с перечнем исков
    Friend iSelectRowDGView_Petitions As Integer = 0        ' Активная строка на гриде с МИП (Материалы исполнительного производства)
    Friend iSelectRowDGView_Listeneng As Integer = 0        ' Активная строка на гриде с перечнем слушаний
    Friend iSelectRowDGView_Members As Integer = 0          ' Активная строка на гриде с перечнем исков

    Friend iLookAndFeel As New DefaultLookAndFeel

    ' Для заполнения деревьев WinForm
    Friend ndLevel_0 As TreeNode = Nothing                  ' Нод нулевого уровня 
    Friend ndLevel_1 As TreeNode = Nothing                  ' Нод первого уровня 
    Friend ndLevel_2 As TreeNode = Nothing                  ' Нод второго уровня 
    Friend ndLevel_3 As TreeNode = Nothing                  ' Нод третьего уровня 
    Friend ndStr_Level_0 As String = ""
    Friend ndStr_Level_1 As String = ""
    Friend ndStr_Level_2 As String = ""
    Friend ndStr_Level_3 As String = ""
    ' Для заполнения деревьев в DevExpress
    Friend XndLevel_0 As TreeListNode
    Friend XndLevel_1 As TreeListNode
    Friend XndLevel_2 As TreeListNode
    Friend XndLevel_3 As TreeListNode
    Friend XndStr_Level_0 As String
    Friend XndStr_Level_1 As String
    Friend XndStr_Level_2 As String
    Friend XndStr_Level_3 As String

    ' Проверка Email на корректность
    Public Function EmailAddressCheck(ByVal email As String) As Boolean
        If email = "" Then Return True
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(email, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True    'Адрес корректен
        Else
            EmailAddressCheck = False   'Адрес НЕ корректен
        End If

    End Function

    ' Проверка корректности введенных данных в маску
    ' txt - входной текст
    Public Function txtMaskCheck(ByVal txt As String) As Boolean
        Dim DlStr As Integer = txt.Length ' Длина проверяемой строки
        ' Цикл по всем знакам текста в поисках "_" , если найден то поле заполнено не до конца
        For i = 3 To DlStr
            If Mid(txt, i, 1) = "_" Then
                Return False
                Exit Function
            End If
        Next i
        Return True
        Exit Function
    End Function

    ' Проверка корректности введенных данных в поле с маской
    ' iControl - текстовое поле с маской
    ' iMask - указанная в поле маска
    ' iMessageError - текст сообщения при ошибке
    Public Function txtMaskValidating(ByVal iControl As Object, ByVal iMessageError As String, Optional ByVal iMask As String = "") As Boolean
        ' если поле не заполнено то, делаем его белым и текст возвращается без литералов
        If iControl.Text = iMask Then
            iControl.BackColor = System.Drawing.SystemColors.Window                                     ' Делаем поле белым
            Return True
            Exit Function
        Else 'Если поле чем то заполнено выполняем проверку корректности
            If txtMaskCheck(iControl.Text) And iControl.MaskFull Then
                ' Текст прошел проверку
                iControl.BackColor = System.Drawing.SystemColors.Window                                 ' Делаем поле белым
                Return True
            Else ' Текст НЕ прошел проверку
                iControl.BackColor = System.Drawing.Color.HotPink                                       ' Делаем поле розовым
                XtraMessageBox.Show(iMessageError, _
                                "ПК <Припять>", MessageBoxButtons.OK, MessageBoxIcon.Information)       ' Сообщение
                iControl.Focus()                                                                        ' Возвращаемся обратно в поле ввода
                iControl.SelectAll()                                                                    ' Выделяем весь текст
                Return False
            End If
        End If
    End Function

    ' Конвертация мобильного номера в вид базы данных
    Public Function ConvertPhoneMobile(ByVal Phone As String)
        If Phone = "7 (   )        " Then
            Return "Null"
        Else
            Phone = Replace(Phone, "7 (", "")
            Phone = Replace(Phone, ")", "")
            Return "'" & Phone & "'"
        End If
    End Function

    ' Проверка и конвертация NULLевых значений для заливки данных
    ' V = строка заначения, Reverse = <<из "" в NULL>> или <<из NULL в "">> , Function = номер функции
    ' 0 - для текстовых полей
    ' 1 - для полей с маской
    ' iMask - маска
    Public Function ConvertToNull(ByVal V As String, _
                                  ByVal Reverse As Boolean, _
                                  ByVal iFunction As Integer, _
                                  Optional ByVal iMask As String = Nothing)
        If V = Nothing Or V Is DBNull.Value Then V = ""
        Select Case iFunction
            Case 0 ' Конвертация для текстовых полей
                Select Case Reverse
                    Case True ' Конвертация из "" в NULL
                        If V = "" Then
                            Return "Null"
                        Else
                            Return "'" & V & "'"
                        End If

                    Case False ' Конвертация из NULL в ""
                        If V = "NULL" Then
                            Return ""
                        Else
                            Return V
                        End If
                End Select
            Case 1 ' Конвертация для полей с маской
                Select Case Reverse
                    Case True ' Конвертация из " " в NULL
                        If V = iMask Then
                            Return "NULL"
                        Else
                            Return "'" & V & "'"
                        End If

                    Case False ' Конвертация из NULL в " "
                        If V = "NULL" Or V = "" Then
                            Return ""
                        Else
                            ' Дата отображается без времени
                            Return FormatDateTime(V, DateFormat.GeneralDate)
                        End If
                End Select
        End Select
        Return XtraMessageBox.Show("Невозможно конвертировать значение......" & Chr(10) & _
                               "_____________________________М.А. Лобин", _
                               "NULL или _", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

    ' Функция возвращает сообщение в статус - баре
    ' Msg - текст сообщения, Element = любой контрол с методом .Text
    Public Sub MessageStatusStrip(ByVal Msg As String, ByVal iControl As Object)
        iControl.Text = Msg     ' Текст сообщение на элементе
        Application.DoEvents()  ' Обработчик сообщение
    End Sub


    ' ======================================================= Обработка событий в текстовых полях с денежным форматом
    ' sender - Объект текстового поля
    ' e - Пространство имен .KeyPressEventArgs
    ' Ввод только цифр и точки
    Public Sub MoneyTextBox_Numbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim c As Integer                                                        ' Переменная для хранения номера позиции точки
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then        ' Если введенный знак относится к знакам препинания или десятичным цыфрам то,
            If Char.IsPunctuation(e.KeyChar) Then                               ' Если введенный знак, знак препинания то,
                If e.KeyChar = Chr(44) Or e.KeyChar = Chr(46) Then              ' Если знак запятая или точка то,
                    c = InStr(sender.Text, DecSeporator)                        ' Считаем номер позиции знака
                    If c > 1 Then                                               ' Если позиция больше 1 то,
                        e.Handled = True                                        ' Отменяем ввод
                    Else
                        e.KeyChar = DecSeporator                                ' Если нет то, вводим точку
                    End If
                Else                                                            ' Если введенный знак, знак препинания, но не запитая или точка
                    e.Handled = True                                            ' Отменяем ввод
                End If
            End If
        ElseIf Asc(e.KeyChar) = 8 Then                                          ' Если нажата клавиша BackSpace то, разрешаем обработку
        Else
            e.Handled = True                                                    ' На все остальное запрет
        End If
    End Sub
    ' Обработка входа-выхода из поля ввода
    Public Sub MoneyTextBox_EnterLeave(ByVal sender As Object, ByVal e As EventArgs, ByVal iEvent As String, ByVal iFormatType As String)
        Dim Dec As Decimal
        Select Case iEvent
            Case "Click" ' Вход
                If Decimal.TryParse(sender.Text, System.Globalization.NumberStyles.Currency, Nothing, Dec) Then
                    sender.Text = Dec.ToString(iFormatType)
                End If
                If iEnter = False Then
                    sender.SelectAll()
                    iEnter = True
                End If
            Case "Leave" ' Выход
                If Len(sender.Text) = 1 And sender.Text = "." Then sender.Clear()
                If Decimal.TryParse(sender.Text, System.Globalization.NumberStyles.Currency, Nothing, Dec) Then
                    sender.Text = Dec.ToString(iFormatType)
                End If
                iEnter = False
        End Select
    End Sub
    ' Загрузка в денежное поле значении из базы данных
    ' iControl - контрол в которы будет загружено значение
    ' iValue - Значение из базы
    ' InOut - 0 - из базы; 1 - в базу
    Public Function OutBD_Money(ByVal iValue As String, ByVal InOut As Integer, ByVal iFormatType As String)
        Select Case InOut
            Case 0
                If iValue <> "" Then
                    Dim Dec As Decimal = iValue
                    Return Dec.ToString(iFormatType)
                Else
                    Return iValue
                End If
            Case 1
                If iValue = "" Then
                    Return "NULL"
                Else
                    Dim Dec As Decimal = iValue
                    Return Replace(Dec.ToString(iFormatType), DecSeporator, ".")
                End If
        End Select
        Return XtraMessageBox.Show("Невозможно конвертировать денежное значение......" & Chr(10) & _
                       "на выходе из базы данных!", _
                       "OutBD_Money", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

    ' ======================================================= Расчет гос.пошлины
    ' Тип иска
    ' Контрол в который нужно записать расчитанную гос.пошлину
    Public Sub CalculateGovTax(ByVal SummDebet As Decimal, ByVal PetitionType As Object, ByVal GovTaxControl As Object)
        Dim Dec As Decimal
        Select Case PetitionType.Text
            Case "Заявление на выдачу СП"
                Dec = ReturnGovTaxSumm(SummDebet) / 2
                GovTaxControl.Text = Dec.ToString("N")
            Case "Исковое заявление"
                Dec = ReturnGovTaxSumm(SummDebet)
                GovTaxControl.Text = Dec.ToString("N")
            Case "Опеляционная жалоба"
                Dec = ReturnGovTaxSumm(SummDebet) / 2
                GovTaxControl.Text = Dec.ToString("N")
        End Select
    End Sub
    ' Расчет суммы в зависимости от типа иска
    Private Function ReturnGovTaxSumm(ByVal iValue As Decimal)
        Select Case iValue
            Case Is <= 10000
                Return 400

            Case 10001 To 20000
                Return iValue * 0.04

            Case 20001 To 100000
                Return (iValue - 20000) * 0.03 + 800

            Case 100001 To 200000
                Return (iValue - 100000) * 0.02 + 3200

            Case 200001 To 1000000
                Return (iValue - 200000) * 0.01 + 5200

            Case Is > 1000001
                Return (iValue - 1000000) * 0.005 + 13200
            Case Else
                Return XtraMessageBox.Show("Невозможно произвести расчет Гос.пошлины, " & Chr(10) & _
                                       "так как сумма не входит ни в один из диапазонов расчета!", _
                        "Расчет госпошлины...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Function

    ' Проверка корректности периода двух дат или правильности последовательности событий
    ' D1, D2 - начало и конец периода
    ' iControl - контрол где будет проверяемая дата
    Public Sub ValidateOfDateDiff(ByVal D1 As String, ByVal D2 As String, ByVal iControl As Object, ByVal iMessageText As String)
        If IsDate(D1) And IsDate(D2) Then                                   ' Проверка являются ли переменные датами
            ' Преобразование значений переменных в дату
            Dim iD1 As DateTime = D1
            Dim iD2 As DateTime = D2
            Dim iDateDiff As Integer = DateDiff(DateInterval.Day, iD1, iD2)                                 ' Разность дат в днях
            Select Case iDateDiff
                Case Is > 0 ' Если разность дат больше нуля
                    iControl.BackColor = System.Drawing.SystemColors.Window                                 ' Делаем поле белым
                Case Is = 0 ' Если разность дат равна нулю
                    iControl.BackColor = System.Drawing.Color.HotPink                                       ' Делаем поле розовым
                    iControl.Focus()                                                                        ' Возвращаемся обратно в поле ввода
                    iControl.SelectAll()                                                                    ' Выделяем весь текст
                    XtraMessageBox.Show(iMessageText, _
                            "Исправьте дату...", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Is < 0 ' Если разность дат меньше нуля
                    iControl.BackColor = System.Drawing.Color.HotPink                                       ' Делаем поле розовым
                    iControl.Focus()                                                                        ' Возвращаемся обратно в поле ввода
                    iControl.SelectAll()                                                                    ' Выделяем весь текст
                    XtraMessageBox.Show(iMessageText, _
                            "Исправьте дату...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        Else
            ' Если ниодно условие на сработало
            XtraMessageBox.Show(iMessageText, _
            "Неверно указана дата...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            iControl.Focus()                                                                                ' Возвращаемся обратно в поле ввода
            iControl.Text = Nothing                                                                         ' Очищаем его
        End If
    End Sub

    ' Конвертер даты типа "01012016" в "01.01.2016"
    ' iDateString - входящая строка с датой
    ' InDb - True: в бузу оборачиваем дату в '01.01.2016' 
    '        False : 01.01.2016
    Public Function DateInDataBase(ByVal iDateString As String, Optional ByVal InDb As Boolean = True)
        Dim val As String
        If iDateString <> "" Then
            val = CDate(Mid(iDateString, 1, 2) & "." & Mid(iDateString, 3, 2) & "." & Mid(iDateString, 5, 4))
            Select Case InDb
                Case True
                    Return "'" & val & "'"
                Case False
                    Return val
            End Select
        Else
            Select Case InDb
                Case True
                    Return "NULL"
                Case False
                    Return ""
            End Select
        End If
    End Function

    ' Суммирование значений по столбцу в таблице из iDataSet
    Public Function SumValueInDateSet(ByVal iTableName As String, ByVal iColumnName As String)
        Dim Counter As Double = 0 ' Счетчик строк
        Dim iSum As Double = 0 ' Накопитель суммы
        ' Цик по строкам iDataSet если он не пустой
        If iDataSet.Tables(iTableName).Rows.Count <> 0 Then
            For Each iRow As DataRow In iDataSet.Tables(iTableName).Rows
                Try
                    Counter = OutBD_Money(iRow.Item(iColumnName).ToString, 0, "N")
                    iSum = Counter + iSum
                Catch : End Try
            Next
            Return iSum
        End If
        Return 0
    End Function

    ' Обработка событий и перемещений внутри контролов с датами
    ' iEvent - Событие вызванное в контроле KeyUp/MouseClick
    ' iControl - контрол где будет проверяемая дата
    ' e - нажатая клавиша
    Public Sub DateMaskEvents(ByVal iEvent As String,
                               ByVal iControl As Object,
                               Optional ByVal e As System.Windows.Forms.Keys = Keys.Left)
        ' Обработка событий
        Select Case iEvent
            Case "KeyUp" ' Нажатие стролок вправо/влево
                ' Обработка перемещений внутри контрола
                ' Перехват нажатия стрелки влево
                If e = Keys.Left Then
                    ' В зависимости от положения курсора выделяем часть даты
                    Select Case iControl.SelectionStart
                        Case 0 To 5
                            iControl.Select(0, 2)
                        Case Is >= 6
                            iControl.Select(3, 2)
                    End Select
                End If
                ' Перехват нажатия стрелки вправо
                If e = Keys.Right Then
                    ' В зависимости от положения курсора выделяем часть даты
                    Select Case iControl.SelectionStart
                        Case 0 To 2
                            iControl.Select(3, 2)
                        Case 3 To 5
                            iControl.Select(3, 2)
                        Case Is >= 6
                            iControl.Select(6, 4)
                    End Select
                End If
                ' Сдвижение курсора на слудующую часть даты
                Select Case iControl.SelectionStart
                    Case 2
                        iControl.Select(3, 2)
                    Case 5
                        iControl.Select(6, 4)
                End Select
                ' ==============================================
            Case "MouseClick" ' Клики мышкой
                ' Обработка кликов мышью внутри контрола
                ' В зависимости от того куда наступила мышь выделяем часть даты
                Select Case iControl.SelectionStart
                    Case 0 To 2
                        iControl.Select(0, 2)
                    Case 3 To 5
                        iControl.Select(3, 2)
                    Case Is >= 6
                        iControl.Select(6, 4)
                End Select
        End Select
    End Sub

    ''' Функция сохраняет массив байт во временную папку.
    ''' </summary>
    ''' <param name="buff">Массив байт.</param>
    ''' <returns>Возвращает путь ко временному файлу.</returns>
    ''' <remarks></remarks>
    Public Function SaveResToTemp(ByVal buff As Byte()) As String
        Dim tempFile As String = Path.GetTempFileName
        Using fs As New FileStream(tempFile, FileMode.Create)
            fs.Write(buff, 0, buff.Length)
            fs.Close()
        End Using
        Return tempFile
    End Function


#Region "Работа с реестром"
    ' Чтение из реестра
    Public Function RegistryRead(ByVal SectionName As String,
                                 ByVal KeyName As String,
                                 Optional ByVal NothingValue As String = "",
                                 Optional ByVal NothingDataType As RegistryValueKind = RegistryValueKind.String)
        ' если раздела не существует, но нет ключа вернется значение по-умолчанию
        ' Проверка существования раздела
        Dim iSec As String = Registry.CurrentUser.CreateSubKey(SectionName).GetValue(KeyName, Nothing) ' Возвращаем значение из реестра
        If iSec = Nothing Then ' Если раздела и ключа не существует
            ' они будут созданы автоматически
            RegistryWrite(SectionName, KeyName, NothingValue, NothingDataType)
        End If
        ' если существуют, вернуться значения из реестра
        Return Registry.CurrentUser.CreateSubKey(SectionName).GetValue(KeyName, NothingValue)
    End Function
    ' Запись в реестр
    Public Sub RegistryWrite(ByVal SectionName As String,
                             ByVal KeyName As String,
                             ByVal Value As String,
                             Optional ByVal DataType As RegistryValueKind = RegistryValueKind.String)
        ' Если ни раздела, ни ключа не существует, он будет создан
        My.Computer.Registry.CurrentUser.CreateSubKey(SectionName, False).SetValue(KeyName, Value, DataType) ' Записываем текст в раздел Test
    End Sub
    ' Создание раздела
    Public Sub RegistryCreateSection(ByVal SectionName As String)
        My.Computer.Registry.CurrentUser.CreateSubKey(SectionName, RegistryKeyPermissionCheck.ReadWriteSubTree) ' Создаем новый раздел в реестре с доступом на запись
    End Sub
    ' Удаление раздела
    Public Sub RegistryDeleteSection(ByVal SectionName As String)
        Try
            My.Computer.Registry.CurrentUser.DeleteSubKeyTree(SectionName, True) ' Удаляем раздел из реестра
        Catch e As Exception
            XtraMessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Удаление ключа из ветки реестра
    Public Function RegistryDeleteKey(ByVal SectionName As String, ByVal KeyName As String)
        Try
            My.Computer.Registry.CurrentUser.OpenSubKey(SectionName, True).DeleteValue(KeyName, True)
        Catch eX As Exception
            XtraMessageBox.Show(eX.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region

#Region "Склонение ФИО в Винительный падеж"
    Function DativeCase(ByVal sSurname As String, ByVal sName As String, ByVal sPatronymic As String) As String
        ' Функция формирует дательный падеж из ФИО
        ' Параметры: sSurname - фамилия, sName - имя, sPatronymic - отчество
        ' © 2013 EducatedFool

        'Application.Volatile(True)    ' автопересчёт формулы на листе
        sSurname = Replace(sSurname, " - ", "-") : sSurname = Replace(Replace(sSurname, " -", "-"), "- ", "-")
        Dim arr() As String
        On Error Resume Next
        If sName = "" And sPatronymic = "" Then
            arr = Split(Trim(sSurname))
            sSurname = arr(0) : sName = arr(1) : sPatronymic = Replace(arr(2), ".", "")
        End If

        ' пол теперь определяется иначе:   что заканчивается на "вна" или "кызы" - то женщины, остальные - мужчины.
        Dim bMaleSex As Boolean ' bMaleSex = (Right(sPatronymic, 1) = "ч" Or Right(sPatronymic, 4) = "оглы")
        bMaleSex = Not (Microsoft.VisualBasic.Right(sPatronymic, 2) = "на" Or Microsoft.VisualBasic.Right(sPatronymic, 4) = "кызы")
        Dim arrSurname() As String
        Dim sRes, sSurnamePart As String
        If Len(sSurname) > 0 Then    '   Фамилия
            arrSurname = Split(sSurname, "-")
            For i = LBound(arrSurname) To UBound(arrSurname)    ' перебираем все части фамилий, содержащих дефис
                sRes = "" : sSurnamePart = arrSurname(i)

                If bMaleSex Then    ' мужские фамилии
                    Select Case Microsoft.VisualBasic.Right(sSurnamePart, 1)
                        Case "о", "и", "ы", "у", "э", "е", "ю" : sRes = sSurnamePart
                        Case "ь", "й" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "ю"
                        Case "я", "а" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "е"
                            If UBound(arrSurname) > 0 And i = 0 Then sRes = sSurnamePart
                        Case Else : sRes = sSurnamePart & "а"
                    End Select

                    Select Case Microsoft.VisualBasic.Right(sSurnamePart, 2)    ' добавлено, для редких фамилий
                        'Case "ец" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "цу"
                        '    If LCase(sSurnamePart) Like "*[уеыаоэяиюё]ец" Then sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "цу"
                        '    If LCase(sSurnamePart) Like "*[!уеыаоэяиюё][!уеыаоэяиюё]ец" Then sRes = sSurnamePart & "у"
                        Case "ин" : sRes = sSurnamePart & "а"
                        Case "зе", "их", "ых" : sRes = sSurnamePart
                        Case "ый" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "ого"
                        Case "ий", "ой" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "ого"
                            If Len(sSurnamePart) <= 4 Then sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "ю"
                            If Microsoft.VisualBasic.Right(sSurnamePart, 3) = "чий" Then sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "ого"
                        Case "уй" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "ую"
                    End Select

                Else    ' женские фамилии
                    Select Case Microsoft.VisualBasic.Right(sSurnamePart, 1)
                        Case "о", "е", "э", "и", "ы", "у", "ю", "б", "в", "г", "д", "ж", "з", "к", "л", "м", "н", "п", _
                             "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ", "ь", "й" : sRes = sSurnamePart
                        Case "я", "а" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "ой"
                            'Case "ая" : sRes = Mid(sSurnamePart, 2, Len(sSurnamePart) - 2) & "ой"
                        Case Else : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 1) & "ой"
                    End Select

                    Select Case Microsoft.VisualBasic.Right(sSurnamePart, 2)    ' добавлено, для редких фамилий
                        Case "ха", "ла", "ее", "на", "ая" : sRes = Mid(sSurnamePart, 1, Len(sSurnamePart) - 2) & "ой"
                    End Select

                End If

                ' не склоняются мужские и женские фамилии, оканчивающиеся на -о, -е, -э, -и, -ы, -у, -ю,
                ' а также на -а с предшествующей гласной
                If LCase(sSurnamePart) Like "*[уеыаоэяиюё]а" Then sRes = sSurnamePart

                arrSurname(i) = sRes
            Next
            DativeCase = Join(arrSurname, "-") & " "    ' соединяем части склоняемой фамилии обратно в одну строку
        End If
        Dim NameException As String
        If Len(sName) > 0 Then    '   Имя
            NameException = GetDativeException(sName)
            If Len(NameException) Then    ' для имен-исключений
                DativeCase = DativeCase & NameException
            Else    ' имя не найдено в списке исключений
                If bMaleSex Then
                    Select Case Microsoft.VisualBasic.Right(sName, 1)
                        Case "й", "ь" : DativeCase = DativeCase & Mid(sName, 1, Len(sName) - 1) & "я"
                        Case "я", "а" : DativeCase = DativeCase & Mid(sName, 1, Len(sName) - 1) & "я"
                        Case "о" : DativeCase = DativeCase & sName
                        Case Else : DativeCase = DativeCase & sName & "а"
                    End Select
                Else
                    Select Case Microsoft.VisualBasic.Right(sName, 2)
                        Case "на" : sName = Mid(sName, 1, Len(sName) - 1) & "ы"
                    End Select
                    Select Case Microsoft.VisualBasic.Right(sName, 1)
                        Case "а", "я"
                            If Mid(sName, Len(sName) - 1, 1) = "и" Then
                                DativeCase = DativeCase & Mid(sName, 1, Len(sName) - 1) & "и"
                            Else
                                DativeCase = DativeCase & Mid(sName, 1, Len(sName) - 1) & "и"
                            End If
                        Case "ь" : DativeCase = DativeCase & Mid(sName, 1, Len(sName) - 1) & "ь"
                        Case Else : DativeCase = DativeCase & sName
                    End Select
                End If
            End If
            DativeCase = DativeCase & " "
        End If

        If Len(sPatronymic) > 0 Then    '   Отчество
            If Microsoft.VisualBasic.Right(sPatronymic, 4) = "оглы" Or Microsoft.VisualBasic.Right(sPatronymic, 4) = "кызы" Then
                DativeCase = DativeCase & sPatronymic
            Else
                If bMaleSex Then
                    DativeCase = DativeCase & sPatronymic & "а"
                Else
                    DativeCase = DativeCase & Mid(sPatronymic, 1, Len(sPatronymic) - 1) & "ы"
                End If
            End If
        End If
        DativeCase = Replace(DativeCase, "-", "- ")
        DativeCase = StrConv(DativeCase, vbProperCase)
        DativeCase = Replace(DativeCase, "- ", "-")
    End Function
    Function GetDativeException(ByVal txt$) As String    ' склонение имён-исключений
        Select Case txt$
            Case "Павел" : GetDativeException = "Павлу"
            Case "Лев" : GetDativeException = "Льву"
            Case "Пётр" : GetDativeException = "Петру"

                ' без изменения (не склоняются) - перечисляем через запятую
            Case "Али", "Бали" : GetDativeException = txt$
        End Select
    End Function
#End Region

#Region "Фамилия имя отчество в фамилия И.О."
    Function GetShortFSN(ByVal iValue As String) As String

    End Function
#End Region

    ' Процедура двойной буферизации контролов
    Public Sub SetDoubleBuffered(ByVal control As Control) 'Процедура DoubleBuffered для DataGridView
        ' Двойная буферезация для элемента управления control
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
    ' Процедура очистки неиспользуемых процессов
    Public Sub LiberationMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    ' Показать форму ожидания
    ' ParentForm - родительская форма
    ' OpenClose - 
    Friend Sub WaitFormShow(ByVal ParentForm As Form, ByVal OpenClose As Integer)
        Dim s As New SplashScreenManager
        Select Case OpenClose
            Case 1
                s.ShowForm(ParentForm, GetType(frWaitSimple), True, True, True)
            Case 0
                s.CloseForm(False)
        End Select
    End Sub

    ' Отчистка содержимого не нужных таблиц в DataSet принадлежащих указанной форме
    ' FormName - форма в которой были созданы таблицы
    Friend Sub RemoveTableDataSet(ByVal _Me As Object)
        ' Края вхождения строки
        Dim lStrNum As Integer = 0
        Dim rStrNum As Integer = _Me.Name.Length
        Dim s As String
        Dim iName As New List(Of String)

        EventChangedControl = False
        iDataSet.Relations.Clear()      ' удаление отношений
        For t = 0 To iDataSet.Tables.Count - 1
            If iDataSet.Tables.Contains(iDataSet.Tables(t).TableName) Then
                lStrNum = InStr(iDataSet.Tables(t).TableName.ToString, _Me.Name)
                If lStrNum <> 0 Then
                    s = Mid(iDataSet.Tables(t).TableName.ToString, lStrNum, rStrNum)
                    If s = _Me.Name.ToString Then
                        ' запись в коллекцию имени таблиц к удалени
                        iName.Add(iDataSet.Tables(t).TableName.ToString)
                        Console.WriteLine(iDataSet.Tables(t).TableName.ToString & " -к удалению")
                    End If
                End If
            End If
        Next
        ' удаление таблиц по коллекции
        For Each n As String In iName
            iDataSet.Tables.Remove(n)
        Next
        Console.WriteLine(iDataSet.Tables.Count)
        For Each t As DataTable In iDataSet.Tables
            Console.WriteLine("Осталась - " & t.TableName)
        Next
        _Me.Dispose()
        EventChangedControl = True
    End Sub

    ' Функция для проверки даты изменения процедур Квазара
    ' которые использует Припять
    Friend Function Pr_GetTrackingProcedures(ByVal iName As String) As Boolean
        Dim iResult As Integer = ExecuteScalar("EXEC Pr_GetTrackingProcedures @ProcedureName = '" & iName & "'")
        Select Case iResult
            Case 0
                XtraMessageBox.Show("Не удалась проверить репозиторий ПК Квазар", _
                                    "Проверка процедуры ПК Квазар",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return True
            Case 1
                XtraMessageBox.Show("Процедура ПК Квазар с именем [" & iName & "] была изменена!" & Chr(10) &
                                    "Необходимо отразить данные изменения в ПК Припять." & Chr(10) &
                                    "Обратитесь к разработчику.",
                                    "Проверка процедуры ПК Квазар",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return True
            Case 2 ' Процедура не менялась
                Return False
            Case 3
                XtraMessageBox.Show("Процедура ПК Квазар с именем [" & iName & "] не найдена в репозитории слежки!" & Chr(10) &
                                    "Для ослеживания изменений, ее необходимо добавить в репозиторий." & Chr(10) &
                                    "Обратитесь к разработчику.",
                                    "Проверка процедуры ПК Квазар",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return True
        End Select
        Return False
    End Function

    ' Функция для проверки корректности фактической даты события
    ' Проверка отсутствия возможности занести событие
    Friend Function OiOValidateDtFact(ByVal AbonentId As String,
                                      ByVal DtBeginOio As String,
                                      ByVal EventTypeId As String,
                                      ByVal DtFact As String) As Integer
        Dim iResult As Integer = ExecuteScalar(
            "EXEC Pr_OiOValidateDtFact " & _
                    "@AbonentId = " & AbonentId & ", " & _
                    "@DtBeginOio = '" & DtBeginOio & "', " & _
                    "@EventTypeId = " & EventTypeId & ", " & _
                    "@DtFact = '" & DtFact & "'"
                                                )
        Dim s As String = "Событие будет записано только в ПК Припять..."
        Select Case iResult
            Case 0      ' успешно
                Return iResult
            Case -1     ' фактическая дата меньше ф.даты одного из предыдущих событий
                XtraMessageBox.Show("Дата события меньше фактической даты одного из предыдущих событий!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                '"<u><b>" & Convert.ToDecimal(iDocsCount) & "</b></u>
                Return iResult
            Case -2     ' Закрыта история ДЗ
                XtraMessageBox.Show("Закрыта история работы с ДЗ!" & Chr(10) & _
                                    Chr(10) & _
                                    "<u><b>Событие будет записано только в ПК Припять...</b></u><b>",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
            Case -3     ' месяц закрыт (забивки не будет вообще никакой)
                XtraMessageBox.Show("Дата фактического события принадлежит закрытому периоду!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
            Case -4     ' отключение/ограничение произведено слишком поздно
                XtraMessageBox.Show("Промежуток между уведомлением и ограничением/отключением превышает допустимый предел!" & Chr(10) & _
                                    Chr(10) & _
                                    "<u><b>Событие будет записано только в ПК Припять...</b></u><b>",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
            Case -5     ' подключение, можно вводить только в последнюю запись истории ДЗ
                XtraMessageBox.Show("Подключение можно вводить только в последнюю запись истории с ДЗ!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
            Case -6     ' отключение/ограничение невозможно, нет уведомления
                XtraMessageBox.Show("Отсутствует фактическая дата вручения уведомления!" & Chr(10) & _
                                    "Ограничение/отключение невозможно!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
            Case -7     ' ДЗ уже не существует (забивки не будет вообще никакой)
                XtraMessageBox.Show("Записи в истории работы с ДЗ, существовавщей на момент подготовки мероприятия больше не существует!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    DevExpress.Utils.DefaultBoolean.True)
                Return iResult
        End Select
    End Function

#Region "Загрузка словаря для проверки орфографии"
    Friend Function LoadSpellChecker(ByVal iParentForm As Object)
        Dim Th As New Thread(AddressOf LoadAtForm)
        Th.IsBackground = True
        Th.Priority = ThreadPriority.Lowest
        Th.Start(iParentForm)
    End Function
    Private Sub LoadAtForm(ByVal iParentForm As Object)
        spCheck.ParentContainer = iParentForm
    End Sub
#End Region
    ' инвертация bool значений на противоположное
    Friend Function InverterBoolean(ByVal Value As Boolean) As Boolean
        If Value Then
            Return False
        Else
            Return True
        End If
    End Function
    ' скрытие всех столбцов в гриде
    Friend Sub HidenAllColumns_Grid(ByVal _grid As GridView, ByVal dt As DataTable)
        _grid.PopulateColumns(dt)
        For Each col As GridColumn In _grid.Columns
            col.Visible = False
        Next
    End Sub
    ' скрытие всех столбцов в TreeList
    Friend Sub HidenAllColumns_TreeList(ByVal _TreeList As TreeList)
        For Each col As TreeListColumn In _TreeList.Columns
            col.Visible = False
        Next
    End Sub

#Region "Загрузка простого файла отчета без передачи параметров"
    ' загрузка простого файла отчета без передачи параметров
    Friend Sub PreparedReport(ByVal _ReportFile As Object, ByVal _Owner As Object)
        SplashScreenManager.ShowForm(_Owner, GetType(frDefaultWaitForm), True, True, True, True)
        Dim FRx As New FastReport.Report                                           ' Новый экземпляр отчета
        Dim ReportFile As Object = _ReportFile
        ' Проверка зашит ли файл отчета в программу
        If File.Exists(SaveResToTemp(ReportFile)) Then
            Try
                AddHandler FRx.FinishReport, AddressOf CloseWait ' событие после загрузке отчета
                FRx.Load(SaveResToTemp(ReportFile)) ' Загрузка отчета из ресурсов программы
                FRx.SetParameterValue("ConnectionString", pref_ConnectionString)
                FRx.Show(True, _Owner)          ' Показать отчет
                FRx.Dispose()                   ' Осводить ресурсы
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Если отчета нет в ресурсах программы
            XtraMessageBox.Show("Не найден файл для генератора отчетов!", _
            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        ' без этого скрывается раньше
        SplashScreenManager.CloseForm(False)
    End Sub
    Friend Sub CloseWait()
        SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "Проверка лицензии программы"
    Private Structure LicenseList ' структура коллекции
        Dim Code As String
        Dim Dt As String
    End Structure
    Friend Function LicenseCheck() As Boolean
        Dim LL As New List(Of LicenseList)
        Dim _Code As String = RegistryRead(pref_ComplexSettings, "License", "8L219-2XL92-389Q7-C1135-68ZO8") ' до 01.01.2018
        Dim st0 As New LicenseList With {.Code = "1P802-4MJ01-204G4-V5093-89IJ9", .Dt = "01.10.2017"}
        Dim st1 As New LicenseList With {.Code = "8L219-2XL92-389Q7-C1135-68ZO8", .Dt = "01.01.2018"}
        Dim st2 As New LicenseList With {.Code = "4M665-4OF25-860O4-P9397-07GQ3", .Dt = "01.04.2018"}
        Dim st3 As New LicenseList With {.Code = "0A215-4JU00-880E9-B2418-19CI5", .Dt = "01.07.2018"} '<<<<<<
        Dim st4 As New LicenseList With {.Code = "8I487-6PH57-089K8-L7172-53GY0", .Dt = "01.10.2018"}
        Dim st5 As New LicenseList With {.Code = "6U467-1SV02-941Z5-J4653-61AG3", .Dt = "01.01.2019"}
        Dim st6 As New LicenseList With {.Code = "3I273-9IE43-169Q4-N4266-43RE8", .Dt = "01.04.2019"}
        Dim st7 As New LicenseList With {.Code = "7G765-3DQ68-039D9-B6602-92TQ0", .Dt = "01.07.2019"}
        Dim st8 As New LicenseList With {.Code = "3H532-1FG28-193A1-I6116-18CR6", .Dt = "01.10.2019"}
        Dim st9 As New LicenseList With {.Code = "3G790-1ZQ78-297Z1-T9024-15KC6", .Dt = "01.01.2020"}
        Dim st10 As New LicenseList With {.Code = "6X883-5EO83-573S6-A7985-36DJ4", .Dt = "01.04.2020"}
        Dim st11 As New LicenseList With {.Code = "7R386-4ND19-497O7-E6970-86WO2", .Dt = "01.07.2020"}
        Dim st12 As New LicenseList With {.Code = "3Q378-7ZZ56-854F9-T0093-16ZE9", .Dt = "01.10.2020"}
        Dim st13 As New LicenseList With {.Code = "8K891-3OE42-482W5-I2788-78SL1", .Dt = "01.01.2021"}
        Dim st14 As New LicenseList With {.Code = "5L867-5CV25-226F7-B6235-41BO7", .Dt = "01.04.2021"}
        Dim st15 As New LicenseList With {.Code = "8U115-4WK63-274R0-G4955-35FV9", .Dt = "01.07.2021"}
        Dim st16 As New LicenseList With {.Code = "8B973-7UU74-443G8-Z0947-07XO2", .Dt = "01.10.2021"}
        Dim st17 As New LicenseList With {.Code = "7W227-9KZ85-119J4-K6479-61DQ8", .Dt = "01.01.2022"}
        Dim st18 As New LicenseList With {.Code = "1P008-4JM62-439B6-F8471-80HE0", .Dt = "01.04.2022"}
        Dim st19 As New LicenseList With {.Code = "7F018-5NJ14-250L6-W2996-88JM6", .Dt = "01.07.2022"}
        Dim st20 As New LicenseList With {.Code = "1E603-8EL44-415N3-B9899-41FO1", .Dt = "01.10.2022"}
        Dim st21 As New LicenseList With {.Code = "1T741-6BW72-996D8-V4502-97DI1", .Dt = "01.01.2023"}
        Dim st22 As New LicenseList With {.Code = "6W830-8GL69-189O0-K7038-35TT2", .Dt = "01.04.2023"}
        Dim st23 As New LicenseList With {.Code = "1C652-4QO36-982O8-V2522-70QC6", .Dt = "01.07.2023"}
        Dim st24 As New LicenseList With {.Code = "6Q559-7VD81-839V4-G3765-14SP4", .Dt = "01.10.2023"}
        Dim st25 As New LicenseList With {.Code = "9V700-4ZZ18-628F0-R5300-04NP4", .Dt = "01.01.2024"}
        Dim st26 As New LicenseList With {.Code = "5F721-3AJ10-483I5-I0369-08DE7", .Dt = "01.04.2024"}
        Dim st27 As New LicenseList With {.Code = "3Q695-4DR82-175Q6-M2652-70HA5", .Dt = "01.07.2024"}
        Dim st28 As New LicenseList With {.Code = "5L438-3QR80-762G5-T0625-76JW9", .Dt = "01.10.2024"}
        Dim st29 As New LicenseList With {.Code = "9D594-0YC45-060G9-A8492-17HV7", .Dt = "01.01.2025"}
        Dim st30 As New LicenseList With {.Code = "8E579-0WS47-972S8-A2202-01VL6", .Dt = "01.04.2025"}
        Dim st31 As New LicenseList With {.Code = "5M859-9NP81-826E1-M4207-33RJ4", .Dt = "01.07.2025"}
        Dim st32 As New LicenseList With {.Code = "5K074-8QA50-603Y2-B3409-61SG6", .Dt = "01.10.2025"}
        LL.AddRange(New LicenseList() {st0, st1, st2, st3, st4, st5, st6, st7, st8, st9, st10, st11, st12, st13, st14, st15, st16,
                                       st17, st18, st19, st20, st21, st22, st23, st24, st25, st26, st27, st28, st29, st30, st31})
        For Each n In LL
            If n.Code = _Code Then
                If CDate(n.Dt) < Now.Date Then
                    XtraMessageBox.Show("Expired license DevExpress Components" & Chr(10) & "https://www.devexpress.com/",
                               "DevExpress", MessageBoxButtons.OK, MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True)
                    Return False
                    Exit Function
                Else
                    Return True
                    Exit Function
                End If
            End If
        Next
        XtraMessageBox.Show("Expired license DevExpress Components" & Chr(10) & "https://www.devexpress.com/",
                               "DevExpress", MessageBoxButtons.OK, MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True)
        Return False
        Exit Function
    End Function
#End Region

#Region "#Экспорт данных из таблицы датасет в Excell"
    ' dt - таблица в датасете
    ' FileName - имя файла на выходе
    ' SheetName - Имя листа в создаваемой книге
    ' ProgressControll - контрол для отображения прогресса
    ' QuestionOpen -    0 - никаких действий экспорт и все;
    '                   1 - спросить открыть файл или нет;
    '                   2 - открывать не спрашивая;
    Friend Function ExportToExcel_DataSet(ByVal dt As DataTable,
                                          ByVal FileName As String,
                                          ByVal SheetName As String,
                                          ByVal ProgressControll As Object,
                                          ByVal QuestionOpen As Integer,
                                          ByVal _owner As Object
                                          ) As Boolean
        If dt.Rows.Count = 0 Then ' отмена экспорта если таблица пустая
            XtraMessageBox.Show("Отсутствуют данные для экпорта ...",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Return False
        End If
        Try
            ProgressControll.EditValue = 0
            Dim colIndex As Integer = 0             ' текущий столбец
            Dim rowIndex As Integer = 0             ' текущая строка
            Dim rowTotal As Integer = dt.Rows.Count ' всего строк
            Dim wb As New Workbook                  ' книга Excel
            Dim ws As Worksheet                     ' лист в книге Excel
            ' запускаем файл из ресурсов
            wb.LoadDocument(SaveResToTemp(My.Resources.Workbook), DocumentFormat.Xlsx)
            ws = wb.Worksheets(0)
            ws.Name = SheetName                 ' имя листа
            ws.ActiveView.Zoom = 90             ' маштаб на листе
            ' сведения о файле
            wb.DocumentProperties.Author = pref_PerformerName
            wb.DocumentProperties.Company = "ПАО Красноярскэнергосбыт"
            wb.DocumentProperties.Manager = Application.CompanyName
            wb.DocumentProperties.Application = Application.ProductName
            ' создаем шапку таблицы
            For Each col As DataColumn In dt.Columns
                ws.Cells(rowIndex, colIndex).SetValueFromText(col.ColumnName)
                colIndex += 1
            Next : colIndex = 0 : rowIndex += 1
            ' заполняем таблицу
            For Each row As DataRow In dt.Rows              ' цикл по строкам
                ' отображение прогресса
                If (rowIndex * 100) / rowTotal >= 100 Then
                    ' чтобы не перешло за 100
                    ProgressControll.EditValue = 100
                Else
                    ProgressControll.EditValue = (rowIndex * 100) / rowTotal
                End If
                ProgressControll.Caption = "Экспорт данных в Microsoft Excel ... " & rowIndex.ToString("N0") & " из " & rowTotal.ToString("N0") & " строк"
                Application.DoEvents()
                ' цикл по столбцам
                For Each col As DataColumn In dt.Columns
                    ws.Cells(rowIndex, colIndex).SetValueFromText(row.Item(col).ToString)
                    colIndex += 1
                    ' индекс столбца сбрасываем
                Next : colIndex = 0 : rowIndex += 1
            Next
            Application.DoEvents()
            ' настройки оформления
            ws.Rows(0).Font.Bold = True                                                 ' жирный шрифт для шапки
            ws.AutoFilter.Apply(ws.GetDataRange)                                        ' вкл автофильтр
            ws.Cells.Font.Name = "Tahoma"                                               ' шрифт для всей таблицы
            ws.Cells.Font.Size = 9                                                      ' размер шрифта
            ws.Cells.Alignment.WrapText = False                                         ' отмена 'Перенос строк'
            ws.Cells.RowHeight = 55                                                     ' толщина строк
            ws.Cells.AutoFitColumns()                                                   ' авторазмер столбцов
            ws.GetDataRange.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)    ' границы ячеек
            ws.GetDataRange.Alignment.Vertical = SpreadsheetVerticalAlignment.Center    ' выравнивание по вертик. центр=
            wb.SaveDocument(FileName, DocumentFormat.OpenXml)                           ' сохранение файла

            ' спрашиваем открыть ли файл
            Select Case QuestionOpen
                Case 1
                    If XtraMessageBox.Show(_owner, "Данные экспортированы. Желаете открыть файл?" & Chr(10) &
                                                               "<b><u>" & FileName & "</u></b>",
                                                               Application.ProductName,
                                                               MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Question,
                                                               DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
                        ProgressControll.Caption = "Открытие книги Microsoft Excel ..."
                        OpenFile(FileName)
                    End If
                Case 2
                    ProgressControll.Caption = "Открытие книги Microsoft Excel ..."
                    OpenFile(FileName)
            End Select

            Return True
        Catch ex As Exception ' если ошибка
            XtraMessageBox.Show(_owner, ex.Message & Chr(10) & _
                   "Ошибка экспорта данных ...",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error)
            Return False
        End Try
    End Function
#End Region

    ' диалог для сохранения файлов
    Friend Function GetSaveFileName(ByVal filter As String, ByVal defaulName As String) As String
        Dim sfDialog As New SaveFileDialog()
        sfDialog.Filter = filter
        sfDialog.FileName = defaulName
        sfDialog.CheckPathExists = False
        sfDialog.CheckFileExists = False
        sfDialog.AddExtension = True
        sfDialog.RestoreDirectory = True
        sfDialog.AutoUpgradeEnabled = True
        If sfDialog.ShowDialog <> DialogResult.OK Then
            Return Nothing
        End If
        Return sfDialog.FileName
    End Function

#Region "Получение сохранение параметров форм (размер и положение)"
    Public Sub LoadViewForm(ByVal _Me As Object)
        Dim PreferenceForms As String = pref_UserSettings & "\" & _Me.Name & "\"
        ' Размер
        Dim SizeHeight As Integer = RegistryRead(PreferenceForms, "Size.Height", 0)
        Dim SizeWidth As Integer = RegistryRead(PreferenceForms, "Size.Width", 0)
        ' Положение
        Dim LocationX As Integer = RegistryRead(PreferenceForms, "Location.X", 0)
        Dim LocationY As Integer = RegistryRead(PreferenceForms, "Location.Y", 0)

        If SizeHeight <> 0 Or SizeWidth <> 0 Then _Me.Size = New System.Drawing.Point(SizeWidth, SizeHeight)
        If LocationX <> 0 Or LocationY <> 0 Then _Me.StartPosition = FormStartPosition.Manual : _Me.Location = New System.Drawing.Point(LocationX, LocationY)
    End Sub
    Public Sub SaveViewForm(ByVal _Me As Object)
        Dim PreferenceForms As String = pref_UserSettings & "\" & _Me.Name & "\"
        ' Размер
        RegistryWrite(PreferenceForms, "Size.Height", _Me.Size.Height)
        RegistryWrite(PreferenceForms, "Size.Width", _Me.Size.Width)
        ' Положение
        RegistryWrite(PreferenceForms, "Location.X", _Me.Location.X)
        RegistryWrite(PreferenceForms, "Location.Y", _Me.Location.Y)
    End Sub
#End Region

    ' Определение индекса строки в DataTable по значению в ключевом поле
    Friend Function GetIndexRowInDataSourse(ByVal _DataTable As DataTable, ByVal _Value As String) As Integer
        If IsNothing(_DataTable.PrimaryKey) Then
            Console.WriteLine("Не найден столбец PrimaryKey в таблице " & _DataTable.TableName)
        Else
            If _Value <> "" Then Return _DataTable.Rows.IndexOf(_DataTable.Rows.Find(_Value))
        End If
    End Function

    ' День месяца в строковом формате (07)
    Friend Function GetDayNumberString(ByVal iDay As Integer) As String
        If Not IsNothing(iDay) Then
            If iDay < 10 Then
                Return "0" & iDay
            Else
                Return iDay
            End If
        Else
            Return "0"
        End If
    End Function

    ' Название месяца в строковом формате (Январь)
    ' iCase - падеж
    ' Именительный	кто? что?
    ' Родительный	кого? чего?
    ' Дательный	кому? чему?
    ' Винительный	кого? что?
    ' Творительный	кем? чем?
    ' Предложный	о ком? о чем?
    ' IsUpper: 0 - строчные; 1 - заглавные; 3 - по умолчанию
    Friend Function GetMonthString(ByVal iMonth As Integer, ByVal iCase As String, ByVal _VbStrConv As Microsoft.VisualBasic.VbStrConv) As String
        Dim iValue As String
        Select Case iCase
            Case "И" ' Именительный	кто? что?
                Select Case iMonth
                    Case 1
                        iValue = "Январь"
                    Case 2
                        iValue = "Февраль"
                    Case 3
                        iValue = "Март"
                    Case 4
                        iValue = "Апрель"
                    Case 5
                        iValue = "Май"
                    Case 6
                        iValue = "Июнь"
                    Case 7
                        iValue = "Июль"
                    Case 8
                        iValue = "Август"
                    Case 9
                        iValue = "Сентябрь"
                    Case 10
                        iValue = "Октябрь"
                    Case 11
                        iValue = "Ноябрь"
                    Case 12
                        iValue = "Декабрь"
                End Select
            Case "Р" ' Родительный	кого? чего?
                Select Case iMonth
                    Case 1
                        iValue = "Января"
                    Case 2
                        iValue = "Февраля"
                    Case 3
                        iValue = "Марта"
                    Case 4
                        iValue = "Апреля"
                    Case 5
                        iValue = "Мая"
                    Case 6
                        iValue = "Июня"
                    Case 7
                        iValue = "Июля"
                    Case 8
                        iValue = "Августа"
                    Case 9
                        iValue = "Сентября"
                    Case 10
                        iValue = "Октября"
                    Case 11
                        iValue = "Ноября"
                    Case 12
                        iValue = "Декабря"
                End Select
            Case "Д"
            Case "В"
            Case "Т"
            Case "П"
        End Select
        Return StrConv(iValue, _VbStrConv)
    End Function

    ' открыть файл - запустить процесс
    Friend Sub OpenFile(ByVal fileName As String, Optional ByVal iWindowStyle As ProcessWindowStyle = ProcessWindowStyle.Normal)
        If File.Exists(fileName) = False Then
            XtraMessageBox.Show("По указанному пути файл не найден ..." & Chr(10) & "<u><b>" & fileName & "</b></u>",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                DevExpress.Utils.DefaultBoolean.True)
            Exit Sub
        End If
        Dim pr As New Process
        pr.StartInfo.FileName = fileName
        pr.StartInfo.WindowStyle = iWindowStyle
        pr.Start()
    End Sub
End Module
