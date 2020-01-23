using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_EmpTypeWiseLoanBalanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                RPT_EmpTypeWiseLoanBalance.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmpTypeWiseLoanBalance.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Employeetype;

                string sDomain = System.Configuration.ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationManager.AppSettings["MyReportPath"];
                serverReport.ReportPath = MyReportPath + "Employee Type Wise Loan Balance";

                if (Convert.ToString(Request.QueryString["EMPT"]) != "")
                {
                    Employeetype = new Microsoft.Reporting.WebForms.ReportParameter("Employeetype", Convert.ToString(Request.QueryString["EMPT"]));
                }
                else
                {
                    Employeetype = new Microsoft.Reporting.WebForms.ReportParameter("Employeetype", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Employeetype };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmpTypeWiseLoanBalance.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmpTypeWiseLoanBalanceReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}