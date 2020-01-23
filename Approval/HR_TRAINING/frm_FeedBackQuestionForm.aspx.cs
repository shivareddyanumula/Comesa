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
public partial class Training_frm_FeedBackQuestionForm : System.Web.UI.Page
{
    SMHR_TRAININGFEEDBACK _obj_SMHR_TRAININGFEEDBACK_RESPONSE;

    #region pageload methods
    /// <summary>
    /// page load methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                displayOptions();
                //Rg_EMIDATA.DataSource = Session["datatable"];
                //Rg_EMIDATA.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestionForm", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
        base.InitializeCulture();
    }

    #endregion


   
    #region display options
    /// <summary>
    /// to display options
    /// </summary>
    private void displayOptions()
    {
        try
        {
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK();
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.Validate;
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_BU_ID = Convert.ToInt32(Session["BU_ID"]);
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_CATEGORY = Convert.ToString(Session["CATEGORY"]);
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_TR_ID = Convert.ToInt32(Session["TR_ID"]);
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_NAME = Convert.ToString(Session["FEEDBACK_NAME"]);
        DataTable dt = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);

        _obj_SMHR_TRAININGFEEDBACK_RESPONSE = new SMHR_TRAININGFEEDBACK();
        _obj_SMHR_TRAININGFEEDBACK_RESPONSE.OPERATION = operation.MODE2;
        if (dt.Rows.Count != 0)
        {
            _obj_SMHR_TRAININGFEEDBACK_RESPONSE.FEEDBACK_ID = Convert.ToInt32(dt.Rows[0]["FEEDBACK_ID"]);
        }
        DataTable DT1 = BLL.get_FeedbackResponse(_obj_SMHR_TRAININGFEEDBACK_RESPONSE);


        if (dt.Rows.Count != 0)
        {
            ReptFeedBack_Admin.DataSource = DT1;
            ReptFeedBack_Admin.DataBind();
            PopulateOptions(DT1);
            lbl_Admin.Visible = true;
            //lblFeedQuesID.Visible = true;
            lbl_TrainingName.Text = "Training Name : " + Convert.ToString(dt.Rows[0]["TR_TITLE"]);
            lbl_FeedBackDate.Text = "FeedBack Created Date : " + Convert.ToDateTime(dt.Rows[0]["FEEDBACK_CREATEDDATE"]);
        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestionForm", ex.StackTrace, DateTime.Now);
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
                       
                    }
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_FeedBackQuestionForm", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion


}
