Public Class frViewFamilyMember
    Dim _clsFamilyMember As New clsFamilyMember         ' Класс для PropertyGrid_FamilyMember
    Public iCurrRowDG As Integer            ' Переменная для хранения номера активной строки в выбранном гриде

    Private Sub fr_ViewFamilyMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim FirstOfMonth As Date = DateSerial(Year(Now), Month(Now), 1)     ' Переменная первого дня текущего месяца
        Me.PropertyGrid_FamilyMember.SelectedObject = _clsFamilyMember      ' Формирование PropertyGrid через класс clsFamilyMember
        ' Заполнение PropertyGrid - Данные абонента
        _clsFamilyMember.DateHistoryChange = FirstOfMonth
        _clsFamilyMember.MaleAFemale = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("MaleAFemale").ToString
        _clsFamilyMember.DateOfBirth = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("DateOfBirth").ToString
        _clsFamilyMember.DtBegin = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("DtBegin").ToString
        _clsFamilyMember.DtClosed = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("DtClosed").ToString
        _clsFamilyMember.Name = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("Name").ToString
        _clsFamilyMember.RegistrAddress = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("RegistrAddress").ToString
        _clsFamilyMember.RoleName = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("RoleName").ToString
        _clsFamilyMember.ShareOwner = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("ShareOwner").ToString
        _clsFamilyMember.SurName = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("SurName").ToString
        _clsFamilyMember.Patronymic = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("Patronymic").ToString
        _clsFamilyMember.BirthPlace = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("BirthPlace").ToString

        ' - Паспортные данные
        _clsFamilyMember.Passport = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("Passport").ToString
        _clsFamilyMember.PassportDate = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("PassportDate").ToString
        _clsFamilyMember.PassportNumber = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("PassportNumber").ToString
        _clsFamilyMember.PassportSeries = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("PassportSeries").ToString
        _clsFamilyMember.PassportSubunit = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("PassportSubunit").ToString
        _clsFamilyMember.PassportSubunitCode = iDataSet.Tables("FamilyMember").Rows(iCurrRowDG).Item("PassportSubunitCode").ToString
    End Sub

    Private Sub bt_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Cancel.Click
        Me.Close()

    End Sub
End Class