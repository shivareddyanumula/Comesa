﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_AllEmpLeavebal.aspx.cs" Inherits="Payroll_frm_AllEmpLeavebal" %>
<%@ Register Src="../AllEmpGridCalendar.ascx" TagName="gridcalender" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td>
                    <uc2:gridcalender id="gridcalender2" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
