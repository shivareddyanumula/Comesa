<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_payrollemail.aspx.cs" Inherits="Payroll_frm_payrollemail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Payrollemailheader" runat="server" Text="Payroll Email"
                    Font-Bold="True" meta:resourcekey="lbl_Payrollemailheader"></asp:Label>
            </td>
        </tr>
    </table>

    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <asp:Label ID="lbl_BU" runat="server" Text="Business Unit" meta:resourcekey="lbl_BU"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" meta:resourcekey="rcmb_BU"
                    Skin="WebBlue" AutoPostBack="True" MaxHeight="120px"
                    OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BU" runat="server" ControlToValidate="rcmb_BU"
                    InitialValue="Select" ErrorMessage="Please Select Business Unit" Text="*" ValidationGroup="Controls"
                    meta:resourcekey="rfv_rcmb_BU">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" meta:resourcekey="lbl_Period"
                    Text="Period"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true"
                    AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_Period" Filter="Contains"
                    MaxHeight="120px" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Period" runat="server" ControlToValidate="rcmb_Period"
                    InitialValue="Select" ErrorMessage="Please Select Period" Text="*" ValidationGroup="Controls"
                    meta:resourcekey="rfv_rcmb_Period">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr runat="server">
            <td>
                <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period&nbsp;Elements"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_PeriodElements" MarkFirstMatch="true" runat="server"
                    AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_PeriodElements"
                    MaxHeight="120px" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodElements" runat="server" ControlToValidate="rcmb_PeriodElements"
                    InitialValue="Select" ErrorMessage="Please Select Period Element" Text="*" ValidationGroup="Controls"
                    meta:resourcekey="rfv_rcmb_PeriodElements">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_selectedEMP" runat="server" Text="Selected&nbsp;Employee&nbsp;Payslip"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_selectedEMP" MarkFirstMatch="true" runat="server"
                    AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_selectedEMP"
                    MaxHeight="120px" Filter="Contains"
                    OnSelectedIndexChanged="rcmb_selectedEMP_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:CheckBox ID="chk_selectedEMP" runat="server" Text="ALL Employees" AutoPostBack="true"
                    OnCheckedChanged="chk_selectedEMP_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_SenddtoEMP" runat="server" Text="Send&nbsp;To&nbsp;Selected&nbsp;Employee"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_SendtoEMP" MarkFirstMatch="true" runat="server"
                    AutoPostBack="True" Skin="WebBlue" meta:resourcekey="rcmb_SendtoEMP" Filter="Contains"
                    MaxHeight="120px" OnSelectedIndexChanged="rcmb_SendtoEMP_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:CheckBox ID="chk_sendtoEMP" runat="server" Text="Self" AutoPostBack="true"
                    OnCheckedChanged="chk_sendtoEMP_CheckedChanged" />
            </td>
        </tr>
        <tr align="center">
            <td align="center" colspan="4">
                <asp:Button ID="btn_Send" runat="server" Text="Send" OnClick="btn_Send_Click" ValidationGroup="Controls" />
                <asp:ValidationSummary ID="vs_payrollemail" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
</asp:Content>