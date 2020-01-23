using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;

public partial class Reportss_Form3AReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_Form3A.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Form3A.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter ToDate;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = MyReportPath + "Form3A";
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
                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "-1");
                }
                if (Convert.ToString(Request.QueryString["EDATE"]) != "")
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", Convert.ToString(Request.QueryString["EDATE"]));
                }
                else
                {
                    ToDate = new Microsoft.Reporting.WebForms.ReportParameter("ToDate", "-1");
                }
                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, Employee, FromDate, ToDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_Form3A.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Form3AReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
