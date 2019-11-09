<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frTest
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
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageComboBoxEdit1 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'ImageComboBoxEdit1
        '
        Me.ImageComboBoxEdit1.Location = New System.Drawing.Point(111, 15)
        Me.ImageComboBoxEdit1.Name = "ImageComboBoxEdit1"
        Me.ImageComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit1.Size = New System.Drawing.Size(284, 20)
        Me.ImageComboBoxEdit1.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(111, 56)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(284, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(401, 56)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "SimpleButton2"
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(111, 83)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(284, 20)
        Me.ComboBoxEdit1.TabIndex = 4
        '
        'frTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 330)
        Me.Controls.Add(Me.ComboBoxEdit1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ImageComboBoxEdit1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Name = "frTest"
        Me.Text = "Form1"
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageComboBoxEdit1 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
End Class
