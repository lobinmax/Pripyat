<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frMessager
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frMessager))
        Me.lb_TextMessege = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lb_TextMessege
        '
        Me.lb_TextMessege.BackColor = System.Drawing.Color.Transparent
        Me.lb_TextMessege.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lb_TextMessege.ForeColor = System.Drawing.Color.Cornsilk
        Me.lb_TextMessege.Location = New System.Drawing.Point(121, 9)
        Me.lb_TextMessege.Name = "lb_TextMessege"
        Me.lb_TextMessege.Size = New System.Drawing.Size(204, 76)
        Me.lb_TextMessege.TabIndex = 0
        Me.lb_TextMessege.Text = "Для ПК Припять опубликовано обновление!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Дата: ___________г." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Время: 00:00:00"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Pripyat.My.Resources.Resources.x_simbol
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(338, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frMessager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(367, 93)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lb_TextMessege)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frMessager"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Messeger"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lb_TextMessege As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
