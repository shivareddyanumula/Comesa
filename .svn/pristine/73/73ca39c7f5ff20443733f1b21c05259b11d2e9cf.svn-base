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

public partial class Reportss_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = ReportViewer1.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Department;
                if (Convert.ToString(Request.QueryString["DEPT"]) != null)
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEPT"]));
                }
                else
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != null)
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }

                if (Convert.ToString(Request.QueryString["PRD"]) != null)
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["PRD"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Period, BusinessGroup, Department };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                ReportViewer1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Default2", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
