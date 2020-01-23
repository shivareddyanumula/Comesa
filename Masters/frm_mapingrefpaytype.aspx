<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_mapingrefpaytype.aspx.cs" Inherits="frm_mapingrefpaytype" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" class="style1">
        <tr>
            <td class="style2">&nbsp;</td>
            <td align="center">
                <asp:Label ID="lbl_MappingPayitemsHeader" runat="server" Text="Mapping Reference Pay Items" Font-Bold="True"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">&nbsp;</td>
            <td>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <telerik:RadGrid ID="rg_payrollrefitm" runat="server"
                            AutoGenerateColumns="False" OnNeedDataSource="rg_NeedDataSource"
                            GridLines="None" AllowPaging="True" AllowFilteringByColumn="true">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TYPE" UniqueName="TYPE" HeaderText="Pay Item Reference" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ID" UniqueName="ID" Visible="false" HeaderText="ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME" HeaderText="Organization Pay Item" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ORGANISATION_NAME" UniqueName="ORGANISATION_NAME" HeaderText="Organization" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_ID" HeaderText="Business Unit" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="STATUS" UniqueName="STATUS" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" OnCommand="link_Edit_Command" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                Text="Edit">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="link_Add" runat="server" OnCommand="link_Add_Command"
                                            Text="Add"></asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                            </MasterTableView>
                            <PagerStyle AlwaysVisible="True" />
                            <FilterMenu Skin="WebBlue">
                            </FilterMenu>
                            <HeaderContextMenu Skin="WebBlue">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <table align="center">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Organization"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Organisation" runat="server" AutoPostBack="True"
                                        MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="ldl_businessunit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_businessunit" runat="server" AutoPostBack="True" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_businessunit" runat="server" ControlToValidate="rcmb_businessunit"
                                        ErrorMessage="Please Select Business unit " Text="*" ValidationGroup="Controls" InitialValue="Select"
                                        meta:resourcekey="rcmb_businessunit"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label1" runat="server" Text="Pay Item reference Id"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Payitemrefer" runat="server" AutoPostBack="True" MarkFirstMatch="true" MaxHeight="120px" TabIndex="2" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Payitemrefer" runat="server" ControlToValidate="rcmb_Payitemrefer"
                                        ErrorMessage="Please Select Pay Item reference Id" Text="*" ValidationGroup="Controls" InitialValue="Select"
                                        meta:resourcekey="rcmb_Payitemrefer"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label3" runat="server" Text="Oraganization Payitems"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmd_orgpayitem" runat="server" MarkFirstMatch="true" MaxHeight="120px" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmd_orgpayitem" runat="server" ControlToValidate="rcmd_orgpayitem"
                                        ErrorMessage="Please Select Organization Pay items" Text="*" ValidationGroup="Controls" InitialValue="Select"
                                        meta:resourcekey="rcmd_orgpayitem"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label4" runat="server" Text="status"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong></td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_status" runat="server"
                                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="100px" AutoPostBack="true"
                                        TabIndex="4" OnSelectedIndexChanged="rcmb_status_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="0" />
                                            <telerik:RadComboBoxItem Text="Inactive" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4" align="right"></td>
                                <td></td>
                                <td>&nbsp;
                                        <br />
                                    <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" TabIndex="5"
                                        Text="Update" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_save" runat="server" Text="Save" TabIndex="5"
                                        OnClick="btn_save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" TabIndex="6"
                                        Text="Cancel" />
                                    <br />
                                    <asp:ValidationSummary ID="vs_Mappingpayitem" runat="server" meta:resourceKey="vs_Mappingpayitem"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style3" colspan="3">&nbsp;</td>
                            </tr>
                        </table>
                        <div>
                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>