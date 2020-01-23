using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;
using Telerik.Web.UI;


public partial class Reportss_EmployeeSkillReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RPT_EmployeeSkill.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeeSkill.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BUSINESSUNIT;
                Microsoft.Reporting.WebForms.ReportParameter EMPLOYEE;
                Microsoft.Reporting.WebForms.ReportParameter SKILLS;
                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Employee_Skills_Report";




                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BUSINESSUNIT = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BUSINESSUNIT = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", "-1");
                }
                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    EMPLOYEE = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    EMPLOYEE = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", "-1");
                }
                if (Convert.ToString(Request.QueryString["SKL"]) != "")
                {
                    SKILLS = new Microsoft.Reporting.WebForms.ReportParameter("SKILLS", Convert.ToString(Request.QueryString["SKL"]));
                }
                else
                {
                    SKILLS = new Microsoft.Reporting.WebForms.ReportParameter("SKILLS", "-1");
                }
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("ORGANISATION", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BUSINESSUNIT, EMPLOYEE, SKILLS };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmployeeSkill.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeSkillReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
