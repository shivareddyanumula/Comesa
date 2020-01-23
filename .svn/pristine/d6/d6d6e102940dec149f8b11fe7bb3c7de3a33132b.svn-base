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

public partial class Training_frm_TrainingFeedBackQuestions : System.Web.UI.Page
{
    SMHR_TRAINING_QUESTIONBANK _obj_SMHR_QuestionBank = new SMHR_TRAINING_QUESTIONBANK();
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Training Feedback Questions");//TRAINING FEEDBACK QUESTIONS");
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
                    Rg_Feedback.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Rg_Feedback.DataBind();
                Page.Validate();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }




    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    public void LoadGrid()
    {
        try
        {

            _obj_SMHR_QuestionBank.OPERATION = operation.Select;

            _obj_SMHR_QuestionBank.QuestionBank_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_QuestionBank(_obj_SMHR_QuestionBank);
            if (dt.Rows.Count != 0)
            {
                Rg_Feedback.DataSource = dt;
            }
            else
            {
                DataTable dt1 = new DataTable();
                Rg_Feedback.DataSource = dt1;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Rg_Feedback_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_SMHR_QuestionBank.QuestionBank_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_QuestionBank.QuestionBank_courseID = Convert.ToInt32(rcmb_Course.SelectedValue);
            _obj_SMHR_QuestionBank.QuestionBank_ChapterID = Convert.ToInt32(rcmb_Chapter.SelectedValue);
            _obj_SMHR_QuestionBank.QuestionBank_Question = rtxt_FeddbackQtn.Text;
            _obj_SMHR_QuestionBank.QuestionBank_option1 = rtxt_Feedbackopt1.Text;
            _obj_SMHR_QuestionBank.QuestionBank_option2 = rtxt_Feedbackopt2.Text;
            _obj_SMHR_QuestionBank.QuestionBank_option3 = rtxt_Feedbackopt3.Text;
            _obj_SMHR_QuestionBank.QuestionBank_option4 = rtxt_Feedbackopt4.Text;
            _obj_SMHR_QuestionBank.QuestionBank_status = rad_IsActive.Checked;
            _obj_SMHR_QuestionBank.QuestionBank_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_QuestionBank.QuestionBank_CREATEDDATE = DateTime.Now;
            _obj_SMHR_QuestionBank.QuestionBank_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_SMHR_QuestionBank.QuestionBank_LASTMDFDATE = DateTime.Now;

            if (rbn_Option1.Checked)
                _obj_SMHR_QuestionBank.QuestionBank_answer = Convert.ToInt32(rbn_Option1.Value);
            else if (rbn_Option2.Checked)
                _obj_SMHR_QuestionBank.QuestionBank_answer = Convert.ToInt32(rbn_Option2.Value);
            else if (rbn_Option3.Checked)
                _obj_SMHR_QuestionBank.QuestionBank_answer = Convert.ToInt32(rbn_Option3.Value);
            else if (rbn_Option4.Checked)
                _obj_SMHR_QuestionBank.QuestionBank_answer = Convert.ToInt32(rbn_Option4.Value);
            else
            {
                BLL.ShowMessage(this, "Please Select one correct option");
                return;
            }


            switch (((Button)sender).ID.ToString())
            {
                case "btn_Save":

                    _obj_SMHR_QuestionBank.OPERATION = operation.Get;

                    if (BLL.get_QuestionBank(_obj_SMHR_QuestionBank).Rows.Count != 0)
                    {
                        BLL.ShowMessage(this, "This Question already exist");
                        return;
                    }
                    _obj_SMHR_QuestionBank.QuestionBank_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_QuestionBank.QuestionBank_CREATEDDATE = DateTime.Now;
                    _obj_SMHR_QuestionBank.OPERATION = operation.Insert;
                    if (BLL.set_QuestionBank(_obj_SMHR_QuestionBank))
                    {


                        BLL.ShowMessage(this, "Information Saved Successfully ");


                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved");
                    }

                    break;

                case "btn_Edit":

                    _obj_SMHR_QuestionBank.OPERATION = operation.Update;
                    _obj_SMHR_QuestionBank.QuestionBank_ID = Convert.ToInt32(lbl_FeedbackID.Text);
                    _obj_SMHR_QuestionBank.QuestionBank_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_QuestionBank.QuestionBank_LASTMDFDATE = DateTime.Now;


                    if (BLL.set_QuestionBank(_obj_SMHR_QuestionBank))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully ");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Updated");
                    }

                    break;
            }
            Rm_Feedback_Page.SelectedIndex = 0;
            LoadGrid();
            Rg_Feedback.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();

            rcmb_Chapter.Enabled = true;
            rcmb_Course.Enabled = true;
            Rm_Feedback_Page.SelectedIndex = 1;
            rcmb_Chapter.SelectedIndex = -1;
            rtxt_FeddbackQtn.Enabled = true;
            btn_Save.Visible = true;
            btn_Cancel.Visible = true;
            btn_Edit.Visible = false;

            LoadDropDowns();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            btn_Edit.Visible = false;
            btn_Save.Visible = false;
            btn_Cancel.Visible = true;

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Edit.Visible = false;

            }
            else
            {
                btn_Edit.Visible = true;
            }
            rtxt_FeddbackQtn.Enabled = false;


            lbl_FeedbackID.Text = Convert.ToString(e.CommandArgument);
            LoadDropDowns();


            _obj_SMHR_QuestionBank.OPERATION = operation.Check;
            _obj_SMHR_QuestionBank.QuestionBank_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_QuestionBank.QuestionBank_ID = Convert.ToInt32(lbl_FeedbackID.Text);

            DataTable dt = BLL.get_QuestionBank(_obj_SMHR_QuestionBank);
            if (dt.Rows.Count != 0)
            {
                rcmb_Course.SelectedIndex = rcmb_Course.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["QUESTIONBANK_COURSEID"]));
                rcmb_Course_SelectedIndexChanged(null, null);
                rcmb_Chapter.SelectedIndex = rcmb_Chapter.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["QUESTIONBANK_CHAPTERID"]));

                //rcmb_Category.SelectedItem.Value
                //string str_dummy = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_QUESTION_CATEGORY"]);
                //rcmb_Category.SelectedItem.Text =Convert.ToString(str_dummy);
                rtxt_FeddbackQtn.Text = Convert.ToString(dt.Rows[0]["QUESTIONBANK_QUESTION"]);
                rtxt_Feedbackopt1.Text = Convert.ToString(dt.Rows[0]["QuestionBank_option1"]);
                rtxt_Feedbackopt2.Text = Convert.ToString(dt.Rows[0]["QuestionBank_option2"]);
                rtxt_Feedbackopt3.Text = Convert.ToString(dt.Rows[0]["QuestionBank_option3"]);
                rtxt_Feedbackopt4.Text = Convert.ToString(dt.Rows[0]["QuestionBank_option4"]);
                if (string.Compare(dt.Rows[0]["QuestionBank_answer"].ToString(), "1", true) == 0)
                    rbn_Option1.Checked = true;
                else if (string.Compare(dt.Rows[0]["QuestionBank_answer"].ToString(), "2", true) == 0)
                    rbn_Option2.Checked = true;
                else if (string.Compare(dt.Rows[0]["QuestionBank_answer"].ToString(), "3", true) == 0)
                    rbn_Option3.Checked = true;
                else if (string.Compare(dt.Rows[0]["QuestionBank_answer"].ToString(), "4", true) == 0)
                    rbn_Option4.Checked = true;
                    rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["QuestionBank_status"]);
                
                rcmb_Chapter.Enabled = false;
                rcmb_Course.Enabled = false;
                //rad_IsActive.Enabled = false;
                Rm_Feedback_Page.SelectedIndex = 1;
            }
            // rcmb_Category.Focus();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    public void ClearControls()
    {
        try
        {
            //  rtxt_FeddbackQtn.ReadOnly = false;
            rtxt_FeddbackQtn.Text = string.Empty;
            rtxt_Feedbackopt1.Text = string.Empty;
            rtxt_Feedbackopt2.Text = string.Empty;
            rtxt_Feedbackopt3.Text = string.Empty;
            rtxt_Feedbackopt4.Text = string.Empty;
            rbn_Option4.Checked = false;
            rbn_Option1.Checked = false;
            rbn_Option3.Checked = false;
            rbn_Option2.Checked = false;
            rcmb_Chapter.SelectedIndex = -1;
            rcmb_Course.SelectedIndex = -1;
            //rcmb_Category.SelectedIndex = -1;
            btn_Save.Visible = false;
            btn_Edit.Visible = false;
            Rm_Feedback_Page.SelectedIndex = 0;
            rcmb_Chapter.Items.Clear();
            rcmb_Chapter.Text = string.Empty;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadDropDowns()
    {
        try
        {
            SMHR_COURSE _obj_Course = new SMHR_COURSE();
            _obj_Course.OPERATION = operation.Select2;
            _obj_Course.COURSE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Course.DataSource = BLL.get_Course(_obj_Course);
            rcmb_Course.DataTextField = "COURSE_NAME";
            rcmb_Course.DataValueField = "COURSE_ID";
            rcmb_Course.DataBind();
            rcmb_Course.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Course_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Chapter.SelectedIndex = -1;
            LoadCourse();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCourse()
    {
        try
        {
            SMHR_CHAPTERS _obj_Chapter = new SMHR_CHAPTERS();
            _obj_Chapter.OPERATION = operation.Select1;
            _obj_Chapter.CHARPTER_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Chapter.CHAPTER_COURSE_ID = Convert.ToInt32(rcmb_Course.SelectedValue);
            rcmb_Chapter.DataSource = BLL.get_Chapter(_obj_Chapter);
            rcmb_Chapter.DataTextField = "CHAPTER_NAME";
            rcmb_Chapter.DataValueField = "CHAPTER_ID";
            rcmb_Chapter.DataBind();
            rcmb_Chapter.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


}
