<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frWaitSimple
    Inherits DevExpress.XtraWaitForm.WaitForm

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
        Me.progressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'progressPanel1
        '
        Me.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.progressPanel1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.progressPanel1.Appearance.Options.UseBackColor = True
        Me.progressPanel1.Appearance.Options.UseForeColor = True
        Me.progressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.progressPanel1.AppearanceCaption.Options.UseFont = True
        Me.progressPanel1.AppearanceDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.progressPanel1.AppearanceDescription.Options.UseFont = True
        Me.progressPanel1.BarAnimationElementThickness = 2
        Me.progressPanel1.Caption = ""
        Me.progressPanel1.Description = ""
        Me.progressPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.progressPanel1.ImageHorzOffset = 20
        Me.progressPanel1.Location = New System.Drawing.Point(20, 17)
        Me.progressPanel1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.progressPanel1.Name = "progressPanel1"
        Me.progressPanel1.ShowCaption = False
        Me.progressPanel1.ShowDescription = False
        Me.progressPanel1.Size = New System.Drawing.Size(241, 47)
        Me.progressPanel1.TabIndex = 0
        Me.progressPanel1.Text = "progressPanel1"
        Me.progressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Ring
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.progressPanel1, 1, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 14, 0, 14)
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(87, 81)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'frWaitSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(87, 81)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Name = "frWaitSimple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.DimGray
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents progressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
