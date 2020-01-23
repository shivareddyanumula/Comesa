<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Frm_EmployeeContractDetails.aspx.cs" Inherits="Reportss_Frm_EmployeeContractDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(org, buid, derict, depart) {
            debugger
            var win = window.radopen('../Reportss/Frm_EmployeeContractDetailsReport.aspx?OG=' + org + '&BU=' + buid + '&DER=' + derict + '&DEP=' + depart, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Employee Contract Details");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <div>
        <table align="center">
            <tr>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="lb_Header" runat="server" Text=" Employee Contract Details" Font-Bold="True" Visible="true"
                        Font-Names="Arial" Font-Size="11pt"></asp:Label><br />
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
                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_BusinessUnit"
                        ErrorMessage="Please Select BusinessUnit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>


                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rad_Directorate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                    </telerik:RadComboBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcm_Department" MarkFirstMatch="true"
                        runat="server" AutoPostBack="True" Filter="Contains">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btn_Submit" runat="server" Text="Generate"
                        OnClick="btn_Submit_Click" ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
                </td>
                <td>
                    <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="Controls" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>