using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_LeaveAllowancesPaidReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_LeaveAllowances.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_LeaveAllowances.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetails;
                Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPT"]);
                //if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                //}
                //else
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                //}
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRDDTL"]) != "")
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "-1");
                }

                if (Convert.ToString(Request.QueryString["Sts"]) != "")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["Sts"]));
                }
                else
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                if (Convert.ToString(Request.QueryString["RPT"]) == "Allocation Summary")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetails, Status };
                    serverReport.SetParameters(parameters);
                }
                else
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetails };
                    serverReport.SetParameters(parameters);
                }

                serverReport.Refresh();
                RPT_LeaveAllowances.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LeaveAllowancesPaidReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}