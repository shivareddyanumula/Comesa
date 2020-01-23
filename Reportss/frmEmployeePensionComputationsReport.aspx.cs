using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_frmEmployeePensionComputationsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmployeePensionComputationsReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeePensionComputationsReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Pension and Life Benefits Report";

                if (Convert.ToString(Request.QueryString["EMP_ID"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP_ID"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Employee };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEmployeePensionComputationsReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}