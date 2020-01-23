<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmpLoans.aspx.cs" Inherits="Reportss_EmpLoans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, ID) {
            var win = window.radopen('../Reportss/AttendanceReports.aspx?EMP=' + url + '&BU=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Loans/Advances"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Employee" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" OnSelectedIndexChanged="ddl_Employee_SelectedIndexChanged" Filter="Contains"
                    Style="height: 22px">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                    ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
        </tr>
        <br />
        <%--<center>
                    <rsweb:ReportViewer ID="RPT_LoanDetails" runat="server" Width="900px" ShowParameterPrompts="False"
                        ProcessingMode="Remote" ToolBarItemBorderColor="Black" ToolBarItemBorderStyle="None"
                        ToolBarItemBorderWidth="2px" BackColor="Silver" BorderColor="#333333" DocumentMapWidth="40%"
                        Font-Names="Arial" Font-Size="9pt" Height="600px">
                    </rsweb:ReportViewer>
                </center>--%>
        <br />
        </td>
        <td>
        &nbsp;
    </table>
</asp:Content>