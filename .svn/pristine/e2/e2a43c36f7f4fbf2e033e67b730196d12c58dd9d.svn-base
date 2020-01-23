<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeDueIncrement.aspx.cs" Inherits="Reportss_EmployeeDueIncrement_" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(ID, BU, FP, IM, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&FP=' + FP + '&IM=' + IM + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Employee Due Increment");

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopB(ID, BU, BNK, BN, FP, PE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&BNK=' + BNK + '&BN=' + BN + '&FP=' + FP + '&PE=' + PE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');

            win.set_title("Transfer Due by Bank");


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopD(ID, BU, VC, FP, PE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&VC=' + VC + '&FP=' + FP + '&PE=' + PE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');

            win.set_title("Deduction Group Summary");


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopS(ID, BU, PI, FP, PE, TYP, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&PI=' + PI + '&FP=' + FP + '&PE=' + PE + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

           
            if (TYP == "4") {
                win.set_title("Deduction Summary");
            }
            if (TYP == "5") {
                win.set_title("Employee Deduction");
            }
            if (TYP == "6") {
                win.set_title("Employee Benefits");
            }
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopGN(ID, BU, ST, FP, PE, TYP, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&ST=' + ST + '&FP=' + FP + '&PE=' + PE + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');
            if (TYP == "8") {
                win.set_title("Employee List By Gross Monthly Salary");
            }
            else {
                win.set_title("Employee List By Net Salary");
            }


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopBS(ID, BU, ST, FP, TYP, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&ST=' + ST + '&FP=' + FP + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            if (TYP == "10") {
                win.set_title("Employee List By Basic Salary");
            }
            if (TYP == "12") {
                win.set_title("Employee List By Gross Annual Salary");
            }
           
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopST(ID, BU, PI, FP, PE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&PI=' + PI + '&FP=' + FP + '&PE=' + PE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Statutory Deduction");


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopEOP(ID, BU, FP, PE, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&FP=' + FP + '&PE=' + PE + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            if (RPTNAME == "13") {
                win.set_title("Employees On Payroll");
            }
            else {
                win.set_title("Employees Excluded From Payroll");
            }


            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

        function ShowPopSts45(ID, BU, PI, FP, PE, sts, TYP, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&PI=' + PI + '&FP=' + FP + '&PE=' + PE + '&Sts=' + sts + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            if (TYP == "3")
            {
                win.set_title("Benefit Summary");
            }

            else if (TYP == "4") {
                win.set_title("Deduction Summary");
            }
            else {
                win.set_title("Employee Deduction");
            }
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopSts9(ID, BU, ST, FP, PE, sts, TYP, RPTNAME) {

            var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&ST=' + ST + '&FP=' + FP + '&PE=' + PE + '&Sts=' + sts + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');

             win.set_title("Employee List By Net Salary");

             win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
         }
         function ShowPopSts10(ID, BU, ST, FP, sts, TYP, RPTNAME) {

             var win = window.radopen('../Reportss/EmployeeDueIncrementReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&ST=' + ST + '&FP=' + FP + '&Sts=' + sts + '&TYP=' + TYP + '&RPTNAME=' + RPTNAME, "RadWindow1");
             win.center();
             win.set_modal(true);

             win.set_title("Employee List By Basic Salary");
             win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
                <br />
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Please Select Business Unit"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trSalStruct" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_SalStruct" runat="server" Text="Salary Structure"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>

                <asp:RequiredFieldValidator ID="rfv_SalStruct" runat="server" ErrorMessage="Please Select Salary Structure"
                    ControlToValidate="rcmb_SalStruct" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trVoteCode" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_VoteCode" runat="server" Text="Vote Code"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_VoteCode" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_VoteCode" runat="server" ErrorMessage="Please Select Vote Code"
                    ControlToValidate="rcmb_VoteCode" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trPayItem" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_PayItem" runat="server" Text="Pay Item"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PayItem" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_PayItem" runat="server" ErrorMessage="Please Select Pay Item"
                    ControlToValidate="rcmb_PayItem" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trBank" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_Bank" runat="server" Text="Bank"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Bank" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Bank_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBank" runat="server" ErrorMessage="Please Select Bank"
                    ControlToValidate="rcmb_Bank" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trBranch" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_Branch" runat="server" Text="Branch Name"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Branch" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr id="trFinancialperiod" runat="server" visible="True">
            <td>
                <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_FinancialPeriod" runat="server" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_FinancialPeriod_SelectedIndexChanged"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvFinancialPeriod" runat="server" ErrorMessage="Please Select Financial Period"
                    ControlToValidate="rcmb_FinancialPeriod" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">

                </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr id="trIncrementMonth" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_IncrementMonth" runat="server" Text="Increment Month"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_IncrementMonth" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_IncrementMonth" runat="server" ErrorMessage="Please Select Increment Month"
                    ControlToValidate="rcmb_IncrementMonth" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*"> 
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trPeriodElements" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcmb_PeriodElements"
                    ErrorMessage="Please Select Period Elements" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status">
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl" runat="server" Text=":" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbStatus" runat="server" MarkFirstMatch="true" MaxHeight="200">
                    <Items>
                        <telerik:RadComboBoxItem Text="Select" Value="-1" />
                        <telerik:RadComboBoxItem Text="Approved" Value="1" />
                        <telerik:RadComboBoxItem Text="Pending" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcbStatus" ValidationGroup="Controls" ErrorMessage="Please Select Status">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmployeeDueIncrement" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>