<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_rgerid.aspx.cs" Inherits="Training_frm_rgerid" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadMultiPage ID="Rm_Training_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
        <telerik:RadPageView ID="Rp_Training_VIEWMAIN" runat="server" Selected="True">
            <table align="center">
                <tr>
                    <td align="center">
                        <center>
                            Training Process
                        </center>
                    </td>
                </tr>
                <tr>
                    <telerik:RadGrid ID="Rg_Resourcegrid" runat="server" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" Skin="WebBlue" PageSize="5"  >
                    </telerik:RadGrid>
                    </tr>
                    <tr>
                    <asp:TextBox ID="_txt_res" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Add_click" />
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>
