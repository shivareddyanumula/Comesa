<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Period.aspx.cs" Inherits="Masters_frm_Period" Culture="auto" meta:resourcekey="Page"
    UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Period" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Period">
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
            <telerik:AjaxSetting AjaxControlID="rcmb_PeriodType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Period" runat="server" Text="Financial Period" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_Period_page" runat="server" SelectedIndex="0"
                    Width="990px" meta:resourcekey="Rm_Period_page">
                    <telerik:RadPageView ID="Rp_PT_ViewMain" runat="server" meta:resourcekey="Rp_PT_ViewMain"
                        Selected="True">
                        <telerik:RadGrid ID="Rg_Period" runat="server" AutoGenerateColumns="False" GridLines="None"
                            Skin="WebBlue" OnNeedDataSource="Rg_Period_NeedDataSource" AllowPaging="True" Width="55%"
                            meta:resourcekey="Rg_Period" AllowFilteringByColumn="true">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="PERIOD_ID" HeaderText="ID" meta:resourcekey="PERIOD_ID"
                                        UniqueName="PERIOD_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERIOD_NAME" HeaderText="Name" meta:resourcekey="PERIOD_NAME"
                                        UniqueName="PERIOD_NAME" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn DataField="PERIOD_STARTDATE" HeaderText="Start Date" Visible="false"
                                        meta:resourcekey="PERIOD_STARTDATE" UniqueName="PERIOD_STARTDATE" ItemStyle-HorizontalAlign="Left"
                                        DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" AllowFiltering="true" AutoPostBackOnFilter="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn DataField="PERIOD_ENDDATE" HeaderText="End Date" meta:resourcekey="PERIOD_ENDDATE"
                                        UniqueName="PERIOD_ENDDATE" ItemStyle-HorizontalAlign="Left" Visible="false"
                                        DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" AllowFiltering="true"
                                        AutoPostBackOnFilter="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn DataField="SD" HeaderText="Start Date" meta:resourcekey="SD"
                                        UniqueName="SD" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ED" HeaderText="End Date" meta:resourcekey="ED"
                                        UniqueName="ED" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PERIOD_ID") %>'
                                                meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Period_ViewDetails" runat="server" meta:resourcekey="Rp_Period_ViewDetails">
                        <table align="center">
                            <tr>
                                <td colspan="6" align="center" style="font-weight: bold;">
                                    <%--<asp:Label ID="lbl_PeriodDetails" runat="server" Text="Details" meta:resourcekey="lbl_PeriodDetails"></asp:Label>--%>
                                </td>
                                <td align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodID" runat="server" Visible="False" meta:resourcekey="lbl_PeriodID"></asp:Label>
                                    <asp:Label ID="lbl_PeriodCode" runat="server" Text="Name" meta:resourcekey="lbl_PeriodCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_PeriodName" runat="server" Skin="WebBlue" TabIndex="1"
                                        LabelCssClass="" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_PeriodName" runat="server" ControlToValidate="rtxt_PeriodName"
                                        ErrorMessage="Please Enter Period Name" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_PeriodName">*</asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_PeriodType" runat="server" Text="Period Type" meta:resourcekey="lbl_PeriodType"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_PeriodType" runat="server" AutoPostBack="True" TabIndex="2"
                                        OnSelectedIndexChanged="rcmb_PeriodType_SelectedIndexChanged" MarkFirstMatch="true" MaxHeight="120px"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PeriodType" runat="server" ControlToValidate="rcmb_PeriodType"
                                        ErrorMessage="Please select Period Type" ValidationGroup="Controls" meta:resourcekey="rfv_rcmb_PeriodType">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="style2" align="left">
                                    <asp:Label ID="lbl_StartDate" runat="server" meta:resourcekey="lbl_StartDate" Text="Start Date"></asp:Label>
                                </td>
                                <td class="style2">
                                    <b>:</b>
                                </td>
                                <td align="left" class="style2">
                                    <telerik:RadDatePicker ID="rdtp_StartDate" runat="server" OnSelectedDateChanged="rdtp_StartDate_SelectedDateChanged" AutoPostBack="true" Skin="WebBlue" TabIndex="3">
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="style2"></td>
                                <td class="style2">
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_StartDate" runat="server" ControlToValidate="rdtp_StartDate"
                                        ErrorMessage="Please select Start Date" ValidationGroup="Controls" meta:resourcekey="rfv_rdtp_StartDate">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="style2"></td>
                            </tr>
                            <tr>
                                <td class="style3" align="left">
                                    <asp:Label ID="lbl_EndDate" runat="server" meta:resourcekey="lbl_EndDate" Text="End Date"></asp:Label>
                                </td>
                                <td class="style3">
                                    <b>:</b>
                                </td>
                                <td align="left" class="style3">
                                    <telerik:RadDatePicker ID="rdtp_EndDate" runat="server" Enabled="False" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="style3"></td>
                                <td class="style3"></td>
                                <td class="style3"></td>
                            </tr>
                            <tr runat="server" id="duration">
                                <td align="left">
                                    <asp:Label ID="lbl_Duration" runat="server" meta:resourcekey="lbl_Duration" Text="Duration"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadNumericTextBox ID="rtxt_Duration" runat="server" Skin="WebBlue" TabIndex="4"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_DurationType" runat="server" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Duration" runat="server" ControlToValidate="rtxt_Duration"
                                        ErrorMessage="Please select a valid durtaion" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_Duration">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DurationType" runat="server" ControlToValidate="rcmb_DurationType"
                                        ErrorMessage="Please select a valid Type" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_DurationType">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="btn_GeneratePeriods" runat="server" meta:resourcekey="btn_Generate" TabIndex="5"
                                        OnClick="btn_Generate_Click" Text="Generate" ValidationGroup="Controls" />
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <telerik:RadGrid ID="Rg_PeriodDetails" runat="server" AllowPaging="false" Skin="WebBlue"
                                        AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="Rg_PeriodDetails_NeedDataSource"
                                        meta:resourcekey="Rg_PeriodDetails" PageSize="12">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="PRDDTL_ID" HeaderText="ID" meta:resourcekey="PRDDTL_ID"
                                                    UniqueName="PRDDTL_ID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_NAME" HeaderText="Name" meta:resourcekey="PRDDTL_NAME"
                                                    UniqueName="PRDDTL_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_STARTDATE" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" HeaderText="Start Date" meta:resourcekey="PRDDTL_STARTDATE"
                                                    UniqueName="PRDDTL_STARTDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PRDDTL_ENDDATE" DataType="System.DateTime" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false" HeaderText="End Date" meta:resourcekey="PRDDTL_ENDDATE"
                                                    UniqueName="PRDDTL_ENDDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="PRDDTL_STATUS" HeaderText="Status" meta:resourcekey="PRDDTL_STATUS" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="rcmb_Status" runat="server" EnabledSkin="WebBlue" MarkFirstMatch="true"
                                                            SelectedIndex='<%# Convert.ToInt32(Eval("PRDDTL_STATUS")) %>'>
                                                            <Items>
                                                                <telerik:RadComboBoxItem runat="server" Text="Open" Value="0" Selected="True" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Close" Value="1" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Save" ValidationGroup="Controls" Visible="False" Style="height: 26px" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7"
                                        Text="Cancel" Width="60px" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:ValidationSummary ID="vs_Period" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vs_Period" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style2 {
            height: 22px;
        }
        .style3 {
            height: 20px;
        }
    </style>
</asp:Content>