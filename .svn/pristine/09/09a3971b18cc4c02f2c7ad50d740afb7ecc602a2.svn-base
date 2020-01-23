using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_RegstrUnRegstrAccStmtsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //RPT_RegstrUnRegstrAccStmts.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                //Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                //serverReport = RPT_RegstrUnRegstrAccStmts.ServerReport;

                //Microsoft.Reporting.WebForms.ReportParameter Organisation;
                //Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                //Microsoft.Reporting.WebForms.ReportParameter Period;
                //Microsoft.Reporting.WebForms.ReportParameter Employee;

                //string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                //WebClient wc = new WebClient();
                //Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                //serverReport.ReportServerCredentials = _ObjNC;
                //serverReport.ReportServerUrl = new Uri(sDomain);
                //string MyReportPath = System.Configuration.ConfigurationManager.AppSettings["MyReportPath"];
                RPT_RegstrUnRegstrAccStmts.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_RegstrUnRegstrAccStmts.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = ConfigurationManager.AppSettings["MyReportPath"];
                //serverReport.ReportPath = MyReportPath + "Register And Unregister Account Statements";

                if (Convert.ToString(Request.QueryString["RPT"]) == "PenCont")
                {
                    serverReport.ReportPath = MyReportPath + "Employee and Employer Pension Contribution";
                }
                else
                {
                    serverReport.ReportPath = MyReportPath + "Register And Unregister Account Statements";
                }


                if (Convert.ToString(Request.QueryString["ORG"]) != "" && Convert.ToString(Request.QueryString["ORG"]) != "0")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "" && Convert.ToString(Request.QueryString["BU"]) != "0")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "" && Convert.ToString(Request.QueryString["PRD"]) != "0")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["empID"]) != "" && Convert.ToString(Request.QueryString["empID"]) != "0")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["empID"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }

                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, Employee };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_RegstrUnRegstrAccStmts.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "RegstrUnRegstrAccStmtsReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}