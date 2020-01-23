<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Main_Page.aspx.cs" Inherits="Main_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <table align="center" width="800px">
        <tr>
            <td>
                &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lbl_Birthday" runat="server" 
                    style="font-weight: 700; font-size: medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lbl_Reminders" runat="server" Text="HAPPY BIRTHDAY TO" 
                    style="font-weight: 700; font-size: small"></asp:Label>
                &nbsp;&nbsp; <u>
                    <telerik:RadTicker ID="RTicker" runat="server" AutoStart="true" Loop="true" 
                    TickSpeed="50" Font-Bold="True" Font-Names="Arial" Font-Size="12pt">
                        <Items>
                            <telerik:RadTickerItem Text='<%# Eval("EMPNAME")%>'></telerik:RadTickerItem>
                        </Items>
                    </telerik:RadTicker>
                </u>
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
    <br />
    <br />
    <br />
</asp:Content>
