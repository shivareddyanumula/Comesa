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

public partial class Reportss_frm_EmpBankTransactionsReport : System.Web.UI.Page
{
      protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    RPT_EmpBankTransactions.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                    serverReport = RPT_EmpBankTransactions.ServerReport;
                    Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                    Microsoft.Reporting.WebForms.ReportParameter Period;
                    Microsoft.Reporting.WebForms.ReportParameter Organisation;
                    Microsoft.Reporting.WebForms.ReportParameter PeriodElements;
                    string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                    WebClient Wc = new WebClient();
                    Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                    serverReport.ReportServerCredentials = _ObjNC;
                    serverReport.ReportServerUrl = new Uri(sDomain);
                    string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                    serverReport.ReportPath = MyReportPath + "EmployeeBankTransaction";
                    if (Convert.ToString(Request.QueryString["PRDELE"]) != "")
                    {
                        PeriodElements = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", Convert.ToString(Request.QueryString["PRDELE"]));
                    }
                    else
                    {
                        PeriodElements = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "-1");
                    }
                    if (Convert.ToString(Request.QueryString["BU"]) != "")
                    {
                        BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                    }
                    else
                    {
                        BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                    }

                    if (Convert.ToString(Request.QueryString["PRD"]) != "")
                    {
                        Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                    }
                    else
                    {
                        Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                    }
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Period, BusinessGroup, PeriodElements };
                    serverReport.SetParameters(parameters);
                    serverReport.Refresh();
                    RPT_EmpBankTransactions.Visible = true;
                }
            }
            catch (Exception ex)
            {
                SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_EmpBankTransactionsReport", ex.StackTrace, DateTime.Now);
                Response.Redirect("~/Frm_ErrorPage.aspx");
            }
        }
    
}
