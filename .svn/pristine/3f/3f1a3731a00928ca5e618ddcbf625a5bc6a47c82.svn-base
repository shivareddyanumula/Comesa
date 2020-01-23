<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Skills.aspx.cs" Inherits="Selfservice_Skills" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        function fnJSOnFormSubmit(sender, group) {
            var isGrpOneValid = Page_ClientValidate(group);
            var i;
            for (i = 0; i < Page_Validators.length; i++) {
                ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
            }
            for (i = 0; i < Page_ValidationSummaries.length; i++) {
                summary = Page_ValidationSummaries[i];
                if (isGrpOneValid) {
                    sender.disabled = "disabled";
                    return true;
                }

                if (fnJSDisplaySummary(summary.validationGroup)) {
                    summary.style.display = "";
                }
            }







        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="300px">
                            <br />
                            <br />
                            <table align="center">
                            </table>
                            <br />
                            <br />
                            <table align="center">
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label1" runat="server" Text="Employee Skill Details" Font-Bold="True" ForeColor="#000000"
                                            Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Skill" runat="server" Text="Skill&nbsp;Name"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcb_Skill" runat="server" Skin="WebBlue" MaxHeight="200px" Filter="Contains">
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
                                        <telerik:RadComboBox ID="rcb_YearLastUsed" runat="server" Skin="WebBlue" MaxHeight="200px" Filter="Contains">
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
                                        <telerik:RadComboBox ID="rcb_ExpertLevel" runat="server" Skin="WebBlue">
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
                                        <asp:Button ID="btn_Skill_Add" runat="server" Text="Add Skill" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Skills')"
                                            OnClick="btn_Skill_Add_Click" />
                                        &nbsp;<asp:Button ID="btn_Skill_Correct" runat="server" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'Skills')"
                                            Text="Correct Skill" OnClick="btn_Skill_Correct_Click" />
                                        &nbsp;<asp:Button ID="btn_Skill_Cancel" runat="server" Text="Cancel" OnClick="btn_Skill_Cancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:ValidationSummary ID="vs_Skill" runat="server" ShowSummary="true" ValidationGroup="Skills" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table align="center">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RG_Skills" runat="server" Skin="WebBlue" GridLines="None" Width="100%"
                                            AutoGenerateColumns="False" OnItemCommand="RG_Skills_ItemCommand">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <MasterTableView>
                                                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                                <Columns>
                                                    <%--<telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                </telerik:GridButtonColumn>--%>
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
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Last&nbsp;Used" UniqueName="APPSKL_LASTUSED">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Skill_LastUsed" runat="server" Text='<%# Eval("APPSKL_LASTUSED") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="ID" UniqueName="APPSKL_EXPERT_ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Skill_Exp_ID" runat="server" Text='<%# Eval("APPSKL_EXPERT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Expertise" UniqueName="APPSKL_EXPERT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Skill_Expertise" runat="server" Text='<%# Eval("APPSKL_EXPERT_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridButtonColumn CommandName="Edit_Rec" Text="Edit" UniqueName="column">
                                                    </telerik:GridButtonColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                        CancelImageUrl="Cancel.gif">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <FilterMenu Skin="WebBlue">
                                            </FilterMenu>
                                            <HeaderContextMenu Skin="WebBlue">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadAjaxPanel>
                    </td>
                </tr>
            </table>
        </div>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    </form>
</body>
</html>