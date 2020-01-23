<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_BusinessUnitBanks.aspx.cs" Inherits="Masters_frm_BusinessUnitBanks"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="cnt_BusinessUnitBanks" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

        <script language="javascript" type="text/javascript">

            function checkboxClick(control) {
                if (control.checked == true) {
                    if (!confirm('Do you want to Change this Bank as Default for This Business Unit')) {
                        control.checked = false;
                    }
                }
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadAjaxManagerProxy ID="RAM_BusinessUnitBanks" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Clients">
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
                <asp:Label ID="lbl_BusinessUnitBankHeader" runat="server" Text="Business Unit Bank"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_BB_page" runat="server" SelectedIndex="0"
                    Style="z-index: 10" Width="990px" Height="590px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_BB_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>

                                <table align="center" width="80%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_BusinessUnitBank" runat="server" AutoGenerateColumns="False"
                                                Skin="WebBlue" GridLines="None" OnNeedDataSource="Rg_BusinessUnitBank_NeedDataSource"
                                                OnItemDataBound="Rg_BusinessUnitBank_ItemDataBound" AllowFilteringByColumn="true"
                                                AllowPaging="True">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="BUSUNTBANK_ID" UniqueName="BUSUNTBANK_ID" HeaderText="ID"
                                                            Visible="False" meta:resourcekey="GridBoundColumnResource1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSUNTBANK_BUSINESSUNIT_ID" UniqueName="BUSUNTBANK_BUSINESSUNIT_ID"
                                                            HeaderText="Business Unit" meta:resourcekey="BUSUNTBANK_BUSINESSUNIT_ID" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSUNTBANK_NAME" UniqueName="BUSUNTBANK_NAME"
                                                            HeaderText=" Name" meta:resourcekey="BUSUNTBANK_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSUNTBANK_ADDRESS" UniqueName="BUSUNTBANK_ADDRESS"
                                                            HeaderText="Address" meta:resourcekey="BUSUNTBANK_ADDRESS" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSUNTBANK_ACCOUNTNO" HeaderText="Account No"
                                                            UniqueName="BUSUNTBANK_ACCOUNTNO" meta:resourcekey="BUSUNTBANK_ACCOUNTNO" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                            UniqueName="STATUS" meta:resourcekey="STATUS" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DEFAULT" HeaderText="Default"
                                                            UniqueName="DEFAULT" meta:resourcekey="DEFAULT" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="BUSUNTBANK_ISACTIVE" HeaderText="Status"
                                                            meta:resourcekey="BUSUNTBANK_ISACTIVE" ItemStyle-HorizontalAlign="Left" Visible="false"
                                                            DataType="System.String" AllowFiltering="true" AutoPostBackOnFilter="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_BusinessUnitBankIsActive" runat="server"
                                                                    Text='<%# (Convert.ToString(Eval("BUSUNTBANK_ISACTIVE")).ToUpper() == "TRUE" ? "Active": "InActive") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="BUSUNTBANK_ISDEFAULT" HeaderText="Is Default" Visible="false"
                                                            meta:resourcekey="BUSUNTBANK_ISDEFAULT" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_BusinessUnitBankIsDefault" runat="server"
                                                                    Text='<%# (Convert.ToString(Eval("BUSUNTBANK_ISDEFAULT")).ToUpper() == "TRUE" ? "True": "False") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("BUSUNTBANK_ID") %>'
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
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_AddResource1" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView><PagerStyle AlwaysVisible="True" />
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
                          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a ID="D2" runat="server" 
                                  href="~/Masters/Importsheets/BusinessUnitBnk_Template.xlsx">Download Business UnitBank Details 
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
                    <telerik:RadPageView ID="Rp_BB_ViewDetails" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnits" runat="server" Skin="WebBlue" MarkFirstMatch="true" MaxHeight="120px" TabIndex="1" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnits" runat="server" ControlToValidate="rcmb_BusinessUnits"
                                        InitialValue="Select" ErrorMessage="Please Select BusinessUnit" Text="*" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnits"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankID" runat="server" Visible="False" meta:resourcekey="lbl_BusinessUnitBankID"></asp:Label><asp:Label
                                        ID="lbl_BusinessUnitBankName" runat="server" Text="Name" meta:resourcekey="lbl_BusinessUnitBankName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BusinessUnitBankName" runat="server" MaxLength="100" TabIndex="2"
                                        Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BusinessUnitBankName" runat="server" Text="*"
                                        ValidationGroup="Controls" ErrorMessage="Please Enter Name" ControlToValidate="rtxt_BusinessUnitBankName"
                                        meta:resourcekey="rfv_rtxt_BusinessUnitBankName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankBranch" runat="server"
                                        meta:resourcekey="lbl_BusinessUnitBankBranch"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BusinessUnitBankBranch" runat="server" TabIndex="3"
                                        Skin="WebBlue" MaxLength="16">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&#160;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankAccountNo" runat="server" Text="Account No"
                                        meta:resourcekey="lbl_BusinessUnitBankAccountNo"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BusinessUnitBankAccountNo" runat="server" Skin="WebBlue" TabIndex="4"
                                        MaxLength="16">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BusinessUnitBankAccountNo" runat="server"
                                        Text="*" ValidationGroup="Controls" ControlToValidate="rtxt_BusinessUnitBankAccountNo"
                                        ErrorMessage="Please Enter Account No"
                                        meta:resourcekey="rfv_rtxt_BusinessUnitBankAccountNo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_BusinessUnitBankAccountNo"
                                        ErrorMessage="Please Enter Only Numeric Characters" ValidationExpression="^[0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BSBCode" runat="server" Text="BSB Code" meta:resourcekey="lbl_BSBCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BSBCode" TabIndex="5"
                                        runat="server" Skin="WebBlue"
                                        LabelCssClass="" MaxLength="50" meta:resourcekey="rtxt_SwiftCodeResource1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&#160;&#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankAddress" runat="server" Text="Address"
                                        meta:resourcekey="lbl_BusinessUnitBankAddress"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_BusinessUnitBankAddress" runat="server" TabIndex="6"
                                        Skin="WebBlue" MaxLength="500" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_BusinessUnitBankAddress"
                                        runat="server" ControlToValidate="rtxt_BusinessUnitBankAddress"
                                        ErrorMessage="Please Enter Address"
                                        meta:resourcekey="rfv_rtxt_BusinessUnitBankAddress" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankIsActive" runat="server" Text="Status"
                                        meta:resourcekey="lbl_BusinessUnitBankIsActive"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitBankIsActive" runat="server" TabIndex="7"
                                        AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>

                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_BusinessUnitBankIsActive" runat="server"
                                        meta:resourcekey="chk_BusinessUnitBankIsActive" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitBankIsDefault" runat="server"
                                        meta:resourcekey="lbl_BusinessUnitBankIsDefault" Text="Default"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_BusinessUnitBankIsDefault" runat="server" TabIndex="8"
                                        meta:resourcekey="chk_BusinessUnitBankIsDefault"
                                        onclick="checkboxClick(this)" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" TabIndex="9"
                                        OnClick="btn_Save_Click" Text="Update" ValidationGroup="Controls"
                                        Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" TabIndex="9"
                                        OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls"
                                        Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" TabIndex="10"
                                        OnClick="btn_Cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_BusinessUnitBank" runat="server"
                                        meta:resourcekey="vs_BusinessUnitBank" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                                <td align="center"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>