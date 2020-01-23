<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmployeeLeaveDetails.aspx.cs" Inherits="Reportss_EmployeeLeaveDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(from, to, ID) {
            var win = window.radopen('../Reportss/EmployeeLeaveDetailsReport.aspx?FROM=' + from + '&TO=' + to + '&BU=' + ID, "RadWindow1");
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
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Leave Details" Font-Bold="True"
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server"
                    MarkFirstMatch="true" AutoPostBack="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_FromDate" runat="server" Text="Start Date"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadDatePicker ID="rd_FromDate" runat="server">
                    <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    <DateInput runat="server" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy">
                    </DateInput>
                </telerik:RadDatePicker>
            </td>
            <td>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rd_FromDate"
                    ErrorMessage="Please select Start Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_ToDate" runat="server" Text="End Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rd_ToDate" runat="server">
                    <Calendar runat="server" UseRowHeadersAsSelectors="false" UseColumnHeadersAsSelectors="false" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" />
                    <DateInput runat="server" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy">
                    </DateInput>
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rd_ToDate"
                    ErrorMessage="Please select To Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <%--<center>
        <rsweb:ReportViewer ID="RPT_EmployeeLeavesDetails" runat="server" Width="950px"
            Height="518px" ShowParameterPrompts="false" ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </center>--%>
</asp:Content>