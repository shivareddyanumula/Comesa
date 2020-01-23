<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Users.aspx.cs" Inherits="Security_frm_Users" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    &nbsp;&nbsp;&nbsp;
    <table align="center" style="width: 50%;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_UserManagerHeader" runat="server" Text="Users" Font-Bold="True"
                    meta:resourcekey="lbl_UserManagerHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_UM_page" runat="server" SelectedIndex="0"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_UM_ViewMain" runat="server">
                        <telerik:RadGrid ID="Rg_UserManager" runat="server" AutoGenerateColumns="False"
                            GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_UserManager_NeedDataSource"
                            AllowFilteringByColumn="true" AllowPaging="true">
                            <HeaderContextMenu>
                            </HeaderContextMenu>
                            <MasterTableView CommandItemDisplay="Top">
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="LOGIN_ID" HeaderText="ID" meta:resourcekey="LOGIN_ID"
                                        UniqueName="LOGIN_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGIN_USERNAME" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="User&nbsp;Name" meta:resourcekey="LOGIN_USERNAME" UniqueName="LOGIN_USERNAME">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGIN_EMP_ID" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Employee&nbsp;Name" meta:resourcekey="LOGIN_EMP_ID" UniqueName="LOGIN_EMP_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGIN_TYPE" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="User&nbsp;Group" meta:resourcekey="LOGIN_TYPE" UniqueName="LOGIN_TYPE">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ORGANISATION_NAME" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Organisation&nbsp;Name" meta:resourcekey="ORGANISATION_NAME" UniqueName="ORGANISATION_NAME">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BUSINESSUNIT_NAME" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Business&nbsp;Unit" meta:resourcekey="BUSINESSUNIT_NAME" UniqueName="BUSINESSUNIT_NAME">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LOGIN_STATUS" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Status" meta:resourcekey="LOGIN_STATUS" UniqueName="LOGIN_STATUS">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Status"
                                        meta:resourcekey="LOGIN_STATUS" UniqueName="LOGIN_STATUS" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_UserManagerStatus" runat="server" Text='<%# (Convert.ToString(Eval("LOGIN_STATUS")).ToUpper() == "TRUE" ? "Active": "Inactive")   %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="ColEdit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("LOGIN_ID") %>'
                                                meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                                <EditFormSettings>
                                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                        UpdateImageUrl="Update.gif">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle AlwaysVisible="true" />
                            </MasterTableView>
                            <GroupingSettings CaseSensitive="false" />
                            <FilterMenu>
                            </FilterMenu>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_UM_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_UserManagerDetails" runat="server" Text="Details" meta:resourcekey="lbl_UserManagerDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerOrg" runat="server" meta:resourcekey="lbl_UserManagerOrg"
                                        Text="Organisation"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Organisation" runat="server"
                                        Skin="WebBlue" MaxHeight="120px" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_Organisation_SelectedIndexChanged" AutoPostBack="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Organisation" runat="server" ControlToValidate="rcmb_Organisation"
                                        ErrorMessage="Please Select Organisation" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerID" runat="server" Text="" Visible="false"></asp:Label><asp:Label
                                        ID="lbl_UserManagerUserGroup" runat="server" Text="User Group" meta:resourcekey="lbl_UserManagerUserGroup"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_UserManagerUserGroups"
                                        Skin="WebBlue" runat="server" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_UserManagerUserGroups" runat="server" ControlToValidate="rcmb_UserManagerUserGroups"
                                        ErrorMessage="Please Select User Group" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerEmployee" runat="server" Text="Employee" meta:resourcekey="lbl_UserManagerEmployee"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_UserManagersEmployee" Skin="WebBlue"
                                        runat="server" MaxHeight="120px" Enabled="false" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_UserManagersEmployee_SelectedIndexChanged" AutoPostBack="true" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rcmb_UserManagersEmployee" runat="server" ControlToValidate="rcmb_UserManagersEmployee"
                                        ErrorMessage="Select a Employee to Assign" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerUserName" runat="server" meta:resourcekey="lbl_UserManagerUserName"
                                        Text="User Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:TextBox ID="rtxt_UserManagerUserName" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_UserManagerUserName" runat="server" ControlToValidate="rtxt_UserManagerUserName"
                                        ErrorMessage="Please Specify User Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerPassword" runat="server" meta:resourcekey="lbl_UserManagerPassword"
                                        Text="Password"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:TextBox ID="rtxt_UserManagerPassword" runat="server" MaxLength="14" Width="200px"
                                        TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_UserManagerPassword" runat="server" ControlToValidate="rtxt_UserManagerPassword"
                                        ErrorMessage="Please Specify Password" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerEmail" runat="server" meta:resourcekey="lbl_UserManagerEmail"
                                        Text="Email"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:TextBox ID="rtxt_UserManagerEmail" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rtxt_UserManagerEmail" runat="server" ControlToValidate="rtxt_UserManagerEmail"
                                        ErrorMessage="Email ID Cannot be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="rtxt_UserManagerEmail"
                                            ErrorMessage="Please check the Email id Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerStatus" runat="server" meta:resourcekey="lbl_UserManagerStatus"
                                        Text="Status"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_UserManagerStatus" runat="server"
                                        Skin="WebBlue">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_UserManagerStatus" runat="server" Visible="false" />
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PassCode" runat="server" Text="Pass Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_PassCode" runat="server" Width="200px" MaxLength="14" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_txt_PassCode" runat="server" ControlToValidate="txt_PassCode"
                                        ErrorMessage="Please Specify Pass Code" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UserManagerBusinessUnit" runat="server" meta:resourcekey="lbl_UserManagerBusinessUnit"
                                        Text="Assign Business Unit "></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_UserManagerBusinessUnit" MarkFirstMatch="true" MaxHeight="120px"
                                        runat="server" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:Button ID="btn_AddBusinessUnit" runat="server" OnClick="btn_AddBusinessUnit_Click"
                                        Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>&#160;&nbsp;
                                </td>
                                <td></td>
                                <td>
                                    <telerik:RadListBox ID="rlst_BusinessUnit" Height="120px"
                                        Width="210px" runat="server" AllowDelete="True" Skin="WebBlue" AutoPostBackOnDelete="True"
                                        OnDeleted="rlst_BusinessUnit_Deleted">
                                    </telerik:RadListBox>
                                </td>

                                <td>&#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save"
                                        runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" Text="Save"
                                        Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server"
                                        meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" Text="Cancel" />
                                    <asp:ValidationSummary
                                        ID="vs_UserManager" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                                <td align="center">&#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>