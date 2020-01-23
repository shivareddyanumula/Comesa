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


public partial class Reportss_EmployeeDetailsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmployeeDetails.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeeDetails.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter EMP_LOGIN_ID;
                Microsoft.Reporting.WebForms.ReportParameter STARTDATE;
                Microsoft.Reporting.WebForms.ReportParameter ENDDATE;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "EmployeeDetailsReport";
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
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["SD"]) != "")
                {
                    STARTDATE = new Microsoft.Reporting.WebForms.ReportParameter("STARTDATE", Convert.ToString(Request.QueryString["SD"]));
                }
                else
                {
                    STARTDATE = new Microsoft.Reporting.WebForms.ReportParameter("STARTDATE", "01-01-1900");
                }
                if (Convert.ToString(Request.QueryString["ED"]) != "")
                {
                    ENDDATE = new Microsoft.Reporting.WebForms.ReportParameter("ENDDATE", Convert.ToString(Request.QueryString["ED"]));
                }
                else
                {
                    ENDDATE = new Microsoft.Reporting.WebForms.ReportParameter("ENDDATE", "01-01-1900");
                }
                EMP_LOGIN_ID = new Microsoft.Reporting.WebForms.ReportParameter("EMP_LOGIN_ID", Convert.ToString(Session["USER_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, EMP_LOGIN_ID, STARTDATE, ENDDATE };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmployeeDetails.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDetailsReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
