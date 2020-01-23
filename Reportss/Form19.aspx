<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Form19.aspx.cs" Inherits="Reportss_Form19" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <rsweb:ReportViewer ID="RPT_Form19" runat="server" Height="518px" Width="950px" ShowParameterPrompts="false"
                    ProcessingMode="Remote" SizeToReportContent="true">
                    <%--<ServerReport ReportPath="/SMHR_CIL/Form19EPF" ReportServerUrl="http://intstsrv01/Reports_SQL08" />--%>
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
