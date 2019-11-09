<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frLoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frLoginForm))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Pass = New DevExpress.XtraEditors.TextEdit()
        Me.ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ChB_ShowPass = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.FormIsShort = New DevExpress.XtraEditors.SimpleButton()
        Me.BD = New DevExpress.XtraEditors.MRUEdit()
        Me.User = New DevExpress.XtraEditors.MRUEdit()
        Me.Server = New DevExpress.XtraEditors.MRUEdit()
        Me.Separator = New DevExpress.XtraEditors.SeparatorControl()
        CType(Me.Pass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChB_ShowPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.User.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Server.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Separator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl1.Appearance.Options.UseImageAlign = True
        Me.LabelControl1.Location = New System.Drawing.Point(217, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl1.TabIndex = 12
        Me.LabelControl1.Text = "Имя пользователя"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl2.Appearance.Options.UseImageAlign = True
        Me.LabelControl2.Location = New System.Drawing.Point(217, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 13
        Me.LabelControl2.Text = "Пароль"
        '
        'Pass
        '
        Me.Pass.Location = New System.Drawing.Point(217, 68)
        Me.Pass.Name = "Pass"
        Me.Pass.Properties.ContextImageOptions.Image = CType(resources.GetObject("Pass.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.Pass.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.Pass.Size = New System.Drawing.Size(226, 20)
        Me.Pass.TabIndex = 2
        '
        'ok
        '
        Me.ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ok.Location = New System.Drawing.Point(217, 116)
        Me.ok.Name = "ok"
        Me.ok.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ok.Size = New System.Drawing.Size(96, 23)
        Me.ok.TabIndex = 4
        Me.ok.Text = "Войти"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(320, 116)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Cancel.Size = New System.Drawing.Size(96, 23)
        Me.Cancel.TabIndex = 16
        Me.Cancel.Text = "Отмена"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl3.Appearance.Options.UseImageAlign = True
        Me.LabelControl3.Location = New System.Drawing.Point(8, 158)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 20
        Me.LabelControl3.Text = "SQL - Сервер:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl4.Appearance.Options.UseImageAlign = True
        Me.LabelControl4.Location = New System.Drawing.Point(233, 158)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl4.TabIndex = 22
        Me.LabelControl4.Text = "База данных:"
        '
        'ChB_ShowPass
        '
        Me.ChB_ShowPass.EnterMoveNextControl = True
        Me.ChB_ShowPass.Location = New System.Drawing.Point(217, 90)
        Me.ChB_ShowPass.Name = "ChB_ShowPass"
        Me.ChB_ShowPass.Properties.Caption = "Показать пароль"
        Me.ChB_ShowPass.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.ChB_ShowPass.Size = New System.Drawing.Size(226, 19)
        Me.ChB_ShowPass.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.ChB_ShowPass)
        Me.PanelControl1.Controls.Add(Me.FormIsShort)
        Me.PanelControl1.Controls.Add(Me.Cancel)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.ok)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.Pass)
        Me.PanelControl1.Controls.Add(Me.BD)
        Me.PanelControl1.Controls.Add(Me.User)
        Me.PanelControl1.Controls.Add(Me.Server)
        Me.PanelControl1.Controls.Add(Me.Separator)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(450, 201)
        Me.PanelControl1.TabIndex = 24
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = Global.Pripyat.My.Resources.Resources.pripyat_login
        Me.PictureEdit1.Location = New System.Drawing.Point(5, 5)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(207, 143)
        Me.PictureEdit1.TabIndex = 23
        '
        'FormIsShort
        '
        Me.FormIsShort.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.FormIsShort.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.pull_up
        Me.FormIsShort.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.FormIsShort.Location = New System.Drawing.Point(422, 116)
        Me.FormIsShort.Name = "FormIsShort"
        Me.FormIsShort.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.FormIsShort.Size = New System.Drawing.Size(20, 23)
        Me.FormIsShort.TabIndex = 17
        Me.FormIsShort.ToolTip = "Параметры подключения"
        '
        'BD
        '
        Me.BD.Location = New System.Drawing.Point(233, 173)
        Me.BD.Name = "BD"
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.BD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Очистить историю баз данных")})
        Me.BD.Properties.ContextImageOptions.Image = CType(resources.GetObject("BD.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.BD.Properties.ImmediatePopup = False
        Me.BD.Properties.PopupFormMinSize = New System.Drawing.Size(210, 0)
        Me.BD.Properties.PopupSizeable = True
        Me.BD.Properties.ValidateOnEnterKey = False
        Me.BD.Size = New System.Drawing.Size(210, 22)
        Me.BD.TabIndex = 21
        '
        'User
        '
        Me.User.EnterMoveNextControl = True
        Me.User.Location = New System.Drawing.Point(217, 20)
        Me.User.Name = "User"
        EditorButtonImageOptions2.Image = CType(resources.GetObject("EditorButtonImageOptions2.Image"), System.Drawing.Image)
        Me.User.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Очистить историю логинов")})
        Me.User.Properties.ContextImageOptions.Image = CType(resources.GetObject("User.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.User.Properties.DropDownRows = 4
        Me.User.Properties.ImmediatePopup = False
        Me.User.Properties.PopupSizeable = True
        Me.User.Properties.ValidateOnEnterKey = False
        Me.User.Size = New System.Drawing.Size(226, 22)
        Me.User.TabIndex = 1
        Me.User.Tag = ""
        '
        'Server
        '
        Me.Server.Location = New System.Drawing.Point(5, 173)
        Me.Server.Name = "Server"
        EditorButtonImageOptions3.Image = CType(resources.GetObject("EditorButtonImageOptions3.Image"), System.Drawing.Image)
        Me.Server.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Очистить историю имен серверов")})
        Me.Server.Properties.ContextImageOptions.Image = CType(resources.GetObject("Server.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.Server.Properties.ImmediatePopup = False
        Me.Server.Properties.PopupFormMinSize = New System.Drawing.Size(210, 0)
        Me.Server.Properties.PopupSizeable = True
        Me.Server.Properties.ValidateOnEnterKey = False
        Me.Server.Size = New System.Drawing.Size(210, 22)
        Me.Server.TabIndex = 19
        '
        'Separator
        '
        Me.Separator.Location = New System.Drawing.Point(5, 144)
        Me.Separator.Name = "Separator"
        Me.Separator.Size = New System.Drawing.Size(438, 23)
        Me.Separator.TabIndex = 24
        '
        'frLoginForm
        '
        Me.AcceptButton = Me.ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(450, 201)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frLoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Добро пожаловать в ПК Припять"
        CType(Me.Pass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChB_ShowPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.User.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Server.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Separator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Pass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ChB_ShowPass As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FormIsShort As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BD As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents User As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents Server As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents Separator As DevExpress.XtraEditors.SeparatorControl

End Class
