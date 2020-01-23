<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_SalaryRegister.aspx.cs" Inherits="Reportss_frm_SalaryRegister" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(prd, ID, sts) {
            var win = window.radopen('../Reportss/SalaryRegisterReport.aspx?PRD=' + prd + '&BU=' + ID + '&Sts=' + sts, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Salary Register");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Salary Register Report" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4"></td>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                    AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Select Business Unit" ValidationGroup="Controls">\
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Period" runat="server" Skin="WebBlue" MarkFirstMatch="true"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Period" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_Period" ErrorMessage="Select Period" ValidationGroup="Controls">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_PeriodElements" runat="server" Skin="WebBlue"
                    AutoPostBack="true" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_PeriodElements_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Periodelements" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_PeriodElements" ErrorMessage="Select Period Element" ValidationGroup="Controls">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbStatus" runat="server" MarkFirstMatch="true" MaxHeight="200">
                    <Items>
                        <telerik:RadComboBoxItem Text="Select" Value="-1" />
                        <telerik:RadComboBoxItem Text="Approved" Value="1" />
                        <telerik:RadComboBoxItem Text="Pending" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcbStatus" ValidationGroup="Controls" ErrorMessage="Please Select Status">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate"
                    OnClick="btn_Submit_Click" ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <%--<table align="center" width="100%">
        <tr>
            <td>
                <rsweb:ReportViewer ID="rvSalaryReg" runat="server" Width="100%">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>--%>
</asp:Content>