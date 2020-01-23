<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Employee_Pay_Item.aspx.cs" Inherits="Reportss_Employee_Pay_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(url, ID, status) {
            var win = window.radopen('../Reportss/AttendanceReports.aspx?PRD=' + url + '&BU=' + ID + '&PAY=' + status, "RadWindow1");
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
            <td colspan="4">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee Pay Item"></asp:Label>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" Skin="WebBlue" MaxHeight="250px" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <td>
            <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
        </td>
        <td>
            <b>:</b>
        </td>
        <td>
            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payperiod" runat="server" Skin="WebBlue" AutoPostBack="true" MarkFirstMatch="true"
                OnSelectedIndexChanged="rcmb_payperiod_SelectedIndexChanged" Filter="Contains">
            </telerik:RadComboBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RFV_Period" runat="server" ErrorMessage="Please Select Period"
                ControlToValidate="rcmb_payperiod" Text="*" ValidationGroup="Controls" InitialValue="Select"></asp:RequiredFieldValidator>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payElements" runat="server" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_PayPeriodElements" runat="server" ErrorMessage="Please Select Period Elements"
                    ControlToValidate="rcmb_payElements" Text="*" ValidationGroup="Controls" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_PayItems" runat="server" Text="Pay Item Name"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Payitems" runat="server" Skin="WebBlue" MaxHeight="250px" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_Payitems" runat="server" ErrorMessage="Please Select Pay Item"
                    ControlToValidate="ddl_Payitems" Text="*" ValidationGroup="Controls" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" Height="26px" OnClick="btn_Submit_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <center>
        <rsweb:ReportViewer ID="RPT_EmpPayItems" runat="server" Width="950px" Height="518px"
            ShowParameterPrompts="false" ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </center>
</asp:Content>