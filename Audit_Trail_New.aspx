<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Audit_Trail_New.aspx.cs" Inherits="Audit_Trail_New" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cnt_Jobs" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Country" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_AuditTrail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_AuditTrailHeader" runat="server" Text="Audit Trail" Font-Bold="True" style="font-size:small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_AuditTrail" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_AuditTrail" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">

                                    <telerik:RadGrid ID="Rg_AuditTrail" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_AuditTrail_NeedDataSource" AllowPaging="True" AllowSorting="true"
                                        meta:resourcekey="Rg_AuditTrail" AllowFilteringByColumn="true">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="AUD_ID" HeaderText="ID" meta:resourcekey="AUD_ID"
                                                    UniqueName="AUD_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_FormName" HeaderText="Form Name" meta:resourcekey="AUD_FormName"
                                                    UniqueName="AUD_FormName" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_ModifiedBy" HeaderText="Modified By" meta:resourcekey="AUD_ModifiedBy"
                                                    UniqueName="AUD_ModifiedBy" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_ModifiedDate" HeaderText="Modified Date" meta:resourcekey="AUD_ModifiedDate"
                                                    UniqueName="AUD_ModifiedDate" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_OldValue" HeaderText="Old Value" meta:resourcekey="AUD_OldValue"
                                                    UniqueName="AUD_OldValue" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_NewValue" HeaderText="New Value" meta:resourcekey="AUD_NewValue"
                                                    UniqueName="AUD_NewValue" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AUD_Desc" HeaderText="Description" meta:resourcekey="AUD_Desc"
                                                    UniqueName="AUD_Desc" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("AUD_ID") %>'
                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <%--<CommandItemTemplate>
                                        <div align="right">
                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                        </div>
                                    </CommandItemTemplate>--%>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>

                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

