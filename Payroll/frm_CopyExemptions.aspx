<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_CopyExemptions.aspx.cs" Inherits="Payroll_frm_CopyExemptions" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Copy Exemptions"
                    Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="lbl_Oldfinancialperiod" runat="server" Text="Old Financial Period">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Oldfinperiod" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Oldfinperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="lbl_Newfinperiod" runat="server" Text="New Financial Period">
                </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Newfinperiod" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Newfinperiod_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="lbl_Exemption" runat="server" Text="Exempted Item"></asp:Label>
            </td>
            <td><b>:</b></td>
            <td align="left">
                <telerik:RadComboBox ID="rcmb_Exempteditem" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmb_Exempteditem_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3">
                <asp:Button ID="btn_Copy" runat="server" Text="Copy Exempted Infomtion"
                    OnClick="btn_Copy_Click" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>