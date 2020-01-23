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

public partial class Reportss_PensionStatementReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_PensionStatement.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_PensionStatement.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter ToDate;
                Microsoft.Reporting.WebForms.ReportParameter SalStruct;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Pension Statement";
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
                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                if (Convert.ToString(Request.QueryString["FRD"]) != "")
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", Convert.ToString(Request.QueryString["FRD"]));
                }
                else
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "-1");
                }
                if (Convert.ToString(Request.QueryString["TOD"]) != "")
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", Convert.ToString(Request.QueryString["TOD"]));
                }
                else
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", "-1");
                }
                if (Convert.ToString(Request.QueryString["SALS"]) != "")
                {
                    SalStruct = new Microsoft.Reporting.WebForms.ReportParameter("SalStruct", Convert.ToString(Request.QueryString["SALS"]));
                }
                else
                {
                    SalStruct = new Microsoft.Reporting.WebForms.ReportParameter("SalStruct", "-1");
                }

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Employee, FromDate, ToDate, SalStruct };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_PensionStatement.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PensionStatementReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}