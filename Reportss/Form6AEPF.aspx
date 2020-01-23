<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Form6AEPF.aspx.cs" Inherits="Reportss_Form6AEPF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <rsweb:ReportViewer ID="RPT_Form6AEPF" runat="server" Height="518px" Width="950px"
                    ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
                    <%--<ServerReport ReportPath="/SMHR_CIL/Form6AEPF" ReportServerUrl="http://192.168.20.63/ReportServer" />--%>
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
