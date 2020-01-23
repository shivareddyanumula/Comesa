<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Assets_Master.aspx.cs" Inherits="Masters_frm_Assets_Master" %>

<script runat="server"></script>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Master" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Master">
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
    <telerik:RadWindowManager ID="RWM_MASTERS" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="lbl_AssetMasterHeader" runat="server" Text="Asset Master" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rm_MR_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="RP_GRIDVIEW" Selected="true" runat="server">
                        <table align="center" width="50%">

                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Asset_Master" runat="server" Skin="WebBlue" GridLines="None"
                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                                        AllowFilteringByColumn="True" AllowSorting="True" OnNeedDataSource="RG_Asset_Master_NeedDataSource">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top" EnableNoRecordsTemplate="true" ShowHeadersWhenNoRecords="true">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="ASSET_CODE" HeaderText="Asset Code" HtmlEncode="true"
                                                    UniqueName="ASSET_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ASSET_NAME" HeaderText="Asset Name"
                                                    UniqueName="ASSET_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" HeaderText="Department Name"
                                                    UniqueName="DEPARTMENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    UniqueName="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Status" DataField="ASSET_IS_ACTIVE">
                                                    <ItemTemplate>
                                                        <%# (Boolean.Parse(Eval("ASSET_IS_ACTIVE").ToString())) ? "Active" : "InActive" %>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%# Eval("ASSET_ID") %>'
                                                            Text="Edit"></asp:LinkButton>
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
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_Add_Click"> Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
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

                        <table align="center">
                            <tr>
                                <td align="center">&nbsp;</td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server"
                        meta:resourcekey="RP_FORMVIEW">
                        <table align="center" width="20%">
                            <tr>

                                <td colspan="3" align="center" nowrap="nowrap">
                                    <asp:Label ID="lbl_Asset_ID" runat="server" Visible="False" Text="Asset ID">
                                    </asp:Label>
                                    <asp:Label ID="lbl_Details" runat="server" meta:resourcekey="DESIGNATION"></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_BusinessUnit" OnSelectedIndexChanged="rad_BusinessUnit_SelectedIndexChanged" runat="server"
                                        EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1" AutoPostBack="True" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rad_BusinessUnit"
                                        InitialValue="Select" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Directorate" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" runat="server"
                                        EnableEmbeddedSkins="false" AutoPostBack="True" MaxLength="50" TabIndex="2" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rad_Directorate"
                                        InitialValue="Select" ErrorMessage="Please Select Directorate" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssetDepartment" runat="server" Text="Department:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_AssetDepartment" runat="server" Filter="Contains"
                                        EnableEmbeddedSkins="false" MaxLength="50" TabIndex="3" MarkFirstMatch="true" MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_AssetDepartment" runat="server" ControlToValidate="rad_AssetDepartment"
                                        InitialValue="Select" ErrorMessage="Please Select Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap">
                                    <asp:Label ID="lbl_AssetCode" runat="server" Style="text-align: left" Text="Asset Code:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_AssetCode" runat="server"
                                        EnableEmbeddedSkins="false" MaxLength="50" TabIndex="4"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rftxt_AssetCode" runat="server" ControlToValidate="rtxt_AssetCode"
                                        ErrorMessage="Please Enter Asset Code" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="rtxt_AssetCode"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td nowrap="nowrap">
                                    <asp:Label ID="lbl_AssetName" runat="server" Text="Asset Name:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_AssetName" runat="server"
                                        EnableEmbeddedSkins="false" MaxLength="100" TabIndex="5">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rftxt_AssetName" runat="server" ControlToValidate="rtxt_AssetName"
                                        ErrorMessage="Please Enter Asset Name" ValidationGroup="Controls">*
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_AssetName"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IsAssetActive" runat="server" Text="Is Active:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IsAssetActive" runat="server" Enabled="false" TabIndex="6"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" TabIndex="7"
                                        ValidationGroup="Controls" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" TabIndex="7"
                                        ValidationGroup="Controls" Visible="false" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="8"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vg_Master" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>