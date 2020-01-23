<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_leaveBalances.aspx.cs" Inherits="Masters_Frm_leaveBalances" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <table align="center">
                <tr id="Tr_LeaveBal" runat="server">
                    <td colspan="3">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <b>Leave Balance</b>
                                </td>
                            </tr>
                            <tr>
                                <td>Employee
                                <%--<table id="tbl_Leavebalance" runat="server" align="center">
                                </table>--%>
                                </td>
                                <td><strong>:</strong></td>
                                <td>

                                    <telerik:RadComboBox ID="rcmb_Employee" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px"
                                        Skin="WebBlue" OnSelectedIndexChanged="RCM_EMPLOYEE_CLICK" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">

                                    <br />
                                </td>

                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table id="tbl_Leavebalance" runat="server" align="center"></table>
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