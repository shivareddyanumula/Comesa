<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Currency.aspx.cs" Inherits="Masters_frm_Currency" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="cnt_Currency" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Currency" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Currency">
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
                <asp:Label ID="lbl_CurrencyHeader" runat="server" Text="Currency" Font-Bold="True"
                    meta:resourcekey="lbl_CurrencyHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CU_page" runat="server" SelectedIndex="0"
                    Style="z-index: 10" Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CU_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>

                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_Currency" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                Skin="WebBlue" OnNeedDataSource="Rg_Currency_NeedDataSource"
                                                AllowPaging="True" meta:resourceKey="Rg_CurrencyResource1" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CURR_ID" HeaderText="ID" meta:resourcekey="CURR_ID"
                                                            UniqueName="CURR_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CURR_CODE"
                                                            HeaderText="Code" meta:resourcekey="CURR_CODE" UniqueName="CURR_CODE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CURR_DESCRIPTION"
                                                            HeaderText="Desc" meta:resourcekey="CURR_DESCRIPTION"
                                                            UniqueName="CURR_DESCRIPTION" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CURR_SYMBOL"
                                                            HeaderText="Symbol" meta:resourcekey="CURR_SYMBOL"
                                                            UniqueName="CURR_SYMBOL" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit"
                                                            meta:resourceKey="ColEdit" ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("CURR_ID") %>'
                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
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
                                                                OnCommand="lnk_Add_Command">Add</asp:LinkButton>
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
                                  href="~/Masters/Importsheets/Currency_details.xlsx">Download Currency Details Template</a> </td>
                              <td><strong>:</strong></td>
                              <td>
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </td>
                              <td>
                                  <asp:Button ID="btn_Imp_Businessunit" runat="server" Text="Import" 
                                      onclick="Btn_Imp_Currency_click" />
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
                    <telerik:RadPageView ID="Rp_CU_ViewDetails" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CurrencyID" runat="server" Visible="False"
                                        meta:resourceKey="lbl_CurrencyIDResource1"></asp:Label>
                                    <asp:Label ID="lbl_CurrencyCode" runat="server" Text="Code" meta:resourcekey="lbl_CurrencyCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CurrencyCode" runat="server" TabIndex="1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CurrencyCode" runat="server" ControlToValidate="rtxt_CurrencyCode"
                                        ErrorMessage="Enter Name" ValidationGroup="Controls"
                                        meta:resourceKey="rfv_rtxt_CurrencyCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CurrencyDesc" runat="server" Text="Desc" meta:resourcekey="lbl_CurrencyDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CurrencyDesc" runat="server" Skin="WebBlue" TabIndex="2"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CurrencyCountry" runat="server" meta:resourcekey="lbl_CurrencyCountry"
                                        Text="Country"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CurrencyCountry" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px"
                                        meta:resourceKey="rcmb_CurrencyCountry" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_CurrencyCountry" runat="server" ControlToValidate="rcmb_CurrencyCountry"
                                        ErrorMessage="Please Select Country" InitialValue="Select"
                                        ValidationGroup="Controls" meta:resourceKey="rfv_rcmb_CurrencyCountry">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CurrencySymbol" runat="server" meta:resourcekey="lbl_CurrencySymbol"
                                        Text="Symbol"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CurrencySymbol" runat="server" Skin="WebBlue" TabIndex="4"
                                        MaxLength="7">
                                    </telerik:RadTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lbl_CurrencyPrecision" runat="server" meta:resourcekey="lbl_CurrencyPrecision"
                                        Text="Percesion"></asp:Label>
                                </td>
                                <td class="style2">
                                    <b>:</b>
                                </td>
                                <td class="style2">
                                    <telerik:RadNumericTextBox ID="rntxt_CurrencyPrecision" runat="server" Skin="WebBlue" TabIndex="5"
                                        MaxLength="1" MinValue="0">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="style2">
                                    <asp:RequiredFieldValidator ID="rfv_rntxt_CurrencyPrecision" runat="server" ControlToValidate="rntxt_CurrencyPrecision"
                                        ErrorMessage="Please Enter Precision" ValidationGroup="Controls"
                                        meta:resourceKey="rfv_rntxt_CurrencyPrecision">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Currency" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourceKey="vs_Currency" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <%-- <input type="button" value="test" onclick="javascript:self.close();" />--%>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
        .style2 {
            height: 26px;
        }
    </style>

</asp:Content>