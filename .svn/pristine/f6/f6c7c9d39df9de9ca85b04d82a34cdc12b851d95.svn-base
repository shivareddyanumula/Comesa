<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmployeeInformation.aspx.cs" Inherits="Reportss_EmployeeInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(ID, emp) {
            var win = window.radopen('../Reportss/EmployeeInformationReport.aspx?BU=' + ID + '&EMP=' + emp, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Information Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Employee Information"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblOrganisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbOrganisation" runat="server" Enabled="false" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmbBusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBusinessUnit" runat="server" ControlToValidate="rcmbBusinessUnit"
                    ErrorMessage="Please Select Business Unit" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbEmployee" runat="server" MaxHeight="200px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmployee" runat="server" ControlToValidate="rcmbEmployee"
                    ErrorMessage="Please Select Employee" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" ValidationGroup="Controls" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsEmployeeInfo" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>