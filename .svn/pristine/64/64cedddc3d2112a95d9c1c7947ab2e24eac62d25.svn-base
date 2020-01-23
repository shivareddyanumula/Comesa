<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="PensionComputation.aspx.cs" Inherits="Reportss_PensionComputation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ORG, BU, DIR, DEP, empID) {
            var win = window.radopen('../Reportss/PensionComputationReport.aspx?ORG=' + ORG + '&BU=' + BU + '&DIR=' + DIR + '&DEP=' + DEP + '&empID=' + empID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Pension Computation");
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
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Height="200">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" ControlToValidate="rcmb_BusinessUnit" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit" InitialValue="Select" runat="server"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblDirectorate" runat="server" Text="Directorate"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true" Height="200" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" ControlToValidate="rcmb_Employee" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Employee" InitialValue="Select" runat="server"></asp:RequiredFieldValidator>
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
    <asp:ValidationSummary ID="vs_summary" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
</asp:Content>