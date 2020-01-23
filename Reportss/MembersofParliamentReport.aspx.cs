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

public partial class Reportss_MembersofParliamentReport_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_MembersofParliamentReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_MembersofParliamentReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter SalStruct;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter Perioddetail;
                Microsoft.Reporting.WebForms.ReportParameter Mode;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "MPSStaffContribution";
                if (Convert.ToString(Request.QueryString["CRTL"]) == "StaffContribution")
                {
                    Mode = new Microsoft.Reporting.WebForms.ReportParameter("Mode", "1");
                }
                else
                {
                    Mode = new Microsoft.Reporting.WebForms.ReportParameter("Mode", "0");
                }
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
                if (Convert.ToString(Request.QueryString["PRDE"]) != "")
                {
                    Perioddetail = new Microsoft.Reporting.WebForms.ReportParameter("Perioddetail", Convert.ToString(Request.QueryString["PRDE"]));
                }
                else
                {
                    Perioddetail = new Microsoft.Reporting.WebForms.ReportParameter("Perioddetail", "-1");
                }
                if (Convert.ToString(Request.QueryString["SALS"]) != "")
                {
                    SalStruct = new Microsoft.Reporting.WebForms.ReportParameter("SalStruct", Convert.ToString(Request.QueryString["SALS"]));
                }
                else
                {
                    SalStruct = new Microsoft.Reporting.WebForms.ReportParameter("SalStruct", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }


                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalStruct, Period, Perioddetail, Mode };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_MembersofParliamentReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MembersofParliamentReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }
}