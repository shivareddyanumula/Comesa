<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Nhif.aspx.cs" Inherits="Reportss_Nhif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        //function ShowPop(url, ID, status, sal) {
        function ShowPop(BU, DIR, DEP, PRD, PE, sts) {
            //var win = window.radopen('../Reportss/Nhif_report.aspx?PRD=' + url + '&BU=' + ID + '&DEPT=' + status, "RadWindow1");
            var win = window.radopen('../Reportss/Nhif_report.aspx?BU=' + BU + '&DIR=' + DIR + '&DEPT=' + DEP + '&PRD=' + PRD + '&PE=' + PE + '&Sts=' + sts, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("NHIF");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="NHIF Report" Font-Bold="True" Font-Names="Arial"
                    Font-Size="11pt"></asp:Label>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true"
                    AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_Directorate" runat="server" MarkFirstMatch="true"
                    AutoPostBack="True" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Department" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payperiod" runat="server" MarkFirstMatch="true" Filter="Contains"
                    Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="rcmb_payperiod_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_payperiod"
                    ErrorMessage="Please select Period" InitialValue="Select " ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Elements"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payElements" runat="server" MaxHeight="200px"
                    Skin="WebBlue" AutoPostBack="True" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcmb_payElements"
                    ErrorMessage="Please select Period Elemants" InitialValue="Select " ValidationGroup="Controls">*</asp:RequiredFieldValidator>
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
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                    ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Controls" />
            </td>
        </tr>

    </table>
    <br />
</asp:Content>