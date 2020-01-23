<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_AssignPriveleges.aspx.cs" Inherits="Security_frm_AssignPriveleges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_AssignPrivilageHeader" runat="server" Text="Assign Privilege"
                    Font-Bold="True" meta:resourcekey="lbl_AssignPrivilageHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_AP_page" runat="server" SelectedIndex="0" Height="490px"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_AP_ViewMain" runat="server">
                        <telerik:RadGrid ID="Rg_AssignPrivilage" runat="server" AutoGenerateColumns="False"
                            GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_AssignPrivilage_NeedDataSource"
                            AllowFilteringByColumn="true" AllowPaging="True">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TYPSEC_ID" HeaderText="ID" meta:resourcekey="TYPSEC_ID"
                                        UniqueName="TYPSEC_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TYPSEC_LOGTYP_ID" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="User Group" meta:resourcekey="TYPSEC_LOGTYP_ID" UniqueName="TYPSEC_LOGTYP_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TYPSEC_FORMS_ID" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Forms" meta:resourcekey="TYPSEC_FORMS_ID" UniqueName="TYPSEC_FORMS_ID">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Read"
                                        AllowFiltering="true" meta:resourcekey="TYPSEC_READ" UniqueName="TYPSEC_READ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_AssignPrivilageRead" runat="server" Text='<%# (Convert.ToString(Eval("TYPSEC_READ")).ToUpper() == "TRUE" ? "Enabled": "Disabled")   %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Write"
                                        AllowFiltering="true" meta:resourcekey="TYPSEC_WRITE" UniqueName="TYPSEC_WRITE">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_AssignPrivilageWrite" runat="server" Text='<%# (Convert.ToString(Eval("TYPSEC_WRITE")).ToUpper() == "TRUE" ? "Enabled": "Disabled")   %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TYPSEC_ID") %>'
                                                meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                            </MasterTableView>
                            <PagerStyle AlwaysVisible="true" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_AP_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_AssignPrivilageDetails" runat="server" Text="Details" meta:resourcekey="lbl_AssignPrivilageDetails"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignPrivilageID" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_AssignPrivilageUserGroup" runat="server" Text="User Group" meta:resourcekey="lbl_AssignPrivilageUserGroup"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AssignPrivilageUserGroups" Skin="WebBlue" runat="server" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_AssignPrivilageUserGroups" runat="server"
                                        ControlToValidate="rcmb_AssignPrivilageUserGroups" ErrorMessage="Select a User Group"
                                        InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignPrivilageUserGroup0" runat="server" Text="Module Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Module" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Module_SelectedIndexChanged"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_AssignPrivilageUserGroups0" runat="server"
                                        ControlToValidate="rcmb_Module" ErrorMessage="Select a Module Name" InitialValue="Select"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignPrivilageForms" runat="server" Text="Forms" meta:resourcekey="lbl_AssignPrivilageForms"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_AssignPrivilagesForms" Skin="WebBlue" runat="server"
                                        MaxHeight="200px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_AssignPrivilagesForms" runat="server" ControlToValidate="rcmb_AssignPrivilagesForms"
                                        ErrorMessage="Select a Form to Assign" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignPrivilageRead" runat="server" meta:resourcekey="lbl_AssignPrivilageRead"
                                        Text="Read"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_AssignPrivilageRead" runat="server" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssignPrivilageWrite" runat="server" meta:resourcekey="lbl_AssignPrivilageWrite"
                                        Text="Write"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_AssignPrivilageWrite" runat="server" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_AssignPrivilage" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                                <td align="center"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>