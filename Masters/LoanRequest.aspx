<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="LoanRequest.aspx.cs" Inherits="Masters_LoanRequest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .RadInput {
            vertical-align: middle;
        }

        .style1 {
            width: 88px;
        }

        .RadPicker {
            vertical-align: middle;
        }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcCalPopup {
                display: block;
                overflow: hidden;
                width: 22px;
                height: 22px;
                background-color: transparent;
                background-repeat: no-repeat;
                text-indent: -2222px;
                text-align: center;
            }

            .RadPicker table.rcTable .rcInputCell {
                padding: 0 4px 0 0;
            }

        .setWidth {
            width: 100px !important;
        }

        .setWidth1 {
            width: 450px !important;
        }
        /*.rgHeader{
            text-align:left !important;
        }*/
    </style>
    <script type="text/javascript">
        function fnJSOnFormSubmit(sender, group) {
            var isGrpOneValid = Page_ClientValidate(group);
            var i;
            for (i = 0; i < Page_Validators.length; i++) {
                ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
            }
            for (i = 0; i < Page_ValidationSummaries.length; i++) {
                summary = Page_ValidationSummaries[i];
                if (isGrpOneValid) {
                    sender.disabled = "disabled";
                    return true;
                }

                if (fnJSDisplaySummary(summary.validationGroup)) {
                    summary.style.display = "";
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_DepartmentHeader" runat="server" Text="Loan Request" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px">
                    <telerik:RadPageView ID="Rp_LoanDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4">
                                    <telerik:RadGrid ID="rg_loandetails" runat="server" AllowFilteringByColumn="true" OnNeedDataSource="rg_loandetails_NeedDataSource"
                                        AutoGenerateColumns="False" GridLines="None" AllowPaging="true" PageSize="10"
                                        Skin="WebBlue" Width="900px">
                                        <HeaderContextMenu Skin="WebBlue" />
                                        <PagerStyle AlwaysVisible="true" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOANREQUESTID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="payitem_payitemname" HeaderText="Type of Loan"
                                                    UniqueName="payitem_payitemname" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount"
                                                    ItemStyle-HorizontalAlign="Left" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridNumericColumn DataField="NOOFINSTALLMENTS" HeaderText="No of Installments"
                                                    UniqueName="NOOFINSTALLMENTS" ItemStyle-HorizontalAlign="Left" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridBoundColumn DataField="status" HeaderText=" Loan Status" UniqueName="status"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOAN_PROCESS_TYPE" HeaderText="Loan Process Type" UniqueName="LOAN_PROCESS_TYPE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Valuation Report" AllowFiltering="false" Visible="false">
                                                    <ItemTemplate>
                                                        <a id="D2" runat="server" target="_blank" href='<%#Eval("LOAN_REQUEST_VALUATIONDOC") %>'>Download Invoice</a>
                                                        <asp:Label ID="lbl_BioData" Text='<%# Eval("LOAN_REQUEST_VALUATIONDOC") %>' Visible="false" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtn_Edit" Text="Edit" runat="server" OnCommand="lbtn_Edit_OnCommand"
                                                            CommandArgument='<%#Eval("LOANREQUESTID") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_add" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_LoanRequest" runat="server">
                        <asp:UpdatePanel ID="upnl" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td colspan="3" align="center"></td>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_depID" runat="server" meta:resourcekey="lbl_depID" Text="lbl_depID"
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DPname0" runat="server" meta:resourcekey="lbl_DPname" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True" MarkFirstMatch="true" MaxHeight="120px"
                                                OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_DName1" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                                InitialValue="Select" ErrorMessage="Business Unit is Mandatory" meta:resourcekey="rfv_rtxt_HCCode"
                                                ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DPDesc" runat="server" meta:resourcekey="lbl_DPDesc" Text="Employee Name"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_EmployeeName" runat="server" HighlightTemplatedItems="True" Filter="Contains"
                                                Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_EmployeeName_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_EmployeeName"
                                                ErrorMessage="Employee Name is Mandatory" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnit"
                                                ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ProcessType" runat="server" meta:resourcekey="lbl_ProcessType"
                                                Text="Loan&nbsp;Process&nbsp;Type"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rb_loanprocesstype" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="rb_loanprocesstype_SelectedIndexChanged">
                                                <Items>
                                                    <%-- <telerik:RadComboBoxItem Value="0" Text="Reducing Balance" />
                                                    <telerik:RadComboBoxItem Value="1" Text="Increasing Balance" />--%>
                                                    <telerik:RadComboBoxItem Value="2" Text="Standard" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rb_loanprocesstype" runat="server" ControlToValidate="rb_loanprocesstype"
                                                ErrorMessage="Loan Process Type is Mandatory" meta:resourcekey="rfv_rb_loanprocesstype"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DPname" runat="server" meta:resourcekey="lbl_DPname" Text="Loan Type"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_LoanType" runat="server" HighlightTemplatedItems="True" MaxHeight="120px" Filter="Contains"
                                                AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_LoanType_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_DName" runat="server" ControlToValidate="rcmb_LoanType"
                                                InitialValue="Select" ErrorMessage="Loan Type is Mandatory" meta:resourcekey="rfv_rtxt_HCCode"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr id="trParentLoan" runat="server" visible="true">
                                        <td>
                                            <asp:Label ID="lbl_ParentLoanNo" runat="server" meta:resourcekey="lbl_DPname" Text="Parent Loan No."></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_ParentLoanNo" runat="server" HighlightTemplatedItems="True"
                                                AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_ParentLoanNo" runat="server" ControlToValidate="rcmb_ParentLoanNo"
                                                InitialValue="Select" ErrorMessage="Parent Loan No. is mandatory" meta:resourcekey="rfv_rcmb_ParentLoanNo"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trRateOfInterest" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Rate of Interest"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRateofInterest" runat="server" Font-Bold="true" Text=""></asp:Label>&nbsp;<b>%</b>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr id="trLoanEligibleAmount" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Loan Eligible Amount"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLoanEligibleAmount" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_loanAmnt" runat="server" meta:resourcekey="lbl_DPname" Text="Loan Amount"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="txt_Amount" runat="server" Culture="English (United States)"
                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                IncrementSettings-Step="0" MaxLength="13" MaxValue="70368744177664" TabIndex="23" MinValue="0"
                                                ValidationGroup="Controls">
                                                <IncrementSettings Step="0" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_DName2" runat="server" ControlToValidate="txt_Amount"
                                                ErrorMessage="Loan Amount is Mandatory" meta:resourcekey="rfv_rtxt_HCCode" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DPDesc0" runat="server" meta:resourcekey="lbl_DPDesc" Text="No of Installments"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <%--<td>
                                    <telerik:RadTextBox ID="rtxt_NOI" runat="server" EnableEmbeddedSkins="false"
                                        ValidationGroup="Controls" LabelCssClass="" MaxLength="3" Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>--%>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_NOI" runat="server" Culture="English (United States)"
                                                IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true"
                                                IncrementSettings-Step="0" MaxLength="3" MaxValue="70368744177664" TabIndex="23" MinValue="1"
                                                ValidationGroup="Controls" AutoPostBack="True" OnTextChanged="rtxt_NOI_TextChanged">
                                                <%--  ontextchanged="rtxt_NOI_TextChanged">--%>
                                                <IncrementSettings Step="0" />
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit0" runat="server" ControlToValidate="rtxt_NOI"
                                                ErrorMessage="No of Installments is Mandatory" meta:resourcekey="rfv_rcmb_BusinessUnit"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DPDesc2" runat="server" meta:resourcekey="lbl_DPDesc" Text="Applied Date"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <%-- <telerik:RadDatePicker ID="txt_StartDate" runat="server" 
                                        EnableEmbeddedSkins="false"  Skin="WebBlue" 
                                        ValidationGroup="Controls">
                                    </telerik:RadDatePicker>--%>

                                            <telerik:RadDatePicker ID="txt_StartDate" runat="server" TabIndex="7" AutoPostBack="true">
                                                <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                            <%--<telerik:RadDatePicker ID="txt_StartDate" runat="server" Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x" >
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>--%>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit1" runat="server" ControlToValidate="txt_StartDate"
                                                ErrorMessage="Applied Date is Mandatory" meta:resourcekey="rfv_rcmb_BusinessUnit"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>

                                            <asp:HiddenField ID="hdnMinTenureMonths" runat="server" />
                                            <asp:HiddenField ID="hdnMaxTenureMonths" runat="server" />
                                            <asp:HiddenField ID="hdnMaxeligibleMonthsforEmp" runat="server" />
                                            <asp:Button ID="rbShowDialog" runat="server" OnClick="rbShowDialog_Click" Text="Calculate EMI"
                                                ValidationGroup="Controls" />
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <telerik:RadWindowManager ID="RWM_EmpDetails" runat="server">
                                                    </telerik:RadWindowManager>
                                                    <telerik:RadWindow ID="RWOrgDetails" runat="server" Height="200px" Visible="false" Modal="true" VisibleStatusbar="false">
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
                                                                                <telerik:RadGrid ID="RG_EMI" runat="server" Skin="WebBlue" GridLines="None" AutoGenerateColumns="False"
                                                                                    AllowSorting="True">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <telerik:GridBoundColumn DataField="MONTHS" HeaderText="MONTHS" meta:resourcekey="MONTHS"
                                                                                                UniqueName="MONTHS">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="EMI" HeaderText="PRINCIPLE" meta:resourcekey="EMI"
                                                                                                UniqueName="EMI">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="INTREST" HeaderText="INTEREST" meta:resourcekey="INTREST"
                                                                                                UniqueName="EMI">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="PRINCIPAL_REPAYMENT" HeaderText="EMI"
                                                                                                meta:resourcekey="PRINCIPAL_REPAYMENT" UniqueName="PRINCIPAL_REPAYMENT">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="OST_PRINCIPAL" HeaderText="BALANCE" meta:resourcekey="OST_PRINCIPAL"
                                                                                                UniqueName="OST_PRINCIPAL">
                                                                                            </telerik:GridBoundColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                    <PagerStyle AlwaysVisible="True" />
                                                                                </telerik:RadGrid>
                                                                                <telerik:RadGrid ID="RG_GenarateEMI" runat="server" Skin="WebBlue" GridLines="None" AutoGenerateColumns="False"
                                                                                    AllowSorting="True">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <telerik:GridBoundColumn DataField="USERLOANEMI_CURR_EMINO" HeaderText="S.No" UniqueName="SNO" Visible="false">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="USERLOANEMI_YEAR" HeaderText="Year" UniqueName="YEAR">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="USERLOANEMI_MONTH" HeaderText="Month" UniqueName="MONTH">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridTemplateColumn UniqueName="USERLOANEMI_EMIAMOUNT" HeaderText="EMI">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblEmiHeader" runat="server" Text="EMI"></asp:Label>
                                                                                                    <asp:CheckBox ID="chkEMI" runat="server" Text="Update All" AutoPostBack="true" OnCheckedChanged="chkEMI_CheckedChanged" />
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <telerik:RadNumericTextBox ID="txt_EMI" runat="server" MinValue="0" MaxLength="10"
                                                                                                        Text='<%# Eval("USERLOANEMI_EMIAMOUNT") %>' Enabled='<%# !Convert.ToBoolean(Eval("USERLOANEMI_EMI_STATUS")) %>'>
                                                                                                    </telerik:RadNumericTextBox>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                    <PagerStyle AlwaysVisible="True" />
                                                                                </telerik:RadGrid>

                                                                                <telerik:RadGrid ID="rgStdLoan" runat="server" Skin="WebBlue" GridLines="None" AutoGenerateColumns="False"
                                                                                    AllowSorting="True" Visible="false">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_SLNO" HeaderText="S.No" UniqueName="S.No">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EMI" HeaderText="Load Advance Deduction" UniqueName="LoadAdvanceDeduction">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EMD" HeaderText="Date(DD/MM/YYYY)" UniqueName="Date(DD/MM/YYYY)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_EIR" HeaderText="Interest(%)" UniqueName="Interest(%)">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_ROI" HeaderText="Interest Amount" UniqueName="Interest Amount">
                                                                                            </telerik:GridBoundColumn>
                                                                                            <telerik:GridBoundColumn DataField="STDLOAN_BAL" HeaderText="Balance" UniqueName="Balance">
                                                                                            </telerik:GridBoundColumn>

                                                                                            <%--<telerik:GridTemplateColumn UniqueName="USERLOANEMI_EMIAMOUNT" HeaderText="EMI">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblEmiHeader" runat="server" Text="EMI"></asp:Label>
                                                                                                    <asp:CheckBox ID="chkEMI" runat="server" Text="Update All" AutoPostBack="true" OnCheckedChanged="chkEMI_CheckedChanged" />
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <telerik:RadNumericTextBox ID="txt_EMI" runat="server" MinValue="0" MaxLength="10"
                                                                                                        Text='<%# Eval("USERLOANEMI_EMIAMOUNT") %>' Enabled='<%# !Convert.ToBoolean(Eval("USERLOANEMI_EMI_STATUS")) %>'>
                                                                                                    </telerik:RadNumericTextBox>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                            </telerik:GridTemplateColumn>--%>
                                                                                        </Columns>
                                                                                    </MasterTableView>
                                                                                    <PagerStyle AlwaysVisible="True" />
                                                                                </telerik:RadGrid>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnEMISave" runat="server" Font-Bold="true" Text="Save EMI Details" OnClick="btnEMISave_Click"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ContentTemplate>
                                                    </telerik:RadWindow>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <telerik:RadWindowManager ID="RWM_VoucherDtls" runat="server">
                                                    </telerik:RadWindowManager>
                                                    <telerik:RadWindow ID="RW_VoucherDtls" runat="server" Height="200px" Visible="false" Modal="true" VisibleStatusbar="false">
                                                        <ContentTemplate>
                                                            <br />
                                                            <br />
                                                            <table style="padding-left: 25px;">
                                                                <tr>
                                                                    <td align="center">
                                                                        <table width="600px">
                                                                            <tr>
                                                                                <td colspan="2" align="center">
                                                                                    <asp:Label ID="Label6" runat="server" Text="Voucher Details" Font-Bold="true" Font-Size="18px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" align="center">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblPayeeName" runat="server" Text="Payee Name"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtPayeeName" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPayeeName"
                                                                                        ErrorMessage="Please Enter Payee Name" ValidationGroup="VCControls">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblParticulars" runat="server" Text="Particulars" Font-Bold="true"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblBankCode" runat="server" Text="Bank Code"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtBankCode" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBankCode"
                                                                                        ErrorMessage="Please Enter Bank Code" ValidationGroup="VCControls">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblBranchcode" runat="server" Text="Branch Code"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtBranchcode" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBranchcode"
                                                                                        ErrorMessage="Please Enter Branch Code" ValidationGroup="VCControls">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAccountno" runat="server" Text="Account No"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtAccountno" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAccountno"
                                                                                        ErrorMessage="Please Enter Account No" ValidationGroup="VCControls">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNet" runat="server" Text="Net"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtNet" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNet"
                                                                                        ErrorMessage="Please Enter Net" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>



                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblVat" runat="server" Text="Vat"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtVat" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVat"
                                                                                        ErrorMessage="Please Enter Vat" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>


                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAmountpayableinwords" runat="server" Text="Amount Payable in Words"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtAmountpayableinwords" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAmountpayableinwords"
                                                                                        ErrorMessage="Please Enter Amount Payable in Words" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>


                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAuthorityreferencenumber" runat="server" Text="Authority Reference Number"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtAuthorityreferencenumber" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAuthorityreferencenumber"
                                                                                        ErrorMessage="Please Enter Authority Reference Number" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>


                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblExamination" runat="server" Text="Examination" Font-Bold="true"></asp:Label></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblvoucherexaminedby" runat="server" Text="Voucher Examined By"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtvoucherexaminedby" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtvoucherexaminedby"
                                                                                        ErrorMessage="Please Enter Voucher Examined By" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadDatePicker ID="txtDate" runat="server">
                                                                                        <DateInput ID="DateInput6" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                                                        </DateInput>
                                                                                    </telerik:RadDatePicker>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate"
                                                                                        ErrorMessage="Please Enter Examination Date" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lbldepositandsuspencecertificate" runat="server" Text="Deposit and Susoence Certificate" Font-Bold="true"></asp:Label></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblDepositAccountno" runat="server" Text="Account No"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtDepositAccountNo" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDepositAccountNo"
                                                                                        ErrorMessage="Please Enter Deposit Account No" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>


                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNetDepositAccountno" runat="server" Text="Net Deposit brought forward from previous month Account No"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtNetDepositAccountno" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNetDepositAccountno"
                                                                                        ErrorMessage="Please Enter Net Deposit brought forward from previous month Account No" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNetDepositMonthKSH" runat="server" Text="Net Deposit brought forward from previous month KSH"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtNetDepositMonthKSH" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNetDepositMonthKSH"
                                                                                        ErrorMessage="Please Enter Net Deposit brought forward from previous month KSH" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCurrentMonthKSH" runat="server" Text="Less/Add: Total Payment/Receipt Current Month KSH"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtCurrentMonthKSH" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCurrentMonthKSH"
                                                                                        ErrorMessage="Please Enter Less/Add: Total Payment/Receipt Current Month KSH" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblBalanceKSH" runat="server" Text="Balance KSH"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtBalanceKSH" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtBalanceKSH"
                                                                                        ErrorMessage="Please Enter Balance KSH" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblEntryVoucher" runat="server" Text="Less: This Entry Voucher No KSH"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtEntryVoucher" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtEntryVoucher"
                                                                                        ErrorMessage="Please Enter Less: This Entry Voucher No KSH" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblDepositDate" runat="server" Text="Date"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadDatePicker ID="txtDepositDate" runat="server">
                                                                                        <DateInput ID="DateInput5" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                                                        </DateInput>
                                                                                    </telerik:RadDatePicker>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDepositDate"
                                                                                        ErrorMessage="Please Enter Authority Date" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblAuthorization" runat="server" Text="Authorization" Font-Bold="true"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAuthDate" runat="server" Text="Date"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadDatePicker ID="txtAuthDate" runat="server">
                                                                                        <DateInput ID="DateInput4" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                                                        </DateInput>
                                                                                    </telerik:RadDatePicker>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAuthDate"
                                                                                        ErrorMessage="Please Enter Authorization Date" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblOtherDetails" runat="server" Text="Other Details" Font-Bold="true"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblVote" runat="server" Text="Vote"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtVote" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtVote"
                                                                                        ErrorMessage="Please Enter Vote" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblHead" runat="server" Text="Head"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtHead" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtHead"
                                                                                        ErrorMessage="Please Enter Head" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblSubHead" runat="server" Text="Sub Head"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtSubHead" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtSubHead"
                                                                                        ErrorMessage="Please Enter Sub Head" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblSource" runat="server" Text="Source"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtSource" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtSource"
                                                                                        ErrorMessage="Please Enter Source" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblProgramme" runat="server" Text="Programme"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtProgramme" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtProgramme"
                                                                                        ErrorMessage="Please Enter Programme" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblGeographical" runat="server" Text="Geographical"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtGeographical" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtGeographical"
                                                                                        ErrorMessage="Please Enter Geographical" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtItem" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtItem"
                                                                                        ErrorMessage="Please Enter Item" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAccountOthNo" runat="server" Text="Account No"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtAccountOthNo" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtAccountOthNo"
                                                                                        ErrorMessage="Please Enter Account No" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblDeptVch" runat="server" Text="Dept. Vch"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtDeptVch" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtDeptVch"
                                                                                        ErrorMessage="Please Enter Dept. Vch" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblStation" runat="server" Text="Station"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtStation" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtStation"
                                                                                        ErrorMessage="Please Enter Station" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCashBookVchNo" runat="server" Text="Cash Book Vch. No"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtCashBookVchNo" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtCashBookVchNo"
                                                                                        ErrorMessage="Please Enter Cash Book Vch. No" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCashBookDate" runat="server" Text="Cash Book Date"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadDatePicker ID="txtCashBookDate" runat="server">
                                                                                        <DateInput ID="DateInput3" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                                                        </DateInput>
                                                                                    </telerik:RadDatePicker>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtCashBookDate"
                                                                                        ErrorMessage="Please Enter Cash Book Date" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblAmountinKSH" runat="server" Text="Amount in KSH"></asp:Label></td>
                                                                                <td valign="middle">
                                                                                    <b>:</b>
                                                                                    <telerik:RadTextBox ID="txtAmountinKSH" runat="server"></telerik:RadTextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtAmountinKSH"
                                                                                        ErrorMessage="Please Enter Amount in KSH" ValidationGroup="VCControls">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="VCControls"></asp:Button>
                                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="VCControls" />
                                                                                </td>
                                                                                <td align="left">&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel"></asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>


                                                        </ContentTemplate>
                                                    </telerik:RadWindow>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblApprovedDate" runat="server" Text="Approved Date"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadDatePicker ID="txt_ApprovedDate" runat="server" TabIndex="8" AutoPostBack="true" OnSelectedDateChanged="txt_ApprovedDate_SelectedDateChanged">
                                                <DateInput ID="DateInput2" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_txt_ApprovedDate" runat="server" ControlToValidate="txt_ApprovedDate"
                                                ErrorMessage="Approved Date is Mandatory" meta:resourcekey="rfv_rcmb_BusinessUnit"
                                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="ctl_rdtp_EffectiveDate" runat="server"
                                                ControlToCompare="txt_StartDate" ControlToValidate="txt_ApprovedDate"
                                                ErrorMessage="Approved Date cannot be less than Applied date"
                                                Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Principle Amount"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEMI" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trBrowse" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Upload Documents"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FBrowse" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTerms" runat="server" Text="Terms & Conditions"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="rtxtTermsAndCond" Height="120px" Width="350px" runat="server"
                                                Enabled="false" TextMode="MultiLine"></asp:TextBox>

                                        </td>
                                    </tr>
                                    <tr id="trCreateVoucher" runat="server" visible="false">
                                        <td>
                                            <asp:LinkButton ID="lnkCreateVoucher" runat="server" Text="Create Voucher" OnClick="lnkCreateVoucher_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:RadioButtonList ID="rbtnAgree" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="I Agree" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="DisAgree" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
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
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click"
                                                Text="Apply" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Save_Click"
                                                Text="Update" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                            &nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                            <asp:HiddenField ID="HF_ID" runat="server" />
                                        </td>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ValidationSummary ID="vs_HolidayCalendar" runat="server" meta:resourcekey="vs_HolidayCalendar"
                                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                        <td align="center">&nbsp;
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