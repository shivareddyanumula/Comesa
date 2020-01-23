<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_TrainingFeedBackQuestions.aspx.cs" Inherits="Training_frm_TrainingFeedBackQuestions" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_FeedbackHeader" runat="server" Text="Question Bank" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Feedback_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="100%" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Feedback_ViewMain" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Feedback" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" OnNeedDataSource="Rg_Feedback_NeedDataSource">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="QuestionBank_ID " HeaderText="SNO" UniqueName="QuestionBank_ID "
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" HeaderText="Course Name"
                                                    UniqueName="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CHAPTER_NAME" HeaderText="Chapter Name"
                                                    UniqueName="CHAPTER_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="QuestionBank_Question" HeaderText="Question"
                                                    UniqueName="QuestionBank_Question">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--  <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_OPTION2" HeaderText="Option2"
                                                    UniqueName="FEEDBACKQUESTS_OPTION2" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_OPTION3" HeaderText="Option3"
                                                    UniqueName="FEEDBACKQUESTS_OPTION3" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                   <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_STATUS" HeaderText="Status"
                                                    UniqueName="FEEDBACKQUESTS_STATUS" Visible="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("QuestionBank_ID") %>'
                                                            OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Feedback_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td colspan="3" align="center" style="font-weight: bold;">&nbsp;
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Course" runat="server" Text="Course"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Course" runat="server" MaxLength="50" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Course_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>

                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_Course" runat="server" ControlToValidate="rcmb_Course"
                                                    ErrorMessage="Please Select  Course Name" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Chapter" runat="server" Text="Chapter"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Chapter" runat="server" MaxLength="50" AutoPostBack="false" MarkFirstMatch="true" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>

                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_Chapter" runat="server" ControlToValidate="rcmb_Chapter"
                                                    ErrorMessage="Please Select Chapter Name" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_FeedbackID" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lbl_FeddbackQtn" runat="server" Text="Question"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_FeddbackQtn" runat="server" MaxLength="500" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_FeddbackQtn" ControlToValidate="rtxt_FeddbackQtn"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Question">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt1" runat="server" Text="Option&nbsp;1"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt1" runat="server" MaxLength="250" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <input id="rbn_Option1" runat="server" value="1" type="radio" name="myRadio" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_Feedbackopt1" ControlToValidate="rtxt_Feedbackopt1"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Option1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt2" runat="server" Text="Option&nbsp;2"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt2" runat="server" MaxLength="250" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <input id="rbn_Option2" runat="server" value="2" type="radio" name="myRadio" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_Feedbackopt2" ControlToValidate="rtxt_Feedbackopt2"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Option2">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt3" runat="server" Text="Option&nbsp;3"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt3" runat="server" MaxLength="250" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <input id="rbn_Option3" runat="server" value="3" type="radio" name="myRadio" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rtxt_Feedbackopt3"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Option3">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt4" runat="server" Text="Option&nbsp;4"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt4" runat="server" MaxLength="250" TextMode="MultiLine">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <input id="rbn_Option4" type="radio" runat="server" value="4" name="myRadio" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="rtxt_Feedbackopt4"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Option4">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackstatus" runat="server" Text="Status"></asp:Label>
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true"></asp:CheckBox>
                                            </td>

                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" Visible="false"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Edit" runat="server" Text="Update" OnClick="btn_Save_Click" Visible="false"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                                        Visible="false" />
                                    <asp:ValidationSummary ID="vs_Feedback" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>