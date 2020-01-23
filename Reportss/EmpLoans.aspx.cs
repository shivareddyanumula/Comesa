using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices;
using System.Net;
using Telerik.Web.UI;
using SMHR;

public partial class Reportss_EmpLoans : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_BusinessUnit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadReport()
    {
        //RPT_LoanDetails.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        //Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
        //serverReport = RPT_LoanDetails.ServerReport;
        //string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
        //WebClient Wc = new WebClient();
        //Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
        //serverReport.ReportServerCredentials = _ObjNC;
        //serverReport.ReportServerUrl = new Uri(sDomain);
        //serverReport.ReportPath = "/SmartHR Kenya MT/" + "Loan Statement";
        //Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
        //Microsoft.Reporting.WebForms.ReportParameter Employee;
        //Microsoft.Reporting.WebForms.ReportParameter Organisation;
        //if (ddl_BusinessUnit.SelectedIndex != 0)
        //{
        //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", ddl_BusinessUnit.SelectedValue);
        //}
        //else
        //{
        //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
        //}
        //if (ddl_Employee.SelectedIndex != 0)
        //{
        //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(ddl_Employee.SelectedValue));
        //}
        //else
        //{
        //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
        //}
        //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
        //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee, Organisation };
        //serverReport.SetParameters(parameters);
        //serverReport.Refresh();
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
            LoadReport();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployees()
    {
        try
        {
            _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (ddl_BusinessUnit.SelectedIndex != 0)
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            ddl_Employee.DataSource = DT_Details;
            ddl_Employee.DataTextField = "Empname";
            ddl_Employee.DataValueField = "EMP_ID";
            ddl_Employee.DataBind();
            ddl_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void ddl_Employee_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //LoadReport();
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(ddl_Employee.SelectedValue) + "','" + Convert.ToString(ddl_BusinessUnit.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_BusinessUnit.SelectedIndex = 0;
            ddl_Employee.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLoans", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
