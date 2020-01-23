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

public partial class Reportss_EmployeeAgeandGenderWise : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Age And Gender Wise");
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
                    btn_Generate.Visible = false;
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
                LoadOrganisation();
                LoadBusinessUnit();
                rcmb_Organisation.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            //obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            //obj_smhr_Period = new SMHR_PERIOD();

            //obj_smhr_Logininfo = new SMHR_LOGININFO();
            //obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            //DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            //rcmb_BusinessUnit.DataSource = dt_BUDetails;
            //rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //rcmb_BusinessUnit.DataBind();
            //rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Logininfo = new SMHR_LOGININFO();


            if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            {
                obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
                obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    //private void loadDepartment()
    //{
    //    //SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    //    //// _obj_smhr_department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    //_obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //    //_obj_smhr_department.MODE = 7;
    //    //DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
    //    //rcmb_Department.DataSource = dt_dept;
    //    //rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //    //rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //    //rcmb_Department.DataBind();
    //    //rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));

    //    obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
    //    obj_smhr_Period = new SMHR_PERIOD();
    //    obj_smhr_Logininfo = new SMHR_LOGININFO();


    //    if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
    //    {
    //        SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
    //        // _obj_smhr_department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_department.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
    //        _obj_smhr_department.MODE = 7;
    //        DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
    //        rcmb_Department.DataSource = dt_dept;
    //        rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //        rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //        rcmb_Department.DataBind();
    //        rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
    //    }
    //    else
    //    {
    //        _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    //        _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
    //        _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_smhr_emp_payitems.OPERATION = operation.Self;
    //        DataTable dt_BU = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
    //        rcmb_Department.DataSource = dt_BU;
    //        rcmb_Department.DataTextField = "DEPARTMENT_NAME";
    //        rcmb_Department.DataValueField = "DEPARTMENT_ID";
    //        rcmb_Department.DataBind();
    //        rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Organisation.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Organisation.SelectedIndex = 0;
            rcmb_BusinessUnit.SelectedIndex = 0;
            //rcmb_Department.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeAgeandGenderWise", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    loadDepartment();
    //}
}