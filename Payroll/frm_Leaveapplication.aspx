<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Leaveapplication.aspx.cs" Inherits="Payroll_frm_Leaveapplication"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function ShowPopup() {
            //To show popup with Incident details
            var empID = document.getElementById('<%= rcmb_LeaveAppEmployeeID.ClientID %>').control._value;
            var IncID = document.getElementById('<%= rcmb_IncidentLeave.ClientID %>').control._value;
            var win = window.radopen('../Workman_Compensation/frm_IncidentDetails.aspx?empID=' + empID + "&incID=" + IncID, "RW_IncidentDetails");
            win.center();
            win.set_modal(true);
        }

        function ShowPopForm() {
            var win = window.radopen("frm_empleavebal.aspx", "RW_Login");
            win.center();
            win.set_modal(true);
        }
    </script>

    <%-- <telerik:RadAjaxManagerProxy ID="RAM_LeaveApp" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_LeaveApp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_LeaveAppEmployeeID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_LeaveAppLType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <style type="text/css">
            div.RadGrid .rgPager .rgAdvPart {
                display: none;
            }
        </style>

        <script language="javascript" type="text/javascript">

            function OnDateSelected(sender, e) {
                var btn = document.getElementById('<%= btn_Calc.ClientID  %>');
                if (btn != null) {
                    btn.click(); event.keyCode = 0
                }
                //sender.set_text('');
            }
            function rbtn_ToDate_Onclick() {
                var btn = document.getElementById('<%= btn_Calc.ClientID  %>');
                if (btn != null) {
                    btn.click(); event.keyCode = 0
                }
            }

            function toggleTbl() {
                var tr = document.getElementById('<%= Tr_LeaveBal.ClientID %>');
                var lnk = document.getElementById('<%= LinkButton1.ClientID %>');
                if (tr.style.display == "none") {

                    lnk.innerHTML = "Click here to close balances";
                    tr.style.display = "block";
                }
                else {
                    tr.style.display = "none";

                    lnk.innerHTML = "Click here to view balances";
                }
            }
            /// 20130129 for reduce filter option
            var column = null;
            var columnName = null;
            function MenuShowing(sender, args) {
                if (column == null) return;
                if (columnName == null) return;
                var menu = sender; var items = menu.get_items();
                if (columnName == "BUSINESSUNIT_CODE") {
                    var i = 0;
                    while (i < items.get_count()) {
                        if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'Contains': '', 'StartsWith': '', 'EndsWith': '' })) {
                            var item = items.getItem(i);
                            if (item != null)
                                item.set_visible(false);
                        }
                        else {
                            var item1 = items.getItem(i);
                            if (item1 != null)
                                item1.set_visible(true);
                        } i++;
                    }
                }
                if (columnName == "LEAVEAPP_EMP_ID") {
                    var a = 0;
                    while (a < items.get_count()) {
                        if (!(items.getItem(a).get_value() in { 'NoFilter': '', 'Contains': '', 'StartsWith': '', 'EndsWith': '' })) {
                            var item2 = items.getItem(a);
                            if (item2 != null)
                                item2.set_visible(false);
                        }
                        else {
                            var item21 = items.getItem(a);
                            if (item21 != null)
                                item21.set_visible(true);
                        } a++;
                    }
                } if (columnName == "LEAVEAPP_LEAVETYPE_ID") {
                    var b = 0;
                    while (b < items.get_count()) {
                        if (!(items.getItem(b).get_value() in { 'NoFilter': '', 'Contains': '', 'StartsWith': '', 'EndsWith': '' })) {
                            var item3 = items.getItem(b);
                            if (item3 != null)
                                item3.set_visible(false);
                        }
                        else {
                            var item31 = items.getItem(b);
                            if (item31 != null)
                                item31.set_visible(true);
                        } b++;
                    }
                } if (columnName == "LEAVEAPP_APPLIEDDATE") {
                    var c = 0;
                    while (c < items.get_count()) {
                        if (!(items.getItem(c).get_value() in { 'NoFilter': '', 'Contains': '', 'EqualTo': '', 'NotEqualTo': '', 'GreaterThan': '', 'LessThan': '' })) {
                            var item4 = items.getItem(c);
                            if (item4 != null)
                                item4.set_visible(false);
                        }
                        else {
                            var item41 = items.getItem(c);
                            if (item41 != null)
                                item41.set_visible(true);
                        } c++;
                    }
                }

                if (columnName == "LEAVEAPP_STATUS") {
                    var j = 0;
                    while (j < items.get_count()) {
                        if (!(items.getItem(j).get_value() in { 'NoFilter': '', 'Contains': '', 'StartsWith': '', 'EndsWith': '' })) {
                            var itemElse = items.getItem(j);
                            if (itemElse != null)
                                itemElse.set_visible(false);
                        }
                        else {
                            var itemElse1 = items.getItem(j);
                            if (itemElse1 != null)
                                itemElse1.set_visible(true);
                        } j++;
                    }
                }

                column = null;
                columnName = null;


            }
            ///vch 20130129
            function filterMenuShowing(sender, eventArgs) {
                column = eventArgs.get_column();
                columnName = eventArgs.get_column().get_uniqueName();
            }
        </script>

    </telerik:RadScriptBlock>
    <asp:UpdatePanel ID="UPDPanel" runat="server">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_LeaveAppHeader" runat="server" Text="Leave Application" Font-Bold="True"
                            meta:resourcekey="lbl_LeaveAppHeader"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_LA_page" runat="server" SelectedIndex="0" Height="690px"
                            Width="990px" meta:resourcekey="Rm_LA_page">
                            <telerik:RadPageView ID="Rp_LA_ViewMain" runat="server" meta:resourcekey="Rp_LA_ViewMain"
                                Selected="True">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_LeaveApp" AllowPaging="true" runat="server" AutoGenerateColumns="False"
                                                AllowFilteringByColumn="True" AllowSorting="true" GridLines="None" Skin="WebBlue"
                                                OnNeedDataSource="Rg_LeaveApp_NeedDataSource" meta:resourcekey="Rg_LeaveApp">
                                                <MasterTableView CommandItemDisplay="Top" PageSize="10">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="LEAVEAPP_ID" UniqueName="LEAVEAPP_ID" HeaderText="ID"
                                                            meta:resourcekey="LEAVEAPP_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID"
                                                            HeaderText="BID" meta:resourcekey="BUSINESSUNIT_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                            HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE" AllowFiltering="true">
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
                                                        <telerik:GridBoundColumn DataField="LEAVEAPP_STATUS" UniqueName="LEAVEAPP_STATUS"
                                                            HeaderText="Status" meta:resourcekey="LEAVEAPP_STATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Employee Grade"
                                                            AllowFiltering="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LEAVEAPP_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit" Text="Edit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit_1" runat="server" CommandArgument='<%# Eval("LEAVEAPP_ID") %>'
                                                                    OnCommand="lnk_Edit_1_Command" meta:resourcekey="lnk_Edit_1" Text="Leave&nbsp;Cancel"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" Text="Apply Leave"
                                                                Font-Bold="true"></asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
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
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_LA_ViewDetails" runat="server" meta:resourcekey="Rp_LA_ViewDetails">
                                <table align="center">
                                    <tr>
                                        <td colspan="3" align="center" style="font-weight: bold;">
                                            <asp:Label ID="lbl_LeaveAppDetails" runat="server" Text="Leave Details" meta:resourcekey="lbl_LeaveAppDetails"></asp:Label>
                                        </td>
                                        <td align="center" style="font-weight: bold;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                                Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                                ErrorMessage="Please Select Business Unit" InitialValue="Select" meta:resourcekey="rcmb_BusinessUnit"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppID" runat="server" Visible="False" meta:resourcekey="lbl_LeaveAppID"></asp:Label>
                                            <asp:Label ID="lbl_LeaveAppEmpName" runat="server" Text="Employee&nbsp;Name" meta:resourcekey="lbl_LeaveAppEmpName"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_LeaveAppEmployeeID" runat="server" MaxHeight="120px" Filter="Contains"
                                                MarkFirstMatch="true" AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="rcmb_LeaveAppEmployeeID_SelectedIndexChanged"
                                                meta:resourcekey="rcmb_LeaveAppEmployeeID">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_LeaveAppEmployeeID" runat="server" ControlToValidate="rcmb_LeaveAppEmployeeID"
                                                InitialValue="Select" ErrorMessage="Please Select Employee Name" Text="*" ValidationGroup="Controls"
                                                meta:resourcekey="rfv_rcmb_LeaveAppEmployeeID"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppLType" runat="server" Text="Leave Type" meta:resourcekey="lbl_LeaveAppLType"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_LeaveAppLType" runat="server" MarkFirstMatch="true" MaxHeight="250"
                                                Skin="WebBlue" meta:resourcekey="rcmb_LeaveAppLType" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_LeaveAppLType" runat="server" ControlToValidate="rcmb_LeaveAppLType"
                                                InitialValue="Select" ErrorMessage="Please Select Leave Type" Text="*" ValidationGroup="Controls"
                                                meta:resourcekey="rfv_rcmb_LeaveAppLType"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCalPrd" runat="server" Text="Calendar Period"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbCalPrd" runat="server" MarkFirstMatch="true" MaxHeight="250" Filter="Contains"
                                                Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="rcbCalPrd_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvCalPrd" runat="server" ControlToValidate="rcbCalPrd" Text="*"
                                                InitialValue="Select" ErrorMessage="Please Select Calendar Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trEmpLeaveBal" visible="false">
                                        <td>
                                            <asp:Label ID="lblLeaveBal" runat="server" Text="Leave Balance"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblEmpLeaveBal" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr id="trIncident" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_IncidentLeave" runat="server" Text="Incident" meta:resourcekey="lbl_IncidentLeave"></asp:Label>
                                        </td>
                                        <td><b>:</b></td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_IncidentLeave" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_IncidentLeave_SelectedIndexChanged"
                                                meta:resourcekey="rcmb_IncidentLeave">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trIncidentLink" runat="server" visible="false">
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="lnk_IncidentDtls" runat="server" OnClientClick="ShowPopup();"
                                                OnClick="lnk_IncidentDtls_Click">Click to View Employee Incident Details</asp:LinkButton>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppAppliedDate" runat="server" meta:resourcekey="lbl_LeaveAppAppliedDate"
                                                Text="Applied Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_LeaveAppAppliedDate" runat="server" Skin="WebBlue"
                                                Enabled="false">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_LeaveAppAppliedDate" runat="server" ControlToValidate="rdtp_LeaveAppAppliedDate"
                                                ErrorMessage="Please Select Applied Date" Text="*" ValidationGroup="Controls"
                                                meta:resourcekey="rfv_rdtp_LeaveAppAppliedDate"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppFromDate" runat="server" meta:resourcekey="lbl_LeaveAppFromDate"
                                                Text="From Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_LeaveAppFromDate" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" AutoPostBack="true" OnSelectedDateChanged="rdtp_LeaveAppFromDate_SelectedDateChanged">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_LeaveAppFromDate" runat="server" ControlToValidate="rdtp_LeaveAppFromDate"
                                                ErrorMessage="Please Select From Date" meta:resourcekey="rfv_rdtp_LeaveAppFromDate"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbtn_FromDate" runat="server" meta:resourcekey="rbtn_FromDate" AutoPostBack="true"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtn_ToDate_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="1">Half Day</asp:ListItem>
                                                <asp:ListItem Value="0">Full Day</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppToDate" runat="server" meta:resourcekey="lbl_LeaveAppToDate"
                                                Text="To Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_LeaveAppToDate" runat="server" Skin="WebBlue"
                                                meta:resourcekey="rdtp_LeaveAppToDate" AutoPostBack="true"
                                                Enabled="true" OnSelectedDateChanged="rdtp_LeaveAppToDate_SelectedDateChanged">
                                                <ClientEvents OnDateSelected="OnDateSelected" />
                                            </telerik:RadDatePicker>
                                            <div style="display: none;">
                                                <asp:Button ID="btn_Calc" runat="server" meta:resourcekey="btn_Calc"
                                                    Text="Get Days" ValidationGroup="Controls" /><%-- OnClick="btn_Calc_Click"--%>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_LeaveAppToDate" runat="server" ControlToValidate="rdtp_LeaveAppToDate"
                                                ErrorMessage="Please Select To Date" meta:resourcekey="rfv_rdtp_LeaveAppToDate"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="rcv_rdtp_LeaveAppToDate" runat="server" ControlToCompare="rdtp_LeaveAppFromDate"
                                                ControlToValidate="rdtp_LeaveAppToDate" ErrorMessage="From Date Should be Less Than To Date."
                                                meta:resourcekey="rcv_rdtp_LeaveAppToDate" Operator="GreaterThanEqual" Text="*"
                                                ValidationGroup="Controls"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbtn_ToDate" runat="server" meta:resourcekey="rbtn_ToDate" AutoPostBack="true"
                                                RepeatDirection="Horizontal" ValidationGroup="Controls" OnSelectedIndexChanged="rbtn_ToDate_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Half Day</asp:ListItem>
                                                <asp:ListItem Value="0">Full Day</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <%-- <asp:RequiredFieldValidator ID="rfv_rtxt_LeaveAppNoofDays" runat="server" ControlToValidate="rtxt_LeaveAppNoofDays"
                                        ErrorMessage="No of Days Cannot be Empty" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rtxt_LeaveAppNoofDays"></asp:RequiredFieldValidator>--%>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppNoofDays" runat="server" meta:resourcekey="lbl_LeaveAppNoofDays"
                                                Text="No of Days"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_LeaveAppNoofDays" runat="server" Skin="WebBlue"
                                                meta:resourcekey="rtxt_LeaveAppNoofDays" ReadOnly="true">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_LeaveAppReason" runat="server" ControlToValidate="rtxt_LeaveAppReason"
                                        ErrorMessage="Reason Cannot be Empty" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_LeaveAppReason"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LeaveAppReason" runat="server" meta:resourcekey="lbl_LeaveAppReason"
                                                Text="Reason"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_LeaveAppReason" runat="server" Skin="WebBlue" MaxLength="100"
                                                meta:resourcekey="rtxt_LeaveAppReason" TextMode="MultiLine">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Document"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FUpload_Doc" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:LinkButton ID="lnk_Download" runat="server" Visible="False">Click Here to View</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btn_LeaveCancel" runat="server" meta:resourcekey="btn_LeaveCancel"
                                                OnClick="btn_LeaveCancel_Click" Text="Leave Cancellation" ValidationGroup="Controls"
                                                Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                Text="Update" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                Text="Save" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_LeaveApp" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:LinkButton ID="lnk_Cal" runat="server" OnClick="lnk_Cal_Click" Visible="false">Leave Calendar</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <caption runat="server" id="captionBal" style="display: none">
                                        <tr>
                                            <td></td>
                                            <td>&nbsp; </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClientClick="javascript:toggleTbl();return false;"
                                                    Text="Click to View the Balance"></asp:LinkButton>
                                                <%--OnClick="LinkButton1_Click"--%></td>
                                            <td>&nbsp; </td>
                                        </tr>
                                    </caption>
                                </table>
                                <table align="center" style="display: none;" visible="true">
                                    <tr id="Tr_LeaveBal" runat="server" style="display: none;">
                                        <td colspan="3">
                                            <table align="center">
                                                <tr>
                                                    <td align="center">
                                                        <b>Leave Balance </b>
                                                        <table id="tbl_Leavebalance" runat="server" align="center">
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Update" />
            <asp:PostBackTrigger ControlID="btn_Save" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>