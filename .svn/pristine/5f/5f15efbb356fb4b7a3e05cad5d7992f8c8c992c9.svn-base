using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using RECRUITMENT;
using SMHR;
using System.IO;
using System.Net.Mail;
using SPMS;
using System.Configuration;

public partial class Recruitment_frm_InterviewAssesmentnew : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm;
    RECRUITMENT_INTERVIEW_PHASE_REMARKS _obj_Rec_InterviewPhaseRemarks;
    SMHR_MASTERS _obj_Smhr_Masters;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMPLOYEE _obj_smhr_employee;

    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_POSITIONS _obj_smhr_Position;
    StringBuilder StrAppend;
    RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def;
    RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList;
    RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade;
    RECRUITMENT_IAF_RATING _obj_IAF_Rating;
    RECRUITMENT_IAF_GENERALINFO _obj_IAF_GeneralInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    SMHR_APPLICANT _obj_smhr_applicant;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {


                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Assessment Form");
                DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
                if (dtformdtls.Rows.Count != 0)
                {
                    if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                    {
                        Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                    }
                    else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    {
                        Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
                    }

                }
                else
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }


                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    rg_FactorsExp.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_SaveFresher.Visible = false;
                    // btn_Update.Visible = false;
                }
                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
                Page.Validate();
                LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadJobRequest()
    {
        try
        {
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);
            _obj_Rec_JobRequisition.MODE = 11;
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            Rcb_JobReq.DataSource = dtJR;
            //Session["CTC"] = dtJR.Rows[0]["JOBREQ_APPCTC"]; 
            int a = Convert.ToInt32(Session["CTC"]);
            Rcb_JobReq.DataTextField = "JOBREQ_REQCODE";
            Rcb_JobReq.DataValueField = "JOBREQ_ID";
            Rcb_JobReq.DataBind();
            Rcb_JobReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadApplicantPhase()
    {
        try
        {
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            Rcb_PhaseID.Items.Clear();
            _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Mode = 7;
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Applicant = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DTApplicant = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            if (DTApplicant.Rows.Count == 0)
            {
                Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                Recruitment_BLL.ShowMessage(this, "Selected Applicant is not Eligible for this Round.");
                return;
            }
            else
            {
                Rcb_PhaseID.DataSource = DTApplicant;
                Rcb_PhaseID.DataValueField = "PHASE_ID";
                Rcb_PhaseID.DataTextField = "PHASE_NAME";
                Rcb_PhaseID.DataBind();
            }
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            rcmb_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            {
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                SMHR_EMPASSETDOC _obj_smhr_empassetdoc = new SMHR_EMPASSETDOC();
                _obj_smhr_empassetdoc.EMPASSETDOC_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_empassetdoc.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_EmpAssetDocBU(_obj_smhr_empassetdoc);
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0][0]));
                //rcmb_BusinessUnit.SelectedValue = Convert.ToString(dt_Details.Rows[0][0]);
                LoadInterviewName();
                rcmb_Interviewername.SelectedIndex = rcmb_Interviewername.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                if (rcmb_Interviewername.SelectedIndex > 0)
                {
                    LoadJobRequest();
                }
            }
            else
            {
                BLL.ShowMessage(this, "You Can Not Access This Screen.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                LoadInterviewName();
            }
            else
            {
                Rcb_JobReq.ClearSelection();
                Rcb_JobReq.Items.Clear();
                Rcb_JobReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadInterviewName()
    {
        try
        {
            rcmb_Interviewername.Items.Clear();
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.SELECTEMPLOYEE;
            _obj_smhr_employee.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = Recruitment_BLL.get_Employee(_obj_smhr_employee);
            if (dt_Details.Rows.Count != 0)
            {
                rcmb_Interviewername.DataSource = dt_Details;
                rcmb_Interviewername.DataTextField = "EMPNAME";
                rcmb_Interviewername.DataValueField = "EMP_ID";
                rcmb_Interviewername.DataBind();
                rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Interviewername_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Interviewername.SelectedIndex > 0)
            {
                LoadJobRequest();
            }
            else
            {
                rcmb_Interviewername.ClearSelection();
                rcmb_Interviewername.Items.Clear();
                rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Next_Click(object sender, EventArgs e)
    {
        try
        {
            //TO CHECK WHETHER ASSESSMENTS/SKILL CATEGORY DEFINED OR NOT, 29.11.2013
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.MODE = 16;
            DataTable dt_assesment = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            if (dt_assesment.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt_assesment.Rows[0]["COUNT"]) == 0)
                {
                    BLL.ShowMessage(this, "Please Define Assessment Masters/Skill Category To Proceed Further.");
                    return;
                }
            }
            //else
            //{
            //    if (Convert.ToInt32(dt_assesment.Rows[0]["COUNT"]) == 0)
            //    {
            //        BLL.ShowMessage(this, "Please Define Assessment Masters/Skill Category To Proceed Further.");
            //        return;
            //    }
            //}
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_JobRequisition.OPERATION = operation.Select;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            if (dt.Rows.Count > 0)
            {
                //if (Convert.ToString(dt.Rows[0]["JOBREQ_RECRUITMENTFOR"]) == "Fresher")
                //{
                //    RMP_InterviewAssesment.SelectedIndex = 1;
                //    RMP_Fresher_1.SelectedIndex = 0;
                //    LoadFresherDetails();
                //    //LoadExperienceDetails();
                //    //ENABLING AND DISABLING THE TABS AND REQUIRED FIELD VALIDATIORS
                //    RTS_Fresher.Tabs.FindTabByValue("2", true).Visible = false;
                //    RTS_Fresher.Tabs.FindTabByValue("5", true).Visible = false;
                //    RTS_Fresher.Tabs.FindTabByValue("6", true).Visible = false;
                //    ViewState["RECRUITMENTFOR"] = "Fresher";
                //    RFV_rntxt_Availability.Enabled = true;
                //    RFV_rntxt_RelPeriod.Enabled = false;
                //    RFV_rcmb_ValidPassport.Enabled = false;
                //    RFV_rcmb_ReadyOnsite_Exp.Enabled=false;
                //    RFV_rcmb_ReadyOnsite.Enabled=true;
                //    RFV_rcmb_Relocation.Enabled = true;
                //    RFV_rntxt_RelExp.Enabled = false;
                //    RFV_rntxt_ExpectedCTC_GenInfo.Enabled = false;
                //}
                //else
                //{
                RMP_InterviewAssesment.SelectedIndex = 1;
                RMP_Fresher_1.SelectedIndex = 0;
                LoadExperienceDetails();
                //ENABLING AND DISABLING THE TABS AND REQUIRED FIELD VALIDATIORS
                //RTS_Fresher.Tabs.FindTabByValue("1", true).Visible = false;
                //RTS_Fresher.Tabs.FindTabByValue("4", true).Visible = false;
                ViewState["RECRUITMENTFOR"] = "Exp";
                //RFV_rntxt_Availability.Enabled = false;
                //RFV_rntxt_RelPeriod.Enabled = true;
                //RFV_rcmb_ValidPassport.Enabled = true;
                //RFV_rcmb_ReadyOnsite_Exp.Enabled = true;
                //RFV_rcmb_ReadyOnsite.Enabled=false;
                //RFV_rcmb_Relocation.Enabled = false;
                //RFV_rntxt_RelExp.Enabled = true;
                //RFV_rntxt_ExpectedCTC_GenInfo.Enabled = true;
                //}

                lbl_DOI_Value.Text = Convert.ToString(DateTime.Now);
                lbl_Position_Value.Text = Convert.ToString(dt.Rows[0]["POSITIONS_CODE"]);
                _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
                _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
                _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_Rec_Interview_Phase_Def.Mode = 4;

                DataTable dtDetails = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
                if (dtDetails.Rows.Count != 0)
                {
                    if (dtDetails.Rows[0]["PHASE_FINAL"].ToString().ToUpper() == "TRUE")
                    {
                        ViewState["PHASE_FINAL"] = 1;
                        btn_HrSubmit.Visible = true;
                        btn_HrRejected.Visible = true;
                        btn_HrSubmit.Enabled = true;
                        btn_HrRejected.Enabled = true;
                        btn_Rejected.Visible = false;
                        btn_SaveFresher.Visible = false;
                        RTS_Fresher.Tabs.FindTabByValue("4", true).Visible = true;
                        //ENABLING REQUIRED FIELD VALIDATORS FOR FINAL ROUND
                        RFV_Rcb_OverallAssessment.Enabled = true;
                        RFV_rcmb_Status.Enabled = true;
                        //RFV_Rdp_JoiningdateConfirmed.Enabled = true;
                        RFV_rtxt_finalHRComments.Enabled = true;
                        //Rfv_rcmb_Department.Enabled = true;
                        //Rfv_rcmb_Designation.Enabled = true;
                        //RFV_rcmb_BusinessUnit_final.Enabled = true;
                        //Rfv_rcmb_Level.Enabled = true;
                        //Rfv_Rnt_Offeredctc.Enabled = true;
                        //LoadCombos();
                    }
                    else
                    {

                        ViewState["PHASE_FINAL"] = 0;
                        btn_HrSubmit.Visible = false;
                        btn_HrRejected.Visible = false;
                        btn_Rejected.Visible = true;
                        btn_SaveFresher.Visible = true;
                        btn_Rejected.Enabled = true;
                        btn_SaveFresher.Enabled = true;
                        RTS_Fresher.Tabs.FindTabByValue("4", true).Visible = false;
                        //DISABLING REQUIRED FIELD VALIDATORS FOR FINAL ROUND
                        RFV_Rcb_OverallAssessment.Enabled = false;
                        RFV_rcmb_Status.Enabled = false;
                        //RFV_Rdp_JoiningdateConfirmed.Enabled = false;
                        RFV_rtxt_finalHRComments.Enabled = false;
                        //Rfv_rcmb_Department.Enabled = false;
                        //Rfv_rcmb_Designation.Enabled = false;
                        //RFV_rcmb_BusinessUnit_final.Enabled = false;
                        //Rfv_rcmb_Level.Enabled = false;
                        //Rfv_Rnt_Offeredctc.Enabled = false;
                    }
                    if (Convert.ToString(dtDetails.Rows[0]["PHASE_PRIORITY"]) != "1")
                    {
                        ViewState["PRIORITY"] = 1;
                        lnk_Vprf.Visible = true;

                    }
                    else
                    {
                        ViewState["PRIORITY"] = 0;
                        lnk_Vprf.Visible = false;
                        //rntxt_PayExpectation.Enabled = true;
                        //rntxt_ExpectedCTC_GenInfo.Enabled = true;
                        //rntxt_Availability.Enabled = true;
                        //rntxt_RelPeriod.Enabled = true;
                        //rcmb_ReadyOnsite.Enabled = true;
                        //rcmb_ReadyOnsite_Exp.Enabled = true;
                        //rcmb_Relocation.Enabled = true;
                        //rntxt_RelExp.Enabled = true;
                        //rcmb_ValidPassport.Enabled = true;
                        //lbl_ExpectedCTC_Value.Text = string.Empty;
                    }
                }
                LoadApplicantDetails();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    //private void LoadCombos()
    //{
    //    //Business Unit
    //    _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //    _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //    rcmb_BusinessUnit_final.Items.Clear();
    //    rcmb_BusinessUnit_final.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //    rcmb_BusinessUnit_final.DataTextField = "BUSINESSUNIT_CODE";
    //    rcmb_BusinessUnit_final.DataValueField = "BUSINESSUNIT_ID";
    //    rcmb_BusinessUnit_final.DataBind();
    //    rcmb_BusinessUnit_final.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

    //    //Grade
    //    rcmb_Level.Items.Clear();
    //    _obj_Smhr_Masters = new SMHR_MASTERS();
    //    _obj_Smhr_Masters.MASTER_TYPE = "GRADE";
    //    _obj_Smhr_Masters.OPERATION = operation.Select;
    //    _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    rcmb_Level.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //    rcmb_Level.DataTextField = "HR_MASTER_CODE";
    //    rcmb_Level.DataValueField = "HR_MASTER_ID";
    //    rcmb_Level.DataBind();
    //    rcmb_Level.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //}
    protected void Rcb_JobReq_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Session["CTC"] = null;
            DataTable dtJR = new DataTable();
            if (Rcb_JobReq.SelectedIndex > 0)
            {
                _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
                _obj_Rec_JobRequisition.MODE = 13;
                _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedValue);
                dtJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                if (dtJR.Rows.Count > 0)
                {
                    Session["CTC"] = dtJR.Rows[0]["JOBREQ_APPCTC"];
                }
                Applicants(Convert.ToInt32(dtJR.Rows[0]["PHASE_PRIORITY"]));
            }
            else
            {
                Rcb_ApplicantID.ClearSelection();
                Rcb_ApplicantID.Items.Clear();
                Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            Rcb_PhaseID.ClearSelection();
            Rcb_PhaseID.Items.Clear();
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void Applicants(int Priority)
    {
        try
        {
            Rcb_ApplicantID.Items.Clear();
            _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();
            _obj_Rec_ResumeShortList.Mode = 9;
            _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_ResumeShortList.RESSHT_ID = Priority;
            _obj_Rec_ResumeShortList.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rcb_ApplicantID.DataSource = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
            Rcb_ApplicantID.DataValueField = "APPLICANT_ID";
            Rcb_ApplicantID.DataTextField = "APPLICANTNAME";
            Rcb_ApplicantID.DataBind();
            Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rcb_ApplicantID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Rcb_ApplicantID.SelectedIndex > 0)
            {
                LoadApplicantPhase();
            }
            else
            {
                Rcb_PhaseID.ClearSelection();
                Rcb_PhaseID.Items.Clear();
                Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //private void LoadFresherDetails()
    //{
    //    //TO LOAD General Assessment GRID
    //    _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
    //    _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_Rec_InterviewAssessmentForm.ASSESSMENT_TYPE="General Assessment";
    //    _obj_Rec_InterviewAssessmentForm.ASSESSMENT_APPLICABLEFOR = "Experience";
    //    _obj_Rec_InterviewAssessmentForm.MODE = 9;
    //    DataTable dt = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
    //    rg_GeneralAssessment.DataSource = dt;
    //    rg_GeneralAssessment.DataBind();
    //    _obj_Rec_InterviewAssessmentForm.ASSESSMENT_TYPE = "Factors";
    //    rg_Factors.DataSource = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
    //    rg_Factors.DataBind();
    //}
    private void LoadExperienceDetails()
    {
        try
        {
            //TO LOAD General Assessment GRID
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.ASSESSMENT_TYPE = "General Assessment";
            _obj_Rec_InterviewAssessmentForm.ASSESSMENT_APPLICABLEFOR = "Fresher";
            _obj_Rec_InterviewAssessmentForm.MODE = 9;
            DataTable dt = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            rg_GeneralAssessment.DataSource = dt;
            rg_GeneralAssessment.DataBind();
            _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.MODE = 11;
            rg_FactorsExp.DataSource = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            rg_FactorsExp.DataBind();

            _obj_Rec_InterviewAssessmentForm.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.ASSESSMENT_TYPE = "Skills/Attributes";
            _obj_Rec_InterviewAssessmentForm.MODE = 9;
            rg_SkillAttributes.DataSource = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            rg_SkillAttributes.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadApplicantDetails()
    {
        try
        {
            DataTable DtApplicantDetails = new DataTable();
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.MODE = 6;
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);

            DtApplicantDetails = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);

            _obj_smhr_applicant = new SMHR_APPLICANT();
            _obj_smhr_applicant.OPERATION = operation.Select;
            _obj_smhr_applicant.APPLICANT_ID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_smhr_applicant.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DtApplicantDetails = BLL.get_Applicant(_obj_smhr_applicant);
            if (DtApplicantDetails.Rows.Count > 0)
            {
                lbl_FullName_Value.Text = Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_FIRSTNAME"]) + " " +
                                             Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_MIDDLENAME"]) + " " +
                                            Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_LASTNAME"]);
                lbl_Email_Value.Text = Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_EMAIL"]);

                lbl_ContactNumber_Value.Text = Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_MOBILE"]);
                if (DtApplicantDetails.Rows[0]["APPLICANT_RESUME"] != System.DBNull.Value && Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_RESUME"]) != "")
                {
                    if (File.Exists(Server.MapPath(Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_RESUME"]))))
                    {
                        lnk_ViewResume.Visible = true;
                        lnk_ViewResume.OnClientClick = "javascript:window.open('../" + Convert.ToString(DtApplicantDetails.Rows[0]["APPLICANT_RESUME"]).TrimStart('~', '/') + "');return false;";
                        ViewState["fileLocation"] = DtApplicantDetails.Rows[0]["APPLICANT_RESUME"];
                    }
                }
                else
                {
                    lnk_ViewResume.Visible = false;
                }
                //lbl_OfferedSalary.Text = "CTC Offered : " + Convert.ToInt32(Session["CTC"]);
            }
            else
            {
                lbl_FullName_Value.Text = string.Empty;
                //rntxt_ContactNumber.Value = 0;
                lbl_ContactNumber_Value.Text = string.Empty;
                lbl_Position_Value.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_SaveFresher_Click(object sender, EventArgs e)
    {
        try
        {
            bool Check1 = false;
            bool Check2 = false;
            bool Check3 = false;

            RadNumericTextBox rnt_rtng1 = new RadNumericTextBox();
            for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
            {
                rnt_rtng1 = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                if (rnt_rtng1.Text != string.Empty)
                    Check1 = true;
            }
            RadComboBox rcmb_rtng_exp1 = new RadComboBox();
            for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
            {
                rcmb_rtng_exp1 = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                if (rcmb_rtng_exp1.SelectedIndex > 0)
                    Check2 = true;
            }
            RadTextBox rtxt_remarks_exp1 = new RadTextBox();
            for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
            {
                rtxt_remarks_exp1 = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                if (rtxt_remarks_exp1.Text != string.Empty)
                    Check3 = true;
            }
            if (!(Check1 || Check2 || Check3))
            {
                BLL.ShowMessage(this, "Please Give Assessment Atleast For One Assessment Type.");
                return;
            }
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.MODE = 1;
            _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_comments_Exp.Text);
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 1;
            if (Recruitment_BLL.set_InterviewAssessmentnew(_obj_Rec_InterviewAssessmentForm))
            {
                DataTable DT = BLL.ExecuteQuery("SELECT MAX(IAF_ID) AS IAF_ID FROM SMHR_INTERVIEWASSESSMENTFORM");
                //if (Convert.ToString(ViewState["RECRUITMENTFOR"]) == "Fresher")
                //{
                //    if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //    {
                //        //TO SAVE GENERAL INFO
                //        _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_PayExpectation.Value);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_Availability.Text);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite.SelectedValue);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELOCATION = Convert.ToString(rcmb_Relocation.SelectedValue);
                //        _obj_IAF_GeneralInfo.MODE = 1;
                //        Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //    }
                //    //TO SAVE GENERAL ASSESSMENTS
                //    RadNumericTextBox rnt_rtng=new RadNumericTextBox();
                //    for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                //    {
                //        rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                //        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" + 
                //                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " + 
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        if (rnt_rtng.Text == string.Empty)
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        else
                //            _obj_IAF_Rating.IAF_RATING_RATING = 0;
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //    //TO SAVE FACTORS ASSESSMENTS
                //    RadComboBox rcmb_rtng = new RadComboBox();
                //    RadTextBox rtxt_remarks = new RadTextBox();
                //    for (int index = 0; index < rg_Factors.Items.Count; index++)
                //    {
                //        rcmb_rtng = rg_Factors.Items[index].FindControl("rcmb_rating") as RadComboBox;
                //        rtxt_remarks = rg_Factors.Items[index].FindControl("rtxt_remarks") as RadTextBox;
                //        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("Factors") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_Factors.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng.SelectedItem.Value);
                //        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks.Text);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //}
                //else
                //{
                //if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //{
                //    //TO SAVE GENERAL INFO
                //    _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_ExpectedCTC_GenInfo.Value);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_RelPeriod.Text);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite_Exp.SelectedValue);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_PASSPORT = Convert.ToString(rcmb_ValidPassport.SelectedValue);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELEXP = Convert.ToDecimal(rntxt_RelExp.Value);
                //    _obj_IAF_GeneralInfo.MODE = 1;
                //    Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //}
                //TO SAVE GENERAL ASSESSMENTS
                RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                {
                    rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                    if (rnt_rtng.Text != string.Empty)
                    {
                        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        if (rnt_rtng.Text != string.Empty)
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        else
                            _obj_IAF_Rating.IAF_RATING_RATING = 0;
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE FACTORS ASSESSMENTS
                RadComboBox rcmb_rtng_exp = new RadComboBox();
                RadTextBox rtxt_remarks_exp = new RadTextBox();
                for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
                {
                    rcmb_rtng_exp = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                    if (rcmb_rtng_exp.SelectedIndex > 0)
                    {
                        rtxt_remarks_exp = rg_FactorsExp.Items[index].FindControl("rtxt_remarks_Exp") as RadTextBox;
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skill Category") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_FactorsExp.Items[index]["SKILLCAT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng_exp.SelectedItem.Value);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE SKILLS/ATRIBUTES ASSESSMENTS
                for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
                {
                    rtxt_remarks_exp = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                    if (rtxt_remarks_exp.Text != string.Empty)
                    {
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skills/Attributes") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_SkillAttributes.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //}                
            }
            Recruitment_BLL.ShowMessage(this, "Interview Assessment Form Is Submitted Successfully");
            //TO UPDATE THE CURRENT STATUS OF JOB REQUISITION, 25-07-2013
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Insert1;
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "In Progress - Assessment";
            Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);

            //TO UPDATE THE CURRENT STATUS OF APPLICANT, 25-07-2013
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Insert2;
            _obj_Rec_JobRequisition.APPLICANT = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            //if (Convert.ToString(ViewState["PHASE_FINAL"]) == "1")
            //    _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "Request For Candidature Approval";
            //else if (Convert.ToString(ViewState["PHASE_ISDELIVERYMANAGER"]) == "1")
            //    _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "Candidature Confirmed";
            //else
            _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "InProgress";
            Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
            //sendMail("Shortlisted");
            RMP_InterviewAssesment.SelectedIndex = 0;
            ClearControls();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            Rcb_JobReq.SelectedIndex = 0;

            Rcb_PhaseID.ClearSelection();
            Rcb_PhaseID.Items.Clear();
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            Rcb_ApplicantID.ClearSelection();
            Rcb_ApplicantID.Items.Clear();
            Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            //General Inforamtion
            //rntxt_PayExpectation.Text = string.Empty;
            //rntxt_Availability.Text = string.Empty;
            //rcmb_ReadyOnsite.SelectedIndex = 0;
            //rcmb_Relocation.SelectedIndex = 0;
            ////General Inforamtion Experice
            //rntxt_RelExp.Text = string.Empty;
            //rntxt_ExpectedCTC_GenInfo.Text = string.Empty;
            //rntxt_RelPeriod.Text = string.Empty;
            //rcmb_ReadyOnsite_Exp.SelectedIndex = 0;
            //rcmb_ValidPassport.SelectedIndex = 0;
            ////Factors
            //rtxt_comments.Text = string.Empty;
            //skills/Attributes
            rtxt_comments_Exp.Text = string.Empty;
            //FinalComments
            rtxt_finalHRComments.Text = string.Empty;
            Rcb_OverallAssessment.SelectedIndex = 0;
            rcmb_Status.SelectedIndex = 0;
            Rdp_JoiningdateConfirmed.SelectedDate = null;
            //rntxt_JoiningBonus.Text = string.Empty;
            //rcmb_BusinessUnit_final.SelectedIndex = 0;
            //rcmb_Level.SelectedIndex = 0;
            //rcmb_Department.SelectedIndex = 0;
            //rcmb_Designation.SelectedIndex = 0;
            //Rnt_Offeredctc.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Rejected_Click(object sender, EventArgs e)
    {
        try
        {
            bool Check1 = false;
            bool Check2 = false;
            bool Check3 = false;

            RadNumericTextBox rnt_rtng1 = new RadNumericTextBox();
            for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
            {
                rnt_rtng1 = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                if (rnt_rtng1.Text != string.Empty)
                    Check1 = true;
            }
            RadComboBox rcmb_rtng_exp1 = new RadComboBox();
            for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
            {
                rcmb_rtng_exp1 = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                if (rcmb_rtng_exp1.SelectedIndex > 0)
                    Check2 = true;
            }
            RadTextBox rtxt_remarks_exp1 = new RadTextBox();
            for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
            {
                rtxt_remarks_exp1 = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                if (rtxt_remarks_exp1.Text != string.Empty)
                    Check3 = true;
            }
            if (!(Check1 || Check2 || Check3))
            {
                BLL.ShowMessage(this, "Please Give Assessment Atleast For One Assessment Type.");
                return;
            }
            btn_SaveFresher.Enabled = false;
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.MODE = 1;
            _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_comments_Exp.Text);
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 0;
            if (Recruitment_BLL.set_InterviewAssessmentnew(_obj_Rec_InterviewAssessmentForm))
            {
                DataTable DT = BLL.ExecuteQuery("SELECT MAX(IAF_ID) AS IAF_ID FROM SMHR_INTERVIEWASSESSMENTFORM");
                //if (Convert.ToString(ViewState["RECRUITMENTFOR"]) == "Fresher")
                //{
                //    if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //    {
                //        //TO SAVE GENERAL INFO
                //        _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_PayExpectation.Value);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_Availability.Text);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite.SelectedValue);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELOCATION = Convert.ToString(rcmb_Relocation.SelectedValue);
                //        _obj_IAF_GeneralInfo.MODE = 1;
                //        Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //    }
                //    //TO SAVE GENERAL ASSESSMENTS
                //    RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                //    for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                //    {
                //        rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                //        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        if (rnt_rtng.Text == string.Empty)
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        else
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //    //TO SAVE FACTORS ASSESSMENTS
                //    RadComboBox rcmb_rtng = new RadComboBox();
                //    RadTextBox rtxt_remarks = new RadTextBox();
                //    for (int index = 0; index < rg_Factors.Items.Count; index++)
                //    {
                //        rcmb_rtng = rg_Factors.Items[index].FindControl("rcmb_rating") as RadComboBox;
                //        rtxt_remarks = rg_Factors.Items[index].FindControl("rtxt_remarks") as RadTextBox;
                //        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("Factors") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_Factors.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng.SelectedItem.Value);
                //        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks.Text);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //}
                //else
                //{
                //if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //{
                //    //TO SAVE GENERAL INFO
                //    _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_ExpectedCTC_GenInfo.Value);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_RelPeriod.Text);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite_Exp.SelectedValue);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_PASSPORT = Convert.ToString(rcmb_ValidPassport.SelectedValue);
                //    _obj_IAF_GeneralInfo.MODE = 1;
                //    Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //}
                //TO SAVE GENERAL ASSESSMENTS
                RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                {
                    rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                    if (rnt_rtng.Text != string.Empty)
                    {
                        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        if (rnt_rtng.Text != string.Empty)
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        else
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE FACTORS ASSESSMENTS
                RadComboBox rcmb_rtng_exp = new RadComboBox();
                RadTextBox rtxt_remarks_exp = new RadTextBox();
                for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
                {
                    rcmb_rtng_exp = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                    if (rcmb_rtng_exp.SelectedIndex > 0)
                    {
                        rtxt_remarks_exp = rg_FactorsExp.Items[index].FindControl("rtxt_remarks_Exp") as RadTextBox;
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skill Category") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_FactorsExp.Items[index]["SKILLCAT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng_exp.SelectedItem.Value);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE SKILLS/ATRIBUTES ASSESSMENTS
                for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
                {
                    rtxt_remarks_exp = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                    if (rtxt_remarks_exp.Text != string.Empty)
                    {
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skills/Attributes") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_SkillAttributes.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //}
            }
            Recruitment_BLL.ShowMessage(this, "Interview Assessment Form Is Rejected Successfully");
            //TO UPDATE THE CURRENT STATUS OF JOB REQUISITION, 25-07-2013
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Insert1;
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "In Progress - Assessment";
            Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);

            //TO UPDATE THE CURRENT STATUS OF APPLICANT, 25-07-2013
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Insert2;
            _obj_Rec_JobRequisition.APPLICANT = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "Rejected";
            Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
            //sendMail("Rejected");
            RMP_InterviewAssesment.SelectedIndex = 0;
            ClearControls();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_HrSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Rdp_JoiningdateConfirmed.SelectedDate == null)
            {
                Recruitment_BLL.ShowMessage(this, "Please Enter Joining Date");
                return;
            }
            bool Check1 = false;
            bool Check2 = false;
            bool Check3 = false;

            RadNumericTextBox rnt_rtng1 = new RadNumericTextBox();
            for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
            {
                rnt_rtng1 = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                if (rnt_rtng1.Text != string.Empty)
                    Check1 = true;
            }
            RadComboBox rcmb_rtng_exp1 = new RadComboBox();
            for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
            {
                rcmb_rtng_exp1 = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                if (rcmb_rtng_exp1.SelectedIndex > 0)
                    Check2 = true;
            }
            RadTextBox rtxt_remarks_exp1 = new RadTextBox();
            for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
            {
                rtxt_remarks_exp1 = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                if (rtxt_remarks_exp1.Text != string.Empty)
                    Check3 = true;
            }
            if (!(Check1 || Check2 || Check3))
            {
                BLL.ShowMessage(this, "Please Give Assessment Atleast For One Assessment Type.");
                return;
            }
            btn_HrRejected.Enabled = false;
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.MODE = 1;
            _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_comments_Exp.Text);
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 1;
            if (Recruitment_BLL.set_InterviewAssessmentnew(_obj_Rec_InterviewAssessmentForm))
            {
                DataTable DT = BLL.ExecuteQuery("SELECT MAX(IAF_ID) AS IAF_ID FROM SMHR_INTERVIEWASSESSMENTFORM");
                //if (Convert.ToString(ViewState["RECRUITMENTFOR"]) == "Fresher")
                //{
                //    if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //    {
                //        //TO SAVE GENERAL INFO
                //        _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_PayExpectation.Value);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_Availability.Text);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite.SelectedValue);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELOCATION = Convert.ToString(rcmb_Relocation.SelectedValue);
                //        _obj_IAF_GeneralInfo.MODE = 1;
                //        Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //    }
                //    //TO SAVE GENERAL ASSESSMENTS
                //    RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                //    for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                //    {
                //        rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                //        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        if (rnt_rtng.Text == string.Empty)
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        else
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //    //TO SAVE FACTORS ASSESSMENTS
                //    RadComboBox rcmb_rtng = new RadComboBox();
                //    RadTextBox rtxt_remarks = new RadTextBox();
                //    for (int index = 0; index < rg_Factors.Items.Count; index++)
                //    {
                //        rcmb_rtng = rg_Factors.Items[index].FindControl("rcmb_rating") as RadComboBox;
                //        rtxt_remarks = rg_Factors.Items[index].FindControl("rtxt_remarks") as RadTextBox;
                //        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("Factors") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_Factors.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng.SelectedItem.Value);
                //        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks.Text);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //}
                //else
                //{
                //if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //{
                //    //TO SAVE GENERAL INFO
                //    _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_ExpectedCTC_GenInfo.Value);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_RelPeriod.Text);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite_Exp.SelectedValue);
                //    _obj_IAF_GeneralInfo.IAF_GENERALINFO_PASSPORT = Convert.ToString(rcmb_ValidPassport.SelectedValue);
                //    _obj_IAF_GeneralInfo.MODE = 1;
                //    Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //}
                //TO SAVE GENERAL ASSESSMENTS
                RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                {
                    rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                    if (rnt_rtng.Text != string.Empty)
                    {
                        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        if (rnt_rtng.Text != string.Empty)
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        else
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE FACTORS ASSESSMENTS
                RadComboBox rcmb_rtng_exp = new RadComboBox();
                RadTextBox rtxt_remarks_exp = new RadTextBox();
                for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
                {
                    rcmb_rtng_exp = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                    if (rcmb_rtng_exp.SelectedIndex > 0)
                    {
                        rtxt_remarks_exp = rg_FactorsExp.Items[index].FindControl("rtxt_remarks_Exp") as RadTextBox;
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skill Category") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_FactorsExp.Items[index]["SKILLCAT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng_exp.SelectedItem.Value);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE SKILLS/ATRIBUTES ASSESSMENTS
                for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
                {
                    rtxt_remarks_exp = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                    if (rtxt_remarks_exp.Text != string.Empty)
                    {
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skills/Attributes") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_SkillAttributes.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //}
            }
            //TO SAVE REMARKS FOR FINAL ROUND
            _obj_Rec_InterviewPhaseRemarks = new RECRUITMENT_INTERVIEW_PHASE_REMARKS();

            _obj_Rec_InterviewPhaseRemarks.MODE = 1;
            _obj_Rec_InterviewPhaseRemarks.INTREM_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_APPLICANTID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_PHASEID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_OVERALLASSESSMENT = Convert.ToString(Rcb_OverallAssessment.SelectedValue);
            _obj_Rec_InterviewPhaseRemarks.INTREM_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_OFFEREDSALARY = Convert.ToDecimal(Rnt_Offeredctc.Text);
            _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE = Convert.ToDateTime(Rdp_JoiningdateConfirmed.SelectedDate.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_DESIGNATIONOFFERED = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_LEVEL = Convert.ToInt32(rcmb_Level.SelectedItem.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_DEPARTMENT = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
            //if (rntxt_JoiningBonus.Text == string.Empty)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGBONUS = Convert.ToDecimal(rntxt_JoiningBonus.Value);
            //else
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGBONUS = Convert.ToDecimal(rntxt_JoiningBonus.Value);
            _obj_Rec_InterviewPhaseRemarks.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_DIVISION = Convert.ToString(Rtxt_Division.Text.Replace("'","''"));
            _obj_Rec_InterviewPhaseRemarks.INTREM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewPhaseRemarks.INTREM_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Recruitment_BLL.set_InterviewPhaseRemarks(_obj_Rec_InterviewPhaseRemarks);
            Recruitment_BLL.ShowMessage(this, "Interview Assessment Form Is Finalized Successfully");
            //sendMail("Shortlisted");
            RMP_InterviewAssesment.SelectedIndex = 0;
            ClearControls();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_HrRejected_Click(object sender, EventArgs e)
    {
        try
        {
            bool Check1 = false;
            bool Check2 = false;
            bool Check3 = false;

            RadNumericTextBox rnt_rtng1 = new RadNumericTextBox();
            for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
            {
                rnt_rtng1 = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                if (rnt_rtng1.Text != string.Empty)
                    Check1 = true;
            }
            RadComboBox rcmb_rtng_exp1 = new RadComboBox();
            for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
            {
                rcmb_rtng_exp1 = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                if (rcmb_rtng_exp1.SelectedIndex > 0)
                    Check2 = true;
            }
            RadTextBox rtxt_remarks_exp1 = new RadTextBox();
            for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
            {
                rtxt_remarks_exp1 = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                if (rtxt_remarks_exp1.Text != string.Empty)
                    Check3 = true;
            }
            if (!(Check1 || Check2 || Check3))
            {
                BLL.ShowMessage(this, "Please Give Assessment Atleast For One Assessment Type.");
                return;
            }
            btn_HrSubmit.Enabled = false;
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.MODE = 1;
            //_obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_comments.Text);
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 0;
            if (Recruitment_BLL.set_InterviewAssessmentnew(_obj_Rec_InterviewAssessmentForm))
            {
                DataTable DT = BLL.ExecuteQuery("SELECT MAX(IAF_ID) AS IAF_ID FROM SMHR_INTERVIEWASSESSMENTFORM");
                //if (Convert.ToString(ViewState["RECRUITMENTFOR"]) == "Fresher")
                //{
                //    if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //    {
                //        //TO SAVE GENERAL INFO
                //        _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_PayExpectation.Value);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_Availability.Text);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite.SelectedValue);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_RELOCATION = Convert.ToString(rcmb_Relocation.SelectedValue);
                //        _obj_IAF_GeneralInfo.MODE = 1;
                //        Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //    }
                //    //TO SAVE GENERAL ASSESSMENTS
                //    RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                //    for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                //    {
                //        rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                //        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        if (rnt_rtng.Text == string.Empty)
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        else
                //            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //    //TO SAVE FACTORS ASSESSMENTS
                //    RadComboBox rcmb_rtng = new RadComboBox();
                //    RadTextBox rtxt_remarks = new RadTextBox();
                //    for (int index = 0; index < rg_Factors.Items.Count; index++)
                //    {
                //        rcmb_rtng = rg_Factors.Items[index].FindControl("rcmb_rating") as RadComboBox;
                //        rtxt_remarks = rg_Factors.Items[index].FindControl("rtxt_remarks") as RadTextBox;
                //        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                //                                                    Convert.ToString("Factors") + "' AND HR_MASTER_ORGANISATION_ID= " +
                //                                                    Convert.ToInt32(Session["ORG_ID"]));
                //        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                //        _obj_IAF_Rating.MODE = 1;
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_Factors.Items[index]["ASSESSMENT_ID"].Text.Trim());
                //        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng.SelectedItem.Value);
                //        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks.Text);
                //        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                //    }
                //}
                //else
                //{
                //    if (Convert.ToString(ViewState["PRIORITY"]) == "0")
                //    {
                //        //TO SAVE GENERAL INFO
                //        _obj_IAF_GeneralInfo = new RECRUITMENT_IAF_GENERALINFO();
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_IAFID = Convert.ToInt32(DT.Rows[0][0]);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_EXPECTEDCTC = Convert.ToDecimal(rntxt_ExpectedCTC_GenInfo.Value);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_AVAILABILITY = Convert.ToInt32(rntxt_RelPeriod.Text);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_ONSITE = Convert.ToString(rcmb_ReadyOnsite_Exp.SelectedValue);
                //        _obj_IAF_GeneralInfo.IAF_GENERALINFO_PASSPORT = Convert.ToString(rcmb_ValidPassport.SelectedValue);
                //        _obj_IAF_GeneralInfo.MODE = 1;
                //        Recruitment_BLL.set_IAF_GeneralInfo(_obj_IAF_GeneralInfo);
                //    }
                //TO SAVE GENERAL ASSESSMENTS
                RadNumericTextBox rnt_rtng = new RadNumericTextBox();
                for (int index = 0; index < rg_GeneralAssessment.Items.Count; index++)
                {
                    rnt_rtng = rg_GeneralAssessment.Items[index].FindControl("rnt_Value") as RadNumericTextBox;
                    if (rnt_rtng.Text != string.Empty)
                    {
                        DataTable dt_type = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("General Assessment") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_GeneralAssessment.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        if (rnt_rtng.Text != string.Empty)
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        else
                            _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToDecimal(rnt_rtng.Value);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE FACTORS ASSESSMENTS
                RadComboBox rcmb_rtng_exp = new RadComboBox();
                RadTextBox rtxt_remarks_exp = new RadTextBox();
                for (int index = 0; index < rg_FactorsExp.Items.Count; index++)
                {
                    rcmb_rtng_exp = rg_FactorsExp.Items[index].FindControl("rcmb_rating") as RadComboBox;
                    if (rcmb_rtng_exp.SelectedIndex > 0)
                    {
                        rtxt_remarks_exp = rg_FactorsExp.Items[index].FindControl("rtxt_remarks_Exp") as RadTextBox;
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skill Category") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_FactorsExp.Items[index]["SKILLCAT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_RATING = Convert.ToInt32(rcmb_rtng_exp.SelectedItem.Value);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //TO SAVE SKILLS/ATRIBUTES ASSESSMENTS
                for (int index = 0; index < rg_SkillAttributes.Items.Count; index++)
                {
                    rtxt_remarks_exp = rg_SkillAttributes.Items[index].FindControl("rtxt_remarks_Exp_Skill") as RadTextBox;
                    if (rtxt_remarks_exp.Text != string.Empty)
                    {
                        DataTable dt_type_Factor = BLL.ExecuteQuery("SELECT HR_MASTER_ID FROM SMHR_HR_MASTER WHERE HR_MASTER_CODE='" +
                                                                    Convert.ToString("Skills/Attributes") + "' AND HR_MASTER_ORGANISATION_ID= " +
                                                                    Convert.ToInt32(Session["ORG_ID"]));
                        _obj_IAF_Rating = new RECRUITMENT_IAF_RATING();
                        _obj_IAF_Rating.MODE = 1;
                        _obj_IAF_Rating.IAF_RATING_ASSESSMENT_TYPE = Convert.ToInt32(dt_type_Factor.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_ASSESSMNET_ID = Convert.ToInt32(rg_SkillAttributes.Items[index]["ASSESSMENT_ID"].Text.Trim());
                        _obj_IAF_Rating.IAF_RATING_IAF_ID = Convert.ToInt32(DT.Rows[0][0]);
                        _obj_IAF_Rating.IAF_RATING_REMARKS = Convert.ToString(rtxt_remarks_exp.Text);
                        Recruitment_BLL.set_IAF_Rating(_obj_IAF_Rating);
                    }
                }
                //}
            }
            //TO SAVE REMARKS FOR FINAL ROUND
            _obj_Rec_InterviewPhaseRemarks = new RECRUITMENT_INTERVIEW_PHASE_REMARKS();

            _obj_Rec_InterviewPhaseRemarks.MODE = 1;
            _obj_Rec_InterviewPhaseRemarks.INTREM_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_APPLICANTID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_PHASEID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_OVERALLASSESSMENT = Convert.ToString(Rcb_OverallAssessment.SelectedValue);
            _obj_Rec_InterviewPhaseRemarks.INTREM_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
            //if (Rnt_Offeredctc.Text != string.Empty)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_OFFEREDSALARY = Convert.ToDecimal(Rnt_Offeredctc.Text);
            //else
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_OFFEREDSALARY = 0;
            if (Rdp_JoiningdateConfirmed.SelectedDate != null)
                _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE = Convert.ToDateTime(Rdp_JoiningdateConfirmed.SelectedDate.Value);
            else
                _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE = null;
            //if (rcmb_Designation.SelectedIndex > 0)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_DESIGNATIONOFFERED = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            //if (rcmb_Level.SelectedIndex > 0)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_LEVEL = Convert.ToInt32(rcmb_Level.SelectedItem.Value);
            //if (rcmb_Department.SelectedIndex > 0)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_DEPARTMENT = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
            //if (rntxt_JoiningBonus.Text == string.Empty)
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGBONUS = Convert.ToDecimal(rntxt_JoiningBonus.Value);
            //else
            //    _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGBONUS = 0;
            if (rcmb_BusinessUnit.SelectedIndex > 0)
                _obj_Rec_InterviewPhaseRemarks.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_DIVISION = Convert.ToString(Rtxt_Division.Text.Replace("'","''"));
            _obj_Rec_InterviewPhaseRemarks.INTREM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewPhaseRemarks.INTREM_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Recruitment_BLL.set_InterviewPhaseRemarks(_obj_Rec_InterviewPhaseRemarks);
            Recruitment_BLL.ShowMessage(this, "Interview Assessment Form Is Rejected Successfully");
            //TO UPDATE THE CURRENT STATUS OF APPLICANT, 25-07-2013
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Insert2;
            _obj_Rec_JobRequisition.APPLICANT = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_JobRequisition.JOBREQ_CURRENTSTATUS = "Rejected";
            Recruitment_BLL.set_JobRequisition(_obj_Rec_JobRequisition);
            //sendMail("Rejected");
            RMP_InterviewAssesment.SelectedIndex = 0;
            ClearControls();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_CancelFresher_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_InterviewAssesment.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rcmb_BusinessUnit_final_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    // DEPARTMENT
    //    rcmb_Department.Items.Clear();
    //    _obj_smhr_Position = new SMHR_POSITIONS();
    //    _obj_smhr_Position.OPERATION = operation.Select;
    //    _obj_smhr_Position.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit_final.SelectedValue);
    //    _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_Position);
    //    rcmb_Department.DataSource = dtPos;
    //    rcmb_Department.DataTextField = "POSITIONS_CODE";
    //    rcmb_Department.DataValueField = "POSITIONS_ID";
    //    rcmb_Department.DataBind();
    //    rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
    //    //POSITION
    //    rcmb_Designation.Items.Clear();
    //    _obj_SMHR_Department = new SMHR_DEPARTMENT();
    //    _obj_SMHR_Department.MODE = 7;
    //    _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BusinessUnit_final.SelectedValue);
    //    DataTable dt = BLL.get_Department(_obj_SMHR_Department);
    //    rcmb_Designation.DataSource = dt;
    //    rcmb_Designation.DataTextField = "DEPARTMENT_NAME";
    //    rcmb_Designation.DataValueField = "DEPARTMENT_ID";
    //    rcmb_Designation.DataBind();
    //    rcmb_Designation.Items.Insert(0, new RadComboBoxItem("Select"));
    //}
    public void sendMail(string Status)
    {
        try
        {
            string To_Name = string.Empty;
            string comments = string.Empty;
            if (Convert.ToString(ViewState["PHASE_FINAL"]) == "1")
                comments = Convert.ToString(rtxt_finalHRComments.Text);
            else
            {
                //if (Convert.ToString(ViewState["RECRUITMENTFOR"]) == "Fresher")
                //    comments = Convert.ToString(rtxt_comments.Text);
                //else
                comments = Convert.ToString(rtxt_comments_Exp.Text);
            }

            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_JobRequisition.MODE = 23;
            DataTable dt = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);
            _obj_PMS_getemployee.Mode = 6;
            DataTable dt_emp = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);

            if (dt.Rows.Count != 0)
            {
                if (Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]) != string.Empty && Convert.ToString(dt.Rows[0]["HR_EMAIL"]) != string.Empty
                    && Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]) != string.Empty && Convert.ToString(dt.Rows[0]["HRSTAFF_EMAIL"]) != string.Empty)
                {
                    
                    
                    string Content = string.Empty;
                    string Subject = string.Empty;
                    string toAddress, subject, body, ccAddress;
                    if (Convert.ToString(ViewState["PHASE_ISDELIVERYMANAGER"]) == "0" && Convert.ToString(ViewState["PHASE_FINAL"]) == "0")
                    {
                        toAddress=(Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]));
                        toAddress=(Convert.ToString(dt.Rows[0]["HRSTAFF_EMAIL"]));
                        To_Name = Convert.ToString(dt.Rows[0]["HRSTAFF_NAME"]);
                        Content = "Please find assessment details against the interview scheduled for the following.";
                        Subject = "Assessment post interview";
                    }
                    else if (Convert.ToString(ViewState["PHASE_FINAL"]) == "1")
                    {
                        toAddress=(Convert.ToString(dt.Rows[0]["APPROVEDBY_EMAIL"]));
                        To_Name = "Sir";
                        if (Status == "Shortlisted")
                        {
                            Content = "Please find the candidates approved for the following resource requisition.";
                            Subject = "Requesting candidature approval";
                        }
                        else
                        {
                            Content = "Please find the candidates rejected for the following resource requisition.";
                            Subject = "Candidature rejection";
                        }
                    }
                    else
                    {
                        toAddress=(Convert.ToString(dt.Rows[0]["HR_EMAIL"]));
                        toAddress=(Convert.ToString(dt.Rows[0]["HRSTAFF_EMAIL"]));
                        To_Name = "HR";
                        if (Status == "Shortlisted")
                        {
                            Content = "Please find the details of the confirmed candidate, request you to process the same.";
                            Subject = "Confirming the candidature";
                        }
                        else
                        {
                            Content = "Please find the details of the rejected candidate.";
                            Subject = "Candidature rejection";
                        }
                    }
                    if (Convert.ToString(ViewState["PHASE_FINAL"]) == "1")
                    {
                        //if (Convert.ToString(dt.Rows[0]["HR_EMAIL"]) == Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]))
                        //    msgMail.CC.Add(Convert.ToString(dt.Rows[0]["HR_EMAIL"]));
                        //else
                        //{
                        //    msgMail.CC.Add(Convert.ToString(dt.Rows[0]["HR_EMAIL"]));
                        //    msgMail.CC.Add(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                        //}
                        if (Convert.ToString(dt.Rows[0]["HR_EMAIL"]) == Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]))
                            ccAddress=(Convert.ToString(dt.Rows[0]["HR_EMAIL"]));
                        else
                        {
                            ccAddress=(Convert.ToString(dt.Rows[0]["HR_EMAIL"]));
                            ccAddress=(Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]));
                        }
                    }
                    else if (Convert.ToString(ViewState["PHASE_ISDELIVERYMANAGER"]) == "1")
                    {
                        if (Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]) == Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]))
                            ccAddress=(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                        else
                        {
                            ccAddress=(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                            ccAddress=(Convert.ToString(dt.Rows[0]["RAISEDBY_EMAIL"]));
                        }
                    }
                    else
                    {
                        //if (Convert.ToString(dt.Rows[0]["HR_EMAIL"]) == Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]))
                        //    msgMail.CC.Add(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                        //else
                        //{
                        //    msgMail.CC.Add(Convert.ToString(dt.Rows[0]["APPROVEDBY_EMAIL"]));
                        //    msgMail.CC.Add(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                        //}
                        ccAddress=(Convert.ToString(dt_emp.Rows[0]["EMP_EMAIL"]));
                    }


                    subject = Subject;
                    body = "<!DOCTYPE html>" +
                                    "<html>" +
                                    "<html>" +
                                    "<head>" +
                                    "<title>Title of the document</title>" +
                                    "<style>" +
                                    "table {'" +
                                        "'margin-left: 25px;'" +
                                    "}'" +
                                    "</style>" +
                                    "</head>" +
                                    "<body> " +
                                    "</div>" +
                                    "<div style='width:400px;height:20px; '>" +
                                    "<p>Dear " + Convert.ToString(To_Name) + ", </p> " +
                                    "</div>" +
                                    "<p>" + Content + " <br>" +
                                    "</p> " +
                                    "<div style='margin-top:-12px;float:left;'>" +
                                    "<table  border='1' bordercolor='#00000' cellpadding='0' cellspacing='0' width=95%>" +
                                    "<tr>" +
                                    "<p> <th nowrap Style='text-align:left; border-style:solid; border-width:2px; border-collapse:collapse; '> &#32; Resource Requisition &nbsp; </th><td Style='border-style:solid; border-width:2px; border-collapse:collapse;'> &#32; " + Convert.ToString(Rcb_JobReq.SelectedItem.Text) + " </td></p></tr> " +
                                    "<tr>" +
                                    "<p><th Style='text-align:left; border-style:solid; border-width:2px; border-collapse:collapse;'>&#32; Phase Definition &#32;  </th><td Style='border-style:solid; border-width:2px; border-collapse:collapse;'> &#32; " + Convert.ToString(Rcb_PhaseID.SelectedItem.Text) + "</td></p></tr> " +
                                    "<tr>" +
                                    "<p><th Style='text-align:left; border-style:solid; border-width:2px;'>&#32; Applicant Name &#32;  </th><td Style='border-style:solid; border-width:2px;'> &#32; " + Convert.ToString(Rcb_ApplicantID.SelectedItem.Text) + "</td></p></tr>" +
                                    "<tr>" +
                                    "<p><th  Style='text-align:left; border-style:solid; border-width:2px;'>&#32;  Comments &#32;  </th><td Style='border-style:solid; border-width:2px;'> &#32; " + Convert.ToString(comments) + "</td></p></tr>" +
                                    "<tr>" +
                                    "<p><th Style='text-align:left; border-style:solid; border-width:2px;'>&#32;  Status &#32;  </th><td Style='border-style:solid; border-width:2px;'> &#32; " + Convert.ToString(Status) + "</td></p></tr>" +
                                    "</table>" +
                                    "</div>" +
                                     "</p> " +
                                    "<p> Regards,<br/>" +
                                    "Smart HR</p>" +
                                    "</body>" +
                                    " </html>";
                    //SmtpClient smtpC = new SmtpClient();
                    //smtpC.Host = Convert.ToString(ConfigurationManager.AppSettings["MAIL_HOST"]);
                    //smtpC.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["MAIL_ID"]), Convert.ToString(ConfigurationManager.AppSettings["MAIL_PWD"]));
                    //smtpC.Send(msgMail);
                    //BLL.SendMail(msgMail);
                    BLL.SendMail(toAddress, ccAddress, subject, body);
                    BLL.ShowMessage(this, "Notification Has Been Sent.");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                }
            }
            else
            {
                BLL.ShowMessage(this, "Security Code is Invalid");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_ViewintAsmt_command(object sender, CommandEventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    "ShowIntasmt('" + Convert.ToString(Rcb_ApplicantID.SelectedItem.Value) + "','" + Convert.ToString(Rcb_JobReq.SelectedItem.Value) + "','" + Convert.ToString(Rcb_PhaseID.SelectedItem.Value) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_ViewJobReqDetails_command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Rcb_JobReq.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    "ShowPop('" + Convert.ToString(Rcb_JobReq.SelectedItem.Value) + "');", true);
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Resource Requisition");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void lnk_ViewJobReqApplicantDetails_command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Rcb_JobReq.SelectedIndex > 0 && Rcb_ApplicantID.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    "ShowApplicantPop('" + Convert.ToString(Rcb_ApplicantID.SelectedValue) + "');", true);
            }
            else
            {
                BLL.ShowMessage(this, "Please Select an Applicant");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
