<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="MedicalBenifits.aspx.cs" Inherits="Medical_MedicalBenifits" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Cnt_MedicalBenifit" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <br />
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenifit" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenifit">
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
                <asp:Label ID="lbl_MedicalBenifitHeader" runat="server" Text="Medical Benefits" Font-Bold="True"></asp:Label>
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
                                            <telerik:RadGrid ID="Rg_MedicalBenifit" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_MedicalBenifit_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <%--<telerik:GridBoundColumn DataField="EXPENDITURE_ID" UniqueName="EXPENDITURE_ID" HeaderText="ID"
                                                            meta:resourcekey="EXPENDITURE_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EXPENDITURE_NAME" UniqueName="EXPENDITURE_NAME" HeaderText="Expenditure Name"
                                                            meta:resourcekey="EXPENDITURE_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EXPENDITURE_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>--%>
                                                        <telerik:GridBoundColumn DataField="PERIOD_ID" UniqueName="PERIOD_ID" HeaderText="ID"
                                                            meta:resourcekey="PERIOD_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERIOD_NAME" UniqueName="PERIOD_NAME" HeaderText="Financial Period Name"
                                                            meta:resourcekey="PERIOD_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PERIOD_ID") %>'
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
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr id="trExpend" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_ExpenditureID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_ExpenditureName" runat="server" Text="Expenditure Name" meta:resourcekey="lbl_ExpenditureName"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_ExpenditureName" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="rad_ExpenditureName_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*" InitialValue="Select"
                                        ControlToValidate="rad_ExpenditureName" ValidationGroup="Controls" Display="Dynamic" ErrorMessage="Please Select Expenditure"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trFinPeriod" runat="server">
                                <td>
                                    <asp:Label ID="lblFinPeriod" runat="server" Text="Financial Period" meta:resourcekey="lblFinPeriod"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="radFinPeriod" runat="server" Skin="WebBlue" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="radFinPeriod_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" InitialValue="Select"
                                        ControlToValidate="radFinPeriod" ValidationGroup="Controls" Display="Dynamic"
                                        ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="3">
                                    <asp:HiddenField ID="hdnIsfuture" runat="server" />
                                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" Skin="WebBlue" Visible="false">
                                        <MasterTableView TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="EMPLOYEEGRADE_ID" HeaderText="ID" Visible="false" meta:resourcekey="EMPLOYEEGRADE_ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_EMPLOYEEGRADE_ID" runat="server" Text='<%# Eval("EMPLOYEEGRADE_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Scale Name" meta:resourcekey="EMPLOYEEGRADE_CODE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_EMPLOYEEGRADE_CODE" runat="server" Text='<%# Eval("EMPLOYEEGRADE_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="MEDICALBENFIT_MAXAMOUNT" HeaderText="Max Eligible Amount" meta:resourcekey="MEDICALBENFIT_MAXAMOUNT">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txt_MEDICALBENFIT_MAXAMOUNT" runat="server" MinValue="0"
                                                            Enabled='<%# Convert.ToBoolean(Eval("MEDICAL_ADDED")) %>' MaxLength="7"
                                                            Text='<%# Eval("MEDICALBENFIT_MAXAMOUNT") %>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true" />
                                                        <asp:Label ID="lblHeaderText" runat="server" Text="Apply All"></asp:Label>
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                                <%--<td>
                                    <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true" Visible="false" Text="Check All" />
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
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