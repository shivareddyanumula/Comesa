using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Reportss_StaffEstablishmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_StaffEstablishment.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_StaffEstablishment.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                //Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Jobs;
                Microsoft.Reporting.WebForms.ReportParameter FinancialYear;

                string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationManager.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Establishment Summary";

                //if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                //}
                //else
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                //}

                //if (Convert.ToString(Request.QueryString["BU"]) != "")
                //{
                //    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                //}
                //else
                //{
                //    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                //}

                if (Convert.ToString(Request.QueryString["JOB"]) != "")
                {
                    Jobs = new Microsoft.Reporting.WebForms.ReportParameter("Jobs", Convert.ToString(Request.QueryString["JOB"]));
                }
                else
                {
                    Jobs = new Microsoft.Reporting.WebForms.ReportParameter("Jobs", "-1");
                }

                if (Convert.ToString(Request.QueryString["FY"]) != "")
                {
                    FinancialYear = new Microsoft.Reporting.WebForms.ReportParameter("FinancialYear", Convert.ToString(Request.QueryString["FY"]));
                }
                else
                {
                    FinancialYear = new Microsoft.Reporting.WebForms.ReportParameter("FinancialYear", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Jobs, FinancialYear };
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Jobs, FinancialYear };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_StaffEstablishment.Visible = true;
            }


        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishmentReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}