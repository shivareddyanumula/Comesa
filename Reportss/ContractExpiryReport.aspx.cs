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

public partial class Reportss_ContractExpiryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_ContractData.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_ContractData.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                //Microsoft.Reporting.WebForms.ReportParameter EMP_LOGIN_ID;
                Microsoft.Reporting.WebForms.ReportParameter StartDate;
                Microsoft.Reporting.WebForms.ReportParameter EndDate;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Contractexpiryreport";
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
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }
                if (Convert.ToString(Request.QueryString["SD"]) != "")
                {
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", Convert.ToString(Request.QueryString["SD"]));
                }
                else
                {
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", "01-01-1900");
                }
                if (Convert.ToString(Request.QueryString["ED"]) != "")
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", Convert.ToString(Request.QueryString["ED"]));
                }
                else
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "01-01-1900");
                }
                //EMP_LOGIN_ID = new Microsoft.Reporting.WebForms.ReportParameter("EMP_LOGIN_ID", Convert.ToString(Session["USER_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, StartDate, EndDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ContractData.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDataReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
