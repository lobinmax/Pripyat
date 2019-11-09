<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frViewFamilyMember
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
        Me.PropertyGrid_FamilyMember = New System.Windows.Forms.PropertyGrid()
        Me.bt_ok = New System.Windows.Forms.Button()
        Me.bt_Cancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PropertyGrid_FamilyMember
        '
        Me.PropertyGrid_FamilyMember.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid_FamilyMember.HelpVisible = False
        Me.PropertyGrid_FamilyMember.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid_FamilyMember.Name = "PropertyGrid_FamilyMember"
        Me.PropertyGrid_FamilyMember.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PropertyGrid_FamilyMember.Size = New System.Drawing.Size(595, 309)
        Me.PropertyGrid_FamilyMember.TabIndex = 0
        Me.PropertyGrid_FamilyMember.ToolbarVisible = False
        '
        'bt_ok
        '
        Me.bt_ok.Location = New System.Drawing.Point(454, 351)
        Me.bt_ok.Name = "bt_ok"
        Me.bt_ok.Size = New System.Drawing.Size(77, 26)
        Me.bt_ok.TabIndex = 1
        Me.bt_ok.Text = "oK"
        Me.bt_ok.UseVisualStyleBackColor = True
        '
        'bt_Cancel
        '
        Me.bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_Cancel.Location = New System.Drawing.Point(537, 351)
        Me.bt_Cancel.Name = "bt_Cancel"
        Me.bt_Cancel.Size = New System.Drawing.Size(63, 26)
        Me.bt_Cancel.TabIndex = 2
        Me.bt_Cancel.Text = "Отмена"
        Me.bt_Cancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(599, 32)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Поля ФИО обязательны к заполнению!"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.PropertyGrid_FamilyMember)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(599, 313)
        Me.Panel2.TabIndex = 4
        '
        'frViewFamilyMember
        '
        Me.AcceptButton = Me.bt_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_Cancel
        Me.ClientSize = New System.Drawing.Size(599, 377)
        Me.ControlBox = False
        Me.Controls.Add(Me.bt_Cancel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.bt_ok)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frViewFamilyMember"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Данные члена семьи"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PropertyGrid_FamilyMember As System.Windows.Forms.PropertyGrid
    Friend WithEvents bt_ok As System.Windows.Forms.Button
    Friend WithEvents bt_Cancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
