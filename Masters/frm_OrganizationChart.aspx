<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_OrganizationChart.aspx.cs" Inherits="Masters_frm_OrganizationChart" %>

<%@ Register Assembly="Dhanush.SmartHR" Namespace="SmartHR" TagPrefix="swc" %>
<asp:Content ID="cnt_OrganizationChart" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align: center; font-weight: bold;">
                <asp:Label ID="lblOrgHeading" Text="Organization Chart" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="pnlOrgChart" runat="server" ScrollBars="Auto" Height="500px" Width="1324px" HorizontalAlign="Center">
                <swc:SmartChartPro ID="wscOrganization" runat="server" Width="1400px" Height="800px" FitToWidth="true" XSpacing="50" YSpacing="50"
                    DrawShadows="True" DataTitleFields="CODE,DESC,ADDRESS" DataNodeName="BusinessUnit"
                    DataKeyField="ID" ShadowColor="Gray" DataFields="CODE" BoxColor="LightGray" BoxGradient="True"
                    BoxTextColor="Black" ChartDepth="9" SmartChartDirectory="~/Images/TempImg" AllowDrillDown="true" DrawLines="true"
                    fontstyle="Bold" ShadowOffset="5" TitleColor="MidnightBlue" MaxChildrenPerLevelGroup="50" OnSmartChartClicked="wscOrganization_SmartChartClicked"
                    OutputType="Image" />
            </asp:Panel>
            <%--<table align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlOrgChart" runat="server" ScrollBars="Auto" Height="500px" Width="1024px" HorizontalAlign="Center"   >
                            <swc:SmartChartPro ID="wscOrganization" runat="server" Width="6000px" Height="5000px"
                                DrawShadows="True" DataTitleFields="CODE,DESC,ADDRESS" DataNodeName="BusinessUnit" 
                                DataKeyField="ID" ShadowColor="Gray" DataFields="CODE" BoxColor="LightGray" BoxGradient="True"
                                BoxTextColor="Black" ChartDepth="9" SmartChartDirectory="~/Images/TempImg" AllowDrillDown="true"
                                fontstyle="Bold" ShadowOffset="5" TitleColor="MidnightBlue" MaxChildrenPerLevelGroup="50" OnSmartChartClicked="wscOrganization_SmartChartClicked"
                                OutputType="Image" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 5%">
                        <telerik:RadTreeView ID="rtvOrgStructure" runat="server" OnNodeExpand="rtvOrgStructure_NodeExpand" OnNodeClick="rtvOrgStructure_NodeClick">
                        </telerik:RadTreeView>
                    </td>
                    <td valign="top">

                        <div id="dvEmpDtls" visible="false" runat="server" style="position: fixed; float: right; width: 310px; height: 150px; padding: 1px 0 0 30px; margin-top: 10px; margin-left: 70px; border: solid; border-color: #275071">
                            <div style="color: #4888a3; font-size: 23px; padding-bottom: 10px;">
                                Employee Details: 
                            </div>
                            <div class="details" style="font-size: 12px; line-height: 21px;">
                                <b>Name:</b>
                                <asp:Label runat="server" ID="lblName"></asp:Label>
                                <br />
                                <b>Employee Code:</b>
                                <asp:Label runat="server" ID="lblEmpCode"></asp:Label>
                                <br />
                                <b>Designation: </b>
                                <asp:Label runat="server" ID="lblDesignation"></asp:Label>
                                <br />
                                <b>Department: </b>
                                <asp:Label ID="lblDept" runat="server"></asp:Label>
                                <br />
                                <b>Reporting Manager: </b>
                                <asp:Label runat="server" ID="lblMgr"></asp:Label>
                            </div>
                        </div>
                    </td>
                </tr>

            </table>--%>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                <ProgressTemplate>
                    <div style="font-size: medium; position: fixed; width: 80px; height: 20px; top: 10px; left: 45%; background-color: whitesmoke;">
                        <b>Loading...</b>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="rtvOrgStructure" EventName="NodeClick" />--%>
            <asp:AsyncPostBackTrigger ControlID="wscOrganization" EventName="SmartChartClicked" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <telerik:RadWindowManager ID="RWM_EmpDetails" runat="server"></telerik:RadWindowManager>
            <telerik:RadWindow ID="RWOrgDetails" runat="server" Height="200px">
                <ContentTemplate>
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblHeading" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%--<telerik:RadGrid ID="RG_EmployeeDetails" runat="server" Skin="WebBlue" GridLines="None" Width="500" ActiveItemStyle-HorizontalAlign="Center" 
                                    AutoGenerateColumns="False" AllowPaging="true" PageSize="2" OnNeedDataSource="RG_EmployeeDetails_NeedDataSource" OnPageIndexChanged="RG_EmployeeDetails_PageIndexChanged">
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" HeaderText="Name"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Designation"></telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>--%>
                                <telerik:RadGrid ID="RG_EmployeeDetails" runat="server" Skin="WebBlue" GridLines="None"
                                    AutoGenerateColumns="False" OnNeedDataSource="RG_EmployeeDetails_NeedDataSource" AllowPaging="True"
                                    AllowSorting="True">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" HeaderText="Name"
                                                meta:resourcekey="EMPLOYEE_NAME" UniqueName="EMPLOYEE_NAME">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Designation"
                                                meta:resourcekey="POSITIONS_CODE" UniqueName="POSITIONS_CODE">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </telerik:RadWindow>
        </ContentTemplate>
        <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RG_EmployeeDetails" EventName="PageIndexChanged" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>