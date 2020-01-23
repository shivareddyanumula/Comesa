<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLog.aspx.cs" Inherits="Reportss_UserLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="RPT_UserLog" runat="server" Width="950px" Height="518px"
            ShowParameterPrompts="false" ProcessingMode="Remote">
            <ServerReport ReportPath="/SmartPM/Smart PM/EmployeeWiseEfforts" ReportServerUrl="http://192.168.20.14/ReportServer_SQL08/" />
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>