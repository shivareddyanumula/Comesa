<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmEmpSkills.aspx.cs" Inherits="Security_frmEmpSkills" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsc" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lblHeader" runat="server" Text="Skill Set"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Skill" runat="server" Text="Skill&nbsp;Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Skill" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_SkillName" runat="server" Text="*" InitialValue="Select"
                                        ControlToValidate="rcb_Skill" ValidationGroup="Skills" Display="Dynamic" ErrorMessage="Choose Skill"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_YearLastUsed" runat="server" Text="Last&nbsp;Used"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_YearLastUsed" runat="server" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                            <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                            <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                            <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_YearLastUsed" runat="server" ControlToValidate="rcb_YearLastUsed"
                                        Text="*" ValidationGroup="Skills" Display="Dynamic" ErrorMessage="Choose Year Last Used"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ExpertLevel" runat="server" Text="Expertise"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_ExpertLevel" runat="server" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                            <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                            <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                            <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Expertise" runat="server" ErrorMessage="Choose Skill Expertise"
                                        Text="*" ValidationGroup="Skills" ControlToValidate="rcb_ExpertLevel" InitialValue="Select"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_Skill_Add" runat="server" ValidationGroup="Skills" Text="Add"
                                        OnClick="btn_Skill_Add_Click" />
                                    <asp:Button ID="btn_Skill_Correct" runat="server" ValidationGroup="Skills" Text="Correct"
                                        OnClick="btn_Skill_Correct_Click" Visible="false" />
                                    <asp:Button ID="btn_Skill_Cancel" runat="server" Text="Cancel" OnClick="btn_Skill_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Skills" runat="server" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                        OnItemCommand="RG_Skills_ItemCommand">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("APPSKL_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_SKILL_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Skill_ID" runat="server" Text='<%# Eval("APPSKL_SKILL_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Skill" UniqueName="APPSKL_SKILL_NAME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Skill_Name" runat="server" Text='<%# Eval("APPSKL_SKILL_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Last&nbsp;Used" UniqueName="APPSKL_LASTUSED">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Skill_LastUsed" runat="server" Text='<%# Eval("APPSKL_LASTUSED") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_EXPERT_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Skill_Exp_ID" runat="server" Text='<%# Eval("APPSKL_EXPERT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Expertise" UniqueName="APPSKL_EXPERT">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Skill_Expertise" runat="server" Text='<%# Eval("APPSKL_EXPERT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>