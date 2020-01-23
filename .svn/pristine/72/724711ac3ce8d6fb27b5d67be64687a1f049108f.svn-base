using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_frm_SalaryProgressionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                RPT_SalaryProgression.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_SalaryProgression.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Directorate;
                Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Employee;


                string sDomain = ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = ConfigurationManager.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Salary Progression";


                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
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

                if (Convert.ToString(Request.QueryString["EMP"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }



                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Directorate, Department, Employee };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_SalaryProgression.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_SalaryProgressionReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}