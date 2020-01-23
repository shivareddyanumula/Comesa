<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="PensionStatement.aspx.cs" Inherits="Reportss_PensionStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ORGID, BU, EMP, FRD, TOD, SALS) {

            var win = window.radopen('../Reportss/PensionStatementReport.aspx?ORG_ID=' + ORGID + '&BU=' + BU + '&EMP=' + EMP + '&FRD=' + FRD + '&TOD=' + TOD + '&SALS=' + SALS, "RadWindow1");
            win.center();
            win.set_modal(true);

            win.set_title("Pension Statement");

            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Pension Statement" Font-Bold="true"
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
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
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
                <telerik:RadComboBox ID="rcmb_SalStruct" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true" OnSelectedIndexChanged="rcmb_SalStruct_SelectedIndexChanged" Filter="Contains">
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
                <asp:Label ID="lbl_Empname" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_EmployeeName" runat="server" HighlightTemplatedItems="True"
                    Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeName" runat="server" ControlToValidate="rcmb_EmployeeName"
                    ErrorMessage="Employee Name is Mandatory" InitialValue="Select" meta:resourcekey="rfv_rcmb_BusinessUnit" ValidationGroup="Controls" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl_FromDate" runat="server" Text="From Date"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_fromdate" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_fromdate" runat="server" ErrorMessage="From Date is Mandatory"
                    ControlToValidate="rcmb_fromdate" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_todate" runat="server" Text="To Date"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_todate" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_todate" runat="server" ErrorMessage="To Date is Mandatory "
                    ControlToValidate="rcmb_todate" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
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