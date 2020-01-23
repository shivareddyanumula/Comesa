<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="DivisionMaster.aspx.cs" Inherits="Masters_DivisionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cnt_Country" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Division" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Division">
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
            <td align="center">
                <asp:Label ID="lbl_DivisionHeader" runat="server" Text="Sub Department" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Division_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Division_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Division" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Countries_NeedDataSource" AllowPaging="True" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_DIV_ID" UniqueName="SMHR_DIV_ID" HeaderText="ID"
                                                    meta:resourcekey="SMHR_DIV_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                    meta:resourcekey="BUSINESSUNIT_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIV_CODE" UniqueName="SMHR_DIV_CODE" HeaderText="Name"
                                                    meta:resourcekey="SMHR_DIV_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIV_DESC" UniqueName="SMHR_DIV_DESC" HeaderText="Description"
                                                    meta:resourcekey="SMHR_DIV_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_DIV_ID") %>'
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
                                        <GroupingSettings CaseSensitive="false" />
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Division_ViewDetails" runat="server">
                        <table align="center" >
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox AutoPostBack="true" EnableEmbeddedSkins="false" ID="ddl_BusinessUnit" 
                                        OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"  runat="server" Filter="Contains"
                                    MarkFirstMatch="true" MaxHeight="120px" TabIndex="1">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddl_BusinessUnit"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit" InitialValue="Select" 
                                       >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server"  Text="Directorate"></asp:Label>                                   
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Directorate" AutoPostBack="true"  runat="server" Skin="WebBlue" TabIndex="2" Filter="Contains"
                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" >
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                <asp:RequiredFieldValidator ID="rfv_Directorate" ControlToValidate="rad_Directorate"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Directorate"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server"  Text="Department"></asp:Label>                               
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Department"  runat="server" Skin="WebBlue" MaxLength="40" TabIndex="3"
                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                 <asp:RequiredFieldValidator ID="rfv_Department" ControlToValidate="rad_Department"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Department"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DivisionID" runat="server" Visible="False" meta:resourcekey="lbl_CountryID"></asp:Label>
                                    <asp:Label ID="lbl_CountryCode" runat="server" Text="Name" 
                                        meta:resourcekey="lbl_CountryCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_SubDepartment" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="4">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                 <asp:RequiredFieldValidator ID="rfv_SubDepartmentName" ControlToValidate="rtxt_SubDepartment"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name"
                                        meta:resourcekey="rfv_rtxt_CountryCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CountryName" runat="server" Text="Description" 
                                        meta:resourcekey="lbl_CountryDesc"></asp:Label>
                                </td>
                                <td>
                                   <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CountryName" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="5">
                                    </telerik:RadTextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_CountryName" ControlToValidate="rtxt_CountryName"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Name cannot be Empty" 
                                        meta:resourcekey="rfv_rtxt_CountryName">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7"
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
