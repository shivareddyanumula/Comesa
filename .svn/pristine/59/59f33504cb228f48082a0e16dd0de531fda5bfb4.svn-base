<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Forecast.aspx.cs" Inherits="Reportss_Forecast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(PD) {
            var win = window.radopen('../Reportss/ForecastReport.aspx?PD=' + PD, "RW_Forecast");
            win.center();
            win.set_modal(true);
            win.set_title("Forecast Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Forecast" Font-Bold="true" Font-Size="11pt"
                    Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" Enabled="false"
                    MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_FinancialPeriod" runat="server" Text="*" Display="Dynamic"
                    ErrorMessage="Please Select Financial Period" ControlToValidate="rcmb_Financialperiod"
                    InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_EstablishmentVacantPositions" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>