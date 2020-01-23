<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Security_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
        <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
    </style>

    <script type="text/javascript">
        function ToggleRow() {
            var trCode = document.getElementById("trCode"),
                state = trCode.style.display;
            var radioButtons = document.getElementsByName("rdb");
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == "1") {
                        trCode.style.display = '';
                    }
                    else {
                        trCode.style.display = 'none';
                    }
                }
            }
        }
    </script>

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
    <script type="text/javascript">
        function disableButton(sender,group) {
            Page_ClientValidate(group);
            if (Page_IsValid) {
                sender.disabled = "disabled";
                __doPostBack(sender.name, '');
            }
        }
    </script>
<%--<script type="text/javascript" src="../btnSingleClickDisable.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="Buttons" />
    <div>
        <br />
        <table align="center">
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Label ID="lbl_ChangePassword" runat="server" Text="Change&nbsp;Password" Style="font-weight: 700;
                        font-size: small; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_UserName" runat="server" Text="User&nbsp;Name" CssClass="style1"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_Name" runat="server" CssClass="style1"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_CurrentPassword" runat="server" Text="Current&nbsp;Password" CssClass="style1"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="txt_CurrentPWD" runat="server" TextMode="Password" Width="125px">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_CurrentPassword" runat="server" ErrorMessage="(* Mandatory)"
                        Style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; font-weight: 700"
                        ControlToValidate="txt_CurrentPWD" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_NewPassword" runat="server" Text="New&nbsp;Password" CssClass="style1"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="txt_NewPWD" runat="server" TextMode="Password" MaxLength="14"  >
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_NewPWD" runat="server" ErrorMessage="(* Mandatory)"
                        Style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; font-weight: 700"
                        ControlToValidate="txt_NewPWD" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_ReTypePassword" runat="server" Text="ReType&nbsp;Password" CssClass="style1"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="txt_ReTypePWD" runat="server" TextMode="Password" MaxLength="15">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_ReType" runat="server" ErrorMessage="(* Mandatory)"
                        Style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; font-weight: 700"
                        ControlToValidate="txt_ReTypePWD" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CompareValidator ID="CV_ReType" runat="server" ControlToCompare="txt_NewPWD"
                        ControlToValidate="txt_ReTypePWD" ErrorMessage="New Password and ReType Password are not similar"
                        Style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; font-weight: 700" ValidationGroup="Controls"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSecurityCode" runat="server" Text="Change&nbsp;Security&nbsp;Code&nbsp;Too?"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdb" runat="server" RepeatDirection="Horizontal" Font-Size="Small"
                        OnClick="ToggleRow()">
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="trCode" runat="server" style="display: none;">
                <td>
                </td>
                <td>
                </td>
                <td>
                    <telerik:RadTextBox ID="rtxtCode" runat="server" MaxLength="14">
                    </telerik:RadTextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit"
                        ValidationGroup="Controls" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false"/>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="vs_ChangePassword" runat="server" ShowMessageBox="false"
            ShowSummary="false" ValidationGroup="Controls" />
    </div>
    </form>
</body>
</html>
