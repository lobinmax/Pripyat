<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frOptionsTask
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frOptionsTask))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.chb_AddToWorking = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmt_SubPerformers = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.dt_Performance = New DevExpress.XtraEditors.DateEdit()
        Me.TimerH = New System.Windows.Forms.Timer(Me.components)
        Me.TimerW = New System.Windows.Forms.Timer(Me.components)
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.chb_AddToWorking.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Performance.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Performance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.AutoEllipsis = True
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl1.LineColor = System.Drawing.Color.Black
        Me.LabelControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Дата исполнения задания"
        '
        'chb_AddToWorking
        '
        Me.chb_AddToWorking.EditValue = True
        Me.chb_AddToWorking.EnterMoveNextControl = True
        Me.chb_AddToWorking.Location = New System.Drawing.Point(178, 31)
        Me.chb_AddToWorking.Name = "chb_AddToWorking"
        Me.chb_AddToWorking.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.chb_AddToWorking.Properties.Appearance.Options.UseForeColor = True
        Me.chb_AddToWorking.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.chb_AddToWorking.Properties.Caption = "Добавить то что на руках"
        Me.chb_AddToWorking.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.chb_AddToWorking.Size = New System.Drawing.Size(170, 19)
        Me.chb_AddToWorking.TabIndex = 2
        Me.chb_AddToWorking.ToolTip = "В конец листа задания будут добавлены не врученные документы " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "находящиеся на рук" & _
    "ах исполнителя выданные за последние 30 дней"
        Me.chb_AddToWorking.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.Color.White
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.AutoEllipsis = True
        Me.LabelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl2.LineColor = System.Drawing.Color.Black
        Me.LabelControl2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl2.Location = New System.Drawing.Point(14, 74)
        Me.LabelControl2.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(201, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Дополнительные исполнители задания"
        '
        'cmt_SubPerformers
        '
        Me.cmt_SubPerformers.AntiAlias = True
        Me.cmt_SubPerformers.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cmt_SubPerformers.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmt_SubPerformers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmt_SubPerformers.ButtonCustom.Symbol = ""
        Me.cmt_SubPerformers.ButtonCustom.Tooltip = "Снять выделение"
        Me.cmt_SubPerformers.ButtonCustom.Visible = True
        Me.cmt_SubPerformers.ButtonCustom2.Symbol = ""
        Me.cmt_SubPerformers.ButtonCustom2.Tooltip = "Выделить все"
        Me.cmt_SubPerformers.ButtonCustom2.Visible = True
        Me.cmt_SubPerformers.ButtonDropDown.Visible = True
        Me.cmt_SubPerformers.ColumnsVisible = False
        Me.cmt_SubPerformers.ForeColor = System.Drawing.Color.Black
        Me.cmt_SubPerformers.GroupNodeStyle = Me.ElementStyle1
        Me.cmt_SubPerformers.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmt_SubPerformers.Location = New System.Drawing.Point(14, 93)
        Me.cmt_SubPerformers.Name = "cmt_SubPerformers"
        Me.cmt_SubPerformers.SelectionClosesPopup = False
        Me.cmt_SubPerformers.Size = New System.Drawing.Size(334, 23)
        Me.cmt_SubPerformers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmt_SubPerformers.TabIndex = 3
        Me.cmt_SubPerformers.ThemeAware = True
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'btn_OK
        '
        Me.btn_OK.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btn_OK.Appearance.Options.UseForeColor = True
        Me.btn_OK.Image = CType(resources.GetObject("btn_OK.Image"), System.Drawing.Image)
        Me.btn_OK.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.btn_OK.ImageToTextIndent = 2
        Me.btn_OK.Location = New System.Drawing.Point(274, 137)
        Me.btn_OK.LookAndFeel.SkinName = "Office 2013"
        Me.btn_OK.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(74, 26)
        Me.btn_OK.TabIndex = 4
        Me.btn_OK.ToolTip = "Сформировать лист выдачи задания"
        Me.btn_OK.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'dt_Performance
        '
        Me.dt_Performance.EditValue = New Date(2017, 3, 22, 17, 13, 4, 549)
        Me.dt_Performance.Location = New System.Drawing.Point(14, 30)
        Me.dt_Performance.Name = "dt_Performance"
        Me.dt_Performance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dt_Performance.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.dt_Performance.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.dt_Performance.Properties.Appearance.Options.UseBackColor = True
        Me.dt_Performance.Properties.Appearance.Options.UseForeColor = True
        Me.dt_Performance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.dt_Performance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_Performance.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_Performance.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.dt_Performance.Properties.NullValuePromptShowForEmptyValue = True
        Me.dt_Performance.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.[True]
        Me.dt_Performance.Size = New System.Drawing.Size(144, 20)
        Me.dt_Performance.TabIndex = 5
        '
        'TimerH
        '
        Me.TimerH.Interval = 1
        '
        'TimerW
        '
        Me.TimerW.Interval = 1
        '
        'PictureEdit1
        '
        Me.PictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(217, 72)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.PictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(20, 18)
        Me.PictureEdit1.TabIndex = 6
        Me.PictureEdit1.ToolTip = "В конец листа задания, будут добавлены дополнительные исполнители" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "и отметка для " & _
    "их подписи"
        Me.PictureEdit1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 50000000
        Me.ToolTip.InitialDelay = 1
        Me.ToolTip.ReshowDelay = 100
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "Контролеры отмеченные в качастве " & Global.Microsoft.VisualBasic.ChrW(10) & "дополнительных исполнителей"
        '
        'frOptionsTask
        '
        Me.AcceptButton = Me.btn_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 175)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.dt_Performance)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.cmt_SubPerformers)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.chb_AddToWorking)
        Me.Controls.Add(Me.LabelControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frOptionsTask"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Параметры листа выдачи задания"
        CType(Me.chb_AddToWorking.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Performance.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Performance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chb_AddToWorking As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmt_SubPerformers As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dt_Performance As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TimerH As System.Windows.Forms.Timer
    Friend WithEvents TimerW As System.Windows.Forms.Timer
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
End Class
