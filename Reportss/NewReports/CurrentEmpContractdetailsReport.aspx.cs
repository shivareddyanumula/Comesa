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
public partial class Reportss_NEW_CurrentEmpContractdetailsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_Cecd.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Cecd.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter ORGANISATION;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                //Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
         Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = MyReportPath + "RptCurrentEmployeeContract";


                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", "-1");
                }

                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("EMPLOYEE", "-1");
                }
                if (Convert.ToString(Request.QueryString["ORG"]) != "")
                {
                    ORGANISATION = new Microsoft.Reporting.WebForms.ReportParameter("ORGANISATION", Convert.ToString(Request.QueryString["ORG"]));
                }
                else
                {
                    ORGANISATION = new Microsoft.Reporting.WebForms.ReportParameter("ORGANISATION", "-1");
                }

                ///  Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                if (Convert.ToString(Request.QueryString["sts"]) != "")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["sts"]));
                }
                else
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { ORGANISATION, BusinessGroup, Employee ,Status};
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_Cecd.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "CurrentEmpContractdetailsReport", ex.StackTrace, DateTime.Now);
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
            byte[] exportBytes = RPT_Cecd.ServerReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "CurrentEmpContractdetailsReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}

