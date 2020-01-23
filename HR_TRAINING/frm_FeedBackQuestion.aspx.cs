using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Text;
using Telerik.Web.UI;
using System.Data.OleDb;
using System.IO;
using System.Data;

public partial class HR_TRAINING_frm_FeedBackQuestion : System.Web.UI.Page
{
    static double minsal = 0.0;
    static double maxsal = 0.0;
    static double int_DOBS = 0;
    static double int_DOBE = 0;
    static int int_MIN = 18;
    static string int_DF = "";
    string strfilename2;
    DataSet ds = new DataSet();
    protected override void InitializeCulture()
    {

        SMHR_TRAINING_FEEDBACKQUESTION _obj_FeedbackQuestion;
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Feedback Questions");//COUNTRY");
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
                    Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;


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
            }
            LoadGrid();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rp_CY_ViewDetails.Selected = true;
            btn_Save.Visible = true;
            rc_type.Enabled = true;
            btn_Update.Visible = false;


            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void LoadGrid()
    {
        try
        {
            SMHR_TRAINING_FEEDBACKQUESTION _obj_FeedbackQuestion = new SMHR_TRAINING_FEEDBACKQUESTION();
            _obj_FeedbackQuestion.OPERATION = operation.Select;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_FeedbackQuestion(_obj_FeedbackQuestion);
            Rg_Countries.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {

            rc_type.Enabled = false;
            btn_Save.Visible = false;
            rtxt_Question.Enabled = false;


            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }


            lbl_FeedBackID.Text = Convert.ToString(e.CommandArgument);

            SMHR_TRAINING_FEEDBACKQUESTION _obj_FeedbackQuestion = new SMHR_TRAINING_FEEDBACKQUESTION();
            _obj_FeedbackQuestion.OPERATION = operation.Get;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_FeedbackQuestion.FEEDBACKQUESTION_ID = Convert.ToInt32(lbl_FeedBackID.Text);
            DataTable dt = BLL.get_FeedbackQuestion(_obj_FeedbackQuestion);

            if (dt.Rows.Count != 0)
            {



                rc_type.SelectedIndex = rc_type.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FEEDBACKQUESTION_TYPE"]));

                rtxt_Description.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTION_QUESTION_DESC"]);
                rtxt_Question.Text = Convert.ToString(dt.Rows[0]["FEEDBACKQUESTION_QUESTION"]);
                rad_IsActive.Checked = Convert.ToBoolean(dt.Rows[0]["FEEDBACKQUESTION_STATUS"]);
                Rm_CY_page.SelectedIndex = 1;


            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {



        try
        {


            SMHR_TRAINING_FEEDBACKQUESTION _obj_FeedbackQuestion = new SMHR_TRAINING_FEEDBACKQUESTION();
            _obj_FeedbackQuestion.FEEDBACKQUESTION_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_FeedbackQuestion.FEEDBACKQUESTION_TYPE = Convert.ToString(rc_type.SelectedValue);
            _obj_FeedbackQuestion.FEEDBACKQUESTION_QUESTION = rtxt_Question.Text;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_QUESTION_DESC = rtxt_Description.Text;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_FeedbackQuestion.FEEDBACKQUESTION_CREATEDDATE = DateTime.Now;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_FeedbackQuestion.FEEDBACKQUESTION_LASTMDFDATE = DateTime.Now;
            _obj_FeedbackQuestion.FEEDBACKQUESTION_STATUS = rad_IsActive.Checked;



            switch (((Button)sender).ID.ToString())
            {
                case "btn_Save":

                    _obj_FeedbackQuestion.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_FeedbackQuestion(_obj_FeedbackQuestion).Rows[0]["Count"]) != "1")
                    {


                        _obj_FeedbackQuestion.OPERATION = operation.Get;

                        if (BLL.get_FeedbackQuestion(_obj_FeedbackQuestion).Rows.Count != 0)
                        {
                            BLL.ShowMessage(this, "This Question already exist");
                            return;
                        }
                        _obj_FeedbackQuestion.FEEDBACKQUESTION_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_FeedbackQuestion.FEEDBACKQUESTION_CREATEDDATE = DateTime.Now;
                        _obj_FeedbackQuestion.OPERATION = operation.Insert;
                        if (BLL.set_FeedBackQuestion(_obj_FeedbackQuestion))
                        {


                            BLL.ShowMessage(this, "Information Saved Successfully ");



                        }
                        else
                        {
                            BLL.ShowMessage(this, "Information Not Saved");
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Question Already Exists");
                        return;
                    }


                    break;

                case "btn_Update":
                    _obj_FeedbackQuestion.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_FeedbackQuestion(_obj_FeedbackQuestion).Rows[0]["Count"]) != "1")
                    {
                        BLL.ShowMessage(this, "FeedBack Question with this Name Already Exists");
                        return;
                    }
                    _obj_FeedbackQuestion.OPERATION = operation.Update;
                    _obj_FeedbackQuestion.FEEDBACKQUESTION_ID = Convert.ToInt32(lbl_FeedBackID.Text);
                    _obj_FeedbackQuestion.FEEDBACKQUESTION_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_FeedbackQuestion.FEEDBACKQUESTION_LASTMDFDATE = DateTime.Now;


                    if (BLL.set_FeedBackQuestion(_obj_FeedbackQuestion))
                    {
                        BLL.ShowMessage(this, "Information Updated Successfully ");
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Information Not Updated");
                    }

                    break;
            }
            Rm_CY_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Countries.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_CY_page.SelectedIndex = 0;

            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void clearControls()
    {
        try
        {
            rtxt_Question.Text = string.Empty;
            rc_type.SelectedIndex = -1;
            rc_type.SelectedIndex = -1;
            rtxt_Description.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

}
