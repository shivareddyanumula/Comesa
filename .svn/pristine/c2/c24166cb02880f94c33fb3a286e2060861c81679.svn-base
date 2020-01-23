using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_MedicalServiceProviderReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_MedicalServiceProvider.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_MedicalServiceProvider.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter ToDate;
                Microsoft.Reporting.WebForms.ReportParameter ServiceProvider;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPT"]);

                if (Convert.ToString(Request.QueryString["FD"]) != "")
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", Convert.ToString(Request.QueryString["FD"]));
                }
                else
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "01-01-1900");
                }
                if (Convert.ToString(Request.QueryString["TD"]) != "")
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", Convert.ToString(Request.QueryString["TD"]));
                }
                else
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", "01-01-1900");
                }
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                ServiceProvider = new Microsoft.Reporting.WebForms.ReportParameter("ServiceProvider", Convert.ToString(Request.QueryString["SP"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, FromDate, ToDate, ServiceProvider };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_MedicalServiceProvider.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalServiceProviderReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}