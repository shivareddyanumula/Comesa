<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Payroll_Default" Culture="auto" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">

    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>

    <br />
    <table align="center">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="Label1" runat="server" Text="Employee Leave Opening Balances"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_BUID" runat="server" Skin="WebBlue" AutoPostBack="true"
                    MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BUID_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Period"></asp:Label>
            </td>
            <td>:
            </td>
            <td>
                <telerik:RadComboBox ID="rcmb_Period" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                    OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLeaveStruct" runat="server" Text="Leave Structure"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbLeaveStruct" runat="server" Skin="WebBlue" AutoPostBack="true" Filter="Contains"
                    MarkFirstMatch="true" OnSelectedIndexChanged="rcmbLeaveStruct_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <telerik:RadGrid ID="RG_Details" runat="server" Skin="WebBlue" AutoGenerateEditColumn="true"
                    OnNeedDataSource="RG_Details_NeedDataSource" OnUpdateCommand="RG_Details_UpdateCommand"
                    OnColumnCreated="RG_Details_ColumnCreated" EnableViewState="true" OnPreRender="RG_Details_PreRender"
                    OnEditCommand="RG_Details_EditCommand" AutoGenerateColumns="true" AllowAutomaticUpdates="true">
                    <%--<telerik:RadGrid ID="RG_Details" runat="server" Skin="WebBlue" 
                    OnNeedDataSource="RG_Details_NeedDataSource"
                     EnableViewState="true" OnPreRender="RG_Details_PreRender"
                    AutoGenerateColumns="true" AllowAutomaticUpdates="true">--%>
                    <MasterTableView EditMode="EditForms">
                        <%-- CommandItemDisplay="Top">--%>
                        <%--<CommandItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit Selected" CommandName="EditSelected"></asp:LinkButton>
                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update Edited" CommandName="UpdateEdited"></asp:LinkButton>
                        </CommandItemTemplate>--%>
                    </MasterTableView>
                    <%-- <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>--%>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <br />
    <table align="center">
        <tr>
            <td>
                <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" Text="Update"
                    OnClick="btn_Update_Click" Visible="False" />
                <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                    Text="Save" Visible="false" />
                <asp:Button ID="btn_Finalise" runat="server" meta:resourcekey="btn_Finalise" OnClick="btn_Finalise_Click"
                    Text="Finalise" Visible="False" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>