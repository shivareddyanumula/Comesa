<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_TrainingFeedBackQuestions.aspx.cs" Inherits="Training_frm_TrainingFeedBackQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
    <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_FeedbackHeader" runat="server" Text="Feedback&nbsp;Question" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Feedback_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="100%" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Feedback_ViewMain" runat="server" Selected="True">
                        <table align="center" >
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Feedback" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true"  OnNeedDataSource="Rg_Feedback_NeedDataSource">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_ID" HeaderText="SNO" UniqueName="FEEDBACKQUESTS_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_QUESTION_CATEGORY" HeaderText="Category"
                                                    UniqueName="FEEDBACKQUESTS_QUESTION_CATEGORY">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_QUESTION" HeaderText="Question"
                                                    UniqueName="FEEDBACKQUESTS_QUESTION">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_OPTION1" HeaderText="Option1"
                                                    UniqueName="FEEDBACKQUESTS_OPTION1" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_OPTION2" HeaderText="Option2"
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
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="ColEdit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("FEEDBACKQUESTS_ID") %>'
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
                                            <td colspan="3" align="center" style="font-weight: bold;">
                                                &nbsp;
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_Category" runat="server" MaxLength="50"   AutoPostBack="false" MarkFirstMatch="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                           <telerik:RadComboBoxItem runat="server" Text="Trainer" Value="Trainer" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Trainee" Value="Trainee" />
                                                     
                                                       
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_Category" runat="server" ControlToValidate="rcmb_Category"
                                                   ErrorMessage="Category cannot be Empty" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_FeedbackID" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lbl_FeddbackQtn" runat="server" Text="Question"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_FeddbackQtn" runat="server" MaxLength="500" >
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_FeddbackQtn" ControlToValidate="rtxt_FeddbackQtn"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Question cannot be Empty">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt1" runat="server" Text="Option&nbsp;1"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt1" runat="server" MaxLength="20" >
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_Feedbackopt1" ControlToValidate="rtxt_Feedbackopt1"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Option1 cannot be Empty">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt2" runat="server" Text="Option&nbsp;2"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt2" runat="server" MaxLength="20" >
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_Feedbackopt2" ControlToValidate="rtxt_Feedbackopt2"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Option2 cannot be Empty">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt3" runat="server" Text="Option&nbsp;3"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt3" runat="server" MaxLength="20" >
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rtxt_Feedbackopt3"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Option3 cannot be Empty">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackopt4" runat="server" Text="Option&nbsp;4"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Feedbackopt4" runat="server" MaxLength="20" >
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="rtxt_Feedbackopt4"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Option4 cannot be Empty">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Feedbackstatus" runat="server" Text="Status"></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcb_Status" runat="server" MarkFirstMatch="true">
                                                <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Active" Value="Active" />
                                                        <telerik:RadComboBoxItem runat="server" Text="InActive" Value="InActive" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Close" Value="Close" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                             <td>
                                                <asp:RequiredFieldValidator ID="rfv_status" runat="server" ControlToValidate="rcb_Status"
                                                   ErrorMessage="Status Cannot Be Empty" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
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

