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


public partial class Reportss_Employee_AssetReport : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            //_obj_smhr_businessunit.OPERATION = operation.Select;
            //_obj_smhr_businessunit.ISDELETED = true;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_Details = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataSource = dt_Details;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployees();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadEmployees()
    {
        try
        {
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            DataTable DT_Details = new DataTable();
            if (rcmb_BusinessUnit.SelectedItem.Value != "")
            {
                _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                DT_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
                if (DT_Details.Rows.Count != 0)
                {
                    BindEmployees(DT_Details);
                }
                else
                {
                    BindEmployees(DT_Details);
                }
            }
            else
            {
                BindEmployees(DT_Details);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void BindEmployees(DataTable DT_Details)
    {
        try
        {
            rcmb_employee.DataSource = DT_Details;
            rcmb_employee.DataTextField = "EMPNAME";
            rcmb_employee.DataValueField = "EMP_ID";
            rcmb_employee.DataBind();
            rcmb_employee.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            //LoadReport();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_employee.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //private void LoadReport()
    //{
        //RPT_EmployeeAssetReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        //Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
        //serverReport = RPT_EmployeeAssetReport.ServerReport;
        //string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
        //WebClient Wc = new WebClient();
        //Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
        //serverReport.ReportServerCredentials = _ObjNC;
        //serverReport.ReportServerUrl = new Uri(sDomain);
        //serverReport.ReportPath = "/SmartHR/" + "Asset Report";
        //Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
        //Microsoft.Reporting.WebForms.ReportParameter Employee;
        //Microsoft.Reporting.WebForms.ReportParameter Organisation;
        //if (Convert.ToString(Request.QueryString["BU"]) != "")
        //{
        //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", Convert.ToString(Request.QueryString["BU"]));
        //}
        //else
        //{
        //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
        //}
        //if (Convert.ToString(Request.QueryString["EMP"]) != "")
        //{
        //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", Convert.ToString(Request.QueryString["EMP"]));
        //}
        //else
        //{
        //    Employee = new Microsoft.Reporting.WebForms.ReportParameter("Employee", "-1");
        //}
        //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
        //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Employee,Organisation };
        //serverReport.SetParameters(parameters);
        //serverReport.Refresh();
        //RPT_EmployeeAssetReport.Visible = true;
    //}
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_employee.SelectedIndex = 0;
            RPT_EmployeeAssetReport.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_AssetReport", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
