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

public partial class PMS_frm_ApprAppraisal_latest : System.Web.UI.Page
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
    string str;
    int Temp = 0;
    int status = 0;
    string strkra;
    int tempkra = 0;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Approver Appraisal");//Self Appraisal");
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
                    btn_Approve.Visible = false;
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
                //LoadEmployees();
                LoadBusinessUnit();
                Rm_Appraisal_PAGE.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_BU.Items.Clear();
            rcmb_BU.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            RG_ApprAppraisal.Visible = false;
            tr_comments.Visible = false;
            tr_btns.Visible = false;
            rtxt_comments.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            DataTable dt_EMP = new DataTable();

            ViewState["Status"] = 0;
            PMS_EMPSETUP _obj_Pms_EmpSetup;
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            //_obj_Pms_EmpSetup.Mode = 19;
            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_RpMgr.SelectedItem.Value);
            //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_Pms_EmpSetup.GSLIFECYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
            _obj_Pms_EmpSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_EMP = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

            int logEmpID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtAppProcessEmpData = BLL.get_PMS_APPROVAL_PROCESS_BY_ORG_ID(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BU.SelectedValue));

            if (dtAppProcessEmpData.Rows.Count > 0)
            {
                if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_1"]))
                {
                    //_obj_Pms_EmpSetup.Mode = 1;
                    _obj_Pms_EmpSetup.Mode = 23;
                }
                else if (logEmpID == Convert.ToInt32(string.IsNullOrEmpty(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"].ToString()) ? 0 : Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"])))
                {
                    _obj_Pms_EmpSetup.Mode = 24;
                }
                else if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_3"]))
                {
                    _obj_Pms_EmpSetup.Mode = 25;
                }
                else
                {
                    //status = 1;
                    _obj_Pms_EmpSetup.Mode = 0;
                }
            }
            else
            {
                status = 2;
            }

            dt_EMP = BLL.Load_Pms_Approver_Appraisal_Grid(_obj_Pms_EmpSetup);
            //dt_EMP = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

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
            int count = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox chk = RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
                if (Convert.ToString(dt_EMP.Rows[index]["APPRAISAL_STATUS"]) == "1" || Convert.ToString(dt_EMP.Rows[index]["APPRAISAL_STATUS"]) == "2" || Convert.ToString(dt_EMP.Rows[index]["APPRAISAL_STATUS"]) == "3")
                {
                    chk.Enabled = true;
                }
                else
                {
                    chk.Enabled = false;
                    count++;
                }
                chk.Checked = false;
            }
            if (count == RG_ApprAppraisal.Items.Count)
            {
                if (RG_ApprAppraisal.Items.Count == 0)
                    ViewState["Status"] = 2;
                else
                    ViewState["Status"] = 1;
                tr_comments.Visible = false;
                tr_btns.Visible = false;
                rtxt_comments.Text = string.Empty;
            }
            else
            {
                tr_comments.Visible = true;
                tr_btns.Visible = true;
                rtxt_comments.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
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
            tr_comments.Visible = false;
            tr_btns.Visible = false;
            rtxt_comments.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalnew", ex.StackTrace, DateTime.Now);
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
                //_obj_Spms_Appraisal.Mode = 5;
                //_obj_Spms_Appraisal.EMPID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Spms_Appraisal.Mode = 1;
                _obj_Spms_Appraisal.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_manager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);
                if (dt_manager.Rows.Count != 0)
                {
                    rcmb_RpMgr.DataSource = dt_manager;
                    rcmb_RpMgr.DataTextField = "MANAGER";
                    rcmb_RpMgr.DataValueField = "REPORTINGMGR_ID";
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
            tr_comments.Visible = false;
            tr_btns.Visible = false;
            rtxt_comments.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
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

                if (status == 1)
                {
                    rcmb_BU.SelectedIndex = 0;
                    rcmb_RpMgr.Items.Clear();
                    rcmb_RpMgr.ClearSelection();
                    rcmb_RpMgr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rtxt_AppraisalCycle.SelectedIndex = 0;

                    BLL.ShowMessage(this, "You Dont have enough Permissions to Access this page..");
                    return;
                }
                else if (status == 2)
                {
                    rcmb_BU.SelectedIndex = 0;
                    rcmb_RpMgr.Items.Clear();
                    rcmb_RpMgr.ClearSelection();
                    rcmb_RpMgr.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rtxt_AppraisalCycle.SelectedIndex = 0;

                    BLL.ShowMessage(this, "No Records to display for this Organisation..");
                    return;
                }
                else
                {
                    RG_ApprAppraisal.Visible = true;
                    if (Convert.ToInt32(ViewState["Status"]) == 1)
                    {
                        BLL.ShowMessage(this, "Approver Appraisal Already Finalized.");
                        tr_comments.Visible = false;
                        tr_btns.Visible = false;
                        rtxt_comments.Text = string.Empty;
                        return;
                    }
                    else if (Convert.ToInt32(ViewState["Status"]) == 2)
                    {
                        BLL.ShowMessage(this, "No Records to Display.");
                        tr_comments.Visible = false;
                        tr_btns.Visible = false;
                        rtxt_comments.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        tr_comments.Visible = true;
                        tr_btns.Visible = true;
                        rtxt_comments.Text = string.Empty;
                    }
                }
            }
            else
            {
                RG_ApprAppraisal.Visible = false;
                tr_comments.Visible = false;
                tr_btns.Visible = false;
                rtxt_comments.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {
            int logEmpID = Convert.ToInt32(Session["EMP_ID"]);
            bool status = false;
            int count = 0;
            DataTable dtAppProcessEmpData = BLL.get_PMS_APPROVAL_PROCESS_BY_ORG_ID(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BU.SelectedValue));

            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox chk = RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    count++;
                    string EMP_ID = Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text);
                    string rtng = Convert.ToString(RG_ApprAppraisal.Items[index]["APPRAISAL_AVGRTG"].Text);
                    //RadRating rtng = RG_ApprAppraisal.Items[index].FindControl("rtng_emprtng") as RadRating;

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                    _obj_Pms_EmpGoalSetting.Mode = 8;
                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(EMP_ID);
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                    }
                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    _obj_GS = new PMS_GoalSettings();
                    if (dt.Rows.Count != 0)
                        _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    else
                        _obj_GS.GS_ID = 0;
                    //TO UPDATE THE STATUS IN APPRAISAL
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(EMP_ID);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_STATUS = 3;
                    _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
                    _obj_Spms_Appraisal.Mode = 48;
                    status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

                    //TO GET THE APPRAISAL ID
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(EMP_ID);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_app_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    //TO CHECK WHETHER DATA EXISTS IN APPRAISAL APPROVER OR NOT
                    _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
                    if (dt_app_id.Rows.Count != 0)
                        _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                    else
                        _obj_Pms_AppApprover.APP_APPROVER_APP_ID = 0;
                    _obj_Pms_AppApprover.Mode = 6;
                    DataTable dt_appr = Pms_Bll.get_AppApprover(_obj_Pms_AppApprover);
                    if (dt_appr.Rows.Count == 0)
                    {
                        //TO INSERT DATA INTO APPRAISAL APPROVER
                        _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = 0;
                        _obj_Pms_AppApprover.Mode = 3;
                        _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(rtng);
                        _obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Convert.ToString(Pms_Bll.ReplaceQuote(rtxt_comments.Text));
                        _obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;
                        _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        if (dtAppProcessEmpData.Rows.Count > 0)
                        {
                            if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_1"]))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 1;
                            }
                            else if (logEmpID == Convert.ToInt32(string.IsNullOrEmpty(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"].ToString()) ? 0 : Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"])))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 2;
                            }
                            else if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_3"]))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 3;
                            }
                            else
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 0;
                            }
                        }

                        bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
                    }
                    else
                    {
                        //TO UPDATE DATA IN APPRAISAL APPROVER
                        _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
                        if (dt_app_id.Rows.Count != 0)
                            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                        else
                            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = 0;
                        _obj_Pms_AppApprover.Mode = 8;
                        _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(rtng);
                        //_obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Convert.ToString(rtxt_comments.Text.Replace("'", "''"));       
                        _obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Convert.ToString(Pms_Bll.ReplaceQuote(rtxt_comments.Text));
                        _obj_Pms_AppApprover.APP_APPROVER_LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_AppApprover.APP_APPROVER_LASTMDFDATE = DateTime.Now;
                        _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        if (dtAppProcessEmpData.Rows.Count > 0)
                        {
                            if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_1"]))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 1;
                            }
                            else if (logEmpID == Convert.ToInt32(string.IsNullOrEmpty(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"].ToString()) ? 0 : Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_2"])))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 2;
                            }
                            else if (logEmpID == Convert.ToInt32(dtAppProcessEmpData.Rows[0]["PMS_APPROVAL_PROCESS_EMP_ID_3"]))
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 3;
                            }
                            else
                            {
                                _obj_Pms_AppApprover.APP_APPROVER_STATUS = 0;
                            }
                        }

                        bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
                    }
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one Employee to Approve.");
                return;
            }
            BLL.ShowMessage(this, "Approver Comments Finalized Successfully.");
            LoadGrid();
            Rm_Appraisal_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Reject_Click(object sender, EventArgs e)
    {
        try
        {
            bool status10;
            bool status11;
            string EMP_ID = string.Empty;
            string EMP_NAME = string.Empty;
            DataTable dtemployee223;
            DataTable dtemployee22;
            DataTable dtemployee224;
            string HR = string.Empty;
            string RpMgr = string.Empty;
            string Email = string.Empty;
            string APPR_EMAIL = string.Empty;
            int count = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                CheckBox chk = RG_ApprAppraisal.Items[index].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    count++;
                    EMP_ID = Convert.ToString(RG_ApprAppraisal.Items[index]["EMP_ID"].Text);
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(EMP_ID);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);

                    _obj_Spms_Appraisal.Mode = 5;

                    DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dtgoal4.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Spms_Appraisal.EMPID = Convert.ToInt32(EMP_ID);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //TO GET THE EMP DETAILS
                    _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
                    _obj_Pms_AppDiscDtls.Mode = 6;
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY = Convert.ToInt32(EMP_ID);
                    dtemployee22 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);
                    //TO ONSERT DATA INTO APPRAISAL_REJECT TABLE
                    _obj_Spms_Appraisal.Mode = 6;
                    _obj_Spms_Appraisal.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.EMPID = Convert.ToInt32(EMP_ID);
                    _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
                    _obj_Spms_Appraisal.APP_REJECT_COMMENTS = Convert.ToString(rtxt_comments.Text.Replace("'", "''"));
                    _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(dtemployee22.Rows[0]["EMP_BU_ID"]);
                    _obj_Spms_Appraisal.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    bool st_reject = Pms_Bll.set_EmpRejectdetails(_obj_Spms_Appraisal);

                    _obj_Spms_Appraisal.Mode = 4;
                    //if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
                    //{
                    //    BLL.ShowMessage(this, "Please do Appraisal Discussion Before Reject.");
                    //    return;
                    //}
                    _obj_Spms_Appraisal.Mode = 3;
                    bool st = Pms_Bll.set_EmpRatingdetails(_obj_Spms_Appraisal);

                    Pms_Bll.ShowMessage(this, "Rejected Successfully");
                    _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
                    _obj_Pms_AppDiscDtls.Mode = 9;
                    _obj_Pms_AppDiscDtls.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    dtemployee223 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);




                    //if ((dtemployee22.Rows.Count != 0))
                    //{
                    //    Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_PMS_APPraisalReject_Backup @HR_name='" + Convert.ToString(dtemployee223.Rows[0]["HrMANAGER"]) + "',@EMPLOYEEmail='" + Convert.ToString(dtemployee22.Rows[0]["employee_EMAILID"]) + "',@REPORTINGMANAGER='" + Convert.ToString(dtemployee22.Rows[0]["REPORTINGMANAGER"]) + "',@EMPNAME='" + Convert.ToString(dtemployee22.Rows[0]["employeename"]) + "'");
                    //    status10 = true;

                    //}

                    //else
                    //{
                    //    status10 = false;
                    //}
                    _obj_Pms_AppDiscDtls.Mode = 7;
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY = Convert.ToInt32(EMP_ID);
                    dtemployee224 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);

                    HR = Convert.ToString(dtemployee223.Rows[0]["HrMANAGER"]);
                    RpMgr = Convert.ToString(dtemployee224.Rows[0]["REPORTINGMANAGER"]);
                    Email = Convert.ToString(dtemployee224.Rows[0]["LOGIN_EMAILID_rmgr"]);
                    APPR_EMAIL = Convert.ToString(dtemployee224.Rows[0]["APPR_EMAIL"]);
                    if (EMP_NAME == string.Empty)
                        EMP_NAME = Convert.ToString(dtemployee224.Rows[0]["employee"]);
                    else
                        EMP_NAME = string.Concat(EMP_NAME, ",", Convert.ToString(dtemployee224.Rows[0]["employee"]));
                }
            }
            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one Employee to Reject.");
                return;
            }
            if (Email != string.Empty)
            {
                Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_PMS_APPraisalRejetomgr @HR_name='" + HR + "',@empname='" + Convert.ToString(EMP_NAME)
                    + "',@REPORTINGMANAGERname='" + RpMgr + "',@REPORTINGMANAGERmail='" + Email
                    + "',@APPCYCLE='" + Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Text)
                    + "',@APPR_EMAIL= '" + APPR_EMAIL + "'");
                status11 = true;
            }
            else
            {
                status11 = false;
            }
            if (status11)
                Pms_Bll.ShowMessage(this, "Notification Send");
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_ViewDetailsCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string EMP_ID = Convert.ToString(e.CommandArgument);
            string STR = "APPR_APPROVAL";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "FeedBack_Details()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                "ShowPop('" + Convert.ToString(EMP_ID) + "','" + Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value) + "','" + STR + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_ApprAppraisal_latest", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
