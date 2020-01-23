﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_NEW_Leave_Balances_Report : System.Web.UI.Page
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("LeaveBalancesReport");
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
                    btn_Generate.Visible = false;

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

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveBalance", ex.StackTrace, DateTime.Now);
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
            //DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails_Calendar(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveBalance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadOrganisation()
    {
        try
        {
            SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
            rcmb_Org.DataSource = dt_logindetails;
            rcmb_Org.DataTextField = "organisation_name";
            rcmb_Org.DataValueField = "organisation_id";
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "YearsInservice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        rcmb_Org.DataBind();
    }
    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            obj_smhr_Logininfo = new SMHR_LOGININFO();
            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();

            //if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
            //    rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            //else
            //    rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            //rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            /////////    rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "YearsInservice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadEmployee()
    {
        try
        {
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            ///  _obj_smhr_emp_payitems.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_emp_payitems.OPERATION = operation.Select_Self;
            DataTable dt_EMP = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            rcmb_Employee.DataSource = dt_EMP;
            rcmb_Employee.DataTextField = "Empname";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveBalance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedValue != "")
            {
                if (Convert.ToString(Session["SELFSERVICE"]) == "ADMIN")
                {
                    obj_smhr_Logininfo = new SMHR_LOGININFO();
                    obj_smhr_Logininfo.OPERATION = operation.Check;
                    string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();
                    //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                    //DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
                    //string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

                    obj_smhr_Logininfo.OPERATION = operation.Check;
                    obj_smhr_Logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
                    DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_Logininfo);

                    rcmb_Employee.Items.Clear();
                    rcmb_Employee.DataSource = dt_getEMP;
                    rcmb_Employee.DataTextField = "EMP_NAME";
                    rcmb_Employee.DataValueField = "EMP_ID";
                    rcmb_Employee.DataBind();
                    //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
                    if (rcmb_BusinessUnit.SelectedValue != "-1")
                        rcmb_Employee.SelectedValue = "-1";
                    LoadPeriod();
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
                    rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
                    LoadPeriod();
                }
            }
            else
            {
                ///rcmb_Employee.Items.Clear();
                //rcmb_Employee.SelectedValue = "-1";                
                //rcmb_Period.SelectedIndex = 0;
                //rcmb_PeriodElements.SelectedIndex = 0;
                rcmb_Employee.Items.Clear();
                rcmb_Employee.Text = string.Empty;
                rcmb_Period.Items.Clear();
                rcmb_Period.Text = string.Empty;
                rcmb_PeriodElements.Items.Clear();
                rcmb_PeriodElements.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "YearsInservice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        if (rcmb_Period.SelectedIndex != 0)
        {
            SMHR_PERIODDTL _obj_smhr_perioddtl = new SMHR_PERIODDTL();
            _obj_smhr_perioddtl.OPERATION = operation.Select;
            _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
            //DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);
            DataTable dt_Details = BLL.get_PeriodDetails_Calendar(_obj_smhr_perioddtl);
            if (dt_Details.Rows.Count != 0)
            {
                rcmb_PeriodElements.DataSource = dt_Details;
                rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                rcmb_PeriodElements.DataBind();
                rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
               /////// LoadEmployee();
            }
        }
        else
        {
            rcmb_PeriodElements.Items.Clear();
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Org.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_PeriodElements.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rcbStatus.SelectedItem.Value) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveBalance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rcmb_Period.Items.Clear();
            rcmb_Period.Text = string.Empty;
            rcmb_PeriodElements.Items.Clear();
            rcmb_PeriodElements.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveBalance", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
