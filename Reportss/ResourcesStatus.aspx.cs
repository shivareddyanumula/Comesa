using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SMHR;
using Telerik.Web.UI;

public partial class Reportss_ResourcesStatus : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation = new SMHR_ORGANISATION();
    SMHR_BUSINESSUNIT obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
    SMHR_PERIOD obj_smhr_Period = new SMHR_PERIOD();
    SMHR_LOGININFO obj_smhr_Logininfo = new SMHR_LOGININFO();
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems = new SMHR_EMP_PAYITEMS();
    SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LoadOrganisation();
                LoadBusinessUnit();
                rcmb_Organisation.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadOrganisation()
    {
        try
        {
            obj_smhr_Logininfo.OPERATION = operation.Login1;
            obj_smhr_Logininfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_logindetails = BLL.get_Logindetails(obj_smhr_Logininfo);

            rcmb_Organisation.DataSource = dt_logindetails;
            rcmb_Organisation.DataTextField = "organisation_name";
            rcmb_Organisation.DataValueField = "organisation_id";
            rcmb_Organisation.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);

            rcmb_BusinessUnit.DataSource = dt_BUDetails;
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataBind();

            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("All"));
            rcmb_ReportManager.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }              

    private void LoadReportingManager()
    {
        try
        {
            //obj_smhr_Logininfo.OPERATION = operation.Login1;
            //obj_smhr_Logininfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //obj_smhr_Logininfo.LOGIN_BUSINESSUNITID =Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.EMP_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);

            DataTable dt_ReportingManager = BLL.GET_REPORTING_MANAGER(_obj_smhr_employee);

            rcmb_ReportManager.DataSource = dt_ReportingManager;
            rcmb_ReportManager.DataTextField = "EMPLOYE NAME";
            rcmb_ReportManager.DataValueField = "EMP_ID";
            rcmb_ReportManager.DataBind();

            rcmb_ReportManager.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Organisation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadBusinessUnit();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (Convert.ToString(rcmb_BusinessUnit.SelectedValue) == "")
                //rcmb_ReportManager.SelectedIndex = 0;
                lbl_BusinessUnit.Visible = true;
            else
                LoadReportingManager();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_ReportManager.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Organisation.SelectedIndex = 0;
            rcmb_BusinessUnit.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "ResourcesStatus", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}