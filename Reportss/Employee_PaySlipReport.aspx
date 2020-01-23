<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee_PaySlipReport.aspx.cs"
    Inherits="Reportss_Employee_PaySlipReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <rsweb:ReportViewer ID="rv_payslip" runat="server" Width="950px" Height="518px" ShowParameterPrompts="false"
                        ProcessingMode="Remote" SizeToReportContent="true">
                        <%--<ServerReport ReportPath="/SmartHR/Pay_Slip" ReportServerUrl="http://192.168.1.241:82/Reportserver" />--%>
                        <%--<ServerReport ReportPath="/SmartHR/Pay Slip" ReportServerUrl="http://intstsrv01/Reportserver_SQL08" />--%>
                    </rsweb:ReportViewer>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnExport" runat="server" Text="Export To PDF"
                        onclick="btnExport_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
