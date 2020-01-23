<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Catagory.aspx.cs" Inherits="Masters_frm_Catagory" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="cnt_Category" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Categories" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Categories">
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
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
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
                <asp:Label ID="lbl_CategoryHeader" runat="server" Text="Category" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CG_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CG_ViewMain" runat="server" Selected="True">
                     <asp:UpdatePanel ID="updPanel1" runat="server">
                    <ContentTemplate>
                        <table align="center" width="70%">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="Rg_Categories" runat="server" AutoGenerateColumns="False"
                                        AllowFilteringByColumn="true" GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Categories_NeedDataSource"
                                        AllowPaging="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="CATEGORY_ID" HeaderText="ID" meta:resourcekey="CATEGORY_ID"
                                                    UniqueName="CATEGORY_ID" Visible="False" >
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CATEGORY_CODE" HeaderText="Name" meta:resourcekey="CATEGORY_CODE"
                                                    UniqueName="CATEGORY_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CATEGORY_DESC" HeaderText="Desc" meta:resourcekey="CATEGORY_DESC"
                                                    UniqueName="CATEGORY_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Over Time" meta:resourcekey="CATEGORY_ISOVERTIME"
                                                    UniqueName="CATEGORY_ISOVERTIME" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_CategoryIsOverTime" runat="server" Text='<%# (Convert.ToString(Eval("CATEGORY_ISOVERTIME")).ToUpper() == "TRUE" ? "Enabled": "Disabled") %>'
                                                            meta:resourcekey="lbl_CategoryIsOverTime"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bank Info" meta:resourcekey="CATEGORY_NEEDBANKINFO"
                                                    UniqueName="CATEGORY_NEEDBANKINFO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_CategoryIsBankInfo" runat="server" Text='<%# (Convert.ToString(Eval("CATEGORY_NEEDBANKINFO")).ToUpper() == "TRUE" ? "Enabled": "Disabled") %>'
                                                            meta:resourcekey="lbl_CategoryIsBankInfo"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("CATEGORY_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command" Text="Edit"></asp:LinkButton>
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
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command"
                                                        Text="Add"></asp:LinkButton>
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
                            <tr>
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
                          <tr>
                          <td>
                              &nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a ID="D1" runat="server" 
                                  href="~/Masters/Importsheets/Master_CategoryTemplate.xlsx">Download Category Details 
                              Template</a> </td>
                              <td><strong>:</strong></td>
                              <td>
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </td>
                              <td>
                                  <asp:Button ID="btn_Imp_category" runat="server" Text="Import" 
                                      onclick="Btn_Imp_Category_click" />
                              </td>
                          </tr>
                          </table>
                             </td>
                           
                            </tr>
                        </table>
                     </ContentTemplate>
                     <Triggers>
                <asp:PostBackTrigger  ControlID="btn_Imp_category"/>

                     </Triggers>
                     </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CG_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                </td>
                                <td align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryID" runat="server" Visible="False" meta:resourcekey="lbl_CategoryID"></asp:Label>
                                    <asp:Label ID="lbl_CategoryCode" runat="server" Text="Name" meta:resourcekey="lbl_CategoryCode"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_CategoryCode" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CategoryCode" runat="server" ControlToValidate="rtxt_CategoryCode"
                                        ErrorMessage="Name cannot be Empty" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_CategoryCode">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" 
                                        ControlToValidate="rtxt_CategoryCode" ErrorMessage="Enter only Alphabets for Category Name" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryDesc" runat="server" Text="Description" meta:resourcekey="lbl_CategoryDesc"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_CategoryDesc" runat="server"
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="rfv_rtxt_CategoryDesc" runat="server" ControlToValidate="rtxt_CategoryDesc"
                                        ErrorMessage="Description cannot be Empty" ValidationGroup="Controls" 
                                        meta:resourcekey="rfv_rtxt_CategoryDesc">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryOverTime" runat="server" Text="OverTime Enabled" meta:resourcekey="lbl_CategoryOverTime"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryOverTime" runat="server" meta:resourcekey="chk_CategoryOverTime" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryNeedBankInfo" runat="server" Text="Bank Info Needed" meta:resourcekey="lbl_CategoryNeedBankInfo"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryNeedBankInfo" runat="server" meta:resourcekey="chk_CategoryNeedBankInfo" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryCurrencyNeeded" runat="server" meta:resourcekey="lbl_CategoryCurrencyNeeded"
                                        Text="Currency Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryCurrencyNeeded" runat="server" meta:resourcekey="chk_CategoryCurrencyNeeded" Enabled="false" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryAgeNeeded" runat="server" meta:resourcekey="lbl_CategoryAgeNeeded"
                                        Text="Age Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryAgeNeeded" runat="server" 
                                        meta:resourcekey="chk_CategoryAgeNeeded" Enabled="False" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryDateFormatNeeded" runat="server" meta:resourcekey="lbl_CategoryDateFormatNeeded"
                                        Text="DateFormat Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryDateFormatNeeded" runat="server" meta:resourcekey="chk_CategoryDateFormatNeeded" Enabled="false" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryAddressNeeded" runat="server" meta:resourcekey="lbl_CategoryAddressNeeded"
                                        Text="Address Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryAddressNeeded" runat="server" meta:resourcekey="chk_CategoryAddressNeeded" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryCountryNeeded" runat="server" meta:resourcekey="lbl_CategoryCountryNeeded"
                                        Text="Country Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryCountryNeeded" runat="server" meta:resourcekey="chk_CategoryCountryNeeded" Enabled="false"/>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryFiscalYearNeeded" runat="server" meta:resourcekey="lbl_CategoryFiscalYearNeeded"
                                        Text="Fiscal Year Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryFiscalYearNeeded" runat="server" meta:resourcekey="chk_CategoryFiscalYearNeeded" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryCalendarYear" runat="server" meta:resourcekey="lbl_CategoryCalendarYear"
                                        Text="Calendar Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryCalendarYear" runat="server" meta:resourcekey="chk_CategoryCalendarYear" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryPaymentMethodsNeeded" runat="server" meta:resourcekey="lbl_CategoryPaymentMethodsNeeded"
                                        Text="Payment Methods Needed"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_CategoryPaymentMethodsNeeded" runat="server" meta:resourcekey="chk_CategoryPaymentMethodsNeeded" Enabled="false" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Localisation" runat="server" meta:resourcekey="lbl_Localisation"
                                        Text="Localisation"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Localisation" runat="server" meta:resourcekey="chk_CategoryPaymentMethodsNeeded" Enabled="false"/>
                                </td>
                                <td>
                                 &nbsp;
                                    <%-- <asp:RequiredFieldValidator ID="rfv_chk_Localisation" runat="server" ControlToValidate="chk_Localisation"
                                        ErrorMessage="Localisation cannot be Empty" ValidationGroup="Controls" meta:resourcekey="rfv_chk_Localisation">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
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
                                    <br />
                                    <asp:ValidationSummary ID="vs_Category" runat="server" meta:resourcekey="vs_Category"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    
</asp:Content>

