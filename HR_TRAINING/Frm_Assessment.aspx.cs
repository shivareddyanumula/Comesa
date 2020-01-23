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

public partial class HR_TRAINING_Frm_Assessment : System.Web.UI.Page
{
    RadioButtonList rbl_Options = new RadioButtonList();
    Label lbl_id = new Label();
    DataTable dt_QuestionPaper = new DataTable();
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Take Assessment");//TRAINING APPROVAL");
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
                    RG_Assessments.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btnSave.Visible = false;
                    //  btn_Update.Visible = false;
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

                LoadCombos();
                dl_QuestionPaper.Visible = false;
                Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
                Session["time"] = null;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }


    private void LoadCombos()
    {


        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_Course.DataSource = BLL.get_Course(_obj_Course);
            rc_Course.DataTextField = "COURSE_NAME";
            rc_Course.DataValueField = "COURSE_ID";
            rc_Course.DataBind();
            rc_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rc_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void radCourse_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            clearControls();
            RadGrid1.Visible = false;
            RG_Assessments.Visible = false;
            if (string.Compare(rc_Course.SelectedItem.Text, "Select", true) != 0)
            {
                SMHR_COURSESCHEDULE _obj_Smhr_TrgRqst = new SMHR_COURSESCHEDULE();
                _obj_Smhr_TrgRqst.OPERATION = operation.Select3;
                _obj_Smhr_TrgRqst.COURSESCHEDULE_COURSEID = Convert.ToInt32(rc_Course.SelectedValue);
                _obj_Smhr_TrgRqst.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//YYY
                rc_CourseSchedule.DataSource = BLL.get_CourseSchedule(_obj_Smhr_TrgRqst);
                rc_CourseSchedule.DataValueField = "CourseSchedule_ID";
                rc_CourseSchedule.DataTextField = "CourseSchedule_Name";
                rc_CourseSchedule.DataBind();
                rc_CourseSchedule.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_Upload_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lblOfflineAssID.Text = e.CommandArgument.ToString();
            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
                if (string.Compare(RadGrid1.Items[i].Cells[2].Text, e.CommandArgument.ToString(), true) == 0)
                {
                    lblOffAssessmentName.Text = RadGrid1.Items[i].Cells[3].Text;
                }
            }
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 3;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
            oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Get_ID;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ID = Convert.ToInt32(e.CommandArgument);
            DataTable dt = BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT);
            lblCurrentDate.Text = DateTime.Now.ToString();
            lblExamID.Text = dt.Rows[0]["TRAINING_ASSESSMENT_ID"].ToString();
            lblCourseName.Text = dt.Rows[0]["COURSE_NAME"].ToString();
            lblAssessment.Text = dt.Rows[0]["TRAINING_ASSESSMENT_NAME"].ToString();
            lblMarks.Text = dt.Rows[0]["TRAINING_ASSESSMENT_NOOFQUESTIONS"].ToString();
            lblNoOfQuestions.Text = dt.Rows[0]["TRAINING_ASSESSMENT_NOOFQUESTIONS"].ToString();
            LoadQuestionPaper(dt.Rows[0]["TRAINING_ASSESSMENT_QUESTIONS"].ToString());
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 1;
            dl_QuestionPaper.Visible = true;
            tmExam.Enabled = true;
            hdnTime.Value = dt.Rows[0]["TRAINING_ASSESSMENT_TIME"].ToString();
            if (Session["time"] == null)
            {
                TimerStart();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadQuestionPaper(string questions)
    {
        try
        {
            SMHR_TRAINING_QUESTIONBANK oSMHR_TRAINING_QUESTIONBANK = new SMHR_TRAINING_QUESTIONBANK();
            oSMHR_TRAINING_QUESTIONBANK.OPERATION = operation.Select3;
            oSMHR_TRAINING_QUESTIONBANK.QuestionBank_Question = questions;
            DataTable dt = BLL.get_QuestionBank(oSMHR_TRAINING_QUESTIONBANK);
            Session["Questions"] = dt;
            PagedDataSource objPagedDataSource = new PagedDataSource();
            objPagedDataSource.DataSource = dt.DefaultView;
            objPagedDataSource.CurrentPageIndex = 0;
            objPagedDataSource.PageSize = 1;
            objPagedDataSource.AllowPaging = true;
            dl_QuestionPaper.DataSource = objPagedDataSource;
            //dl_QuestionPaper.ItemCommand += new DataListCommandEventHandler(dl_QuestionPaper_ItemCommand);
            dl_QuestionPaper.DataBind();
            Session["PagedDataSource"] = objPagedDataSource;
            btnPrevious.Enabled = false;
            if (dt.Rows.Count > 1)
                btnNext.Enabled = true;
            else
                btnNext.Enabled = false;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindCourseCategory()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rc_Course.DataSource = BLL.get_Course(_obj_Course);
            rc_Course.DataTextField = "COURSE_NAME";
            rc_Course.DataValueField = "COURSE_ID";
            rc_Course.DataBind();
            rc_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void clearControls()
    {
        try
        {
            rc_CourseSchedule.Items.Clear();
            rc_CourseSchedule.ClearSelection();
            rc_CourseSchedule.Text = string.Empty;
            rdExamType.ClearSelection();
            RG_Assessments.Visible = false;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void dl_QuestionPaper_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataTable dt_Options = (DataTable)Session["Questions"];
            rbl_Options = (RadioButtonList)e.Item.FindControl("rbl_options");
            lbl_id = (Label)e.Item.FindControl("lbl_questionID");
            DataRow[] drs = dt_Options.Select("QUESTIONBANK_ID in (" + lbl_id.Text + ")");
            rbl_Options.Items.Insert(0, new ListItem(drs[0]["QUESTIONBANK_OPTION1"].ToString(), "1"));
            rbl_Options.Items.Insert(1, new ListItem(drs[0]["QUESTIONBANK_OPTION2"].ToString(), "2"));
            rbl_Options.Items.Insert(2, new ListItem(drs[0]["QUESTIONBANK_OPTION3"].ToString(), "3"));
            rbl_Options.Items.Insert(3, new ListItem(drs[0]["QUESTIONBANK_OPTION4"].ToString(), "4"));
            if (string.Compare(drs[0]["Selected"].ToString(), "0", true) != 0)
                rbl_Options.SelectedIndex = Convert.ToInt32(drs[0]["Selected"]) - 1;
            rbl_Options.DataBind();
        }
        catch (Exception ex)
        {
            // Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rbl_options_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadGrid1.Visible = true;
            RG_Assessments.Visible = true;
            if (dl_QuestionPaper != null)
            {
                if (dl_QuestionPaper.Items.Count > 0)
                {

                    dt_QuestionPaper = Session["Questions"] as DataTable;
                    foreach (DataListItem dl in dl_QuestionPaper.Items)
                    {
                        Label lblQID = dl.FindControl("lbl_questionID") as Label;
                        RadioButtonList rbl = dl.FindControl("rbl_options") as RadioButtonList;
                        DataRow[] dr = dt_QuestionPaper.Select("QUESTIONBANK_ID in (" + lblQID.Text + ")");
                        if (dr.Length == 1)
                        {
                            dr[0]["Selected"] = rbl.SelectedItem.Value;
                        }
                    }
                    Session["Questions"] = dt_QuestionPaper;
                }
            }
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rdExamType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rc_Course.SelectedIndex == 0)
            {
                rdExamType.ClearSelection();
                BLL.ShowMessage(this, "Please select Course");
                return;
            }
            if (rc_CourseSchedule.SelectedIndex == 0)
            {
                rdExamType.ClearSelection();
                BLL.ShowMessage(this, "Please select Course Schedule");
                return;
            }
            loadGrid();
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            PagedDataSource objPagedDataSource = new PagedDataSource();
            objPagedDataSource = (PagedDataSource)Session["PagedDataSource"];
            objPagedDataSource.CurrentPageIndex = objPagedDataSource.CurrentPageIndex + 1;
            objPagedDataSource.PageSize = 1;
            objPagedDataSource.AllowPaging = true;
            dl_QuestionPaper.DataSource = objPagedDataSource;
            dl_QuestionPaper.DataBind();
            Session["PagedDataSource"] = objPagedDataSource;
            if (objPagedDataSource.CurrentPageIndex == ((DataView)(objPagedDataSource.DataSource)).Count - 1)
            {
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
            else
            {
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            PagedDataSource objPagedDataSource = new PagedDataSource();
            objPagedDataSource = (PagedDataSource)Session["PagedDataSource"];
            objPagedDataSource.CurrentPageIndex = objPagedDataSource.CurrentPageIndex - 1;
            objPagedDataSource.PageSize = 1;
            objPagedDataSource.AllowPaging = true;
            dl_QuestionPaper.DataSource = objPagedDataSource;
            dl_QuestionPaper.DataBind();
            Session["PagedDataSource"] = objPagedDataSource;
            if (objPagedDataSource.CurrentPageIndex == 0)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnEndExam_Click(object sender, EventArgs e)
    {
        try
        {
            dt_QuestionPaper = Session["Questions"] as DataTable;
            DataRow[] dr = dt_QuestionPaper.Select("Selected = 0");

            if (dr.Length != 0)
            {
                if (Session["time"] != null)
                {
                    BLL.ShowMessage(this, "Please answer all questions");
                    return;
                }
            }

            SMHR_ASSESSMENT_RESULT oSMHR_ASSESSMENT_RESULT = new SMHR_ASSESSMENT_RESULT();
            dr = dt_QuestionPaper.Select("QUESTIONBANK_ANSWER=Selected");
            double result = (Convert.ToDouble(dr.Length) / Convert.ToDouble(dt_QuestionPaper.Rows.Count)) * 100;
            lblPercentage.Text = (result).ToString() + "%";
            lblGainedMarks.Text = dr.Length.ToString();
            SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
            oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Select_New;
            oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ID = Convert.ToInt32(lblExamID.Text);
            oSMHR_TRAINING_ONLINEASSESSMENT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT);
            if (result >= Convert.ToInt32(dt.Rows[0]["TRAINING_ASSESSMENT_MINMARKS"]))
            {
                lblResult.Text = "Pass";
                oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_RESULT = true;
            }
            else
            {
                lblResult.Text = "Fail";
                oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_RESULT = false;
            }

            oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_ASSESSMENTID = Convert.ToInt32(lblExamID.Text);
            oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_DATE = DateTime.Now;
            oSMHR_ASSESSMENT_RESULT.ASSESSMENTRESULT_MARKS = dr.Length;
            oSMHR_ASSESSMENT_RESULT.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            oSMHR_ASSESSMENT_RESULT.CREATEDDATE = DateTime.Now;
            oSMHR_ASSESSMENT_RESULT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_ASSESSMENT_RESULT.OPERATION = operation.Insert;
            BLL.set_AssessmentResult(oSMHR_ASSESSMENT_RESULT);
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 2;
            Session["time"] = null;
            tmExam.Enabled = false;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void loadGrid()
    {
        try
        {
            if (string.Compare(rdExamType.SelectedValue, "Online", true) == 0)
            {
                SMHR_TRAINING_ONLINEASSESSMENT oSMHR_TRAINING_ONLINEASSESSMENT = new SMHR_TRAINING_ONLINEASSESSMENT();
                oSMHR_TRAINING_ONLINEASSESSMENT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_COURSE_ID = Convert.ToInt32(rc_Course.SelectedValue);
                oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_COURSESCHEDULE_ID = Convert.ToInt32(rc_CourseSchedule.SelectedValue);
                oSMHR_TRAINING_ONLINEASSESSMENT.TRAINING_ASSESSMENT_ID = Convert.ToInt32(Session["EMP_ID"]);
                oSMHR_TRAINING_ONLINEASSESSMENT.OPERATION = operation.Select2;
                DataTable dt = BLL.get_OnlineAssessment(oSMHR_TRAINING_ONLINEASSESSMENT);
                if (dt.Columns.Count > 1)
                {
                    RG_Assessments.DataSource = dt;
                    RG_Assessments.DataBind();
                }
                else
                {
                    RG_Assessments.DataSource = null;
                    RG_Assessments.DataBind();
                }

                RG_Assessments.Visible = true;
                RadGrid1.Visible = false;
            }
            else
            {
                RadGrid1.Visible = true;
                RG_Assessments.Visible = false;
                SMHR_TRAINING_OFFLINEASSESSMENTS _obj_SMHR_Offlineassesments = new SMHR_TRAINING_OFFLINEASSESSMENTS();
                _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_COURSEID = Convert.ToInt32(rc_Course.SelectedValue);
                _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_COURSESCHEDULEID = Convert.ToInt32(rc_CourseSchedule.SelectedValue);
                _obj_SMHR_Offlineassesments.OFFLINEASSESSMENT_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_SMHR_Offlineassesments.OPERATION = operation.Select2;
                DataTable DT = BLL.get_OfflineAssessment(_obj_SMHR_Offlineassesments);
                if (DT.Columns.Count > 1)
                {
                    RadGrid1.DataSource = DT;
                    RadGrid1.DataBind();
                }
                else
                {
                    RadGrid1.DataSource = null;
                    RadGrid1.DataBind();
                }

                RG_Assessments.Visible = false;
                RadGrid1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void TimerStart()
    {
        try
        {
            Session["time"] = DateTime.Now.AddSeconds(Convert.ToDouble(hdnTime.Value) * 60);
            dl_QuestionPaper.Enabled = true;
            hdnTime.Value = string.Empty;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void tmExam_Tick(object sender, EventArgs e)
    {
        try
        {
            if (Session["time"] != null)
            {

                TimeSpan time1 = new TimeSpan();
                time1 = (DateTime)Session["time"] - DateTime.Now;

                if (time1.Minutes <= 0 && time1.Seconds <= 0)
                {
                    dl_QuestionPaper.Enabled = false;
                    btnNext.Enabled = btnPrevious.Enabled = false;

                    BLL.ShowMessage(this, "Thank you for taking the exam. Please click on the End Exam to submit your answers. Do NOT refresh the page or use the back button on the browser!!!");
                    lblTimer.Text = "0:00";
                    tmExam.Enabled = false;
                    Session["time"] = null;
                }

                else
                {
                    lblTimer.Text = "Time Left " + ":" + time1.Minutes.ToString() + ":" + time1.Seconds.ToString();
                }

            }
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rc_CourseSchedule_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rdExamType.ClearSelection();
            RG_Assessments.Visible = false;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SMHR_OFFLINEASSESSMENT_RESULT oSMHR_OFFLINEASSESSMENT_RESULT = new SMHR_OFFLINEASSESSMENT_RESULT();
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_ASSESSMENTID = Convert.ToInt32(lblOfflineAssID.Text);
            oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_EMPID = Convert.ToInt32(Session["EMP_ID"]);
            if (fileupload_upload.HasFile)
            {
                string pdfName = lblOffAssessmentName.Text + "_" + Guid.NewGuid().ToString() + "_FBIO" + fileupload_upload.FileName;
                string strPath = "~/EmpUploads/" + pdfName;
                fileupload_upload.PostedFile.SaveAs(Server.MapPath("~/EmpUploads/") + pdfName);
                oSMHR_OFFLINEASSESSMENT_RESULT.OFFLINE_RESULTDOC = strPath;
            }
            else
            {
                BLL.ShowMessage(this, "Please select file to upload");
                return;
            }
            oSMHR_OFFLINEASSESSMENT_RESULT.CREATEDBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            oSMHR_OFFLINEASSESSMENT_RESULT.CREATEDDATE = DateTime.Now;
            oSMHR_OFFLINEASSESSMENT_RESULT.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]); // ### Need to Get the Session
            oSMHR_OFFLINEASSESSMENT_RESULT.LASTMDFDATE = DateTime.Now;
            oSMHR_OFFLINEASSESSMENT_RESULT.OPERATION = operation.Insert;
            if (BLL.set_OfflineAssessmentResult(oSMHR_OFFLINEASSESSMENT_RESULT))
            {
                BLL.ShowMessage(this, "Information Updated Successfully");
                Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
            }
            else
            {
                BLL.ShowMessage(this, "Information Not Saved");
            }

            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
            loadGrid();
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_TRGFEEDABCK_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            //Utils.HandleWebException(ex, this);
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Assessment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}