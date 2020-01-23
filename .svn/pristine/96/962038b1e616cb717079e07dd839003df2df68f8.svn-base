using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;

public partial class Reportss_EmployeeSalaryRegisterReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmployeeSalaryRegister.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeeSalaryRegister.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodElement;
                Microsoft.Reporting.WebForms.ReportParameter Employee;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "EmployeeSalaryRegister";
                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["prddtl"]) != "")
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", Convert.ToString(Request.QueryString["prddtl"]));
                }
                else
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", "-1");
                }
                if (Convert.ToString(Request.QueryString["emp"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["emp"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, Period, PeriodElement, Employee };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmployeeSalaryRegister.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeSalaryRegisterReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
