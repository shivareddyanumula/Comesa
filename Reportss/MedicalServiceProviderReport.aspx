<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicalServiceProviderReport.aspx.cs" Inherits="Reportss_MedicalServiceProviderReport" %>

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
    <rsweb:ReportViewer ID="RPT_MedicalServiceProvider" runat="server" Height="518px" Width="950px"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
