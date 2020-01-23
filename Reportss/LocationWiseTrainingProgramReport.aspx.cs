using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_LocationWiseTrainingProgramReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_LocationWiseTraining.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_LocationWiseTraining.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Location;
                Microsoft.Reporting.WebForms.ReportParameter Course;
                Microsoft.Reporting.WebForms.ReportParameter Batch;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetail;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPT"]);


                if (Convert.ToString(Request.QueryString["LT"]) != "" && Convert.ToString(Request.QueryString["LT"]) != "0")
                {
                    Location = new Microsoft.Reporting.WebForms.ReportParameter("Location", Convert.ToString(Request.QueryString["LT"]));
                }
                else
                {
                    Location = new Microsoft.Reporting.WebForms.ReportParameter("Location", "-1");
                }
                if (Convert.ToString(Request.QueryString["CRSE"]) != "")
                {
                    Course = new Microsoft.Reporting.WebForms.ReportParameter("Course", Convert.ToString(Request.QueryString["CRSE"]));
                }
                else
                {
                    Course = new Microsoft.Reporting.WebForms.ReportParameter("Course", "-1");
                }
                if (Convert.ToString(Request.QueryString["BTCH"]) != "")
                {
                    Batch = new Microsoft.Reporting.WebForms.ReportParameter("Batch", Convert.ToString(Request.QueryString["BTCH"]));
                }
                else
                {
                    Batch = new Microsoft.Reporting.WebForms.ReportParameter("Batch", "-1");
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
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", "-1");
                }
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters;
                if (Convert.ToString(Request.QueryString["RPT"]) == "Location Wise Training Programs")
                {
                    parameters = new Microsoft.Reporting.WebForms.ReportParameter[] { Organisation, Location, Course, Batch, Period, PeriodDetail };
                }
                else
                {
                    parameters = new Microsoft.Reporting.WebForms.ReportParameter[] { Organisation, Course, Batch };
                }

                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_LocationWiseTraining.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LocationWiseTrainingProgramReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    
    }
}