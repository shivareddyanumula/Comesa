using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SPMS;
using Telerik.Web.UI;
using SMHR;

public partial class PMS_frm_Task : System.Web.UI.Page
{

    DataTable dtbuid = new DataTable();
    SPMS_TASK _obj_Pms_Task;
    PMS_GETEMPLOYEE _obj_PMS_getemployee;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SPMS_GOALSETTING _obj_Pms_GoalSetting;
    PMS_GoalSettings _obj_GS;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
    protected void Page_Load(object sender, EventArgs e)
    {try
        {
        Page.Validate();
        if (!Page.IsPostBack)
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("TASK");
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

            //LoadGoal();

            LoadGrid();
            Rp_TASK_VIEWMAIN.Visible = true;
            Rp_TASK_VIEWDETAILS.Visible = false;
            //rdtp_DATE.MinDate = DateTime.Now;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                Rg_Task.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;



            }

        }

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }

    #region Add Command

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
        clearControls();

        btn_Save.Visible = true;
        btn_cancel.Visible = true;
        btn_Save.Text = "Save";
        btn_cancel.Text = "Cancel";
        rtxt_TaskName.Enabled = true;
        LoadBusinessUnit();
        rcmb_EmployeeType.Enabled = true;
        rcmb_BusinessUnitType.Enabled = true;
        //rcmb_BusinessUnitType.SelectedIndex = -1;
        //LoadGoal();
        Rm_TASK_PAGE.SelectedIndex = 1;
        Rp_TASK_VIEWDETAILS.Visible = true;
        Rp_TASK_VIEWMAIN.Visible = false;
        //lbl_BusinessUnitName.Visible = false;
        //rcmb_BusinessUnitType.Visible = false;
        rcmb_GoalType.Enabled = true;
        rdtp_DATE.Enabled = true;
        rcm_apprcycle.SelectedIndex = 0;
        //PMS_EMPSETUP _obj_Pms_EmpSetup;
        //_obj_Pms_EmpSetup = new PMS_EMPSETUP();

        //_obj_PMS_getemployee = new PMS_GETEMPLOYEE();

        //if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
        //{
        //    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        //}
        //else
        //{
        //    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

        //}
        //_obj_PMS_getemployee.Mode = 1;
        //_obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
        //dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);


        //if (dtbuid.Rows.Count != 0)
        //{
        //    rcmb_EmployeeType.Items.Clear();
        //    rcmb_EmployeeType.DataSource = dtbuid;
        //    rcmb_EmployeeType.DataTextField = "employee";
        //    rcmb_EmployeeType.DataValueField = "EMPID";
        //    rcmb_EmployeeType.DataBind();
        //    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        //    //rcmb_BusinessUnitType.Visible = false;
        //    //lbl_BusinessUnitName.Visible = false;
        //}
        //else
        //{
        //    DataTable dt1 = new DataTable();

        //    rcmb_EmployeeType.DataSource = dt1;
        //    rcmb_EmployeeType.DataBind();
        //    //lbl_BusinessUnitName.Visible = false;
        //    //rcmb_BusinessUnitType.Visible = false;


        //}
        //rcmb_EmployeeType.SelectedIndex = 0;
        ////lbl_BusinessUnitName.Visible = false;
        ////rcmb_BusinessUnitType.Visible = false;
        //rcm_apprcycle.Enabled = true;

        //DataTable dt2 = new DataTable();

        //rcm_apprcycle.DataSource = dt2;
        //rcm_apprcycle.DataBind();
        //rcmb_GoalType.DataSource = dt2;
        //rcmb_GoalType.DataBind();
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    /// <summary>
    ///IN THIS CLEAR CONTROLS METHOD I AM MAKING ALL CONTROLS FIELDS AS NULL
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void clearControls()
    {
        try
        {
            lbl_Task_Id.Text = string.Empty;
            rcmb_BusinessUnitType.SelectedIndex = 0;
            //rcmb_EmployeeType.SelectedIndex = 0;
            rcmb_GoalType.SelectedIndex = 0;
            rtxt_TaskName.Text = string.Empty;
            rtxt_TaskDescription.Text = string.Empty;
            rdtp_DATE.SelectedDate = null;
            btn_Save.Visible = false;
            Rm_TASK_PAGE.SelectedIndex = 0;

            rcmb_GoalType.ClearSelection();
            rcmb_GoalType.Items.Clear();
            rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_EmployeeType.ClearSelection();
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcm_apprcycle.ClearSelection();
            rcm_apprcycle.Items.Clear();
            rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }



    #endregion

    #region LoadGoals
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadGoal()
    { try
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

                rcmb_GoalType.Items.Clear();
                 _obj_Pms_GoalSetting = new SPMS_GOALSETTING();
                _obj_Pms_GoalSetting.Mode = 10;
                _obj_Pms_GoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_GoalSetting.GSDTL_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);//i am passing employee
                _obj_Pms_GoalSetting.BU_ID = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);//i am passing apprycle cycle value
                DataTable dt = Pms_Bll.get_GoalSetting(_obj_Pms_GoalSetting);
                if (dt.Rows.Count != 0)
                {
                    rcmb_GoalType.DataSource = dt;
                    rcmb_GoalType.DataTextField = "GSDTL_NAME";
                    rcmb_GoalType.DataValueField = "GSDTL_ID";
                    rcmb_GoalType.DataBind();
                    rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    DataTable dt44 = new DataTable();
                    rcmb_GoalType.DataSource = dt44;
                    rcmb_GoalType.DataBind();
                    rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                }
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Employee Is Not Under Active Appraisal");
                DataTable dt441 = new DataTable();
                rcmb_GoalType.DataSource = dt441;
                rcmb_GoalType.DataBind();
                rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        else
        {
            Pms_Bll.ShowMessage(this, "Employee Is Inactive");
            DataTable dt441 = new DataTable();
            rcmb_GoalType.DataSource = dt441;
            rcmb_GoalType.DataBind();
            rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }

        }

    catch (Exception ex)
    {
        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
        Response.Redirect("~/Frm_ErrorPage.aspx");
    }
    }
    #endregion



    #region LoadGoals
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadGoal1()
    {
        try
        {
         _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
        _obj_Pms_Appraisalcycle.MODE = 11;
        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["empid1"]);//where i am passing employee to get bunit
        DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
        if(dtem.Rows.Count !=0)
        {
        _obj_Pms_Appraisalcycle.MODE = 8;
        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);
        DataTable dtappid = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
        if (dtappid.Rows.Count != 0)
        {

            rcmb_GoalType.Items.Clear();
            SPMS_GOALSETTING _obj_Pms_GoalSetting = new SPMS_GOALSETTING();
            _obj_Pms_GoalSetting.Mode = 10;
            _obj_Pms_GoalSetting.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_GoalSetting.GSDTL_ID = Convert.ToInt32(Session["empid1"]);//i am passing employee
            _obj_Pms_GoalSetting.BU_ID = Convert.ToInt32(dtappid.Rows[0]["APPRCYCLE_ID"]);//i am passing apprycle cycle value
            DataTable dt = Pms_Bll.get_GoalSetting(_obj_Pms_GoalSetting);
            if (dt.Rows.Count != 0)
            {
                rcmb_GoalType.DataSource = dt;
                rcmb_GoalType.DataTextField = "GSDTL_NAME";
                rcmb_GoalType.DataValueField = "GSDTL_ID";
                rcmb_GoalType.DataBind();
                rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt44 = new DataTable();
                rcmb_GoalType.DataSource = dt44;
                rcmb_GoalType.DataBind();
                rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }

        else
        {
            Pms_Bll.ShowMessage(this, "Employee Is Not Under Active Appraisal");
            DataTable dt44 = new DataTable();
            rcmb_GoalType.DataSource = dt44;
            rcmb_GoalType.DataBind();
            rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        }

        else
        { Pms_Bll.ShowMessage(this,"Employee Is Inactive");
             DataTable dt44 = new DataTable();
            rcmb_GoalType.DataSource = dt44;
            rcmb_GoalType.DataBind();
            rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }

         }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    #region LoadAppraisalcycle
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadAppraisalCycle()
    {
        try
        {
            //PMS_Appraisalcycle _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            //_obj_Pms_Appraisalcycle.MODE = 11;
            //_obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
            //DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);


            //_obj_Pms_Appraisalcycle.MODE = 7;
            //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);

            // _obj_GS = new PMS_GoalSettings();
            //_obj_GS.GS_MODE = 22;
            //_obj_GS.GS_EMP_ID=Convert.ToInt32((rcmb_EmployeeType.SelectedItem.Value));

            //_obj_GS.GS_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt = Pms_Bll.get_GS(_obj_GS);
            //if (dt.Rows.Count != 0)
            //{
            //    rcm_apprcycle.DataSource = dt;
            //    rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
            //    rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
            //    rcm_apprcycle.DataBind();
            //    rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //}
            //else
            //{
            //    DataTable dt44 = new DataTable();
            //    rcm_apprcycle.DataSource = dt44;
            //    rcm_apprcycle.DataBind();
            //    rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            //}
            rcm_apprcycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();

            _obj_Pms_Appraisalcycle.MODE = 9;
            if (Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value) > 0)
            {
                //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dt.Rows[0]["BUSINESSUNIT_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
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
                rcm_apprcycle.DataSource = DT_AppraisalCycle;
                rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
                rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
                rcm_apprcycle.DataBind();
                rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt6 = new DataTable();

                rcm_apprcycle.DataSource = dt6;

                rcm_apprcycle.DataBind();
                rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadAppraisalcycle
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadAppraisalCycle1()
    {
        try
        {
         _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
        _obj_Pms_Appraisalcycle.MODE = 11;
        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["empid1"]);//where i am passing employee to get bunit
        DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

        if (dtem.Rows.Count != 0)
        {
            _obj_Pms_Appraisalcycle.MODE = 7;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);

            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);


            DataTable dt = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (dt.Rows.Count != 0)
            {
                rcm_apprcycle.DataSource = dt;
                rcm_apprcycle.DataTextField = "APPRCYCLE_NAME";
                rcm_apprcycle.DataValueField = "APPRCYCLE_ID";
                rcm_apprcycle.DataBind();
                rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt44 = new DataTable();
                rcm_apprcycle.DataSource = dt44;
                rcm_apprcycle.DataBind();
                rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }
        else
        {
            DataTable dt44 = new DataTable();
            rcm_apprcycle.DataSource = dt44;
            rcm_apprcycle.DataBind();
            rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }

         }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    #region LoadGridmethods
    /// <summary>
    /// Here DataNeedSource Is Used To Bind Data To Grid 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void Rg_Task_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        
        try
        {
        _obj_Pms_Task = new SPMS_TASK();
        _obj_Pms_Task.Mode = 1;
        _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
        if (dt.Rows.Count != 0)
        {
            Rg_Task.DataSource = dt;

        }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    /// <summary>
    ///In This Data Binding From Database To Datatable Binding to Radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void LoadGrid()
    {
        try
        {

            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 1;
            _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
            if (dt.Rows.Count != 0)
            {
                Rg_Task.DataSource = dt;
                Rg_Task.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                Rg_Task.DataSource = dt1;
                Rg_Task.DataBind();
            }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region LoadBusineeUnit(not used)
    /// <summary>
    ///  I Am Loading Business uit values based on business unit id
    /// </summary>

    protected void LoadBusinessUnit()
    {
        try
        {
            rcmb_BusinessUnitType.Items.Clear();
            DataTable dt_Details = new DataTable();

            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BusinessUnitType.DataSource = dt_BUDetails;
                rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnitType.DataBind();
                rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_BusinessUnitType.SelectedIndex = 0;
            }

           
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        

    }
    #endregion

    #region Loading Employee Detailss
    /// <summary>
    /// HERE I AM LOADING EMPLOYEE DETAILS WHEN BUSINESS UNIT COMBO BOX SELECT INDEX CHANGED EVENT FIRED
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>


    protected void rcmb_BusinessUnitType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
         try
        {
            if (rcmb_BusinessUnitType.SelectedIndex > 0)
            {
                PMS_EMPSETUP _obj_Pms_EmpSetup;
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();
                _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_PMS_getemployee.Mode = 4;
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);

                if (dtbuid.Rows.Count != 0)
                {
                    rcmb_EmployeeType.Items.Clear();
                    rcmb_EmployeeType.DataSource = dtbuid;
                    rcmb_EmployeeType.DataTextField = "employee";
                    rcmb_EmployeeType.DataValueField = "EMPID";
                    rcmb_EmployeeType.DataBind();
                    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_BusinessUnitType.Visible = false;
                    //lbl_BusinessUnitName.Visible = false;
                }
                else
                {
                    DataTable dt1 = new DataTable();

                    rcmb_EmployeeType.DataSource = dt1;
                    rcmb_EmployeeType.DataBind();
                    //lbl_BusinessUnitName.Visible = false;
                    //rcmb_BusinessUnitType.Visible = false;


                }
                rcmb_EmployeeType.SelectedIndex = 0;
                //lbl_BusinessUnitName.Visible = false;
                //rcmb_BusinessUnitType.Visible = false;
                rcm_apprcycle.Enabled = true;

                DataTable dt2 = new DataTable();
                rcmb_GoalType.DataSource = dt2;
                rcmb_GoalType.DataBind();
                LoadAppraisalCycle();
            }
            else
            {
                rcmb_EmployeeType.ClearSelection();
                rcmb_EmployeeType.Items.Clear();
                rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcm_apprcycle.ClearSelection();
                rcm_apprcycle.Items.Clear();
                rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                rcmb_GoalType.ClearSelection();
                rcmb_GoalType.Items.Clear();
                rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
      
        }
         catch (Exception ex)
         {
             //Pms_Bll.ShowMessage(this, ex.Message.ToString());
             //return;
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }

    private void LoadEmployees()
    {//not necessary
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_BusinessUnitType.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void BindEmployees(DataTable dt)
    {
        try
        {
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.DataSource = dt;
            rcmb_EmployeeType.DataTextField = "EMPNAME";
            rcmb_EmployeeType.DataValueField = "EMP_ID";
            rcmb_EmployeeType.DataBind();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion



    #region EditCommand


    /// <summary>
    ///IN THIS BASED ON Task_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_command(object sender, CommandEventArgs e)
    {
        try
        {

            clearControls();
            btn_Save.Text = "Update";
            LoadBusinessUnit();
            //LoadGoal();
            rcmb_BusinessUnitType.SelectedIndex = -1;

            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 2;
            _obj_Pms_Task.TASK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Pms_Bll.get_Task(_obj_Pms_Task);
            if (DT.Rows.Count != 0)
            {
                lbl_Task_Id.Text = Convert.ToString(DT.Rows[0]["TASK_ID"]);
                Session["empid1"] = (DT.Rows[0]["EMP_ID"]);
                _obj_Pms_Task = new SPMS_TASK();
                _obj_Pms_Task.Mode = 6;
                _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(Convert.ToString(DT.Rows[0]["EMP_ID"]));
                DataTable dt_Bus = Pms_Bll.get_Task(_obj_Pms_Task);
                LoadBusinessUnit();
                rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.FindItemIndexByValue(Convert.ToString(dt_Bus.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                //LoadEmployees();

                PMS_EMPSETUP _obj_Pms_EmpSetup;
                _obj_Pms_EmpSetup = new PMS_EMPSETUP();

                _obj_PMS_getemployee = new PMS_GETEMPLOYEE();

                if ((Convert.ToString(Session["EMP_TYPE"])) == "5")
                {
                    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                }
                else
                {
                    _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);

                }
                _obj_PMS_getemployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_PMS_getemployee.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
                _obj_PMS_getemployee.Mode = 5;
                dtbuid = Pms_Bll.get_RMEmployees(_obj_PMS_getemployee);


                if (dtbuid.Rows.Count != 0)
                {
                    rcmb_EmployeeType.Items.Clear();
                    rcmb_EmployeeType.DataSource = dtbuid;
                    rcmb_EmployeeType.DataTextField = "employee";
                    rcmb_EmployeeType.DataValueField = "EMPID";
                    rcmb_EmployeeType.DataBind();
                    rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    //rcmb_BusinessUnitType.Visible = false;
                    //lbl_BusinessUnitName.Visible = false;
                }
                else
                {
                    DataTable dt1 = new DataTable();

                    rcmb_EmployeeType.DataSource = dt1;
                    rcmb_EmployeeType.DataBind();
                    //lbl_BusinessUnitName.Visible = false;
                    //rcmb_BusinessUnitType.Visible = false;


                }
                //EmpLoad();
                rcmb_EmployeeType.SelectedIndex = rcmb_EmployeeType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["EMP_ID"]));
                //rcmb_EmployeeType.SelectedValue = Convert.ToString(DT.Rows[0]["TASK_EMP_ID"]);
                rtxt_TaskName.Text = Convert.ToString(DT.Rows[0]["TASK_NAME"]);
                rtxt_TaskDescription.Text = Convert.ToString(DT.Rows[0]["TASK_DESCRIPTION"]);
                rdtp_DATE.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TASK_DATE"]);
                LoadGoal1();
                rcmb_GoalType.SelectedIndex = rcmb_GoalType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TASK_GOAL"]));
                LoadAppraisalCycle1();
                rcm_apprcycle.SelectedIndex = rcm_apprcycle.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TASK_APPRAISAL_CYCLE"]));
                btn_Save.Visible = true;
                rtxt_TaskName.Enabled = false;
                Rm_TASK_PAGE.SelectedIndex = 1;
                Rp_TASK_VIEWMAIN.Visible = false;
                Rp_TASK_VIEWDETAILS.Visible = true;
                rcmb_BusinessUnitType.Enabled = false;
                rcmb_EmployeeType.Enabled = false;
                //rcmb_BusinessUnitType.Visible = false;
                //lbl_BusinessUnitName.Visible = false;
                rcmb_GoalType.Enabled = false;
                rcm_apprcycle.Enabled = false;
                rdtp_DATE.Enabled = false;

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {


                    btn_Save.Visible = false;

                }
                else
                {
                    btn_Save.Visible = true;
                }
              
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Error Occured");
                

            }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region save,cancel events
    /// <summary>
    /// WHILE INSERTING THERE IS NO NEED TO ADD LAST MDF BY,LAST MDF DATE,BASED ON LABEL _KRAID IF IT IS NULL THEN PERFORM INSERTION 
    /// IF END DATE IS NULL THEN WE HAVE TO USE THIS AND IT IS TO BE DEFINED IN TRANSLAYER
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            if (lbl_Task_Id.Text == "")
            {
                _obj_Pms_Task = new SPMS_TASK();
                _obj_Pms_Task.Mode = 8;
                _obj_Pms_Task.TASK_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskName.Text));
                _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_Task.TASK_GOAL_ID = Convert.ToInt32(rcmb_GoalType.SelectedItem.Value);
                _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
                if (dt.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Task Name Already Exist");
                    return;
                }
                else
                {
                    if (rdtp_DATE.SelectedDate < DateTime.Now)
                    {
                        rdtp_DATE.Clear();

                        Pms_Bll.ShowMessage(this, "TaskDate Should Be Greater Than Current Date");
                        return;
                    }

                     _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                    _obj_Pms_Appraisalcycle.MODE = 11;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(Session["EMP_ID"]);//where i am passing employee to get bunit
                    DataTable dtem = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);

                    if (dtem.Rows.Count != 0)
                    {
                        _obj_Pms_Appraisalcycle.MODE = 7;
                        _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtem.Rows[0]["EMP_BUSINESSUNIT_ID"]);

                        _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);


                        DataTable dt22 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                        if (dt22.Rows.Count != 0)
                        {
                            DateTime dt_st = Convert.ToDateTime(dt22.Rows[0]["APPCYCLE_STARTDATE"]);
                            DateTime dt_et = Convert.ToDateTime(dt22.Rows[0]["APPCYCLE_ENDDATE"]);


                            if ((rdtp_DATE.SelectedDate.Value > dt_et) || (rdtp_DATE.SelectedDate.Value < dt_st))
                            {
                                BLL.ShowMessage(this, "Date Should Validate With Appraisal Cycle Date");
                                return;
                            }
                        }

                        else
                        {
                            BLL.ShowMessage(this, "Error Occured");
                            return;

                        }

                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "Employee Is In Active");
                        return;

                    }
                    _obj_Pms_Task = new SPMS_TASK();


                    _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Pms_Task.TASK_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskName.Text));
                    _obj_Pms_Task.TASK_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskDescription.Text));
                    _obj_Pms_Task.TASK_DATE = rdtp_DATE.SelectedDate.Value;
                    _obj_Pms_Task.TASK_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Pms_Task.TASK_GOAL_ID = Convert.ToInt32(rcmb_GoalType.SelectedItem.Value);
                    _obj_Pms_Task.TASK_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                    _obj_Pms_Task.TASK_CREATEDDATE = DateTime.Now;
                    _obj_Pms_Task.TASK_APPRAISAL_CYCLE = Convert.ToInt32(rcm_apprcycle.SelectedItem.Value);
                    _obj_Pms_Task.Mode = 4;
                    bool status = Pms_Bll.set_Task(_obj_Pms_Task);
                    if (status == true)
                    {
                        LoadGrid();
                        Rg_Task.DataBind();
                        btn_Save.Visible = true;
                        Rm_TASK_PAGE.SelectedIndex = 0;
                        Rp_TASK_VIEWDETAILS.Visible = false;
                        Rp_TASK_VIEWMAIN.Visible = true;
                        Pms_Bll.ShowMessage(this, "Task Inserted Successfully");

                        return;
                    }
                }
            }
            else
            {
                _obj_Pms_Task = new SPMS_TASK();
                _obj_Pms_Task.TASK_ID = Convert.ToInt32(lbl_Task_Id.Text);
                _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_Task.TASK_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskName.Text));
                _obj_Pms_Task.TASK_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskDescription.Text));
                _obj_Pms_Task.TASK_DATE = rdtp_DATE.SelectedDate.Value;
                _obj_Pms_Task.TASK_GOAL_ID = Convert.ToInt32(rcmb_GoalType.SelectedItem.Value);
                _obj_Pms_Task.TASK_LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Pms_Task.TASK_LASTMDFDATE = DateTime.Now;
                _obj_Pms_Task.TASK_APPRAISAL_CYCLE = Convert.ToInt32(rcm_apprcycle.SelectedItem.Value);
                _obj_Pms_Task.Mode = 5;
                bool status = Pms_Bll.set_Task(_obj_Pms_Task);
                if (status == true)
                {
                    LoadGrid();
                    Rg_Task.DataBind();
                    btn_Save.Visible = true;
                    Rm_TASK_PAGE.SelectedIndex = 0;
                    Rp_TASK_VIEWDETAILS.Visible = false;
                    Rp_TASK_VIEWMAIN.Visible = true;


                }
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Task Updated Successfully");
                   // return;
                }

            }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            Rm_TASK_PAGE.SelectedIndex = 0;
            Rp_TASK_VIEWMAIN.Visible = true;
            Rp_TASK_VIEWDETAILS.Visible = false;
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
    #endregion


    #region employee index changed event
    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        try
        {
            if (rcmb_EmployeeType.SelectedItem.Text != "Select")
            {
                LoadGoal();
                //LoadAppraisalCycle();
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Employee");
                DataTable dt33 = new DataTable();
                rcmb_GoalType.DataSource = dt33;
                rcmb_GoalType.DataBind();
                rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                //rcm_apprcycle.DataSource = dt33;
                //rcm_apprcycle.DataBind();
                //rcm_apprcycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            //Pms_Bll.ShowMessage(this, ex.Message.ToString());
            //return;
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PmsTask", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


}
