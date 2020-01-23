using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_RegstrUnRegstrAccStmts : System.Web.UI.Page
{
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("County");
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

                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
                {
                    smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                    _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                    _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                    SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                    Response.Redirect("~/frm_UnAuthorized.aspx", false);
                }

                //To load BusinessUnits
                LoadCombos();

                if (Request.QueryString.HasKeys())
                {
                    string control = Convert.ToString(Request.QueryString["Control"]);
                    if (control == "PenCont")
                    {
                        lblHeading.Text = "Employee and Employer Pension Contribution";
                    }
                }
                else
                {
                    lblHeading.Text = "Register And Unregister Account Statements";
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            //To fetch BusinessUnits
            DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), null, null, null);
            rcmb_BusinessUnit.DataSource = ds.Tables[0];
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            //To fetch Periods
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));

            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                LoadEmployees();
            }
            else
            {
                rcmb_Employee.Items.Clear();
                rcmb_Employee.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objEmployee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            objEmployee.OPERATION = operation.GetEmployeePensionDetails;
            DataTable dtEmployees = BLL.get_Employeedetail(objEmployee);
            rcmb_Employee.DataSource = dtEmployees;
            rcmb_Employee.DataTextField = "EMPLOYEENAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.HasKeys())
            {
                string control = Convert.ToString(Request.QueryString["Control"]);
                if (control == "PenCont")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPopup('" + Convert.ToString(Convert.ToInt32(Session["ORG_ID"])) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(control) + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(Convert.ToInt32(Session["ORG_ID"])) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "');", true);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearContols();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void clearContols()
    {
        try
        {
            rcmb_BusinessUnit.ClearSelection();
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
            rcmb_Period.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmts", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}