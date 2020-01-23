<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="ScaleWise.aspx.cs" Inherits="Reportss_ScaleWise" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(SCL, FD, TD) {
            var win = window.radopen('../Reportss/ScaleWiseReport.aspx?SCL=' + SCL, "RW_ScaleWise");
            win.center();
            win.set_modal(true);
            win.set_title("Scale Wise Appraisal");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Scale Wise Appraisal Result" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Scale" runat="server" Text="Scale"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Scale" runat="server" MarkFirstMatch="true" AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Scale" runat="server" ErrorMessage="Please Select Scale"
                    ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Scale" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--  <tr>
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDate" runat="server" Width="190px"></telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpStartDate" runat="server" ControlToValidate="rdpStartDate"
                    ErrorMessage="Please Select Start Date"
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
                <telerik:RadDatePicker ID="rdpEndDate" runat="server" Width="190px">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpEndDate" runat="server" ControlToValidate="rdpEndDate"
                    ErrorMessage="Please Select End Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
          <asp:CompareValidator ID="CompareValidatorDate" runat="server" ControlToCompare="rdpEndDate"
                ControlToValidate="rdpStartDate" Display="None" ErrorMessage="From date cannot be greaterthan To date"
                operator = "LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>--%>
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
    <asp:ValidationSummary ID="vs_ScaleWise" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>