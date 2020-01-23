<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="DivisionalwiseEmployee.aspx.cs" Inherits="Reportss_DivisionalwiseEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowPop(ID, BU, Dept) {
            var win = window.radopen('../Reportss/DivisionalwiseEmployeeReport.aspx?ORG_ID=' + ID + '&BU=' + BU + '&Dept=' + DEPT, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Divisional wise Employee Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Font-Bold="true" Text="Divisional Wise Employee" Font-Size="11pt" Font-Names="Arial"> </asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ErrorMessage="Please Select Business Unit"
                    ControlToValidate="rcmb_BusinessUnit" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trDepartment" runat="server">
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>

            <td>
                <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ErrorMessage="Please Select Department"
                    ControlToValidate="rcmb_Department" ValidationGroup="Controls" InitialValue="Select" ForeColor="Red" Text="*">
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



    <asp:ValidationSummary ID="vs_EmployeeDetails" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />

    <telerik:RadWindow runat="server" ID="rwDivWiseEmp" Height="500" Width="800"
        Modal="true" VisibleOnPageLoad="false" Behaviors="Close" Title="Divisional Wise Employee">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                        <rsweb:ReportViewer ID="RPT_DivisionalwiseEmployeereport" runat="server" Height="518px" Width="950px"
                            ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>