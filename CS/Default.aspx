<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="S130793._Default" %>

<%@ Register Assembly="DevExpress.XtraCharts.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.XtraCharts.v13.1.Web, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dxpgw" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export" />
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [CategoryName], [ProductSales] FROM [ProductReports]"></asp:AccessDataSource>
        <br />
        <dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" CssClass="" DataSourceID="AccessDataSource1">
            <Fields>
                <dxwpg:PivotGridField ID="fieldCategoryName" Area="RowArea" AreaIndex="0" FieldName="CategoryName">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldProductSales" Area="DataArea" AreaIndex="0" FieldName="ProductSales">
                </dxwpg:PivotGridField>
            </Fields>
        </dxwpg:ASPxPivotGrid>
        <dxpgw:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGrid1">
        </dxpgw:ASPxPivotGridExporter>
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="ASPxPivotGrid1"  Height="434px" SeriesDataMember="Series" Width="861px">
            <SeriesTemplate ArgumentDataMember="Arguments" 
                 
                ValueDataMembersSerializable="Values">
                <ViewSerializable>
<cc1:SideBySideBarSeriesView HiddenSerializableString="to be serialized">
                </cc1:SideBySideBarSeriesView>
</ViewSerializable>
                <LabelSerializable>
<cc1:SideBySideBarSeriesLabel HiddenSerializableString="to be serialized" LineVisible="True">
                    <FillStyle >
                        <OptionsSerializable>
<cc1:SolidFillOptions HiddenSerializableString="to be serialized" />
</OptionsSerializable>
                    </FillStyle>
                </cc1:SideBySideBarSeriesLabel>
</LabelSerializable>
                <PointOptionsSerializable>
<cc1:PointOptions HiddenSerializableString="to be serialized">
                </cc1:PointOptions>
</PointOptionsSerializable>
                <LegendPointOptionsSerializable>
<cc1:PointOptions HiddenSerializableString="to be serialized">
                </cc1:PointOptions>
</LegendPointOptionsSerializable>
            </SeriesTemplate>
            <DiagramSerializable>
<cc1:XYDiagram>
                <axisx visibleinpanesserializable="-1">
<Range SideMarginsEnabled="True"></Range>
</axisx>
                <axisy visibleinpanesserializable="-1">
<Range SideMarginsEnabled="True"></Range>
</axisy>
            </cc1:XYDiagram>
</DiagramSerializable>
            <FillStyle >
                <OptionsSerializable>
<cc1:SolidFillOptions HiddenSerializableString="to be serialized" />
</OptionsSerializable>
            </FillStyle>
            <Legend AlignmentHorizontal="Center" AlignmentVertical="TopOutside"></Legend>
        </dxchartsui:WebChartControl>
    </div>
    </form>
</body>
</html>
