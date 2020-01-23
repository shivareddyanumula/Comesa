<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="PF_contribution.aspx.cs" Inherits="Reportss_PF_contribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(url, emp, ID, status, sal) {

            var win = window.radopen('../Reportss/PF_contributionReport.aspx?PRD=' + url + '&PERIODELEMENT=' + emp + '&BU=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("PF Contribution");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="PF Contribution Report" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" InitialValue="Select"
                    ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please select Business Unit" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Period" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" InitialValue="Select"
                    ControlToValidate="rcmb_Period" ErrorMessage="Please select Period" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_PeriodElements" runat="server" Skin="WebBlue"
                    AutoPostBack="true" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElements" runat="server" InitialValue="Select"
                    ControlToValidate="rcmb_PeriodElements" ErrorMessage="Please select Period Element" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <br />
                <asp:Button ID="btn_Generate" runat="server" Text="Generate"
                    ValidationGroup="Controls" OnClick="btn_Generate_Click" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
                <br />
                <asp:ValidationSummary ID="VS_Payslip" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <%--<table align="center" width="100%">
        <tr>
            <td>
                <rsweb:ReportViewer ID="rvPFcontribution" runat="server" Width="100%">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>--%>
</asp:Content>