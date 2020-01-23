using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_Form16 : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_EMPLOYEE obj_smhr_Employee;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_PERIOD obj_smhr_Period;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {


                LoadOrganisation();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOrganisation()
    {
        try
        {
        obj_smhr_Organisation = new SMHR_ORGANISATION();
        obj_smhr_Organisation.MODE = 1;
        DataTable dt_OrganisationDetails = BLL.get_Organisation(obj_smhr_Organisation);
        rcmb_Organisation.DataSource = dt_OrganisationDetails;
        rcmb_Organisation.DataValueField = "ORGANISATION_ID";
        rcmb_Organisation.DataTextField = "ORGANISATION_DESC";
        rcmb_Organisation.DataBind();
        rcmb_Organisation.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            //obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
            ////obj_smhr_Period = new SMHR_PERIOD();

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployee()
    {
        try
        { 
        //obj_smhr_Logininfo = new SMHR_LOGININFO();
        //obj_smhr_Logininfo.OPERATION = operation.Check;
        //string str_BusinessUnit_ID = Convert.ToString(rcmb_BusinessUnit.SelectedValue).ToUpper();
        ////obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
        ////DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
        ////string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

        //obj_smhr_Logininfo.OPERATION = operation.Check;
        //obj_smhr_Logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
        //DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(obj_smhr_Logininfo);

        //rcmb_Employee.Items.Clear();
        //rcmb_Employee.DataSource = dt_getEMP;
        //rcmb_Employee.DataTextField = "EMP_NAME";
        //rcmb_Employee.DataValueField = "EMP_ID";
        //rcmb_Employee.DataBind();
        //rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployee();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rdp_FromDate.SelectedDate) + "','" + Convert.ToString(rcmb_Organisation.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" + Convert.ToString(rdp_ToDate.SelectedDate) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
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
            rdp_FromDate.SelectedDate = null;
            rdp_ToDate.SelectedDate = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form16", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
