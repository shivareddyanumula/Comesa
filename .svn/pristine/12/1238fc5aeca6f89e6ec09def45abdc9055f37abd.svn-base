<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="EmployeeWiseTrainingProgram.aspx.cs" Inherits="Reportss_EmployeeWiseTrainingProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(BU, DRCT, DEP, SDEP, RPT) {
            var win = window.radopen('../Reportss/EmployeeWiseTrainingProgramReport.aspx?BU=' + BU + '&DRCT=' + DRCT + '&DEP=' + DEP + '&SDEP=' + SDEP + '&RPT=' + RPT, "RW_EmployeeWiseTraining");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Wise Training Program Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <br />
                <asp:Label ID="lbl_header" runat="server" Text="Employee Wise Training Report" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BU" runat="server" Text="Business Unit">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged"
                    MaxHeight="120px" AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BU" runat="server" ControlToValidate="rcmb_BU"
                    ErrorMessage="Please select Business Unit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" MaxHeight="120px" AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rcmb_Directorate"
                    ErrorMessage="Please select Directorate" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" MaxHeight="120px" AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rcmb_Department"
                    ErrorMessage="Please select Department" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_SDepartment" runat="server" Text="Sub Department"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_SDepartment" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="rfv_SDepartment" runat="server" ErrorMessage="Please Select Sub Department"
             ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_SDepartment" InitialValue="Select"></asp:RequiredFieldValidator>--%>
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