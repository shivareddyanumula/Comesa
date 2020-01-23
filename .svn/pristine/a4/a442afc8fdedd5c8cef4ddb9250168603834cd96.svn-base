using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SMHR;
using Telerik.Web.UI;
using System.Globalization;

public partial class Masters_frmCurrencyConversion : System.Web.UI.Page
{
    SMHR_LOGININFO _obj_SMHR_LoginInfo;
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_CURRENCY _obj_smhr_Currency;
    SMHR_CURRENCY_CONVERSION _obj_Curr_Conv;
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
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Currency Conversion");//COUNTRY");
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
                    Rg_CurrConv.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
                Rm_CurrConv.SelectedIndex = 0;
                LoadBusinessUnit();
                LoadToCurrency();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadToCurrency()
    {
        try
        {
            rcmb_ToCurrency.Items.Clear();
            _obj_smhr_Currency = new SMHR_CURRENCY();
            _obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Currency(_obj_smhr_Currency);
            rcmb_ToCurrency.DataSource = dt_Details;
            rcmb_ToCurrency.DataTextField = "CURR_CODE";
            rcmb_ToCurrency.DataValueField = "CURR_ID";
            rcmb_ToCurrency.DataBind();
            rcmb_ToCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadBusinessUnit()
    {
        try
        {
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            rcmb_BusinessUnit.Items.Clear();
            rcmb_BusinessUnit.DataSource = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_BusinessUnit.SelectedIndex > 0)
            {
                _obj_smhr_businessunit = new SMHR_BUSINESSUNIT();
                _obj_smhr_businessunit.OPERATION = operation.EMPTY1;
                _obj_smhr_businessunit.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_businessunit.BUSINESSUNIT_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
                DataTable dt = BLL.get_BusinessUnit(_obj_smhr_businessunit);
                rcmb_FromCurrency.DataSource = dt;
                rcmb_FromCurrency.DataTextField = "CURR_CODE";
                rcmb_FromCurrency.DataValueField = "BUSINESSUNIT_CURRENCY_ID";
                rcmb_FromCurrency.DataBind();
                rcmb_FromCurrency.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_FromCurrency.ClearSelection();
                rcmb_FromCurrency.Items.Clear();
                rcmb_FromCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            _obj_Curr_Conv = new SMHR_CURRENCY_CONVERSION();
            _obj_Curr_Conv.CURRENCY_CONVERSION_BU = Convert.ToInt32(rcmb_BusinessUnit.SelectedItem.Value);
            _obj_Curr_Conv.CURRENCY_CONVERSION_FROMCURR = Convert.ToInt32(rcmb_FromCurrency.SelectedItem.Value);
            _obj_Curr_Conv.CURRENCY_CONVERSION_TOCURR = Convert.ToInt32(rcmb_ToCurrency.SelectedItem.Value);
            _obj_Curr_Conv.CURRENCY_CONVERSION_RATE = Convert.ToDecimal(rnt_ConvRate.Value);
            //_obj_Curr_Conv.CREATEDBY = Convert.ToInt32(Session["ORG_ID"]);
            //_obj_Curr_Conv.LASTMDFBY = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Curr_Conv.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
            _obj_Curr_Conv.LASTMDFBY = Convert.ToInt32(Session["USER_ID"]);
            if (Convert.ToInt32(rcmb_FromCurrency.SelectedValue) == Convert.ToInt32(rcmb_ToCurrency.SelectedValue))
            {
                BLL.ShowMessage(this, "From Currency And To Currency Can Not Be The Same");
                return;
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SAVE":
                    _obj_Curr_Conv.MODE = 4;
                    if (Convert.ToInt32(BLL.get_Currency_Conversion(_obj_Curr_Conv).Rows[0]["COUNT"]) != 0)
                    {
                        BLL.ShowMessage(this, "Conversion For This Combination Already Exists.");
                        return;
                    }
                    _obj_Curr_Conv.MODE = 1;
                    if (BLL.set_Currency_Conversion(_obj_Curr_Conv))
                        BLL.ShowMessage(this, "Information Saved Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Saved");
                    break;

                case "BTN_UPDATE":
                    _obj_Curr_Conv.MODE = 4;
                    if (Convert.ToInt32(BLL.get_Currency_Conversion(_obj_Curr_Conv).Rows[0]["COUNT"]) != 1)
                    {
                        BLL.ShowMessage(this, "Conversion For This Combination Already Exists.");
                        return;
                    }
                    _obj_Curr_Conv.CURRENCY_CONVERSION_ID = Convert.ToInt32(lbl_currID.Text);
                    _obj_Curr_Conv.MODE = 2;
                    if (BLL.set_Currency_Conversion(_obj_Curr_Conv))
                        BLL.ShowMessage(this, "Information Updated Successfully");
                    else
                        BLL.ShowMessage(this, "Information Not Updated");
                    break;
            }
            Rm_CurrConv.SelectedIndex = 0;
            LoadGrid();
            Rg_CurrConv.DataBind();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_Curr_Conv = new SMHR_CURRENCY_CONVERSION();
            _obj_Curr_Conv.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Curr_Conv.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_Curr_Conv.MODE = 3;
            Rg_CurrConv.DataSource = BLL.get_Currency_Conversion(_obj_Curr_Conv);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
                    
                
            ClearControls();
            btn_Save.Visible = true;
            btn_Update.Visible = false;
            Rm_CurrConv.SelectedIndex = 1;
            rcmb_BusinessUnit.Enabled = true;
            rcmb_FromCurrency.Enabled = true;
            rcmb_ToCurrency.Enabled = true;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_FromCurrency.Items.Clear();
            rcmb_ToCurrency.SelectedIndex = 0;
            rnt_ConvRate.Value = 0.0;
            lbl_currID.Text = string.Empty;
            rcmb_FromCurrency.ClearSelection();
            rcmb_FromCurrency.Items.Clear();
            rcmb_FromCurrency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_Edit_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Rm_CurrConv.SelectedIndex = 1;
            rcmb_BusinessUnit.Enabled = false;
            rcmb_FromCurrency.Enabled = false;
            rcmb_ToCurrency.Enabled = false;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
            _obj_Curr_Conv = new SMHR_CURRENCY_CONVERSION();
            _obj_Curr_Conv.CURRENCY_CONVERSION_ID = Convert.ToInt32(e.CommandArgument);
            lbl_currID.Text = Convert.ToString(e.CommandArgument);
            _obj_Curr_Conv.MODE = 5;
            DataTable dt = BLL.get_Currency_Conversion(_obj_Curr_Conv);
            rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["CURRENCY_CONVERSION_BU"]));
            rcmb_ToCurrency.SelectedIndex = rcmb_ToCurrency.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["CURRENCY_CONVERSION_TOCURR"]));
            rcmb_BusinessUnit_SelectedIndexChanged(null, null);
            rcmb_FromCurrency.SelectedIndex = rcmb_FromCurrency.Items.FindItemIndexByValue(Convert.ToString(dt.Rows[0]["CURRENCY_CONVERSION_FROMCURR"]));
            rnt_ConvRate.Value = Convert.ToDouble(dt.Rows[0]["CURRENCY_CONVERSION_RATE"]);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_CurrConv_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            Rm_CurrConv.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmCurrencyConversion", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    
}
