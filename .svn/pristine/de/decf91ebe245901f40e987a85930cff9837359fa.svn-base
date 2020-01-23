using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_EmployeeRetirmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmployeeRetirment.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeeRetirment.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                // Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                //Microsoft.Reporting.WebForms.ReportParameter EMP_LOGIN_ID;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter ToDate;

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
                // EMP_LOGIN_ID = new Microsoft.Reporting.WebForms.ReportParameter("EMP_LOGIN_ID", Convert.ToString(Session["USER_ID"]));
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, FromDate, ToDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmployeeRetirment.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeRetirmentReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    
    }
}