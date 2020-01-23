using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Net;

public partial class Reportss_ResourcesStatusReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_ResourcesStatus.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_ResourcesStatus.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter ORG;
                Microsoft.Reporting.WebForms.ReportParameter BU;
                Microsoft.Reporting.WebForms.ReportParameter RMANAGER;
                //Microsoft.Reporting.WebForms.ReportParameter EMP_LOGIN_ID;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Resources Status";

                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BU = new Microsoft.Reporting.WebForms.ReportParameter("BU", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BU = new Microsoft.Reporting.WebForms.ReportParameter("BU", "-1");
                }
                if (Convert.ToString(Request.QueryString["Rep_Emp"]) != "")
                {
                    RMANAGER = new Microsoft.Reporting.WebForms.ReportParameter("RMANAGER", Convert.ToString(Request.QueryString["Rep_Emp"]));
                }
                else
                {
                    RMANAGER = new Microsoft.Reporting.WebForms.ReportParameter("RMANAGER", "-1");
                }

                //EMP_LOGIN_ID = new Microsoft.Reporting.WebForms.ReportParameter("EMP_LOGIN_ID", Convert.ToString(Session["USER_ID"]));
                ORG = new Microsoft.Reporting.WebForms.ReportParameter("ORG", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { ORG, BU, RMANAGER };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_ResourcesStatus.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatusReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}