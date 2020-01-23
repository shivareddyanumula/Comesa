<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="PaymentofBonusActFormB.aspx.cs" Inherits="Reportss_PaymentofBonusActFormB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center">
    <tr>
    <td align="center">
    
    <rsweb:ReportViewer ID="RPT_PaymentofBonusActFormB" runat="server" Height="518px" Width="950px"
     ShowParameterPrompts="false" ProcessingMode="Remote" SizeToReportContent="true">
     <%--<ServerReport ReportPath="/SMHR_CIL/PaymentofBonusActFormB" ReportServerUrl="http://intstsrv01/Reportserver_SQL08" />--%>
     </rsweb:ReportViewer>
    </td>
    </tr>
    </table>
</asp:Content>

