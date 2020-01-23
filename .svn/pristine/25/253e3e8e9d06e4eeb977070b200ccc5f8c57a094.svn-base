<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_comoffrequest.aspx.cs" Inherits="Payroll_frm_comoffrequest" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_COMPOFFDetails" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_CmpOffDet">
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
            <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_CmpOffEmployeeID">
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
                <asp:Label ID="lbl_COMPOFFDetHeader" runat="server" Text="ALL COMPENSATORY OFF DETAILS"
                    Font-Bold="True" meta:resourcekey="lbl_COMPOFFDetHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CMPOFF_page" runat="server" SelectedIndex="0" Width="990px"
                    Height="490px" meta:resourcekey="Rm_CMPOFF_page">
                    <telerik:RadPageView ID="Rp_CMPOFF_ViewMain" runat="server" meta:resourcekey="Rp_CMPOFF_ViewMain"
                        Selected="True">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_CmpOffDet" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Width="800px" Skin="WebBlue" OnNeedDataSource="Rg_CmpOffDet_NeedDataSource" meta:resourcekey="Rg_CmpOffDet"
                                        AllowPaging="True" AllowFilteringByColumn="true">
                                        <ClientSettings>
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMPCOMPOFF_ID" UniqueName="EMPCOMPOFF_ID" HeaderText="ID"
                                                    meta:resourcekey="EMPCOMPOFF_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEE" UniqueName="EMPLOYEE" HeaderText="Employee Name"
                                                    meta:resourcekey="EMPLOYEE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPCOMPOFF_WORKDAY" UniqueName="EMPCOMPOFF_WORKDAY"
                                                    HeaderText="Work Day" meta:resourcekey="EMPCOMPOFF_WORKDAY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="EMPCOMPOFF_COMPOFFDAY" UniqueName="EMPCOMPOFF_COMPOFFDAY"
                                                    HeaderText="Compoff Day" meta:resourcekey="EMPCOMPOFF_COMPOFFDAY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="EMPCOMPOFF_REASON" UniqueName="EMPCOMPOFF_REASON"
                                                    HeaderText="Reason" meta:resourcekey="EMPCOMPOFF_REASON">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COMPOFF_STATUS" UniqueName="COMPOFF_STATUS" HeaderText="Status"
                                                    meta:resourcekey="COMPOFF_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="APPROVED_BY" UniqueName="APPROVED_BY" HeaderText="Approved&nbsp;By"
                                                    meta:resourcekey="APPROVED_BY">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false" meta:resourcekey="GridTemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%# Eval("EMPCOMPOFF_ID") %>'
                                                            meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add </asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CMPOFF_ViewDetails" runat="server" meta:resourcekey="Rp_CMPOFF_ViewDetails">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_ComOffDetails" runat="server" Text="Apply for a Compensatory Off"
                                        meta:resourcekey="lbl_ComOffDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CmpDetID" runat="server" Visible="False" meta:resourcekey="lbl_CmpDetID"></asp:Label>
                                    <asp:Label ID="lbl_ComOffDetBU" runat="server" Text="Business Unit" meta:resourcekey="lbl_ComOffDetBU"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" Skin="WebBlue" Filter="Contains"
                                        MarkFirstMatch="true" meta:resourcekey="rcmb_BusinessUnit" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        ErrorMessage="Please Select Business Unit" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnit"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee" Text="Employee"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CmpOffEmployeeID" runat="server" AutoPostBack="True" Filter="Contains"
                                        MaxHeight="120px" MarkFirstMatch="true" Skin="WebBlue" meta:resourcekey="rcmb_CmpOffEmployeeID">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_CmpOffEmployeeID"
                                        ErrorMessage="Please Select Employee" InitialValue="Select" meta:resourcekey="rfv_rcmb_CmpOffEmployeeID"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Compoff" runat="server" Text="Leave Type"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Compoff" runat="server" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Compoff" runat="server" ControlToValidate="rcmb_Compoff"
                                        ErrorMessage="Please Select Leave Type" ValidationGroup="Controls" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AppDate" runat="server" meta:resourcekey="lbl_AppDate"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_AppDate" runat="server" Skin="WebBlue" meta:resourcekey="rdp_AppDate">
                                        <Calendar runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="false" UseRowHeadersAsSelectors="false"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" Skin="WebBlue" LabelCssClass="" Width="">
                                        </DateInput>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdp_AppDate" runat="server" ControlToValidate="rdtp_Dateofwork"
                                        ErrorMessage="Please Specify Apply Date" meta:resourcekey="rfv_rdp_AppDate"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_WorkDay" runat="server" meta:resourcekey="lbl_WorkDay" Text="Work Day"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_Dateofwork" runat="server" Culture="English (United States)"
                                        AutoPostBack="true" Skin="WebBlue" meta:resourcekey="rdtp_Dateofwork" OnSelectedDateChanged="rdtp_Dateofwork_SelectedDateChanged">
                                        <Calendar runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" Skin="WebBlue" LabelCssClass="" Width="">
                                        </DateInput>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_Dateofwork" runat="server" ControlToValidate="rdtp_Dateofwork"
                                        ErrorMessage="Please Specify Work Day" meta:resourcekey="rfv_rdtp_Dateofwork"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_compoffday" runat="server" meta:resourcekey="lbl_compoffday" Text="Compoff Day"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_compoffday" runat="server" Culture="English (United States)"
                                        Skin="WebBlue" meta:resourcekey="rdtp_Dateofwork">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput Skin="WebBlue" LabelCssClass="" Width="">
                                        </DateInput>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_compoffday" runat="server" ControlToValidate="rdtp_compoffday"
                                        ErrorMessage="Please Specify Compoff Day " InitialValue="Select" meta:resourcekey="rfv_rdtp_compoffday"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NDays" runat="server" meta:resourcekey="lbl_NDays" Text="No. of Days"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_NDays" runat="server" Enabled="False" EnableEmbeddedSkins="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <%--</tr>--%>
                            <%--</tr __designer:mapid="25f"> </tr __designer:mapid="3cc">--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LoginTime" runat="server" meta:resourcekey="lbl_LoginTime"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_LoginTime" runat="server">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_LoginTime" runat="server" ControlToValidate="rtp_LoginTime"
                                        ErrorMessage="Please Specify Login Time" ValidationGroup="Controls" meta:resourcekey="rfv_rtp_LoginTime">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--</tr __designer:mapid="3cd">--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LogOutTime" runat="server" meta:resourcekey="lbl_LogOutTime"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_LogoutTime" runat="server">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtp_LogOutTime" runat="server" ControlToValidate="rtp_LogOutTime"
                                        ErrorMessage="Please Specify Logout Time" meta:resourcekey="rfv_rtp_LogOutTime"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CmpOffreason" runat="server" meta:resourcekey="lbl_CmpOffreason"
                                        Text="Reason"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Reason" runat="server" MaxLength="500" Skin="WebBlue"
                                        TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Reason" runat="server" ControlToValidate="rtxt_Reason"
                                        ErrorMessage="Please Select Reason" meta:resourcekey="rfv_rtxt_Reason" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_OTDet" runat="server" meta:resourcekey="vs_OTDet" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Controls" />
</asp:Content>