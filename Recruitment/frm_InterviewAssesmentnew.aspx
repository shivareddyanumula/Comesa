<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_InterviewAssesmentnew.aspx.cs" Inherits="Recruitment_frm_InterviewAssesmentnew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            height: 30px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function ShowPop(JOBREQ_ID) {
                var win = window.radopen('../Recruitment/frm_JobReqDetails.aspx?JOBREQ_ID=' + JOBREQ_ID, "RW_ViewJobReqDetails");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }

            function ShowApplicantPop(APPLICANT_ID) {
                var win = window.radopen('../Recruitment/frm_ViewApplicantDetails.aspx?APPID=' + APPLICANT_ID, "RW_KRAApproval2");
                //var win = window.radopen('../Recruitment/frm_applicantadd.aspx?APPID=' + APPLICANT_ID, "RW_ViewJobReqDetails");
                win.center();
                //win.setTitle("Applicant Details");
                //win.height = 30;
                win.set_modal(true);
            }

            function ShowIntasmt(APPLICANT_ID, JOBREID, IAF_PHASEDEFID) {
                var win = window.radopen('../Recruitment/frm_ViewInterviewAssesmentnew.aspx?APPID=' + APPLICANT_ID + '&JOBREID=' + JOBREID + '&IAF_PHASEDEFID=' + IAF_PHASEDEFID, "RW_ApplicantDetails");
                //var win = window.radopen('../Recruitment/frm_applicantadd.aspx?APPID=' + APPLICANT_ID, "RW_ViewJobReqDetails");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
            function disableButon(sender, group) {
                Page_ClientValidate(group);
                if (Page_IsValid) {
                    sender.disabled = "disabled";
                    //__doPostBack(sender.name, '');
                }
            }
        </script>

    </telerik:RadScriptBlock>
    <telerik:RadMultiPage ID="RMP_InterviewAssesment" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RPV_InterviewAssesmentHeader" runat="server">
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_HeaderText" runat="server" Font-Bold="True" Font-Underline="true"
                            Text="Assesment Form"></asp:Label>
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
                                <td align="right">
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" AutoPostBack="true" MarkFirstMatch="true" Filter="Contains"
                                        Enabled="false" MaxHeight="120px" Skin="WebBlue" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BU" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        InitialValue="Select" ErrorMessage="Please select Business Unit" meta:resourcekey="rfv_BU"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Interviewname" runat="server" Text="Interviewer Name"></asp:Label>
                                </td>
                                <td align="right">
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Interviewername" runat="server" AutoPostBack="true" Filter="Contains"
                                        Enabled="false" Skin="WebBlue" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Interviewername_SelectedIndexChanged"
                                        MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_Interviewer" runat="server" ControlToValidate="rcmb_Interviewername"
                                        ErrorMessage="Please Select Interviewer Name" meta:resourcekey="rfv_Interviewer"
                                        InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobReq" runat="server" Text="Resource Requisition"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_JobReq" runat="server" AutoPostBack="true" MarkFirstMatch="true"
                                        MaxHeight="120px" OnSelectedIndexChanged="Rcb_JobReq_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rcb_JobReq" runat="server" ControlToValidate="Rcb_JobReq"
                                        ErrorMessage="Pelase Select Resource Requisition" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ApplicantID" runat="server" Text="Select Applicant"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_ApplicantID" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        MaxHeight="120px" OnSelectedIndexChanged="Rcb_ApplicantID_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rcb_ApplicantID" runat="server" ControlToValidate="Rcb_ApplicantID"
                                        ValidationGroup="Controls" ErrorMessage="Please Select Applicant" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PhaseID" runat="server" Text="Phase"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcb_PhaseID" runat="server" MaxHeight="120px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Rcb_PhaseID" runat="server" ControlToValidate="Rcb_PhaseID"
                                        ErrorMessage="Please Select Phase" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;
                                </td>
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
                                    <asp:Button ID="btn_Next" runat="server" Text="Next" ValidationGroup="Controls" OnClick="btn_Next_Click" />
                                    <asp:Button ID="btn_Clear" runat="server" Text="Cancel" OnClick="btn_Clear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="VS_InterviewAssesmentHeader" runat="server" ShowMessageBox="true"
                                        ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RPV_Fesher" runat="server">
            <br />
            <br />
            <%-- <asp:UpdatePanel ID="updApplicant" runat="server">
                            <ContentTemplate>--%>
            <table style="width: 100%;" align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbl_Header" runat="server" Text="Applicant Details">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <telerik:RadTabStrip ID="RTS_Fresher" runat="server" Skin="WebBlue" MultiPageID="RMP_Fresher_1"
                            SelectedIndex="6" Align="Center">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Contact Details" PageViewID="ContactDetials"
                                    Value="0" Selected="true">
                                </telerik:RadTab>
                                <%-- <telerik:RadTab runat="server" Text="General Information" PageViewID="GeneralInformation"
                                    Value="1">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="General Information" PageViewID="GeneralInformationExp"
                                    Value="2">
                                </telerik:RadTab>--%>
                                <telerik:RadTab runat="server" Text="General Assessment" PageViewID="GeneralAssessment"
                                    Value="1">
                                </telerik:RadTab>
                                <%--<telerik:RadTab runat="server" Text="Factors" PageViewID="Factors" Value="4">
                                </telerik:RadTab>--%>
                                <telerik:RadTab runat="server" Text="Skills" PageViewID="FactorsExp" Value="2">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Attributes" PageViewID="SkillsAttributes"
                                    Value="3">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Final Comments" PageViewID="FinalComments" Value="4">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                        <telerik:RadMultiPage ID="RMP_Fresher_1" runat="server" Width="100%" SelectedIndex="6"
                            ScrollBars="Auto">
                            <telerik:RadPageView ID="ContactDetials" runat="server" Selected="true">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_FullName" runat="server" Text="Full Name" Font-Bold="true"></asp:Label>
                                            <asp:Label ID="lbl_Skill" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_FullName_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ContactNumber" runat="server" Text="Contact Number" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ContactNumber_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Email" runat="server" Text="Email Address" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Email_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_DOI" runat="server" Text="Date Of Interview" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_DOI_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Position" runat="server" Text="Position Title" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Position_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lbl_RefBy" runat="server" Text="Referred By" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_RefBy_Value" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnk_ViewResume" Font-Size="10pt" runat="server">Click Here to Download the Resume</asp:LinkButton>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="7">
                                            <asp:LinkButton ID="lnk_ViewJobReqDetails" runat="server" OnCommand="lnk_ViewJobReqDetails_command"
                                                Text="View Resource Requisition Details"></asp:LinkButton>
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="lnk_ViewJobReqApplicantDetails" runat="server" OnCommand="lnk_ViewJobReqApplicantDetails_command"
                                                Text="View Applicant Details"></asp:LinkButton>
                                            &nbsp;&nbsp;
                                             <asp:LinkButton ID="lnk_Vprf" runat="server" OnCommand="lnk_ViewintAsmt_command"
                                                 Text="View Previous Rounds FeedBack"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" align="center">
                                            <asp:Button ID="btn_SaveFresher" runat="server" Text="Shortlisted" ValidationGroup="Fresher"
                                                OnClick="btn_SaveFresher_Click" OnClientClick="disableButon(this,'Fresher')" UseSubmitBehavior="false" />
                                            <asp:Button ID="btn_Rejected" runat="server" Text="Rejected" ValidationGroup="Fresher"
                                                OnClick="btn_Rejected_Click" />
                                            <asp:Button ID="btn_HrSubmit" runat="server" Text="Shortlisted" Visible="false" ValidationGroup="Fresher"
                                                OnClick="btn_HrSubmit_Click" />
                                            <asp:Button ID="btn_HrRejected" runat="server" Text="Rejected" Visible="false" ValidationGroup="Fresher"
                                                OnClick="btn_HrRejected_Click" />
                                            <asp:Button ID="btn_CancelFresher" runat="server" Text="Cancel" OnClick="btn_CancelFresher_Click" />
                                            <asp:ValidationSummary ID="vs_Summary" runat="server" ShowMessageBox="true" ShowSummary="false"
                                                ValidationGroup="Fresher" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <%--<telerik:RadPageView ID="GeneralInformation" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Qualification" runat="server" Text="Qualification"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Qualification_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_TechSkills" runat="server" Text="Technical Skills"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_TechSkills_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_PayExpectation" runat="server" Text="Pay Expectation"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_PayExpectation" runat="server">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Availability" runat="server" Text="Availability(days)"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_Availability" runat="server" DataType="System.Single"
                                                MaxLength="3" MinValue="0">
                                                <NumberFormat DecimalDigits="0" KeepTrailingZerosOnFocus="True" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rntxt_Availability" runat="server" ControlToValidate="rntxt_Availability"
                                                ErrorMessage="Please Enter Availability" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ReadyOnsite" runat="server" Text="Ready to be Onsite"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_ReadyOnsite" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                    <telerik:RadComboBoxItem Text="No" Value="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rcmb_ReadyOnsite" runat="server" ControlToValidate="rcmb_ReadyOnsite"
                                                ErrorMessage="Please Select Ready to be Onsite" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Relocation" runat="server" Text="Re-location(If required)"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Relocation" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                    <telerik:RadComboBoxItem Text="No" Value="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rcmb_Relocation" runat="server" ControlToValidate="rcmb_Relocation"
                                                ErrorMessage="Please Select Re-location(If required)" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="GeneralInformationExp" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTotExp" runat="server" Text="Total Experience"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotExpValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_RelExp" runat="server" Text="Relevant Experience"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_RelExp" runat="server" MinValue="0" MaxValue="70">
                                                <NumberFormat DecimalDigits="2" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rntxt_RelExp" runat="server" ControlToValidate="rntxt_RelExp"
                                                ErrorMessage="Please Enter Relevant Experience" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCurrCTC" runat="server" Text="Current CTC"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_CurrCTC_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ExpectedCTC_GenInfo" runat="server" Text="Expected CTC"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_ExpectedCTC_GenInfo" runat="server">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rntxt_ExpectedCTC_GenInfo" runat="server" ControlToValidate="rntxt_ExpectedCTC_GenInfo"
                                                ErrorMessage="Please Enter Expected CTC" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_TechSkills_Exp" runat="server" Text="Technical Skills"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_TechSkillsExp_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_RelPeriod" runat="server" Text="Relieving Period"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_RelPeriod" runat="server" DataType="System.Single"
                                                MaxLength="3" MinValue="0">
                                                <NumberFormat DecimalDigits="0" KeepTrailingZerosOnFocus="True" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rntxt_RelPeriod" runat="server" ControlToValidate="rntxt_RelPeriod"
                                                ErrorMessage="Please Enter Relieving Period" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ReasonforChange" runat="server" Text="Reason for Change"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ReasonforChange_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ReadyOnsite_Exp" runat="server" Text="Ready to be Onsite"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_ReadyOnsite_Exp" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                    <telerik:RadComboBoxItem Text="No" Value="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rcmb_ReadyOnsite_Exp" runat="server" ControlToValidate="rcmb_ReadyOnsite_Exp"
                                                ErrorMessage="Please Select Ready to be Onsite" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ValidPassport" runat="server" Text="Valid Passport"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_ValidPassport" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem Text="Yes" Value="Yes" />
                                                    <telerik:RadComboBoxItem Text="No" Value="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RFV_rcmb_ValidPassport" runat="server" ControlToValidate="rcmb_ValidPassport"
                                                    ErrorMessage="Please Select Valid Passport" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                            </td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>--%>
                            <telerik:RadPageView ID="GeneralAssessment" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rg_GeneralAssessment" runat="server" GridLines="None" AutoGenerateColumns="false"
                                                Skin="WebBlue" Width="700px">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                            HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC"
                                                            HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating(0-10)" HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="rnt_Value" runat="server" AutoPostBack="true" Width="60px"
                                                                    SkinID="1" Skin="WebBlue" MinValue="0" MaxValue="10">
                                                                    <NumberFormat DecimalDigits="2" />
                                                                </telerik:RadNumericTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <GroupingSettings CaseSensitive="false" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <%--<telerik:RadPageView ID="Factors" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rg_Factors" runat="server" GridLines="NonFshorte" AutoGenerateColumns="false"
                                                Skin="WebBlue" Width="700px">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                            HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC"
                                                            HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating">
                                                            <ItemTemplate>
                                                                <telerik:RadComboBox ID="rcmb_rating" runat="server" Width="40px" SkinID="1" Skin="WebBlue">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <telerik:RadTextBox ID="rtxt_remarks" runat="server" TextMode="MultiLine" MaxLength="400">
                                                                </telerik:RadTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <GroupingSettings CaseSensitive="false" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_Addcomments" runat="server" Text="Additional Comments" Font-Bold="true"
                                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_comments" runat="server" MaxLength="400" TextMode="MultiLine"
                                                SkinID="1" Width="400px" Height="90px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>--%>
                            <telerik:RadPageView ID="FactorsExp" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td align="center">
                                            <telerik:RadGrid ID="rg_FactorsExp" runat="server" GridLines="None" AutoGenerateColumns="false"
                                                Skin="WebBlue" AllowFilteringByColumn="false" Width="550px">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="SKILLCAT_ID" UniqueName="SKILLCAT_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="SKILLCAT_SKILLID" UniqueName="SKILLCAT_SKILLID"
                                                            Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="SKILLCAT_NAME" UniqueName="SKILLCAT_NAME" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="SKILLCAT_DESCRIPTION" UniqueName="SKILLCAT_DESCRIPTION"
                                                            HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating" HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <telerik:RadComboBox ID="rcmb_rating" runat="server" Width="60px" SkinID="1" Skin="WebBlue">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                                                                        <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                                                                    </Items>
                                                                </telerik:RadComboBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Remarks" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <telerik:RadTextBox ID="rtxt_remarks_Exp" SkinID="1" runat="server" TextMode="MultiLine"
                                                                    MaxLength="200" Width="180px">
                                                                </telerik:RadTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <GroupingSettings CaseSensitive="false" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="SkillsAttributes" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rg_SkillAttributes" runat="server" GridLines="None" AutoGenerateColumns="false"
                                                Skin="WebBlue" Width="700px">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_ID" UniqueName="ASSESSMENT_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_NAME" UniqueName="ASSESSMENT_NAME"
                                                            HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSESSMENT_DESC" UniqueName="ASSESSMENT_DESC"
                                                            HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Remarks" HeaderStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <telerik:RadTextBox ID="rtxt_remarks_Exp_Skill" runat="server" TextMode="MultiLine"
                                                                    MaxLength="400">
                                                                </telerik:RadTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <GroupingSettings CaseSensitive="false" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_AddComments_Exp" runat="server" Text="Additional Comments" Font-Bold="true"
                                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_comments_Exp" runat="server" MaxLength="400" SkinID="1"
                                                TextMode="MultiLine" Width="400px" Height="90px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="FinalComments" runat="server">
                                <br />
                                <table>
                                    <%--<tr>
                                        <td colspan="7">
                                            <asp:Label ID="lbl_finalHRComments" runat="server" Text="Final Round Comments" Font-Bold="true"
                                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_finalHRComments" runat="server" Text="Final Comments"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_finalHRComments" runat="server" MaxLength="400" Rows="3"
                                                TextMode="MultiLine" Width="622px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rtxt_finalHRComments" runat="server" ControlToValidate="rtxt_finalHRComments" Enabled="false"
                                                ErrorMessage="Please Enter Final Comments" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <%-- The below tags are for the HR Round  --%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_OverallAssessment" runat="server" Text="Overall Assessment"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td colspan="1">
                                            <telerik:RadComboBox ID="Rcb_OverallAssessment" runat="server" MarkFirstMatch="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="Select" Text="Select" />
                                                    <telerik:RadComboBoxItem Value="Excellent" Text="Excellent" />
                                                    <telerik:RadComboBoxItem Value="Very Good" Text="Very Good" />
                                                    <telerik:RadComboBoxItem Value="Average" Text="Average" />
                                                    <telerik:RadComboBoxItem Value="Below Average" Text="Below Average" />
                                                    <telerik:RadComboBoxItem Value="Poor" Text="Poor" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Rcb_OverallAssessment" runat="server" ControlToValidate="Rcb_OverallAssessment"
                                                ErrorMessage="Please Select Overall Assessment" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td colspan="1">
                                            <telerik:RadComboBox ID="rcmb_Status" runat="server" MarkFirstMatch="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="Select" Text="Select" />
                                                    <telerik:RadComboBoxItem Value="Selected" Text="Selected" />
                                                    <telerik:RadComboBoxItem Value="Short listed but on Hold" Text="Short listed but on Hold" />
                                                    <telerik:RadComboBoxItem Value="Rejected" Text="Rejected" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rcmb_Status" runat="server" ControlToValidate="rcmb_Status"
                                                ErrorMessage="Please Select Status" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_JoiningdateConfirmed" runat="server" Text="Joining Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="Rdp_JoiningdateConfirmed" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <%--<asp:RequiredFieldValidator ID="RFV_Rdp_JoiningdateConfirmed" runat="server" ControlToValidate="Rdp_JoiningdateConfirmed"
                                                ErrorMessage="Please Enter Joining Date" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>

                                    <tr id="tr_Recommendation" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_Recommendation" runat="server" Text="Recommendation"></asp:Label>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td colspan="5">
                                            <telerik:RadComboBox ID="Rcb_Recommendation" runat="server" MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <%--<tr id="Tr1" runat="server">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="5">
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>&nbsp;
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td colspan="7">
                                            <asp:Label ID="lbl_FinalCompensationDetails" runat="server" Text="Final Compensation Details"
                                                Font-Bold="true" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lbl_IfSelected" runat="server" Text="(if Selected and Offered) "></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lbl_PrevSal" runat="server" Text="Previous Salary"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_PrevSal_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_ExpectedCTC" runat="server" Text="Expected CTC"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ExpectedCTC_Value" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_JoiningBonus" runat="server" Text="Joining Bonus (if any)"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_JoiningBonus" runat="server" MaxLength="8" MinValue="0">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Businessunit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit_final" runat="server" AutoPostBack="True"
                                                MaxHeight="120px" Width="200px" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BusinessUnit_final_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_rcmb_BusinessUnit_final" runat="server" ControlToValidate="rcmb_BusinessUnit_final"
                                                ErrorMessage="Please Select Business Unit" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Level" runat="server" Text="Level"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Level" runat="server" Width="200px" MarkFirstMatch="true"
                                                MaxHeight="120px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="Rfv_rcmb_Level" runat="server" ControlToValidate="rcmb_Level"
                                                ErrorMessage="Please Select Level" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" Width="200px" MarkFirstMatch="true"
                                                MaxHeight="120px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="Rfv_rcmb_Department" runat="server" ControlToValidate="rcmb_Department"
                                                ErrorMessage="Please Select Department" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_DesignationOffered0" runat="server" Text="Designation"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Designation" runat="server" Width="200px" MarkFirstMatch="true"
                                                MaxHeight="120px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="Rfv_rcmb_Designation" runat="server" ControlToValidate="rcmb_Designation"
                                                ErrorMessage="Please Select Designation" InitialValue="Select" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_OfferedCTC" runat="server" Text="Offered CTC"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="Rnt_Offeredctc" runat="server">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="Rfv_Rnt_Offeredctc" runat="server" ControlToValidate="Rnt_Offeredctc"
                                                ErrorMessage="Please Enter OfferedCTC" ValidationGroup="Fresher">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr id="tr_OfferedSalary" runat="server">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_OfferedSalary" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
            <%--</ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Update" />
                                <asp:PostBackTrigger ControlID="btn_Save" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>