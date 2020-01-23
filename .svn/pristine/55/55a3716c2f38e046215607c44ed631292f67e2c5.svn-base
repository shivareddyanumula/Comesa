<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Wht.aspx.cs" Inherits="Reportss_Wht" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="WHT" Font-Bold="True"
                    Font-Names="Arial" Font-Size="11pt"></asp:Label>
            </td>
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
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_Department" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payperiod" runat="server" Skin="WebBlue" AutoPostBack="true" MarkFirstMatch="true"
                    OnSelectedIndexChanged="rcmb_payperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="rcmb_payperiod" ErrorMessage="Please select Period"
                    InitialValue="Select " ValidationGroup="Controls">*</asp:RequiredFieldValidator>
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
                <telerik:RadComboBox EnableEmbeddedSkins="false" ID="rcmb_payElements" runat="server" Skin="WebBlue"
                    AutoPostBack="True" MarkFirstMatch="true" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_payElements_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="rcmb_payElements"
                    ErrorMessage="Please Select Period Elements" InitialValue="Select "
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" ValidationGroup="Controls" OnClick="btn_Submit_Click" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="VS_EmpPapItems" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
    <center>
        <rsweb:ReportViewer ID="RPT_WhtReport" runat="server" Width="950px" Height="518px"
            ShowParameterPrompts="false" ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </center>
</asp:Content>