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

public partial class Reportss_Pms_EmpRatingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmpRatingDetailsReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmpRatingDetailsReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter AppraisalCycle;
                Microsoft.Reporting.WebForms.ReportParameter Status;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "ConsolidationRatingReport";
                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["AppCycle"]) != "")
                {
                    AppraisalCycle = new Microsoft.Reporting.WebForms.ReportParameter("AppraisalCycle", Convert.ToString(Request.QueryString["AppCycle"]));
                }
                else
                {
                    AppraisalCycle = new Microsoft.Reporting.WebForms.ReportParameter("AppraisalCycle", "-1");
                }
                if (Convert.ToString(Request.QueryString["Status"]) != "")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["Status"]));
                }
                else
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "Completed");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, AppraisalCycle, Status };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmpRatingDetailsReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Pms_EmpRatingReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
