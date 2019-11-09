Public Class frWaitAskur
    Sub New()
        InitializeComponent()
        Me.progressPanel1.AutoHeight = True
    End Sub
    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel1.Caption = caption
    End Sub
    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel1.Description = description
    End Sub
    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub
    Public Enum WaitFormCommand
        SomeCommandId
    End Enum

    Private Sub frWaitAskur_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
