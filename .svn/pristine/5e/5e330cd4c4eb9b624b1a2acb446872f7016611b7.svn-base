<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Chapters.aspx.cs" Inherits="HR_TRAINING_frm_Chapters" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Chapters" Font-Bold="True"
                    meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center" width="45%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="CHAPTER_ID" UniqueName="CHAPTER_ID" HeaderText="ID"
                                                    meta:resourcekey="CHAPTER_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Course Name"
                                                    meta:resourcekey="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CHAPTER_NAME" UniqueName="CHAPTER_NAME" HeaderText="Name"
                                                    meta:resourcekey="CHAPTER_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CHAPTER_DESCRIPTION" UniqueName="CHAPTER_DESCRIPTION"
                                                    HeaderText="Description" meta:resourcekey="CHAPTER_DESCRIPTION">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false" >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("CHAPTER_ID") %>'
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
                                <td align="left">
                                    <asp:Label ID="lbl_CN" runat="server" Text="Course Name" meta:resourcekey="lbl_CN"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CN" runat="server" Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_CN" runat="server" ControlToValidate="rcmb_CN"
                                        meta:resourcekey="rfv_rcmb_CN" ErrorMessage="Please Select Course Name" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_ChapterId" runat="server" Visible="False" meta:resourcekey="lbl_ChapterId"></asp:Label>
                                    <asp:Label ID="lbl_ChapterName" runat="server" Text="Name" meta:resourcekey="lbl_ChapterName"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ChapterName"  runat="server"
                                        Skin="WebBlue" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ChapterName" ControlToValidate="rtxt_ChapterName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please enter the Name"
                                        meta:resourcekey="rfv_rtxt_ChapterName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_ChapterDesc" runat="server" Text="Description" meta:resourcekey="lbl_ChapterDesc"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ChapterDesc" runat="server" Skin="WebBlue" MaxLength="50"
                                        TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_ChapterDesc" ControlToValidate="rtxt_ChapterDesc"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter the Description"
                                        meta:resourcekey="rfv_rtxt_ChapterDesc">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true"></asp:CheckBox>
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
