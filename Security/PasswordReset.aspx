<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="Security_PasswordReset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Label ID="lbl_ResetPassword" runat="server" Text="Reset&nbsp;Password" Style="font-weight: 700; font-size: small; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" AutoPostBack="true" MaxHeight="120px"
                            OnSelectedIndexChanged="rcmbBusinessUnit_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvBusinessUnit" runat="server" InitialValue="Select" Display="Dynamic"
                            Text="*" ControlToValidate="rcmbBusinessUnit" ErrorMessage="Please Select Business Unit"
                            ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmbEmployee" runat="server" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200px"
                            OnSelectedIndexChanged="rcmbEmployee_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployee" runat="server" InitialValue="Select"
                            Text="*" ControlToValidate="rcmbEmployee" ErrorMessage="Please Select Employee"
                            ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUserGroup" runat="server" Text="User Group"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmbUserGroup" runat="server" MarkFirstMatch="true" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserGroup" runat="server" InitialValue="Select"
                            Text="*" ControlToValidate="rcmbUserGroup" ErrorMessage="Please Select User Group"
                            ValidationGroup="Controls"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
                <td>
                    <asp:Label ID="lblResetPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPWD" runat="server" TextMode="Password" Width="125px">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvResetPassword" runat="server" Text="*" ControlToValidate="txtPWD"
                        ErrorMessage="Please Enter Password To Reset" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" ValidationGroup="Controls" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vs_ResetPassword" runat="server" ShowMessageBox="true"
                ShowSummary="false" ValidationGroup="Controls" />
        </div>
    </form>
</body>
</html>