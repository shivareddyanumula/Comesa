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


public partial class PMS_frm_PmsAppraisalDiscussion : System.Web.UI.Page
{
    SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting;
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALGOAL _obj_Spms_AppraisalGoal;
    SPMS_GOALSETTINGKRADETAILS _obj_Spms_GoalStgKraDtls;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
    SPMS_APRAISALAPPROVER _obj_Pms_AppApprover;
    SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls;
    PMS_GoalSettings_Details _obj_Pms_GoalSettingdetails;
    PMS_LOGININFO _obj_Pms_LoginInfo;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_EMPSETUP _obj_pms_EmployeeSetup;

    #region page load methods

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            rdtp_DateofDiscussion.SelectedDate = DateTime.Today;
            rdtp_DateofDiscussion.Enabled = false;
            if (!Page.IsPostBack)
            {
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Appraisal Discussion");
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
                    // Rg_Appraisal_Goal.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    // btn_Update.Visible = false;
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
                //PMS_EMPSETUP _obj_Pms_EmpSetup;
                //_obj_Pms_EmpSetup = new PMS_EMPSETUP();


                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.MODE = 8;
                //if(dt_buu.Rows.Count !=0)
                //{
                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //}
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //if (dtappid.Rows.Count != 0)
                //{
                //    _obj_Pms_EmpSetup.Mode = 12;
                //    if (dt_buu.Rows.Count != 0)
                //    {
                //        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //    }
                //    if(dtappid.Rows.Count !=0)
                //    {
                //    _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //    }
                //    _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                //    if (dt.Rows.Count != 0)
                //    {
                //        rcmb_EmployeeType11.DataSource = dt;
                //        rcmb_EmployeeType11.DataTextField = "EMPLOYEE_NAME";
                //        rcmb_EmployeeType11.DataValueField = "EMP_ID";
                //        rcmb_EmployeeType11.DataBind();
                //        rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_EmployeeType11.Enabled = true;

                //        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //        {

                //            rcmb_EmployeeType11.Enabled = false;


                //        }

                //        else
                //        {
                //            rcmb_EmployeeType11.Enabled = true;
                //        }


                //    }
                //    else
                //    {
                //        DataTable dt5 = new DataTable();

                //        rcmb_EmployeeType11.DataSource = dt5;
                //        rcmb_EmployeeType11.DataBind();
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //Pms_Bll.ShowMessage(this, "Approver Appraisal Has Not Done");
                //        rcmb_EmployeeType11.Enabled = false;

                //    }
                //}

                //else
                //{
                //    DataTable dt5 = new DataTable();

                //    rcmb_EmployeeType11.DataSource = dt5;
                //    rcmb_EmployeeType11.DataBind();
                //    //lbl_BusinessUnitName.Visible = false;
                //    //rcmb_BusinessUnitType.Visible = false;
                //    //Pms_Bll.ShowMessage(this, "Approver Appraisal Has Not Done");
                //    rcmb_EmployeeType11.Enabled = false;


                //}

                ////Rm_Appraisal_PAGE.SelectedIndex = 0;
                //Rm_Appraisal_Kra.Visible = false;
                //Rm_Appraisal_Goal.Visible = false;
                //Rm_Kra_Details.Visible = false;
                //Rm_AppraisalDiscussion.Visible = false;
                //rtxt_GpMgr.Text = string.Empty;
                //rtxt_RpMgr.Text = string.Empty;
                //rtxt_GpMgr.Enabled = true;
                //rtxt_RpMgr.Enabled = true;
                ////rtxt_Project.Enabled = true;






            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region LoadGoal Grid
    /// <summary>
    /// here i am binding goal grid based on employee selection 
    /// </summary>
    /// <param name="dt"></param>
    protected void LoadGrid()
    {

        //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
        //_obj_Pms_EmpGoalSetting.Mode = 10;

        //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);


        //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
        //int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
        //_obj_Pms_GoalSettingdetails = new PMS_GoalSettings_Details();
        //_obj_Pms_GoalSettingdetails.GSDTL_GS_ID = GSID;
        //_obj_Pms_GoalSettingdetails.GS_DETAILS_MODE = 5;
        //DataTable dt_details = new DataTable();
        //dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
        //if (dt_details.Rows.Count != 0)
        //{
        //    Rg_Appraisal_Goal.DataSource = dt_details;
        //    Rg_Appraisal_Goal.DataBind();

        //    PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
        //    _obj_Pms_Appraisalcycle.MODE = 11;
        //    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
        //    DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

        //    _obj_Pms_Appraisalcycle.MODE = 8;
        //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
        //    DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);

        //    _obj_Spms_Appraisal.Mode = 5;

        //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);

        //    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
        //    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);
        //    _obj_Spms_AppraisalGoal.Mode = 7;

        //    DataTable dt8 = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

        //    rnt_GoalAvgrtg.Value = Convert.ToInt32(dt8.Rows[0]["APP_GOALS_MGR_RATING"]);
        //    rnt_GoalAvgrtg.Enabled = false;
        //    Rm_Kra_Details.Visible = true;
        //    Rm_Appraisal_PAGE.SelectedIndex = 0;

        //    Rm_Appraisal_Goal.Visible = true;

        //    Rg_Appraisal_Goal.Visible = true;

        //    Rp_Appraisal_VIEWDETAILS.Visible = true;
        //    Rm_Appraisal_Kra.SelectedIndex = 0;
        //    Rm_Kra_Details.Visible = true;
        //    LoadKraGrid();


        //}
        //else
        //{

        //    Pms_Bll.ShowMessage(this, "No Goal Assigned");

        //    Rm_Kra_Details.Visible = false;
        //    Rm_AppraisalDiscussion.Visible = false;
        //    Rm_Appraisal_Goal.Visible = false;


        //    return;
        //}




    }

    #endregion

    #region LoadKra Grid
    /// <summary>
    /// here i am binding Kra grid based on employee selection 
    /// </summary>
    /// <param name="dt"></param>
    protected void LoadKraGrid()
    {

        //_obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
        //_obj_Pms_EmpGoalSetting.Mode = 8;

        //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
        //DataTable dt = Pms_Bll.get_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
        //int GSID = Convert.ToInt32(dt.Rows[0]["GS_ID"]);
        //_obj_Pms_GoalSettingdetails = new PMS_GoalSettings_Details();
        //_obj_Pms_GoalSettingdetails.GSDTL_GS_ID = GSID;
        //_obj_Pms_GoalSettingdetails.GS_DETAILS_MODE = 5;
        //DataTable dt_details = new DataTable();
        //dt_details = Pms_Bll.get_GSdetails(_obj_GSdetails);
        //if (dt_details.Rows.Count != 0)
        //{
        //    _obj_Spms_GoalStgKraDtls = new SPMS_GOALSETTINGKRADETAILS();
        //    _obj_Spms_GoalStgKraDtls.Mode = 7;
        //    _obj_Spms_GoalStgKraDtls.GS_KRA_GSDTL_ID = Convert.ToInt32(dt_details.Rows[0]["GSDTL_GS_ID"]);
        //    DataTable dt2 = Pms_Bll.get_GoalStgKraDtls(_obj_Spms_GoalStgKraDtls);

        //    if (dt2.Rows.Count != 0)
        //    {
        //        Rg_Appraisal_Kra.DataSource = dt2;
        //        Rg_Appraisal_Kra.DataBind();
        //        LOADAPPROVER();
        //        PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
        //        _obj_Pms_Appraisalcycle.MODE = 11;
        //        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
        //        DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

        //        _obj_Pms_Appraisalcycle.MODE = 8;
        //        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
        //        DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

        //        _obj_Spms_Appraisal = new SPMS_APPRAISAL();

        //        _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);

        //        _obj_Spms_Appraisal.Mode = 5;

        //        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);

        //        DataTable dtkra = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
        //        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtkra.Rows[0]["APPRAISAL_ID"]);
        //        _obj_Spms_AppraisalKra.Mode = 7;
        //        DataTable dt5 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
        //        rnt_KraAvgrtg.Value = Convert.ToInt32(dt5.Rows[0]["APP_KRA_MGR_RATING"]);

        //        rnt_KraAvgrtg.Enabled = false;
        //        Rm_Appraisal_PAGE.SelectedIndex = 0;
        //        Rm_Appraisal_Goal.Visible = true;
        //        Rg_Appraisal_Kra.Visible = true;
        //        Rg_Appraisal_Goal.Visible = true;//n
        //        Rm_Appraisal_Kra.Visible = true;
        //        Rp_Appraisal_VIEWDETAILS.Visible = true;
        //        Rm_Kra_Details.Visible = true;
        //        Rm_Appraisal_Kra.SelectedIndex = 0;
        //        Rm_Kra_Details.Visible = true;
        //    }
        //    else
        //    {
        //        Pms_Bll.ShowMessage(this, "No Kra Assigned");
        //        rcmb_BusinessUnitType.Enabled = true;
        //        rcmb_EmployeeType11.Enabled = true;
        //        Rm_Kra_Details.Visible = false;
        //        Rm_AppraisalDiscussion.Visible = false;

        //        Rm_Appraisal_Kra.Visible = false;

        //        return;
        //    }
        //}
        //else
        //{
        //    Pms_Bll.ShowMessage(this, "No Kra Available");
        //    rcmb_BusinessUnitType.Enabled = true;
        //    rcmb_EmployeeType11.Enabled = true;
        //    Rm_Kra_Details.Visible = false;
        //    Rm_AppraisalDiscussion.Visible = false;

        //    Rm_Appraisal_Kra.Visible = false;

        //    return;
        //}
    }
    #endregion

    #region LoadBusineeUnit
    /// <summary>
    /// I Am Loading Business uit values based on business unit id
    /// </summary>

    protected void LoadBusinessUnit()
    {
        try
        {
            rcmb_BusinessUnitType.Items.Clear();
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            DataTable dt = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnitType.DataSource = dt;// (DataTable)BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitType.DataBind();
            rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));


            //Rm_Appraisal_PAGE.SelectedIndex = 0;
            Rm_Appraisal_Kra.Visible = false;
            Rm_Appraisal_Goal.Visible = false;
            Rm_Kra_Details.Visible = false;
            Rm_AppraisalDiscussion.Visible = false;
            rtxt_GpMgr.Text = string.Empty;
            rtxt_RpMgr.Text = string.Empty;
            //rtxt_Project.Text = string.Empty;
            //rtxt_Role.Text = string.Empty;
            //rtxt_GpMgr.Enabled = true;
            //rtxt_RpMgr.Enabled = true;
            ////rtxt_Project.Enabled = true;
            //rcmb_EmployeeType11.Items.Clear();
            //rtxt_AppraisalCycle.Items.Clear();
            rtxt_AppraisalCycle.ClearSelection();
            rtxt_AppraisalCycle.Items.Clear();
            rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            rcmb_EmployeeType11.ClearSelection();
            rcmb_EmployeeType11.Items.Clear();
            rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
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

            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
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
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Loading Employee Details
    /// <summary>
    /// HERE I AM LOADING EMPLOYEE DETAILS WHEN BUSINESS UNIT COMBO BOX SELECT INDEX CHANGED EVENT FIRED
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>


    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            //_obj_Pms_Appraisalcycle.MODE = 8;
            //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



            //PMS_EMPSETUP _obj_Pms_EmpSetup;
            //_obj_Pms_EmpSetup = new PMS_EMPSETUP();
            //_obj_Pms_EmpSetup.Mode = 12;
            //_obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            //_obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
            //DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

            //rcmb_EmployeeType11.Items.Clear();
            //rcmb_EmployeeType11.DataSource = dt;
            //rcmb_EmployeeType11.DataTextField = "EMPLOYEE_NAME";
            //rcmb_EmployeeType11.DataValueField = "EMP_ID";
            //rcmb_EmployeeType11.DataBind();
            //rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                LoadAppraisalCycle();
                //PMS_EMPSETUP _obj_Pms_EmpSetup;
                //_obj_Pms_EmpSetup = new PMS_EMPSETUP();


                //_obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                //_obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                //SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                //_obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                //DataTable dt_buu = new DataTable();
                //dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                //_obj_Pms_Appraisalcycle.MODE = 8;
                //if (dt_buu.Rows.Count != 0)
                //{
                //    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);//Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //}
                //_obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                //DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //if (dtappid.Rows.Count != 0)
                //{
                //    _obj_Pms_EmpSetup.Mode = 12;
                //    if (dt_buu.Rows.Count != 0)
                //    {
                //        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value); //Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                //    }
                //    if (dtappid.Rows.Count != 0)
                //    {
                //        _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                //    }
                //    _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                //    DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                //    if (dt.Rows.Count != 0)
                //    {
                //        rcmb_EmployeeType11.DataSource = dt;
                //        rcmb_EmployeeType11.DataTextField = "EMPLOYEE_NAME";
                //        rcmb_EmployeeType11.DataValueField = "EMP_ID";
                //        rcmb_EmployeeType11.DataBind();
                //        rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_EmployeeType11.Enabled = true;

                //        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                //        {

                //            rcmb_EmployeeType11.Enabled = false;


                //        }

                //        else
                //        {
                //            rcmb_EmployeeType11.Enabled = true;
                //        }


                //    }
                //    else
                //    {
                //        DataTable dt5 = new DataTable();

                //        rcmb_EmployeeType11.DataSource = dt5;
                //        rcmb_EmployeeType11.DataBind();
                //        //lbl_BusinessUnitName.Visible = false;
                //        //rcmb_BusinessUnitType.Visible = false;
                //        //Pms_Bll.ShowMessage(this, "Approver Appraisal Has Not Done");
                //        rcmb_EmployeeType11.Enabled = false;

                //    }
                //}

                //else
                //{
                //    DataTable dt5 = new DataTable();

                //    rcmb_EmployeeType11.DataSource = dt5;
                //    rcmb_EmployeeType11.DataBind();
                //    //lbl_BusinessUnitName.Visible = false;
                //    //rcmb_BusinessUnitType.Visible = false;
                //    //Pms_Bll.ShowMessage(this, "Approver Appraisal Has Not Done");
                //    rcmb_EmployeeType11.Enabled = false;


                //}

                //Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_RpMgr.Text = string.Empty;
                //rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
            }
            else
            {
                //Pms_Bll.ShowMessage(this, "Please Select Employee");
                rcmb_EmployeeType11.ClearSelection();
                rcmb_EmployeeType11.Items.Clear();
                rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_AppraisalCycle.ClearSelection();
                rtxt_AppraisalCycle.Items.Clear();
                rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                //rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                rtxt_AppraisalCycle.Text = string.Empty;
                rtxt_AppraisalCycle.Enabled = true;
                Rm_AppraisalDiscussion.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rtxt_AppraisalCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rtxt_AppraisalCycle.SelectedIndex > 0)
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup;
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                _obj_pms_EmployeeSetup = new PMS_EMPSETUP();
                _obj_pms_EmployeeSetup.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_buu = new DataTable();
                dt_buu = BLL.get_Business_Units(_obj_smhr_logininfo);

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);//Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.Mode = 20;//12;
                    if (dt_buu.Rows.Count != 0)
                    {
                        _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value); //Convert.ToInt32(dt_buu.Rows[0]["BUSINESSUNIT_ID"]);
                    }
                    if (dtappid.Rows.Count != 0)
                    {
                        _obj_Pms_EmpSetup.GSLIFECYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Pms_EmpSetup.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);

                    if (dt.Rows.Count != 0)
                    {
                        rcmb_EmployeeType11.DataSource = dt;
                        rcmb_EmployeeType11.DataTextField = "EMPLOYEE_NAME";
                        rcmb_EmployeeType11.DataValueField = "EMP_ID";
                        rcmb_EmployeeType11.DataBind();
                        rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        //rcmb_BusinessUnitType.Visible = false;
                        //lbl_BusinessUnitName.Visible = false;
                        //rcmb_EmployeeType11.Enabled = true;

                        if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                        {

                            rcmb_EmployeeType11.Enabled = false;


                        }

                        else
                        {
                            rcmb_EmployeeType11.Enabled = true;
                        }


                    }
                    else
                    {
                        rcmb_EmployeeType11.ClearSelection();
                        rcmb_EmployeeType11.Items.Clear();
                        rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        rcmb_EmployeeType11.Enabled = false;

                    }
                }

                else
                {
                    rcmb_EmployeeType11.ClearSelection();
                    rcmb_EmployeeType11.Items.Clear();
                    rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    rcmb_EmployeeType11.Enabled = false;


                }

                //Rm_Appraisal_PAGE.SelectedIndex = 0;
                Rm_Appraisal_Kra.Visible = false;
                Rm_Appraisal_Goal.Visible = false;
                Rm_Kra_Details.Visible = false;
                Rm_AppraisalDiscussion.Visible = false;
                rtxt_GpMgr.Text = string.Empty;
                rtxt_RpMgr.Text = string.Empty;
                //rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
            }
            else
            {
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                //rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                Rm_AppraisalDiscussion.Visible = false;
                rcmb_EmployeeType11.ClearSelection();
                rcmb_EmployeeType11.Items.Clear();
                rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees()
    {
        try
        {
            _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_PMS_getemployee.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtbuid1 = Pms_Bll.get_GMEmployees(_obj_PMS_getemployee);
            if (dtbuid1.Rows.Count != 0)
            {
                rtxt_RpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["REPORTINGMANAGER"]);
                rtxt_GpMgr.Text = Convert.ToString(dtbuid1.Rows[0]["APPROVALMGR"]);
            }
            rcmb_EmployeeType11.Items.Clear();
            rcmb_EmployeeType11.DataSource = dtbuid1;
            rcmb_EmployeeType11.DataTextField = "employee";
            rcmb_EmployeeType11.DataValueField = "EMPID";
            rcmb_EmployeeType11.DataBind();
            rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //rcmb_BusinessUnitType.Visible = false;
            //lbl_BusinessUnitName.Visible = false;
            rtxt_RpMgr.Enabled = false;
            rtxt_GpMgr.Enabled = false;


            //rcmb_BusinessUnitType.Visible = false;
            //lbl_BusinessUnitName.Visible = false;
            rtxt_RpMgr.Enabled = false;
            rtxt_GpMgr.Enabled = false;

            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtem.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            //where i am getting apprisal cycle 


            PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
            _obj_GS.GS_MODE = 9;
            _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
            if (dtappid.Rows.Count != 0)
            {
                _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

            if (dt1.Rows.Count != 0)
            {
                //rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                //rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                //rtxt_Role.Enabled = false;
                //rtxt_Project.Enabled = false;
                rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                LBL_Appraise_Id.Text = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                rtxt_AppraisalCycle.Enabled = false;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    #endregion

    public void LOADAPPROVER()
    {
        //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
        //_obj_Pms_Appraisalcycle.MODE = 11;
        //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
        //DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

        //_obj_Pms_Appraisalcycle.MODE = 8;
        //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
        //DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


        //_obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //_obj_Spms_Appraisal.Mode = 11;
        //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
        //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
        //DataTable dtappraisal = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //_obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
        //_obj_Pms_AppApprover.Mode = 6;
        //_obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dtappraisal.Rows[0]["APPRAISAL_ID"]);
        //DataTable dtapprover = Pms_Bll.get_AppApprover(_obj_Pms_AppApprover);
        //txt_ApproverComments.Text=Convert.ToString(dtapprover.Rows[0]["APP_APPROVER_COMMENTS"]);
        //rnt_FinalRating.Value=Convert.ToInt32(dtapprover.Rows[0]["APP_APPROVER_RATING"]);
        //txt_ApproverComments.Enabled=false;
        //rnt_FinalRating.Enabled=false;
        //lnk_Idp.Visible=false;
        //lnk_Task.Visible=false;
        //btn_ApproverSubmit.Visible=false;



    }

    #region employee index changed

    protected void rcmb_EmployeeType11_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if ((rcmb_EmployeeType11.SelectedItem.Text == "Select"))
            {
                Pms_Bll.ShowMessage(this, "Please Select Employee");
                //rtxt_RpMgr.Enabled = true;
                //rtxt_GpMgr.Enabled = true;
                ////rtxt_Role.Enabled = true;
                ////rtxt_Project.Enabled = true;
                rtxt_RpMgr.Text = String.Empty;
                rtxt_GpMgr.Text = string.Empty;
                //rtxt_Role.Text = string.Empty;
                //rtxt_Project.Text = string.Empty;
                //rtxt_AppraisalCycle.Text = string.Empty;
                //rtxt_AppraisalCycle.Enabled = true;
                Rm_AppraisalDiscussion.Visible = false;
            }
            else
            {


                PMS_EMPSETUP _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
                _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

                DataTable dt_bu = BLL.get_Business_Units(_obj_smhr_logininfo);
                if (dt_bu.Rows.Count != 0)
                {
                    _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(dt_bu.Rows[0]["BUSINESSUNIT_ID"]);
                }

                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                _obj_Pms_EmpSetup.Mode = 6;
                _obj_Pms_EmpSetup.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DTREPO = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTREPO.Rows.Count != 0)
                {

                    rtxt_RpMgr.Text = Convert.ToString(DTREPO.Rows[0]["REPORTINGMGR_NAME"]);
                    rtxt_RpMgr.Enabled = false;

                }

                DataTable dtEmpPostn = BLL.Get_Emp_Position(Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value));
                if (dtEmpPostn.Rows.Count > 0)
                    rtxt_Position.Text = Convert.ToString(dtEmpPostn.Rows[0]["POSITIONS_CODE"]);

                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_EmpSetup.Mode = 7;
                DataTable DTgeneralmgr = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
                if (DTgeneralmgr.Rows.Count != 0)
                {
                    rtxt_GpMgr.Text = Convert.ToString(DTgeneralmgr.Rows[0]["GENERALMGR_NAME"]);
                    rtxt_GpMgr.Enabled = false;

                }

                PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtem.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                //where i am getting apprisal cycle 


                PMS_GoalSettings _obj_GS = new PMS_GoalSettings();
                _obj_GS.GS_MODE = 9;
                _obj_GS.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                if (dtappid.Rows.Count != 0)
                {
                    _obj_GS.GS_APPRAISAL_CYCLE = Convert.ToString(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToString(dtappid.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt1 = Pms_Bll.get_GS(_obj_GS);

                if (dt1.Rows.Count != 0)
                {
                    //rtxt_Role.Text = Convert.ToString(dt1.Rows[0]["ROLE_NAMES"]);
                    //rtxt_Project.Text = Convert.ToString(dt1.Rows[0]["PROJECT_NAME"]);
                    //rtxt_AppraisalCycle.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_NAME"]);
                    //LBL_Appraise_Id.Text = Convert.ToString(dt1.Rows[0]["APPRCYCLE_ID"]);
                    //rtxt_Role.Enabled = false;
                    //rtxt_Project.Enabled = false;
                    //rtxt_AppraisalCycle.Enabled = false;


                }
                else
                {

                }






                Session["empid"] = rcmb_EmployeeType11.SelectedItem.Value;
                lnk_Idp.OnClientClick = " openRadWin('frm_idp.aspx'); return false;";
                lnk_Task.OnClientClick = " openRadWin('frm_Pms_Task.aspx'); return false;";

                lbl_ApproverComments.Visible = true;
                txt_ApproverComments.Visible = true;
                lbl_FinalRating.Visible = true;
                rnt_FinalRating.Visible = true;
                Rg_Appraisal_Goal.Enabled = true;

                btn_Cancel.Visible = true;

                lbl_KraAvgRtg.Visible = false;
                lbl_GoalAvgRtg.Visible = false;
                rnt_GoalAvgrtg.Visible = false;
                rnt_KraAvgrtg.Visible = false;


                Rg_Appraisal_Kra.Enabled = true;
                txt_ApproverComments.Enabled = false;
                rnt_FinalRating.Enabled = false;
                btn_ApproverSubmit.Enabled = true;


                lbl_KraAvgRtg.Enabled = true;

                //rdtp_DateofDiscussion.SelectedDate = null;
                rtxt_EmployeeCommentsAppDiscussion.Text = string.Empty;
                rtxt_MgrCommentsAppDiscussion.Text = string.Empty;

                Rm_Appraisal_Goal.Enabled = true;
                Rg_Appraisal_Goal.Enabled = true;
                lbl_GoalAvgRtg.Enabled = true;
                rnt_GoalAvgrtg.Enabled = false;
                rnt_KraAvgrtg.Enabled = false;

                Rg_Appraisal_Goal.Visible = false;
                Rg_Appraisal_Kra.Visible = false;
                lnk_Task.Visible = true;
                Rm_Kra_Details.Visible = false;

                Rm_AppraisalDiscussion.Visible = true;




                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz2.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz2.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz2 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.Mode = 37;
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                if (dtappidzz2.Rows.Count != 0)
                {

                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt15 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                if (dt15.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Already Appraisal Status Done");
                    //btn_Save.Visible = false;
                    //btn_Cancel.Visible = false;
                    //rtxt_EmployeeCommentsAppDiscussion.Enabled = false;
                    //rtxt_MgrCommentsAppDiscussion.Enabled = false;


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 23;
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                    if (dtappidzz2.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);//Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt12 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    if (dt12.Rows.Count != 0)
                    {
                        rtxt_EmployeeCommentsAppDiscussion.Text = Convert.ToString(dt12.Rows[0]["APP_DISCUSSION_EMP_COMMENTS"]);
                        rtxt_MgrCommentsAppDiscussion.Text = Convert.ToString(dt12.Rows[0]["APP_DISCUSSION_MGR_COMMENTS"]);
                        rdtp_DateofDiscussion.SelectedDate = Convert.ToDateTime(dt12.Rows[0]["APP_DISCUSSION_DATE"]);
                        rtxt_EmployeeCommentsAppDiscussion.Enabled = false;
                        rtxt_MgrCommentsAppDiscussion.Enabled = false;
                        rdtp_DateofDiscussion.Enabled = false;
                        btn_Save.Visible = false;
                        btn_Cancel.Visible = false;

                    }
                    else
                    {
                        btn_Save.Visible = false;
                        btn_Cancel.Visible = false;
                        rtxt_EmployeeCommentsAppDiscussion.Enabled = false;
                        rtxt_MgrCommentsAppDiscussion.Enabled = false;


                    }
                }

                else
                {




                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 23;
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                    if (dtappidzz2.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappidzz2.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt12 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (dt12.Rows.Count != 0)
                    {
                        rtxt_EmployeeCommentsAppDiscussion.Text = Convert.ToString(dt12.Rows[0]["APP_DISCUSSION_EMP_COMMENTS"]);
                        rtxt_MgrCommentsAppDiscussion.Text = Convert.ToString(dt12.Rows[0]["APP_DISCUSSION_MGR_COMMENTS"]);
                        rdtp_DateofDiscussion.SelectedDate = Convert.ToDateTime(dt12.Rows[0]["APP_DISCUSSION_DATE"]);
                        rtxt_EmployeeCommentsAppDiscussion.Enabled = false;
                        rtxt_MgrCommentsAppDiscussion.Enabled = false;
                        rdtp_DateofDiscussion.Enabled = false;
                        btn_Save.Visible = false;
                        btn_Cancel.Visible = false;

                        Pms_Bll.ShowMessage(this, "Already Appraisal Discussion Done");
                    }
                    else
                    {
                        rtxt_EmployeeCommentsAppDiscussion.Text = string.Empty;
                        rtxt_MgrCommentsAppDiscussion.Text = string.Empty;
                        //rdtp_DateofDiscussion.SelectedDate = null;
                        rtxt_EmployeeCommentsAppDiscussion.Enabled = true;
                        rtxt_MgrCommentsAppDiscussion.Enabled = true;
                        rdtp_DateofDiscussion.Enabled = false;
                        btn_Save.Visible = true;
                        btn_Cancel.Visible = true;
                    }

                }


            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Loadgoal,kraDetails

    /// <summary>
    /// Here i am loading grid based on emploee selecteion task grid will be displayed
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>

    protected void rcmb_feedback_indexchanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    #endregion

    #region Rg_Appraisal Goal commands

    protected void Rg_Appraisal_Goal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Label lblgsdt_id = new System.Web.UI.WebControls.Label();


        //Label lblappraisaldtl = new System.Web.UI.WebControls.Label();
        //int i = Convert.ToInt32(e.CommandArgument);

        //lblgsdt_id = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_Id") as Label;
        //lblappraisaldtl = Rg_Appraisal_Goal.Rows[i].FindControl("lbl_Goal_AppraisalCycle") as Label;
        //TextBox txtempfeed = new System.Web.UI.WebControls.TextBox();
        //Button btnsubmitempfeed = new System.Web.UI.WebControls.Button();
        //Button btncancelempfeed = new System.Web.UI.WebControls.Button();
        //txtempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalEmployeeFeedback") as TextBox;
        //btnsubmitempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpSubmit") as Button;
        //btncancelempfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalEmpCancel") as Button;


        //TextBox txtmgrfeed = new System.Web.UI.WebControls.TextBox();
        //Button btnsubmitmgrfeed = new System.Web.UI.WebControls.Button();
        //Button btncancelmgrfeed = new System.Web.UI.WebControls.Button();
        //RadRating rdratingmgr = new Telerik.Web.UI.RadRating();
        //txtmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("txt_GoalManagerFeedback") as TextBox;
        //btnsubmitmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrSubmit") as Button;
        //btncancelmgrfeed = Rg_Appraisal_Goal.Rows[i].FindControl("btn_GoalMgrCancel") as Button;
        //rdratingmgr = Rg_Appraisal_Goal.Rows[i].FindControl("rdrtg_GoalMgr") as RadRating;

        //#region Employee Feedback


        //if (e.CommandName == "GoalEmployee_Feed")
        //{
        //    _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();

        //    _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
        //    _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = 0;
        //    _obj_Spms_AppraisalGoal.Mode = 5;
        //    DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

        //    if (dtgoal.Rows.Count != 0)
        //    {
        //        txtempfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_EMP_COMMENTS"]);

        //        if (txtempfeed.Visible == true)
        //        {

        //            txtempfeed.Visible = false;


        //        }
        //        else
        //        {

        //            txtempfeed.Visible = true;
        //            txtempfeed.Enabled = false;

        //        }
        //    }
        //    else
        //    {

        //        if (txtempfeed.Visible == true)
        //        {

        //            txtempfeed.Visible = false;


        //        }
        //        else
        //        {

        //            txtempfeed.Visible = true;
        //            txtempfeed.Enabled = false;

        //        }



        //    }
        //}
        //#endregion


        //#region Manager Feedback
        //else if (e.CommandName == "GoalMgr_Feed")
        //{

        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);

        //    _obj_Spms_Appraisal.Mode = 5;
        //    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
        //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);

        //    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //    if (dtg.Rows.Count != 0)
        //    {
        //        _obj_Spms_AppraisalGoal = new SPMS_APPRAISALGOAL();
        //        _obj_Spms_AppraisalGoal.APP_GOALS_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);


        //        _obj_Spms_AppraisalGoal.APP_GOALS_GSDTL_ID = Convert.ToInt32(lblgsdt_id.Text);
        //        _obj_Spms_AppraisalGoal.Mode = 8;
        //        DataTable dtgoal = Pms_Bll.get_AppraisalGoal(_obj_Spms_AppraisalGoal);

        //        if (dtgoal.Rows.Count != 0)
        //        {

        //            txtmgrfeed.Text = Convert.ToString(dtgoal.Rows[0]["APP_GOALS_MGR_COMMENTS"]);


        //            rdratingmgr.Value = Convert.ToInt32(dtgoal.Rows[0]["APP_GOALS_MGR_RATING"]);



        //            txtmgrfeed.Enabled = false;
        //            if (txtmgrfeed.Visible == true)
        //            {

        //                rdratingmgr.Visible = false;
        //                txtmgrfeed.Visible = false;

        //                btnsubmitmgrfeed.Visible = false;
        //                btncancelmgrfeed.Visible = false;
        //            }
        //            else
        //            {

        //                rdratingmgr.Visible = true;
        //                txtmgrfeed.Visible = true;
        //                btnsubmitmgrfeed.Visible = false;
        //                btncancelmgrfeed.Visible = false;

        //            }



        //        }

        //        else
        //        {
        //            if (txtmgrfeed.Visible == true)
        //            {

        //                rdratingmgr.Visible = false;
        //                txtmgrfeed.Visible = false;
        //                btnsubmitmgrfeed.Visible = false;
        //                btncancelmgrfeed.Visible = false;
        //            }
        //            else
        //            {

        //                rdratingmgr.Visible = true;
        //                txtmgrfeed.Visible = true;

        //                btnsubmitmgrfeed.Visible = false;
        //                btncancelmgrfeed.Visible = false;
        //            }


        //        }

        //    }
        //}
    }
    //#endregion

    #endregion

    #region Rg_Appraisal Kra Commands


    protected void Rg_Appraisal_Kra_Command(object sender, GridViewCommandEventArgs e)
    {
        //Label lblkradt_id = new System.Web.UI.WebControls.Label();
        //Label lblappraisalKradtl = new System.Web.UI.WebControls.Label();
        //int i = Convert.ToInt32(e.CommandArgument);

        //lblkradt_id = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_Id") as Label;
        //lblappraisalKradtl = Rg_Appraisal_Kra.Rows[i].FindControl("lbl_Kra_AppraisalCycle") as Label;
        //TextBox txtKraEmployeeFeedback = new System.Web.UI.WebControls.TextBox();
        //Button btnKraEmpSubmit = new System.Web.UI.WebControls.Button();
        //Button btnKraEmpCancel = new System.Web.UI.WebControls.Button();
        //txtKraEmployeeFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraEmployeeFeedback") as TextBox;
        //btnKraEmpSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpSubmit") as Button;
        //btnKraEmpCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraEmpCancel") as Button;

        //TextBox txtKraManagerFeedback = new System.Web.UI.WebControls.TextBox();
        //Button btnKraMgrSubmit = new System.Web.UI.WebControls.Button();
        //Button btnKraMgrCancel = new System.Web.UI.WebControls.Button();
        //RadRating rdrtgKraMgr = new Telerik.Web.UI.RadRating();
        //txtKraManagerFeedback = Rg_Appraisal_Kra.Rows[i].FindControl("txt_KraManagerFeedback") as TextBox;
        //btnKraMgrSubmit = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrSubmit") as Button;
        //btnKraMgrCancel = Rg_Appraisal_Kra.Rows[i].FindControl("btn_KraMgrCancel") as Button;
        //rdrtgKraMgr = Rg_Appraisal_Kra.Rows[i].FindControl("rdrtg_KraMgr") as RadRating;

        //#region Employee Kra Feedback


        //if (e.CommandName == "KraEmployee_Feed")
        //{

        //    _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
        //    _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
        //    _obj_Spms_AppraisalKra.Mode = 5;
        //    DataTable dtKra = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);
        //    if (dtKra.Rows.Count != 0)
        //    {
        //        txtKraEmployeeFeedback.Text = Convert.ToString(dtKra.Rows[0]["APP_KRA_EMP_COMMENTS"]);

        //        if (txtKraEmployeeFeedback.Visible == true)
        //        {
        //            txtKraEmployeeFeedback.Visible = false;


        //        }
        //        else
        //        {
        //            txtKraEmployeeFeedback.Visible = true;

        //            txtKraEmployeeFeedback.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        if (txtKraEmployeeFeedback.Visible == true)
        //        {
        //            txtKraEmployeeFeedback.Visible = false;


        //        }
        //        else
        //        {
        //            txtKraEmployeeFeedback.Visible = true;

        //            txtKraEmployeeFeedback.Enabled = false;
        //        }
        //    }
        //}
        //#endregion



        //#region Manager Kra Feedback
        //else if (e.CommandName == "KraMgr_Feed")
        //{
        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);

        //    _obj_Spms_Appraisal.Mode = 5;
        //    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 2;
        //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);

        //    DataTable dtg = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
        //    if (dtg.Rows.Count != 0)
        //    {
        //        _obj_Spms_AppraisalKra = new SPMS_APPRAISALKRA();
        //        _obj_Spms_AppraisalKra.APP_KRA_APP_ID = Convert.ToInt32(dtg.Rows[0]["APPRAISAL_ID"]);

        //        _obj_Spms_AppraisalKra.APP_KRA_KRA_ID = Convert.ToInt32(lblkradt_id.Text);
        //        _obj_Spms_AppraisalKra.Mode = 8;
        //        DataTable dtKra1 = Pms_Bll.get_AppraisalKra(_obj_Spms_AppraisalKra);

        //        if (dtKra1.Rows.Count != 0)
        //        {
        //            txtKraManagerFeedback.Text = Convert.ToString(dtKra1.Rows[0]["APP_KRA_MGR_COMMENTS"]);
        //            rdrtgKraMgr.Value = Convert.ToInt32(dtKra1.Rows[0]["APP_KRA_MGR_RATING"]);

        //            txtKraManagerFeedback.Enabled = false;
        //            rdrtgKraMgr.Enabled = false;
        //            if (txtKraManagerFeedback.Visible == true)
        //            {

        //                rdrtgKraMgr.Visible = false;
        //                txtKraManagerFeedback.Visible = false;
        //                btnKraMgrSubmit.Visible = false;
        //                btnKraMgrCancel.Visible = false;
        //            }
        //            else
        //            {
        //                rdrtgKraMgr.Visible = true;
        //                txtKraManagerFeedback.Visible = true;
        //                btnKraMgrSubmit.Visible = false;
        //                btnKraMgrCancel.Visible = false;
        //            }
        //        }

        //        else
        //        {
        //            if (txtKraManagerFeedback.Visible == true)
        //            {
        //                rdrtgKraMgr.Visible = false;
        //                txtKraManagerFeedback.Visible = false;
        //                btnKraMgrSubmit.Visible = false;
        //                btnKraMgrCancel.Visible = false;
        //            }
        //            else
        //            {
        //                rdrtgKraMgr.Visible = true;
        //                txtKraManagerFeedback.Visible = true;
        //                btnKraMgrSubmit.Visible = false;
        //                btnKraMgrCancel.Visible = false;
        //            }

        //        }
        //    }
        //}
    }
    //#endregion



    #endregion


    #region Approver Submit Method

    protected void btn_ApproverSubmit_Click(object sender, EventArgs e)
    {


        //_obj_Spms_Appraisal = new SPMS_APPRAISAL();

        //_obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
        //_obj_Spms_Appraisal.APPRAISAL_DATE = DateTime.Now;
        //_obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = 1;
        //_obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 8;//FOR APPROVER SUBMIT
        //_obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);
        //_obj_Spms_Appraisal.APPRAISAL_CREATEDBY = 1;
        //_obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;

        //_obj_Spms_Appraisal.Mode = 4;
        //bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
        //if (status == true)
        //{

        //    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

        //    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
        //    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 8;
        //    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(LBL_Appraise_Id.Text);


        //    _obj_Spms_Appraisal.Mode = 5;

        //    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

        //    _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
        //    _obj_Pms_AppApprover.APP_APPROVER_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
        //    _obj_Pms_AppApprover.Mode = 3;
        //    _obj_Pms_AppApprover.APP_APPROVER_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(txt_ApproverComments.Text));
        //    _obj_Pms_AppApprover.APP_APPROVER_RATING = Convert.ToInt32(rnt_FinalRating.Value);
        //    _obj_Pms_AppApprover.APP_APPROVER_CREATEDBY = 1;
        //    _obj_Pms_AppApprover.APP_APPROVER_CREATEDDATE = DateTime.Now;

        //    bool status1 = Pms_Bll.set_AppApprover(_obj_Pms_AppApprover);
        //    if (status1 == true)
        //    {
        //        Pms_Bll.ShowMessage(this, "Approver Comments Inserted Successfully");

        //        rcmb_BusinessUnitType.Enabled = false;
        //        rcmb_EmployeeType11.Enabled = true;

        //        btn_Cancel.Visible = false;
        //        lbl_KraAvgRtg.Enabled = false;
        //        rnt_KraAvgrtg.Enabled = false;
        //        Rg_Appraisal_Kra.Enabled = false;
        //        Rm_Appraisal_Goal.Enabled = false;



        //        rcmb_EmployeeType11.ClearSelection();
        //        DataTable dt = new DataTable();
        //        rcmb_EmployeeType11.DataSource = dt;
        //        rcmb_EmployeeType11.DataBind();
        //        Rm_Appraisal_PAGE.SelectedIndex = 0;
        //        Rm_Appraisal_Kra.Visible = false;
        //        Rm_Appraisal_Goal.Visible = false;
        //        Rm_Kra_Details.Visible = false;
        //        Rm_AppraisalDiscussion.Visible = false;

        //        rtxt_RpMgr.Text = string.Empty;
        //        rtxt_GpMgr.Text = string.Empty;
        //        rcmb_BusinessUnitType.Enabled = true;
        //        rcmb_EmployeeType11.Enabled = true;
        //        rtxt_RpMgr.Enabled = true;
        //        rtxt_GpMgr.Enabled = true;
        //        //rtxt_Role.Enabled = true;
        //        //rtxt_Project.Enabled = true;
        //        rtxt_AppraisalCycle.Enabled = true;
        //        //rtxt_Role.Text = string.Empty;
        //        //rtxt_Project.Text = string.Empty;
        //        rtxt_AppraisalCycle.Text = string.Empty;


        //        return;
        //    }
        //}

    }

    #endregion

    protected void btn_ApproverCancel_Click1(object sender, EventArgs e)
    {

        //rcmb_EmployeeType11.ClearSelection();
        //DataTable dt = new DataTable();
        //rcmb_EmployeeType11.DataSource = dt;
        //rcmb_EmployeeType11.DataBind();
        //Rm_Appraisal_PAGE.SelectedIndex = 0;
        //Rm_Appraisal_Kra.Visible = false;
        //Rm_Appraisal_Goal.Visible = false;
        //Rm_Kra_Details.Visible = false;
        //Rm_AppraisalDiscussion.Visible = false;

        //rtxt_RpMgr.Text = string.Empty;
        //rtxt_GpMgr.Text = string.Empty;



    }

    #region appdisc save click

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {



            PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 11;
            _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

            _obj_Pms_Appraisalcycle.MODE = 8;
            if (dtemzz.Rows.Count != 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtappidzz = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
            _obj_Spms_Appraisal.Mode = 12;
            if (dtappidzz.Rows.Count != 0)
            {
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz.Rows[0]["APPRCYCLE_ID"]);
            }
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtcheck = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

            if (dtcheck.Rows.Count != 0)
            {
                Pms_Bll.ShowMessage(this, "Approver Discussion Already Finalised");

            }
            else
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtemzz01F = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                _obj_Pms_Appraisalcycle.MODE = 8;
                if (dtemzz01F.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzz01F.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                }
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtappidzz1F = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                _obj_Spms_Appraisal.Mode = 27;
                if (dtappidzz1F.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzz1F.Rows[0]["APPRCYCLE_ID"]);
                }
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtapp_id = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_DATE = DateTime.Now;
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 9;//FOR APPROVER SUBMIT
                _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value); //Convert.ToInt32(LBL_Appraise_Id.Text);
                _obj_Spms_Appraisal.APPRAISAL_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                _obj_Spms_Appraisal.APPRAISAL_STATUS = 4;
                _obj_Spms_Appraisal.APPRAISAL_CREATEDDATE = DateTime.Now;
                if (dtapp_id.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtapp_id.Rows[0]["APPRAISAL_ID"]);
                }
                _obj_Spms_Appraisal.Mode = 6;

                bool status = Pms_Bll.set_Appraisal(_obj_Spms_Appraisal);
                if (status == true)
                {
                    _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);//where i am passing employee to get bunit
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtemzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Pms_Appraisalcycle.MODE = 8;
                    if (dtemzzl.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzl.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    }
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dtappidzzl = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();

                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPROVALSTAGE = 9;
                    if (dtappidzzl.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rtxt_AppraisalCycle.SelectedItem.Value);// Convert.ToInt32(dtappidzzl.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Spms_Appraisal.Mode = 5;

                    DataTable dtgoal1 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    _obj_Pms_AppApprover = new SPMS_APRAISALAPPROVER();
                    _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
                    if (dtgoal1.Rows.Count != 0)
                    {
                        _obj_Pms_AppDiscDtls.APP_DISCUSSION_APP_ID = Convert.ToInt32(dtgoal1.Rows[0]["APPRAISAL_ID"]);
                    }
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_EMP_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_EmployeeCommentsAppDiscussion.Text));
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_MGR_COMMENTS = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_MgrCommentsAppDiscussion.Text));
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_DATE = rdtp_DateofDiscussion.SelectedDate.Value;
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDBY = Convert.ToInt32(Session["user_id"]);
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_CREATEDDATE = DateTime.Now;
                    _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_AppDiscDtls.Mode = 3;
                    bool status1 = Pms_Bll.set_AppDiscDtls(_obj_Pms_AppDiscDtls);
                    if (status1 == true)
                    {

                        //SPMS_EMPGOALSETTING _obj_Pms_EmpGoalSetting = new SPMS_EMPGOALSETTING();
                        //_obj_Pms_EmpGoalSetting.Mode = 14;
                        //_obj_Pms_EmpGoalSetting.GS_APPRAISAL_CYCLE = Convert.ToString(dtappidzzl.Rows[0]["APPRCYCLE_ID"]);
                        //_obj_Pms_EmpGoalSetting.GS_EMP_ID = Convert.ToInt32(rcmb_EmployeeType11.SelectedItem.Value);
                        //bool status5 = Pms_Bll.set_EmpGoalSetting(_obj_Pms_EmpGoalSetting);
                        //Pms_Bll.ShowMessage(this, "GoalSetting Completed");

                        LoadBusinessUnit();
                        //rcmb_EmployeeType11.ClearSelection();
                        //DataTable dt9 = new DataTable();
                        //rcmb_EmployeeType11.DataSource = dt9;
                        //rcmb_EmployeeType11.DataBind();
                        //rcmb_EmployeeType11.SelectedIndex = 0;
                        rcmb_EmployeeType11.Enabled = true;
                        rcmb_BusinessUnitType.Enabled = true;

                        Rm_Appraisal_PAGE.SelectedIndex = 0;
                        Rm_Appraisal_Kra.Visible = false;
                        Rm_Appraisal_Goal.Visible = false;
                        Rm_Kra_Details.Visible = false;
                        Rm_AppraisalDiscussion.Visible = false;
                        rtxt_GpMgr.Enabled = true;
                        rtxt_RpMgr.Enabled = true;
                        rtxt_RpMgr.Text = string.Empty;
                        rtxt_GpMgr.Text = string.Empty;
                        //rtxt_Role.Enabled = true;
                        //rtxt_Project.Enabled = true;
                        rtxt_AppraisalCycle.Enabled = true;
                        //rtxt_Role.Text = string.Empty;
                        //rtxt_Project.Text = string.Empty;
                        //rtxt_AppraisalCycle.Text = string.Empty;
                        rcmb_EmployeeType11.ClearSelection();
                        rcmb_EmployeeType11.Items.Clear();
                        rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        rtxt_AppraisalCycle.ClearSelection();
                        rtxt_AppraisalCycle.Items.Clear();
                        rtxt_AppraisalCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                        Pms_Bll.ShowMessage(this, "Appraisal Discussion given Successfully");
                        return;
                    }



                }





            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region appdisc cancel

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_EmployeeType11.ClearSelection();
            //DataTable dt = new DataTable();
            //rcmb_EmployeeType11.DataSource = dt;
            //rcmb_EmployeeType11.DataBind();
            //rcmb_EmployeeType11.SelectedIndex = 0;
            Rm_Appraisal_PAGE.SelectedIndex = 0;
            Rm_Appraisal_Kra.Visible = false;
            Rm_Appraisal_Goal.Visible = false;
            Rm_Kra_Details.Visible = false;
            Rm_AppraisalDiscussion.Visible = false;

            rtxt_RpMgr.Text = string.Empty;
            rtxt_GpMgr.Text = string.Empty;
            //rtxt_Role.Enabled = true;
            //rtxt_Project.Enabled = true;
            rtxt_AppraisalCycle.Enabled = true;
            //rtxt_Role.Text = string.Empty;
            //rtxt_Project.Text = string.Empty;
            rtxt_AppraisalCycle.Text = string.Empty;

            rcmb_EmployeeType11.ClearSelection();
            rcmb_EmployeeType11.Items.Clear();
            rcmb_EmployeeType11.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            LoadBusinessUnit();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsAppraisalDiscussion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

}
