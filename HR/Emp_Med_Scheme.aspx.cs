using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;

public partial class HR_Emp_Med_Scheme : System.Web.UI.Page
{
    SMHR_EMP_MED_SCHEME _obj_Med_Scheme;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE MEDICAL SCHEME");
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
                RG_MED_SCHEME.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;


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
            LoadCombos();
            lbl_ID.Text = string.Empty;
        }
      }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadData()
    {
        try
        {
            _obj_Med_Scheme = new SMHR_EMP_MED_SCHEME();
            _obj_Med_Scheme.Mode = 1;
            _obj_Med_Scheme.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Emp_Med_scheme(_obj_Med_Scheme);
            RG_MED_SCHEME.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void RG_MED_SCHEME_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_MED_SCHEME.SelectedIndex = 1;
            ddl_BusinessUnit.Enabled = true;
            ddl_Employee.Enabled = true;
            ddl_Period.Enabled = true;
            clearFields();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            lbl_ID.Text = Convert.ToString(e.CommandArgument);
            _obj_Med_Scheme = new SMHR_EMP_MED_SCHEME();
            _obj_Med_Scheme.Mode = 2;
            _obj_Med_Scheme.SMHR_MED_ID = Convert.ToInt32(lbl_ID.Text);
            _obj_Med_Scheme.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_Emp_Med_scheme(_obj_Med_Scheme);
            if (dt.Rows.Count != 0)
            {
                LoadCombos();
                ddl_BusinessUnit.SelectedIndex = ddl_BusinessUnit.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_MED_BU_ID"]));
                //ddl_BusinessUnit_SelectedIndexChanged(null, null);
                LoadEmployees_Edit();
                ddl_Employee.SelectedIndex = ddl_Employee.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_MED_EMP_ID"]));
                ddl_Period.SelectedIndex = ddl_Period.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["SMHR_MED_PERIOD_ID"]));
                txt_IP_Av_Amt.Value = Convert.ToDouble(dt.Rows[0]["SMHR_MED_IP_AV_AMT"]);
                txt_OP_Av_Amt.Value = Convert.ToDouble(dt.Rows[0]["SMHR_MED_OP_AV_AMT"]);
                Load_Med_Details();
            }
            RMP_MED_SCHEME.SelectedIndex = 1;
            ddl_BusinessUnit.Enabled = false;
            ddl_Employee.Enabled = false;
            ddl_Period.Enabled = false;
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {

                btn_Submit.Visible = false;


            }
            else
            {
                btn_Submit.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl_ID.Text == string.Empty)
            {
                _obj_Med_Scheme = new SMHR_EMP_MED_SCHEME();
                _obj_Med_Scheme.Mode = 5;
                _obj_Med_Scheme.SMHR_MED_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                _obj_Med_Scheme.SMHR_MED_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                _obj_Med_Scheme.SMHR_MED_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedValue);
                _obj_Med_Scheme.SMHR_MED_IP_AV_AMT = Convert.ToDouble(txt_IP_Av_Amt.Value);
                _obj_Med_Scheme.SMHR_MED_OP_AV_AMT = Convert.ToDouble(txt_OP_Av_Amt.Value);
                _obj_Med_Scheme.SMHR_MED_CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _obj_Med_Scheme.SMHR_MED_CREATEDDATE = DateTime.Now;
                _obj_Med_Scheme.SMHR_MED_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt = BLL.get_Emp_Med_scheme(_obj_Med_Scheme);
                if (dt.Rows.Count == 0)
                {
                    _obj_Med_Scheme.Mode = 3;
                    bool status = BLL.set_Emp_Med_Scheme(_obj_Med_Scheme);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Employee Medical Scheme Details Added Successfully");
                        LoadData();
                        RG_MED_SCHEME.DataBind();
                        RMP_MED_SCHEME.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "An Error Occured while performing the request");
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Medical Scheme Details of Employee for this period is already defined");
                    return;
                }
            }
            else
            {
                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = Convert.ToInt32(ddl_Employee.SelectedItem.Value);
                //dt_Details = new DataTable();
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);
                if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 1)
                {
                    BLL.ShowMessage(this, "Employee is Resigned.You can not update the record.");
                    return;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 2)
                {
                    BLL.ShowMessage(this, "Employee is Relieved.You can not update the record.");
                    return;
                }
                else if (Convert.ToInt32(dt_Details.Rows[0]["EMP_STATUS"]) == 3)
                {
                    BLL.ShowMessage(this, "Employee is Rehired.You can not update the record.");
                    return;
                }
                else
                {
                    _obj_Med_Scheme = new SMHR_EMP_MED_SCHEME();
                    _obj_Med_Scheme.Mode = 4;
                    _obj_Med_Scheme.SMHR_MED_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_Med_Scheme.SMHR_MED_BU_ID = Convert.ToInt32(ddl_BusinessUnit.SelectedValue);
                    _obj_Med_Scheme.SMHR_MED_EMP_ID = Convert.ToInt32(ddl_Employee.SelectedValue);
                    _obj_Med_Scheme.SMHR_MED_PERIOD_ID = Convert.ToInt32(ddl_Period.SelectedValue);
                    _obj_Med_Scheme.SMHR_MED_IP_AV_AMT = Convert.ToDouble(txt_IP_Av_Amt.Value);
                    _obj_Med_Scheme.SMHR_MED_OP_AV_AMT = Convert.ToDouble(txt_OP_Av_Amt.Value);
                    _obj_Med_Scheme.SMHR_MED_LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
                    _obj_Med_Scheme.SMHR_MED_ID = Convert.ToInt32(lbl_ID.Text);
                    _obj_Med_Scheme.SMHR_MED_LASTMDFDATE = DateTime.Now;
                    bool status = BLL.set_Emp_Med_Scheme(_obj_Med_Scheme);
                    if (status == true)
                    {
                        BLL.ShowMessage(this, "Employee Medical Scheme Details Updated Successfully");
                        LoadData();
                        RG_MED_SCHEME.DataBind();
                        RMP_MED_SCHEME.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "An Error Occured while performing the request");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            RMP_MED_SCHEME.SelectedIndex = 0;
            clearFields();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            ddl_BusinessUnit.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            ddl_Period.DataSource = dt_Details;
            ddl_Period.DataValueField = "PERIOD_ID";
            ddl_Period.DataTextField = "PERIOD_NAME";
            ddl_Period.DataBind();
            ddl_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);//AS IT  IS DISPLAYING BUSINESSUNITS BASED ON THE ORGANISATION.
                if (DT_Details.Rows.Count != 0)
                {
                    ddl_Employee.DataSource = DT_Details;
                    ddl_Employee.DataTextField = "EMPNAME";
                    ddl_Employee.DataValueField = "EMP_ID";
                    ddl_Employee.DataBind();
                    ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    ddl_Employee.DataSource = DT_Details;
                    ddl_Employee.DataTextField = "EMPNAME";
                    ddl_Employee.DataValueField = "EMP_ID";
                    ddl_Employee.DataBind();
                    ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    private void LoadEmployees_Edit()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty1;
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
                _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);//AS IT  IS DISPLAYING BUSINESSUNITS BASED ON THE ORGANISATION.
                if (DT_Details.Rows.Count != 0)
                {
                    ddl_Employee.DataSource = DT_Details;
                    ddl_Employee.DataTextField = "EMPNAME";
                    ddl_Employee.DataValueField = "EMP_ID";
                    ddl_Employee.DataBind();
                    ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
                else
                {
                    ddl_Employee.DataSource = DT_Details;
                    ddl_Employee.DataTextField = "EMPNAME";
                    ddl_Employee.DataValueField = "EMP_ID";
                    ddl_Employee.DataBind();
                    ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
            else
            {
                ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void Load_Med_Details()
    {
        try
        {
            _obj_Med_Scheme = new SMHR_EMP_MED_SCHEME();
            _obj_Med_Scheme.Mode = 1;
            _obj_Med_Scheme.SMHR_MED_ID = Convert.ToInt32(lbl_ID.Text);
            //_obj_Med_Scheme.SMHR_MED_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);AS IT DOESN'T HAVE ANY COLUMN RELATED TO ORGANISATION
            DataTable dt = BLL.get_Emp_Med_scheme_Details(_obj_Med_Scheme);
            RG_MED_DETAILS.DataSource = dt;
            RG_MED_DETAILS.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void clearFields()
    {
        try
        {
            txt_IP_Av_Amt.Value = null;
            txt_OP_Av_Amt.Value = null;
            ddl_BusinessUnit.SelectedIndex = 0;
            ddl_Employee.Items.Clear();
            ddl_Period.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_Med_Scheme", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
