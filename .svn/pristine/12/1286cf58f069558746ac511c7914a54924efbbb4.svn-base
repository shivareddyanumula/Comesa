using SMHR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Reportss_StaffEstablishment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
               
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Establishment Summary");
            DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);
            if (dtformdtls.Rows.Count != 0)
            {
                if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                {
                    Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                }
                else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                {
                    Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                }
                else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                {
                    Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
                }

            }
            else
            {
                smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                Response.Redirect("~/frm_UnAuthorized.aspx", false);
            }


            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                //Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Generate.Visible = false;
                //btn_Update.Visible = false;
            }
            else if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
            {
                smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();
                _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());
                SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                Response.Redirect("~/frm_UnAuthorized.aspx", false);
            }
            LoadFinPeriod();
            //LoadBusinessUnit();
            LoadJobs();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    //private void LoadBusinessUnit()
    //{
    //    try
    //    {
    //        SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    //        _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
    //        _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
    //        DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
    //        rcmb_BusinessUnit.DataSource = dt_BUDetails;
    //        rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
    //        rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
    //        rcmb_BusinessUnit.DataBind();
    //        rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("All", "-1"));
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        { 
        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) + "','" + Convert.ToString(rcmb_Job.SelectedValue) + "','" + Convert.ToString(rcmb_Financialperiod.SelectedValue) + "');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ShowPop('" + Convert.ToString(rcmb_Job.SelectedValue) + "','" + Convert.ToString(rcmb_Financialperiod.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            //rcmb_BusinessUnit.ClearSelection();
            //rcmb_Job.Items.Clear();
            //rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            //rcmb_BusinessUnit_SelectedIndexChanged(null, null);
            rcmb_Financialperiod.ClearSelection();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    //protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    try
    //    {
    //        LoadJobs();            
    //    }
    //    catch (Exception ex)
    //    {
    //        SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
    //        Response.Redirect("~/Frm_ErrorPage.aspx");
    //        return;
    //    }
    //}

    private void LoadJobs()
    {
        try
        {
            //if (rcmb_BusinessUnit.SelectedIndex > 0)
            //{
            //    SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
            //    _obj_Jobs.OPERATION = operation.Get;
            //    _obj_Jobs.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            //    _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    DataTable DT = BLL.get_Jobs(_obj_Jobs);
            //    rcmb_Job.DataSource = DT;
            //    rcmb_Job.DataTextField = "JOBS_CODE";
            //    rcmb_Job.DataValueField = "JOBS_ID";
            //    rcmb_Job.DataBind();
            //    rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All","-1"));
            //}
            //else
            //{
            SMHR_JOBS _obj_Jobs = new SMHR_JOBS();
            _obj_Jobs.OPERATION = operation.Select;
            //_obj_Jobs.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Jobs.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable DT = BLL.get_Jobs(_obj_Jobs);
            rcmb_Job.DataSource = DT;
            rcmb_Job.DataTextField = "JOBS_CODE";
            rcmb_Job.DataValueField = "JOBS_ID";
            rcmb_Job.DataBind();
            rcmb_Job.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("All", "-1"));
            //}
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "StaffEstablishment", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
}