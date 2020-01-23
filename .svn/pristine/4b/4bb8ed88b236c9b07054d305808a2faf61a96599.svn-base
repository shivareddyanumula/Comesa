using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_WorkmansCompensationReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_WorkmansCompensation.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_WorkmansCompensation.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Scale;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter ToDate;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetails;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Workmans compensation";
                //Scale = new Microsoft.Reporting.WebForms.ReportParameter("Scale", "26");
                //FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "01-01-1900");
                //ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", "01-01-1900");
                //PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "287");
                //Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "0");
                if (string.Compare(Request.QueryString["RPTTYPE"], "ScaleWise", true) == 0 && Request.QueryString["SCL"] != null)
                {
                    Scale = new Microsoft.Reporting.WebForms.ReportParameter("Scale", Convert.ToString(Request.QueryString["SCL"]));
                }
                else
                {
                    Scale = new Microsoft.Reporting.WebForms.ReportParameter("Scale", "-1");
                }

                if (Convert.ToString(Request.QueryString["FD"]) != null && !string.IsNullOrEmpty(Request.QueryString["FD"]))
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", Convert.ToDateTime(Request.QueryString["FD"]).ToString("MM/dd/yyyy"));
                }
                else
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "01-01-1900");
                }
                if (Convert.ToString(Request.QueryString["TD"]) != null && !string.IsNullOrEmpty(Request.QueryString["TD"]))
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", Convert.ToDateTime(Request.QueryString["TD"]).ToString("MM/dd/yyyy"));
                }
                else
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", "01-01-1900");
                }
                if (string.Compare(Request.QueryString["RPTTYPE"], "Monthly", true) == 0 && Convert.ToString(Request.QueryString["PRD"]) != null)
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (string.Compare(Request.QueryString["RPTTYPE"], "Monthly", true) == 0 && Convert.ToString(Request.QueryString["PRDDTL"]) != null)
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "-1");
                }
                //EMP_LOGIN_ID = new Microsoft.Reporting.WebForms.ReportParameter("EMP_LOGIN_ID", Convert.ToString(Session["USER_ID"]));
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Scale, FromDate, ToDate, Period, PeriodDetails };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_WorkmansCompensation.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "WorkmansCompensationReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    
    }
}


