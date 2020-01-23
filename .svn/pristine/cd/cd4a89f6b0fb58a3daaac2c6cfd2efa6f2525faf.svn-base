<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Death_Employees.aspx.cs" Inherits="Reportss_Death_EmployeesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(from, to, ID, BU) {
            var win = window.radopen('../Reportss/Death_EmployeesReport.aspx?From=' + from + '&To=' + to + '&ORG_ID=' + ID + '&BU=' + BU, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Death Employees Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Death Employee Report" Font-Bold="true"
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
                <%-- <asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" Text="*" ControlToValidate="rdp_StartDate"
                    ValidationGroup="Controls" ErrorMessage="Select From Date"></asp:RequiredFieldValidator>--%>
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
                <%-- <asp:RequiredFieldValidator ID="rfv_EndDate" runat="server" Text="*" ControlToValidate="rdp_EndDate"
                    ValidationGroup="Controls" ErrorMessage="Select To Date"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_chk" runat="server" Text="Include"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:CheckBox ID="chk_Include" runat="server" OnCheckedChanged="chk_Include_CheckedChanged" />
            </td>
            <td>
            </td>
        </tr>--%>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true"
                     AutoPostBack="true" onselectedindexchanged="rcmb_Period_SelectedIndexChanged" 
                    >
                </telerik:RadComboBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="rfv_Period" runat="server" ControlToValidate="rcmb_Period" InitialValue="Select"
             Text="*" ValidationGroup="Controls" ErrorMessage="Select Period"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_DeathEmployeeDetails" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>