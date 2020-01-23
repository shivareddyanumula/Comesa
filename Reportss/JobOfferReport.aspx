<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobOfferReport.aspx.cs" Inherits="Reportss_JobOfferReport" %>


<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
   <center>
    
        <rsweb:ReportViewer ID="RPT_JobOfferReport" runat="server" Width="950px" Height="518px" BackColor="White"
            ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
        </rsweb:ReportViewer>
    </center>
</asp:Content>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <rsweb:ReportViewer ID="RPT_JobOfferReport" runat="server" Height="518px" Width="950px"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
     <%--<ServerReport ReportPath="/SMHR_CIL/ArrearsReport" ReportServerUrl="http://intstsrv01/Reports_SQL08" />--%>
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>