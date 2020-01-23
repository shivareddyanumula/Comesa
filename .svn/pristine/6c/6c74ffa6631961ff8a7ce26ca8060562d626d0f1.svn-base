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

public partial class Reportss_EmployeeListReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                string Reportname = Convert.ToString(Request.QueryString["RPTNAME"]);
                EmployeeList.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
                serverReport = EmployeeList.ServerReport;

                Microsoft.Reporting.WebForms.ReportParameter Organisation;
                Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
                Microsoft.Reporting.WebForms.ReportParameter SalaryStructure;
                Microsoft.Reporting.WebForms.ReportParameter EmployeeType;
                Microsoft.Reporting.WebForms.ReportParameter FROM;
                Microsoft.Reporting.WebForms.ReportParameter To;
                Microsoft.Reporting.WebForms.ReportParameter Tribe;
                Microsoft.Reporting.WebForms.ReportParameter County;
                Microsoft.Reporting.WebForms.ReportParameter Directorate;
                Microsoft.Reporting.WebForms.ReportParameter Department;


                string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
               
                //serverReport.ReportPath = MyReportPath + Convert.ToString(Request.QueryString["RPTNAME"]);
                switch(Convert.ToString(Request.QueryString["RPTNAME"]))
                {
                    case "1":
                        serverReport.ReportPath = MyReportPath + "EmployeeList";
                        break;
                    case "2":
                         serverReport.ReportPath = MyReportPath + "EmployeeList";
                        break;
                    case "3":
                        serverReport.ReportPath = MyReportPath + "Employee On Disability Tax Exemption";
                        break;
                    case "4":
                        serverReport.ReportPath = MyReportPath + "Employee List by Service";
                        break;
                    case "5":
                        serverReport.ReportPath = MyReportPath + "Employee List by County";
                        break;
                    case "6":
                        serverReport.ReportPath = MyReportPath + "Transfer Due by Cash";
                        break;
                    case "7":
                        serverReport.ReportPath = MyReportPath + "Employee List by Age";
                        break;
                    case "8":
                        serverReport.ReportPath = MyReportPath + "Employee List by Ethnicity";
                        break;
                    case "9":
                        serverReport.ReportPath = MyReportPath + "EmployeeListDepartment";
                        break;
                    case "10":
                        serverReport.ReportPath = MyReportPath + "EmployeeListDepartment";
                        break;
                    case "11":
                        serverReport.ReportPath = MyReportPath + "EmployeeListDepartment";
                        break;
                    case "12":
                        serverReport.ReportPath = MyReportPath + "Employee House Allowance";
                        break;
                    case "13":
                        serverReport.ReportPath = MyReportPath + "Allocation Code";
                        break;
                    case "14":
                        serverReport.ReportPath = MyReportPath + "Employee Type";
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
                if (Convert.ToString(Request.QueryString["SAL"]) != "" && Convert.ToString(Request.QueryString["SAL"]) != null)
                {
                    SalaryStructure = new Microsoft.Reporting.WebForms.ReportParameter("SalaryStructure", Convert.ToString(Request.QueryString["SAL"]));
                }
                else
                {
                    SalaryStructure = new Microsoft.Reporting.WebForms.ReportParameter("SalaryStructure", "-1");
                }
                if (Convert.ToString(Request.QueryString["EMPTYPE"]) != "" && Convert.ToString(Request.QueryString["EMPTYPE"]) != null)
                {
                    EmployeeType = new Microsoft.Reporting.WebForms.ReportParameter("EmployeeType", Convert.ToString(Request.QueryString["EMPTYPE"]));
                }
                else
                {
                    EmployeeType = new Microsoft.Reporting.WebForms.ReportParameter("EmployeeType", "-1");
                }
                if (Convert.ToString(Request.QueryString["CTY"]) != "" && Convert.ToString(Request.QueryString["CTY"]) != null)
                {
                    County = new Microsoft.Reporting.WebForms.ReportParameter("County", Convert.ToString(Request.QueryString["CTY"]));
                }
                else
                {
                    County = new Microsoft.Reporting.WebForms.ReportParameter("County", "-1");
                }
                if (Convert.ToString(Request.QueryString["FRM"]) != "" && Convert.ToString(Request.QueryString["FRM"]) != null)
                {
                    FROM = new Microsoft.Reporting.WebForms.ReportParameter("FROM", Convert.ToString(Request.QueryString["FRM"]));
                }
                else
                {
                    FROM = new Microsoft.Reporting.WebForms.ReportParameter("FROM", "-1");
                }
                if (Convert.ToString(Request.QueryString["To"]) != "" && Convert.ToString(Request.QueryString["To"]) != null)
                {
                    To = new Microsoft.Reporting.WebForms.ReportParameter("To", Convert.ToString(Request.QueryString["To"]));
                }
                else
                {
                    To = new Microsoft.Reporting.WebForms.ReportParameter("To", "-1");
                }
                if (Convert.ToString(Request.QueryString["TRB"]) != "" && Convert.ToString(Request.QueryString["TRB"]) != null)
                {
                    Tribe = new Microsoft.Reporting.WebForms.ReportParameter("Tribe", Convert.ToString(Request.QueryString["TRB"]));
                }
                else
                {
                    Tribe = new Microsoft.Reporting.WebForms.ReportParameter("Tribe", "-1");
                }
                if (Convert.ToString(Request.QueryString["DI"]) != "" && Convert.ToString(Request.QueryString["DI"]) != null)
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", Convert.ToString(Request.QueryString["DI"]));
                }
                else
                {
                    Directorate = new Microsoft.Reporting.WebForms.ReportParameter("Directorate", "-1");
                }
                if (Convert.ToString(Request.QueryString["DE"]) != "" && Convert.ToString(Request.QueryString["DE"]) != null)
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", Convert.ToString(Request.QueryString["DE"]));
                }
                else
                {
                    Department = new Microsoft.Reporting.WebForms.ReportParameter("Department", "-1");
                }
                //if (Reportname == "EmployeeList")
                if (Reportname == "1" || Reportname == "2" || Reportname == "14")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalaryStructure, EmployeeType };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "Employee On Disability Tax Exemption" || Reportname == "Employee List by Service")
                else if (Reportname == "3" || Reportname == "4" )
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, SalaryStructure };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "Transfer Due by Cash")
                else if (Reportname == "6" || Reportname == "12" || Reportname == "13")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit };
                    serverReport.SetParameters(parameters);

                }
                //else if (Reportname == "Employee List by County"
                 else if (Reportname == "5" )
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, County };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "Employee List by Age")
                else if (Reportname == "7")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, FROM, To };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "Employee List by Ethnicity")
                else if (Reportname == "8")
                {
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Tribe };
                    serverReport.SetParameters(parameters);
                }
                //else if (Reportname == "EmployeeListDepartment")
                else if (Reportname == "9" || Reportname == "10" || Reportname == "11")
                {
                   
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Organisation, BusinessUnit, Directorate, Department };
                    serverReport.SetParameters(parameters);

                }
                serverReport.Refresh();
                EmployeeList.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EmployeeListReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}


