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

public partial class Reportss_Death_EmployeesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            if (!Page.IsPostBack)
            {
                RPT_Death_Employees.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Death_Employees.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter StartDate;
                Microsoft.Reporting.WebForms.ReportParameter EndDate;
                Microsoft.Reporting.WebForms.ReportParameter Checked;
                //Microsoft.Reporting.WebForms.ReportParameter Period;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Death_EmployeesReport";
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
                if (Convert.ToString(Request.QueryString["From"]) != "")
                {
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", Convert.ToString(Request.QueryString["From"]));
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(1));
                }
                else
                {
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(0));
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", "01/01/2010");
                }
                if (Convert.ToString(Request.QueryString["To"]) != "")
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", Convert.ToString(Request.QueryString["To"]));
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(1));
                }
                else
                {
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(0));
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "01/01/2010");
                }
                //if (Convert.ToString(Request.QueryString["CHK"]) != "")
                //{
                //    if (Convert.ToString(Request.QueryString["CHK"]) == "true")
                //    {
                //    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(1));
                //    }
                //    else
                //    {
                //        Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(0));
                //    }

                //}
                //else
                //{
                //    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", "-1");
                //}
                //if (Convert.ToString(Request.QueryString["PRD"]) != "")
                //{
                //    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                //}
                //else
                //{
                //    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                //}
                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, StartDate, EndDate, Checked };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_Death_Employees.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Death_EmployeesReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
