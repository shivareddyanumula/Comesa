<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_OTDetails.aspx.cs" Inherits="Payroll_frm_OTDetails" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_OTDetails" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_OTDet">
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
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_OTDetEmployeeID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_OTDetPeriodMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_OTDetPeriodDetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_OTDetHeader" runat="server" Text="OT Details" Font-Bold="True"
                    meta:resourcekey="lbl_OTDetHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_OT_page" runat="server" SelectedIndex="0"
                    Width="990px" Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_OT_page">
                    <telerik:RadPageView ID="Rp_OT_ViewMain" runat="server" meta:resourcekey="Rp_OT_ViewMain"
                        Selected="True">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_OTDet" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_OTDet_NeedDataSource" meta:resourcekey="Rg_OTDet"
                                        AllowPaging="True" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_ID" UniqueName="EMPOTTRANS_ID" HeaderText="ID"
                                                    meta:resourcekey="EMPOTTRANS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID" HeaderText="BID"
                                                    meta:resourcekey="BUSINESSUNIT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_EMPID" UniqueName="EMPOTTRANS_EMPID"
                                                    HeaderText="Employee Name" meta:resourcekey="EMPOTTRANS_EMPID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_TYPEID" UniqueName="EMPOTTRANS_TYPEID"
                                                    HeaderText="Leave Type" meta:resourcekey="EMPOTTRANS_TYPEID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_HOURS" UniqueName="EMPOTTRANS_HOURS"
                                                    HeaderText="No of Hours" meta:resourcekey="EMPOTTRANS_HOURS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_DATE" UniqueName="EMPOTTRANS_DATE"
                                                    HeaderText="Date of OT" meta:resourcekey="EMPOTTRANS_DATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPOTTRANS_STATUS" UniqueName="EMPOTTRANS_STATUS"
                                                    HeaderText="Status" meta:resourcekey="EMPOTTRANS_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPOTTRANS_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_OT_ViewDetails" runat="server" meta:resourcekey="Rp_OT_ViewDetails">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_OTDetDetails" runat="server" meta:resourcekey="lbl_OTDetDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetBusinessUnit" runat="server"
                                        meta:resourcekey="lbl_OTDetBusinessUnit" Text="Business Unit"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server"
                                        AutoPostBack="True" Skin="WebBlue"
                                        MarkFirstMatch="true" Filter="Contains"
                                        meta:resourcekey="rcmb_BusinessUnit"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetBusinessUnit" runat="server"
                                        ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Select a Business Unit"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_OTDetBusinessUnit" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetID" runat="server" meta:resourcekey="lbl_OTDetID"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_OTDetEmpName" runat="server"
                                        meta:resourcekey="lbl_OTDetEmpName" Text="Employee&nbsp;Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_OTDetEmployeeID" runat="server"
                                        AutoPostBack="True" Skin="WebBlue"
                                        MarkFirstMatch="true" Filter="Contains"
                                        meta:resourcekey="rcmb_OTDetEmployeeID"
                                        OnSelectedIndexChanged="rcmb_OTDetEmployeeID_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_EmpJoinDate" runat="server"
                                        meta:resourcekey="lbl_EmpJoinDate" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetOTType" runat="server" meta:resourcekey="lbl_OTDetOTType"
                                        Text="OT Type"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_OTDetOTType" runat="server" Skin="WebBlue"
                                        MarkFirstMatch="true" Filter="Contains" meta:resourcekey="rcmb_OTDetOTType">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetOTType" runat="server" ControlToValidate="rcmb_OTDetOTType"
                                        ErrorMessage="Select a OT Type" InitialValue="Select" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_OTDetOTType"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetPeriodMain" runat="server" meta:resourcekey="lbl_OTDetPeriodMain"
                                        Text="Period"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_OTDetPeriodMain" runat="server" Skin="WebBlue"
                                        meta:resourcekey="rcmb_OTDetPeriodMain" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_OTDetPeriodMain_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetPeriodMain" runat="server" ControlToValidate="rcmb_OTDetPeriodMain"
                                        ErrorMessage="Select a Main Period " Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_OTDetPeriodMain" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetPeriodDetails" runat="server" meta:resourcekey="lbl_OTDetLType"
                                        Text="Period Details"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_OTDetPeriodDetails" runat="server"
                                        Skin="WebBlue" meta:resourcekey="rcmb_OTDetPeriodDetails"
                                        AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_OTDetPeriodDetails_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_OTDetPeriodDetails" runat="server" ControlToValidate="rcmb_OTDetPeriodDetails"
                                        ErrorMessage="Select a Period Detail" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_OTDetPeriodDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetOTDate" runat="server" meta:resourcekey="lbl_OTDetOTDate"
                                        Text="OT Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_OTDetOTDate" runat="server"
                                        Culture="English (United States)" Skin="WebBlue"
                                        meta:resourcekey="rdtp_OTDetOTDate"
                                        OnSelectedDateChanged="rdtp_OTDetOTDate_SelectedDateChanged">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput Skin="WebBlue" LabelCssClass="" Width="">
                                        </DateInput>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_OTDetOTDate" runat="server" ControlToValidate="rdtp_OTDetOTDate"
                                        ErrorMessage="OT Date cannot be Empty" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rdtp_OTDetOTDate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_OTDetOTHours" runat="server"
                                        meta:resourcekey="lbl_OTDetOTHours" Text="No of Hours"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxt_OTDetOTHours" runat="server"
                                        Culture="English (United States)" Skin="WebBlue" LabelCssClass=""
                                        meta:resourcekey="rtxt_OTDetOTHours">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_OTDetOTHours" runat="server"
                                        ControlToValidate="rtxt_OTDetOTHours"
                                        ErrorMessage="No of Hours Cannot be Empty"
                                        meta:resourcekey="rfv_rtxt_OTDetOTHours" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit"
                                        OnClick="btn_Save_Click" Text="Update" ValidationGroup="Controls"
                                        Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save"
                                        OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls"
                                        Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel"
                                        OnClick="btn_Cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_OTDet" runat="server" meta:resourcekey="vs_OTDet"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>