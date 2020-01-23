using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportss_MonthWiseEmployeeNotPaidReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                RPT_EmpNotPaid.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmpNotPaid.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetail;

                string sDomain = System.Configuration.ConfigurationManager.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationManager.AppSettings["MyReportPath"];

                serverReport.ReportPath = MyReportPath + "Month Wise Employee Not Paid";

                //if (Convert.ToString(Request.QueryString["RPT"]) != "")
                //{
                //    serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPT"]);
                //}
                //else
                //{
                //    serverReport.ReportPath = MyReportPath + "All Loans";
                //}


                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
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


                if (Convert.ToString(Request.QueryString["PDTL"]) != "")
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", Convert.ToString(Request.QueryString["PDTL"]));
                }
                else
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", "-1");
                }
                
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetail };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmpNotPaid.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MonthWiseEmployeeNotPaidReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}