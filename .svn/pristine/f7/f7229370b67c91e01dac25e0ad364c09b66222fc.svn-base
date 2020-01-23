<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_InterviewAssesmentFianal.aspx.cs" Inherits="Recruitment_frm_InterviewAssesmentFianal" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"
        >
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="111%" Width="100%">--%>
    <br />
    <br />
    <telerik:RadMultiPage ID="RMP_InterviewAssesment" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RPV_InterviewAssesmentHeader" runat="server">
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_HeaderText" runat="server" Font-Bold="True" Font-Underline="true"
                            Text="Interview Assesment Form"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="2" cellspacing="2" align="center">
                            <tr id="tr_bunit" runat="server">
                                <td>
                                    <asp:Label ID="lbl_BU" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td align="right">:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                                        Skin="WebBlue" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BU" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        InitialValue="Select" ErrorMessage="Please select Business Unit" meta:resourcekey="rfv_BU"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>

                            <tr id="tr_intername" runat="server">
                                <td>
                                    <asp:Label ID="lbl_Interviewname" runat="server" Text="Interviewer Name"></asp:Label>
                                </td>
                                <td align="right">:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Interviewername" runat="server" AutoPostBack="true" Skin="WebBlue"
                                        OnSelectedIndexChanged="rcmb_Interviewername_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Interviewer" runat="server" ControlToValidate="rcmb_Interviewername"
                                        ErrorMessage="Please Choose Interviewer Name" meta:resourcekey="rfv_Interviewer" Text="*"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobReq" runat="server" Text="Job Request"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_JobReq" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="Rcb_JobReq_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <%-- <td>
                                        <asp:RequiredFieldValidator ID="RFV_Rcb_JobReq" runat="server" ControlToValidate="Rcb_JobReq"
                                            ErrorMessage="Select Job Request" InitialValue="Select" ValidationGroup="ControlsHeader">*</asp:RequiredFieldValidator>
                                    </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApplicantID" runat="server" Text="Select Applicant"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_ApplicantID" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="Rcb_ApplicantID_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <%-- <td>
                                        <asp:RequiredFieldValidator ID="RFV_Rcb_ApplicantID" runat="server" ControlToValidate="Rcb_ApplicantID"
                                            ValidationGroup="ControlsHeader" ErrorMessage="Select the Applicant" InitialValue="Select">*</asp:RequiredFieldValidator>
                                    </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PhaseID" runat="server" Text="Phase"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_PhaseID" runat="server"
                                        MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rcb_PhaseID" runat="server" ControlToValidate="Rcb_PhaseID"
                                        ErrorMessage="Select Phase" InitialValue="Select" ValidationGroup="ControlsHeader">*</asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Button ID="btn_Next" runat="server" Text="Next" OnClick="btn_Submit_Click" ValidationGroup="ControlsHeader" />
                                    <asp:Button ID="btn_Clear" runat="server" Text="Cancel" OnClick="btn_Clear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="VS_InterviewAssesmentHeader" runat="server" ShowMessageBox="true"
                                        ShowSummary="false" ValidationGroup="ControlsHeader" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RPV_InterviewAssesmentDetails" runat="server" Selected="false">
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_Caption" runat="server" Font-Bold="True" Font-Underline="true"
                            Text="Interview Assesment Form"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="2" cellspacing="2" align="center">
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lbl_ContactInformation" Text="Candidate's Contact Information" runat="server"
                                        Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                    <asp:Label ID="lbl_Skill" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_JobReqId" runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_RefferedBy" Text="Reffered By" runat="server" Font-Bold="true"
                                        Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_RefferedBy" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FullName" runat="server" Text="Full name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_FullName" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_DateOfInterview" runat="server" Text="Date of Interview"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DateofInterview" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ContactNumber" runat="server" Text="Contact Number"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="rntxt_ContactNumber" runat="server"
                                        DisplayMask="###-###-####" Enabled="false"
                                        Mask="(###) ###-####" Skin="WebBlue" TextWithLiterals="() -">
                                    </telerik:RadMaskedTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_PositionAppliedFor" runat="server"
                                        Text="Position Applied for"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_PositionAppliedFor" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ToatlExp" runat="server" Text="Total Exp"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_TotalExp" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Qualification" runat="server" Text="Qualification"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Qualification" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RelevantExp" runat="server" Text="Relevant Exp"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_RelevantExp" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Company" runat="server" Text="Current Company"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Company" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <%-- <tr>
                                    <td>
                                        <asp:Label ID="lbl_Certifications" runat="server" Text="Certifications (if any)"></asp:Label>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_Certifications" runat="server" Enabled="false" 
                                            >
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_ValidPassport" runat="server" Text="Valid Passport (Y/N)"></asp:Label>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_ValidPassport" runat="server" Enabled="false" 
                                            >
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>--%>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnk_ViewResume" Font-Size="10pt" runat="server">Click Here to View Resume</asp:LinkButton>
                                </td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:Label ID="lbl_FirstRound" runat="server" Text="" Font-Bold="true" Font-Names="Arial"
                                        Font-Size="10pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <telerik:RadGrid ID="RG_Skills1" runat="server" AutoGenerateColumns="False"
                                        Width="620px" Skin="WebBlue">
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                        <MasterTableView>
                                            <Columns>
                                                <%--<telerik:GridBoundColumn DataField="SkillCat_ID" HeaderText="ID" UniqueName="Skills_ID"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="SKILLCAT_NAME" HeaderText="Skills" UniqueName="Skills">
                                                    </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="JR_SKILLS_ID" HeaderText="ID" UniqueName="Skills_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Skills" UniqueName="Skills">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="Column1">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_Column1" runat="server" Text="Assesment"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <telerik:RadComboBox ID="Rcb_Assesment" runat="server" Skin="WebBlue" MarkFirstMatch="true">
                                                                <Items>
                                                                    <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                                    <telerik:RadComboBoxItem Text="Beginner" Value="1" />
                                                                    <telerik:RadComboBoxItem Text="Intermediate" Value="2" />
                                                                    <telerik:RadComboBoxItem Text="Expert" Value="3" />
                                                                </Items>
                                                            </telerik:RadComboBox>
                                                        </asp:Panel>
                                                        <%--<telerik:RadComboBox ID="Rcb_Assesment" runat="server" 
                                                                  OnDataBinding="Rcb_Assesment_DataBinding"
                                                                     MarkFirstMatch="true">
                                                                </telerik:RadComboBox>--%>
                                                        <%--OnDataBinding="Rcb_Assesment_DataBinding"--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <FilterMenu>
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <%-- This tags are added for the HR Round Phase--%>
                            <tr id="tr_CTC" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_PreviousCTC" runat="server" Text="Previous / Current CTC"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="Rntxt_PreviousCTC" runat="server"
                                        NumberFormat-AllowRounding="false"
                                        NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_ExpectedCTC" runat="server" Text="Expected CTC"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="Rntxt_ExpectedCTC" runat="server"
                                        NumberFormat-AllowRounding="false"
                                        NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr id="tr_NoticePeriod" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_NoticePeriod" runat="server" Text="Notice Period"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="Rtxt_NoticePeriod" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_ReasonforChange" runat="server" Text="Reason for change"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="Rtxt_ReasonforChange" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr id="tr_FamilyDetails" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_FamilyDetails" runat="server" Text="Family Details"></asp:Label>
                                </td>
                                <td>:</td>
                                <td colspan="5">
                                    <telerik:RadTextBox ID="Rtxt_FamilyDetails" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <%--The above tags are added for the HR Round Phase --%>
                            <tr>
                                <td colspan="7">
                                    <asp:Label ID="lbl_AdditionalComments" runat="server" Text="Additional Comments"
                                        Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td colspan="5">
                                    <telerik:RadTextBox ID="rtxt_AdditionalComments1" runat="server"
                                        MaxLength="500" Rows="3" TextMode="MultiLine"
                                        Width="622px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <%-- The below tags are for the HR Round  --%>
                            <tr id="tr_OverallAssessment" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_OverallAssessment" runat="server" Text="Overall Assessment"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td colspan="1">
                                    <telerik:RadComboBox ID="Rcb_OverallAssessment" runat="server"
                                        MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select" />
                                            <telerik:RadComboBoxItem Value="1" Text="Beginner" />
                                            <telerik:RadComboBoxItem Value="2" Text="Intermediate" />
                                            <telerik:RadComboBoxItem Value="3" Text="Expert" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rcb_OverallAssessment" runat="server"
                                        ControlToValidate="Rcb_OverallAssessment"
                                        ErrorMessage="Select Overall Assessment" InitialValue="Select"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr_Recommendation" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_Recommendation" runat="server" Text="Recommendation"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td colspan="5">
                                    <telerik:RadComboBox ID="Rcb_Recommendation" runat="server"
                                        MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="5">&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr id="tr_FinalCompensationDetails" runat="server" visible="false">
                                <td colspan="7">
                                    <asp:Label ID="lbl_FinalCompensationDetails" runat="server"
                                        Text="Final Compensation Details" Font-Bold="true" Font-Names="Arial"
                                        Font-Size="10pt"></asp:Label>
                                    <asp:Label ID="lbl_IfSelected" runat="server" Text="(if selected) "></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td colspan="7"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                            <tr id="tr_BU" runat="server" visible="false">
                                <%--<td>
                                        <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit" 
                                            meta:resourcekey="lbl_BusinessUnitName"></asp:Label>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" 
                                             meta:resourcekey="rcmb_BusinessUnitType" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged"                                          
                                            Width="200px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="Rfv_Rntxt_BusinessUnit" runat="server" 
                                            ControlToValidate="rcmb_BusinessUnit" ErrorMessage="Enter Business Unit" InitialValue="Select" 
                                          ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                    </td>--%>
                                <td>
                                    <asp:Label ID="lbl_JoiningdateConfirmed" runat="server"
                                        Text="Joining Date"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadDatePicker ID="Rdp_JoiningdateConfirmed" runat="server">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rdp_JoiningdateConfirmed" runat="server"
                                        ControlToValidate="Rdp_JoiningdateConfirmed" ErrorMessage="Enter Joining Date"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr_Department" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Department" runat="server" AutoPostBack="True"
                                        meta:resourcekey="rcmb_BusinessUnitType"
                                        Width="200px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rfv_Rntxt_Department" runat="server"
                                        ControlToValidate="rcmb_Department" ErrorMessage="Enter Department"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_DesignationOffered0" runat="server" Text="Designation"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Designation" runat="server" AutoPostBack="True" Filter="Contains"
                                        meta:resourcekey="rcmb_BusinessUnitType" Width="200px" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rfv_Rntxt_Designation" runat="server"
                                        ControlToValidate="rcmb_Designation" ErrorMessage="Enter Designation" InitialValue="Select"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr_OfferedCTC" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_OfferedCTC" runat="server" Text="Offered CTC"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <%--<telerik:RadTextBox ID="Rtxt_OfferedCTC" runat="server" 
                                            >
                                        </telerik:RadTextBox>--%>
                                    <telerik:RadNumericTextBox ID="Rnt_Offeredctc" runat="server">
                                    </telerik:RadNumericTextBox>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rfv_Rntxt_Offeredctc" runat="server"
                                        ControlToValidate="Rnt_Offeredctc" ErrorMessage="Enter OfferedCTC"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Level" runat="server" Text="Level"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Level" runat="server" AutoPostBack="True"
                                        meta:resourcekey="rcmb_BusinessUnitType" Filter="Contains"
                                        Width="200px" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rfv_Rntxt_Level" runat="server"
                                        ControlToValidate="rcmb_Level" ErrorMessage="Enter Level" InitialValue="Select"
                                        ValidationGroup="ControlsHR">*</asp:RequiredFieldValidator>
                                </td>
                                <%--<td>
                                        <asp:Label ID="lbl_Division" runat="server" Text="Division"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="Rtxt_Division" runat="server" 
                                            MaxLength="100">
                                        </telerik:RadTextBox>
                                    </td>--%>
                            </tr>
                            <tr id="tr_OfferedSalary" runat="server" visible="false">
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_OfferedSalary" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Button ID="btn_Submit" runat="server" Text="Shortlisted" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_Rejected" runat="server" Text="Rejected" OnClick="btn_Submit_Click" />
                                    <asp:Button ID="btn_HrSubmit" runat="server" Text="Shortlisted" OnClick="btn_Submit_Click"
                                        Visible="false" ValidationGroup="ControlsHR" />
                                    <asp:Button ID="btn_HrRejected" runat="server" Text="Rejected" OnClick="btn_Submit_Click"
                                        Visible="false" ValidationGroup="ControlsHR" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Clear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <asp:ValidationSummary ID="vs_Assessment" runat="server" ShowMessageBox="True" ShowSummary="False"
                                    ValidationGroup="ControlsHR" />
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <%--</telerik:RadAjaxPanel>--%>
</asp:Content>