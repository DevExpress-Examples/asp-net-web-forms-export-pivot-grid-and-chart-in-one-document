Imports System
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraPrintingLinks
Imports System.IO

Namespace S130793
    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim ps As New PrintingSystem()

            Dim link1 As New PrintableComponentLink()
            link1.Component = ASPxPivotGridExporter1
            link1.PrintingSystem = ps

            Dim link2 As New PrintableComponentLink()
            WebChartControl1.DataBind()
            link2.Component = DirectCast(WebChartControl1, IChartContainer).Chart
            link2.PrintingSystem = ps

            Dim compositeLink As New CompositeLink()
            compositeLink.Links.AddRange(New Object() { link1, link2 })
            compositeLink.PrintingSystem = ps

            compositeLink.CreateDocument()
            compositeLink.PrintingSystem.ExportOptions.Pdf.DocumentOptions.Author = "Test"
            Using stream As New MemoryStream()
                compositeLink.PrintingSystem.ExportToPdf(stream)
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