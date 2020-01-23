<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Resignation_Report.aspx.cs" Inherits="Reportss_Resignation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(from, to, ID) {
            var win = window.radopen('../Reportss/ResignationReport.aspx?From=' + from + '&To=' + to + '&BU=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Resignation Details Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Resignation Report" Style="font-weight: 700; font-size: small"></asp:Label>
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
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false" Filter="Contains">
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" AutoPostBack="true"
                    runat="server" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="ddl_BusinessUnit" ErrorMessage="Select Business Unit" ValidationGroup="Controls">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" EnableEmbeddedSkins="false">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Department" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_Department" ErrorMessage="Select Department" ValidationGroup="Controls">
                </asp:RequiredFieldValidator>
            </td>
        </tr>--%>
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
                <%--<asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" Text="*" ControlToValidate="rdp_StartDate"
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
                <%--<asp:RequiredFieldValidator ID="rfv_EndDate" runat="server" Text="*" ControlToValidate="rdp_EndDate"
                    ValidationGroup="Controls" ErrorMessage="Select To Date"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <%-- <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" EnableEmbeddedSkins="false"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Period" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_Period" ErrorMessage="Select Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPeriodElement" runat="server" Text="Period Element">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PeriodElement" runat="server" EnableEmbeddedSkins="false">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_PeriodElement" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_PeriodElement" ErrorMessage="Select Period Element" ValidationGroup="Controls">
                </asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_StartDate" runat="server" Text="Start Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker  EnableEmbeddedSkins="false" ID="txt_StartDate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txt_StartDate" ErrorMessage="Please select Start Date" 
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_EndDate" runat="server" Text="End Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker  EnableEmbeddedSkins="false" ID="txt_EndDate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txt_EndDate" ErrorMessage="Please select End Date" 
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" ValidationGroup="Controls"
                    OnClick="btn_Submit_Click" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <%--<center>
        <rsweb:ReportViewer ID="RPT_ResignationReport" runat="server" Width="950px" ProcessingMode="Remote"
            ShowBackButton="True" Height="490px" ShowParameterPrompts="False">
        </rsweb:ReportViewer>
    </center>--%>
    <br />
</asp:Content>