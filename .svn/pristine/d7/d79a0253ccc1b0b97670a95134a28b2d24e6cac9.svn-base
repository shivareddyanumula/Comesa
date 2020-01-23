using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_PayItemWiseAllocationSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_PayItemWiseAllocation.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_PayItemWiseAllocation.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetail;
                Microsoft.Reporting.WebForms.ReportParameter PayItem;
                Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = ConfigurationManager.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "PayItem Wise Allocation Summary";

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

                if (Convert.ToString(Request.QueryString["PRDTL"]) != "")
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", Convert.ToString(Request.QueryString["PRDTL"]));
                }
                else
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", "-1");
                }

                if (Convert.ToString(Request.QueryString["PAYI"]) != "")
                {
                    PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", Convert.ToString(Request.QueryString["PAYI"]));
                }
                else
                {
                    PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", "-1");
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

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetail, PayItem, Status };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_PayItemWiseAllocation.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PayItemWiseAllocationSummaryReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}