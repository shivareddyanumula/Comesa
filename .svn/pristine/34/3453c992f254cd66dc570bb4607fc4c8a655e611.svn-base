<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Location.aspx.cs" Inherits="Masters_frm_Location" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindowManager ID="RWM_Location" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManagerProxy ID="RAM_Location" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Location">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_LocationHeader" runat="server" Text="Location" Font-Bold="True"
                    meta:resourcekey="lbl_HolidayCalendarHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Location" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_Location_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="LOCATION_ID" UniqueName="LOCATION_ID" HeaderText="ID"
                                                    meta:resourcekey="LOCATION_ID" Visible="False">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="LOCATION_NAME" UniqueName="LOCATION_NAME"
                                                    AllowFiltering="true" HeaderText="Name" meta:resourcekey="LOCATION_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOCATION_DESC" UniqueName="LOCATION_DESC"
                                                    AllowFiltering="true" HeaderText="Description" meta:resourcekey="HOLMST_DESCRIPTION"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="STATUS" UniqueName="STATUS"
                                                    AllowFiltering="true" HeaderText="Status" meta:resourcekey="HOLMST_DESCRIPTION"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LOCATION_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Location_ViewDetails" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                                <td align="center" style="font-weight: bold;">&nbsp;
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LOCID" runat="server" meta:resourcekey="lbl_DPname" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_LOCname" runat="server" meta:resourcekey="lbl_DPname" Text="Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Locname" runat="server" Skin="WebBlue" LabelCssClass=""
                                        MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Locname" runat="server" ControlToValidate="rtxt_Locname"
                                        ErrorMessage="Please Enter Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_Locname"
                                        ErrorMessage="Please Enter Only Alphabets" ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_LocDesc" runat="server" meta:resourcekey="lbl_LocDesc" Text="Description"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Desc" runat="server" Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <%--  <asp:CheckBox ID="chk_Active" runat="server" Checked="true" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue"
                                        MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="0" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Edit" runat="server" Text="Update" Visible="False" ValidationGroup="Controls"
                                        meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="False" ValidationGroup="Controls"
                                        meta:resourcekey="btn_Save" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" meta:resourcekey="btn_Cancel"
                                        OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_Location" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Controls" ShowSummary="False" meta:resourcekey="vs_Location" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <%--  <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_HolidayCalendar" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Controls" ShowSummary="False" meta:resourcekey="vs_HolidayCalendar" />
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>--%>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

