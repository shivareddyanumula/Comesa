using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using System.Text;
using Telerik.Web.UI;
using SPMS;
public partial class Training_frm_TrainingFeedBack : System.Web.UI.Page
{
    //SMHR_JOBREQUISITION _obj_Smhr_JobReqDetails = new SMHR_JOBREQUISITION();
    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
    SMHR_FEEDBACK_QUESTION _obj_SMHR_FEEDBACK_QUESTION = new SMHR_FEEDBACK_QUESTION();
    SMHR_TRAININGFEEDBACK _obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Assign Feedback");//ASSIGN FEEDBACK");
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
                    Rg_TrgFeedback.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
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
                LoadGrid();
                Rg_TrgFeedback.DataBind();
                Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }





    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            //rcm_employee.Visible = false;
            LoadCombos();

            //lbl_assign.Visible = false;
            btn_Cancel.Visible = true;
            Rp_TRGFEEDABCK_VIEWMAIN.Visible = false;
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 1;
            RP_trgfeedback_VIEWDETAILS.Visible = true;
            rcmb_CourseSchedule.SelectedIndex = 0;
            rtxt_AssessmentName.Text = string.Empty;
            rtxt_FeedbackDescription.Text = string.Empty;
            rtxt_AssessmentName.Enabled = true;
            rcmb_CC.Enabled = true;
            rcmb_CourseName.Enabled = true;
            rcmb_CourseSchedule.Enabled = true;
            btn_Save.Visible = true;
            btn_Update.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);

            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Rg_TrgFeedback_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

        //_obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Select;

        //DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);
        //if (dt.Rows.Count != 0)
        //{
        //Rg_TrgFeedback.DataSource = dt;
        LoadGrid();
        //}
    }
    protected void LoadGrid()
    {
        try
        {
            SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
            oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Select;
            oSMHR_TRAINING_ONLINEASSESSMENT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT);
            if (dt.Rows.Count != 0)
            {
                Rg_TrgFeedback.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_TrgFeedback.DataSource = dt1;

                Rg_TrgFeedback.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    protected void lnk_FEEDBACK_ID_Command(object sender, CommandEventArgs e)
    {

        try
        {
            ClearControls();
            SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
            oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Get;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            lbl_id.Text = Convert.ToString(e.CommandArgument);

            DataTable DT = BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT);
            if (DT.Rows.Count != 0)
            {
                LoadCombos();
                rcmb_CC.SelectedIndex = rcmb_CC.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_COURSECATEGORY_ID"]));
                rcmb_CC_SelectedIndexChanged(null, null);
                rcmb_CourseName.SelectedIndex = rcmb_CourseName.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_COURSE_ID"]));
                rcmb_CourseName_SelectedIndexChanged(null, null);
                rcmb_CourseSchedule.SelectedIndex = rcmb_CourseSchedule.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_COURSESCHEDULE_ID"]));
                radChapters.SelectedIndex = radChapters.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_CHAPTER_ID"]));
                radChapters_SelectedIndexChanged(null, null);
                BindSelectedQuestions(Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_QUESTIONS"]));
                rtxt_AssessmentName.Text = Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_NAME"]);
                rtxt_FeedbackDescription.Text = Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_DESC"]);
                radNoOfQuestions.Text = Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_NOOFQUESTIONS"]);
                radMarks.Text = Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_MINMARKS"]);
                radAssessmentTime.Text = Convert.ToString(DT.Rows[0]["TRAINING_ASSESSMENT_TIME"]);
                radStartdate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TRAINING_ASSESSMENT_STARTDATE"]);
                radEndDate.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TRAINING_ASSESSMENT_ENDDATE"]);
                radStartTime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TRAINING_ASSESSMENT_STARTTIME"]);
                radEndTime.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TRAINING_ASSESSMENT_ENDTIME"]);

                rcmb_CC.Enabled = false;
                rcmb_CourseName.Enabled = false;
                rcmb_CourseSchedule.Enabled = false;

                Rm_TRGFEEDABCK_PAGE.SelectedIndex = 1;
                btn_Update.Visible = true;
                btn_Save.Visible = false;
                btn_Cancel.Visible = true;
                rtxt_AssessmentName.Enabled = false;
                //rtxt_FeedbackDescription.Enabled = false;
                Rp_TRGFEEDABCK_VIEWMAIN.Visible = false;
                RP_trgfeedback_VIEWDETAILS.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void BindSelectedQuestions(string selectedQuestions)
    {
        try
        {
            string[] strQuestions = selectedQuestions.Split(',');
            foreach (RadListBoxItem rl in radQuestions.Items)
            {
                if (strQuestions.Contains(rl.Value))
                    rl.Checked = true;
                else
                    rl.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    private void LoadCombos()
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            SMHR_MASTERS _obj_Smhr_Masters = new SMHR_MASTERS();
            //Course Category
            rcmb_CC.Items.Clear();
            _obj_Smhr_Masters.MASTER_TYPE = "COURSE";
            _obj_Smhr_Masters.OPERATION = operation.Select1;
            _obj_Smhr_Masters.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_CC.DataSource = BLL.get_MasterRecords(_obj_Smhr_Masters);
            rcmb_CC.DataTextField = "HR_MASTER_CODE";
            rcmb_CC.DataValueField = "HR_MASTER_ID";
            rcmb_CC.DataBind();
            rcmb_CC.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (radQuestions.CheckedItems.Count == 0)
            {
                BLL.ShowMessage(this, "Please select Questions");
                return;
            }
            if (Convert.ToInt32(radNoOfQuestions.Text) != radQuestions.CheckedItems.Count)
            {
                BLL.ShowMessage(this, "No Of Questions and Selected Questions Not matched");
                return;
            }
            SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_COURSECATEGORY_ID = Convert.ToInt32(rcmb_CC.SelectedValue);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_COURSE_ID = Convert.ToInt32(rcmb_CourseName.SelectedValue);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_COURSESCHEDULE_ID = Convert.ToInt32(rcmb_CourseSchedule.SelectedValue);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_NAME = rtxt_AssessmentName.Text;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_DESC = rtxt_FeedbackDescription.Text;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_CHAPTER_ID = Convert.ToInt32(radChapters.SelectedValue);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_NOOFQUESTIONS = Convert.ToInt32(radNoOfQuestions.Text);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_MINMARKS = Convert.ToInt32(radMarks.Text);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_TIME = Convert.ToInt32(radAssessmentTime.Text);
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_STARTDATE = (DateTime)radStartdate.SelectedDate;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_STARTTIME = (DateTime)radStartTime.SelectedDate;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ENDDATE = (DateTime)radEndDate.SelectedDate;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ENDTIME = (DateTime)radEndTime.SelectedDate;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_QUESTIONS = GetSelectedQuestions();

            oSMHR_TRAINING_ONLINEASSESSMENT.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            oSMHR_TRAINING_ONLINEASSESSMENT.CREATEDDATE = DateTime.Now;
            oSMHR_TRAINING_ONLINEASSESSMENT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_TRAINING_ONLINEASSESSMENT.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            oSMHR_TRAINING_ONLINEASSESSMENT.LASTMDFDATE = DateTime.Now;
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_UPDATE":
                    oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Update;
                    oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ID = Convert.ToInt32(lbl_id.Text);
                    if (BLL.set_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                case "BTN_SAVE":
                    oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Assessment Name with this Name Already Exists");
                        return;
                    }
                    oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Insert;
                    if (BLL.set_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;
                default:
                    break;
            }
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
            LoadGrid();
            Rg_TrgFeedback.DataBind();
            Rg_TrgFeedback.Visible = true;
            Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private string GetSelectedQuestions()
    {
        StringBuilder sb = new StringBuilder();
        foreach (RadListBoxItem rl in radQuestions.CheckedItems)
        {
            sb.Append(rl.Value + ",");
        }
        return sb.ToString().Remove(sb.ToString().Length - 1);
    }

    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            Session["TR_ID"] = Convert.ToInt32(rcmb_CourseName.SelectedValue);
            Session["CATEGORY"] = Convert.ToString(rcmb_CourseSchedule.SelectedValue);
            Session["BU_ID"] = Convert.ToInt32(rcmb_CC.SelectedValue);
            Session["FEEDBACK_NAME"] = BLL.ReplaceQuote(Convert.ToString(rtxt_AssessmentName.Text));

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad() { WinOpen_image(); }", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RP_trgfeedback_VIEWDETAILS.Visible = false;
            Rp_TRGFEEDABCK_VIEWMAIN.Visible = true;
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

            LoadGrid();
            Rg_TrgFeedback.DataBind();
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;


            //LoadGrid();
            //Rg_TrgFeedback.Visible = true;
            //Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_CourseName.Items.Clear();
            rcmb_CourseName.ClearSelection();
            rcmb_CourseName.Text = string.Empty;
            rcmb_CourseSchedule.Items.Clear();
            rcmb_CourseSchedule.ClearSelection();
            rcmb_CourseSchedule.Text = string.Empty;
            rtxt_AssessmentName.Text = string.Empty;
            radChapters.Items.Clear();
            radChapters.ClearSelection();
            radChapters.Text = string.Empty;
            radNoOfQuestions.Text = string.Empty;
            radAssessmentTime.Text = string.Empty;
            radMarks.Text = string.Empty;
            radStartdate.SelectedDate = null;
            radEndDate.SelectedDate = null;
            radStartTime.SelectedDate = null;
            radEndTime.SelectedDate = null;
            radQuestions.Items.Clear();
            radQuestions.ClearChecked();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_FeedBack_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {

            //assign feedback to trainer of that trg
            if (rcmb_CourseSchedule.SelectedItem.Text == "Trainer")
            {
                SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();


                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_AssessmentName.Text));
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_CC.SelectedItem.Value);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_CourseName.SelectedItem.Value);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_CourseSchedule.SelectedItem.Text);

                DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

                SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
                _obj_Smhr_Trner.Mode = 5;
                _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_CourseName.SelectedItem.Value);
                DataTable dt1 = BLL.get_TRAINer(_obj_Smhr_Trner);


                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 2;
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                //if trg is external then inplace of trainer we are passing hr employeeid
                if (dt1.Rows.Count != 0)
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                }
                else
                {//IF TRAINER EXTERNAL WE HAVE TO GIVE HR ID

                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.Mode = 21;
                    _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable DT45 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (DT45.Rows.Count != 0)
                    {
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                    }

                    else
                    {
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                    }
                }

                DataTable dt2 = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                if (dt2.Rows.Count != 0)
                {

                    BLL.ShowMessage(this, "Tarining Already Assigned To Employee");
                    return;
                }
                else
                {
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                    if (dt1.Rows.Count != 0)
                    {
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(dt1.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]);
                    }

                    else
                    {
                        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                        _obj_Smhr_TrgRqst.Mode = 21;
                        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable DT455 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                        if (DT455.Rows.Count != 0)
                        {
                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                        }

                        else
                        {
                            _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = 0;
                        }

                    }
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                    bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Feedback Assigned Successfully");
                        LoadGrid();
                        Rg_TrgFeedback.DataBind();
                        Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                        return;
                    }

                }
            }
            else if (rcmb_CourseSchedule.SelectedItem.Text == "Trainee")
            {

                SMHR_ASSIGNFEEDBACK_EMPLOYEE _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();

                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 6;
                _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(lbl_id.Text);

                DataTable dttrnee = BLL.get__SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);

                if (dttrnee.Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Tarining Already Assigned To Trainee");
                    return;

                }
                else
                {
                    SMHR_TRAINEE _obj_Smhr_TrnEE = new SMHR_TRAINEE();
                    _obj_Smhr_TrnEE.Mode = 5;
                    _obj_Smhr_TrnEE.TRAINEE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_TrnEE.TRAINEE_TR_ID = Convert.ToInt32(rcmb_CourseName.SelectedItem.Value);
                    DataTable dtemp = BLL.get_TRAINEE(_obj_Smhr_TrnEE);
                    //  for (int i = 0; i <= dtemp.Rows.Count ; i++)
                    //  {
                    foreach (DataRow item in dtemp.Rows)
                    {
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE1;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(rcmb_CC.SelectedItem.Value);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(rcmb_CourseName.SelectedItem.Value);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(rcmb_CourseSchedule.SelectedItem.Text);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = BLL.ReplaceQuote(Convert.ToString(rtxt_AssessmentName.Text));
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt5 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE = new SMHR_ASSIGNFEEDBACK_EMPLOYEE();
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.Mode = 3;

                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGNFEED_FEEBAK_ID = Convert.ToInt32(dt5.Rows[0]["FEEDBACK_ID"]);
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_EMP_ID = Convert.ToInt32(item["TRAINEE_EMPID"]);
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE.ASSIGN_CREATEDDATE = DateTime.Now;
                        bool status = BLL.set_SMHR_ASSIGNFEEDBACK_EMPLOYEE(_obj_SMHR_ASSIGNFEEDBACK_EMPLOYEE);
                        if (status == true)
                        {
                            //BLL.ShowMessage(this, "Feedback Assigned Successfully");
                            //LoadGrid();
                            //Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;

                        }
                        //BLL.ShowMessage(this, "Feedback Assigned Successfully");
                        LoadGrid();
                        Rg_TrgFeedback.DataBind();

                        Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_CC_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_CC.SelectedIndex > 0)
            {
                SMHR_COURSE _obj_Smhr_Course = new SMHR_COURSE();
                _obj_Smhr_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_Course.COURSE_CATEGORYID = rcmb_CC.SelectedValue;
                _obj_Smhr_Course.OPERATION = operation.Get;
                DataTable DT = BLL.get_Course(_obj_Smhr_Course);
                rcmb_CourseName.DataSource = DT;
                rcmb_CourseName.DataValueField = "COURSE_ID";
                rcmb_CourseName.DataTextField = "COURSE_NAME";
                rcmb_CourseName.DataBind();
                rcmb_CourseName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_CourseName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (string.Compare(rcmb_CourseName.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_COURSESCHEDULE _obj_Smhr_TrgRqst = new SMHR_COURSESCHEDULE();
                _obj_Smhr_TrgRqst.OPERATION = operation.Course;
                _obj_Smhr_TrgRqst.COURSESCHEDULE_COURSEID = Convert.ToInt32(rcmb_CourseName.SelectedValue);
                _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
                rcmb_CourseSchedule.DataSource = BLL.get_CourseSchedule(_obj_Smhr_TrgRqst);
                rcmb_CourseSchedule.DataValueField = "CourseSchedule_ID";
                rcmb_CourseSchedule.DataTextField = "CourseSchedule_Name";
                rcmb_CourseSchedule.DataBind();
                rcmb_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


                SMHR_CHAPTERS _obj_Chapter = new SMHR_CHAPTERS();
                _obj_Chapter.OPERATION = operation.Select1;
                _obj_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Chapter.CHAPTER_COURSE_ID = Convert.ToInt32(rcmb_CourseName.SelectedValue);
                radChapters.DataSource = BLL.get_Chapter(_obj_Chapter);
                radChapters.DataTextField = "CHAPTER_NAME";
                radChapters.DataValueField = "CHAPTER_ID";
                radChapters.DataBind();
                radChapters.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void radChapters_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_TRAINING_QUESTIONBANK _obj_Question = new SMHR_TRAINING_QUESTIONBANK();
            _obj_Question.OPERATION = operation.Select2;
            _obj_Question.QuestionBank_ChapterID = Convert.ToInt32(radChapters.SelectedValue);
            _obj_Question.QuestionBank_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            radQuestions.DataSource = BLL.get_QuestionBank(_obj_Question);
            radQuestions.DataTextField = "Questionbank_question";
            radQuestions.DataValueField = "QuestionBank_ID";
            radQuestions.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBack", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
