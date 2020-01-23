<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_emploantran.aspx.cs" Inherits="Payroll_frm_emploantran" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_LoanDetails" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Loandet">
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
            <telerik:AjaxSetting AjaxControlID="btn_process">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Calculate1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit_1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtn_EMIDATA">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_PayType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function openRadWin(str) {
                var win = window.radopen(str, "RW_EMICALENDER");
                win.center();
                win.set_height("400");
                win.set_width("600");
            }
        </script>
    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_LoanDetHeader" runat="server" Font-Bold="true" Text="Loan/Advances"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Loan_page" runat="server" SelectedIndex="0" Width="980px">
                    <telerik:RadPageView ID="Rp_Loan_ViewMain" runat="server" meta:resourcekey="Rp_Loan_ViewMain"
                        Selected="True">

                        <table align="center" width="80%">
                            <tr>

                                <td>

                                    <telerik:RadGrid ID="Rg_Loandet" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="None"
                                        OnNeedDataSource="Rg_Loandet_NeedDataSource" PageSize="10" Skin="WebBlue" ClientSettings-Scrolling-AllowScroll="true"
                                        ClientSettings-Scrolling-UseStaticHeaders="true" Width="900px" Height="355px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" HeaderText="BID"
                                                    meta:resourcekey="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_ID" HeaderText="ID"
                                                    meta:resourcekey="LOANTRANS_ID" UniqueName="LOANTRANS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="Employee Name"
                                                    meta:resourcekey="EMPNAME" UniqueName="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_LOANNO" HeaderText="Loan No"
                                                    meta:resourcekey="LOANTRANS_LOANNO" UniqueName="LOANTRANS_LOANNO">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_EMP_ID" HeaderText="EmployeeID"
                                                    meta:resourcekey="LOANTRANS_EMP_ID" UniqueName="LOANTRANS_EMP_ID"
                                                    Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="payitem_payitemname"
                                                    HeaderText="Type of Loan"
                                                    UniqueName="payitem_payitemname">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_PROCESS_TYPE"
                                                    HeaderText="Loan Process Type"
                                                    UniqueName="LOANTRANS_PROCESS_TYPE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="Amount" FilterControlWidth="100px"
                                                    HeaderText="Actual Loan Amount" meta:resourcekey="EMPLOANTRAN_AMOUNT"
                                                    UniqueName="Amount">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="LOANTRANS_LOANAMOUNT" FilterControlWidth="100px"
                                                    HeaderText="Loan Amount" meta:resourcekey="EMPLOANTRAN_AMOUNT"
                                                    UniqueName="Loan Amount">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_ISSUEDATE"
                                                    HeaderText="Loan Issued Date" meta:resourcekey="LOANTRANS_ISSUEDATE"
                                                    UniqueName="LOANTRANS_ISSUEDATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRAN_STATUS"
                                                    HeaderText="Loan Status" meta:resourcekey="LOANTRAN_STATUS"
                                                    UniqueName="LOANTRAN_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server"
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' meta:resourcekey="lnk_Edit"
                                                            OnCommand="lnk_Edit_Command" Text="Edit/View"></asp:LinkButton>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridTemplateColumn AllowFiltering="false" 
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColSanction">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Sanction" runat="server" 
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' meta:resourcekey="lnk_Sanction" 
                                                            OnCommand="lnk_Sanction_Command" Text="Sanction Loan"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="false"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColEdit_1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit_1" runat="server" Visible='<%# Convert.ToBoolean(Eval("STATUSENABLED")) %>'
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' meta:resourcekey="lnk_Edit_1"
                                                            OnCommand="lnk_Edit_1_Command" Text="Postpone"></asp:LinkButton>
                                                        <%--  <asp:LinkButton ID="lnk_Edit_1" runat="server" Visible='<%# Convert.ToBoolean(Eval("IsLoanCompleted")) %>'
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' meta:resourcekey="lnk_Edit_1"
                                                            OnCommand="lnk_Edit_1_Command" Text="Postpone"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Reschedule" runat="server" Visble='<%# Convert.ToBoolean(Eval("IsLoanCompleted")) %>'
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' Enabled='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("LOANTRANS_LOANINSTALL"))) %>'
                                                            OnCommand="lnk_Reschedule_Command" Text="Reschedule"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_PreClosure" runat="server" Visible='<%# Convert.ToBoolean(Eval("IsLoanCompleted")) %>'
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' OnCommand="lnk_PreClosure_Command" Text="Pre-Closure"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_PreClosOrWithdrawl" runat="server" CommandArgument='<%# Eval("LOANTRANS_ID") %>'
                                                            OnCommand="lnk_PreClosOrWithdrawl_Command" Text="Pre-Closure/Withdrawal" Enabled='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("LOANTRANS_LOANINSTALL"))) %>'
                                                            Visble='<%# !Convert.ToBoolean(Eval("IsLoanClosed")) %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkUpdateRefID" runat="server" CommandArgument='<%# Eval("LOANTRANS_ID") %>'
                                                             OnCommand="lnkUpdateRefID_Command" Text="Update-RefId">
                                                        </asp:LinkButton>--%>
                                                <%-- Enabled='<%# !Convert.ToBoolean(Eval("IsLoanClosed")) %>'--%>
                                                <%--</ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <PagerStyle AlwaysVisible="True" />
                                            <CommandItemTemplate>
                                                <div align="right">
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_loan_ViewDetails" runat="server" meta:resourcekey="Rp_loan_ViewDetails">
                        <%--<telerik:RadPageView ID="Rp_loan_ViewDetails" runat="server" meta:resourcekey="Rp_loan_ViewDetails">--%>
                        <table>
                            <tr>
                                <td>

                                    <telerik:RadTabStrip ID="rd_LOANTRANS" runat="server" Align="Center"
                                        MultiPageID="RMP_LoanDet" SelectedIndex="0" Skin="WebBlue" Width="570px">
                                        <Tabs>
                                            <telerik:RadTab runat="server" PageViewID="RPV_Loans" Text="Loan"
                                                Visible="False">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_RPTReschedule"
                                                Text="Rescheduling" Visible="false">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_RPTDetails" Text="Repayment"
                                                Visible="false">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_Reschedule" Text="Reschedule" Visible="false"></telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_PreClosure" Text="PreClosure" Visible="false"></telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_PreClosOrWithdrawl" Text="PreClosureOrWithdrawal" Visible="false"></telerik:RadTab>
                                            <telerik:RadTab runat="server" PageViewID="RPV_UpdRefId" Text="UpdateReferenceId" Visible="false"></telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                </td>

                            </tr>

                            <tr>
                                <td>

                                    <telerik:RadMultiPage ID="RMP_LoanDet" runat="server" SelectedIndex="0"
                                        Width="1004px">
                                        <telerik:RadPageView ID="RPV_Loans" runat="server">
                                            <table align="center" width="40%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lbl_LoanDetDetails" runat="server"></asp:Label></td>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_loantrans_ID" runat="server" Visible="False" meta:resourcekey="lbl_loantrans_ID"></asp:Label>
                                                        <asp:Label ID="lbl_BusinessUnit" runat="server"
                                                            meta:resourcekey="lbl_BusinessUnit"></asp:Label></td>
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
                                                        <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true" Enabled="false"
                                                            Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains"
                                                            OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server"
                                                            ControlToValidate="rcmb_Employee" ErrorMessage="Select a Employee"
                                                            InitialValue="Select" meta:resourcekey="rfv_rcmb_Employee" Text="*"
                                                            ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_loanno" runat="server" meta:resourcekey="lbl_loanno"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_loanno" runat="server"
                                                            Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                            EmptyMessage="Auto Generated Code" ReadOnly="True" Width="125px">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_loantype" runat="server" meta:resourcekey="lbl_loantype"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_loantype" runat="server" MarkFirstMatch="true"
                                                            meta:resourcekey="rcmb_loantype" Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_loantype" runat="server"
                                                            ControlToValidate="rcmb_loantype" ErrorMessage="Select a Main Period "
                                                            meta:resourcekey="rfv_rcmb_loantype" Text="*" ValidationGroup="Controls"
                                                            InitialValue="Select"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Loan Process Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcbLoanPrcsType" runat="server" MarkFirstMatch="true"
                                                            Skin="WebBlue" Enabled="false">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Value="Reducing Balance" Text="Reducing Balance" />
                                                                <telerik:RadComboBoxItem Value="Increasing Balance" Text="Increasing Balance" />
                                                                <telerik:RadComboBoxItem Value="Standard" Text="Standard" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <asp:HiddenField ID="hdn_LoanProcessType" runat="server" />
                                                <asp:HiddenField ID="hdn_IsLoanSanctioned" runat="server" />
                                                <asp:HiddenField ID="hfLoanProcessType" runat="server" />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_IssueDate" runat="server"
                                                            meta:resourcekey="lbl_IssueDate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_IssueDate" runat="server"
                                                            Culture="English (United States)" meta:resourcekey="rdtp_IssueDate" Enabled="false"
                                                            Skin="WebBlue" Width="135px">
                                                        </telerik:RadDatePicker>
                                                        <asp:Label ID="lblissue" runat="server" meta:resourcekey="lblissue"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_IssueDate" runat="server"
                                                            ControlToValidate="rdtp_IssueDate" ErrorMessage="Please give Issue Date"
                                                            meta:resourcekey="rfv_rdtp_IssueDate" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Amount" runat="server" meta:resourcekey="lbl_Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_Amount" runat="server"
                                                            Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount"
                                                            MinValue="0" Skin="WebBlue" AutoPostBack="true" OnTextChanged="rtxt_Amount_TextChanged">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_Amount" runat="server"
                                                            ControlToValidate="rtxt_Amount" ErrorMessage="Amount cannot be empty"
                                                            meta:resourcekey="rfv_rtxt_Amount" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIR" runat="server" Text="Interest Rate (%)"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rntbIR" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="13"
                                                            MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_InterestAmt" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12" Value="0" Visible="false"
                                                            meta:resourcekey="rtxt_InterestAmt" MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_installments" runat="server"
                                                            meta:resourcekey="lbl_installments"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_installments" runat="server"
                                                            Culture="English (United States)" MaxLength="12"
                                                            meta:resourcekey="rtxt_installments" Skin="WebBlue" AutoPostBack="true" OnTextChanged="rtxt_installments_TextChanged">
                                                            <NumberFormat AllowRounding="false" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_installments" runat="server"
                                                            ControlToValidate="rtxt_installments" ErrorMessage="No of installments"
                                                            meta:resourcekey="rfv_rtxt_installments" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="lbl_interestAmt" runat="server"
                                                            meta:resourcekey="lbl_interestAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_InterestAmt" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12"
                                                            meta:resourcekey="rtxt_InterestAmt" MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                        %
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_InterestAmt" runat="server"
                                                            ControlToValidate="rtxt_InterestAmt"
                                                            ErrorMessage="Please enter Interest Amount"
                                                            meta:resourcekey="rfv_rtxt_InterestAmt" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_MonthlyEMI" runat="server" meta:resourcekey="lbl_MonthlyEMI"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_MonthlyEMI" runat="server" Enabled="false"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkbtn_EMIDATA" runat="server"
                                                            meta:resourcekey="lnkbtn_EMIDATA" OnClientClick="return false" Visible="False">EMI Calendar</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_PayMode" runat="server" meta:resourcekey="lbl_PayMode"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>

                                                        <telerik:RadComboBox ID="ddl_PayMode" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" OnSelectedIndexChanged="ddl_PayMode_SelectedIndexChanged"
                                                            Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>

                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RFV_PayMode" runat="server"
                                                            ControlToValidate="ddl_PayMode" ErrorMessage="Please Choose Payment Mode"
                                                            meta:resourcekey="RFV_PayMode" Text="*" InitialValue="Select"
                                                            ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr id="cheque" runat="server">
                                                    <td>
                                                        <asp:Label ID="lbl_Cheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="txt_ChequeNumber" runat="server"
                                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RFV_Cheque" runat="server"
                                                            ControlToValidate="txt_ChequeNumber" ErrorMessage="Enter Cheque Number"
                                                            meta:resourcekey="RFV_Cheque" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_effectiveDate" runat="server"
                                                            meta:resourcekey="lbl_effectiveDate"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_EffectiveDate" runat="server" AutoPostBack="true"
                                                            Culture="English (United States)" meta:resourcekey="rdtp_EffectiveDate"
                                                            Skin="WebBlue">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_EffectiveDate" runat="server"
                                                            ControlToValidate="rdtp_EffectiveDate"
                                                            ErrorMessage="Please Enter Effective Date"
                                                            meta:resourcekey="rfv_rdtp_EffectiveDate" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="ctl_rdtp_EffectiveDate" runat="server"
                                                            ControlToCompare="rdtp_IssueDate" ControlToValidate="rdtp_EffectiveDate"
                                                            ErrorMessage="Effective Date cannot be less than Issue date"
                                                            Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator></td>
                                                    <td>
                                                        <asp:Button ID="btn_Calculate" runat="server" meta:resourcekey="btn_Calculate"
                                                            OnClick="btn_Calculate1_Click" ValidationGroup="Controls" Visible="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_purpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_purpose" runat="server" MaxLength="500"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_purpose" runat="server"
                                                            ControlToValidate="rtxt_purpose" ErrorMessage="Please Enter Purpose"
                                                            meta:resourcekey="rfv_rtxt_purpose" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>

                                                <tr>
                                                    <td align="center" colspan="5">&#160;&#160;&#160;&#160;&#160;&#160;
                                                       <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit"
                                                           Text="Update" OnClick="btn_Save_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')"
                                                           Visible="False" />
                                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" Text="Save"
                                                            OnClick="btn_Save_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')"
                                                            Visible="False" />
                                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel"
                                                            OnClick="btn_Cancel_Click" />
                                                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" Visible="false" OnClick="btn_Delete_Click" OnClientClick="disableButtoneve(this);" UseSubmitBehavior="false" />
                                                        <asp:Button ID="btn_Sanction" runat="server" OnClick="btn_Sanction_Click"
                                                            Text="Sanction" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                                        <asp:ValidationSummary ID="vs_OTDet" runat="server" meta:resourcekey="vs_OTDet"
                                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lbl_LoanDetEmpDOJ" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RPV_RPTDetails" runat="server">
                                            <%--  meta:resourcekey="lbl_LoanDetEmpName"--%>
                                            <table align="center" width="40%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lbl_RPTDETAILS" runat="server" meta:resourcekey="lbl_RPTDETAILS"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_RLOANNO" runat="server" meta:resourcekey="lbl_RLOANNO"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_RloanNo" runat="server" ReadOnly="True"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_RloanTrasnID" runat="server" Skin="WebBlue"
                                                            Visible="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_RLoanBalAmt" runat="server"
                                                            meta:resourcekey="lbl_RLoanBalAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_RLoanBalanceAmt" runat="server" ReadOnly="True"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_RPrincipalBalanceAmt" runat="server"
                                                            ReadOnly="True" Skin="WebBlue" Visible="False">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Ramount" runat="server" meta:resourcekey="lbl_Ramount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_Ramount" runat="server"
                                                            Culture="English (United States)" meta:resourcekey="rtxt_Amount" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_Ramount" runat="server"
                                                            ControlToValidate="rtxt_Ramount" ErrorMessage="Repayment Amount is Mandatory"
                                                            meta:resourcekey="rfv_rtxt_Ramount" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_DateofTrans" runat="server"
                                                            meta:resourcekey="lbl_DateofTrans"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_DateofTRans" runat="server" Skin="WebBlue">
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                                ViewSelectorText="x">
                                                            </Calendar>
                                                            <%--<DatePopupButton HoverImageUrl="" ImageUrl="" />--%>
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_DateofTRans" runat="server"
                                                            ControlToValidate="rdtp_DateofTRans"
                                                            ErrorMessage="Date of Transaction is Mandatory"
                                                            meta:resourcekey="rfv_rdtp_DateofTRans" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_PayType" runat="server" meta:resourcekey="lbl_PayType"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PayType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                            meta:resourcekey="rcmb_PayType"
                                                            OnSelectedIndexChanged="rcmb_PayType_SelectedIndexChanged" Skin="WebBlue">
                                                            <Items>
                                                                <telerik:RadComboBoxItem runat="server" Text="Cash" Value="1" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Cheque" Value="2" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PayType" runat="server"
                                                            ControlToValidate="rcmb_PayType"
                                                            ErrorMessage="Please mention Loan repayment type"
                                                            meta:resourcekey="rfv_rcmb_PayType" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr id="Cheqtr" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lbl_ChequeNo" runat="server" meta:resourcekey="lbl_ChequeNo"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_ChequeNo" runat="server" MaxLength="8"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_ChequeNo" runat="server"
                                                            ControlToValidate="rtxt_ChequeNo" ErrorMessage="No of installments"
                                                            meta:resourcekey="rfv_rtxt_ChequeNo" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr id="banktr" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lbl_bankname" runat="server" meta:resourcekey="lbl_bankname"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_bankname" runat="server" Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr id="branchtr" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lbl_branchname" runat="server" meta:resourcekey="lbl_branchname"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_branchname" runat="server" Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Rinstallments" runat="server"
                                                            meta:resourcekey="lbl_Rinstallments"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_Rinstallments" runat="server"
                                                            meta:resourcekey="rtxt_Rinstallments" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_RInterestRate" runat="server"
                                                            meta:resourcekey="lbl_RInterestRate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_RInterestRate" runat="server"
                                                            Culture="English (United States)"
                                                            Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_RevisedEMI" runat="server" meta:resourcekey="lbl_RevisedEMI"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_RevisedEMI" runat="server"
                                                            Culture="English (United States)" meta:resourcekey="rtxt_RevisedEMI"
                                                            Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Currency" runat="server" meta:resourcekey="lbl_Currency"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_process" runat="server" meta:resourcekey="btn_Process"
                                                            OnClick="btn_process_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls1')" />
                                                        <asp:ValidationSummary ID="VS_Second" runat="server"
                                                            meta:resourcekey="vs_OTDet" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Controls1" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RPV_RPTReschedule" runat="server">
                                            <table align="center" width="40%">
                                                <tr>
                                                    <td>
                                                        <telerik:RadGrid ID="rg_loantrandetails" runat="server" AllowPaging="true"
                                                            AutoGenerateColumns="False" GridLines="None"
                                                            OnNeedDataSource="rg_loantrandetails_NeedDataSource" Skin="WebBlue">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="LOANTRANDTL_ID" HeaderText="LTDID"
                                                                        meta:resourcekey="LOANTRANDTL_ID" UniqueName="LOANTRANDTL_ID" Visible="False">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="LOANTRADTL_LOANTRAN_ID" HeaderText="LTID"
                                                                        meta:resourcekey="LOANTRADTL_LOANTRAN_ID" UniqueName="LOANTRADTL_LOANTRAN_ID"
                                                                        Visible="False">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="DUE_DATE" HeaderText="Due&nbsp;Date"
                                                                        meta:resourcekey="DUE_DATE" UniqueName="DUE_DATE">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIAMOUNT"
                                                                        HeaderText="EMI&nbsp;Amount" meta:resourcekey="LOANTRANDTL_EMIAMOUNT"
                                                                        UniqueName="LOANTRANDTL_EMIAMOUNT">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="REMAINING_PRINCIPAL"
                                                                        HeaderText="Principal&nbsp;Balance" meta:resourcekey="REMAINING_PRINCIPAL"
                                                                        UniqueName="REMAINING_PRINCIPAL">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="REMAINING_LOAN"
                                                                        HeaderText="Loan&nbsp;Balance" meta:resourcekey="REMAINING_LOAN"
                                                                        UniqueName="REMAINING_LOAN">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="LOANTRANDTL_PRINCIPLEAMT"
                                                                        HeaderText="Principal&nbsp;Amount" meta:resourcekey="LOANTRANDTL_PRINCIPLEAMT"
                                                                        UniqueName="LOANTRANDTL_PRINCIPLEAMT">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="EMIS" HeaderText="EMI&nbsp;Count"
                                                                        meta:resourcekey="EMIS" UniqueName="EMIS">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <%--<telerik:GridBoundColumn DataField="LOANTRANDTL_EMISTATUS" UniqueName="LOANTRANDTL_EMISTATUS"
                                                            HeaderText="STATUS" meta:resourcekey="LOANTRANDTL_EMISTATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn HeaderText="STATUS"
                                                                        meta:resourcekey="LOANTRANDTL_EMISTATUS" UniqueName="LOANTRANDTL_EMISTATUS">
                                                                        <ItemTemplate>
                                                                            <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true"
                                                                                SelectedIndex='<%# Convert.ToInt32(Eval("LOANTRANDTL_EMISTATUS")) %>'
                                                                                Skin="WebBlue" Enabled='<%# Convert.ToInt32(Eval("LOANTRANDTL_EMISTATUS")) == 0 ? true : false %>'>
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="Open" Value="0" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Close" Value="1" />
                                                                                    <telerik:RadComboBoxItem runat="server" Text="Postponed" Value="2" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--<telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                </telerik:GridBoundColumn>--%>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btn_RSchedProcess" runat="server" Text="Postpone Process" OnClick="btn_RSchedProcess_Click" OnClientClick=" disableButtoneve(this);" UseSubmitBehavior="false" />
                                                        <asp:Button ID="btn_RSCancel" runat="server"
                                                            Text="Cancel" OnClick="btn_RSCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RPV_Reschedule" runat="server">
                                            <table align="center" width="40%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblReschedule" runat="server"></asp:Label></td>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                                        <asp:Label ID="lblLoanTransID" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_RescheduleBU" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_RescheduleBU" runat="server"
                                                            ControlToValidate="rcmb_RescheduleBU" ErrorMessage="Select a Business Unit"
                                                            InitialValue="Select" meta:resourcekey="rcmb_RescheduleBU" Text="*"
                                                            ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEmployee" runat="server" Text="Employee Name"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_RescheduleEmployee" runat="server" MarkFirstMatch="true" Enabled="false"
                                                            Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_RescheduleEmployee" runat="server"
                                                            ControlToValidate="rcmb_RescheduleEmployee" ErrorMessage="Select a Employee"
                                                            InitialValue="Select" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLoanNo" runat="server" Text="Loan No."></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_LoanNumber" runat="server" Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                            EmptyMessage="Auto Generated Code" ReadOnly="True" Width="125px" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLoanType" runat="server" Text="Loan Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_RescheduleLoanType" runat="server" Enabled="false" MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_RescheduleLoanType" runat="server"
                                                            ControlToValidate="rcmb_RescheduleLoanType" ErrorMessage="Select a Loan Type"
                                                            Text="*" ValidationGroup="RescheduleControls"
                                                            InitialValue="Select"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIssueDate" runat="server"
                                                            meta:resourcekey="lbl_IssueDate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdp_IssueDate" runat="server"
                                                            Culture="English (United States)" meta:resourcekey="rdtp_IssueDate" Enabled="false"
                                                            Skin="WebBlue" Width="135px">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdp_IssueDate" runat="server"
                                                            ControlToValidate="rdp_IssueDate" ErrorMessage="Please give Issue Date"
                                                            meta:resourcekey="rfv_rdtp_IssueDate" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAmount" runat="server" meta:resourcekey="lbl_Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <%--<telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server"
                                                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" 
                                                                        MinValue="0" Skin="WebBlue">
                                                                    </telerik:RadNumericTextBox>--%>
                                                        <telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_LoanAmount" runat="server"
                                                            ControlToValidate="rtxt_LoanAmount" ErrorMessage="Amount cannot be empty"
                                                            meta:resourcekey="rtxt_LoanAmount" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCurrentLoanBal" runat="server" Text="Current Loan Balance"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <%--<telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server"
                                                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" 
                                                                        MinValue="0" Skin="WebBlue">
                                                                    </telerik:RadNumericTextBox>--%>
                                                        <telerik:RadNumericTextBox ID="rtxt_LoanBalance" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_LoanBalance" runat="server"
                                                            ControlToValidate="rtxt_LoanBalance" ErrorMessage="Current Loan Balance cannot be empty"
                                                            Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblInstallments" runat="server"
                                                            meta:resourcekey="lbl_installments"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_InstallmentNo" runat="server"
                                                            Culture="English (United States)" MaxLength="3" AutoPostBack="true"
                                                            Skin="WebBlue" Type="Number" MinValue="1" OnTextChanged="rtxt_InstallmentNo_TextChanged">
                                                            <NumberFormat AllowRounding="false" />
                                                            <NumberFormat DecimalDigits="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_InstallmentNo" runat="server"
                                                            ControlToValidate="rtxt_InstallmentNo" ErrorMessage="No of installments"
                                                            meta:resourcekey="rfv_rtxt_InstallmentNo" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblInterestRate" runat="server"
                                                            meta:resourcekey="lbl_interestAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_InterestRate" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12"
                                                            MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_InterestRate" runat="server"
                                                            ControlToValidate="rtxt_InterestRate"
                                                            ErrorMessage="Please enter Interest Amount"
                                                            meta:resourcekey="rfv_rtxt_InterestAmt" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEMI" runat="server" meta:resourcekey="lbl_MonthlyEMI"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_EMI" runat="server" Enabled="false"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkViewEMI" runat="server" OnClientClick="return false" Visible="False">EMI Calendar</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPayMode" runat="server" meta:resourcekey="lbl_PayMode"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>

                                                        <telerik:RadComboBox ID="rcmb_PaymentMode" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" OnSelectedIndexChanged="ddl_PayMode_SelectedIndexChanged"
                                                            Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>

                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PaymentMode" runat="server"
                                                            ControlToValidate="rcmb_PaymentMode" ErrorMessage="Please Choose Payment Mode"
                                                            Text="*" InitialValue="Select" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr id="trChequeNo" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblCheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_ChequeNumber" runat="server"
                                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" Enabled="false">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_ChequeNumber" runat="server"
                                                            ControlToValidate="rtxt_ChequeNumber" ErrorMessage="Enter Cheque Number"
                                                            Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEffectiveDate" runat="server"
                                                            meta:resourcekey="lbl_effectiveDate"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdp_EffectiveDate" runat="server"
                                                            Culture="English (United States)" meta:resourcekey="rdtp_EffectiveDate" Enabled="false"
                                                            Skin="WebBlue">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdp_EffectiveDate" runat="server"
                                                            ControlToValidate="rdp_EffectiveDate"
                                                            ErrorMessage="Please Enter Effective Date"
                                                            meta:resourcekey="rdp_EffectiveDate" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="rv_rdp_EffectiveDate" runat="server"
                                                            ControlToCompare="rdtp_IssueDate" ControlToValidate="rdtp_EffectiveDate"
                                                            ErrorMessage="Effective Date cannot be less than Issue date"
                                                            Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="RescheduleControls"></asp:CompareValidator></td>
                                                    <td>
                                                        <asp:Button ID="btnRescheduleCal" runat="server" meta:resourcekey="btn_Calculate"
                                                            OnClick="btnRescheduleCal_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'RescheduleControls')" Visible="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPurpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_ReschedulePurpose" runat="server" MaxLength="500"
                                                            Skin="WebBlue" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_ReschedulePurpose" runat="server"
                                                            ControlToValidate="rtxt_ReschedulePurpose" ErrorMessage="Please Enter Purpose"
                                                            Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>

                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <asp:Button ID="btnReschedule" runat="server" Text="Reschedule" OnClick="btnReschedule_Click" Visible="true" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'RescheduleControls')" />
                                                        <asp:Button ID="btnCancelRescehdule" runat="server" Text="Cancel" OnClick="btnCancelRescehdule_Click" Visible="true" />
                                                        <asp:ValidationSummary ID="vs_RescheduleControls" runat="server" meta:resourcekey="vs_OTDet"
                                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="RescheduleControls" />


                                                        <%--to store maxeligible amounts--%>
                                                        <asp:Label ID="lblLoanEligibleAmount" runat="server" Visible="false"></asp:Label>
                                                        <asp:HiddenField ID="hdnMinTenureMonths" runat="server" />
                                                        <asp:HiddenField ID="hdnMaxTenureMonths" runat="server" />
                                                        <asp:HiddenField ID="hdnMaxeligibleMonthsforEmp" runat="server" />
                                                        <asp:HiddenField ID="hdnClosedEMICount" runat="server" />
                                                        <%--to store maxeligible amounts--%>


                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>

                                        <telerik:RadPageView ID="RPV_PreClosOrWithdrawl" runat="server">
                                            <table align="center" width="55%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblPreClosOrWithdrawl" runat="server" Text="Loan Pre-Closure/Withdrawal" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlBU" runat="server" Text="Business Unit"></asp:Label>
                                                        <asp:Label ID="lblPreClosOrWithdrawlTransID" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblPreClosOrWithdrawlEMINo" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosOrWithdrawlBU" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosOrWithdrawl" runat="server"
                                                            ControlToValidate="rcmb_PreClosOrWithdrawlBU" ErrorMessage="Select a Business Unit"
                                                            InitialValue="Select" Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlEmp" runat="server" Text="Employee Name"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosOrWithdrawlEmp" runat="server" MarkFirstMatch="true" Enabled="false"
                                                            Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosOrWithdrawlEmp" runat="server"
                                                            ControlToValidate="rcmb_PreClosOrWithdrawlEmp" ErrorMessage="Select a Employee"
                                                            InitialValue="Select" Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlLoanNo" runat="server" Text="Loan No."></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_PreClosOrWithdrawlLoanNo" runat="server" Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                            EmptyMessage="Auto Generated Code" ReadOnly="True" Width="125px" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlProcessType" runat="server" Text="Loan Process Type"></asp:Label>
                                                    </td>

                                                    <td>:</td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PrClosWithdrwlLoanProcessType" runat="server" Enabled="false">
                                                            <Items>
                                                                <%-- <telerik:RadComboBoxItem Value="0" Text="Reducing Balance" Visible="false" />
                                                                <telerik:RadComboBoxItem Value="1" Text="Increasing Balance" Visible="false" />--%>
                                                                <telerik:RadComboBoxItem Value="0" Text="Standard" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlLoanType" runat="server" Text="Loan Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosOrWithdrawlLoanType" runat="server" Enabled="false" MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosOrWithdrawlLoanType" runat="server"
                                                            ControlToValidate="rcmb_PreClosOrWithdrawlLoanType" ErrorMessage="Select a Loan Type"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"
                                                            InitialValue="Select"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <asp:HiddenField ID="hdn_PreClosOrWithdrawl_LoanProcessType" runat="server" Visible="false" />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlIssueDate" runat="server"
                                                            meta:resourcekey="lbl_IssueDate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_PreClosOrWithdrawlIssueDate" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue" Width="135px">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_PreClosOrWithdrawlIssueDate" runat="server"
                                                            ControlToValidate="rdtp_PreClosOrWithdrawlIssueDate" ErrorMessage="Please give Issue Date"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlAvailableBal" runat="server" Text="Loan Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrawlLoanAmt" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="PreClosOrWithdrawlControls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosOrWithdrawlLoanAmt" runat="server"
                                                            ControlToValidate="rtxt_PreClosOrWithdrawlLoanAmt" ErrorMessage="Amount cannot be empty"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlCurrLoanBal" runat="server" Text="Current Loan Balance"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <%--<telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server"
                                                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" 
                                                                        MinValue="0" Skin="WebBlue">
                                                                    </telerik:RadNumericTextBox>--%>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosWithdrwlLoanBalance" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="rtxt_LoanBalance" ErrorMessage="Current Loan Balance cannot be empty"
                                                            Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlType" runat="server" Text="Withdrawal Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>

                                                        <asp:RadioButtonList ID="rbtnPreClosOrWithdrawlType" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" AutoPostBack="true" OnSelectedIndexChanged="rbtnPreClosOrWithdrawlType_SelectedIndexChanged">
                                                            <asp:ListItem Text="Partial Payment" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Complete Payment" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>

                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr id="trWithdrawalAmt" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrawlAmt" runat="server" Text="Withdrawal Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrawlLoanBalance" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="PreClosOrWithdrawlControls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosOrWithdrawlLoanBalance" runat="server"
                                                            ControlToValidate="rtxt_PreClosOrWithdrawlLoanBalance" ErrorMessage="Withdrawal Amount cannot be empty"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <asp:Panel ID="pnlPartialPreClosure" runat="server" Visible="false">
                                                    <tr id="trPreClosurePartialAmt" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ID="lblPreclosurePartialAmt" Text="Pre-Closure Amount" runat="server"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_PreClosurePartialAmt" runat="server" Culture="English (United States)"
                                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                                IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0"
                                                                ValidationGroup="PreClosOrWithdrawlControls" AutoPostBack="true" OnTextChanged="rtxt_PreClosurePartialAmt_TextChanged">
                                                                <IncrementSettings Step="0" />
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosurePartialAmt" runat="server"
                                                                ControlToValidate="rtxt_PreClosurePartialAmt" ErrorMessage="Enter Pre-Closure Amount"
                                                                Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblParitalPreClosureBalance" Text="Balance after Partial Pre-Closure" runat="server"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_ParitalPreClosureBalance" runat="server" Culture="English (United States)"
                                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                                IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                                ValidationGroup="PreClosOrWithdrawlControls">
                                                                <IncrementSettings Step="0" />
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_ParitalPreClosureBalance" runat="server"
                                                                ControlToValidate="rtxt_ParitalPreClosureBalance" ErrorMessage="Partial Pre-Closure Balance cannot be empty"
                                                                Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPreClosOrWithdrwlTnstallments" Text="No. of Installments" runat="server"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrwlTnstallments" runat="server" Culture="English (United States)"
                                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                                IncrementSettings-Step="0" MaxLength="3" MaxValue="70368744177664" MinValue="0"
                                                                ValidationGroup="PreClosOrWithdrawlControls" AutoPostBack="true" OnTextChanged="rtxt_PreClosOrWithdrwlTnstallments_TextChanged">
                                                                <IncrementSettings Step="0" />
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosOrWithdrwlTnstallments" runat="server"
                                                                ControlToValidate="rtxt_PreClosOrWithdrwlTnstallments" ErrorMessage="Enter No. of Installments"
                                                                Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPreClosOrWithdrwlEMIAmount" Text="Monthly Installment" runat="server"></asp:Label>
                                                        </td>
                                                        <td>:</td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrwlEMIAmount" runat="server" Culture="English (United States)"
                                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                                IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                                ValidationGroup="PreClosOrWithdrawlControls">
                                                                <IncrementSettings Step="0" />
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                        <td>
                                                            <%--<asp:RequiredFieldValidator ID="rfv_rtxt_PreClosOrWithdrwlEMIAmount" runat="server"
                                                                ControlToValidate="rtxt_PreClosOrWithdrwlEMIAmount" ErrorMessage="Monthly Installment cannot be empty"
                                                                Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkPreClosOrWithdrwlEMI" runat="server" OnClientClick="return false" Visible="False">EMI Calendar</asp:LinkButton>
                                                        </td>
                                                    </tr>


                                                </asp:Panel>




                                                <tr id="trPreClosIntrestOnLoanBal" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lblPreClosIntOnCurrLoanBal" runat="server" Text="Interest On Current Loan Balance"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosIntrestOnLoanBal" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" Type="Number"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosIntrestOnLoanBal" runat="server" ControlToValidate="rtxt_PreClosIntrestOnLoanBal" ErrorMessage="Interest On Current Loan Balance must not be empty"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPrecClosOrWithdrwlIntRate" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPrecClosOrWithdrwlIntRate" runat="server"
                                                            meta:resourcekey="lbl_interestAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PrecClosOrWithdrwlIntRate" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12" MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PrecClosOrWithdrwlIntRate" runat="server"
                                                            ControlToValidate="rtxt_PrecClosOrWithdrwlIntRate" ErrorMessage="Please enter Interest Amount"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr id="trPreClosOrWithdrwlTotAmt" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlTotAmt" runat="server" Text="Total Amount to pay"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrwlTotAmt" runat="server" Enabled="false" Type="Number"></telerik:RadNumericTextBox>
                                                        <%--<telerik:RadTextBox ID="rtxt_PreClosureTotAmt" runat="server" Enabled="false"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>--%>
                                                    </td>
                                                    <td></td>
                                                    <%--<td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return false" Visible="False">EMI Calender</asp:LinkButton>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlPayMode" runat="server" meta:resourcekey="lbl_PayMode"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>

                                                        <telerik:RadComboBox ID="rcmb_PreClosOrWithdrwlPayMode" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>

                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosOrWithdrwlPayMode" runat="server"
                                                            ControlToValidate="rcmb_PreClosOrWithdrwlPayMode" ErrorMessage="Please Choose Payment Mode"
                                                            Text="*" InitialValue="Select" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr id="trPreClosOrWithdrwlCheque" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlCheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosOrWithdrwlChequeNo" runat="server"
                                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" Enabled="false">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosOrWithdrwlChequeNo" runat="server"
                                                            ControlToValidate="rtxt_PreClosOrWithdrwlChequeNo" ErrorMessage="Enter Cheque Number"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlEffecDt" runat="server"
                                                            meta:resourcekey="lbl_effectiveDate"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_PreClosOrWithdrwlEffDt" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_PreClosOrWithdrwlEffDt" runat="server"
                                                            ControlToValidate="rdtp_PreClosOrWithdrwlEffDt" ErrorMessage="Please Enter Effective Date"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnPreClosOrWithdrwlCal" runat="server" meta:resourcekey="btn_Calculate" OnClick="btnPreClosOrWithdrwlCal_Click"
                                                            ValidationGroup="PreClosOrWithdrawlControls" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlPurpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_PreClosWithdrwlPurpose" runat="server" MaxLength="500"
                                                            Skin="WebBlue" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosWithdrwlPurpose" runat="server"
                                                            ControlToValidate="rtxt_PreClosWithdrwlPurpose" ErrorMessage="Please Enter Purpose"
                                                            Text="*" ValidationGroup="PreClosOrWithdrawlControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr id="trPreClosOrWithdrwlComments" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPreClosOrWithdrwlComments" runat="server" Text="Comments"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPreClosOrWithdrwlComments" runat="server" TextMode="MultiLine" Rows="3" Columns="30"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <br />
                                                        <asp:Button ID="btnPreClosOrWithdrawl" runat="server" Text="PreClose Loan" OnClick="btnPreClosOrWithdrawl_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'PreClosOrWithdrawlControls')" Visible="true" />
                                                        <asp:Button ID="btnPreClosOrWithdrawlControls_Cancel" runat="server" Text="Cancel" OnClick="btnPreClosOrWithdrawlControls_Cancel_Click" Visible="true" />
                                                        <asp:ValidationSummary ID="vs_PreClosOrWithdrawl" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="PreClosOrWithdrawlControls" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>

                                        <telerik:RadPageView ID="RPV_Preclosure" runat="server">
                                            <table align="center" width="45%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblPreclosure" runat="server" Text="Loan Pre-Closure" Font-Bold="true"></asp:Label></td>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureBU" runat="server" Text="Business Unit"></asp:Label>
                                                        <asp:Label ID="lblPreClosureTransID" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblPreClosureEMINo" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosureBU" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosureBU" runat="server"
                                                            ControlToValidate="rcmb_PreClosureBU" ErrorMessage="Select a Business Unit"
                                                            InitialValue="Select" Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureEmp" runat="server" Text="Employee Name"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosureEmp" runat="server" MarkFirstMatch="true" Enabled="false"
                                                            Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosureEmp" runat="server"
                                                            ControlToValidate="rcmb_PreClosureEmp" ErrorMessage="Select a Employee"
                                                            InitialValue="Select" Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureLoanNo" runat="server" Text="Loan No."></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_PreClosureLoanNo" runat="server" Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                            EmptyMessage="Auto Generated Code" ReadOnly="True" Width="125px" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureLoanType" runat="server" Text="Loan Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_PreClosureLoanType" runat="server" Enabled="false" MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosureLoanType" runat="server"
                                                            ControlToValidate="rcmb_PreClosureLoanType" ErrorMessage="Select a Loan Type"
                                                            Text="*" ValidationGroup="PreClosureControls"
                                                            InitialValue="Select"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureIssueDate" runat="server"
                                                            meta:resourcekey="lbl_IssueDate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_PreClosureIssueDate" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue" Width="135px">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_PreClosureIssueDate" runat="server"
                                                            ControlToValidate="rdtp_PreClosureIssueDate" ErrorMessage="Please give Issue Date"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureLoanAmt" runat="server" meta:resourcekey="lbl_Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <%--<telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server"
                                                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" 
                                                                        MinValue="0" Skin="WebBlue">
                                                                    </telerik:RadNumericTextBox>--%>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosureLoanAmt" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosureLoanAmt" runat="server"
                                                            ControlToValidate="rtxt_PreClosureLoanAmt" ErrorMessage="Amount cannot be empty"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureLoanBalance" runat="server" Text="Current Loan Balance"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <%--<telerik:RadNumericTextBox ID="rtxt_LoanAmount" runat="server"
                                                                        Culture="English (United States)" MaxLength="13" meta:resourcekey="rtxt_Amount" 
                                                                        MinValue="0" Skin="WebBlue">
                                                                    </telerik:RadNumericTextBox>--%>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosureLoanBalance" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosureLoanBalance" runat="server"
                                                            ControlToValidate="rtxt_PreClosureLoanBalance" ErrorMessage="Current Loan Balance cannot be empty"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIntrestOnLoanBal" runat="server" Text="Interest On Current Loan Balance"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_IntrestOnLoanBal" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" Type="Number"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="Controls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_IntrestOnLoanBal" runat="server" ControlToValidate="rtxt_IntrestOnLoanBal" ErrorMessage="Interest On Current Loan Balance must be empty"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server"
                                                            meta:resourcekey="lbl_installments"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="RadNumericTextBox3" runat="server"
                                                            Culture="English (United States)" MaxLength="12"
                                                            meta:resourcekey="rtxt_installments" Skin="WebBlue" Type="Number" MinValue="0">
                                                            <NumberFormat AllowRounding="false" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="rtxt_InstallmentNo" ErrorMessage="No of installments"
                                                            meta:resourcekey="rfv_rtxt_InstallmentNo" Text="*" ValidationGroup="RescheduleControls"></asp:RequiredFieldValidator></td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosreIntRate" runat="server"
                                                            meta:resourcekey="lbl_interestAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosureIntRate" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12" MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                        %
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosureIntRate" runat="server"
                                                            ControlToValidate="rtxt_PreClosureIntRate" ErrorMessage="Please enter Interest Amount"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureTotAmt" runat="server" Text="Total Amount to pay"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosureTotalAmt" runat="server" Enabled="false" Type="Number"></telerik:RadNumericTextBox>
                                                        <%--<telerik:RadTextBox ID="rtxt_PreClosureTotAmt" runat="server" Enabled="false"
                                                            Skin="WebBlue">
                                                        </telerik:RadTextBox>--%>
                                                    </td>
                                                    <td></td>
                                                    <%--<td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return false" Visible="False">EMI Calender</asp:LinkButton>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosurePayMode" runat="server" meta:resourcekey="lbl_PayMode"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>

                                                        <telerik:RadComboBox ID="rcmb_PreClosurePayMode" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>

                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_PreClosurePayMode" runat="server"
                                                            ControlToValidate="rcmb_PreClosurePayMode" ErrorMessage="Please Choose Payment Mode"
                                                            Text="*" InitialValue="Select" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr id="trPreClosureCheque" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblPreClosureCheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_PreClosureChequeNo" runat="server"
                                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" Enabled="false">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosureChequeNo" runat="server"
                                                            ControlToValidate="rtxt_PreClosureChequeNo" ErrorMessage="Enter Cheque Number"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosureEffecDt" runat="server"
                                                            meta:resourcekey="lbl_effectiveDate"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdtp_PreClosureEffDt" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rdtp_PreClosureEffDt" runat="server"
                                                            ControlToValidate="rdtp_PreClosureEffDt" ErrorMessage="Please Enter Effective Date"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator>
                                                        <%--<asp:CompareValidator ID="cv_rdtp_PreClosureEffDt" runat="server"
                                                            ControlToCompare="rdtp_pre" ControlToValidate="rdtp_EffectiveDate"
                                                            ErrorMessage="Effective Date cannot be less than Issue date"
                                                            Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="RescheduleControls"></asp:CompareValidator>--%>
                                                    </td>
                                                    <td>
                                                        <%--<asp:Button ID="btnPreClosureCal" runat="server" meta:resourcekey="btn_Calculate"
                                                            OnClick="btnPreClosureCal_Click" ValidationGroup="PreClosureControls" Visible="true" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPreClosurePurpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_PreClosurePurpose" runat="server" MaxLength="500"
                                                            Skin="WebBlue" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_PreClosurePurpose" runat="server"
                                                            ControlToValidate="rtxt_PreClosurePurpose" ErrorMessage="Please Enter Purpose"
                                                            Text="*" ValidationGroup="PreClosureControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <asp:Button ID="btnPreClosure" runat="server" Text="PreClose Loan" OnClick="btnPreClosure_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'PreClosureControls')" Visible="true" />
                                                        <asp:Button ID="btnPreClosureCancel" runat="server" Text="Cancel" OnClick="btnPreClosureCancel_Click" Visible="true" />
                                                        <asp:ValidationSummary ID="vsPreClosure" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="PreClosureControls" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <telerik:RadWindowManager ID="RWM_EmpDetails" runat="server">
                                                    </telerik:RadWindowManager>
                                                    <telerik:RadWindow ID="RWOrgDetails" runat="server" Height="200px" Visible="false" Modal="true" VisibleStatusbar="false"
                                                        VisibleOnPageLoad="false">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <table align="center">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblHeading" runat="server" Font-Bold="true" Text="EMI Details"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <telerik:RadGrid ID="rgStdLoan" runat="server" Skin="WebBlue" GridLines="None" AutoGenerateColumns="False"
                                                                                    AllowSorting="True">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <%--<telerik:GridBoundColumn DataField="STDLOAN_SLNO" HeaderText="S.No" UniqueName="S.No">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EMI" HeaderText="Loan Advance Deduction" UniqueName="LoadAdvanceDeduction">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_LES" HeaderText="Loan EMI Status" UniqueName="LoanEMISts">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EMD" HeaderText="Date(DD/MM/YYYY)" UniqueName="Date(DD/MM/YYYY)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EIR" HeaderText="Interest(%)" UniqueName="Interest(%)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_ROI" HeaderText="Interest Amount" UniqueName="Interest Amount">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_BAL" HeaderText="Balance" UniqueName="Balance">
                                                                                            </telerik:GridBoundColumn>--%>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_CURR_EMINO" HeaderText="S.No" UniqueName="S.No">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIAMOUNT" HeaderText="Loan Advance Deduction" UniqueName="LoadAdvanceDeduction">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMISTATUS" HeaderText="Loan EMI Status" UniqueName="LoanEMISts">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIPAYMENTDUEDATE" HeaderText="Date(DD/MM/YYYY)" UniqueName="Date(DD/MM/YYYY)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANS_INTERESTRATE" HeaderText="Interest(%)" UniqueName="Interest(%)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_INTEREST" HeaderText="Interest Amount" UniqueName="Interest Amount">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="LOANTRANDTL_CURRENTLOANAMOUNt" HeaderText="Balance" UniqueName="Balance">
                                                                                            </telerik:GridBoundColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                    <PagerStyle AlwaysVisible="True" />
                                                                                </telerik:RadGrid>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ContentTemplate>
                                                    </telerik:RadWindow>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RPV_UpdRefId" runat="server">
                                            <table align="center" width="55%">
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblUpdRefId" runat="server" Text="Update ReferenceId" Font-Bold="true"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIdBU" runat="server" Text="Business Unit"></asp:Label>
                                                        <asp:Label ID="lblRefLoanTransID" runat="server" Visible="False"></asp:Label>
                                                        <%--<asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>--%>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmbRefIdBU" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvrcmbRefIdBU" runat="server"
                                                            ControlToValidate="rcmbRefIdBU" ErrorMessage="Select a Business Unit"
                                                            InitialValue="Select" Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIDEmp" runat="server" Text="Employee Name"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmbRefIdEmp" runat="server" MarkFirstMatch="true" Enabled="false"
                                                            Skin="WebBlue" AutoPostBack="True" MaxHeight="120px" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvrcmbRefIdEmp" runat="server"
                                                            ControlToValidate="rcmbRefIdEmp" ErrorMessage="Select a Employee"
                                                            InitialValue="Select" Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIDLoanNo" runat="server" Text="Loan No."></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxtRefIdLoanNo" runat="server" Skin="WebBlue" DisabledStyle-BackColor="Window"
                                                            EmptyMessage="Auto Generated Code" ReadOnly="True" Width="125px" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIdLoanProcType" runat="server" Text="Loan Process Type"></asp:Label>
                                                    </td>

                                                    <td>:</td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmbRefIdLoanprocType" runat="server" Enabled="false">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Value="0" Text="Reducing Balance" />
                                                                <telerik:RadComboBoxItem Value="1" Text="Increasing Balance" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIdLoanType" runat="server" Text="Loan Type"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmbRefIdLoanType" runat="server" Enabled="false" MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrcmbRefIdLoanType" runat="server"
                                                            ControlToValidate="rcmbRefIdLoanType" ErrorMessage="Select a Loan Type"
                                                            Text="*" ValidationGroup="UpdRefIDControls"
                                                            InitialValue="Select"></asp:RequiredFieldValidator>--%>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUpdRefIssueDate" runat="server"
                                                            meta:resourcekey="lbl_IssueDate"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdpUpdRefIssueDate" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue" Width="135px">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrdpUpdRefIssueDate" runat="server"
                                                            ControlToValidate="rdpUpdRefIssueDate" ErrorMessage="Please give Issue Date"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRefIDLoanAmt" runat="server" Text="Loan Amount"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxtUpdRefIdLoanAmt" runat="server" Culture="English (United States)"
                                                            IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                            IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" MinValue="0" Enabled="false"
                                                            ValidationGroup="UpdRefIDControls">
                                                            <IncrementSettings Step="0" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrtxtUpdRefIdLoanAmt" runat="server"
                                                            ControlToValidate="rtxtUpdRefIdLoanAmt" ErrorMessage="Amount cannot be empty"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr id="trUpdRefIntrst" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblUpdRefIntrstAmt" runat="server"
                                                            meta:resourcekey="lbl_interestAmt"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxtUpdRefIntrstAmt" runat="server" Enabled="false"
                                                            Culture="English (United States)" MaxLength="12" MinValue="0" Skin="WebBlue">
                                                        </telerik:RadNumericTextBox>
                                                        %
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrtxtUpdRefIntrstAmt" runat="server"
                                                            ControlToValidate="rtxtUpdRefIntrstAmt" ErrorMessage="Please enter Interest Amount"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUpdRefPayMode" runat="server" meta:resourcekey="lbl_PayMode"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmbUpdRefPayMode" runat="server" AutoPostBack="True"
                                                            MarkFirstMatch="true" Skin="WebBlue" Enabled="false" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrcmbUpdRefPayMode" runat="server"
                                                            ControlToValidate="rcmbUpdRefPayMode" ErrorMessage="Please Choose Payment Mode"
                                                            Text="*" InitialValue="Select" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>

                                                </tr>
                                                <tr id="trUpdRefCheque" runat="server">
                                                    <td>
                                                        <asp:Label ID="lblUpdRefCheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxtUpdRefCheque" runat="server"
                                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" Enabled="false">
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrtxtUpdRefCheque" runat="server"
                                                            ControlToValidate="rtxtUpdRefCheque" ErrorMessage="Enter Cheque Number"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUpdRefEffDt" runat="server"
                                                            meta:resourcekey="lbl_effectiveDate"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="rdpUpdRefEffDt" runat="server"
                                                            Culture="English (United States)" Enabled="false" Skin="WebBlue">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrdpUpdRefEffDt" runat="server"
                                                            ControlToValidate="rdpUpdRefEffDt" ErrorMessage="Please Enter Effective Date"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblUpdRefPurpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label></td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxtUpdRefPurpose" runat="server" MaxLength="500"
                                                            Skin="WebBlue" Enabled="false">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrtxtUpdRefPurpose" runat="server"
                                                            ControlToValidate="rtxtUpdRefPurpose" ErrorMessage="Please Enter Purpose"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblReferenceId" runat="server" Text="Reference ID"></asp:Label>
                                                    </td>
                                                    <td>:</td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxtReferenceId" runat="server" MaxLength="50"></telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <%--<asp:RequiredFieldValidator ID="rfvrtxtReferenceId" runat="server"
                                                            ControlToValidate="rtxtReferenceId" ErrorMessage="Please Enter Reference ID"
                                                            Text="*" ValidationGroup="UpdRefIDControls"></asp:RequiredFieldValidator>--%>
                                                        <%--<asp:RegularExpressionValidator ID="revrtxtReferenceId" runat="server" ControlToValidate="rtxtReferenceId" ErrorMessage="Enter only alpha-numeric characters"
                                                            Text="*" ValidationGroup="UpdRefIDControls" ValidationExpression="[a-zA-Z0-9]*"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <br />
                                                        <%--<asp:Button ID="Button2" runat="server" Text="PreClose Loan" OnClick="btnPreClosOrWithdrawl_Click" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'PreClosOrWithdrawlControls')" Visible="true" />--%>
                                                        <asp:Button ID="btnUpdateRefId" runat="server" Text="Update" OnClick="btnUpdateRefId_Click" Visible="true" ValidationGroup="UpdRefIDControls" />
                                                        <asp:Button ID="btnCancelRefId" runat="server" Text="Cancel" OnClick="btnCancelRefId_Click" Visible="true" CausesValidation="false" />
                                                        <asp:ValidationSummary ID="vsUpdRefIDControls" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UpdRefIDControls" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>