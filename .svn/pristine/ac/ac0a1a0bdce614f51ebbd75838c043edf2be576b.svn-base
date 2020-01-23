using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;
using Telerik.Web.UI;


public partial class Reportss_SalaryRegisterReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RPT_SalaryRegister.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_SalaryRegister.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Salary Register";

                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", "-1");
                }

                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("PERIOD", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("PERIOD", "-1");
                }

                if (Convert.ToString(Request.QueryString["Sts"]) != "")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["Sts"]));
                }
                else
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["Sts"]));
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Period, BusinessGroup, Status };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_SalaryRegister.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SalaryRegisterReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
