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

public partial class Reportss_DynamicRepor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                string Reportname = Convert.ToString(Request.QueryString["RPTNAME"]);
                AdhocReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = AdhocReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter ColumnNames;
               


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];

                serverReport.ReportPath = MyReportPath + "Adhoc Report";
                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "" && Convert.ToString(Request.QueryString["ORG_ID"]) != null)
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "" && Convert.ToString(Request.QueryString["BU"]) != null)
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }
                if (Convert.ToString(Request.QueryString["CLMS"]) != "" && Convert.ToString(Request.QueryString["CLMS"]) != null)
                {
                    //ColumnNames = new Microsoft.Reporting.WebForms.ReportParameter("ColumnNames", Convert.ToString(Request.QueryString["CLMS"]));
                    ColumnNames = new Microsoft.Reporting.WebForms.ReportParameter("ColumnNames", Convert.ToString(Request.QueryString["CLMS"]).Split(','));
                }
                else
                {
                    ColumnNames = new Microsoft.Reporting.WebForms.ReportParameter("ColumnNames", "-1");
                    ColumnNames = new Microsoft.Reporting.WebForms.ReportParameter("ColumnNames", Convert.ToString(Request.QueryString["ColumnNames"]).Split(','));
                }
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, ColumnNames };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                AdhocReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "DynamicRepor", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
