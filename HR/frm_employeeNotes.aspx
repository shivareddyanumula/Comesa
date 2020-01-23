<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_employeeNotes.aspx.cs" Inherits="HR_frm_employeeNotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_EmpNotes" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_NotesRec">
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
            <telerik:AjaxSetting AjaxControlID="rcmb_DisactRecEmpID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_NotesRecHeader" runat="server" Font-Bold="True" meta:resourcekey="lbl_NotesRecHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="70%">
                <telerik:RadMultiPage ID="Rm_NR_page" runat="server" SelectedIndex="0" Height="490px"
                    ScrollBars="Auto" Width="100%">
                    <telerik:RadPageView ID="Rp_NR_ViewMain" runat="server">
                        <table align="center" width="70%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_NotesRec" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_NotesRec_NeedDataSource" AllowPaging="true"
                                        AllowSorting="true" AllowFilteringByColumn="True">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMPNOTES_ID" meta:resourcekey="EMPNOTES_ID" UniqueName="EMPNOTES_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUNIT" HeaderStyle-HorizontalAlign="Center" meta:resourcekey="EMPNOTES_BUNIT"
                                                    UniqueName="BUNIT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNOTES_EMPID" HeaderStyle-HorizontalAlign="Center"
                                                    meta:resourcekey="EMPNOTES_EMPID" UniqueName="EMPNOTES_EMPID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNOTES_RPTMNGID" HeaderStyle-HorizontalAlign="Center"
                                                    meta:resourcekey="EMPNOTES_RPTMNGID" UniqueName="EMPNOTES_RPTMNGID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNOTES_DATE" HeaderStyle-HorizontalAlign="Center"
                                                    meta:resourcekey="EMPNOTES_DATE" UniqueName="EMPNOTES_DATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNOTES_REMARKS" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center"
                                                    meta:resourcekey="EMPNOTES_REMARKS" UniqueName="EMPNOTES_REMARKS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPNOTES_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <PagerStyle AlwaysVisible="true" />
                                        </MasterTableView>
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_NR_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_NotesRecDetails" runat="server" meta:resourcekey="lbl_NotesRecDetails"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_BusinessUnit" Skin="WebBlue" MarkFirstMatch="true" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_BU" runat="server" ControlToValidate="ddl_BusinessUnit"
                                        InitialValue="Select" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NotesRecID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_NotesRecEmployee" runat="server" meta:resourcekey="lbl_NotesRecEmployee"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_NotesRecEmpID" Skin="WebBlue" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_NotesRecEmpID_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_NotesRecEmpID" runat="server" ControlToValidate="rcmb_NotesRecEmpID"
                                        InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_NotesRecEmpID">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_NotesRecDOJ" runat="server" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NotesRecManager" runat="server" meta:resourcekey="lbl_NotesRecManager"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_NotesRecManagerID" runat="server" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_NotesRecManagerID" runat="server" ControlToValidate="rcmb_NotesRecManagerID"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_NotesRecManagerID" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NotesRecRemarks" runat="server" meta:resourcekey="lbl_NotesRecRemarks"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_NotesRecRemarks" runat="server" MaxLength="100" Rows="3"
                                        TextMode="MultiLine" Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_NotesRecRemarks" runat="server" ControlToValidate="rtxt_NotesRecRemarks"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_NotesRecRemarks">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NotesRecReason" runat="server" meta:resourcekey="lbl_NotesRecReason"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_NotesRecReason" runat="server" MaxLength="5000" Rows="4"
                                        TextMode="MultiLine" Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_NotesRecReason" runat="server" ControlToValidate="rtxt_NotesRecReason"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_NotesRecReason">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_NotesRecDate" runat="server" meta:resourcekey="lbl_NotesRecDate"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_NotesRecDate" runat="server" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_NotesRecDate" runat="server" ControlToValidate="rdtp_NotesRecDate"
                                        ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_NotesRecDate">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="rcv_rdtp_NotesRecDate" runat="server" ControlToCompare="rdtp_NotesRecDOJ"
                                        ControlToValidate="rdtp_NotesRecDate" Operator="GreaterThanEqual" Type="Date"
                                        ErrorMessage="Recording Date cannot be less than Date of Join" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                    ValidationGroup="Controls" Visible="False" /><asp:Button ID="btn_Save" runat="server"
                                                        meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                        Visible="False" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ValidationSummary ID="vs_NotesRec" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
