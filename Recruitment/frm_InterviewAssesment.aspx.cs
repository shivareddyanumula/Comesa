using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Text;
using SMHR;
using RECRUITMENT;

public partial class Recruitment_frm_InterviewAssesment : System.Web.UI.Page
{

    SMHR_MASTERS _obj_Smhr_Masters;
    RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm;
    StringBuilder StrAppend;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def;
    RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList;
    RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Page.Validate();
                //LoadSkill();
                //LoadApplicant();
                LoadJobRequest();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
           
        }
    }

    private void LoadSkill()
    {
        try
        {
            DataTable dtDetails = new DataTable();

            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MODE = 1;
            _obj_Smhr_Masters.MASTER_ID = Convert.ToInt32(lbl_Skill.Text);
            dtDetails = BLL.get_MasterRecords(_obj_Smhr_Masters);

            if (dtDetails.Rows.Count != 0)
            {
                RG_Skills1.DataSource = dtDetails;
                RG_Skills1.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
 
    private void LoadApplicant()
    {
        try
        {
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();

            _obj_Rec_InterviewAssessmentForm.MODE = 5;
            Rcb_ApplicantID.DataSource = Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            Rcb_ApplicantID.DataTextField = "APPLICANT_CODE";
            Rcb_ApplicantID.DataValueField = "RESSHT_APPLID";
            Rcb_ApplicantID.DataBind();
            Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadJobRequest()
    {
        try
        {

            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();

            _obj_Rec_JobRequisition.MODE = 1;
            Rcb_JobReq.DataSource = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);

            Rcb_JobReq.DataTextField = "JOBREQ_REQCODE";
            Rcb_JobReq.DataValueField = "JOBREQ_ID";
            Rcb_JobReq.DataBind();
            Rcb_JobReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPhase()
    {
        try
        {

            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();

            _obj_Rec_Interview_Phase_Def.Mode = 6;
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);

            Rcb_PhaseID.DataSource = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            Rcb_PhaseID.DataValueField = "PHASE_ID";
            Rcb_PhaseID.DataTextField = "PHASE_NAME";
            Rcb_PhaseID.DataBind();
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadApplicantPhase()
    {
        try
        {
            DataTable DTApplicant = new DataTable();

            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();

            Rcb_PhaseID.Items.Clear();

            _obj_Rec_Interview_Phase_Def.Mode = 7;
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Applicant = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);

            DTApplicant = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            
            //Rcb_PhaseID.DataSource = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_SMHR_INTERVIEW_PHASE_DEF);

            if (DTApplicant.Rows.Count == 0)
            {
                Recruitment_BLL.ShowMessage(this, "Selected Applicant is already Rejected.");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    
    }

    private void Applicants()
    {
        try
        {

            _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();

            _obj_Rec_ResumeShortList.Mode = 9;
            _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);

            Rcb_ApplicantID.DataSource = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
           Rcb_ApplicantID.DataValueField = "RESSHT_APPLID";
           Rcb_ApplicantID.DataTextField = "APPLICANT_CODE";
           Rcb_ApplicantID.DataBind();
           Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));

        
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
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
            if (DtApplicantDetails.Rows.Count > 0)
            {

                rtxt_FullName.Text = Convert.ToString(DtApplicantDetails.Rows[0]["NAME"]);
                rntxt_ContactNumber.Text = Convert.ToString(DtApplicantDetails.Rows[0]["APPCONT_PHONE"]);
                rtxt_PositionAppliedFor.Text = Convert.ToString(DtApplicantDetails.Rows[0]["DESIGNATION"]);
                rtxt_Qualification.Text = Convert.ToString(DtApplicantDetails.Rows[0]["QUALIFICATION"]);
                rtxt_Company.Text = Convert.ToString(DtApplicantDetails.Rows[0]["COMPANY"]);
                lbl_Skill.Text = Convert.ToString(DtApplicantDetails.Rows[0]["JOREQ_SKILL"]);
                //lbl_FirstRound.Text = Convert.ToString(DtApplicantDetails.Rows[0]["PHASE_NAME"]);
                //lbl_JobReqId.Text = Convert.ToString(DtApplicantDetails.Rows[0]["RESSHT_JOBREQID"]);
                lbl_FirstRound.Text = Convert.ToString(Rcb_PhaseID.SelectedItem.Text);
                LoadSkill();
            }
            else
            {
                rtxt_FullName.Text = string.Empty;
                //rntxt_ContactNumber.Value = 0;
                rntxt_ContactNumber.Text = string.Empty;
                rtxt_PositionAppliedFor.Text = string.Empty;
                rtxt_Qualification.Text = string.Empty;
                rtxt_Company.Text = string.Empty;
                lbl_Skill.Text = string.Empty;
                lbl_FirstRound.Text = string.Empty;
                lbl_JobReqId.Text = string.Empty;

                DataTable DtEmpty = new DataTable();
                RG_Skills1.DataSource = DtEmpty;
                RG_Skills1.DataBind();
                //rdi_Date.Clear();
                rtxt_AdditionalComments1.Text = string.Empty;
                rtxt_Signature.Text = string.Empty;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }  

    protected void Rcb_Assesment_DataBinding(object sender, EventArgs e)
    {
        try
        {

            _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();

            RadComboBox txtCompleteBy = (RadComboBox)sender;
            _obj_Rec_ApplicantGrade.MODE = 1;
            DataTable dt = new DataTable();
            dt = Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade);
            txtCompleteBy.DataSource = dt;
            txtCompleteBy.DataTextField = "APPGRADE_NAME";
            txtCompleteBy.DataValueField = "APPLGRADE_ID";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            StrAppend = new StringBuilder();

            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();

            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            //_obj_Rec_InterviewAssessmentForm.MODE = 7;

            //if (Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm).Rows[0]["COUNT"].ToString() != "0")
            //{
            //    Recruitment_BLL.ShowMessage(this, "Sorry.Applicant had already attended the Interview");
            //    return;
            //}
            //else
            //{
                _obj_Rec_InterviewAssessmentForm.MODE = 1;
                _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_AdditionalComments1.Text);
                _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["UserId"]);
                _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE = DateTime.Now;
                _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY = Convert.ToInt32(Session["UserId"]);
                _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE = DateTime.Now;

                switch (((Button)sender).ID.ToUpper())
                {
                    case "BTN_SUBMIT":

                        _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 1;
                        //_obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
                        //_obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
                        _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
                        _obj_Rec_InterviewAssessmentForm.IAF_DATE = DateTime.Now; //Convert.ToDateTime(rdi_Date.Text);//

                        foreach (GridDataItem Singleitem in RG_Skills1.Items)
                        {
                            _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);

                            RadComboBox chk = (RadComboBox)Singleitem.Cells[4].FindControl("Rcb_Assesment");
                            StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                            StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                            StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                            StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE + "'");
                            StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE + "' ");
                            StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE + "'");
                            StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                        }

                        if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                        {
                            Recruitment_BLL.ShowMessage(this, "Record saved successfully");
                        }
                        else
                        {
                            Recruitment_BLL.ShowMessage(this, "Record not saved");
                        }

                        ClearControls();
                        RMP_InterviewAssesment.SelectedIndex = 0;

                        break;
                    case "BTN_REJECTED":

                        _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 0;
                        //_obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
                        //_obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
                        _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
                        _obj_Rec_InterviewAssessmentForm.IAF_DATE = DateTime.Now; //Convert.ToDateTime(rdi_Date.Text);

                        foreach (GridDataItem Singleitem in RG_Skills1.Items)
                        {
                            _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);
                            RadComboBox chk = (RadComboBox)Singleitem.Cells[4].FindControl("Rcb_Assesment");
                            StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                            StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                            StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                            StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE + "'");
                            StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE + "' ");
                            StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE + "'");
                            StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                        }

                        if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                        {
                            Recruitment_BLL.ShowMessage(this, "Record saved successfully");
                        }
                        else
                        {
                            Recruitment_BLL.ShowMessage(this, "Record not saved");
                        }

                        ClearControls();
                        RMP_InterviewAssesment.SelectedIndex = 0;

                        break;
                    case "BTN_NEXT":
                        LoadApplicantDetails();
                        RMP_InterviewAssesment.SelectedIndex = 1;
                        break;
                    default:
                        break;

                }
//            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rcb_ApplicantID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadApplicantDetails();
            //LoadPhase();
            Rcb_PhaseID.Items.Clear();
            if (Rcb_ApplicantID.SelectedItem.Value.ToString() != "0")
            {
                LoadApplicantPhase();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rcb_JobReq_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //LoadPhase();
            Applicants();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rcb_PhaseID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //Applicants();
            LoadPhase();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_InterviewAssesment.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rtxt_FullName.Text = string.Empty;
            //rntxt_ContactNumber.Value = 0;
            rntxt_ContactNumber.Text = string.Empty;
            rtxt_PositionAppliedFor.Text = string.Empty;
            rtxt_Qualification.Text = string.Empty;
            rtxt_Company.Text = string.Empty;
            lbl_Skill.Text = string.Empty;
            lbl_FirstRound.Text = string.Empty;
            lbl_JobReqId.Text = string.Empty;
            Rcb_PhaseID.Items.Clear();
            Rcb_ApplicantID.Items.Clear();
            Rcb_JobReq.SelectedIndex = 0;
            DataTable DtEmpty = new DataTable();
            RG_Skills1.DataSource = DtEmpty;
            RG_Skills1.DataBind();
            //rdi_Date.Clear();
            rtxt_AdditionalComments1.Text = string.Empty;
            rtxt_Signature.Text = string.Empty;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
}
