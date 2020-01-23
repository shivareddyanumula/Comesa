<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Employee_AssetReport.aspx.cs" Inherits="Reportss_Employee_AssetReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(ID, status) {
            var win = window.radopen('../Reportss/EmployeeAsset_Report.aspx?BU=' + ID + '&EMP=' + status, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Asset Report" Style="font-weight: 700; font-size: small"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_employee" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="rcmb_employee" ErrorMessage="Please select Employee"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate"
                    OnClick="btn_Submit_Click" ValidationGroup="Controls" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <center>
        <rsweb:ReportViewer ID="RPT_EmployeeAssetReport" runat="server" Width="950px" ProcessingMode="Remote"
            ShowBackButton="True" Height="490px" ShowParameterPrompts="False">
        </rsweb:ReportViewer>
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>