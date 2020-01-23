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
using Telerik.Web.UI;
using SMHR;

public partial class HR_frm_Emptax : System.Web.UI.Page
{

    #region Global References
    /// <summary>
    /// this region will consists of elements which were used throught out this class
    /// </summary>
    SMHR_LOGININFO _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();
    SMHR_TAX_TRANS _obj_smhr_tax_trans = new SMHR_TAX_TRANS();
    DataTable dt_Result = new DataTable();
    #endregion

    #region Page Load
    /// <summary>
    /// this region will consists of loading of combo boxes,
    /// which are parent (basic things) for doing any sort of transaction through this screen
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
            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("COUNTRY");
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
                rg_Taxinfo.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Save.Visible = false;
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
            LoadCombos();
        }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

    #region Loading Methods
    /// <summary>
    /// this region will consists of methods which will load and also clear the combo boxes
    /// </summary>
    private void LoadCombos()
    {
        try
        {
            // clearing business units, financial period
            rcmb_Businessunit.Items.Clear();
            rcmb_Financialperiod.Items.Clear();
            btn_Save.Visible = false;
            rg_Taxinfo.Visible = false;
            // loading business units
            _obj_SMHR_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_SMHR_LoginInfo.LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            dt_Result = BLL.get_Business_Units(_obj_SMHR_LoginInfo);
            if (dt_Result.Rows.Count != 0)
            {
                rcmb_Businessunit.DataSource = dt_Result;
                rcmb_Businessunit.DataValueField = "BUSINESSUNIT_ID";
                rcmb_Businessunit.DataTextField = "BUSINESSUNIT_CODE";
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
                //rcmb_Businessunit.SelectedIndex = 0;
            }
            else
            {
                rcmb_Businessunit.DataSource = dt_Result;
                rcmb_Businessunit.DataBind();
                rcmb_Businessunit.Items.Insert(0, new RadComboBoxItem("Select"));
            }

            // Loading Periods           
            _obj_smhr_period.OPERATION = operation.Select;
            _obj_SMHR_LoginInfo = new SMHR_LOGININFO();
            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            dt_Result = BLL.get_PeriodHeaderDetails(_obj_smhr_period);
            if (dt_Result.Rows.Count != 0)
            {
                rcmb_Financialperiod.DataSource = dt_Result;
                rcmb_Financialperiod.DataValueField = "PERIOD_ID";
                rcmb_Financialperiod.DataTextField = "PERIOD_NAME";
                rcmb_Financialperiod.DataBind();
                rcmb_Financialperiod.Items.Insert(0, new RadComboBoxItem("Select"));
            }
            else
            {
                rcmb_Financialperiod.DataSource = dt_Result;
                rcmb_Financialperiod.DataBind();
                rcmb_Financialperiod.Items.Insert(0, new RadComboBoxItem("Select"));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void ClearControls()
    {
        try
        {
            rcmb_Businessunit.ClearSelection();
            rcmb_Financialperiod.ClearSelection();
            rcmb_Taxelement.Items.Clear();
            rcmb_Taxelement.Items.Insert(0, new RadComboBoxItem("", ""));
            rg_Taxinfo.Visible = false;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    private void LoadGrid()
    {
        try
        {
            _obj_smhr_tax_trans.Mode = 12;
            _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
            _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
            _obj_smhr_tax_trans.SMHR_EMPTAX_ID = Convert.ToInt32(rcmb_Taxelement.SelectedValue);
            dt_Result = BLL.get_Tax_trans(_obj_smhr_tax_trans);
            rg_Taxinfo.DataSource = dt_Result;
            rg_Taxinfo.DataBind();
            for (int rows = 0; rows < rg_Taxinfo.Items.Count; rows++)
            {
                Label lbl_emp_id = rg_Taxinfo.Items[rows].FindControl("lbl_Empid") as Label;
                _obj_smhr_tax_trans.SMHR_EMPTAX_EMPID = Convert.ToInt32(lbl_emp_id.Text);
                _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                _obj_smhr_tax_trans.SMHR_EMPTAX_TAXID = Convert.ToInt32(rcmb_Taxelement.SelectedValue);
                _obj_smhr_tax_trans.Mode = 14;
                dt_Result = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                RadNumericTextBox rtxt_amount = rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox;
                if (dt_Result.Rows.Count > 0)
                    rtxt_amount.Text = dt_Result.Rows[0][0].ToString();
                else
                    rtxt_amount.Text = "0.0";

            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #endregion

    #region Selection Changed Methods
    /// <summary>
    /// this region will handle all the selection changed methods 
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Businessunit_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex <= 0)
            {
                rcmb_Financialperiod.ClearSelection();
                rcmb_Taxelement.Items.Clear();
                rcmb_Taxelement.Items.Insert(0, new RadComboBoxItem("", ""));
                rg_Taxinfo.Visible = false;
                btn_Save.Visible = false;
            }
            else
            {
                rcmb_Financialperiod.ClearSelection();
                rcmb_Taxelement.Items.Clear();
                rcmb_Taxelement.Items.Insert(0, new RadComboBoxItem("", ""));
                rg_Taxinfo.Visible = false;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Financialperiod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Businessunit.SelectedIndex > 0)
            {
                if (rcmb_Financialperiod.SelectedIndex > 0)
                {
                    // loading tax elements
                    rcmb_Taxelement.Items.Clear();
                    _obj_smhr_tax_trans.Mode = 11;
                    _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                    dt_Result = BLL.get_Tax_trans(_obj_smhr_tax_trans);
                    if (dt_Result.Rows.Count > 0)
                    {
                        rcmb_Taxelement.DataSource = dt_Result;
                        rcmb_Taxelement.DataTextField = "SMHR_TAX_NAME";
                        rcmb_Taxelement.DataValueField = "SMHR_TAX_ID";
                        rcmb_Taxelement.DataBind();
                        rcmb_Taxelement.Items.Insert(0, new RadComboBoxItem("Select", "0"));
                        rcmb_Taxelement.ClearSelection();
                        rg_Taxinfo.Visible = false;
                        btn_Save.Visible = false;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "No Tax Elements Were Defined For the Selected Businessunit");
                        btn_Save.Visible = false;
                        rg_Taxinfo.Visible = false;
                        return;
                    }
                }
                else
                {
                    rcmb_Financialperiod.ClearSelection();
                    rcmb_Taxelement.Items.Clear();
                    rcmb_Taxelement.Items.Insert(0, new RadComboBoxItem("", ""));
                    rg_Taxinfo.Visible = false;
                    btn_Save.Visible = false;
                    BLL.ShowMessage(this, "Select Financial Period");
                }
            }
            else
            {
                rcmb_Financialperiod.Items.Clear();
                rcmb_Taxelement.Items.Clear();
                rg_Taxinfo.Visible = false;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void rcmb_Taxelement_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcmb_Taxelement.SelectedIndex > 0)
            {
                //loading the grid
                rg_Taxinfo.DataSource = null;
                rg_Taxinfo.DataBind();
                LoadGrid();
                btn_Save.Visible = true;
                rg_Taxinfo.Visible = true;
            }
            else
            {
                rg_Taxinfo.Visible = false;
                btn_Save.Visible = false;
                if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_Financialperiod.SelectedIndex > 0))
                    BLL.ShowMessage(this, "Select Tax Element");
                else
                    BLL.ShowMessage(this, "Select Proper Information");
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_selectall_checkedchanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_all = (CheckBox)sender;
            if (rg_Taxinfo.Items.Count > 0)
            {
                if (chk_all.Checked)
                {
                    for (int row = 0; row < rg_Taxinfo.Items.Count; row++)
                    {
                        CheckBox chkrow = rg_Taxinfo.Items[row].FindControl("chk_Select") as CheckBox;
                        chkrow.Checked = true;
                    }
                }
                else
                {
                    for (int row = 0; row < rg_Taxinfo.Items.Count; row++)
                    {
                        CheckBox chkrow = rg_Taxinfo.Items[row].FindControl("chk_Select") as CheckBox;
                        chkrow.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    #endregion

    #region Button Clicks
    /// <summary>
    /// this region will consists of methods that will perform some action when any button is pressed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            bool rowchecked = false;
            if ((rcmb_Businessunit.SelectedIndex > 0) && (rcmb_Financialperiod.SelectedIndex > 0) && (rcmb_Taxelement.SelectedIndex > 0))
            {
                for (int rows = 0; rows < rg_Taxinfo.Items.Count; rows++)
                {
                    CheckBox chk_selectedrow = rg_Taxinfo.Items[rows].FindControl("chk_Select") as CheckBox;
                    if (chk_selectedrow.Checked)
                    {
                        rowchecked = true;
                        if (((rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox).Text == "") || (Convert.ToDouble((rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox).Text) < 0))
                        {
                            BLL.ShowMessage(this, "Enter Amount Greater Than Zero And Less than Maximum Amount in the Row :" + rows);
                            ((rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox).Text) = "";
                            return;
                        }
                        if (Convert.ToDouble((rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox).Text) > Convert.ToDouble((rg_Taxinfo.Items[rows].FindControl("lbl_Maxlimit") as Label).Text))
                        {
                            BLL.ShowMessage(this, "Amount Should be Less than Maximum Limit in The Row: " + rows);
                            return;
                        }
                        // deleting employee for that tax id with the period and amount
                        Label lbl_emp_id = rg_Taxinfo.Items[rows].FindControl("lbl_Empid") as Label;
                        _obj_smhr_tax_trans.SMHR_EMPTAX_EMPID = Convert.ToInt32(lbl_emp_id.Text);
                        _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_ID = Convert.ToInt32(rcmb_Taxelement.SelectedValue);
                        _obj_smhr_tax_trans.Mode = 13;
                        BLL.set_Tax_Trans(_obj_smhr_tax_trans);
                        // inserting employee with taxid and correspondin amounts
                        _obj_smhr_tax_trans.Mode = 2;
                        _obj_smhr_tax_trans.SMHR_EMPTAX_EMPID = Convert.ToInt32(lbl_emp_id.Text);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_TAXID = Convert.ToInt32(rcmb_Taxelement.SelectedValue);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_PERIOD_ID = Convert.ToInt32(rcmb_Financialperiod.SelectedValue);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_AMOUNT = Convert.ToDouble((rg_Taxinfo.Items[rows].FindControl("rtxt_Amount") as RadNumericTextBox).Text);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_AMT = Convert.ToDouble((rg_Taxinfo.Items[rows].FindControl("lbl_Maxlimit") as Label).Text);
                        _obj_smhr_tax_trans.BUID = Convert.ToInt32(rcmb_Businessunit.SelectedValue);
                        _obj_smhr_tax_trans.SMHR_EMPTAX_CREATEDBY = Convert.ToInt32(Convert.ToString(Session["EMP_ID"]));
                        _obj_smhr_tax_trans.SMHR_EMPTAX_CREATEDDATE = DateTime.Now;
                        bool status = BLL.set_Tax_Trans(_obj_smhr_tax_trans);

                    }
                }
                if (!rowchecked)
                    BLL.ShowMessage(this, "Select Atleast One Employee");
                else
                {
                    BLL.ShowMessage(this, "Tax Information Is Saved Successfully");
                    ClearControls();
                }

            }
            else
            {
                BLL.ShowMessage(this, "Select Proper Information");
                return;
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frm_Emptax", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    #endregion

}
