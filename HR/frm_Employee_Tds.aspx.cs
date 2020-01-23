using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using Telerik.Web.UI;
using System.Data;

public partial class HR_Employee_Tds : System.Web.UI.Page
{
    SMHR_EMP_TDS _obj_smhr_EMP_TDS;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_PERIOD obj_smhr_Period;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                Session.Remove("WRITEFACILITY");
                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE PAST GROSS & TDS INFO");
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
                    rg_Tds.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    foreach (GridColumn col in rg_Tds.Columns)
                    {
                        if (col.UniqueName == "ColEdit")
                        {
                            col.Visible = false;
                        }
                    }
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
                loadGrid();
                rg_Tds.DataBind();
                LoadBusinessUnit_Tds();
                loadPeriod();
                //rntxt_Tds_Amount.Value = 0.00;


            }

            //loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }



    #region loadDropdown

    private void LoadBusinessUnit_Tds()
    {
        try
        {
            _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
            _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            rcmb_Tds_Buid.DataSource = BLL.get_BusinessUnit(_obj_smhr_businessunit);
            rcmb_Tds_Buid.DataValueField = "BUSINESSUNIT_ID";
            rcmb_Tds_Buid.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_Tds_Buid.DataBind();
            rcmb_Tds_Buid.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            rcmb_Tds_EmpId.Items.Clear();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadEmployee_Tds()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.OPERATION = operation.Check;
            string str_BusinessUnit_ID = Convert.ToString(rcmb_Tds_Buid.SelectedValue).ToUpper();
            //obj_smhr_logininfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
            //DataTable dt_getBUSINESS_ID = BLL.get_Sup_BusinessUnit(obj_smhr_logininfo);
            //string str_BUSINESSUNIT_ID = Convert.ToString(dt_getBUSINESS_ID.Rows[0][0]);

            _obj_SMHR_LoginInfo.OPERATION = operation.Check;
            _obj_SMHR_LoginInfo.BUID = Convert.ToInt32(str_BusinessUnit_ID);
            DataTable dt_getEMP = BLL.get_Sup_BusinessUnit(_obj_SMHR_LoginInfo);

            rcmb_Tds_EmpId.Items.Clear();
            rcmb_Tds_EmpId.DataSource = dt_getEMP;
            rcmb_Tds_EmpId.DataTextField = "EMP_NAME";
            rcmb_Tds_EmpId.DataValueField = "EMP_ID";
            rcmb_Tds_EmpId.DataBind();
            rcmb_Tds_EmpId.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Index_Changed

    protected void rcmb_Tds_Buid_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            LoadEmployee_Tds();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region LoadGrid

    private void LoadGrid_Tds()
    {
        try
        {
            _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
            _obj_smhr_EMP_TDS.OPERATION = operation.Select;
            _obj_smhr_EMP_TDS.TDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            rg_Tds.DataSource = BLL.get_EMP_TDS(_obj_smhr_EMP_TDS);
            rg_Tds.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }
    #endregion


    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rmp_Main.SelectedIndex = 1;
            LoadBusinessUnit_Tds();
            loadPeriod();
            rcmb_Tds_Buid.Enabled = true;
            rcmb_Tds_EmpId.Enabled = true;
            rcmb_Period.Enabled = true;

            rntxt_Prev_Gross_Amount.Text = null;
            rntxt_prev_tds_amount.Text = null;
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            rcmb_Tds_EmpId.Enabled = true;
            rcmb_Period.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
            return;
        }
    }

    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                btn_Update.Visible = false;

            }

            else
            {
                btn_Update.Visible = true;
            }
            rmp_Main.SelectedIndex = 1;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            LoadBusinessUnit_Tds();

            rcmb_Tds_EmpId.Enabled = false;
            rcmb_Tds_Buid.Enabled = false;
            rcmb_Period.Enabled = false;
            _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
            _obj_smhr_EMP_TDS.OPERATION = operation.Validate;
            _obj_smhr_EMP_TDS.EMP_TDS_ID = Convert.ToInt32(e.CommandArgument);
            Session["EMP_TDS_ID"] = Convert.ToString(e.CommandArgument);
            DataTable dt = BLL.get_EMP_TDS(_obj_smhr_EMP_TDS);
            rcmb_Tds_Buid.SelectedIndex = rcmb_Tds_Buid.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["BUSINESSUNIT_ID"]));

            LoadEmployee_Tds();

            rcmb_Tds_EmpId.SelectedIndex = rcmb_Tds_EmpId.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_ID"]));
            rntxt_Prev_Gross_Amount.Text = Convert.ToString(dt.Rows[0]["EMP_TDS_PREV_GROSS_AMOUNT"]);
            rntxt_prev_tds_amount.Text = Convert.ToString(dt.Rows[0]["EMP_TDS_PREV_TDS_AMOUNT"]);
            rcmb_Period.SelectedIndex = rcmb_Period.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["EMP_TDS_PERIOD_ID"]));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();

            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    // _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
                    _obj_smhr_EMP_TDS.OPERATION = operation.Insert;
                    _obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcmb_Tds_Buid.SelectedValue);
                    _obj_smhr_EMP_TDS.TDS_EMPID = Convert.ToInt32(rcmb_Tds_EmpId.SelectedValue);
                    if (rntxt_Prev_Gross_Amount.Text == "")
                    {
                        _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = 0.00;

                    }
                    else
                    {
                        _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = Convert.ToDouble(rntxt_Prev_Gross_Amount.Text);
                    }
                    if (rntxt_prev_tds_amount.Text == "")
                    {
                        _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = 0.00;
                    }
                    else
                    {
                        _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = Convert.ToDouble(rntxt_prev_tds_amount.Text);
                    }
                    _obj_smhr_EMP_TDS.TDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_EMP_TDS.TDS_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
                    _obj_smhr_EMP_TDS.OPERATION = operation.Check;
                    if (Convert.ToString(BLL.get_EMP_TDS(_obj_smhr_EMP_TDS).Rows[0]["Count"]) != "0")
                    {
                        BLL.ShowMessage(this, "Business unit with this Combination Already Exists!");
                        return;
                    }
                    _obj_smhr_EMP_TDS.OPERATION = operation.Insert;
                    if (BLL.set_EMP_TDS(_obj_smhr_EMP_TDS))
                    {

                        BLL.ShowMessage(this, "Information Saved Successfully");

                    }

                    break;

                case "BTN_UPDATE":
                    _obj_smhr_EMP_TDS.OPERATION = operation.Update;
                    if (rntxt_Prev_Gross_Amount.Text == "")
                    {
                        _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = 0.00;
                    }
                    else
                    {
                        _obj_smhr_EMP_TDS.PREV_GROSS_AMOUNT = Convert.ToDouble(rntxt_Prev_Gross_Amount.Text);
                    }
                    if (rntxt_prev_tds_amount.Text == "")
                    {
                        _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = 0.00;
                    }
                    else
                    {
                        _obj_smhr_EMP_TDS.PREV_TDS_AMOUNT = Convert.ToDouble(rntxt_prev_tds_amount.Text);
                    }
                    _obj_smhr_EMP_TDS.TDS_EMPID = Convert.ToInt32(rcmb_Tds_EmpId.SelectedValue);
                    _obj_smhr_EMP_TDS.TDS_BUID = Convert.ToInt32(rcmb_Tds_Buid.SelectedValue);
                    _obj_smhr_EMP_TDS.TDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_EMP_TDS.TDS_PERIOD = Convert.ToInt32(rcmb_Period.SelectedValue);
                    _obj_smhr_EMP_TDS.EMP_TDS_ID = Convert.ToInt32(Session["EMP_TDS_ID"]);
                    if (BLL.set_EMP_TDS(_obj_smhr_EMP_TDS))
                    {

                        BLL.ShowMessage(this, "Information Updated Successfully");

                    }
                    break;
                default:
                    break;
            }
            rmp_Main.SelectedIndex = 0;
            loadGrid();
            rg_Tds.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            clearControls();
            rmp_Main.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region loadGrid()
    public void loadGrid()
    {
        try
        {
            _obj_smhr_EMP_TDS = new SMHR_EMP_TDS();
            _obj_smhr_EMP_TDS.OPERATION = operation.Select;
            _obj_smhr_EMP_TDS.TDS_ORGID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Grid = BLL.get_EMP_TDS(_obj_smhr_EMP_TDS);
            rg_Tds.DataSource = dt_Grid;

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    public void clearControls()
    {
        try
        {
            rcmb_Tds_Buid.SelectedIndex = 0;
            rcmb_Tds_EmpId.SelectedIndex = 0;
            rcmb_Period.SelectedIndex = 0;
            rntxt_Prev_Gross_Amount.Text = null;
            rntxt_prev_tds_amount.Text = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    public void loadPeriod()
    {
        try
        {
            obj_smhr_Period = new SMHR_PERIOD();
            obj_smhr_Period.OPERATION = operation.Select;
            obj_smhr_Period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_PeriodHeaderDetails(obj_smhr_Period);
            rcmb_Period.DataSource = dt_Details;
            rcmb_Period.DataValueField = "PERIOD_ID";
            rcmb_Period.DataTextField = "PERIOD_NAME";
            rcmb_Period.DataBind();
            rcmb_Period.Items.Insert(0, new RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rg_Tds_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            loadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Employee_Tds", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}
