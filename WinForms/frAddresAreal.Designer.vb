<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAdressAreal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAdressAreal))
        Me.btn_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Close = New DevExpress.XtraEditors.SimpleButton()
        Me.tlAddressAreal = New DevExpress.XtraTreeList.TreeList()
        CType(Me.tlAddressAreal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Enabled = False
        Me.btn_ok.Image = Global.Pripyat.My.Resources.Resources.mapit_16x16
        Me.btn_ok.Location = New System.Drawing.Point(141, 383)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(96, 22)
        Me.btn_ok.TabIndex = 4
        Me.btn_ok.Text = "Выбрать"
        '
        'btn_Close
        '
        Me.btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Close.Image = Global.Pripyat.My.Resources.Resources.close_16x16
        Me.btn_Close.Location = New System.Drawing.Point(243, 383)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(96, 22)
        Me.btn_Close.TabIndex = 5
        Me.btn_Close.Text = "Закрыть"
        '
        'tlAddressAreal
        '
        Me.tlAddressAreal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlAddressAreal.Cursor = System.Windows.Forms.Cursors.Default
        Me.tlAddressAreal.ImageIndexFieldName = ""
        Me.tlAddressAreal.Location = New System.Drawing.Point(0, 0)
        Me.tlAddressAreal.Name = "tlAddressAreal"
        Me.tlAddressAreal.OptionsBehavior.Editable = False
        Me.tlAddressAreal.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tlAddressAreal.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tlAddressAreal.OptionsView.ShowColumns = False
        Me.tlAddressAreal.OptionsView.ShowHorzLines = False
        Me.tlAddressAreal.OptionsView.ShowIndicator = False
        Me.tlAddressAreal.OptionsView.ShowVertLines = False
        Me.tlAddressAreal.Size = New System.Drawing.Size(344, 369)
        Me.tlAddressAreal.TabIndex = 6
        Me.tlAddressAreal.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid
        '
        'frAdressAreal
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Close
        Me.ClientSize = New System.Drawing.Size(344, 422)
        Me.Controls.Add(Me.tlAddressAreal)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.btn_ok)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(360, 460)
        Me.Name = "frAdressAreal"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Выбор адреса"
        CType(Me.tlAddressAreal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tlAddressAreal As DevExpress.XtraTreeList.TreeList
End Class
