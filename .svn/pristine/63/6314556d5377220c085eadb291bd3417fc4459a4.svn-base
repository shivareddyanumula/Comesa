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

public partial class Reportss_NewReports_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_Ec.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Ec.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                //Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodElement;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                ///////  Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                
                if (Convert.ToString(Session["frm"]) == "edu")
                    serverReport.ReportPath = MyReportPath + "EducationClaimBalanceReport";
                else
                    serverReport.ReportPath = MyReportPath + "MedicalClaimReport";

                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("EMPBUSINESSUNITID", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("EMPBUSINESSUNITID", "-1");
                }

                //if (Convert.ToString(Request.QueryString["EMP"]) != "")
                //{
                //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                //}
                //else
                //{
                //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                //}
                //if (Convert.ToString(Request.QueryString["ORG"]) != "")
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG"]));
                //}
                //else
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                //}


                if (Convert.ToString(Request.QueryString["Emp"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPID", Convert.ToString(Request.QueryString["Emp"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPID", "-1");
                }


                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("EDUPERIODID", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("EDUPERIODID", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRDDTL"]) != "")
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PRDDTLID", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PRDDTLID", "-1");
                }
                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee, Period, PeriodElement };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_Ec.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SpouseReport", ex.StackTrace, DateTime.Now);
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
            byte[] exportBytes = RPT_Ec.ServerReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "SpouseReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}