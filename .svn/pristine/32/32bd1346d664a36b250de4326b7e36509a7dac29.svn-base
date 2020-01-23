using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;
using Telerik.Web.UI;

public partial class Reportss_Employee_Payslip : System.Web.UI.Page
{
    SMHR_EMPLOYEE _obj_smhr_employee;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pay Slips");
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
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
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



                LoadOrganisation();
                LoadCombos();
                trDept.Visible = false;
                trEmployee.Visible = false;
                if (Convert.ToString(Session["SELFSERVICE"]) != "")
                {
                    if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
                    {
                        trBusinessUnit.Visible = false;
                        trRblist.Visible = false;
                        trDept.Visible = false;
                        trEmployee.Visible = false;
                    }
                    else
                    {
                        trBusinessUnit.Visible = true;
                        trRblist.Visible = true;
                    }
                }
                else
                {
                    trBusinessUnit.Visible = false;
                    trRblist.Visible = false;
                    trDept.Visible = false;
                    trEmployee.Visible = false;
                }
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected override void InitializeCulture()
    {
        BLL.SetCulture_Theme(Page, Request);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadReport()
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payperiod.SelectedItem.Value) + "','" + Convert.ToString(Session["EMP_ID"]) + "','" + Convert.ToString(Session["dept"]) + "','" + Convert.ToString(Session["buid"]) + "');", true);
            }
            else if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payperiod.SelectedItem.Value) + "','" + Convert.ToString(Session["EMP_ID"]) + "','" + Convert.ToString(Session["dept"]) + "','" + Convert.ToString(Session["buid"]) + "');", true);
            }
            else
            {
                if (rbList.Items[1].Selected)
                {
                    if ((ddl_Department.SelectedIndex > 0) && (rcmb_employee.SelectedIndex > 0))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payperiod.SelectedItem.Value) + "','" + Convert.ToString(rcmb_employee.SelectedItem.Value) + "','" + Convert.ToString(ddl_Department.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "');", true);
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please Select Department and Employee to generate the payslip");
                    }
                }
                else if (rbList.Items[0].Selected)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payperiod.SelectedItem.Value) + "','" + Convert.ToString(-1) + "','" + Convert.ToString(-1) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "');", true);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            if (Request.QueryString["EMPID"] == null)
            {
                DataTable dt_Details = BLL.get_payslip("PERIOD", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(Session["USER_ID"]));
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_payperiod.DataSource = dt_Details;
                    rcmb_payperiod.DataValueField = "PERIOD_ID";
                    rcmb_payperiod.DataTextField = "PAYPERIOD";
                    rcmb_payperiod.DataBind();
                    rcmb_payperiod.Items.Insert(0, new RadComboBoxItem("Select", "0"));



                }
                else
                    BLL.ShowMessage(this, "Please run Payroll");
            }
            else
            {
                //tr_Employee.Style.Add("Display", "none");
                DataTable dt_Details = BLL.get_payslip("PERIOD1", Convert.ToString(Request.QueryString["EMPID"]), string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(Session["USER_ID"]));
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_payperiod.DataSource = dt_Details;
                    rcmb_payperiod.DataValueField = "PERIOD_ID";
                    rcmb_payperiod.DataTextField = "PAYPERIOD";
                    rcmb_payperiod.DataBind();
                    rcmb_payperiod.Items.Insert(0, new RadComboBoxItem("Select", "0"));


                }
                else
                {
                    rcmb_payperiod.Items.Insert(0, new RadComboBoxItem("Select", "0"));

                    BLL.ShowMessage(this, "There are no Payslips to Display");
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_payperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "")
            {
                rcmb_BusinessUnit.Items.Clear();
                if (rcmb_payperiod.SelectedIndex != 0)
                {
                    string periodid = rcmb_payperiod.SelectedItem.Value;
                    DataTable dtemp = BLL.get_payslip("BU", periodid, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(Session["USER_ID"]));
                    rcmb_BusinessUnit.DataSource = dtemp;
                    rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rcmb_BusinessUnit.DataBind();
                    rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                }

            }
            else
            {

                if (rcmb_payperiod.SelectedItem.Value != "0")
                {
                    if (Convert.ToString(Session["SELFSERVICE"]).ToUpper() == "TRUE")
                    {
                        trBusinessUnit.Visible = false;
                        getEmployee();
                    }
                    else
                    {
                        string periodid = rcmb_payperiod.SelectedItem.Value;
                        DataTable dtemp = BLL.get_payslip("BU", periodid, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(Session["USER_ID"]));
                        rcmb_BusinessUnit.DataSource = dtemp;
                        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                        rcmb_BusinessUnit.DataBind();
                        rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    private void LoadEmployees()
    {
        try
        {
            //rcmb_employee.Items.Clear();
            //if (rcmb_BusinessUnit.SelectedItem.Value != "0")
            //{
            //    rcmb_employee.Items.Clear();
            //    string periodid = rcmb_payperiod.SelectedItem.Value;
            //    string buid = rcmb_BusinessUnit.SelectedItem.Value;
            //    string deptid = ddl_Department.SelectedItem.Value;
            //    DataTable dtemp = BLL.get_payslip("EMP", periodid, buid,deptid);
            //    rcmb_employee.DataSource = dtemp;
            //    rcmb_employee.DataValueField = "EMP_ID";
            //    rcmb_employee.DataTextField = "EMPNAME";
            //    rcmb_employee.DataBind();
            //    rcmb_employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            //}

            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                //SMHR_LOGININFO obj_smhr_logininfo = new SMHR_LOGININFO();
                //obj_smhr_logininfo.OPERATION = operation.Check;
                //string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();


                //obj_smhr_logininfo.OPERATION = operation.Check;
                //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                //DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.getdeptwise;
                _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                _obj_smhr_employee.EMP_DEPARTMENT_ID = Convert.ToInt32(ddl_Department.SelectedValue);
                DataTable dt_getEMP = BLL.get_Employee(_obj_smhr_employee);
                rcmb_employee.Items.Clear();
                rcmb_employee.DataSource = dt_getEMP;
                rcmb_employee.DataTextField = "EMP_NAME";
                rcmb_employee.DataValueField = "EMP_ID";
                rcmb_employee.DataBind();
                rcmb_employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
            else
            {
                SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
                _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_emp_payitems.OPERATION = operation.Self;
                DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                rcmb_employee.DataSource = dt_EMP;
                rcmb_employee.DataTextField = "Empname";
                rcmb_employee.DataValueField = "EMP_ID";
                rcmb_employee.DataBind();
                rcmb_employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            rcmb_employee.Items.Clear();
            string periodid = rcmb_payperiod.SelectedItem.Value;
            string buid = rcmb_BusinessUnit.SelectedItem.Value;
            //string deptid = ddl_Department.SelectedItem.Value;
            DataTable dtemp = BLL.get_payslip("EMP", periodid, buid, string.Empty, string.Empty, string.Empty, Convert.ToInt32(Session["USER_ID"]));
            rcmb_employee.DataSource = dtemp;
            rcmb_employee.DataValueField = "EMP_ID";
            rcmb_employee.DataTextField = "EMPNAME";
            rcmb_employee.DataBind();
            rcmb_employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();

            _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_department.MODE = 7;
            DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
            ddl_Department.DataSource = dt_dept;
            ddl_Department.DataValueField = "DEPARTMENT_ID";
            ddl_Department.DataTextField = "DEPARTMENT_NAME";
            ddl_Department.DataBind();
            ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            //rv_payslip.Visible = true;
            LoadReport();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payperiod.SelectedItem.Value) + "','" + Convert.ToString(rcmb_employee.SelectedItem.Value) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(ddl_Department.SelectedValue) + "');", true);        
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_Department.Items.Clear();
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_employee.Items.Clear();
            rcmb_payperiod.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ddl_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["SELFSERVICE"]) == "")
            {
                LoadEmployees();
                rcmb_employee.Enabled = true;

            }
            else
            {
                LoadEmployees();

                rcmb_employee.Enabled = true;
                rcmb_employee.SelectedIndex = rcmb_employee.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rbList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbList.Items[0].Selected)
            {
                trDept.Visible = false;
                trEmployee.Visible = false;
            }
            else if (rbList.Items[1].Selected)
            {
                trDept.Visible = true;
                trEmployee.Visible = true;
            }
            loadDepartment();
            rcmb_employee.Items.Clear();
            rcmb_employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void loadDepartment()
    {
        try
        {
            SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();

            _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_smhr_department.MODE = 7;
            DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
            ddl_Department.DataSource = dt_dept;
            ddl_Department.DataValueField = "DEPARTMENT_ID";
            ddl_Department.DataTextField = "DEPARTMENT_NAME";
            ddl_Department.DataBind();
            ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void getEmployee()
    {
        try
        {
            _obj_smhr_employee = new SMHR_EMPLOYEE();
            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
            if (Convert.ToString(dt_Details.Rows[0]["EMP_PICTURE"]) != string.Empty)
            {
                Session["dept"] = Convert.ToString(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]);
                Session["buid"] = Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Payslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
