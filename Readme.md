# How to export ASPxPivotGrid and bound WebChartControl to the same print document


This example illustrates how to combine several ASP.NET controls in one export document. The project shows how to apply this solution to ASPxPivotGrid and WebChartControl, but it is also applicable to other components that implement the [**IPrintable**](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IPrintable.class) and [**IBasePrintable**](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.IBasePrintable.class) interfaces. To determine if a component implements an interface, refer to our documentation (for instance, check the [ASPxPivotGridExporter](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGridExporter.class) class link) or source code.

This example uses the **Printing.Core** library. Make sure that you include it into your project. 

### Steps to implement:
1. Create a [PrintableComponentLinkBase ](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.members) object for each control you want to export.
2. Specify the [PrintableComponentLinkBase.Component](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.Component.property) property: use your printable component here. 
3. Create a [CompositeLinkBase](https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraPrintingLinksCompositeLinkBasetopic) object. It is used to combine several printing links.
4. Add PrintingLinkBase objects to the [CompositeLinkBase.Links](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.Links.property) collection. 
5. Call the [CompositeLinkBase.ExportTo[FORMAT]](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.ExportToDocx.overloads) method to export the document.

