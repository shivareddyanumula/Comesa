<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_leaveDetails.aspx.cs"
    Inherits="Masters_Frm_leaveDetails" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </div>
    <table align="center">
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadGrid ID="Rg_LeaveApp" AllowPaging="true" runat="server" AutoGenerateColumns="False"
                    OnNeedDataSource="Rg_LeaveApp_NeedDataSource" AllowFilteringByColumn="false" AllowSorting="true"
                    GridLines="None" Skin="WebBlue" Visible="false" meta:resourcekey="Rg_LeaveApp">
                    <MasterTableView CommandItemDisplay="None" PageSize="10">
                        <Columns>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_ID" UniqueName="LEAVEAPP_ID" HeaderText="ID"
                                meta:resourcekey="LEAVEAPP_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID"
                                HeaderText="BID" meta:resourcekey="BUSINESSUNIT_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_EMP_ID" UniqueName="LEAVEAPP_EMP_ID"
                                HeaderText="Employee Name" meta:resourcekey="LEAVEAPP_EMP_ID">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_LEAVETYPE_ID" UniqueName="LEAVEAPP_LEAVETYPE_ID"
                                HeaderText="Leave Type" meta:resourcekey="LEAVEAPP_LEAVETYPE_ID">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_APPLIEDDATE" UniqueName="LEAVEAPP_APPLIEDDATE"
                                HeaderText="Applied Date" meta:resourcekey="LEAVEAPP_APPLIEDDATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_FROMDATE" UniqueName="LEAVEAPP_FROMDATE" DataFormatString = "{0:dd/MM/yyyy}"
                                HeaderText="From Date" meta:resourcekey="LEAVEAPP_FROMDATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_TODATE" UniqueName="LEAVEAPP_TODATE" DataFormatString = "{0:dd/MM/yyyy}"
                                HeaderText="To Date" meta:resourcekey="LEAVEAPP_TODATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_DAYS" UniqueName="LEAVEAPP_DAYS" HeaderText="Leave Days"
                                meta:resourcekey="LEAVEAPP_DAYS">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_STATUS" UniqueName="LEAVEAPP_STATUS"
                                Visible="True" HeaderText="Status" meta:resourcekey="LEAVEAPP_STATUS">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="50px" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("LEAVEAPP_STATUS") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Employee Scale"
                                AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <PagerStyle AlwaysVisible="true" />
                    </MasterTableView>
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Scrolling AllowScroll="false" />
                        <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                    </ClientSettings>
                    <FilterMenu OnClientShown="MenuShowing" DefaultGroupSettings-ExpandDirection="Down"
                        DefaultGroupSettings-Height="100px" />
                </telerik:RadGrid>
            </td>
            <td>
                <telerik:RadGrid ID="Rg_rollback" AllowPaging="true" runat="server" AutoGenerateColumns="False"
                    OnNeedDataSource="Rg_LeaveApp_NeedDataSourcerollback" AllowFilteringByColumn="false"
                    AllowSorting="true" GridLines="None" Skin="WebBlue" Visible="false" meta:resourcekey="Rg_LeaveApp">
                    <MasterTableView CommandItemDisplay="None" PageSize="10">
                        <Columns>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_ID" UniqueName="LEAVEAPP_ID" HeaderText="ID"
                                meta:resourcekey="LEAVEAPP_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID"
                                HeaderText="BID" meta:resourcekey="BUSINESSUNIT_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_EMP_ID" UniqueName="LEAVEAPP_EMP_ID"
                                HeaderText="Employee Name" meta:resourcekey="LEAVEAPP_EMP_ID">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_LEAVETYPE_ID" UniqueName="LEAVEAPP_LEAVETYPE_ID"
                                HeaderText="Leave Type" meta:resourcekey="LEAVEAPP_LEAVETYPE_ID">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_APPLIEDDATE" UniqueName="LEAVEAPP_APPLIEDDATE"
                                HeaderText="Applied Date" meta:resourcekey="LEAVEAPP_APPLIEDDATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_FROMDATE" UniqueName="LEAVEAPP_FROMDATE" DataFormatString = "{0:dd/MM/yyyy}"
                                HeaderText="From Date" meta:resourcekey="LEAVEAPP_FROMDATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_TODATE" UniqueName="LEAVEAPP_TODATE" DataFormatString = "{0:dd/MM/yyyy}"
                                HeaderText="To Date" meta:resourcekey="LEAVEAPP_TODATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_DAYS" UniqueName="LEAVEAPP_DAYS" HeaderText="Leave Days"
                                meta:resourcekey="LEAVEAPP_DAYS">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LEAVEAPP_STATUS" UniqueName="LEAVEAPP_STATUS"
                                Visible="True" HeaderText="Status" meta:resourcekey="LEAVEAPP_STATUS">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="50px" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("LEAVEAPP_STATUS") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE"
                                HeaderText="Employee Scale" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_rolback" runat="server"   CommandArgument='<%#Eval("LEAVEAPP_ID") %>'
                                        OnCommand="Rollback_click" Text="RollBack">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="right" Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <PagerStyle AlwaysVisible="true" />
                    </MasterTableView>
                    <GroupingSettings CaseSensitive="false" />
                    <ClientSettings>
                        <Scrolling AllowScroll="false" />
                        <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                    </ClientSettings>
                    <FilterMenu OnClientShown="MenuShowing" DefaultGroupSettings-ExpandDirection="Down"
                        DefaultGroupSettings-Height="100px" />
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
