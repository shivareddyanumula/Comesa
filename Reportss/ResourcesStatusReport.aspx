﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourcesStatusReport.aspx.cs" Inherits="Reportss_ResourcesStatusReport" %>

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
    <rsweb:ReportViewer ID="RPT_ResourcesStatus" runat="server" Height="518px" Width="950px"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
     <%--<ServerReport ReportPath="/SmartPM/Smart PM/Project Wise Employee Status" ReportServerUrl="http://192.168.20.14/ReportServer_SQL08/" />--%>
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>    
    </div>
    </form>
</body>
</html>