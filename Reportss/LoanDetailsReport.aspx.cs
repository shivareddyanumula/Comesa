using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_LoanDetailsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                RPT_LoanDetails.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_LoanDetails.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter Directorate;
                Microsoft.Reporting.WebForms.ReportParameter Department;
                //Microsoft.Reporting.WebForms.ReportParameter SubDepartment;
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter Loantype;


                string sDomain = System.Configuration.ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationManager.AppSettings["MyReportPath"];

                //serverReport.ReportPath = MyReportPath + "All Loans";

                if (Convert.ToString(Request.QueryString["RPT"]) != "")
                {
                    serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPT"]);
                }
                else
                {
                    serverReport.ReportPath = MyReportPath + "All Loans";
                }


                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }

                if (Convert.ToString(Request.QueryString["DIR"]) != "")
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", Convert.ToString(Request.QueryString["DIR"]));
                }
                else
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", "-1");
                }


                if (Convert.ToString(Request.QueryString["DEPT"]) != "")
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEPT"]));
                }
                else
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                }

                //if (Convert.ToString(Request.QueryString["SDEPT"]) != "")
                //{
                //    SubDepartment = new Microsoft.Reporting.WebForms.ReportParameter("SubDepartment", Convert.ToString(Request.QueryString["SDEPT"]));
                //}
                //else
                //{
                //    SubDepartment = new Microsoft.Reporting.WebForms.ReportParameter("SubDepartment", "-1");
                //}

                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }

                if (Convert.ToString(Request.QueryString["LT"]) != "")
                {
                    Loantype = new Microsoft.Reporting.WebForms.ReportParameter("Loantype", Convert.ToString(Request.QueryString["LT"]));
                }
                else
                {
                    Loantype = new Microsoft.Reporting.WebForms.ReportParameter("Loantype", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, Directorate, Department, SubDepartment, Employee, Loantype };
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, Directorate, Department, Employee, Loantype };
                //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Employee, Loantype };

                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_LoanDetails.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "LoanDetailsReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}