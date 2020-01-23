using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using SPMS;
using System.Text;

public partial class HR_TRAINING_frm_RatingFeedbackQuestions : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Rate Feedback Questions");//TRAINING APPROVAL");
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

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    RG_TrainingApproval.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_submit.Visible = false;
                    //btn_Update.Visible = false;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }




    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {

        if (string.Compare(rc_type.SelectedValue, "Trainer", true) == 0 && rc_Trainer.SelectedIndex <= 0)
        {
            BLL.ShowMessage(this, "Please select Trainer");
            return;
        }

        DataTable dtFeedBackTable = GetFeedbackRatingTable();
        SMHR_FEEDBACK_RATING _obj_SMHR_QuestionBank = new SMHR_FEEDBACK_RATING();
        try
        {

            System.Web.UI.HtmlControls.HtmlInputRadioButton rad_IsActive; int qtnid;
            bool isChecked = false;
            for (int index = 0; index < RG_TrainingApproval.Items.Count; index++)
            {
                qtnid = Convert.ToInt32(RG_TrainingApproval.Items[index].Cells[2].Text);
                rad_IsActive = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rbn_Rate1") as System.Web.UI.HtmlControls.HtmlInputRadioButton;
                if (rad_IsActive.Checked)
                {
                    isChecked = true;
                    _obj_SMHR_QuestionBank.RATING_RATING = Convert.ToInt32(rad_IsActive.Value);
                }
                rad_IsActive = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rbn_Rate2") as System.Web.UI.HtmlControls.HtmlInputRadioButton;
                if (rad_IsActive.Checked)
                {
                    isChecked = true;
                    _obj_SMHR_QuestionBank.RATING_RATING = Convert.ToInt32(rad_IsActive.Value);
                }
                rad_IsActive = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rbn_Rate3") as System.Web.UI.HtmlControls.HtmlInputRadioButton;
                if (rad_IsActive.Checked)
                {
                    isChecked = true;
                    _obj_SMHR_QuestionBank.RATING_RATING = Convert.ToInt32(rad_IsActive.Value);
                }
                rad_IsActive = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rbn_Rate4") as System.Web.UI.HtmlControls.HtmlInputRadioButton;
                if (rad_IsActive.Checked)
                {
                    isChecked = true;
                    _obj_SMHR_QuestionBank.RATING_RATING = Convert.ToInt32(rad_IsActive.Value);
                }
                rad_IsActive = new System.Web.UI.HtmlControls.HtmlInputRadioButton();
                rad_IsActive = RG_TrainingApproval.Items[index].FindControl("rbn_Rate5") as System.Web.UI.HtmlControls.HtmlInputRadioButton;
                if (rad_IsActive.Checked)
                {
                    isChecked = true;
                    _obj_SMHR_QuestionBank.RATING_RATING = Convert.ToInt32(rad_IsActive.Value);
                }
                if (!isChecked)
                {
                    BLL.ShowMessage(this, "Please rate all question to proceed");
                    return;
                }

                //continue;
                if (string.Compare(rc_type.SelectedItem.Text, "Trainer", true) == 0)
                    dtFeedBackTable.Rows.Add(rc_type.SelectedItem.Text, Convert.ToInt32(rc_ServiceProvider.SelectedValue), Convert.ToInt32(rc_Trainer.SelectedValue), _obj_SMHR_QuestionBank.RATING_RATING,
                        Convert.ToInt32(Session["USER_ID"]), DateTime.Now, Convert.ToInt32(Session["USER_ID"]), DateTime.Now, Convert.ToInt32(Session["ORG_ID"]), qtnid);
                else
                    dtFeedBackTable.Rows.Add(rc_type.SelectedItem.Text, Convert.ToInt32(rc_ServiceProvider.SelectedValue), 0, _obj_SMHR_QuestionBank.RATING_RATING,
                       Convert.ToInt32(Session["USER_ID"]), DateTime.Now, Convert.ToInt32(Session["USER_ID"]), DateTime.Now, Convert.ToInt32(Session["ORG_ID"]), qtnid);

            }






            _obj_SMHR_QuestionBank.FEEDBACK_TABLE = dtFeedBackTable;
            _obj_SMHR_QuestionBank.OPERATION = operation.Insert;
            if (BLL.set_Rating(_obj_SMHR_QuestionBank))
            {


                BLL.ShowMessage(this, "Information Saved Successfully");
                btn_submit.Visible = true;
                btn_Cancel.Visible = true;
                rc_Trainer.SelectedIndex = -1;
                rc_ServiceProvider.SelectedIndex = -1;
                rc_type.SelectedIndex = -1;

            }

            else
            {
                BLL.ShowMessage(this, "Information Not Saved");
                btn_submit.Visible = true;
                btn_Cancel.Visible = true;
                rc_Trainer.SelectedIndex = -1;
                rc_ServiceProvider.SelectedIndex = -1;
                rc_type.SelectedIndex = -1;
            }
            RG_TrainingApproval.Visible = false;
            btn_submit.Visible = false;
            btn_Cancel.Visible = false;
            rc_ServiceProvider.Items.Clear();
            rc_Trainer.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    private DataTable GetFeedbackRatingTable()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add("RATING_TYPE", typeof(string));
            dt.Columns.Add("RATING_SERVICEPROVIDER", typeof(int));
            dt.Columns.Add("RATING_TRAINER_NAME", typeof(int));
            dt.Columns.Add("RATING_RATING", typeof(int));
            dt.Columns.Add("RATING_CREATEDBY", typeof(int));
            dt.Columns.Add("RATING_CREATEDATE", typeof(DateTime));
            dt.Columns.Add("RATING_LASTMDFBY", typeof(int));
            dt.Columns.Add("RATING_LASTMDFDATE", typeof(DateTime));
            dt.Columns.Add("RATING_ORGID", typeof(int));
            dt.Columns.Add("RATING_QUESTIONID", typeof(int));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return dt;
    }

    protected void rc_type_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RG_TrainingApproval.Visible = false;
           

            SMHR_FEEDBACK_RATING _obj_Smhr_ServiceProvider = new SMHR_FEEDBACK_RATING();
            if (rc_type.SelectedIndex > 0)
            {
                _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
                _obj_Smhr_ServiceProvider.RATING_TYPE = Convert.ToString(rc_type.SelectedItem.Text);
                _obj_Smhr_ServiceProvider.RATING_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable DT = BLL.get_Rating(_obj_Smhr_ServiceProvider);
                DataTable DT = BLL.get_Rating(_obj_Smhr_ServiceProvider);
                rc_ServiceProvider.DataSource = DT;
                rc_ServiceProvider.DataValueField = "SERVICEPROVIDER_ID";
                rc_ServiceProvider.DataTextField = "SERVICEPROVIDER_NAME";
                rc_ServiceProvider.DataBind();
                rc_ServiceProvider.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
            else
            {
            RG_TrainingApproval.Visible = false;
            btn_Cancel.Visible = false;
            btn_submit.Visible = false;
            rc_ServiceProvider.Items.Clear();
            rc_ServiceProvider.Text = string.Empty;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void rc_ServiceProvider_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            btn_Cancel.Visible = true;
            btn_submit.Visible = true;
            if (rc_type.SelectedValue == "Service Provider")
            {
                rc_Trainer.Enabled = false;


            }
            else
            {
                rc_Trainer.Enabled = true;
                SMHR_FEEDBACK_RATING _obj_smhr_Trainer = new SMHR_FEEDBACK_RATING();
                //SMHR_TRAINERPROFILE _obj_smhr_Trainer = new SMHR_TRAINERPROFILE();
                _obj_smhr_Trainer.OPERATION = operation.Select1;
                _obj_smhr_Trainer.RATING_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_Trainer.RATING_SERVICEPROVIDER = Convert.ToInt32(rc_ServiceProvider.SelectedValue);
                DataTable Dt = BLL.get_Rating(_obj_smhr_Trainer);
                rc_Trainer.DataSource = Dt;
                rc_Trainer.DataValueField = "Trainer_TrainerProfile_id";
                rc_Trainer.DataTextField = "Trainer_Name";
                rc_Trainer.DataBind();
                rc_Trainer.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            }
            RG_TrainingApproval.Visible = true;
            SMHR_TRAINING_FEEDBACKQUESTION _obj_FeedBack = new SMHR_TRAINING_FEEDBACKQUESTION();
            _obj_FeedBack.OPERATION = operation.Select1;
            _obj_FeedBack.FEEDBACKQUESTION_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_FeedBack.FEEDBACKQUESTION_TYPE = Convert.ToString(rc_type.SelectedValue);
            DataTable DT = BLL.get_FeedbackQuestion(_obj_FeedBack);
            if (DT.Rows.Count != 0)
            {
                RG_TrainingApproval.DataSource = DT;
                RG_TrainingApproval.DataBind();
            }
            else
            {
                RG_TrainingApproval.DataSource = DT;
                RG_TrainingApproval.DataBind();
                btn_submit.Visible = false;


            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rc_ServiceProvider.Items.Clear();
            rc_Trainer.Items.Clear();
            rc_type.SelectedIndex = -1;
            rc_Trainer.SelectedIndex = -1;
            rc_ServiceProvider.SelectedIndex = -1;
            RG_TrainingApproval.Visible = false;
            btn_Cancel.Visible = false;
            btn_submit.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_RatingFeedbackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}