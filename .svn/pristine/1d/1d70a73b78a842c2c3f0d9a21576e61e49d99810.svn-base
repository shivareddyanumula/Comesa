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


public partial class Reportss_Rehire_Report : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PERIOD _obj_smhr_period;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
            }
            Page.Validate();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Rehire_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadCombos()
    {
        try
        {
            //_obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_businessunit.OPERATION = operation.Select;
            //_obj_smhr_businessunit.ISDELETED = true;
            //DataTable dt_Details = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            //ddl_BusinessUnit.DataSource = dt_Details;
            //ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            //ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            //ddl_BusinessUnit.DataBind();
            //ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_period = new SMHR_PERIOD();

            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            ddl_BusinessUnit.DataSource = dt_BUDetails;
            ddl_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            ddl_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            ddl_BusinessUnit.DataBind();
            ddl_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Rehire_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            RPT_RehireReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            serverReport = RPT_RehireReport.ServerReport;
            RPT_RehireReport.AsyncRendering = false;
            if (!RPT_RehireReport.Enabled)
            {
                RPT_RehireReport.CurrentPage = 1;
            }


            string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            WebClient Wc = new WebClient();
            Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            serverReport.ReportServerCredentials = _ObjNC;
            serverReport.ReportServerUrl = new Uri(sDomain);
            serverReport.ReportPath = "/SmartHR/" + "Rehire Employees Report";
            Microsoft.Reporting.WebForms.ReportParameter BusinessUnit;
            Microsoft.Reporting.WebForms.ReportParameter StartDate;
            Microsoft.Reporting.WebForms.ReportParameter EndDate;
            Microsoft.Reporting.WebForms.ReportParameter Includedates;
            if (ddl_BusinessUnit.SelectedIndex != 0)
            {
                BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", ddl_BusinessUnit.SelectedValue);
            }
            else
            {
                BusinessUnit = new Microsoft.Reporting.WebForms.ReportParameter("BUSINESSUNIT", "-1");
            }
            if ((txt_StartDate.SelectedDate != null) && (txt_EndDate.SelectedDate != null))
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("INCLUDEDATES", "YES");
                StartDate = new Microsoft.Reporting.WebForms.ReportParameter("STARTDATE", txt_StartDate.SelectedDate.Value.ToShortDateString());
                EndDate = new Microsoft.Reporting.WebForms.ReportParameter("ENDDATE", txt_EndDate.SelectedDate.Value.ToShortDateString());
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessUnit, Includedates, StartDate, EndDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_RehireReport.Visible = true;
            }
            if ((txt_StartDate.SelectedDate != null) && (txt_EndDate.SelectedDate == null))
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("INCLUDEDATES", "YES");
                StartDate = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", txt_StartDate.SelectedDate.Value.ToShortDateString());
                EndDate = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", DateTime.Now.ToShortDateString());
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessUnit, Includedates, StartDate, EndDate };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_RehireReport.Visible = true;
            }
            else
            {
                Includedates = new Microsoft.Reporting.WebForms.ReportParameter("INCLUDEDATES", "NO");
                Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessUnit, Includedates };
                serverReport.SetParameters(parameters);
                serverReport.Refresh();
                RPT_RehireReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Rehire_Report", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
