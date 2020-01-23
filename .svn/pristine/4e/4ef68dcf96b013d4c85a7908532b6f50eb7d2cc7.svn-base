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

public partial class Reportss_frmGratuityReportSS : System.Web.UI.Page
{
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_PERIODDTL _obj_smhr_perioddtl;
    SMHR_LOGININFO _obj_LoginInfo;
    SMHR_PERIOD _obj_smhr_period;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckLoginUser();
            LoadPeriod();
            LoadOrganisation();
            LoadBusinessUnit();
        }
    }

    /// <summary>
    /// Loading of grid data
    /// </summary>
    private void LoadGrid()
    {
        try
        {
            rgGratuityReportSS.DataSource = BLL.GetGratuityReportSSReportData(Convert.ToInt32(Session["ORG_ID"]), Convert.ToInt32(rcbBU.SelectedValue), Convert.ToInt32(rcbPrdDtl.SelectedValue));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Need data source for Gratuity Report - Sun Systems
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rgGratuityReportSS_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(rcbBU.SelectedIndex) > 0 && Convert.ToInt32(rcbPrdDtl.SelectedIndex) > 0)
                LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Checking of Login Users
    /// </summary>
    private void CheckLoginUser()
    {
        try
        {
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Gratuity Report – Sun Systems");

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
                btnGenerate.Visible = false;
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
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To load all Organisation details
    /// </summary>
    private void LoadOrganisation()
    {
        try
        {
            _obj_LoginInfo = new SMHR_LOGININFO();

            _obj_LoginInfo.OPERATION = operation.Login1;
            _obj_LoginInfo.LOGIN_ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dt_logindetails = BLL.get_Logindetails(_obj_LoginInfo);

            if (dt_logindetails.Rows.Count > 0)
            {
                rcbOrg.DataSource = dt_logindetails;
                rcbOrg.DataTextField = "ORGANISATION_NAME";
                rcbOrg.DataValueField = "ORGANISATION_ID";
                rcbOrg.DataBind();

                rcbOrg.SelectedIndex = rcbOrg.Items.FindItemIndexByValue(Convert.ToString(Session["ORG_ID"]));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load Business Units
    /// </summary>
    private void LoadBusinessUnit()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();

            _obj_LoginInfo = new SMHR_LOGININFO();
            _obj_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);

            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_LoginInfo);

            if (dt_BUDetails.Rows.Count > 0)
            {
                rcbBU.DataSource = dt_BUDetails;
                rcbBU.DataTextField = "BUSINESSUNIT_CODE";
                rcbBU.DataValueField = "BUSINESSUNIT_ID";
                rcbBU.DataBind();
            }
            rcbBU.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load all Period data
    /// </summary>
    private void LoadPeriod()
    {
        try
        {
            _obj_smhr_period = new SMHR_PERIOD();

            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(_obj_smhr_period);

            if (dt_Details.Rows.Count > 0)
            {
                rcbPeriod.DataSource = dt_Details;
                rcbPeriod.DataTextField = "PERIOD_NAME";
                rcbPeriod.DataValueField = "PERIOD_ID";
                rcbPeriod.DataBind();
            }
            rcbPeriod.Items.Insert(0, new RadComboBoxItem("Select"));
            rcbPrdDtl.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On select Index changed event for Period Details
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcbPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbPeriod.SelectedIndex > 0)
            {
                _obj_smhr_perioddtl = new SMHR_PERIODDTL();
                _obj_smhr_perioddtl.OPERATION = operation.Select;
                _obj_smhr_perioddtl.PRDDTL_PERIOD_ID = Convert.ToInt32(rcbPeriod.SelectedItem.Value);

                DataTable dt_Details = BLL.get_PeriodDetails(_obj_smhr_perioddtl);

                if (dt_Details.Rows.Count != 0)
                {
                    rcbPrdDtl.DataSource = dt_Details;
                    rcbPrdDtl.DataTextField = "PRDDTL_NAME";
                    rcbPrdDtl.DataValueField = "PRDDTL_ID";
                    rcbPrdDtl.DataBind();
                }
                rcbPrdDtl.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
                rcbPrdDtl.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Generate click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            rwGratuityReportSS.VisibleOnPageLoad = true;

            LoadGrid();
            rgGratuityReportSS.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Excel click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rgGratuityReportSS.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
            rgGratuityReportSS.ExportSettings.IgnorePaging = true;
            rgGratuityReportSS.ExportSettings.ExportOnlyData = true;
            rgGratuityReportSS.ExportSettings.FileName = "Test";
            rgGratuityReportSS.MasterTableView.ExportToExcel();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("", ""), "Result", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Clear Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            rcbBU.SelectedIndex = rcbPeriod.SelectedIndex = rcbPrdDtl.SelectedIndex = 0;
            rwGratuityReportSS.VisibleOnPageLoad = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmGratuityReportSS", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}