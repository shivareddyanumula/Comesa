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

public partial class Reportss_Employee_Pay_Item : System.Web.UI.Page
{
    SMHR_PERIOD _obj_smhr_period;
    SMHR_EMPLOYEE _obj_smhr_employee;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_PERIODDTL _obj_Smhr_Prddtl;
    SMHR_PAYITEMS _obj_PayItems;
    SMHR_BUSINESSUNIT _obj_BusinessUnit;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_Item", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    private void LoadCombos()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_payperiod.DataSource = dt_Details;
            rcmb_payperiod.DataValueField = "PERIOD_ID";
            rcmb_payperiod.DataTextField = "PERIOD_NAME";
            rcmb_payperiod.DataBind();
            rcmb_payperiod.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_PayItems = new SMHR_PAYITEMS();
            _obj_PayItems.OPERATION = operation.Select;
            _obj_PayItems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt = BLL.get_PayItems(_obj_PayItems);
            ddl_Payitems.DataSource = dt;
            ddl_Payitems.DataTextField = "PAYITEM_PAYITEMNAME";
            ddl_Payitems.DataValueField = "PAYITEM_ID";
            ddl_Payitems.DataBind();
            ddl_Payitems.Items.Insert(0, new RadComboBoxItem("Select"));

            ddl_BusinessUnit.Items.Clear();
            //_obj_BusinessUnit = new SMHR_BUSINESSUNIT();
            //_obj_BusinessUnit.OPERATION = operation.Select;
            //_obj_BusinessUnit.ISDELETED = true;
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_Item", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void rcmb_payperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_payperiod.SelectedIndex != 0)
            {
                _obj_Smhr_Prddtl = new SMHR_PERIODDTL();
                _obj_Smhr_Prddtl.OPERATION = operation.Select;
                _obj_Smhr_Prddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcmb_payperiod.SelectedValue);
                DataTable dt_Details = BLL.get_PeriodDetails(_obj_Smhr_Prddtl);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_payElements.DataSource = dt_Details;
                    rcmb_payElements.DataValueField = "PRDDTL_ID";
                    rcmb_payElements.DataTextField = "PRDDTL_NAME";
                    rcmb_payElements.DataBind();
                    rcmb_payElements.Items.Insert(0, new RadComboBoxItem("Select"));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_Item", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_Payitems.SelectedIndex = 0;
            ddl_BusinessUnit.SelectedIndex = 0;
            rcmb_payElements.Items.Clear();
            rcmb_payperiod.SelectedIndex = 0;
            RPT_EmpPayItems.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_Item", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_payElements.SelectedValue) + "','" + Convert.ToString(ddl_BusinessUnit.SelectedValue) + "','" + Convert.ToString(ddl_Payitems.SelectedValue) + "');", true);
            //if (ddl_Payitems.SelectedIndex != 0)
            //{
            //RPT_EmpPayItems.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            //Microsoft.Reporting.WebForms.ServerReport serverReport = default(Microsoft.Reporting.WebForms.ServerReport);
            //serverReport = RPT_EmpPayItems.ServerReport;
            //RPT_EmpPayItems.AsyncRendering = false;
            //if (!RPT_EmpPayItems.Enabled)
            //{
            //    RPT_EmpPayItems.CurrentPage = 1;
            //}


            //string sDomain = System.Configuration.ConfigurationSettings.AppSettings["MyReportViewerDomain"];
            //WebClient Wc = new WebClient();
            //Reports.ReportServerNetworkCredentials _ObjNC = new Reports.ReportServerNetworkCredentials();
            //serverReport.ReportServerCredentials = _ObjNC;
            //serverReport.ReportServerUrl = new Uri(sDomain);
            //serverReport.ReportPath = "/SmartHR/" + "Pay Item";
            //Microsoft.Reporting.WebForms.ReportParameter BusinessGroup;
            //Microsoft.Reporting.WebForms.ReportParameter Period;
            //Microsoft.Reporting.WebForms.ReportParameter PayItem;
            //Microsoft.Reporting.WebForms.ReportParameter Organisation;
            //if (ddl_BusinessUnit.SelectedIndex != 0)
            //{
            //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", ddl_BusinessUnit.SelectedValue);
            //}
            //else
            //{
            //    BusinessGroup = new Microsoft.Reporting.WebForms.ReportParameter("BusinessUnit", "-1");
            //}
            //Period = new Microsoft.Reporting.WebForms.ReportParameter("Period", Convert.ToString(rcmb_payElements.SelectedValue));
            //PayItem = new Microsoft.Reporting.WebForms.ReportParameter("PayItem", Convert.ToString(ddl_Payitems.SelectedValue));
            //Organisation = new Microsoft.Reporting.WebForms.ReportParameter("Organisation", Convert.ToString(Session["ORG_ID"]));
            //Microsoft.Reporting.WebForms.ReportParameter[] parameters = { BusinessGroup, Period, PayItem, Organisation };
            //serverReport.SetParameters(parameters);
            //serverReport.Refresh();
            //RPT_EmpPayItems.Visible = true;
            // }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Employee_Pay_Item", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}
