<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_AddQuarters.aspx.cs" Inherits="Pension_frm_AddQuarters" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenfitClaim" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenfitClaim">
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
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_scheme" runat="server" Text="Quarters" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_InteretsQuarters" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_InteretsQuarters_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="QRTR_ID" UniqueName="QRTR_ID"
                                                            HeaderText="ID" meta:resourcekey="QRTR_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME"
                                                            HeaderText="Period Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="QRTR_NOOFQRTRS" UniqueName="QRTR_NOOFQRTRS" HeaderText="No Of Quarters"
                                                            meta:resourcekey="QRTR_NOOFQRTRS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1"
                                                            AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("QRTR_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
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
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="60%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFinPeriod" runat="server" Text="Financial Period"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="radFinPeriod" runat="server" AutoPostBack="true" OnSelectedIndexChanged="radFinPeriod_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                            <asp:HiddenField ID="hdnStartDate" runat="server" />
                                            <asp:HiddenField ID="hdnEndDate" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*"
                                                ControlToValidate="radFinPeriod" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNoOfQuarters" runat="server" Text="No Of Quarters"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="radQuarters" runat="server" AutoPostBack="true" OnSelectedIndexChanged="radQuarters_SelectedIndexChanged">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Select" Value="0" />
                                                    <telerik:RadComboBoxItem Text="1" Value="1" />
                                                    <telerik:RadComboBoxItem Text="2" Value="2" />
                                                    <telerik:RadComboBoxItem Text="3" Value="3" />
                                                    <telerik:RadComboBoxItem Text="4" Value="4" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                ControlToValidate="radFinPeriod" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <telerik:RadGrid ID="Rg_Quarters" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" AllowFilteringByColumn="false" Skin="WebBlue"
                                                Visible="false">
                                                <MasterTableView CommandItemDisplay="None">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="QUARTER_ID" UniqueName="QUARTER_ID" HeaderText="QUARTER_ID"
                                                            meta:resourcekey="QUARTER_ID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="QUARTER_NAME" UniqueName="QUARTER_NAME" AllowFiltering="false"
                                                            HeaderText="Quarter Name" meta:resourcekey="QUARTER_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColStartDate" HeaderText="Start Date"
                                                            meta:resourcekey="ColToIssuedDate" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadDatePicker ID="rdpStartDate" MinDate='<%#Eval("QUARTER_SDATE") %>' SelectedDate='<%#   Convert.IsDBNull(Eval("QUARTER_SSDATE")) ? null : Eval("QUARTER_SSDATE") %>' runat="server" MaxDate='<%# Eval("QUARTER_EDATE") %>'>
                                                                    <DateInput MinDate='<%#Eval("QUARTER_SDATE") %>' ID="dateinput1" runat="server" MaxDate='<%# Eval("QUARTER_EDATE") %>'>
                                                                    </DateInput>
                                                                </telerik:RadDatePicker>
                                                                <asp:RequiredFieldValidator ID="rfv_dob" runat="server" ControlToValidate="rdpStartDate"
                                                                    Text="*" ValidationGroup="Controls" ErrorMessage="Please select Date"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEndDate" HeaderText="End Date"
                                                            meta:resourcekey="ColToIssuedDate" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadDatePicker ID="rdpEndDate" MinDate='<%# Eval("QUARTER_SDATE") %>' SelectedDate='<%#  Convert.IsDBNull(Eval("QUARTER_SEDATE")) ? null : Eval("QUARTER_SEDATE") %>' runat="server" MaxDate='<%# Eval("QUARTER_EDATE") %>'>
                                                                    <DateInput MinDate='<%#Eval("QUARTER_SDATE") %>' ID="dateinput2" runat="server" MaxDate='<%# Eval("QUARTER_EDATE") %>'>
                                                                    </DateInput>
                                                                </telerik:RadDatePicker>
                                                                <asp:RequiredFieldValidator ID="rfv_dob1" runat="server" ControlToValidate="rdpEndDate"
                                                                    Text="*" ValidationGroup="Controls" ErrorMessage="Please select Date"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>

                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                                <asp:PostBackTrigger ControlID="btn_Update" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>