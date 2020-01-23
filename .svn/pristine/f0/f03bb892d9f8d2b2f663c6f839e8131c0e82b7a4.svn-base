<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Form16.aspx.cs" Inherits="Reportss_Form16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../smhr.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript">
        function ShowPop(url, ID,BU,emp,date) {
            var win = window.radopen('../Reportss/Form16Report.aspx?PRD=' + url + '&ORG_ID='+ID+ '&BU=' + BU+ '&EMP='+emp+ '&EDATE='+date , "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Form 16");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center">
<tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Form 16 Report" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
<tr>
<td>
<asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
</td>
<td>
<b>:</b>
</td>
<td>
<telerik:RadComboBox ID="rcmb_Organisation" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true"
 AutoPostBack="true" 
        onselectedindexchanged="rcmb_Organisation_SelectedIndexChanged"></telerik:RadComboBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfv_Organisation" runat="server" InitialValue="Select" Text="*"
 ValidationGroup="Controls" ErrorMessage="Select Organisation" ControlToValidate="rcmb_Organisation">
 </asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
</td>
<td>
<b>:</b>
</td>
<td>
<telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true"
 AutoPostBack="true" 
        onselectedindexchanged="rcmb_BusinessUnit_SelectedIndexChanged"></telerik:RadComboBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" InitialValue="Select" Text="*"
 ValidationGroup="Controls" ErrorMessage="Select Business Unit" ControlToValidate="rcmb_BusinessUnit">
 </asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
</td>
<td>
<b>:</b>
</td>
<td>
<telerik:RadComboBox ID="rcmb_Employee" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true"
 AutoPostBack="true"></telerik:RadComboBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfv_Employee" runat="server" InitialValue="Select" Text="*"
 ValidationGroup="Controls" ErrorMessage="Select Employee" ControlToValidate="rcmb_Employee">
 </asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_FromDate" runat="server" Text="From Date"></asp:Label>
</td>
<td>
<b>:</b>
</td>
<td>
<telerik:RadDatePicker ID="rdp_FromDate" runat="server"></telerik:RadDatePicker>
</td>
<td>
<asp:RequiredFieldValidator ID="rfv_FromDate" runat="server" Text="*"
 ValidationGroup="Controls" ErrorMessage="Select From Date" ControlToValidate="rdp_FromDate">
 </asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_ToDate" runat="server" Text="To Date"></asp:Label>
</td>
<td>
<b>:</b>
</td>
<td>
<telerik:RadDatePicker ID="rdp_ToDate" runat="server"></telerik:RadDatePicker>
</td>
<td>
<asp:RequiredFieldValidator ID="rfv_ToDate" runat="server" Text="*"
 ValidationGroup="Controls" ErrorMessage="Select To Date" ControlToValidate="rdp_ToDate">
 </asp:RequiredFieldValidator>
</td>
</tr>
<tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
</table>
<table align="center">
    <tr>
    <td align="center">
    <asp:Button ID="btn_Generate" runat="server" Text="Generate" 
            onclick="btn_Generate_Click" style="height: 26px" ValidationGroup="Controls"/>
    </td>
    <td>
    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
            onclick="btn_Cancel_Click" />
    </td>
    </tr>
    </table>
    <asp:ValidationSummary ID="vs_Form16" runat="server" ShowMessageBox="true"
     ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>

