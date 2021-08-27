<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128566537/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1164)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# How to export ASPxPivotGrid and bound WebChartControl to the same print document
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1164/)**
<!-- run online end -->


This example illustrates how to combine several ASP.NET controls in one export document. The project shows how to apply this solution to ASPxPivotGrid and WebChartControl, but it is also applicable to other components that implement the [**IPrintable**](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IPrintable.class) and [**IBasePrintable**](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IBasePrintable.class) interfaces. To determine if a component implements an interface, refer to our documentation (for instance, check the [ASPxPivotGridExporter](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGridExporter.class) class link) or source code.

This example uses the **Printing.Core** library. Make sure that you include it into your project. 

### Steps to implement:
1. Create a [PrintableComponentLinkBase ](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.members) object for each control you want to export.
2. Specify the [PrintableComponentLinkBase.Component](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.Component.property) property: use your printable component here. 
3. Create a [CompositeLinkBase](https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraPrintingLinksCompositeLinkBasetopic) object. It is used to combine several printing links.
4. Add PrintingLinkBase objects to the [CompositeLinkBase.Links](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.Links.property) collection. 
5. Call the [CompositeLinkBase.ExportTo[FORMAT]](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.ExportToDocx.overloads) method to export the document.

### See also:
[How to export MVCxPivotGrid and the bound ChartControl to the same print document](https://github.com/DevExpress-Examples/how-to-export-mvcxpivotgrid-and-the-bound-chartcontrol-to-the-same-print-document-t263225)

