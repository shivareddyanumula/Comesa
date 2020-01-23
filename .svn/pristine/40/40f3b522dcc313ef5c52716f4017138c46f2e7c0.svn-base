<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CmprsnRptWithPrevMnthReport.aspx.cs" Inherits="Reportss_New_Reports_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <script type="text/javascript">
        var message = "Right Click Disabled!";

        ///////////////////////////////////
        function clickIE4() {
            if (event.button == 2) {
                alert(message);
                return false;
            }
        }

        function clickNS4(e) {
            if (document.layers || document.getElementById && !document.all) {
                if (e.which == 2 || e.which == 3) {
                    alert(message);
                    return false;
                }
            }
        }

        if (document.layers) {
            document.captureEvents(Event.MOUSEDOWN);
            document.onmousedown = clickNS4;
        }
        else if (document.all && !document.getElementById) {
            document.onmousedown = clickIE4;
        }

        document.oncontextmenu = new Function("alert(message);return false")


        function winOpen(str) {
            window.open(str);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <rsweb:ReportViewer ID="RPT_CmprsnRptWithPrevMnth" runat="server" Height="518px" Width="950px"
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
