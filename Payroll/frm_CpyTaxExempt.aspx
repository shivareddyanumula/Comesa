<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_CpyTaxExempt.aspx.cs" Inherits="Payroll_frm_CpyTaxExempt" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Copying Tax From Old Financial Period to Next Financial Period"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td></td>
            <td align="left">
                <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="left">
                <asp:Label ID="lbl_OldFinancialperiod" runat="server" Text="Old Financial Period" runat="server"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_OldFinperiod" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                    OnSelectedIndexChanged="rcmb_OldFinperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="left">
                <asp:Label ID="lbl_NewFinperiod" runat="server" Text="New Financial Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_NewFinperiod" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_NewFinperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3" align="center">
                <asp:Button ID="btn_Copy" runat="server"
                    Text="Copy Previous Tax Savings"
                    OnClientClick="return confirm('Are You Sure You Want to Overwrite Existed Tax Information of New Financial Period with Old Financial Period Tax Information ?')"
                    OnClick="btn_Copy_Click" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>