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
    SMHR_FEEDBACK_QUESTION _obj_SMHR_FEEDBACK_QUESTION = new SMHR_FEEDBACK_QUESTION();
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo = new SMHR_LOGINTYPE();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                LoadGrid();
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TRAINING FEEDBACK QUESTIONS");
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
                    Rg_Feedback.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                }
                Rg_Feedback.DataBind();

            }
            Page.Validate();
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
            _obj_SMHR_FEEDBACK_QUESTION = new SMHR_FEEDBACK_QUESTION();
            _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Select;
            _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION = "";
            _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_STATUS = "Active";//YYY
            _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_FeedbackQuestion(_obj_SMHR_FEEDBACK_QUESTION);
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
        LoadGrid();
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).ID.ToString())
            {
                case "btn_Save":
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION_CATEGORY = Convert.ToString (rcmb_Category.SelectedValue);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION = BLL.ReplaceQuote(rtxt_FeddbackQtn.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Start;//YYY
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (BLL.get_FeedbackQuestion(_obj_SMHR_FEEDBACK_QUESTION).Rows.Count != 0)
                    {
                        BLL.ShowMessage(this, "This Question already exist");
                        return;
                    }
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION = BLL.ReplaceQuote(rtxt_FeddbackQtn.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION1 = BLL.ReplaceQuote(rtxt_Feedbackopt1.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION2 = BLL.ReplaceQuote(rtxt_Feedbackopt2.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION3 = BLL.ReplaceQuote(rtxt_Feedbackopt3.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION4 = BLL.ReplaceQuote(rtxt_Feedbackopt4.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_STATUS = Convert.ToString(rcb_Status.SelectedItem.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION_CATEGORY = Convert.ToString(rcmb_Category.SelectedValue);
                    _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Insert;
                    _obj_SMHR_FEEDBACK_QUESTION.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    //Convert.ToInt32(Session["Userid"]);
                    _obj_SMHR_FEEDBACK_QUESTION.CREATEDDATE = DateTime.Now;

                    if (BLL.set_Feedbackquestion(_obj_SMHR_FEEDBACK_QUESTION))
                    {

                        BLL.ShowMessage(this, "Information Saved Successfully ");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Saved Successfully");
                    }
                    break;
                case "btn_Edit":
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION = BLL.ReplaceQuote(rtxt_FeddbackQtn.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION1 = BLL.ReplaceQuote(rtxt_Feedbackopt1.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION2 = BLL.ReplaceQuote(rtxt_Feedbackopt2.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION3 = BLL.ReplaceQuote(rtxt_Feedbackopt3.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_OPTION4 = BLL.ReplaceQuote(rtxt_Feedbackopt4.Text);
                  
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_STATUS = Convert.ToString(rcb_Status.SelectedItem.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_QUESTION_CATEGORY = Convert.ToString (rcmb_Category.SelectedValue);
                    _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_ID = Convert.ToInt32(lbl_FeedbackID.Text);
                    _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Update;
                    _obj_SMHR_FEEDBACK_QUESTION.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    //Convert.ToInt32(Session["Userid"]);
                    _obj_SMHR_FEEDBACK_QUESTION.LASTMDFDATE = DateTime.Now;

                    if (BLL.set_Feedbackquestion(_obj_SMHR_FEEDBACK_QUESTION))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully ");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Updated Successfully");
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
            Rm_Feedback_Page.SelectedIndex = 1;

            btn_Save.Visible = true;
            btn_Cancel.Visible = true;
            btn_Edit.Visible = false;
       
            lbl_FeedbackID.Text = "";
            rcmb_Category.Focus();
            rcb_Status.SelectedItem.Text = "Active";
            rcb_Status.Enabled = false;
            rcmb_Category.Enabled = true;
            rtxt_FeddbackQtn.Enabled = true;
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
            _obj_SMHR_FEEDBACK_QUESTION = new SMHR_FEEDBACK_QUESTION();
            _obj_SMHR_FEEDBACK_QUESTION.OPERATION = operation.Check;
            _obj_SMHR_FEEDBACK_QUESTION.FEEDBACKQUESTS_ID = Convert.ToInt32(lbl_FeedbackID.Text);

            DataTable dt = BLL.get_FeedbackQuestion(_obj_SMHR_FEEDBACK_QUESTION);
            if (dt.Rows.Count != 0)
            {
                rcmb_Category.SelectedIndex = rcmb_Category.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_QUESTION_CATEGORY"]));
                //rcmb_Category.SelectedItem.Value
                //string str_dummy = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_QUESTION_CATEGORY"]);
                //rcmb_Category.SelectedItem.Text =Convert.ToString(str_dummy);
                rtxt_FeddbackQtn.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_QUESTION"]);
                rtxt_Feedbackopt1.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_OPTION1"]);
                rtxt_Feedbackopt2.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_OPTION2"]);
                rtxt_Feedbackopt3.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_OPTION3"]);
                rtxt_Feedbackopt4.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_OPTION4"]);

                rcb_Status.SelectedIndex = rcb_Status.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FEEDBACKQUESTS_STATUS"]));
                rcmb_Category.Enabled = false;
                rcb_Status.Enabled = false;
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
          
            rcmb_Category.SelectedIndex = -1;
            //btn_Save.Visible = false;
            //btn_Edit.Visible = false;
            rcb_Status.SelectedIndex = -1;
            Rm_Feedback_Page.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingFeedBackQuestions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}
