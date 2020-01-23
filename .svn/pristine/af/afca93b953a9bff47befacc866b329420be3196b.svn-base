using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Text;

public partial class Payroll_frm_payrollemail : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PAYROLL _obj_smhr_payroll;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadCombos()
    {
        try
        {
            rcmb_BU.Items.Clear();
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_Period.Items.Clear();
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
            DataTable dt_Details = new DataTable();
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rcmb_Period.SelectedIndex) > 0)
            {
                rcmb_PeriodElements.Items.Clear();
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_payroll.MODE = 11;
                DataTable dt_Details = new DataTable();
                dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                rcmb_PeriodElements.DataSource = dt_Details;
                rcmb_PeriodElements.DataValueField = "PRDDTL_ID";
                rcmb_PeriodElements.DataTextField = "PRDDTL_NAME";
                rcmb_PeriodElements.DataBind();
                rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_PeriodElements.Items.Clear();
                rcmb_PeriodElements.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BU_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BU.SelectedIndex > 0)
            {
                LoadEmployees();
            }
            else
            {
                rcmb_selectedEMP.Items.Clear();
                rcmb_SendtoEMP.Items.Clear();
                rcmb_SendtoEMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
                rcmb_selectedEMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployees()
    {
        try
        {
            rcmb_selectedEMP.Items.Clear();
            SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
            _obj_smhr_emp_payitems.OPERATION = operation.Empty;
            _obj_smhr_emp_payitems.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_emp_payitems.SMHR_BUSUNIT = Convert.ToInt32(rcmb_BU.SelectedValue);
            DataTable dt_Details = BLL.get_EmpDetails(_obj_smhr_emp_payitems);
            rcmb_selectedEMP.DataSource = dt_Details;
            rcmb_selectedEMP.DataTextField = "EMPNAME";
            rcmb_selectedEMP.DataValueField = "EMP_ID";
            rcmb_selectedEMP.DataBind();
            rcmb_selectedEMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));

            rcmb_SendtoEMP.Items.Clear();
            rcmb_SendtoEMP.Items.Clear();
            rcmb_SendtoEMP.DataSource = dt_Details;
            rcmb_SendtoEMP.DataTextField = "EMPNAME";
            rcmb_SendtoEMP.DataValueField = "EMP_ID";
            rcmb_SendtoEMP.DataBind();
            rcmb_SendtoEMP.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Send_Click(object sender, EventArgs e)
    {
        try
        {
            if (!((rcmb_selectedEMP.SelectedIndex > 0 || chk_selectedEMP.Checked == true) && (rcmb_SendtoEMP.SelectedIndex > 0 || chk_sendtoEMP.Checked == true)))
            {
                BLL.ShowMessage(this, "Please Select Properly.");
                return;
            }
            if (rcmb_selectedEMP.SelectedIndex > 0 && rcmb_SendtoEMP.SelectedIndex > 0)
            {

            }
            else if (rcmb_selectedEMP.SelectedIndex > 0 && chk_sendtoEMP.Checked == true)
            {

            }
            else if (chk_selectedEMP.Checked == true && rcmb_SendtoEMP.SelectedIndex > 0)
            {

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectedEMP_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_selectedEMP.SelectedIndex > 0 && chk_selectedEMP.Checked==true)
            {
                //BLL.ShowMessage(this, "To Check this First Please Unselect the Employee.");
                rcmb_selectedEMP.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_sendtoEMP_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_SendtoEMP.SelectedIndex > 0 && chk_sendtoEMP.Checked==true)
            {
                //BLL.ShowMessage(this, "To Check this First Please Unselect the Employee.");
                rcmb_SendtoEMP.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_selectedEMP_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_selectedEMP.SelectedIndex > 0 && chk_selectedEMP.Checked == true)
            {
                //BLL.ShowMessage(this, "Please first Uncheck the ALL Employees.");
                chk_selectedEMP.Checked = false;
                
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_SendtoEMP_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_SendtoEMP.SelectedIndex > 0 && chk_sendtoEMP.Checked == true)
            {
                //BLL.ShowMessage(this, "Please first Uncheck the ALL Employees.");
                chk_sendtoEMP.Checked = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Payrollemail", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
