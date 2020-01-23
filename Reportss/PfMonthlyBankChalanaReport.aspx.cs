using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;

public partial class Reportss_PfMonthlyBankChalanaReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_PfMonthlyBankChalana.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_PfMonthlyBankChalana.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Oganisation;
                Microsoft.Reporting.WebForms.ReportParameter Period;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = MyReportPath + "PfMonthlyBankChalana";
                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                {
                    Oganisation = new Microsoft.Reporting.WebForms.ReportParameter("Oganisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    Oganisation = new Microsoft.Reporting.WebForms.ReportParameter("Oganisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Oganisation, Period };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_PfMonthlyBankChalana.Visible = true;
            }
        }
       catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PfMonthlyBankChalanaReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
          
        
    }
}
