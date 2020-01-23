<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_EmpReducingLoanTran.aspx.cs" Inherits="Payroll_frm_EmpReducingLoanTran" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                radopen(str, "RW_EMI_CALENDER");
            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindowManager ID="RWM_EMICALENDER" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close">
        <Windows>
            <telerik:RadWindow ID="RW_EMICALENDER" Skin="WebBlue" Modal="true" runat="server"
                Width="300px" Height="500px" Title="EMI CALENDER" VisibleStatusbar="false" ReloadOnShow="true"
                Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_LoanDetHeader" runat="server" Font-Bold="true" Text="Employee Reducing Balances LoanTransaction Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Loan_page" runat="server" SelectedIndex="0" Width="990px">
                    <telerik:RadPageView ID="Rp_Loan_ViewMain" runat="server" meta:resourcekey="Rp_Loan_ViewMain"
                        Selected="True">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Loandet" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" AllowPaging="true" PageSize="10" AllowFilteringByColumn="True"
                                        ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                        OnNeedDataSource="Rg_Loandet_NeedDataSource" Width="800px" Height="355px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" UniqueName="BUSINESSUNIT_ID"
                                                    HeaderText="BID" meta:resourcekey="BUSINESSUNIT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit" meta:resourcekey="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_ID" UniqueName="LOANTRANS_ID" HeaderText="ID"
                                                    meta:resourcekey="LOANTRANS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" HeaderText="Employee"
                                                    meta:resourcekey="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_LOANNO" UniqueName="LOANTRANS_LOANNO"
                                                    HeaderText="LoanNo" meta:resourcekey="LOANTRANS_LOANNO">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_EMP_ID" UniqueName="LOANTRANS_EMP_ID"
                                                    HeaderText="EmployeeID" meta:resourcekey="LOANTRANS_EMP_ID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_LOANAMOUNT" UniqueName="LOANTRANS_LOANAMOUNT"
                                                    HeaderText="Loan Amount" meta:resourcekey="EMPLOANTRAN_AMOUNT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOANTRANS_ISSUEDATE" UniqueName="LOANTRANS_ISSUEDATE" AllowFiltering="false"
                                                    HeaderText="Loan Issued Date" meta:resourcekey="LOANTRANS_ISSUEDATE">
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
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%# Eval("LOANTRANS_ID") %>'
                                                            meta:resourcekey="lnk_Edit" Text="Edit/View"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn AllowFiltering="false" 
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="ColSanction">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Sanction" runat="server" 
                                                            CommandArgument='<%# Eval("LOANTRANS_ID") %>' meta:resourcekey="lnk_Sanction" 
                                                            OnCommand="lnk_Sanction_Command" Text="Sanction Loan"></asp:LinkButton>
                                                    </ItemTemplate>
                                                
                                                </telerik:GridTemplateColumn>--%>
                                                <%--<telerik:GridTemplateColumn UniqueName="ColEdit_1" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit_1" runat="server" OnCommand="lnk_Edit_1_Command" CommandArgument='<%# Eval("LOANTRANS_ID") %>'
                                                            meta:resourcekey="lnk_Edit_1" Text="Reschedule"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <PagerStyle AlwaysVisible="True" />
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <%--<asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add</asp:LinkButton>--%>
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
                    <telerik:RadPageView ID="Rp_loan_ViewDetails" runat="server" meta:resourcekey="Rp_loan_ViewDetails">
                        <%--<telerik:RadTabStrip ID="rd_LOANTRANS" runat="server" MultiPageID="RMP_LoanDet" SelectedIndex="0"
                             Width="570px" Align="Center">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Loan" PageViewID="RPV_Loans">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Rescheduling" PageViewID="RPV_RPTReschedule"
                                    Visible="false">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Repayment" PageViewID="RPV_RPTDetails" Visible="false">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>--%>
                        <%--<telerik:RadPageView ID="Rp_loan_ViewDetails" runat="server" meta:resourcekey="Rp_loan_ViewDetails">--%>
                        <telerik:RadMultiPage ID="RMP_LoanDet" runat="server" Width="1004px" SelectedIndex="0">
                            <telerik:RadPageView ID="RPV_Loans" runat="server">
                                <table align="center" width="40%">
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Label ID="lbl_LoanDetDetails" runat="server" meta:resourcekey="lbl_LoanDetDetails"></asp:Label>
                                        </td>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Label ID="lbl_LoanDetEmpDOJ" runat="server" meta:resourcekey="lbl_LoanDetEmpName"
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_loantrans_ID" runat="server" Visible="False" meta:resourcekey="lbl_loantrans_ID"></asp:Label>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" MarkFirstMatch="true" Enabled="false"
                                                OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" AutoPostBack="True" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                                ErrorMessage="Select a Business Unit" InitialValue="Select" meta:resourcekey="rcmb_BusinessUnit"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_LoanDetEmpName" runat="server" meta:resourcekey="lbl_LoanDetEmpName"
                                                Text="Employee&nbsp;Name"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" MaxHeight="120px" MarkFirstMatch="true" Enabled="false"
                                                Skin="WebBlue" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" AutoPostBack="True" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" ControlToValidate="rcmb_Employee"
                                                InitialValue="Select" ErrorMessage="Select a Employee" Text="*" ValidationGroup="Controls"
                                                meta:resourcekey="rfv_rcmb_Employee"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_loanno" runat="server" meta:resourcekey="lbl_loanno"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_loanno" runat="server" EmptyMessage="Auto Generated Code"
                                                Skin="WebBlue" ReadOnly="True" Width="125px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_loantype" runat="server" meta:resourcekey="lbl_loantype"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_loantype" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                                meta:resourcekey="rcmb_loantype" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_loantype" runat="server" ControlToValidate="rcmb_loantype"
                                                ErrorMessage="Select a Main Period " Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_loantype"
                                                InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_IssueDate" runat="server" meta:resourcekey="lbl_IssueDate"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_IssueDate" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rdtp_IssueDate" Enabled="false"
                                                Width="135px">
                                            </telerik:RadDatePicker>
                                            <asp:Label ID="lblissue" runat="server" meta:resourcekey="lblissue" Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_IssueDate" runat="server" ControlToValidate="rdtp_IssueDate"
                                                ErrorMessage="Please give Issue Date" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_IssueDate"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Amount" runat="server" meta:resourcekey="lbl_Amount"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Amount" runat="server" MaxLength="12" MinValue="0"
                                                Skin="WebBlue" meta:resourcekey="rtxt_Amount">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Amount" runat="server" ControlToValidate="rtxt_Amount"
                                                ErrorMessage="Amount cannot be empty" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_Amount"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_installments" runat="server" meta:resourcekey="lbl_installments"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_installments" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rtxt_installments" MaxLength="12">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_installments" runat="server" ControlToValidate="rtxt_installments"
                                                ErrorMessage="No of installments" meta:resourcekey="rfv_rtxt_installments" Text="*"
                                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_interestAmt" runat="server" meta:resourcekey="lbl_interestAmt"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_InterestAmt" runat="server"
                                                Skin="WebBlue" meta:resourcekey="rtxt_InterestAmt" MinValue="0" MaxLength="12">
                                                <NumberFormat AllowRounding="false" DecimalDigits="4" />
                                            </telerik:RadNumericTextBox>
                                            %
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_InterestAmt" runat="server" ControlToValidate="rtxt_InterestAmt"
                                                ErrorMessage="Please enter Interest Amount" meta:resourcekey="rfv_rtxt_InterestAmt"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_MonthlyEMI" runat="server" meta:resourcekey="lbl_MonthlyEMI"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_MonthlyEMI" runat="server" Skin="WebBlue"
                                                Enabled="false">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkbtn_EMIDATA" runat="server" meta:resourcekey="lnkbtn_EMIDATA"
                                                OnClientClick="return false" Visible="False">EMI CALENDER</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_PayMode" runat="server" Text="Payment&nbsp;Mode" meta:resourcekey="lbl_PayMode"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddl_PayMode" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddl_PayMode_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_PayMode" runat="server" ControlToValidate="ddl_PayMode"
                                                ErrorMessage="Please Choose Payment Mode" meta:resourcekey="RFV_PayMode" InitialValue="- Select -"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr runat="server" id="cheque">
                                        <td>
                                            <asp:Label ID="lbl_Cheque" runat="server" meta:resourcekey="lbl_Cheque"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="txt_ChequeNumber" runat="server" NumberFormat-GroupSeparator=""
                                                NumberFormat-DecimalDigits="0">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Cheque" runat="server" ControlToValidate="txt_ChequeNumber"
                                                ErrorMessage="Enter Cheque Number" meta:resourcekey="RFV_Cheque" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_effectiveDate" runat="server" meta:resourcekey="lbl_effectiveDate"></asp:Label>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_EffectiveDate" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rdtp_EffectiveDate">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_EffectiveDate" runat="server" ControlToValidate="rdtp_EffectiveDate"
                                                ErrorMessage="Please give Effective Date" meta:resourcekey="rfv_rdtp_EffectiveDate"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="ctl_rdtp_EffectiveDate" runat="server" ControlToCompare="rdtp_IssueDate"
                                                ControlToValidate="rdtp_EffectiveDate" ErrorMessage="Issue Date cannot be ahead of Effective Date"
                                                Operator="GreaterThanEqual" Text="*" ValidationGroup="Controls" Type="Date"></asp:CompareValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_Calculate" runat="server" meta:resourcekey="btn_Calculate" OnClick="btn_Calculate1_Click"
                                                ValidationGroup="Controls" Visible="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_purpose" runat="server" meta:resourcekey="lbl_purpose"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_purpose" runat="server" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_purpose" runat="server" ControlToValidate="rtxt_purpose"
                                                ErrorMessage="Please enter Purpose" meta:resourcekey="rfv_rtxt_purpose"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                                        <td align="center" colspan="5">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit"
                                                Text="Update" OnClick="btn_Save_Click" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" Text="Save"
                                                OnClick="btn_Save_Click" ValidationGroup="Controls" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel"
                                                OnClick="btn_Cancel_Click" />
                                            <asp:Button ID="btn_Sanction" runat="server" OnClick="btn_Sanction_Click"
                                                Text="Sanction" ValidationGroup="Controls" />
                                            <asp:ValidationSummary ID="vs_OTDet" runat="server" meta:resourcekey="vs_OTDet"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="RPV_RPTDetails" runat="server">
                                <table align="center" width="40%">
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Label ID="lbl_RPTDETAILS" runat="server" meta:resourcekey="lbl_RPTDETAILS"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_RLOANNO" runat="server" meta:resourcekey="lbl_RLOANNO"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_RloanNo" runat="server" Skin="WebBlue"
                                                ReadOnly="True">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_RloanTrasnID" runat="server" Skin="WebBlue" Visible="false">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_RLoanBalAmt" runat="server" meta:resourcekey="lbl_RLoanBalAmt"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_RLoanBalanceAmt" runat="server" Skin="WebBlue"
                                                ReadOnly="True">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_RPrincipalBalanceAmt" runat="server" Skin="WebBlue"
                                                ReadOnly="True" Visible="False">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Ramount" runat="server" meta:resourcekey="lbl_Ramount"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Ramount" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rtxt_Amount">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Ramount" runat="server" ControlToValidate="rtxt_Ramount"
                                                ErrorMessage="Repayment Amount is Mandatory" meta:resourcekey="rfv_rtxt_Ramount"
                                                Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DateofTrans" runat="server" meta:resourcekey="lbl_DateofTrans"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_DateofTRans" runat="server" Skin="WebBlue">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_DateofTRans" runat="server" ControlToValidate="rdtp_DateofTRans"
                                                ErrorMessage="Date of Transaction is Mandatory" Text="*" ValidationGroup="Controls1"
                                                meta:resourcekey="rfv_rdtp_DateofTRans"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_PayType" runat="server" meta:resourcekey="lbl_PayType"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_PayType" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                                                meta:resourcekey="rcmb_PayType" AutoPostBack="True" OnSelectedIndexChanged="rcmb_PayType_SelectedIndexChanged">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="Cash" Value="1" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Cheque" Value="2" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_PayType" runat="server" ControlToValidate="rcmb_PayType"
                                                ErrorMessage="Please mention Loan repayment type" meta:resourcekey="rfv_rcmb_PayType"
                                                Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="Cheqtr" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_ChequeNo" runat="server" meta:resourcekey="lbl_ChequeNo"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_ChequeNo" runat="server" MaxLength="8" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_ChequeNo" runat="server" ControlToValidate="rtxt_ChequeNo"
                                                ErrorMessage="No of installments" meta:resourcekey="rfv_rtxt_ChequeNo" Text="*"
                                                ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="banktr" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_bankname" runat="server" meta:resourcekey="lbl_bankname"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_bankname" runat="server" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="branchtr" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_branchname" runat="server" meta:resourcekey="lbl_branchname"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_branchname" runat="server" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Rinstallments" runat="server" meta:resourcekey="lbl_Rinstallments"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_Rinstallments" runat="server" Skin="WebBlue"
                                                meta:resourcekey="rtxt_Rinstallments">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_RInterestRate" runat="server" meta:resourcekey="lbl_RInterestRate"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_RInterestRate" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rtxt_RInterestRate">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_RevisedEMI" runat="server" meta:resourcekey="lbl_RevisedEMI"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_RevisedEMI" runat="server" Culture="English (United States)"
                                                Skin="WebBlue" meta:resourcekey="rtxt_RevisedEMI">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Currency" runat="server" meta:resourcekey="lbl_Currency"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btn_process" runat="server" meta:resourcekey="btn_Process" ValidationGroup="Controls1"
                                                OnClick="btn_process_Click" />
                                            <asp:ValidationSummary ID="VS_Second" runat="server" meta:resourcekey="vs_OTDet"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls1" />
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
                                            <telerik:RadGrid ID="rg_loantrandetails" runat="server" Skin="WebBlue"
                                                AutoGenerateColumns="False" GridLines="None" AllowPaging="true" OnNeedDataSource="rg_loantrandetails_NeedDataSource">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="LOANTRANDTL_ID" UniqueName="LOANTRANDTL_ID" HeaderText="LTDID"
                                                            meta:resourcekey="LOANTRANDTL_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="LOANTRADTL_LOANTRAN_ID" UniqueName="LOANTRADTL_LOANTRAN_ID"
                                                            HeaderText="LTID" meta:resourcekey="LOANTRADTL_LOANTRAN_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DUE_DATE" UniqueName="DUE_DATE" HeaderText="Due&nbsp;Date"
                                                            meta:resourcekey="DUE_DATE">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="LOANTRANDTL_EMIAMOUNT" UniqueName="LOANTRANDTL_EMIAMOUNT"
                                                            HeaderText="Reducing Balance&nbsp;Amount" meta:resourcekey="LOANTRANDTL_EMIAMOUNT">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="REMAINING_PRINCIPAL" UniqueName="REMAINING_PRINCIPAL"
                                                            HeaderText="Principal&nbsp;Balance" meta:resourcekey="REMAINING_PRINCIPAL">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="REMAINING_LOAN" UniqueName="REMAINING_LOAN" HeaderText="Loan&nbsp;Balance"
                                                            meta:resourcekey="REMAINING_LOAN" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMIS" UniqueName="EMIS" HeaderText="Reducing Balance&nbsp;Count"
                                                            meta:resourcekey="EMIS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="LOANTRANDTL_EMISTATUS" UniqueName="LOANTRANDTL_EMISTATUS"
                                                            HeaderText="STATUS" meta:resourcekey="LOANTRANDTL_EMISTATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridTemplateColumn UniqueName="LOANTRANDTL_EMISTATUS" HeaderText="STATUS"
                                                            meta:resourcekey="LOANTRANDTL_EMISTATUS">
                                                            <ItemTemplate>
                                                                <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true" Skin="WebBlue" SelectedIndex='<%# Convert.ToInt32(Eval("LOANTRANDTL_EMISTATUS")) %>'>
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Text="Open" Value="0" Selected="True" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="Close" Value="1" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="Postponed" Value="2" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btn_RSchedProcess" runat="server" meta:resourcekey="btn_RSchedProcess"
                                                OnClick="btn_RSchedProcess_Click" />
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
                        </telerik:RadMultiPage>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>