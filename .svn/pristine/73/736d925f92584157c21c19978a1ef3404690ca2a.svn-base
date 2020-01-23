<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="AuditSecurityPrivileges.aspx.cs" Inherits="AuditSecurityPrivileges" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
            <td width="100%">
                <telerik:RadTabStrip ID="rtsAuditDetails" runat="server" MultiPageID="rmpAuditOrg"
                    SelectedIndex="0" Width="100%" OnTabClick="rtsAuditDetails_TabClick">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="MainScreen" Text="Main Data"
                            TabIndex="1" Value="MainScreenTab">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="AuditScreen" Text="Audit Data"
                            TabIndex="2" Value="AuditScreenTab">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpAuditDetails" runat="server" SelectedIndex="0" ScrollBars="Auto" Width="100%">
                    <telerik:RadPageView ID="MainScreen" runat="server" Selected="true" Width="100%">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center">
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
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
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
                                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="View" UniqueName="radiobox3">
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
                                        UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="AuditScreen" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgAudit" runat="server" AutoGenerateColumns="False" Visible="false"
                                        AllowFilteringByColumn="True" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                        AllowPaging="True" OnNeedDataSource="rgAudit_NeedDataSource">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="None">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_AUDIT_ID" HeaderText="ID" meta:resourceKey="SMHR_AUDIT_ID"
                                                    UniqueName="SMHR_AUDIT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name" meta:resourcekey="EMP_NAME"
                                                    UniqueName="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOGIN_USERNAME" HeaderText="Login User ID" meta:resourcekey="LOGIN_USERNAME"
                                                    UniqueName="LOGIN_USERNAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LOGTYP_CODE" HeaderText="User Role" meta:resourcekey="LOGTYP_CODE"
                                                    UniqueName="LOGTYP_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FORMS_NAME" HeaderText="Screen Name" meta:resourcekey="FORMS_NAME"
                                                    UniqueName="FORMS_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AUDIT_COLUMN" HeaderText="Column Name" meta:resourcekey="SMHR_AUDIT_COLUMN"
                                                    UniqueName="SMHR_AUDIT_COLUMN" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AUDIT_TRANSACTIONDESC" HeaderText="Description"
                                                    UniqueName="SMHR_AUDIT_TRANSACTIONDESC" ItemStyle-HorizontalAlign="Left" meta:resourcekey="SMHR_AUDIT_TRANSACTIONDESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AUDIT_OLDVALUE" HeaderText="Old Value" meta:resourcekey="SMHR_AUDIT_OLDVALUE"
                                                    UniqueName="SMHR_AUDIT_OLDVALUE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AUDIT_NEWVALUE" HeaderText="New Value" meta:resourcekey="SMHR_AUDIT_NEWVALUE"
                                                    UniqueName="SMHR_AUDIT_NEWVALUE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DATE" HeaderText="Modified Date" meta:resourcekey="DATE"
                                                    UniqueName="DATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView><PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>