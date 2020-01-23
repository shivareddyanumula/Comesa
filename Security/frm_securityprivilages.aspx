﻿<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_securityprivilages.aspx.cs" Inherits="Security_frm_securityprivilages" %>
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_securityprivilages.aspx.cs" Inherits="Security_frm_securityprivilages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_security" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbl_AssignSecurity" runat="server" Text="Assign Privileges" Font-Bold="True"
                    Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_AssignSecurity" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="Rp_AssignSecurity" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_AssignSecurity" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_AssignSecurity_NeedDataSource"
                                        AllowFilteringByColumn="true" AllowPaging="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <%--  <telerik:GridBoundColumn DataField="TYPSEC_ID" HeaderText="ID" UniqueName="TYPSEC_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="LOGTYP_CODE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="User Group" UniqueName="LOGTYP_CODE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ORGANISATION_NAME" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Organisation Name" UniqueName="ORGANISATION_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LOGTYP_ID") %>'
                                                            OnCommand="lnk_edit_command">Select</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_AssignSecurity_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Organisation" runat="server" Text="Organisation"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Organisation" Skin="WebBlue" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_Organisation_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Organisation" runat="server"
                                        ControlToValidate="rcmb_Organisation" ErrorMessage="Please Select Organisation"
                                        ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SecurityUserGroup" runat="server" Text="User Group"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Usergroup" Skin="WebBlue" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rcmb_Usergroup_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Usergroup" runat="server"
                                        ControlToValidate="rcmb_Usergroup" ErrorMessage="Please Select User Group"
                                        ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="super_module_id" runat="server">
                                <td>
                                    <asp:Label ID="lbl_sup_module" runat="server" Text="Super Module Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_sup_module" runat="server" AutoPostBack="True" Skin="WebBlue"
                                        OnSelectedIndexChanged="rcmb_sup_module_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_sup_module" runat="server"
                                        ControlToValidate="rcmb_sup_module" ErrorMessage="Please Select Super Module Name"
                                        ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr id="module_id" runat="server">
                                <td>
                                    <asp:Label ID="lbl_AssignSecurityModule" runat="server" Text="Sub Module Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Module" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Module_SelectedIndexChanged"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Module" runat="server"
                                        ControlToValidate="rcmb_Module" ErrorMessage="Please Select Sub Module Name"
                                        ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Clear" runat="server" OnClick="btn_Clear_Click" Text="Clear" />
                                </td>
                            </tr>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <telerik:RadGrid ID="Rg_Securitygrid" runat="server" Width="800px" AutoGenerateColumns="False"
                    GridLines="None" AllowPaging="false">
                    <GroupingSettings CaseSensitive="false" />
                    <%-- <ClientSettings>
                                            <Scrolling AllowScroll="True" />
                                        </ClientSettings>--%>
                    <MasterTableView>
                        <Columns>
                            <%-- <telerik:GridBoundColumn DataField="Form_ID" UniqueName="Form_ID" Visible="False">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LBL_form_ID" runat="server" Text='<%# Eval("FORMS_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FORMS_NAME" HeaderText="Form Name" UniqueName="FORMS_NAME">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Full" UniqueName="radiobox1">

                                <HeaderTemplate>
                                    <asp:RadioButton ID="Chk_FullControl1" Text="Full" Checked="false" OnCheckedChanged="Full_Check_Changed"
                                        UniqueName="Chk_FullControl1" AutoPostBack="true" runat="server" GroupName="radcontrol1" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RadioButton ID="Chk_FullControl" runat="server" GroupName="radcontrol" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="View" UniqueName="radiobox3" Visible="false">

                                <HeaderTemplate>
                                    <asp:RadioButton ID="Chk_View1" Text="View" Checked="false" OnCheckedChanged="view_Check_Changed"
                                        runat="server" AutoPostBack="true" GroupName="radcontrol1" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RadioButton ID="Chk_View" runat="server" GroupName="radcontrol" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="N/A" UniqueName="radiobox3">

                                <HeaderTemplate>

                                    <asp:RadioButton ID="Chk_NotApplicable1" Text="N/A" Checked="false" OnCheckedChanged="NotApplicate_Check_Changed"
                                        AutoPostBack="true" runat="server" GroupName="radcontrol1" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RadioButton ID="Chk_NotApplicable" runat="server" GroupName="radcontrol" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ActiveItemStyle HorizontalAlign="Center" />
                    <PagerStyle AlwaysVisible="True" />
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update"
                    UseSubmitBehavior="false" ValidationGroup="Controls" Visible="False" /> <%--OnClientClick="fnJSOnFormSubmit(this,'Controls')"--%>
                <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" UseSubmitBehavior="false" ValidationGroup="Controls" /><%--OnClientClick="fnJSOnFormSubmit(this,'Controls')"--%>
                <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ValidationSummary ID="vs_AssignFunctionality" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    </telerik:RadPageView> </telerik:RadMultiPage> </td> </tr> </table>
</asp:Content>