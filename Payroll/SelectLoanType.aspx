<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="SelectLoanType.aspx.cs" Inherits="Payroll_SelectLoanType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center">
        <tr>
            <td colspan="1" align="center" style="font-weight: bold;">
                <asp:Label ID="lbl_lty" runat="server" Text="Loan Type" meta:resourcekey="lbl_lty"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:RadioButton ID="rb_EMI" runat="server" Text="EQUATED MONTHLY INSTALLMENT" meta:resourcekey="rb_EMI"
                    GroupName="select" AutoPostBack="True" OnCheckedChanged="rb_EMI_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:RadioButton ID="rb_red" Text="REDUCING BALANCE" GroupName="select" runat="server"
                    AutoPostBack="True" OnCheckedChanged="rb_red_CheckedChanged" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
