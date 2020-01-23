<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_InterviewRounds.aspx.cs" MasterPageFile="~/SMHRMaster.master"  Inherits="Recruitment_frm_InterviewRounds" %>


<script runat="server">
  
</script>

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
                <asp:Label ID="lbl_Heading" runat="server" Font-Bold="True" 
                    meta:resourcekey="DESIGNATION"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rm_MR_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                     Width="990px" Height="490px" ScrollBars="Auto" 
                    >
                    <telerik:RadPageView ID="RP_GRIDVIEW" runat="server" meta:resourcekey="RP_GRIDVIEW" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="RG_InterviewRound" runat="server"  Skin="WebBlue"  GridLines="None"
                                        AutoGenerateColumns="False" OnNeedDataSource="RG_InterviewPriority_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="True" AllowSorting="True" >
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_ID" HeaderText="ID" 
                                                    meta:resourcekey="HR_MASTER_ID" UniqueName="HR_MASTER_ID" 
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Name" 
                                                    meta:resourcekey="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_DESC" HeaderText="Description" 
                                                    meta:resourcekey="HR_MASTER_DESC" UniqueName="HR_MASTER_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                               <%-- <telerik:GridTemplateColumn AllowFiltering="False" 
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Master_Edit" runat="server" 
                                                            CommandArgument='<%# Eval("HR_MASTER_ID") %>' 
                                                            meta:resourcekey="lnk_Master_EditResource1" OnCommand="lnk_MasterEdit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" 
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                           <%-- <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" 
                                                        OnClick="lnk_Add_Click"> Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>--%>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu  Skin="WebBlue" >
                                        </FilterMenu>
                                        <HeaderContextMenu  Skin="WebBlue" >
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        
     <table align="center">
     <tr>
     <td align="center">
     <asp:UpdatePanel ID="up_masters" runat="server">
     <ContentTemplate>
     <table align="center">
     <tr align="center">
     <td align="center" colspan="3" >Import 
     <asp:Label ID="lblheader" runat="server" >
     </asp:Label>  Details
     </td>
     </tr>
     <tr>
     <td>
           <a href="~/Masters/Importsheets/Import_Masters.xlsx" runat="server" id="A2">Download 
           <asp:Label ID="ldl_dl" runat="server"></asp:Label>  Template</a>
     </td>
     <td>
    <asp:FileUpload ID="fu_masters" runat="server" />      
     </td>
     <td>
     <asp:Button ID="btn_import" runat="server" Text="Import" 
             onclick="btn_import_Click" />
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
                        <table align="center" width="20%">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_Details" runat="server" meta:resourcekey="DESIGNATION"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Code" runat="server" Style="text-align: left" 
                                        ></asp:Label>
                                    <asp:Label ID="lbl_Master_ID" runat="server" Text="Interview Round" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_InterviewCode" runat="server" 
                                        EnableEmbeddedSkins ="false" MaxLength="50"  
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rftxt_MasterCode" runat="server" ControlToValidate="rntxt_InterviewCode"
                                        ErrorMessage=" Please Enter Interview Code" ValidationGroup="Controls" 
                                        >*</asp:RequiredFieldValidator>
                                        
                                         
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Desc" runat="server" Text="Interview Name :" 
                                        ></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_InterviewName" runat="server" 
                                        EnableEmbeddedSkins ="false" MaxLength="50" >
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Save_Click" Text="Update" Visible="False"
                                        ValidationGroup="Controls" Width="61px" 
                                        meta:resourcekey="btn_Edit" />
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" Visible="False"
                                        ValidationGroup="Controls" meta:resourcekey="btn_Save" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
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
