using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using SPMS;
using Telerik.Web.UI;

public partial class PMS_frm_Pms_Reports : System.Web.UI.Page
{
    SPMS_APPRAISAL _obj_Spms_Appraisal;
    SPMS_APPRAISALKRA _obj_Spms_AppraisalKra;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    PMS_Appraisalcycle _obj_Pms_Appraisalcycle;
    SPMS_APRAISALSTATUS _obj_Pms_AppStatus;
    SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();

            if (!Page.IsPostBack)
            {


                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Other Reports");
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
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {

                Rg_Ratings.Enabled = false;


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

                Rg_Ratings.Enabled = true;
            }

            loadBusinessUnit();
            Rm_Reprts_Main_PAGE.SelectedIndex = 1;
            Rm_Reprts_Main_PAGE.Visible = true;
            Rm_Goal_Reports.Visible = false;
            Rm_Appraisal.Visible = false;
            Rm_App_Disc.Visible = false;


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rtn_Reportlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (rtn_Reportlist.SelectedValue)
            {
                case "0":
                    Rm_Goal_Reports.Visible = true;
                    Rm_Appraisal.Visible = false;
                    Rm_App_Disc.Visible = false;
                    loadBusinessUnitGoal();
                    Rm_Reprts_Main_PAGE.Visible = false;

                    break;
                case "1":
                    Rm_Goal_Reports.Visible = false;
                    Rm_Appraisal.Visible = true;
                    Rm_App_Disc.Visible = false;
                    loadBusinessUnitAppraisal();
                    Rm_Reprts_Main_PAGE.Visible = false;

                    break;
                case "3":
                    Rm_Goal_Reports.Visible = false;
                    Rm_Appraisal.Visible = false;
                    Rm_App_Disc.Visible = true;
                    loadBusinessUnitAppDisc();
                    Rm_Reprts_Main_PAGE.Visible = false;

                    break;
                case "4":
                    Rm_Reprts_Main_PAGE.SelectedIndex = 1;
                    loadBusinessUnit();
                    break;
                default:
                    return;
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #region loadbusinessunits

    protected void loadBusinessUnitGoal()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BusinessUnitGoal.DataSource = dt_BUDetails;
                rcmb_BusinessUnitGoal.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnitGoal.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnitGoal.DataBind();
                rcmb_BusinessUnitGoal.Items.Insert(0, new RadComboBoxItem("Select"));

            }

            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BusinessUnitGoal.DataSource = dt_Details;

                rcmb_BusinessUnitGoal.DataBind();
                rcmb_BusinessUnitGoal.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadBusinessUnit()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_BusinessUnit.DataSource = dt_BUDetails;
                rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));

            }
            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_BusinessUnit.DataSource = dt_Details;

                rcmb_BusinessUnit.DataBind();
                rcmb_BusinessUnit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadBusinessUnitAppraisal()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_businessunitAppraisal.DataSource = dt_BUDetails;
                rcmb_businessunitAppraisal.DataValueField = "BUSINESSUNIT_ID";
                rcmb_businessunitAppraisal.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_businessunitAppraisal.DataBind();
                rcmb_businessunitAppraisal.Items.Insert(0, new RadComboBoxItem("Select"));

            }
            else
            {
                DataTable dt_Details = new DataTable();
                rcmb_businessunitAppraisal.DataSource = dt_Details;

                rcmb_businessunitAppraisal.DataBind();
                rcmb_businessunitAppraisal.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadBusinessUnitAppDisc()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();


            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcm_bunitAppDisc.DataSource = dt_BUDetails;
                rcm_bunitAppDisc.DataValueField = "BUSINESSUNIT_ID";
                rcm_bunitAppDisc.DataTextField = "BUSINESSUNIT_CODE";
                rcm_bunitAppDisc.DataBind();
                rcm_bunitAppDisc.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                DataTable dt_Details = new DataTable();
                rcm_bunitAppDisc.DataSource = dt_Details;

                rcm_bunitAppDisc.DataBind();
                rcm_bunitAppDisc.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    #endregion

    #region businessunit select index change event
    protected void rcmb_BusinessUnitGoal_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnitGoal.SelectedItem.Text != "Select")
            {
                loadAppCycleGoal();
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Business Unit");
                DataTable dt = new DataTable();
                RCB_AppraisalCycleGoal.DataSource = dt;
                RCB_AppraisalCycleGoal.DataBind();
                rcmb_RptEmp_Goal.DataSource = dt;
                rcmb_RptEmp_Goal.DataBind();
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcmb_businessunitAppraisal_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_businessunitAppraisal.SelectedItem.Text != "Select")
            {
                loadAppCyclAppraisal();
            }

            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Business Unit");
                DataTable dt = new DataTable();
                rcmb_appraisalApprais.DataSource = dt;
                rcmb_appraisalApprais.DataBind();

                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void rcm_bunitAppDisc_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcm_bunitAppDisc.SelectedItem.Text != "Select")
            {
                loadAppCyclAppDisc();
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Business Unit");
                DataTable dt = new DataTable();
                rcm_app_cycleAppDisc.DataSource = dt;
                rcm_app_cycleAppDisc.DataBind();

                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion


    #region LOAD APPRAISAL CYCLE
    protected void loadAppCycleGoal()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.OPERATION = operation.Empty;
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitGoal.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                RCB_AppraisalCycleGoal.DataSource = DT_AppraisalCycle;
                RCB_AppraisalCycleGoal.DataTextField = "APPRCYCLE_NAME";
                RCB_AppraisalCycleGoal.DataValueField = "APPRCYCLE_ID";
                RCB_AppraisalCycleGoal.DataBind();
                RCB_AppraisalCycleGoal.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
            else
            {
                DataTable dt1 = new DataTable();
                RCB_AppraisalCycleGoal.DataSource = dt1;

                RCB_AppraisalCycleGoal.DataBind();
                RCB_AppraisalCycleGoal.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadAppCyclAppraisal()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.OPERATION = operation.Empty;
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_businessunitAppraisal.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rcmb_appraisalApprais.DataSource = DT_AppraisalCycle;
                rcmb_appraisalApprais.DataTextField = "APPRCYCLE_NAME";
                rcmb_appraisalApprais.DataValueField = "APPRCYCLE_ID";
                rcmb_appraisalApprais.DataBind();
                rcmb_appraisalApprais.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

            else
            {
                DataTable dt1 = new DataTable();

                rcmb_appraisalApprais.DataSource = dt1;

                rcmb_appraisalApprais.DataBind();
                rcmb_appraisalApprais.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void loadAppCyclAppDisc()
    {
        try
        {
            _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
            _obj_Pms_Appraisalcycle.OPERATION = operation.Empty;
            _obj_Pms_Appraisalcycle.MODE = 8;
            _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcm_bunitAppDisc.SelectedItem.Value);
            _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
            DataTable DT_AppraisalCycle = new DataTable();
            DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
            if (DT_AppraisalCycle.Rows.Count != 0)
            {
                rcm_app_cycleAppDisc.DataSource = DT_AppraisalCycle;
                rcm_app_cycleAppDisc.DataTextField = "APPRCYCLE_NAME";
                rcm_app_cycleAppDisc.DataValueField = "APPRCYCLE_ID";
                rcm_app_cycleAppDisc.DataBind();
                rcm_app_cycleAppDisc.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }

            else
            {
                DataTable dt1 = new DataTable();
                rcm_app_cycleAppDisc.DataSource = dt1;

                rcm_app_cycleAppDisc.DataBind();
                rcm_app_cycleAppDisc.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region appraisal cycle changed
    protected void RCB_AppraisalCycleGoal_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (RCB_AppraisalCycleGoal.SelectedItem.Text != "Select")
            {
                rcmb_RptEmp_Goal.Items.Clear();
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.Mode = 1;
                _obj_Spms_Appraisal.BUID = Convert.ToInt32(rcmb_BusinessUnitGoal.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_manager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);
                if (dt_manager.Rows.Count != 0)
                {
                    rcmb_RptEmp_Goal.DataSource = dt_manager;
                    rcmb_RptEmp_Goal.DataTextField = "MANAGER";
                    rcmb_RptEmp_Goal.DataValueField = "REPORTINGMGR_ID";
                    rcmb_RptEmp_Goal.DataBind();
                    rcmb_RptEmp_Goal.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {
                    DataTable dt5 = new DataTable();
                    rcmb_RptEmp_Goal.DataSource = dt5;
                    rcmb_RptEmp_Goal.DataBind();
                    rcmb_RptEmp_Goal.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rcmb_RptEmp_Goal.ClearSelection();
                rcmb_RptEmp_Goal.Items.Clear();
                rcmb_RptEmp_Goal.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_RptEmp_Goal_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_RptEmp_Goal.SelectedItem.Text != "Select")
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnitGoal.SelectedValue);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);

                DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzz1.Rows.Count != 0)
                {
                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 25;
                    _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(rcmb_BusinessUnitGoal.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(RCB_AppraisalCycleGoal.SelectedItem.Value);//Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
                    _obj_Spms_Appraisal.EMP_ID = Convert.ToInt32(rcmb_RptEmp_Goal.SelectedItem.Value);
                    DataTable DT = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);

                    if (DT.Rows.Count != 0)
                    {
                        RG_GoalReports.DataSource = DT;
                        RG_GoalReports.DataBind();
                        Rm_Goal_Reports.SelectedIndex = 1;
                    }
                    else
                    {
                        DataTable dt2 = new DataTable();
                        RG_GoalReports.DataSource = dt2;
                        RG_GoalReports.DataBind();
                        Rm_Goal_Reports.SelectedIndex = 1;
                    }

                }
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_appraisalApprais_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_appraisalApprais.SelectedItem.Text != "Select")
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_businessunitAppraisal.SelectedValue);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzz1.Rows.Count != 0)
                {

                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 24;
                    _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(rcmb_businessunitAppraisal.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rcmb_appraisalApprais.SelectedItem.Value);//Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
                    DataTable DT = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (DT.Rows.Count != 0)
                    {
                        RG_AppraisalReports.DataSource = DT;
                        RG_AppraisalReports.DataBind();
                        Rm_Appraisal.SelectedIndex = 1;
                    }

                    else
                    {
                        DataTable dt2 = new DataTable();
                        RG_AppraisalReports.DataSource = dt2;
                        RG_AppraisalReports.DataBind();
                        Rm_Appraisal.SelectedIndex = 1;
                    }
                }

            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Active Appraisal Cycle Under Business Unit");
                DataTable dt1 = new DataTable();
                RG_AppraisalReports.DataSource = dt1;
                RG_AppraisalReports.DataBind();
                Rm_Goal_Reports.SelectedIndex = 1;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcm_app_cycleAppDisc_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcm_app_cycleAppDisc.SelectedItem.Text != "Select")
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcm_bunitAppDisc.SelectedValue);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["org_id"]);
                DataTable dtappidzz1 = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtappidzz1.Rows.Count != 0)
                {


                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 26;
                    _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(rcm_bunitAppDisc.SelectedItem.Value);
                    _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rcm_app_cycleAppDisc.SelectedItem.Value);//Convert.ToInt32(dtappidzz1.Rows[0]["APPRCYCLE_ID"]);
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["org_id"]);
                    DataTable DT = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
                    if (DT.Rows.Count != 0)
                    {
                        Rg_appdisc.DataSource = DT;
                        Rg_appdisc.DataBind();
                        Rm_App_Disc.SelectedIndex = 1;
                    }

                    else
                    {
                        DataTable dt2 = new DataTable();

                        Rg_appdisc.DataSource = dt2;
                        Rg_appdisc.DataBind();
                        Rm_App_Disc.SelectedIndex = 1;

                    }
                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "No Active Appraisal Cycle Under Business Unit");
                DataTable dt1 = new DataTable();
                Rg_appdisc.DataSource = dt1;
                Rg_appdisc.DataBind();
                Rm_Goal_Reports.SelectedIndex = 1;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion


    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedItem.Text != "Select")
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.OPERATION = operation.Empty;
                _obj_Pms_Appraisalcycle.MODE = 8;
                _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable DT_AppraisalCycle = new DataTable();
                DT_AppraisalCycle = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (DT_AppraisalCycle.Rows.Count != 0)
                {
                    rcmb_AppCycle.DataSource = DT_AppraisalCycle;
                    rcmb_AppCycle.DataTextField = "APPRCYCLE_NAME";
                    rcmb_AppCycle.DataValueField = "APPRCYCLE_ID";
                    rcmb_AppCycle.DataBind();
                    rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
                else
                {

                    DataTable dt4 = new DataTable();
                    rcmb_AppCycle.DataSource = dt4;

                    rcmb_AppCycle.DataBind();
                    rcmb_AppCycle.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                    return;
                }
            }

            else
            {

                Pms_Bll.ShowMessage(this, "Please Select Business Unit");
                DataTable dt5 = new DataTable();
                rcmb_AppCycle.DataSource = dt5;
                rcmb_AppCycle.DataBind();
                //rcmb_RManager.Visible = false;
                //lbl_RM.Visible = false;
                rcmb_RManager.DataSource = dt5;
                rcmb_RManager.DataBind();
                Rg_Ratings.Visible = false;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void rcmb_AppCycle_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_AppCycle.SelectedItem.Text != "Select")
            {
                //yyyy
                _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                _obj_Spms_Appraisal.Mode = 1;
                _obj_Spms_Appraisal.BUID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dt_manager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);
                if (dt_manager.Rows.Count != 0)
                {
                    rcmb_RManager.DataSource = dt_manager;
                    rcmb_RManager.DataTextField = "MANAGER";
                    rcmb_RManager.DataValueField = "REPORTINGMGR_ID";
                    rcmb_RManager.DataBind();
                    rcmb_RManager.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }

                else
                {
                    DataTable dt5 = new DataTable();
                    rcmb_RManager.DataSource = dt5;

                    rcmb_RManager.DataBind();
                    rcmb_RManager.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

                }
            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Appraisal Cycle");
                DataTable dt5 = new DataTable();

                //rcmb_RManager.Visible = false;
                //lbl_RM.Visible = false;
                rcmb_RManager.DataSource = dt5;
                rcmb_RManager.DataBind();
                //rcmb_RManager.Visible = false;
                //lbl_RM.Visible = false;
                Rg_Ratings.Visible = false;
                return;

            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }



    protected void rcmb_RManager_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_RManager.SelectedItem.Text != "Select")
            {
                _obj_Pms_Appraisalcycle = new PMS_Appraisalcycle();
                _obj_Pms_Appraisalcycle.MODE = 11;
                _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Pms_Appraisalcycle.APPRCYCLE_ID = Convert.ToInt32(rcmb_RManager.SelectedItem.Value);//where i am passing employee to get bunit
                DataTable dtemzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);
                if (dtemzzR.Rows.Count != 0)
                {
                    _obj_Pms_Appraisalcycle.MODE = 8;
                    _obj_Pms_Appraisalcycle.APPRCYCLE_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    //_obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(dtemzzR.Rows[0]["EMP_BUSINESSUNIT_ID"]);
                    _obj_Pms_Appraisalcycle.APPRCYCLE_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
                    DataTable dtappidzzR = Pms_Bll.get_Appraisalcycle(_obj_Pms_Appraisalcycle);



                    _obj_Spms_Appraisal = new SPMS_APPRAISAL();
                    _obj_Spms_Appraisal.Mode = 2;
                    _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(rcmb_RManager.SelectedItem.Value);
                    if (dtappidzzR.Rows.Count != 0)
                    {
                        _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value); //Convert.ToInt32(dtappidzzR.Rows[0]["APPRCYCLE_ID"]);
                    }
                    _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    DataTable dt_Rmanager = Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal);

                    if (dt_Rmanager.Rows.Count != 0)
                    {
                        Rg_Ratings.DataSource = dt_Rmanager;
                        Rg_Ratings.DataBind();


                        _obj_Pms_AppStatus = new SPMS_APRAISALSTATUS();
                        _obj_Pms_AppStatus.Mode = 7;
                        _obj_Pms_AppStatus.APP_STATUS_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _obj_Pms_AppStatus.APP_STATUS_APPRAISALCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
                        DataTable dtappsttusemp = Pms_Bll.get_AppStatus(_obj_Pms_AppStatus);
                        if (dtappsttusemp.Rows.Count != 0)
                        {
                            for (int k = 0; k <= Rg_Ratings.Items.Count - 1; k++)
                            {
                                for (int z = 0; z < dtappsttusemp.Rows.Count; z++)
                                {
                                    if (Convert.ToInt32(dt_Rmanager.Rows[k]["EMP_ID"]) == Convert.ToInt32(dtappsttusemp.Rows[z]["APP_EMP_ID"]))
                                    {

                                        LinkButton lnkrej = Rg_Ratings.Items[k].FindControl("lnk_Employee_Edit") as LinkButton;
                                        lnkrej.Visible = false;



                                    }

                                }

                            }
                        }
                        else
                        {
                            Rg_Ratings.DataSource = dt_Rmanager;
                            Rg_Ratings.DataBind();
                            //Pms_Bll.ShowMessage(this, "No Employee Completed Appraisal Status");

                        }


                        Rm_Reprts_Main_PAGE.SelectedIndex = 2;
                    }
                    else
                    {
                        Pms_Bll.ShowMessage(this, "No Employee Under Reporting Manager");


                        //Rg_Ratings.Visible = false;
                        return;

                    }

                }

                //else
                //{
                //    Pms_Bll.ShowMessage(this, "Employee Is In Active");


                //    //Rg_Ratings.Visible = false;
                //    return;

                //}

            }
            else
            {
                Pms_Bll.ShowMessage(this, "Please Select Reporting Manager");


                //Rg_Ratings.Visible = false;
                return;
            }
        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }


    }

    protected void Rg_Ratings_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //GridDataItem item = e.Item as GridDataItem;
        //GridTableCell linkcell = new GridTableCell();
        //linkcell = (GridTableCell)item["TemplateLinkColumn"];
        //HyperLink lnkcolumn = (HyperLink)linkcell.FindControl("Link");

        //// Set the text to the quote number
        //lnkcolumn.Text = "Google";

        ////Set the URL
        //lnkcolumn.NavigateUrl = "http://www.google.com";

        ////Tell it to open in a new window
        //lnkcolumn.Target = "_new";

    }

    protected void lnk_Reject_Command(object sender, CommandEventArgs e)
    {
        try
        {
            _obj_Spms_Appraisal = new SPMS_APPRAISAL();
            _obj_Spms_Appraisal.APPRAISAL_EMP_ID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);

            _obj_Spms_Appraisal.Mode = 5;

            DataTable dtgoal4 = Pms_Bll.get_Appraisal(_obj_Spms_Appraisal);
            if (dtgoal4.Rows.Count != 0)
            {
                _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
            }
            //_obj_Spms_AppraisalKra.APP_KRA_FIXED = 1;
            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Spms_Appraisal.APPRAISAL_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.Mode = 4;
            //if (Convert.ToString(Pms_Bll.get_EmpRatingDetails(_obj_Spms_Appraisal).Rows[0]["Count"]) == "0")
            //{
            //    BLL.ShowMessage(this, "Please do Appraisal Discussion Before Reject.");
            //    return;
            //}
            //TO GET THE EMP DETAILS
            SPMS_APRAISALDISCUSSION _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
            _obj_Pms_AppDiscDtls.Mode = 6;
            _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dtemployee22 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);
            //TO ONSERT DATA INTO APPRAISAL_REJECT TABLE
            _obj_Spms_Appraisal.Mode = 6;
            _obj_Spms_Appraisal.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Spms_Appraisal.EMPID = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            _obj_Spms_Appraisal.APPRAISAL_ID = Convert.ToInt32(dtgoal4.Rows[0]["APPRAISAL_ID"]);
            _obj_Spms_Appraisal.APPRAISAL_APPRAISALCYCLE = Convert.ToInt32(rcmb_AppCycle.SelectedItem.Value);
            _obj_Spms_Appraisal.APPRAISAL_BUSSINESS_UNIT = Convert.ToInt32(dtemployee22.Rows[0]["EMP_BU_ID"]);
            _obj_Spms_Appraisal.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            bool st_reject = Pms_Bll.set_EmpRejectdetails(_obj_Spms_Appraisal);

            _obj_Spms_Appraisal.Mode = 3;
            bool st = Pms_Bll.set_EmpRatingdetails(_obj_Spms_Appraisal);

            Pms_Bll.ShowMessage(this, "Rejected Successfully");
            _obj_Pms_AppDiscDtls = new SPMS_APRAISALDISCUSSION();
            _obj_Pms_AppDiscDtls.Mode = 9;
            _obj_Pms_AppDiscDtls.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtemployee223 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);

            bool status10;
            bool status11;
            //if ((dtemployee22.Rows.Count != 0))
            //{
            //    Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_PMS_APPraisalReject_Backup @HR_name='" + Convert.ToString("HR") + "',@EMPLOYEEmail='" + Convert.ToString(dtemployee22.Rows[0]["employee_EMAILID"]) + "',@REPORTINGMANAGER='" + Convert.ToString(dtemployee22.Rows[0]["REPORTINGMANAGER"]) + "',@EMPNAME='" + Convert.ToString(dtemployee22.Rows[0]["employeename"]) + "'");
            //    status10 = true;

            //}

            //else
            //{
            //    status10 = false;
            //}
            _obj_Pms_AppDiscDtls.Mode = 7;
            _obj_Pms_AppDiscDtls.APP_DISCUSSION_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Pms_AppDiscDtls.APP_DISCUSSION_LASTMDFBY = Convert.ToInt32(Convert.ToString(e.CommandArgument));
            DataTable dtemployee224 = Pms_Bll.get_AppDiscDtls(_obj_Pms_AppDiscDtls);
            if (dtemployee224.Rows.Count > 0 && dtemployee223.Rows.Count > 0)
            {
                Dal.ExecuteNonQuery("EXEC USP_SEND_EMAIL_PMS_APPraisalRejetomgr @HR_name='" + Convert.ToString(dtemployee223.Rows[0]["HrMANAGER"]) + "',@empname='" + Convert.ToString(dtemployee224.Rows[0]["employee"]) + "',@REPORTINGMANAGERname='" + Convert.ToString(dtemployee224.Rows[0]["REPORTINGMANAGER"]) + "',@REPORTINGMANAGERmail='" + Convert.ToString(dtemployee224.Rows[0]["LOGIN_EMAILID_rmgr"]) + "'");
                status11 = true;
            }
            else
            {
                status11 = false;
            }
            if (status11)
                Pms_Bll.ShowMessage(this, "Notification Sent");

            Rm_Reprts_Main_PAGE.SelectedIndex = 0;
            Rm_Reprts_Main_PAGE.Visible = true;
            Rm_Goal_Reports.Visible = false;
            Rm_Appraisal.Visible = false;
            Rm_App_Disc.Visible = false;


        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void lnk_ViewDetailsCommand(object sender, CommandEventArgs e)
    {
        try
        {
            string EMP_ID = Convert.ToString(e.CommandArgument);
            string STR = "APPR_APPROVAL";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "FeedBack_Details()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                "ShowPop('" + Convert.ToString(EMP_ID) + "','" + Convert.ToString(rcmb_AppCycle.SelectedItem.Value) + "','" + STR + "');", true);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Pms_Reports", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
