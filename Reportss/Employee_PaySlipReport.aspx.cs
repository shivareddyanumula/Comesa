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

public partial class Reportss_Employee_PaySlipReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                rv_payslip.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = rv_payslip.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Pay_Slip";
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("PERIOD", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("PERIOD", "-1");
                }
                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", "-1");
                }

                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", "-1");
                }
                if (Convert.ToString(Request.QueryString["DEPT"]) != "")
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEPT"]));
                }
                else
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organization", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Period, Employee, BusinessGroup, Department, Organisation };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                rv_payslip.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_PaySlipReport", ex.StackTrace, DateTime.Now);
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
            byte[] exportBytes = rv_payslip.ServerReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_PaySlipReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
