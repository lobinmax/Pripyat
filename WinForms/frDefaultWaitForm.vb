Public Class frDefaultWaitForm
    Dim p As String
    Dim revers As Boolean
    Dim PointsMax As Integer = 20
    Sub New()
        InitializeComponent()
        Me.progressPanel1.AutoHeight = False
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

    Private Sub tmPoints_Tick(sender As System.Object, e As System.EventArgs) Handles tmPoints.Tick
        If revers Then
            p = Microsoft.VisualBasic.Left(p, p.Length - 1)
            If p.Length = 1 Then revers = False
        Else
            p += "."
            If p.Length = PointsMax Then revers = True
        End If
        Me.progressPanel1.Description = "Идет загрузка " & p
    End Sub

    Private Sub frDefaultWaitForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class
