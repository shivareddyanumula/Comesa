<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmpTypeWiseLoanBalance.aspx.cs" Inherits="Reportss_EmpTypeWiseLoanBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(EMPT) {
            var win = window.radopen('../Reportss/EmpTypeWiseLoanBalanceReport.aspx?EMPT=' + EMPT, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Type Wise Loan Balance");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <br />
                <asp:Label ID="lbl_header" runat="server" Text="Employee Type wise Loan Balance Report" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_EmployeeType" runat="server" Text="Employee Type">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="200" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_EmployeeType" ValidationGroup="Controls" ErrorMessage="Please Select Employee Type">
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate"
                    OnClick="btn_Generate_Click" ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_LoanDetails" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>