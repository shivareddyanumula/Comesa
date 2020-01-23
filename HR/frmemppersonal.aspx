<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmemppersonal.aspx.cs" Inherits="HR_frmemppersonal"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RASMgr" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="RFDecorator" DecoratedControls="All" runat="server"
         Skin="WebBlue"  meta:resourcekey="RFDecorator" />
    <table style="height: 176px; width: 420px">
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td colspan="5">
                <asp:Label ID="lbl_info" runat="server" meta:resourcekey="lbl_Info"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_BU"  Skin="WebBlue"  runat="server" Enabled="False"
                    MaxLength="100" Width="125px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_Position" runat="server" meta:resourcekey="lbl_Position"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_Position"  Skin="WebBlue"  runat="server"
                    Enabled="False" Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_Grade" runat="server" meta:resourcekey="lbl_Grade"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_Grade"  Skin="WebBlue"  runat="server" Enabled="False"
                    Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_SalStr" runat="server" meta:resourcekey="lbl_SalStr"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_SalStr"  Skin="WebBlue"  runat="server" Enabled="False"
                    Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_GrossSal" runat="server" meta:resourcekey="lbl_GrossSal"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_GrossSal"  Skin="WebBlue"  runat="server"
                    Enabled="False" Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_Basic" runat="server" meta:resourcekey="lbl_Basic"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_Basic"  Skin="WebBlue"  runat="server" Enabled="False"
                    Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_LS" runat="server" meta:resourcekey="lbl_LS"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_LS"  Skin="WebBlue"  runat="server" Enabled="False"
                    Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lbl_RM" runat="server" meta:resourcekey="lbl_RM"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox  ID="txt_RM"  Skin="WebBlue"  runat="server" Enabled="False"
                    MaxLength="100" Width="125px">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div>
    </div>
    </form>
</body>
</html>
