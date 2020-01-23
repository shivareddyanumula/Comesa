<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_SalaryProgression.aspx.cs" Inherits="Reportss_frm_SalaryProgression" %>

<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(buID, dir, dept, emp) {
            var win = window.radopen('../Reportss/frm_SalaryProgressionReport.aspx?BU=' + buID + '&DIR=' + dir + '&DEPT=' + dept + '&EMP=' + emp, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Salary Progression Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <br />
                <asp:Label ID="lblHeader" runat="server" Font-Bold="true" Text="Salary Progression"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td style="width: 152px">
                <asp:Label ID="lblOrganisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <telerik:RadComboBox ID="rcmbOrganisation" runat="server" Enabled="false" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3" style="width: 150px">
                <uc1:BUFilter runat="server" ID="BUFilter1" ShowBusinessUnitSpan="true" ShowEmployeeSpan="true" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" ValidationGroup="Controls" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsEmployeeInfo" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>