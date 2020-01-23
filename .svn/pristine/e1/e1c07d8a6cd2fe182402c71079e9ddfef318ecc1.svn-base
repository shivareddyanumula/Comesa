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

public partial class PMS_frm_Pms_EmpSetup : System.Web.UI.Page
{

    PMS_EMPSETUP _obj_Pms_EmpSetup;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                LoadGrid();
                btn_update.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
            btn_Save.Text = "Save";
            DataTable dt = new DataTable();
            rcmb_EmployeeType.DataSource = dt;
            rcmb_EmployeeType.DataBind();
            rcmb_GeneralMgrType.DataSource = dt;
            rcmb_GeneralMgrType.DataBind();
            rcmb_ReportingMgrType.DataSource = dt;
            rcmb_ReportingMgrType.DataBind();
            Rm_EMPSETUP_PAGE.SelectedIndex = 1;
            rcmb_BusinessUnitType.Enabled = true;
            rcmb_EmployeeType.Enabled = true;
            rcmb_ReportingMgrType.Enabled = true;
            btn_update.Visible = false;
            btn_Save.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region LoadGrid
    /// <summary>
    ///IN THIS data binding from database to datatable binding to radgrid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rgem_needsource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 1;

            DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
            if (dt.Rows.Count != 0)
            {
                Rg_EmpSetup.DataSource = dt;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 1;

            DataTable dt = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
            if (dt.Rows.Count != 0)
            {
                Rg_EmpSetup.DataSource = dt;

                Rg_EmpSetup.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();

                Rg_EmpSetup.DataSource = dt1;

                Rg_EmpSetup.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    #endregion


    #region LoadBusineeUnit
    /// <summary>
    /// I am loading business unit values based on business unit id
    /// </summary>

    protected void LoadBusinessUnit()
    {
        try
        {
            SMHR_LOGININFO _obj_smhr_logininfo = new SMHR_LOGININFO();
            _obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"].ToString());
            _obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"].ToString());
            rcmb_BusinessUnitType.Items.Clear();
            rcmb_BusinessUnitType.DataSource = BLL.get_Business_Units(_obj_smhr_logininfo);
            rcmb_BusinessUnitType.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnitType.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnitType.DataBind();
            rcmb_BusinessUnitType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployees()
    {
        try
        {

            PMS_GETEMPLOYEE _obj_Pms_GetEmployee = new PMS_GETEMPLOYEE();
            _obj_Pms_GetEmployee.Mode = 1;
            DataTable DT_Details = new DataTable();
            if (rcmb_BusinessUnitType.SelectedItem.Value != "")
            {
                _obj_Pms_GetEmployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                DT_Details = Pms_Bll.get_Employee(_obj_Pms_GetEmployee);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    #endregion



    #region Loading Reporting Mgr Manager Details
    /// <summary>
    /// I AM LOADING MANAGER DETAILS BASED ON SELECTED BUSINESS UNIT AND WHOSE EMPLOYEE NAME SHOULD NOT TO BE COME IN MANAGER LIST
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>


    protected void rcmb_EmployeeType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadReportingManager();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void BindManager(DataTable dt)
    {
        try
        {
            rcmb_ReportingMgrType.Items.Clear();
            rcmb_ReportingMgrType.DataSource = dt;
            rcmb_ReportingMgrType.DataTextField = "EMPNAME";
            rcmb_ReportingMgrType.DataValueField = "EMP_ID";
            rcmb_ReportingMgrType.DataBind();
            rcmb_ReportingMgrType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }

    private void LoadReportingManager()
    {
        try
        {
            PMS_GETEMPLOYEE _obj_Pms_GetEmployee = new PMS_GETEMPLOYEE();
            _obj_Pms_GetEmployee.Mode = 2;
            DataTable DT_Details = new DataTable();
            if (rcmb_EmployeeType.SelectedItem.Value != "")
            {
                _obj_Pms_GetEmployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_GetEmployee.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                DT_Details = Pms_Bll.get_Employee(_obj_Pms_GetEmployee);
                if (DT_Details.Rows.Count != 0)
                {
                    BindManager(DT_Details);
                }
                else
                {
                    BindManager(DT_Details);
                }
            }
            else
            {
                BindManager(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion



    #region Loading General Mgr Manager Details

    protected void rcmb_ReportingMgrType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadGeneralManager();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
       
    }



    protected void BindGeneralManager(DataTable dt)
    {
        try
        {
            rcmb_GeneralMgrType.Items.Clear();
            rcmb_GeneralMgrType.DataSource = dt;
            rcmb_GeneralMgrType.DataTextField = "EMPNAME";
            rcmb_GeneralMgrType.DataValueField = "EMP_ID";
            rcmb_GeneralMgrType.DataBind();
            rcmb_GeneralMgrType.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }

    private void LoadGeneralManager()
    {
        try
        {
            PMS_GETEMPLOYEE _obj_Pms_GetEmployee = new PMS_GETEMPLOYEE();
            _obj_Pms_GetEmployee.Mode = 3;
            DataTable DT_Details = new DataTable();
            if (rcmb_EmployeeType.SelectedItem.Value != "")
            {
                _obj_Pms_GetEmployee.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_GetEmployee.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_GetEmployee.REPORTINGMGR_ID = Convert.ToInt32(rcmb_ReportingMgrType.SelectedItem.Value);
                DT_Details = Pms_Bll.get_Employee(_obj_Pms_GetEmployee);
                if (DT_Details.Rows.Count != 0)
                {
                    BindGeneralManager(DT_Details);
                }
                else
                {
                    BindGeneralManager(DT_Details);
                }
            }
            else
            {
                BindGeneralManager(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(rcmb_ReportingMgrType.SelectedItem.Value);
            _obj_Pms_EmpSetup.GENERALMGR_ID = Convert.ToInt32(rcmb_GeneralMgrType.SelectedItem.Value);
            _obj_Pms_EmpSetup.Mode = 5;
            DataTable dtemp = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
            if (Convert.ToInt32(dtemp.Rows[0]["Count"]) != 0)
            {

                Pms_Bll.ShowMessage(this, "Employee Already Assigned");
                rcmb_ReportingMgrType.Enabled = true;
            }
            else
            {

                _obj_Pms_EmpSetup = new PMS_EMPSETUP();


                _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
                _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(rcmb_ReportingMgrType.SelectedItem.Value);
                _obj_Pms_EmpSetup.GENERALMGR_ID = Convert.ToInt32(rcmb_GeneralMgrType.SelectedItem.Value);
                _obj_Pms_EmpSetup.EMP_SETUP_CREATEDBY = 1; // ### Need to Get the Session
                _obj_Pms_EmpSetup.EMP_SETUP_CREATEDDATE = DateTime.Now;
                _obj_Pms_EmpSetup.Mode = 3;
                bool status = Pms_Bll.set_EmpSetup(_obj_Pms_EmpSetup);
                if (status == true)
                {
                    Pms_Bll.ShowMessage(this, "Record Inserted Successfully");

                    btn_Save.Visible = true;
                    LoadGrid();
                    Rm_EMPSETUP_PAGE.SelectedIndex = 0;
                    DataTable dt = new DataTable();
                    rcmb_BusinessUnitType.SelectedIndex = 0;
                    rcmb_EmployeeType.SelectedIndex = 0;
                    rcmb_ReportingMgrType.SelectedIndex = 0;
                    rcmb_GeneralMgrType.SelectedIndex = 0;
                    rcmb_GeneralMgrType.Enabled = true;
                    rcmb_BusinessUnitType.Enabled = true;
                    rcmb_EmployeeType.Enabled = true;
                    rcmb_ReportingMgrType.Enabled = true;
                    rcmb_EmployeeType.DataSource = dt;
                    rcmb_EmployeeType.DataBind();
                    rcmb_GeneralMgrType.DataSource = dt;
                    rcmb_GeneralMgrType.DataBind();
                    rcmb_ReportingMgrType.DataSource = dt;
                    rcmb_ReportingMgrType.DataBind();
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        


       
    }
    protected void rcmb_GeneralMgrType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_ReportingMgrType.Enabled = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    #region EditCommand


    /// <summary>
    ///IN THIS BASED ON Project_ID(COMMANDARGUMENT) ALL DATA WILL BE TAKEN TO DATATABLE THEN WE CAN BIND TO INDIVIDUAL FIELDS
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>

    protected void lnk_edit_Command(object sender, CommandEventArgs e)
    {
        try
        {


            btn_update.Visible = true;
          
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();
            _obj_Pms_EmpSetup.Mode = 2;


            _obj_Pms_EmpSetup.EMP_SETUP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable DT = Pms_Bll.get_EmpSetup(_obj_Pms_EmpSetup);
            lbl_Emp_Setup_Id.Text = Convert.ToString(DT.Rows[0]["EMP_SETUP_ID"]);
            LoadBusinessUnit();
            rcmb_BusinessUnitType.SelectedIndex = rcmb_BusinessUnitType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["BU_ID"]));
            LoadEmployees();
            rcmb_EmployeeType.SelectedIndex = rcmb_EmployeeType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["EMP_ID"]));

            LoadReportingManager();
            rcmb_ReportingMgrType.SelectedIndex = rcmb_ReportingMgrType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["REPORTINGMGR_ID"]));
            LoadGeneralManager();
            rcmb_GeneralMgrType.SelectedIndex = rcmb_GeneralMgrType.Items.FindItemIndexByValue(Convert.ToString(DT.Rows[0]["GENERALMGR_ID"]));
            btn_Save.Visible = true;
            rcmb_ReportingMgrType.Enabled = true;
            Rm_EMPSETUP_PAGE.SelectedIndex = 1;
            rcmb_BusinessUnitType.Enabled = false;
            rcmb_EmployeeType.Enabled = false;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    #endregion
    protected void btn_Cancel_Click1(object sender, EventArgs e)
    {
        try
        {
            LoadGrid();
            Rm_EMPSETUP_PAGE.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            Pms_Bll.ShowMessage(this, ex.Message.ToString());
            return;
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Pms_EmpSetup = new PMS_EMPSETUP();

            _obj_Pms_EmpSetup.EMP_SETUP_ID = Convert.ToInt32(lbl_Emp_Setup_Id.Text);
            _obj_Pms_EmpSetup.BU_ID = Convert.ToInt32(rcmb_BusinessUnitType.SelectedItem.Value);
            _obj_Pms_EmpSetup.EMP_ID = Convert.ToInt32(rcmb_EmployeeType.SelectedItem.Value);
            _obj_Pms_EmpSetup.REPORTINGMGR_ID = Convert.ToInt32(rcmb_ReportingMgrType.SelectedItem.Value);
            _obj_Pms_EmpSetup.GENERALMGR_ID = Convert.ToInt32(rcmb_GeneralMgrType.SelectedItem.Value);
            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFBY = 1; // ### Need to Get the Session
            _obj_Pms_EmpSetup.EMP_SETUP_LASTMDFDATE = DateTime.Now;
            _obj_Pms_EmpSetup.Mode = 20;
            bool status = Pms_Bll.set_EmpSetup(_obj_Pms_EmpSetup);
            if (status == true)
            {
                Pms_Bll.ShowMessage(this, "Record Updated Successfully");
                LoadGrid();
                btn_Save.Visible = true;
                Rm_EMPSETUP_PAGE.SelectedIndex = 0;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_EmpSetup", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
