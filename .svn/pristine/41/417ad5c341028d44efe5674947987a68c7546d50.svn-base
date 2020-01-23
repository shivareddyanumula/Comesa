<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_HolidayCalendar.aspx.cs" Inherits="Masters_frm_HolidayCalendar"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="cnt_HolidayCalendar" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_HOLIDAYCALENDAR" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_HolidayCalendar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_HolidayCalendarHeader" runat="server" Text="Holiday Calendar"
                    Font-Bold="True" meta:resourcekey="lbl_HolidayCalendarHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_HolidayCalendar_page" runat="server" SelectedIndex="0"
                    Style="z-index: 10" Width="990px" Height="490px"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_HolidayCalendar_ViewMain" runat="server" Selected="True">

                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_HolidayCalendar" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" OnNeedDataSource="Rg_HolidayCalendar_NeedDataSource" AllowPaging="True"
                                        Skin="WebBlue" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="HOLMST_ID" UniqueName="HOLMST_ID" HeaderText="ID"
                                                    meta:resourcekey="CATEGORY_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="HOLMST_BUSINESSUNITCODE" UniqueName="HOLMST_BUSINESSUNITCODE" HeaderText="Business Unit"
                                                    meta:resourcekey="HOLMST_BUSINESSUNITCODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="HOLMST_CODE" UniqueName="HOLMST_CODE" HeaderText="Code"
                                                    meta:resourcekey="HOLMST_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HOLMST_DESCRIPTION" UniqueName="HOLMST_DESCRIPTION"
                                                    HeaderText="Description" meta:resourcekey="HOLMST_DESCRIPTION" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HOLMST_DATE" UniqueName="HOLMST_DATE" HeaderText="Date"
                                                    meta:resourcekey="HOLMST_DATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("HOLMST_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColDelete" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("HOLMST_ID") %>'
                                                            OnCommand="lnk_Delete_Command">Delete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_HolidayCalendar_ViewDetails" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_CategoryDetails" runat="server" Text="Details" meta:resourcekey="lbl_CategoryDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_HCID" runat="server" meta:resourcekey="lbl_HCInfo" Text="lbl_HCID"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                        HighlightTemplatedItems="True" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        ErrorMessage="Please select a Business Unit" InitialValue="Select" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_HCCode" runat="server" meta:resourcekey="lbl_HCCode" Text="Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_HCCode" runat="server" Skin="WebBlue" LabelCssClass="" MaxLength="100" TabIndex="1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_HCCode" runat="server" ControlToValidate="rtxt_HCCode"
                                        ErrorMessage="Code is Mandatory" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_HCCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_HCDesc" runat="server" meta:resourcekey="lbl_HCDesc" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_HCDesc" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="2">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_HOLMST_DATE" runat="server" meta:resourcekey="lbl_HOLMST_DATE"
                                        Text=" Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_HCDATE" runat="server" Skin="WebBlue" TabIndex="3">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_HCDATE" runat="server" ControlToValidate="rdtp_HCDATE"
                                        ErrorMessage="Please select a valid Date" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_HCDATE">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Edit" runat="server" Text="Update" Visible="False" ValidationGroup="Controls" TabIndex="4"
                                        meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="False" ValidationGroup="Controls" TabIndex="4"
                                        meta:resourcekey="btn_Save" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" meta:resourcekey="btn_Cancel" TabIndex="5"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_HolidayCalendar" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Controls" ShowSummary="False" meta:resourcekey="vs_HolidayCalendar" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>