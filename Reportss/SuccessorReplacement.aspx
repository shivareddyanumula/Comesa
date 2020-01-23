<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="SuccessorReplacement.aspx.cs" Inherits="Reportss_SuccessorReplacement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop(BU, FMDT, T0DT, RPT) {
            var win = window.radopen('../Reportss/SuccessorReplacementReport.aspx?BU=' + BU + '&FRMDT=' + FMDT + '&TODT=' + T0DT + '&RPT=' + RPT, "RW_SuccessorReplacement");
            win.center();
            win.set_modal(true);
            //win.set_title("Successor Replacement Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true" Enabled="false">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select"
                    Text="*" ControlToValidate="rcmb_Organisation" ValidationGroup="Controls" ErrorMessage="Select Organisation">
                </asp:RequiredFieldValidator>
            </td>
        </tr>--%>
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
                    Text="*" ValidationGroup="Controls" ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please Select Business Unit">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_frmdate" runat="server" Text="From Date"> </asp:Label></td>
            <td><strong>:</strong></td>
            <td>
                <telerik:RadDatePicker ID="rdt_StartDate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpStartDate" runat="server" ControlToValidate="rdt_StartDate"
                    ErrorMessage="Please Select From Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_todate" runat="server" Text="To Date"> </asp:Label>
            </td>
            <td><strong>:</strong>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdt_todate" runat="server">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdt_todate"
                    ErrorMessage="Please Select To Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <asp:CompareValidator ID="CompareValidatorDate" runat="server" ControlToCompare="rdt_todate"
            ControlToValidate="rdt_StartDate" Display="None" ErrorMessage="From date cannot be greaterthan To date"
            Operator="LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
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
    <asp:ValidationSummary ID="vs_Vacancy" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>