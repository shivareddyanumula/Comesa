<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeRetirment.aspx.cs" Inherits="Reportss_EmployeeRetirment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(FD, TD, RPT) {
            var win = window.radopen('../Reportss/EmployeeRetirmentReport.aspx?FD=' + FD + '&TD=' + TD + '&RPT=' + RPT, "RW_Retirment");
            win.center();
            win.set_height("350");
            win.set_width("700");
            win.set_modal(true);
            //win.set_title("Employee Due To Retire Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowPopUp(FD, TD, RPT) {
            var win = window.radopen('../Reportss/WorkmansCompensationReport.aspx?FD=' + FD + '&TD=' + TD + '&RPT=' + RPT, "RW_Retirment");
            win.center();
            win.set_height("350");
            win.set_width("700");
            win.set_modal(true);
            //win.set_title("Employee Due To Retire Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function ShowMedicalInvoicePopUp(FD, TD, RPT, SP) {
            var win = window.radopen('../Reportss/MedicalServiceProviderReport.aspx?FD=' + FD + '&TD=' + TD + '&RPT=' + RPT + '&SP=' + SP, "RW_Retirment");
            win.center();
            win.set_height("450");
            win.set_width("700");
            win.set_modal(true);
            //win.set_title("Employee Due To Retire Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

        function OnKeyPress(sender, args) {
            var re = /^[0-9\-\:\/]$/;
            args.set_cancel(!re.test(args.get_keyCharacter()));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"> </asp:Label>
            </td>
        </tr>
        <%-- <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDate" runat="server" Width="190px" AutoPostBack="true" OnSelectedDateChanged="rdpEndDate_SelectedDateChanged">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpStartDate" runat="server" ControlToValidate="rdpStartDate"
                    ErrorMessage="Please Select From Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEndDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpEndDate" runat="server" Width="190px" AutoPostBack="true" OnSelectedDateChanged="rdpEndDate_SelectedDateChanged">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpEndDate" runat="server" ControlToValidate="rdpEndDate"
                    ErrorMessage="Please Select To Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorDate" runat="server" ControlToCompare="rdpEndDate"
                    ControlToValidate="rdpStartDate" Display="None" ErrorMessage="From date cannot be greater than To date"
                    Operator="LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
            </td>
        </tr>
        <tr runat="server" id="trServiceProvider" visible="false">
            <td>
                <asp:Label ID="lblServiceProvider" runat="server" Text="Medical Service Provider"></asp:Label>
            </td>
            <td><b>:</b></td>
            <td>
                <telerik:RadComboBox ID="rcmb_ServiceProvider" runat="server" Filter="Contains"></telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_ServiceProvider" runat="server" InitialValue="Select" ControlToValidate="rcmb_ServiceProvider"
                    ErrorMessage="Please Select Medical Service Provider" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <br />
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
    <asp:ValidationSummary ID="vs_EmployeeRetirment" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>