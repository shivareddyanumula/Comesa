<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Pms_Rating_chart.aspx.cs" Inherits="PMS_frm_Pms_Rating_chart" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lbl_Header" runat="server" Text="Rating Chart" Font-Bold="True"
                    meta:resourcekey="lbl_Header"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BU" runat="server" Text="Business&nbsp;Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true"
                    MaxHeight="120px" AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_AppCycle" runat="server" Text="Appraisal&nbsp;Cycle"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_AppCycle" runat="server" MarkFirstMatch="true"
                    MaxHeight="120px" AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_AppCycle_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">

                <telerik:RadChart ID="RadChart2" runat="server" DefaultType="Spline" AutoTextWrap="true"
                    Skin="LightGreen" OnItemDataBound="RadChart2_ItemDataBound" Width="650px" SeriesOrientation="Horizontal"
                    Visible="true" Height="250px">
                    <Series>
                        <telerik:ChartSeries Name="tEST" Type="Spline" DataLabelsColumn="APP_OVERALLRTG" DataXColumn="percentage"
                            DataYColumn="Average">
                            <Appearance LegendDisplayMode="ItemLabels">
                                <FillStyle FillType="ComplexGradient" MainColor="243, 206, 119">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="243, 206, 119" />
                                            <telerik:GradientElement Color="236, 190, 82" Position="0.5" />
                                            <telerik:GradientElement Color="210, 157, 44" Position="1" />
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="223, 170, 40" />
                            </Appearance>
                        </telerik:ChartSeries>
                    </Series>
                    <Legend>
                        <Appearance Position-AlignedPosition="Right">
                            <ItemAppearance>
                            </ItemAppearance>
                            <ItemTextAppearance TextProperties-Color="113, 94, 57">
                            </ItemTextAppearance>
                            <Border Color="225, 217, 201"></Border>
                        </Appearance>
                    </Legend>
                    <PlotArea>
                        <XAxis>
                            <Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                                <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <Appearance RotationAngle="270" Dimensions-Width="450px">
                                </Appearance>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </XAxis>
                        <YAxis>
                            <Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202" CustomFormat="##;##">
                                <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                                <MinorGridLines Color="231, 225, 212"></MinorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <Appearance RotationAngle="0">
                                </Appearance>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </YAxis>
                        <YAxis2>
                            <AxisLabel>
                                <Appearance RotationAngle="0">
                                </Appearance>
                            </AxisLabel>
                        </YAxis2>
                        <Appearance Dimensions-Margins="18%, 23%, 12%, 10%">
                            <FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                            </FillStyle>
                            <Border Color="226, 218, 202"></Border>
                        </Appearance>
                    </PlotArea>
                    <Appearance>
                        <FillStyle MainColor="235, 249, 213">
                        </FillStyle>
                        <Border Color="203, 225, 169"></Border>
                    </Appearance>
                    <ChartTitle Visible="false">
                        <Appearance>
                            <FillStyle MainColor="">
                            </FillStyle>
                        </Appearance>
                        <TextBlock Text="Leaves Left:">
                            <Appearance TextProperties-Color="77, 153, 4" Dimensions-AutoSize="False" Dimensions-Height="50px"
                                Dimensions-Width="200px" TextProperties-Font="Verdana, 10pt">
                            </Appearance>
                        </TextBlock>
                    </ChartTitle>
                </telerik:RadChart>
            </td>
        </tr>
    </table>
</asp:Content>