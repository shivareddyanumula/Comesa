<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="24Q.aspx.cs" Inherits="Reportss_24Q" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(url, ID, BU, date) {
            var win = window.radopen('../Reportss/24QReport.aspx?PRD=' + url + '&ORG_ID=' + ID + '&BU=' + BU + '&PRDDTL=' + date, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" AutoPostBack="true" Filter="Contains"
                    MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Organisation_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" Text="*" ControlToValidate="rcmb_Organisation"
                    ValidationGroup="Controls" ErrorMessage="Select Organisation">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="BusinessUnit">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" Text="*"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" ErrorMessage="Select BusinessUnit">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_FromDate" runat="server" Text="From Date">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_FromDate" runat="server"
                    DateInput-DateFormat="dd/MM/yyyy"
                    OnSelectedDateChanged="rdp_FromDate_SelectedDateChanged">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_FromDate" runat="server" Text="*"
                    ControlToValidate="rdp_FromDate" ValidationGroup="Controls" ErrorMessage="Select Start Date">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_ToDate" runat="server" Text="To Date">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <%--<telerik:RadDatePicker ID="rdp_ToDate" runat="server" DateInput-DateFormat="dd/MM/yyyy"></telerik:RadDatePicker>--%>
                <telerik:RadTextBox ID="rtxt_ToDate" runat="server">
                </telerik:RadTextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ToDate" runat="server" Text="*"
                    ControlToValidate="rtxt_ToDate" ValidationGroup="Controls" ErrorMessage="Select End Date">
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
                    ValidationGroup="Controls" OnClick="btn_Generate_Click" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Absentees" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>