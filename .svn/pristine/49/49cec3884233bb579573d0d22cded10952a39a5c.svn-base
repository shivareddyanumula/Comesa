<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Payrolldetails.aspx.cs" Inherits="Payroll_frm_Payrolldetails" Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">        
        function validation() {
             var hfEmpCnt = document.getElementById('<%= hfEmpCnt.ClientID %>');            
            if (hfEmpCnt.value != "0") {
                if (confirm("Employees with status - Updated or Confirmed(after Update) are still in pending for Approval and are not eligible for payroll process. Do you want to continue..? ") == true)
                    return true;
                else
                    return false;
            }
        }
    </script>
    <script type="text/javascript">
        // FOR SHOWING THE RESULT OF EMPLOYEES WHO ARE UNDER THAT PERIOD (CALLING REPORT)
        function ShowPopForm(ORG, BU, PRD, PRDDTL, paytran, Localisation) {
            var win = window.radopen('../Reportss/PreApprovalPayRegisterReport.aspx?ORG=' + ORG + '&BU=' + BU + '&PRD=' + PRD + '&PRDDTL=' + PRDDTL + '&PAYTRAN=' + paytran + '&Localisation=' + Localisation, "RW_TranDetails");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function Close() {
            GetRadWindow().Close();
        }
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

        // FOR VALIDATING THE SALARY STRUCTURE CHECKBOXES ATLEAST ONE IS CHECKED OR NOT
        //        function ValidateCheckboxlist(source, args) {
        //            var chkListSal = document.getElementById('<%= chklst_Salarystruct.ClientID %>');
        //            var chkListinputs = chkListSal.getElementsByTagName("input");
        //            for (var i = 0; i < chkListinputs.length; i++) {
        //                if (chkListinputs[i].checked) {
        //                    args.IsValid = true;
        //                    return;
        //                }
        //            }
        //            args.IsValid = false;
        //        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:HiddenField runat="server" ID="hfEmpCnt" Value="0" />
    <table align="center">
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Heading" runat="server" Text="Payroll Process" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <telerik:RadMultiPage ID="RMP_Payrolldetails" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RP_RunPayroll" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RFV_Businessunit" runat="server" Text="*" Display="Dynamic"
                                        ErrorMessage="Please Select Businessunit" ControlToValidate="rcmb_Businessunit"
                                        InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Financialperiod_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RFV_FinancialPeriod" runat="server" Text="*" Display="Dynamic"
                                        ErrorMessage="Please Select Financial Period" ControlToValidate="rcmb_Financialperiod"
                                        InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Period" MarkFirstMatch="true" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" Display="Dynamic"
                                        ErrorMessage="Please Select Period" ControlToValidate="rcmb_Period" InitialValue="Select"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr id="Salstruct" runat="server">
                                <td colspan="4" align="center">
                                    <asp:CheckBoxList ID="chklst_Salarystruct" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="3" AutoPostBack="true" OnSelectedIndexChanged="chklst_Salarystruct_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </td>
                                <td>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr id="PayrollProcees" runat="server">
                                <td colspan="5" align="center">
                                    <asp:Button ID="btn_Runpayroll" runat="server" Text="Run Payroll Process" OnClick="btn_Runpayroll_Click"
                                        OnClientClick="javascript:return validation();" ValidationGroup="Controls" />
                                    <%-- UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')"--%>
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_RecordIncident" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                            <tr id="Grid" runat="server">
                                <td colspan="5">
                                    <telerik:RadGrid ID="rg_Payrolldetails" runat="server" AutoGenerateColumns="false">
                                        <MasterTableView CommandItemDisplay="None">
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="PayTran Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("TEMP_PAYTRAN_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn HeaderText="PayTran Name" DataField="TEMP_PAYTRAN_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Details">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtn_View" Text="View Details" runat="server" CommandArgument='<%#Eval("TEMP_PAYTRAN_ID") %>'
                                                            OnCommand="lnkbtn_View_Command">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtn_Rollback" runat="server" Text="RollBack" CommandArgument='<%#Eval("TEMP_PAYTRAN_ID") %>'
                                                            OnCommand="lnkbtn_Rollback_Command"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>