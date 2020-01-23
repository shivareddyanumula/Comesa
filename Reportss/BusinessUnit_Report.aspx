<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="BusinessUnit_Report.aspx.cs" Inherits="Reportss_BU_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(ID) {
            var win = window.radopen('../Reportss/BusinessReport.aspx?BU=' + ID, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_title("Business Unit Report");
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lbl_Header" runat="server" Text="Business Unit Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <br />
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
                <telerik:RadComboBox ID="rcmb_Organisation" runat="server" Enabled="false"  MarkFirstMatch="true">
                </telerik:RadComboBox>
            </td>
            
        </tr>
        <tr>
            
                <td>
                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                </td>
                <td>
                    :
                </td>
                <td>
                    <telerik:RadComboBox EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true"
                        OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_BusinessUnit"
                        ErrorMessage="Please select BusinessUnit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                </td>
           
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btn_Submit" runat="server" Text="Generate" OnClick="btn_Submit_Click"
                    Style="height: 26px" ValidationGroup="Controls" />&nbsp;
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
                    ShowMessageBox="true" ValidationGroup="Controls" />
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
</asp:Content>
