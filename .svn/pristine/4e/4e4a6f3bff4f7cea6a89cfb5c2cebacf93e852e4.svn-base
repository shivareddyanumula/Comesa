using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


public partial class Grievances_frm_lettermail : System.Web.UI.Page
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
                Microsoft.Reporting.WebForms.ReportParameter Employee;
                Microsoft.Reporting.WebForms.ReportParameter Grievance;
                string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
                WebClient Wc = new WebClient();
                Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
                serverReport.ReportServerCredentials = _ObjNC;
                serverReport.ReportServerUrl = new Uri(sDomain);
                string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
                if (Convert.ToString(Request.QueryString["empid"]) != "")
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["empid"]));
                }
                else
                {
                    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
                }
                Grievance = new Microsoft.Reporting.WebForms.ReportParameter("Grievance", Convert.ToString(Request.QueryString["grevid"]));
                //OG=' + org + '&BU=' + buid + '&DER=' + derict+'&DEP='+depart+'&FMDATE='+frmdate+'&TDAT='+Tdate, "RadWindow1");
                if (Convert.ToString(Request.QueryString["type"]).ToUpper() == "TERMINATE")
                {

                    serverReport.ReportPath = MyReportPath + "Termination";
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Employee };
                    serverReport.SetParameters(parameters);
                }
                else
                {

                    serverReport.ReportPath = MyReportPath + "Suspension";
                    Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Employee, Grievance };
                    serverReport.SetParameters(parameters);
                }



                serverReport.Refresh();
                RPT_terminateEmployee.Visible = true;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_lettermail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}