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
using System.IO;
using System.Configuration;

public partial class Reportss_New_Reports_EmpLeaveStmtReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_EmpLeaveStmt.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmpLeaveStmt.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter FromDate;
                Microsoft.Reporting.WebForms.ReportParameter EndDate;
                Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string Report_Name = string.Empty;
                Report_Name = "RptEmployeeLeaveStatement";
                serverReport.ReportPath = MyReportPath + Report_Name;
                if (Convert.ToString(Request.QueryString["Emp"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["Emp"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                if (Convert.ToString(Request.QueryString["FD"]) != "")
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", Convert.ToString(Request.QueryString["FD"]));
                }
                else
                {
                    FromDate = new Microsoft.Reporting.WebForms.ReportParameter("FromDate", "-1");
                }
                if (Convert.ToString(Request.QueryString["ED"]) != "")
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", Convert.ToString(Request.QueryString["ED"]));
                }
                else
                {
                    EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "-1");
                }
                if (Convert.ToString(Request.QueryString["ORG"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG"]));
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

                if (Convert.ToString(Request.QueryString["sts"]) != "")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["sts"]));
                }
                else
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation,BusinessUnit,Employee,FromDate,EndDate,Status };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmpLeaveStmt.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmtReport ", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streamids;
            byte[] exportBytes = RPT_EmpLeaveStmt.ServerReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = mimeType;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=ExportedReport." + fileNameExtension);
            HttpContext.Current.Response.BinaryWrite(exportBytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpLeaveStmtReport ", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}