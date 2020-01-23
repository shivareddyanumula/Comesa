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

public partial class PMS_Frm_Manager_Feedback : System.Web.UI.Page
{

    SPMS_TASK _obj_Pms_Task;
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_PERIODICFEEDBACK _obj_Pms_PeriodicFeedback;
    PMS_FEEDBACK _obj_pms_Feedback;
    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    SMHR_LOGININFO _obj_smhr_logininfo;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    PMS_GoalSettings _obj_GS;
    SPMS_PROJECT _obj_Pms_Project;

    #region pageload methods

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Manager Periodic Feedback");
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
                    RG_Kra.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());

                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
                if (dt_bu.Rows.Count != 0)
                {
                    _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                    _obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                    _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_PMS_getemployee.Mode = 1;

                    DataTable dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);


                    //LoadEmployees();


                    LoadBusinessUnit();//not useful()


                    RMP_Task.Visible = false;
                    Rm_Kra.Visible = false;
                    Rm_Goal.Visible = false;
                    rcmb_EmployeeType.Enabled = true;
                    rcmb_BusinessUnitType.Enabled = true;
                    //rcmb_feedback.Visible = true;
                    //rcmb_feedback.Enabled = false;
                    RM_All.Visible = false;
                    //_obj_Pms_Appraisalcycle.MODE = 13;
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ID=Convert.ToInt32(Session["EMP_TYPE"]);
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dtusername = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    //if (dtusername.Rows.Count != 0)
                    //{

                    //    Session["USERNAME"] = Convert.ToString(dtusername.Rows[0]["LOGTYP_CODE"]);
                    //}

                    //else
                    //{
                    //    //Session["USERNAME"] = 0;

                    //}
                    if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                    {

                        //rcmb_feedback.Enabled = false;


                    }

                    else
                    {
                        //rcmb_feedback.Enabled = true;



                    }

                    //rcmb_feedback.Enabled = false;
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Employee Not Assigned To Business Unit");
                    return;
                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region TaskGrid Methods

    protected void Rg_Task_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 7;
            _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

            DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
            if (dt.Rows.Count != 0)
            {
                RG_Task.DataSource = dt;

            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadTaskGrid()
    {
        try
        {
            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 7;

            _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
            if (dt.Rows.Count != 0)
            {
                RG_Task.DataSource = dt;
                RG_Task.DataBind();
                RMP_Task.Visible = true;


            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Task Assigned");
                DataTable dt2 = new DataTable();
                RG_Task.DataSource = dt2;
                RG_Task.DataBind();
                //rcmb_feedback.SelectedIndex = 0;
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadbusinessunit(no use)

    protected void LoadBusinessUnit()//not useful()
    {
        try
        {

            rcmb_BusinessUnitType.Items.Clear();
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BusinessUnitType.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitType.DataBind();
            rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
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
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {//not useful()

        try
        {
            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                //LoadEmployees();
                LoadAppraisalCycle();
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                // rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                rtxt_Role.Enabled = false;
                // rtxt_Project.Enabled = false;
                //rtxt_AppraisalCycle.Enabled = false;
                RG_All.Visible = false;
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rtxt_RpMgr.Enabled = true;
                //rtxt_GpMgr.Enabled = true;
                //rtxt_Role.Enabled = true;
                //rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                //rtxt_AppraisalCycle.Enabled = true;
                //rcmb_feedback.Enabled = false;
                //rcmb_feedback.SelectedIndex = 0;
                RG_Goal.Visible = false;
                RG_Kra.Visible = false;
                RG_Task.Visible = false;
                RG_All.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
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
                LoadEmployees();
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                rtxt_RpMgr.Enabled = false;
                rtxt_GpMgr.Enabled = false;
                rtxt_Role.Enabled = false;
                //rtxt_Project.Enabled = false;
                //rtxt_AppraisalCycle.Enabled = false;
                RG_All.Visible = false;
            }
            else
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rtxt_RpMgr.Enabled = true;
                //rtxt_GpMgr.Enabled = true;
                //rtxt_Role.Enabled = true;
                //rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                //rtxt_AppraisalCycle.Enabled = true;
                //rcmb_feedback.Enabled = false;
                //rcmb_feedback.SelectedIndex = 0;
                RG_Goal.Visible = false;
                RG_Kra.Visible = false;
                RG_Task.Visible = false;
                RG_All.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loademployee based on login

    private void LoadEmployees()
    {
        try
        {
            if ((Convert.ToInt32(Session["EMP_ID"])) != 0)
            {
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_PMS_getemployee.Mode = 4;
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid.Rows.Count != 0)
                {
                    rtxt_RpMgr.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                    rtxt_GpMgr.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                    rcmb_EmployeeType.Items.Clear();
                    rcmb_EmployeeType.DataSource = dtbuid;
                    rcmb_EmployeeType.DataTextField = "employee";
                    rcmb_EmployeeType.DataValueField = "EMPID";
                    rcmb_EmployeeType.DataBind();
                    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_BusinessUnitType.Visible = false;
                    //lbl_BusinessUnitName.Visible = false;
                    rtxt_RpMgr.Enabled = false;
                    rtxt_GpMgr.Enabled = false;
                    //lbl_givefeedback.Text = "Feedback For   :";

                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtem.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
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
                                //rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                                rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                                rtxt_Role.Enabled = false;
                                //rtxt_Project.Enabled = false;
                                rtxt_AppraisalCycle.Enabled = false;
                                //rcmb_feedback.Enabled = true;

                            }
                            else
                            {
                                //rcmb_feedback.SelectedIndex = 0;

                                //rcmb_feedback.Enabled = false;
                            }
                        }
                        else
                        {

                            //rcmb_feedback.SelectedIndex = 0;

                            //rcmb_feedback.Enabled = false;

                        }
                        rtxt_RpMgr.Enabled = true;
                        rtxt_GpMgr.Enabled = true;
                        rtxt_GpMgr.Text = string.Empty;
                        rtxt_RpMgr.Text = string.Empty;


                    }

                    else
                    {
                        Pms_Bll.ShowMessage(this, "Employee Has Not Under BusinessUnit");
                        return;
                    }
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "No Employees Are There Under That Manager");
                    return;

                }

            }
            else
            {//employee useful
                //_obj_Pms_EmpSetup = new PMS_EMPSETUP();


                //_obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);
                //if (dt_buu.Rows.Count != 0)
                //{
                //    _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                //    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //    ViewState["BUID"] = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //    _obj_Pms_EmpSetup.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_Pms_EmpSetup);
                //    if (dtbuid1.Rows.Count != 0)
                //    {
                //        rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                //        rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMANAGER"]);
                //        rcmb_EmployeeType.Items.Clear();
                //        rcmb_EmployeeType.DataSource = dtbuid1;
                //        rcmb_EmployeeType.DataTextField = "employee";
                //        rcmb_EmployeeType.DataValueField = "EMPID";
                //        rcmb_EmployeeType.DataBind();

                //        rcmb_BusinessUnitType.Visible = false;
                //        lbl_BusinessUnitName.Visible = false;
                //        rtxt_RpMgr.Enabled = false;
                //        rtxt_GpMgr.Enabled = false;
                //        lbl_givefeedback.Text = "ViewFeedback   :";


                //        _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //        _obj_Pms_Appraisalcycle.MODE = 11;
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["emp_id"]);//where i am passing employee to get bunit
                //        DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //        if (dtem.Rows.Count != 0)
                //        {
                //            _obj_Pms_Appraisalcycle.MODE = 8;
                //            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                //            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //            //where i am getting apprisal cycle 
                //            if (dtappid.Rows.Count != 0)
                //            {

                //                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                //                _obj_GS.GS_MODE = 9;
                //                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                //                _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                //                if (dt1.Rows.Count != 0)
                //                {
                //                    rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                //                    rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                //                    rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                //                    rtxt_Role.Enabled = false;
                //                    rtxt_Project.Enabled = false;
                //                    rtxt_AppraisalCycle.Enabled = false;
                //                    rcmb_feedback.Enabled = true;
                //                }
                //                else
                //                {
                //                    rcmb_feedback.SelectedIndex = 0;
                //                    rcmb_feedback.Enabled = false;

                //                }
                //            }
                //            else
                //            {
                //                rcmb_feedback.SelectedIndex = 0;
                //                rcmb_feedback.Enabled = false;
                //            }

                //            rtxt_RpMgr.Enabled = false;
                //            rtxt_GpMgr.Enabled = false;
                //            rcmb_feedback.Visible = false;
                //            RG_Goal.Visible = true;
                //            RG_Kra.Visible = true;
                //            RG_Task.Visible = true;

                //        }
                //        else
                //        {
                //            Pms_Bll.ShowMessage(this, "Employee Not In Active State");

                //            lbl_BusinessUnitName.Visible = false;
                //            rcmb_BusinessUnitType.Visible = false;
                //            rcmb_feedback.SelectedIndex = 0;
                //            rcmb_feedback.Enabled = false;
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        Pms_Bll.ShowMessage(this, "Employee Not In Active State");

                //        lbl_BusinessUnitName.Visible = false;
                //        rcmb_BusinessUnitType.Visible = false;
                //        rcmb_feedback.SelectedIndex = 0;
                //        rcmb_feedback.Enabled = false;
                //        return;

                //    }

                //}
                //else
                //{
                //    Pms_Bll.ShowMessage(this, "Employee Not Under Business Unit");

                //    lbl_BusinessUnitName.Visible = false;
                //    rcmb_BusinessUnitType.Visible = false;
                //    rcmb_feedback.SelectedIndex = 0;
                //    rcmb_feedback.Enabled = false;
                //    return;
                //}
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region loadfeedback

    protected void Loadfeedback()
    {
        try
        {
            if ((Convert.ToInt32(Session["EMP_ID"])) != 0)
            {
                LoadTaskGrid();
                LoadGoalGrid();
                LoadKraGrid();
            }
            else
            {//employee useful
                //    LoadTaskGrid();
                //    LinkButton lnkaddtaskfeedback = new LinkButton();
                //    LinkButton lnkupdatetaskfeedback = new LinkButton();

                //    for (int k = 0; k <= RG_Task.Items.Count - 1; k++)
                //    {

                //        lnkaddtaskfeedback = RG_Task.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
                //        lnkaddtaskfeedback.Enabled = false;

                //        lnkupdatetaskfeedback = RG_Task.Items[k].FindControl("lnk_update") as LinkButton;
                //        lnkupdatetaskfeedback.Enabled = false;


                //    }

                //    LoadGoalGrid();
                //    LinkButton lnkaddgoalfeedback = new LinkButton();
                //    LinkButton lnkupdategoalfeedback = new LinkButton();
                //    for (int k = 0; k <= RG_Goal.Items.Count - 1; k++)
                //    {

                //        lnkaddgoalfeedback = RG_Goal.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
                //        lnkaddgoalfeedback.Enabled = false;

                //        lnkupdategoalfeedback = RG_Goal.Items[k].FindControl("lnk_update") as LinkButton;
                //        lnkupdategoalfeedback.Enabled = false;
                //    }
                //    LoadKraGrid();
                //    LinkButton lnkaddkrafeedback = new LinkButton();
                //    LinkButton lnkupdatekrafeedback = new LinkButton();
                //    for (int k = 0; k <= RG_Kra.Items.Count - 1; k++)
                //    {

                //        lnkaddkrafeedback = RG_Kra.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
                //        lnkaddkrafeedback.Enabled = false;

                //        lnkupdatekrafeedback = RG_Kra.Items[k].FindControl("lnk_update") as LinkButton;
                //        lnkupdatekrafeedback.Enabled = false;
                //    }

            }
            Rm_Kra.Visible = false;
            Rm_Goal.Visible = false;


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    #endregion

    #region Loadgrids when feedback changed



    //<summary>
    //Here i am loading grid based on emploee selecteion task grid will be displayed
    //</summary>
    //<param name="o"></param>
    //<param name="e"></param>

    //protected void rcmb_feedback_indexchanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (rcmb_feedback.SelectedItem.Text != "Select")
    //        {
    //            if (!(rcmb_BusinessUnitType.SelectedIndex > 0 && rcmb_EmployeeType.SelectedIndex > 0))
    //            {
    //                rcmb_feedback.SelectedIndex = 0;
    //                BLL.ShowMessage(this, "Please Select Proper Parameters.");
    //                return;
    //            }
    //            if (rcmb_feedback.SelectedItem.Text == "TASK")
    //            {
    //                if ((Convert.ToInt32(Session["EMP_ID"])) != 0)
    //                {
    //                    LoadTaskGrid();
    //                }
    //                else
    //                {//employee useful
    //                    //LoadTaskGrid();
    //                    //LinkButton lnkaddtaskfeedback = new LinkButton();
    //                    //LinkButton lnkupdatetaskfeedback = new LinkButton();

    //                    //for (int k = 0; k <= RG_Task.Items.Count - 1; k++)
    //                    //{

    //                    //    lnkaddtaskfeedback = RG_Task.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
    //                    //    lnkaddtaskfeedback.Enabled = false;
    //                    //    lnkaddtaskfeedback.Visible = false;
    //                    //    lnkupdatetaskfeedback = RG_Task.Items[k].FindControl("lnk_update") as LinkButton;
    //                    //    lnkupdatetaskfeedback.Enabled = false;
    //                    //    lnkupdatetaskfeedback.Visible = false;


    //                    //}



    //                }
    //                Rm_Kra.Visible = false;
    //                Rm_Goal.Visible = false;
    //                RMP_Task.Visible = true;
    //                RG_Task.Visible = true;
    //            }

    //            else if (rcmb_feedback.SelectedItem.Text == "GOAL")
    //            {
    //                if ((Convert.ToInt32(Session["EMP_ID"])) != 0)
    //                {
    //                    //LoadGoalGrid();
    //                    LoadGrid_All();
    //                }
    //                else
    //                {//employee useful
    //                    //LoadGoalGrid();
    //                    //LinkButton lnkaddgoalfeedback = new LinkButton();
    //                    //LinkButton lnkupdategoalfeedback = new LinkButton();
    //                    //for (int k = 0; k <= RG_Goal.Items.Count - 1; k++)
    //                    //{

    //                    //    lnkaddgoalfeedback = RG_Goal.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
    //                    //    lnkaddgoalfeedback.Enabled = false;
    //                    //    lnkaddgoalfeedback.Visible = false;

    //                    //    lnkupdategoalfeedback = RG_Goal.Items[k].FindControl("lnk_update") as LinkButton;
    //                    //    lnkupdategoalfeedback.Enabled = false;
    //                    //    lnkupdategoalfeedback.Visible = false;
    //                    //    //Session["emp"] = "lnkupdategoalfeedback";

    //                    //}

    //                }

    //                Rm_Kra.Visible = false;
    //                RMP_Task.Visible = false;
    //                Rm_Goal.Visible = true;
    //                RG_Goal.Visible = true;
    //            }

    //            else if (rcmb_feedback.SelectedItem.Text == "KRA")
    //            {
    //                if ((Convert.ToInt32(Session["EMP_ID"])) != 0)
    //                {
    //                    LoadKraGrid();
    //                }
    //                else
    //                {//employee useful
    //                    //LoadKraGrid();
    //                    //LinkButton lnkaddkrafeedback = new LinkButton();
    //                    //LinkButton lnkupdatekrafeedback = new LinkButton();
    //                    //for (int k = 0; k <= RG_Kra.Items.Count - 1; k++)
    //                    //{

    //                    //    lnkaddkrafeedback = RG_Kra.Items[k].FindControl("lnk_AddFeedback") as LinkButton;
    //                    //    lnkaddkrafeedback.Enabled = false;
    //                    //    lnkaddkrafeedback.Visible = false;
    //                    //    lnkupdatekrafeedback = RG_Kra.Items[k].FindControl("lnk_update") as LinkButton;
    //                    //    lnkupdatekrafeedback.Enabled = false;
    //                    //    lnkupdatekrafeedback.Visible = false;
    //                    //}

    //                }
    //                RMP_Task.Visible = false;
    //                Rm_Goal.Visible = false;
    //                Rm_Kra.Visible = true;
    //                RG_Kra.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            Pms_Bll.ShowMessage(this, "Please Select Feedback");

    //            RG_Goal.Visible = false;
    //            RG_Kra.Visible = false;
    //            RG_Task.Visible = false;

    //            return;
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}



    #endregion

    #region employee select index changed method

    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_EmployeeType.SelectedItem.Text == "Select"))
            {

                Pms_Bll.ShowMessage(this, "Please Select Employee");
                //rtxt_RpMgr.Enabled = true;
                //rtxt_GpMgr.Enabled = true;
                //rtxt_Role.Enabled = true;
                //rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                //rtxt_AppraisalCycle.Enabled = true;
                //rcmb_feedback.Enabled = false;
                //rcmb_feedback.SelectedIndex = 0;
                RG_Goal.Visible = false;
                RG_Kra.Visible = false;
                RG_Task.Visible = false;
                RG_All.Visible = false;
            }
            else
            {

                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                _obj_Pms_LoginInfo = new PMS_LOGININFO();


                _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);



                _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(ViewState["BUID"]);

                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {
                    rtxt_Role.Text = Convert.ToString(DTREPO.Rows[0]["POSITIONS_CODE"]);
                    rtxt_RpMgr.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    rtxt_RpMgr.Enabled = false;
                }

                else
                {
                    //rcmb_feedback.SelectedIndex = 0;
                    rtxt_RpMgr.Text = string.Empty;
                    rtxt_RpMgr.Enabled = false;
                }

                _obj_Pms_EmpSetup = new PMS_EMPSETUP();



                _obj_Pms_EmpSetup.Mode = 7;
                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    rtxt_GpMgr.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    rtxt_GpMgr.Enabled = false;
                }
                else
                {
                    //rcmb_feedback.SelectedIndex = 0;
                    rtxt_GpMgr.Text = string.Empty;
                    rtxt_GpMgr.Enabled = false;
                }


                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    //where i am getting apprisal cycle active under that business unit
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
                            //rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                            //rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                            //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                            //rtxt_Role.Enabled = false;
                            //rtxt_Project.Enabled = false;
                            //rtxt_AppraisalCycle.Enabled = false;
                            //rcmb_feedback.Enabled = true;
                            LoadGrid_All();
                            RM_All.Visible = true;
                            RG_All.Visible = true;

                        }
                        else
                        {
                            //rcmb_feedback.SelectedIndex = 0;
                            //rcmb_feedback.Enabled = false;
                            rtxt_Role.Text = string.Empty;
                            // rtxt_Project.Text = string.Empty;
                            //rtxt_AppraisalCycle.Text = string.Empty;
                            RM_All.Visible = false;
                            RG_All.Visible = false;

                        }
                        RG_Goal.Visible = false;
                        RG_Kra.Visible = false;
                        RG_Task.Visible = false;
                        //RM_All.Visible = true;
                        //RG_All.Visible = true;
                        //rcmb_feedback.SelectedIndex = 0;
                    }

                    else
                    {
                        Pms_Bll.ShowMessage(this, "Employee Has No Active Appraisals");
                        return;

                    }
                }


                else
                {

                    Pms_Bll.ShowMessage(this, "Employee Not In Active State");
                    return;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region LoadGoal Grid
    //<summary>
    //here i am binding goal grid based on employee selection 
    //</summary>
    //<param name="dt"></param>



    protected void RG_Goal_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                _obj_Pms_EmpGoalSetting.Mode = 8;


                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);

                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
                _obj_GSdetails.GS_DETAILS_MODE = 5;
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dt_details.Rows.Count != 0)
                {
                    RG_Goal.DataSource = dt_details;

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_All_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                    _obj_Pms_EmpGoalSetting.Mode = 8;


                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);

                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    //PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                    //_obj_GSdetails.GSDTL_GS_ID = GSID;
                    //_obj_GSdetails.GS_DETAILS_MODE = 5;
                    //_obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dt_details = new DataTable();
                    //dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 18;
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                    DataTable dt_details = new DataTable();
                    dt_details = Pms_Bll.get_GS(_obj_GS);
                    if (dt_details.Rows.Count != 0)
                    {
                        RG_All.DataSource = dt_details;

                    }
                }
            }
            else
            {
                DataTable dt_details = new DataTable();
                RG_All.DataSource = dt_details;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadGoalGrid()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappid.Rows.Count != 0)
                {

                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                    _obj_Pms_EmpGoalSetting.Mode = 8;
                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);

                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    if (dt.Rows.Count != 0)
                    {
                        int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                        PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                        _obj_GSdetails.GSDTL_GS_ID = GSID;
                        _obj_GSdetails.GS_DETAILS_MODE = 5;
                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_details = new DataTable();
                        dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                        if (dt_details.Rows.Count != 0)
                        {
                            RG_Goal.DataSource = dt_details;
                            RG_Goal.DataBind();

                            Rm_Goal.Visible = true;

                        }
                        else
                        {

                            Pms_Bll.ShowMessage(this, "No Goal Assigned");
                            DataTable dt1 = new DataTable();
                            RG_Goal.DataSource = dt1;
                            RG_Goal.DataBind();
                            //rcmb_feedback.SelectedIndex = 0;
                            return;
                        }
                    }

                    else
                    {
                        Pms_Bll.ShowMessage(this, "No Goals Assigned");
                        DataTable dt1 = new DataTable();
                        RG_Goal.DataSource = dt1;
                        RG_Goal.DataBind();
                        //rcmb_feedback.SelectedIndex = 0;
                        return;

                    }
                }

                else
                {
                    Pms_Bll.ShowMessage(this, "Employee Has No Active Appraisal Cycle");
                    return;
                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Employee Not Under Any Business Unit");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadGrid_All()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappid.Rows.Count != 0)
                {

                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                    _obj_Pms_EmpGoalSetting.Mode = 8;
                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);

                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);

                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    if (dt.Rows.Count != 0)
                    {
                        int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                        //PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                        //_obj_GSdetails.GSDTL_GS_ID = GSID;
                        //_obj_GSdetails.GS_DETAILS_MODE = 5;
                        //_obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                        //DataTable dt_details = new DataTable();
                        //dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                        _obj_GS = new PMS_GoalSettings();
                        _obj_GS.GS_MODE = 18;
                        _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_GS.GS_ID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                        DataTable dt_details = new DataTable();
                        dt_details = Pms_Bll.get_GS(_obj_GS);
                        if (dt_details.Rows.Count != 0)
                        {
                            RG_All.DataSource = dt_details;
                            RG_All.DataBind();

                            RM_All.Visible = true;

                        }
                        else
                        {

                            Pms_Bll.ShowMessage(this, "No Goals are Assigned");
                            DataTable dt1 = new DataTable();
                            RG_All.DataSource = dt1;
                            RG_All.DataBind();
                            //rcmb_feedback.SelectedIndex = 0;
                            return;
                        }
                    }

                    else
                    {
                        Pms_Bll.ShowMessage(this, "No Goals are Assigned");
                        DataTable dt1 = new DataTable();
                        RG_All.DataSource = dt1;
                        RG_All.DataBind();
                        //rcmb_feedback.SelectedIndex = 0;
                        return;

                    }
                }

                else
                {
                    Pms_Bll.ShowMessage(this, "Employee Has No Active Appraisal Cycle");
                    return;
                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Employee Not Under Any Business Unit");
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadKra Grid
    //<summary>
    //here i am binding Kra grid based on employee selection 
    //</summary>
    //<param name="dt"></param>
    protected void RG_kra_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                _obj_Pms_EmpGoalSetting.Mode = 8;

                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);



                DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GSDTL_GS_ID = GSID;
                _obj_GSdetails.GS_DETAILS_MODE = 5;
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dt_details.Rows.Count != 0)
                {
                    _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                    _obj_Spms_GoalStgKraDtls.Mode = 7;
                    _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                    _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                    if (dt2.Rows.Count != 0)
                    {
                        RG_Kra.DataSource = dt2;
                    }
                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void LoadKraGrid()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//where i am passing employee to get bunit
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                if (dtappid.Rows.Count != 0)
                {
                    _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                    _obj_Pms_EmpGoalSetting.Mode = 8;

                    _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);


                    DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    if (dt.Rows.Count != 0)
                    {

                        int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
                        PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                        _obj_GSdetails.GSDTL_GS_ID = GSID;
                        _obj_GSdetails.GS_DETAILS_MODE = 5;
                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dt_details = new DataTable();
                        dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
                        if (dt_details.Rows.Count != 0)
                        {
                            _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
                            _obj_Spms_GoalStgKraDtls.Mode = 7;
                            _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
                            _obj_Spms_GoalStgKraDtls.LASTMDFBY = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                            _obj_Spms_GoalStgKraDtls.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

                            if (dt2.Rows.Count != 0)
                            {
                                RG_Kra.DataSource = dt2;
                                RG_Kra.DataBind();

                                Rm_Kra.Visible = true;
                            }
                            else
                            {
                                Pms_Bll.ShowMessage(this, "No Kra Assigned");
                                DataTable dt1 = new DataTable();
                                RG_Kra.DataSource = dt1;
                                RG_Kra.DataBind();
                                //rcmb_feedback.SelectedIndex = 0;
                                return;
                            }
                        }
                        else
                        {

                            Pms_Bll.ShowMessage(this, "No Kra Assigned");
                            DataTable dt2 = new DataTable();
                            RG_Kra.DataSource = dt2;
                            RG_Kra.DataBind();
                            //rcmb_feedback.SelectedIndex = 0;
                            return;


                        }

                    }

                    else
                    {
                        Pms_Bll.ShowMessage(this, "No Kra Assigned");
                        DataTable dt2 = new DataTable();
                        RG_Kra.DataSource = dt2;
                        RG_Kra.DataBind();
                        //rcmb_feedback.SelectedIndex = 0;
                        return;
                    }
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Employee Not Under Any Apparisal Cycle");
                    return;
                }

            }

            else
            {

                Pms_Bll.ShowMessage(this, "Employee Not Under Any Business Unit");
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region task grid methods

    protected void Rg_Task_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        try
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            switch (e.DetailTableView.Name)
            {
                case "Feedback":
                    {

                        int TaskID = Convert.ToInt32(dataItem.GetDataKeyValue("TASK_ID"));

                        _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
                        _obj_Pms_PeriodicFeedback.Mode = 5;
                        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_TASK_ID = TaskID;
                        _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dttask = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
                        e.DetailTableView.DataSource = dttask;

                        break;
                    }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_update_command(object sender, CommandEventArgs e)
    {
        //Label lbltaskid = new Label();
        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;

        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
        //_obj_pms_Feedback = new PMS_FEEDBACK();
        //_obj_pms_Feedback.Mode = 4;
        //DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);
        //_obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));

        //_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;

        //bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);


        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "Task FeedBack Inserted Successfully");
        //    LoadTaskGrid();

        //}

    }

    protected void btnsubmit_TaskFeedback_click(object sender, EventArgs e)
    {
        //Label lbltaskid = new Label();

        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;
        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);

        // int i;
        // for (i = 0; i <= RG_Task.Items.Count - 1; i++)
        // {
        //     _obj_pms_Feedback = new PMS_FEEDBACK();
        //     _obj_pms_Feedback.Mode = 4;
        //     DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //     _obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);

        //     lbltaskid = RG_Task.Items[i].FindControl("lblTASK_ID") as Label;
        //     _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(lbltaskid.Text);


        //     _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //     _obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //     _obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;

        //     bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);


        //     if (status == true)
        //     {
        //         Pms_Bll.ShowMessage(this, "Task FeedBack Inserted Successfully");
        //         LoadTaskGrid();

        //     }
        // }



    }

    #endregion

    #region goal grid methods

    protected void RG_Goal_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        try
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            switch (e.DetailTableView.Name)
            {
                case "Feedback":
                    {

                        int GOALID = Convert.ToInt32(dataItem.GetDataKeyValue("GSDTL_ID"));

                        _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
                        _obj_Pms_PeriodicFeedback.Mode = 5;
                        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_TASK_ID = GOALID;
                        _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dttask = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
                        e.DetailTableView.DataSource = dttask;

                        break;
                    }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void RG_All_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    //{
    //    try
    //    {
    //        GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
    //        switch (e.DetailTableView.Name)
    //        {
    //            case "Feedback":
    //                {

    //                    int GOALID = Convert.ToInt32(dataItem.GetDataKeyValue("ROLEKRA_ID"));
    //                    string type = Convert.ToString(dataItem.GetDataKeyValue("A"));
    //                    int index= Convert.ToInt32(dataItem.ItemIndex);
    //                    //string type = Convert.ToString(RG_All.Items[index]["A"].Text).Trim();
    //                    //Label lblid = new Label();
    //                    //lblid = RG_All.Items[index].FindControl("lbl_type") as Label;
    //                    _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
    //                    if (type == "Goal")
    //                    {
    //                        _obj_Pms_PeriodicFeedback.PF_PM_ID = 1;
    //                    }
    //                    else if (type == "IDP")
    //                    {
    //                        _obj_Pms_PeriodicFeedback.PF_PM_ID = 2;
    //                    }
    //                    else
    //                    {
    //                        _obj_Pms_PeriodicFeedback.PF_PM_ID = 3;
    //                    }
    //                    _obj_Pms_PeriodicFeedback.Mode = 5;
    //                    //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
    //                    _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
    //                    _obj_Pms_PeriodicFeedback.PF_TASK_ID = GOALID;
    //                    _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

    //                    DataTable dttask = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
    //                    e.DetailTableView.DataSource = dttask;

    //                    break;
    //                }
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void lnk_goal_addcomand(object sender, CommandEventArgs e)
    {
        try
        {
            Session["goalid"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["empid1"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            //Session["pmidgoal"] = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
            Session.Remove("taskid");
            Session.Remove("kraid");
            Session.Remove("pmidtask");
            Session.Remove("pmidkra");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_taskaddcommand(object sender, CommandEventArgs e)
    {
        try
        {
            Session["taskid"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["empid1"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

            //Session["pmidtask"] = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
            Session.Remove("goalid");
            Session.Remove("kraid");
            Session.Remove("pmidgoal");
            Session.Remove("pmidkra");
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_kraaddcommand(object sender, CommandEventArgs e)
    {
        try
        {
            Session["kraid"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["empid1"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            //Session["pmidkra"] = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
            Session.Remove("goalid");
            Session.Remove("taskid");
            Session.Remove("pmidgoal");
            Session.Remove("pmidtask");
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_all_addcomand(object sender, CommandEventArgs e)
    {
        try
        {
            LinkButton lnkAdd = sender as LinkButton;
            GridDataItem item = lnkAdd.NamingContainer as GridDataItem;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "openRadWin('frm_Pms_TaskFeedback.aspx?KRA_ID=" + item["KRA_ID"].Text.ToString() + "')", true);

            Session["rolekarid"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["empid1"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            Session["APPCYCLE_ID"] = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void lnk_all_Viewcomand(object sender, CommandEventArgs e)
    {
        try
        {
            LinkButton lnkAdd = sender as LinkButton;
            GridDataItem item = lnkAdd.NamingContainer as GridDataItem;

            Session["rolekarid"] = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["empid1"] = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            Session["APPCYCLE_ID"] = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);
            if (Convert.ToString(e.CommandName).Trim() == "Goal")
                Session["TYPE"] = 1;
            else if (Convert.ToString(e.CommandName).Trim() == "IDP")
                Session["TYPE"] = 2;
            else
                Session["TYPE"] = 3;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "FeedBack_Details('frm_Pms_ViewFeedBack.aspx')", true);
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RG_All_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            if (rcmb_EmployeeType.SelectedIndex > 0)
            {
                GridDataItem dtItem = (GridDataItem)e.Item;
                int index = dtItem.ItemIndex;
                string a = Convert.ToString(dtItem.GetDataKeyValue("A"));
                //string a = Convert.ToString(RG_All.Items[index]["A"].Text).Trim();
                //Label lblid = new Label();
                //lblid = RG_All.Items[index].FindControl("lbl_type") as Label;
                if (a == "Goal")
                {
                    Session["TYPE"] = 1;
                }
                else if (a == "IDP")
                {
                    Session["TYPE"] = 2;
                }
                else
                {
                    Session["TYPE"] = 3;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_goalupdate_command(object sender, CommandEventArgs e)
    {

        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;

        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);

        //_obj_pms_Feedback = new PMS_FEEDBACK();
        //_obj_pms_Feedback.Mode = 4;
        //DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);
        //_obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
        //_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;
        //bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);

        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "Goal Feedback Inserted Successfully");

        //    LoadGoalGrid();
        //}
    }

    protected void btn_Submit_GoalFeedback_click(object sender, EventArgs e)
    {
        //Label lblgoalid = new Label();
        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;
        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);

        //_obj_pms_Feedback = new PMS_FEEDBACK();
        //_obj_pms_Feedback.Mode = 4;
        //DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);
        //int i;
        //for (i = 0; i <= RG_Goal.Items.Count - 1; i++)
        //{

        //    lblgoalid  = RG_Goal.Items[i].FindControl("lblGOAL_ID") as Label;
        //    _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(lblgoalid.Text);
        //    _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //    _obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //    _obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;



        //}
        //bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);

        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "Goal Feedback Inserted Successfully");

        //    LoadGoalGrid();
        //}

    }

    #endregion

    #region kra grid methods

    protected void RG_Kra_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
    {
        try
        {

            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;


            switch (e.DetailTableView.Name)
            {
                case "Feedback":
                    {

                        int kraID = Convert.ToInt32(dataItem.GetDataKeyValue("gs_kra_id"));

                        _obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
                        _obj_Pms_PeriodicFeedback.Mode = 5;
                        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_TASK_ID = kraID;
                        _obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                        _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        DataTable dttask = Pms_Bll.get_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
                        e.DetailTableView.DataSource = dttask;

                        break;
                    }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_kraupdate_command(object sender, CommandEventArgs e)
    {
        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;

        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);

        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);

        //_obj_pms_Feedback = new PMS_FEEDBACK();
        //_obj_pms_Feedback.Mode = 4;
        //DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);
        //_obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
        //_obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //_obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;
        //bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "KRA Feedback Inserted Successfully");

        //    LoadKraGrid();
        //}


    }

    protected void btn_Submit_KraFeedback_click(object sender, EventArgs e)
    {
        //Label lblkraid = new Label();
        //_obj_Pms_PeriodicFeedback = new SPMS_PERIODICFEEDBACK();
        //_obj_Pms_PeriodicFeedback.Mode = 3;
        //_obj_Pms_PeriodicFeedback.PF_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
        //_obj_Pms_PeriodicFeedback.PF_PM_ID = Convert.ToInt32(rcmb_feedback.SelectedItem.Value);

        //_obj_pms_Feedback = new PMS_FEEDBACK();
        //_obj_pms_Feedback.Mode = 4;
        //DataTable dtfeed_id = Pms_Bll.get_Feedback(_obj_pms_Feedback);
        //_obj_Pms_PeriodicFeedback.PF_FEEDBACK_ID = Convert.ToInt32(dtfeed_id.Rows[0]["temp"]);
        //int i;
        //for (i = 0; i <= RG_Kra.Items.Count - 1; i++)
        //{

        //   lblkraid  = RG_Kra.Items[i].FindControl("lblKRA_ID") as Label;
        //   _obj_Pms_PeriodicFeedback.PF_TASK_ID = Convert.ToInt32(lblkraid.Text);
        //   _obj_Pms_PeriodicFeedback.PF_ORGANISATION_ID = 1;
        //   _obj_Pms_PeriodicFeedback.PF_CREATEDBY = 1;
        //   _obj_Pms_PeriodicFeedback.PF_CREATEDDATE = DateTime.Now;



        //}
        //bool status = Pms_Bll.set_PeriodicFeedback(_obj_Pms_PeriodicFeedback);
        //if (status == true)
        //{
        //    Pms_Bll.ShowMessage(this, "Kra Feedback Inserted Successfully");

        //    LoadKraGrid();
        //}


    }

    #endregion

    protected void RG_All_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item["A"].Text == "Goal")
                {
                    item["A"].Text = "Competency";
                }
                else if (item["A"].Text == "IDP")
                {
                    item["A"].Text = "Value";
                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_Manager_Feedback", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
