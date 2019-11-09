Imports DevExpress.XtraEditors
Public Class frSearchAbonent
    Dim WithEvents TextControl As TextBox ' Для запрета редактирования DataGrida
    ' Переменные части адреса для разделенного поиска 
    Public ArealName As String
    Public VillageName As String
    Public StreetName As String
    Public House As String
    Public LetterHouse As String
    Public Build As String
    Public Room As String
    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.RadBut_AbonNum.BackColor = Me.BackColor
        Me.RadBut_PointNum.BackColor = Me.BackColor
        Me.RadBut_LastSurname.BackColor = Me.BackColor
        Me.RadBut_Adress.BackColor = Me.BackColor
        Me.Panel1.BackColor = Me.BackColor
        Me.Panel2.BackColor = Me.BackColor
        Me.Panel3.BackColor = Me.BackColor
        Me.Panel4.BackColor = Me.BackColor
        Me.Panel6.BackColor = Me.BackColor
        Me.Panel7.BackColor = Me.BackColor
    End Sub
    Private Sub frSearchAbonent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ОчиститьПоляФормы()
        Me.PictureBox1.Parent = Me.Panel6
        Me.RadBut_MemberPripyat.Text = "Член семьи " & Application.ProductName
        ' Разворачиваем все поисковые панели
        Me.PanSearch_LastSurname.Dock = DockStyle.Fill
        Me.PanSearch_Address.Dock = DockStyle.Fill
        Me.PanSearch_AbonentNum.Dock = DockStyle.Fill

        Me.PanSearch_AbonentNum.Show()
        Me.PanSearch_AbonentNum.Focus()
        Me.PanSearch_AbonentNum.Select()

        Me.Txt_AbonNumber.Focus()
        Me.Txt_AbonNumber.Select(0, Me.Txt_AbonNumber.Text.Length)
        Me.Txt_AbonNumber.SelectAll()
    End Sub

    Private Sub But_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles But_Search.Click
        MessageStatusStrip("", StLab_Messege)
        ' Заменяем пустые критерии поиска на знак % для выполнения запроса поиска по адресу
        If Areal = "NULL" Then Areal = "%"
        If CityVillage = "NULL" Then CityVillage = "%"
        If Street = "NULL" Then Street = "%"
        If Me.Txt_House.Text = "" Then House = "%" Else House = Me.Txt_House.Text
        If Me.Txt_LetterHouse.Text = "" Then LetterHouse = "%" Else LetterHouse = Me.Txt_LetterHouse.Text
        If Me.Txt_Build.Text = "" Then Build = "%" Else Build = Me.Txt_Build.Text
        If Me.Txt_Room.Text = "" Then Room = "%" Else Room = Me.Txt_Room.Text

        ' Запрос на поиск по лицевому
        If Me.RadBut_AbonNum.Checked Then
            If Replace(Me.Txt_AbonNumber.Text, " ", "") = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не задан лицевой счет...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)                ' Сообщение об операции
                Application.DoEvents()                                          ' Обработчик сообщение
                SearchAbonNumber(Replace(Me.Txt_AbonNumber.Text, " ", ""))      ' Процедура поиска
            End If
        End If

        ' Запрос на поиск по номеру ТУ
        If Me.RadBut_PointNum.Checked Then
            If Replace(Me.Txt_AbonNumber.Text, " ", "") = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не задан номер точки учета...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)                ' Сообщение об операции
                Application.DoEvents()                                          ' Обработчик сообщение
                SearchPointNumber(Replace(Me.Txt_AbonNumber.Text, " ", ""))     ' Процедура поиска
            End If
        End If

        ' ========================================
        ' Запрос на поиск по фамилии
        ' Запрос на поиск Собственнику
        If Me.RadBut_LastSurname.Checked And Me.RadBut_MaimMember.Checked Then
            If Me.Txt_Surname.Text = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не не указана фамилия абонента...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)        ' Сообщение об операции
                Application.DoEvents()                                  ' Обработчик сообщение
                SearchManeSurname(Me.Txt_Surname.Text)                  ' Процедура поиска
            End If
        End If

        ' Запрос на поиск по члену семьи ПК Квазар
        If Me.RadBut_LastSurname.Checked And Me.RadBut_MemberQuasar.Checked Then
            If Me.Txt_Surname.Text = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не не указана фамилия члена семьи...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)        ' Сообщение об операции
                Application.DoEvents()                                  ' Обработчик сообщение
                SearchQuasarMember(Me.Txt_Surname.Text)                 ' Процедура поиска
            End If
        End If

        ' Запрос на поиск по члену семьи ПК Припять
        If Me.RadBut_LastSurname.Checked And Me.RadBut_MemberPripyat.Checked Then
            If Me.Txt_Surname.Text = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не указана фамилия члена семьи...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)        ' Сообщение об операции
                Application.DoEvents()                                  ' Обработчик сообщение
                XtraMessageBox.Show("В данной функции пока нет необходимости..." & Chr(10) & "_____________________________М.А. Лобин", _
                                "Обработчик не найден", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If

        ' ========================================
        ' Запрос на поиск по адресу
        If Me.RadBut_Adress.Checked Then
            If Me.Txt_AddressString.Text = "" And _
               Me.Txt_House.Text = "" And _
               Me.Txt_LetterHouse.Text = "" And _
               Me.Txt_Build.Text = "" And _
               Me.Txt_Room.Text = "" Then
                MessageStatusStrip("Ошибка поиска...", StLab_Count)
                MessageStatusStrip("Не указаны адресные критерии поиска...", StLab_Messege) : Exit Sub
            Else
                MessageStatusStrip("Идет поиск...", StLab_Count)                                    ' Сообщение об операции
                Application.DoEvents()                                                              ' Обработчик сообщение
                SearchAddress(Areal, CityVillage, Street, House, LetterHouse, Build, Room)  ' Процедура поиска
            End If
        End If

        Me.DataGrid.DataSource = iDataSet.Tables("FindedAbonents")      ' Привязка DataGrid к iDataSet
        Me.StLab_Count.Text = "Найдено - " & Me.DataGrid.RowCount       ' Сколько найдено лицевых
        Me.DataGrid.Columns.Item(0).Visible = False                     ' Скрываем первый столбец с id
    End Sub

    Private Sub ОчиститьПоляФормы()
        Me.Txt_AbonNumber.Text = ""
        Me.Txt_Build.Text = ""
        Me.Txt_House.Text = ""
        Me.Txt_House.Text = ""
        Me.Txt_Room.Text = ""
    End Sub

    Private Sub frSearchAbonent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then Me.Txt_AbonNumber.Focus() : Me.Txt_AbonNumber.SelectAll()
    End Sub

    ' Радио кнопки для выбора критерия поиска
    ' ==============================================================================================================
    Private Sub RadBut_AbonNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_AbonNum.CheckedChanged       ' По лицевому
        If RadBut_AbonNum.Checked Then
            Me.PanSearch_LastSurname.Hide()
            Me.PanSearch_Address.Hide()
            Me.PanSearch_AbonentNum.Show()
            Me.Txt_AbonNumber.Focus()
            Me.Txt_AbonNumber.SelectAll()
        End If
    End Sub

    Private Sub RadBut_PointNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_PointNum.CheckedChanged
        If RadBut_PointNum.Checked Then
            Me.PanSearch_LastSurname.Hide()
            Me.PanSearch_Address.Hide()
            Me.PanSearch_AbonentNum.Show()
            Me.Txt_AbonNumber.Focus()
            Me.Txt_AbonNumber.SelectAll()
        End If
    End Sub

    Private Sub RadBut_LastSurname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_LastSurname.CheckedChanged     ' По фамилии
        If RadBut_LastSurname.Checked Then
            Me.PanSearch_Address.Hide()
            Me.PanSearch_AbonentNum.Hide()
            Me.PanSearch_LastSurname.Show()
            Me.Txt_Surname.Focus()
            Me.Txt_Surname.SelectAll()
        End If
    End Sub

    Private Sub RadBut_Adress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadBut_Adress.Click
        If RadBut_Adress.Checked Then
            Me.PanSearch_LastSurname.Hide()
            Me.PanSearch_AbonentNum.Hide()
            Me.PanSearch_Address.Show()
            frAdressAreal.Vid = 0
            frAdressAreal.AddressFunction = 10
            If frAdressAreal.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Txt_AddressString.Text = AddressString
            End If
            frAdressAreal.Dispose()         ' Выгружаем форму
            Me.Txt_House.Focus()
            Me.Txt_House.SelectAll()
        End If
    End Sub

    Private Sub RadBut_MaimMember_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_MaimMember.CheckedChanged
        If Me.RadBut_LastSurname.Checked Then
            Me.Txt_Surname.Focus()
            Me.Txt_Surname.SelectAll()
        End If
    End Sub

    Private Sub RadBut_MemberPripyat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_MemberPripyat.CheckedChanged
        If Me.RadBut_MemberPripyat.Checked Then
            Me.Txt_Surname.Focus()
            Me.Txt_Surname.SelectAll()
        End If
    End Sub

    Private Sub RadBut_MemberQuasar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBut_MemberQuasar.CheckedChanged
        If Me.RadBut_MemberQuasar.Checked Then
            Me.Txt_Surname.Focus()
            Me.Txt_Surname.SelectAll()
        End If
    End Sub
    ' ==============================================================================================================

    ' События текстовых полей
    ' ==============================================================================================================
    Private Sub Txt_AbonNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AbonNumber.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.But_Search_Click(sender, e)
            If DataGrid.Rows.Count <> 0 Then
                With Me.DataGrid
                    .Select()
                    .Focus()
                End With
            End If
        End If
    End Sub

    Private Sub Txt_Surname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Surname.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.But_Search_Click(sender, e)
            If DataGrid.Rows.Count <> 0 Then
                With Me.DataGrid
                    .Select()
                    .Focus()
                End With
            End If
        End If
    End Sub

    Private Sub Txt_AddressString_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AddressString.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_House.Focus()
            Me.Txt_House.SelectAll()
        End If
    End Sub

    Private Sub Txt_House_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_House.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_LetterHouse.Focus()
            Me.Txt_LetterHouse.SelectAll()
        End If
    End Sub

    Private Sub Txt_LetterHouse_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_LetterHouse.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_Build.Focus()
            Me.Txt_Build.SelectAll()
        End If
    End Sub

    Private Sub Txt_Build_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Build.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_Room.Focus()
            Me.Txt_Room.SelectAll()
        End If
    End Sub

    Private Sub Txt_Room_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Room.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            Me.But_Search_Click(sender, e)
            If DataGrid.Rows.Count <> 0 Then
                With Me.DataGrid
                    .Select()
                    .Focus()
                End With
            End If
        End If
    End Sub

    ' ==============================================================================================================
    '                                                                                             События DataGrid |
    ' ==============================================================================================================
    Private Sub DataGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGrid.KeyPress
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            pref_AbonentId = Me.DataGrid.CurrentRow.Cells(0).Value
            ' Запись в реестр id последнего абонента
            RegistryWrite(pref_RegistryPath & "HistoryLogins", "LastAbonentId", pref_AbonentId)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            frAdressAreal.Dispose()
        End If
    End Sub

    ' Отмена перехода на следующию строку по Ентеру
    Private Sub DataGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGrid.KeyDown
        If e.KeyCode = Keys.Enter Then e.Handled = True
    End Sub

    Private Sub DataGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellDoubleClick
        pref_AbonentId = Me.DataGrid.CurrentRow.Cells(0).Value
        ' Запись в реестр id последнего абонента
        RegistryWrite(pref_RegistryPath & "HistoryLogins", "LastAbonentId", pref_AbonentId)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        frAdressAreal.Dispose()
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) _
            Handles DataGrid.EditingControlShowing
        ' Отмена при попытке редактировать Грид
        TextControl = e.Control
        TextControl.ReadOnly = True ' вот и не сможем менять содержимое
    End Sub

    Private Sub DataGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellEndEdit
        ' ВКЛ Запрета на редактирование
        Me.DataGrid.ReadOnly = True
    End Sub

    Private Sub DataGrid_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGrid.CellMouseDown
        ' Активиция ячейки правой кнопкой мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            ' ОТКЛ Запрета на редактированиее
            sender.ReadOnly = False
            sender.CurrentCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
            sender.BeginEdit(True)
        End If
    End Sub
    ' ==============================================================================================================
End Class