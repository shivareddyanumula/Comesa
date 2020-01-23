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


public partial class Reportss_PmsGSDoneReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_GSDoneReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_GSDoneReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter AppraisalCycle;
                Microsoft.Reporting.WebForms.ReportParameter RptMgr;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Goal Setting Done";
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
                if (Convert.ToString(Request.QueryString["AppCycle"]) != "")
                {
                    AppraisalCycle = new Microsoft.Reporting.WebForms.ReportParameter("AppraisalCycle", Convert.ToString(Request.QueryString["AppCycle"]));
                }
                else
                {
                    AppraisalCycle = new Microsoft.Reporting.WebForms.ReportParameter("AppraisalCycle", "-1");
                }
                if (Convert.ToString(Request.QueryString["RptMgr"]) != "")
                {
                    RptMgr = new Microsoft.Reporting.WebForms.ReportParameter("RptMgr", Convert.ToString(Request.QueryString["RptMgr"]));
                }
                else
                {
                    RptMgr = new Microsoft.Reporting.WebForms.ReportParameter("RptMgr", "-1");
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, AppraisalCycle, RptMgr };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_GSDoneReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsGSDoneReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    string mimeType;
    //    string encoding;
    //    string fileNameExtension;
    //    Warning[] warnings;
    //    string[] streamids;
    //    byte[] exportBytes = RPT_GSDoneReport.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
    //    HttpContext.Current.Response.Buffer = true;
    //    HttpContext.Current.Response.Clear();
    //    HttpContext.Current.Response.ContentType = mimeType;
    //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=ExportedReport." + fileNameExtension);
    //    HttpContext.Current.Response.BinaryWrite(exportBytes);
    //    HttpContext.Current.Response.Flush();
    //    HttpContext.Current.Response.End();
    //}
}
