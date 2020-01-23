<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="MembersofParliament.aspx.cs" Inherits="Reportss_MembersofParliament_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ORG_ID, BU, SALS, PRD, PRDE, CRTL) {

            var win = window.radopen('../Reportss/MembersofParliamentReport.aspx?ORG_ID=' + ORG_ID + '&BU=' + BU + '&SALS=' + SALS + '&PRD=' + PRD + '&PRDE=' + PRDE + '&CRTL=' + CRTL, "RadWindow1");
            win.center();
            win.set_modal(true);
            var control = document.getElementById('<%=Request.QueryString["Control"]%>');
            if (CRTL == "StaffContribution")
                win.set_title("Staff Contribution");
            else {
                win.set_title("Members of Parliament Contribution");
            }
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
                <br />
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Business Unit is Mandatory"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_SalaryStructure" runat="server" Text="Salary Structure"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Salarystructure" runat="server" ErrorMessage="Salary Structure is Mandatory"
                    ControlToValidate="rcmb_SalStruct" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Period" runat="server" Text="period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Financialperiod" runat="server" ErrorMessage=" Period is Mandatory "
                    ControlToValidate="rcmb_Period" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl_PeriodElement" runat="server" Text="Period Element"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Periodelement" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Calendarperiod" runat="server" ErrorMessage="Period Element is Mandatory "
                    ControlToValidate="rcmb_Periodelement" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

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
    <asp:ValidationSummary ID="vs_EmployeeDueIncrement" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>