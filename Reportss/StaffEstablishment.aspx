<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="StaffEstablishment.aspx.cs" Inherits="Reportss_StaffEstablishment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //function ShowPop(BU, JOB, FY) {
        function ShowPop(JOB, FY) {
            //var win = window.radopen('../Reportss/StaffEstablishmentReport.aspx?BU=' + BU + '&JOB=' + JOB + '&FY=' + FY, "RW_VacantPositions");
            var win = window.radopen('../Reportss/StaffEstablishmentReport.aspx?JOB=' + JOB + '&FY=' + FY, "RW_VacantPositions");
            win.center();
            win.set_modal(true);
            win.set_title("Establishment Summary");
            win.set_width("700px");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Establishment Summary" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
        <%--   <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" MarkFirstMatch="true">
                </telerik:RadComboBoDx>
            </td>
            <td></td>
        </tr>--%>
        <%--<tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit">
                </asp:Label>
            </td>
            <td><b>:</b> </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lbl_Jobs" runat="server" Text="Job"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Job" runat="server" AutoPostBack="true" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Job" runat="server" Text="*" Display="Dynamic"
                    ErrorMessage="Please Select Job" ControlToValidate="rcmb_Job"
                    InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" Enabled="false"
                    MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_FinancialPeriod" runat="server" Text="*" Display="Dynamic"
                    ErrorMessage="Please Select Financial Period" ControlToValidate="rcmb_Financialperiod"
                    InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_StaffEstablishment" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>