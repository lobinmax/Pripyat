<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frLicense
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frLicense))
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = Global.Pripyat.My.Resources.Resources.DE_LOGO
        Me.PictureEdit1.Location = New System.Drawing.Point(12, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ReadOnly = True
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(424, 70)
        Me.PictureEdit1.TabIndex = 0
        '
        'TextEdit1
        '
        Me.TextEdit1.EnterMoveNextControl = True
        Me.TextEdit1.Location = New System.Drawing.Point(33, 143)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Mask.EditMask = "d"
        Me.TextEdit1.Properties.MaxLength = 5
        Me.TextEdit1.Size = New System.Drawing.Size(70, 20)
        Me.TextEdit1.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(12, 114)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(424, 23)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Enter your registration code"
        '
        'TextEdit2
        '
        Me.TextEdit2.EnterMoveNextControl = True
        Me.TextEdit2.Location = New System.Drawing.Point(109, 143)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Mask.EditMask = "d"
        Me.TextEdit2.Properties.MaxLength = 5
        Me.TextEdit2.Size = New System.Drawing.Size(70, 20)
        Me.TextEdit2.TabIndex = 3
        '
        'TextEdit3
        '
        Me.TextEdit3.EnterMoveNextControl = True
        Me.TextEdit3.Location = New System.Drawing.Point(185, 143)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.Mask.EditMask = "d"
        Me.TextEdit3.Properties.MaxLength = 5
        Me.TextEdit3.Size = New System.Drawing.Size(70, 20)
        Me.TextEdit3.TabIndex = 4
        '
        'TextEdit4
        '
        Me.TextEdit4.EnterMoveNextControl = True
        Me.TextEdit4.Location = New System.Drawing.Point(261, 143)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Mask.EditMask = "d"
        Me.TextEdit4.Properties.MaxLength = 5
        Me.TextEdit4.Size = New System.Drawing.Size(70, 20)
        Me.TextEdit4.TabIndex = 5
        '
        'TextEdit5
        '
        Me.TextEdit5.EnterMoveNextControl = True
        Me.TextEdit5.Location = New System.Drawing.Point(337, 143)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Properties.Mask.EditMask = "d"
        Me.TextEdit5.Properties.MaxLength = 5
        Me.TextEdit5.Size = New System.Drawing.Size(70, 20)
        Me.TextEdit5.TabIndex = 6
        '
        'btnApply
        '
        Me.btnApply.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnApply.Appearance.Options.UseFont = True
        Me.btnApply.Location = New System.Drawing.Point(261, 202)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(94, 33)
        Me.btnApply.TabIndex = 7
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(361, 202)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 33)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(33, 169)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(106, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "Your code is wrong ..."
        Me.LabelControl2.Visible = False
        '
        'frLicense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 246)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.TextEdit5)
        Me.Controls.Add(Me.TextEdit4)
        Me.Controls.Add(Me.TextEdit3)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frLicense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registration DevExpress Components"
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
