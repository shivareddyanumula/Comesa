<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nssf_report.aspx.cs" Inherits="Reportss_Nssf_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="left">
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Width="900px"
                        Height="500px" ShowParameterPrompts="false" SizeToReportContent="true">
                        <%--<ServerReport ReportPath="/SmartHR/NSSFContributions" ReportServerUrl="http://192.168.1.241:82/Reportserver" />--%>
                        <%--<ServerReport ReportPath="/SmartHR/NSSFContributions" ReportServerUrl="http://intstsrv01/Reportserver_SQL08" />--%>
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
