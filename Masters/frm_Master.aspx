<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Master.aspx.cs" Inherits="Masters_frm_Master" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:radajaxmanagerproxy id="RAM_Master" runat="server">
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
    </telerik:radajaxmanagerproxy>
    <telerik:radwindowmanager id="RWM_MASTERS" runat="server" style="z-index: 8000">
    </telerik:radwindowmanager>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="lbl_Heading" runat="server" Font-Bold="True"
                    meta:resourcekey="DESIGNATION"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage id="rm_MR_Page" runat="server" selectedindex="0" style="z-index: 10"
                    width="990px" height="490px" scrollbars="Auto">
                    <telerik:RadPageView ID="RP_GRIDVIEW" runat="server" meta:resourcekey="RP_GRIDVIEW" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Master" runat="server" Skin="WebBlue" GridLines="None"
                                        AutoGenerateColumns="False" OnNeedDataSource="RG_Master_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="True" AllowSorting="True">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_ID" HeaderText="ID"
                                                    meta:resourcekey="HR_MASTER_ID" UniqueName="HR_MASTER_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Type of Cost"
                                                    meta:resourcekey="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE">
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_DESC" HeaderText="Description"
                                                    meta:resourcekey="HR_MASTER_DESC" UniqueName="HR_MASTER_DESC">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_STATUS" HeaderText="Status"
                                                    meta:resourcekey="HR_MASTER_STATUS" UniqueName="HR_MASTER_STATUS">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridTemplateColumn HeaderText="Status" Visible="false"  AllowFiltering="true" DataField="HR_MASTER_STATUS"  >
                                                    <ItemTemplate>
                                                        <%# (Boolean.Parse(Eval("HR_MASTER_STATUS").ToString())) ? "Active" : "InActive" %>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                              
                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Master_Edit" runat="server"
                                                            CommandArgument='<%# Eval("HR_MASTER_ID") %>'
                                                            meta:resourcekey="lnk_Master_EditResource1" OnCommand="lnk_MasterEdit_Command">Edit</asp:LinkButton>
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
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add"
                                                        OnClick="lnk_Add_Click"> Add</asp:LinkButton>
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

                        <table id="tblImportTemplate" runat="server" visible="false" align="center">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="up_masters" runat="server">
                                        <ContentTemplate>
                                            <table align="center">
                                                <tr align="center">
                                                    <td align="center" colspan="3">Import 
     <asp:Label ID="lblheader" runat="server">
     </asp:Label>
                                                        Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="~/Masters/Importsheets/Import_Masters.xlsx" runat="server" id="A2">Download 
           <asp:Label ID="ldl_dl" runat="server"></asp:Label>
                                                            Template</a>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="fu_masters" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_import" runat="server" Text="Import"
                                                            OnClick="btn_import_Click" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_import" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server"
                        meta:resourcekey="RP_FORMVIEW">
                        <table align="center" >
                            <tr>
                                <td colspan="3" align="center">

                                    <asp:Label ID="lbl_Details" runat="server" meta:resourcekey="DESIGNATION"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Code" runat="server"  Text="Code:"
                                        meta:resourcekey="lbl_Code"></asp:Label>
                                    <asp:Label ID="lbl_Master_ID" runat="server" Text="lbl_Master_ID"
                                        Visible="False" meta:resourcekey="lbl_Master_ID"></asp:Label>
                                </td>
                                <td>:
                                   
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_MasterCode" runat="server"
                                        EnableEmbeddedSkins="false" MaxLength="200" TabIndex="1"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rftxt_MasterCode" runat="server" ControlToValidate="rtxt_MasterCode"
                                        ErrorMessage="Please Enter Name" ValidationGroup="Controls"
                                        meta:resourcekey="rftxt_MasterCode">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_rtxt_MasterCode" runat="server" ControlToValidate="rtxt_MasterCode" ErrorMessage="Enter only Alphabets for Type of Cost"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>

                                </td>
                              
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Desc" runat="server" Text="Description:"
                                        meta:resourcekey="lbl_Desc"></asp:Label>
                                </td>
                                <td>:
                                    
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_MasterDesc" runat="server"
                                        EnableEmbeddedSkins="false" MaxLength="200" TabIndex="2">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rftxt_MasterDesc" runat="server" ControlToValidate="rtxt_MasterDesc" ErrorMessage="Please Enter Description" ValidationGroup="Controls" Text="*" Enabled="false"></asp:RequiredFieldValidator>
            </td>
                                </tr>

        
        <tr id="isactive" runat="server" visible="false">
            <td>
                <asp:Label ID="lbl_isactive1" runat="server" Text="IsActive:"></asp:Label>
            </td>
            <td>
                <strong>:</strong>
            </td>
            <td>
                <asp:CheckBox ID="rad_isactive1" runat="server" TabIndex="3" Checked="true" Visible="true"></asp:CheckBox>
            </td>

        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Save_Click" Text="Update" Visible="False" TabIndex="4"
                    ValidationGroup="Controls" Width="61px" 
                    meta:resourcekey="btn_Edit" CausesValidation="False" />
                <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" Visible="False" TabIndex="4"
                    ValidationGroup="Controls" meta:resourcekey="btn_Save" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="5"
                    OnClick="btn_Cancel_Click" meta:resourcekey="btn_Cancel" />
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