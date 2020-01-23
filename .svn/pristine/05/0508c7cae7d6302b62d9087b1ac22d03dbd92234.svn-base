<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_LoanDeposits.aspx.cs" Inherits="Payroll_frm_LoanDeposits" %>

<%--<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>--%>
<script runat="server">

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Master" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Master">
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
    <telerik:RadWindowManager ID="RWM_MASTERS" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="lbl_LoanDepHeader" runat="server" Font-Bold="true" Text="Loan Boosting"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_LoanDep_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_LoanDep_MainPage" runat="server" Selected="True">

                        <table align="center" width="80%">
                            <tr>

                                <td>

                                    <telerik:RadGrid ID="Rg_Loandeposits" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_Loandeposits_NeedDataSource" PageSize="5" Skin="WebBlue"
                                        ClientSettings-Scrolling-UseStaticHeaders="false">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <%--  <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" HeaderText="BID"
                                                    UniqueName="BUSINESSUNIT_ID" Visible="False">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DepositsId" HeaderText="ID"
                                                    UniqueName="DepositsId" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="Employee Name"
                                                    UniqueName="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LoanNo" HeaderText="Loan No"
                                                    UniqueName="LoanNo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="payitem_payitemname"
                                                    HeaderText="Type of Loan"
                                                    UniqueName="payitem_payitemname">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="DepositAmount" FilterControlWidth="100px"
                                                    HeaderText="Boosting Amount"
                                                    UniqueName="DepositAmount">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="UpdatedLoanAmt" FilterControlWidth="100px"
                                                    HeaderText="Updated Loan Balance"
                                                    UniqueName="UpdatedLoanAmt">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server"
                                                            CommandArgument='<%# Eval("DepositsId") %>' meta:resourcekey="lnk_View"
                                                            OnCommand="lnk_View_Command" Text="View"></asp:LinkButton>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                            </Columns>
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
                        </table>
                    </telerik:RadPageView>

                    <telerik:RadPageView ID="RPV_Loans" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Skin="WebBlue" Enabled="false">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server"
                                        ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Select a Business Unit"
                                        InitialValue="Select" meta:resourcekey="rcmb_BusinessUnit" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LoanDetEmpName" runat="server"
                                        meta:resourcekey="lbl_LoanDetEmpName" Text="Employee&nbsp;Name"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EmployeeName" runat="server" MarkFirstMatch="true" Enabled="false"
                                        Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server"
                                        ControlToValidate="rcmb_EmployeeName" ErrorMessage="Select a Employee"
                                        InitialValue="Select" meta:resourcekey="rfv_rcmb_Employee" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_loantype" runat="server" Text="Loan Type"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_loantype" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_loantype_SelectedIndexChanged"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_loantype" runat="server"
                                        ControlToValidate="rcmb_loantype" ErrorMessage="Select  Loan Type "
                                        meta:resourcekey="rfv_rcmb_loantype" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_loanno" runat="server" Text="Loan No"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_loanno" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_loanno_SelectedIndexChanged"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_loanno" runat="server"
                                        ControlToValidate="rcmb_loanno" ErrorMessage="Select Loan No "
                                        meta:resourcekey="rfv_rcmb_loantype" Text="*" ValidationGroup="Controls"
                                        InitialValue="Select"></asp:RequiredFieldValidator></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AccumulativeBalance" runat="server" Text="Accumulative Balance"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rad_AccumulativeBalance" runat="server"
                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount"
                                        MinValue="0" Skin="WebBlue" Enabled="false">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="rtxt_Amount" ErrorMessage="Amount cannot be empty"
                                                             Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BoostingAmount" runat="server" Text="Boosting Amount"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxt_Amount" runat="server"
                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" AutoPostBack="true" OnTextChanged="rtxt_Amount_TextChanged"
                                        MinValue="0" Skin="WebBlue">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Amount" runat="server"
                                        ControlToValidate="rtxt_Amount" ErrorMessage="Boosting Amount cannot be empty"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_boostdate" runat="server" Text="Loan Boost Date" Enabled="false"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdpt_boostdate" runat="server"
                                        Culture="English (United States)" Skin="WebBlue" Width="135px">
                                    </telerik:RadDatePicker>

                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="rdpt_boostdate" ErrorMessage="Please give Issue Date"
                                                            meta:resourcekey="rfv_rdtp_IssueDate" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UpdatedLoanBalance" runat="server" Text="Updated Loan Balance"></asp:Label></td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rad_UpdatedLoanBalance" runat="server"
                                        Culture="English (United States)" MaxLength="13" Enabled="false"
                                        MinValue="0" Skin="WebBlue">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="rad_UpdatedLoanBalance" ErrorMessage="Please Click on Apply Link Button"
                                                             Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />&nbsp;
                                               <asp:LinkButton ID="lnk_Apply" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Apply_Command">Apply</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vg_Master" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>