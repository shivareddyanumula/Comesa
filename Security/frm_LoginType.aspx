<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LoginType.aspx.cs" Inherits="Security_frm_LoginType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_LoginTypeHeader" runat="server" Text="User Group" Font-Bold="True"
                    meta:resourcekey="lbl_LoginTypeHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_LT_page" runat="server" SelectedIndex="0">
                    <%--Height="490px" ScrollBars="Auto"> Removing Scroll--%>
                    <telerik:RadPageView ID="Rp_LT_ViewMain" runat="server"> 
                        <telerik:RadGrid  ID="Rg_LoginType" runat="server" AutoGenerateColumns="False" GridLines="None"
                             Skin="WebBlue"   OnNeedDataSource ="Rg_LoginType_NeedDataSource" AllowFilteringByColumn="true">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="LOGTYP_ID" UniqueName="LOGTYP_ID" HeaderText="ID"
                                        meta:resourcekey="LOGTYP_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGTYP_CODE" UniqueName="LOGTYP_CODE" HeaderText="User Group"
                                        meta:resourcekey="LOGTYP_CODE" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGTYP_DESC" UniqueName="LOGTYP_DESC" HeaderText="Description"
                                        meta:resourcekey="LOGTYP_DESC" HeaderStyle-HorizontalAlign="Center">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LOGTYP_ID") %>' 
                                                OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton></div>
                                </CommandItemTemplate>
                            </MasterTableView>
                            <PagerStyle AlwaysVisible="true" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_LT_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_LoginTypeDetails" runat="server" Text="Details" meta:resourcekey="lbl_LoginTypeDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LoginTypeID" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_LoginTypeCode" runat="server" Text="User Group" meta:resourcekey="lbl_LoginTypeCode"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_LoginTypeCode" Style="text-transform: uppercase;" runat="server"
                                           MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_LoginTypeCode" runat="server" 
                                        ControlToValidate="rtxt_LoginTypeCode" ErrorMessage="Please Specify User Group" 
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rev_rtxt_LoginTypeCode" runat="server" ControlToValidate="rtxt_LoginTypeCode" ErrorMessage="Please Enter only Alphabets for User Group" 
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LoginTypeName" runat="server" Text="Description" meta:resourcekey="lbl_LoginTypeDesc"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_LoginTypeName"  runat="server"  Skin="WebBlue" 
                                        MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_LoginTypeName" runat="server" 
                                        ControlToValidate="rtxt_LoginTypeName" ErrorMessage="Please Specify Description" 
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="rev_rtxt_LoginTypeName" runat="server" ControlToValidate="rtxt_LoginTypeName" ErrorMessage="Please Enter only Alphabets for Description" 
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_LoginType" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                                <td align="center">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
