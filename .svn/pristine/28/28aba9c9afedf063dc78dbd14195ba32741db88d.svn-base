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

public partial class Masters_frm_PayrollPeriod : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PERIOD _obj_smhr_period;
    SMHR_PAYROLL _obj_smhr_payroll;
    SMHR_PAYROLLPERIOD _obj_smhr_PayrollPeriod;

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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Payroll Period");
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
                    rg_PayrollPeriod.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    btn_Save.Visible = false;
                    btn_Update.Visible = false;
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
                LoadCombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadCombos()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BU.DataSource = dt_BUDetails;
            rcmb_BU.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BU.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BU.DataBind();
            rcmb_BU.Items.Insert(0, new RadComboBoxItem("Select"));

            _obj_smhr_period = new SMHR_PERIOD();
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }


    protected void rcmb_Period_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Period.SelectedIndex > 0)
            {
                _obj_smhr_payroll = new SMHR_PAYROLL();
                _obj_smhr_payroll.PERIODDTLID = Convert.ToInt32(rcmb_Period.SelectedValue);
                _obj_smhr_payroll.MODE = 28;
                DataTable dt_Details = BLL.get_payrolltrans(_obj_smhr_payroll);
                if (dt_Details.Rows.Count != 0)
                {
                    rcmb_PeriodDetails.DataSource = dt_Details;
                    rcmb_PeriodDetails.DataValueField = "PRDDTL_ID";
                    rcmb_PeriodDetails.DataTextField = "PRDDTL_NAME";
                    rcmb_PeriodDetails.DataBind();
                    rcmb_PeriodDetails.Items.Insert(0, new RadComboBoxItem("Select"));
                    rcmb_PeriodDetails.Visible = true;
                }
                else
                {
                    rcmb_PeriodDetails.ClearSelection();
                    rcmb_PeriodDetails.Items.Clear();
                    rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
            else
            {
                rcmb_PeriodDetails.ClearSelection();
                rcmb_PeriodDetails.Items.Clear();
                rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_PayrollPeriod = new SMHR_PAYROLLPERIOD();
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_BU = Convert.ToInt32(rcmb_BU.SelectedItem.Value);
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_PERIOD = Convert.ToInt32(rcmb_Period.SelectedItem.Value);
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_PERIODDETAILS = Convert.ToInt32(rcmb_PeriodDetails.SelectedItem.Value);
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_STARTDATE = Convert.ToDateTime(rdtp_StartDate.SelectedDate);
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_ENDDATE = Convert.ToDateTime(rdtp_EndDate.SelectedDate);
            _obj_smhr_PayrollPeriod.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_PayrollPeriod.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_PayrollPeriod.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_smhr_PayrollPeriod.MODE = 2;
                    if (Convert.ToString(BLL.get_PayrollPeriod(_obj_smhr_PayrollPeriod).Rows[0]["COUNT"]) != "0")
                    {
                        BLL.ShowMessage(this, "Details are already Saved for the Selected BU and Period Detials");
                        return;
                    }
                    _obj_smhr_PayrollPeriod.MODE = 1;
                    if (BLL.set_PayrollPeriod(_obj_smhr_PayrollPeriod))
                        BLL.ShowMessage(this, "Information Saved Successfully.");
                    break;
                case "BTN_UPDATE":
                    _obj_smhr_PayrollPeriod.MODE = 2;
                    if (Convert.ToString(BLL.get_PayrollPeriod(_obj_smhr_PayrollPeriod).Rows[0]["COUNT"]) != "1")
                    {
                        BLL.ShowMessage(this, "Details are already Saved for the Selected BU and Period Details");
                        return;
                    }
                    _obj_smhr_PayrollPeriod.PAYROLLPERIOD_ID = Convert.ToInt32(lbl_ID.Text);
                    _obj_smhr_PayrollPeriod.MODE = 5;
                    if (BLL.set_PayrollPeriod(_obj_smhr_PayrollPeriod))
                        BLL.ShowMessage(this, "Information Updated Successfully.");
                    break;
                default:
                    break;
            }
            ClearControls();
            RMP_PayrollPeriod.SelectedIndex = 0;
            LoadGrid();
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            RMP_PayrollPeriod.SelectedIndex = 0;
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void ClearControls()
    {
        try
        {
            rcmb_BU.SelectedIndex = 0;
            rcmb_Period.SelectedIndex = 0;
            rcmb_PeriodDetails.ClearSelection();
            rcmb_PeriodDetails.Items.Clear();
            rcmb_PeriodDetails.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            rdtp_StartDate.SelectedDate = null;
            rdtp_EndDate.SelectedDate = null;
            lbl_ID.Text = string.Empty;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_PayrollPeriod_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            _obj_smhr_PayrollPeriod = new SMHR_PAYROLLPERIOD();
            _obj_smhr_PayrollPeriod.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_PayrollPeriod.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_PayrollPeriod.MODE = 3;
            DataTable dt = BLL.get_PayrollPeriod(_obj_smhr_PayrollPeriod);
            rg_PayrollPeriod.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadGrid()
    {
        try
        {
            _obj_smhr_PayrollPeriod = new SMHR_PAYROLLPERIOD();
            _obj_smhr_PayrollPeriod.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_PayrollPeriod.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_PayrollPeriod.MODE = 3;
            DataTable dt = BLL.get_PayrollPeriod(_obj_smhr_PayrollPeriod);
            rg_PayrollPeriod.DataSource = dt;
            rg_PayrollPeriod.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            ClearControls();
            RMP_PayrollPeriod.SelectedIndex = 1;
            LoadCombos();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            rcmb_BU.Enabled = true;
            rcmb_Period.Enabled = true;
            rcmb_PeriodDetails.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            RMP_PayrollPeriod.SelectedIndex = 1;
            rcmb_PeriodDetails.Enabled = false;
            rcmb_Period.Enabled = false;
            rcmb_BU.Enabled = false;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            LoadCombos();
            lbl_ID.Text = Convert.ToString(Convert.ToInt32(e.CommandArgument));
            _obj_smhr_PayrollPeriod = new SMHR_PAYROLLPERIOD();
            _obj_smhr_PayrollPeriod.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_PayrollPeriod.PAYROLLPERIOD_ID = Convert.ToInt32(e.CommandArgument);
            _obj_smhr_PayrollPeriod.MODE = 4;
            DataTable dt = BLL.get_PayrollPeriod(_obj_smhr_PayrollPeriod);
            if (dt.Rows.Count > 0)
            {
                rcmb_BU.SelectedIndex = rcmb_BU.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYROLLPERIOD_BU"]));
                rcmb_Period.SelectedIndex = rcmb_Period.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYROLLPERIOD_PERIOD"]));
                rcmb_Period_SelectedIndexChanged(null, null);
                rcmb_PeriodDetails.SelectedIndex = rcmb_PeriodDetails.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["PAYROLLPERIOD_PERIODDETAILS"]));
                rdtp_StartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PAYROLLPERIOD_STARTDATE"]);
                rdtp_EndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["PAYROLLPERIOD_ENDDATE"]);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_PayrollPeriod", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
