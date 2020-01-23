using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPMS;
using Telerik.Web.UI;
using SMHR;

public partial class Reportss_PmsAppraisalOpen : System.Web.UI.Page
{
    SMHR_ORGANISATION obj_smhr_Organisation;
    SMHR_BUSINESSUNIT obj_smhr_Businessunit;
    SMHR_LOGININFO obj_smhr_Logininfo;
    SMHR_EMP_PAYITEMS _obj_smhr_emp_payitems;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SPMS_APPRAISAL _obj_Spms_Appraisal;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Open Appraisals");
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
                    // Rg_Countries.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Generate.Visible = false;
                    // btn_Update.Visible = false;
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
                Page.Validate();

                LoadOrganisation();
                LoadBusinessUnit();
                rcmb_Organisation.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
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
            rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem(Convert.ToString(Session["ORG_NAME"])));

            rcmb_AppCycle.Items.Insert(0, new RadComboBoxItem("All"));
            rcmb_RptEmp.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                LoadAppraisalCycle();
                LoadReportManager();
            }
            else
            {
                rcmb_AppCycle.ClearSelection();
                rcmb_AppCycle.Items.Clear();
                rcmb_AppCycle.Items.Insert(0, new RadComboBoxItem("All"));
                rcmb_RptEmp.ClearSelection();
                rcmb_RptEmp.Items.Clear();
                rcmb_RptEmp.Items.Insert(0, new RadComboBoxItem("All"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadReportManager()
    {
        try
        {
            rcmb_RptEmp.Items.Clear();
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.Mode = 1;
            _obj_Spms_Appraisal.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_manager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);
            if (dt_manager.Rows.Count != 0)
            {
                rcmb_RptEmp.DataSource = dt_manager;
                rcmb_RptEmp.DataTextField = "MANAGER";
                rcmb_RptEmp.DataValueField = "REPORTINGMGR_ID";
                rcmb_RptEmp.DataBind();
                rcmb_RptEmp.Items.Insert(0, new RadComboBoxItem("All"));
            }
            else
            {
                DataTable dt5 = new DataTable();
                rcmb_RptEmp.DataSource = dt5;
                rcmb_RptEmp.DataBind();
                rcmb_RptEmp.Items.Insert(0, new RadComboBoxItem("All"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadAppraisalCycle()
    {
        try
        {
            rcmb_AppCycle.Items.Clear();
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.MODE = 9;
            if (Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value) > 0)
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            }
            else
            {
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = 0;
            }
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rcmb_AppCycle.DataSource = DT_AppraisalCycle;
                rcmb_AppCycle.DataTextField = "APPRCYCLE_NAME";
                rcmb_AppCycle.DataValueField = "APPRCYCLE_ID";
                rcmb_AppCycle.DataBind();
                rcmb_AppCycle.Items.Insert(0, new RadComboBoxItem("All"));
            }
            else
            {
                DataTable dt6 = new DataTable();
                rcmb_AppCycle.DataSource = dt6;
                rcmb_AppCycle.DataBind();
                rcmb_AppCycle.Items.Insert(0, new RadComboBoxItem("All"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                "ShowPop('" + Convert.ToString(rcmb_Organisation.SelectedValue) + "','" + Convert.ToString(rcmb_BusinessUnit.SelectedValue) +
                            "', '" + Convert.ToString(rcmb_AppCycle.SelectedValue) + "', '" + Convert.ToString(rcmb_RptEmp.SelectedValue) + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            rcmb_Organisation.SelectedIndex = 0;
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_AppCycle.ClearSelection();
            rcmb_AppCycle.Items.Clear();
            rcmb_AppCycle.Items.Insert(0, new RadComboBoxItem("All"));
            rcmb_RptEmp.ClearSelection();
            rcmb_RptEmp.Items.Clear();
            rcmb_RptEmp.Items.Insert(0, new RadComboBoxItem("All"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "PmsAppraisalOpen", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
