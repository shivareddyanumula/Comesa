<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_CourseMaster.aspx.cs" Inherits="Training_frm_CourseMaster" Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lbl_Coursemaster" runat="server" Text="Master" Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <telerik:RadMultiPage ID="RMP_CourseMaster" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_Allcourses" runat="server">
                        <telerik:RadGrid runat="server" AutoGenerateColumns="false" ID="rg_Courses" 
                        onneeddatasource="rg_Courses_NeedDataSource" AllowFilteringByColumn="true" AllowPaging="true" PageSize="10">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Type" DataField="HR_MASTER_TYPE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="HR_MASTER_CODE">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_AddCourse" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="5">
                                    &#160;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_CourseType" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Course" runat="server" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" />
                                            <telerik:RadComboBoxItem runat="server" Text="COURSE" />
                                            <telerik:RadComboBoxItem runat="server" Text="RESOURCE" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_Code" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Code" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                         <%--   <tr id="skil_id" runat="server" visible="false">
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_skills" runat="server" Text="Skills"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadListBox ID="rlb_skills" runat="server" CheckBoxes="true" Height="100px"
                                        Width="200px">
                                    </telerik:RadListBox>
                                </td>
                                <td>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
                                    &nbsp; &nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
