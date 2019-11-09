Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraPrinting.Preview.Native
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraRichEdit
Imports System.IO
Imports System.Diagnostics
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Printing
Imports System.Net
Imports DevExpress.XtraEditors.Controls


Public Class frTest

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        'Dim report As New XtraReport
        'report.FromFile("C:\Users\lobin\Documents\Visual Studio 2010\Projects\Pripyat\XtraReports\.repx\blkNotice.repx", True)
        'report.ShowPreview()
        'Dim printTool As New ReportPrintTool(report)
        'printTool.ShowPreviewDialog()
        'Dim report As New XtraReport
        'Dim filename As String = "C:\Users\lobin\Documents\Visual Studio 2010\Projects\Pripyat\XtraReports\.repx\Invoice.repx"
        'report.LoadLayout(filename)

        Dim report As New blNotice()
        Dim printTool As New ReportPrintTool(report)



        DevExpress.DataAccess.Sql.SqlDataSource.AllowCustomSqlQueries = True
        DevExpress.DataAccess.Sql.SqlDataSource.DisableCustomQueryValidation = True
        ' report.lbTextDoc.Text = "Первая строка " & Microsoft.VisualBasic.ChrW(13) & "Новая строка" & Microsoft.VisualBasic.ChrW(10) & "Новая строка"
        ' printTool.Print()
        'printTool.PrintDialog()
        ' printTool.ShowRibbonPreviewDialog()
        printTool.ShowPreview()

    End Sub

    Private Sub frTest_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim printDoc As New PrintDocument 
        Dim def As Integer
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            ComboBox1.Items.Add(pkInstalledPrinters)

            Dim someItem As New ImageComboBoxItem
            someItem.Description = pkInstalledPrinters
            someItem.ImageIndex = 0
            someItem.Value = i

            ImageComboBoxEdit1.Properties.Items.Add(someItem)

            ComboBoxEdit1.Properties.Items.Add(pkInstalledPrinters)
            If (printDoc.PrinterSettings.IsDefaultPrinter()) Then
                ComboBox1.Text = printDoc.PrinterSettings.PrinterName
                'ImageComboBoxEdit1.SelectedText = printDoc.PrinterSettings.PrinterName
                'ImageComboBoxEdit1.SelectedIndex = i
                'ImageComboBoxEdit1.Text = printDoc.PrinterSettings.PrinterName
                ComboBoxEdit1.Text = printDoc.PrinterSettings.PrinterName
                If printDoc.PrinterSettings.PrinterName = pkInstalledPrinters Then def = i
            End If
        Next
        ImageComboBoxEdit1.SelectedIndex = def
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
      

    End Sub

    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton2.Click

    End Sub
End Class