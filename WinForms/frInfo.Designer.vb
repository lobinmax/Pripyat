<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frInfo
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frInfo))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.counter = New System.Windows.Forms.Timer(Me.components)
        Me.tex = New DevExpress.XtraEditors.LabelControl()
        Me.tbox = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 2
        '
        'counter
        '
        '
        'tex
        '
        Me.tex.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tex.Location = New System.Drawing.Point(70, 5)
        Me.tex.Name = "tex"
        Me.tex.Size = New System.Drawing.Size(135, 25)
        Me.tex.TabIndex = 2
        Me.tex.Text = "Уведомление"
        '
        'tbox
        '
        Me.tbox.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.tbox.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.tbox.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.tbox.Location = New System.Drawing.Point(70, 38)
        Me.tbox.Name = "tbox"
        Me.tbox.Size = New System.Drawing.Size(288, 49)
        Me.tbox.TabIndex = 3
        Me.tbox.Text = "Что-то произошло"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.PictureBox1)
        Me.PanelControl1.Controls.Add(Me.tbox)
        Me.PanelControl1.Controls.Add(Me.tex)
        Me.PanelControl1.Controls.Add(Me.SeparatorControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(363, 93)
        Me.PanelControl1.TabIndex = 5
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.BackColor = System.Drawing.Color.Transparent
        Me.SeparatorControl1.Location = New System.Drawing.Point(70, 23)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(293, 19)
        Me.SeparatorControl1.TabIndex = 5
        '
        'frInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 93)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frInfo"
        Me.ShowInTaskbar = False
        Me.Text = "frInfo"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents counter As System.Windows.Forms.Timer
    Friend WithEvents tex As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbox As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
End Class
