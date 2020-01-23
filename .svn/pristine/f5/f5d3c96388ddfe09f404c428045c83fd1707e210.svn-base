<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Form6A.aspx.cs" Inherits="Reportss_Form6A" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(url, date, ID) {
            var win = window.radopen('../Reportss/Form6AReport.aspx?PRD=' + url + '&EDATE=' + date + '&ORG_ID=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Form 6A");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Form 6A Report" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select Organisation" ControlToValidate="rcmb_Organisation">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" 
                    EnableEmbeddedSkins="false" AutoPostBack="true" onselectedindexchanged="rcmb_Period_SelectedIndexChanged" 
                    >
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lbl_StartDate" runat="server" Text="From Date">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_StartDate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select From Date" ControlToValidate="rdp_StartDate">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_EndDate" runat="server" Text="To Date">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdp_EndDate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_EndDate" runat="server" Text="*"
                    ValidationGroup="Controls" ErrorMessage="Select To Date" ControlToValidate="rdp_EndDate">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
        <td>
        <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements">
        </asp:Label>
        </td>
        <td>
        <b>:</b>
        </td>
        <td>
        <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" AutoPostBack="true"
        EnableEmbeddedSkins="false">
        </telerik:RadComboBox>
        </td>
        <td></td>
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
                    OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Form6A" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>