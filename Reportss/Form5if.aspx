<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Form5if.aspx.cs" Inherits="Reportss_Form5if" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center">
    <tr>
    <td align="center">
    
    <rsweb:ReportViewer ID="RPT_Form5if" runat="server" Height="518px" Width="950px"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
         <%--<ServerReport ReportPath="/SMHR_CIL/Form5if" ReportServerUrl="http://intstsrv01/Reports_SQL08" />--%>
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>
</asp:Content>

