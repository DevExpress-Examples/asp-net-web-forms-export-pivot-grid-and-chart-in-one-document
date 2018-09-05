using System;
using DevExpress.XtraPrinting;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrintingLinks;
using System.IO;

namespace S130793 {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            PrintingSystemBase ps = new PrintingSystemBase();
            ps.ExportOptions.Pdf.DocumentOptions.Author = "Test";

            PrintableComponentLinkBase link1 = new PrintableComponentLinkBase(ps);
            link1.Component = ASPxPivotGridExporter1;

            PrintableComponentLinkBase link2 = new PrintableComponentLinkBase(ps);
            WebChartControl1.DataBind();
            link2.Component = ((IChartContainer)WebChartControl1).Chart;

            CompositeLinkBase compositeLink = new CompositeLinkBase(ps);
            compositeLink.Links.AddRange(new object[] { link1, link2 });

            using (MemoryStream stream = new MemoryStream()) {
                compositeLink.ExportToPdf(stream);
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", "application/pdf");
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", "attachment; filename=test.pdf");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }

            ps.Dispose();
        }
    }
}