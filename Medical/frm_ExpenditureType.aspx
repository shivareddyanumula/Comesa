<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ExpenditureType.aspx.cs" Inherits="Medical_frm_ExpenditureType" %>

<asp:Content ID="cnt_ExpenditureType" ContentPlaceHolderID="cphDefault" Runat="Server">
    <br />
    <br />
    <br />
   <telerik:RadAjaxManagerProxy ID="RAM_Expenditure" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Expenditure">
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
    <table align="center" style="vertical-align: top;">
                <tr>
    <td>
     <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    </td>
    </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ExpenditureHeader" runat="server" Text="Expenditure Type" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                         <asp:UpdatePanel ID="updPanel1" runat="server">
                    <ContentTemplate>
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="Rg_Expenditure" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Expenditure_NeedDataSource"
                                        AllowPaging="True" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EXPENDITURE_ID" UniqueName="EXPENDITURE_ID" HeaderText="ID"
                                                    meta:resourcekey="EXPENDITURE_ID" Visible="False">
                                                </telerik:GridBoundColumn>                                                
                                                <telerik:GridBoundColumn DataField="EXPENDITURE_NAME" UniqueName="EXPENDITURE_NAME" HeaderText="Expenditure Type"
                                                    meta:resourcekey="EXPENDITURE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="EXPENDITURE_DESC" UniqueName="EXPENDITURE_DESC" HeaderText="Description"
                                                    meta:resourcekey="EXPENDITURE_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EXPENDITURE_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
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
                            </tr>                            <tr>
                            <td>
                            
                                                      <table>
                          <tr>
                          <td></td>
                          <td></td>
                          <td></td>
                          <td></td>
                          <td></td>
                          
                          <td></td>
                          </tr>
                         
                          </table>

                            </td>
                            </tr>
                        </table>
                        </ContentTemplate>
                       
                        </asp:UpdatePanel>                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="35%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ExpenditureID" runat="server" Visible="false" ></asp:Label>
                                    <asp:Label ID="lbl_ExpenditureName" runat="server" Text="Expenditure Type" meta:resourcekey="lbl_ExpenditureName"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_ExpenditureName" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ExpenditureName" ControlToValidate="rtxt_ExpenditureName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Expenditure Type"
                                        meta:resourcekey="rfv_rtxt_ExpenditureName">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_ExpenditureName" ErrorMessage="Enter only Alphabets for Expenditure Type"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ExpenditureDesc" runat="server" Text="Description" meta:resourcekey="lbl_ExpenditureDesc"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_ExpenditureDesc" runat="server" Skin="WebBlue"  TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false"/>
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false"/>
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

