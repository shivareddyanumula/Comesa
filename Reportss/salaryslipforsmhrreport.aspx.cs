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


public partial class Reportss_salaryslipforsmhrreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_SalarySlipForSmhr.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_SalarySlipForSmhr.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                //Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetails;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = MyReportPath + "SalarySlipSmartHR";
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
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                //if(Convert.ToString(Request.QueryString["DEPT"])!="")
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department",Convert.ToString(Request.QueryString["DEPT"]));
                //}
                //else
                //{
                //    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department","-1");
                //}
                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
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
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", Convert.ToString(Request.QueryString["PRDDTL"]));
                }
                else
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", "-1");
                }
                //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessGroup, Employee, Period, PeriodDetails };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_SalarySlipForSmhr.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "salaryslipforsmhrreport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
