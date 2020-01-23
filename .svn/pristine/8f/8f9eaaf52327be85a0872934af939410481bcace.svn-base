<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Selfservice_Contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <table align="center">
            <tr>
                <td>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" />
                    <br />
                    <br />
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_ContactDetails" runat="server" Text="Employee Contact Details"
                                    Style="font-weight: 700; font-size: medium; color: #000000;"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_MobileNo" runat="server" Text="Mobile&nbsp;No">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadMaskedTextBox ID="rmtxt_MobileNo" runat="server" DisplayMask="##-##########"
                                                Mask="##-##########" Enabled="false">
                                            </telerik:RadMaskedTextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="rev_MobileNo" runat="server" ControlToValidate="rmtxt_MobileNo"
                                                Display="Dynamic" Text="*"  ErrorMessage="Enter 10 digits for mobile number" ValidationExpression="\d{2}-\d{10}"
                                                ValidationGroup="Contact"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_LandlineNo" runat="server" Text="LandLine&nbsp;No">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadMaskedTextBox ID="rmtxt_LandlineNo" runat="server" DisplayMask="##### ########"
                                                Mask="##### ########" Enabled="false">
                                            </telerik:RadMaskedTextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="rev_LandlineNo" runat="server" ControlToValidate="rmtxt_LandlineNo"
                                                Display="Dynamic" Text="*" ErrorMessage="Enter the Landline No. with STD Code" ValidationExpression="^[0][1-9]{2,4} [0-9]{6,8}$"
                                                ValidationGroup="Contact"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_EmailID" runat="server" Text="Email&nbsp;ID">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_EmailID" runat="server" Enabled="false">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td colspan="4">
                                            <asp:RegularExpressionValidator ID="rev_EmailID" runat="server" ControlToValidate="rtxt_EmailID"
                                                Text="*" ErrorMessage="Please Enter Valid Email ID" Display="Dynamic" ValidationGroup="Contact"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr>
                                        <td colspan="8">
                                            <asp:Button ID="btn_Correct" runat="server" Text="Correct" OnClick="btn_Correct_Click"
                                                ValidationGroup="Contact" />
                                            <asp:Button ID="btn_Update" runat="server" Text="Update Details" ValidationGroup="Contact"
                                                OnClick="btn_Update_Click" />
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:ValidationSummary ID="vs_Contact" runat="server" ValidationGroup="Contact" ShowMessageBox="true"
                                            ShowSummary="false" />
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    </form>
</body>
</html>
