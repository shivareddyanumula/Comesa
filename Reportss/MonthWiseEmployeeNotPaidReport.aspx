﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthWiseEmployeeNotPaidReport.aspx.cs" Inherits="Reportss_MonthWiseEmployeeNotPaidReport" %>

<!DOCTYPE html>

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
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <rsweb:ReportViewer ID="RPT_EmpNotPaid" runat="server" Width="950px" Height="518px"
                            ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
