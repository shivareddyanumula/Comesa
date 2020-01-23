using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using SPMS;
using Telerik.Web.UI;
using System.Collections;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Drawing;


public partial class PMS_frm_GS : System.Web.UI.Page
{
    PMS_GoalSettings _obj_GS;
    PMS_GoalSettings_Details _obj_GSdetails;
    PMS_GOALKRA _obj_Pms_GOALKRA;
    PMS_EMPSETUP _obj_Pms_EmpSetup;
    pms_kraform _obj_PMS_KRA;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SPMS_ROLEKRA _obj_Pms_Roles;
    GOALSETTING_GOALKRA_DETAILS _obj_Pms_goalkradetails;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    DataTable dt_KRA = new DataTable();
    DataTable dt_goal = new DataTable();
    DataSet ds = new DataSet("DataSet");
    SMHR_LOGININFO _obj_smhr_logininfo;
    PMS_BINDROLES _obj_roles;
    SPMS_PROJECT _obj_Pms_Project;
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_ROLEKRA _obj_Pms_RoleKra;
    pms_IDPSCREEN _obj_idp;
    GOALSETTING_IDP_DETAILS _obj_Pms_goalIDPdetails;
    SMHR_EMPLOYEE _obj_Smhr_Employee;
    int mode;

    double sum = 0;

    #region Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            //if (hid.Value != null && hid.Value != string.Empty)
            //{
            //    if (Convert.ToInt32(hid.Value) == 1)
            //        lnk_Edit_Command(null, null);
            //}
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("GOAL SETTING");
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
                    Rg_Goal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                    Rg_Goal.Enabled = false;
                }

                else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    Rg_Goal.Enabled = true;

                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }
                //_obj_GS = new PMS_GoalSettings();
                //_obj_GS.GS_MODE = 17;
                //_obj_GS.EMPID = Convert.ToInt32(Session["EMP_ID"]);
                //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //Rg_Goal.DataSource = Pms_Bll.get_GS(_obj_GS);
                //Rg_Goal.DataBind();
                Session.Remove("BU");

                ////TO LOAD WEIGHTAGE DESC
                //_obj_GS = new PMS_GoalSettings();
                //_obj_GS.GS_MODE = 35;
                //DataTable dt = Pms_Bll.get_GS(_obj_GS);
                //rg_Wt_Desc_KRA.DataSource = dt;
                //rg_Wt_Desc_KRA.DataBind();
                //rg_Wt_Desc_Goal.DataSource = dt;
                //rg_Wt_Desc_Goal.DataBind();
                //rg_Wt_Desc_IDP.DataSource = dt;
                //rg_Wt_Desc_IDP.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void Rg_Goal_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LoadGrid()
    {
        try
        {
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 17;
            _obj_GS.EMPID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            Rg_Goal.DataSource = Pms_Bll.get_GS(_obj_GS);
            //Rg_Goal.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Load Methods

    protected void loadBusinessUnit()
    {
        try
        {
            RCB_BusinessUnit.Items.Clear();
            _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            RCB_BusinessUnit.Items.Clear();
            DataTable dtbu = new DataTable();

            dtbu = BLL.get_Business_Units(_obj_smhr_logininfo);
            if (dtbu.Rows.Count != 0)
            {
                RCB_BusinessUnit.DataSource = dtbu;
                RCB_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                RCB_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                RCB_BusinessUnit.DataBind();
                RCB_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt5 = new DataTable();
                RCB_BusinessUnit.DataSource = dt5;

                RCB_BusinessUnit.DataBind();
                RCB_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {

            //if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
            //{

            if ((Convert.ToString(Session["EMP_TYPE"])) == "0")//for manager only this screen not for employee
            {
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                _obj_PMS_getemployee.Mode = 2;
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid.Rows.Count != 0)
                {
                    txt_ReportingManager.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                    txt_GeneralManager.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                    RCB_EmployeeName.SelectedValue = Convert.ToInt32(dtbuid.Rows[0]["EMPID"]).ToString();
                    RCB_EmployeeName.Items.Clear();
                    RCB_EmployeeName.DataSource = dtbuid;
                    RCB_EmployeeName.DataTextField = "employee";
                    RCB_EmployeeName.DataValueField = "EMPID";
                    RCB_EmployeeName.DataBind();
                    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    RCB_EmployeeName.SelectedIndex = 0;
                    //RCB_BusinessUnit.Visible = false;
                    //lbl_BusinessUnit.Visible = false;
                    txt_ReportingManager.Enabled = false;
                    txt_GeneralManager.Enabled = false;
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);//where i am passing employee to get bunit

                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtem.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 9;
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value);  //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_GS.GS_APPRAISAL_CYCLE = string.Empty;

                    }
                    DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                    //if (dt1.Rows.Count != 0)
                    //{
                    //    RCB_RoleName.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    //    RCMB_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    //    RCMB_Project.Enabled = true;
                    //    RCB_RoleName.Enabled = true;

                    //}
                }


                else
                {
                    RCB_EmployeeName.Items.Clear();
                    Pms_Bll.ShowMessage(this, "No Employees Are There Under That Manager For this Business Unit.");
                    return;

                }
            }
            else
            {
                /* 
            _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //RCB_BusinessUnit.Items.Clear();
            DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
            */

                //////_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //////_obj_Pms_Appraisalcycle.MODE = 11; 
                //////DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                _obj_PMS_getemployee.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                //    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //    _obj_Pms_Appraisalcycle.MODE = 9; 
                //    DataTable DT_AppraisalCycle = new DataTable();
                ////    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID  = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                //DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_PMS_getemployee.Mode = 2;
                //if (dt_bu.Rows.Count != 0)
                //{
                //    _obj_PMS_getemployee.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                //}
                //else
                //{
                //    _obj_PMS_getemployee.BU_ID = 0;
                //}
                if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
                {
                    _obj_PMS_getemployee.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                }
                else
                {
                    _obj_PMS_getemployee.BU_ID = 0;
                }

                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.GS_APPRAISAL_CYCLE = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value); //Convert.ToInt32(DT_AppraisalCycle.Rows[0]["APPRCYCLE_ID"]);  
                DataTable dtbuid1 = new DataTable();
                _obj_PMS_getemployee.Mode = 2;
                dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid1.Rows.Count != 0)
                {
                    //lbl_RMID.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMGR_ID"]);
                    //txt_ReportingManager.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                    //txt_GeneralManager.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMGR"]);
                    //RCB_EmployeeName.SelectedValue = Convert.ToInt32(dtbuid1.Rows[0]["EMPID"]).ToString();
                    RCB_EmployeeName.Items.Clear();
                    RCB_EmployeeName.DataSource = dtbuid1;
                    RCB_EmployeeName.DataTextField = "employee";
                    RCB_EmployeeName.DataValueField = "EMPID";
                    RCB_EmployeeName.DataBind();
                    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    RCB_EmployeeName.SelectedIndex = 0;
                    //RCB_BusinessUnit.Visible = false;
                    //lbl_BusinessUnit.Visible = false;
                    //txt_ReportingManager.Enabled = true;
                    //txt_GeneralManager.Enabled = true;

                    //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    //_obj_Pms_Appraisalcycle.MODE = 11;
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["emp_id"]);
                    ////where i am passing employee to get bunit
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    //_obj_Pms_Appraisalcycle.MODE = 8;
                    //if (dtem.Rows.Count != 0)
                    //{
                    //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    //}
                    //else
                    //{
                    //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    //}
                    //if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
                    //{
                    //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                    //}
                    //else
                    //{
                    //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    //}
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //DataTable dtappid1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                    //if (dtappid1.Rows.Count != 0)
                    //{

                    //    _obj_GS = new PMS_GoalSettings();
                    //    _obj_GS.GS_MODE = 9;
                    //    _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                    //    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid1.Rows[0]["APPRCYCLE_ID"]);

                    //    DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                    //    //if (dt1.Rows.Count != 0)
                    //    //{
                    //    //    RCB_RoleName.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    //    //    RCMB_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    //    //    RCMB_Project.Enabled = true;
                    //    //    RCB_RoleName.Enabled = true;

                    //    //}
                    //}
                    //else
                    //{
                    //    //RCB_RoleName.Text = string.Empty;
                    //    //RCMB_Project.Text = string.Empty;
                    //    //RCMB_Project.Enabled = false;
                    //    //RCB_RoleName.Enabled = false;

                    //}
                }
                else
                {
                    RCB_EmployeeName.Items.Clear();
                    Pms_Bll.ShowMessage(this, "No Employees Are There Under That Manager For this Business Unit.");
                    return;

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployeesEdit()
    {
        try
        {

            //if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
            //{

            if ((Convert.ToString(Session["EMP_TYPE"])) == "0")//for manager only this screen not for employee
            {
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                _obj_PMS_getemployee.Mode = 2;
                DataTable dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid.Rows.Count != 0)
                {
                    txt_ReportingManager.Text = Convert.ToString(dtbuid.Rows[0]["REPORTINGMANAGER"]);
                    txt_GeneralManager.Text = Convert.ToString(dtbuid.Rows[0]["approvalmgr"]);
                    RCB_EmployeeName.SelectedValue = Convert.ToInt32(dtbuid.Rows[0]["EMPID"]).ToString();
                    RCB_EmployeeName.Items.Clear();
                    RCB_EmployeeName.DataSource = dtbuid;
                    RCB_EmployeeName.DataTextField = "employee";
                    RCB_EmployeeName.DataValueField = "EMPID";
                    RCB_EmployeeName.DataBind();
                    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //RCB_BusinessUnit.Visible = false;
                    //lbl_BusinessUnit.Visible = false;
                    txt_ReportingManager.Enabled = false;
                    txt_GeneralManager.Enabled = false;
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);//where i am passing employee to get bunit

                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtem.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    else
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 9;
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value); //Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    }
                    else
                    {
                        _obj_GS.GS_APPRAISAL_CYCLE = string.Empty;

                    }
                    DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                    if (dt1.Rows.Count != 0)
                    {
                        //RCB_RoleName.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                        //RCMB_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                        //RCMB_Project.Enabled = true;
                        //RCB_RoleName.Enabled = true;

                    }
                }


                else
                {
                    RCB_EmployeeName.Items.Clear();
                    Pms_Bll.ShowMessage(this, "No Employees Are There Under That Manager For this Business Unit.");
                    return;

                }
            }
            else
            {
                _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //RCB_BusinessUnit.Items.Clear();
                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                _obj_PMS_getemployee.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 9;
                DataTable DT_AppraisalCycle = new DataTable();
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_PMS_getemployee.Mode = 2;

                if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
                {
                    _obj_PMS_getemployee.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                }
                else
                {
                    _obj_PMS_getemployee.BU_ID = 0;
                }

                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.GS_APPRAISAL_CYCLE = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value); //Convert.ToInt32(DT_AppraisalCycle.Rows[0]["APPRCYCLE_ID"]);
                DataTable dtbuid1 = new DataTable();
                _obj_PMS_getemployee.Mode = 3;
                dtbuid1 = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
                if (dtbuid1.Rows.Count != 0)
                {
                    //lbl_desg_text.Text = Convert.ToString(dtbuid1.Rows[0]["POSITIONS_CODE"]);
                    lbl_RMID.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMGR_ID"]);
                    lbl_GMID.Text = Convert.ToString(dtbuid1.Rows[0]["approvalmgr_ID"]);
                    txt_ReportingManager.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                    txt_GeneralManager.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMGR"]);
                    RCB_EmployeeName.SelectedValue = Convert.ToInt32(dtbuid1.Rows[0]["EMPID"]).ToString();
                    //  RCB_EmployeeName.Items.Clear();
                    RCB_EmployeeName.DataSource = dtbuid1;
                    RCB_EmployeeName.DataTextField = "employee";
                    RCB_EmployeeName.DataValueField = "EMPID";
                    RCB_EmployeeName.DataBind();
                    RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    RCB_EmployeeName.Items.Clear();
                    Pms_Bll.ShowMessage(this, "No Employees Are There Under That Manager For this Business Unit.");
                    return;

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void LOADBUID()
    {
        try
        {
            _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            RCB_BusinessUnit.Items.Clear();
            DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
            if (dt_bu.Rows.Count != 0)
            {
                RCB_BusinessUnit.DataSource = dt_bu;
                RCB_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                RCB_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                RCB_BusinessUnit.DataBind();
                RCB_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

            Session["BU"] = dt_bu;

            ////To check whether organisation has Integration with Smart PM or not 
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_bu1 = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //if (dt_bu1.Rows.Count > 0)
            //{
            //    //if (dt_bu1.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu1.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
            //    //{
            //    //    //rlst_pjt.Items.Clear();
            //    //}
            //    //else
            //    //{
            //    //    LoadProject();
            //    //}
            //}
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void LoadRolename()
    //{
    //    try
    //    {
    //        DataTable dt = (DataTable)Session["BU"];

    //        //RCB_RoleName.Items.Clear();
    //        _obj_roles = new PMS_BINDROLES();

    //        _obj_roles.MODE = 8;
    //        if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
    //        {
    //            //_obj_roles.BUID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
    //            _obj_roles.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
    //        }
    //        else
    //        {
    //            _obj_roles.BUID = 0;

    //        }
    //        _obj_roles.CREATEDBY = Convert.ToInt32(Session["org_id"]);

    //        DataTable DT_Roles = new DataTable();

    //        DT_Roles = Pms_Bll.get_roles(_obj_roles);
    //        if (DT_Roles.Rows.Count != 0)
    //        {
    //            RCB_RoleName.DataSource = DT_Roles;
    //            RCB_RoleName.DataTextField = "ROLE_NAME";
    //            RCB_RoleName.DataValueField = "ROLE_ID";
    //            RCB_RoleName.DataBind();
    //            RCB_RoleName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        }

    //        else
    //        {
    //            DataTable dt6 = new DataTable();
    //            RCB_RoleName.DataSource = dt6;

    //            RCB_RoleName.DataBind();
    //            RCB_RoleName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void LoadAppraisalCycle()
    {
        try
        {
            DataTable dt = (DataTable)Session["BU"];

            RCB_ApprasialCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

            _obj_Pms_Appraisalcycle.MODE = 9;
            if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
            {
                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                RCB_ApprasialCycle.DataSource = DT_AppraisalCycle;
                RCB_ApprasialCycle.DataTextField = "APPRCYCLE_NAME";
                RCB_ApprasialCycle.DataValueField = "APPRCYCLE_ID";
                RCB_ApprasialCycle.DataBind();
                RCB_ApprasialCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt6 = new DataTable();

                RCB_ApprasialCycle.DataSource = dt6;

                RCB_ApprasialCycle.DataBind();
                RCB_ApprasialCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //protected void LoadProject()
    //{
    //    try
    //    {
    //        DataTable dt = (DataTable)Session["BU"];
    //        rlst_pjt.Items.Clear();
    //        _obj_Pms_Project = new SPMS_PROJECT();
    //        //if (Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value) > 0)
    //        //{
    //        //    //_obj_Pms_Project.BUID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
    //        //    _obj_Pms_Project.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
    //        //}
    //        //else
    //        //{
    //        //    _obj_Pms_Project.BUID = 0;
    //        //}
    //        _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(Session["org_id"]);
    //        _obj_Pms_Project.Mode = 6;
    //        DataTable DT_Project = new DataTable();
    //        DT_Project = Pms_Bll.get_Project(_obj_Pms_Project);
    //        if (DT_Project.Rows.Count != 0)
    //        {
    //            rlst_pjt.DataSource = DT_Project;
    //            rlst_pjt.DataTextField = "PROJECT_NAME";
    //            rlst_pjt.DataValueField = "PROJECT_ID";
    //            rlst_pjt.DataBind();
    //        }
    //        else
    //        {
    //            DataTable dt6 = new DataTable();
    //            rlst_pjt.DataSource = dt6;

    //            rlst_pjt.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //protected void LoadProject_SMPM()
    //{
    //    try
    //    {
    //        if (RCB_EmployeeName.SelectedIndex > 0)
    //        {
    //            DataTable dt = (DataTable)Session["BU"];
    //            rlst_pjt.Items.Clear();

    //            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    //            _obj_smhr_logininfo.OPERATION = operation.Select3;
    //            _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
    //            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
    //            if (dt_emp.Rows.Count > 0)
    //            {
    //                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//Convert.ToInt32(dt_emp.Rows[0]["EMP_BUSINESSUNIT_ID"]);
    //                _obj_smhr_logininfo.OPERATION = operation.Empty;
    //                DataTable dt_org = BLL.get_LoginInfo(_obj_smhr_logininfo);
    //                if (dt_org.Rows.Count > 0)
    //                {
    //                    _obj_Pms_Project = new SPMS_PROJECT();
    //                    _obj_Pms_Project.EMP_CODE = Convert.ToString(dt_emp.Rows[0]["EMP_EMPCODE"]);
    //                    _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(dt_org.Rows[0]["SMPM_ORG"]);
    //                    //_obj_Pms_Project.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
    //                    _obj_Pms_Project.Mode = 9;
    //                    DataTable DT_Project = Pms_Bll.get_Project(_obj_Pms_Project);
    //                    if (DT_Project.Rows.Count > 0)
    //                    {
    //                        rlst_pjt.DataSource = DT_Project;
    //                        rlst_pjt.DataTextField = "PROJECT_NAME";
    //                        rlst_pjt.DataValueField = "PROJECT_ID";
    //                        rlst_pjt.DataBind();
    //                    }
    //                    else
    //                    {
    //                        DataTable dt6 = new DataTable();
    //                        rlst_pjt.DataSource = dt6;
    //                        rlst_pjt.DataBind();
    //                        Pms_Bll.ShowMessage(this, "Please Assign Projects for this Employee in Smart PM.");
    //                        return;
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            DataTable dt6 = new DataTable();
    //            rlst_pjt.DataSource = dt6;
    //            rlst_pjt.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}
    //protected void LoadProject_SMPM_Edit()
    //{
    //    try
    //    {
    //        if (RCB_EmployeeName.SelectedIndex > 0)
    //        {
    //            DataTable dt = (DataTable)Session["BU"];
    //            rlst_pjt.Items.Clear();

    //            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
    //            _obj_smhr_logininfo.OPERATION = operation.Select3;
    //            _obj_smhr_logininfo.LOGIN_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
    //            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //            DataTable dt_emp = BLL.get_LoginInfo(_obj_smhr_logininfo);
    //            if (dt_emp.Rows.Count > 0)
    //            {
    //                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);//Convert.ToInt32(dt_emp.Rows[0]["EMP_BUSINESSUNIT_ID"]);
    //                _obj_smhr_logininfo.OPERATION = operation.Empty;
    //                DataTable dt_org = BLL.get_LoginInfo(_obj_smhr_logininfo);
    //                if (dt_org.Rows.Count > 0)
    //                {
    //                    _obj_Pms_Project = new SPMS_PROJECT();
    //                    _obj_Pms_Project.EMP_CODE = Convert.ToString(dt_emp.Rows[0]["EMP_EMPCODE"]);
    //                    _obj_Pms_Project.PROJECT_ORG_ID = Convert.ToInt32(dt_org.Rows[0]["SMPM_ORG"]);
    //                    //_obj_Pms_Project.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
    //                    _obj_Pms_Project.Mode = 10;
    //                    DataTable DT_Project = Pms_Bll.get_Project(_obj_Pms_Project);
    //                    if (DT_Project.Rows.Count > 0)
    //                    {
    //                        rlst_pjt.DataSource = DT_Project;
    //                        rlst_pjt.DataTextField = "PROJECT_NAME";
    //                        rlst_pjt.DataValueField = "PROJECT_ID";
    //                        rlst_pjt.DataBind();
    //                    }
    //                    else
    //                    {
    //                        DataTable dt6 = new DataTable();
    //                        rlst_pjt.DataSource = dt6;
    //                        rlst_pjt.DataBind();
    //                        Pms_Bll.ShowMessage(this, "Please Assign Projects for this Employee in Smart PM.");
    //                        return;
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            DataTable dt6 = new DataTable();
    //            rlst_pjt.DataSource = dt6;
    //            rlst_pjt.DataBind();
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //    }
    //}

    protected void createcontrols()
    {
        try
        {
            DataTable dt_KRA = new DataTable();
            DataTable dt_goal = new DataTable();
            DataTable dt_IDP = new DataTable();

            dt_KRA.Rows.Clear();
            dt_KRA.Columns.Clear();
            dt_goal.Rows.Clear();
            dt_goal.Columns.Clear();
            dt_KRA.Columns.Add("GSID");
            dt_KRA.Columns.Add("ROLEKRA_ID");
            dt_KRA.Columns.Add("NAME");
            dt_KRA.Columns.Add("DESC");
            //dt_KRA.Columns.Add("MEASURE");
            //dt_KRA.Columns.Add("WEIGHTAGE");

            //dt_KRA.Columns.Add("TARGET");
            //dt_KRA.Columns.Add("TIMELINES");

            //dt_KRA.Columns.Add("SNO");
            dt_KRA.Columns.Add("A");//to differ it from Goal or KRA
            dt_KRA.Columns.Add("KRA_ID");
            dt_KRA.Columns.Add("SNO");
            //dt_KRA.Columns.Add("KRA_NAME");
            dt_KRA.PrimaryKey = new DataColumn[] { dt_KRA.Columns["SNO"] };
            Session["dtKRA"] = dt_KRA;


            dt_IDP.Rows.Clear();
            dt_IDP.Columns.Clear();
            dt_IDP.Rows.Clear();
            dt_IDP.Columns.Clear();
            dt_IDP.Columns.Add("GSID");
            dt_IDP.Columns.Add("ROLEKRA_ID");
            dt_IDP.Columns.Add("NAME");
            dt_IDP.Columns.Add("DESC");
            //dt_IDP.Columns.Add("MEASURE");
            //dt_IDP.Columns.Add("WEIGHTAGE");

            //dt_IDP.Columns.Add("TARGET");
            //dt_IDP.Columns.Add("TIMELINES");

            //dt_KRA.Columns.Add("SNO");
            dt_IDP.Columns.Add("A");//to differ it from Goal or KRA
            dt_IDP.Columns.Add("SNO");
            dt_IDP.PrimaryKey = new DataColumn[] { dt_IDP.Columns["SNO"] };
            Session["dt_IDP"] = dt_IDP;

            dt_goal.Columns.Add("GSID");
            dt_goal.Columns.Add("ROLEKRA_ID");
            dt_goal.Columns.Add("NAME");
            dt_goal.Columns.Add("DESC");
            //dt_goal.Columns.Add("MEASURE");
            //dt_goal.Columns.Add("WEIGHTAGE");

            //dt_goal.Columns.Add("TARGET");
            //dt_goal.Columns.Add("TIMELINES");

            dt_goal.Columns.Add("SN0");
            dt_goal.PrimaryKey = new DataColumn[] { dt_goal.Columns["SNO"] };
            ViewState["dtgoal"] = dt_goal;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Select Index Changed

    protected void RCB_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RCB_BusinessUnit.SelectedIndex > 0)
            {
                /* New Code */
                LoadPositions();    //To load Positions based on Business Unit

                /* New Code */


                //LoadEmployees();
                //LoadRolename();
                createcontrols();
                //LoadProject();
                LoadAppraisalCycle();
                RCB_EmployeeName.ClearSelection();
                RCB_EmployeeName.Items.Clear();
                RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                ////To check whether organisation has Integration with Smart PM or not 
                //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                //if (dt_bu.Rows.Count > 0)
                //{
                //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
                //    {
                //        rlst_pjt.Items.Clear();
                //    }
                //    else
                //    {
                //        rlst_pjt.ClearChecked();
                //    }
                //}
            }
            else
            {
                RCB_EmployeeName.ClearSelection();
                RCB_EmployeeName.Items.Clear();
                RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //RCB_RoleName.Items.Clear();
                //rlst_pjt.ClearChecked();
                RCB_ApprasialCycle.ClearSelection();
                RCB_ApprasialCycle.Items.Clear();
                RCB_ApprasialCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            //lbl_desg_text.Text = string.Empty;
            txt_GeneralManager.Text = string.Empty;
            txt_ReportingManager.Text = string.Empty;
            lnk_ViewKRA.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void RCB_ApprasialCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RCB_ApprasialCycle.SelectedIndex > 0)
            {
                LoadEmployees();
            }
            else
            {
                RCB_EmployeeName.ClearSelection();
                RCB_EmployeeName.Items.Clear();
                RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            //RCB_RoleName.SelectedIndex = 0;
            //rlst_pjt.ClearChecked();
            //txt_JobDescription.Text = string.Empty;
            txt_GeneralManager.Text = string.Empty;
            txt_ReportingManager.Text = string.Empty;
            //lbl_desg_text.Text = string.Empty;
            lnk_ViewKRA.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RCB_EmployeeName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

            if ((RCB_EmployeeName.SelectedItem.Text == "Select"))
            {
                Pms_Bll.ShowMessage(this, "Please Select Employee");
                txt_ReportingManager.Enabled = true;
                txt_GeneralManager.Enabled = true;
                //lbl_desg_text.Text = string.Empty;
                txt_ReportingManager.Text = String.Empty;
                txt_GeneralManager.Text = string.Empty;
                //RCMB_Project.SelectedIndex = 0;
                //rlst_pjt.SelectedIndex = -1;
                //rlst_pjt.Enabled = false;
                //RCB_RoleName.SelectedIndex = 0;
                //RCB_ApprasialCycle.SelectedIndex = 0;
                //rlst_pjt.ClearChecked();
                //txt_JobDescription.Text = string.Empty;

                ////To check whether organisation has Integration with Smart PM or not 
                //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                //if (dt_bu.Rows.Count > 0)
                //{
                //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
                //    {
                //        rlst_pjt.Items.Clear();
                //    }
                //    else
                //    {
                //        rlst_pjt.ClearChecked();
                //    }
                //}
            }
            else
            {
                ////To check whether organisation has Integration with Smart PM or not 
                //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
                //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
                //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_bu = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
                //if (dt_bu.Rows.Count > 0)
                //{
                //    if (dt_bu.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
                //    {
                //        //LoadProject_SMPM();
                //    }
                //    else
                //    {
                //        rlst_pjt.ClearChecked();
                //    }
                //}

                _obj_Pms_EmpSetup = new PMS_EMPSETUP();
                _obj_Pms_LoginInfo = new PMS_LOGININFO();
                _obj_Pms_LoginInfo.EMPID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {
                    //lbl_desg_text.Text = Convert.ToString(DTREPO.Rows[0]["POSITIONS_CODE"]);
                    txt_ReportingManager.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    txt_ReportingManager.Enabled = false;
                    lbl_RMID.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_ID"]);
                    lbl_GMID.Text = Convert.ToString(DTREPO.Rows[0]["GENERALMGR_ID"]);
                }


                _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 7;
                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    txt_GeneralManager.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    txt_GeneralManager.Enabled = false;

                }

                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzzl.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzl.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                else
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;

                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                _obj_Pms_EmpGoalSetting.Mode = 15;
                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                if (dtappidzzl.Rows.Count != 0)
                {

                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value);//Convert.ToString(dtappidzzl.Rows[0]["APPRCYCLE_ID"]);
                }
                else
                {
                    _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";
                }
                _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["org_id"]);
                DataTable DT12 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);

                //To fetch Position_ID of the selected employee
                _obj_Pms_EmpGoalSetting.Mode = 36;
                _obj_Pms_EmpGoalSetting.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_EmpGoalSetting.BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
                DataTable dtPosition = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                if (dtPosition.Rows.Count > 0)
                {
                    rcmb_Position.SelectedIndex = rcmb_Position.FindItemIndexByValue(Convert.ToString(dtPosition.Rows[0]["POSITIONS_ID"]));
                    rcmb_Position.Enabled = false;
                }
                else
                    rcmb_Position.SelectedIndex = 0;

                //***to check the goal setting status of the the selected employee *****/

                //if (DT12.Rows.Count != 0)
                //{


                //    Pms_Bll.ShowMessage(this, "Already Goal Setting Done For This Employee");
                //    btn_Save.Enabled = false;
                //}
                //else
                //{
                btn_Save.Enabled = true;
                //}
                //RCMB_Project.SelectedIndex = 0;
                //rlst_pjt.SelectedIndex = -1;
                //rlst_pjt.Enabled = true;
                //RCB_RoleName.SelectedIndex = 0;
                //RCB_ApprasialCycle.SelectedIndex = 0;
                //rlst_pjt.ClearChecked();
                //txt_JobDescription.Text = string.Empty;
                //DataTable dt_empty = new DataTable();
                //Rg_KRAGOAL.DataSource = dt_empty;
                //Rg_KRAGOAL.DataBind();


            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RCB_KRA_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RCB_KRA.SelectedIndex > 0)
            {
                //_obj_PMS_KRA = new pms_kraform();
                //_obj_PMS_KRA.KRA_MODE = 6;
                //_obj_PMS_KRA.KRA_NAME = Convert.ToString(RCB_KRA.SelectedItem.Value);
                //DataTable dt1 = new DataTable();
                //dt1 = Pms_Bll.get_kra(_obj_PMS_KRA);

                /* To load KRA_Objectives */
                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.Mode = 10;
                _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(RCB_KRA.SelectedValue);
                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtKraObjectives = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
                rcmb_KraObjective.Items.Clear();    //To clear items
                rcmb_KraObjective.Text = string.Empty;  //To clear selected item
                rfv_rcmb_KraObjective.Enabled = true;
                if (dtKraObjectives.Rows.Count > 0)
                {
                    rcmb_KraObjective.DataSource = dtKraObjectives;
                    rcmb_KraObjective.DataTextField = "KRA_OBJ_NAME";
                    rcmb_KraObjective.DataValueField = "KRA_OBJ_ID";
                    rcmb_KraObjective.DataBind();
                    rcmb_KraObjective.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }







                // _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                _obj_Pms_RoleKra.Mode = 9;
                ////_obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(RCB_RoleName.SelectedItem.Value);
                _obj_Pms_RoleKra.ROLE_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
                //_obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(RCB_KRA.SelectedValue);
                //_obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtKraDtls = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
                if (dtKraDtls.Rows.Count != 0)
                {

                    txt_KraDescription.Text = Convert.ToString(dtKraDtls.Rows[0]["KRA_DESCRIPTION"]);
                    //txt_KraMeasure.Text = Convert.ToString(dt1.Rows[0]["KRA_MEASURE"]);


                    //txt_KraMeasure.Enabled = false;
                    txt_KraDescription.Enabled = false;
                    //rnt_KraWeigthage.Enabled = false;
                    //Rg_KRA.Visible = false;

                    btn_SaveAssignkra.Visible = true;
                    //btn_UpdateAssignkra.Visible = false;
                    //RNT_KraTarget.Text = string.Empty;

                    //rnt_Kratargetachieved.Text = string.Empty;
                    //rdtp_TIMELINES.MinDate = DateTime.Now;
                }
                else
                {

                    //txt_KraDescription.Enabled = true;
                    txt_KraDescription.Enabled = false;
                    //txt_KraMeasure.Enabled = true;
                    //txt_KraMeasure.Text = string.Empty;
                    txt_KraDescription.Text = string.Empty;
                    //rdtp_TIMELINES.MinDate = DateTime.Now;
                    return;

                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Kra");
                rcmb_KraObjective.Items.Clear();
                rcmb_KraObjective.Text = string.Empty;
                //txt_KraDescription.Enabled = true;
                txt_KraDescription.Enabled = false;
                //txt_KraMeasure.Enabled = true;
                //txt_KraMeasure.Text = string.Empty;
                txt_KraDescription.Text = string.Empty;
                //rdtp_TIMELINES.MinDate = DateTime.Now;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_idp_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_idp.SelectedIndex > 0)
            {
                _obj_idp = new pms_IDPSCREEN();
                _obj_idp.IDP_MODE = 7;
                //_obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rcmb_idp.SelectedItem.Text));
                //_obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                _obj_idp.IDP_ID = Convert.ToInt32(rcmb_idp.SelectedValue);
                _obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_idp(_obj_idp);
                if (dt.Rows.Count != 0)
                {
                    //string str = Convert.ToString(dt.Rows[0]["IDP_DESCRIPTION"]);

                    txt_idpdesc.Text = Convert.ToString(dt.Rows[0]["IDP_DESCRIPTION"]);



                    //txt_idpmeasure.Enabled = true;
                    txt_idpdesc.Enabled = false;
                    //rnt_KraWeigthage.Enabled = false;
                    //Rg_KRA.Visible = false;

                    btn_IDP_Save.Visible = true;
                    //btn_IDP_Update.Visible = false;
                    //rtxt_idptarget.Text = string.Empty;

                    //rnt_Kratargetachieved.Text = string.Empty;
                    //rdtp_TIMELINES.MinDate = DateTime.Now;
                }
                else
                {

                    //txt_idpdesc.Enabled = true;
                    txt_idpdesc.Enabled = false;
                    txt_idpdesc.Text = string.Empty;
                    //txt_idpmeasure.Enabled = true;
                    //txt_idpmeasure.Text = string.Empty;
                    //rdtp_TIMELINES.MinDate = DateTime.Now;
                    return;

                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select  value");
                //txt_idpdesc.Enabled = true;
                txt_idpdesc.Enabled = false;
                txt_idpdesc.Text = string.Empty;
                //txt_idpmeasure.Enabled = true;
                //txt_idpmeasure.Text = string.Empty;
                //rdtp_TIMELINES.MinDate = DateTime.Now;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region GoalSettings Save

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //bool selected = false;
            //for (int selecteditems = 0; selecteditems < rlst_pjt.Items.Count; selecteditems++)
            //{
            //    if (rlst_pjt.Items[selecteditems].Checked)
            //        selected = true;
            //}
            //if (!selected)
            //{
            //    BLL.ShowMessage(this, "Please Select Atleast One Project.");
            //    return;
            //}
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtemzzl.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappidzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
            _obj_Pms_EmpGoalSetting.Mode = 15;

            _obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            if (dtappidzzl.Rows.Count != 0)
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value);//Convert.ToString(dtappidzzl.Rows[0]["APPRCYCLE_ID"]);
            }
            else
            {
                _obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = "0";

            }
            _obj_Pms_EmpGoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    DataTable DT12 = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                    if (DT12.Rows.Count != 0)
                    {
                        Pms_Bll.ShowMessage(this, "Already Goal Setting Done");
                        return;
                    }
                    else
                    {
                        _obj_GS = new PMS_GoalSettings();
                        _obj_GS.GS_MODE = 4;

                        _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
                        _obj_GS.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                        _obj_GS.GS_APPRAISAL_CYCLE = (RCB_ApprasialCycle.SelectedValue);
                        //_obj_GS.GS_ROLENAME = Convert.ToInt32(RCB_RoleName.SelectedValue);
                        _obj_GS.GS_ROLENAME = Convert.ToInt32(rcmb_Position.SelectedValue);

                        //_obj_GS.GS_JOB_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_JobDescription.Text));
                        //_obj_GS.GS_PROJECT = Convert.ToString(RCMB_Project.SelectedValue);
                        //ShowCheckedItems(rlst_pjt, Label1);
                        //_obj_GS.GS_PROJECT = Convert.ToString(Label1.Text);
                        _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_GS.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GS.LASTMDFDATE = DateTime.Now;
                        _obj_GS.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GS.CREATEDDATE = DateTime.Now;
                        bool status = Pms_Bll.set_GS(_obj_GS);
                        if (status == true)
                        {
                            Pms_Bll.ShowMessage(this, "Record Inserted Successfully");
                            btn_Save.Enabled = false;
                            btn_assignGoal.Visible = true;
                            btn_assignIDP.Visible = true;
                            btn_assignKRA.Visible = true;
                            RCB_EmployeeName.Enabled = false;
                            rcmb_Position.Enabled = false;
                            RCB_BusinessUnit.Enabled = false;
                            //RCB_RoleName.Enabled = false;
                            //RCMB_Project.Enabled = false;
                            //rlst_pjt.Enabled = false;
                            RCB_ApprasialCycle.Enabled = false;
                            //txt_JobDescription.Enabled = false;
                            btn_Save_Details.Visible = true;
                            lnk_CopyKRA.Visible = true;

                        }


                        //DataTable dt_empty = new DataTable();
                        //Rg_KRAGOAL.DataSource = dt_empty;
                    }
                    break;
                case "BTN_UPDATE":
                    _obj_GS = new PMS_GoalSettings();
                    _obj_GS.GS_MODE = 5;
                    _obj_GS.GS_ID = Convert.ToInt32(lbl_gs_dum_id.Text);
                    _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedValue);
                    _obj_GS.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
                    _obj_GS.GS_APPRAISAL_CYCLE = (RCB_ApprasialCycle.SelectedValue);
                    //_obj_GS.GS_ROLENAME = Convert.ToInt32(RCB_RoleName.SelectedValue);
                    _obj_GS.GS_ROLENAME = Convert.ToInt32(rcmb_Position.SelectedValue);
                    //_obj_GS.GS_JOB_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(txt_JobDescription.Text));
                    //_obj_GS.GS_PROJECT = Convert.ToString(RCMB_Project.SelectedValue);
                    //ShowCheckedItems(rlst_pjt, Label1);
                    //_obj_GS.GS_PROJECT = Convert.ToString(Label1.Text);
                    _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_GS.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                    _obj_GS.LASTMDFDATE = DateTime.Now;
                    _obj_GS.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                    _obj_GS.CREATEDDATE = DateTime.Now;
                    bool status1 = Pms_Bll.set_GS(_obj_GS);
                    if (status1 == true)
                    {
                        Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                        btn_Save.Enabled = false;
                        btn_Update.Enabled = false;
                        btn_assignGoal.Visible = true;
                        btn_assignIDP.Visible = true;
                        btn_assignKRA.Visible = true;
                        RCB_EmployeeName.Enabled = false;
                        rcmb_Position.Enabled = false;
                        RCB_BusinessUnit.Enabled = false;
                        //RCB_RoleName.Enabled = false;
                        //RCMB_Project.Enabled = false;
                        //rlst_pjt.Enabled = false;
                        RCB_ApprasialCycle.Enabled = false;
                        //txt_JobDescription.Enabled = false;
                        btn_Save_Details.Visible = true;
                        lnk_CopyKRA.Visible = true;

                    }
                    break;
                default:
                    break;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Add KRAs, Goal (Competency), IDP (Values) to grid

    protected void btn_SaveAssignkra_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_KraObjective.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please Select Objective");
                return;
            }
            //int totaltemp = 0;
            //int weightage = 0;
            //int f =0;
            //if (Check_Combo(Rg_KRAGOAL, "lbl_ID", RCB_KRA))
            if (Check_Combo(Rg_KRAGOAL, "lbl_ID", rcmb_KraObjective))
            {

                DataTable dt_KRA = (DataTable)Session["dtKRA"];
                DataRow dr = dt_KRA.NewRow();
                //dr[0] = Convert.ToString(RCB_KRA.SelectedItem.Value);
                dr[0] = Convert.ToInt32(0); //To identify that 0 is not from DB
                //dr[1] = Convert.ToString(RCB_KRA.SelectedValue);
                //dr[2] = Convert.ToString(RCB_KRA.SelectedItem.Text.Replace("'", "''"));
                dr[1] = Convert.ToString(rcmb_KraObjective.SelectedValue);
                dr[2] = Convert.ToString(rcmb_KraObjective.SelectedItem.Text.Replace("'", "''"));
                dr[3] = Convert.ToString(txt_KraDescription.Text.Replace("'", "''"));
                //dr[4] = Convert.ToString(txt_KraMeasure.Text.Replace("'", "''"));
                //int wt = Convert.ToInt32(RNT_KraWeightage.Text);
                //// GridFooterItem footer = (GridFooterItem)Rg_KRAGOAL.MasterTableView.GetItems(GridItemType.Footer)[0];
                //totaltemp = wt;
                //if (Rg_KRAGOAL.Items.Count > 0)
                //{
                //    for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                //    {
                //        TextBox txt;
                //        txt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage");
                //        weightage = Convert.ToInt32(txt.Text);
                //        totaltemp = weightage + totaltemp;
                //         f = totaltemp;
                //    }
                //    //if ((weightage + totaltemp) > 100)
                //    //{
                //    //    BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
                //    //    return;
                //    //}
                //    if (f > 100)
                //    {
                //        BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
                //        return;
                //    }
                //    else
                //    {
                //        dr[5] = RNT_KraWeightage.Text;
                //    }
                //}
                //else
                //{
                //dr[5] = RNT_KraWeightage.Text;
                //}
                //dr[6] = Convert.ToString(RNT_KraTarget.Text.Replace("'", "''"));
                //

                ////**** to check KRA date falls in Appraisal cycle date range ****//

                //int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                //_obj_Pms_Appraisalcycle.MODE = 2;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_TIMELINES.SelectedDate.Value <= dt_et) && (rdtp_TIMELINES.SelectedDate.Value >= dt_st))
                ////    {
                ////        dr[7] = rdtp_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                ////    }

                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////}
                //dr[8] = rnt_Kratargetachieved.Text;
                dr[4] = "KRA";
                dr[5] = Convert.ToInt32(RCB_KRA.SelectedValue);
                dr[6] = dt_KRA.Rows.Count + 1;// Convert.ToString(dt_KRA.Rows.Count + 1);
                //dr[6] = Convert.ToString(RCB_KRA.SelectedValue);
                //dr[7] = Convert.ToString(RCB_KRA.SelectedItem.Text.Replace("'", "''"));
                dt_KRA.Rows.Add(dr);
                // clearfields();
                //ds.Tables.Add(dt_KRA);
                dt_KRA.DefaultView.Sort = "A ASC";
                dt_KRA = dt_KRA.DefaultView.ToTable();
                Rg_KRAGOAL.DataSource = dt_KRA;
                Rg_KRAGOAL.DataBind();
                Session["dtKRA"] = dt_KRA;
                Rg_KRAGOAL.Visible = true;

                RM_GS.SelectedIndex = 1;

                btn_Save_Details.Visible = true;

                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GS_DETAILS_MODE = 12;
                _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dtgsdtlid.Rows.Count != 0)
                {

                    btn_Update_Details.Visible = true;
                    btn_Save_Details.Visible = false;
                }
                else
                {
                    btn_Update_Details.Visible = false;
                    btn_Save_Details.Visible = true;
                }
                btn_Update.Enabled = false;
                //RCB_RoleName.Enabled = false;
                string s = lbl_gs_dum_id.Text;
                if (s != "")
                {
                    if (dtgsdtlid.Rows.Count != 0)
                    {


                        hd_Field.Value = "2";
                    }
                    else
                    {
                        hd_Field.Value = "1";
                    }

                }
                else
                {
                    hd_Field.Value = "1";

                }
                //btn_assignGoal.Visible = true;
                //btn_assignKRA.Visible = false;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "This KRA is already assigned");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string z = Convert.ToString(txt_GoalDescription.Text);
            //string b = Convert.ToString(txt_Measure.Text);
            if (rcmb_CMP.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please Select Competency");
                return;
            }

            //if (b.Length > 50)
            //{
            //    Pms_Bll.ShowMessage(this, "Measure Cannot Greater Than 50 Characters");
            //    return;

            //}


            //int totaltemp = 0;
            //int weightage = 0;
            //int weightage_p = 0;

            if (Check_Combo2(Rg_KRAGOAL, "lbl_ID", rcmb_idp))
            {
                DataTable dt_KRA = (DataTable)Session["dtKRA"];
                DataRow dr = dt_KRA.NewRow();
                //dr[0] = dt_KRA.Rows.Count + 1;//reprents "GSID"
                dr[0] = Convert.ToInt32(0); //To identify that 0 is not from DB
                dr[1] = Convert.ToInt32(rcmb_CMP.SelectedValue);
                dr[2] = Convert.ToString(rcmb_CMP.SelectedItem.Text.Replace("'", "''"));
                dr[3] = Convert.ToString(txt_GoalDescription.Text.Replace("'", "''"));
                //dr[4] = "Goal";
                dr[4] = "Competency";
                dr[6] = dt_KRA.Rows.Count + 1;
                //for (int o = 0; o < Rg_KRAGOAL.Items.Count; o++)
                //{
                //    Label lblname = new System.Web.UI.WebControls.Label();


                //    lblname = Rg_KRAGOAL.Items[o].FindControl("lbl_NAME") as Label;
                //    //string goalgridname = Convert.ToString(txt_GoalName.Text);
                //    //string zz = Convert.ToString(lblname.Text);
                //    //if (goalgridname == zz)
                //    //{
                //    //    Pms_Bll.ShowMessage(this, "Already Goal Exist");
                //    //    //txt_GoalName.Text = string.Empty;
                //    //    return;
                //    //}
                //}



                //if (Rg_KRAGOAL.Items.Count > 0)
                //{
                //    weightage_p = Convert.ToInt32(RNT_Weightage.Text);
                //    totaltemp = weightage_p;
                //    for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                //    {
                //        TextBox txt;
                //        txt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage");

                //        weightage = Convert.ToInt32(txt.Text);

                //        totaltemp = totaltemp+weightage;
                //    }
                //    if (totaltemp > 100)
                //    {
                //        BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
                //        return;
                //    }
                //    else
                //    {
                //        dr[5] = RNT_Weightage.Text;
                //    }


                //}
                //else
                //{
                //dr[5] = RNT_Weightage.Text;
                //}

                //dr1[4] = RNT_Weightage.Text;
                //dr[9] = dt_KRA.Rows.Count + 1;
                //dr[8] = "Goal";
                //dr[6] = Convert.ToString(RNT_GoalTarget.Text.Replace("'", "''"));
                //dr[7] = rdtp_Goal_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                //int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                //_obj_Pms_Appraisalcycle.MODE = 2;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_Goal_TIMELINES.SelectedDate.Value <= dt_et) && (rdtp_Goal_TIMELINES.SelectedDate.Value >= dt_st))
                ////    {
                ////        dr[7] = rdtp_Goal_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                ////    }

                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////}

                dt_KRA.Rows.Add(dr);
                ViewState["dtgoal"] = dt_KRA;
                //ds.Tables.Add(dt_KRA);
                dt_KRA.DefaultView.Sort = "A ASC";
                dt_KRA = dt_KRA.DefaultView.ToTable();
                Rg_KRAGOAL.DataSource = dt_KRA;
                Session["dtKRA"] = dt_KRA;
                Rg_KRAGOAL.DataBind();
                RM_GS.SelectedIndex = 1;
                btn_Save_Details.Visible = true;
                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GS_DETAILS_MODE = 12;
                _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dtgsdtlid.Rows.Count != 0)
                {

                    btn_Update_Details.Visible = true;
                    btn_Save_Details.Visible = false;
                }
                else
                {
                    btn_Update_Details.Visible = false;
                    btn_Save_Details.Visible = true;
                }
                btn_Update.Enabled = false;
                //RCB_RoleName.Enabled = false;
                string s = lbl_gs_dum_id.Text;
                if (s != "")
                {
                    if (dtgsdtlid.Rows.Count != 0)
                    {


                        hd_Field.Value = "2";
                    }
                    else
                    {
                        hd_Field.Value = "1";
                    }

                }
                else
                {
                    hd_Field.Value = "1";

                }

                //btn_assignGoal.Visible = false;
                //btn_assignKRA.Visible = true;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "This Competency is already assigned");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_IDP_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //int totaltemp = 0;
            //int weightage = 0;
            //int f = 0;
            if (Check_Combo1(Rg_KRAGOAL, "lbl_ID", rcmb_idp))
            {

                DataTable dt_KRA = (DataTable)Session["dtKRA"];
                DataRow dr = dt_KRA.NewRow();
                //dr[0] = Convert.ToString(rcmb_idp.SelectedItem.Value);
                dr[0] = Convert.ToInt32(0); //To identify that 0 is not from DB
                dr[1] = Convert.ToString(rcmb_idp.SelectedValue);
                dr[2] = Convert.ToString(rcmb_idp.SelectedItem.Text.Replace("'", "''"));
                dr[3] = Convert.ToString(txt_idpdesc.Text.Replace("'", "''"));
                //dr[4] = Convert.ToString(txt_idpmeasure.Text.Replace("'", "''"));
                //int wt = Convert.ToInt32(rnt_idp_wt.Text);
                // GridFooterItem footer = (GridFooterItem)Rg_KRAGOAL.MasterTableView.GetItems(GridItemType.Footer)[0];
                //totaltemp = wt;
                //if (Rg_KRAGOAL.Items.Count > 0)
                //{
                //    for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                //    {
                //        TextBox txt;
                //        txt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage");
                //        weightage = Convert.ToInt32(txt.Text);
                //        totaltemp = weightage + totaltemp;
                //        f = totaltemp;
                //    }
                //    //if ((weightage + totaltemp) > 100)
                //    //{
                //    //    BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
                //    //    return;
                //    //}
                //    if (f > 100)
                //    {
                //        BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
                //        return;
                //    }
                //    else
                //    {
                //        dr[5] = RNT_KraWeightage.Text;
                //    }
                //}
                //else
                //{
                //dr[5] = rnt_idp_wt.Text;
                //}
                //dr[6] = Convert.ToString(rtxt_idptarget.Text.Replace("'", "''"));
                //

                ////**** to check KRA date falls in Appraisal cycle date range ****//

                //int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                //_obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                //_obj_Pms_Appraisalcycle.MODE = 2;
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_idpdate.SelectedDate.Value <= dt_et) && (rdtp_idpdate.SelectedDate.Value >= dt_st))
                ////    {
                ////        dr[7] = rdtp_idpdate.SelectedDate.Value.Date.ToShortDateString();
                ////    }

                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////}
                //dr[8] = rnt_Kratargetachieved.Text;
                //dr[4] = "IDP";
                dr[4] = "Value";
                dr[6] = Convert.ToString(dt_KRA.Rows.Count + 1);
                dt_KRA.Rows.Add(dr);
                // clearfields();
                //ds.Tables.Add(dt_KRA);
                dt_KRA.DefaultView.Sort = "A ASC";
                dt_KRA = dt_KRA.DefaultView.ToTable();
                Rg_KRAGOAL.DataSource = dt_KRA;
                Rg_KRAGOAL.DataBind();
                Session["dtKRA"] = dt_KRA;
                Rg_KRAGOAL.Visible = true;

                RM_GS.SelectedIndex = 1;

                btn_Save_Details.Visible = true;

                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GS_DETAILS_MODE = 12;
                _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dtgsdtlid.Rows.Count != 0)
                {

                    btn_Update_Details.Visible = true;
                    btn_Save_Details.Visible = false;
                }
                else
                {
                    btn_Update_Details.Visible = false;
                    btn_Save_Details.Visible = true;
                }
                btn_Update.Enabled = false;
                //RCB_RoleName.Enabled = false;
                string s = lbl_gs_dum_id.Text;
                if (s != "")
                {
                    if (dtgsdtlid.Rows.Count != 0)
                    {
                        hd_Field.Value = "2";
                    }
                    else
                    {
                        hd_Field.Value = "1";
                    }

                }
                else
                {
                    hd_Field.Value = "1";

                }
                //btn_assignGoal.Visible = true;
                //btn_assignKRA.Visible = false;
            }
            else
            {
                Pms_Bll.ShowMessage(this, "This IDP is already assigned");
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    public bool Check_Combo(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {
            Label lbl_KRANAME = new Label();
            lbl_KRANAME = (Label)Rg_KRAGOAL.FindControl("lbl_NAME") as Label;

            
            if (Rg_KRAGOAL.Items.Count > 0)
            {
                for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    //lbl_Control = (Label)Rg_KRA.Items[i].FindControl("" + lbl_KRANAME + "") as Label;
                    //if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(RCB_KRA.SelectedItem.Text))
                    if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(rcmb_KraObjective.SelectedItem.Text))
                    {
                        status = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

    public bool Check_Combo1(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {
            Label lbl_KRANAME = new Label();
            lbl_KRANAME = (Label)Rg_KRAGOAL.FindControl("lbl_NAME") as Label;


            if (Rg_KRAGOAL.Items.Count > 0)
            {
                for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    //lbl_Control = (Label)Rg_KRA.Items[i].FindControl("" + lbl_KRANAME + "") as Label;
                    if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(rcmb_idp.SelectedItem.Text))
                    {
                        status = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

    public bool Check_Combo2(RadGrid rdGrid, string lbl_validate, RadComboBox rcmb_Validate)
    {
        bool status = true;
        try
        {
            Label lbl_KRANAME = new Label();
            lbl_KRANAME = (Label)Rg_KRAGOAL.FindControl("lbl_NAME") as Label;


            if (Rg_KRAGOAL.Items.Count > 0)
            {
                for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                {
                    Label lbl_Control = new Label();
                    lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    //lbl_Control = (Label)Rg_KRA.Items[i].FindControl("" + lbl_KRANAME + "") as Label;
                    if (Convert.ToString(lbl_KRANAME.Text) == Convert.ToString(rcmb_CMP.SelectedItem))
                    {
                        status = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        return status;
    }

    #region Adding Goal to Grid


    #endregion

    #region Update Goal , KRA

    protected void btn_UpdateGoalSettingsDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_CMP.SelectedIndex <= 0)
            {
                Pms_Bll.ShowMessage(this, "Please Select Competency");
                return;
            }
            //int totaltemp = 0;
            //totaltemp = Convert.ToInt32(RNT_Weightage.Text);
            //string z = Convert.ToString(txt_GoalDescription.Text);
            //string b = Convert.ToString(txt_Measure.Text);
            //if (z.Length > 1000)
            //{
            //    Pms_Bll.ShowMessage(this, "Description Cannot Greater Than 1000 Characters");
            //    return;

            //}

            //if (b.Length > 50)
            //{
            //    Pms_Bll.ShowMessage(this, "Measure Cannot Greater Than 50 Characters");
            //    return;

            //}

            dt_KRA = (DataTable)Session["dtKRA"];
            dt_KRA.PrimaryKey = new DataColumn[] { dt_KRA.Columns["SNO"] };
            DataRow dr;
            DataRow dr1 = dt_KRA.Rows.Find(lbl_GSID.Text);
            int RowIndex = 0;
            for (int index = 0; index < dt_KRA.Rows.Count; index++)
            {
                if (dt_KRA.Rows[index].Equals(dr1))
                {
                    RowIndex = index;
                }
                //else
                //{
                //    totaltemp = Convert.ToInt32(dt_KRA.Rows[index]["Weightage"]) + totaltemp;
                //}
            }
            //if (totaltemp > 100)
            //{
            //    BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
            //    return;
            //}
            dr = dt_KRA.Rows[RowIndex];
            dr.BeginEdit();
            if (dr["SNO"].ToString() == Convert.ToString(lbl_GSID.Text))
            {
                //dr["ROLEKRA_ID"] = Convert.ToString(lbl_GSID.Text);
                dr["ROLEKRA_ID"] = Convert.ToInt32(rcmb_CMP.SelectedValue);
                dr["NAME"] = Convert.ToString(rcmb_CMP.SelectedItem.Text);
                dr["DESC"] = Convert.ToString(txt_GoalDescription.Text.Replace("'", "''"));
                int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                _obj_Pms_Appraisalcycle.MODE = 2;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_Goal_TIMELINES.SelectedDate.Value <= dt_et) && (rdtp_Goal_TIMELINES.SelectedDate.Value >= dt_st))
                ////    {
                ////        dr["Timelines"] = rdtp_Goal_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                ////    }

                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////    //dr["Timelines"] = rdtp_Goal_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                ////}//item["KRATargetAchieved"] = rnt_Kratargetachieved.Text;
            }
            dr.EndEdit();

            dt_KRA.DefaultView.Sort = "A ASC";
            dt_KRA = dt_KRA.DefaultView.ToTable();

            Session["dtKRA"] = dt_KRA;
            //clearfields();
            RM_GS.SelectedIndex = 1;
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
            btn_Save_Details.Visible = true;

            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }

            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {


                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";
                }

            }
            else
            {
                hd_Field.Value = "1";

            }
            //btn_assignGoal.Visible = false;
            //btn_assignKRA.Visible = true;

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_UpdateAssignkra_Click(object sender, EventArgs e)
    {
        try
        {
            //int totaltemp = 0;
            //totaltemp = Convert.ToInt32(RNT_KraWeightage.Text);


            dt_KRA = (DataTable)Session["dtKRA"];

            dt_KRA.PrimaryKey = new DataColumn[] { dt_KRA.Columns["SNO"] };

            DataRow item;
            DataRow item1 = dt_KRA.Rows.Find(lbl_kra.Text);
            int RowIndex = 0;
            for (int index = 0; index < dt_KRA.Rows.Count; index++)
            {
                if (dt_KRA.Rows[index].Equals(item1))
                {
                    RowIndex = index;
                }
                //else
                //{

                //    totaltemp = Convert.ToInt32(dt_KRA.Rows[index]["Weightage"]) + totaltemp;
                //}
            }
            //if (totaltemp > 100)
            //{
            //    BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
            //    return;
            //}
            item = dt_KRA.Rows[RowIndex];
            item.BeginEdit();
            if (item["SNO"].ToString() == Convert.ToString(lbl_kra.Text))
            {
                item["ROLEKRA_ID"] = Convert.ToString(RCB_KRA.SelectedItem.Value);
                item["NAME"] = Convert.ToString(RCB_KRA.SelectedItem.Text.Replace("'", "''"));
                item["DESC"] = Convert.ToString(txt_KraDescription.Text.Replace("'", "''"));
                //item["Measure"] = Convert.ToString(txt_KraMeasure.Text.Replace("'", "''"));
                //item["Weightage"] = RNT_KraWeightage.Text;
                //item["Target"] = Convert.ToString(RNT_KraTarget.Text.Replace("'", "''"));
                //item["Timelines"] = rdtp_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                _obj_Pms_Appraisalcycle.MODE = 2;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_TIMELINES.SelectedDate.Value <= dt_et) && (rdtp_TIMELINES.SelectedDate.Value >= dt_st))
                ////    {
                ////        item["Timelines"] = rdtp_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                ////    }
                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////}

                //item["KRATargetAchieved"] = rnt_Kratargetachieved.Text;
            }
            item.EndEdit();
            item.AcceptChanges();

            dt_KRA.DefaultView.Sort = "A ASC";
            dt_KRA = dt_KRA.DefaultView.ToTable();

            Session["dtKRA"] = dt_KRA;
            //clearfields();
            RM_GS.SelectedIndex = 1;
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
            btn_Save_Details.Visible = true;




            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }


            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {


                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";

                }

            }
            else
            {
                hd_Field.Value = "1";

            }
            //btn_assignGoal.Visible = true;
            //btn_assignKRA.Visible = false;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void btn_IDP_Update_Click(object sender, EventArgs e)
    {
        try
        {
            //int totaltemp = 0;
            //totaltemp = Convert.ToInt32(RNT_KraWeightage.Text);

            dt_KRA = (DataTable)Session["dtKRA"];
            dt_KRA.PrimaryKey = new DataColumn[] { dt_KRA.Columns["SNO"] };

            DataRow item;
            DataRow item1 = dt_KRA.Rows.Find(lbl_idp.Text);
            int RowIndex = 0;
            for (int index = 0; index < dt_KRA.Rows.Count; index++)
            {
                if (dt_KRA.Rows[index].Equals(item1))
                {
                    RowIndex = index;
                }
                //else
                //{

                //    totaltemp = Convert.ToInt32(dt_KRA.Rows[index]["Weightage"]) + totaltemp;
                //}
            }
            //if (totaltemp > 100)
            //{
            //    BLL.ShowMessage(this, "Please Manage your Weightage, its crossing Maximum Level");
            //    return;
            //}
            item = dt_KRA.Rows[RowIndex];
            item.BeginEdit();
            if (item["SNO"].ToString() == Convert.ToString(lbl_idp.Text))
            {
                item["ROLEKRA_ID"] = Convert.ToString(rcmb_idp.SelectedItem.Value);
                item["NAME"] = Convert.ToString(rcmb_idp.SelectedItem.Text.Replace("'", "''"));
                item["DESC"] = Convert.ToString(txt_idpdesc.Text.Replace("'", "''"));
                //item["Measure"] = Convert.ToString(txt_idpmeasure.Text.Replace("'", "''"));
                //item["Weightage"] = rnt_idp_wt.Text;
                //item["Target"] = Convert.ToString(rtxt_idptarget.Text.Replace("'", "''"));
                //item["Timelines"] = rdtp_TIMELINES.SelectedDate.Value.Date.ToShortDateString();
                int appid = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = appid;
                _obj_Pms_Appraisalcycle.MODE = 2;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_daterange = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                ////if (dt_daterange.Rows.Count != 0)
                ////{
                ////    DateTime dt_st = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_STARTDATE"]);
                ////    DateTime dt_et = Convert.ToDateTime(dt_daterange.Rows[0]["APPCYCLE_ENDDATE"]);

                ////    if ((rdtp_idpdate.SelectedDate.Value <= dt_et) && (rdtp_idpdate.SelectedDate.Value >= dt_st))
                ////    {
                ////        item["Timelines"] = rdtp_idpdate.SelectedDate.Value.Date.ToShortDateString();
                ////    }
                ////    else
                ////    {
                ////        BLL.ShowMessage(this, "Date should validate with Appraisal Cycle Date");
                ////        return;
                ////    }
                ////}

                //item["KRATargetAchieved"] = rnt_Kratargetachieved.Text;
            }
            item.EndEdit();
            item.AcceptChanges();

            dt_KRA.DefaultView.Sort = "A ASC";
            dt_KRA = dt_KRA.DefaultView.ToTable();

            Session["dtKRA"] = dt_KRA;

            //clearfields();
            RM_GS.SelectedIndex = 1;
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
            btn_Save_Details.Visible = true;




            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }


            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {


                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";

                }

            }
            else
            {
                hd_Field.Value = "1";

            }
            //btn_assignGoal.Visible = true;
            //btn_assignKRA.Visible = false;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    #endregion

    #region Cancel button Events

    protected void btn_Cancel_GoalSettingsDetails_Click(object sender, EventArgs e)
    {
        try
        {

            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }

            RM_GS.SelectedIndex = 1;
            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {

                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";
                }


            }
            else
            {
                hd_Field.Value = "1";

            }

            btn_assignGoal.Visible = true;
            btn_assignKRA.Visible = true;
            btn_assignIDP.Visible = true;
            if (Convert.ToString(ViewState["Edit"]) == "true")
            {
                //btn_UpdateAssignkra.Visible = false;
                //btn_UpdateGoalSettingsDetails.Visible = false;
                //btn_IDP_Update.Visible = false;
                btn_assignGoal.Visible = false;
                btn_assignKRA.Visible = false;
                btn_assignIDP.Visible = false;
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = false;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_CancelKRA_Click(object sender, EventArgs e)
    {
        try
        {

            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }

            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {


                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";
                }
            }
            else
            {
                hd_Field.Value = "1";
            }
            btn_assignGoal.Visible = true;
            btn_assignKRA.Visible = true;
            btn_assignIDP.Visible = true;
            RM_GS.SelectedIndex = 1;
            if (Convert.ToString(ViewState["Edit"]) == "true")
            {
                //btn_UpdateAssignkra.Visible = false;
                //btn_UpdateGoalSettingsDetails.Visible = false;
                //btn_IDP_Update.Visible = false;
                btn_assignGoal.Visible = false;
                btn_assignKRA.Visible = false;
                btn_assignIDP.Visible = false;
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = false;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_IDP_Click(object sender, EventArgs e)
    {
        try
        {

            _obj_GSdetails = new PMS_GoalSettings_Details();
            _obj_GSdetails.GS_DETAILS_MODE = 12;
            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
            DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
            if (dtgsdtlid.Rows.Count != 0)
            {

                btn_Update_Details.Visible = true;
                btn_Save_Details.Visible = false;
            }
            else
            {
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = true;
            }

            string s = lbl_gs_dum_id.Text;
            if (s != "")
            {
                if (dtgsdtlid.Rows.Count != 0)
                {


                    hd_Field.Value = "2";
                }
                else
                {
                    hd_Field.Value = "1";
                }
            }
            else
            {
                hd_Field.Value = "1";
            }
            btn_assignGoal.Visible = true;
            btn_assignKRA.Visible = true;
            btn_assignIDP.Visible = true;
            RM_GS.SelectedIndex = 1;
            if (Convert.ToString(ViewState["Edit"]) == "true")
            {
                //btn_UpdateAssignkra.Visible = false;
                //btn_UpdateGoalSettingsDetails.Visible = false;
                //btn_IDP_Update.Visible = false;
                btn_assignGoal.Visible = false;
                btn_assignKRA.Visible = false;
                btn_assignIDP.Visible = false;
                btn_Update_Details.Visible = false;
                btn_Save_Details.Visible = false;
                //btn_IDP_Update.Visible = false;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region ItemDataBound

    protected void Rg_KRAGOAL_ItemDataBound(object sender, GridItemEventArgs e)
    {

        try
        {
            //COMMENTED ON 11.01.2012
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem dataItem = (GridDataItem)e.Item;
            //    sum = sum + Convert.ToDouble((dataItem["Template1"].FindControl("txt_Weightage") as TextBox).Text);
            //    Session["Test"] = sum;
            //    //if (dataItem["A"].Text == "KRA")
            //    //{
            //    //    dataItem.BackColor = System.Drawing.Color.Black;
            //    //    dataItem.ForeColor = System.Drawing.Color.White;
            //    //    dataItem.ToolTip = "KRA";
            //    //}
            //    //else
            //    //{
            //    //    dataItem.BackColor = System.Drawing.Color.White;
            //    //    dataItem.ForeColor = System.Drawing.Color.Black;
            //    //    dataItem.ToolTip = "Goal";
            //    //}
            //}

            //foreach (GridDataItem dataItem in Rg_KRAGOAL.MasterTableView.Items)
            //{
            //    if (dataItem["A"].Text == "K")
            //    {
            //        dataItem.BackColor = System.Drawing.Color.Black;
            //        dataItem.ForeColor = System.Drawing.Color.White;
            //        dataItem.ToolTip = "KRA";
            //    }
            //    else
            //    {
            //        dataItem.BackColor = System.Drawing.Color.White;
            //        dataItem.ForeColor = System.Drawing.Color.Black;
            //        dataItem.ToolTip = "KRA";
            //    }
            //}

            //COMMENTED ON 11.01.2012
            //else if (e.Item is GridFooterItem)
            //{
            //    GridFooterItem footer = (GridFooterItem)e.Item;
            //    //footer["Measure"].Controls.Add(new LiteralControl("<span style='color: Black; font-weight: bold;'>Total Weightage for this employee is:</span> "));
            //    if (Session["Test"]!=null)
            //    {
            //    (footer["Template1"].FindControl("TextBox2") as RadNumericTextBox).Value = Double.Parse(Session["Test"].ToString());
            //    }
            //}
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region Main Methods

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //LOADBUID();
            //LoadEmployees();
            //LoadRolename();
            //createcontrols();
            //LoadProject();
            //LoadAppraisalCycle();

            //Commented on 11.04.2012
            //_obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 17;
            //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.EMPID = Convert.ToInt32(Session["EMP_ID"]);
            //Rg_Goal.DataSource = Pms_Bll.get_GS(_obj_GS);
            LoadGrid();
            Rg_Goal.DataBind();
            RM_GS.SelectedIndex = 0;
            rcmb_Position.Items.Clear();
            rcmb_Position.Items.Insert(0,new RadComboBoxItem("",""));

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Update_Details_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            bool status1 = false;
            bool status2 = false;
            Label lbl_KRANAME = new Label();
            //TextBox txt_weigh = new TextBox();
            Label lbl_GName = new Label();
            //TextBox Txt_Gweightage = new TextBox();
            Label lbl_IDPName = new Label();
            //TextBox txt_idp_wt = new TextBox();
            //_obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 12;
            //DataTable Dt_detail = Pms_Bll.get_GS(_obj_GS);


            int GSID1 = Convert.ToInt32(lbl_gs_dum_id.Text);
            DataTable dt_KRA = new DataTable();
            //To Update the Status in Goal Setting.
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            _obj_GS.GS_ID = Convert.ToInt32(GSID1);
            _obj_GS.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedItem.Value);
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedValue);
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_GS.GS_STATUS = 0;
            _obj_GS.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
            _obj_GS.LASTMDFDATE = DateTime.Now;
            _obj_GS.GS_MODE = 32;
            status = Pms_Bll.set_GS(_obj_GS);   //To update PMS_GOAL_SETTING
            //double KS = Double.Parse(Session["Test"].ToString());
            //if ((KS < 100) || (KS > 100))
            //{
            //    BLL.ShowMessage(this, "Please check your weightages!!");
            //    return;
            //}
            //else
            //{
            for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
            {
                if (Rg_KRAGOAL.Items[i]["A"].Text == "KRA") //To insert/update KRA
                {
                    lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    Label lbl_KRA_ID = Rg_KRAGOAL.Items[i].FindControl("lbl_KRA_ID") as Label;
                    Label lbl_KRAdesc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                    //Label lbl_KRAmeasure = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                    _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                    _obj_Pms_goalkradetails.MODE = 10;
                    _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(GSID1);  //GoalSetting_ID
                    _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["org_id"]); //Org_ID
                    _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_KRA_ID.Text);   //Holds KRA_ID
                    _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //Holds KRA_OBJ_ID

                    DataTable dtgs_kra_id = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);     //To check if record already exists

                    //where i am getting gs_kra_id to update based on that

                    if (dtgs_kra_id.Rows.Count != 0)    //If record already exits, then Update
                    {
                        _obj_Pms_goalkradetails.MODE = 5;
                        if (dtgs_kra_id.Rows.Count != 0)
                        {
                            _obj_Pms_goalkradetails.GS_KRA_ID = Convert.ToInt32(dtgs_kra_id.Rows[0]["GS_KRA_ID"]);  //Identity value of PMS_GOALSETTING_KRA_DETAIL
                        }
                        _obj_Pms_goalkradetails.GS_KRA_GSDTL_ID = GSID1;    //GoalSetting ID
                        //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_KRA_ID.Text);   //KRA_ID
                        _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store KRA_OBJ_ID
                        _obj_Pms_goalkradetails.GS_KRA_NAME = Convert.ToString(lbl_KRANAME.Text.Replace("'", "''"));    //KRA_OBJ Name
                        _obj_Pms_goalkradetails.GS_KRA_DESCRIPTION = Convert.ToString(lbl_KRAdesc.Text.Replace("'", "''")); //KRA Description
                        _obj_Pms_goalkradetails.GS_KRA_DATE = DateTime.Now;
                        _obj_Pms_goalkradetails.LASTMDFDATE = DateTime.Now;
                        _obj_Pms_goalkradetails.LASTMDFBY = Convert.ToInt32(Session["user_id"]);

                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(lbl_KRAmeasure.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;

                        //txt_weigh = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = Convert.ToInt32(txt_weigh.Text);
                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = "";
                        //else
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Trim().Replace("'", "''"));

                        ////_obj_Pms_goalkradetails.GS_KRA_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);    //To update
                    }

                    else
                    {
                        /* To insert new record into PMS_GOALSETTING_KRA_DETAIL */
                        _obj_Pms_goalkradetails.MODE = 4;
                        _obj_Pms_goalkradetails.GS_KRA_GS_ID = GSID1;   //GoalSetting ID
                        lbl_KRA_ID = Rg_KRAGOAL.Items[i].FindControl("lbl_KRA_ID") as Label;    //KRA_ID
                        lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;  //KRA_OBJ_NAME
                        Label lbl_kra_desc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;   //KRA_Description
                        //Label lbl_kra_meas = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        _obj_Pms_goalkradetails.GS_KRA_GSDTL_ID = GSID1;    //GoalSetting ID
                        //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_KRA_ID.Text);   //KRA_ID
                        _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store KRA_OBJ_ID
                        _obj_Pms_goalkradetails.GS_KRA_NAME = Convert.ToString(lbl_KRANAME.Text.Replace("'", "''"));    //KRA_OBJ_NAME
                        _obj_Pms_goalkradetails.GS_KRA_DESCRIPTION = Convert.ToString(lbl_kra_desc.Text.Replace("'", "''"));    //KRA Description
                        _obj_Pms_goalkradetails.GS_KRA_DATE = DateTime.Now;
                        _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_goalkradetails.CREATEDDATE = DateTime.Now;
                        _obj_Pms_goalkradetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = string.Empty;

                        //_obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(lbl_kra_meas.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;

                        //txt_weigh = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = Convert.ToInt32(txt_weigh.Text);

                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = "";
                        //else
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_Pms_goalkradetails.GS_KRA_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);    //To insert new record into PMS_GOALSETTING_KRA_DETAIL

                    }

                }
                //else if (Rg_KRAGOAL.Items[i]["A"].Text == "IDP")
                else if (Rg_KRAGOAL.Items[i]["A"].Text == "Value")
                {
                    lbl_IDPName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    Label lbl_KRAdesc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                    //Label lbl_KRAmeasure = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                    _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                    _obj_Pms_goalIDPdetails.MODE = 10;
                    _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(GSID1);
                    _obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                    DataTable dtgs_IDP_id = Pms_Bll.get_GsIDP(_obj_Pms_goalIDPdetails);

                    //where i am getting gs_kra_id to update based on that

                    if (dtgs_IDP_id.Rows.Count != 0)
                    {


                        _obj_Pms_goalIDPdetails.MODE = 5;
                        if (dtgs_IDP_id.Rows.Count != 0)
                        {
                            _obj_Pms_goalIDPdetails.GS_IDP_ID = Convert.ToInt32(dtgs_IDP_id.Rows[0]["GS_IDP_ID"]);
                        }
                        _obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID = GSID1;
                        _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalIDPdetails.GS_IDP_NAME = Convert.ToString(lbl_IDPName.Text.Replace("'", "''"));
                        _obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION = Convert.ToString(lbl_KRAdesc.Text.Replace("'", "''"));
                        _obj_Pms_goalIDPdetails.GS_IDP_DATE = DateTime.Now;
                        _obj_Pms_goalIDPdetails.LASTMDFDATE = DateTime.Now;
                        _obj_Pms_goalIDPdetails.LASTMDFBY = Convert.ToInt32(Session["user_id"]);

                        //_obj_Pms_goalIDPdetails.GS_IDP_MEASURE = Convert.ToString(lbl_KRAmeasure.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;

                        //txt_idp_wt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE = Convert.ToInt32(txt_idp_wt.Text);
                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = "";
                        //else
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);
                    }

                    else
                    {
                        _obj_Pms_goalIDPdetails.MODE = 4;
                        _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = GSID1;
                        lbl_IDPName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                        Label lbl_kra_desc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                        //Label lbl_kra_meas = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        _obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID = GSID1;
                        _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalIDPdetails.GS_IDP_NAME = Convert.ToString(lbl_IDPName.Text.Replace("'", "''"));
                        _obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION = Convert.ToString(lbl_kra_desc.Text.Replace("'", "''"));
                        _obj_Pms_goalIDPdetails.GS_IDP_DATE = DateTime.Now;
                        //_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        _obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_goalIDPdetails.CREATEDDATE = DateTime.Now;
                        _obj_Pms_goalIDPdetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED = string.Empty;

                        //_obj_Pms_goalIDPdetails.GS_IDP_MEASURE = Convert.ToString(lbl_kra_meas.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;
                        //txt_idp_wt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE = Convert.ToInt32(txt_idp_wt.Text);
                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = "";
                        //else
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);

                    }

                }
                else
                {
                    lbl_GName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                    Label lbl_GDesc1 = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                    //Label lbl_measr1 = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                    _obj_GSdetails = new PMS_GoalSettings_Details();
                    _obj_GSdetails.GS_DETAILS_MODE = 11;
                    _obj_GSdetails.GSDTL_GS_ID = GSID1;
                    _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                    _obj_GSdetails.GSDTL_NAME = Convert.ToString(lbl_GName.Text);
                    //_obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(lbl_GDesc1.Text);
                    _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtgsdtl_id = Pms_Bll.get_GSdetails(_obj_GSdetails);

                    if (dtgsdtl_id.Rows.Count != 0)
                    {
                        _obj_GSdetails.GS_DETAILS_MODE = 4;
                        _obj_GSdetails.GSDTL_GS_ID = GSID1;
                        if (dtgsdtl_id.Rows.Count != 0)
                        {
                            _obj_GSdetails.GSDTL_ID = Convert.ToInt32(dtgsdtl_id.Rows[0]["GSDTL_ID"]);
                        }

                        //Txt_Gweightage = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store Goal/Competency ID
                        _obj_GSdetails.GSDTL_NAME = Convert.ToString(lbl_GName.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(lbl_GDesc1.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DATE = DateTime.Now;
                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                        _obj_GSdetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GSdetails.CREATEDDATE = DateTime.Now;

                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(lbl_measr1.Text.Replace("'", "''"));
                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_GSdetails.GSDTL_WEIGHTAGE = Convert.ToInt32(Txt_Gweightage.Text);

                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_GSdetails.GSDTL_TARGET = "";
                        //else
                        //    _obj_GSdetails.GSDTL_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_GSdetails.GSDTL_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status1 = Pms_Bll.set_GSdetails(_obj_GSdetails);

                    }


                    else
                    {
                        _obj_GSdetails = new PMS_GoalSettings_Details();
                        _obj_GSdetails.GS_DETAILS_MODE = 3;
                        _obj_GSdetails.GSDTL_GS_ID = GSID1;

                        lbl_GName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                        Label lbl_Gdesc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                        //Label lbl_gmeas = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        //Txt_Gweightage = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store Goal/Competency ID
                        _obj_GSdetails.GSDTL_NAME = Convert.ToString(lbl_GName.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(lbl_Gdesc.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DATE = DateTime.Now;
                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["org_id"]);
                        _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                        _obj_GSdetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GSdetails.CREATEDDATE = DateTime.Now;
                        _obj_GSdetails.GSDTL_TARGET_ACHEIVED = string.Empty;

                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(lbl_gmeas.Text.Replace("'", "''"));
                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_GSdetails.GSDTL_WEIGHTAGE = Convert.ToInt32(Txt_Gweightage.Text);
                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_GSdetails.GSDTL_TARGET = "";
                        //else
                        //    _obj_GSdetails.GSDTL_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_GSdetails.GSDTL_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);

                        status1 = Pms_Bll.set_GSdetails(_obj_GSdetails);
                    }
                }
            }

            //}

            if ((status == true) || (status1 == true) || (status2 == true))
            {
                Pms_Bll.ShowMessage(this, "Goal Settings Completed Successfully");
            }
            //if (lbl_RMID.Text != string.Empty && lbl_RMID.Text != string.Empty && Rg_KRAGOAL.Items.Count > 0)
            //{
            //    if (lbl_Gs_Status.Text == "2")
            //        sendMail();
            //}
            //else
            //{
            //    Pms_Bll.ShowMessage(this, " weightages without 100% cannot be saved");
            //    return;
            //}
            gs_dum_id.Visible = false;
            //_obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 17;
            //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_GS.EMPID = Convert.ToInt32(Session["EMP_ID"]);
            //Rg_Goal.DataSource = Pms_Bll.get_GS(_obj_GS);
            LoadGrid();
            Rg_Goal.DataBind();
            RM_GS.SelectedIndex = 0;

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Save_Details_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            bool status1 = false;
            bool status2 = false;
            Label lbl_KRANAME = new Label();
            //TextBox txt_weigh = new TextBox();
            Label lbl_GName = new Label();
            //TextBox Txt_Gweightage = new TextBox();
            Label lbl_IDPName = new Label();
            //TextBox txt_Idp_wt = new TextBox();
            _obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 12;
            //DataTable Dt_detail = Pms_Bll.get_GS(_obj_GS);
            _obj_GS.GS_MODE = 21;
            _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value);
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable Dt_detail = Pms_Bll.get_GS(_obj_GS);

            int GSID = Convert.ToInt32(Dt_detail.Rows[0]["Temp"]);

            DataTable dt_KRA = new DataTable();
            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
            _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
            _obj_Pms_goalkradetails.MODE = 4;
            _obj_Pms_goalkradetails.GS_KRA_GS_ID = GSID;
            if (Rg_KRAGOAL.Items.Count > 0)
            {

                //double KS = Double.Parse(((Convert.ToString(Session["Test"]) == "") ? "0.0" : Convert.ToString(Session["Test"])));
                //if ((KS < 100) || (KS > 100))
                //{
                //    BLL.ShowMessage(this, "Please check your weightages!!");
                //    return;
                //}
                //else
                //{
                for (int i = 0; i < Rg_KRAGOAL.Items.Count; i++)
                {
                    if (Rg_KRAGOAL.Items[i]["A"].Text == "KRA")
                    {

                        lbl_KRANAME = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                        Label lbl_kra_desc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                        //Label lbl_kra_measr = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        Label lbl_KRA_ID = Rg_KRAGOAL.Items[i].FindControl("lbl_KRA_ID") as Label;
                        _obj_Pms_goalkradetails.GS_KRA_GSDTL_ID = GSID;
                        //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);
                        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(lbl_KRA_ID.Text);
                        _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store KRA_OBJ_ID
                        _obj_Pms_goalkradetails.GS_KRA_NAME = Convert.ToString(lbl_KRANAME.Text.Replace("'", "''"));        //To store KRA_OBJ_Name
                        _obj_Pms_goalkradetails.GS_KRA_DESCRIPTION = Convert.ToString(lbl_kra_desc.Text.Replace("'", "''"));    //To store KRA desc
                        _obj_Pms_goalkradetails.GS_KRA_DATE = DateTime.Now;
                        _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["org_id"]);

                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(lbl_kra_measr.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;
                        //txt_weigh = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = Convert.ToInt32(txt_weigh.Text);
                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = "";
                        //else
                        //    _obj_Pms_goalkradetails.GS_KRA_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));

                        _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        ////_obj_Pms_goalkradetails.GS_KRA_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);
                        DateTime dt = _obj_Pms_goalkradetails.GS_KRA_TIMELINES;
                        _obj_Pms_goalkradetails.CREATEDDATE = DateTime.Now;
                        _obj_Pms_goalkradetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_goalkradetails.GS_KRA_TARGET_ACHEIVED = string.Empty;
                        status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);

                    }
                    //else if (Rg_KRAGOAL.Items[i]["A"].Text == "IDP")
                    else if (Rg_KRAGOAL.Items[i]["A"].Text == "Value")
                    {
                        _obj_Pms_goalIDPdetails.MODE = 4;
                        lbl_IDPName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                        Label lbl_idp_desc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                        //Label lbl_idp_measr = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        _obj_Pms_goalIDPdetails.GS_IDP_GSDTL_ID = GSID;
                        _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store IDP/Value ID
                        _obj_Pms_goalIDPdetails.GS_IDP_NAME = Convert.ToString(lbl_IDPName.Text.Replace("'", "''"));        //To store IDP/Value Name

                        _obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION = Convert.ToString(lbl_idp_desc.Text.Replace("'", "''"));    //To store IDP/Value description
                        _obj_Pms_goalIDPdetails.GS_IDP_DATE = DateTime.Now;
                        _obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["org_id"]);
                        //_obj_Pms_goalIDPdetails.GS_IDP_MEASURE = Convert.ToString(lbl_idp_measr.Text.Replace("'", "''"));
                        //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = 0;

                        //txt_Idp_wt = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE = Convert.ToInt32(txt_Idp_wt.Text);

                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = "";
                        //else
                        //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        //_obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        ////_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);
                        _obj_Pms_goalIDPdetails.CREATEDDATE = DateTime.Now;
                        _obj_Pms_goalIDPdetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_Pms_goalIDPdetails.GS_IDP_TARGET_ACHEIVED = string.Empty;
                        status = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);

                    }

                    else
                    {

                        _obj_GSdetails = new PMS_GoalSettings_Details();
                        _obj_GSdetails.GS_DETAILS_MODE = 3;
                        _obj_GSdetails.GSDTL_GS_ID = GSID;

                        lbl_GName = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_NAME") as Label;
                        Label lbl_Gdesc = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_Desc") as Label;
                        _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[i]["ROLEKRA_ID"].Text);    //To store Goal/Competency ID
                        _obj_GSdetails.GSDTL_NAME = Convert.ToString(lbl_GName.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(lbl_Gdesc.Text.Replace("'", "''"));
                        _obj_GSdetails.GSDTL_DATE = DateTime.Now;
                        _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["org_id"]);
                        _obj_GSdetails.LASTMDFDATE = DateTime.Now;
                        _obj_GSdetails.CREATEDBY = Convert.ToInt32(Session["user_id"]);
                        _obj_GSdetails.CREATEDDATE = DateTime.Now;
                        _obj_GSdetails.GSDTL_TARGET_ACHEIVED = string.Empty;

                        //Label lbl_gmeas = (Label)Rg_KRAGOAL.Items[i].FindControl("lbl_MEasure") as Label;
                        //Txt_Gweightage = (TextBox)Rg_KRAGOAL.Items[i].FindControl("txt_Weightage") as TextBox;
                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(lbl_gmeas.Text.Replace("'", "''"));
                        //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[i]["Measure"].Text);
                        //_obj_GSdetails.GSDTL_WEIGHTAGE = Convert.ToInt32(Txt_Gweightage.Text);

                        //if (Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text) == "&nbsp;")
                        //    _obj_GSdetails.GSDTL_TARGET = "";
                        //else
                        //    _obj_GSdetails.GSDTL_TARGET = Convert.ToString(Rg_KRAGOAL.Items[i]["Target"].Text.Replace("'", "''"));
                        ////_obj_GSdetails.GSDTL_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[i]["Timelines"].Text);
                        status1 = Pms_Bll.set_GSdetails(_obj_GSdetails);
                    }
                }

                //}
            }
            else
            {
                status = false;
                status1 = false;
                status2 = false;
            }



            if ((status == true) || (status1 == true) || (status2 == true))
            {
                Pms_Bll.ShowMessage(this, "Goal Settings Completed Successfully");
            }
            //else
            //{
            //    Pms_Bll.ShowMessage(this, " weightages without 100% cannot be saved");
            //    return;
            //}
            //PMS_NOTIFICATION _obj_Pms_Send_Notification;
            //PMS_LOGININFO _obj_Pms_LoginInfo;//yyy
            //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
            //_obj_Pms_LoginInfo = new PMS_LOGININFO();

            //_obj_Pms_LoginInfo.EMPID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);

            //DataTable dtbuid1 = Pms_Bll.get_LoginInfo(_obj_Pms_EmpSetup);
            //if (lbl_RMID.Text != string.Empty && lbl_RMID.Text != string.Empty && Rg_KRAGOAL.Items.Count > 0)
            //{
            //    //_obj_Pms_Send_Notification = new PMS_NOTIFICATION();
            //    //_obj_Pms_Send_Notification.EMPID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            //    //_obj_Pms_Send_Notification.RMID = Convert.ToInt32(lbl_RMID.Text);
            //    //_obj_Pms_Send_Notification.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            //    //_obj_Pms_Send_Notification.APPRAISAL_CYCLE = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
            //    ////bool status3 = Pms_Bll.Send_Notification2(_obj_Pms_Send_Notification);//aaa
            //    //Pms_Bll.ShowMessage(this, "NOTIFICATION SEND");
            //    sendMail();

            //}
            gs_dum_id.Visible = false;

            //_obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 17;
            //_obj_GS.EMPID = Convert.ToInt32(Session["EMP_ID"]);
            //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //Rg_Goal.DataSource = Pms_Bll.get_GS(_obj_GS);
            //Rg_Goal.DataBind();
            LoadGrid();
            Rg_Goal.DataBind();

            RM_GS.SelectedIndex = 0;

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Assign Goal, KRA

    protected void btn_assignGoal_Click(object sender, EventArgs e)
    {
        try
        {
            RM_GS.SelectedIndex = 3;
            ClearGoalFields();
            btn_Submit.Visible = true;
            //btn_UpdateGoalSettingsDetails.Visible = false;
            //txt_GoalName.Enabled = true;
            txt_GoalDescription.Enabled = false;
            rcmb_CMP.Enabled = true;
            ////rdtp_Goal_TIMELINES.SelectedDate = null;

            //To load Competencies
            //PMS_CMP objCmp = new PMS_CMP();
            //objCmp.CMP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //objCmp.CMP_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            //objCmp.OPERATION = operation.Select_New;
            //DataTable dtCmps = Pms_Bll.get_cmp(objCmp);


            //To load Goals/Competencies based on position
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
            _obj_Pms_RoleKra.PMS_Type = 2;  // 2 means Competency/Goal
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            DataTable dtCmps = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

            //To remove existing goals from DataTable
            if (dtCmps.Rows.Count != 0)
            {
                for (int index = 0; index < Rg_KRAGOAL.Items.Count; index++)
                {
                    for (int count = 0; count < dtCmps.Rows.Count; count++)
                    {
                        //if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "Goal" && Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToInt32(dtCmps.Rows[count]["CMP_ID"]))
                        if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "Competency" && Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToInt32(dtCmps.Rows[count]["CMP_ID"]))
                        {
                            dtCmps.Rows[count].Delete();
                            dtCmps.AcceptChanges();
                        }
                    }
                }
            }


            rcmb_CMP.Items.Clear();
            rcmb_CMP.Text = string.Empty;
            if (dtCmps.Rows.Count > 0)
            {
                rcmb_CMP.DataSource = dtCmps;
                rcmb_CMP.DataTextField = "CMP_NAME";
                rcmb_CMP.DataValueField = "CMP_ID";
                rcmb_CMP.DataBind();
                rcmb_CMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_assignKRA_Click1(object sender, EventArgs e)
    {
        try
        {
            RM_GS.SelectedIndex = 2;
            ClearKRAFields();
            RCB_KRA.Enabled = true;
            rcmb_KraObjective.Enabled = true;
            //_obj_Pms_Roles = new SPMS_ROLEKRA();
            //_obj_Pms_Roles.Mode = 6;
            ////_obj_Pms_Roles.ROLE_ID = Convert.ToInt32(RCB_RoleName.SelectedItem.Value);
            //_obj_Pms_Roles.ROLE_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
            //_obj_Pms_Roles.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            //_obj_Pms_Roles.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Pms_Roles.PMS_Type = 1;    //1 = KRA
            //DataTable dt = new DataTable();
            //dt = Pms_Bll.get_RoleKra(_obj_Pms_Roles);

            //To load Goals/Competencies based on position
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
            _obj_Pms_RoleKra.PMS_Type = 1;  // 1 means KRA's
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            DataTable dt = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

            ////To remove existing goals from DataTable
            //if (dt.Rows.Count != 0)
            //{
            //    for (int index = 0; index < Rg_KRAGOAL.Items.Count; index++)
            //    {
            //        for (int count = 0; count < dt.Rows.Count; count++)
            //        {
            //            if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "KRA" && Convert.ToString((Rg_KRAGOAL.Items[index].FindControl("lbl_KRA_ID") as Label).Text) == Convert.ToString(dt.Rows[count]["KRA_ID"]))
            //            {
            //                dt.Rows[count].Delete();
            //                dt.AcceptChanges();
            //            }
            //        }
            //    }
            //}





            if (dt.Rows.Count != 0)
            {
                //DataTable dt_kra = Session["dtKRA"] as DataTable;
                //for (int index = 0; index < dt_kra.Rows.Count; index++)
                //{
                //    for (int count = 0; count < dt.Rows.Count; count++)
                //    {
                //        if (Convert.ToString(dt_kra.Rows[index]["A"]) == "KRA" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt.Rows[count]["ROLE_KRA_ID"]))
                //        {
                //            dt.Rows[count].Delete();
                //            dt.AcceptChanges();
                //        }
                //    }
                //}

                RCB_KRA.Items.Clear();
                RCB_KRA.DataSource = dt;
                RCB_KRA.DataTextField = "KRA_NAME";
                RCB_KRA.DataValueField = "ROLE_KRA_ID";
                RCB_KRA.DataBind();
                RCB_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                RCB_KRA.SelectedIndex = 0;
                //Rg_KRA.Visible = false;
                //.Visible = false;
                //rdtp_Goal_TIMELINES.MinDate = DateTime.Now;
                btn_SaveAssignkra.Visible = true;
                //btn_UpdateAssignkra.Visible = false;
                //txt_KraDescription.Enabled = true;
                txt_KraDescription.Enabled = false;
                //txt_KraMeasure.Enabled = true;
                ////rdtp_TIMELINES.SelectedDate = null;
            }

            else
            {
                DataTable dt1 = new DataTable();
                RCB_KRA.DataSource = dt1;

                RCB_KRA.DataBind();
                RCB_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                RCB_KRA.SelectedIndex = 0;
                //Rg_KRA.Visible = false;
                //.Visible = false;
                //rdtp_Goal_TIMELINES.MinDate = DateTime.Now;
                btn_SaveAssignkra.Visible = true;
                //btn_UpdateAssignkra.Visible = false;
                RCB_KRA.Enabled = true;
                //txt_KraDescription.Enabled = true;
                txt_KraDescription.Enabled = false;
                //txt_KraMeasure.Enabled = true;
                ////rdtp_TIMELINES.SelectedDate = null;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_assignIDP_Click(object sender, EventArgs e)
    {
        try
        {
            RM_GS.SelectedIndex = 4;
            ClearIDPFields();
            rcmb_CMP.Enabled = true;
            //_obj_idp = new pms_IDPSCREEN();
            //_obj_idp.IDP_MODE = 8;
            ////_obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
            //_obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            //_obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_idp.IDP_BU_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            //DataTable dt = Pms_Bll.get_idp(_obj_idp);


            //To load Goals/Competencies based on position
            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
            _obj_Pms_RoleKra.PMS_Type = 3;  // 3 means Values/IDP's
            _obj_Pms_RoleKra.OPERATION = operation.Get;
            DataTable dt = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

            if (dt.Rows.Count != 0)
            {
                //for (int count = 0; count < dt.Rows.Count; count++)
                //{
                //    for (int index = 0; index < Rg_KRAGOAL.Items.Count; index++)
                //    {

                //        if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "IDP" && Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToString(dt.Rows[count]["IDP_ID"]))
                //        {
                //            dt.Rows[count].Delete();
                //            count++;
                //        }
                //    }
                //}
                for (int index = 0; index < Rg_KRAGOAL.Items.Count; index++)
                {
                    for (int count = 0; count < dt.Rows.Count; count++)
                    {
                        //if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "IDP" && Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToString(dt.Rows[count]["IDP_ID"]))
                        if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "Value" && Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToString(dt.Rows[count]["IDP_ID"]))
                        {
                            dt.Rows[count].Delete();
                            dt.AcceptChanges();
                        }
                    }
                }

                rcmb_idp.Items.Clear();
                rcmb_idp.DataSource = dt;
                rcmb_idp.DataTextField = "IDP_NAME";
                rcmb_idp.DataValueField = "IDP_ID";
                rcmb_idp.DataBind();
                rcmb_idp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_idp.SelectedIndex = 0;
                //Rg_KRA.Visible = false;
                //.Visible = false;
                //rdtp_Goal_TIMELINES.MinDate = DateTime.Now;
                btn_IDP_Save.Visible = true;
                //btn_IDP_Update.Visible = false;
                rcmb_idp.Enabled = true;
                //txt_idpdesc.Enabled = true;
                txt_idpdesc.Enabled = false;
                //txt_idpmeasure.Enabled = true;
                //rnt_idp_wt.Text = string.Empty;
                ////rdtp_idpdate.SelectedDate = null;
            }

            else
            {
                DataTable dt1 = new DataTable();
                rcmb_idp.DataSource = dt1;
                rcmb_idp.DataBind();
                rcmb_idp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_idp.SelectedIndex = 0;
                //Rg_KRA.Visible = false;
                //.Visible = false;
                //rdtp_Goal_TIMELINES.MinDate = DateTime.Now;
                btn_IDP_Save.Visible = true;
                //btn_IDP_Update.Visible = false;
                rcmb_idp.Enabled = true;
                //txt_idpdesc.Enabled = true;
                txt_idpdesc.Enabled = false;
                //txt_idpmeasure.Enabled = true;
                ////rdtp_idpdate.SelectedDate = null;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void Rg_KRAGOAL_CustomAggregate(object sender, GridCustomAggregateEventArgs e)
    {
        try
        {
            double sum = 0;
            //COOMENTED ON 11.01.2012
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem dataItem = (GridDataItem)e.Item;
            //    sum = sum + Convert.ToDouble((dataItem["Template1"].FindControl("txt_Weightage") as TextBox).Text);
            //    Session["Test"] = sum;
            //}


            //    if (dataItem["A"].Text == "K")
            //    {
            //        dataItem.BackColor = System.Drawing.Color.Black;
            //        dataItem.ForeColor = System.Drawing.Color.White;
            //        dataItem.ToolTip = "KRA";
            //    }
            //    else
            //    {
            //        dataItem.BackColor = System.Drawing.Color.White;
            //        dataItem.ForeColor = System.Drawing.Color.Black;
            //        dataItem.ToolTip = "KRA";
            //    }
            //}

            //foreach (GridDataItem dataItem in Rg_KRAGOAL.MasterTableView.Items)
            //{
            //    if (dataItem["A"].Text == "K")
            //    {
            //        dataItem.BackColor = System.Drawing.Color.Black;
            //        dataItem.ForeColor = System.Drawing.Color.White;
            //        dataItem.ToolTip = "KRA";
            //    }
            //    else
            //    {
            //        dataItem.BackColor = System.Drawing.Color.White;
            //        dataItem.ForeColor = System.Drawing.Color.Black;
            //        dataItem.ToolTip = "KRA";
            //    }
            //}

            //COOMENTED ON 11.01.2012
            //else if (e.Item is GridFooterItem)
            //{
            //    GridFooterItem footer = (GridFooterItem)e.Item;
            //    footer["Measure"].Controls.Add(new LiteralControl("<span style='color: Black; font-weight: bold;'>Total Weightage for this employee is:</span> "));
            //    (footer["Template1"].FindControl("TextBox2") as RadNumericTextBox).Value = Double.Parse(Session["Test"].ToString());
            //}

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_KRAGOAL_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {

            if (e.Item is GridDataItem)
            {
                if (Convert.ToString(e.CommandName) == "Edit_Rec")
                {
                    /* Disable all controls */
                    RCB_KRA.Enabled = false;
                    rcmb_KraObjective.Enabled = false;
                    txt_KraDescription.Enabled = false;

                    rcmb_CMP.Enabled = false;
                    txt_GoalDescription.Enabled = false;

                    rcmb_idp.Enabled = false;
                    txt_idpdesc.Enabled = false;
                    /* Disable all controls */

                    if (hd_Field.Value == "0")
                    {
                        hd_Field.Value = "2";
                    }



                    if (hd_Field.Value == "2")
                    {
                        GridDataItem dtItem = (GridDataItem)e.Item;
                        int index = dtItem.ItemIndex;
                        string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
                        if (a == "KRA")
                        {

                            Label lbl_descc = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lbl_measure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            //TextBox txtwweight = new TextBox();
                            //txtwweight = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;

                            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                            //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                            _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);    //KRA_OBJ_ID
                            _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32((Rg_KRAGOAL.Items[index].FindControl("lbl_KRA_ID") as Label).Text); //KRA_ID
                            _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
                            _obj_Pms_goalkradetails.MODE = 11;

                            _obj_Pms_goalkradetails.GS_KRA_DESCRIPTION = Convert.ToString(lbl_descc.Text);
                            //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                            //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(lbl_measure.Text);
                            //_obj_Pms_goalkradetails.GS_KRA_WEIGHTAGE = Convert.ToInt32(txtwweight.Text);
                            //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                            //    _obj_Pms_goalkradetails.GS_KRA_TARGET = "";
                            //else
                            //    _obj_Pms_goalkradetails.GS_KRA_TARGET = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                            //_obj_Pms_goalkradetails.GS_KRA_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
                            DataTable dt_KRAdet1 = new DataTable();
                            dt_KRAdet1 = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);
                            if (dt_KRAdet1.Rows.Count != 0)
                            {
                            }
                            else
                            {
                                hd_Field.Value = "1";
                            }

                        }
                        //else if (a == "IDP")
                        else if (a == "Value")
                        {

                            Label lbl_descc = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lbl_measure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            //TextBox txtwweight = new TextBox();
                            //txtwweight = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;

                            _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                            _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                            _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
                            _obj_Pms_goalIDPdetails.MODE = 11;

                            _obj_Pms_goalIDPdetails.GS_IDP_DESCRIPTION = Convert.ToString(lbl_descc.Text);
                            //_obj_Pms_goalkradetails.GS_KRA_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                            //_obj_Pms_goalIDPdetails.GS_IDP_MEASURE = Convert.ToString(lbl_measure.Text);
                            //_obj_Pms_goalIDPdetails.GS_IDP_WEIGHTAGE = Convert.ToInt32(txtwweight.Text);
                            //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                            //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = "";
                            //else
                            //    _obj_Pms_goalIDPdetails.GS_IDP_TARGET = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                            //_obj_Pms_goalIDPdetails.GS_IDP_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
                            DataTable dt_IDPdet1 = new DataTable();
                            dt_IDPdet1 = Pms_Bll.get_GsIDP(_obj_Pms_goalIDPdetails);
                            if (dt_IDPdet1.Rows.Count != 0)
                            {
                            }
                            else
                            {
                                hd_Field.Value = "1";
                            }
                        }
                        else
                        {

                            Label lblname = new Label();
                            lblname = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
                            Label lbldescee = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lblmeasure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            //TextBox txtwweigh = new TextBox();
                            //txtwweigh = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;

                            PMS_GoalSettings_Details _obj_GSdetails = new PMS_GoalSettings_Details();
                            _obj_GSdetails.GS_DETAILS_MODE = 13;
                            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                            _obj_GSdetails.GSDTL_NAME = Convert.ToString(lblname.Text);
                            _obj_GSdetails.GSDTL_DESCRIPTION = Convert.ToString(lbldescee.Text);
                            //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(lblmeasure.Text);
                            //_obj_GSdetails.GSDTL_MEASURE = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                            //_obj_GSdetails.GSDTL_WEIGHTAGE = Convert.ToInt32(txtwweigh.Text);
                            //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                            //    _obj_GSdetails.GSDTL_TARGET = "";
                            //else
                            //    _obj_GSdetails.GSDTL_TARGET = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                            //_obj_GSdetails.GSDTL_TIMELINES = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);

                            DataTable dtexistgoal = Pms_Bll.get_GSdetails(_obj_GSdetails);
                            if (dtexistgoal.Rows.Count != 0)
                            {
                            }
                            else
                            {
                                hd_Field.Value = "1";
                            }


                        }

                    }

                    //----------
                    if (hd_Field.Value == "1")//new edit i.e., with a normal datatable
                    {
                        GridDataItem dtItem = (GridDataItem)e.Item;
                        int index = dtItem.ItemIndex;
                        string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
                        if (a == "KRA")
                        {

                            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                            RM_GS.SelectedIndex = 2;


                            RCB_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            //TextBox txtwweight = new TextBox();
                            //txtwweight = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;
                            Label lbl_name = new Label();
                            lbl_name = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
                            Label lbl_descc = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lbl_measure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            lbl_kra.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);

                            _obj_Pms_Roles = new SPMS_ROLEKRA();
                            _obj_Pms_Roles.Mode = 6;
                            //_obj_Pms_Roles.ROLE_ID = Convert.ToInt32(RCB_RoleName.SelectedItem.Value);
                            _obj_Pms_Roles.ROLE_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
                            _obj_Pms_Roles.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_Roles.PMS_Type = 1;    //1 means KRA
                            DataTable dt = new DataTable();
                            dt = Pms_Bll.get_RoleKra(_obj_Pms_Roles);
                            RCB_KRA.Items.Clear();
                            RCB_KRA.Text = string.Empty;
                            rcmb_KraObjective.Items.Clear();
                            rcmb_KraObjective.Text = string.Empty;
                            if (dt.Rows.Count != 0)
                            {
                                RCB_KRA.Items.Clear();
                                RCB_KRA.DataSource = dt;
                                RCB_KRA.DataTextField = "KRA_NAME";
                                RCB_KRA.DataValueField = "ROLE_KRA_ID";
                                RCB_KRA.DataBind();

                                //RCB_KRA.SelectedIndex = RCB_KRA.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["KRA_ID"].Text));
                                RCB_KRA.SelectedIndex = RCB_KRA.Items.FindItemIndexByValue(Convert.ToString((Rg_KRAGOAL.Items[index].FindControl("lbl_KRA_ID") as Label).Text));
                                // rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EXPENSE_BUSINESSUNIT_ID"]));
                                txt_KraDescription.Text = Convert.ToString(lbl_descc.Text);


                                /* To load KRA_Objectives */
                                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                _obj_Pms_RoleKra.Mode = 10;
                                _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(RCB_KRA.SelectedValue);
                                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dtKraObjectives = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
                                //rcmb_KraObjective.Items.Clear();    //To clear items
                                //rcmb_KraObjective.Text = string.Empty;  //To clear selected item
                                if (dtKraObjectives.Rows.Count > 0)
                                {
                                    rcmb_KraObjective.DataSource = dtKraObjectives;
                                    rcmb_KraObjective.DataTextField = "KRA_OBJ_NAME";
                                    rcmb_KraObjective.DataValueField = "KRA_OBJ_ID";
                                    rcmb_KraObjective.DataBind();
                                    rcmb_KraObjective.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                                    //To select the KRA_Objective 
                                    rcmb_KraObjective.SelectedIndex = rcmb_KraObjective.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text));

                                }

                                //txt_KraMeasure.Text = Convert.ToString(lbl_measure.Text);
                                //txt_KraMeasure.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                                //RNT_KraWeightage.Text = Convert.ToString(txtwweight.Text);
                                //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                                //    RNT_KraTarget.Text = "";
                                //else
                                //    RNT_KraTarget.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                                //rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
                                //btn_UpdateAssignkra.Visible = true;
                                btn_SaveAssignkra.Visible = false;
                                btn_CancelKRA.Visible = true;


                                RCB_KRA.Enabled = false;
                                txt_KraDescription.Enabled = false;
                                //txt_KraMeasure.Enabled = false;
                                hd_Field.Value = "0";
                                if (Convert.ToString(ViewState["Edit"]) == "true")
                                {
                                    //btn_UpdateGoalSettingsDetails.Visible = false;
                                    //btn_UpdateAssignkra.Visible = false;
                                    //btn_IDP_Update.Visible = false;
                                }
                            }
                        }
                        //else if (a == "IDP")
                        else if (a == "Value")
                        {

                            _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                            RM_GS.SelectedIndex = 4;

                            //rcmb_idp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                            //TextBox txtwweight = new TextBox();
                            //txtwweight = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;
                            Label lbl_name = new Label();
                            lbl_name = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
                            Label lbl_descc = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lbl_measure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            lbl_idp.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);




                            //To load Goals/Competencies based on position
                            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                            _obj_Pms_RoleKra.PMS_Type = 3;  // 3 means Values/IDP's
                            _obj_Pms_RoleKra.OPERATION = operation.Get;
                            DataTable dt = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

                            //if (dt.Rows.Count != 0)
                            //{
                            //    rcmb_idp.Items.Clear();
                            //    rcmb_idp.DataSource = dt;
                            //    rcmb_idp.DataTextField = "IDP_NAME";
                            //    rcmb_idp.DataValueField = "IDP_ID";
                            //    rcmb_idp.DataBind();
                            //    rcmb_idp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                            //    rcmb_idp.SelectedIndex = rcmb_idp.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text));
                            //    txt_idpdesc.Text = Convert.ToString(lbl_descc.Text);
                            //}




                            //_obj_idp = new pms_IDPSCREEN();
                            //_obj_idp.IDP_MODE = 9;
                            //_obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
                            //_obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                            //_obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            //DataTable dt = Pms_Bll.get_idp(_obj_idp);
                            if (dt.Rows.Count != 0)
                            {
                                rcmb_idp.Items.Clear();
                                rcmb_idp.DataSource = dt;
                                rcmb_idp.DataTextField = "IDP_NAME";
                                rcmb_idp.DataValueField = "IDP_ID";
                                rcmb_idp.DataBind();

                                rcmb_idp.SelectedIndex = rcmb_idp.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text));
                                // rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EXPENSE_BUSINESSUNIT_ID"]));
                                txt_idpdesc.Text = Convert.ToString(lbl_descc.Text);
                                //txt_idpmeasure.Text = Convert.ToString(lbl_measure.Text);
                                //txt_KraMeasure.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                                //rnt_idp_wt.Text = Convert.ToString(txtwweight.Text);
                                //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                                //    rtxt_idptarget.Text = "";
                                //else
                                //    rtxt_idptarget.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                                ////rdtp_idpdate.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
                                //btn_IDP_Update.Visible = true;
                                btn_IDP_Save.Visible = false;
                                btn_Cancel_IDP.Visible = true;


                                //rcmb_idp.Enabled = false;
                                txt_idpdesc.Enabled = false;
                                //txt_KraMeasure.Enabled = false;
                                hd_Field.Value = "0";
                                if (Convert.ToString(ViewState["Edit"]) == "true")
                                {
                                    //btn_UpdateGoalSettingsDetails.Visible = false;
                                    //btn_UpdateAssignkra.Visible = false;
                                    //btn_IDP_Update.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            Label lblname = new Label();
                            //TextBox txtwweigh = new TextBox();
                            lblname = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
                            Label lbldescee = Rg_KRAGOAL.Items[index].FindControl("lbl_Desc") as Label;
                            //Label lblmeasure = Rg_KRAGOAL.Items[index].FindControl("lbl_MEasure") as Label;
                            lbl_GSID.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);
                            //txtwweigh = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;
                            //txt_GoalName.Text = Convert.ToString(lblname.Text);
                            txt_GoalDescription.Text = Convert.ToString(lbldescee.Text);
                            //txt_Measure.Text = Convert.ToString(lblmeasure.Text);
                            //txt_Measure.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
                            //RNT_Weightage.Text = Convert.ToString(txtwweigh.Text);
                            //if (Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text) == "&nbsp;")
                            //    RNT_GoalTarget.Text = "";
                            //else
                            //    RNT_GoalTarget.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
                            //rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
                            ////rdtp_Goal_TIMELINES.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);

                            //To load Goals/Competencies based on position
                            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                            _obj_Pms_RoleKra.PMS_Type = 2;  // 2 means Competencies/Goals
                            _obj_Pms_RoleKra.OPERATION = operation.Get;
                            DataTable dt = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

                            if (dt.Rows.Count > 0)
                            {
                                rcmb_CMP.Items.Clear();
                                rcmb_CMP.DataSource = dt;
                                rcmb_CMP.DataTextField = "CMP_NAME";
                                rcmb_CMP.DataValueField = "CMP_ID";
                                rcmb_CMP.DataBind();

                                rcmb_CMP.SelectedIndex = rcmb_CMP.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text));
                            }


                            RM_GS.SelectedIndex = 3;
                            //btn_UpdateGoalSettingsDetails.Visible = true;
                            btn_Submit.Visible = false;
                            //txt_GoalName.Enabled = false;
                            txt_GoalDescription.Enabled = false;
                            btn_Submit.Visible = false;
                            if (Convert.ToString(ViewState["Edit"]) == "true")
                            {
                                //btn_UpdateGoalSettingsDetails.Visible = false;
                                //btn_UpdateAssignkra.Visible = false;
                            }

                        }

                    }
                    else if (hd_Field.Value == "2")
                    {
                        ////////////////////////
                        GridDataItem dtItem = (GridDataItem)e.Item;
                        int index = dtItem.ItemIndex;
                        string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
                        if (a == "KRA")
                        {

                            //Loading a KRA drop down
                            _obj_Pms_Roles = new SPMS_ROLEKRA();
                            _obj_Pms_Roles.Mode = 6;
                            //_obj_Pms_Roles.ROLE_ID = Convert.ToInt32(RCB_RoleName.SelectedItem.Value);
                            _obj_Pms_Roles.ROLE_ID = Convert.ToInt32(rcmb_Position.SelectedValue);
                            _obj_Pms_Roles.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_Roles.PMS_Type = 1;    //1 means KRA
                            DataTable dt = new DataTable();
                            dt = Pms_Bll.get_RoleKra(_obj_Pms_Roles);
                            if (dt.Rows.Count != 0)
                            {
                                RCB_KRA.Items.Clear();
                                RCB_KRA.DataSource = dt;
                                RCB_KRA.DataTextField = "KRA_NAME";
                                RCB_KRA.DataValueField = "ROLE_KRA_ID";
                                RCB_KRA.DataBind();

                                RCB_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                //
                                _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                                _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32((Rg_KRAGOAL.Items[index].FindControl("lbl_KRA_ID") as Label).Text);
                                _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                                _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
                                _obj_Pms_goalkradetails.MODE = 10;
                                _obj_Pms_goalkradetails.GS_KRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt_KRAdet = new DataTable();
                                dt_KRAdet = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);
                                if (dt_KRAdet.Rows.Count != 0)
                                {
                                    RCB_KRA.SelectedIndex = RCB_KRA.Items.FindItemIndexByValue(Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_KRA_ID"]));

                                    if (RCB_KRA.SelectedIndex > 0)
                                    {
                                        /* To load KRA_Objectives */
                                        _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                        _obj_Pms_RoleKra.Mode = 10;
                                        _obj_Pms_RoleKra.ROLEKRA_ID = Convert.ToInt32(RCB_KRA.SelectedValue);
                                        _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                        DataTable dtKraObjectives = Pms_Bll.get_RoleKra(_obj_Pms_RoleKra);
                                        rcmb_KraObjective.Items.Clear();    //To clear items
                                        rcmb_KraObjective.Text = string.Empty;  //To clear selected item
                                        if (dtKraObjectives.Rows.Count > 0)
                                        {
                                            rcmb_KraObjective.DataSource = dtKraObjectives;
                                            rcmb_KraObjective.DataTextField = "KRA_OBJ_NAME";
                                            rcmb_KraObjective.DataValueField = "KRA_OBJ_ID";
                                            rcmb_KraObjective.DataBind();
                                            rcmb_KraObjective.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                                            //To select the KRA_Objective 
                                            rcmb_KraObjective.SelectedIndex = rcmb_KraObjective.Items.FindItemIndexByValue(Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_OBJ_ID"]));
                                        }
                                    }


                                    lbl_kra.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);

                                    txt_KraDescription.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_DESCRIPTION"]);
                                    //txt_KraMeasure.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_MEASURE"]);
                                    //RNT_KraWeightage.Value = Convert.ToInt32(dt_KRAdet.Rows[0]["GS_KRA_WEIGHTAGE"]);
                                    //RNT_KraTarget.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_TARGET"]);
                                    ////rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(dt_KRAdet.Rows[0]["GS_KRA_TIMELINES"]);
                                    RM_GS.SelectedIndex = 2;
                                    //btn_UpdateAssignkra.Visible = true;
                                    btn_SaveAssignkra.Visible = false;
                                    btn_CancelKRA.Visible = true;
                                    RCB_KRA.Enabled = false;
                                    rcmb_KraObjective.Enabled = false;
                                    txt_KraDescription.Enabled = false;
                                    //txt_KraMeasure.Enabled = false;
                                    //if (Convert.ToString(ViewState["Edit"]) == "true")
                                    //{
                                    //    //btn_UpdateAssignkra.Visible = false;
                                    //}
                                }
                                //_obj_Pms_goalkradetails.GS_KRA_GS_ID = 
                            }
                        }
                        //else if (a == "IDP")
                        else if (a == "Value")
                        {
                            //To populate IDP values in combobox
                            //To load Goals/Competencies based on position
                            _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                            _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                            _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                            _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                            _obj_Pms_RoleKra.PMS_Type = 3;  // 3 means Values/IDP's
                            _obj_Pms_RoleKra.OPERATION = operation.Get;
                            DataTable dt = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);



                            ////Loading a KRA drop down
                            //_obj_idp = new pms_IDPSCREEN();
                            //_obj_idp.IDP_MODE = 9;
                            ////_obj_idp.IDP_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(txt_IDP.Text));
                            //_obj_idp.IDP_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
                            //_obj_idp.IDP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                            //DataTable dt = Pms_Bll.get_idp(_obj_idp);
                            if (dt.Rows.Count > 0)
                            {
                                rcmb_idp.Items.Clear();
                                rcmb_idp.DataSource = dt;
                                rcmb_idp.DataTextField = "IDP_NAME";
                                rcmb_idp.DataValueField = "IDP_ID";
                                rcmb_idp.DataBind();

                                rcmb_idp.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                //
                                _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                                _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                                _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
                                _obj_Pms_goalIDPdetails.MODE = 10;
                                _obj_Pms_goalIDPdetails.GS_IDP_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                DataTable dt_KRAdet = new DataTable();
                                dt_KRAdet = Pms_Bll.get_GsIDP(_obj_Pms_goalIDPdetails);
                                if (dt_KRAdet.Rows.Count != 0)
                                {
                                    rcmb_idp.SelectedIndex = rcmb_idp.Items.FindItemIndexByValue(Convert.ToString(dt_KRAdet.Rows[0]["GS_IDP_IDP_ID"]));
                                    lbl_idp.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);

                                    txt_idpdesc.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_IDP_DESCRIPTION"]);
                                    //txt_idpmeasure.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_IDP_MEASURE"]);
                                    //rnt_idp_wt.Value = Convert.ToInt32(dt_KRAdet.Rows[0]["GS_IDP_WEIGHTAGE"]);
                                    //rtxt_idptarget.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_IDP_TARGET"]);
                                    ////rdtp_idpdate.SelectedDate = Convert.ToDateTime(dt_KRAdet.Rows[0]["GS_IDP_TIMELINES"]);
                                    RM_GS.SelectedIndex = 4;
                                    //btn_IDP_Update.Visible = true;
                                    btn_IDP_Save.Visible = false;
                                    btn_Cancel_IDP.Visible = true;
                                    rcmb_idp.Enabled = false;
                                    txt_idpdesc.Enabled = false;
                                    //txt_idpmeasure.Enabled = false;
                                    //if (Convert.ToString(ViewState["Edit"]) == "true")
                                    //{
                                    //    //btn_UpdateAssignkra.Visible = false;
                                    //    btn_IDP_Update.Visible = false;
                                    //}
                                }
                                //_obj_Pms_goalkradetails.GS_KRA_GS_ID = 
                            }
                        }
                        else
                        {
                            _obj_GSdetails = new PMS_GoalSettings_Details();
                            //_obj_GSdetails.GSDTL_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                            _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text);
                            _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
                            _obj_GSdetails.GS_DETAILS_MODE = 8;
                            _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                            DataTable dt_Goaldet = new DataTable();
                            dt_Goaldet = Pms_Bll.get_GSdetails(_obj_GSdetails);
                            if (dt_Goaldet.Rows.Count != 0)
                            {
                                //To fill Goals

                                //To load Goals/Competencies based on position
                                _obj_Pms_RoleKra = new SPMS_ROLEKRA();
                                _obj_Pms_RoleKra.ROLEKRA_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                                _obj_Pms_RoleKra.BUID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                                _obj_Pms_RoleKra.PositionID = Convert.ToInt32(rcmb_Position.SelectedValue);
                                _obj_Pms_RoleKra.PMS_Type = 2;  // 2 means Competency/Goal
                                _obj_Pms_RoleKra.OPERATION = operation.Get;
                                DataTable dtCmps = Pms_Bll.getPositionKRA(_obj_Pms_RoleKra);

                                ////To remove existing goals from DataTable
                                //if (dtCmps.Rows.Count != 0)
                                //{
                                //    for (int index = 0; index < Rg_KRAGOAL.Items.Count; index++)
                                //    {
                                //        for (int count = 0; count < dtCmps.Rows.Count; count++)
                                //        {
                                //            if (Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text) == "Goal" && Convert.ToString(Rg_KRAGOAL.Items[index]["ROLEKRA_ID"].Text) == Convert.ToString(dtCmps.Rows[count]["CMP_ID"]))
                                //            {
                                //                dtCmps.Rows[count].Delete();
                                //                dtCmps.AcceptChanges();
                                //            }
                                //        }
                                //    }
                                //}


                                rcmb_CMP.Items.Clear();
                                rcmb_CMP.Text = string.Empty;
                                if (dtCmps.Rows.Count > 0)
                                {
                                    rcmb_CMP.DataSource = dtCmps;
                                    rcmb_CMP.DataTextField = "CMP_NAME";
                                    rcmb_CMP.DataValueField = "CMP_ID";
                                    rcmb_CMP.DataBind();
                                    rcmb_CMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                                }

                                rcmb_CMP.SelectedIndex = rcmb_CMP.FindItemIndexByValue(Convert.ToString(dt_Goaldet.Rows[0]["GSDTL_CMP_ID"]));

                                /* End of code - To fill goals*/




                                //lbl_GSID.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);
                                //txt_GoalName.Text = Convert.ToString(dt_Goaldet.Rows[0]["GSDTL_NAME"]);
                                txt_GoalDescription.Text = Convert.ToString(dt_Goaldet.Rows[0]["GSDTL_DESCRIPTION"]);



                                //txt_Measure.Text = Convert.ToString(dt_Goaldet.Rows[0]["GSDTL_MEASURE"]);
                                //RNT_Weightage.Value = Convert.ToInt32(dt_Goaldet.Rows[0]["GSDTL_WEIGHTAGE"]);
                                //RNT_GoalTarget.Text = Convert.ToString(dt_Goaldet.Rows[0]["GSDTL_TARGET"]);
                                ////rdtp_Goal_TIMELINES.SelectedDate = Convert.ToDateTime(dt_Goaldet.Rows[0]["GSDTL_TIMELINES"]);
                                RM_GS.SelectedIndex = 3;
                                //btn_UpdateGoalSettingsDetails.Visible = true;
                                btn_Submit.Visible = false;
                                //txt_GoalName.Enabled = false;
                                txt_GoalDescription.Enabled = false;
                                rcmb_CMP.Enabled = false;
                                btn_Submit.Visible = false;
                                btn_Submit.Visible = false;
                                //if (Convert.ToString(ViewState["Edit"]) == "true")
                                //{
                                //    btn_UpdateGoalSettingsDetails.Visible = false;
                                //}
                            }
                        }
                        hd_Field.Value = "0";
                    }
                    else // after record is inserted and getting edited.
                    {

                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region Clearfields

    protected void ClearKRAFields()
    {
        try
        {
            RCB_KRA.SelectedIndex = 0;
            rcmb_KraObjective.Items.Clear();
            rcmb_KraObjective.Text = string.Empty;
            txt_KraDescription.Text = string.Empty;
            //txt_KraMeasure.Text = string.Empty;
            //RNT_KraWeightage.Text = string.Empty;
            //RNT_KraTarget.Text = string.Empty;
            ////rdtp_TIMELINES.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ClearIDPFields()
    {
        try
        {
            rcmb_idp.SelectedIndex = 0;
            txt_idpdesc.Text = string.Empty;
            //txt_idpmeasure.Text = string.Empty;
            //rnt_idp_wt.Text = string.Empty;
            //rtxt_idptarget.Text = string.Empty;
            ////rdtp_idpdate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ClearGoalFields()
    {
        try
        {
            //txt_GoalName.Text = string.Empty;
            txt_GoalDescription.Text = string.Empty;
            //txt_Measure.Text = string.Empty;
            //RNT_Weightage.Text = string.Empty;
            //RNT_GoalTarget.Text = string.Empty;
            ////rdtp_TIMELINES.SelectedDate = null;
            //btn_UpdateGoalSettingsDetails.Visible = false;
            btn_Submit.Visible = true;
            ////rdtp_Goal_TIMELINES.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void ClearFields()
    {
        try
        {
            RCB_BusinessUnit.SelectedIndex = -1;
            RCB_EmployeeName.ClearSelection();
            RCB_EmployeeName.Items.Clear();
            RCB_EmployeeName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //RCMB_Project.ClearSelection();
            //RCMB_Project.Items.Clear();
            //RCMB_Project.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rlst_pjt.ClearChecked();

            //RCB_RoleName.ClearSelection();
            //RCB_RoleName.Items.Clear();
            //RCB_RoleName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            RCB_ApprasialCycle.ClearSelection();

            RCB_ApprasialCycle.Items.Clear();
            RCB_ApprasialCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //RCB_EmployeeName.SelectedIndex = 0;
            //RCMB_Project.SelectedIndex = -1;
            //RCB_RoleName.SelectedIndex = -1;
            //RCB_ApprasialCycle.SelectedIndex = -1;
            //RCMB_Project.Items.Clear();
            //RCB_ApprasialCycle.Items.Clear();
            //RCB_RoleName.Items.Clear();
            //RCB_EmployeeName.Items.Clear();
            //txt_JobDescription.Text = string.Empty;
            RCB_BusinessUnit.Enabled = true;
            RCB_EmployeeName.Enabled = true;
            rcmb_Position.Enabled = true;
            //RCB_RoleName.Enabled = true;
            //txt_JobDescription.Enabled = true;
            RCB_ApprasialCycle.Enabled = true;
            lbl_RMID.Text = string.Empty;
            lbl_GMID.Text = string.Empty;
            Rg_Goal.DataSource = dt_goal;
            Rg_Goal.DataBind();
            //for (int rows = 0; rows < Rg_KRAGOAL.Items.Count; rows++)
            //{
            //    TextBox txt_kra = new TextBox();
            //    txt_kra = (Rg_KRAGOAL.Items[rows].FindControl("txt_Weightage") as TextBox);
            //    txt_kra.Text = "";

            //}
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
            Session["Test"] = null;
            lbl_Gs_Status.Text = string.Empty;
            lnk_ViewKRA.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearGoalFields();
            ClearKRAFields();
            ClearIDPFields();
            Session.Remove("Test");
            RCB_EmployeeName.SelectedIndex = 0;
            //RCMB_Project.SelectedIndex = -1;
            //rlst_pjt.SelectedIndex = 0;
            //RCB_RoleName.SelectedIndex = -1;
            RCB_ApprasialCycle.SelectedIndex = -1;
            //txt_JobDescription.Text = string.Empty;
            RCB_BusinessUnit.Enabled = false;
            RCB_EmployeeName.Enabled = false;
            rcmb_Position.Enabled = false;
            //RCB_RoleName.Enabled = false;
            //txt_JobDescription.Enabled = false;
            RCB_ApprasialCycle.Enabled = false;
            lbl_gs_dum_id.Text = Convert.ToString(e.CommandArgument);
            ViewState["Edit"] = "false";
            _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            Session["GSID"] = _obj_GS.GS_ID;
            _obj_GS.GS_MODE = 2;
            DataTable dt_det = new DataTable();
            dt_det = Pms_Bll.get_GS(_obj_GS);

            LOADBUID();
            if (dt_det.Rows.Count > 0)
            {
                if (dt_det.Rows[0]["GS_BU_ID"] != System.DBNull.Value)
                {
                    RCB_BusinessUnit.SelectedIndex = RCB_BusinessUnit.FindItemIndexByValue(dt_det.Rows[0]["GS_BU_ID"].ToString());
                }
            }

            LoadAppraisalCycle();
            RCB_ApprasialCycle.SelectedIndex = RCB_ApprasialCycle.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_APPRAISAL_CYCLE"]));
            LoadEmployeesEdit();
            if (dt_det.Rows.Count > 0)
            {
                if (dt_det.Rows[0]["GS_EMP_ID"] != System.DBNull.Value)
                {
                    RCB_EmployeeName.SelectedIndex = RCB_EmployeeName.FindItemIndexByValue(dt_det.Rows[0]["GS_EMP_ID"].ToString());
                }
            }
            //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
            //_obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            //_obj_Pms_EmpSetup.Mode = 6;
            //_obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
            //if (DTREPO.Rows.Count > 0)
            //lbl_desg_text.Text = Convert.ToString(DTREPO.Rows[0]["POSITIONS_CODE"]);

            //LoadRolename();   //Not reqd.

            LoadPositions();
            //LoadProject();
            //To check whether organisation has Integration with Smart PM or not 
            //SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_Smhr_BusinessUnit.OPERATION = operation.Get_BU;
            //_obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_bu1 = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            //if (dt_bu1.Rows.Count > 0)
            //{
            //    if (dt_bu1.Rows[0]["ORGANISATION_INTEGRATION"] != DBNull.Value && Convert.ToString(dt_bu1.Rows[0]["ORGANISATION_INTEGRATION"]) == "True")
            //    {
            //        //LoadProject_SMPM_Edit();
            //    }
            //    else
            //    {
            //        //LoadProject();
            //    }
            //}

            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (dt_det.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32((dt_det.Rows[0]["GS_EMP_ID"]));//where i am passing employee to get bunit
            }

            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = 0;
            }
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            //if (dtappid.Rows.Count != 0)
            //{

            //if (Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]) == Convert.ToInt32(dt_det.Rows[0]["GS_APPRAISAL_CYCLE"]))
            //{
            SPMS_APPRAISAL _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.Mode = 40;
            if (dt_det.Rows.Count != 0)
            {
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(dt_det.Rows[0]["GS_EMP_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dt_det.Rows[0]["GS_APPRAISAL_CYCLE"]);
                lbl_Gs_Status.Text = Convert.ToString(dt_det.Rows[0]["GS_STATUS"]);
                if (Convert.ToString(dt_det.Rows[0]["GS_STATUS"]) != "1")
                {
                    lnk_ViewKRA.Visible = true;
                    lnk_CopyKRA.Visible = true;
                }
                else
                {
                    lnk_ViewKRA.Visible = false;
                    lnk_CopyKRA.Visible = false;
                }
            }
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappstage = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

            if (dtappstage.Rows.Count > 0)  //IF record exists, then either self appraisal or mgr appraisal has started
            {
                //To hide save/update buttons
                btn_Update.Visible = false;
                btn_Save.Visible = false;

                //To hide assign buttons
                btn_assignKRA.Visible = false;
                btn_assignIDP.Visible = false;
                btn_assignGoal.Visible = false;
                btn_Save_Details.Visible = false;
                btn_Update_Details.Visible = false;
            }
            else
            {
                //To hide save/update buttons
                btn_Update.Visible = false;
                btn_Save.Visible = false;

                //To show assign buttons
                btn_assignKRA.Visible = true;
                btn_assignIDP.Visible = true;
                btn_assignGoal.Visible = true;
                btn_Update_Details.Visible = true;
            }


            //if (dtappstage.Rows.Count != 0 || Convert.ToInt32(dt_det.Rows[0]["GS_STATUS"]) == 1)
            if (dtappstage.Rows.Count != 0)
            {
                //Rg_KRAGOAL.Columns[12].Visible = false;
                Rg_KRAGOAL.Columns[10].Visible = false;
                if (Convert.ToInt32(dt_det.Rows[0]["GS_STATUS"]) == 1)
                {
                    //BLL.ShowMessage(this, "Goal Setting is Approved for this Employee.You Can not edit the record.");
                }
                else
                {
                    Pms_Bll.ShowMessage(this, "Goal Setting Can Not Be Edited Self Appraisal Started");
                }
                //To view the details
                foreach (GridColumn col in Rg_KRAGOAL.Columns)
                {
                    if (col.UniqueName == "ColEdit")
                    {
                        col.Visible = false;
                    }
                }
                ViewState["Edit"] = "true";
                if (dt_det.Rows.Count != 0)
                {
                    RCB_EmployeeName.SelectedIndex = RCB_EmployeeName.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_EMP_ID"]));
                    //RCMB_Project.SelectedIndex = RCMB_Project.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_PROJECT"]));
                    //Label1.Text = Convert.ToString(dt_det.Rows[0]["GS_PROJECT"]);
                    //getCheckedItems(rlst_pjt, Label1);
                    //LoadAppraisalCycle();
                    //RCB_ApprasialCycle.SelectedIndex = RCB_ApprasialCycle.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_APPRAISAL_CYCLE"]));
                    //txt_JobDescription.Text = Convert.ToString(dt_det.Rows[0]["GS_JOB_DESCRIPTION"]);
                    //RCB_RoleName.SelectedIndex = RCB_RoleName.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_ROLENAME"]));
                    rcmb_Position.SelectedIndex = rcmb_Position.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_ROLENAME"]));
                    //lnk_ViewKRA.Visible = true;
                }
                //_obj_GS.GS_MODE = 18;
                _obj_GS.GS_MODE = 38;
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GS(_obj_GS);
                dt_details.Columns.Add("SNO");
                int m = 1;
                foreach (DataRow item_1 in dt_details.Rows)
                {
                    item_1["SNO"] = Convert.ToString(m);
                    m = m + 1;
                }
                dt_details.PrimaryKey = new DataColumn[] { dt_details.Columns["SNO"] };
                Session["dtKRA"] = dt_details;
                Rg_KRAGOAL.DataSource = dt_details;
                Rg_KRAGOAL.DataBind();
                //if (dt_details.Rows.Count != 0)
                //{
                //    btn_assignGoal.Visible = true;
                //    btn_assignKRA.Visible = false;
                //}
                //else
                //{
                //    btn_assignGoal.Visible = true;
                //    btn_assignKRA.Visible = false;
                //}

                hd_Field.Value = "2";
                //btn_Save_Details.Visible = false;

                ////To check whether if any kra's/goals/competencies are saved for corresponding goalsetting
                //_obj_GSdetails = new PMS_GoalSettings_Details();
                //_obj_GSdetails.GS_DETAILS_MODE = 12;
                //_obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                //DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
                //if (dtgsdtlid.Rows.Count != 0)  //If any kra's exist:- show update button and hide save button; else:- vice-versa
                //{

                //    btn_Update_Details.Visible = true;
                //    btn_Save_Details.Visible = false;
                //}
                //else
                //{
                //    btn_Update_Details.Visible = false;
                //    btn_Save_Details.Visible = true;
                //}


                //btn_Save.Enabled = false;
                //btn_assignKRA.Visible = false;
                //btn_assignGoal.Visible = false;
                //btn_Update_Details.Visible = false;
                //btn_Save_Details.Visible = false;
                ////btn_UpdateAssignkra.Visible = false;
                ////btn_UpdateGoalSettingsDetails.Visible = false;
                //btn_assignIDP.Visible = false;
                ////btn_IDP_Update.Visible = false;

                ////RCMB_Project.Enabled = false;
                ////rlst_pjt.Enabled = false;
                //// RCB_RoleName.Enabled = false; 
                RM_GS.SelectedIndex = 1;
                //if (dt_details.Rows.Count == 0)
                //{
                //    ////RCB_RoleName.Enabled = true;
                //    //btn_Update.Visible = true;
                //    //btn_Update.Enabled = true;

                //    //To hide update button
                //    btn_Update.Visible = false;
                //    btn_Save.Visible = false;

                //    //To show assign buttons
                //    btn_assignKRA.Visible = true;
                //    btn_assignIDP.Visible = true;
                //    btn_assignGoal.Visible = true;
                //    btn_Update_Details.Visible = true;

                //}
                //else
                //{
                //    //RCB_RoleName.Enabled = false;
                //    btn_Update.Visible = false;
                //    btn_Update.Enabled = false;
                //}
            }

            else
            {
                //Rg_KRAGOAL.Columns[12].Visible = true;
                Rg_KRAGOAL.Columns[10].Visible = true;
                if (dt_det.Rows.Count != 0)
                {
                    RCB_EmployeeName.SelectedIndex = RCB_EmployeeName.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_EMP_ID"]));
                    //RCMB_Project.SelectedIndex = RCMB_Project.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_PROJECT"]));
                    //Label1.Text = Convert.ToString(dt_det.Rows[0]["GS_PROJECT"]);
                    //getCheckedItems(rlst_pjt, Label1);
                    LoadAppraisalCycle();
                    RCB_ApprasialCycle.SelectedIndex = RCB_ApprasialCycle.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_APPRAISAL_CYCLE"]));
                    //txt_JobDescription.Text = Convert.ToString(dt_det.Rows[0]["GS_JOB_DESCRIPTION"]);
                    //RCB_RoleName.SelectedIndex = RCB_RoleName.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_ROLENAME"]));
                    rcmb_Position.SelectedIndex = rcmb_Position.Items.FindItemIndexByValue(Convert.ToString(dt_det.Rows[0]["GS_ROLENAME"]));
                }
                //_obj_GS.GS_MODE = 18;
                _obj_GS.GS_MODE = 38;
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_GS.GS_ID = Convert.ToInt32(Session["GSID"]);
                DataTable dt_details = new DataTable();
                dt_details = Pms_Bll.get_GS(_obj_GS);
                dt_details.Columns.Add("SNO");
                int m = 1;
                foreach (DataRow item_1 in dt_details.Rows)
                {
                    item_1["SNO"] = Convert.ToString(m);
                    m = m + 1;
                }
                dt_details.PrimaryKey = new DataColumn[] { dt_details.Columns["SNO"] };
                Session["dtKRA"] = dt_details;
                Rg_KRAGOAL.DataSource = dt_details;
                Rg_KRAGOAL.DataBind();
                //if (dt_details.Rows.Count != 0)
                //{
                //    btn_assignGoal.Visible = true;
                //    btn_assignKRA.Visible = false;
                //}
                //else
                //{
                //    btn_assignGoal.Visible = true;
                //    btn_assignKRA.Visible = false;
                //}

                hd_Field.Value = "2";
                //btn_Save_Details.Visible = false;


                _obj_GSdetails = new PMS_GoalSettings_Details();
                _obj_GSdetails.GS_DETAILS_MODE = 12;
                _obj_GSdetails.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(Session["GSID"]);
                DataTable dtgsdtlid = Pms_Bll.get_GSdetails(_obj_GSdetails);
                if (dtgsdtlid.Rows.Count != 0)
                {

                    btn_Update_Details.Visible = true;
                    btn_Save_Details.Visible = false;
                }
                else
                {
                    btn_Update_Details.Visible = false;
                    btn_Save_Details.Visible = true;
                }
                //btn_Save.Enabled = false;
                btn_assignKRA.Visible = true;
                btn_assignGoal.Visible = true;
                btn_assignIDP.Visible = true;
                //RCMB_Project.Enabled = false;
                //rlst_pjt.Enabled = false;
                //RCB_RoleName.Enabled = false;
                RM_GS.SelectedIndex = 1;
                //if (dt_details.Rows.Count == 0)
                //{
                //    //RCB_RoleName.Enabled = true;
                //    btn_Update.Visible = true;
                //    btn_Update.Enabled = true;
                //}
                //else
                //{
                //    //RCB_RoleName.Enabled = false;
                //    btn_Update.Visible = false;
                //    btn_Update.Enabled = false;
                //}
            }

            //}
            //else
            //{

            //    Pms_Bll.ShowMessage(this, "Goal Setting Can Not Be Edited Appraiasl Cycle Changed");

            //}
            //}

            //else
            //{
            //    Pms_Bll.ShowMessage(this, "Goal Setting Can Not Be Edited Appraiosal Cycle Changed");

            //}
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LOADBUID();
            //RCB_RoleName.Enabled = true;
            //RCMB_Project.Enabled = true;
            //rlst_pjt.Enabled = true;
            RCB_BusinessUnit.Enabled = true;
            //LoadEmployees();
            //LoadRolename();
            createcontrols();
            //LoadProject();
            //  LoadAppraisalCycle();
            Session["Test"] = 0;
            RM_GS.SelectedIndex = 1;
            ClearFields();
            ClearKRAFields();
            ClearGoalFields();
            ClearIDPFields();
            GridFooterItem footeritem = (GridFooterItem)Rg_KRAGOAL.MasterTableView.GetItems(GridItemType.Footer)[0];
            hd_Field.Value = "1";
            btn_Save_Details.Visible = false;
            //RCMB_Project.Enabled = true;
            //rlst_pjt.Enabled = true;
            btn_assignKRA.Visible = false;
            btn_assignGoal.Visible = false;
            btn_IDP_Save.Visible = false;
            btn_assignIDP.Visible = false;
            btn_Update_Details.Visible = false;
            btn_Save.Visible = true;
            btn_Save.Enabled = true;
            Session["GSID"] = 0;
            txt_ReportingManager.Text = string.Empty;
            txt_GeneralManager.Text = string.Empty;
            //lbl_desg_text.Text = string.Empty;
            lnk_CopyKRA.Visible = false;
            btn_Update.Visible = false;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private static void ShowCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            IList<RadListBoxItem> collection = listBox.CheckedItems;
            foreach (RadListBoxItem item in collection)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.Value);
                }
                else
                {
                    sb.Append("," + item.Value);
                }
            }

            label.Text = sb.ToString();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(HttpContext.Current.Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            HttpContext.Current.Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void getCheckedItems(RadListBox listBox, Label label)
    {
        try
        {
            string strVal = label.Text;
            string[] Ar = strVal.Split(new Char[] { ',' });
            for (int i = 0; i < Ar.Length; i++)
            {
                string strTemp = Ar[i].Trim();

                if (listBox.FindItemByValue(strTemp) != null)
                    listBox.FindItemByValue(strTemp).Checked = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void Rg_KRAGOAL_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (Session["dtKRA"] != null)
            {
                DataTable dt_KRA = (DataTable)Session["dtKRA"];
                if (dt_KRA.Rows.Count != 0)
                {
                    Rg_KRAGOAL.DataSource = dt_KRA;
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    Rg_KRAGOAL.DataSource = dt1;
                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Details_Edit_Command(object sender, CommandEventArgs e)
    {
        //if (hd_Field.Value == "1")//new edit i.e., with a normal datatable
        //{
        //    GridDataItem dtItem = (GridDataItem)e.Item;
        //    int index = dtItem.ItemIndex;
        //    string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
        //    if (a == "K")
        //    {

        //        _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
        //        RM_GS.SelectedIndex = 1;
        //        _obj_Pms_Roles = new SPMS_ROLEKRA();
        //        _obj_Pms_Roles.Mode = 6;
        //        _obj_Pms_Roles.ROLE_ID = Convert.ToInt32(RCB_RoleName.SelectedItem.Value);
        //        DataTable dt = new DataTable();
        //        dt = Pms_Bll.get_RoleKra(_obj_Pms_Roles);
        //        RCB_KRA.DataSource = dt;
        //        RCB_KRA.DataTextField = "KRA_NAME";
        //        RCB_KRA.DataValueField = "ROLEKRA_ID";
        //        RCB_KRA.DataBind();

        //        RCB_KRA.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        //        TextBox txtwweight = new TextBox();
        //        txtwweight = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;
        //        Label lbl_name = new Label();
        //        lbl_name = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
        //        lbl_kra.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);
        //        RCB_KRA.SelectedIndex = RCB_KRA.Items.FindItemIndexByValue(Convert.ToString(Rg_KRAGOAL.Items[index]["ID"].Text));
        //        // rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EXPENSE_BUSINESSUNIT_ID"]));
        //        txt_KraDescription.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Desc"].Text);
        //        //txt_KraMeasure.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
        //        //RNT_KraWeightage.Text = Convert.ToString(txtwweight.Text);
        //        //RNT_KraTarget.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
        //        //rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
        //        btn_UpdateAssignkra.Visible = true;
        //        btn_SaveAssignkra.Visible = false;
        //        btn_CancelKRA.Visible = true;
        //        hd_Field.Value = "0";

        //    }
        //    else
        //    {
        //        Label lblname = new Label();
        //        TextBox txtwweigh = new TextBox();
        //        lblname = Rg_KRAGOAL.Items[index].FindControl("lbl_NAME") as Label;
        //        lbl_GSID.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["SNO"].Text);
        //        txtwweigh = Rg_KRAGOAL.Items[index].FindControl("txt_Weightage") as TextBox;
        //        txt_GoalName.Text = Convert.ToString(lblname.Text);
        //        txt_GoalDescription.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Desc"].Text);
        //        //txt_Measure.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Measure"].Text);
        //        //RNT_Weightage.Text = Convert.ToString(txtwweigh.Text);
        //        //RNT_GoalTarget.Text = Convert.ToString(Rg_KRAGOAL.Items[index]["Target"].Text);
        //        //rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(Rg_KRAGOAL.Items[index]["TIMELINES"].Text);
        //        RM_GS.SelectedIndex = 2;
        //        btn_UpdateGoalSettingsDetails.Visible = true;
        //        btn_Submit.Visible = false;

        //    }

        //}
        //else if (hd_Field.Value == "2")
        //{
        //    GridDataItem dtItem = (GridDataItem)e.Item;
        //    int index = dtItem.ItemIndex;
        //    string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
        //    if (a == "K")
        //    {
        //        _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
        //        _obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
        //        _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(Session["GSID"].ToString());
        //        _obj_Pms_goalkradetails.MODE = 10;
        //        DataTable dt_KRAdet = new DataTable();
        //        dt_KRAdet = Pms_Bll.get_Gskra(_obj_Pms_goalkradetails);
        //        RCB_KRA.SelectedIndex = RCB_KRA.Items.FindItemIndexByValue(Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_KRA_ID"]));
        //        txt_KraDescription.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_DESCRIPTION"]);
        //        //txt_KraMeasure.Text = Convert.ToString(dt_KRAdet.Rows[0]["GS_KRA_MEASURE"]);
        //        //RNT_KraWeightage.Value = Convert.ToInt32(dt_KRAdet.Rows[0]["GS_KRA_WEIGHTAGE"]);
        //        //RNT_KraTarget.Value = Convert.ToInt32(dt_KRAdet.Rows[0]["GS_KRA_TARGET"]);
        //        //rdtp_TIMELINES.SelectedDate = Convert.ToDateTime(dt_KRAdet.Rows[0]["GS_KRA_TIMELINES"]);
        //        hd_Field.Value = "0";
        //        //_obj_Pms_goalkradetails.GS_KRA_GS_ID = 
        //    }
        //    else
        //    { }
        //}
        //else // after record is inserted and getting edited.
        //{

        //}
    }

    public void sendMail()
    {
        try
        {
            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            _obj_PMS_getemployee.Mode = 6;
            DataTable dt = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["APPMGR_EMAIL"] != System.DBNull.Value && dt.Rows[0]["APPMGR_EMAIL"] != string.Empty &&
                    dt.Rows[0]["RPTMGR_EMAIL"] != System.DBNull.Value && dt.Rows[0]["RPTMGR_EMAIL"] != string.Empty)
                {
                    string toAddress, subject, body, ccAddress;
                    ccAddress=(Convert.ToString(dt.Rows[0]["RPTMGR_EMAIL"]));
                    toAddress=(Convert.ToString(dt.Rows[0]["APPMGR_EMAIL"]));
                     subject = "Goal Setting";
                     body = "<html>" +
                                    "<body> " +
                                    "<p>Dear, " + Convert.ToString(dt.Rows[0]["APPMGR_NAME"]) + " </p> " +
                                    "<p>Goal Setting has been done for " + Convert.ToString(dt.Rows[0]["EMP_NAME"]) + " for Appraisal Cycle - " + Convert.ToString(RCB_ApprasialCycle.SelectedItem.Text) + ".Please Review and Approve. <br>" +
                                    "</p> " +
                                    "<p>Best Regards,<br/><br/>" +
                                    "Team Smart HR</p>" +
                                    "</body>" +
                                    " </html>";
                    
                     BLL.SendMail(toAddress, ccAddress, subject, body);
                    BLL.ShowMessage(this, "A Mail has been sent to the Reviewer.");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", "<script type='text/javascript'>Close()</" + "script>", false);
                }
            }
            else
            {
                BLL.ShowMessage(this, "Security Code is Invalid");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_ViewKRA_command(object sender, CommandEventArgs e)
    {
        try
        {
            //if (RCB_RoleName.SelectedIndex > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
            //        "ShowPop('" + Convert.ToString(RCB_RoleName.SelectedItem.Value) + "');", true);
            //}
            //else
            //{
            //    BLL.ShowMessage(this, "Please Select Role");
            //    return;
            //}

            //To pass PositionID as QueryString
            if (rcmb_Position.SelectedIndex > 0 && RCB_BusinessUnit.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                    "ShowPop(" + Convert.ToString(rcmb_Position.SelectedValue) + "," + Convert.ToString(RCB_BusinessUnit.SelectedValue) + ");", true);
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Role");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void RCB_RoleName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //if (RCB_RoleName.SelectedIndex > 0)
        //    lnk_ViewKRA.Visible = true;
        //else
        //    lnk_ViewKRA.Visible = false;
    }

    protected void lnk_DeleteCommand(object sender, CommandEventArgs e)
    {
        try
        {
            bool status = false;
            bool status1 = false;
            //GridDataItem dtItem = (GridDataItem)e.CommandArgument;
            //int index = dtItem.ItemIndex;
            LinkButton lbtn = sender as LinkButton;
            GridItem gvRow = lbtn.Parent.Parent as GridItem;
            int index = gvRow.ItemIndex;
            string a = Convert.ToString(Rg_KRAGOAL.Items[index]["A"].Text);
            string GS_ID = Convert.ToString(Rg_KRAGOAL.Items[index]["GSID"].Text);
            DataTable dt = Session["dtKRA"] as DataTable;
            //if (a == "Goal")
            if (a == "Competency")
            {
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    //if (Convert.ToString(dt.Rows[count]["A"]) == "Goal" && Convert.ToString(e.CommandArgument) == Convert.ToString(dt.Rows[count]["ROLEKRA_ID"]))
                    if (Convert.ToString(dt.Rows[count]["A"]) == "Competency" && Convert.ToString(e.CommandArgument) == Convert.ToString(dt.Rows[count]["ROLEKRA_ID"]))
                    {
                        dt.Rows[count].Delete();
                        dt.AcceptChanges();
                        status = true;
                    }
                }
                if (Convert.ToInt32(GS_ID) > 0) //If GS_ID = 0 means record is not from DB. So no need to go to DB
                {
                    _obj_GSdetails = new PMS_GoalSettings_Details();
                    _obj_GSdetails.GS_DETAILS_MODE = 14;
                    //_obj_GSdetails.GSDTL_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
                    _obj_GSdetails.GSDTL_CMP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
                    _obj_GSdetails.GSDTL_GS_ID = Convert.ToInt32(GS_ID);
                    status1 = Pms_Bll.set_GSdetails(_obj_GSdetails);
                }
            }
            else if (a == "KRA")
            {
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    if (Convert.ToString(dt.Rows[count]["A"]) == "KRA" && Convert.ToString(e.CommandArgument) == Convert.ToString(dt.Rows[count]["ROLEKRA_ID"]))
                    {
                        dt.Rows[count].Delete();
                        dt.AcceptChanges();
                        status = true;
                    }
                }
                if (Convert.ToInt32(GS_ID) > 0) //If GS_ID = 0 means record is not from DB. So no need to go to DB
                {
                    _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
                    _obj_Pms_goalkradetails.MODE = 12;
                    //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
                    _obj_Pms_goalkradetails.GS_KRA_OBJ_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));   //KRA_OBJ_ID
                    _obj_Pms_goalkradetails.GS_KRA_GS_ID = Convert.ToInt32(GS_ID);
                    status1 = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);
                }
            }
            else
            {
                for (int count = 0; count < dt.Rows.Count; count++)
                {
                    //if (Convert.ToString(dt.Rows[count]["A"]) == "IDP" && Convert.ToString(e.CommandArgument) == Convert.ToString(dt.Rows[count]["ROLEKRA_ID"]))
                    if (Convert.ToString(dt.Rows[count]["A"]) == "Value" && Convert.ToString(e.CommandArgument) == Convert.ToString(dt.Rows[count]["ROLEKRA_ID"]))
                    {
                        dt.Rows[count].Delete();
                        dt.AcceptChanges();
                        status = true;
                    }
                }
                if (Convert.ToInt32(GS_ID) > 0) //If GS_ID = 0 means record is not from DB. So no need to go to DB
                {
                    _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
                    _obj_Pms_goalIDPdetails.MODE = 12;
                    _obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
                    _obj_Pms_goalIDPdetails.GS_IDP_GS_ID = Convert.ToInt32(GS_ID);
                    status1 = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);
                }
            }
            dt.DefaultView.Sort = "A ASC";
            Rg_KRAGOAL.DataSource = dt;
            Rg_KRAGOAL.DataBind();
            Session["dtKRA"] = dt;
            if (status == true || status1 == true)
                BLL.ShowMessage(this, "Selected " + a + " Details Deleted Successfully. ");
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_CopyKRA_command(object sender, CommandEventArgs e)
    {
        try
        {
            if (RCB_ApprasialCycle.SelectedIndex > 0)
            {
                RM_GS.SelectedIndex = 5;
                LoadCopyAppraisalCycle();
                DataTable dt = new DataTable();
                Rg_CopyKRA.DataSource = dt;
                Rg_CopyKRA.DataBind();
                Rg_CopyKRA.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                //    "ShowWin('" + Convert.ToString(RCB_EmployeeName.SelectedItem.Value) + "','" + Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value) + "');", true);
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Appraisal Cycle");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCopyAppraisalCycle()
    {
        try
        {
            rcmb_CopyAppCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 15;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_Appraisalcycle.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);
            DataTable DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            rcmb_CopyAppCycle.DataSource = DT_AppraisalCycle;
            rcmb_CopyAppCycle.DataTextField = "APPRCYCLE_NAME";
            rcmb_CopyAppCycle.DataValueField = "APPRCYCLE_ID";
            rcmb_CopyAppCycle.DataBind();
            rcmb_CopyAppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_CopyAppCycle_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_CopyAppCycle.SelectedIndex > 0)
            {
                LoadCopyGrid();
                Rg_CopyKRA.DataBind();
                if (Rg_CopyKRA.Items.Count == 0)
                {
                    BLL.ShowMessage(this, "No Records to Display.");
                    btn_Copy.Visible = false;
                }
                else
                {
                    btn_Copy.Visible = true;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                Rg_CopyKRA.DataSource = dt;
                Rg_CopyKRA.DataBind();
                btn_Copy.Visible = false;
                Rg_CopyKRA.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCopyGrid()
    {
        try
        {
            _obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 34;
            _obj_GS.GS_MODE = 39;
            _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(RCB_ApprasialCycle.SelectedItem.Value);// Convert.ToString(Request.QueryString["APPCYCLE_ID"]);
            _obj_GS.BUID = Convert.ToInt32(rcmb_CopyAppCycle.SelectedItem.Value);
            _obj_GS.GS_EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);//Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
            DataTable dt_details = Pms_Bll.get_GS(_obj_GS);
            DataTable dt_kra = Session["dtKRA"] as DataTable;
            for (int index = 0; index < dt_kra.Rows.Count; index++)
            {
                for (int count = 0; count < dt_details.Rows.Count; count++)
                {
                    if (Convert.ToString(dt_kra.Rows[index]["A"]) == "KRA" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt_details.Rows[count]["ROLEKRA_ID"]) && Convert.ToString(dt_kra.Rows[index]["KRA_ID"]) == Convert.ToString(dt_details.Rows[count]["KRA_ID"]))
                    {
                        dt_details.Rows[count].Delete();
                        dt_details.AcceptChanges();
                    }
                    //else if (Convert.ToString(dt_kra.Rows[index]["A"]) == "IDP" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt_details.Rows[count]["ROLEKRA_ID"]))
                    else if (Convert.ToString(dt_kra.Rows[index]["A"]) == "Value" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt_details.Rows[count]["ROLEKRA_ID"]))
                    {
                        dt_details.Rows[count].Delete();
                        dt_details.AcceptChanges();
                    }
                    //else if (Convert.ToString(dt_kra.Rows[index]["A"]).ToUpper() == "GOAL" && Convert.ToString(dt_kra.Rows[index]["NAME"]).ToUpper().Trim() == Convert.ToString(dt_details.Rows[count]["NAME"]).ToUpper().Trim())
                    //else if (Convert.ToString(dt_kra.Rows[index]["A"]).ToUpper() == "GOAL" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt_details.Rows[count]["ROLEKRA_ID"]))
                    else if (Convert.ToString(dt_kra.Rows[index]["A"]).ToUpper() == "COMPETENCY" && Convert.ToString(dt_kra.Rows[index]["ROLEKRA_ID"]) == Convert.ToString(dt_details.Rows[count]["ROLEKRA_ID"]))
                    {
                        dt_details.Rows[count].Delete();
                        dt_details.AcceptChanges();
                    }
                }
            }
            Rg_CopyKRA.DataSource = dt_details;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < Rg_CopyKRA.Items.Count; i++)
            {
                CheckBox Chk_All = (CheckBox)sender;
                if (Chk_All.Checked)
                {
                    for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_CopyKRA.Items[index].FindControl("chckbtn_Select");
                        c.Checked = true; ;
                    }
                }
                else
                {
                    for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
                    {
                        CheckBox c = (CheckBox)Rg_CopyKRA.Items[index].FindControl("chckbtn_Select");
                        c.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            bool status = false;
            _obj_GS = new PMS_GoalSettings();
            _obj_Pms_goalkradetails = new GOALSETTING_GOALKRA_DETAILS();
            _obj_Pms_goalIDPdetails = new GOALSETTING_IDP_DETAILS();
            _obj_GSdetails = new PMS_GoalSettings_Details();
            int count = 0;
            DataTable dt_KRA = (DataTable)Session["dtKRA"];
            for (int index = 0; index < Rg_CopyKRA.Items.Count; index++)
            {
                CheckBox chk = Rg_CopyKRA.Items[index].FindControl("chckbtn_Select") as CheckBox;
                if (chk.Checked)
                {
                    count++;
                    if (Rg_CopyKRA.Items[index]["A"].Text == "KRA")
                    {
                        //_obj_Pms_goalkradetails.GS_KRA_KRA_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        //_obj_Pms_goalkradetails.APPCYCLE = Convert.ToInt32(rcmb_CopyAppCycle.SelectedItem.Value);
                        //_obj_Pms_goalkradetails.BUID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value);//Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        //_obj_Pms_goalkradetails.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);// Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        //_obj_Pms_goalkradetails.MODE = 13;
                        //status = Pms_Bll.set_Gskra(_obj_Pms_goalkradetails);
                        //
                        DataRow dr = dt_KRA.NewRow();
                        //dr[0] = Convert.ToString(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        dr[0] = 0;  //0 represents "GSID", not from DB
                        dr[1] = Convert.ToString(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        dr[2] = Convert.ToString(Rg_CopyKRA.Items[index]["NAME"].Text.Replace("'", "''"));
                        dr[3] = Convert.ToString(Rg_CopyKRA.Items[index]["DESC"].Text.Replace("'", "''"));
                        //dr[4] = Convert.ToString(Rg_CopyKRA.Items[index]["MEASURE"].Text.Replace("'", "''"));
                        //dr[5] = Convert.ToString(Rg_CopyKRA.Items[index]["WEIGHTAGE"].Text);
                        //dr[6] = Convert.ToString(Rg_CopyKRA.Items[index]["TARGET"].Text.Replace("'", "''"));
                        //dr[4] = "IDP";
                        dr[4] = "KRA";
                        dr[5] = Convert.ToString((Rg_CopyKRA.Items[index].FindControl("lbl_KRA_ID1") as Label).Text);
                        dr[6] = dt_KRA.Rows.Count + 1;
                        dt_KRA.Rows.Add(dr);
                        status = true;
                    }
                    //else if (Rg_CopyKRA.Items[index]["A"].Text == "IDP")
                    else if (Rg_CopyKRA.Items[index]["A"].Text == "Value")
                    {
                        //_obj_Pms_goalIDPdetails.GS_IDP_IDP_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        //_obj_Pms_goalIDPdetails.APPCYCLE = Convert.ToInt32(rcmb_CopyAppCycle.SelectedItem.Value);
                        //_obj_Pms_goalIDPdetails.BUID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value); //Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        //_obj_Pms_goalIDPdetails.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);// Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        //_obj_Pms_goalIDPdetails.MODE = 13;
                        //status = Pms_Bll.set_GsIDP(_obj_Pms_goalIDPdetails);
                        //
                        DataRow dr = dt_KRA.NewRow();
                        //dr[0] = Convert.ToString(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        dr[0] = 0;  //0 represents "GSID", not from DB
                        dr[1] = Convert.ToString(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        dr[2] = Convert.ToString(Rg_CopyKRA.Items[index]["NAME"].Text.Replace("'", "''"));
                        dr[3] = Convert.ToString(Rg_CopyKRA.Items[index]["DESC"].Text.Replace("'", "''"));
                        //dr[4] = Convert.ToString(Rg_CopyKRA.Items[index]["MEASURE"].Text.Replace("'", "''"));
                        //dr[5] = Convert.ToString(Rg_CopyKRA.Items[index]["WEIGHTAGE"].Text);
                        //dr[6] = Convert.ToString(Rg_CopyKRA.Items[index]["TARGET"].Text.Replace("'", "''"));
                        //dr[4] = "IDP";
                        dr[4] = "Value";
                        dr[6] = dt_KRA.Rows.Count + 1;
                        dt_KRA.Rows.Add(dr);
                        status = true;
                    }
                    else
                    {
                        //_obj_GSdetails.GSDTL_ID = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text);
                        //_obj_GSdetails.APPCYCLE = Convert.ToInt32(rcmb_CopyAppCycle.SelectedItem.Value);
                        //_obj_GSdetails.BUID = Convert.ToInt32(RCB_ApprasialCycle.SelectedItem.Value); //Convert.ToInt32(Convert.ToString(Request.QueryString["APPCYCLE_ID"]));
                        //_obj_GSdetails.EMP_ID = Convert.ToInt32(RCB_EmployeeName.SelectedItem.Value);// Convert.ToInt32(Convert.ToString(Request.QueryString["EMP_ID"]));
                        //_obj_GSdetails.GS_DETAILS_MODE = 15;
                        //status = Pms_Bll.set_GSdetails(_obj_GSdetails);

                        DataRow dr = dt_KRA.NewRow();
                        //dr[0] = dt_KRA.Rows.Count + 1;//reprents "GSID"
                        dr[0] = 0;  //0 represents "GSID", not from DB
                        dr[1] = Convert.ToInt32(Rg_CopyKRA.Items[index]["ROLEKRA_ID"].Text); ;//represents "ID" Column
                        dr[2] = Convert.ToString(Rg_CopyKRA.Items[index]["NAME"].Text.Replace("'", "''"));
                        dr[3] = Convert.ToString(Rg_CopyKRA.Items[index]["DESC"].Text.Replace("'", "''"));
                        //dr[4] = Convert.ToString(Rg_CopyKRA.Items[index]["MEASURE"].Text.Replace("'", "''"));
                        //dr[5] = Convert.ToString(Rg_CopyKRA.Items[index]["WEIGHTAGE"].Text);
                        //dr[9] = dt_KRA.Rows.Count + 1;
                        //dr[4] = "Goal";
                        dr[4] = "Competency";
                        dr[6] = dt_KRA.Rows.Count + 1;
                        dt_KRA.Rows.Add(dr);
                        status = true;
                    }
                }
            }
            dt_KRA.DefaultView.Sort = "A ASC";
            dt_KRA = dt_KRA.DefaultView.ToTable();
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
            Session["dtKRA"] = dt_KRA;

            if (count == 0)
            {
                BLL.ShowMessage(this, "Please Select Atleast one KRA to Copy");
                return;
            }
            if (status)
            {
                LoadCopyGrid();
                Rg_CopyKRA.DataBind();
                if (Rg_CopyKRA.Items.Count == 0)
                {
                    btn_Copy.Visible = false;
                }
                else
                {
                    btn_Copy.Visible = true;
                }
                BLL.ShowMessage(this, "Selected KRAs Copied Successfully.");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_CopyCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rg_CopyKRA.Visible = false;
            rcmb_CopyAppCycle.SelectedIndex = 0;
            btn_Copy.Visible = false;
            RM_GS.SelectedIndex = 1;
            DataTable dt_KRA = (DataTable)Session["dtKRA"];
            Rg_KRAGOAL.DataSource = dt_KRA;
            Rg_KRAGOAL.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void Rg_CopyKRA_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_CopyAppCycle.SelectedIndex > 0)
            {
                LoadCopyGrid();
                if (Rg_CopyKRA.Items.Count == 0)
                    BLL.ShowMessage(this, "No Records to Display.");
            }
            else
            {
                DataTable dt = new DataTable();
                Rg_CopyKRA.DataSource = dt;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    /* New Code*/
    private void LoadPositions()
    {
        try
        {
            if (Session["ORG_ID"] != "")
            {
                if (RCB_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_POSITIONS _obj_smhr_positions = new SMHR_POSITIONS();
                    _obj_smhr_positions.OPERATION = operation.Select;
                    _obj_smhr_positions.JOBLOC_BUSINESSUNIT_ID = Convert.ToInt32(RCB_BusinessUnit.SelectedValue);
                    _obj_smhr_positions.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtPos = BLL.get_BUPositions(_obj_smhr_positions);
                    rcmb_Position.DataSource = dtPos;
                    rcmb_Position.DataTextField = "POSITIONS_CODE";
                    rcmb_Position.DataValueField = "POSITIONS_ID";
                    rcmb_Position.DataBind();
                    rcmb_Position.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Business Unit");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_CMP_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_CMP.SelectedIndex > 0)
            {

                //To fetch Competency details
                PMS_CMP objCmp = new PMS_CMP();
                objCmp.CMP_ID = Convert.ToInt32(rcmb_CMP.SelectedValue);
                objCmp.OPERATION = operation.Get;
                DataTable dtCmps = Pms_Bll.get_cmp(objCmp);
                if (dtCmps.Rows.Count > 0)
                {
                    txt_GoalDescription.Text = Convert.ToString(dtCmps.Rows[0]["CMP_DESCRIPTION"]);
                    btn_IDP_Save.Visible = true;
                    //btn_IDP_Update.Visible = false;
                    txt_GoalDescription.Enabled = false;
                }
                else
                {
                    txt_GoalDescription.Enabled = false;
                    txt_GoalDescription.Text = string.Empty;
                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Competency");
                txt_GoalDescription.Text = string.Empty;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_GS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /* New Code*/
}
