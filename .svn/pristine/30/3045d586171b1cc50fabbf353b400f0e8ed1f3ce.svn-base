<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingFeedBack.aspx.cs" Inherits="Training_frm_TrainingFeedBack" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>

    <script type="text/javascript">
        //        function openRadWin(str) {
        //            radopen(str, "RW_FeedBack");
        //        }
        function WinOpen_image() {
            var wnd = window.radopen("frm_FeedBackQuestionForm.aspx", "rw_updatepage");
            wnd.SetTitle("Preview");
            wnd.set_status = " ";
            wnd.center();
        }
        function OnClientClose(oWnd, args) {

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindowManager ID="RWM_FeedBack" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close">
        <Windows>
            <%--  <telerik:RadWindow ID="RW_FeedBack" Skin="WebBlue" Modal="true" runat="server" Width="800px"
                Height="800px" Title="FeedBack Questions" AutoSize="true" VisibleStatusbar="false"
                ReloadOnShow="true" Behaviors="Close" KeepInScreenBounds="true" ShowContentDuringLoad="true">
            </telerik:RadWindow>--%>
            <telerik:RadWindow ID="RW_FeedBack" runat="server" Skin="WebBlue" Modal="true" Title="FeedBack Questions"
                ReloadOnShow="true" OnClientClose="OnClientClose" ShowContentDuringLoad="true"
                KeepInScreenBounds="true" Width="1200px" VisibleStatusbar="false" Height="1200px"
                Behaviors="Close">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_TrainingFeedback" runat="server" Text="Training Feedback" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_TRGFEEDABCK_PAGE" runat="server" SelectedIndex="0" Width="990px"
                    Style="z-index: 10" ScrollBars="Auto" Height="350px">
                    <telerik:RadPageView ID="Rp_TRGFEEDABCK_VIEWMAIN" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_id" runat="server" Visible="false"></asp:Label>
                                    <telerik:RadGrid ID="Rg_TrgFeedback" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_TrgFeedback_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="FEEDBACK_ID" UniqueName="FEEDBACK_ID" HeaderText="ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_TITLE" UniqueName="TR_TITLE" HeaderText="Training">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACK_CATEGORY" UniqueName="FEEDBACK_CATEGORY"
                                                    HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FEEDBACK_NAME" UniqueName="FEEDBACK_NAME" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColAssign" AllowFiltering="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Assign" runat="server" CommandArgument='<%# Eval("FEEDBACK_ID") %>'
                                                            OnCommand="lnk_FEEDBACK_ID_Command" Visible="false">Assign</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_trgfeedback_VIEWDETAILS" runat="server" meta:resourcekey="RP_PROJECT_VIEWDETAILSResource1">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_Heading" runat="server" Text="Training FeedBack"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_BU" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BU" ControlToValidate="rcmb_BU" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Business Unit cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_TrainingName" runat="server" Text="Training Module"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_TRName" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_TRName" ControlToValidate="rcmb_TRName" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Training Name cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Type" runat="server" Text="Type"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Type_SelectedIndexChanged"
                                        MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                            <telerik:RadComboBoxItem runat="server" Text="Trainer" Value="Trainer" />
                                            <telerik:RadComboBoxItem runat="server" Text="Trainee" Value="Trainee" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_Type" ControlToValidate="rcmb_Type" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Type cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FeedbackName" runat="server" Text="Feedback&nbsp;Name"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_FeedbackName" runat="server" LabelCssClass="" MaxLength="40">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_FeedbackName" runat="server" ControlToValidate="rtxt_FeedbackName"
                                        ErrorMessage="Feedback Name Cannot Be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FeedbackDescription" runat="server" meta:resourcekey="lbl_FeedbackDescription"
                                        Text="Description"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_FeedbackDescription" runat="server" Height="100px" Width="200px"
                                        LabelCssClass="" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_attendanceback" runat="server" Text="Back Dated Attendance"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rnt_bakdateddate" runat="server" Width="50px" AllowOutOfRangeAutoCorrect="false">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_backdatedattendance" runat="server" ControlToValidate="rnt_bakdateddate"
                                        ErrorMessage="Back Date Cannot Be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Quetions" runat="server" Text="Quetions"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadListBox ID="rlb_Quetions" runat="server" CheckBoxes="true" Height="100px"
                                        Width="200px" AutoPostBack="true" OnItemCheck="QuestionRadListBox_ItemCheck">
                                    </telerik:RadListBox>
                                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style1" colspan="3">
                                    <telerik:RadGrid ID="RG_FeedBack" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        Visible="false" PageSize="5" Width="300px" OnNeedDataSource="RG_FeedBack_NeedDataSource"
                                        Skin="WebBlue">
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="FeedBackID"
                                                    Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppID" runat="server" Text='<%# Eval("FEEDBACKQUESTS_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="FeadBack Question">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppName" runat="server" Text='<%# Eval("FEEDBACKQUESTS_QUESTION") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--    <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_ID" HeaderText="FeedBackID" >
                                  </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_QUESTION" HeaderText="FeadBack Question" >
                                  </telerik:GridBoundColumn>--%>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                                    CancelImageUrl="Cancel.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu>
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <%-- <td>
                        <asp:Label ID="lbl_assign" runat="server" Text="Assign To"></asp:Label>
                    </td>--%>
                                <%-- <td>
                        <telerik:RadComboBox ID="rcm_employee" runat="server" AutoPostBack="false" EnableEmbeddedSkins="false">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="rfv_rcm_employee" ControlToValidate="rcm_employee"
                            InitialValue="Select" runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee">*</asp:RequiredFieldValidator>
                    </td>--%>
                                <td>
                                    <asp:Button ID="btn_assign" runat="server" Visible="false" Text="Assign" ValidationGroup="Controls"
                                        OnClick="btn_assign_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Preview" runat="server" Text="Preview" OnClick="btn_Preview_Click"
                                        ValidationGroup="Controls" />
                                    <%--OnClientClick=" openRadWin('frm_FeedBackQuestionForm.aspx'); return false;"--%>
                                    <asp:Button ID="btn_Finalize" runat="server" Text="Finalize" Visible="false" OnClick="btn_Finalize_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_Feedbackrespns" runat="server" ShowMessageBox="True"
                                        ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
