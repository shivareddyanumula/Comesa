<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="RegstrUnRegstrAccStmts.aspx.cs" Inherits="Reportss_RegstrUnRegstrAccStmts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ORG, BU, PRD, empID, rpt) {
            //var win = window.radopen('../Reportss/RegstrUnRegstrAccStmtsReport.aspx?ORG=' + ORG + '&BU=' + BU + ' &PRD=' + PRD + '&empID=' + empID, "RadWindow1");
            var win = window.radopen('../Reportss/RegstrUnRegstrAccStmtsReport.aspx?ORG=' + ORG + '&BU=' + BU + '&PRD=' + PRD + '&empID=' + empID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Register And Unregister Account Statements");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopup(ORG, BU, PRD, empID, rpt) {
            //var win = window.radopen('../Reportss/RegstrUnRegstrAccStmtsReport.aspx?ORG=' + ORG + '&BU=' + BU + ' &PRD=' + PRD + '&empID=' + empID, "RadWindow1");
            var win = window.radopen('../Reportss/RegstrUnRegstrAccStmtsReport.aspx?ORG=' + ORG + '&BU=' + BU + '&PRD=' + PRD + '&empID=' + empID + '&RPT=' + rpt, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee and Employer Pension Contribution");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MaxHeight="200" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please Select Business Unit" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" ControlToValidate="rcmb_Period" Text="*" ErrorMessage="Please Select Period" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" MaxHeight="200" MarkFirstMatch="true" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" ControlToValidate="rcmb_Employee" ErrorMessage="Please Select Employee" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <br />
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" ValidationGroup="Controls" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Summary" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
</asp:Content>