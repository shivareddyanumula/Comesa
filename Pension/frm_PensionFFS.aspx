<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_PensionFFS.aspx.cs" Inherits="Pension_frm_PensionFFS" %>

<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_PensionFFS" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_PensionFFS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkWithdrawlEdit">
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
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Directorate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Department">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
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
                <asp:Label ID="lblHeading" runat="server" Text="Part, Full and Final Settlement" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <%--<td align="center">--%>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table align="center" width="85%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_PensionFFS" runat="server" Skin="WebBlue" GridLines="None"
                                                AutoGenerateColumns="False" OnNeedDataSource="RG_PensionFFS_NeedDataSource" AllowPaging="True"
                                                AllowFilteringByColumn="True" AllowSorting="True">
                                                <GroupingSettings CaseSensitive="False" />
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="WITHDRAWL_ID" HeaderText="ID"
                                                            meta:resourcekey="WITHDRAWL_ID" UniqueName="WITHDRAWL_ID"
                                                            Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name"
                                                            meta:resourcekey="EMP_NAME" UniqueName="EMP_NAME">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridDateTimeColumn DataField="WITHDRAWL_SETTLEMENTDATE" HeaderText="Settlement Date"
                                                            meta:resourcekey="WITHDRAWL_SETTLEMENTDATE" UniqueName="WITHDRAWL_SETTLEMENTDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                        </telerik:GridDateTimeColumn>
                                                        <telerik:GridBoundColumn DataField="SETTLEMENT_TYPE" HeaderText="Settlement Type"
                                                            meta:resourcekey="SETTLEMENT_TYPE" UniqueName="SETTLEMENT_TYPE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WITHDRAWL_PAYITEM" HeaderText="PayItem Name"
                                                            meta:resourcekey="WITHDRAWL_PAYITEM" UniqueName="WITHDRAWL_PAYITEM">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="WITHDRAWL_WITHDRAWLAMOUNT" HeaderText="Withdrawal Amount"
                                                            meta:resourcekey="WITHDRAWL_WITHDRAWLAMOUNT" UniqueName="WITHDRAWL_WITHDRAWLAMOUNT" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridNumericColumn DataField="WITHDRAWL_BALANCE" HeaderText="Balance" UniqueName="WITHDRAWL_BALANCE" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False"
                                                            meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkWithdrawlEdit" runat="server"
                                                                    CommandArgument='<%# Eval("WITHDRAWL_ID") %>'
                                                                    OnCommand="lnkWithdrawlEdit_Command" CausesValidation="false">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                            InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" CausesValidation="false"
                                                                OnClick="lnk_Add_Click"> Add</asp:LinkButton>
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
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center">
                                    <tr>
                                        <td colspan="3" align="center">
                                            <%--<asp:Label ID="lblHeading" runat="server" Text="Part, Full and Final Settlement" Font-Bold="true"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" Text="*" InitialValue="Select" ErrorMessage="Please Select Business Unit" runat="server"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDirectorate" runat="server" Text="Directorate"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" Height="100" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" CausesValidation="false" MarkFirstMatch="true" Height="100" EnableVirtualScrolling="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                                            <asp:HiddenField ID="hdnFFSID" runat="server" />
                                            <asp:HiddenField ID="hdnIsPartialPaymnt" runat="server" />
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" InitialValue="Select" Text="*" ValidationGroup="Controls" ControlToValidate="rcmb_Employee" ErrorMessage="Please Select Employee"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px">
                                            <asp:Label ID="lblTotPensionAmt" runat="server" Text="Total Provident Fund Amount"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_TotPensionAmt" runat="server" Type="Number" MinValue="0" ReadOnly="true"></telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAmtDisbursed" runat="server" Text="Amount Disbursed"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_AmtDisbursed" runat="server" MinValue="0" Type="Number" ReadOnly="true"></telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBalAmt" runat="server" Text="Balance Amount"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_BalAmt" runat="server" Type="Number" MinValue="0" ReadOnly="true"></telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_WithdrawlType" runat="server" Text="Withdrawal Type"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_WithdrawlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_WithdrawlType_SelectedIndexChanged" EmptyMessage="Select">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Self" Value="Self" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Family" Value="Family" />

                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_WithdrawlType" runat="server" ControlToValidate="rcmb_WithdrawlType" Text="*" ErrorMessage="Please Select Withdrawal Type" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>


                                    <tr id="trRelation" runat="server">
                                        <td>
                                            <asp:Label ID="lblRelation" runat="server" Text="Relation"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Relation" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Relation_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Relation" runat="server" Text="*" ErrorMessage="Please Select Relation" ControlToValidate="rcmb_Relation" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trBeneficiary" runat="server">
                                        <td>
                                            <asp:Label ID="lblBeneficiary" runat="server" Text="Beneficiary Name"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_Beneficiary" runat="server" ReadOnly="true"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSettlementType" runat="server" Text="Settlement Type"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_SettlementType" runat="server" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr id="trPayItem" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lblPayItem" runat="server" Text="Pay Item"></asp:Label>
                                        </td>
                                        <td>;</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_PayItem" runat="server" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAmount" runat="server" Text="Withdrawal Amount"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Amount" Type="Number" NumberFormat-DecimalDigits="2" MinValue="0" runat="server"></telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSettlementDate" runat="server" Text="Settlement Date"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtpSettlementDate" runat="server"></telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <br />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Controls" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnSave" />
                                <%--<asp:PostBackTrigger ControlID="btnUpdate" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:ValidationSummary ID="vs_summary" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>