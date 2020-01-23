<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LeaveMaster.aspx.cs" Inherits="Masters_frm_LeaveMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">

    <telerik:RadAjaxManagerProxy ID="RAM_LeaveMaster" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_LeaveMaster">
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
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Heading" runat="server" Font-Bold="True" meta:resourcekey="lbl_Heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadMultiPage ID="rm_MR_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                        Width="1014px" Height="490px" ScrollBars="Auto">
                        <telerik:RadPageView ID="RP_GRIDVIEW" runat="server" meta:resourcekey="RP_GRIDVIEW"
                            Selected="True">
                            <asp:UpdatePanel ID="updPanel1" runat="server">
                                <ContentTemplate>
                                    <table align="center" width="50%">
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="RG_LeaveMaster" runat="server" Skin="WebBlue" GridLines="None"
                                                    AutoGenerateColumns="False" AllowPaging="True" AllowFilteringByColumn="True"
                                                    AllowSorting="True" OnNeedDataSource="RG_LeaveMaster_NeedDataSource">
                                                    <GroupingSettings CaseSensitive="False" />
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="LEAVEMASTER_ID" HeaderText="ID" meta:resourcekey="LEAVEMASTER_ID"
                                                                UniqueName="LEAVEMASTER_ID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="LEAVEMASTER_CODE" HeaderText="Name" meta:resourcekey="LEAVEMASTER_CODE"
                                                                UniqueName="LEAVEMASTER_CODE">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="LEAVEMASTER_DESCRIPTION" HeaderText="Description"
                                                                meta:resourcekey="LEAVEMASTER_DESCRIPTION" UniqueName="LEAVEMASTER_DESCRIPTION">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="False" meta:resourcekey="GridTemplateColumn"
                                                                UniqueName="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Master_Edit" runat="server" OnCommand="lnk_Edit_Command"
                                                                        CommandArgument='<%# Eval("LEAVEMASTER_ID") %>' meta:resourcekey="lnk_Master_EditResource1">Edit</asp:LinkButton>
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
                                                                <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command"> Add</asp:LinkButton>
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
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
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
                                                            <a id="D2" runat="server" href="~/Masters/Importsheets/LeaveMastear_template.xlsx">Download
                                                                Leave Master Details Template</a>
                                                        </td>
                                                        <td>
                                                            <strong>:</strong>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_Imp_LeaveMaster" runat="server" Text="Import" OnClick="Btn_Imp_LeaveMaster_click" />
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <%--<asp:PostBackTrigger ControlID="btn_Imp_LeaveMaster" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RP_FORMVIEW" runat="server" meta:resourcekey="RP_FORMVIEW">
                            <table align="center" width="20%">
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="lbl_Details" runat="server" meta:resourcekey="lbl_Details"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_LeaveCode" runat="server" Style="text-align: left" Text="Code:"
                                            meta:resourcekey="lbl_LeaveCode"></asp:Label>
                                        <asp:Label ID="lbl_LeaveMaster_ID" runat="server" Text="lbl_Master_ID" Visible="False"
                                            meta:resourcekey="lbl_LeaveMaster_ID"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_LeaveMasterCode" runat="server" EnableEmbeddedSkins="false" TabIndex="1"
                                            MaxLength="50">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_txt_MasterCode" runat="server" ControlToValidate="rtxt_LeaveMasterCode"
                                            ErrorMessage="Please Enter Name" ValidationGroup="Controls" meta:resourcekey="rfv_txt_MasterCode">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rev_rtxt_LeaveMasterCode" runat="server" ControlToValidate="rtxt_LeaveMasterCode"
                                            ErrorMessage="Enter only Alphabets for Name" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"
                                            ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_LDesc" runat="server" Text="Description:" meta:resourcekey="lbl_LDesc"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_LeaveMasterDesc" runat="server" EnableEmbeddedSkins="false" TabIndex="2"
                                            MaxLength="100">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="compoff" runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="lbl_checkcompoff" runat="server" meta:resourcekey="lbl_checkcompoff"
                                            Text="Check&nbsp;Compoff"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="rchk_compoff" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_check15days" runat="server" Text="15 days"></asp:Label>
                                    </td>
                                    <td>
                                    <strong>:</strong>
                                    </td>
                                    <td style="margin-left: 40px">
                                        <asp:CheckBox ID="chk_allowpay" runat="server" AutoPostBack="true" OnCheckedChanged="AllowPay_click" TabIndex="3" />
                                        
                                      
                                    </td>
                                    <td></td>
                                    
                                </tr>
                                 <tr>
                                    <td>
                                        <asp:Label ID="lbl_IncidentLeave" runat="server" meta:resourcekey="lbl_IncidentLeave"
                                            Text="Incident Leave"></asp:Label>
                                    </td>
                                    <td>
                                       <b>:</b>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_IncidentLeave" runat="server" AutoPostBack="true" OnCheckedChanged="chk_IncidentLeave_CheckedChanged" TabIndex="4" />
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" Text="Update" TabIndex="5"
                                            ValidationGroup="Controls" Visible="False" Width="61px" OnClick="btn_Save_Click1" />
                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" Text="Save" TabIndex="5"
                                            ValidationGroup="Controls" Visible="False" OnClick="btn_Save_Click1" />
                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" Text="Cancel" TabIndex="6"
                                            OnClick="btn_Cancel_Click1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:ValidationSummary ID="vg_Master" runat="server" meta:resourcekey="vg_Master"
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
