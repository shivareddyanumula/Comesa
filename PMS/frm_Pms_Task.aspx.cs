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




public partial class PMS_frm_Pms_Task : System.Web.UI.Page
{
    
  SPMS_TASK _obj_Pms_Task;
  PMS_GETEMPLOYEE _obj_PMS_getemployee;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                LoadTaskGrid();

                //DataTable dtappr = new DataTable();
                //rcmb_apprcycle.DataSource = dtappr;
                //rcmb_apprcycle.DataBind();

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }





    protected void LoadTaskGrid()
    {
        try
        {
        _obj_Pms_Task = new SPMS_TASK();
        _obj_Pms_Task.Mode = 7;
        _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(Session["empid"]);
        DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
        if (dt.Rows.Count != 0)
        {
            Rg_Task.DataSource = dt;
            Rg_Task.DataBind();
        }
        else
        {
            Pms_Bll.ShowMessage(this, "No Task Assigned");
            DataTable dt1 = new DataTable();
            Rg_Task.DataSource = dt1;
            Rg_Task.DataBind();
            return;
        }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
        rcmb_BusinessUnitType.SelectedIndex = -1;
        LoadGoal();
        Rm_TASK_PAGE.SelectedIndex = 1;
        lbl_BusinessUnitName.Visible = false;
        rcmb_BusinessUnitType.Visible = false;
        
        rcmb_EmployeeType.SelectedIndex = Convert.ToInt32(Session["empid"]);

        PMS_EMPSETUP _obj_Pms_EmpSetup;
        _obj_Pms_EmpSetup = new PMS_EMPSETUP();

        _obj_PMS_getemployee = new PMS_GETEMPLOYEE();

        if ((Convert.ToString(Session["EMP_TYPE"])) == "13")
        {
            _obj_PMS_getemployee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
        }

        DataTable dtbuid = Pms_Bll.get_GMEmployees(_obj_PMS_getemployee);


        if (dtbuid.Rows.Count != 0)
        {
            rcmb_EmployeeType.Items.Clear();
            rcmb_EmployeeType.DataSource = dtbuid;
            rcmb_EmployeeType.DataTextField = "employee";
            rcmb_EmployeeType.DataValueField = "EMPID";
            rcmb_EmployeeType.DataBind();
            rcmb_EmployeeType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rcmb_BusinessUnitType.Visible = false;
            lbl_BusinessUnitName.Visible = false;
        }
        else
        {
            DataTable dt1 = new DataTable();

            rcmb_EmployeeType.DataSource = dt1;
            rcmb_EmployeeType.DataBind();
            lbl_BusinessUnitName.Visible = false;
            rcmb_BusinessUnitType.Visible = false;


        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
            rcmb_EmployeeType.SelectedIndex = 0;
            rcmb_GoalType.SelectedIndex = 0;
            rtxt_TaskName.Text = string.Empty;
            rtxt_TaskDescription.Text = string.Empty;
            rdtp_DATE.SelectedDate = null;
            btn_Save.Visible = false;
            Rm_TASK_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region LoadGoals
    /// <summary>
    /// HERE I AM LOADING Goals DETAILS FROM PREVIOUS GOAL SETTING DETAILS TABLE
    /// </summary>

    protected void LoadGoal()
    {
        try
        {
        rcmb_GoalType.Items.Clear();
        SPMS_GOALSETTING _obj_Pms_GoalSetting = new SPMS_GOALSETTING();
        _obj_Pms_GoalSetting.Mode = 1;
        DataTable dt = Pms_Bll.get_GoalSetting(_obj_Pms_GoalSetting);
        rcmb_GoalType.DataSource = dt;
        rcmb_GoalType.DataTextField = "GSDTL_NAME";
        rcmb_GoalType.DataValueField = "GSDTL_ID";
        rcmb_GoalType.DataBind();
        rcmb_GoalType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    #region LoadGrid
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
        DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
        if (dt.Rows.Count != 0)
        {
            Rg_Task.DataSource = dt;

        }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
            DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
            if (dt.Rows.Count != 0)
            {
                Rg_Task.DataSource = dt;
                Rg_Task.DataBind();
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region LoadBusineeUnit
    /// <summary>
    ///  I Am Loading Business uit values based on business unit id
    /// </summary>

    protected void LoadBusinessUnit()
    {
        try
        {
            rcmb_BusinessUnitType.Items.Clear();
            SMHR_BUSINESSUNIT _obj_Smhr_BusinessUnit = new SMHR_BUSINESSUNIT();
            _obj_Smhr_BusinessUnit.OPERATION = operation.Select;
            _obj_Smhr_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            DataTable dt = BLL.get_BusinessUnit(_obj_Smhr_BusinessUnit);
            rcmb_BusinessUnitType.DataSource = dt;
            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitType.DataBind();
            rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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

             LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    private void LoadEmployees()
    {
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
            LoadGoal();
            rcmb_BusinessUnitType.SelectedIndex = -1;

            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 2;
            _obj_Pms_Task.TASK_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Pms_Bll.get_Task(_obj_Pms_Task);
            lbl_Task_Id.Text = Convert.ToString(DT.Rows[0]["TASK_ID"]);
          
            _obj_Pms_Task = new SPMS_TASK();
            _obj_Pms_Task.Mode = 6;
            _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(Convert.ToString(DT.Rows[0]["EMP_ID"]));
            DataTable dt_Bus = Pms_Bll.get_Task(_obj_Pms_Task);
            LoadBusinessUnit();
            rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.FindItemIndexByValue(Convert.ToString(dt_Bus.Rows[0]["EMP_BUSINESSUNIT_ID"]));
            LoadEmployees();
            rcmb_EmployeeType.SelectedIndex = rcmb_EmployeeType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["EMP_ID"]));
            rtxt_TaskName.Text = Convert.ToString(DT.Rows[0]["TASK_NAME"]);
            rtxt_TaskDescription.Text = Convert.ToString(DT.Rows[0]["TASK_DESCRIPTION"]);
            rdtp_DATE.SelectedDate = Convert.ToDateTime(DT.Rows[0]["TASK_DATE"]);
            rcmb_GoalType.SelectedIndex = rcmb_GoalType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["TASK_GOAL"]));
            btn_Save.Visible = true;
            Rm_TASK_PAGE.SelectedIndex = 1;
            rcmb_BusinessUnitType.Enabled = false;
            rcmb_EmployeeType.Enabled = false;
            lbl_BusinessUnitName.Visible = false;
            rcmb_BusinessUnitType.Visible = false;
            rtxt_TaskName.Enabled = false;
            rcmb_GoalType.Enabled = false;
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
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
    ///  <param name="e"></param>


    protected void btn_Save_Click(object sender, EventArgs e)
    {

        try
        {
            if (lbl_Task_Id.Text == "")
            {
                _obj_Pms_Task = new SPMS_TASK();
                _obj_Pms_Task.Mode = 8;
                _obj_Pms_Task.TASK_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskName.Text));
              
                DataTable dt = Pms_Bll.get_Task(_obj_Pms_Task);
                if (dt.Rows.Count != 0)
                {
                    Pms_Bll.ShowMessage(this, "Task Name Already Exist");
                    return;
                }
                else
                {

                    _obj_Pms_Task = new SPMS_TASK();


                    _obj_Pms_Task.TASK_EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                    _obj_Pms_Task.TASK_NAME = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskName.Text));
                    _obj_Pms_Task.TASK_DESCRIPTION = Pms_Bll.ReplaceQuote(Convert.ToString(rtxt_TaskDescription.Text));
                    _obj_Pms_Task.TASK_DATE = rdtp_DATE.SelectedDate.Value;
                    _obj_Pms_Task.TASK_GOAL_ID = Convert.ToInt32(rcmb_GoalType.SelectedItem.Value);
                    _obj_Pms_Task.TASK_CREATEDBY = 1; // ### Need to Get the Session
                    _obj_Pms_Task.TASK_CREATEDDATE = DateTime.Now;
                    _obj_Pms_Task.Mode = 4;
                    bool status = Pms_Bll.set_Task(_obj_Pms_Task);
                    if (status == true)
                    {
                        Pms_Bll.ShowMessage(this, "Task Inserted Successfully");
                        LoadGrid();
                        Rg_Task.DataBind();
                        btn_Save.Visible = true;
                        Rm_TASK_PAGE.SelectedIndex = 0;
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
                _obj_Pms_Task.TASK_LASTMDFBY = 1; // ### Need to Get the Session
                _obj_Pms_Task.TASK_LASTMDFDATE = DateTime.Now;
                _obj_Pms_Task.Mode = 5;
                bool status = Pms_Bll.set_Task(_obj_Pms_Task);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Task Updated Successfully");
                    LoadGrid();
                    Rg_Task.DataBind();
                    btn_Save.Visible = true;
                    Rm_TASK_PAGE.SelectedIndex = 0;
                    return;
                }

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_TASK_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Task", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    }
