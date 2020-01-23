using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;

public partial class Reportss_Emp_AssignmentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                rv_AssignmentDetails.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = rv_AssignmentDetails.ServerReport;
                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = "/SmartHR/" + "AssignmentDetails";
                serverReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Emp_AssignmentDetails", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
