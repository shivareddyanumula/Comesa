<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="SalarySlip.aspx.cs" Inherits="Reportss_PaySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, prddtl, emp, BU, Localisation) {

            var win = window.radopen('../Reportss/SalarySlipReport.aspx?PRD=' + url + '&PRDDTL=' + prddtl + '&EMP=' + emp + '&BU=' + BU + '&Localisation=' + Localisation, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_width("670");
            win.set_title("Salary Slip");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Salary Slip" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
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
                            <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true"
                                OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" Text="*" InitialValue="Select"
                                ControlToValidate="rcmb_Period" ErrorMessage="Please Select Period" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_payperiod" runat="server" Text="Pay Period"></asp:Label>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_PeriodElements" runat="server"
                                Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_payperiod_SelectedIndexChanged"
                                MarkFirstMatch="true" MaxHeight="200px" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_paypriod" runat="server" InitialValue="Select"
                                ControlToValidate="rcmb_PeriodElements" ErrorMessage="Please select Pay Period"
                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
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
                                MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="True" Skin="WebBlue"
                                Width="160px" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvBusinessUnit" runat="server" Text="*" InitialValue="Select"
                                ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please Select Business Unit"
                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
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
                    <%--<tr id="trDept" runat="server">
                        <td>
                            <asp:Label ID="lbl_BusinessUnit0" runat="server" Text="Department"></asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Department" runat="server"
                                MarkFirstMatch="true" Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="ddl_Department_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                         <td>
                            <asp:RequiredFieldValidator ID="RFV_Department" runat="server" ControlToValidate="ddl_Department"
                                ErrorMessage="Please Select Department" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr id="trEmployee" runat="server">
                        <td>
                            <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Employee" runat="server" MaxHeight="120px" Filter="Contains"
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_SalarySlip" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>