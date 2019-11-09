<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frConverterDBFtoTXT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frConverterDBFtoTXT))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_CreateTXT = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_Converting = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Num_SumPayments = New System.Windows.Forms.NumericUpDown()
        Me.Num_DtPayments = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Num_AbonNumber = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chb_AllDirectories = New System.Windows.Forms.CheckBox()
        Me.btn_ChooseFolder = New System.Windows.Forms.Button()
        Me.txt_PathFolder = New System.Windows.Forms.TextBox()
        Me.lb_Loger = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lab_ReadCount = New System.Windows.Forms.Label()
        Me.lab_ReadFile = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Num_SumPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_DtPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_AbonNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_CreateTXT)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.btn_Converting)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chb_AllDirectories)
        Me.GroupBox1.Controls.Add(Me.btn_ChooseFolder)
        Me.GroupBox1.Controls.Add(Me.txt_PathFolder)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 191)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры считывания файла DBF"
        '
        'btn_CreateTXT
        '
        Me.btn_CreateTXT.Enabled = False
        Me.btn_CreateTXT.Location = New System.Drawing.Point(413, 148)
        Me.btn_CreateTXT.Name = "btn_CreateTXT"
        Me.btn_CreateTXT.Size = New System.Drawing.Size(120, 36)
        Me.btn_CreateTXT.TabIndex = 5
        Me.btn_CreateTXT.Text = "2. Выгрузить в *.TXT"
        Me.btn_CreateTXT.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 59)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(147, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btn_Converting
        '
        Me.btn_Converting.Enabled = False
        Me.btn_Converting.Location = New System.Drawing.Point(413, 106)
        Me.btn_Converting.Name = "btn_Converting"
        Me.btn_Converting.Size = New System.Drawing.Size(120, 36)
        Me.btn_Converting.TabIndex = 4
        Me.btn_Converting.Text = "1. Прочитать данные"
        Me.btn_Converting.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Num_SumPayments)
        Me.GroupBox2.Controls.Add(Me.Num_DtPayments)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Num_AbonNumber)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(159, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 99)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Распололожение данных"
        '
        'Num_SumPayments
        '
        Me.Num_SumPayments.Location = New System.Drawing.Point(197, 71)
        Me.Num_SumPayments.Name = "Num_SumPayments"
        Me.Num_SumPayments.Size = New System.Drawing.Size(38, 20)
        Me.Num_SumPayments.TabIndex = 3
        Me.Num_SumPayments.ThousandsSeparator = True
        Me.Num_SumPayments.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'Num_DtPayments
        '
        Me.Num_DtPayments.Location = New System.Drawing.Point(197, 45)
        Me.Num_DtPayments.Name = "Num_DtPayments"
        Me.Num_DtPayments.Size = New System.Drawing.Size(38, 20)
        Me.Num_DtPayments.TabIndex = 2
        Me.Num_DtPayments.ThousandsSeparator = True
        Me.Num_DtPayments.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "- Столбец <Сумма платежа>                    "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "- Столбец <Дата платежа>                "
        '
        'Num_AbonNumber
        '
        Me.Num_AbonNumber.Location = New System.Drawing.Point(197, 19)
        Me.Num_AbonNumber.Name = "Num_AbonNumber"
        Me.Num_AbonNumber.Size = New System.Drawing.Size(38, 20)
        Me.Num_AbonNumber.TabIndex = 1
        Me.Num_AbonNumber.ThousandsSeparator = True
        Me.Num_AbonNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "- Столбец <Номер лицевого>                 "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Путь к папке с файлами                     "
        '
        'chb_AllDirectories
        '
        Me.chb_AllDirectories.Checked = True
        Me.chb_AllDirectories.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_AllDirectories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chb_AllDirectories.Location = New System.Drawing.Point(159, 55)
        Me.chb_AllDirectories.Name = "chb_AllDirectories"
        Me.chb_AllDirectories.Size = New System.Drawing.Size(223, 24)
        Me.chb_AllDirectories.TabIndex = 1
        Me.chb_AllDirectories.Text = "Включать подкаталоги                 "
        Me.chb_AllDirectories.UseVisualStyleBackColor = True
        '
        'btn_ChooseFolder
        '
        Me.btn_ChooseFolder.BackgroundImage = Global.Pripyat.My.Resources.Resources.folder_50x50
        Me.btn_ChooseFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ChooseFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ChooseFolder.Location = New System.Drawing.Point(495, 21)
        Me.btn_ChooseFolder.Name = "btn_ChooseFolder"
        Me.btn_ChooseFolder.Size = New System.Drawing.Size(38, 32)
        Me.btn_ChooseFolder.TabIndex = 1
        Me.btn_ChooseFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ChooseFolder.UseVisualStyleBackColor = True
        '
        'txt_PathFolder
        '
        Me.txt_PathFolder.Enabled = False
        Me.txt_PathFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_PathFolder.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txt_PathFolder.Location = New System.Drawing.Point(6, 33)
        Me.txt_PathFolder.Name = "txt_PathFolder"
        Me.txt_PathFolder.Size = New System.Drawing.Size(483, 20)
        Me.txt_PathFolder.TabIndex = 0
        '
        'lb_Loger
        '
        Me.lb_Loger.ColumnWidth = 542
        Me.lb_Loger.FormattingEnabled = True
        Me.lb_Loger.HorizontalScrollbar = True
        Me.lb_Loger.Location = New System.Drawing.Point(4, 202)
        Me.lb_Loger.Name = "lb_Loger"
        Me.lb_Loger.Size = New System.Drawing.Size(542, 173)
        Me.lb_Loger.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5847!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4153!))
        Me.TableLayoutPanel1.Controls.Add(Me.lab_ReadCount, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lab_ReadFile, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 377)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(549, 23)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lab_ReadCount
        '
        Me.lab_ReadCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lab_ReadCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lab_ReadCount.Location = New System.Drawing.Point(396, 0)
        Me.lab_ReadCount.Name = "lab_ReadCount"
        Me.lab_ReadCount.Size = New System.Drawing.Size(150, 23)
        Me.lab_ReadCount.TabIndex = 4
        Me.lab_ReadCount.Text = "Кол-во квитанций - "
        Me.lab_ReadCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lab_ReadFile
        '
        Me.lab_ReadFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lab_ReadFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lab_ReadFile.Location = New System.Drawing.Point(3, 0)
        Me.lab_ReadFile.Name = "lab_ReadFile"
        Me.lab_ReadFile.Size = New System.Drawing.Size(387, 23)
        Me.lab_ReadFile.TabIndex = 3
        Me.lab_ReadFile.Text = "Файл - "
        Me.lab_ReadFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frConverterDBFtoTXT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 400)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lb_Loger)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frConverterDBFtoTXT"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Конвертация файлов .dbf в .txt"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Num_SumPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_DtPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_AbonNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_PathFolder As System.Windows.Forms.TextBox
    Friend WithEvents btn_ChooseFolder As System.Windows.Forms.Button
    Friend WithEvents chb_AllDirectories As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Num_SumPayments As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Num_AbonNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Num_DtPayments As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_CreateTXT As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Converting As System.Windows.Forms.Button
    Friend WithEvents lb_Loger As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lab_ReadCount As System.Windows.Forms.Label
    Friend WithEvents lab_ReadFile As System.Windows.Forms.Label
End Class
