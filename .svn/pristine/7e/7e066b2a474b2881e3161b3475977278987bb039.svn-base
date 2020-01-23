<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="ContractExpiry.aspx.cs" Inherits="Reportss_ContractExpiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(ID, BU, SD, ED) {
            var win = window.radopen('../Reportss/ContractExpiryReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&SD=' + SD + '&ED=' + ED, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
    <script type="text/javascript">
        function OnKeyPress(sender, args) {
            var re = /^[0-9\-\:\/]$/;
            args.set_cancel(!re.test(args.get_keyCharacter()));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Contract Expiry Report" Font-Bold="true"
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
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmb_Organisation" ValidationGroup="Controls" ErrorMessage="Select Organisation">
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
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select"
                    Text="*" ValidationGroup="Controls" ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Select Business Unit">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDate" runat="server" Width="190px" AutoPostBack="true"
                    OnSelectedDateChanged="rdpStartDate_OnSelectedDateChanged" DateInput-ClientEvents-OnKeyPress="OnKeyPress">
                </telerik:RadDatePicker>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <%--<telerik:RadDatePicker ID="rdpEndDate" runat="server" Width="190px"></telerik:RadDatePicker>--%>
                <telerik:RadDatePicker ID="rdpEndDate" runat="server" Width="190px" DateInput-ClientEvents-OnKeyPress="OnKeyPress">
                </telerik:RadDatePicker>
            </td>
            <td></td>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EmployeeDetails" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>