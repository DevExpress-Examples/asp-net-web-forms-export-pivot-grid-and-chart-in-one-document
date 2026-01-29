Imports System
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraPrintingLinks
Imports System.IO

Namespace S130793

    Public Partial Class _Default
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim ps As PrintingSystemBase = New PrintingSystemBase()
            ps.ExportOptions.Pdf.DocumentOptions.Author = "Test"
            Dim link1 As PrintableComponentLinkBase = New PrintableComponentLinkBase(ps)
            link1.Component = ASPxPivotGridExporter1
            Dim link2 As PrintableComponentLinkBase = New PrintableComponentLinkBase(ps)
            WebChartControl1.DataBind()
            link2.Component = CType(WebChartControl1, IChartContainer).Chart
            Dim compositeLink As CompositeLinkBase = New CompositeLinkBase(ps)
            compositeLink.Links.AddRange(New Object() {link1, link2})
            Using stream As MemoryStream = New MemoryStream()
                compositeLink.ExportToPdf(stream)
                Response.Clear()
                Response.Buffer = False
                Response.AppendHeader("Content-Type", "application/pdf")
                Response.AppendHeader("Content-Transfer-Encoding", "binary")
                Response.AppendHeader("Content-Disposition", "attachment; filename=test.pdf")
                Response.BinaryWrite(stream.ToArray())
                Response.End()
            End Using

            ps.Dispose()
        End Sub
    End Class
End Namespace
