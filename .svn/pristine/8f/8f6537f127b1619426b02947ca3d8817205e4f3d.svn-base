using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using SMHR;
using System.Net.Mail;
using System.Configuration;

public partial class PMS_frm_GsApproval : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
    SPMS_APPRAISALIDP _obj_Spms_AppraisalIdp;
    SPMS_APRAISALAPPROVER _obj_Pms_AppApprover;
    SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls;
    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_NOTIFICATION _obj_Pms_Send_Notification;
    PMS_EMPSETUP _obj_pms_EmployeeSetup;
    SMHR_LOGININFO _obj_smhr_logininfo;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    PMS_GoalSettings _obj_GS;
    PMS_EMPSETUP _obj_Pms_EmpSetup;
    SPMS_ROLES _obj_Pms_Roles;
    SPMS_ROLEKRA _obj_Pms_RoleKra;
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
    GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Goal Setting Approval");
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
                    RG_ApprAppraisal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                //LoadEmployees();
                LoadBusinessUnit();
                Rm_Appraisal_PAGE.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BU.Items.Clear();
            rcmb_BU.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            RG_ApprAppraisal.Visible = false;
            tr_btns.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 31;
            _obj_GS.EMPID = Convert.ToInt32(rcmb_RpMgr.SelectedItem.Value);
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_EMP = Pms_Bll.get_GS(_obj_GS);
            if (dt_EMP.Rows.Count > 0)
            {
                RG_ApprAppraisal.DataSource = dt_EMP;
                RG_ApprAppraisal.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                RG_ApprAppraisal.DataSource = dt;
                RG_ApprAppraisal.DataBind();
            }
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox chk = RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
                chk.Checked = false;
            }
            if (RG_ApprAppraisal.Items.Count == 0)
            {
                tr_btns.Visible = false;
                BLL.ShowMessage(this, "No records to Display.");
                return;
            }
            else
            {
                tr_btns.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                LoadAppraisalCycle();
            }
            else
            {
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            rcmb_RpMgr.ClearSelection();
            rcmb_RpMgr.Items.Clear();
            rcmb_RpMgr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            RG_ApprAppraisal.Visible = false;
            tr_btns.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadAppraisalCycle()
    {
        try
        {
            rtxt_AppraisalCycle.ClearSelection();
            rtxt_AppraisalCycle.Items.Clear();
            rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 9;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.DataSource = DT_AppraisalCycle;
                rtxt_AppraisalCycle.DataTextField = "APPRCYCLE_NAME";
                rtxt_AppraisalCycle.DataValueField = "APPRCYCLE_ID";
                rtxt_AppraisalCycle.DataBind();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_AppraisalCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_AppraisalCycle.SelectedIndex > 0)
            {
                rcmb_RpMgr.Items.Clear();
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.Mode = 5;
                _obj_Spms_Appraisal.EMPID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_manager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);
                if (dt_manager.Rows.Count != 0)
                {
                    rcmb_RpMgr.DataSource = dt_manager;
                    rcmb_RpMgr.DataTextField = "RPTEMP_NAME";
                    rcmb_RpMgr.DataValueField = "RPTEMP_ID";
                    rcmb_RpMgr.DataBind();
                    rcmb_RpMgr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rcmb_RpMgr.ClearSelection();
                rcmb_RpMgr.Items.Clear();
                rcmb_RpMgr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            RG_ApprAppraisal.Visible = false;
            tr_btns.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_RpMgr_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_RpMgr.SelectedIndex > 0)
            {
                LoadGrid();
                RG_ApprAppraisal.Visible = true;
            }
            else
            {
                RG_ApprAppraisal.Visible = false;
                tr_btns.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int count = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox c = (CheckBox)RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select");
                if (c.Checked)
                {
                    count++;
                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text));
                    _obj_GS.GS_ID = Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["GS_ID"].Text));
                    _obj_GS.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedValue);
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GS.GS_STATUS = 1;
                    _obj_GS.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                    _obj_GS.LASTMDFDATE = DateTime.Now;
                    _obj_GS.GS_MODE = 32;
                    status = Pms_Bll.set_GS(_obj_GS);
                    if (status)
                        sendMail(Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text)), "Approved");
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one Employee to Approve.");
                return;
            }
            if (status)
            {
                BLL.ShowMessage(this, "Goal Settings for Selected Employees Approved Successfully.Notification Sent.");

                LoadGrid();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < RG_ApprAppraisal.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select");
                        if (c.Enabled)
                            c.Checked = true;
                        else
                            c.Checked = false;
                    }
                }
                else
                {
                    for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            int count = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox c = (CheckBox)RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select");
                if (c.Checked)
                {
                    count++;
                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text));
                    _obj_GS.GS_ID = Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["GS_ID"].Text));
                    _obj_GS.BUID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedValue);
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GS.GS_STATUS = 2;
                    _obj_GS.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                    _obj_GS.LASTMDFDATE = DateTime.Now;
                    _obj_GS.GS_MODE = 32;
                    status = Pms_Bll.set_GS(_obj_GS);
                    if (status)
                        sendMail(Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text)), "Rejected");
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one Employee to Reject.");
                return;
            }
            if (status)
            {
                BLL.ShowMessage(this, "Goal Settings for Selected Employees Rejected Successfully.Notification Sent.");
                LoadGrid();
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_ViewDetailsCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string EMP_ID = Convert.ToString(e.CommandArgument);
            string STR = "GS_APPROVAL";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "FeedBack_Details()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                "ShowPop('" + Convert.ToString(EMP_ID) + "','" + Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value) + "','" + STR + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    public void sendMail(int EMP_ID, string STR)
    {
        try
        {
            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(EMP_ID);
            _obj_PMS_getemployee.Mode = 6;
            DataTable dt = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["APPMGR_EMAIL"] != System.DBNull.Value && dt.Rows[0]["APPMGR_EMAIL"] != string.Empty &&
                    dt.Rows[0]["RPTMGR_EMAIL"] != System.DBNull.Value && dt.Rows[0]["RPTMGR_EMAIL"] != string.Empty)
                {
                    //MailMessage msgMail = new MailMessage();
                    //string From = string.Empty;
                    //string To = string.Empty;
                    //string Body = string.Empty;
                    //msgMail.From = new MailAddress("smtpmail@dhanushinfotech.com", "Smart HR");
                    ////msgMail.To.Add(Convert.ToString("priya.bulusu@dhanushinfotech.net"));

                    string toAddress, subject, body, ccAddress;
                    ccAddress = (Convert.ToString(dt.Rows[0]["APPMGR_EMAIL"]));
                    toAddress = (Convert.ToString(dt.Rows[0]["RPTMGR_EMAIL"]));
                    if (STR.Trim() == "Approved")
                    {
                        if (dt.Rows[0]["EMP_EMAIL"] != System.DBNull.Value && dt.Rows[0]["EMP_EMAIL"] != string.Empty)
                            toAddress = (Convert.ToString(dt.Rows[0]["EMP_EMAIL"]));
                        else
                            return;
                    }

                    subject = "Goal Setting";
                    body = "<html>" +
                                    "<body> " +
                                    "<p>Dear, " + Convert.ToString(dt.Rows[0]["RPTMGR_NAME"]) + " </p> " +
                                    "<p>Goal Setting is " + STR + " for " + Convert.ToString(dt.Rows[0]["EMP_NAME"]) + " for Appraisal Cycle - " + Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Text) + ". <br>" +
                                    "</p> " +
                                    "<p>Best Regards,<br/><br/>" +
                                    "Team Smart HR</p>" +
                                    "</body>" +
                                    " </html>";

                    BLL.SendMail(toAddress, ccAddress, subject, body);
                    //BLL.ShowMessage(this, "A Mail has been sent to the Reviewer.");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                }
            }
            //else
            //{
            //    BLL.ShowMessage(this, "Security Code is Invalid");
            //    return;
            //}
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GsApproval", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
