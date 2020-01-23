<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AVC.aspx.cs" Inherits="Pension_frm_AVC" %>



<%@ Register Src="~/BUFilter.ascx" TagName="BU" TagPrefix="BUFilter" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
    <br /><br />
<telerik:radajaxmanagerproxy id="RAM_MedicalBenfitClaim" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenfitClaim">
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
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:radwindowmanager id="RWM_POSTREPLY1" runat="server" style="z-index: 8000">
                </telerik:radwindowmanager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_scheme" runat="server" Text="Additional Voluntary Contribution" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:radmultipage id="Rm_CY_page" runat="server" selectedindex="0" style="z-index: 10"
                    width="990px" height="490px" scrollbars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_MedicalClaim" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_MedicalClaim_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PENSIONSCHEME_ID" UniqueName="PENSIONSCHEME_ID" HeaderText="ID"
                                                            meta:resourcekey="PENSIONSCHEME_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PENSIONSCHEME_EMPID" UniqueName="PENSIONSCHEME_EMPID" Visible="false" HeaderText="Emp ID"
                                                            meta:resourcekey="PENSIONSCHEME_EMPID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME" HeaderText="Employee Name"
                                                            meta:resourcekey="EMP_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVC_PENSION_AMOUNT" UniqueName="AVC_PENSION_AMOUNT" HeaderText="AVC Amount" 
                                                            >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="PENSIONSCHEME_PENSIONNO" UniqueName="PENSIONSCHEME_PENSIONNO" HeaderText="Pension ID"
                                                            meta:resourcekey="PENSIONSCHEME_PENSIONNO">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        
                                                        
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("AVC_ID") %>'
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

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                                                        <ContentTemplate>
                        <table align="center" width="50%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left">
                                    &nbsp;<BUFilter:BU ID="BU1" runat="server" />
                                </td>
                            </tr>
                           <%-- <tr>
                             <td style="width:150px;" >
                             <asp:Label ID="lblSchemeID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDateofJoiningScheme" runat="server" Text="Date of Joining Scheme"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                     <telerik:RadDatePicker ID="rdpDateofJoiningScheme" runat="server" MinDate="1900-01-01"   >                                       
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" 
                                                                    ControlToValidate="rdpDateofJoiningScheme" ValidationGroup="Controls" 
                                                                    Display="Dynamic" ErrorMessage="Please Select Date of Joining"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                             <td style="width:150px;">
                                  <asp:Label ID="lblAVCID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIDNumber" runat="server" Text="Additional Voluntary Contribution"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                     <telerik:RadNumericTextBox ID="radPensionIDNo" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0" 
                                     NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ExpenditureName" runat="server" Text="*" 
                                                                    ControlToValidate="radPensionIDNo" ValidationGroup="Controls" 
                                                                    Display="Dynamic" ErrorMessage="Please Enter Additional Voluntary Contribution"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                        Text="Update" Visible="False"  />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                        Text="Save" Visible="False"  />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                                                            </ContentTemplate>

                             <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Save" />
                                                            <asp:PostBackTrigger ControlID="btn_Update" />
                                                        </Triggers>
                         </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:radmultipage>
            </td>
        </tr>
    </table>
</asp:Content>

