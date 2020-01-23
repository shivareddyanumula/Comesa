<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeAgeandGenderWise.aspx.cs" Inherits="Reportss_EmployeeAgeandGenderWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(ID, BU, dept) {
            var win = window.radopen('../Reportss/EmployeeAgeandGenderWiseReport.aspx?ORG_ID=' + ID + '&BU=' + BU, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Age and Gender Wise Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Employee Age and Gender Wise Report" Font-Bold="true"
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
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Organisation_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" ControlToValidate="rcmb_Organisation" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select Organisation" InitialValue="Select">
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
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ValidationGroup="Controls" InitialValue="Select"
                    Text="*" ErrorMessage="Select Business Unit" ControlToValidate="rcmb_BusinessUnit">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--  <tr>
        <td>
        <asp:Label ID="lbl_Department" runat="server" Text="Department">
        </asp:Label>
        </td>
        <td>
        <b>:</b>
        </td>
        <td>
        <telerik:RadComboBox ID="rcmb_Department" runat="server" AutoPostBack="true" MarkFirstMatch="true">
        </telerik:RadComboBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="rfv_Department" runat="server" InitialValue="Select" Text="*"
         ControlToValidate="rcmb_Department" ValidationGroup="Controls" ErrorMessage="Select Department">
         </asp:RequiredFieldValidator>
        </td>
        </tr>--%>
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
                    OnClick="btn_Cancel_Click" Style="height: 26px" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmployeeAgeAndGenderWise" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>