﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using SMHR;
using Telerik.Web.UI;

public partial class Reportss_frmReportData : System.Web.UI.Page
{
    static string rptStr = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                #region Commented2
                /*rptStr = Convert.ToString(Request.QueryString["rptStr"]);
                RPT_Report.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Report.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetails;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];

                if (rptStr == "EBG")
                    serverReport.ReportPath = MyReportPath + "EmployeeBasicandgrosssalaryvariation";

                if (rptStr == "PD")
                    serverReport.ReportPath = MyReportPath + "paymentandDeduction";

                if (rptStr == "EMT")
                    serverReport.ReportPath = MyReportPath + "Employeemonthlytransaction";


                // serverReport.ReportPath = MyReportPath + "PayRegister";
                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }
                if (Convert.ToString(Request.QueryString["prd"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["prd"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["prdDtl"]) != "")
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", Convert.ToString(Request.QueryString["prdDtl"]));
                }
                else
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "-1");
                }

                if (rptStr == "EBG")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetails };
                    serverReport.SetParameters(parameters);
                }
                if (rptStr == "PD" || rptStr == "EMT")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, Period, PeriodDetails };
                    serverReport.SetParameters(parameters);
                }

                serverReport.Refresh();
                RPT_Report.Visible = true;*/
                #endregion

                rptStr = Convert.ToString(Request.QueryString["rptStr"]);

                RPT_Report.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Report.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter Period;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetails;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];

                if (rptStr == "EBG")
                    serverReport.ReportPath = MyReportPath + "EmployeeBasicandgrosssalaryvariation";

                if (rptStr == "PD")
                    serverReport.ReportPath = MyReportPath + "paymentandDeduction";

                if (rptStr == "EMT")
                    serverReport.ReportPath = MyReportPath + "Employeemonthlytransaction";

                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }
                if (Convert.ToString(Request.QueryString["prd"]) != "")
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(Request.QueryString["prd"]));
                }
                else
                {
                    Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
                }
                if (Convert.ToString(Request.QueryString["prdDtl"]) != "")
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", Convert.ToString(Request.QueryString["prdDtl"]));
                }
                else
                {
                    PeriodDetails = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetails", "-1");
                }

                if (rptStr == "EBG")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Period, PeriodDetails };
                    serverReport.SetParameters(parameters);
                }
                if (rptStr == "PD" || rptStr == "EMT")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit, Period, PeriodDetails };
                    serverReport.SetParameters(parameters);
                }

                serverReport.Refresh();
                RPT_Report.Visible = true;

                #region Commented
                /*rptStr = Convert.ToString(Request.QueryString["rptStr"]);

                RPT_Report.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = RPT_Report.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter organisation;
                Microsoft.Reporting.WebForms.ReportParameter Businessunit;
                Microsoft.Reporting.WebForms.ReportParameter Organisation;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];

                if (rptStr == "GWE")
                    serverReport.ReportPath = MyReportPath + "Gradewiseemployeelist";

                if (rptStr == "ECD")
                    serverReport.ReportPath = MyReportPath + "EmployeeContractDetails";

                if (rptStr == "GDP")
                    serverReport.ReportPath = MyReportPath + "GeographicalDistributionOfProfessionalPosts";

                if (rptStr == "RAR")
                    serverReport.ReportPath = MyReportPath + "RetirementAgeReport";

                if (rptStr == "SDR")
                    serverReport.ReportPath = MyReportPath + "SpouseOrDependantsReport";

                if (rptStr == "ER")
                    serverReport.ReportPath = MyReportPath + "EmployeeRegister";

                //serverReport.ReportPath = MyReportPath + "EmployeeFamilyDetails";
                //if (Convert.ToString(Request.QueryString["ORG_ID"]) != "")
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                //}
                //else
                //{
                //    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                //}
                if (Convert.ToString(Request.QueryString["BU"]) != "")
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    Businessunit = new Microsoft.Reporting.WebForms.ReportParameter("Businessunit", "-1");
                }

                organisation = new Microsoft.Reporting.WebForms.ReportParameter("organisation", Convert.ToString(Session["ORG_ID"]));
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));

                if (rptStr == "ECD" || rptStr == "GDP" || rptStr == "RAR" || rptStr == "ER" || rptStr == "SDR")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, Businessunit };
                    serverReport.SetParameters(parameters);
                }
                else
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { organisation, Businessunit };
                    serverReport.SetParameters(parameters);
                }
                serverReport.Refresh();
                RPT_Report.Visible = true;*/
                #endregion
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "FrmReport1Data", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}