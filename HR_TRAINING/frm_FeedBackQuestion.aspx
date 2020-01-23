<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_FeedBackQuestion.aspx.cs" Inherits="HR_TRAINING_frm_FeedBackQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" width="990px">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_TrainerProfile" runat="server" Text="Feedback Questions" Font-Bold="True"
                    meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
        
    <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
        Width="990px" Height="490px">
        <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
            <table align="center" >
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="Rg_Countries" runat="server" AutoGenerateColumns="False" GridLines="None"
                            Skin="WebBlue" AllowPaging="True" AllowFilteringByColumn="true">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="FEEDBACKQUESTION_ID" UniqueName="FEEDBACKQUESTION_ID"
                                        HeaderText="ID" meta:resourcekey="FEEDBACKQUESTION_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FEEDBACKQUESTION_TYPE" UniqueName="FEEDBACKQUESTION_TYPE"
                                        HeaderText="Type" meta:resourcekey="FEEDBACKQUESTION_TYPE">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FEEDBACKQUESTION_QUESTION" UniqueName="FEEDBACKQUESTION_QUESTION"
                                        HeaderText="Questions" meta:resourcekey="FEEDBACKQUESTION_QUESTION">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1"
                                        AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("FEEDBACKQUESTION_ID") %>'
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
        <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lbl_Type" runat="server" Text="Type" meta:resourcekey="lbl_CourseDetails"></asp:Label>
                    </td>
                    <td align="left">
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rc_type" runat="server">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                <telerik:RadComboBoxItem runat="server" Text="Service Provider" Value="Service Provider" />
                                <telerik:RadComboBoxItem runat="server" Text="Trainer" Value="Trainer" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_rc_type" ErrorMessage="Please Select Type"
                            InitialValue="Select" ValidationGroup="Part" ControlToValidate="rc_type">
                                  *
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lbl_Question" runat="server" Text="Question" meta:resourcekey="lbl_Question"></asp:Label>
                        <asp:Label ID="lbl_FeedBackID" runat="server" Text="Question" meta:resourcekey="lbl_FeedBackID"
                            Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="rtxt_Question" runat="server" EnableEmbeddedSkins="true"
                            AutoPostBack="true" MaxLength="100" Height="50px" TextMode="SingleLine" Width="200px">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_Questionn" ErrorMessage="Please enter Question "
                            ValidationGroup="Part" ControlToValidate="rtxt_Question">
                                  *
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Description" runat="server" Text="Description" meta:resourcekey="lbl_Description"></asp:Label>
                    </td>
                    <td align="left">
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="rtxt_Description" runat="server" EnableEmbeddedSkins="true"
                            AutoPostBack="true" MaxLength="100" Height="50px" TextMode="SingleLine" Width="200px">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_Description" ErrorMessage="Please enter Description "
                            ValidationGroup="Part" ControlToValidate="rtxt_Description">
                                  *
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_IsActive" runat="server" Text="Status" meta:resourcekey="lbl_IsActive"></asp:Label>
                    </td>
                    <td align="left">
                        <b>:</b>
                    </td>
                    <td align="left">
                         <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                       
                        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Part"
                            Visible="false" />
                        <asp:Button ID="btn_Update" runat="server" ValidationGroup="Part" OnClick="btn_Save_Click"
                            Text="Update" Visible="false" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                        <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
                            ValidationGroup="Part" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    </td>
        </tr>
    </table>
</asp:Content>
