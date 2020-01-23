using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_PensionComputation : System.Web.UI.Page
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Pension Computation");
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
                lblHeading.Text = "Pension Computation";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
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
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select", "0"));

            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                //To fetch directorates
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                BindDirectorate(ds.Tables[1]);
                LoadEmployees();
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
            }
            else
            {
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_Employee.Items.Clear();
                rcmb_Employee.Text = string.Empty;
                rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Directorate_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                BindDepartment(ds.Tables[2]);

                //To populate employee details
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
            else
            {
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), null, null);
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
                rcmb_Department.Items.Clear();
                rcmb_Department.ClearSelection();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Department.SelectedIndex > 0)
            {
                
                //To populate employee details
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), Convert.ToInt32(rcmb_Department.SelectedValue));
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
            else
            {
                //DataSet ds = BLL.GetEmployeeFilterDetails(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcmb_BusinessUnit.SelectedValue), Convert.ToInt32(rcmb_Directorate.SelectedValue), null);
                //BindEmployee(ds.Tables[3]);
                LoadEmployees();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindDirectorate(DataTable dt)
    {
        try
        {
            rcmb_Directorate.DataSource = dt;
            rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
            rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
            rcmb_Directorate.DataBind();
            rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void BindDepartment(DataTable dt)
    {
        try
        {
            rcmb_Department.DataSource = dt;
            rcmb_Department.DataTextField = "DEPARTMENT_NAME";
            rcmb_Department.DataValueField = "DEPARTMENT_ID";
            rcmb_Department.DataBind();
            rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            SMHR_EMPLOYEE objEmployee = new SMHR_EMPLOYEE();
            objEmployee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            objEmployee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                objEmployee.EMP_DIRECTORATE_ID = Convert.ToInt32(rcmb_Directorate.SelectedValue);
            }
            if (rcmb_Department.SelectedIndex > 0)
            {
                objEmployee.EMP_DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedValue);
            }
            objEmployee.OPERATION = operation.Chk;
            DataTable dtEmployees = BLL.get_Employeedetail(objEmployee);
            rcmb_Employee.DataSource = dtEmployees;
            rcmb_Employee.DataTextField = "EMPLOYEENAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(Convert.ToInt32(Session["ORG_ID"])) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Period.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(Convert.ToInt32(Session["ORG_ID"])) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Directorate.SelectedValue) + "','" + Convert.ToString(rcmb_Department.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.ClearSelection();
            //rcmb_BusinessUnit.Text = string.Empty;
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_Employee.Items.Clear();
            rcmb_Employee.Text = string.Empty;
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionComputation", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}