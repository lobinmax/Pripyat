Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class blNotice

    Private Sub XrTable2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTable2.BeforePrint
        Dim c As Integer = 0
        For Each r As XRTableRow In sender.Rows
            r.Visible = InverterBoolean(sender.Rows(r.Index).Cells(1).Text = "")
            If r.Visible = True Then c += 1
        Next
        sender.Visible = InverterBoolean(c = 1)
        lbEnergyStates.Visible = InverterBoolean(c = 1)
    End Sub
End Class