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

public partial class Training_frm_TrainingApproval : System.Web.UI.Page
{

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
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TRAINING APPROVAL");
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

                    btn_Approve.Enabled = false;
                    btn_Reject.Enabled = false;
                }
                else
                {
                    btn_Approve.Enabled = true;
                    btn_Reject.Enabled = true;
                }

                LoadData();
                rdp_ApprovalDate.SelectedDate = DateTime.Now;
                rdp_ApprovalDate.Enabled = false;
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){ }", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion
    #region load trg under login user
    /// <summary>
    /// loading trgs under login user
    /// </summary>
    private void LoadData()
    {
        try
    {
        SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
        _obj_Smhr_TrgRqst.Mode = 8;
        _obj_Smhr_TrgRqst.TR_RAISEDBY = Convert.ToInt32(Session["emp_id"]);
        _obj_Smhr_TrgRqst.TR_ORG_ID = Convert.ToInt32(Session["org_id"]);//YYY
        DataTable DT = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
        if (DT.Rows.Count != 0)
        {
            RG_TrainingApproval.DataSource = DT;
            RG_TrainingApproval.DataBind();
        }
        else
        {
            DataTable DT1 = new DataTable();
            RG_TrainingApproval.DataSource = DT1;
            RG_TrainingApproval.DataBind();

        }
         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    #endregion

    //protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    //{
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "function pageLoad(){  ShowPopForm('" + Convert.ToString(e.CommandArgument) + "'); }", true);
    //}
    protected void RG_TrainingApproval_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }


    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Masters/Default.aspx", false);
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region reject trgs
    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
    {


        CheckBox chkBox = new CheckBox();
        Label lblID = new Label();
        int index;
        bool status = false;
        int i = 0;
        string str = "";
        for (index = 0; index <= RG_TrainingApproval.Items.Count - 1; index++)
        {
            chkBox = RG_TrainingApproval.Items[index].FindControl("chk_Choose") as CheckBox;
            lblID = RG_TrainingApproval.Items[index].FindControl("lbltrgID") as Label;
            if (chkBox.Checked)
            {
                if (str == "")
                    str = "" + lblID.Text + "";
                else
                    str = str + "," + lblID.Text + "";

                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                _obj_Smhr_TrgRqst.Mode = 9;
                _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lblID.Text);
                _obj_Smhr_TrgRqst.TR_APPROVEDBY = Convert.ToInt32(Session["emp_id"]);
                _obj_Smhr_TrgRqst.TR_STATUS = "Rejected";
                status = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
            }
            else
            {
                i = i + 1;
            }

           
        }

        if (i == RG_TrainingApproval.Items.Count)
        {
            BLL.ShowMessage(this, "Please Select Training");
            return;
        }
       
       
        if (status == true)
        {
            BLL.ShowMessage(this, "Selected Trainings Rejected");
            LoadData();
            RG_TrainingApproval.DataBind();
            //RG_ExpenseApproval.Visible = false;
            return;
        }


         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    #endregion
    #region trg approval
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
    {
        CheckBox chkBox = new CheckBox();
        Label lblID = new Label();
        string str = "";
        bool status = false;
        for (int index = 0; index <= RG_TrainingApproval.Items.Count - 1; index++)
        {
            chkBox = RG_TrainingApproval.Items[index].FindControl("chk_Choose") as CheckBox;
            
            lblID = RG_TrainingApproval.Items[index].FindControl("lbltrgID") as Label;
            if (chkBox.Checked)
            {
                if (str == "")
                    str = "" + lblID.Text + "";
                else
                    str = str + "," + lblID.Text + "";

                SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();

                _obj_Smhr_TrgRqst.Mode = 9;
                _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lblID.Text);
                _obj_Smhr_TrgRqst.TR_APPROVEDBY = Convert.ToInt32(Session["emp_id"]);
                _obj_Smhr_TrgRqst.TR_STATUS = "Approved";
                status = BLL.set_TrgRqst(_obj_Smhr_TrgRqst);
            }


           
        }

        if (string.IsNullOrEmpty(str))
        {
            BLL.ShowMessage(this, "Please Select Training");
            return;
        }
       
       
        if (status == true)
        {
            SMHR_TRAININGREQUEST _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
            _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lblID.Text);
            _obj_Smhr_TrgRqst.Mode = 13;
            DataTable dt_ger_tr = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
            if (dt_ger_tr.Rows.Count != 0)
            {
                for (int i = 0; i < dt_ger_tr.Rows.Count; i++)
                {
                    if (dt_ger_tr.Rows[i]["LOGIN_EMAILID"] != System.DBNull.Value)
                    {
                        Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_TRAINING @LOGIN_EMAILID='" + Convert.ToString(dt_ger_tr.Rows[i]["LOGIN_EMAILID"]) + "',@RAISEDBY='" + Convert.ToString(dt_ger_tr.Rows[i]["RAISEDBY"]) + "',@APPROVEDBY='" + Convert.ToString(dt_ger_tr.Rows[i]["APPROVEDBY"]) + "',@TR_TITLE='" + Convert.ToString(dt_ger_tr.Rows[i]["TR_TITLE"]) + "'");
                    }

                }
            }


            SMHR_TRAINER _obj_Smhr_Trner = new SMHR_TRAINER();
            _obj_Smhr_Trner.TRAINERDETAILS_TR_ID = Convert.ToInt32(lblID.Text);
            _obj_Smhr_Trner.Mode = 18;
            _obj_Smhr_Trner.TRAINERDETAILS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dttrgexist = BLL.get_TRAINer(_obj_Smhr_Trner);

            if (dttrgexist.Rows.Count != 0)
            {

                if (Convert.ToInt32(dttrgexist.Rows[0]["TRAINERDETAILS_EMPLOYEEID"]) != 0)
                {

                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lblID.Text);
                    _obj_Smhr_TrgRqst.Mode = 14;
                    DataTable dt_ger_tr1 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (dt_ger_tr1.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt_ger_tr1.Rows.Count; i++)
                        {
                            if (dt_ger_tr1.Rows[i]["LOGIN_EMAILID"] != System.DBNull.Value)
                            {
                                Dal.ExecuteNonQuery(" exec USP_SEND_EMAIL_TRAINEE @LOGIN_EMAILID  = '" + Convert.ToString(dt_ger_tr1.Rows[i]["LOGIN_EMAILID"]) + "',@EMPLOYEE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["EMPLOYEE"]) + "',@TR_TITLE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TR_TITLE"]) + "',@TS_STARTDATE ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TS_STARTDATE"]) + "',@TS_SESSIONS='" + Convert.ToString(dt_ger_tr1.Rows[i]["TS_SESSIONS"]) + "',@TS_STARTTIME ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TS_STARTTIME"]) + "',@TS_ENDTIME ='" + Convert.ToString(dt_ger_tr1.Rows[i]["TS_ENDTIME"]) + "'");
                            }
                        }
                    }
                }
                else
                {
                    _obj_Smhr_TrgRqst = new SMHR_TRAININGREQUEST();
                    _obj_Smhr_TrgRqst.TR_ID = Convert.ToInt32(lblID.Text);
                    _obj_Smhr_TrgRqst.Mode = 22;
                    DataTable dt_ger_tr2 = BLL.get_TrgRqst(_obj_Smhr_TrgRqst);
                    if (dt_ger_tr2.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt_ger_tr2.Rows.Count; i++)
                        {
                            if (dt_ger_tr2.Rows[i]["LOGIN_EMAILID"] != System.DBNull.Value)
                            {
                                Dal.ExecuteNonQuery(" exec USP_SEND_EMAIL_TRAINEE @LOGIN_EMAILID  = '" + Convert.ToString(dt_ger_tr2.Rows[i]["LOGIN_EMAILID"]) + "',@EMPLOYEE ='" + Convert.ToString(dt_ger_tr2.Rows[i]["EMPLOYEE"]) + "',@TR_TITLE ='" + Convert.ToString(dt_ger_tr2.Rows[i]["TR_TITLE"]) + "',@TS_STARTDATE ='" + Convert.ToString(dt_ger_tr2.Rows[i]["TS_STARTDATE"]) + "',@TS_SESSIONS='" + Convert.ToString(dt_ger_tr2.Rows[i]["TS_SESSIONS"]) + "',@TS_STARTTIME ='" + Convert.ToString(dt_ger_tr2.Rows[i]["TS_STARTTIME"]) + "',@TS_ENDTIME ='" + Convert.ToString(dt_ger_tr2.Rows[i]["TS_ENDTIME"]) + "'");
                            }

                        }
                    }

                }
            }

            BLL.ShowMessage(this, "Selected Trainings Approved");
            BLL.ShowMessage(this, "Notification Send");
            LoadData();
            RG_TrainingApproval.DataBind();
            //RG_ExpenseApproval.Visible = false;
            return;
        }


         }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_TrainingApproval", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    #endregion
}
