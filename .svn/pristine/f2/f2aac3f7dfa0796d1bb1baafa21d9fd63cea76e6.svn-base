<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TDS_Consultant.aspx.cs" Inherits="Payroll_frm_TDS_Consultant" %>

<asp:Content ID="Cnt_TDS_Consultant" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_TDS_Consultant_Header" runat="server" Text="TDS Consultant" Font-Bold="True"
                    meta:resourcekey="lbl_TDS_Consultant_Header"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_TDS_Consultant_Page" runat="server" SelectedIndex="0"
                    Style="z-index: 10" Width="990px" Height="490px"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_TDS_Consultant_Grid_Page" runat="server" Selected="True">
                        <table align="center" width="60%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_TDS_Consultant" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" AllowPaging="True"
                                        OnNeedDataSource="Rg_TDS_Consultant_NeedDataSource" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TDS_ID" HeaderText="ID" meta:resourcekey="TDS_ID"
                                                    UniqueName="TDS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_COUNTRY_ID"
                                                    HeaderText="Country" meta:resourcekey="TDS_COUNTRY_ID"
                                                    UniqueName="TDS_COUNTRY_ID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COUNTRY_CODE"
                                                    HeaderText="Country" meta:resourcekey="COUNTRY_CODE"
                                                    UniqueName="COUNTRY_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TDS_Value"
                                                    HeaderText="Value" meta:resourcekey="TDS_Value"
                                                    UniqueName="TDS_Value">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TDS_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add"
                                                        OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <ActiveItemStyle HorizontalAlign="Center" />
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_TDS_Consultant_Details_Page" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_TDS_Consultant_Details" runat="server" Text="Details" meta:resourcekey="lbl_TDS_Consultant_Details"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TDS_Consultant_ID" runat="server" Visible="False" meta:resourcekey="lbl_TDS_Consultant_ID"></asp:Label>
                                    <asp:Label ID="lbl_TDS_Consultant_CtryCode" runat="server" Text="Name" meta:resourcekey="lbl_TDS_Consultant_CtryCode"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_TDS_Consultant_CtryCode" MarkFirstMatch="true" runat="server" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_TDS_Consultant_CtryCode" runat="server" ControlToValidate="rcmb_TDS_Consultant_CtryCode"
                                        ErrorMessage="Country cannot be Empty" ValidationGroup="Controls" meta:resourcekey="rfv_TDS_Consultant_CtryCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TDS_Consultant_Value" runat="server" Text="Value" meta:resourcekey="lbl_TDS_Consultant_Value"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_TDS_Consultant_Value" runat="server" Skin="WebBlue">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_TDS_Consultant_Value" runat="server" ControlToValidate="rntxt_TDS_Consultant_Value"
                                        ErrorMessage="Value cannot be Empty" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rntxt_TDS_Consultant_Value">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_TDS" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vs_TDS" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>