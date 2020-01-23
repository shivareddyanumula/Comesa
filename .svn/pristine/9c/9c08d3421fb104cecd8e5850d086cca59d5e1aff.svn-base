<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_skill.aspx.cs" Inherits="Recruitment_frm_skill" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_skill.aspx.cs" Inherits="Recruitment_frm_skill" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Heading" runat="server" meta:resourcekey="lbl_Heading"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <telerik:RadMultiPage ID="RM_Skillscategary" runat="server" SelectedIndex="0" Style="z-index: 10"
                ScrollBars="Auto">
                <telerik:RadPageView ID="Rp_Skillcategary" runat="server"
                    Selected="True">
                    <table align="center">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_Skillscategary" runat="server" AutoGenerateColumns="False"
                                    GridLines="None" Skin="WebBlue" AllowPaging="true"
                                    PageSize="5" AllowFilteringByColumn="True" OnNeedDataSource="RG_Skillscategary_NeedDataSource">
                                    <MasterTableView CommandItemDisplay="Top">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="SkillId" DataField="SKILLCAT_ID" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Skillcat skillid" DataField="SKILLCAT_SKILLID">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Skill Name" DataField="SKILLCAT_NAME">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Skill Description" DataField="SKILLCAT_DESCRIPTION">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" OnCommand="lnk_Edit_Commnad"
                                                        CommandArgument='<%# Eval("SKILLCAT_ID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <CommandItemTemplate>
                                            <div align="right">
                                                <asp:LinkButton ID="lnk_add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                <%--<asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command1">Add</asp:LinkButton>--%>
                                            </div>
                                        </CommandItemTemplate>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RP_Skillscategary" runat="server" Width="100%">
                    <table align="center">
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]"></asp:Label>
                                            <asp:Label ID="lbl_Skills" runat="server" Text="Skills"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="RCB_Skills" runat="server" AutoPostBack="true" MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Skills" runat="server" ErrorMessage="Enter Skills"
                                                ControlToValidate="RCB_Skills"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_skillname" runat="server" Text="Skill Name"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Skillname" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Skillname" runat="server" ErrorMessage="Enter SkillName"
                                                ControlToValidate="txt_Skillname"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Description" runat="server" Text="Skill Description"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Description" runat="server" ErrorMessage="Enter SkillDescription"
                                                ControlToValidate="txt_Description"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="7">
                                            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />&nbsp;
                                            <asp:Button ID="btn_Update" runat="server" Text="Update"
                                                OnClick="btn_Update_Click" />&nbsp;
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </tr>
    </table>
</asp:Content>