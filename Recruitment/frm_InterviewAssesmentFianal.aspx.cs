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

public partial class Recruitment_frm_InterviewAssesmentFianal : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Page.Validate();
                if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
                {
                    LoadBusinessUnit();
                    //LoadApplicantPhase();
                    //    LoadInterviewName();
                    //   LoadJobRequest();

                }
                else
                {
                    LoadBusinessUnit();
                   // tr_bunit.Visible = false;
                  //  tr_intername.Visible = false;
                    LoadJobRequest();
                }
               
            }
        }
        
         catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            //   //Business Unit
            //   rcmb_BusinessUnit.Items.Clear();
            //   _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //   _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            //   _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //   _obj_Smhr_BusinessUnit.ISDELETED = true;
            //   DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //   rcmb_BusinessUnit.DataSource = dt;
            //   rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //   rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //   rcmb_BusinessUnit.DataBind();
            ////   rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //   rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            ////Department
            //_obj_Smhr_Masters = new SMHR_MASTERS();
            //_obj_Smhr_Masters.MASTER_TYPE = "DEPARTMENT";
            //_obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_Masters.OPERATION = operation.Select;
            //DataTable dt_Department = new DataTable();
            //dt_Department = BLL.get_MasterRecords(_obj_Smhr_Masters);
            //rcmb_Department.DataSource = dt_Department;
            //rcmb_Department.DataTextField = "HR_MASTER_CODE";
            //rcmb_Department.DataValueField = "HR_MASTER_ID";
            //rcmb_Department.DataBind();
            //rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            ////Designation
            //_obj_Smhr_Masters.MASTER_TYPE = "DESIGNATION";
            //_obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Smhr_Masters.OPERATION = operation.Select;
            //DataTable dt_Designation = new DataTable();
            //dt_Designation = BLL.get_MasterRecords(_obj_Smhr_Masters);
            //rcmb_Designation.DataSource = dt_Designation;
            //rcmb_Designation.DataTextField = "HR_MASTER_CODE";
            //rcmb_Designation.DataValueField = "HR_MASTER_ID";
            //rcmb_Designation.DataBind();
            //rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            _obj_smhr_Position = new SMHR_POSITIONS();
            _obj_smhr_Position.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable dt_Details = BLL.get_Positions(_obj_smhr_Position);
            rcmb_Designation.DataSource = dt_Details;
            rcmb_Designation.DataTextField = "POSITIONS_CODE";
            rcmb_Designation.DataValueField = "POSITIONS_ID";
            rcmb_Designation.DataBind();
            rcmb_Designation.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));


            //Level
            _obj_Smhr_Masters = new SMHR_MASTERS();
            _obj_Smhr_Masters.MASTER_TYPE = "GRADE";
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_Masters.OPERATION = operation.Select;
            DataTable dt_Level = new DataTable();
            dt_Level = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_Level.DataSource = dt_Level;
            rcmb_Level.DataTextField = "HR_MASTER_CODE";
            rcmb_Level.DataValueField = "HR_MASTER_ID";
            rcmb_Level.DataBind();
            rcmb_Level.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadInterviewName();
            LoadDepartment();
            LoadCombos();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Interviewername_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadJobRequest();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDepartment()
    {
        try
        {
            _obj_SMHR_Department = new SMHR_DEPARTMENT();
            _obj_SMHR_Department.MODE = 9;
            _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            DataTable dt_Details = BLL.get_Department(_obj_SMHR_Department);
            if (dt_Details.Rows.Count != 0)
            {
                rcmb_Department.DataSource = dt_Details;
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataValueField = "DEPARTMENT_ID";
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Department.DataSource = dt_Details;
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Methods USed in the Page

    /// <summary>
    /// To Load the Skills 
    /// </summary>
    private void LoadSkill()
    {
        try
        {
            DataTable dtDetails = new DataTable();


            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            lbl_Skill.Text = Convert.ToString(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Phase_ID = Convert.ToInt32(lbl_Skill.Text);
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString()); 
            _obj_Rec_Interview_Phase_Def.Mode = 4;

            dtDetails = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            if (dtDetails.Rows.Count != 0)
            {
                if (dtDetails.Rows[0]["PHASE_FINAL"].ToString().ToUpper() == "TRUE")
                {
                    VisibleControls(true);
                    btn_HrSubmit.Visible = true;
                    btn_HrRejected.Visible = true;
                    btn_Rejected.Visible = false;
                    btn_Submit.Visible = false;
                }
                else
                {
                    VisibleControls(false);
                    btn_HrSubmit.Visible = false;
                    btn_HrRejected.Visible = false;
                    btn_Rejected.Visible = true;
                    btn_Submit.Visible = true;
                }

                _obj_Rec_SkillCategary = new RECRUITMENT_SKILLSCATEGARY();

                _obj_Rec_SkillCategary.MODE = 19;
                _obj_Rec_SkillCategary.PHASE_ID = Convert.ToInt32(lbl_Skill.Text);
                DataTable DT_SKILS = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
                string str_skillitems = "";
                if (DT_SKILS.Rows.Count > 0)
                {
                    for (int i = 0; i <= DT_SKILS.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            str_skillitems = str_skillitems + DT_SKILS.Rows[i]["phase_skill"];
                        }
                        else
                        {
                            str_skillitems = str_skillitems + ",";
                            str_skillitems = str_skillitems + DT_SKILS.Rows[i]["phase_skill"];
                        }
                    }
                }

                _obj_Rec_SkillCategary.MODE = 6;
                _obj_Rec_SkillCategary.@SKILLCAT_NAME = str_skillitems;
                _obj_Rec_SkillCategary.SKILL_JR_ID = Convert.ToInt32(Rcb_JobReq.SelectedValue);

                //Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
                RG_Skills1.DataSource = Recruitment_BLL.get_skillscategary(_obj_Rec_SkillCategary);
                RG_Skills1.DataBind();
            }



            //_obj_SMHR_Masters = new SMHR_MASTERS();
            //_obj_SMHR_Masters.MODE = 1;
            //_obj_SMHR_Masters.MASTER_ID = Convert.ToInt32(lbl_Skill.Text);
            //dtDetails = Recruitment_BLL.get_MasterRecords(_obj_SMHR_Masters);

            //if (dtDetails.Rows.Count != 0)
            //{
            //    RG_Skills1.DataSource = dtDetails;
            //    RG_Skills1.DataBind();
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load the JobRequest
    /// </summary>
    private void LoadJobRequest()
    {
        try
        {
            //Session["CTC"] = null;
            DataTable dtJR = new DataTable();

            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32 ( rcmb_Interviewername.SelectedItem.Value);

            }
            else
                _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32(Session["EMP_ID"]);

            _obj_Rec_JobRequisition.MODE = 11;

            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dtJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
            if (dtJR.Rows.Count != 0)
              {
                  Rcb_JobReq.DataSource = dtJR;
                  //Session["CTC"] = dtJR.Rows[0]["JOBREQ_APPCTC"]; 
                  int a = Convert.ToInt32(Session["CTC"]);
                  Rcb_JobReq.DataTextField = "JOBREQ_REQCODE";
                  Rcb_JobReq.DataValueField = "JOBREQ_ID";
                  Rcb_JobReq.DataBind();
                  Rcb_JobReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));
              }
              else
              {
                //  Recruitment_BLL.ShowMessage(this, "No Job Requisition Raised");
                  DataTable dt1 = new DataTable();
                  Rcb_JobReq.DataSource = dt1;
                  Rcb_JobReq.DataBind();
                  Rcb_JobReq.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                  return;
              }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void LoadBusinessUnit()
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
            //  rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void LoadInterviewName()
    {
        try
        {
            //if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            //{

                _obj_smhr_employee = new SMHR_EMPLOYEE();

                _obj_smhr_employee.OPERATION = operation.SELECTEMPLOYEE;
                _obj_smhr_employee.BUID  = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
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
                //else
                //{

                //    rcmb_Interviewername.DataSource = dt_Details;
                //    rcmb_Interviewername.DataBind();
                //    rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                //    return;

                //}
            //}
            //else
            //{
            //    _obj_smhr_employee = new SMHR_EMPLOYEE();

            //    _obj_smhr_employee.OPERATION = operation.SELECTEMPLOYEE;
            //    rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(Session["BUSINESSUNIT_ID"]));
            //  //  rcmb_BusinessUnit.SelectedIndex =rcmb_BusinessUnit.FindItemIndexByValue(Session["BUSINESSUNIT_ID"].ToString () );
            //    rcmb_BusinessUnit.Enabled = false; 
            //  _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
              

             
            //    DataTable dt_Details = Recruitment_BLL.get_Employee(_obj_smhr_employee);
                
            //   if (dt_Details.Rows.Count != 0)
            //    {
            //        rcmb_Interviewername.DataSource = dt_Details;
            //        rcmb_Interviewername.DataTextField = "EMPNAME";
            //        rcmb_Interviewername.DataValueField = "EMP_ID";
            //        rcmb_Interviewername.DataBind();
            //        rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            //    }
            //    else
            //    {

            //        rcmb_Interviewername.DataSource = dt_Details;
            //        rcmb_Interviewername.DataBind();
            //        rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            //        return;

            //    }
            //    rcmb_BusinessUnit.SelectedIndex = 1;
            //    rcmb_BusinessUnit_SelectedIndexChanged(null, null);

            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    /// <summary>
    /// To Load the Phase State for the Selected Applicant
    /// </summary>
    private void LoadApplicantPhase()
    {
        try
        {
            DataTable DTApplicant = new DataTable();

            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();

            Rcb_PhaseID.Items.Clear();
            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);
            }
            else
            {
                _obj_Rec_Interview_Phase_Def.PHASE_INTERVIEWERNAME = Convert.ToInt32(Session["EMP_ID"]);
            }

            _obj_Rec_Interview_Phase_Def.Mode = 7;
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.Applicant = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_Interview_Phase_Def.PHASE_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
          

            DTApplicant = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);


            //commented by Aravinda
            if (DTApplicant.Rows.Count == 0)
            {
                //Recruitment_BLL.ShowMessage(this, "Selected Applicant is already Rejected.");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    /// <summary>
    /// To Load the Applicants for the selected JobRequest
    /// </summary>
    private void Applicants()
    {
        try
        {

            _obj_Rec_ResumeShortList = new RECRUITMENT_RESUMESHORTLIST();

            _obj_Rec_ResumeShortList.Mode = 9;
           // _obj_Rec_ResumeShortList.RESSHT_JOBREQID = rcmb_BusinessUnit.FindItemIndexByValue(Convert.ToString(Session["BUSINESSUNIT_ID"]));
          _obj_Rec_ResumeShortList.RESSHT_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);

            Rcb_ApplicantID.DataSource = Recruitment_BLL.getApplicants(_obj_Rec_ResumeShortList);
            Rcb_ApplicantID.DataValueField = "RESSHT_APPLID";
            Rcb_ApplicantID.DataTextField = "APPLICANTNAME";
            Rcb_ApplicantID.DataBind();
            Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("Select", "0"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load the Applicant Details for the Selected Applicant and the job request
    /// </summary>
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
                rtxt_DateofInterview.Text = Convert.ToString(DtApplicantDetails.Rows[0]["PHASE_INTERVIEWDATE"]);
                lbl_Skill.Text = Convert.ToString(Rcb_PhaseID.SelectedItem.Value);
                rtxt_TotalExp.Text = Convert.ToString(DtApplicantDetails.Rows[0]["EXPERIENCE"]);
                lbl_Skill.Text = Convert.ToString(DtApplicantDetails.Rows[0]["JOREQ_SKILL"]);

                //lbl_FirstRound.Text = Convert.ToString(DtApplicantDetails.Rows[0]["PHASE_NAME"]);
                //lbl_JobReqId.Text = Convert.ToString(DtApplicantDetails.Rows[0]["RESSHT_JOBREQID"]);
                lbl_FirstRound.Text = Convert.ToString(Rcb_PhaseID.SelectedItem.Text);
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
                LoadSkill();
                lbl_OfferedSalary.Text ="CTC Offered : "+ Convert.ToInt32(Session["CTC"]);
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
                rtxt_TotalExp.Text = string.Empty;
                lbl_FirstRound.Text = string.Empty;
                lbl_JobReqId.Text = string.Empty;

                DataTable DtEmpty = new DataTable();
                RG_Skills1.DataSource = DtEmpty;
                RG_Skills1.DataBind();
                //rdi_Date.Clear();
                rtxt_AdditionalComments1.Text = string.Empty;
                //rtxt_Signature.Text = string.Empty;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    /// <summary>
    /// To Clear the Controls Data
    /// </summary>
    private void ClearControls()
    {
        try
        {
            rtxt_FullName.Text = string.Empty;
            rntxt_ContactNumber.Text = string.Empty;
            rtxt_PositionAppliedFor.Text = string.Empty;
            rtxt_Qualification.Text = string.Empty;
            rtxt_Company.Text = string.Empty;
            lbl_Skill.Text = string.Empty;
            lbl_FirstRound.Text = string.Empty;
            lbl_JobReqId.Text = string.Empty;
            Rcb_PhaseID.Items.Clear();
            Rcb_PhaseID.Items.Insert(0, new RadComboBoxItem("", ""));
            rcmb_Interviewername.Items.Clear();
            rcmb_Interviewername.Items.Insert(0, new RadComboBoxItem("",""));
            Rcb_ApplicantID.Items.Clear();
            Rcb_ApplicantID.Items.Insert(0, new RadComboBoxItem("",""));
            //Rcb_JobReq.SelectedIndex = 0;
            Rcb_JobReq.ClearSelection();
            DataTable DtEmpty = new DataTable();
            RG_Skills1.DataSource = DtEmpty;
            RG_Skills1.DataBind();
            //rdi_Date.Clear();
            rtxt_AdditionalComments1.Text = string.Empty;
            //rtxt_Signature.Text = string.Empty;

            Rtxt_NoticePeriod.Text = string.Empty;
            Rtxt_ReasonforChange.Text = string.Empty;
            Rtxt_FamilyDetails.Text = string.Empty;
            Rntxt_PreviousCTC.Value = 0;
            Rntxt_ExpectedCTC.Value = 0;

            //Rtxt_Department.Text = string.Empty;
           // Rtxt_DesignationOffered.Text = string.Empty;
            //Rtxt_Division.Text = string.Empty;
           // Rtxt_Level.Text = string.Empty;
            Rnt_Offeredctc.Text = string.Empty;
            Rdp_JoiningdateConfirmed.Clear();
           
            Rcb_Recommendation.Items.Clear();
            Rcb_OverallAssessment.Items.Clear();
            rcmb_BusinessUnit.ClearSelection();
            //rcmb_BusinessUnit.Items.Clear();
            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("",""));
            rcmb_Department.Items.Clear();            
            rcmb_Designation.Items.Clear();
            rcmb_Level.Items.Clear();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    /// <summary>
    /// This is used for showing the controls based on the Round.
    /// </summary>
    /// <param name="Status"></param>
    private void VisibleControls(bool Status)
    {
        try
        {
            tr_Department.Visible = Status;
            tr_OfferedCTC.Visible = Status;
            tr_OfferedSalary.Visible = Status;
            tr_OverallAssessment.Visible = Status;
            //tr_Recommendation.Visible = Status;
            tr_FinalCompensationDetails.Visible = Status;
            tr_BU.Visible = Status;
            tr_OfferedSalary.Visible = Status;
            tr_OfferedSalary.Visible = Status;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    private void SaveData()
    {
        try
        {
              DataTable DtApplicantDetails = new DataTable();
            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            _obj_Rec_InterviewAssessmentForm.MODE = 8;
            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            //if (Convert.ToString(Recruitment_BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm).Rows[0]["Count"]) != "0")
            //    {
            //      Recruitment_BLL.ShowMessage(this, "This Combination Already Exists");
            //      return;
            //    }
            
        

            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();

            _obj_Rec_InterviewAssessmentForm.IAF_APPLID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_JOBREID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);

            _obj_Rec_InterviewAssessmentForm.MODE = 1;
            _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS = Convert.ToString(rtxt_AdditionalComments1.Text);
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]); 
            _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE = DateTime.Now;
            _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); 
            _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE = DateTime.Now;

            _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewAssessmentForm.IAF_DATE = DateTime.Now;
            _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    private void SaveRemarks()
    {
        try
        {
            _obj_Rec_InterviewPhaseRemarks = new RECRUITMENT_INTERVIEW_PHASE_REMARKS();

            _obj_Rec_InterviewPhaseRemarks.MODE = 1;
            _obj_Rec_InterviewPhaseRemarks.INTREM_JOBREQID = Convert.ToInt32(Rcb_JobReq.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_APPLICANTID = Convert.ToInt32(Rcb_ApplicantID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_PHASEID = Convert.ToInt32(Rcb_PhaseID.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_OVERALLASSESSMENT = Convert.ToString(Rcb_OverallAssessment.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_OFFEREDSALARY = Convert.ToDecimal(Rnt_Offeredctc.Text);
            _obj_Rec_InterviewPhaseRemarks.INTREM_JOININGDATE = Convert.ToDateTime(Rdp_JoiningdateConfirmed.SelectedDate.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_DESIGNATIONOFFERED = Convert.ToInt32(rcmb_Designation.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_LEVEL = Convert.ToInt32(rcmb_Level.SelectedItem.Value);
            _obj_Rec_InterviewPhaseRemarks.INTREM_DEPARTMENT = Convert.ToInt32(rcmb_Department.SelectedItem.Value);
            //_obj_Rec_InterviewPhaseRemarks.INTREM_DIVISION = Convert.ToString(Rtxt_Division.Text.Replace("'","''"));
            _obj_Rec_InterviewPhaseRemarks.INTREM_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewPhaseRemarks.INTREM_CREATEDDATE = DateTime.Now;
            _obj_Rec_InterviewPhaseRemarks.INTREM_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_InterviewPhaseRemarks.INTREM_LASTMDFDATE = DateTime.Now;
            _obj_Rec_InterviewPhaseRemarks.INTREM_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Rec_InterviewPhaseRemarks.BUID = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    #endregion

    protected void LoadGrade(object sender, EventArgs e)
    {
        try
        {
    //////     //   _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();

    //////        RadComboBox txtCompleteBy = (RadComboBox)sender;
                   
                 _obj_Smhr_Masters = new SMHR_MASTERS();
                 _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_Smhr_Masters.OPERATION = operation.Select;
    //////        //  _obj_Smhr_Masters.MASTER_TYPE = "GRADESET"; 
    //////        _obj_Smhr_Masters.MASTER_TYPE = "INTERVIEW ROUNDS";
            DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
    //////        txtCompleteBy.DataSource = dt_Details;
    //////        txtCompleteBy.DataTextField = "HR_MASTER_CODE";
    //////        txtCompleteBy.DataValueField = "HR_MASTER_ID";
    //////        txtCompleteBy.DataBind();
    //////        txtCompleteBy.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            Rcb_OverallAssessment.DataSource = dt_Details;
            Rcb_OverallAssessment.DataTextField = "HR_MASTER_CODE";
            Rcb_OverallAssessment.DataValueField = "HR_MASTER_ID";
            Rcb_OverallAssessment.DataBind();
            Rcb_OverallAssessment.Items.Insert(0, new RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
            protected void LoadApplicantGrade()
            {
                try
                {
                    _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();

                //    Rcb_OverallAssessment.DataSource = dt;
                    Rcb_OverallAssessment.DataTextField = "APPGRADE_NAME";
                    Rcb_OverallAssessment.DataValueField = "APPLGRADE_ID";
                    Rcb_OverallAssessment.DataBind();
                    Rcb_OverallAssessment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                }
                catch (Exception ex)
                {

                    SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
                    Response.Redirect("~/Frm_ErrorPage.aspx");
                    return;
                }
        }


    #region ComboBox DataBinding Event Code
    protected void Rcb_Assesment_DataBinding(object sender, EventArgs e)
    {
        try
        {
           // RadComboBox txtCompleteBy = (RadComboBox)sender;
           // _obj_Smhr_Masters = new SMHR_MASTERS();
           // _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
           // _obj_Smhr_Masters.OPERATION = operation.Select;
           // //  _obj_Smhr_Masters.MASTER_TYPE = "GRADESET"; 
           // _obj_Smhr_Masters.MASTER_TYPE = "INTERVIEW ROUNDS";
           // DataTable dt_Details = BLL.get_MasterRecords(_obj_Smhr_Masters);
           // txtCompleteBy.DataSource = dt_Details;
           // txtCompleteBy.DataTextField = "HR_MASTER_CODE";
           // txtCompleteBy.DataValueField = "HR_MASTER_ID";
           //// txtCompleteBy.DataBind();
           // txtCompleteBy.Items.Insert(0, new RadComboBoxItem("Select", "0"));

           // Rcb_OverallAssessment.DataSource = dt_Details;
           // Rcb_OverallAssessment.DataTextField = "HR_MASTER_CODE";
           // Rcb_OverallAssessment.DataValueField = "HR_MASTER_ID";
           // Rcb_OverallAssessment.DataBind();
           // Rcb_OverallAssessment.Items.Insert(0, new RadComboBoxItem("Select", "0"));



            _obj_Rec_ApplicantGrade = new RECRUITMENT_APPLICANTGRADE();

            RadComboBox txtCompleteBy = (RadComboBox)sender;

            _obj_Rec_ApplicantGrade.MODE = 1;

            //////////if (tr_Department.Visible)
            //////////{
            //////////    _obj_Rec_ApplicantGrade.APPGRADE_NAME = "HR";
            //////////}
            //////////else
            //////////{
            //////////    _obj_Rec_ApplicantGrade.APPGRADE_NAME = "TECHNICAL";
            //////////}

            DataTable dt = new DataTable();
            dt = Recruitment_BLL.get_ApplicantGrade(_obj_Rec_ApplicantGrade);
            txtCompleteBy.DataSource = dt;
            txtCompleteBy.DataTextField = "APPGRADE_NAME";
            txtCompleteBy.DataValueField = "APPLGRADE_ID";

            Rcb_OverallAssessment.DataSource = dt;
            Rcb_OverallAssessment.DataTextField = "APPGRADE_NAME";
            Rcb_OverallAssessment.DataValueField = "APPLGRADE_ID";
            Rcb_OverallAssessment.DataBind();
            Rcb_OverallAssessment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #endregion

    #region Button Click Event Code

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
         //   LoadApplicantGrade();
            StrAppend = new StringBuilder();

            _obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            //if (rcmb_BusinessUnit.SelectedItem.Value.ToString() != "0")
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                if (rcmb_Interviewername.SelectedIndex > 0)
                {
                    if (Rcb_JobReq.SelectedIndex > 0)
                    {
                     if(Rcb_ApplicantID.SelectedIndex > 0)
                     {  
                        switch (((Button)sender).ID.ToUpper())
                        {
                            case "BTN_SUBMIT":
                              
                                SaveData();

                                _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 1;

                                foreach (GridDataItem Singleitem in RG_Skills1.Items)
                                {
                                    _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);

                                    RadComboBox chk = (RadComboBox)Singleitem.Cells[4].FindControl("Rcb_Assesment");
                                    StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                                    StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                                  StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                 ///    StrAppend.AppendLine(",@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                    StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE.ToString("MM/dd/yyyy") + "'");
                                    StrAppend.AppendLine(",@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID + "'");
                                    StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE.ToString("MM/dd/yyyy") + "' ");
                                    StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE.ToString("MM/dd/yyyy") + "'");
                                    StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                                }

                                if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");


                                }
                                else
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                }

                                   ClearControls();
                                RMP_InterviewAssesment.SelectedIndex = 0;

                                break;
                            case "BTN_REJECTED":

                                SaveData();

                                _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 0;

                                foreach (GridDataItem Singleitem in RG_Skills1.Items)
                                {
                                    _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);
                                    RadComboBox chk = (RadComboBox)Singleitem.Cells[4].FindControl("Rcb_Assesment");
                                    StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                                    StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                                    StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                   // StrAppend.AppendLine(",@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                    StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE.ToString("MM/dd/yyyy") + "'");
                                    StrAppend.AppendLine(",@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID + "'");
                                    StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE.ToString("MM/dd/yyyy") + "' ");
                                    StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE.ToString("MM/dd/yyyy") + "'");
                                    StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                                }

                                if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");

                                }
                                else
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                }

                                ClearControls();
                                RMP_InterviewAssesment.SelectedIndex = 0;

                                break;
                            case "BTN_NEXT":
                                LoadApplicantDetails();
                                RMP_InterviewAssesment.SelectedIndex = 1;
                                break;
                            case "BTN_HRSUBMIT":

                                SaveData();

                                _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 1;

                                foreach (GridDataItem Singleitem in RG_Skills1.Items)
                                {
                                    _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);

                                    RadComboBox chk = (RadComboBox)Singleitem.Cells[3].FindControl("Rcb_Assesment");
                                    StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                                    StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                                      StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                    //StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "');
                                    //StrAppend.AppendLine(",@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                    StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE + "'");
                                    StrAppend.AppendLine(",@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID + "'");
                                    StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE + "' ");
                                    StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE + "'");
                                    StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                                }

                                if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                                {
                                    SaveRemarks();
                                    if (Recruitment_BLL.set_InterviewPhaseRemarks(_obj_Rec_InterviewPhaseRemarks))
                                    {
                                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");

                                    }
                                    else
                                    {
                                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                    }

                                }
                                else
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                }

                                ClearControls();
                                RMP_InterviewAssesment.SelectedIndex = 0;

                                break;
                            case "BTN_HRREJECTED":
                                SaveData();

                                _obj_Rec_InterviewAssessmentForm.IAF_APPROVE = 0;

                                foreach (GridDataItem Singleitem in RG_Skills1.Items)
                                {
                                    _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID = Convert.ToInt32(Singleitem.Cells[2].Text);
                                    RadComboBox chk = (RadComboBox)Singleitem.Cells[4].FindControl("Rcb_Assesment");
                                    StrAppend.Append("Exec USP_SMHR_INTERVIEWASSESSMENTFORM @MODE = 1 , @IAF_APPLID = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPLID + "'");
                                    StrAppend.AppendLine(",@IAF_JOBREID = '" + _obj_Rec_InterviewAssessmentForm.IAF_JOBREID + "', @IAF_SKILLCAT_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_SKILLCAT_ID + "'");
                                    StrAppend.AppendLine(",@IAF_APPLGRADE_ID = '" + chk.SelectedItem.Value + "',@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                   // StrAppend.AppendLine(",@IAF_ADDLCOMMENTS = '" + _obj_Rec_InterviewAssessmentForm.IAF_ADDLCOMMENTS + "'");
                                    StrAppend.AppendLine(",@IAF_APPROVE = '" + _obj_Rec_InterviewAssessmentForm.IAF_APPROVE + "', @IAF_DATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_DATE + "'");
                                    StrAppend.AppendLine(",@IAF_ORGANISATION_ID = '" + _obj_Rec_InterviewAssessmentForm.IAF_ORGANISATION_ID + "'");
                                    StrAppend.AppendLine(",@IAF_CREATEDBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDBY + "',@IAF_CREATEDDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_CREATEDDATE.ToString("MM/dd/yyyy") + "' ");
                                    StrAppend.AppendLine(",@IAF_LASTMDFBY = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFBY + "' , @IAF_LASTMDFDATE = '" + _obj_Rec_InterviewAssessmentForm.IAF_LASTMDFDATE.ToString("MM/dd/yyyy") + "'");
                                    StrAppend.AppendLine(",@IAF_PHASEDEFID ='" + _obj_Rec_InterviewAssessmentForm.IAF_PHASEDEFID + "'");
                                }

                                if (Recruitment_BLL.set_InterviewAssessment(_obj_Rec_InterviewAssessmentForm, StrAppend.ToString()))
                                {
                                    SaveRemarks();
                                    if (Recruitment_BLL.set_InterviewPhaseRemarks(_obj_Rec_InterviewPhaseRemarks))
                                    {
                                        Recruitment_BLL.ShowMessage(this, "Information Saved Successfully");
                                        rcmb_BusinessUnit.Items.Clear();
                                        rcmb_Interviewername.Items.Clear();
                                        Rcb_JobReq.Items.Clear();
                                        Rcb_ApplicantID.Items.Clear();
                                        Rcb_PhaseID.Items.Clear();
                                    }
                                    else
                                    {
                                        Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                    }
                                }
                                else
                                {
                                    Recruitment_BLL.ShowMessage(this, "Information Not Saved");
                                }

                                ClearControls();
                                RMP_InterviewAssesment.SelectedIndex = 0;
                                break;
                            default:
                                break;

                        }
                    }
                     else
                     {
                         BLL.ShowMessage(this, " Please Select Applicant Name");
                     }
                    }
                    else
                    {
                        BLL.ShowMessage(this, " Please Select Job Requisition");
                    }
                }

                else
                {
                    BLL.ShowMessage(this, "Please Select Interviewer Name");
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Business Unit");
            }
              
         }
        
        
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion

    #region ComboBox SelectedIndex Changed Code

    protected void Rcb_ApplicantID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            Rcb_PhaseID.Items.Clear();
            if (Rcb_ApplicantID.SelectedItem.Value.ToString() != "0")
            {
                LoadApplicantPhase();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
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
                if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
                {
                    _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32(rcmb_Interviewername.SelectedItem.Value);

                }
                else
                    _obj_Rec_JobRequisition.INTERVIWERNAME = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(Rcb_JobReq.SelectedValue);
                dtJR = Recruitment_BLL.get_JobRequisition(_obj_Rec_JobRequisition);
                if (dtJR.Rows.Count > 0)
                {
                    Session["CTC"] = dtJR.Rows[0]["JOBREQ_APPCTC"];
                }
                Applicants();
            }
            else
                BLL.ShowMessage(this, "Select Job Requisition");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_InterviewAssesmentFianal", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    #endregion 
   
    
}
