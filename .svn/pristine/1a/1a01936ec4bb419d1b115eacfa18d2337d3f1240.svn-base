using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_MonitoringEmployeePensionContributionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            RPT_MonitoringEmployeePensionContributionReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            serverReport = RPT_MonitoringEmployeePensionContributionReport.ServerReport;

            Microsoft.Reporting.WebForms.ReportParameter Organisation;
            Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
            Microsoft.Reporting.WebForms.ReportParameter Directorate;
            Microsoft.Reporting.WebForms.ReportParameter Department;
            Microsoft.Reporting.WebForms.ReportParameter SubDepartment;
            Microsoft.Reporting.WebForms.ReportParameter Employee;
            Microsoft.Reporting.WebForms.ReportParameter year;
            Microsoft.Reporting.WebForms.ReportParameter month;

            string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
            WebClient wc = new WebClient();
            Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            serverReport.ReportServerCredentials = _ObjNC;
            serverReport.ReportServerUrl = new Uri(sDomain);
            serverReport.ReportPath = MyReportPath + "Employee Pension Details";
            Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
            if (Convert.ToString(Request.QueryString["BU"]) != "")
            {
                BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
            }
            else
            {
                BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
            }
            if (Convert.ToString(Request.QueryString["Department"]) != "")
            {
                Department = new Microsoft.Reporting.WebForms.ReportParameter("Department ", Convert.ToString(Request.QueryString["Department"]));
            }
            else
            {
                Department = new Microsoft.Reporting.WebForms.ReportParameter("Department ", "-1");
            }
            if (Convert.ToString(Request.QueryString["Directorate"]) != "")
            {
                Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", Convert.ToString(Request.QueryString["Directorate"]));
            }
            else
            {
                Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", "-1");
            }
            if (Convert.ToString(Request.QueryString["SubDivision"]) != "")
            {
                SubDepartment = new Microsoft.Reporting.WebForms.ReportParameter("SubDivision", Convert.ToString(Request.QueryString["SubDivision"]));
            }
            else
            {
                SubDepartment = new Microsoft.Reporting.WebForms.ReportParameter("SubDivision", "-1");
            }
            if (Convert.ToString(Request.QueryString["EMP"]) != "")
            {
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
            }
            else
            {
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
            }
            if (Convert.ToString(Request.QueryString["year"]) != "")
            {
                year = new Microsoft.Reporting.WebForms.ReportParameter("Year", Convert.ToString(Request.QueryString["year"]));
            }
            else
            {
                year = new Microsoft.Reporting.WebForms.ReportParameter("Year", "-1");
            }
            if (Convert.ToString(Request.QueryString["month"]) != "")
            {
                month = new Microsoft.Reporting.WebForms.ReportParameter("Month", Convert.ToString(Request.QueryString["month"]));
            }
            else
            {
                month = new Microsoft.Reporting.WebForms.ReportParameter("Month", "-1");
            }

            Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, Directorate, Department, year, month, SubDepartment, Employee };
            serverReport.SetParameters(parameters);
            serverReport.Refresh();
            RPT_MonitoringEmployeePensionContributionReport.Visible = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MonitoringEmployeePensionContributionReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
