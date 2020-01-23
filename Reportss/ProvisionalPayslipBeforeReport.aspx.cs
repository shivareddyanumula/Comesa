using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_ProvisionalPayslipBeforeReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RPT_ProvisionalPayslip.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_ProvisionalPayslip.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodElement;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "PayrollProcess_Before";

                if (Convert.ToString(Request.QueryString["Employee"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["Employee"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                if (Convert.ToString(Request.QueryString["Organisation"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["Organisation"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BusinessUnit"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BusinessUnit"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["Period"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["Period"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["PeriodElement"]) != "")
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", Convert.ToString(Request.QueryString["PeriodElement"]));
                }
                else
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", "-1");
                }

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Employee, Organisation, BusinessUnit, Period, PeriodElement };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ProvisionalPayslip.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalPayslip", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}