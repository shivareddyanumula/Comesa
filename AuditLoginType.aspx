<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="AuditLoginType.aspx.cs" Inherits="AuditLoginType" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_LoginTypeHeader" runat="server" Text="User Group" Font-Bold="True"
                    meta:resourcekey="lbl_LoginTypeHeader"></asp:Label>
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
                                    <telerik:RadMultiPage ID="Rm_LT_page" runat="server" SelectedIndex="0">
                                        <%--Height="490px" ScrollBars="Auto"> Removing Scroll--%>
                                        <telerik:RadPageView ID="Rp_LT_ViewMain" runat="server">
                                            <telerik:RadGrid ID="Rg_LoginType" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                Skin="WebBlue" OnNeedDataSource="Rg_LoginType_NeedDataSource" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="LOGTYP_ID" UniqueName="LOGTYP_ID" HeaderText="ID"
                                                            meta:resourcekey="LOGTYP_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="LOGTYP_CODE" UniqueName="LOGTYP_CODE" HeaderText="User Group"
                                                            meta:resourcekey="LOGTYP_CODE" HeaderStyle-HorizontalAlign="Center">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="LOGTYP_DESC" UniqueName="LOGTYP_DESC" HeaderText="Description"
                                                            meta:resourcekey="LOGTYP_DESC" HeaderStyle-HorizontalAlign="Center">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LOGTYP_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="true" />
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="Rp_LT_ViewDetails" runat="server">
                                            <table align="center">
                                                <tr>
                                                    <td colspan="3" align="center" style="font-weight: bold;">
                                                        <asp:Label ID="lbl_LoginTypeDetails" runat="server" Text="Details" meta:resourcekey="lbl_LoginTypeDetails"></asp:Label>
                                                    </td>
                                                    <td align="center" style="font-weight: bold;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_LoginTypeID" runat="server" Text="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbl_LoginTypeCode" runat="server" Text="User Group" meta:resourcekey="lbl_LoginTypeCode"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_LoginTypeCode" Style="text-transform: uppercase;" runat="server"
                                                            MaxLength="50">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_LoginTypeCode" runat="server"
                                                            ControlToValidate="rtxt_LoginTypeCode" ErrorMessage="Please Specify User Group"
                                                            ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rev_rtxt_LoginTypeCode" runat="server" ControlToValidate="rtxt_LoginTypeCode" ErrorMessage="Please Enter only Alphabets for User Group"
                                                            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_LoginTypeName" runat="server" Text="Description" meta:resourcekey="lbl_LoginTypeDesc"></asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_LoginTypeName" runat="server" Skin="WebBlue"
                                                            MaxLength="50">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_LoginTypeName" runat="server"
                                                            ControlToValidate="rtxt_LoginTypeName" ErrorMessage="Please Specify Description"
                                                            ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rev_rtxt_LoginTypeName" runat="server" ControlToValidate="rtxt_LoginTypeName" ErrorMessage="Please Enter only Alphabets for Description"
                                                            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                                                            Text="Update" ValidationGroup="Controls" Visible="False" />
                                                        <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                            Text="Save" ValidationGroup="Controls" Visible="False" />
                                                        <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                            Text="Cancel" />
                                                        <asp:ValidationSummary ID="vs_LoginType" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Controls" />
                                                    </td>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
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