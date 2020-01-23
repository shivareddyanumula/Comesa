<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Employee_Payslip.aspx.cs" Inherits="Reportss_Employee_Payslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, emp, status, ID) {

            var win = window.radopen('../Reportss/Employee_PaySlipReport.aspx?PRD=' + url + '&EMP=' + emp + '&DEPT=' + status + '&BU=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Pay Slip");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center" width="990px" style="vertical-align: top;">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Employee PaySlip Report" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" style="width: 32%;">
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
                            <asp:Label ID="lbl_payperiod" runat="server" Text="Pay Period"></asp:Label>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payperiod" runat="server"
                                Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_payperiod_SelectedIndexChanged"
                                MarkFirstMatch="true" MaxHeight="200px" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_paypriod" runat="server" InitialValue="Select"
                                ControlToValidate="rcmb_payperiod" ErrorMessage="Please select Pay Period" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trBusinessUnit" runat="server">
                        <td>
                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                        </td>
                        <td>:
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_BusinessUnit" runat="server" Filter="Contains"
                                MarkFirstMatch="true" AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged"
                                Width="160px">
                            </telerik:RadComboBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="trRblist" runat="server">
                        <td>
                            <asp:Label ID="lblRbList" runat="server" Text="Select&nbsp;All&nbsp;Employees?"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbList" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                OnSelectedIndexChanged="rbList_SelectedIndexChanged">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td></td>
                    </tr>
                    <tr id="trDept" runat="server">
                        <td>
                            <asp:Label ID="lbl_BusinessUnit0" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td>:
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Department" runat="server" Filter="Contains"
                                MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="ddl_Department_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <%-- <td>
                            <asp:RequiredFieldValidator ID="RFV_Department" runat="server" ControlToValidate="ddl_Department"
                                ErrorMessage="Please Select Department" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>--%>
                    </tr>
                    <tr id="trEmployee" runat="server">
                        <td>
                            <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_employee" runat="server" Filter="Contains"
                                MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_employee_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="tr_Employee1" runat="server">
                        <td colspan="4" style="text-align: center">
                            <br />
                            <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                                ValidationGroup="Controls" />
                            &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                            <br />
                            <asp:ValidationSummary ID="VS_Payslip" runat="server" ShowMessageBox="True" ShowSummary="False"
                                ValidationGroup="Controls" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <%--<center>
                    <rsweb:ReportViewer ID="rv_payslip" runat="server" Width="950px" ProcessingMode="Remote" 
                        ShowBackButton="True" ShowToolBar="true" ShowParameterPrompts="false" Height="600px">
                    </rsweb:ReportViewer>
                </center>--%>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>