<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_userPrivileges.aspx.cs" Inherits="Security_frm_userPrivileges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">
            function GetSelectedItems() {
                alert($find("<%= Rg_Privilege.MasterTableView.ClientID %>").get_selectedItems().length);
            }
        </script>

    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_AssignPrivilageDetails" runat="server" Text="User Privileges"
                    Font-Bold="true" meta:resourcekey="lbl_AssignPrivilageDetails"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td colspan="3" align="center" style="font-weight: bold;">&nbsp;
                        </td>
                        <td align="center" style="font-weight: bold;"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_AssignPrivilageUserGroup" runat="server" Text="Package" meta:resourcekey="lbl_AssignPrivilageUserGroup"></asp:Label>
                        </td>
                        <td>:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Package" Skin="WebBlue" runat="server" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_AssignPrivilageUserGroups" runat="server"
                                ControlToValidate="rcmb_Package" ErrorMessage="Package cannot be empty" InitialValue="Select"
                                ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_AssignPrivilageForms" runat="server" Text="Module" meta:resourcekey="lbl_AssignPrivilageForms"></asp:Label>
                        </td>
                        <td>:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Module" Skin="WebBlue" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rcmb_Module_SelectedIndexChanged" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_AssignPrivilagesForms" runat="server" ControlToValidate="rcmb_Module"
                                ErrorMessage="Module cannot be empty" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <telerik:RadGrid ID="Rg_Privilege" runat="server" AutoGenerateColumns="False" OnPreRender="Rg_Privilege_PreRender" OnItemCreated="Rg_Privilege_ItemCreated" AllowMultiRowSelection="true"
                                GridLines="None" AllowFilteringByColumn="false" Width="700px">
                                <GroupingSettings CaseSensitive="False" />
                                <MasterTableView>
                                    <Columns>
                                        <%--     <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />--%>
                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Email">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Form" runat="server" Text='<%# Eval("FORMS_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="FORMS_NAME" HeaderText="Form Name" Visible="true"
                                            UniqueName="FORMS_NAME">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Read" UniqueName="CheckBoxTemplateColumn" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkbox1" runat="server" AutoPostBack="true"
                                                    Text="Read" OnCheckedChanged="ToggleSelectedState" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRead" runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Write" UniqueName="CheckBoxTemplateColumn1" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="ToggleSelectedState1" AutoPostBack="true"
                                                    Text="Write" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkWrite" runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <PagerStyle AlwaysVisible="True"></PagerStyle>
                                </MasterTableView>
                                <%--<ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>--%>
                                <ActiveItemStyle HorizontalAlign="Left" />
                                <PagerStyle AlwaysVisible="True" />
                            </telerik:RadGrid>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_AssignPrivilageID" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" Text="Update"
                                ValidationGroup="Controls" Visible="False" />
                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                Text="Save" ValidationGroup="Controls" />
                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                Text="Cancel" />
                            <asp:ValidationSummary ID="vs_AssignPrivilage" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="Controls" />
                        </td>
                        <td align="center"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>