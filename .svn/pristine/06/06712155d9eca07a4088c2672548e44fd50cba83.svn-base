<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="Frm_Assessment.aspx.cs" Inherits="HR_TRAINING_Frm_Assessment" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_TrainingFeedback" runat="server" Text="My Assessment" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="Rm_TRGFEEDABCK_PAGE" runat="server" SelectedIndex="0" 
                    Width="990px" Height="490px" Style="z-index: 10">
                    <telerik:RadPageView ID="Rp_TRGFEEDABCK_VIEWMAIN" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <div style="height: 490px; width: 1014px; overflow: auto;">
                                        <table align="center">

                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblCourse" runat="server" Text="Course Name" meta:resourcekey="lblCourse"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rc_Course" runat="server" AutoPostBack="true" Filter="Contains"
                                                                    OnSelectedIndexChanged="radCourse_SelectedIndexChanged"></telerik:RadComboBox>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rvf_Course" runat="server" ControlToValidate="rc_Course"
                                                                    meta:resourcekey="rvf_Course" ErrorMessage="Please Select Course" InitialValue="Select"
                                                                    Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbl_CourseSchedule" runat="server" Text="Course Schedule" meta:resourcekey="lblCourse"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rc_CourseSchedule" runat="server" Skin="WebBlue" AutoPostBack="true" Filter="Contains"
                                                                    OnSelectedIndexChanged="rc_CourseSchedule_SelectedIndexChanged">
                                                                </telerik:RadComboBox>

                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfv_CourseSchedule" runat="server" ControlToValidate="rc_CourseSchedule"
                                                                    meta:resourcekey="rfv_CourseSchedule" ErrorMessage="Please Select Course Schedule" InitialValue="Select"
                                                                    Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblExamType" runat="server" Text="Assessment Type" meta:resourcekey="lblExamType"></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdExamType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdExamType_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                                    <asp:ListItem Text="Offline" Value="Offline"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rc_CourseSchedule"
                                                                    meta:resourcekey="rfv_CourseSchedule" ErrorMessage="Please Select Course Schedule" InitialValue="Select"
                                                                    Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <telerik:RadGrid ID="RG_Assessments" runat="server" AutoGenerateColumns="False" GridLines="None" Visible="false"
                                                                    Skin="WebBlue">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_ID" UniqueName="TRAINING_ASSESSMENT_ID" HeaderText="ID"
                                                                                meta:resourcekey="TRAINING_ASSESSMENT_ID" Visible="False">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_NAME" UniqueName="TRAINING_ASSESSMENT_NAME"
                                                                                HeaderText="Name" meta:resourcekey="TRAINING_ASSESSMENT_NAME">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_STARTDATE" UniqueName="TRAINING_ASSESSMENT_STARTDATE"
                                                                                HeaderText="Start Date" meta:resourcekey="TRAINING_ASSESSMENT_STARTDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_STARTTIME" UniqueName="TRAINING_ASSESSMENT_STARTTIME"
                                                                                HeaderText="Start Time" meta:resourcekey="TRAINING_ASSESSMENT_STARTTIME">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_ENDDATE" UniqueName="TRAINING_ASSESSMENT_ENDDATE"
                                                                                HeaderText="End Date" meta:resourcekey="TRAINING_ASSESSMENT_ENDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="TRAINING_ASSESSMENT_ENDTIME" UniqueName="TRAINING_ASSESSMENT_ENDTIME"
                                                                                HeaderText="End Time" meta:resourcekey="TRAINING_ASSESSMENT_ENDTIME">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false" >
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TRAINING_ASSESSMENT_ID") %>' 
                                                                                        OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Start Assessment</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <PagerStyle AlwaysVisible="True" />
                                                                    <HeaderContextMenu Skin="WebBlue">
                                                                    </HeaderContextMenu>
                                                                </telerik:RadGrid>
                                                                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" visible="false"
                                                                    Skin="WebBlue">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="OFFLINEASSESSMENT_ID" UniqueName="OFFLINEASSESSMENT_ID" HeaderText="ID"
                                                                                meta:resourcekey="OFFLINEASSESSMENT_ID" Visible="False">
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="OFFLINEASSESSMENT_NAME" UniqueName="OFFLINEASSESSMENT_NAME"
                                                                                HeaderText="Name" meta:resourcekey="OFFLINEASSESSMENT_NAME">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME"
                                                                                HeaderText="Course Name" meta:resourcekey="COURSE_NAME">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name"
                                                                                HeaderText="Course Schedule Name" meta:resourcekey="CourseSchedule_Name">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="Download Assessment">
                                                                                <ItemTemplate>
                                                                                    <a id="D2" runat="server" target="_blank" href='<%#Eval("OFFLINEASSESSMENT_UPLOADEDDOC") %>'>Download Assessment</a>
                                                                                    <asp:Label ID="lbl_BioData" Text='<%#Eval("OFFLINEASSESSMENT_UPLOADEDDOC") %>' Visible="false"
                                                                                        runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnk_Upload" runat="server" CommandArgument='<%# Eval("OFFLINEASSESSMENT_ID") %>'
                                                                                        OnCommand="lnk_Upload_Command" meta:resourcekey="lnk_Edit">Upload Assessment</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <PagerStyle AlwaysVisible="True" />
                                                                    <HeaderContextMenu Skin="WebBlue">
                                                                    </HeaderContextMenu>
                                                                </telerik:RadGrid>
                                                            </td>

                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>


                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_trgfeedback_VIEWDETAILS" runat="server" meta:resourcekey="RP_PROJECT_VIEWDETAILSResource1">
                        <table>
                            <tr>
                                <td align="center" colspan="2">
                                    <b>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblExamID" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCourseNametxt" runat="server" Text="Course Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAssesmentName" runat="server" Text="Assessment Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAssessment" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTotalQuestions" runat="server" Text="Total Questions"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNoOfQuestions" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMarks" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:Timer ID="tmExam" runat="server" Interval="1000" Enabled="false" OnTick="tmExam_Tick">
                                    </asp:Timer>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="width: 100%">
                                                <asp:HiddenField runat="server" ID="hdnTime" Value="" />
                                                <asp:Label ID="lblTimer" runat="server" Text="" Visible="true" Width="200px" Font-Bold="true"></asp:Label>
                                            </div>
                                            <asp:DataList ID="dl_QuestionPaper" runat="server" OnItemDataBound="dl_QuestionPaper_ItemDataBound"
                                                RepeatColumns="1" Font-Size="Large" BorderWidth="1px" BorderColor="#95a49c" BackColor="#d5e2db"
                                                Width="750px" Style="font-family: Arial; font-size: small">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="left" style="width: 2%">
                                                                <asp:Label ID="lbl_questionID" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="#D56A00"
                                                                    Style="font-size: small" Text='<%# Eval("QUESTIONBANK_ID") %>' Visible="false"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 96%">
                                                                <asp:Label ID="lblSN" runat="server" Font-Bold="true" Text='<%# Eval("SNO") %>' /><b>.</b>
                                                                <asp:Label ID="lbl_Question" runat="server" Font-Bold="true" Text='<%# Eval("QUESTIONBANK_QUESTION") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="2">
                                                                <asp:RadioButtonList ID="rbl_options" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbl_options_SelectedIndexChanged">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </ContentTemplate>
                                        <%--<Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tmExam" EventName="Tick" />
                                        </Triggers>--%>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                                    <asp:Button ID="btnEndExam" runat="server" Text="End Exam" OnClick="btnEndExam_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView1" runat="server" meta:resourcekey="RadPageView1">
                        <br />
                        <br />
                        <br />
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="3">
                                    <b>You have successfully completed the Exam. </b>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Marks</b>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblGainedMarks" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Marks Percentage</b>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblPercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Result</b>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server" meta:resourcekey="RadPageView1">                     
                        <br />
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOfflineAssID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblOffAssessmentNametxt" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblOffAssessmentName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAssDoc" runat="server" Text="Document"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <asp:FileUpload ID="fileupload_upload" runat="server" />
                                    
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="fileupload_upload"
                                        ValidationGroup="Controls" runat="Server" ErrorMessage="Only doc files are allowed"
                                        Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
                                    <asp:ValidationSummary ID="vs_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                                                 </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnSave" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

