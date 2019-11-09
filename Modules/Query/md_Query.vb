Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSpellChecker
Imports DevExpress.Utils.Animation

Module mdSelect
    ' Переменные для клиентской базы данных
    Friend Conn As New SqlConnection                                                ' Подключение к БД
    Friend SqlCom As New SqlCommand                                                 ' Переменная для Sql запросов
    Friend iDataAdapter As New SqlDataAdapter                                       ' Адаптер для заполнения таблицы после запроса
    Friend iDataSet As New DataSet                                                  ' Таблица для хранения результатов запроса

    ' Переменные для локальной базы данных с настройками
    ' Friend Conn_Ce As New OleDbConnection                                         ' Подключение к локальной БД с настройками
    ' Friend SqlCom_Ce As New OleDbCommand                                          ' Переменная для Sql запросов локальной БД с настройками
    ' Friend iDataAdapter_Ce As New OleDbDataAdapter                                ' Адаптер БД с настройками для заполнения таблицы после запроса
    ' Friend iDataSet_Ce As New DataSet                                             ' Таблица для хранения результатов запроса из БД с настройками

    Friend iPlayer As New Media.SoundPlayer                                         ' Экземпляр плеера

    ' Переменные для универсального Селекта
    Friend iTableName As String                                                     ' Имя будущей таблицы
    Friend iCommandText As String                                                   ' Текст SQL запроса
    Friend CompliteLoad As Boolean                                                  ' Если False, запрос к базе еще выполняется

    ' Переменные для хранения параметров
    Friend pref_PerformerId As String                                               ' id текущего пользователя
    Friend pref_PerformerName As String                                             ' Имя текущего пользователя
    Friend pref_PerformerLogin As String                                            ' Логин текущего пользователя
    Friend pref_ServerIP As String                                                  ' ip текущего сервера
    Friend pref_DataBaseName As String                                              ' Имя текущей базы данных
    Friend pref_DivisionIndex As String                                             ' преффикс подразделения для регистрации
    Friend pref_AbonentId As String                                                 ' Id текущего абонента
    Friend pref_ConnectionString As String                                          ' Строка подключения текущего пользователя
    Friend pref_RegistryPath As String = "Software\Microsoft\.Net\"                 ' Префикс пути в реестре к настройкам
    Friend pref_ComplexSettings As String = pref_RegistryPath & "ComplexSettings\"  ' Префикс пути в реестре к настройкам комплекса
    Friend pref_UserSettings As String = pref_RegistryPath & "UserSettings\"        ' Префикс пути в реестре к настройкам пользователя
    Friend pref_CityOrVillages As Integer                                           ' 0 - городская база; 1 - сельская база

    Friend spCheck As New SpellChecker                                              ' Элемент для проверки орфографии
    Friend tmWaitAnimation As New TransitionManager                                 ' Анимация при ожидании

    ' -----------------------------------------------------------------------------------------------------------------
    ' -----------------------------------------------------------------------------------------------------------------
    ' Подключение к клиентской базе данных
    Friend Sub ConnectionToBase(ByVal server As String, ByVal user As String, ByVal pass As String, ByVal bd As String)
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.ConnectionString = "Persist Security Info=False;" & _
                                "Connect Timeout= 360;" & _
                                "User ID=" & user & ";" & _
                                "Password=" & pass & ";" & _
                                "Initial Catalog=" & bd & ";" & _
                                "Server=" & server          ' Строка подключения с переменными из входных параметров процедуры
        pref_ConnectionString = "Persist Security Info=False;" & _
                                "Connect Timeout= 360;" & _
                                "User ID=" & user & ";" & _
                                "Password=" & pass & ";" & _
                                "Initial Catalog=" & bd & ";" & _
                                "Server=" & server
        If Conn.State = ConnectionState.Closed Then Conn.Open() ' Открываем соединение
        GetConstantsDB(user)                                ' Вызов процедуры получения Имени, id пользователя и 1-ого лицевого в базе
    End Sub

    ' Универсальная процедура с входными параметрами для выборки из бызы
    ' iTableName - Имя создаваемой таблицы в iDataSet
    ' iCommandText - Текст команды
    ' iName - Имя дочерней процедуры
    Friend Function SelectQueryData(ByVal iTableName As String, ByVal iCommandText As String, Optional ByVal iName As String = "") As Boolean
        CompliteLoad = False    ' Запрос выполняется
        Try
            ' Если таблица iTableName существует то, очищае ее' Если таблица iTableName существует то, очищае ее
            If iDataSet.Tables.Contains(iTableName) Then iDataSet.Tables(iTableName).Clear()
            If Conn.State = ConnectionState.Closed Then Conn.Open() ' Открываем соединение
            With SqlCom ' Настраиваем команду SQL
                SqlCom.Connection = Conn                    ' Указываем подключение                                
                SqlCom.CommandText = iCommandText           ' Указываем текст запроса
                SqlCom.CommandTimeout = 600
            End With

            ' Настраиваем Адаптер
            With iDataAdapter
                .SelectCommand = SqlCom             ' Указываем команду на выгрузку данных из базы
                .Fill(iDataSet, iTableName)         ' Выгруженные данные заливаем в DateSet и именуем 
            End With
            CompliteLoad = True     ' Запрос выполнен
            Return True
            ' ======================================================================================================
            'iDataAdapter.Dispose()      ' Освобождаем ресурсы от DataAdapter
            'iDataSet.Dispose()          ' Освобождаем ресурсы от DataSet
            ' Если ошибка #5, значит привязка к DateSet уже определена
            'Catch When Err.Number = 5
            '    iDataAdapter.Update(iDataSet, iTableName)       ' Значит просто обновляем таблицу

            ' Сообщение при неудачном подключении к базе данных
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message & Chr(10) & _
                   "Ошибка вызова процедуры: <b>" & iName & "</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            CompliteLoad = True     ' Запрос выполнен
            Return False
        End Try
        Conn.Close()
    End Function
    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    ' Универсальная процедура с входными параметрами для выполнения процедур в базе
    ' iCommandText - текст команды
    ' iName - Имя дочерней процедуры
    Friend Function ExecuteQuery(ByVal iCommandText As String, Optional ByVal iName As String = "")
        Dim _DataAdapter As New SqlDataAdapter
        CompliteLoad = False    ' Запрос выполняется
        Try ' Попытка обновления данных
            If Conn.State = ConnectionState.Closed Then Conn.Open() ' Открываем соединение
            SqlCom.CommandText = iCommandText                       ' Запись текста команды
            SqlCom.ExecuteNonQuery()                                ' Выполнение команды на сервер
            SqlCom.CommandTimeout = 600
            CompliteLoad = True                                     ' Запрос выполнен
            Return True
            ' Сообщение при неудачном подключении к базе данных
        Catch ex As Exception
            ' Сообщение при неудачном подключении к базе данных
            XtraMessageBox.Show(ex.Message & Chr(10) & _
                   "Ошибка вызова процедуры: <b>" & iName & "</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            CompliteLoad = True     ' Запрос выполнен
            Return False
        End Try
        Conn.Close()            ' Закрываем соединение
    End Function

    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    ' Универсальная процедура с входными параметрами для выполнения скалярных функций в базе
    ' iCommandText - текст команды
    ' iName - Имя дочерней процедуры
    Friend Function ExecuteScalar(ByVal iCommandText As String, Optional ByVal iName As String = "")
        CompliteLoad = False    ' Запрос выполняется
        Try ' Попытка обновления данных
            If Conn.State = ConnectionState.Closed Then Conn.Open() ' Открываем соединение
            SqlCom.CommandText = iCommandText                       ' Запись текста команды
            SqlCom.CommandTimeout = 600                             ' Таймаут запроса

            CompliteLoad = True     ' Запрос выполнен
            Return SqlCom.ExecuteScalar()                           ' Выполнение команды на сервер
            ' Сообщение при неудачном подключении к базе данных
        Catch ex As Exception
            ' Сообщение при неудачном подключении к базе данных
            XtraMessageBox.Show(ex.Message & Chr(10) & _
                   "Ошибка вызова процедуры: <b>" & iName & "</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            CompliteLoad = True     ' Запрос выполнен
            Return Nothing
        End Try
        Conn.Close()            ' Закрываем соединение
    End Function



#Region "Резервный код для работы с Access"
    ' Универсальная процедура с входными параметрами для выборки из локальной базы настроек
    ' iTableName_Ce - Имя создаваемой таблицы в iDataSet
    ' iCommandText_Ce - Текст команды
    ' iName_Ce - Имя дочерней процедуры
    ' Friend Sub SelectQueryData_Ce(ByVal iTableName_Ce As String, ByVal iCommandText_Ce As String, Optional ByVal iName_Ce As String = "")
    ' If Conn_Ce.State = ConnectionState.Closed Then Conn_Ce.Open() ' Открываем соединение

    ' Try ' Настраиваем команду SQL
    ' With SqlCom_Ce
    ' Если таблица iTableName существует то, очищае ее
    ' If iDataSet_Ce.Tables.Contains(iTableName_Ce) Then iDataSet_Ce.Tables(iTableName_Ce).Clear()
    ' SqlCom_Ce.Connection = Conn_Ce                    ' Указываем подключение                                
    ' SqlCom_Ce.CommandText = iCommandText_Ce           ' Указываем текст запроса
    ' End With

    ' Настраиваем Адаптер
    ' With iDataAdapter_Ce
    ' .SelectCommand = SqlCom_Ce              ' Указываем команду на выгрузку данных из базы
    ' .Fill(iDataSet_Ce, iTableName_Ce)       ' Выгруженные данные заливаем в DateSet и именуем 
    ' End With
    ' ======================================================================================================

    ' iDataAdapter_Ce.Dispose()      ' Освобождаем ресурсы от DataAdapter
    ' iDataSet_Ce.Dispose()          ' Освобождаем ресурсы от DataSet
    ' Conn_Ce.Close()                ' Закрываем соединение

    ' Если ошибка #5, значит привязка к DateSet_Ce уже определена
    ' Catch When Err.Number = 5
    ' iDataAdapter_Ce.Update(iDataSet_Ce, iTableName_Ce)       ' Значит просто обновляем таблицу

    ' Сообщение при неудачном подключении к базе данных настроек
    ' Catch ex As Exception
    ' MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical & Chr(10) & _
    ' "Ошибка вызова прощедуры: " & iName_Ce, Application.ProductName)
    ' Conn_Ce.Close()
    ' End Try
    ' End Sub
#End Region

    ' Получаем имя и id пользователя зашедшего в программу
    Public Sub GetConstantsDB(ByVal user As String)
        ' Выгружаем данные зашедшего пользователя
        iTableName = "PerfInfo"                                                         ' Имя будущей таблицы
        iCommandText = "SELECT name, " & _
                              "PerformerId " & _
                       "FROM vPerformers " & _
                       "WHERE (vPerformers.Login='" & user & "')"                       ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "GetConstantsDB - FirstAbonent")      ' Выполняем универсальный Селект
        ' ======================================================================================================
        ' Выгружаем id первого лицевого в базе
        pref_AbonentId = RegistryRead(pref_RegistryPath & "HistoryLogins", "LastAbonentId", "NULL")
        ' Выполняем универсальный Селект
        SelectQueryData(
                        "FirstAbonent",
                        "SELECT AbonentId FROM vAbonents WHERE AbonentId = " & pref_AbonentId,
                        "GetConstantsDB - FirstAbonent"
                        )
        If iDataSet.Tables("FirstAbonent").Rows.Count = 0 Then
            SelectQueryData(
                            "FirstAbonent",
                            "SELECT top 1 AbonentId " & _
                            "FROM vAbonents ",
                            "GetConstantsDB - FirstAbonent"
                            )
            pref_AbonentId = iDataSet.Tables("FirstAbonent").Rows(0).Item("AbonentId").ToString
        End If
        ' ======================================================================================================
        ' Выгружаем преффикс подразделения
        iTableName = "DivisionIndex"                                                    ' Имя будущей таблицы
        iCommandText = "SELECT  (" & _
                                "SELECT      Value " & _
                                "FROM        Pr_PripyatConstants AS p " & _
                                "WHERE       Name = 'NomenclatureDivision' " & _
                                ") + '-' +   (" & _
                                            "Select Value " & _
                                            "FROM        Pr_PripyatConstants AS p1 " & _
                                            "WHERE       Name = 'NomenclatureGroup' " & _
                                            ") AS Value"                                   ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetConstantsDB - DivisionIndex")     ' Выполняем универсальный Селект

        ' Оперируем полученными данными
        ' ======================================================================================================


        ' Если значение LastAbonentId отсутствует, берем пербый лицевой из базы
        If pref_AbonentId = "" Then pref_AbonentId = iDataSet.Tables("FirstAbonent").Rows(0).Item("AbonentId")

        pref_PerformerId = iDataSet.Tables("PerfInfo").Rows(0).Item("PerformerId")                          ' Запись в настройки id текущего пользователя
        pref_PerformerName = iDataSet.Tables("PerfInfo").Rows(0).Item("name")                               ' Запись в настройки имени текущего пользователя
        pref_DivisionIndex = iDataSet.Tables("DivisionIndex").Rows(0).Item("Value")                         ' Запись в настройки преффикса подразделения

        iDataSet.Tables("PerfInfo").DataSet.Tables.Remove("PerfInfo")                                       ' Удаляем PerfInfo из DataSet
        iDataSet.Tables("FirstAbonent").DataSet.Tables.Remove("FirstAbonent")                               ' Удаляем FirstAbonent из DataSet
        iDataSet.Tables("DivisionIndex").DataSet.Tables.Remove("DivisionIndex")                             ' Удаляем DivisionIndex из DataSet
        ' ======================================================================================================
        pref_CityOrVillages = ExecuteScalar("SELECT dbo.GetConstantValue('AttribAccount')", "Pr_fnsGetConstants")     ' Тип базы (0 - город; 1 - село)

    End Sub

    ' Получаем основные данные и историю состояния по Id из переменных pref_...
    Public Sub GetGeneralInfo()
        ' Выгружаем историю абонента
        iTableName = "AbonentHistory"       ' Имя будущей таблицы
        iCommandText = "Exec  Pr_GetAbonentHistory " & _
                             "@AbonentId=" & pref_AbonentId                     ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "GetGeneralInfo - AbonentHistory")    ' Выполняем универсальный Селект

        ' ======================================================================================================
        ' Выгружаем основную информацию по абоненту
        ' Выгружаем историю абонента
        iTableName = "GenInfo"              ' Имя будущей таблицы
        iCommandText = "   SELECT * " & _
                          "FROM vPr_AbonentInfo " & _
                          "WHERE(AbonentId =" & pref_AbonentId & ")"    ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "GetGeneralInfo - GenInfo")   ' Выполняем универсальный Селект
    End Sub

    ' Поиск абонента по номеру абонента
    Public Sub SearchAbonNumber(ByVal Number As String)
        ' Выгружаем найденные лицевые
        iTableName = "FindedAbonents"       ' Имя будущей таблицы
        iCommandText = "SELECT AbonentId, " & _
                               "AbonNumber AS '№ Абонента', " & _
                               "Fio AS 'ФИО', " & _
                               "Address AS 'Адрес' " & _
                       "FROM  vPr_AbonentInfo " & _
                       "WHERE AbonNumber LIKE '%" & Number & "%'"       ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "SearchAbonNumber")   ' Выполняем универсальный Селект
    End Sub

    ' Поиск абонента по номеру точки учета
    Public Sub SearchPointNumber(ByVal Number As String)
        ' Выгружаем найденные лицевые
        iTableName = "FindedAbonents"       ' Имя будущей таблицы
        iCommandText = "SELECT  vPoints_ListPointsInformation.AbonentId, " & _
                               "vPoints_ListPointsInformation.AbonNumber AS '№ Абонента', " & _
                               "vPoints_ListPointsInformation.AbonentName AS 'ФИО', " & _
                               "vPoints_ListPointsInformation.Address AS 'Адрес' " & _
                       "FROM    vPoints_ListPointsInformation INNER JOIN vPoints " & _
                               "ON vPoints_ListPointsInformation.PointId = vPoints.PointId " & _
                       "WHERE  (vPoints_ListPointsInformation.PointNumber LIKE '%" & Number & "%') AND (vPoints.EnergyTypeId = 1)"       ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "SearchPointNumber")                                                                   ' Выполняем универсальный Селект
    End Sub

    ' Поиск абонента по фамилии
    ' ======================================================================================================
    ' --------по фамилии Собственника
    Public Sub SearchManeSurname(ByVal SurName As String)
        ' Выгружаем найденные лицевые
        iTableName = "FindedAbonents"                            ' Имя будущей таблицы
        iCommandText = "SELECT AbonentId, " & _
                              "AbonNumber AS '№ Абонента', " & _
                              "Fio AS 'ФИО',  Address AS 'Адрес' " & _
                       "FROM   vPr_AbonentInfo " & _
                       "WHERE  SurName LIKE '" & SurName & "%'" & _
                       "ORDER BY Fio"                           ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "SearchManeSurname")      ' Выполняем универсальный Селект
    End Sub

    ' --------по фамилии члена семьи Квазар
    Public Sub SearchQuasarMember(ByVal SurName As String)
        ' Выгружаем найденные лицевые
        iTableName = "FindedAbonents"                            ' Имя будущей таблицы
        iCommandText = "SELECT vFamilyMembers.AbonentId, " & _
                              "vFamilyMembers.AbonNumber AS '№ Абонента', " & _
                              "vFamilyMembers.FullName AS 'ФИО', " & _
                              "vAbonents.CommAddressString AS 'Адрес' " & _
                       "FROM   vAbonents RIGHT OUTER JOIN vFamilyMembers " & _
                              "ON dbo.vAbonents.AbonentId = dbo.vFamilyMembers.AbonentId " & _
                       "WHERE  vFamilyMembers.SurName LIKE '" & SurName & "%'"           ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "SearchQuasarMember")                  ' Выполняем универсальный Селект
    End Sub
    ' ======================================================================================================

    ' Поиск абонента по адресу
    Public Sub SearchAddress(Optional ByVal ArealName As String = "%", _
                             Optional ByVal VillageName As String = "%", _
                             Optional ByVal StreetName As String = "%", _
                             Optional ByVal House As String = "%", _
                             Optional ByVal LetterHouse As String = "%", _
                             Optional ByVal Build As String = "%", _
                             Optional ByVal Room As String = "%")

        ' Выгружаем найденные лицевые
        iTableName = "FindedAbonents"                                   ' Имя будущей таблицы
        iCommandText = "SELECT	AbonentId, " & _
                               "AbonNumber AS '№ Абонента', " & _
                               "Fio AS 'ФИО', " & _
                               "Address AS 'Адрес' " & _
                       "FROM vPr_AbonentInfo " & _
                       "WHERE ArealName like '" & ArealName & "' and " & _
                             "VillageName like '" & VillageName & "' and " & _
                             "StreetName like '" & StreetName & "' and " & _
                             "House like '" & House & "' and " & _
                             "LetterHouse like '" & LetterHouse & "' and " & _
                             "Build like '" & Build & "' and " & _
                             "Room  like '" & Room & "'"                ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "SearchAddress")      ' Выполняем универсальный Селект
    End Sub

    ' Выборка типов комнат (RoomType)
    Public Sub GetRoomType()
        ' Выгружаем типы комнат
        iTableName = "RoomType"                                         ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM vRoomTypes"                                ' Текст SQL запроса
        SelectQueryData(iTableName, iCommandText, "GetRoomType")        ' Выполняем универсальный Селект

        ' Оперируем полученными данными
        ' ======================================================================================================
        ' Добавляем в таблицу "RoomType" пустую запись
        With iDataSet.Tables("RoomType")
            Dim rowArray(1) As Object
            rowArray(0) = DBNull.Value
            rowArray(1) = ""
            .Rows.Add.ItemArray = rowArray
        End With
        ' ======================================================================================================
    End Sub

    ' Выборка истории членов семьи - по Квазару
    'Public Sub GetFamilyMemberHistory(ByVal iFunc As Integer, Optional ByVal FamilyMemberId As String = Nothing)
    '' Выгружаем историю членов семьи
    '   iTableName = "FamilyMember"                                     ' Имя будущей таблицы
    '  Select Case iFunc
    'Case 0 ' Выборка Членов семьи по Квазару с полной информацией
    '   iCommandText = "SELECT * " & _
    '                 "FROM vFamilyMembers  " & _
    '                "WHERE AbonentId =" & pref_AbonentId     ' Текст SQL запроса
    '     Case 1 ' Выборка Членов семьи по Квазару (только ФИО)
    'iCommandText = "SELECT FamilyMemberId, FullName " & _
    '              "FROM vFamilyMembers  " & _
    '             "WHERE AbonentId =" & pref_AbonentId     ' Текст SQL запроса
    'Case 2 ' Выборка полной информации члена семьи по Квазару (Для формы перекачки члена семьи из Квазара в Припять)
    'iCommandText = "SELECT SurName, " & _
    '                     "Name, " & _
    '                    "Patronymic, " & _
    '                   "RoleName AS FamilyRoles, " & _
    '                  "MaleAFemale AS SexMembers, " & _
    '                 "DateOfBirth AS PDDateOfBirth, " & _
    '                "DtBegin AS DtResidence, " & _
    '               "DtClosed AS DtUnResidence, " & _
    '              "RegistrAddress AS Residence, " & _
    '             "ShareOwner, " & _
    '            "PassportSeries AS PDSeries, " & _
    '           "PassportNumber AS PDNumber, " & _
    '          "PassportDate AS PDDateOfIssue, " & _
    '         "PassportSubunit AS PDSubunit, " & _
    '        "PassportSubunitCode AS PDSubunitCode, " & _
    '       "Passport " & _
    ' "FROM vFamilyMembers " & _
    '"WHERE FamilyMemberId =" & FamilyMemberId                       ' Текст SQL запроса
    'End Select
    'SelectQueryData(iTableName, iCommandText, "GetFamilyMemberHistory (iFunc - " & iFunc)    ' Выполняем универсальный Селект
    'End Sub

    ' Выборка семейных ролей
    'Public Sub GetFamilyRole()
    ' Выгружаем виды семейных ролей
    ' iTableName = "FamilyRole"                                               ' Имя будущей таблицы
    'iCommandText = "SELECT * " & _
    ' "FROM vPr_FamilyRoles"                                   ' Текст SQL запроса
    'SelectQueryData(iTableName, iCommandText, "GetFamilyRole")              ' Выполняем универсальный Селект
    'End Sub

    ' Выборка таблицы адресов
    'Public Sub GetAddressAreal()
    ' Выгружаем виды семейных ролей
    'iTableName = "AddressAreal"                                             ' Имя будущей таблицы
    'iCommandText = "SELECT * " & _
    '"FROM vAddressArealVillage " & _
    ' "WHERE StreetName <> ''" & _
    '"ORDER BY ArealName, VillageName, StreetName"            ' Текст SQL запроса
    'SelectQueryData(iTableName, iCommandText, "GetAddressAreal")            ' Выполняем универсальный Селект
    'End Sub

    ' Выборка таблицы членов семьи ПК Припять
    Public Sub GetPr_Members(ByVal iFunc As Integer)
        ' Выгружаем членов семьи ПК Припять
        Select Case iFunc
            Case 0 ' Вся информация по члену семьи в ПК Припять
                iTableName = "Members"                                                  ' Имя будущей таблицы
                iCommandText = "SELECT * " & _
                               "FROM vPr_Member " & _
                               "WHERE AbonentId = " & pref_AbonentId            ' Текст SQL запроса")
                SelectQueryData(iTableName, iCommandText, "GetPr_Members")              ' Выполняем универсальный Селект
            Case 1 ' Только ФИО для ComboBox_ов
                iTableName = "Members_FIO"                                              ' Имя будущей таблицы
                iCommandText = "SELECT MemberId, Surname + ' ' + Name + ' ' + Patronymic as FullName " & _
                               "FROM vPr_Member " & _
                               "WHERE AbonentId = " & pref_AbonentId            ' Текст SQL запроса")
                SelectQueryData(iTableName, iCommandText, "GetPr_Members")              ' Выполняем универсальный Селект
        End Select
    End Sub

    ' Выборка полов члена семьи ПК Припять
    ' Public Sub GetPr_SexMembers()
    ' Выгружаем пол члена семьи
    '  iTableName = "SexMember"                                                ' Имя будущей таблицы
    '  iCommandText = "SELECT * " & _
    '                 "FROM Pr_SexMembers "                                    ' Текст SQL запроса")
    '  SelectQueryData(iTableName, iCommandText, "GetPr_SexMembers")           ' Выполняем универсальный Селект
    'End Sub

    ' Получить текущую дату и время на сервере
    Public Function iTimeNow(ByRef iFunc As Integer)
        ' Выгружаем тукущую дату на сервере
        iTableName = "Now"                                                      ' Имя будущей таблицы
        iCommandText = "SELECT	CONVERT(VARCHAR,GETDATE(),104) +' '+ CONVERT(VARCHAR,GETDATE(),108) AS Now, " & _
                       "DATEPART(YEAR,GETDATE()) AS 'Year', " & _
                       "DATEPART(MONTH,GETDATE()) AS 'Month', " & _
                       "DATEPART(DAY,GETDATE()) AS DayNumber, " & _
                       "DATEPART(YEAR,GETDATE()) * 100 + DATEPARt(MONTH ,GETDATE()) AS 'Period', " & _
                       "DATENAME(MONTH,GETDATE()) AS 'MonthName', " & _
                       "CAST(DATEPARt(MONTH,GETDATE()) as VARCHAR) + ' - ' + CAST(DATENAME(MONTH,GETDATE()) as VARCHAR) as 'MonthNameString', " & _
                       "CAST(GETDATE() as DATE) as 'Date', " & _
                       "CAST(GETDATE() as TIME)	as 'Time', " & _
                       "CONVERT(VARCHAR,GETDATE(),104) as 'DateNormal', " & _
                       "CONVERT(VARCHAR,GETDATE(),104) + ' г.' as 'DateNormalStr'" ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "iTimeNow")                   ' Выполняем универсальный Селект
        ' Возвращаем результат по выбранной функции
        Select Case iFunc
            Case 0 ' iFunc - 0 (Now)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Now").ToString & "'"
            Case 1 ' iFunc - 1 (Year)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Year").ToString & "'"
            Case 2 ' iFunc - 2 (Month)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Month").ToString & "'"
            Case 3 ' iFunc - 3 (DayNumber)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("DayNumber").ToString & "'"
            Case 4 ' iFunc - 4 (Period)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Period").ToString & "'"
            Case 5 ' iFunc - 5 (MonthName)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("MonthName").ToString & "'"
            Case 6 ' iFunc - 6 (MonthNameString)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("MonthNameString").ToString & "'"
            Case 7 ' iFunc - 7 (Date)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Date").ToString & "'"
            Case 8 ' iFunc - 8 (Time)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("Time").ToString & "'"
            Case 9 ' iFunc - 9 (DateNormal)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("DateNormal").ToString & "'"
            Case 10 ' iFunc - 10 (DateNormalStr)
                Return "'" & iDataSet.Tables("Now").Rows(0).Item("DateNormalStr").ToString & "'"
        End Select
        Return Nothing
        iDataSet.Tables("Now").DataSet.Tables.Remove("Now")                     ' Удаляем TimeNow из DataSet
    End Function

    ' Выборка заявлений в суд
    Public Sub GetPr_PetitionsDebt()
        ' Выгружаем заявлений в суд
        iTableName = "PetitionsDebt"                                            ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM vPr_PetitionsDebt " & _
                       "WHERE(AbonentId =" & pref_AbonentId & ") " & _
                       "ORDER BY DtPeriodStart"                                 ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_PetitionsDebt")        ' Выполняем универсальный Селект
        ' Добавление итоговых сумм в конец iDataSet
        Dim iCount As Integer = iDataSet.Tables("PetitionsDebt").Rows.Count     ' Кол-во исков
        Dim iSumDebt, iSumGovTax, iDebtSummAfterDecision As Double                                      ' Сумма долгов и госпошлин
        If iCount <> 0 Then
            iSumDebt = SumValueInDateSet("PetitionsDebt", "DebtSumm")
            iSumGovTax = SumValueInDateSet("PetitionsDebt", "GovTax")
            iDebtSummAfterDecision = SumValueInDateSet("PetitionsDebt", "DebtSummAfterDecision")
            ' Запись итоговых сумм в массив
            With iDataSet.Tables("PetitionsDebt")
                Dim rowArray(8) As Object
                rowArray(0) = DBNull.Value
                rowArray(1) = DBNull.Value
                rowArray(2) = DBNull.Value
                rowArray(3) = DBNull.Value
                rowArray(4) = "Итого"
                rowArray(5) = iSumDebt
                rowArray(6) = iSumGovTax
                rowArray(7) = iDebtSummAfterDecision
                .Rows.Add.ItemArray = rowArray
            End With
        End If
    End Sub

    ' Выборка видов услуг
    Public Sub GetPr_EnergyTypes()
        iTableName = "EnergyTypes"                                              ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM Pr_EnergyTypes " & _
                       "ORDER BY EnergyTypeId"                                  ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_EnergyTypes")          ' Выполняем универсальный Селект
    End Sub

    ' Выборка типов заявлений в суд
    Public Sub GetPr_PetitionTypes()
        iTableName = "PetitionTypes"                                            ' Имя будущей таблицы
        iCommandText = "SELECT *  " & _
                       "FROM Pr_PetitionType  " & _
                       "ORDER BY PetitionTypeId"                                ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_PetitionTypes")        ' Выполняем универсальный Селект
    End Sub

    ' Выборка судебных инстанций
    Public Sub GetPr_CourtType()
        iTableName = "CourtType"                                                ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM Pr_CourtType  " & _
                       "ORDER BY CourtTypeId"                                   ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_CourtType")            ' Выполняем универсальный Селект
    End Sub

    ' Выборка номеров судебных участков
    Public Sub GetPr_JudicialArea(ByVal CourtTypeId As Integer)
        iTableName = "JudicialArea"                                             ' Имя будущей таблицы
        iCommandText = "SELECT JudicialAreaId, NameString FROM vPr_JudicialArea WHERE CourtTypeId = " & CourtTypeId & _
                        " ORDER BY CAST(REPLACE(Number, '№ ', '') AS int)"      ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_JudicialArea")         ' Выполняем универсальный Селект
    End Sub

    ' Выборка итогов слушания
    Public Sub GetPr_ListeningType()
        iTableName = "ListeningType"                                            ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM Pr_ListeningType " & _
                       "ORDER BY ListeningTypeId"                               ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_ListeningType")        ' Выполняем универсальный Селект
    End Sub

    ' Выборка видов решения суда
    Public Sub GetPr_DecisionType()
        iTableName = "DecisionType"                                             ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM Pr_DecisionType " & _
                       "ORDER BY Name"                                ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_DecisionType")         ' Выполняем универсальный Селект
    End Sub

    ' Выборка причин решения суда
    ' DecisionTypeId - Выборка подРешений завист от самого решения суда
    Public Sub GetPr_DecisionTypeExt(ByVal iFunc As Integer, Optional ByVal DecisionTypeId As Integer = 0)
        ' iFunc = 0 - Все причины
        ' iFunc = 1 - Причины по конкретному решению
        Select Case iFunc
            Case 0
                iTableName = "DecisionTypeExt"                                       ' Имя будущей таблицы
                iCommandText = "SELECT DecisionTypeExtId, Name " & _
                                "FROM Pr_DecisionTypeExt " & _
                                "ORDER BY Name"                            ' Текст SQL запроса")
                SelectQueryData(iTableName, iCommandText, "GetPr_DecisionTypeExt")      ' Выполняем универсальный Селект
            Case 1
                iTableName = "DecisionTypeExt"                                      ' Имя будущей таблицы
                iCommandText = "SELECT DecisionTypeExtId, Name " & _
                                "FROM Pr_DecisionTypeExt " & _
                                "WHERE DecisionTypeId = " & DecisionTypeId & _
                                "ORDER BY Name"                            ' Текст SQL запроса")
                SelectQueryData(iTableName, iCommandText, "GetPr_DecisionTypeExt")      ' Выполняем универсальный Селект
        End Select
    End Sub

    ' Выборка направлений решений суда
    Public Sub GetPr_DecisionDirections()
        iTableName = "DecisionDirections"                                       ' Имя будущей таблицы
        iCommandText = "SELECT * FROM " & _
                       "Pr_DecisionDirections " & _
                       "ORDER BY DecisionDirectionId"                           ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_DecisionDirections")   ' Выполняем универсальный Селект
    End Sub

    ' Выборка причин окончания исковых мероприятий
    Public Sub GetPr_ReasonForEnd()
        iTableName = "ReasonForEnd"                                             ' Имя будущей таблицы
        iCommandText = "SELECT * " & _
                       "FROM Pr_ReasonForEnd " & _
                       "ORDER BY ReasonForEndId"                                ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_ReasonForEnd")         ' Выполняем универсальный Селект
    End Sub

    ' Выборка слушаний по иску
    Public Sub GetPr_PetitionsListening(ByVal AbonentId As String, _
                                        ByVal MemberId As String, _
                                        ByVal DtPeriodStartId As String, _
                                        ByVal DtPeriodEndId As String, _
                                        ByVal EnergyTypeId As String)
        iTableName = "PetitionsListening"                                                   ' Имя будущей таблицы
        iCommandText = "SELECT     * " & _
                       "FROM       vPr_PetitionsListening " & _
                       "WHERE     (AbonentId = " & AbonentId & ") AND " & _
                                 "(MemberId = " & MemberId & ") AND " & _
                                 "(DtPeriodStart  = " & DtPeriodStartId & ") AND " & _
                                 "(DtPeriodEnd= " & DtPeriodEndId & ") AND " & _
                                 "(EnergyTypeId = " & EnergyTypeId & ")"                    ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_PetitionsListening")               ' Выполняем универсальный Селект
    End Sub

    ' Выборка платежных поручений по иску
    Public Sub GetPr_PayOrders(ByVal AbonentId As String, _
                               ByVal MemberId As String, _
                               ByVal DtPeriodStartId As String, _
                               ByVal DtPeriodEndId As String, _
                               ByVal EnergyTypeId As String)
        iTableName = "PayOrders"                                                     ' Имя будущей таблицы
        iCommandText = "SELECT     * " & _
                       "FROM       vPr_PayOrders " & _
                       "WHERE     (AbonentId = " & AbonentId & ") AND " & _
                                 "(MemberId = " & MemberId & ") AND " & _
                                 "(DtPeriodStart  = " & DtPeriodStartId & ") AND " & _
                                 "(DtPeriodEnd= " & DtPeriodEndId & ") AND " & _
                                 "(EnergyTypeId = " & EnergyTypeId & ")"             ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_PayOrders")                 ' Выполняем универсальный Селект
    End Sub

    ' Выборка статусов поручений по иску
    Public Sub GetPr_PayOrderStatus()
        iTableName = "PayOrderStatus"                                                   ' Имя будущей таблицы
        iCommandText = "SELECT   PayOrderStatusId, Name " & _
                       "FROM     Pr_PayOrderStatus " & _
                       "ORDER BY PayOrderStatusId"             ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_PayOrderStatus")                     ' Выполняем универсальный Селект
    End Sub

    ' Выборка материалов исполнительного производства
    'Public Sub GetPr_Petitions(ByVal AbonentId As String, _
    '                          ByVal MemberId As String, _
    '                           ByVal DtPeriodStartId As String, _
    '                           ByVal DtPeriodEndId As String, _
    '                           ByVal EnergyTypeId As String)
    '    iTableName = "Petitions"                                                     ' Имя будущей таблицы
    '    iCommandText = "SELECT     * " & _
    '                   "FROM       vPr_Petitions " & _
    '                   "WHERE     (AbonentId = " & AbonentId & ") AND " & _
    '                             "(MemberId = " & MemberId & ") AND " & _
    '                             "(DtPeriodStart  = " & DtPeriodStartId & ") AND " & _
    '                             "(DtPeriodEnd= " & DtPeriodEndId & ") AND " & _
    '                             "(EnergyTypeId = " & EnergyTypeId & ")"             ' Текст SQL запроса")
    '    SelectQueryData(iTableName, iCommandText, "GetPr_Petitions")                 ' Выполняем универсальный Селект
    'End Sub

    ' Выборка судебных участков
    ' Public Sub GetPr_JudicialAreaList(ByVal CourtTypeId As String)
    '     iTableName = "JudicialAreaList"                                         ' Имя будущей таблицы
    '    iCommandText = "SELECT   * " & _
    '                   "FROM     vPr_JudicialArea " & _
    '                   "WHERE CourtTypeId = " & CourtTypeId                 ' Текст SQL запроса")
    '    SelectQueryData(iTableName, iCommandText, "GetPr_JudicialAreaList")    ' Выполняем универсальный Селект
    'End Sub

    ' Выборка судей по участку
    Public Sub GetPr_Judges(ByVal CourtTypeId As String)
        iTableName = "Judges"                                       ' Имя будущей таблицы
        iCommandText = "SELECT   * " & _
                       "FROM     vPr_Judges " & _
                       "WHERE CourtTypeId = CAST (" & CourtTypeId & " as int) " & _
                       "ORDER BY Name"                              ' Текст SQL запроса")
        SelectQueryData(iTableName, iCommandText, "GetPr_Judges")   ' Выполняем универсальный Селект
    End Sub
End Module


#Region "Процедуры обновления данных в базе базе"
Module mdInsertUpdate


#Region "Резервный код для работы с Accesse"
    ' Универсальная процедура с входными параметрами для выборки из бызы
    ' iCommandText - текст команды
    ' iName - Имя дочерней процедуры
    ' Friend Function InsertUpdateDeleteQueryData_Ce(ByVal iCommandText_Ce As String, Optional ByVal iName_Ce As String = "")
    ' Try ' Попытка обновления данных
    ' Conn_Ce.Open()                                     ' Открываем соединение
    ' SqlCom_Ce.CommandText = iCommandText_Ce            ' Запись текста команды
    ' SqlCom_Ce.ExecuteNonQuery()                        ' Выполнение команды на сервер
    ' Conn_Ce.Close()                                    ' Закрываем соединение
    ' Return True
    ' Сообщение при неудачном подключении к базе данных
    ' Catch ex As Exception
    ' Сообщение при неудачном подключении к базе данных
    ' MsgBox(ex.Message & Chr(10) & _
    ' "Ошибка вызова прощедуры: " & iName_Ce, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, Application.ProductName)
    ' Conn_Ce.Close()
    ' Return False
    ' End Try
    ' End Function
#End Region

    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    ' =================================================vPr_Member==================================================
    ' Обновление vPr_Member
    'Public Function Update_vPrMember(ByVal Surname As String, ByVal Name As String, ByVal Patronymic As String, _
    '                            ByVal FamilyRoleId As String, ByVal DtResidence As String, ByVal DtUnResidence As String, _
    '                            ByVal SexMembersId As String, ByVal ShareOwner As String, ByVal Residence As String, _
    '                            ByVal PDDateOfBirth As String, ByVal PDSeries As String, ByVal PDNumber As String, _
    '                            ByVal PDDateOfIssue As String, ByVal PDSubunit As String, ByVal PDSubunitCode As String, _
    '                            ByVal Phone As String, ByVal Email As String, ByVal AddressOfLive As String, _
    '                            ByVal PlaceOfWork As String, ByVal DtUpdate As String, ByVal UpdatePerformerId As String, _
    '                            ByVal Note As String, ByVal AbonentId As String, ByVal MemberId As String)
    ' Текст команды для обновления
    '    iCommandText = "UPDATE Pr_Members " & _
    '                     "SET Surname=" & Surname & ", " & _
    '                         "Name=" & Name & ", " & _
    '                         "Patronymic=" & Patronymic & ", " & _
    '                         "FamilyRoleId=" & FamilyRoleId & ", " & _
    '                         "DtResidence=" & DtResidence & ", " & _
    '                         "DtUnResidence=" & DtUnResidence & ", " & _
    '                         "SexMembersId=" & SexMembersId & ", " & _
    '                         "ShareOwner=" & "'" & ShareOwner & "', " & _
    '                         "Residence=" & Residence & ", " & _
    '                         "PDDateOfBirth=" & PDDateOfBirth & ", " & _
    '                        "PDSeries=" & PDSeries & ", " & _
    ''                        "PDNumber=" & PDNumber & ", " & _
    '                        "PDDateOfIssue=" & PDDateOfIssue & ", " & _
    '                         "PDSubunit=" & PDSubunit & ", " & _
    '                         "PDSubunitCode=" & PDSubunitCode & ", " & _
    '                         "Phone=" & Phone & ", " & _
    '                         "Email=" & Email & ", " & _
    '                         "AddressOfLive=" & AddressOfLive & ", " & _
    '                         "PlaceOfWork=" & PlaceOfWork & ", " & _
    '                         "DtUpdate=" & DtUpdate & " , " & _
    '                         "UpdatePerformerId=" & UpdatePerformerId & ", " & _
    '                         "Note=" & Note & " " & _
    '                  "WHERE  AbonentId = " & AbonentId & " AND " & _
    '                         "MemberId = " & MemberId
    ' Выполнение команды
    '    If ExecuteQuery(iCommandText, "Update_vPrMember") Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    ' Вставка данных в vPr_Member
    Public Function Insert_vPrMember(ByVal AbonentId As String, ByVal Surname As String, ByVal Name As String, ByVal Patronymic As String, _
                                ByVal FamilyRoleId As String, ByVal DtResidence As String, ByVal DtUnResidence As String, _
                                ByVal DtCreate As String, ByVal CreatePerformerId As String, ByVal SexMembersId As String, _
                                ByVal ShareOwner As String, ByVal Residence As String, _
                                ByVal PDDateOfBirth As String, ByVal PDSeries As String, ByVal PDNumber As String, _
                                ByVal PDDateOfIssue As String, ByVal PDSubunit As String, ByVal PDSubunitCode As String, _
                                ByVal Phone As String, ByVal Email As String, ByVal AddressOfLive As String, _
                                ByVal PlaceOfWork As String, ByVal DtUpdate As String, ByVal UpdatePerformerId As String, _
                                ByVal Note As String)
        ' Текст команды для обновления
        iCommandText = "INSERT INTO Pr_Members (AbonentId, " & _
                                               "Surname, " & _
                                               "Name, " & _
                                               "Patronymic, " & _
                                               "FamilyRoleId, " & _
                                               "DtResidence, " & _
                                               "DtUnResidence, " & _
                                               "DtCreate, " & _
                                               "CreatePerformerId, " & _
                                               "SexMembersId, " & _
                                               "ShareOwner, " & _
                                               "Residence, " & _
                                               "PDDateOfBirth, " & _
                                               "PDSeries, " & _
                                               "PDNumber, " & _
                                               "PDDateOfIssue, " & _
                                               "PDSubunit, " & _
                                               "PDSubunitCode, " & _
                                               "Phone, " & _
                                               "Email, " & _
                                               "AddressOfLive, " & _
                                               "PlaceOfWork, " & _
                                               "DtUpdate, " & _
                                               "UpdatePerformerId, " & _
                                               "Note) " & _
                               "VALUES (" & AbonentId & ", " & _
                                            Surname & ", " & _
                                            Name & ", " & _
                                            Patronymic & ", " & _
                                            FamilyRoleId & ", " & _
                                            DtResidence & ", " & _
                                            DtUnResidence & ", " & _
                                            DtCreate & ", " & _
                                            CreatePerformerId & ", " & _
                                            SexMembersId & ", " & _
                                            "'" & ShareOwner & "', " & _
                                            Residence & ", " & _
                                            PDDateOfBirth & ", " & _
                                            PDSeries & ", " & _
                                            PDNumber & ", " & _
                                            PDDateOfIssue & ", " & _
                                            PDSubunit & ", " & _
                                            PDSubunitCode & ", " & _
                                            Phone & ", " & _
                                            Email & ", " & _
                                            AddressOfLive & ", " & _
                                            PlaceOfWork & ", " & _
                                            DtUpdate.ToString & ", " & _
                                            UpdatePerformerId & ", " & _
                                            Note & " )"
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Insert_vPrMember") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Удаление записи из таблицы Pr_Member
    Public Function Delete_PrMember(ByRef MemberId As String)
        iCommandText = "DELETE FROM Pr_Members " & _
                              "WHERE MemberId = " & MemberId
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Delete_PrMember") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ==============================================================================================================


    ' =================================================Pr_PetitionsDebt=============================================
    ' Обновление Pr_PetitionsDebt
    Public Function Update_PrPetitionsDebt(ByVal AbonentId As String, ByVal MemberId As String, ByVal DtPeriodStartId As String, _
                                            ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, ByVal DtPeriodStart As String, _
                                            ByVal DtPeriodEnd As String, ByVal EnergyType As String, ByVal DebtSumm As String, _
                                            ByVal GovTax As String, ByVal CourtTypeId As String, ByVal PetitionTypeId As String, _
                                            ByVal NumberPetitions As String, ByVal DtPetitions As String, ByVal DtDispatch As String, _
                                            ByVal DtDecision As String, ByVal DealNumber As String, ByVal DebtSummAfterDecision As String, ByVal JudicialAreaId As String, _
                                            ByVal DecisionNumber As String, ByVal DecisionTypeId As String, ByVal DecisionTypeExtId As String, _
                                            ByVal DecisionDirectionId As String, ByVal DtDecisionDirection As String, ByVal DtJudicialOrder As String, ByVal DtClose As String, _
                                            ByVal ReasonForEndId As String, ByVal DtUpdate As String, ByVal UpdatePerformerId As String,
                                            ByVal Note As String, ByVal PetitionsPacksId As String)
        ' Текст команды для обновления
        iCommandText = "UPDATE Pr_PetitionsDebt " & _
                          "SET DtPeriodStart=" & DtPeriodStart & ", " & _
                              "DtPeriodEnd=" & DtPeriodEnd & ", " & _
                              "EnergyTypeId=" & EnergyType & ", " & _
                              "DebtSumm=" & DebtSumm & ", " & _
                              "GovTax=" & GovTax & ", " & _
                              "CourtTypeId=" & CourtTypeId & ", " & _
                              "PetitionTypeId=" & PetitionTypeId & ", " & _
                              "NumberPetitions=" & NumberPetitions & ", " & _
                              "DtPetitions=" & DtPetitions & ", " & _
                              "DtDispatch=" & DtDispatch & ", " & _
                              "DtDecision=" & DtDecision & ", " & _
                              "DealNumber=" & DealNumber & ", " & _
                              "DebtSummAfterDecision=" & DebtSummAfterDecision & ", " & _
                              "JudicialAreaId=" & JudicialAreaId & ", " & _
                              "DecisionNumber=" & DecisionNumber & ", " & _
                              "DecisionTypeId=" & DecisionTypeId & ", " & _
                              "DecisionTypeExtId=" & DecisionTypeExtId & ", " & _
                              "DecisionDirectionId=" & DecisionDirectionId & ", " & _
                              "DtDecisionDirection=" & DtDecisionDirection & ", " & _
                              "DtJudicialOrder=" & DtJudicialOrder & " , " & _
                              "DtClose=" & DtClose & ", " & _
                              "ReasonForEndId=" & ReasonForEndId & ", " & _
                              "DtUpdate=" & DtUpdate & ", " & _
                              "UpdatePerformerId=" & UpdatePerformerId & ", " & _
                              "Note=" & Note & ", " & _
                              "PetitionsPacksId=" & PetitionsPacksId & " " & _
                        "WHERE AbonentId = " & AbonentId & " AND " & _
                              "MemberId = " & MemberId & " AND " & _
                              "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                              "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                              "EnergyTypeId = " & EnergyTypeId & _
                     " EXECUTE dbo.Pr_ReCalculatePetitionPack " & PetitionsPacksId
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Update_Pr_PetitionsDebt") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Вставка Pr_PetitionsDebt
    Public Function Insert_PrPetitionsDebt(ByVal AbonentId As String, ByVal MemberId As String, ByVal Pr_EnergyTypeId As String, _
                                           ByVal DtPeriodStart As String, ByVal DtPeriodEnd As String, ByVal DebtSumm As String, _
                                            ByVal GovTax As String, ByVal CourtTypeId As String, ByVal PetitionTypeId As String, _
                                             ByVal JudicialAreaId As String, ByVal NumberPetitions As String, ByVal DtPetitions As String, _
                                             ByVal DtCreate As String, ByVal CratePerformerId As String, ByVal PeriodCreate As String)
        iCommandText = "DECLARE @PackID int " & _
        "SET  @PackID = dbo.Pr_fnsGetCountPacks ( " & Pr_EnergyTypeId & " ," & PetitionTypeId & ")" & _
"If ISNULL(@PackID, 0) = 0 " & _
        "BEGIN " & _
        "INSERT INTO Pr_PetitionsPacks (DtCreate, " & _
                                       "CratePerformerId, " & _
                                       "PackNumber, " & _
                                       "Pr_EnergyTypeId, " & _
                                       "PetitionsPacksType, " & _
                                       "PetitionsCount, " & _
                                       "PetitionsSumDebt, " & _
                                       "PetitionsSumGovTax, " & _
                                       "PetitionsSumDebtAfterDecision, " & _
                                       "Note, " & _
                                       "DtUpdate, " & _
                                       "PeriodCreate) " & _
                       "VALUES (" & DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    "dbo.Pr_fnsGetNamePetitionPack (" & PetitionTypeId & "), " & _
                                    Pr_EnergyTypeId & ", " & _
                                    PetitionTypeId & ", " & _
                                    "0, " & _
                                    "0, " & _
                                    "0, " & _
                                    "0, " & _
                                    "'Пачка создана автоматически', " & _
                                    DtCreate & ", " & _
                                    PeriodCreate & " ) " & _
        "SET  @PackID = dbo.Pr_fnsGetCountPacks ( " & Pr_EnergyTypeId & " ," & PetitionTypeId & ")" & _
 "INSERT INTO Pr_PetitionsDebt (AbonentId, " & _
                                       "MemberId, " & _
                                       "DtCreate, " & _
                                       "CratePerformerId, " & _
                                       "DtPeriodStart, " & _
                                       "DtPeriodEnd, " & _
                                       "EnergyTypeId, " & _
                                       "DebtSumm, " & _
                                       "GovTax, " & _
                                       "CourtTypeId, " & _
                                       "PetitionTypeId, " & _
                                       "JudicialAreaId, " & _
                                       "NumberPetitions, " & _
                                       "DtPetitions, " & _
                                       "DtUpdate, " & _
                                       "UpdatePerformerId, " & _
                                       "PeriodCreate, " & _
                                       "PetitionsPacksId) " & _
                       "VALUES (" & AbonentId & ", " & _
                                    MemberId & ", " & _
                                    DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    DtPeriodStart & ", " & _
                                    DtPeriodEnd & ", " & _
                                    Pr_EnergyTypeId & ", " & _
                                    DebtSumm & ", " & _
                                    GovTax & ", " & _
                                    CourtTypeId & ", " & _
                                    PetitionTypeId & ", " & _
                                    JudicialAreaId & ", " & _
                                    NumberPetitions & ", " & _
                                    DtPetitions & ", " & _
                                    DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    PeriodCreate & ", " & _
                                    "dbo.Pr_fnsGetCountPacks ( " & Pr_EnergyTypeId & " ," & PetitionTypeId & ") ) " & _
                        "EXECUTE dbo.Pr_ReCalculatePetitionPack @PackID " & _
        "End " & _
        "Else " & _
 "INSERT INTO Pr_PetitionsDebt (AbonentId, " & _
                                       "MemberId, " & _
                                       "DtCreate, " & _
                                       "CratePerformerId, " & _
                                       "DtPeriodStart, " & _
                                       "DtPeriodEnd, " & _
                                       "EnergyTypeId, " & _
                                       "DebtSumm, " & _
                                       "GovTax, " & _
                                       "CourtTypeId, " & _
                                       "PetitionTypeId, " & _
                                       "JudicialAreaId, " & _
                                       "NumberPetitions, " & _
                                       "DtPetitions, " & _
                                       "DtUpdate, " & _
                                       "UpdatePerformerId, " & _
                                       "PeriodCreate, " & _
                                       "PetitionsPacksId) " & _
                       "VALUES (" & AbonentId & ", " & _
                                    MemberId & ", " & _
                                    DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    DtPeriodStart & ", " & _
                                    DtPeriodEnd & ", " & _
                                    Pr_EnergyTypeId & ", " & _
                                    DebtSumm & ", " & _
                                    GovTax & ", " & _
                                    CourtTypeId & ", " & _
                                    PetitionTypeId & ", " & _
                                    JudicialAreaId & ", " & _
                                    NumberPetitions & ", " & _
                                    DtPetitions & ", " & _
                                    DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    PeriodCreate & ", " & _
                                    "dbo.Pr_fnsGetCountPacks (" & Pr_EnergyTypeId & " ," & PetitionTypeId & ") )" & _
                        "EXECUTE dbo.Pr_ReCalculatePetitionPack @PackID "
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Insert_Pr_PetitionsDebt") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Удаление записи из таблицы Pr_PetitionsDebt
    Public Function Delete_PrPetitionsDebt(ByVal AbonentId As String, ByVal MemberId As String, _
                                           ByVal DtPeriodStartId As String, ByVal DtPeriodEndId As String, _
                                           ByVal EnergyTypeId As String, ByVal PetitionsPacksId As String)
        ' Если удаляется иск, сначала нужно удалить все слушания по нему
        iCommandText = "DELETE FROM  Pr_PetitionsListening " & _
                              "WHERE AbonentId = " & AbonentId & " AND " & _
                                    "MemberId = " & MemberId & " AND " & _
                                    "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                                    "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                                    "EnergyTypeId = " & EnergyTypeId & _
        " " & _
                                    "DELETE FROM  Pr_PetitionsDebt " & _
                              "WHERE AbonentId = " & AbonentId & " AND " & _
                                    "MemberId = " & MemberId & " AND " & _
                                    "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                                    "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                                    "EnergyTypeId = " & EnergyTypeId & _
        " " & _
                                " EXECUTE dbo.Pr_ReCalculatePetitionPack " & PetitionsPacksId
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Delete_PrMember") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ==============================================================================================================


    ' =================================================Pr_PetitionsListening=============================================
    ' Обновление Pr_PetitionsListening
    Public Function Update_PrPetitionsListening(ByVal AbonentId As String, ByVal MemberId As String, ByVal DtPeriodStartId As String, _
                                                ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, ByVal DtListeningId As String, _
                                                ByVal DtListening As String, ByVal DtPostpone As String, ByVal ListeningTypeId As String, ByVal PostponeReasonId As String, _
                                                ByVal DtCreate As String, ByVal CratePerformerId As String, ByVal DtUpdate As String, _
                                                ByVal UpdatePerformerId As String, ByVal ListeningPostpone As Boolean)
        ' ListeningType - если значение TRUE то, слушание перенесено на определенную дату, значит добавляем в таблицу
        '                 еще одну строку с результатов в ОЖИДАНИИ
        '                 если значение FALSE то, добавляется только одна строка
        Select Case ListeningPostpone
            Case True ' слушание перенесено
                iCommandText = "UPDATE Pr_PetitionsListening " & _
                                  "SET DtListening = " & DtListening & ", " & _
                                      "DtPostpone = " & DtPostpone & ", " & _
                                      "ListeningTypeId = " & ListeningTypeId & ", " & _
                                      "DtUpdate = " & DtUpdate & ", " & _
                                      "UpdatePerformerId = " & UpdatePerformerId &
                                "WHERE AbonentId = " & AbonentId & " AND " & _
                                      "MemberId = " & MemberId & " AND " & _
                                      "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                                      "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                                      "EnergyTypeId = " & EnergyTypeId & " AND " & _
                                      "DtListening = " & DtListeningId & _
                "" & _
                "INSERT INTO Pr_PetitionsListening (AbonentId, " & _
                                                    "MemberId, " & _
                                                    "DtPeriodStart, " & _
                                                    "DtPeriodEnd, " & _
                                                    "EnergyTypeId, " & _
                                                    "DtListening, " & _
                                                    "ListeningTypeId, " & _
                                                    "PostponeReasonId, " & _
                                                    "DtCreate, " & _
                                                    "CratePerformerId, " & _
                                                    "DtUpdate, " & _
                                                    "UpdatePerformerId) " & _
                "VALUES (" & AbonentId & ", " & _
                            MemberId & ", " & _
                            DtPeriodStartId & ", " & _
                            DtPeriodEndId & ", " & _
                            EnergyTypeId & ", " & _
                            DtPostpone & ", " & _
                            3 & ", " & _
                            PostponeReasonId & ", " & _
                            DtCreate & ", " & _
                            CratePerformerId & ", " & _
                            DtUpdate & ", " & _
                            UpdatePerformerId & " ) "

            Case False ' слушание с результатом
                iCommandText = "UPDATE Pr_PetitionsListening " & _
                                  "SET DtListening = " & DtListening & ", " & _
                                      "DtPostpone = " & DtPostpone & ", " & _
                                      "ListeningTypeId = " & ListeningTypeId & ", " & _
                                      "DtUpdate = " & DtUpdate & ", " & _
                                      "UpdatePerformerId = " & UpdatePerformerId &
                                "WHERE AbonentId = " & AbonentId & " AND " & _
                                      "MemberId = " & MemberId & " AND " & _
                                      "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                                      "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                                      "EnergyTypeId = " & EnergyTypeId & " AND " & _
                                      "DtListening = " & DtListeningId
        End Select
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Insert_PrPetitionsListening") Then
            Return True
        Else
            Return False
        End If

    End Function
    ' Вставка Pr_PetitionsListening
    Public Function Insert_PrPetitionsListening(ByVal AbonentId As String, ByVal MemberId As String, ByVal DtPeriodStartId As String, _
                                                ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, ByVal DtListening As String, _
                                                ByVal DtPostpone As String, ByVal ListeningTypeId As String, ByVal PostponeReasonId As String, _
                                                ByVal DtCreate As String, ByVal CratePerformerId As String, ByVal DtUpdate As String, _
                                                ByVal UpdatePerformerId As String, ByVal ListeningPostpone As Boolean)
        ' ListeningType - если значение TRUE то, слушание перенесено на определенную дату, значит добавляем в таблицу
        '                 еще одну строку с результатов в ОЖИДАНИИ
        '                 если значение FALSE то, добавляется только одна строка
        Select Case ListeningPostpone
            Case True ' слушание перенесено
                iCommandText = "INSERT INTO Pr_PetitionsListening (AbonentId, " & _
                               "MemberId, " & _
                               "DtPeriodStart, " & _
                               "DtPeriodEnd, " & _
                               "EnergyTypeId, " & _
                               "DtListening, " & _
                               "DtPostpone, " & _
                               "ListeningTypeId, " & _
                               "PostponeReasonId, " & _
                               "DtCreate, " & _
                               "CratePerformerId, " & _
                               "DtUpdate, " & _
                               "UpdatePerformerId) " & _
               "VALUES (" & AbonentId & ", " & _
                            MemberId & ", " & _
                            DtPeriodStartId & ", " & _
                            DtPeriodEndId & ", " & _
                            EnergyTypeId & ", " & _
                            DtListening & ", " & _
                            DtPostpone & ", " & _
                            ListeningTypeId & ", " & _
                            PostponeReasonId & ", " & _
                            DtCreate & ", " & _
                            CratePerformerId & ", " & _
                            DtUpdate & ", " & _
                            UpdatePerformerId & " ) " & _
                "" & _
                "INSERT INTO Pr_PetitionsListening (AbonentId, " & _
                                                    "MemberId, " & _
                                                    "DtPeriodStart, " & _
                                                    "DtPeriodEnd, " & _
                                                    "EnergyTypeId, " & _
                                                    "DtListening, " & _
                                                    "ListeningTypeId, " & _
                                                    "PostponeReasonId, " & _
                                                    "DtCreate, " & _
                                                    "CratePerformerId, " & _
                                                    "DtUpdate, " & _
                                                    "UpdatePerformerId) " & _
                "VALUES (" & AbonentId & ", " & _
                            MemberId & ", " & _
                            DtPeriodStartId & ", " & _
                            DtPeriodEndId & ", " & _
                            EnergyTypeId & ", " & _
                            DtPostpone & ", " & _
                            3 & ", " & _
                            PostponeReasonId & ", " & _
                            DtCreate & ", " & _
                            CratePerformerId & ", " & _
                            DtUpdate & ", " & _
                            UpdatePerformerId & " ) "

            Case False ' слушание с результатом
                iCommandText = "INSERT INTO Pr_PetitionsListening (AbonentId, " & _
                                               "MemberId, " & _
                                               "DtPeriodStart, " & _
                                               "DtPeriodEnd, " & _
                                               "EnergyTypeId, " & _
                                               "DtListening, " & _
                                               "DtPostpone, " & _
                                               "ListeningTypeId, " & _
                                               "PostponeReasonId, " & _
                                               "DtCreate, " & _
                                               "CratePerformerId, " & _
                                               "DtUpdate, " & _
                                               "UpdatePerformerId) " & _
                               "VALUES (" & AbonentId & ", " & _
                                            MemberId & ", " & _
                                            DtPeriodStartId & ", " & _
                                            DtPeriodEndId & ", " & _
                                            EnergyTypeId & ", " & _
                                            DtListening & ", " & _
                                            DtPostpone & ", " & _
                                            ListeningTypeId & ", " & _
                                            PostponeReasonId & ", " & _
                                            DtCreate & ", " & _
                                            CratePerformerId & ", " & _
                                            DtUpdate & ", " & _
                                            UpdatePerformerId & " ) "
        End Select
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Insert_PrPetitionsListening") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Удаление Pr_PetitionsListening
    Public Function Delete_PrPetitionsListening(ByVal AbonentId As String, ByVal MemberId As String, ByVal DtPeriodStartId As String, _
                                            ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, ByVal DtListening As String)

        iCommandText = "DELETE FROM  Pr_PetitionsListening " & _
                              "WHERE AbonentId = " & AbonentId & " AND " & _
                                    "MemberId = " & MemberId & " AND " & _
                                    "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                                    "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                                    "EnergyTypeId = " & EnergyTypeId & " AND " & _
                                    "DtListening = " & DtListening
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Delete_PrMember") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ==============================================================================================================


    ' =================================================Pr_PayOrders=============================================
    ' Обновление Pr_PayOrders
    Public Function Update_PrPayOrders(ByVal PayOrderId As String, ByVal AbonentId As String, ByVal MemberId As String, _
                                       ByVal DtPeriodStartId As String, ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, _
                                       ByVal DtPayOrder As String, ByVal SumPayOrder As String, ByVal NumberPayOrder As String, _
                                       ByVal PayOrderStatusId As String, ByVal DtUpdate As String, ByVal UpdatePerformerId As String)
        iCommandText = "UPDATE Pr_PayOrders " & _
                          "SET DtPayOrder = " & DtPayOrder & ", " & _
                              "SumPayOrder = " & SumPayOrder & ", " & _
                              "NumberPayOrder = " & NumberPayOrder & ", " & _
                              "PayOrderStatusId = " & PayOrderStatusId & " " & _
                        "WHERE PayOrderId = " & PayOrderId & " AND " & _
                              "AbonentId = " & AbonentId & " And " & _
                              "MemberId = " & MemberId & " AND " & _
                              "DtPeriodStart = " & DtPeriodStartId & " AND " & _
                              "DtPeriodEnd = " & DtPeriodEndId & " AND " & _
                              "EnergyTypeId = " & EnergyTypeId
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Update_PrPayOrders") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Добавление в Pr_PayOrders
    Public Function Insert_PrPayOrders(ByVal AbonentId As String, ByVal MemberId As String, ByVal DtPeriodStartId As String, _
                                       ByVal DtPeriodEndId As String, ByVal EnergyTypeId As String, ByVal DtPayOrder As String, _
                                       ByVal SumPayOrder As String, ByVal NumberPayOrder As String, ByVal PayOrderStatusId As String, _
                                       ByVal DtCreate As String, ByVal CratePerformerId As String, ByVal DtUpdate As String, _
                                       ByVal UpdatePerformerId As String)
        iCommandText = "INSERT INTO Pr_PayOrders (" & _
                                   "AbonentId, " & _
                                   "MemberId, " & _
                                   "DtPeriodStart, " & _
                                   "DtPeriodEnd, " & _
                                   "EnergyTypeId, " & _
                                   "DtPayOrder, " & _
                                   "SumPayOrder, " & _
                                   "NumberPayOrder, " & _
                                   "PayOrderStatusId, " & _
                                   "DtCreate, " & _
                                   "CratePerformerId, " & _
                                   "DtUpdate, " & _
                                   "UpdatePerformerId) " & _
                "VALUES (" & AbonentId & ", " & _
                             MemberId & ", " & _
                             DtPeriodStartId & ", " & _
                             DtPeriodEndId & ", " & _
                             EnergyTypeId & ", " & _
                             DtPayOrder & ", " & _
                             SumPayOrder & ", " & _
                             NumberPayOrder & ", " & _
                             PayOrderStatusId & ", " & _
                             DtCreate & ", " & _
                             CratePerformerId & ", " & _
                             DtUpdate & ", " & _
                             UpdatePerformerId & " )"
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Insert_PrPayOrders") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Удаление из Pr_PayOrders
    Public Function Delete_PrPayOrders(ByVal PayOrderId As String)
        iCommandText = "DELETE FROM Pr_PayOrders " & _
                            "WHERE (PayOrderId = " & PayOrderId & ")"
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "Delete_PrPayOrders") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ==============================================================================================================


    ' =================================================Pr_PetitionsEvents=============================================
    ' Обновление Pr_Petitions



















    ' =================================================Pr_PetitionsPacks=============================================
    Public Function CreatePetitionPack(ByVal DtCreate As String, ByVal CratePerformerId As String, _
                                       ByVal PackNumber As String, ByVal Pr_EnergyTypeId As String, _
                                       ByVal PetitionTypeId As String, ByVal DtUpdate As String, _
                                       ByVal PeriodCreate As String)
        ' Текст команды для вставки пачки
        iCommandText = "INSERT INTO Pr_PetitionsPacks (DtCreate, " & _
                                       "CratePerformerId, " & _
                                       "PackNumber, " & _
                                       "Pr_EnergyTypeId, " & _
                                       "PetitionsPacksType, " & _
                                       "PetitionsCount, " & _
                                       "PetitionsSumDebt, " & _
                                       "PetitionsSumGovTax, " & _
                                       "PetitionsSumDebtAfterDecision, " & _
                                       "Note, " & _
                                       "DtUpdate, " & _
                                       "PeriodCreate) " & _
                       "VALUES (" & DtCreate & ", " & _
                                    CratePerformerId & ", " & _
                                    "dbo.Pr_fnsGetNamePetitionPack (" & PetitionTypeId & "), " & _
                                    Pr_EnergyTypeId & ", " & _
                                    PetitionTypeId & ", " & _
                                    "0, " & _
                                    "0, " & _
                                    "0, " & _
                                    "0, " & _
                                    "'Пачка создана автоматически', " & _
                                    DtCreate & ", " & _
                                    PeriodCreate & " )"
        ' Выполнение команды
        If ExecuteQuery(iCommandText, "CreatePetitionPack") Then
            Return True
        Else
            Return False
        End If
    End Function
    ' ==============================================================================================================



End Module
#End Region





'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
'MsgBox("BarBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
'MsgBox("BarBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground
'MsgBox("BarCaptionBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2
'MsgBox("BarCaptionBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveBackground
'MsgBox("BarCaptionInactiveBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveBackground2
'MsgBox("BarCaptionInactiveBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText
'MsgBox("BarCaptionInactiveText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionText
'MsgBox("BarCaptionText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
'MsgBox("BarDockedBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarFloatingBorder
'MsgBox("BarFloatingBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarPopupBackground
'MsgBox("BarPopupBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarPopupBorder
'MsgBox("BarPopupBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarStripeColor
'MsgBox("BarStripeColor")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.CustomizeBackground
'MsgBox("CustomizeBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.CustomizeBackground2
'MsgBox("CustomizeBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor
'MsgBox("DockSiteBackColor")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2
'MsgBox("DockSiteBackColor2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground
'MsgBox("ExplorerBarBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ExplorerBarBackground2
'MsgBox("ExplorerBarBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemBackground
'MsgBox("ItemBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemBackground2
'MsgBox("ItemBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground
'MsgBox("ItemCheckedBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground2
'MsgBox("ItemCheckedBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBorder
'MsgBox("ItemCheckedBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedText
'MsgBox("ItemCheckedText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDesignTimeBorder
'MsgBox("ItemDesignTimeBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDisabledBackground
'MsgBox("ItemDisabledBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDisabledText
'MsgBox("ItemDisabledText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedBackground
'MsgBox("ItemExpandedBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedBackground2
'MsgBox("ItemExpandedBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedBorder
'MsgBox("ItemExpandedBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedShadow
'MsgBox("ItemExpandedShadow")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedText
'MsgBox("ItemExpandedText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground
'MsgBox("ItemHotBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2
'MsgBox("ItemHotBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder
'MsgBox("ItemHotBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText
'MsgBox("ItemHotText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
'MsgBox("ItemPressedBackground")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
'MsgBox("ItemPressedBackground2")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
'MsgBox("ItemPressedBorder")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText
'MsgBox("ItemPressedText")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemSeparator
'MsgBox("ItemSeparator")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemSeparatorShade
'MsgBox("ItemSeparatorShade")
'Me.gp_FiltersPrint.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
'MsgBox("ItemText")




'iDataTable.Clear() 'Очищаем таблицу
'SqlCom = New OleDb.OleDbCommand("SELECT vPerformers.Name FROM vPerformers vPerformers  WHERE (vPerformers.Login<>'" & My.Settings.LastUser & "')", Conn) ' Указываем строку запроса и привязываем к соединению
'Conn.Open() ' Открываем соединение
'SqlCom.ExecuteNonQuery() 'Выполняем запрос
'iDataAdapter = New OleDb.OleDbDataAdapter(SqlCom) 'Через адаптер получаем результаты запроса

'iDataAdapter.Fill(iDataSet) ' Заполняем таблицу результатми
'iDataAdapter.Fill(iDataTable) ' Заполняем таблицу результатми

'Me.TextBox1.Text = iDataSet.Tables(0).Rows(0).Item(0) '.ToString
'Me.ComboBox1.DataSource = DS.Tables("Table").Columns(0)

'For Each r As DataRow In iDataSet.Tables(0).Rows
'ComboBox1.Items.Add(r.Item(0))
'Next


'Me.DataGridView1.DataSource = iDataTable ' Привязываем Грид к источнику данных


'Conn.Close() ' Закрываем соединение



' =================== Заполнение дерева улицами
'Private Sub frAbonents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'Dim pNod As String = ""
'Dim Conn As New OleDbConnection
'Conn.ConnectionString = "Provider=SQLOLEDB;SERVER=10.60.161.105;UID=lobin;PWD=19101987;DATABASE=QLesosibirskCity"  ' Строка подключения с переменными из процедуры"
'Открытие соединения 
'Conn.Open()
'Создание объекта Command 
'SqlCom = New OleDb.OleDbCommand _
'("SELECT vAddressArealVillage.VillageName, vAddressArealVillage.StreetName FROM vAddressArealVillage vAddressArealVillage WHERE(vAddressArealVillage.StreetName Is Not Null) ORDER BY                           vAddressArealVillage.VillageName", Conn)

'Вывод результатов в TreeView 
'TreeView.Nodes.Clear()
'Dim pNode As TreeNode ' parent 
'Dim cNode As TreeNode ' child 

'iDataAdapter = New OleDb.OleDbDataAdapter(SqlCom)                                                                     ' Через адаптер получаем результаты запроса
'iDataAdapter.Fill(iDataSet, "улицы")                                                                                           ' Заполняем таблицу результатми


'For Each r As DataRow In iDataSet.Tables("улицы").Rows
'If r.Item(0) <> pNod Then
'pNode = TreeView.Nodes.Add(r.Item(0))
'pNod = pNode.Text
'Else
'cNode = New TreeNode
'cNode.Text = r.Item(1)
'pNode.Nodes.Add(cNode)
'pNode.Expand() ' Разворачивает радительский узел
'End If
'Next
'Conn.Close()
'End Sub