﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicRepor.aspx.cs" Inherits="Reportss_DynamicRepor" %>

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
    <rsweb:ReportViewer ID="AdhocReport" runat="server" Height="518px" Width="100%"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
