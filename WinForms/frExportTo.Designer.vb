<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frExportTo
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
        Me.pb_Progress = New System.Windows.Forms.PictureBox()
        Me.pn_Progress = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pb_Progress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pb_Progress
        '
        Me.pb_Progress.Image = Global.Pripyat.My.Resources.Resources.exportToExcel
        Me.pb_Progress.Location = New System.Drawing.Point(11, 11)
        Me.pb_Progress.Name = "pb_Progress"
        Me.pb_Progress.Size = New System.Drawing.Size(170, 58)
        Me.pb_Progress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Progress.TabIndex = 0
        Me.pb_Progress.TabStop = False
        '
        'pn_Progress
        '
        Me.pn_Progress.BackgroundImage = Global.Pripyat.My.Resources.Resources.ProgressDarkBlue
        Me.pn_Progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pn_Progress.Location = New System.Drawing.Point(187, 33)
        Me.pn_Progress.Name = "pn_Progress"
        Me.pn_Progress.Size = New System.Drawing.Size(1, 32)
        Me.pn_Progress.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.pn_Progress)
        Me.Panel1.Controls.Add(Me.pb_Progress)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 85)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(187, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Экспорт списка в книгу Excel..."
        '
        'frExportTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 85)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frExportTo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frExportTo"
        CType(Me.pb_Progress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pb_Progress As System.Windows.Forms.PictureBox
    Friend WithEvents pn_Progress As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
