<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="EmployeesLeaveCalendar.aspx.cs" Inherits="Payroll_EmployeesLeaveCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script language="javascript" type="text/javascript">
            function ShowPopForm() {
                var win = window.radopen("frm_AllEmpLeavebal.aspx", "RW_Login");
                win.center();
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lbl_header" runat="server" Text="Team Leave Calendar" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true"
                    MaxHeight="120px" AutoPostBack="True" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" ControlToValidate="rcmb_Employee" InitialValue="Select"
                    Text="*" ErrorMessage="Please Select Employee" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:LinkButton ID="lnk_Cal" runat="server" OnClick="lnk_Cal_Click" ValidationGroup="Controls">Leave Calender</asp:LinkButton>
                <asp:ValidationSummary ID="vs_LeaveApp" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
</asp:Content>