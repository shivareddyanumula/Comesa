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


public partial class Reportss_Expense_Report : System.Web.UI.Page
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
                LoadCombos();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            RPT_ExpenseReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            serverReport = RPT_ExpenseReport.ServerReport;
            string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            WebClient Wc = new WebClient();
            Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            serverReport.ReportServerCredentials = _ObjNC;
            serverReport.ReportServerUrl = new Uri(sDomain);
            serverReport.ReportPath = "/SmartHR/" + "Employee Expense Report";
            Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
            Microsoft.Reporting.WebForms.ReportParameter Employee;
            Microsoft.Reporting.WebForms.ReportParameter StartDate;
            Microsoft.Reporting.WebForms.ReportParameter EndDate;
            Microsoft.Reporting.WebForms.ReportParameter Includedates;
            Microsoft.Reporting.WebForms.ReportParameter Organisation;
            Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", ddl_BusinessUnit.SelectedValue);
            }
            else
            {
                BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
            }
            if (ddl_Employee.SelectedIndex != 0)
            {
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(ddl_Employee.SelectedValue));
            }
            else
            {
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
            }
            if ((txt_StartDate.SelectedDate != null) && (txt_EndDate.SelectedDate != null))
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("Includedates", "YES");
                StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", txt_StartDate.SelectedDate.Value.ToShortDateString());
                EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", txt_EndDate.SelectedDate.Value.ToShortDateString());
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee, Includedates, StartDate, EndDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ExpenseReport.Visible = true;
            }
            if ((txt_StartDate.SelectedDate != null) && (txt_EndDate.SelectedDate == null))
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("Includedates", "YES");
                StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", txt_StartDate.SelectedDate.Value.ToShortDateString());
                EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", DateTime.Now.ToShortDateString());
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee, Includedates, StartDate, EndDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ExpenseReport.Visible = true;
            }
            else
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("INCLUDEDATES", "NO");
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee, Includedates };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ExpenseReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
        
        
    }

    private void LoadCombos()
    {
        try
        { 
        //_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
        //_obj_smhr_businessunit.OPERATION = operation.Select;
        //_obj_smhr_businessunit.ISDELETED = true;
        //DataTable dt_Details = BLL.get_BusinessUnit(_obj_smhr_businessunit);
        //ddl_BusinessUnit.DataSource = dt_Details;
        //ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        //ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        //ddl_BusinessUnit.DataBind();
        //ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
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
        ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        { 
        SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
        _obj_smhr_emp_payitems.OPERATION = operation.Empty;
        DataTable DT_Details = new DataTable();
        if (ddl_BusinessUnit.SelectedItem.Value != "")
        {
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(ddl_BusinessUnit.SelectedItem.Value);
            DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            if (DT_Details.Rows.Count != 0)
            {
                BindEmployees(DT_Details);
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        else
        {
            BindEmployees(DT_Details);
        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try 
        { 
        ddl_Employee.DataSource = DT_Details;
        ddl_Employee.DataTextField = "EMPNAME";
        ddl_Employee.DataValueField = "EMP_ID";
        ddl_Employee.DataBind();
        ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_BusinessUnit.SelectedIndex = 0;
            ddl_Employee.SelectedIndex = 0;
            txt_StartDate.SelectedDate = null;
            txt_EndDate.SelectedDate = null;
            RPT_ExpenseReport.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Expense_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
