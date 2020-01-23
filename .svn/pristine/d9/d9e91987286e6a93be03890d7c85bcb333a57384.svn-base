<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="LocationWiseTrainingProgram.aspx.cs" Inherits="Reportss_LocationWiseTrainingProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(LT, CRSE, BTCH, PRD, PRDDTL, RPT) {
            var win = window.radopen('../Reportss/LocationWiseTrainingProgramReport.aspx?LT=' + LT + '&CRSE=' + CRSE + '&BTCH=' + BTCH + '&PRD=' + PRD + '&PRDDTL=' + PRDDTL + '&RPT=' + RPT, "RW_LocationWiseTraining");
            win.center();
            win.set_modal(true);
            //win.set_title("Location Wise Training Program Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <br />
                <asp:Label ID="lbl_header" runat="server" Text="Location Wise Training Report" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"> </asp:Label>
            </td>
        </tr>
        <tr id="Location" runat="server">
            <td>
                <asp:Label ID="lbl_location" runat="server" Text="Location">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Location" runat="server" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Location_SelectedIndexChanged" AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Location" runat="server" ControlToValidate="rcmb_Location"
                    ErrorMessage="Please select Location" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="Course" runat="server">
            <td>
                <asp:Label ID="lbl_Course" runat="server" Text="Course">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Course" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Course_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Course" runat="server" ControlToValidate="rcmb_Course"
                    ErrorMessage="Please select Course" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="Batch" runat="server">
            <td>
                <asp:Label ID="lbl_Batch" runat="server" Text="Batch">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_batch" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_batch" runat="server" ControlToValidate="rcmb_batch"
                    ErrorMessage="Please select Batch" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="Period" runat="server">
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
        <tr id="PeriodElement" runat="server">
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