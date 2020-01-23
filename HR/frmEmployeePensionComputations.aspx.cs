﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class HR_frmEmployeePensionComputations : System.Web.UI.Page
{
    SMHR_DEPARTMENT _obj_SMHR_Department;
    SMHR_ASSET_MASTER _obj_SMHR_AssetMaster;
    static DataTable dt_Details = new DataTable();
    SMHR_BUSINESSUNIT _obj_SMHR_BusinessUnit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_EMPLOYEE _obj_smhr_employee;
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            if (!IsPostBack)
            {
                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Pension Computation");
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
                    btn_ViewDetails.Visible = false;
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
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
        try
        {
            if ((Convert.ToInt32(Session["EMP_ID"]) == 0))
            {
                rad_BusinessUnit.Items.Clear();
                _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
                _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
                if (dt_BUDetails.Rows.Count > 0)
                {
                    rad_BusinessUnit.DataSource = dt_BUDetails;
                    rad_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                    rad_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                    rad_BusinessUnit.DataBind();
                }
                rad_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void Load_Directorate()
    {
        try
        {
            rad_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (rad_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rad_BusinessUnit.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                    rad_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rad_Directorate.DataValueField = "DIRECTORATE_ID";
                    rad_Directorate.DataSource = DT;
                    rad_Directorate.DataBind();
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rad_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDepartment()
    {
        try
        {
            if (rad_BusinessUnit.SelectedIndex != 0)
            {
                _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_Department.BUID = Convert.ToInt32(rad_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                rad_Department.DataSource = dt;
                rad_Department.DataTextField = "DEPARTMENT_NAME";
                rad_Department.DataValueField = "DEPARTMENT_ID";
                rad_Department.DataBind();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_BusinessUnit.SelectedIndex > 0)
            {
                Load_Directorate();
                LoadEmployees();
            }
            else
            {
                rad_Directorate.ClearSelection();
                rad_Directorate.Items.Clear();
                rad_Directorate.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rad_Department.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rad_SubDepartment.Items.Clear();
                rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rad_Employee.Items.Clear();
                rad_Employee.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rdp_DOB.Clear();
                rdp_DOJ.Clear();
                rad_Age.Text = string.Empty;
                // pnl_CalculatePension.Visible = false;
                txt_Category.Text = string.Empty;
                txt_lifeBenefit.Text = string.Empty;
                txt_Pension.Text = string.Empty;
                txt_Total.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_Directorate.SelectedIndex > 0)
            {
                LoadDepartment();
                LoadEmployees();
            }
            else
            {
                rad_Department.ClearSelection();
                rad_Department.Items.Clear();
                rad_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                rad_SubDepartment.Items.Clear();
                rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                LoadEmployees();
                rdp_DOB.Clear();
                rdp_DOJ.Clear();
                rad_Age.Text = string.Empty;
                //pnl_CalculatePension.Visible = false;     
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadDivision()
    {
        try
        {
            if (rad_Department.SelectedValue != null)
            {
                rad_SubDepartment.Items.Clear();
                _obj_SMHR_BusinessUnit = new SMHR_BUSINESSUNIT();
                _obj_SMHR_BusinessUnit.OPERATION = operation.Select1;
                _obj_SMHR_BusinessUnit.BUID = Convert.ToInt32(rad_BusinessUnit.SelectedValue);
                _obj_SMHR_BusinessUnit.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedValue);
                _obj_SMHR_BusinessUnit.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedValue);
                _obj_SMHR_BusinessUnit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Divisions = BLL.Get_Divisions(_obj_SMHR_BusinessUnit);
                if (Dt_Divisions.Rows.Count > 0)
                {

                    rad_SubDepartment.DataSource = Dt_Divisions;
                    rad_SubDepartment.DataTextField = "SMHR_DIV_CODE";
                    rad_SubDepartment.DataValueField = "SMHR_DIV_ID";
                    rad_SubDepartment.DataBind();
                }
                rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
            }
            else
            {
                rad_SubDepartment.Items.Clear();
                txt_Category.Text = string.Empty;
                txt_lifeBenefit.Text = string.Empty;
                txt_Pension.Text = string.Empty;
                txt_Total.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_CalculatePension_Click(object sender, EventArgs e)
    {
        try
        {
            if (!pnl_CalculatePension.Visible)
            {
                pnl_CalculatePension.Visible = true;
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.GetEmployeePensionDetails;
                if (rad_Employee.SelectedIndex > 0)
                {
                    _obj_smhr_employee.EMP_ID = Convert.ToInt32(rad_Employee.SelectedValue);
                }
                else
                {
                    _obj_smhr_employee.EMP_ID = 0;
                }
                dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (dt_Details != null)
                {
                    if (dt_Details.Rows.Count > 0)
                    {
                        txt_Category.Text = dt_Details.Rows[0]["Category"].ToString();
                        txt_Pension.Text = dt_Details.Rows[0]["PENSION"].ToString();
                        txt_lifeBenefit.Text = dt_Details.Rows[0]["LIFE_BENEFIT"].ToString();
                        txt_Total.Text = Convert.ToString(Convert.ToDecimal(txt_Pension.Text) + Convert.ToDecimal(txt_lifeBenefit.Text));
                    }
                }
            }
            else
            {
                pnl_CalculatePension.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_Department.SelectedIndex > 0)
            {
                LoadDivision();
                LoadEmployees();

            }
            else
            {
                rad_SubDepartment.ClearSelection();
                rad_SubDepartment.Items.Clear();
                rad_SubDepartment.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                LoadEmployees();
                rdp_DOB.Clear();
                rdp_DOJ.Clear();
                rad_Age.Text = string.Empty;
                // pnl_CalculatePension.Visible = false;
                txt_Category.Text = string.Empty;
                txt_lifeBenefit.Text = string.Empty;
                txt_Pension.Text = string.Empty;
                txt_Total.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rad_Employee.DataSource = DT_Details;
            rad_Employee.DataTextField = "EMPNAME";
            rad_Employee.DataValueField = "EMP_ID";
            rad_Employee.DataBind();
            rad_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            DataTable DT_Details = new DataTable();
            if (rad_BusinessUnit.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.OPERATION = operation.EmployeesBUwise;
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rad_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                if (rad_Directorate.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.DIRECTORATE_ID = Convert.ToInt32(rad_Directorate.SelectedItem.Value);
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDirectoratewise; //Inserted BY Ragha Sudha on 4th oct 2013 for directoratewise
                }
                if (rad_Department.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesDepartmentwise;
                    _obj_smhr_emp_payitems.DEPARTMENT_ID = Convert.ToInt32(rad_Department.SelectedItem.Value);
                }
                if (rad_SubDepartment.SelectedIndex > 0)
                {
                    _obj_smhr_emp_payitems.OPERATION = operation.EmployeesSubDepartmentWise; //Inserted BY Ragha Sudha on 4th oct 2013 for directoratewise
                    _obj_smhr_emp_payitems.SUBDEPARTMENT_ID = Convert.ToInt32(rad_SubDepartment.SelectedItem.Value);
                }
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
                //}
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_SubDepartment_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_SubDepartment.SelectedIndex > 0)
            {
                rad_Employee.Items.Clear();
                LoadEmployees();
            }
            else
            {
                rad_Employee.ClearSelection();
                LoadEmployees();
                rdp_DOB.Clear();
                rdp_DOJ.Clear();
                rad_Age.Text = string.Empty;
                // pnl_CalculatePension.Visible = false;
                txt_Category.Text = string.Empty;
                txt_lifeBenefit.Text = string.Empty;
                txt_Pension.Text = string.Empty;
                txt_Total.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rad_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rad_Employee.SelectedIndex > 0)
            {
                _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.GetEmployeeDOJDOB;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(rad_Employee.SelectedValue);
                dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (dt_Details != null)
                {
                    if (dt_Details.Rows.Count > 0)
                    {
                        rdp_DOB.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["DOB"]);
                        rdp_DOJ.SelectedDate = Convert.ToDateTime(dt_Details.Rows[0]["DOJ"]);

                        DateTime dt = Convert.ToDateTime(rdp_DOB.SelectedDate.Value);
                        DateTime BirthDate = Convert.ToDateTime(rdp_DOB.SelectedDate.Value);
                        dt = dt.AddYears(15);
                        if (dt < DateTime.Now)
                        {
                            int years = DateTime.Now.Year - BirthDate.Year;
                            if (DateTime.Now.Month < BirthDate.Month ||
                            (DateTime.Now.Month == BirthDate.Month &&
                            DateTime.Now.Day < BirthDate.Day))
                                years--;
                            rad_Age.Text = Convert.ToString(years + " yrs");
                        }
                    }
                }
            }
            else
            {
                rdp_DOB.Clear();
                rdp_DOJ.Clear();
                rad_Age.Text = string.Empty;
                //  pnl_CalculatePension.Visible = false;
                txt_Category.Text = string.Empty;
                txt_lifeBenefit.Text = string.Empty;
                txt_Pension.Text = string.Empty;
                txt_Total.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_ViewDetails_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rad_Employee.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputations", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}