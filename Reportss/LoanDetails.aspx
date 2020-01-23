<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="LoanDetails.aspx.cs" Inherits="Reportss_LoanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(BU, DIR, DEPT, EMP, LT, rpt) {
            //function ShowPop(BU, EMP, LT) {
            var win = window.radopen('../Reportss/LoanDetailsReport.aspx?BU=' + BU + '&DIR=' + DIR + '&DEPT=' + DEPT + '&EMP=' + EMP + '&LT=' + LT + '&RPT=' + rpt, "RadWindow1");
            //var win = window.radopen('../Reportss/LoanDetailsReport.aspx?BU=' + BU + '&EMP=' + EMP + '&LT=' + LT, "RadWindow1");
            win.center();
            win.set_modal(true);
            if (rpt == "Special Loans") {
                win.set_title("Special Loans");
            }
            else if (rpt == "Combined Loan") {
                win.set_title("Combined Loan");
            }
            else {
                win.set_title("All Loans");
            }
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

        function ShowPopup(BU, DIR, DEPT, EMP, LT, rpt, LN) {
            //function ShowPop(BU, EMP, LT) {
            var win = window.radopen('../Reportss/CarAdvanceAndMortgageLoan.aspx?BU=' + BU + '&DIR=' + DIR + '&DEPT=' + DEPT + '&EMP=' + EMP + '&LT=' + LT + '&RPT=' + rpt + '&LN=' + LN, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Car Advance And Mortgage Loan Account Statement");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <br />
                <asp:Label ID="lbl_header" runat="server" Text="Loan Report" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="200" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" Text="*"
                    ControlToValidate="rcmb_Organisation" ValidationGroup="Controls" ErrorMessage="Select Organisation">
                </asp:RequiredFieldValidator>
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
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MaxHeight="200">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Please Select Business Unit"
                    ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_BusinessUnit" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDirectorate" runat="server" Text="Directorate">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" MaxHeight="200">
                </telerik:RadComboBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_rcmb_Directorate" runat="server" ErrorMessage="Please Select Directorate" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Directorate" InitialValue="Select"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDepartment" runat="server" Text="Department">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" MaxHeight="200">
                </telerik:RadComboBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_rcmb_Department" runat="server" ErrorMessage="Please Select Department" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Department" InitialValue="Select"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lblSubDepartment" runat="server" Text="Sub-Department">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_SubDepartment" runat="server" MarkFirstMatch="true" AutoPostBack="true"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_SubDepartment" runat="server" ErrorMessage="Please Select Sub-Department" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_SubDepartment" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lblEmployee" runat="server" Text="Employee">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" ErrorMessage="Please Select Employee" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Employee" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLoanType" runat="server" Text="Loan Type">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_LoanType" runat="server" MarkFirstMatch="true" MaxHeight="200" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_LoanType_SelectedIndexChanged" AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_LoanType" runat="server" ErrorMessage="Please Select Loan Type" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_LoanType" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trLoanNo" runat="server">
            <td>
                <asp:Label ID="lblLoanNo" runat="server" Text="Loan Number">
                </asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_LoanNo" runat="server" MarkFirstMatch="true" MaxHeight="200" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_LoanNo" runat="server" ErrorMessage="Please Select Loan Number" ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_LoanNo" InitialValue="Select"></asp:RequiredFieldValidator>
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