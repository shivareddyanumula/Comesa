<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="LeaveBalancesReport.aspx.cs" Inherits="Reportss_NEW_Leave_Balances_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript">
         function ShowPop(Org,BU,url,prddtl,emp,sts) {
             var win = window.radopen('../NewReports/LeaveBalancesReportNew.aspx?ORG=' + Org + '&BU=' + BU +'&PRD=' + url + '&PRDDTL=' + prddtl + '&EMP=' + emp+'&sts='+sts, "RadWindow1");
             win.center();
             win.set_modal(true);
             win.set_title("Leave Balances");
           ///////////////////  win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
     <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Leave Balances Report" Font-Bold="true"
                    Font-Size="11pt" Font-Names="Arial"> </asp:Label>
            </td>
        </tr>
         
     <tr>
            <td>
                <asp:Label ID="lbl_Org" runat="server" Text="Organisation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Org" runat="server" MarkFirstMatch="true" MaxHeight="120px" Enabled="false">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged"  MaxHeight="120px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
        <td>
        <asp:Label ID="lbl_Employee" runat="server" Text="Employee">
        </asp:Label>
        </td>
        <td>
        <b>:</b>
        </td>
        <td>
        <telerik:RadComboBox ID="rcmb_Employee" runat="server" EnableEmbeddedScripts="false" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px">
        </telerik:RadComboBox>
        </td>
        <td>
        <%--<asp:RequiredFieldValidator ID="rfv_Employee" runat="server" InitialValue="Select" Text="*"
         ValidationGroup="Controls" ControlToValidate="rcmb_Employee" ErrorMessage="Select Employee">
         </asp:RequiredFieldValidator>--%>
        </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"> </asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" MarkFirstMatch="true"
                    EnableEmbeddedSkins="false" AutoPostBack="true" onselectedindexchanged="rcmb_Period_SelectedIndexChanged"  MaxHeight="120px">
                </telerik:RadComboBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="rfv_Period" runat="server" ErrorMessage="Select Period"
             ValidationGroup="Controls" Text="*" ControlToValidate="rcmb_Period" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="lbl_PeriodElements" runat="server" Text="Period Element">
        </asp:Label>
        </td>
        <td>
        <b>:</b>
        </td>
        <td>
        <telerik:RadComboBox ID="rcmb_PeriodElements" runat="server" EnableEmbeddedSkins="false" MarkFirstMatch="true"
         AutoPostBack="true"  MaxHeight="120px">
         </telerik:RadComboBox>
        </td>
        <td>
        <asp:RequiredFieldValidator ID="rfv_PeriodElements" runat="server" ControlToValidate="rcmb_PeriodElements"
         ValidationGroup="Controls" Text="*" ErrorMessage="Select Period Elements" InitialValue="Select"></asp:RequiredFieldValidator>
        </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status">
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl" runat="server" Text=":" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbStatus" runat="server" MarkFirstMatch="true" MaxHeight="200">
                    <Items>
                        <telerik:RadComboBoxItem Text="Select" Value="-1" />
                        <telerik:RadComboBoxItem Text="Approved" Value="1" />
                        <telerik:RadComboBoxItem Text="Pending" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcbStatus" ValidationGroup="Controls" ErrorMessage="Please Select Status">
                </asp:RequiredFieldValidator>
            </td>
        </tr>

    
           
    </table>
    <table align="center">
    <tr>
    <td align="center">
    <asp:Button ID="btn_Generate" runat="server" Text="Generate" 
            onclick="btn_Generate_Click" ValidationGroup="Controls"/>
    </td>
    <td>
    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
            onclick="btn_Cancel_Click" />
    </td>
    </tr>
    </table>
    <asp:ValidationSummary ID="vs_Absentees" runat="server" ValidationGroup="Controls"
     ShowMessageBox="true" ShowSummary="false" />
</asp:Content>



