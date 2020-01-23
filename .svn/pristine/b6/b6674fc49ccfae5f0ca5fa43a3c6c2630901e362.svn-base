using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_TrainingCostReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_TrainingCost.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_TrainingCost.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Course;
                Microsoft.Reporting.WebForms.ReportParameter CourseSchedule;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Training Cost";


                if (Convert.ToString(Request.QueryString["CRSE"]) != "")
                {
                    Course = new Microsoft.Reporting.WebForms.ReportParameter("Course", Convert.ToString(Request.QueryString["CRSE"]));
                }
                else
                {
                    Course = new Microsoft.Reporting.WebForms.ReportParameter("Course", "-1");
                }
                if (Convert.ToString(Request.QueryString["CRSHUDLE"]) != "")
                {
                    CourseSchedule = new Microsoft.Reporting.WebForms.ReportParameter("CourseSchedule", Convert.ToString(Request.QueryString["CRSHUDLE"]));
                }
                else
                {
                    CourseSchedule = new Microsoft.Reporting.WebForms.ReportParameter("CourseSchedule", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Course, CourseSchedule };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_TrainingCost.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "TrainingCostReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}