<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpouseReport.aspx.cs" Inherits="Reportss_NEW_SpouseReport" %>

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
                        <asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>
                        <rsweb:ReportViewer ID="RPT_Spouse" runat="server" Height="518px" Width="950px"
                            ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true" ShowExportControls="false">
                            <%--<ServerReport ReportPath="/SMHR_CIL/SalarySlip" ReportServerUrl="http://intstsrv01/Reportserver_SQL08" />--%>
                        </rsweb:ReportViewer>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export To PDF" OnClick="btnExport_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
