using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using SMHR;
using System.Net;
using Microsoft.ReportingServices;
using Telerik.Web.UI;

public partial class Reportss_Employee_Pay_ItemReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RPT_EmployeePayItem.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_EmployeePayItem.ServerReport;
                RPT_EmployeePayItem.AsyncRendering = false;
                if (!RPT_EmployeePayItem.Enabled)
                {
                    RPT_EmployeePayItem.CurrentPage = 1;
                }


                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                serverReport.ReportPath = "/SmartHR/" + "Pay Item";
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PayItem;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
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
                if (Convert.ToString(Request.QueryString["PAY"]) != "")
                {
                    PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", Convert.ToString(Request.QueryString["PAY"]));
                }
                else
                {
                    PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", "-1");
                }
                //Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(rcmb_payElements.SelectedValue));
                //PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", Convert.ToString(ddl_Payitems.SelectedValue));
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Period, PayItem, Organisation };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_EmployeePayItem.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_ItemReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
