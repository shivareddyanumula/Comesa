﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


public partial class Reportss_Frm_TerminatedEmployeesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                RPT_terminateEmployee.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_terminateEmployee.ServerReport;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter STARTDATE;
                Microsoft.Reporting.WebForms.ReportParameter ENDDATE;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter Department;
                Microsoft.Reporting.WebForms.ReportParameter Directorate;
                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];

                //OG=' + org + '&BU=' + buid + '&DER=' + derict+'&DEP='+depart+'&FMDATE='+frmdate+'&TDAT='+Tdate, "RadWindow1");
                serverReport.ReportPath = MyReportPath + "Terminated Employees";
                if (Convert.ToString(Request.QueryString["DEP"]) != "")
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DEP"]));
                }
                else
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }

                if (Convert.ToString(Request.QueryString["TDAT"]) != "")
                {
                    ENDDATE = new Microsoft.Reporting.WebForms.ReportParameter("ENDDATE", Convert.ToString(Request.QueryString["TDAT"]));
                }
                else
                {
                    ENDDATE = new Microsoft.Reporting.WebForms.ReportParameter("ENDDATE", "-1");
                }
                if (Convert.ToString(Request.QueryString["FMDATE"]) != "")
                {
                    STARTDATE = new Microsoft.Reporting.WebForms.ReportParameter("STARTDATE", Convert.ToString(Request.QueryString["FMDATE"]));
                }
                else
                {
                    STARTDATE = new Microsoft.Reporting.WebForms.ReportParameter("STARTDATE", "-1");
                }
                if (Convert.ToString(Request.QueryString["DER"]) != "")
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", Convert.ToString(Request.QueryString["DER"]));
                }
                else
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", "-1");
                }

                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, STARTDATE, ENDDATE, Businessunit, Department, Directorate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_terminateEmployee.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Frm_TerminatedEmployeesReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}