using System;
using System.Data;
using System.Data.SqlClient;
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
using Telerik.Web.UI;

public partial class Reportss_ResignationReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RPT_ResignationReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_ResignationReport.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                //Microsoft.Reporting.WebForms.ReportParameter StartDate;
                //Microsoft.Reporting.WebForms.ReportParameter EndDate;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                //Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter StartDate;
                Microsoft.Reporting.WebForms.ReportParameter EndDate;
                Microsoft.Reporting.WebForms.ReportParameter Checked;
                //Microsoft.Reporting.WebForms.ReportParameter Period;

                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "ResignedEmployees";
                //if (Convert.ToString(Request.QueryString["DEPT"]) != null)
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEPT"]));
                //}
                //else
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                //}
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                //if (Convert.ToString(Request.QueryString["DEPT"]) != "")
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEPT"]));
                //}
                //else
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                //}
                if (Convert.ToString(Request.QueryString["From"]) != "")
                {
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", Convert.ToString(Request.QueryString["From"]));
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(1));
                }
                else
                {
                    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", "01/01/2010");
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(0));
                }
                if (Convert.ToString(Request.QueryString["To"]) != "")
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", Convert.ToString(Request.QueryString["To"]));
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(1));
                }
                else
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "01/01/2010");
                    Checked = new Microsoft.Reporting.WebForms.ReportParameter("IncludeDate", Convert.ToString(0));
                }
                //if (Convert.ToString(Request.QueryString["PRD"]) != "")
                //{
                //    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                //}
                //else
                //{
                //    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                //}
                //if (Convert.ToString(Request.QueryString["PRD"]) != "")
                //{
                //    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", Convert.ToString(Request.QueryString["PRD"]));
                //}
                //else
                //{
                //    StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", "-1");
                //}
                //if (Convert.ToString(Request.QueryString["PRD1"]) != "")
                //{
                //    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", Convert.ToString(Request.QueryString["PRD"]));
                //}
                //else
                //{
                //    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "-1");
                //}
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, StartDate, EndDate, Checked };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ResignationReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResignationReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
