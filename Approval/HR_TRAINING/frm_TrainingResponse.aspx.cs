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

public partial class Training_frm_TrainingResponse : System.Web.UI.Page
{
   
    SMHR_TRAININGFEEDBACK_RESPONSE _obj_SMHR_TRAININGFEEDBACK_RESPONSE1;

  
    SMHR_FEEDBACK_QUESTIONS _obj_SMHR_FEEDBACK_QUESTIONS ;
    SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst;
   

   
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
            btn_Save.Attributes.Add("onclick", "return confirm_delete();");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void rcmb_ScheduleName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadTrainers();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void LoadTrainers()
    {
        try
        {
        SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
        _obj_Smhr_Trner.OPERATION = operation.Select;
        _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
        DataTable dttrainers = BLL.get_TrainerDetails(_obj_Smhr_Trner);
       
            ReptFeedBack_AllTrainer.DataSource = dttrainers;
            ReptFeedBack_AllTrainer.DataBind();

            for (int i = 0; i < ReptFeedBack_AllTrainer.Items.Count; i++)
            {
                Label lblTrainerName = ReptFeedBack_AllTrainer.Items[i].FindControl("lbl_Trainer") as Label;
                lblTrainerName.Visible = true;
                _obj_SMHR_FEEDBACK_QUESTIONS = new SMHR_FEEDBACK_QUESTIONS();
                DataTable DT1 = new DataTable();
                _obj_SMHR_FEEDBACK_QUESTIONS.OPERATION = operation.TRAINER;
                _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_QUESTION = "";
                _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_STATUS = "Active";
                DT1 = BLL.get_FeedbackQuestions(_obj_SMHR_FEEDBACK_QUESTIONS);
                if (DT1.Rows.Count != 0)
                {

                    Repeater repttrainer = ReptFeedBack_AllTrainer.Items[i].FindControl("ReptFeedBack_Trainer") as Repeater;
                    repttrainer.DataSource = DT1;
                    repttrainer.DataBind();
                    PopulateOptions3(DT1, i);
                    //lbl_Trainer.Visible = true;
                }                
            }
            if (ReptFeedBack_Couseller.Items.Count == 0 && ReptFeedBack_Course.Items.Count == 0 && ReptFeedBack_Admin.Items.Count ==0)
             {
                              BLL.ShowMessage(this, "No Feedback Question Defined.");

                              Rm_Feedbackrespns_Page.SelectedIndex = 0;
            }
       
       
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadDropDown()
    {
        try
        {
      

       DataTable DT = new DataTable();
        _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode  = 1;
        rcmb_ScheduleName.DataSource = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        rcmb_ScheduleName.DataTextField = "TR_TITLE";
        rcmb_ScheduleName.DataValueField = "TR_ID";
        rcmb_ScheduleName.DataBind();
        rcmb_ScheduleName.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        rcmb_ScheduleName.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void LoadGrid()
    {
        try
        {
            if (Convert.ToString(Session["LOGIN_TYPE"]) == "ADMIN-DEPT")
        {
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE1 = new SMHR_TRAININGFEEDBACK_RESPONSE();
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Select;
            DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1);
            Rg_Feedbackrespns.DataSource = dt;
            lbl_Status.Visible = true;
            rcmb_Status.Visible = true;
            lbl_StatusColumn.Visible = true;
        }
        else
        {
            //_obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK_RESPONSE();

            _obj_SMHR_TRAININGFEEDBACK_RESPONSE1 = new SMHR_TRAININGFEEDBACK_RESPONSE();
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Start;
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1);
            Rg_Feedbackrespns.DataSource = dt;
            //lbl_Status.Visible = false;
            //rcmb_Status.Visible = false;
            //lbl_StatusColumn.Visible = false;
        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Rg_Feedbackrespns_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_FeedBack_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadFeedback();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
        _lbl_id.Text = Convert.ToString(e.CommandArgument);
        loadDropDown();
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1 = new SMHR_TRAININGFEEDBACK_RESPONSE();

        displayOptions();

        if (Convert.ToString(Session["LOGIN_TYPE"]) == "ADMIN-DEPT")
        {
            btn_Update.Visible = true;
            btn_Cancel.Visible = true;
        }
        else
        {
            btn_Update.Visible = true;
            btn_Cancel.Visible = true;
        }
        
        DataTable dt = new DataTable();
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Check;
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(_lbl_id.Text);
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = 0;
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = 0;
        dt = (BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1));
        rcmb_ScheduleName.SelectedIndex = rcmb_ScheduleName.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FEEDBACKRES_TR_ID"]));
        LoadTrainers();   
        rcmb_Status.SelectedIndex = rcmb_Status.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["FEEDBACKRES_STATUS"]));
        rtxt_Feedbackresponse.Text = Convert.ToString((dt.Rows[0]["FEEDBACKRES_COMMENTS"]));
        for (int i = 0; i <= ReptFeedBack_Admin.Items.Count -1 ; i++)
        {
            Label lblQuesID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;
            RadioButtonList rdb = ReptFeedBack_Admin.Items[i].FindControl("rdbTest") as RadioButtonList;
            string strExp = "FEEDBACKRES_FEEDBACKQUESTS_ID = '" + lblQuesID.Text + "'";
            DataRow[] drRows = dt.Select(strExp);
            if (drRows.Length > 0)
            {
                switch (drRows[0]["FEEDBACKRES_RESPONSE"].ToString())
                {
                    case "1":
                        rdb.Items[0].Selected = true;
                        break;
                    case "2":
                        rdb.Items[1].Selected = true;
                        break;
                    case "3":
                        rdb.Items[2].Selected = true;
                        break;
                    case "4":
                        rdb.Items[3].Selected = true;
                        break;
                    case "5":
                        rdb.Items[4].Selected = true;
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i <= ReptFeedBack_Course.Items.Count - 1; i++)
        {
            Label lblQuesID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;
            RadioButtonList rdb = ReptFeedBack_Course.Items[i].FindControl("rdbTest") as RadioButtonList;
            string strExp = "FEEDBACKRES_FEEDBACKQUESTS_ID = '" + lblQuesID.Text + "'";
            DataRow[] drRows = dt.Select(strExp);
            if (drRows.Length > 0)
            {
                switch (drRows[0]["FEEDBACKRES_RESPONSE"].ToString())
                {
                    case "1":
                        rdb.Items[0].Selected = true;
                        break;
                    case "2":
                        rdb.Items[1].Selected = true;
                        break;
                    case "3":
                        rdb.Items[2].Selected = true;
                        break;
                    case "4":
                        rdb.Items[3].Selected = true;
                        break;
                    case "5":
                        rdb.Items[4].Selected = true;
                        break;
                    default:
                        break;
                }
            }
        }

        for (int i = 0; i <= ReptFeedBack_Couseller.Items.Count - 1; i++)
        {
            Label lblQuesID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;
            RadioButtonList rdb = ReptFeedBack_Couseller.Items[i].FindControl("rdbTest") as RadioButtonList;
            string strExp = "FEEDBACKRES_FEEDBACKQUESTS_ID = '" + lblQuesID.Text + "'";
            DataRow[] drRows = dt.Select(strExp);
            if (drRows.Length > 0)
            {
                switch (drRows[0]["FEEDBACKRES_RESPONSE"].ToString())
                {
                    case "1":
                        rdb.Items[0].Selected = true;
                        break;
                    case "2":
                        rdb.Items[1].Selected = true;
                        break;
                    case "3":
                        rdb.Items[2].Selected = true;
                        break;
                    case "4":
                        rdb.Items[3].Selected = true;
                        break;
                    case "5":
                        rdb.Items[4].Selected = true;
                        break;
                    default:
                        break;
                }
            }
        }

        for (int j = 0; j <= ReptFeedBack_AllTrainer.Items.Count - 1; j++)
        {
            Repeater repttrainer = ReptFeedBack_AllTrainer.Items[j].FindControl("ReptFeedBack_Trainer") as Repeater;
            Label lblFeedTrainerID = ReptFeedBack_AllTrainer.Items[j].FindControl("lbl_TrainerID") as Label;

            for (int i = 0; i <= repttrainer.Items.Count - 1; i++)
            {
                Label lblQuesID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;
                RadioButtonList rdb = repttrainer.Items[i].FindControl("rdbTest") as RadioButtonList;
                string strExp = "FEEDBACKRES_FEEDBACKQUESTS_ID = '" + lblQuesID.Text + "' and FEEDBACKRES_TRAINER_ID = '" + lblFeedTrainerID.Text + "'";
                DataRow[] drRows = dt.Select(strExp);
                if (drRows.Length > 0)
                {
                    switch (drRows[0]["FEEDBACKRES_RESPONSE"].ToString())
                    {
                        case "1":
                            rdb.Items[0].Selected = true;
                            break;
                        case "2":
                            rdb.Items[1].Selected = true;
                            break;
                        case "3":
                            rdb.Items[2].Selected = true;
                            break;
                        case "4":
                            rdb.Items[3].Selected = true;
                            break;
                        case "5":
                            rdb.Items[4].Selected = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //if (Convert.ToString(Session["LOGIN_TYPE"]) == "ADMIN")
        //{
        //    ReptFeedBack_Admin.Visible = false;
        //    ReptFeedBack_Course.Visible = false;
        //    ReptFeedBack_Couseller.Visible = false;
        //    ReptFeedBack_AllTrainer.Visible = false;
        //    lbl_Feedbackresponse.Visible = false;
        //    rtxt_Feedbackresponse.Visible = false;
        //}
        btn_Save.Visible = false;
        rcmb_ScheduleName.Enabled = false;
        Rm_Feedbackrespns_Page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
        loadDropDown();
        Rm_Feedbackrespns_Page.SelectedIndex = 1;
        btn_Save.Visible = true;
        btn_Cancel.Visible = true;
        btn_Update.Visible = false;

        displayOptions();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void DisableOptions()
    {

    }
    public void clearControls()
    {
        try
        {
        rtxt_Feedbackresponse.Text = "";
        Rm_Feedbackrespns_Page.SelectedIndex = 0;
        LoadGrid();
        Rg_Feedbackrespns.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        bool status = false;
        try
        {
            for (int i = 0; i <= ReptFeedBack_Admin.Items.Count - 1; i++)
            {
                RadioButtonList rdb = ReptFeedBack_Admin.Items[i].FindControl("rdbTest") as RadioButtonList;
                if (rdb.SelectedIndex == -1)
                {
                    BLL.ShowMessage(this, "Please Select the Feedback for all Questions.");
                    return;
                }
            }
            for (int i = 0; i <= ReptFeedBack_Course.Items.Count - 1; i++)
            {
                RadioButtonList rdb = ReptFeedBack_Course.Items[i].FindControl("rdbTest") as RadioButtonList;
                if (rdb.SelectedIndex == -1)
                {
                    BLL.ShowMessage(this, "Please Select the Feedback for all Questions.");
                    return;
                }
            }
            for (int i = 0; i <= ReptFeedBack_Couseller.Items.Count - 1; i++)
            {
                RadioButtonList rdb = ReptFeedBack_Couseller.Items[i].FindControl("rdbTest") as RadioButtonList;
                if (rdb.SelectedIndex == -1)
                {
                    BLL.ShowMessage(this, "Please Select the Feedback for all Questions.");
                    return;
                }
            }
            for (int j = 0; j <= ReptFeedBack_AllTrainer.Items.Count - 1; j++)
            {
                Repeater repttrainer = ReptFeedBack_AllTrainer.Items[j].FindControl("ReptFeedBack_Trainer") as Repeater;
                for (int i = 0; i <= repttrainer.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = repttrainer.Items[i].FindControl("rdbTest") as RadioButtonList;
                    if (rdb.SelectedIndex == -1)
                    {
                        BLL.ShowMessage(this, "Please Select the Feedback for all Questions.");
                        return;
                    }
                }
            }
            Label lblID = new Label();
            if (_lbl_id.Text == string.Empty)
            {
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1 = new SMHR_TRAININGFEEDBACK_RESPONSE();
                DataTable DT1 = new DataTable();
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Check;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                if (BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1).Rows.Count != 0)
                {
                    BLL.ShowMessage(this, "Already FeedBack is given for this Traininig.");
                    return;
                }


                int FeedBackNo;
                DataTable DT = new DataTable();
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Empty;
                DT = (BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1));
                if ((DT.Rows[0]["FEEDBACK_NO"] == null) || (Convert.ToString(DT.Rows[0]["FEEDBACK_NO"]) == ""))
                {
                    FeedBackNo = 1;
                }
                else
                {
                    FeedBackNo = Convert.ToInt32(DT.Rows[0]["FEEDBACK_NO"]);
                }

                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Insert;
                for (int i = 0; i <= ReptFeedBack_Admin.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Admin.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_DATE = DateTime.Now;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(FeedBackNo);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Insert;
                for (int i = 0; i <= ReptFeedBack_Course.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Course.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_DATE = DateTime.Now;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(FeedBackNo);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Insert;
                for (int i = 0; i <= ReptFeedBack_Couseller.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Couseller.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_DATE = DateTime.Now;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(FeedBackNo);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

                for (int j = 0; j <= ReptFeedBack_AllTrainer.Items.Count - 1; j++)
                {
                    Repeater repttrainer = ReptFeedBack_AllTrainer.Items[j].FindControl("ReptFeedBack_Trainer") as Repeater;
                    Label lblFeedTrainerID = ReptFeedBack_AllTrainer.Items[j].FindControl("lbl_TrainerID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Insert;
                    for (int i = 0; i <= repttrainer.Items.Count - 1; i++)
                    {
                        RadioButtonList rdb = repttrainer.Items[i].FindControl("rdbTest") as RadioButtonList;
                        Label lblFeedQuesID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;

                        lblID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TRAINER_ID = Convert.ToInt32(lblFeedTrainerID.Text);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_DATE = DateTime.Now;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(FeedBackNo);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.CREATEDDATE = DateTime.Now;
                        if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }

            }
            else
            {
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1 = new SMHR_TRAININGFEEDBACK_RESPONSE();
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.OPERATION = operation.Update;
                _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEBBACKRES_FEEDBACK_NO = Convert.ToInt32(_lbl_id.Text);
                for (int i = 0; i <= ReptFeedBack_Admin.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Admin.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

                for (int i = 0; i <= ReptFeedBack_Course.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Course.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

                for (int i = 0; i <= ReptFeedBack_Couseller.Items.Count - 1; i++)
                {
                    RadioButtonList rdb = ReptFeedBack_Couseller.Items[i].FindControl("rdbTest") as RadioButtonList;
                    Label lblFeedQuesID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;

                    lblID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFDATE = DateTime.Now;
                    if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                for (int j = 0; j <= ReptFeedBack_AllTrainer.Items.Count - 1; j++)
                {
                    Repeater repttrainer = ReptFeedBack_AllTrainer.Items[j].FindControl("ReptFeedBack_Trainer") as Repeater;
                    Label lblFeedTrainerID = ReptFeedBack_AllTrainer.Items[j].FindControl("lbl_TrainerID") as Label;
                    for (int i = 0; i <= repttrainer.Items.Count - 1; i++)
                    {
                        RadioButtonList rdb = repttrainer.Items[i].FindControl("rdbTest") as RadioButtonList;
                        Label lblFeedQuesID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;

                        lblID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_USER_ID = Convert.ToInt32(Session["USER_ID"]);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_FEEDBACKQUESTS_ID = Convert.ToInt32(lblFeedQuesID.Text);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_RESPONSE = rdb.SelectedValue;
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_COMMENTS = BLL.ReplaceQuote(Convert.ToString(rtxt_Feedbackresponse.Text));
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_STATUS = Convert.ToString(rcmb_Status.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TRAINER_ID = Convert.ToInt32(lblFeedTrainerID.Text);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.FEEDBACKRES_TR_ID = Convert.ToInt32(rcmb_ScheduleName.SelectedValue);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                        _obj_SMHR_TRAININGFEEDBACK_RESPONSE1.LASTMDFDATE = DateTime.Now;
                        if (BLL.set_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE1))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
            }
            if (status)
            {
                BLL.ShowMessage(this, "FeedBack Details have been saved");
              
            }
            else
            {
                BLL.ShowMessage(this, "FeedBack Details not saved");
            }
            Rm_Feedbackrespns_Page.SelectedIndex = 0;
            LoadGrid();
            Rg_Feedbackrespns.DataBind();

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadFeedback()
    {
     
    }

    private void displayOptions()
    {
        try
        {
            _obj_SMHR_FEEDBACK_QUESTIONS = new SMHR_FEEDBACK_QUESTIONS();
            _obj_SMHR_FEEDBACK_QUESTIONS.OPERATION = operation.ADMIN;
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_QUESTION = "";
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_STATUS = "Active";
            DataTable dt = BLL.get_FeedbackQuestions(_obj_SMHR_FEEDBACK_QUESTIONS);
            if (dt.Rows.Count != 0)
            {
                ReptFeedBack_Admin.DataSource = dt;
                ReptFeedBack_Admin.DataBind();
                PopulateOptions(dt);
                lbl_Admin.Visible = true;
            }

            _obj_SMHR_FEEDBACK_QUESTIONS.OPERATION = operation.Course;
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_QUESTION = "";
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_STATUS = "Active";
            dt = BLL.get_FeedbackQuestions(_obj_SMHR_FEEDBACK_QUESTIONS);
            if (dt.Rows.Count != 0)
            {
                ReptFeedBack_Course.DataSource = dt;
                ReptFeedBack_Course.DataBind();
                PopulateOptions1(dt);
                lbl_Course.Visible = true;
            }
            _obj_SMHR_FEEDBACK_QUESTIONS.OPERATION = operation.Counseller;
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_QUESTION = "";
            _obj_SMHR_FEEDBACK_QUESTIONS.FEEDBACKQUESTS_STATUS = "Active";
            dt = BLL.get_FeedbackQuestions(_obj_SMHR_FEEDBACK_QUESTIONS);
            if (dt.Rows.Count != 0)
            {
                ReptFeedBack_Couseller.DataSource = dt;
                ReptFeedBack_Couseller.DataBind();
                PopulateOptions2(dt);
                lbl_Counseller.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


       
    }

    public void PopulateOptions(DataTable dt)
    {
        try
        {

        for (int i = 0; i < ReptFeedBack_Admin.Items.Count; i++)
        {
            RadioButtonList rdb = ReptFeedBack_Admin.Items[i].FindControl("rdbTest") as RadioButtonList;
            Label lblQuestID = ReptFeedBack_Admin.Items[i].FindControl("lblFeedQuesID") as Label;
            string strExp = "FEEDBACKQUESTS_ID = '" + lblQuestID.Text + "'"; 
            DataRow[] drRow = dt.Select(strExp);
            
            if(drRow.Length > 0)
            {
                foreach (DataRow dr in drRow)
                {
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION1"].ToString(), "1"));
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION2"].ToString(), "2"));
                    if (dr["FEEDBACKQUESTS_OPTION3"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION3"].ToString(), "3"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION4"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION4"].ToString(), "4"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION5"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION5"].ToString(), "5"));
                    }
                }
            }
            
        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void PopulateOptions1(DataTable dt)
    {
        try
        {
        for (int i = 0; i < ReptFeedBack_Course.Items.Count; i++)
        {
            RadioButtonList rdb = ReptFeedBack_Course.Items[i].FindControl("rdbTest") as RadioButtonList;
            Label lblQuestID = ReptFeedBack_Course.Items[i].FindControl("lblFeedQuesID") as Label;
            string strExp = "FEEDBACKQUESTS_ID = '" + lblQuestID.Text + "'";
            DataRow[] drRow = dt.Select(strExp);

            if (drRow.Length > 0)
            {
                foreach (DataRow dr in drRow)
                {
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION1"].ToString(), "1"));
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION2"].ToString(), "2"));
                    if (dr["FEEDBACKQUESTS_OPTION3"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION3"].ToString(), "3"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION4"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION4"].ToString(), "4"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION5"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION5"].ToString(), "5"));
                    }
                }
            }

        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void PopulateOptions2(DataTable dt)
    {
        try
        {
        for (int i = 0; i < ReptFeedBack_Couseller.Items.Count; i++)
        {
            RadioButtonList rdb = ReptFeedBack_Couseller.Items[i].FindControl("rdbTest") as RadioButtonList;
            Label lblQuestID = ReptFeedBack_Couseller.Items[i].FindControl("lblFeedQuesID") as Label;
            string strExp = "FEEDBACKQUESTS_ID = '" + lblQuestID.Text + "'";
            DataRow[] drRow = dt.Select(strExp);

            if (drRow.Length > 0)
            {
                foreach (DataRow dr in drRow)
                {
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION1"].ToString(), "1"));
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION2"].ToString(), "2"));
                    if (dr["FEEDBACKQUESTS_OPTION3"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION3"].ToString(), "3"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION4"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION4"].ToString(), "4"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION5"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION5"].ToString(), "5"));
                    }
                }
            }

        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    public void PopulateOptions3(DataTable dt, int j)
    {
        try
        {
        Repeater repttrainer = ReptFeedBack_AllTrainer.Items[j].FindControl("ReptFeedBack_Trainer") as Repeater;
        for (int i = 0; i < repttrainer.Items.Count; i++)
        {
            RadioButtonList rdb = repttrainer.Items[i].FindControl("rdbTest") as RadioButtonList;
            Label lblQuestID = repttrainer.Items[i].FindControl("lblFeedQuesID") as Label;
            string strExp = "FEEDBACKQUESTS_ID = '" + lblQuestID.Text + "'";
            DataRow[] drRow = dt.Select(strExp);

            if (drRow.Length > 0)
            {
                foreach (DataRow dr in drRow)
                {
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION1"].ToString(), "1"));
                    rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION2"].ToString(), "2"));
                    if (dr["FEEDBACKQUESTS_OPTION3"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION3"].ToString(), "3"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION4"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION4"].ToString(), "4"));
                    }
                    if (dr["FEEDBACKQUESTS_OPTION5"].ToString() != String.Empty)
                    {
                        rdb.Items.Add(new ListItem(dr["FEEDBACKQUESTS_OPTION5"].ToString(), "5"));
                    }
                }
            }

        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingResponse", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}


     