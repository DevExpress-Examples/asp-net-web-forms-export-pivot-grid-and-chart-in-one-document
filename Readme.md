<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128566537/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1164)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# ASP.NET Web Forms - How to export ASPxPivotGrid and bound WebChartControl to the same print document

This example demonstrates how to combine several ASP.NET controls in one exported document. This project shows how to apply this solution to [ASPxPivotGrid](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid) and [WebChartControl](https://docs.devexpress.com/AspNet/DevExpress.XtraCharts.Web.WebChartControl), but it is also applicable to other components that implement the [IPrintable](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPrinting.IPrintable) and [IBasePrintable](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IBasePrintable) interfaces.
> [!NOTE]
> This example uses the **Printing.Core** library. Make sure that you include it in your project.

## Implementation Details

1. Create a [PrintableComponentLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase) object for each exported component.
2. Specify the [PrintableComponentLinkBase.Component](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.Component) property. 
3. Create a [CompositeLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase) object to combine several printing links.
4. Add `PrintableComponentLinkBase` objects to the [CompositeLinkBase.Links](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.Links) collection. 
5. Call the [CompositeLinkBase.ExportTo[FORMAT]](https://docs.devexpress.com/CoreLibraries/devexpress.xtraprinting.linkbase.exporttodocx.overloads) method to export the document.

```csharp
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
```

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## More Examples

* [How to export several controls to different XLSX worksheets](https://github.com/DevExpress-Examples/asp-net-web-forms-export-several-controls-to-different-sheets)
* [How to export ASPxGridView and WebChartControl to the same print document](https://github.com/DevExpress-Examples/asp-net-web-forms-export-grid-and-chart-in-one-document)
* [Grid View for Web Forms - How to export multiple grids into a single print document](https://github.com/DevExpress-Examples/asp-net-web-forms-grid-export-two-grids-in-one-document)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-export-pivot-grid-and-chart-in-one-document&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-export-pivot-grid-and-chart-in-one-document&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
