<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_leavetran.aspx.cs" Inherits="Payroll_frm_leavetran" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--   <telerik:RadAjaxManagerProxy ID="RAM_ExpenseEntry" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="rg_leavetypewise">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rtn_Reportlist">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rg_EmployeeWise">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rg_EmployeeLeavedetail">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_BU">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_emp">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rcmb_Leaves">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManagerProxy>--%>
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_leavetranHeader" runat="server" Text="Leave Reports"
                            Font-Bold="True" meta:resourcekey="lbl_leavetranHeader"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_RT_page" runat="server" SelectedIndex="0"
                            Style="z-index: 10" Width="990px" Height="490px" ScrollBars="Auto">
                            <telerik:RadPageView ID="Rp_RT_ViewMain" runat="server">
                                <table align="center" width="60%">
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rtn_Reportlist" runat="server" OnSelectedIndexChanged="rtn_Reportlist_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Value="0">Employee Wise Leave Report</asp:ListItem>
                                                <asp:ListItem Value="1">Leave Type wise Report</asp:ListItem>
                                                <asp:ListItem Value="3">Business unit wise Leave Report</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_RT_Employee" runat="server">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True" Skin="WebBlue"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_BusinessUnit" Filter="Contains"
                                                OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MaxHeight="120px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td style="margin-left: 200px">
                                            <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                                                MaxHeight="120px" Skin="WebBlue" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr>
                                        <td colspan="6">
                                            <telerik:RadGrid ID="rg_EmployeeWise" runat="server" Skin="WebBlue"
                                                ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                                HeaderStyle-HorizontalAlign="Center">
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_RT_LeaveStr" runat="server">
                                <table align="center">
                                    <tr>
                                        <%--      <td>
                                            <asp:Label ID="lbl_LeaveStr" runat="server" Text="Leave Structure"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadComboBox  ID="rcmb_LeaveStructure" runat="server" AutoPostBack="True"
                                                 Skin="WebBlue"  meta:resourcekey="rcmb_LeaveStructure">
                                            </telerik:RadComboBox>
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="lbl_LeaveTypes" runat="server" Text="Leave Type"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Leaves" runat="server" AutoPostBack="True" Skin="WebBlue" MaxHeight="120px" Filter="Contains"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_Leaves" OnSelectedIndexChanged="rcmb_Leaves_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr>
                                        <td colspan="6">
                                            <telerik:RadGrid ID="rg_leavetypewise" runat="server" Skin="WebBlue" ClientSettings-Scrolling-AllowScroll="true"
                                                ClientSettings-Scrolling-UseStaticHeaders="true" HeaderStyle-HorizontalAlign="Center">
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Detailed" runat="server">
                                <table align="center">
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="lbl_BU" runat="server" meta:resourcekey="lbl_BU"
                                                Text="Business&amp;nbsp;Unit"></asp:Label>
                                        </td>
                                        <td class="style2">
                                            <b>:</b>
                                        </td>
                                        <td class="style2">
                                            <telerik:RadComboBox ID="rcmb_BU" runat="server" AutoPostBack="True" Skin="WebBlue" MaxHeight="120px" Filter="Contains"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_BU" OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td style="margin-left: 200px" class="style2">
                                            <asp:Label ID="lbl_emp" runat="server" Text="Employee"></asp:Label>
                                        </td>
                                        <td class="style2">
                                            <b>:</b>
                                        </td>
                                        <td class="style2">
                                            <telerik:RadComboBox ID="rcmb_emp" runat="server" AutoPostBack="True" MaxHeight="120px" MarkFirstMatch="true"
                                                Skin="WebBlue" OnSelectedIndexChanged="rcmb_emp_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:RadioButtonList ID="rd_Periodlist" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="rd_Periodlist_SelectedIndexChanged">
                                                <asp:ListItem Value="1">One Month</asp:ListItem>
                                                <asp:ListItem Value="3">Three Months</asp:ListItem>
                                                <asp:ListItem Value="6">Six Months </asp:ListItem>
                                                <asp:ListItem Value="12">Twelve Months </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr>
                                        <td colspan="6">
                                            <telerik:RadGrid ID="rg_EmployeeLeavedetail" runat="server" AutoGenerateColumns="true"
                                                Skin="WebBlue" OnItemDataBound="rg_EmployeeLeavedetail_ItemDataBound"
                                                ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <CommandItemTemplate>
                                                        <div align="left">
                                                            <asp:Label ID="lbl_Header" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                        </div>
                                                    </CommandItemTemplate>

                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style2 {
            height: 12px;
        }
    </style>
</asp:Content>