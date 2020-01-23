<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="WorkmansCompensation.aspx.cs" Inherits="Reportss_WorkmansCompensation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(RPTTYPE, SCL, FD, TD, PRD, PRDDTL) {
            var win = window.radopen('../Reportss/WorkmansCompensationReport.aspx?RPTTYPE=' + RPTTYPE + '&SCL=' + SCL + '&FD=' + FD + '&TD=' + TD + '&PRD=' + PRD + '&PRDDTL=' + PRDDTL, "RW_WorkmansCompensation");
            win.center();
            win.set_height("350");
            win.set_width("700");
            win.set_modal(true);
            win.set_title("Workmans Compensation");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Workmans Compensation" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Report" runat="server" Text="Report Type"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_ReportType" runat="server" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_ReportType_SelectedIndexChanged"
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Specific Duration" Value="2" />
                        <telerik:RadComboBoxItem runat="server" Text="Monthly" Value="3" />
                        <telerik:RadComboBoxItem runat="server" Text="ScaleWise" Value="4" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Reporttype" runat="server" ErrorMessage="Please Select Report Type"
                    ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_ReportType" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trscale" runat="server">
            <td>
                <asp:Label ID="lbl_Scale" runat="server" Text="Scale"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Scale" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Scale" runat="server" ErrorMessage="Select Scale"
                    ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Scale" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trStartDate" runat="server">
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDate" runat="server" Width="190px">
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rdpStartDate" runat="server" ControlToValidate="rdpStartDate"
                    ErrorMessage="Please Select From Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trEndDate" runat="server">
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
                    ErrorMessage="Please Select To Date"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorDate" runat="server" ControlToCompare="rdpEndDate"
                    ControlToValidate="rdpStartDate" Display="None" ErrorMessage="From date cannot be greaterthan To date"
                    Operator="LessThanEqual" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
            </td>
        </tr>


        <tr id="trPeriod" runat="server">
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true" Filter="Contains"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Period" runat="server" ErrorMessage="Select Period"
                    ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Period" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trPeriodElement" runat="server">
            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Element">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_PeriodElements" runat="server" ControlToValidate="rcmb_PeriodElements"
                    ValidationGroup="Controls" Text="*" ErrorMessage="Select Period Elements" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click" ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_LeaveAllowances" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>