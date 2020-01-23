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

public partial class PMS_frm_PmsApproverAppraisalnew : System.Web.UI.Page
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

    string strkra;
    int tempkra = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                //LoadEmployees();



                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Self Appraisal");
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
                    btn_Approve_Detail.Visible = false;
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
                LoadBusinessUnit();
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                //rdtp_DATEofAppraisal.SelectedDate = DateTime.Now;
                //rdtp_DATEofAppraisal.Enabled = false;
                Rm_Appraisal_PAGE.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
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
            //rtxt_AppraisalCycle.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            rtxt_Project.Text = string.Empty;
            rtxt_RpMgr.Text = string.Empty;
            rcmb_EmployeeType.Items.Clear();
            rtxt_AppraisalCycle.Items.Clear();
            //btn_Approve.Visible = false;
            //rtxt_final_comments.Visible = false;
            //rdt_final_rtng.Visible = false;
            //tr_final_rtng.Visible = false;
            //tr_final_comments.Visible = false;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(Convert.ToInt32(rcmb_BU.SelectedItem.Value));
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS = new PMS_GoalSettings();
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;

            _obj_GS.GS_MODE = 27;
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                RG_ApprAppraisal.DataSource = dt_details;
                RG_ApprAppraisal.DataBind();
            }
            RG_ApprAppraisal.Visible = true;
            int count = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                if (dt_details.Rows[index]["APPR_FIXED"] != System.DBNull.Value)
                {
                    if (Convert.ToString(dt_details.Rows[index]["APPR_FIXED"]) != string.Empty)
                    {
                        if (Convert.ToString(dt_details.Rows[index]["APPR_FIXED"]) == "1")
                        {
                            //RG_MgrAppraisal.Items[index].Enabled = false;
                            count++;
                        }
                        else
                        {
                            //RG_MgrAppraisal.Items[index].Enabled = true;
                        }
                    }
                    else
                    {
                        //RG_MgrAppraisal.Items[index].Enabled = true;
                    }
                }
                else
                {
                    //RG_MgrAppraisal.Items[index].Enabled = true;
                }
            }
            if (count == RG_ApprAppraisal.Items.Count)
            {
                ViewState["Status"] = 1;
                //btn_Submit.Visible = false;
                //btn_Finalise.Visible = false;
                //btn_Cancel.Visible = true;
            }
            //if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            //{
            //    btn_Approve.Visible = false;
            //}
            //else
            //{
            //    btn_Approve.Visible = true;
            //}
            //tr_final_rtng.Visible = true;
            //tr_final_comments.Visible = true;

            //COMMENTED ON 18.01.2012
            //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
            //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            //_obj_Spms_Appraisal.Mode = 47;
            //_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_final = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            //if (dt_final.Rows.Count > 0)
            //{
            //    //rdt_final_rtng.Value = Convert.ToDecimal(dt_final.Rows[0]["FINAL_RATING"]);
            //    //if (Convert.ToString(dt_final.Rows[0]["APPRAISAL_STATUS"]) == "2")
            //    //    rtxt_final_comments.Enabled = true;
            //    //else
            //    //    rtxt_final_comments.Enabled = false;

            //}
            //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
            //_obj_Spms_Appraisal.Mode = 22;
            //_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            //DataTable dt_app_appr = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            //if (dt_app_appr.Rows.Count > 0)
            //{
            //    //rtxt_final_comments.Text = Convert.ToString(dt_app_appr.Rows[0]["APP_APPROVER_COMMENTS"]);
            //    //ViewState["Status"] = 1;
            //}
            //else
            //{
            //    //ViewState["Status"] = 0;
            //    //rtxt_final_comments.Text = string.Empty;
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    //protected void btn_Approve_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        bool status = false;
    //        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
    //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
    //        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

    //        _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
    //        _obj_Pms_EmpGoalSetting.Mode = 8;
    //        _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
    //        if (dtappid.Rows.Count != 0)
    //        {
    //            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
    //        }
    //        else
    //        {
    //            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
    //        }
    //        _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
    //        _obj_GS = new PMS_GoalSettings();
    //        if (dt.Rows.Count != 0)
    //            _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
    //        else
    //            _obj_GS.GS_ID = 0;
    //       //TO UPDATE THE STATUS IN APPRAISAL
    //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
    //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
    //        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
    //        _obj_Spms_Appraisal.APPRAISAL_STATUS = 3;
    //        _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
    //        _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
    //        _obj_Spms_Appraisal.Mode = 48;
    //        status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

    //        //TO GET THE APPRAISAL ID
    //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();
    //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
    //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
    //        _obj_Spms_Appraisal.Mode = 5;
    //        _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        DataTable dt_app_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

    //        //TO INSERT DATE INTO APPRAISAL APPROVER
    //        _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
    //        if (dt_app_id.Rows.Count != 0)
    //            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
    //        else
    //            _obj_Pms_AppApprover.APP_APPROVER_APP_ID = 0;
    //        _obj_Pms_AppApprover.Mode = 3;
    //        _obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_final_comments.Text));
    //        _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(rdt_final_rtng.Value);
    //        _obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = Convert.ToInt32(Session["user_id"]);
    //        _obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;
    //        _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
    //        if (status1 == true)
    //        {
    //            btn_Approve.Visible = false;
    //            rtxt_final_comments.Enabled = false;
    //            BLL.ShowMessage(this, "Approver Comments Finalised Successfully.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //protected void btn_Cancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LoadGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                LoadAppraisalCycle();
                //rcmb_EmployeeType.Items.Clear();
                //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.MODE = 8;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //if (dtappidzzR.Rows.Count != 0)
                //{
                //    PMS_EMPSETUP _obj_Pms_EmpSetup;
                //    _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                //    _obj_Pms_EmpSetup.Mode = 19;
                //    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //    _obj_Pms_EmpSetup.GSLIFECYCLE = Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                //    _obj_Pms_EmpSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt_EMP = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                //    if (dt_EMP.Rows.Count != 0)
                //    {
                //        rcmb_EmployeeType.DataSource = dt_EMP;
                //        rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                //        rcmb_EmployeeType.DataValueField = "EMP_ID";
                //        rcmb_EmployeeType.DataBind();
                //        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //    }
                //}
            }
            else
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            RG_ApprAppraisal.Visible = false;
            //rtxt_AppraisalCycle.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            rtxt_Project.Text = string.Empty;
            rtxt_RpMgr.Text = string.Empty;
            rtxt_Role.Text = string.Empty;
            rcmb_EmployeeType.ClearSelection();
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rtxt_final_comments.Visible = false;
            //rdt_final_rtng.Visible = false;
            //tr_final_rtng.Visible = false;
            //tr_final_comments.Visible = false;
            //btn_Approve.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
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
                rtxt_AppraisalCycle.DataSource = DT_AppraisalCycle;
                rtxt_AppraisalCycle.DataTextField = "APPRCYCLE_NAME";
                rtxt_AppraisalCycle.DataValueField = "APPRCYCLE_ID";
                rtxt_AppraisalCycle.DataBind();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt6 = new DataTable();

                rtxt_AppraisalCycle.DataSource = dt6;

                rtxt_AppraisalCycle.DataBind();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                //LoadAppraisalCycle();
                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                if (dtbuid1.Rows.Count != 0)
                {
                    rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                    rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                    rtxt_RpMgr.Enabled = false;
                    rtxt_GpMgr.Enabled = false;

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    //where i am getting apprisal cycle 
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_GS = new PMS_GoalSettings();
                        _obj_GS.GS_MODE = 9;
                        _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                        DataTable dt1 = Pms_Bll.get_GS(_obj_GS);
                        if (dt1.Rows.Count != 0)
                        {
                            rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                            rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                            //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                            //lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                            //rtxt_AppraisalCycle.Enabled = false;
                            rtxt_Role.Enabled = false;
                            rtxt_Project.Enabled = false;
                            LoadGrid();
                            RG_ApprAppraisal.Visible = true;
                            if (Convert.ToInt32(ViewState["Status"]) == 1)
                            {
                                BLL.ShowMessage(this, "Approver Appraisal Already Fianlized.");
                                //btn_Approve.Visible = false;
                                return;
                            }
                        }
                        else
                        {
                            Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                            rtxt_Role.Text = string.Empty;
                            rtxt_Project.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;
                            RG_ApprAppraisal.Visible = false;
                            //tr_final_rtng.Visible = false;
                            //tr_final_comments.Visible = false;
                            //btn_Approve.Visible = false;
                        }
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                        rtxt_Role.Text = string.Empty;
                        rtxt_Project.Text = string.Empty;
                        //rtxt_AppraisalCycle.Text = string.Empty;
                        RG_ApprAppraisal.Visible = false;
                        //tr_final_rtng.Visible = false;
                        //tr_final_comments.Visible = false;
                        //btn_Approve.Visible = false;
                    }
                }

                else
                {
                    RG_ApprAppraisal.Visible = false;
                    rtxt_RpMgr.Text = string.Empty;
                    rtxt_GpMgr.Text = string.Empty;
                    rtxt_Role.Text = string.Empty;
                    rtxt_Project.Text = string.Empty;
                    //tr_final_rtng.Visible = false;
                    //tr_final_comments.Visible = false;
                    //btn_Approve.Visible = false;
                    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                    return;
                }
            }
            else
            {

                rtxt_Role.Text = string.Empty;
                rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                RG_ApprAppraisal.Visible = false;
                rtxt_RpMgr.Text = string.Empty;
                rtxt_GpMgr.Text = string.Empty;
                //tr_final_rtng.Visible = false;
                //tr_final_comments.Visible = false;
                //btn_Approve.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_AppraisalCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_AppraisalCycle.SelectedIndex > 0)
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzzR.Rows.Count != 0)
                {
                    PMS_EMPSETUP _obj_Pms_EmpSetup;
                    _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                    _obj_Pms_EmpSetup.Mode = 19;
                    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                    _obj_Pms_EmpSetup.GSLIFECYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Pms_EmpSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_EMP = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                    if (dt_EMP.Rows.Count != 0)
                    {
                        rcmb_EmployeeType.DataSource = dt_EMP;
                        rcmb_EmployeeType.DataTextField = "EMPLOYEE_NAME";
                        rcmb_EmployeeType.DataValueField = "EMP_ID";
                        rcmb_EmployeeType.DataBind();
                        rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    }
                }
                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //_obj_pms_EmployeeSetup.BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //_obj_pms_EmployeeSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_pms_EmployeeSetup);
                //if (dtbuid1.Rows.Count != 0)
                //{
                //    //rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                //    //rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                //    //rtxt_RpMgr.Enabled = false;
                //    //rtxt_GpMgr.Enabled = false;

                //    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 8;
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //    //where i am getting apprisal cycle 
                //    if (dtappid.Rows.Count != 0)
                //    {
                //        _obj_GS = new PMS_GoalSettings();
                //        _obj_GS.GS_MODE = 9;
                //        _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //        _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //        DataTable dt1 = Pms_Bll.get_GS(_obj_GS);
                //        if (dt1.Rows.Count != 0)
                //        {
                //            rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                //            rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                //            //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                //            //lbl_Apprais_id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                //            //rtxt_AppraisalCycle.Enabled = false;
                //            rtxt_Role.Enabled = false;
                //            rtxt_Project.Enabled = false;
                //            LoadGrid();
                //            RG_ApprAppraisal.Visible = true;
                //            if (Convert.ToInt32(ViewState["Status"]) == 1)
                //            {
                //                BLL.ShowMessage(this, "Approver Appraisal Already Fianlized.");
                //                //btn_Approve.Visible = false;
                //                return;
                //            }
                //        }
                //        else
                //        {
                //            Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                //            rtxt_Role.Text = string.Empty;
                //            rtxt_Project.Text = string.Empty;
                //            //rtxt_AppraisalCycle.Text = string.Empty;
                //            RG_ApprAppraisal.Visible = false;
                //            //tr_final_rtng.Visible = false;
                //            //tr_final_comments.Visible = false;
                //            //btn_Approve.Visible = false;
                //        }
                //    }
                //    else
                //    {
                //        Pms_Bll.ShowMessage(this, "Goal Setting Has Not Done");
                //        rtxt_Role.Text = string.Empty;
                //        rtxt_Project.Text = string.Empty;
                //        //rtxt_AppraisalCycle.Text = string.Empty;
                //        RG_ApprAppraisal.Visible = false;
                //        //tr_final_rtng.Visible = false;
                //        //tr_final_comments.Visible = false;
                //        //btn_Approve.Visible = false;
                //    }
                //}

                //else
                //{
                //    rtxt_Role.Text = string.Empty;
                //    rtxt_Project.Text = string.Empty;
                //    RG_ApprAppraisal.Visible = false;
                //    //tr_final_rtng.Visible = false;
                //    //tr_final_comments.Visible = false;
                //    //btn_Approve.Visible = false;
                //    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                //    return;
                //}
            }
            else
            {
                rtxt_Role.Text = string.Empty;
                rtxt_Project.Text = string.Empty;
                RG_ApprAppraisal.Visible = false;
                rtxt_RpMgr.Text = string.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            rtxt_Role.Text = string.Empty;
            rtxt_Project.Text = string.Empty;
            RG_ApprAppraisal.Visible = false;
            rtxt_RpMgr.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Approve_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            int tot_wt = 0;
            int tot_goal_wt = 0;
            int tot_kra_wt = 0;
            int tot_idp_wt = 0;
            for (int index = 0; index < RG_ApprAppraisal.Items.Count; index++)
            {
                Label lbltype = new Label();
                lbltype = RG_ApprAppraisal.Items[index].FindControl("lbl_type") as Label;
                tot_wt = tot_wt + Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                if (lbltype.Text.Trim() == "Goal")
                    tot_goal_wt = tot_goal_wt + Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                else if (lbltype.Text.Trim() == "IDP")
                    tot_idp_wt = tot_idp_wt + Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
                else
                    tot_kra_wt = tot_kra_wt + Convert.ToInt32(Convert.ToString(RG_ApprAppraisal.Items[index]["WEIGHTAGE"].Text).Trim());
            }
            //TO GET THE AVG RATINGS FOR THAT APPRAISAL
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.Mode = 45;
            DataTable dt_avg_rtngs = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            decimal goal_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_GOAL_AVGRTG"]);
            decimal kra_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_KRA_AVGRTG"]);
            decimal idp_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APPRAISAL_IDP_AVGRTG"]);
            decimal appr_rtng = Convert.ToDecimal(dt_avg_rtngs.Rows[0]["APP_APPROVER_RATING"]);

            bool status = false;
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
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
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_STATUS = 3;
            _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
            _obj_Spms_Appraisal.Mode = 48;
            status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);

            //TO GET THE APPRAISAL ID
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.Mode = 5;
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_app_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

            if (lbl_type_text.Text.Trim() == "Goal")
            {
                //TO UPDATE THE DATA IN APPRAISAL GOALS WITH APPROVER COMMENTS
                _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
                if (dt_app_id.Rows.Count != 0)
                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                else
                    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
                _obj_Spms_AppraisalGoal.APP_GOALS_APPR_RATING = Convert.ToDecimal(rtng_appr_Detail.Value);
                _obj_Spms_AppraisalGoal.APP_GOALS_APPR_COMMENTS = Convert.ToString(rtxt_appr_Comments_Detail.Text.Replace("'", "''"));
                _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                _obj_Spms_AppraisalGoal.APP_GOALS_APPR_FIXED = 1;
                _obj_Spms_AppraisalGoal.APP_GOAL_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_Spms_AppraisalGoal.Mode = 20;
                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_AppraisalGoal.APP_GOALS_LASTMDFDATE = DateTime.Now;
                bool status10 = Pms_Bll.set_AppraisalGoal(_obj_Spms_AppraisalGoal);

                //TO GET THE WEIGHTAGE
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_GSdetails.GS_DETAILS_MODE = 8;
                DataTable dt_goal_wt = Pms_Bll.get_GSdetails(_obj_GSdetails);

                //CALCULATING AVG RATING
                goal_rtng = goal_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_goal_wt.Rows[0]["GSDTL_WEIGHTAGE"])) / tot_goal_wt;
                appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_goal_wt.Rows[0]["GSDTL_WEIGHTAGE"])) / tot_wt;
            }
            else if (lbl_type_text.Text.Trim() == "IDP")
            {
                //UPDATING THE APPRAISAL IDP DATA WITH STATUS OF FIXED
                _obj_Spms_AppraisalIdp = new SPMS_APPRAISALIDP();
                _obj_Spms_AppraisalIdp.APP_IDP_APPR_RATING = Convert.ToDecimal(rtng_appr_Detail.Value);
                _obj_Spms_AppraisalIdp.APP_IDP_APPR_COMMENTS = Convert.ToString(rtxt_appr_Comments_Detail.Text.Replace("'", "''"));
                if (dt_app_id.Rows.Count != 0)
                    _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                else
                    _obj_Spms_AppraisalIdp.APP_IDP_APP_ID = 0;
                _obj_Spms_AppraisalIdp.APP_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_Spms_AppraisalIdp.APP_IDP_APPR_FIXED = 1;
                _obj_Spms_AppraisalIdp.Mode = 21;
                _obj_Spms_AppraisalIdp.APP_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_AppraisalIdp.APP_IDP_LASTMDFDATE = DateTime.Now;
                bool status10 = Pms_Bll.set_AppraisalIdp(_obj_Spms_AppraisalIdp);

                //TO GET THE WEIGHTAGE
                _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_goalIDPdetails.MODE = 10;
                DataTable dt_idp_wt = Pms_Bll.get_GsIDP(_obj_Pms_goalIDPdetails);

                //CALCULATING AVG RATING
                idp_rtng = idp_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_idp_wt.Rows[0]["GS_IDP_WEIGHTAGE"])) / tot_idp_wt;
                appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_idp_wt.Rows[0]["GS_IDP_WEIGHTAGE"])) / tot_wt;
            }
            else//FOR KRA
            {
                //UPDATING THE APPRAISAL KRA DATA WITH STATUS OF FIXED
                _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
                _obj_Spms_AppraisalKra.APP_KRA_APPR_RATING = Convert.ToDecimal(rtng_appr_Detail.Value);
                _obj_Spms_AppraisalKra.APP_KRA_APPR_COMMENTS = Convert.ToString(rtxt_appr_Comments_Detail.Text.Replace("'", "''"));
                if (dt_app_id.Rows.Count != 0)
                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dt_app_id.Rows[0]["APPRAISAL_ID"]);
                else
                    _obj_Spms_AppraisalKra.APP_KRA_APP_ID = 0;
                _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_Spms_AppraisalKra.APP_KRA_APPR_FIXED = 1;
                _obj_Spms_AppraisalKra.Mode = 21;
                _obj_Spms_AppraisalKra.APP_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Spms_AppraisalKra.APP_KRA_LASTMDFDATE = DateTime.Now;
                bool status10 = Pms_Bll.set_AppraisalKra(_obj_Spms_AppraisalKra);

                //TO GET THE WEIGHTAGE
                _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_rolekra.Text);
                _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_goalkradetails.MODE = 10;
                DataTable dt_kra_wt = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);

                //CALCULATING AVG RATING
                kra_rtng = kra_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_kra_wt.Rows[0]["GS_KRA_WEIGHTAGE"])) / tot_kra_wt;
                appr_rtng = appr_rtng + (Convert.ToDecimal(rtng_appr_Detail.Value) * Convert.ToInt32(dt_kra_wt.Rows[0]["GS_KRA_WEIGHTAGE"])) / tot_wt;
            }

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
                _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(appr_rtng);
                _obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                _obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;
                _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
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
                _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToDecimal(appr_rtng);
                _obj_Pms_AppApprover.APP_APPROVER_LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                _obj_Pms_AppApprover.APP_APPROVER_LASTMDFDATE = DateTime.Now;
                _obj_Pms_AppApprover.APP_APPROVER_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
            }

            //TO UPDATE THE AVG RATINGS IN APPRAISAL
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.APPRAISAL_GOAL_AVGRTG = Convert.ToDecimal(goal_rtng);
            _obj_Spms_Appraisal.APPRAISAL_KRA_AVGRTG = Convert.ToDecimal(kra_rtng);
            _obj_Spms_Appraisal.APPRAISAL_IDP_AVGRTG = Convert.ToDecimal(idp_rtng);
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_LASTMDFDATE = DateTime.Now;
            _obj_Spms_Appraisal.Mode = 46;
            bool status11 = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
            //btn_Approve.Visible = false;
            //rtxt_final_comments.Enabled = false;
            BLL.ShowMessage(this, "Approver Comments Finalised Successfully.");
            LoadGrid();
            Rm_Appraisal_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_rolekra.Text = string.Empty;
            lbl_type_text.Text = string.Empty;
            lbltype_detail_text.Text = string.Empty;
            lbl_rolekra_detail_text.Text = string.Empty;
            rtng_emp_detail.Value = 0;
            rtng_mgr_detail.Value = 0;
            rtng_appr_Detail.Value = 0;
            rtxt_emp_Comments_Detail.Text = string.Empty;
            rtxt_mgr_Comments_detail.Text = string.Empty;
            rtxt_appr_Comments_Detail.Text = string.Empty;
            Rm_Appraisal_PAGE.SelectedIndex = 1;
            lbl_rolekra.Text = Convert.ToString(e.CommandArgument);
            lbl_type_text.Text = Convert.ToString(e.CommandName);
            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 8;
            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS = new PMS_GoalSettings();
            DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
            if (dt.Rows.Count != 0)
                _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
            else
                _obj_GS.GS_ID = 0;
            _obj_GS.GS_ROLEKRA_ID = Convert.ToInt32(lbl_rolekra.Text);
            if (lbl_type_text.Text.Trim() == "Goal")
                _obj_GS.GS_MODE = 28;
            else if (lbl_type_text.Text.Trim() == "IDP")
                _obj_GS.GS_MODE = 29;
            else
                _obj_GS.GS_MODE = 30;
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dt_details = new DataTable();
            dt_details = Pms_Bll.get_GS(_obj_GS);
            if (dt_details.Rows.Count > 0)
            {
                lbltype_detail_text.Text = Convert.ToString(dt_details.Rows[0]["A"]);
                lbl_rolekra_detail_text.Text = Convert.ToString(dt_details.Rows[0]["NAME"]);
                rtng_emp_detail.Value = Convert.ToDecimal(dt_details.Rows[0]["TARGET_ACHIEVED"]);
                rtxt_emp_Comments_Detail.Text = Convert.ToString(dt_details.Rows[0]["EMP_COMMENTS"]);
                rtng_mgr_detail.Value = Convert.ToDecimal(dt_details.Rows[0]["MGR_RATING"]);
                rtxt_mgr_Comments_detail.Text = Convert.ToString(dt_details.Rows[0]["MGR_COMMENTS"]);
                if (dt_details.Rows[0]["APPR_RATING"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["APPR_RATING"]) != "")
                {
                    rtng_appr_Detail.Value = Convert.ToDecimal(dt_details.Rows[0]["APPR_RATING"]);
                }
                if (dt_details.Rows[0]["APPR_COMMENTS"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["APPR_COMMENTS"]) != "")
                {
                    rtxt_appr_Comments_Detail.Text = Convert.ToString(dt_details.Rows[0]["APPR_COMMENTS"]);
                }
                if (dt_details.Rows[0]["APPR_FIXED"] != System.DBNull.Value && Convert.ToString(dt_details.Rows[0]["APPR_FIXED"]) != string.Empty)
                {
                    if (Convert.ToString(dt_details.Rows[0]["APPR_FIXED"]) == "1")
                    {
                        btn_Approve_Detail.Visible = false;
                        rtng_appr_Detail.Enabled = false;
                        rtxt_appr_Comments_Detail.Enabled = false;
                    }
                    else
                    {
                        btn_Approve_Detail.Visible = true;
                        rtng_appr_Detail.Enabled = true;
                        rtxt_appr_Comments_Detail.Enabled = true;
                    }
                }
                else
                {
                    btn_Approve_Detail.Visible = true;
                    rtng_appr_Detail.Enabled = true;
                    rtxt_appr_Comments_Detail.Enabled = true;
                }
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Approve_Detail.Visible = false;
                    rtng_appr_Detail.Enabled = false;
                    rtxt_appr_Comments_Detail.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Detail_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_rolekra.Text = string.Empty;
            lbl_type_text.Text = string.Empty;
            Rm_Appraisal_PAGE.SelectedIndex = 0;
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsApproverAppraisalnew", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
