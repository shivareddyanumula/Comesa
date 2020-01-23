<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_TrainingResponse.aspx.cs" Inherits="Training_frm_TrainingResponse" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">

 <script language="javascript">
     function confirm_delete() {
         if (confirm("Are you sure you want to Confirm the Feedback?. After Giving you cannot change.") == true)
             return true;
         else
             return false;
     }
    </script>

    <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_FeedbackrespnsHeader" runat="server" Text="Training&nbsp;Feedback"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_Feedbackrespns_Page" runat="server" SelectedIndex="1"
                    Style="z-index: 10" width = "100%" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Feedbackrespns_ViewMain" runat="server" Selected="True">
                        <table align="center" >
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Feedbackrespns" runat="server"  EnableEmbeddedSkins=false AutoGenerateColumns="False"
                                        GridLines="None" OnNeedDataSource="Rg_Feedbackrespns_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="FEEDBACKRES_TR_ID" UniqueName="FEEDBACKRES_TR_ID"
                                                    HeaderText="CourseID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACKRES_USER_ID" UniqueName="FEEDBACKRES_USER_ID"
                                                    HeaderText="UserID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_TITLE" ItemStyle-HorizontalAlign="Left" UniqueName="TR_TITLE" HeaderText="Training Name">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="USER_FIRSTNAME" UniqueName="USER_FIRSTNAME"  ItemStyle-HorizontalAlign="Left" HeaderText="User Name">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </telerik:GridBoundColumn>
                                                   <telerik:GridBoundColumn DataField="FEEDBACKRES_COMMENTS" UniqueName="FEEDBACKRES_COMMENTS"  ItemStyle-HorizontalAlign="Left" HeaderText="FeedBack Comments">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" OnCommand="lnk_Edit_Command" runat="server" CommandArgument='<%# Eval("FEEBBACKRES_FEEDBACK_NO") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" OnCommand="lnk_Add_Command" runat="server">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Feedbackrespns_ViewDetails" runat="server">
                        <table align="center" style="vertical-align: top;">
                            <tr>
                                <td align ="left">
                                    <asp:Label ID="lbl_FeedbackID" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="_lbl_id" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_ScheduleName" runat="server" Text="Training&nbsp;Name"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_ScheduleName" runat="server" AutoPostBack="True" Filter="Contains"
                                        EnableEmbeddedSkins="false" OnSelectedIndexChanged="rcmb_ScheduleName_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_ScheduleName" ControlToValidate="rcmb_ScheduleName"
                                        InitialValue="Select" runat="server" ValidationGroup="Controls" ErrorMessage="Batch Name cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lbl_Admin" runat="server" Text="Admin" Font-Bold="True" Visible="false"></asp:Label>
                        <asp:Repeater ID="ReptFeedBack_Admin" runat="server">
                            <HeaderTemplate>
                                <table align="center"  style="border: solid 1px #9aadc4;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lblFeedQuesID" runat="server" Text='<%#Bind("FEEDBACKQUESTS_ID")%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="border: 1; background-color: #9aadc4">
                                    <td colspan="6" valign="top" align="left">
                                        <asp:Label ID="lblQuestion" runat="server" Text='Question:    ' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblFeedQuesName" runat="server" Font-Bold="true" Text='<%#Bind("FEEDBACKQUESTS_QUESTION")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border: 1">
                                        <asp:RadioButtonList ID="rdbTest" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5px">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lbl_Course" runat="server" Text="Course" Font-Bold="True" Visible="false"></asp:Label>
                        <asp:Repeater ID="ReptFeedBack_Course" runat="server">
                            <HeaderTemplate>
                                <table align="center" style="border: solid 1px #9aadc4;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lblFeedQuesID" runat="server" Text='<%#Bind("FEEDBACKQUESTS_ID")%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="border: 1; background-color: #9aadc4">
                                    <td colspan="6" valign="top" align="left">
                                        <asp:Label ID="lblQuestion" runat="server" Text='Question:    ' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblFeedQuesName" runat="server" Font-Bold="true" Text='<%#Bind("FEEDBACKQUESTS_QUESTION")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border: 1">
                                        <asp:RadioButtonList ID="rdbTest" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5px">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lbl_Counseller" runat="server" Text="Counseller" Font-Bold="True"
                            Visible="false"></asp:Label>
                        <asp:Repeater ID="ReptFeedBack_Couseller" runat="server">
                            <HeaderTemplate>
                                <table align="center" style="border: solid 1px #9aadc4;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lblFeedQuesID" runat="server" Text='<%#Bind("FEEDBACKQUESTS_ID")%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="border: 1; background-color: #9aadc4">
                                    <td colspan="6" valign="top" align="left">
                                        <asp:Label ID="lblQuestion" runat="server" Text='Question:    ' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblFeedQuesName" runat="server" Font-Bold="true" Text='<%#Bind("FEEDBACKQUESTS_QUESTION")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border: 1">
                                        <asp:RadioButtonList ID="rdbTest" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5px">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="ReptFeedBack_AllTrainer" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Trainer" runat="server" Text="Trainer Feedback for " Font-Bold="True" Visible="false">
                                </asp:Label>
                                <asp:Label ID="lbl_TrainerID" runat="server" Text='<%#Bind("TRAINERDETAILS_EMPLOYEEID")%>' Font-Bold="True" Visible="false">
                                </asp:Label>
                                <asp:Label ID="lbl_TrainerName" runat="server" Text='<%#Bind("USER_FIRSTNAME")%>' Font-Bold="True" Visible="true">
                                </asp:Label>
                                <asp:Repeater ID="ReptFeedBack_Trainer" runat="server">
                                    <HeaderTemplate>
                                        <table align="center"  style="border: solid 1px #9aadc4;">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="5">
                                                <asp:Label ID="lblFeedQuesID" runat="server" Text='<%#Bind("FEEDBACKQUESTS_ID")%>'
                                                    Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="border: 1; background-color: #9aadc4">
                                            <td colspan="6" valign="top" align="left">
                                                <asp:Label ID="lblQuestion" runat="server" Text='Question:    ' Font-Bold="true"></asp:Label>
                                                <asp:Label ID="lblFeedQuesName" runat="server" Font-Bold="true" Text='<%#Bind("FEEDBACKQUESTS_QUESTION")%>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 1">
                                                <asp:RadioButtonList ID="rdbTest" runat="server" RepeatDirection="Horizontal">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" height="5px">
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:Repeater>
                        <table align="center" style="vertical-align: top;">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>
                                
                            </tr>
                            <tr>
                                <td align ="left">
                                    <asp:Label ID="lbl_Feedbackresponse" runat="server" Text="Comments"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td class="style1">
                                    <telerik:RadTextBox ID="rtxt_Feedbackresponse" TextMode="MultiLine" Rows="5" Columns="20" EnableEmbeddedSkins=false
                                        runat="server" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                               
                            </tr>
                            <tr>
                                <td align ="left">
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_StatusColumn" runat="server" Text=":"></asp:Label>
                                </td>
                                <td class="style1">
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" EmptyMessage="Active" EnableEmbeddedSkins=false MarkFirstMatch="true">
                                     <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Active" Value="Active" />
                                                        <telerik:RadComboBoxItem runat="server" Text="InActive" Value="InActive" />
                                                        <telerik:RadComboBoxItem runat="server" Text="Close" Value="Close" />
                                                    </Items>
                                    </telerik:RadComboBox>
                                </td>
                               
                            </tr>
                             <tr>
                                <td align="center">
                                    <br />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls"
                                        OnClick="btn_Save_Click" Visible="false" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                        Visible="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" Visible="false" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_Feedbackrespns" runat="server" ShowMessageBox="True"
                                        ShowSummary="true" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 169px;
        }
    </style>

</asp:Content>


