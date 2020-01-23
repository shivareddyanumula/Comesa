<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_recruitmentskillscategary.aspx.cs" Inherits="Recruitment_frm_recruitmentskillscategary" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">&nbsp;<asp:Label ID="lbl_PhaseDefinitionHeader" runat="server" Text="Skill Category" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_SkillsCategary" runat="server">
                    <telerik:RadPageView ID="RP_SkillCategary" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_SkillsCategary" runat="server"
                                        AllowFilteringByColumn="true" AutoGenerateColumns="false" OnNeedDataSource="RG_Skillscategary_NeedDataSource"
                                        AllowPaging="true" PageSize="5">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Skill_id" DataField="SKILLCAT_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="SkillCategoryId" DataField="SKILLCAT_SKILLID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Skill Category" DataField="HR_MASTER_CODE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Skill Name" DataField="SKILLCAT_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Skill Description" DataField="SKILLCAT_DESCRIPTION">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%#Eval("SKILLCAT_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_skillscategarydetails" runat="server" Width="100%">
                        <table align="center">
                            <%--<tr>
                                <td align="center" colspan="5">
                                    <h4>
                                        Skill Category Details
                                    </h4>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_skillsCategary" runat="server" Text="Skill"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCMB_Skills" runat="server" AutoPostBack="true" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_SkillsCategary" runat="server" ErrorMessage="Please Select Skill"
                                        Text="*" ControlToValidate="RCMB_Skills" ValidationGroup="Controls" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_skillname" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%-- <asp:TextBox ID="Txt_Skillname" runat="server"></asp:TextBox>--%>
                                    <telerik:RadTextBox ID="RT_Skillname" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Skillname" runat="server" Text="*" ErrorMessage="Please Enter Name"
                                        ControlToValidate="RT_Skillname" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_SkillDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%-- <asp:TextBox ID="txt_SkillDesc" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                                    <telerik:RadTextBox ID="RT_SkillDesc" runat="server" weight="500px">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <%--   <asp:RequiredFieldValidator ID="RFV_SkillDescription" runat="server" Text="*" ErrorMessage="Enter SkillDescription"
                                        ControlToValidate="RT_SkillDesc" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="7">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls" />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                                        ValidationGroup="Controls" />&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_SkillCategarySummary" runat="server" ValidationGroup="Controls"
                            ShowMessageBox="True" ShowSummary="False" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>