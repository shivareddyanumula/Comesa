<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_DisactRecording.aspx.cs" Inherits="HR_frm_DisactRecording" %>

<asp:Content ID="cnt_DisactRecording" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:RadAjaxManagerProxy ID="RAM_DisactRec" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="Rg_DisactRec">
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
                    <telerik:AjaxSetting AjaxControlID="rcmb_DisactRecEmpID">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManagerProxy>
            <table align="center" style="vertical-align: top;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_DisactRecHeader" runat="server" Text="Displinary Notes Recording on Employee"
                            Font-Bold="True" meta:resourcekey="lbl_DisactRecHeader"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="Rm_DR_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                            Width="990px" Height="490px" ScrollBars="Auto">
                            <telerik:RadPageView ID="Rp_DR_ViewMain" runat="server">
                                <table align="center" width="70%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid  ID="Rg_DisactRec" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_DisactRec_NeedDataSource"
                                                AllowPaging="true" AllowFilteringByColumn="True">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMPDSPACT_ID" UniqueName="EMPDSPACT_ID" meta:resourcekey="EMPDSPACT_ID"
                                                            Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUNIT" UniqueName="BUNIT" meta:resourcekey="EMPDSPACT_BUNIT"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDSPACT_EMPID" UniqueName="EMPDSPACT_EMPID"
                                                            meta:resourcekey="EMPDSPACT_EMPID" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDSPACT_RPTMNGID" UniqueName="EMPDSPACT_RPTMNGID"
                                                            meta:resourcekey="EMPDSPACT_RPTMNGID" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDSPACT_DATE" UniqueName="EMPDSPACT_DATE" meta:resourcekey="EMPDSPACT_DATE"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDSPACT_REMARKS" UniqueName="EMPDSPACT_REMARKS"
                                                            AllowFiltering="false" meta:resourcekey="EMPDSPACT_REMARKS" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPDSPACT_ID") %>'
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
                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton></div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                                <PagerStyle AlwaysVisible="true" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="Rp_DR_ViewDetails" runat="server">
                                <table align="center" width="40%">
                                    <tr>
                                        <td colspan="4" align="center" style="font-weight: bold;">
                                            <asp:Label ID="lbl_DisactRecDetails" runat="server" meta:resourcekey="lbl_DisactRecDetails"></asp:Label>
                                            <asp:HiddenField ID="HF_ID" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecBU" runat="server" Text="Business Unit" ></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_DisactRecBU" runat="server" AutoPostBack="True" MarkFirstMatch="true"  MaxHeight="120px"
                                                Skin="WebBlue" Filter="Contains"
                                                onselectedindexchanged="rcmb_DisactRecBU_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_BU" runat="server" ControlToValidate="rcmb_DisactRecBU"
                                                InitialValue="Select" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecID" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_DisactRecEmployee" runat="server" meta:resourcekey="lbl_DisactRecEmployee"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_DisactRecEmpID" runat="server" AutoPostBack="True"  MaxHeight="120px"
                                                MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_DisactRecEmpID_SelectedIndexChanged"
                                                Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_DisactRecEmpID" runat="server" ControlToValidate="rcmb_DisactRecEmpID"
                                                InitialValue="Select" meta:resourcekey="rfv_rcmb_DisactRecEmpID" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_DisactRecDOJ" runat="server" 
                                                Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecManager" runat="server" meta:resourcekey="lbl_DisactRecManager"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_DisactRecManagerID" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                                Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_DisactRecManagerID" meta:resourcekey="rfv_rcmb_DisactRecManagerID"
                                                runat="server" ControlToValidate="rcmb_DisactRecManagerID" ValidationGroup="Controls"
                                                InitialValue="Select">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecRemarks" runat="server" meta:resourcekey="lbl_DisactRecRemarks"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadTextBox  ID="rtxt_DisactRecRemarks" runat="server"
                                                MaxLength="100" Rows="3" TextMode="MultiLine" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_DisactRecRemarks" meta:resourcekey="rfv_rtxt_DisactRecRemarks"
                                                runat="server" ControlToValidate="rtxt_DisactRecRemarks" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecReason" runat="server" meta:resourcekey="lbl_DisactRecReason"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_DisactRecReason" runat="server" 
                                                MaxLength="500" Rows="4" Skin="WebBlue" TextMode="MultiLine">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_DisactRecReason" meta:resourcekey="rfv_rtxt_DisactRecReason"
                                                runat="server" ControlToValidate="rtxt_DisactRecReason" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecDate" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_DisactRecDate" runat="server" 
                                                Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rdtp_DisactRecDate" runat="server" ControlToValidate="rdtp_DisactRecDate"
                                                meta:resourcekey="rfv_rdtp_DisactRecDate" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="rcv_rdtp_DisactRecDate" runat="server" ControlToCompare="rdtp_DisactRecDOJ"
                                                ControlToValidate="rdtp_DisactRecDate" ErrorMessage="Recording Date cannot be less Date of Join"
                                                Operator="GreaterThanEqual" Type="Date" ValidationGroup="Controls">*</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DisactRecAttachment" runat="server" meta:resourcekey="lbl_DisactRecAttachment"></asp:Label>
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fupAttachment" runat="server" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnk_fupAttachment" runat="server" meta:resourcekey="lnk_fupAttachment"
                                                Visible="False"></asp:LinkButton>
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
                                            <asp:ValidationSummary ID="vs_DisactRec" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Edit" />
            <asp:PostBackTrigger ControlID="btn_Save" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
