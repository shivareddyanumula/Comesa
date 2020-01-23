<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Dynamic.aspx.cs" Inherits="Reportss_Dynamic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ID, BU, CLMS) {
            var win = window.radopen('../Reportss/DynamicRepor.aspx?ORG_ID=' + ID + '&BU=' + BU + '&CLMS=' + CLMS, "RadWindow1");

            win.center();
            win.set_modal(true);
            win.set_title("Dynamic Report")

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="3" align="center">
                <br />
                <asp:Label ID="lblHeading" runat="server" Text="Dynamic Report" Font-Bold="true"></asp:Label>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td><b>:
            </b></td>
            <td>
                <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="150" Width="200px" Filter="Contains"></telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="rfvBusinessunit" runat="server" InitialValue="Select" ControlToValidate="rcmbBusinessUnit" ErrorMessage="Please select Business Unit" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:CheckBox ID="chkcheckall" Text="Check all" TextAlign="Right" AutoPostBack="True" OnCheckedChanged="chkSelectAll_CheckedChanged" runat="server" /></td>
        </tr>

        <tr>
            <td align="justify">
                <asp:Label ID="lblColumns" runat="server" Text="Employee By"></asp:Label>
            </td>
            <td><b>:
            </b></td>
            <td>
                <%-- <telerik:RadComboBox ID="rcmbColumns" runat="server" MarkFirstMatch="true" MaxHeight="150"></telerik:RadComboBox>--%>
                <telerik:RadListBox ID="RLB_Colums" runat="server" CheckBoxes="true" ShowCheckAll="true"
                    Height="150px" Width="200px" Filter="Contains">
                </telerik:RadListBox>
                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            </td>

        </tr>
    </table>
    <table align="center">
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td align="center">
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" Width="75px" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" Width="75px" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_BusinessUnit" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Controls" />
</asp:Content>