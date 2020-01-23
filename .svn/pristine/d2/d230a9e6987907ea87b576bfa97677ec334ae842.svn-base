<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Spouse.aspx.cs" Inherits="Reportss_NEW_Spouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPop(Org,BU, emp,sts) {
            var win = window.radopen('../NewReports/SpouseReport.aspx?ORG=' + Org + '&BU=' + BU + '&EMP=' + emp+'&sts='+sts, "RadWindow1");
            win.center();
           ////////////////// win.set_modal(true);
            win.set_title("Spouse/Dependants Report");
            //////////////win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_header" runat="server" Text="Spouse/Dependants Report" Font-Bold="true"
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
                    AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MaxHeight="120px">
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
                <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true"
                    AutoPostBack="true" MaxHeight="120px">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" Text="*" InitialValue="Select"
                    ControlToValidate="rcmb_Employee" ErrorMessage="Please Select Employee" ValidationGroup="Controls"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
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
                <asp:Button ID="btn_Generate" runat="server" Text="Generate" OnClick="btn_Generate_Click" ValidationGroup="Controls" />
            </td>
            <td>
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Spouse" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="Controls" />
</asp:Content>



