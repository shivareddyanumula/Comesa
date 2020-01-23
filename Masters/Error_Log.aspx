<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="Error_Log.aspx.cs" Inherits="Masters_Error_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" width="50%">
        <tr>
          <tr>
            <td align="center">
                <asp:Label ID="lbl_DepartmentHeader" runat="server" Text="Error Log Details" Font-Bold="True"></asp:Label>
            </td>
        </tr>
            <td>
                <telerik:RadGrid ID="Rg_Mamager" runat="server" AutoGenerateColumns="False" GridLines="None"
                    Skin="WebBlue"  OnNeedDataSource="Rg_Mamager_NeedDataSource"
                    AllowPaging="True" Width="50%">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("LOG_ID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        <%--    <telerik:GridTemplateColumn HeaderText="Choose" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOpen" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridBoundColumn DataField="LOG_MESSAGE" HeaderText="Message" UniqueName="LOG_MESSAGE"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOG_TRACE_DESC" HeaderText="Stack Trace" UniqueName="LOG_TRACE_DESC">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOG_FORM_ERROR_DESC" HeaderText="Form Name" UniqueName="LOG_FORM_ERROR_DESC">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LOG_DATE" HeaderText="Date" UniqueName="LOG_DATE">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="ColDelete" meta:resourcekey="GridTemplateColumn"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_Delete" runat="server" OnCommand="lnk_Delete_Command" CommandArgument='<%# Eval("LOG_ID") %>'
                                        meta:resourcekey="lnk_Delete" Text="Delete" OnClientClick="return confirm('Do you want to delete this record?');"></asp:LinkButton></ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle AlwaysVisible="True" />
                    <FilterMenu Skin="WebBlue">
                    </FilterMenu>
                    <HeaderContextMenu Skin="WebBlue">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
