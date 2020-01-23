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

public partial class Payroll_frm_CpyTaxExempt : System.Web.UI.Page
{
    #region References
    /// <summary>
    /// This region will consists of classes that were used throughout this screen
    /// </summary>
    SMHR_LOGININFO _obj_Logininfo = new SMHR_LOGININFO();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_TAX_TRANS _obj_smhr_tax_trans = new SMHR_TAX_TRANS();
    DataTable dt_Information = new DataTable();
    #endregion

    #region Page Load
    /// <summary>
    /// This Region Loads Business Unit which are under Logined User and Financial Periods of that organisation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //code for security privilage
                Session.Remove("WRITEFACILITY");

                SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();
                _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COPY PREVIOUS TAX SAVINGS");
                _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
                _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
                _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                //_obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("EMPLOYEE BANK DETAILS");
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
                    btn_Copy.Visible = false;
                    //   btn_Update.Visible = false;
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
                Loadcombos();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Loading Methods
    /// <summary>
    /// This region will consists of methods to load combos and clear combos
    /// </summary>
    protected void Loadcombos()
    {
        try
        {
            btn_Copy.Visible = false;
            _obj_Logininfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Logininfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            // Loading Business Units
            DataTable dt_BUDetails = BLL.get_Business_Units(_obj_Logininfo);
            if (dt_BUDetails.Rows.Count != 0)
            {
                rcmb_Businessunit.DataSource = dt_BUDetails;
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));

            // Loading Financial Period

            _obj_smhr_period.OPERATION = operation.Select;
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Information = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Information.Rows.Count != 0)
            {
                rcmb_OldFinperiod.DataSource = dt_Information;
                rcmb_OldFinperiod.DataValueField = "PERIOD_ID";
                rcmb_OldFinperiod.DataTextField = "PERIOD_NAME";
                rcmb_OldFinperiod.DataBind();
                rcmb_OldFinperiod.Items.Insert(0, new RadComboBoxItem("Select"));
                rcmb_OldFinperiod.SelectedIndex = 0;
            }
            else
                rcmb_OldFinperiod.Items.Insert(0, new RadComboBoxItem("Select"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    // for Clearing the controls
    protected void Clearcontrols()
    {
        try
        {
            rcmb_Businessunit.ClearSelection();
            rcmb_OldFinperiod.ClearSelection();
            rcmb_NewFinperiod.Items.Clear();
            rcmb_NewFinperiod.Items.Insert(0, new RadComboBoxItem("", ""));
            btn_Copy.Visible = false;
            //rcmb_NewFinperiod.SelectedItem.Text = null;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Selected Index Changed
    /// <summary>
    /// This region will consists of methods for on selection of any combo box 
    /// </summary>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex <= 0)
            {
                Clearcontrols();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// in this method we are loading the financial periods which are in future and which were not deleted
    /// </summary>
    protected void rcmb_OldFinperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex > 0)
            {
                btn_Copy.Visible = false;
                if (rcmb_OldFinperiod.SelectedIndex > 0)
                {
                    _obj_smhr_tax_trans.Mode = 5;
                    _obj_smhr_tax_trans.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_OldFinperiod.SelectedValue);
                    dt_Information = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                    rcmb_NewFinperiod.Items.Clear();
                    if (dt_Information.Rows.Count > 0)
                    {
                        rcmb_NewFinperiod.DataSource = dt_Information;
                        rcmb_NewFinperiod.DataTextField = "PERIOD_NAME";
                        rcmb_NewFinperiod.DataValueField = "PERIOD_ID";
                        rcmb_NewFinperiod.DataBind();
                        rcmb_NewFinperiod.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        //btn_Copy.Enabled = true;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Other Found Which is Greater than Selected Old Financial Period");
                        rcmb_NewFinperiod.Items.Insert(0, new RadComboBoxItem("", ""));
                        //btn_Copy.Enabled = false;
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Select OldFinancial Period");
                    rcmb_NewFinperiod.Items.Clear();
                    rcmb_NewFinperiod.Items.Insert(0, new RadComboBoxItem("", ""));
                }

            }
            else
            {
                BLL.ShowMessage(this, "Select Businessunit");
                Clearcontrols();
                return;
            }

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    /// <summary>
    /// this method will load the button if some thing is selected
    /// </summary>    
    protected void rcmb_NewFinperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_NewFinperiod.SelectedIndex > 0)
            {
                if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
                {
                    btn_Copy.Visible = false;
                    btn_Copy.Enabled = false;
                }
                else
                {
                    btn_Copy.Visible = true;
                    btn_Copy.Enabled = true;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Select Target Financial Period or New Financial Period");
                btn_Copy.Enabled = false;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Button Clicks

    protected void btn_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if ((rcmb_OldFinperiod.SelectedIndex > 0) && (rcmb_NewFinperiod.SelectedIndex > 0) && (rcmb_Businessunit.SelectedIndex > 0))
            {
                // checking for the existance of employee whose tax is already defined for the new financial period
                string Semp_count = "0";
                _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_NewFinperiod.SelectedValue);
                _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                _obj_smhr_tax_trans.Mode = 6;
                dt_Information = BLL.get_Tax_trans(_obj_smhr_tax_trans);

                if (dt_Information.Rows.Count > 0)
                {
                    // counting the number of employee who are under new financial period
                    Semp_count = Convert.ToString(dt_Information.Rows[0][0]);
                }
                // duping who ever there previously for that business unit and selected financial period
                _obj_smhr_tax_trans.Mode = 7;
                _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_OldFinperiod.SelectedValue);
                _obj_smhr_tax_trans.SMHR_EMPTAX_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_tax_trans.SMHR_EMPTAX_NEWPERIODID = Convert.ToInt32(rcmb_NewFinperiod.SelectedValue);
                _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                bool Status = BLL.set_Tax_Trans(_obj_smhr_tax_trans);
                if (Status)
                    BLL.ShowMessage(this, "Tax Information is Successfully Copied");
                else
                    BLL.ShowMessage(this, "There is no Tax Information For The Period:" + rcmb_OldFinperiod.SelectedItem.Text);
                Clearcontrols();
                // CHECKING FOR RECORDS EFFECTED
                //_obj_smhr_tax_trans.MODE = 9;
                //_obj_smhr_tax_trans.SMHR_EMPTAX_NEWPERIODID = Convert.ToInt32(rcmb_NewFinperiod.SelectedValue);
                //_obj_smhr_tax_trans.SMHR_EMPTAX_BU = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                //dt_Information = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                //int count = 0;
                //if (dt_Information.Rows.Count > 0)
                //{
                //    count = Convert.ToInt32(dt_Information.Rows[0][0].ToString());
                //    BLL.ShowMessage(this, "Number Of Records Inserted Are :" + count);
                //}
                BLL.ShowMessage(this, "Number Of Records Overwrited Are :" + Semp_count);



            }
            else
            {
                BLL.ShowMessage(this, "Select Correct Information");
                rcmb_NewFinperiod.SelectedIndex = 0;
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clearcontrols();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_CpyTaxExempt", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

}
