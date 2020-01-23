<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmGratuityReportZSReport.aspx.cs" Inherits="Reportss_frmGratuityReportZSReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gratuity Report – Zurich Systems</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="rvGratuityReportZSReport" runat="server" Width="950px" Height="518px"
                ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>