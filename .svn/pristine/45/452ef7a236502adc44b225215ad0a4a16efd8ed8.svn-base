using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using RECRUITMENT;
using System.Globalization;
using System.Threading;
using Telerik.Web.UI;

public partial class Recruitment_frm_JobOffers : System.Web.UI.Page
{
    #region References

    SMHR_SALARYSTRUCT _obj_smhr_salaryStruct;
    SMHR_LEAVESTRUCT _obj_Smhr_Leavestruct;
    RECRUITMENT_JOBREQUISITION _obj_Rec_JobRequisition;
    RECRUITMENT_JOBOFFERS _obj_Rec_JobOffers;

    RECRUITMENT_INTERVIEW_PHASE_DEF _obj_Rec_Interview_Phase_Def;

    int JOBREQ_ID = 0;

    #endregion

    //Session["JOBOFFRSREQCODE"]="" ;
    //Session["JOBOFFRSAPPLICANTID"]="" ;

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Job Offer");
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
                    RG_Joboffers.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
                    btn_Update.Visible = false;
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
                RM_Joboffers.SelectedIndex = 0;
                LoadJobRequsitionCode();
                loadsalarystruct();
                loadleavestruct();
                loadgrid();
                Session["Applicant"] = "";
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        Page.Validate();
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    #endregion

    #region LoadJobRequsitionCode

    private void LoadJobRequsitionCode()
    {
        try
        {
            RCMB_JobRequistion.Items.Clear();
            DataTable DT = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Empty;
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DT = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            RCMB_JobRequistion.DataSource = DT;
            RCMB_JobRequistion.DataTextField = "JOBREQ_REQCODE";
            RCMB_JobRequistion.DataValueField = "JOBREQ_ID";
            RCMB_JobRequistion.DataBind();
            RCMB_JobRequistion.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadJobRequsitionCode_Edit()
    {
        try
        {
            RCMB_JobRequistion.Items.Clear();
            DataTable DT = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.Empty1;
            _obj_Rec_JobRequisition.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DT = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            RCMB_JobRequistion.DataSource = DT;
            RCMB_JobRequistion.DataTextField = "JOBREQ_REQCODE";
            RCMB_JobRequistion.DataValueField = "JOBREQ_ID";
            RCMB_JobRequistion.DataBind();
            RCMB_JobRequistion.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadData

    protected void Load_data(string str_jobreq)
    {
        try
        {
            //DataTable dt_Details = new DataTable();
            //_obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            //_obj_Rec_JobRequisition.OPERATION = operation.load;
            //_obj_Rec_JobRequisition.JOBREQ_REQCODE = str_jobreq;
            //dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            //if (dt_Details.Rows.Count > 0)
            //{
            //    //lbl_id.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
            //    RTB_JobRequistionDescription.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQNAME"]);
            //    RTB_Businessunit.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
            //    RTB_RasiedBy.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_RAISEDBY"]);
            //    RTB_Designation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
            //    RTB_Department.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DEPARTMENT"]);  
            //    RTB_Dateofcreation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQDATE"]);
            //}
            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.load;
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(str_jobreq);
            dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            if (dt_Details.Rows.Count > 0)
            {
                //lbl_id.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                RTB_JobRequistionDescription.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQNAME"]);
                RTB_Businessunit.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
                RTB_RasiedBy.Text = Convert.ToString(dt_Details.Rows[0]["RASIEDBY"]);
                RTB_Designation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                RTB_Department.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DEPARTMENT"]);
                RTB_Dateofcreation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_CREATEDDATE"]);
                RTB_Scale.Text = Convert.ToString(dt_Details.Rows[0]["EMPLOYEEGRADE_CODE"]);
                RTB_Directorate.Text = Convert.ToString(dt_Details.Rows[0]["DIRECTORATE_CODE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadApplicant

    private void LoadApplicant(int JOB_REQ)
    {
        try
        {
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = JOB_REQ;
            _obj_Rec_Interview_Phase_Def.Mode = 9;
            RCMB_Applicant.DataSource = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            RCMB_Applicant.DataTextField = "EMPNAME";
            RCMB_Applicant.DataValueField = "APPLICANT_ID";
            RCMB_Applicant.DataBind();
            RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //_obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            //_obj_Rec_InterviewAssessmentForm.MODE = 5;
            //RCMB_Applicant.DataSource = BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            //RCMB_Applicant.DataTextField = "APPLICANT_CODE";
            //RCMB_Applicant.DataValueField = "RESSHT_APPLID";
            //RCMB_Applicant.DataBind();
            //RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadApplicant_Edit(int JOB_REQ)
    {
        try
        {
            _obj_Rec_Interview_Phase_Def = new RECRUITMENT_INTERVIEW_PHASE_DEF();
            _obj_Rec_Interview_Phase_Def.Phase_JobReqID = JOB_REQ;
            _obj_Rec_Interview_Phase_Def.Mode = 21;
            RCMB_Applicant.DataSource = Recruitment_BLL.get_InterviewPhaseDefinition(_obj_Rec_Interview_Phase_Def);
            RCMB_Applicant.DataTextField = "EMPNAME";
            RCMB_Applicant.DataValueField = "APPLICANT_ID";
            RCMB_Applicant.DataBind();
            RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            //_obj_Rec_InterviewAssessmentForm = new RECRUITMENT_INTERVIEWASSESSMENTFORM();
            //_obj_Rec_InterviewAssessmentForm.MODE = 5;
            //RCMB_Applicant.DataSource = BLL.get_InterviewAssessment(_obj_Rec_InterviewAssessmentForm);
            //RCMB_Applicant.DataTextField = "APPLICANT_CODE";
            //RCMB_Applicant.DataValueField = "RESSHT_APPLID";
            //RCMB_Applicant.DataBind();
            //RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadGrid

    protected void loadgrid()
    {
        try
        {
            _obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
            _obj_Rec_JobOffers.OPERATION = operation.Select;
            _obj_Rec_JobOffers.JOBOFFRS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            // _obj_Rec_JobOffers.APPLICANT_ID = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
            DataTable dt = Recruitment_BLL.get_joboffers(_obj_Rec_JobOffers);
            RG_Joboffers.DataSource = dt;
            //  RG_Joboffers.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadsalarystruct

    protected void loadsalarystruct()
    {
        try
        {
            _obj_smhr_salaryStruct = new SMHR_SALARYSTRUCT();
            _obj_smhr_salaryStruct.OPERATION = operation.LOADSALARY;
            _obj_smhr_salaryStruct.SALARYSTRUCT_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_salarystruct = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            // RCB_SalaryStructure.DataSource = BLL.get_SalaryHeaderDetails(_obj_smhr_salaryStruct);
            RCB_SalaryStructure.DataTextField = "SALARYSTRUCT_CODE";
            RCB_SalaryStructure.DataValueField = "SALARYSTRUCT_ID";
            RCB_SalaryStructure.DataSource = dt_salarystruct;
            RCB_SalaryStructure.DataBind();
            RCB_SalaryStructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadleavestruct

    protected void loadleavestruct()
    {
        try
        {
            _obj_Smhr_Leavestruct = new SMHR_LEAVESTRUCT();
            _obj_Smhr_Leavestruct.OPERATION = operation.loadleavestruct;
            _obj_Smhr_Leavestruct.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_leave = BLL.get_LeaveStructHeaderDetails(_obj_Smhr_Leavestruct);
            RCMB_leavestructure.DataTextField = "LEAVESTRUCT_CODE";
            RCMB_leavestructure.DataValueField = "LEAVESTRUCT_ID";
            RCMB_leavestructure.DataSource = dt_leave;
            RCMB_leavestructure.DataBind();
            RCMB_leavestructure.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region load_Requistion

    protected void load_Requistion()
    {
        try
        {
            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.load;
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
            if (dt_Details != null)//Inserted by Apoorva Dec 3
            {
                if (dt_Details.Rows.Count > 0)//Inserted by Apoorva Dec 3
                {
                    dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
                    //lbl_id.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                    RTB_JobRequistionDescription.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQNAME"]);
                    RTB_Businessunit.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
                    RTB_RasiedBy.Text = Convert.ToString(dt_Details.Rows[0]["RASIEDBY"]);
                    RTB_Designation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                    RTB_Department.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DEPARTMENT"]);
                    RTB_Directorate.Text = Convert.ToString(dt_Details.Rows[0]["DIRECTORATE_CODE"]);
                    RTB_Scale.Text = Convert.ToString(dt_Details.Rows[0]["EMPLOYEEGRADE_CODE"]);
                    RTB_OfferSalary.Text = Convert.ToString(dt_Details.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                    RTB_Dateofcreation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_CREATEDDATE"]);
                    JOBREQ_ID = Convert.ToInt32(dt_Details.Rows[0]["JOBREQ_ID"]);
                }
            }
            LoadApplicant(JOBREQ_ID);
            RTB_JobRequistionDescription.Enabled = false;
            RTB_Businessunit.Enabled = false;
            RTB_RasiedBy.Enabled = false;
            RTB_Designation.Enabled = false;
            RTB_Department.Enabled = false;
            RTB_Dateofcreation.Enabled = false;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }


    #endregion

    #region job_applicant

    protected void job_applicant()
    {
        try
        {
            DataTable dt_Details1 = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.loadapplicant;
            _obj_Rec_JobRequisition.APPLICANT = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
            dt_Details1 = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            //lblApcode.Text = Convert.ToString(dt_Details1.Rows[0]["APPLICANT_ID"]);
            if (dt_Details1.Rows.Count != 0)
            {
                RTB_ApplicantName.Text = Convert.ToString(dt_Details1.Rows[0]["EMPNAME"]);
                lblApcode.Text = RCMB_Applicant.SelectedItem.Value;
                Session["Applicant"] = lblApcode.Text.ToString();
            }
            else
            {
                RTB_ApplicantName.Text = string.Empty;
                lblApcode.Text = string.Empty;
                Session["Applicant"] = "";
            }
            RTB_ApplicantName.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void lnk_Add_Command(object sender, EventArgs e)
    {
        try
        {
            clearfields();
            RM_Joboffers.SelectedIndex = 1;
            btn_Submit.Visible = true;
            btn_Update.Visible = false;
            RDP_JoinDate.MinDate = DateTime.Now;
            //RDP_Offerdate.MinDate = DateTime.Now;
            RCMB_JobRequistion.Enabled = true;
            RCMB_Applicant.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RCMB_JobRequistion_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        //_obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
        //_obj_Rec_JobOffers.MODE = 1;
        //_obj_Rec_JobOffers.JOBOFFRS_REQCODE = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
        //DataTable dt_joboffer = BLL.get_OfferLetterCheck(_obj_Rec_JobOffers);
        //if (Convert.ToInt32(dt_joboffer.Rows[0]["count"]) == 0)
        //{
        try
        {
            RTB_RasiedBy.Text = string.Empty;
            RTB_Designation.Text = string.Empty;
            RTB_Dateofcreation.Text = string.Empty;
            RTB_Businessunit.Text = string.Empty;
            RTB_ApplicantName.Text = string.Empty;
            RTB_Department.Text = string.Empty;
            RTB_Directorate.Text = string.Empty;
            RTB_Scale.Text = string.Empty;
            // RCMB_Applicant.ClearSelection();
            RTB_JobRequistionDescription.Text = string.Empty;
            //RCMB_JobRequistion.ClearSelection();
            RCB_SalaryStructure.ClearSelection();
            RCMB_leavestructure.ClearSelection();
            RDP_JoinDate.SelectedDate = null;
            RDP_Offerdate.SelectedDate = null;
            RTB_OfferSalary.Text = string.Empty;
            RCMB_Applicant.ClearSelection();
            RCMB_Applicant.Items.Clear();
            RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            DataTable dt_Details = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.load;
            _obj_Rec_JobRequisition.JOBREQ_ID = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
            dt_Details = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            if (dt_Details.Rows.Count != 0)
            {
                //lbl_id.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_ID"]);
                RTB_JobRequistionDescription.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQNAME"]);
                RTB_Businessunit.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_BUSINESSUNIT_ID"]);
                RTB_RasiedBy.Text = Convert.ToString(dt_Details.Rows[0]["RASIEDBY"]);
                RTB_Designation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DESIGNATION"]);
                RTB_Department.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_DEPARTMENT"]);
                RTB_Dateofcreation.Text = Convert.ToString(dt_Details.Rows[0]["JOBREQ_REQEXPIRY"]);
                RTB_Directorate.Text = Convert.ToString(dt_Details.Rows[0]["DIRECTORATE_CODE"]);
                RTB_Scale.Text = Convert.ToString(dt_Details.Rows[0]["EMPLOYEEGRADE_CODE"]);
                RTB_OfferSalary.Text = Convert.ToString(dt_Details.Rows[0]["EMPLOYEEGRADE_SLAB_AMOUNT"]);
                //RDP_Offerdate.SelectedDate = Convert.ToDateTime(Convert.ToString(dt_Details.Rows[0]["INTREM_JOININGDATE"]));

                JOBREQ_ID = Convert.ToInt32(dt_Details.Rows[0]["JOBREQ_ID"]);
                LoadApplicant(JOBREQ_ID);
            }
            else
            {
                LoadApplicant(JOBREQ_ID);
                job_applicant();
            }
            //}
            //else
            //{

            //    BLL.ShowMessage(this, "Offer Letter already generated");
            //    return;          
            //} 
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void RCMB_Applicant_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            DataTable dt_Details1 = new DataTable();
            _obj_Rec_JobRequisition = new RECRUITMENT_JOBREQUISITION();
            _obj_Rec_JobRequisition.OPERATION = operation.loadapplicant;
            _obj_Rec_JobRequisition.APPLICANT = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
            dt_Details1 = Recruitment_BLL.get_JobReqDetails(_obj_Rec_JobRequisition);
            //lblApcode.Text = Convert.ToString(dt_Details1.Rows[0]["APPLICANT_ID"]);      
            if (dt_Details1.Rows.Count != 0)
            {
                RTB_ApplicantName.Text = Convert.ToString(dt_Details1.Rows[0]["EMPNAME"]);
                lblApcode.Text = RCMB_Applicant.SelectedItem.Value;
                Session["Applicant"] = lblApcode.Text.ToString();
                CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                newCulture.DateTimeFormat.DateSeparator = "/";
                Thread.CurrentThread.CurrentCulture = newCulture;
                RDP_Offerdate.SelectedDate = Convert.ToDateTime(dt_Details1.Rows[0]["INTREM_JOININGDATE"]);

                //RTB_OfferSalary.Text = string.Empty;
                RCB_SalaryStructure.ClearSelection();
                RCMB_leavestructure.ClearSelection();
                RDP_JoinDate.SelectedDate = null;
            }
            else
            {
                RTB_ApplicantName.Text = string.Empty;
                lblApcode.Text = string.Empty;
                Session["Applicant"] = "";
                RDP_Offerdate.SelectedDate = null;
                //RTB_OfferSalary.Text = string.Empty;
                RCB_SalaryStructure.ClearSelection();
                RCMB_leavestructure.ClearSelection();
                RDP_JoinDate.SelectedDate = null;

            }

            RTB_ApplicantName.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
            _obj_Rec_JobOffers.JOBOFFRS_REQCODE = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
            //  _obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
            _obj_Rec_JobOffers.JOBOFFRS_JOINDATE = Convert.ToDateTime(RDP_JoinDate.SelectedDate);
            _obj_Rec_JobOffers.JOBOFFRS_OFFERDATE = Convert.ToDateTime(RDP_Offerdate.SelectedDate);
            if (RCMB_leavestructure.SelectedIndex > 0)
                _obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT = Convert.ToInt32(RCMB_leavestructure.SelectedItem.Value);
            if (RCB_SalaryStructure.SelectedIndex > 0)
                _obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT = Convert.ToInt32(RCB_SalaryStructure.SelectedItem.Value);
            _obj_Rec_JobOffers.JOBOFFRS_OFFERSAL = Convert.ToDecimal(RTB_OfferSalary.Text);
            _obj_Rec_JobOffers.JOBOFFRS_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_JobOffers.JOBOFFRS_CREATEDATE = DateTime.Now;
            _obj_Rec_JobOffers.JOBOFFRS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Rec_JobOffers.JOBOFFRS_LASTMDFDATE = DateTime.Now;
            _obj_Rec_JobOffers.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Session["JOBOFFRS_REQCODE"] = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
            Session["JOBOFFRS_APPLICANT_ID"] = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    _obj_Rec_JobOffers.OPERATION = operation.Check;
                    _obj_Rec_JobOffers.JOBOFFRS_ID = Convert.ToInt32(lbl_id.Text);
                    _obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
                    if (Convert.ToString(Recruitment_BLL.get_Applicant(_obj_Rec_JobOffers).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "Applicant Already Selected");
                        return;
                    }
                    _obj_Rec_JobOffers.OPERATION = operation.Update;
                    if (Recruitment_BLL.set_joboffers(_obj_Rec_JobOffers))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully");

                        //loadgrid();
                        //clearfields();
                        //RM_Joboffers.SelectedIndex = 0;
                        //Response.Redirect("~/Reports/JobofferReport.aspx");
                        Session["JOBOFFRS_REQCODE"] = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
                        Session["JOBOFFRS_APPLICANT_ID"] = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value) + "','" + Convert.ToInt32(RCMB_Applicant.SelectedItem.Value) + "');", true);

                        //  Response.Redirect("~/Reports/JobofferReport.aspx");
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Updated");
                    }
                    loadgrid();
                    RG_Joboffers.DataBind();
                    RM_Joboffers.SelectedIndex = 0;
                    break;
                case "BTN_SUBMIT":

                    _obj_Rec_JobOffers.OPERATION = operation.Check;
                    _obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
                    if (Convert.ToString(Recruitment_BLL.get_Applicant(_obj_Rec_JobOffers).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Applicant Already Selected");

                        return;
                    }
                    _obj_Rec_JobOffers.OPERATION = operation.Insert;
                    if (Recruitment_BLL.set_joboffers(_obj_Rec_JobOffers))
                    {
                        BLL.ShowMessage(this, "Information Saved Successfully");
                        //loadgrid();
                        //clearfields();
                        //RM_Joboffers.SelectedIndex = 0;
                        //Response.Redirect("~/Reports/JobofferReport.aspx");
                        Session["JOBOFFRS_REQCODE"] = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
                        Session["JOBOFFRS_APPLICANT_ID"] = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
                        //  Response.Redirect("~/Reports/JobofferReport.aspx");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value) + "','" + Convert.ToInt32(RCMB_Applicant.SelectedItem.Value) + "');", true);
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }

                    loadgrid();
                    RG_Joboffers.DataBind();
                    RM_Joboffers.SelectedIndex = 0;

                    break;
                default:
                    break;
                //        break;
                //        bool status = BLL.set_joboffers(_obj_Rec_JobOffers);
                // if (status == true)
                // {
                //    BLL.ShowMessage(this, "Information Inserted Succesfully");
                //    //loadgrid();
                //    //clearfields();
                //    //RM_Joboffers.SelectedIndex = 0;
                //    //Response.Redirect("~/Reports/JobofferReport.aspx");
                //    Session["JOBOFFRS_REQCODE"] = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
                //    Session["JOBOFFRS_APPLICANT_ID"] = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
                //    Response.Redirect("~/Reports/JobofferReport.aspx");
                //    return;
                //}
                //else
                //{
                //    BLL.ShowMessage(this, "Unable to Update the record,Execption Occured");
                //    return;
                //}

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearfields();
            RM_Joboffers.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            clearfields();
            _obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
            _obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
            _obj_Rec_JobOffers.OPERATION = operation.Select;
            _obj_Rec_JobOffers.JOBOFFRS_ID = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Recruitment_BLL.get_joboffers(_obj_Rec_JobOffers);
            lbl_id.Text = Convert.ToString(DT.Rows[0]["JOBOFFRS_ID"]);
            //RCMB_JobRequistion.SelectedIndex = RCMB_JobRequistion.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]));
            //LoadApplicant(int JOB_REQ);
            //RCMB_JobRequistion.SelectedIndex = RCMB_JobRequistion.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]));
            LoadJobRequsitionCode_Edit();
            int JOBREQ_ID = Convert.ToInt32(DT.Rows[0]["JOBOFFRS_REQCODE"]);
            RCMB_JobRequistion.SelectedValue = Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]);
            //Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]);      
            load_Requistion();
            LoadApplicant_Edit(JOBREQ_ID);
            // RCMB_JobRequistion. = Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]);
            RCMB_Applicant.SelectedValue = Convert.ToString(DT.Rows[0]["JOBOFFRS_APPLICANT_ID"]);
            //RCMB_Applicant.SelectedItem.Value = Convert.ToString(DT.Rows[0]["JOBOFFRS_APPLICANT_ID"]);
            job_applicant();
            RDP_Offerdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["JOBOFFRS_OFFERDATE"]);
            loadsalarystruct();
            //RCB_SalaryStructure.SelectedIndex = RCB_SalaryStructure.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["JOBOFFRS_SALSTRUCT"]));//
            RCB_SalaryStructure.SelectedValue = Convert.ToString(DT.Rows[0]["JOBOFFRS_SALSTRUCT"]);
            loadleavestruct();
            RCMB_leavestructure.SelectedValue = Convert.ToString(DT.Rows[0]["JOBOFFRS_LEAVESTRUCT"]); //
            //   RCMB_leavestructure.SelectedItem.Value = Convert.ToString(DT.Rows[0]["JOBOFFRS_LEAVESTRUCT"]);
            RDP_JoinDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["JOBOFFRS_JOINDATE"]);
            RTB_OfferSalary.Text = Convert.ToString(Convert.ToDecimal(DT.Rows[0]["JOBOFFRS_OFFERSAL"]));
            string str_jobreq = Convert.ToString(DT.Rows[0]["JOBOFFRS_REQCODE"]);
            //RDP_Offerdate.MinDate = Convert.ToDateTime(DT.Rows[0]["JOBOFFRS_OFFERDATE"]);
            RDP_JoinDate.MinDate = Convert.ToDateTime(DT.Rows[0]["JOBOFFRS_JOINDATE"]);
            Load_data(str_jobreq);
            RM_Joboffers.SelectedIndex = 1;
            btn_Submit.Visible = false;
            btn_Update.Visible = true;
            RTB_JobRequistionDescription.Enabled = false;
            RTB_RasiedBy.Enabled = false;
            RTB_Designation.Enabled = false;
            RTB_Department.Enabled = false;
            RTB_Dateofcreation.Enabled = false;
            RTB_Businessunit.Enabled = false;
            RTB_ApplicantName.Enabled = false;
            RCMB_Applicant.Enabled = false;
            RCMB_JobRequistion.Enabled = false;
            if (Convert.ToString(DT.Rows[0]["APPLICANT_STATUS"]) == "Selected")
            {
                BLL.ShowMessage(this, "Applicant Has Been Already Converted To Employee.");
                btn_Update.Visible = false;
            }
            else
                btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void RG_Joboffers_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            //_obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
            //_obj_Rec_JobOffers.OPERATION = operation.Select;
            //DataTable dt = BLL.get_joboffers(_obj_Rec_JobOffers);
            //RG_Joboffers.DataSource = dt;

            loadgrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void clearfields()
    {
        try
        {
            RTB_RasiedBy.Text = string.Empty;
            RTB_Designation.Text = string.Empty;
            RTB_Dateofcreation.Text = string.Empty;
            RTB_Businessunit.Text = string.Empty;
            RTB_ApplicantName.Text = string.Empty;
            RTB_Department.Text = string.Empty;
            // RCMB_Applicant.ClearSelection();
            RTB_JobRequistionDescription.Text = string.Empty;
            RCMB_JobRequistion.ClearSelection();
            RCB_SalaryStructure.ClearSelection();
            RCMB_leavestructure.ClearSelection();
            RDP_JoinDate.SelectedDate = null;
            RDP_Offerdate.SelectedDate = null;
            RTB_OfferSalary.Text = string.Empty;
            RCMB_Applicant.ClearSelection();
            RCMB_Applicant.Items.Clear();
            RCMB_Applicant.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            RDP_JoinDate.MinDate = Convert.ToDateTime("01-01-1900");
            RTB_Directorate.Text = string.Empty;
            RTB_Scale.Text = string.Empty;
            //RDP_Offerdate.MinDate = Convert.ToDateTime("01-01-1900");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_JobOffers", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void btn_Update_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        _obj_Rec_JobOffers = new RECRUITMENT_JOBOFFERS();
    //        _obj_Rec_JobOffers.OPERATION = operation.Update;
    //        _obj_Rec_JobOffers.JOBOFFRS_ID = Convert.ToInt32(lbl_id.Text);
    //        _obj_Rec_JobOffers.JOBOFFRS_REQCODE = Convert.ToInt32(RCMB_JobRequistion.SelectedItem.Value);
    //        _obj_Rec_JobOffers.JOBOFFRS_APPLICANT_ID = Convert.ToInt32(RCMB_Applicant.SelectedItem.Value);
    //        _obj_Rec_JobOffers.JOBOFFRS_JOINDATE = Convert.ToDateTime(RDP_JoinDate.SelectedDate);
    //        _obj_Rec_JobOffers.JOBOFFRS_OFFERDATE = Convert.ToDateTime(RDP_Offerdate.SelectedDate);
    //        _obj_Rec_JobOffers.JOBOFFRS_LEAVESTRUCT = Convert.ToInt32(RCMB_leavestructure.SelectedItem.Value);
    //        _obj_Rec_JobOffers.JOBOFFRS_SALSTRUCT = Convert.ToInt32(RCB_SalaryStructure.SelectedItem.Value);
    //        _obj_Rec_JobOffers.JOBOFFRS_OFFERSAL = Convert.ToDecimal(RTB_OfferSalary.Text);
    //        _obj_Rec_JobOffers.JOBOFFRS_LASTMDFBY = 2; // ### Need to Get the Session
    //        _obj_Rec_JobOffers.JOBOFFRS_LASTMDFDATE = DateTime.Now;
    //        bool status = BLL.set_joboffers(_obj_Rec_JobOffers);
    //        if (status == true)
    //        {
    //            BLL.ShowMessage(this, "information Updated Succesfully");
    //            loadgrid();
    //            clearfields();
    //            RM_Joboffers.SelectedIndex = 0;
    //            return;
    //        }
    //        else
    //        {
    //            BLL.ShowMessage(this, "Unable to Update the record,Execption Occured");
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        BLL.ShowMessage(this, ex.Message.ToString());
    //        return;
    //    }   
    //}
}
