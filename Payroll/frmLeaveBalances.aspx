<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLeaveBalances.aspx.cs"
    Inherits="Payroll_frmLeaveBalances" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr id="Tr_LeaveBal" runat="server">
                    <td colspan="3">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <b>Current Leave Balance </b>
                                    <br />
                                    <br />
                                    <table id="tbl_Leavebalance" runat="server" align="center">
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>