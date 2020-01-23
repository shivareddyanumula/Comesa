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

public partial class Reportss_EmployeeDueIncrementReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                string Reportname = Convert.ToString(Request.QueryString["RPTNAME"]);

                EmployeeDueIncrement.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = EmployeeDueIncrement.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter Financialperiod;
                Microsoft.Reporting.WebForms.ReportParameter IncrementMonth;
                Microsoft.Reporting.WebForms.ReportParameter Bank;
                Microsoft.Reporting.WebForms.ReportParameter PeriodDetail;
                Microsoft.Reporting.WebForms.ReportParameter Payitem;
                Microsoft.Reporting.WebForms.ReportParameter VoteCode;
                Microsoft.Reporting.WebForms.ReportParameter Type;
                Microsoft.Reporting.WebForms.ReportParameter SalaryStructure;
                Microsoft.Reporting.WebForms.ReportParameter Branch;
                Microsoft.Reporting.WebForms.ReportParameter Status;

                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                //serverReport.ReportPath = MyReportPath + "EmployeeList";
                //serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPTNAME"]);
                switch (Reportname)
                {
                    case "1":
                        serverReport.ReportPath = MyReportPath + "Employee Due Increment";
                        break;
                    case "2":
                        serverReport.ReportPath = MyReportPath + "Transfer Due by Bank";
                        break;
                    case "3":
                        serverReport.ReportPath = MyReportPath + "AllocationSummary";
                        break;
                    case "4":
                        serverReport.ReportPath = MyReportPath + "Deduction Summary";   //"AllocationSummary";
                        break;
                    case "5":
                        serverReport.ReportPath = MyReportPath + "Employee Benefit Deduction";
                        break;
                    case "6":
                        serverReport.ReportPath = MyReportPath + "Employee_Benefits";
                        break;
                    case "7":
                        serverReport.ReportPath = MyReportPath + "Deduction Group Summary";
                        break;
                    case "8":
                        serverReport.ReportPath = MyReportPath + "EmployeeGrossBasicNetSalary";
                        break;
                    case "9":
                        serverReport.ReportPath = MyReportPath + "EmployeeGrossBasicNetSalary";
                        break;
                    case "10":
                        serverReport.ReportPath = MyReportPath + "EmployeeGrossBasicNetSalary";
                        break;
                    case "11":
                        serverReport.ReportPath = MyReportPath + "Statuatory Deduction";
                        break;
                    case "12":
                        serverReport.ReportPath = MyReportPath + "EmployeeGrossBasicNetSalary";
                        break;
                    case "13":
                        serverReport.ReportPath = MyReportPath + "Employees On Payroll";
                        break;
                    case "14":
                        serverReport.ReportPath = MyReportPath + "Employees Excluded From Payroll";
                        break;
                }

                if (Convert.ToString(Request.QueryString["ORG_ID"]) != "" && Convert.ToString(Request.QueryString["ORG_ID"]) != null)
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Request.QueryString["ORG_ID"]));
                }
                else
                {
                    Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
                }
                if (Convert.ToString(Request.QueryString["BU"]) != "" && Convert.ToString(Request.QueryString["BU"]) != null)
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
                }
                else
                {
                    BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
                }
                if (Convert.ToString(Request.QueryString["FP"]) != "" && Convert.ToString(Request.QueryString["FP"]) != null)
                {
                    Financialperiod = new Microsoft.Reporting.WebForms.ReportParameter("Financialperiod", Convert.ToString(Request.QueryString["FP"]));
                }
                else
                {
                    Financialperiod = new Microsoft.Reporting.WebForms.ReportParameter("Financialperiod", "-1");
                }
                if (Convert.ToString(Request.QueryString["IM"]) != "" && Convert.ToString(Request.QueryString["IM"]) != null)
                {
                    IncrementMonth = new Microsoft.Reporting.WebForms.ReportParameter("IncrementMonth", Convert.ToString(Request.QueryString["IM"]));
                }
                else
                {
                    IncrementMonth = new Microsoft.Reporting.WebForms.ReportParameter("IncrementMonth", "-1");
                }
                if (Convert.ToString(Request.QueryString["BNK"]) != "" && Convert.ToString(Request.QueryString["BNK"]) != null)
                {
                    Bank = new Microsoft.Reporting.WebForms.ReportParameter("Bank", Convert.ToString(Request.QueryString["BNK"]));
                }
                else
                {
                    Bank = new Microsoft.Reporting.WebForms.ReportParameter("Bank", "-1");
                }
                if (Convert.ToString(Request.QueryString["BN"]) != "" && Convert.ToString(Request.QueryString["BN"]) != null)
                {
                    Branch = new Microsoft.Reporting.WebForms.ReportParameter("Branch", Convert.ToString(Request.QueryString["BN"]));
                }
                else
                {
                    Branch = new Microsoft.Reporting.WebForms.ReportParameter("Branch", "-1");
                }
                if (Convert.ToString(Request.QueryString["PE"]) != "" && Convert.ToString(Request.QueryString["PE"]) != null)
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", Convert.ToString(Request.QueryString["PE"]));
                }
                else
                {
                    PeriodDetail = new Microsoft.Reporting.WebForms.ReportParameter("PeriodDetail", "-1");
                }

                if (Reportname == "6")
                {
                    Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "1");
                }
                else
                {
                    if (Convert.ToString(Request.QueryString["Sts"]) != "" && Convert.ToString(Request.QueryString["Sts"]) != null)
                    {
                        Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", Convert.ToString(Request.QueryString["Sts"]));
                    }
                    else
                    {
                        Status = new Microsoft.Reporting.WebForms.ReportParameter("Status", "-1");
                    }
                }

                if (Convert.ToString(Request.QueryString["PI"]) != "" && Convert.ToString(Request.QueryString["PI"]) != null)
                {
                    Payitem = new Microsoft.Reporting.WebForms.ReportParameter("Payitem", Convert.ToString(Request.QueryString["PI"]));
                }
                else
                {
                    Payitem = new Microsoft.Reporting.WebForms.ReportParameter("Payitem", "-1");
                }
                if (Convert.ToString(Request.QueryString["VC"]) != "" && Convert.ToString(Request.QueryString["VC"]) != null)
                {
                    VoteCode = new Microsoft.Reporting.WebForms.ReportParameter("VoteCode", Convert.ToString(Request.QueryString["VC"]));
                }
                else
                {
                    VoteCode = new Microsoft.Reporting.WebForms.ReportParameter("VoteCode", "-1");
                }
                if (Convert.ToString(Request.QueryString["TYP"]) != "" && Convert.ToString(Request.QueryString["TYP"]) != null)
                {
                    Type = new Microsoft.Reporting.WebForms.ReportParameter("Type", Convert.ToString(Request.QueryString["TYP"]));
                }
                else
                {
                    Type = new Microsoft.Reporting.WebForms.ReportParameter("Type", "-1");
                }
                if (Convert.ToString(Request.QueryString["ST"]) != "" && Convert.ToString(Request.QueryString["ST"]) != null)
                {
                    SalaryStructure = new Microsoft.Reporting.WebForms.ReportParameter("SalaryStructure", Convert.ToString(Request.QueryString["ST"]));
                }
                else
                {
                    SalaryStructure = new Microsoft.Reporting.WebForms.ReportParameter("SalaryStructure", "-1");
                }


                //if (Reportname == "Employee Due Increment")

                if (Reportname == "1")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Financialperiod, IncrementMonth };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "Transfer Due by Bank")
                else if (Reportname == "2")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Bank, Branch, Financialperiod, PeriodDetail };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "AllocationSummary" || Reportname == "Employee Benefit Deduction")
                else if (Reportname == "4" || Reportname == "5" || Reportname == "6")
                {
                   if (Reportname == "6")
                    {
                        Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Payitem, Financialperiod, PeriodDetail };
                        serverReport.SetParameters(parameters);
                    }
                    else
                    {
                        Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Payitem, Financialperiod, PeriodDetail, Status, Type };
                        serverReport.SetParameters(parameters);
                    }
                }
                //else if (Reportname == "Deduction Group Summary")
                else if (Reportname == "7")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, VoteCode, Financialperiod, PeriodDetail };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "EmployeeGrossBasicNetSalary")
                else if (Reportname == "8" || Reportname == "9" || Reportname == "10" || Reportname == "12"|| Reportname == "3")
                {
                    //if (Reportname == "9" || Reportname == "10")
                    //{
                    //    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Payitem, Financialperiod, PeriodDetail, Status, Type };
                    //    serverReport.SetParameters(parameters);
                    //}
                    if (Reportname == "9" || Reportname == "10" )
                    {
                        Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalaryStructure, Financialperiod, PeriodDetail, Status, Type };
                        serverReport.SetParameters(parameters);
                    }
                    //else if (Reportname == "10")
                    //{
                    //    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalaryStructure, Financialperiod, Status, PeriodDetail };
                    //    serverReport.SetParameters(parameters);
                    //}
                    else if(Reportname == "3")
                    {
                        Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit,Payitem, Financialperiod, PeriodDetail, Status,Type };
                        serverReport.SetParameters(parameters);
                    }
                    else
                    {
                        Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalaryStructure, Financialperiod, PeriodDetail, Type };
                        serverReport.SetParameters(parameters);
                    }
                }
                //else if (Reportname == "Statuatory Deduction")
                else if (Reportname == "11")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Payitem, Financialperiod, PeriodDetail };
                    serverReport.SetParameters(parameters);
                }
                else if (Reportname == "13" || Reportname == "14")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Financialperiod, PeriodDetail };
                    serverReport.SetParameters(parameters);
                }

                serverReport.Refresh();
                EmployeeDueIncrement.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeDueIncrementReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}