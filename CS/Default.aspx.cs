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
            PrintingSystem ps = new PrintingSystem();
            
            PrintableComponentLink link1 = new PrintableComponentLink();
            link1.Component = ASPxPivotGridExporter1;
            link1.PrintingSystem = ps;

            PrintableComponentLink link2 = new PrintableComponentLink();
            WebChartControl1.DataBind();
            link2.Component = ((IChartContainer)WebChartControl1).Chart;
            link2.PrintingSystem = ps;

            CompositeLink compositeLink = new CompositeLink();
            compositeLink.Links.AddRange(new object[] { link1, link2 });
            compositeLink.PrintingSystem = ps;

            compositeLink.CreateDocument();
            compositeLink.PrintingSystem.ExportOptions.Pdf.DocumentOptions.Author = "Test";
            using(MemoryStream stream = new MemoryStream()) {
                compositeLink.PrintingSystem.ExportToPdf(stream);
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