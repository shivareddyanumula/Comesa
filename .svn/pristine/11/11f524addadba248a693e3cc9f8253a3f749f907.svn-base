<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="LeaveEncashment.aspx.cs" Inherits="Reportss_LeaveEncashment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, ID, BU, emp) {
            var win = window.radopen('../Reportss/LeaveEncashmentReport.aspx?PRD=' + url + '&ORG_ID=' + ID + '&BU=' + BU + '&EMP=' + emp, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Leave Encashment Report" Font-Bold="true"
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
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true" Filter="Contains"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Organisation_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select Organisation" ControlToValidate="rcmb_Organisation">
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
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select Business Unit" ControlToValidate="rcmb_BusinessUnit">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_Employee" runat="server" Text="Employee">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" 
                    AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" InitialValue="Select" Text="*"
             ValidationGroup="Controls" ErrorMessage="Select Employee" ControlToValidate="rcmb_Employee">
             </asp:RequiredFieldValidator>
            </td>
        </tr--%>
        <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Period" runat="server" InitialValue="Select" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select Period" ControlToValidate="rcmb_Period">
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click" ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_LeaveEncashment" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>