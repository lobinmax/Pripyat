Public Class frInfo
    Dim Speed As Integer
    Dim wa As Rectangle = SystemInformation.WorkingArea
    Dim x As Integer = wa.Left + wa.Width - Me.Width + 432
    Dim subX As Integer = wa.Left + wa.Width
    Dim у As Integer = 40
    Dim Sped As Integer
    Dim co As Integer = 1
    Public Mess As String = ""

    Private Sub frInfo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ' Public iControl As Object ' Контрол который будет недоступен во время показа сообщения
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.SeparatorControl1.Parent = Me.PanelControl1
        tbox.Text = Mess
        Speed = 100
        Me.Location = New Point(x, у)
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'iControl.Enabled = False
        Speed -= 1
        x = Me.Location.X
        Sped = Speed / 10
        Me.Location = New Point(x - Sped, у)
        If Me.Location.X < wa.Left + wa.Width - Me.Width + 1 Then
            Timer1.Stop()
            counter.Start()
        End If
        If Me.Location.X > wa.Left + wa.Width - Me.Width + 500 Then
            'iControl.Enabled = True
            Me.Close()
        End If
    End Sub
    Private Sub counter_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles counter.Tick
        'iControl.Enabled = False
        co += 1
        If co = 5 Then
            Speed = -50
            Timer1.Start()
        End If
    End Sub
End Class