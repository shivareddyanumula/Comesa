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
using System.Data;

public partial class Reportss_ProvisionalPayslipBefore : System.Web.UI.Page
{
    static int buID = 0;
    static int prdID = 0;
    static int prdDtlID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();

            if (!Page.IsPostBack)
            {
                LoadEmployees();
                rwPreAprPaySlip.VisibleOnPageLoad = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalReportBefore", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            DataTable dtEMPData = BLL.get_EmployeeBySearchString(Convert.ToInt32(Session["ORG_ID"]), string.Empty);

            rcmb_Employee.DataSource = dtEMPData;
            rcmb_Employee.DataTextField = "EMPNAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalPayslipBefore", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            DataTable dtEMPData1 = BLL.get_Employeeorgbusiness(Convert.ToInt32(rcmb_Employee.SelectedValue));

            Session["emp_businessunit_id"] = dtEMPData1.Rows[0]["emp_businessunit_id"].ToString();
            Session["emp_organistation_id"] = dtEMPData1.Rows[0]["emp_organisation_id"].ToString();

            buID = Convert.ToInt32(dtEMPData1.Rows[0]["emp_businessunit_id"]);
            rwPreAprPaySlip.VisibleOnPageLoad = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalPayslipBefore", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtEMPData2 = BLL.USP_SMHR_EMP_BEFORE_PROVISION_TEMP(Convert.ToInt32(rcmb_Employee.SelectedValue));
            DataTable dtEMPData3 = BLL.USP_SMHR_PERIODDETAILS_emp("GetDateData");

            prdID = Convert.ToInt32(dtEMPData3.Rows[0]["PRDDTL_PERIOD_ID"]);
            prdDtlID = Convert.ToInt32(dtEMPData3.Rows[0]["PRDDTL_ID"]);

            //Session["PRDDTL_PERIOD_ID"] = dtEMPData3.Rows[0]["PRDDTL_PERIOD_ID"].ToString();
            //Session["PRDDTL_ID"] = dtEMPData3.Rows[0]["PRDDTL_ID"].ToString();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Employee.SelectedValue) + "','" +
            //    Session["emp_organistation_id"] + "', '" + Session["emp_businessunit_id"] + "', '" + Session["PRDDTL_PERIOD_ID"] + Session["PRDDTL_ID"] + "');", true);
            
            RPT_ProvisionalPayslip.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            serverReport = RPT_ProvisionalPayslip.ServerReport;

            Microsoft.Reporting.WebForms.ReportParameter Employee;
            Microsoft.Reporting.WebForms.ReportParameter Organisation;
            Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
            Microsoft.Reporting.WebForms.ReportParameter Period;
            Microsoft.Reporting.WebForms.ReportParameter PeriodElement;

            string sDomain = ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            WebClient wc = new WebClient();
            Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            serverReport.ReportServerCredentials = _ObjNC;
            serverReport.ReportServerUrl = new Uri(sDomain);
            string MyReportPath = System.Configuration.ConfigurationSettings.AppSettings["MyReportPath"];
            serverReport.ReportPath = MyReportPath + "PayrollProcess_Before";

            if (rcmb_Employee.SelectedValue != "")
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(rcmb_Employee.SelectedValue));
            else
                Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
            if (Convert.ToString(Session["ORG_ID"]) != "")
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
            else
                Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", "-1");
            if (buID > 0)
                BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(buID));
            else
                BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
            if (prdID > 0)
                Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(prdID));
            else
                Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", "-1");
            if (prdDtlID > 0)
                PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", Convert.ToString(prdDtlID));
            else
                PeriodElement = new Microsoft.Reporting.WebForms.ReportParameter("PeriodElement", "-1");

            Microsoft.Reporting.WebForms.ReportParameter[] parameters = { Employee, Organisation, BusinessUnit, Period, PeriodElement };
            serverReport.SetParameters(parameters);
            serverReport.Refresh();
            
            RPT_ProvisionalPayslip.Visible = true;
            rwPreAprPaySlip.VisibleOnPageLoad = true;
        }
        catch (Exception ex)
        {
            if (ex.Message == "FAILEDTRANS")
            {
                //BLL.ShowMessage(this, "No Payelements found for selected Employee");
                BLL.ShowMessage(this, "Assign Pay Elements for selected Employee");
                return;
            }
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalPayslipBefore", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_Employee.SelectedIndex = 0;
            rwPreAprPaySlip.VisibleOnPageLoad = false;
            Response.Redirect("~/Reportss/ProvisionalPayslipBefore.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ProvisionalPayslipBefore", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}