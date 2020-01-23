using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;

public partial class PMS_frm_Pms_TaskFeedback : System.Web.UI.Page
{
    PMS_FEEDBACK _obj_pms_Feedback;
    SPMS_PERIODICFEEDBACK _obj_Pms_PeriodicFeedback;


    #region pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        int KRAID = Request.QueryString["KRA_ID"] != null ? Convert.ToInt32(Request.QueryString["KRA_ID"]) : 0;
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                rdtp_Task_Feedbac.SelectedDate = DateTime.Now;
                rdtp_Task_Feedbac.Enabled = false;

                SPMS_KRA _obj_Spms_Kras = new SPMS_KRA();
                _obj_Spms_Kras.Mode = 2;
                _obj_Spms_Kras.KRA_ID = KRAID;// Session["KRA_ID"] != null ? Convert.ToInt32(Session["KRA_ID"]) : 0;
                _obj_Spms_Kras.KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_Kras(_obj_Spms_Kras);

                if (dt.Rows.Count > 0)
                {
                    rtxt_KRAName.Text = dt.Rows[0]["KRA_NAME"].ToString();
                    rtxt_KRAName.Visible = true;
                    lbl_KRA_Name.Visible = true;
                }
                else
                {
                    rtxt_KRAName.Visible = false;
                    rtxt_KRAName.Text = string.Empty;
                    lbl_KRA_Name.Visible = false;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_TaskFeedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region submit method

    protected void Btn_Submit_TaskFeedbac_Click(object sender, EventArgs e)
    {
        try
        {
            int r1 = Convert.ToInt32(rd_TaskRt.Value);
            if (r1 == 0)
            {

                Pms_Bll.ShowMessage(this, "Please Select Rating");
                return;
            }

            //string i = Convert.ToString(Session["goalid"]);
            //string r=Convert.ToString(Session["taskid"]);

            //string e1 = Convert.ToString(Session["kraid"]);

            _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
            _obj_Pms_PeriodicFeedback.Mode = 7;

            _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(Session["empid1"]);

            //if (i != string.Empty)
            //{
            //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["goalid"]);
            //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidgoal"]);
            //}
            //else if (r != string.Empty)
            //{
            //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["taskid"]);
            //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidtask"]);
            //}
            //else if (e1 != string.Empty)
            //{
            //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["kraid"]);
            //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidkra"]);
            //}
            _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["rolekarid"]);
            _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["TYPE"]);
            _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_PeriodicFeedback.GSLIFECYCLE = Convert.ToInt32(Session["APPCYCLE_ID"]);
            DataTable dtcomments = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
            for (int k = 0; k <= dtcomments.Rows.Count - 1; k++)
            {
                string z = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskFeedbac.Text));
                if (Convert.ToString(dtcomments.Rows[k]["FEEDBACK_COMMENTS"]) == z)
                {
                    Pms_Bll.ShowMessage(this, "Feedback Already Exists");
                    rtxt_TaskFeedbac.Text = string.Empty;
                    rd_TaskRt.Value = 0;
                    return;
                }


            }



            _obj_pms_Feedback = new PMS_FEEDBACK();
            _obj_pms_Feedback.Mode = 3;
            _obj_pms_Feedback.FEEDBACK_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskFeedbac.Text));
            _obj_pms_Feedback.FEEDBACK_RATING = Convert.ToInt32(rd_TaskRt.Value);
            _obj_pms_Feedback.FEEDBACK_DATE = rdtp_Task_Feedbac.SelectedDate.Value;
            _obj_pms_Feedback.FEEDBACK_MGR_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_pms_Feedback.FEEDBACK_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_pms_Feedback.FEEDBACK_CREATEDDATE = DateTime.Now;
            bool status = Pms_Bll.set_Feedback(_obj_pms_Feedback);
            if (status == true)
            {

                Pms_Bll.ShowMessage(this, "Manager Feedback Inserted");
                //Pms_Bll.ShowMessage(this, "Please click on Update link to complete this insertion");// to alert the user in continuation of process
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:Close();", true);

                _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
                _obj_Pms_PeriodicFeedback.Mode = 3;

                _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(Session["empid1"]);

                _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["TYPE"]);


                //if (i != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidgoal"]);
                //}
                //else if (r != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidtask"]);
                //}
                //else if (e1 != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(Session["pmidkra"]);
                //}


                _obj_pms_Feedback = new PMS_FEEDBACK();
                _obj_pms_Feedback.Mode = 4;
                DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
                _obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);

                //if (i != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["goalid"]);
                //}
                //else if (r != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["taskid"]);
                //}
                //else if (e1 != string.Empty)
                //{
                //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["kraid"]);
                //}
                _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Session["rolekarid"]);
                _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_PeriodicFeedback.PF_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;
                _obj_Pms_PeriodicFeedback.GSLIFECYCLE = Convert.ToInt32(Session["APPCYCLE_ID"]);
                bool status22 = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);

                //Label lnkupdate = new Label();
                //lnkupdate = (Label)PreviousPage.FindControl("lbl_Employee");
                //lnkupdate.Enabled = false;
                //ContentPlaceHolder cph1 = (ContentPlaceHolder)Page.PreviousPage.Master.FindControl("cphDefault")as ContentPlaceHolder;

                //Label lblemp = (Label)cph1.FindControl("lbl_Employee");
                //lblemp.Visible = false;


            }



        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_TaskFeedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion


}
