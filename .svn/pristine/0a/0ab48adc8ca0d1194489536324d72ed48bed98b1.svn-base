using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_EstablishmentVacantPositions : System.Web.UI.Page
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
                // LoadOrganisation();
                LoadFinPeriod();
                LoadBusinessUnit();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EstablishmentVacantPositions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
         try
        {
        //SMHR_BUSINESSUNIT _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
        //_obj_smhr_period = new SMHR_PERIOD();

        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
        rcmb_BusinessUnit.DataSource = dt_BUDetails;
        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
        rcmb_BusinessUnit.DataBind();
        rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("All", "-1"));
        }
         catch (Exception ex)
         {
             SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EstablishmentVacantPositions", ex.StackTrace, DateTime.Now);
             Response.Redirect("~/Frm_ErrorPage.aspx");
         }
    }
    private void LoadFinPeriod()
    {
        try 
        { 
        // for loading the financial periods
        SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
        DataTable dt_Details = new DataTable();
        //_obj_smhr_period.OPERATION = operation.Select;
        _obj_smhr_period.OPERATION = operation.Empty;   //To fetch current financial period
        _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
        dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
        rcmb_Financialperiod.DataSource = dt_Details;
        rcmb_Financialperiod.DataTextField = "PERIOD_NAME";
        rcmb_Financialperiod.DataValueField = "PERIOD_ID";
        rcmb_Financialperiod.DataBind();
        //rcmb_Financialperiod.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EstablishmentVacantPositions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    //private void LoadOrganisation()
    //{

    //    SMHR_LOGININFO _obj_LoginInfo = new SMHR_LOGININFO();
    //    _obj_LoginInfo.OPERATION = operation.Login1;
    //    _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //    DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);
    //    rcmb_Organisation.DataSource = dt_logindetails;
    //    rcmb_Organisation.DataTextField = "organisation_name";
    //    rcmb_Organisation.DataValueField = "organisation_id";
    //    rcmb_Organisation.DataBind();
    //}
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Financialperiod.SelectedValue) + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Financialperiod.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EstablishmentVacantPositions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Financialperiod.ClearSelection();
            rcmb_BusinessUnit.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EstablishmentVacantPositions", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}