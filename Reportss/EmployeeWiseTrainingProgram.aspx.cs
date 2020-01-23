using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_EmployeeWiseTrainingProgram : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_PERIOD obj_smhr_Period;
    SMHR_TRAINING_LOCATION _obj_Smhr_Location;
    SMHR_LOGININFO obj_smhr_Logininfo;
    string Control;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Page.Validate();
            Control = Convert.ToString(Request.QueryString["Control"]);
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString(lbl_header.Text);//"Employee Wise Training Program");
                if(Control!=null)
                {
                 _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Leave Data");
                }
                else
                {
                    _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Employee Wise Training Program");
                }
                
                        
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
                if (Control != null)
                {
                    if (Control == "IncrementCycle")
                        lbl_header.Text = "Increment Cycle";
                }
                else
                {
                    lbl_header.Text = "Employee Wise Training Program";
                }
                LoadBusinessUnit();
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        Page.Validate();
    }

    protected void Load_Directorate()
    {
        try
        {
            rcmb_Directorate.Items.Clear();
            if (Convert.ToString(Session["ORG_ID"]) != string.Empty)
            {
                if (rcmb_BU.SelectedIndex > 0)
                {
                    SMHR_DIRECTORATE _obj_Smhr_Directorate = new SMHR_DIRECTORATE();
                    _obj_Smhr_Directorate.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Smhr_Directorate.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BU.SelectedValue);
                    DataTable DT = BLL.get_Directorate(_obj_Smhr_Directorate);
                    rcmb_Directorate.DataTextField = "DIRECTORATE_CODE";
                    rcmb_Directorate.DataValueField = "DIRECTORATE_ID";
                    rcmb_Directorate.DataSource = DT;
                    rcmb_Directorate.DataBind();
                    rcmb_Directorate.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDepartment()
    {
        try
        {
            if (rcmb_BU.SelectedIndex != 0)
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
                _obj_SMHR_Department.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
                DataTable dt = BLL.get_Department(_obj_SMHR_Department);
                rcmb_Department.DataSource = dt;
                rcmb_Department.DataTextField = "DEPARTMENT_NAME";
                rcmb_Department.DataValueField = "DEPARTMENT_ID";
                rcmb_Department.DataBind();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Department.Items.Clear();
                rcmb_Department.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Directorate_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_SDepartment.Items.Clear();
            rcmb_SDepartment.Text = string.Empty;
            if (rcmb_Directorate.SelectedIndex > 0)
            {
                LoadDepartment();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadDivision()
    {
        try
        {
            if (rcmb_Department.SelectedValue != null)
            {
                rcmb_SDepartment.Items.Clear();
                obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
                obj_smhr_Businessunit.OPERATION = operation.Select1;
                obj_smhr_Businessunit.BUID = Convert.ToInt32(rcmb_BU.SelectedValue);
                obj_smhr_Businessunit.DEPARTMENT_ID = Convert.ToInt32(rcmb_Department.SelectedValue);
                obj_smhr_Businessunit.DIRECTORATE_ID = Convert.ToInt32(rcmb_Directorate.SelectedValue);
                obj_smhr_Businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable Dt_Divisions = BLL.Get_Divisions(obj_smhr_Businessunit);
                if (Dt_Divisions.Rows.Count > 0)
                {

                    rcmb_SDepartment.DataSource = Dt_Divisions;
                    rcmb_SDepartment.DataTextField = "SMHR_DIV_CODE";
                    rcmb_SDepartment.DataValueField = "SMHR_DIV_ID";
                    rcmb_SDepartment.DataBind();
                }
                rcmb_SDepartment.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_SDepartment.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Department_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcmb_SDepartment.Items.Clear();
            rcmb_SDepartment.Text = string.Empty;
            if (rcmb_Department.SelectedIndex > 0)
            {
                LoadDivision();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                Load_Directorate();
            }
            else
            {
                rcmb_Directorate.Items.Clear();
                rcmb_Directorate.Text = string.Empty;
                rcmb_Department.Items.Clear();
                rcmb_Department.Text = string.Empty;
                rcmb_SDepartment.Items.Clear();
                rcmb_SDepartment.Text = string.Empty;
                //rcmb_Directorate.Items.Clear();
                //rcmb_Directorate.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            string RPT_NAME = string.Empty;
            if (Control != null)
            {
                if (Control == "IncrementCycle")
                    RPT_NAME = "Increment Cycle";

            }
            else
            {
                RPT_NAME = "Employee Wise Training Program";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BU.SelectedValue) + "','" + Convert.ToString(rcmb_Directorate.SelectedValue) + "','" + Convert.ToString(rcmb_Department.SelectedValue) + "','" + Convert.ToString(rcmb_SDepartment.SelectedValue) + "','" + RPT_NAME + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_BU.Items.Clear();
            rcmb_BU.SelectedIndex = 0;
            rcmb_Directorate.Items.Clear();
            rcmb_Directorate.Text = string.Empty;
            rcmb_Department.Items.Clear();
            rcmb_Department.Text = string.Empty;
            rcmb_SDepartment.Items.Clear();
            rcmb_SDepartment.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeWiseTrainingProgram", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}