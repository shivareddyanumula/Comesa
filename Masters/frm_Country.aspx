<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Country.aspx.cs" Inherits="Masters_frm_Country" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="cnt_Country" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Country" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Country">
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
                <asp:Label ID="lbl_CountryHeader" runat="server" Text="Country" Font-Bold="True"></asp:Label>
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
                                            <telerik:RadGrid ID="Rg_Countries" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Countries_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="COUNTRY_ID" UniqueName="COUNTRY_ID" HeaderText="ID"
                                                            meta:resourcekey="COUNTRY_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="COUNTRY_CODE" UniqueName="COUNTRY_CODE" HeaderText="Code"
                                                            meta:resourcekey="COUNTRY_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="COUNTRY_NAME" UniqueName="COUNTRY_NAME" HeaderText="Name"
                                                            meta:resourcekey="COUNTRY_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("COUNTRY_ID") %>'
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <table>
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
                          <td> <a ID="D2" runat="server" 
                                  href="~/Masters/Importsheets/Country_Template.xlsx">Download Country Details Template</a> </td>
                              <td><strong>:</strong></td>
                              <td>
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </td>
                              <td>
                                  <asp:Button ID="btn_Imp_Businessunit" runat="server" Text="Import" 
                                      onclick="Btn_Imp_Businessunit_click" />
                              </td>
                          </tr>
                          </table>--%>

                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger  ControlID="btn_Imp_Businessunit"/>--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="35%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CountryID" runat="server" Visible="False" meta:resourcekey="lbl_CountryID"></asp:Label>
                                    <asp:Label ID="lbl_CountryCode" runat="server" Text="Name" meta:resourcekey="lbl_CountryCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CountryCode" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="1">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CountryCode" ControlToValidate="rtxt_CountryCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Code cannot be Empty"
                                        meta:resourcekey="rfv_rtxt_CountryCode">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_CountryCode" ErrorMessage="Enter only Alphabets for Country Name"
                                        ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CountryName" runat="server" Text="Description" meta:resourcekey="lbl_CountryDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CountryName" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="2">
                                    </telerik:RadTextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_CountryName" ControlToValidate="rtxt_CountryName"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Name cannot be Empty" 
                                        meta:resourcekey="rfv_rtxt_CountryName">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Update" Visible="False" ValidationGroup="Controls" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Save" Visible="False" ValidationGroup="Controls" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="4"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False" 
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