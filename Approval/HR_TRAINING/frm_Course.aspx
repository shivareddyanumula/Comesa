<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Course.aspx.cs" Inherits="Training_frm_Course" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Course" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="COURSE_ID" UniqueName="COURSE_ID" HeaderText="ID"
                                                    meta:resourcekey="COURSE_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_BUSINESSUNIT_ID" UniqueName="COURSE_BUSINESSUNIT_ID"
                                                    HeaderText="Business Unit Code" meta:resourcekey="COURSE_BUSINESSUNIT_ID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_CATEGORYID" UniqueName="COURSE_CATEGORYID"
                                                    HeaderText="Course Name" meta:resourcekey="COURSE_CATEGORYID">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Module Name"
                                                    meta:resourcekey="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_DESC" UniqueName="COURSE_DESC" HeaderText="Module Desc"
                                                    meta:resourcekey="COURSE_DESC">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("COURSE_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Course_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_CourseDetails" runat="server" Text="Course Details" meta:resourcekey="lbl_CourseDetails"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit" meta:resourcekey="lbl_BusinessUnitName"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_BusinessUnitType_indexchanged" Width="200px" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" ControlToValidate="rcmb_BusinessUnitType"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select BusinessUnit"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_CC" runat="server" Text="Course Name" meta:resourcekey="lbl_CC"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CC" runat="server" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_CC" runat="server" ControlToValidate="rcmb_CC"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Course Name" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_CourseId" runat="server" Visible="False" meta:resourcekey="lbl_CourseId"></asp:Label>
                                    <asp:Label ID="lbl_CourseName" runat="server" Text="Module Name" meta:resourcekey="lbl_CourseName"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CourseName" Style="text-transform: uppercase;" runat="server"
                                        Skin="WebBlue" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CourseName" ControlToValidate="rtxt_CourseName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Module Name Cannot Be Empty"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_CourseDesc" runat="server" Text="Module Desc" meta:resourcekey="lbl_CourseDesc"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_CourseDesc" runat="server" Skin="WebBlue" MaxLength="50"
                                        TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CourseDesc" ControlToValidate="rtxt_CourseDesc"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Module Desc Cannot Be Empty"
                                        meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="skil_id" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_skills" runat="server" Text="Skills"></asp:Label>
                                </td>
                                <td align="right">
                                    :
                                </td>
                                <td>
                                    <telerik:RadListBox ID="rlb_skills" runat="server" CheckBoxes="true" Height="100px"
                                        Width="200px">
                                    </telerik:RadListBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
