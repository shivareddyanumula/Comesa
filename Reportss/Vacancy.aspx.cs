using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_Vacancy : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            if (!Page.IsPostBack)
            {
                LoadOrganisation();
                LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Vacancy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadOrganisation()
    {
        try
        { 
        SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
        _obj_LoginInfo.OPERATION = operation.Login1;
        _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
        rcmb_Organisation.DataSource = dt_logindetails;
        rcmb_Organisation.DataTextField = "organisation_name";
        rcmb_Organisation.DataValueField = "organisation_id";
        rcmb_Organisation.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Vacancy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadBusinessUnit()
    {
        try
        { 
        obj_smhr_Businessunit = new SMHR_BUSINESSUNIT();
        obj_smhr_Logininfo = new SMHR_LOGININFO();

        obj_smhr_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        obj_smhr_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(obj_smhr_Logininfo);
        rcmb_BusinessUnit.DataSource = dt_BUDetails;
        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BusinessUnit.DataBind();
        rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Vacancy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
       
    }
   
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Organisation.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "Vacancy", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        rcmb_BusinessUnit.SelectedIndex = 0;
    }
}