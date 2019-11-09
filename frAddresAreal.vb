Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors

Public Class frAdressAreal

    Friend Vid As Integer = 0               ' Вид формы в зависимости от того какой формой вызван диалог
    '                                           0 - вид для диалога поиска
    '                                           1 - вид для выбора адреса (Родитель "Все улицы")
    Friend AddressFunction As Integer = 10  ' Для форм выбора адреса (Родитель "Все улицы")
    '                                           10 - можно выбрать только улицу
    '                                           11 - можно выбрать любую ветку
    Private Sub frAddresAreal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAddressTree(AddressFunction, Vid, Me.tlAddressAreal, Me.btn_ok)
        Me.tlAddressAreal.FocusedNode() = Me.tlAddressAreal.Nodes(0)
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        If Me.tlAddressAreal.Selection(0).Selected Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub tlAddressAreal_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal.AfterFocusNode
        Dim nD As TreeListNode = Me.tlAddressAreal.Selection(0)
        If EventChangedControl = True Then
            Select Case AddressFunction
                Case 10 ' для диалога поиска
                    If nD.Item("AddressPartType") = "Street" Then
                        Me.btn_ok.Enabled = True
                    Else
                        Me.btn_ok.Enabled = False
                    End If
                Case 11  ' для прочих диалогов
                    Me.btn_ok.Enabled = True
            End Select
            Areal = nD.Item("Areal")
            ArealId = Trim(nD.Item("ArealId"))
            CityVillage = nD.Item("CityVillage")
            CityVillageId = Trim(nD.Item("CityVillageId"))
            Street = nD.Item("Street")
            StreetId = Trim(nD.Item("StreetId"))
            AddressString = nD.Item("AddressString")
        End If
    End Sub
    Private Sub tlAddressAreal_MouseDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlAddressAreal.MouseDoubleClick
        Dim nD As TreeListNode = tlAddressAreal.Selection(0)
        If EventChangedControl = True Then
            Select Case AddressFunction
                Case 10 ' для диалога поиска
                    If nD.Item("AddressPartType") = "Street" Then
                        Me.DialogResult = DialogResult.OK
                    End If
                Case 11  ' для прочих диалогов
                    Me.DialogResult = DialogResult.OK
            End Select
        End If
    End Sub
End Class