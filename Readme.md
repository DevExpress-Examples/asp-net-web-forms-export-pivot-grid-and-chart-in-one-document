<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128566537/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1164)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# ASP.NET Web Forms - How to export ASPxPivotGrid and bound WebChartControl to the same print document
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1164/)**
<!-- run online end -->

This example demonstrates how to combine several ASP.NET controls in one exported document. This project shows how to apply this solution to [ASPxPivotGrid](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid) and [WebChartControl](https://docs.devexpress.com/AspNet/DevExpress.XtraCharts.Web.WebChartControl), however it is also applicable to other components that implement the [IPrintable](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPrinting.IPrintable) and [IBasePrintable](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IBasePrintable) interfaces. To determine if a component implements an interface, refer to our documentation (for instance, check the [ASPxPivotGridExporter](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGridExporter) class link) or source code.

> [!NOTE]
> This example uses the **Printing.Core** library. Make sure that you include it into your project. 

## Implementation Details

1. Create a [PrintableComponentLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase) object for each control you want to export.
2. Specify the [PrintableComponentLinkBase.Component](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.Component) property: use your printable component here. 
3. Create a [CompositeLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase) object. It is used to combine several printing links.
4. Add `PrintableComponentLinkBase` objects to the [CompositeLinkBase.Links](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.Links) collection. 
5. Call the [CompositeLinkBase.ExportTo[FORMAT]](https://docs.devexpress.com/CoreLibraries/devexpress.xtraprinting.linkbase.exporttodocx.overloads) method to export the document.

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
