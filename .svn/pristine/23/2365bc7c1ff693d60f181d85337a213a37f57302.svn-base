<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="DependentsInformationReoprt.aspx.cs" Inherits="Reportss_DependentsInformationReoprt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, ID, status) {
            var win = window.radopen('../Reportss/DependentsInformationReports.aspx?PRD=' + url + '&BU=' + ID + '&DEPT=' + status, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Dependents Information Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Dependents Information Report"
                    Font-Bold="True" Font-Names="Arial" Font-Size="11pt"></asp:Label>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" Filter="Contains"
                    AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcb_Department" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_PeriodElements0" runat="server" Text="Period "></asp:Label>
            </td>
            <td>&nbsp;
            </td>
            <td>
                <telerik:RadDatePicker ID="RadPeriod" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadPeriod"
                    ErrorMessage="Please select Period" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                    Height="26px" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                    ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <%--  <center>
        <rsweb:ReportViewer ID="RPT_DependentReport" runat="server" Width="950px" Height="518px"
            ShowParameterPrompts="false" ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </center>--%>
</asp:Content>