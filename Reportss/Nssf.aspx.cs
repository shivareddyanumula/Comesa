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

public partial class Reportss_Nssf : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("NSSF");
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
                    //  Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Submit.Visible = false;
                    //  btn_Update.Visible = false;
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
                LoadCombos1();
                LoadCombos();

            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos1()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_payperiod.DataSource = dt_Details;
            rcmb_payperiod.DataValueField = "PERIOD_ID";
            rcmb_payperiod.DataTextField = "PERIOD_NAME";
            rcmb_payperiod.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        rcmb_payperiod.Items.Insert(0, new RadComboBoxItem("Select"));
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payElements.SelectedValue) + "','" + Convert.ToString(ddl_BusinessUnit.SelectedValue) + "','" + Convert.ToString(ddl_Department.SelectedValue) + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(ddl_BusinessUnit.SelectedValue) + "','"
                + Convert.ToString(rcmb_Directorate.SelectedValue) + "','" + Convert.ToString(ddl_Department.SelectedValue) + "','"
                + Convert.ToString(rcmb_payperiod.SelectedValue) + "','" + Convert.ToString(rcmb_payElements.SelectedValue) + "','" + rcbStatus.SelectedValue + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_payperiod.SelectedIndex = 0;
            //rcmb_payElements.SelectedIndex = 0;
            rcmb_payElements.Items.Clear();
            rcmb_payElements.Text = string.Empty;
            ddl_BusinessUnit.SelectedIndex = 0;
            //ddl_Department.SelectedIndex = 0;
            ddl_Department.Items.Clear();
            ddl_Department.Text = string.Empty;
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcbStatus.SelectedValue = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_period = new SMHR_PERIOD();

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
         //   ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //SMHR_DEPARTMENT _obj_smhr_department = new SMHR_DEPARTMENT();
            //_obj_smhr_department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            //_obj_smhr_department.MODE = 7;
            //DataTable dt_dept = BLL.get_Department(_obj_smhr_department);
            //ddl_Department.DataSource = dt_dept;
            //ddl_Department.DataValueField = "DEPARTMENT_ID";
            //ddl_Department.DataTextField = "DEPARTMENT_NAME";
            //ddl_Department.DataBind();
            //ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));

            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                Load_Directorate();
            }
            else
            {
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                ddl_Department.Items.Clear();
                ddl_Department.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void Load_Directorate()
    {
        try
        {
            rcmb_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (ddl_BusinessUnit.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                    rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                    rcmb_Directorate.DataSource = DT;
                    rcmb_Directorate.DataBind();
                    rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All"));
                }
                else
                {
                    rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_payperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_payperiod.SelectedIndex > 0)
            {
                SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_payperiod.SelectedItem.Value);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_payElements.DataSource = dt_Details;
                    rcmb_payElements.DataValueField = "PRDDTL_ID";
                    rcmb_payElements.DataTextField = "PRDDTL_NAME";
                    rcmb_payElements.DataBind();
                    rcmb_payElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                rcmb_payElements.Items.Clear();
                rcmb_payElements.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_payElements_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void rcmb_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ddl_Department.Items.Clear();
            ddl_Department.Text = string.Empty;
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                LoadDepartment();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDepartment()
    {
        try
        {
            if (ddl_BusinessUnit.SelectedIndex > 0)
            {
                SMHR_DEPARTMENT _obj_SMHR_Department = new SMHR_DEPARTMENT();
                _obj_SMHR_Department.MODE = 7;
                // if (rad_Directorate.SelectedIndex > 0)
                // {
                _obj_SMHR_Department.DIRECTORATE_ID = Convert.ToInt32(rcmb_Directorate.SelectedValue);
                // }
                //else
                //{
                //    _obj_SMHR_Department.MODE = 16;
                //    _obj_SMHR_Department.DIRECTORATE_ID = 0;
                //}
                _obj_SMHR_Department.BUID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                ddl_Department.DataSource = dt;
                ddl_Department.DataTextField = "DEPARTMENT_NAME";
                ddl_Department.DataValueField = "DEPARTMENT_ID";
                ddl_Department.DataBind();
                ddl_Department.Items.Insert(0, new RadComboBoxItem("All"));
            }
            else
            {
                ddl_Department.Items.Clear();
                ddl_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Nssf", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
