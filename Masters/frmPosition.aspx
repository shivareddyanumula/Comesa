<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPosition.aspx.cs" MasterPageFile="~/SMHRMaster.master" Inherits="Masters_frmPosition" %>

<asp:Content ID="cnt_Position" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Positions" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Positions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rm_page" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadWindowManager ID="RWM_POSITIONPOSTREPLY" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PositionsHeader" runat="server" Text="Position" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_PO_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto" meta:resourcekey="Rm_PO_page">
                    <telerik:RadPageView ID="Rp_PO_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="Upnl_Grid" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadAjaxPanel ID="RAP_Jobs" runat="server" Width="100%" LoadingPanelID="RLP_Applicant">
                                                <table align="center">
                                                    <tr>
                                                        <td align="center">
                                                            <telerik:RadGrid ID="Rg_Positions" runat="server" AutoGenerateColumns="False"
                                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Positions_NeedDataSource"
                                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                                <HeaderContextMenu Skin="WebBlue">
                                                                </HeaderContextMenu>
                                                                <PagerStyle AlwaysVisible="true" />
                                                                <MasterTableView CommandItemDisplay="Top">
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_ID" HeaderText="ID" meta:resourcekey="POSITIONS_ID"
                                                                            UniqueName="POSITIONS_ID" Visible="False">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Name" meta:resourcekey="POSITIONS_CODE"
                                                                            UniqueName="POSITIONS_CODE" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_DESC" HeaderText="Desc" meta:resourcekey="POSITIONS_DESC"
                                                                            UniqueName="POSITIONS_DESC" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="POSITIONS_STATUS" HeaderText="Status" meta:resourcekey="POSITIONS_STATUS"
                                                                            UniqueName="POSITIONS_STATUS" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit"
                                                                            AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("POSITIONS_ID") %>'
                                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                    <EditFormSettings>
                                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                                            UpdateImageUrl="Update.gif">
                                                                        </EditColumn>
                                                                    </EditFormSettings>
                                                                    <CommandItemTemplate>
                                                                        <div align="right">
                                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                                        </div>
                                                                    </CommandItemTemplate>
                                                                </MasterTableView>
                                                                <FilterMenu Skin="WebBlue">
                                                                </FilterMenu>
                                                                <GroupingSettings CaseSensitive="false" />
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table align="center" style="display: none">
                                                                <tr>
                                                                    <td colspan="7"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="7" align="center">
                                                                        <asp:Label ID="lbl_PositionInfo" runat="server" Text="Import Position Details"
                                                                            Style="font-weight: 700"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_Position" runat="server" Text="Position Details"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <a href="~/Masters/Importsheets/Position Template.xlsx" runat="server" id="Position">Download Position Template</a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_Import" runat="server" Text="Browse Your Data"></asp:Label>
                                                                    </td>
                                                                    <td><b>:</b></td>
                                                                    <td>
                                                                        <asp:FileUpload ID="fupld_Position" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btn_Import" runat="server" Text="Import"
                                                                            OnClick="btn_Import_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadAjaxPanel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_Import" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_PO_ViewDetails" runat="server" meta:resourcekey="Rp_PO_ViewDetails">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsID" runat="server" Visible="False" meta:resourcekey="lbl_PositionsID"></asp:Label>
                                    <asp:Label ID="lbl_PositionsCode" runat="server" Text="Name" meta:resourcekey="lbl_PositionsCode"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_PositionsCode" runat="server"
                                        Skin="WebBlue" MaxLength="80">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_PositionsCode" runat="server" ControlToValidate="rtxt_PositionsCode"
                                        ErrorMessage="Name cannot be Empty" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_PositionsCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsDesc" runat="server" Text="Description" meta:resourcekey="lbl_PositionsDesc"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_PositionsDesc" runat="server"
                                        Skin="WebBlue" MaxLength="80">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsJobs" runat="server" meta:resourcekey="lbl_PositionsJobs"
                                        Text="Jobs"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PositionsJobs" runat="server" MarkFirstMatch="true"
                                        Skin="WebBlue" OnSelectedIndexChanged="rcmb_PositionsJobs_SelectedIndexChanged"
                                        AutoPostBack="True" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PositionsJobs" runat="server" ControlToValidate="rcmb_PositionsJobs"
                                        ErrorMessage="Please select a Job" ValidationGroup="Controls" InitialValue="Select"
                                        meta:resourcekey="rfv_rcmb_PositionsJobs">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsStartDate1" runat="server" meta:resourcekey="lbl_PositionsStartDate"
                                        Text="Jobs&nbsp;Start&nbsp;Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="lbl_PositionsStartDate0" runat="server"
                                        Enabled="False" Skin="WebBlue">
                                        <Calendar Skin="WebBlue" runat="server"
                                            UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton CssClass="rcCalPopup rcDisabled" HoverImageUrl=""
                                            ImageUrl="" />
                                        <DateInput DateFormat="dd-MM-yyyy" DisplayDateFormat="dd-MM-yyyy"
                                            runat="server">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsEndDate1" runat="server" meta:resourcekey="lbl_PositionsEndDate"
                                        Text="Jobs&nbsp;End&nbsp;Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="lbl_PositionsEndDate0" runat="server"
                                        Enabled="False" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsStatus" runat="server" Text="Status" meta:resourcekey="lbl_PositionsStatus"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PositionsStatus" runat="server" MarkFirstMatch="true"
                                        Skin="WebBlue">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Active" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="InActive" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PositionsStatus" runat="server" ControlToValidate="rcmb_PositionsStatus"
                                        ErrorMessage="Please select the Status" InitialValue="Select" meta:resourcekey="rfv_rcmb_PositionsStatus"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsStartDate" runat="server" meta:resourcekey="lbl_PositionsStartDate"
                                        Text="Start Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_PositionsStartDate" runat="server"
                                        Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_PositionsStartDate" runat="server" ControlToValidate="rdtp_PositionsStartDate"
                                        ErrorMessage="Start date cannot be Empty" meta:resourcekey="rfv_rdtp_PositionsStartDate"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="rcv_rdtp_PositionsStartDate" runat="server" ControlToCompare="lbl_PositionsStartDate0"
                                        ControlToValidate="rdtp_PositionsStartDate" ErrorMessage="Position Start Date Cannot be Less than Jobs Start Date"
                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PositionsEndDate" runat="server" meta:resourcekey="lbl_PositionsEndDate"
                                        Text="End Date"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_PositionsEndDate" runat="server"
                                        Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="rcv_rdtp_PositionsEndDate" runat="server" ControlToCompare="rdtp_PositionsStartDate"
                                        ControlToValidate="rdtp_PositionsEndDate" ErrorMessage="EndDate Cannot be less than StartDate"
                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="rcv_rdtp_PositionsEndDate0" runat="server" ControlToCompare="lbl_PositionsEndDate0"
                                        ControlToValidate="rdtp_PositionsEndDate" ErrorMessage="Position End Date Cannot be Less than Jobs End Date"
                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Positions" runat="server" meta:resourcekey="vs_Positions"
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