<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmGratuityReportSS.aspx.cs" Inherits="Reportss_frmGratuityReportSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup(buID, prdDtlID) {
            var win = window.radopen('../Reportss/frmGratuityReportSSReports.aspx?ssBU=' + ID + '&ssPrdDtlID=' + prdDtlID, "RadWindow1");
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
                <asp:Label ID="lbl_Header" runat="server" Text="Gratuity Report – Sun Systems" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbOrg" runat="server" Enabled="false" MarkFirstMatch="true" Filter="Contains">
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcbBU" MarkFirstMatch="true"
                    runat="server" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvBU" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcbBU" ValidationGroup="Controls"
                    ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td align="left">
                <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcbPeriod" runat="server" AutoPostBack="True" Filter="Contains"
                    MarkFirstMatch="true" OnSelectedIndexChanged="rcbPeriod_SelectedIndexChanged"
                    Skin="WebBlue" MaxHeight="120px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" ControlToValidate="rcbPeriod" InitialValue="Select"
                    ErrorMessage="Please select Period" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblPrdDtl" runat="server" Text="Period Details"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcbPrdDtl" runat="server" InitialValue="Select"
                    MarkFirstMatch="true" Skin="WebBlue" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPrdDtl" runat="server" ControlToValidate="rcbPrdDtl" InitialValue="Select"
                    ErrorMessage="Please select Period Details" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowSummary="false"
                    ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <telerik:RadWindow runat="server" ID="rwGratuityReportSS" VisibleOnPageLoad="false"
        Behaviors="Maximize, Close" Modal="true" Width="800px" Height="600px"
        Title="Gratuity Report – Sun Systems">
        <ContentTemplate>
            <asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="~/Images/xl.jpg"
                OnClick="imgBtnExcel_Click" Text="Export to Excel" />
            <telerik:RadGrid runat="server" ID="rgGratuityReportSS" Width="100%"
                OnNeedDataSource="rgGratuityReportSS_NeedDataSource">
            </telerik:RadGrid>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>