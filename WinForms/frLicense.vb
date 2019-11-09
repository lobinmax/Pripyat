Imports DevExpress.XtraEditors

Public Class frLicense
    Private Sub TextEdit1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit1.TextChanged
        If sender.Text.Length = 5 Then TextEdit2.Focus() : TextEdit2.SelectAll()
    End Sub
    Private Sub TextEdit2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit2.TextChanged
        If sender.Text.Length = 5 Then TextEdit3.Focus() : TextEdit3.SelectAll()
    End Sub
    Private Sub TextEdit3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit3.TextChanged
        If sender.Text.Length = 5 Then TextEdit4.Focus() : TextEdit4.SelectAll()
    End Sub
    Private Sub TextEdit4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit4.TextChanged
        If sender.Text.Length = 5 Then TextEdit5.Focus() : TextEdit5.SelectAll()
    End Sub
    Private Sub TextEdit5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit5.TextChanged
        If sender.Text.Length = 5 Then btnApply.Focus()
    End Sub
    Private Sub frLicense_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frLicense_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' заполняем поля текущей лицензией
        Dim _Code As String = RegistryRead(pref_ComplexSettings, "License", "0")
        Dim Code() As String = _Code.Split("-")
        Me.TextEdit1.Text = Code(0)
        Me.TextEdit2.Text = Code(1)
        Me.TextEdit3.Text = Code(2)
        Me.TextEdit4.Text = Code(3)
        Me.TextEdit5.Text = Code(4)
    End Sub
    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        ' записываем код
        RegistryWrite(pref_ComplexSettings, "License",
                                  Me.TextEdit1.Text & "-" &
                                  Me.TextEdit2.Text & "-" &
                                  Me.TextEdit3.Text & "-" &
                                  Me.TextEdit4.Text & "-" &
                                  Me.TextEdit5.Text)
        ' проверяем на корректность
        If LicenseCheck() Then
            Me.LabelControl2.Visible = False
            Me.DialogResult = Windows.Forms.DialogResult.OK


        Else
            Me.LabelControl2.Visible = True
        End If
    End Sub
End Class