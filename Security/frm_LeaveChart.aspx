<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_LeaveChart.aspx.cs" Inherits="Security_frm_LeaveChart" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td align="center">
                        <telerik:RadComboBox ID="rcmbPeriod" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                            OnSelectedIndexChanged="rcmbPeriod_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" InitialValue="Select" Text="*"
                            ControlToValidate="rcmbPeriod" ValidationGroup="Leave" ErrorMessage="Please select period"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPeriodElement" runat="server" Text="Period Element"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td align="center">
                        <telerik:RadComboBox ID="rcmbPeriodElement" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                            OnSelectedIndexChanged="rcmbPeriodElement_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPeriodElement" runat="server" InitialValue="Select"
                            Text="*" ControlToValidate="rcmbPeriodElement" ErrorMessage="Please select period element"
                            ValidationGroup="Leave"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trLeaveBalance" runat="server" visible="true">
                    <td colspan="4">
                        <telerik:RadChart ID="RadChart2" runat="server" DefaultType="Pie" AutoTextWrap="true"
                            Skin="LightGreen" OnItemDataBound="RadChart2_ItemDataBound" Width="450px" SeriesOrientation="Horizontal"
                            Visible="false" Height="250px">
                            <Series>
                                <telerik:ChartSeries Name="tEST" Type="Pie" DataYColumn="LT_CURRENTBALANCE">
                                    <Appearance LegendDisplayMode="ItemLabels">
                                        <%--<FillStyle FillType="ComplexGradient" MainColor="243, 206, 119">
                                        <FillSettings>
                                            <ComplexGradient>
                                                <telerik:GradientElement Color="243, 206, 119" />
                                                <telerik:GradientElement Color="236, 190, 82" Position="0.5" />
                                                <telerik:GradientElement Color="210, 157, 44" Position="1" />
                                            </ComplexGradient>
                                        </FillSettings>
                                    </FillStyle>--%>
                                        <%-- <TextAppearance TextProperties-Color="112, 93, 56">
                                    </TextAppearance>
                                    <Border Color="223, 170, 40" />--%>
                                    </Appearance>
                                </telerik:ChartSeries>
                            </Series>
                            <Legend>
                                <Appearance Position-AlignedPosition="Right">
                                    <ItemAppearance>
                                    </ItemAppearance>
                                    <%--<ItemTextAppearance TextProperties-Color="113, 94, 57">
                                </ItemTextAppearance>
                                <Border Color="225, 217, 201"></Border>--%>
                                </Appearance>
                            </Legend>
                            <PlotArea>
                                <XAxis>
                                    <%--<Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                                    <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                                    <TextAppearance TextProperties-Color="112, 93, 56">
                                    </TextAppearance>
                                </Appearance>--%>
                                    <AxisLabel>
                                        <Appearance RotationAngle="270">
                                        </Appearance>
                                        <TextBlock>
                                            <%--<Appearance TextProperties-Color="112, 93, 56">
                                        </Appearance>--%>
                                        </TextBlock>
                                    </AxisLabel>
                                </XAxis>
                                <YAxis>
                                    <%--<Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202">
                                    <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                                    <MinorGridLines Color="231, 225, 212"></MinorGridLines>
                                    <TextAppearance TextProperties-Color="112, 93, 56">
                                    </TextAppearance>
                                </Appearance>--%>
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
                                    <%--<FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                                </FillStyle>--%>
                                    <Border Color="226, 218, 202"></Border>
                                </Appearance>
                            </PlotArea>
                            <%--<Appearance>
                            <FillStyle MainColor="235, 249, 213">
                            </FillStyle>
                            <Border Color="203, 225, 169"></Border>
                        </Appearance>--%>
                            <ChartTitle>
                                <Appearance>
                                    <FillStyle MainColor="">
                                    </FillStyle>
                                </Appearance>
                                <TextBlock Text="Leaves Left:">
                                    <Appearance TextProperties-Color="77, 153, 4" Dimensions-AutoSize="False" Dimensions-Height="50px"
                                        Dimensions-Width="120px" TextProperties-Font="Verdana, 10pt">
                                    </Appearance>
                                </TextBlock>
                            </ChartTitle>
                        </telerik:RadChart>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsLeave" runat="server" ShowMessageBox="false" ShowSummary="true" ValidationGroup="Leave" />
            <br />
            <asp:Label ID="lbl_ZeroLeaves" runat="server" Visible="false"> </asp:Label>
        </div>
    </form>
</body>
</html>