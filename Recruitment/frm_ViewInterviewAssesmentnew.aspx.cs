using RECRUITMENT;
using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Recruitment_frm_ViewInterviewAssesmentnew : System.Web.UI.Page
{
    //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit;
    //RECRUITMENT_INTERVIEWASSESSMENTFORM _obj_Rec_InterviewAssessmentForm;
    //RECRUITMENT_INTERVIEW_PHASE_REMARKS _obj_Rec_InterviewPhaseRemarks;
    //SMHR_MASTERS _obj_Smhr_Masters;
    //SMHR_LOGININFO _obj_SMHR_LoginInfo;
    //SMHR_EMPLOYEE _obj_smhr_employee;

    //SMHR_DEPARTMENT _obj_SMHR_Department;
    //SMHR_POSITIONS _obj_smhr_Position;
    //StringBuilder StrAppend;
    //RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def;
    //RECRUITMENT_SKILLSCATEGARY _obj_Rec_SkillCategary;
    //RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    //RECRUITMENT_RESUMESHORTLIST _obj_Rec_ResumeShortList;
    //RECRUITMENT_APPLICANTGRADE _obj_Rec_ApplicantGrade;
    //RECRUITMENT_IAF_RATING _obj_IAF_Rating;
    //RECRUITMENT_IAF_GENERALINFO _obj_IAF_GeneralInfo;
    //PMS_GETEMPLOYEE _obj_PMS_getemployee;
    //SMHR_APPLICANT _obj_smhr_applicant;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Page.Validate();
                //LoadBusinessUnit();
                LOADPHASE();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewInterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

 
    public void LOADPHASE()
    {
        try
        {
            //Convert.ToString(Request.QueryString["APPID"]));
            SMHR_INTERVIEWASSESSMENTFORM _OBJ_SMHR_INTERVIEWASSESSMENTFORM = new SMHR_INTERVIEWASSESSMENTFORM();
            _OBJ_SMHR_INTERVIEWASSESSMENTFORM.MODE = 12;
            _OBJ_SMHR_INTERVIEWASSESSMENTFORM.IAF_APPLID = Convert.ToInt32(Request.QueryString["APPID"]);
            _OBJ_SMHR_INTERVIEWASSESSMENTFORM.IAF_JOBREID = Convert.ToInt32(Request.QueryString["JOBREID"]);
            _OBJ_SMHR_INTERVIEWASSESSMENTFORM.IAF_PHASEDEFID = Convert.ToInt32(Request.QueryString["IAF_PHASEDEFID"]);


            DataTable DT_PHASE = BLL.GET_SMHR_INTERVIEWASSESSMENTFORM(_OBJ_SMHR_INTERVIEWASSESSMENTFORM);
            Rcb_PhaseID.DataSource = DT_PHASE;
            Rcb_PhaseID.DataValueField = "Phase_Id";
            Rcb_PhaseID.DataTextField = "Phase_Name";
            Rcb_PhaseID.DataBind();
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewInterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
   
    protected void Rcb_PhaseID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if (Convert.ToInt32(Rcb_PhaseID.SelectedIndex) > 0)
            {
                SMHR_INTERVIEWASSESSMENTFORM _obj_SMHR_INTERVIEWASSESSMENTFORM = new SMHR_INTERVIEWASSESSMENTFORM();
                _obj_SMHR_INTERVIEWASSESSMENTFORM.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.IAF_APPLID = Convert.ToInt32(Request.QueryString["APPID"]);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.IAF_JOBREID = Convert.ToInt32(Request.QueryString["JOBREID"]);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.MODE = 13;
                DataTable dt_GAssessment = BLL.GET_SMHR_INTERVIEWASSESSMENTFORM(_obj_SMHR_INTERVIEWASSESSMENTFORM);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.MODE = 14;
                DataTable dt_skill = BLL.GET_SMHR_INTERVIEWASSESSMENTFORM(_obj_SMHR_INTERVIEWASSESSMENTFORM);
                _obj_SMHR_INTERVIEWASSESSMENTFORM.MODE = 15;
                DataTable dt_factor = BLL.GET_SMHR_INTERVIEWASSESSMENTFORM(_obj_SMHR_INTERVIEWASSESSMENTFORM);
                rg_GeneralAssessment.DataSource = dt_GAssessment;
                rg_GeneralAssessment.DataBind();
                rg_SkillAttributes.DataSource = dt_skill;
                rg_SkillAttributes.DataBind();
                rg_FactorsExp.DataSource = dt_factor;
                rg_FactorsExp.DataBind();
                if (dt_skill.Rows.Count > 0)
                    rtxt_comments_Exp.Text = Convert.ToString(dt_skill.Rows[0]["IAF_ADDLCOMMENTS"]);
            }



            RMP_InterviewAssesment.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewInterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_InterviewAssesment.SelectedIndex = 0; Rcb_PhaseID.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ViewInterviewAssesmentnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


}