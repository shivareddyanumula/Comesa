<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingFeedBack.aspx.cs" Inherits="Training_frm_TrainingFeedBack" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
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
        var tab_select_function = function (event, ui) {
            jQuery('#tabindex').val(ui.index);
        };
        jQuery("#tabs").tabs({
            select: tab_select_function
        });
        jQuery("#tabs").tabs("option", "selected", [jQuery('#tabindex').val()]);

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindowManager ID="RWM_FeedBack" runat="server" Skin="WebBlue" Animation="Slide"
        AnimationDuration="300" Behaviors="Close">
        <Windows>

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
                <asp:Label ID="lbl_TrainingFeedback" runat="server" Text="Online Assessment" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_TRGFEEDABCK_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                    Width="990px" Height="490px" Style="z-index: 10">
                    <telerik:RadPageView ID="Rp_TRGFEEDABCK_VIEWMAIN" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_id" runat="server" Visible="false"></asp:Label>
                                    <telerik:RadGrid ID="Rg_TrgFeedback" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_TrgFeedback_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_ID" UniqueName="TRAINING_ASSESSMENT_ID" HeaderText="ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_NAME" UniqueName="TRAINING_ASSESSMENT_NAME" HeaderText="Assessment Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_NOOFQUESTIONS" UniqueName="TRAINING_ASSESSMENT_NOOFQUESTIONS"
                                                    HeaderText="No Of Questions">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_TIME" UniqueName="TRAINING_ASSESSMENT_TIME" HeaderText="Time">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColAssign" AllowFiltering="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Assign" runat="server" CommandArgument='<%# Eval("TRAINING_ASSESSMENT_ID") %>'
                                                            OnCommand="lnk_FEEDBACK_ID_Command">Edit</asp:LinkButton>
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
                                <td>
                                    <asp:Label ID="lbl_CC" runat="server" Text="Course Category"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CC" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CC_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BU" ControlToValidate="rcmb_CC" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Course Category">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblNoOfQuestions" runat="server" Text="No Of Questions"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="radNoOfQuestions" runat="server" MinValue="1" MaxLength="2" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="radNoOfQuestions"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="No Of Questions cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CourseName" runat="server" Text="Course Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CourseName" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CourseName_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_TRName" ControlToValidate="rcmb_CourseName" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Course">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblMarks" runat="server" Text="Minimum %of Marks"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="radMarks" runat="server" MinValue="1" MaxLength="3" MaxValue="100" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="radMarks"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Minimum %of Marks cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CourseSchedule" runat="server" Text="Course Schedule"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_CourseSchedule" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_Type" ControlToValidate="rcmb_CourseSchedule" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Course Schedule">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblAssessmentTime" runat="server" Text="Assessment Time"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="radAssessmentTime" runat="server" MinValue="1" MaxLength="3" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="radAssessmentTime"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Assessment Time cannot be Empty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AssessmentName" runat="server" Text="Assessment Name"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_AssessmentName" runat="server" LabelCssClass="" MaxLength="40">
                                    </telerik:RadTextBox>

                                    <asp:RequiredFieldValidator ID="rfv_rtxt_FeedbackName" runat="server" ControlToValidate="rtxt_AssessmentName"
                                        ErrorMessage="Assessment Name cannot be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>


                                <td align="left">
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" meta:resourcekey="lblStartDate"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="radStartdate" runat="server" MaxLength="50" oncut="return false;">
                                        <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy" ReadOnly="true" autocomplete="off">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="radStartdate"
                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select Start Date"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FeedbackDescription" runat="server" meta:resourcekey="lbl_FeedbackDescription"
                                        Text="Description"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td rowspan="2">
                                    <telerik:RadTextBox ID="rtxt_FeedbackDescription" runat="server" LabelCssClass="" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" meta:resourcekey="lblStartDate"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="radEndDate" runat="server" MaxLength="50" oncut="return false;">
                                        <DateInput ID="DateInput2" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy" ReadOnly="true" autocomplete="off">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <asp:CompareValidator ID="cv_DOJ" runat="server" ControlToCompare="radStartdate" ControlToValidate="radEndDate"
                                        Display="Dynamic" meta:resourcekey="cv_DOJ" Operator="GreaterThan" Text="*" Type="Date" ErrorMessage="End Date should be greater than Start Date"
                                        ValidationGroup="Controls"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfv_DOJ" runat="server" ControlToValidate="radEndDate"
                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select End Date"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>


                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lblStartTime" runat="server" Text="Start Time" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="radStartTime" runat="server" DateInput-ReadOnly="true" MinDate="1900-01-01" MaxLength="50" Width="245px">
                                    </telerik:RadTimePicker>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="radStartTime"
                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select Start Time"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="lblChapters" runat="server" Text="Chapters"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="radChapters" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                                        OnSelectedIndexChanged="radChapters_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="radChapters" InitialValue="Select"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Chapters">*</asp:RequiredFieldValidator>
                                </td>

                                <td>
                                    <asp:Label ID="lblEndTime" runat="server" Text="End Time" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="radEndTime" runat="server" DateInput-ReadOnly="true" MinDate="1900-01-01" MaxLength="50" Width="245px">
                                    </telerik:RadTimePicker>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="radStartTime" ControlToValidate="radEndTime"
                                        Display="Dynamic" meta:resourcekey="cv_DOJ" Operator="GreaterThan" Text="*" Type="String" ErrorMessage="End Time should be greater than Start Time"
                                        ValidationGroup="Controls"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="radEndTime"
                                        meta:resourcekey="rfv_DOJ" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Please Select End Time"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblQuestions" runat="server" meta:resourcekey="lblQuestions"
                                        Text="Questions"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td colspan="4">
                                    <telerik:RadListBox ID="radQuestions" runat="server" CheckBoxes="true" Height="100px" Style="min-width: 600px;">
                                    </telerik:RadListBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="6">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Save_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vs_Feedbackrespns" runat="server" ShowMessageBox="True"
                                        ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="tabindex" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>