<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Dashboard1.aspx.cs" Inherits="Masters_Default3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table width="990px" align="center">
        <tr>
            <td align="center" colspan="5">
                <telerik:RadTicker AutoStart="true" runat="server" ID="Radticker1" Loop="true">
                </telerik:RadTicker>
            </td>
        </tr>
        <tr>
            <td width="270px">
                &nbsp;&nbsp;
                <asp:Label ID="lbl_quicklink" runat="server" Text="Quick Links">
                </asp:Label>
                <telerik:RadTabStrip  runat="server" ID="RTS_MANAGER"
                    Orientation="VerticalLeft" SelectedIndex="0" Align="Justify">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="Apply Leave" NavigateUrl="~/Payroll/frm_Leaveapplication.aspx">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Compensatory Off Request" NavigateUrl="~/Payroll/frm_comoffrequest.aspx"
                            Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Expense Request" NavigateUrl="~/Payroll/frm_ExpenseTrans.aspx ">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Loan/Advances Request" NavigateUrl="~/Payroll/SelectLoanType.aspx">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
            <td align="center" width="150px">
                <telerik:RadChart ID="RadChart2" runat="server" DefaultType="Pie" AutoTextWrap="true"
                    Skin="LightGreen" OnItemDataBound="RadChart2_ItemDataBound" Width="150px" Visible="false"
                    Height="250px">
                    <PlotArea>
                        <XAxis>
                            <Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                                <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </XAxis>
                        <YAxis>
                            <Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202">
                                <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                                <MinorGridLines Color="231, 225, 212"></MinorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </YAxis>
                        <Appearance Dimensions-Margins="20%, 23%, 30%, 10%">
                            <FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                            </FillStyle>
                            <Border Color="226, 218, 202"></Border>
                        </Appearance>
                    </PlotArea>
                    <Appearance Dimensions-Width="150px">
                        <FillStyle MainColor="235, 249, 213">
                        </FillStyle>
                        <Border Color="203, 225, 169"></Border>
                    </Appearance>
                    <Series>
                        <telerik:ChartSeries Name="Series 1" Type="Pie" DataYColumn="LT_CURRENTBALANCE" DataLabelsColumn="LEAVEMASTER_CODE">
                            <Appearance LegendDisplayMode="ItemLabels">
                                <FillStyle MainColor="243, 206, 119" FillType="ComplexGradient">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="243, 206, 119"></telerik:GradientElement>
                                            <telerik:GradientElement Color="236, 190, 82" Position="0.5"></telerik:GradientElement>
                                            <telerik:GradientElement Color="210, 157, 44" Position="1"></telerik:GradientElement>
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="223, 170, 40"></Border>
                            </Appearance>
                        </telerik:ChartSeries>
                    </Series>
                    <ChartTitle>
                        <Appearance>
                            <FillStyle MainColor="">
                            </FillStyle>
                        </Appearance>
                        <TextBlock Text="Casual and Sick Leaves:">
                            <Appearance TextProperties-Color="77, 153, 4" TextProperties-Font="Verdana, 10pt">
                            </Appearance>
                        </TextBlock>
                    </ChartTitle>
                    <Legend>
                        <Appearance Corners="Round, Round, Round, Round, 6" Position-AlignedPosition="BottomRight">
                            <ItemTextAppearance TextProperties-Color="113, 94, 57">
                            </ItemTextAppearance>
                            <Border Color="225, 217, 201"></Border>
                        </Appearance>
                    </Legend>
                </telerik:RadChart>
                <br />
                <asp:Label ID="lbl_zeroleave" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="center" width="150px">
                <telerik:RadChart ID="RadChart_YtdBalances" runat="server" DefaultType="Pie" AutoTextWrap="true"
                    Skin="LightGreen" OnItemDataBound="RadChart_YtdBalances_ItemDataBound" Width="150px"
                    Visible="False" Height="250px">
                    <Series>
                        <telerik:ChartSeries Name="Series 1">
                            <Appearance>
                                <FillStyle MainColor="243, 206, 119" FillType="ComplexGradient">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="243, 206, 119"></telerik:GradientElement>
                                            <telerik:GradientElement Color="236, 190, 82" Position="0.5"></telerik:GradientElement>
                                            <telerik:GradientElement Color="210, 157, 44" Position="1"></telerik:GradientElement>
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="223, 170, 40"></Border>
                            </Appearance>
                        </telerik:ChartSeries>
                        <telerik:ChartSeries Name="Series 2">
                            <Appearance>
                                <FillStyle MainColor="154, 220, 230" FillType="ComplexGradient">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="154, 220, 230"></telerik:GradientElement>
                                            <telerik:GradientElement Color="121, 207, 220" Position="0.5"></telerik:GradientElement>
                                            <telerik:GradientElement Color="89, 185, 204" Position="1"></telerik:GradientElement>
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="117, 177, 192"></Border>
                            </Appearance>
                        </telerik:ChartSeries>
                    </Series>
                    <PlotArea>
                        <XAxis>
                            <Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                                <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </XAxis>
                        <YAxis>
                            <Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202">
                                <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                                <MinorGridLines Color="231, 225, 212"></MinorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </YAxis>
                        <Appearance Dimensions-Margins="45%, 23%, 12%, 10%">
                            <FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                            </FillStyle>
                            <Border Color="226, 218, 202"></Border>
                        </Appearance>
                    </PlotArea>
                    <Appearance Dimensions-Width="150px">
                        <FillStyle MainColor="235, 249, 213">
                        </FillStyle>
                        <Border Color="203, 225, 169"></Border>
                    </Appearance>
                    <ChartTitle>
                        <Appearance>
                            <FillStyle MainColor="">
                            </FillStyle>
                        </Appearance>
                        <TextBlock Text="YTD balances:">
                            <Appearance TextProperties-Color="77, 153, 4" TextProperties-Font="Verdana, 10pt">
                            </Appearance>
                        </TextBlock>
                    </ChartTitle>
                    <Legend>
                        <Appearance Corners="Round, Round, Round, Round, 6" Position-AlignedPosition="BottomRight">
                            <ItemTextAppearance TextProperties-Color="113, 94, 57">
                            </ItemTextAppearance>
                            <Border Color="225, 217, 201"></Border>
                        </Appearance>
                    </Legend>
                </telerik:RadChart>
                <br />
                <asp:Label ID="lbl_zeroytd" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="center" width="150px">
                <telerik:RadChart ID="RadChart_Performance" runat="server" DefaultType="Pie" AutoTextWrap="true"
                    Skin="LightGreen" OnItemDataBound="RadChart_Performance_ItemDataBound" Width="150px"
                    Visible="false" Height="250px">
                    <Series>
                        <telerik:ChartSeries Name="Series 1">
                            <Appearance>
                                <FillStyle MainColor="243, 206, 119" FillType="ComplexGradient">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="243, 206, 119"></telerik:GradientElement>
                                            <telerik:GradientElement Color="236, 190, 82" Position="0.5"></telerik:GradientElement>
                                            <telerik:GradientElement Color="210, 157, 44" Position="1"></telerik:GradientElement>
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="223, 170, 40"></Border>
                            </Appearance>
                        </telerik:ChartSeries>
                        <telerik:ChartSeries Name="Series 2">
                            <Appearance>
                                <FillStyle MainColor="154, 220, 230" FillType="ComplexGradient">
                                    <FillSettings>
                                        <ComplexGradient>
                                            <telerik:GradientElement Color="154, 220, 230"></telerik:GradientElement>
                                            <telerik:GradientElement Color="121, 207, 220" Position="0.5"></telerik:GradientElement>
                                            <telerik:GradientElement Color="89, 185, 204" Position="1"></telerik:GradientElement>
                                        </ComplexGradient>
                                    </FillSettings>
                                </FillStyle>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                                <Border Color="117, 177, 192"></Border>
                            </Appearance>
                        </telerik:ChartSeries>
                    </Series>
                    <PlotArea>
                        <XAxis>
                            <Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                                <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </XAxis>
                        <YAxis>
                            <Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202">
                                <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                                <MinorGridLines Color="231, 225, 212"></MinorGridLines>
                                <TextAppearance TextProperties-Color="112, 93, 56">
                                </TextAppearance>
                            </Appearance>
                            <AxisLabel>
                                <TextBlock>
                                    <Appearance TextProperties-Color="112, 93, 56">
                                    </Appearance>
                                </TextBlock>
                            </AxisLabel>
                        </YAxis>
                        <Appearance Dimensions-Margins="20%, 23%, 30%, 10%">
                            <FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                            </FillStyle>
                            <Border Color="226, 218, 202"></Border>
                        </Appearance>
                    </PlotArea>
                    <Appearance Dimensions-Width="150px">
                        <FillStyle MainColor="235, 249, 213">
                        </FillStyle>
                        <Border Color="203, 225, 169"></Border>
                    </Appearance>
                    <ChartTitle>
                        <Appearance>
                            <FillStyle MainColor="">
                            </FillStyle>
                        </Appearance>
                        <TextBlock Text="Performance:">
                            <Appearance TextProperties-Color="77, 153, 4" TextProperties-Font="Verdana, 10pt">
                            </Appearance>
                        </TextBlock>
                    </ChartTitle>
                    <Legend>
                        <Appearance Corners="Round, Round, Round, Round, 6" Position-AlignedPosition="BottomRight">
                            <ItemTextAppearance TextProperties-Color="113, 94, 57">
                            </ItemTextAppearance>
                            <Border Color="225, 217, 201"></Border>
                        </Appearance>
                    </Legend>
                </telerik:RadChart>
                <br />
                <asp:Label ID="lbl_zerohike" runat="server" Visible="false"></asp:Label>
            </td>
            <td width="270px" align="right" rowspan="2">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_MgrLeaveAppStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_MgrCompOffAppStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_MgrExpenseAppStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="990px" align="center">
        <tr>
            <td align="left" width="30%">
                <asp:Label ID="lbl_quicklink2" runat="server" Text="Quick Links">
                </asp:Label>
                <telerik:RadTabStrip ID="RTSM_PENDING" runat="server" 
                    Orientation="VerticalLeft" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="Pending Leave Approval" NavigateUrl="~/Approval/frm_LeaveApproval.aspx">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Pending Comp Off Approval" NavigateUrl="~/Approval/frm_CompOffApproval.aspx">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Pending Expense Approval" NavigateUrl="~/Approval/frm_ExpenseApproval.aspx">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Pending Loan Approval">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
            <td align="center" width="20%">
                <table align="center" width="600px">
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                            <asp:Label ID="lbl_Birthday" runat="server" Style="font-weight: 700; font-size: small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Label ID="lbl_Reminders" runat="server" Text="HAPPY BIRTHDAY TO" Style="font-weight: 700;
                                font-size: small"></asp:Label>&nbsp;&nbsp; <u>
                                    <telerik:RadTicker ID="RTicker" runat="server" AutoStart="true" Loop="true" TickSpeed="50"
                                        Font-Bold="True" Font-Names="Arial" Font-Size="12pt">
                                        <Items>
                                            <telerik:RadTickerItem Text='<%# Eval("EMPNAME")%>'></telerik:RadTickerItem>
                                        </Items>
                                    </telerik:RadTicker>
                                </u>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" width="30%">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_pendingleave" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_pendingcompoff" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_pendingexpense" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_pendingloan" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="990px" align="center">
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <table width="40%" align="center" bgcolor="white">
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lbl_PersonalDetails" runat="server" Text="Employee Personal Details"
                    ForeColor="#3399FF" Font-Size="20px" Font-Underline="true"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_EmployeeId" runat="server" Text="Employee ID:" Font-Bold="True"
                    ForeColor="#3399FF" Font-Size="15px"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <asp:Label ID="lbl_EmpId" runat="server" Font-Bold="true" ForeColor="#3399FF" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_EmployeeName" runat="server" Text="Employee Name:" ForeColor="#3399FF"
                    Font-Bold="true" Font-Size="15px"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <asp:Label ID="lbl_EmpName" runat="server" Font-Bold="true" ForeColor="#3399FF" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_EmployeeDesg" runat="server" Text="Employee Designation:" ForeColor="#3399FF"
                    Font-Bold="true" Font-Size="15px"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <asp:Label ID="lbl_EmpDesignation" runat="server" Font-Bold="true" ForeColor="#3399FF"
                    Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_EmployeeDept" runat="server" Text="Employee Department:" ForeColor="#3399FF"
                    Font-Bold="true" Font-Size="15px"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <asp:Label ID="lbl_EmpDepartment" runat="server" Font-Bold="true" ForeColor="#3399FF"
                    Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lbl_EmployeeBloodGroup" runat="server" Text="Employee BloodGroup:"
                    ForeColor="#3399FF" Font-Bold="true" Font-Size="15px"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <asp:Label ID="lbl_EmpBloodGroup" runat="server" Font-Bold="true" Font-Size="15px"
                    ForeColor="#3399FF"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
