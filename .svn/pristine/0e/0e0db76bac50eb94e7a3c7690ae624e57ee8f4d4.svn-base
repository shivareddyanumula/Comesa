<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Project.aspx.cs" Inherits="PMS_frm_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Project" runat="server" Text="Project" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_PROJECT_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    meta:resourcekey="Rm_PROJECT_PAGEResource1">
                    <telerik:RadPageView ID="Rp_PROJECT_VIEWMAIN" runat="server" Selected="True" Width="493px"
                        meta:resourcekey="Rp_PROJECT_VIEWMAINResource1">
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Project" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_Project_NeedDataSource"
                                        PageSize="5" AllowFilteringByColumn="True" meta:resourcekey="Rg_ProjectResource1">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="PROJECT_ID" UniqueName="PROJECT_ID" HeaderText="ID"
                                                    meta:resourcekey="PROJECT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE" HeaderText="Business Unit">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="PROJECT_NAME" UniqueName="PROJECT_NAME" HeaderText="Project Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PROJECT_DESCRIPTION" UniqueName="PROJECT_DESCRIPTION"
                                                    HeaderText="Description">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" meta:resourcekey="lnk_Edit" CommandArgument='<%# Eval("PROJECT_ID") %>'
                                                            OnCommand="lnk_edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_PROJECT_VIEWDETAILS" runat="server" meta:resourcekey="RP_PROJECT_VIEWDETAILSResource1">
                        <table align="center" width="30%">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_det" runat="server" Text="Details" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                   <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" meta:resourcekey="rcmb_BUI" MarkFirstMatch="true"  MaxHeight="120px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Please select Business Unit" ValidationGroup="Controls" InitialValue="Select"  >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ProjectId" runat="server" meta:resourcekey="lbl_ProjectIdResource1"
                                        Visible="False"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lbl_ProjectName" runat="server" Text="Project&nbsp;Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ProjectName" runat="server"
                                        LabelCssClass="" meta:resourcekey="rtxt_ProjectNameResource1" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ProjectName" runat="server" ControlToValidate="rtxt_ProjectName"
                                        ErrorMessage="Please Enter Project Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ProjectDescription" runat="server" meta:resourcekey="lbl_ProjectDescription"
                                        Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ProjectDescription" runat="server"
                                        LabelCssClass="" meta:resourcekey="rtxt_ProjectDescriptionResource1" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click1"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_PROJECT" runat="server" meta:resourcekey="vs_PROJECTResource1"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>