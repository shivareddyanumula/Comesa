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
using RECRUITMENT;
public partial class Reportss_JobofferReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                RPT_JobOfferReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_JobOfferReport.ServerReport;
                RPT_JobOfferReport.AsyncRendering = false;
                if (!RPT_JobOfferReport.Enabled)
                {
                    RPT_JobOfferReport.CurrentPage = 1;
                }


                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "JobOffer";
                Microsoft.Reporting.WebForms.ReportParameter ApplicantId;
                Microsoft.Reporting.WebForms.ReportParameter JobId;
                if (Convert.ToString(Request.QueryString["ApplicantId"]) != "")
                {
                    ApplicantId = new Microsoft.Reporting.WebForms.ReportParameter("ApplicantId", Session["JOBOFFRS_APPLICANT_ID"].ToString());
                    //  Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    ApplicantId = new Microsoft.Reporting.WebForms.ReportParameter("ApplicantId", "-1");
                }
                if (Convert.ToString(Request.QueryString["JobId"]) != "")
                {
                    JobId = new Microsoft.Reporting.WebForms.ReportParameter("JobId", Session["JOBOFFRS_APPLICANT_ID"].ToString());
                    //  Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    JobId = new Microsoft.Reporting.WebForms.ReportParameter("JobId", "-1");
                }



                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { ApplicantId, JobId };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_JobOfferReport.Visible = true;

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "JobofferReport122", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



}
