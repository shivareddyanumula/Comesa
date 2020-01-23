<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Security_ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
            return oWindow;
        }

        function Close() {
            GetRadWindow().Close();
        }   
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <br />
        <table align="center">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Enter Security Code" ForeColor="Black"
                        Font-Size="9pt" Style="font-weight: 700; font-family: Arial" />
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="txt_PassCode" runat="server" TextMode="Password">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Pass Code"
                        ControlToValidate="txt_PassCode" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Controls1"
                        ShowMessageBox="true" ShowSummary="false" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btn_Type_Save" runat="server" Text="Send Mail" ValidationGroup="Controls1"
                        OnClick="btn_Type_Save_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
