using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_salaryslipforsmhr : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadPeriod();
                //LoadPeriodElements();
                LoadOrganisation();
                LoadBusinessUnit();
                rcmb_Organisation.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOrganisation()
    {
        try
        {
            //obj_smhr_Organisation = new SMHR_ORGANISATION();
            //obj_smhr_Organisation.MODE = 1;
            //DataTable dt_OrganisationDetails = BLL.get_Organisation(obj_smhr_Organisation);
            //rcmb_Organisation.DataSource = dt_OrganisationDetails;
            //rcmb_Organisation.DataValueField = "ORGANISATION_ID";
            //rcmb_Organisation.DataTextField = "ORGANISATION_DESC";
            //rcmb_Organisation.DataBind();
            //rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));

            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            rcmb_Organisation.DataSource = dt_logindetails;
            rcmb_Organisation.DataTextField = "organisation_name";
            rcmb_Organisation.DataValueField = "organisation_id";
            rcmb_Organisation.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_logininfo = new SMHR_LOGININFO();

            obj_smhr_logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                obj_smhr_logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_logininfo);
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                DataTable dt_BU = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                rcmb_BusinessUnit.DataSource = dt_BU;
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataValueField = "EMP_BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadDepartment()
    //{
    //    SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    //    // _obj_smhr_department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    _obj_smhr_department.MODE = 7;
    //    _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //    DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
    //    rcmb_Department.DataSource = dt_dept;
    //    rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //    rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //    rcmb_Department.DataBind();
    //    rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
    //}

    private void LoadEmployee()
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                obj_smhr_logininfo = new SMHR_LOGININFO();
                obj_smhr_logininfo.OPERATION = operation.Check;
                string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();
                //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                //DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                //string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

                obj_smhr_logininfo.OPERATION = operation.Check;
                obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);

                rcmb_Employee.Items.Clear();
                rcmb_Employee.DataSource = dt_getEMP;
                rcmb_Employee.DataTextField = "EMP_NAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                rcmb_Employee.DataSource = dt_EMP;
                rcmb_Employee.DataTextField = "Empname";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
                rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //DataTable dt_Details = BLL.get_PeriodHeaderDetails_Calendar(obj_smhr_Period);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void LoadPeriodElements()
    //{
    //    SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
    //    _obj_smhr_perioddtl.OPERATION = operation.Select;
    //    DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
    //    if (dt_Details.Rows.Count != 0)
    //    {
    //        rcmb_PeriodElements.DataSource = dt_Details;
    //        rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
    //        rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
    //        rcmb_PeriodElements.DataBind();
    //        rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
    //    }
    //}

    protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployee();
            //LoadDepartment();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex != 0)
            {
                SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
                //DataTable dt_Details = BLL.get_PeriodDetails_Calendar(_obj_smhr_perioddtl);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodElements.DataSource = dt_Details;
                    rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodElements.DataBind();
                    rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_PeriodElements.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_Organisation.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Organisation.SelectedIndex = 0;
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_Employee.SelectedIndex = 0;
            rcmb_Period.SelectedIndex = 0;
            rcmb_PeriodElements.SelectedIndex = 0;
            //rcmb_Department.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhr", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
