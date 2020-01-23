using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_frmPreApprovalPayReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_PreApprovalPayReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_PreApprovalPayReport.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodElement;
                Microsoft.Reporting.WebForms.ReportParameter Employee;

                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter PayTranId;

                string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                string MyReportPath = ConfigurationManager.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                //if (Convert.ToString(Request.QueryString["LOCALISATION"]).ToUpper() != "KENYA")

                serverReport.ReportPath = MyReportPath + "Provisional Pay Slip";
                /////serverReport.ReportPath = MyReportPath + "PreApprovalPayReport";
                
                //else
                //    serverReport.ReportPath = MyReportPath + "PreApprovalPayRegister_Kenya";

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
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRD"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["PRDDTL"]) != "")
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", "-1");
                }
                if (Convert.ToString(Request.QueryString["EMPID"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMPID"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }

                if (Convert.ToString(Request.QueryString["paytran"]) != "")
                {
                    PayTranId = new Microsoft.Reporting.WebForms.ReportParameter("PayTranId", Convert.ToString(Request.QueryString["paytran"]));
                }
                else
                {
                    PayTranId = new Microsoft.Reporting.WebForms.ReportParameter("PayTranId", "-1");
                }

                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

               Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, Period, PeriodElement, Employee };
               /// Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodElement, PayTranId };

                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_PreApprovalPayReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmPreApprovalPayReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}