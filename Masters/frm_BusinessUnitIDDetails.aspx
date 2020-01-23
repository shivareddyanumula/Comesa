<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_BusinessUnitIDDetails.aspx.cs" Inherits="Masters_frm_BusinessUnitIDDetails"
    Culture="auto" UICulture="auto" %>



<asp:Content ID="cnt_BusinessUnitIDDetails" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_BusinessUnitIDDetails" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_BusinessUnitIDDetails">
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
            <td>
                <telerik:RadMultiPage ID="Rm_BUIDDetails_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_BUIDDetails_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>

                                <table align="center" width="70%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lbl_BUIDHeader" runat="server" Text="Business Unit Other Information" Font-Bold="True"
                                                meta:resourcekey="lbl_BUIDHeader"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_BUIDDetails" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                OnNeedDataSource="Rg_BUIDDetails_NeedDataSource" AllowFilteringByColumn="true"
                                                AllowPaging="True">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="BUIDDETAILS_ID" UniqueName="BUIDDETAILS_ID" HeaderText="ID" AllowFiltering="false"
                                                            meta:resourcekey="BUIDDETAILS_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUIDDETAILS_BUID" UniqueName="BUIDDETAILS_BUID" AllowFiltering="true"
                                                            HeaderText="Business Unit " meta:resourcekey="BUIDDETAILS_BUID" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUIDDETAILS_NAME" UniqueName="BUIDDETAILS_NAME" AllowFiltering="true"
                                                            HeaderText=" Name" meta:resourcekey="BUIDDETAILS_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUIDDETAILS_DESCRIPTION" UniqueName="BUIDDETAILS_DESCRIPTION" AllowFiltering="true"
                                                            HeaderText="Description" meta:resourcekey="BUIDDETAILS_DESCRIPTION" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUIDDETAILS_VALUE" UniqueName="BUIDDETAILS_VALUE" AllowFiltering="true"
                                                            HeaderText="Value" meta:resourcekey="BUIDDETAILS_VALUE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("BUIDDETAILS_ID") %>'
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
                                                <FilterMenu>
                                                </FilterMenu>
                                                <HeaderContextMenu>
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--  <table>
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
                          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a ID="D2" runat="server" 
                                  href="~/Masters/Importsheets/BusinessUniDetails_temp.xlsx">Download Business UnitDetailsDetails 
                              Template</a> </td>
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
                                <%-- <asp:PostBackTrigger  ControlID="btn_Imp_Businessunit"/>--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_BUIDDetails_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_BankBranchDetails" runat="server" Text="Business Unit Other Information"
                                        meta:resourcekey="lbl_BankBranchDetails"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BUCode" runat="server" Text="Business Unit" meta:resourcekey="lbl_BUCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BUCode" runat="server" TabIndex="1"
                                        meta:resourcekey="rcmb_BUCode" MarkFirstMatch="true" MaxHeight="120px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="DIPL" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUCode" runat="server" ControlToValidate="rcmb_BUCode"
                                        meta:resourcekey="rfv_rcmb_BUCode" ErrorMessage="Please Select Business Unit"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BUIDDetails_ID" runat="server" Visible="False" meta:resourcekey="lbl_BUIDDetails_ID"></asp:Label>
                                    <asp:Label ID="lbl_BUIDDetails_Name" runat="server" Text="Name" meta:resourcekey="lbl_BUIDDetails_Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BUIDDetails_Name" TabIndex="2"
                                        runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BUIDDetails_Name" ControlToValidate="rtxt_BUIDDetails_Name"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name"
                                        meta:resourcekey="rfv_rtxt_BUIDDetails_Name">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BUIDDetails_Desc" runat="server" Text="Description" meta:resourcekey="lbl_BUIDDetails_Desc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BUIDDetails_Desc" runat="server" TabIndex="3"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BUIDDetails_Desc" ControlToValidate="rtxt_BUIDDetails_Desc"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Description"
                                        meta:resourcekey="rfv_rtxt_BUIDDetails_Desc">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BUIDDetails_Value" runat="server" Text="Value" meta:resourcekey="lbl_BUIDDetails_Value"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BUIDDetails_Value" runat="server" TabIndex="4"
                                        MaxLength="12">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BUIDDetails_Value" ControlToValidate="rtxt_BUIDDetails_Value"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Value"
                                        meta:resourcekey="rfv_rtxt_BUIDDetails_Value">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_BUIDDetails_Value"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="6"
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
