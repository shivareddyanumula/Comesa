<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="PensionBalances.aspx.cs" Inherits="Reportss_PensionBalances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        <%--function ShowPoppb(ORG_ID, BU, SALS, EMP, CP, CRTL) {

            var win = window.radopen('../Reportss/PensionBalancesReport.aspx?ORG_ID=' + ORG_ID + '&BU=' + BU + '&SALS=' + SALS + '&EMP=' + EMP + '&CP=' + CP + '&CRTL=' + CRTL, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');

            win.set_title("Pension Balances");


             win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }--%>
        function ShowPopmbs(ORG_ID, BU, SALS, EMP, FP, CRTL) {

            var win = window.radopen('../Reportss/PensionBalancesReport.aspx?ORG_ID=' + ORG_ID + '&BU=' + BU + '&SALS=' + SALS + '&EMP=' + EMP + '&FP=' + FP + '&CRTL=' + CRTL, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');
            if (CRTL == " Provident Fund Balances")
                win.set_title("Pension Balances");
            else
                win.set_title("Member Benefit Statement");


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
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Business Unit is Mandatory"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_SalaryStructure" runat="server" Text="Salary Structure"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_SalStruct_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Salarystructure" runat="server" ErrorMessage="Salary Structure is Mandatory"
                    ControlToValidate="rcmb_SalStruct" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Employeename" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_EmployeeName" runat="server" HighlightTemplatedItems="True" Filter="Contains"
                    Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeName" runat="server" ControlToValidate="rcmb_EmployeeName"
                    ErrorMessage="Employee Name is Mandatory" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnit" ValidationGroup="Controls" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lbl_FinancialPeriod" runat="server" Text="Financial period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_FinancialPeriod" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Financialperiod" runat="server" ErrorMessage="Financial Period is Mandatory "
                    ControlToValidate="rcmb_FinancialPeriod" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
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