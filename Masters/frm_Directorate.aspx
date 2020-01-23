<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Directorate.aspx.cs" Inherits="Masters_frm_Directorate" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_County" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_County">
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
                <asp:Label ID="lbl_DirectorateHeader" runat="server" Text="Directorate" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="590px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_Directorates" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Counties_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="DIRECTORATE_ID" UniqueName="DIRECTORATE_ID" HeaderText="ID"
                                                            meta:resourcekey="Directorate_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECTORATE_CODE" UniqueName="DIRECTORATE_CODE" HeaderText="Name"
                                                            meta:resourcekey="Directorate_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECTORATE_NAME" UniqueName="DIRECTORATE_NAME" HeaderText=" Description"
                                                            meta:resourcekey="DIRECTORATE_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                            meta:resourcekey="BUSINESSUNIT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECTORATE_STATUS" UniqueName="DIRECTORATE_STATUS" HeaderText=" Status"
                                                            meta:resourcekey="DIRECTORATE_STATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("Directorate_ID") %>'
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
                        <table align="center" width="45%">
                            <%--  <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>--%>

                            <tr>
                                <td valign="middle">
                                    <asp:Label ID="lbl_DirectorateID" runat="server" Visible="False" meta:resourcekey="lbl_DirectorateID"></asp:Label>
                                    <asp:Label ID="lbl_DirectorateCode" runat="server" Text="Name" meta:resourcekey="lbl_DirectorateCode"></asp:Label>
                                </td>
                                <td valign="middle"><b>:</b>
                                </td>
                                <td valign="middle">
                                    <telerik:RadTextBox ID="rtxt_DirectorateCode" runat="server" TextMode="Multiline" TabIndex="1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DirectorateCode1" ControlToValidate="rtxt_DirectorateCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name ">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rtxt_DirectorateCode1" ControlToValidate="rtxt_DirectorateCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name ">*</asp:RequiredFieldValidator>--%>

                                    <%--<asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_DirectorateCode" ErrorMessage="Enter only Alphabets for Directorate Name"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DirectorateName" runat="server" Text="Description" meta:resourcekey="lbl_DirectorateDesc" TextMode="Multiline"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DirectorateName" runat="server" TabIndex="2"
                                        Skin="WebBlue" MaxLength="100" TextMode="Multiline">
                                    </telerik:RadTextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_DirectorateName" ControlToValidate="rtxt_DirectorateName"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Name cannot be Empty" 
                                        meta:resourcekey="rfv_rtxt_DirectorateName">*</asp:RequiredFieldValidator>--%>
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
                                    <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" AutoPostBack="true" MaxHeight="120px" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                        MarkFirstMatch="true" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit1" runat="server" ControlToValidate="ddl_BusinessUnit"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_BusinessUnit1" runat="server" ControlToValidate="ddl_BusinessUnit"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server" Text="Parent Directorate"></asp:Label>
                                </td>
                                <td align="right">
                                    <b>:</b>
                                </td>

                                <td>
                                    <telerik:RadComboBox ID="ddl_Directorate" runat="server" CausesValidation="False" MaxHeight="120px" TabIndex="4"
                                        MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>

                            <tr>
                                <td>Status
                                </td>
                                <td><strong>:</strong></td>
                                <td>
                                    <telerik:RadComboBox ID="Rcm_status" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        MaxHeight="120px" Filter="Contains"
                                        TabIndex="5">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Rcm_status"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please Select  Status"></asp:RequiredFieldValidator></td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" TabIndex="6"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Directorate" runat="server" ShowMessageBox="True" ShowSummary="False"
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
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
</asp:Content>--%>