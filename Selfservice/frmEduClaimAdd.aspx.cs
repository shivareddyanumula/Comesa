﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Selfservice_frmEduClaimAdd : System.Web.UI.Page
{
    SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
    SMHR_BUSINESSUNIT _obj_smhr_businessunit;
    SMHR_LOGININFO _obj_smhr_logininfo;
    SMHR_LOGINTYPE _obj_Smhr_LoginInfo;
    SMHR_CURRENCY _obj_smhr_Currency;

    static int allowanceID = 0;
    static int eduClmID = 0;
    static int val = 0;

    static int buID = 0;
    static int grdID = 0;
    static int deptID = 0;
    static int chkCnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //code for security privilage
            Session.Remove("WRITEFACILITY");

            SMHR_LOGININFO _obj_Smhr_LoginInfo = new SMHR_LOGININFO();

            _obj_Smhr_LoginInfo.OPERATION = operation.Empty1;
            _obj_Smhr_LoginInfo.LOGIN_USERNAME = Convert.ToString(Session["USERNAME"]).Trim();
            _obj_Smhr_LoginInfo.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = "Educational Claim";

            DataTable dtformdtls = BLL.get_LoginInfo(_obj_Smhr_LoginInfo);

            if (dtformdtls.Rows.Count != 0)
            {
                if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == true))
                    Session["WRITEFACILITY"] = 1;//WHICH MEANS READ AND WRITE
                else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == true) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    Session["WRITEFACILITY"] = 2;//WHICH MEANS READ NO WRITE
                else if ((Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_READ"]) == false) && (Convert.ToBoolean(dtformdtls.Rows[0]["TYPSEC_WRITE"]) == false))
                    Session["WRITEFACILITY"] = 3;//WHICH MEANS NO READ AND NO WRITE
            }

            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 2)
            {
                rgEmpDepndnts.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                btn_Submit.Visible = false;
            }
            if (Convert.ToInt32(Session["WRITEFACILITY"]) == 3)
            {
                smhr_UNAUTHORIZED _obj_smhr_unauthorized = new smhr_UNAUTHORIZED();

                _obj_smhr_unauthorized.UNAUTHORIZED_USERID = Convert.ToInt32(Session["USER_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_FORMID = Convert.ToInt32(ViewState["FORMS_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_MODULEID = Convert.ToInt32(ViewState["MODULE_ID"]);
                _obj_smhr_unauthorized.UNAUTHORIZED_ACCESSDATE = Convert.ToDateTime(DateTime.Now.ToString());

                SMHR.BLL.UnAuthorized_Log(_obj_smhr_unauthorized);
                Response.Redirect("~/frm_UnAuthorized.aspx", false);
            }
            //code for security privilage

            LoadEmployees();
            LoadFinancialPeriod();

            if (rcmb_Employee.SelectedIndex == 0)
            {
                LoadBenGrid(0, 0);
                rgEmpDepndnts.DataBind();
            }

            rcmb_Employee.SelectedIndex = 0;

            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
            {
                if (Convert.ToString(Request.QueryString["type"]) == "self")
                {
                    rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
                    rcmb_Employee_SelectedIndexChanged(null, null);
                    rcmb_Employee.Enabled = false;
                }
                else
                {
                    rcmb_Employee.SelectedIndex = 0;
                    rcmb_Employee.Enabled = true;
                }
            }
            else
            {
                rcmb_Employee.SelectedIndex = 0;
                rcmb_Employee.Enabled = true;
            }

            if (Session["mbMsg"] != null && Convert.ToString(Session["mbMsg"]) == "ss")
            {
                BLL.ShowMessage(this, "Information Saved Successfully for selected record(s)");
                Session["mbMsg"] = null;
            }
        }
    }

    /// <summary>
    /// To Load all Beneficiaries w.r.t Emp ID
    /// </summary>
    /// <param name="empID"></param>
    protected void LoadBenGrid(int empID, int prdID)
    {
        try
        {
            DataTable dt = new DataTable();

            if (empID > -1)
            {
                dt = BLL.GetFamilyDataEducational(empID, prdID);
                rgEmpDepndnts.Visible = true;
            }
            else
                rgEmpDepndnts.Visible = false;

            rgEmpDepndnts.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load all the Employee's Data
    /// </summary>
    protected void LoadEmployees()
    {
        try
        {
            rcmb_Employee.Items.Clear();
            rcmb_Employee.ClearSelection();
            rcmb_Employee.AppendDataBoundItems = true;
            rcmb_Employee.Enabled = true;
            //// rcmb_Employee.Text = radMedicalServiceProvider.Text = rtbOtherExpndName.Text = string.Empty;

            DataTable dtEMPData = BLL.get_EmployeeBySearchString(Convert.ToInt32(Session["ORG_ID"]), string.Empty);

            if (dtEMPData.Rows.Count > 0)
            {
                rcmb_Employee.DataSource = dtEMPData;
                rcmb_Employee.DataTextField = "EMPNAME";
                rcmb_Employee.DataValueField = "EMP_ID";
                rcmb_Employee.DataBind();
            }
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load all the Financial Period's Data
    /// </summary>
    protected void LoadFinancialPeriod()
    {
        try
        {
            rcbFinPeriod.Items.Clear();
            rcbFinPeriod.ClearSelection();
            rcbFinPeriod.Text = string.Empty;
            rcbFinPeriod.AppendDataBoundItems = true;
            rcbFinPeriod.Enabled = true;

            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtFinPrd = BLL.GET_FIN_PERIOD(_obj_smhr_period);

            if (dtFinPrd.Rows.Count > 0)
            {
                rcbFinPeriod.DataSource = dtFinPrd;
                rcbFinPeriod.DataTextField = "PERIOD_NAME";
                rcbFinPeriod.DataValueField = "PERIOD_ID";
                rcbFinPeriod.DataBind();
            }
            rcbFinPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load all the Grid Control's Data
    /// </summary>
    protected void LoadGridControls()
    {
        try
        {
            if (rgEmpDepndnts.Items.Count > 0)
            {
                RadComboBox rcmb_Currency;

                SMHR_CURRENCY _obj_smhr_Currency = new SMHR_CURRENCY();
                _obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                DataTable dtCurr = BLL.get_Currency(_obj_smhr_Currency);

                for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
                {
                    rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;

                    if (dtCurr.Rows.Count > 0)
                    {
                        rcmb_Currency.DataSource = dtCurr;
                        rcmb_Currency.DataTextField = "CURR_CODE";
                        rcmb_Currency.DataValueField = "CURR_ID";
                        rcmb_Currency.DataBind();
                    }
                    rcmb_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Need data source for Rad grid
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rgEmpDepndnts_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0 && rcbFinPeriod.SelectedIndex > 0)
            {
                LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue), Convert.ToInt32(rcbFinPeriod.SelectedValue));
                rgEmpDepndnts.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On select index changed event for an Employee
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            grdID = 0;
            ClearControls();

            if (rdpt_ReceiptDate.SelectedDate == null)
            {
                rdpt_ReceiptDate.MinDate = new DateTime((DateTime.Now.AddMonths(-1)).Year, (DateTime.Now.AddMonths(-1)).Month, 26);
                rdpt_ReceiptDate.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                if (rdpt_ReceiptDate.MaxDate > DateTime.Now.Date)
                    rdpt_ReceiptDate.MaxDate = DateTime.Now;
            }

            LoadFinancialPeriod();

            if (rcmb_Employee.SelectedIndex > 0)
            {
                if (rcbFinPeriod.SelectedIndex == 0)
                    LoadBenGrid(0, 0);
                else
                    LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue), Convert.ToInt32(rcbFinPeriod.SelectedValue));

                rgEmpDepndnts.DataBind();

                LoadGridControls();

                DataTable dtEmp = BLL.GetFamilyDataMedical(Convert.ToInt32(rcmb_Employee.SelectedValue));

                if (dtEmp.Rows.Count > 0)
                {
                    rtbBusinessUnit.Text = Convert.ToString(dtEmp.Rows[0]["BUS_CODE"]);
                    rtbDepartment.Text = Convert.ToString(dtEmp.Rows[0]["DEPT_NAME"]);
                    rtbScale.Text = Convert.ToString(dtEmp.Rows[0]["GRADE"]);

                    buID = Convert.ToInt32(dtEmp.Rows[0]["BU_ID"]);
                    grdID = Convert.ToInt32(dtEmp.Rows[0]["EMP_GRADE"]);
                    deptID = Convert.ToInt32(dtEmp.Rows[0]["DEP_ID"]);
                }
            }
            else
            {
                rtbBusinessUnit.Text = rtbDepartment.Text = rtbScale.Text = string.Empty;
                buID = grdID = deptID = 0;

                LoadBenGrid(0, 0);
                rgEmpDepndnts.DataBind();
            }
            chkCnt = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On select index changed event for Financial Period
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcbFinPeriod_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbFinPeriod.SelectedIndex > 0)
            {
                SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

                _obj_smhr_period.OPERATION = operation.Select;
                _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_smhr_period.PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);

                DataTable dtPrdDtls = BLL.get_PeriodHeaderDetails(_obj_smhr_period);

                if (dtPrdDtls.Rows.Count > 0)
                {
                    rdpt_ReceiptDate.Clear();

                    rdpt_ReceiptDate.MinDate = Convert.ToDateTime(dtPrdDtls.Rows[0]["PERIOD_STARTDATE"]);
                    rdpt_ReceiptDate.MaxDate = Convert.ToDateTime(dtPrdDtls.Rows[0]["PERIOD_ENDDATE"]);

                    if (rdpt_ReceiptDate.MaxDate > DateTime.Now.Date)
                        rdpt_ReceiptDate.MaxDate = DateTime.Now;
                }

                if (rcmb_Employee.SelectedIndex == 0)
                    LoadBenGrid(0, 0);
                else
                    LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue), Convert.ToInt32(rcbFinPeriod.SelectedValue));

                DataTable dtEmp = BLL.GetFamilyDataEducational(Convert.ToInt32(rcmb_Employee.SelectedValue), Convert.ToInt32(rcbFinPeriod.SelectedValue));

                if (dtEmp.Rows.Count > 0)
                    rntbEduAllScale.Text = Convert.ToString(dtEmp.Rows[0]["ALW_ELGB"]);
            }
            else
            {
                rntbEduAllScale.Text = string.Empty;
                LoadBenGrid(0, 0);
            }

            rgEmpDepndnts.DataBind();
            LoadGridControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Check changed event for radgrid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadNumericTextBox rntbCurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule75;
            RadNumericTextBox radAmount;
            RadComboBox rcmb_Currency;
            RadNumericTextBox rntbRecNo;
            Button btnClaim;
            CheckBox chk;
            CheckBox chk_rule;

            int checkCnt = 0;
            decimal amnt = 0;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;

                if (chk.Checked == true && btnClaim.Enabled == true)
                    checkCnt++;
            }

            if (checkCnt == 0)
                chkCnt = 0;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;
                chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;

                if (chk.Checked)
                {
                    if (chkCnt > 0 && btnClaim.Enabled == false)
                    {
                        chk.Checked = false;
                        //BLL.ShowMessage(this, "You are allowed for only one record to enter all the details at once..!");
                        BLL.ShowMessage(this, "Please complete the process for checked Employee");
                        return;
                    }
                    else
                    {
                        rcmb_Currency.Enabled = radAmount.Enabled = rntbRecNo.Enabled = btnClaim.Enabled = chk_rule.Enabled = true;
                        chkCnt++;
                    }
                }
                else
                {
                    if (rcmb_Currency.Enabled == true && radAmount.Enabled == true && rntbRecNo.Enabled == true && btnClaim.Enabled == true)
                        chkCnt--;

                    if (rcmb_Currency.SelectedIndex == 0 && rnt_maxcurramt.Text == string.Empty && radAmount.Text == string.Empty &&
                           rntbCurrencyAmt.Text == string.Empty && rntbRule75.Text == string.Empty)
                    {
                        rcmb_Currency.SelectedIndex = 0;
                        rnt_maxcurramt.Text = radAmount.Text = rntbCurrencyAmt.Text = rntbRule75.Text = rntbRecNo.Text = string.Empty;
                        rcmb_Currency.Enabled = radAmount.Enabled = rntbRecNo.Enabled = btnClaim.Enabled = chk_rule.Enabled = false;
                        chk_rule.Checked = false;
                    }
                    else
                    {
                        if ((rcmb_Currency.SelectedIndex == 0 || rnt_maxcurramt.Text == string.Empty || radAmount.Text == string.Empty ||
                           rntbCurrencyAmt.Text == string.Empty || rntbRule75.Text == string.Empty) && (btnClaim.Enabled == true))
                        {
                            rcmb_Currency.SelectedIndex = 0;
                            rnt_maxcurramt.Text = radAmount.Text = rntbCurrencyAmt.Text = rntbRule75.Text = rntbRecNo.Text = string.Empty;
                            rcmb_Currency.Enabled = radAmount.Enabled = rntbRecNo.Enabled = btnClaim.Enabled = chk_rule.Enabled = false;
                            chk_rule.Checked = false;
                        }
                        else
                            rcmb_Currency.Enabled = radAmount.Enabled = rntbRecNo.Enabled = btnClaim.Enabled = chk_rule.Enabled = false;
                    }

                    if (rntbRule75.Text != string.Empty)
                        amnt = amnt + Convert.ToDecimal(rntbRule75.Text);

                    //// if (amnt > 0)
                    //// {
                    ////     lblClmTtlAmnt.Text = amnt.ToString();
                    ////     lblClmBalAmnt.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - Convert.ToDecimal(lblClmTtlAmnt.Text));
                    //// }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Select Index changed event for Currency
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcmb_Currency_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            RadComboBox rcmb_Currency;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox radAmount;
            RadNumericTextBox rntbCurrencyAmt;
            RadNumericTextBox rntbRule75;
            RadNumericTextBox rntbRecNo;
            Label lblBenName;
            Label lblBal;
            CheckBox chk_rule;
            CheckBox chk;
            
            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox; 
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                lblBal = rgEmpDepndnts.Items[i].FindControl("lblBal") as Label;
                chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                {
                    rnt_maxcurramt.Text = radAmount.Text = rntbCurrencyAmt.Text = rntbRule75.Text = rntbRecNo.Text = string.Empty;
                    chk_rule.Checked = false;

                    if (lblBal.Text != string.Empty && lblBal.Text == "0.00")
                    {
                        rcmb_Currency.SelectedIndex = 0;
                        BLL.ShowMessage(this, "There is no balance available for claiming the Medical benefits for the Beneficiary - " + lblBenName.Text);
                        return;
                    }

                    if (rcmb_Currency.SelectedIndex > 0 && lblBal.Text != string.Empty && rntbRule75.Text == string.Empty)
                    {
                        rnt_maxcurramt.Text = radAmount.Text = rntbCurrencyAmt.Text = rntbRule75.Text = string.Empty;

                        DataTable dtMBData = BLL.ConvMoneyEducational(1, rcmb_Currency.SelectedValue, lblBal.Text);

                        if (dtMBData.Rows.Count > 0)
                            rnt_maxcurramt.Text = Convert.ToString(dtMBData.Rows[0]["CONV_MNY"]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On Text changed event for Claim Amount
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void radAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            RadComboBox rcmb_Currency;
            RadNumericTextBox radAmount;
            RadNumericTextBox rntbCurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule75;
            Button btnClaim;
            Label lblBenName;
            Label lblBal;
            CheckBox chk_rule;

            //decimal amnt = 0;
            //decimal ruleAmnt = 0;
            //decimal clmBalAmnt = 0;
            //decimal clmdAmnt = 0;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                lblBal = rgEmpDepndnts.Items[i].FindControl("lblBal") as Label;
                chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;

                if (rcmb_Currency.SelectedIndex > 0 && rnt_maxcurramt.Text != string.Empty && radAmount.Text != string.Empty && btnClaim.Enabled == true)
                {
                    DataTable dtMBData = BLL.ConvMoneyEducational(2, rcmb_Currency.SelectedValue, radAmount.Text);

                    if (dtMBData.Rows.Count > 0)
                    {
                        if (chk_rule.Checked)
                        {
                            rntbCurrencyAmt.Text = Convert.ToString(dtMBData.Rows[0]["CONV_MNY"]);
                            rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rntbCurrencyAmt.Text) * Convert.ToDecimal(0.75));
                        }
                        else
                            rntbCurrencyAmt.Text = rntbRule75.Text = Convert.ToString(dtMBData.Rows[0]["CONV_MNY"]);
                    }
                }
                else
                {
                    if (rntbRule75.Text == string.Empty)
                    {
                        chk_rule.Checked = false;
                        rntbCurrencyAmt.Text = rntbRule75.Text = string.Empty;
                        radAmount.Focus();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Button Click event for button - "Claim"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClaim_Click(object sender, EventArgs e)
    {
        try
        {
            RadNumericTextBox radAmount;
            RadComboBox rcmb_Currency;
            RadNumericTextBox rntbRecNo;
            Button btnClaim;
            CheckBox chk_rule;
            CheckBox chk;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;
                chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                {
                    if (rcmb_Currency.SelectedIndex > 0 && radAmount.Text != string.Empty && rntbRecNo.Text != string.Empty && btnClaim.Enabled == true)
                        chk.Checked = rcmb_Currency.Enabled = radAmount.Enabled = rntbRecNo.Enabled = btnClaim.Enabled = chk_rule.Enabled = false;
                    else
                    {
                        if (rcmb_Currency.SelectedIndex == 0 || radAmount.Text == string.Empty || rntbRecNo.Text == string.Empty)
                        {
                            BLL.ShowMessage(this, "Please Enter All the Details before Clicking on Claim Button...!");
                            return;
                        }
                    }
                }
            }
            chkCnt = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Save click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            int benCnt = 0;
            int checkCnt = 0;

            RadNumericTextBox rntbCurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule75;
            RadNumericTextBox radAmount;
            RadComboBox rcmb_Currency;
            RadNumericTextBox rntbRecNo;
            Label lblFmlyDtlID;
            Label lblBenName;
            Label lblRelID;
            Label lblBal;
            CheckBox chk_rule;
            CheckBox chk;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (rcmb_Currency.SelectedIndex > 0 && rnt_maxcurramt.Text != string.Empty && radAmount.Text != string.Empty && rntbCurrencyAmt.Text != string.Empty &&
                        rntbRule75.Text != string.Empty && rntbRecNo.Text != string.Empty)
                    benCnt++;

                if (chk.Checked)
                    checkCnt++;
            }

            if (benCnt == 0)
            {
                BLL.ShowMessage(this, "Please enter all the details of at least one record in the grid before submitting..!");
                return;
            }
            else if (checkCnt > 0)
            {
                BLL.ShowMessage(this, "Please click the Claim button before submitting ..!");
                return;
            }
            else
            {
                if (fu_Browse.HasFile)
                {
                    string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + fu_Browse.FileName;
                    string strPath = "~/Download/EducationInvoice/" + pdfName;
                    FBrowse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = strPath;
                }
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = string.Empty;
                if (fu_Browse.HasFile)
                {
                    string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + fu_Browse.FileName;
                    string strPath = "~/Download/EducationInvoice/" + pdfName;
                    fu_Browse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = strPath;
                }
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = string.Empty;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_IS_FINALIZE = false;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_BU_ID = buID;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_DATE = Convert.ToDateTime(rdpt_ReceiptDate.SelectedDate);
                //_OBJ_SMHR_EDU_ALLOWANCE.EDU_CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EXPEN_NAME = string.Empty;
                if (rtbDepartment.Text != string.Empty)
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = deptID;
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = 0;
                if (rtbScale.Text != string.Empty)
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = grdID;
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = 0;
                if (rcbFinPeriod.SelectedValue != string.Empty)
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = 0;
                if (rntbEduAllScale.Text != string.Empty)
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = Convert.ToInt32(rntbEduAllScale.Text);
                else
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = 0;

                for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
                {
                    rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                    rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                    radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                    rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                    rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                    rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox;
                    lblBal = rgEmpDepndnts.Items[i].FindControl("lblBal") as Label;
                    lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                    lblRelID = rgEmpDepndnts.Items[i].FindControl("lblRelID") as Label;
                    lblFmlyDtlID = rgEmpDepndnts.Items[i].FindControl("lblFmlyDtlID") as Label;
                    chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;

                    if (lblFmlyDtlID.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(lblFmlyDtlID.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = 0;
                    if (chk_rule.Checked)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ISRULEID = true;
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ISRULEID = false;
                    if (radAmount.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CLAIM_AMT = Convert.ToDecimal(radAmount.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CLAIM_AMT = 0;
                    if (rntbRecNo.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_NO = Convert.ToInt32(rntbRecNo.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_NO = 0;
                    if (lblBal.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = Convert.ToDecimal(lblBal.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = 0;
                    if (rcmb_Currency.SelectedValue != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = 0;
                    if (rntbCurrencyAmt.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_AMT = Convert.ToDecimal(rntbCurrencyAmt.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_AMT = 0;
                    if (rnt_maxcurramt.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CONVERION_AMT = Convert.ToDecimal(rnt_maxcurramt.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_CONVERION_AMT = 0;
                    if (rntbRule75.Text != string.Empty)
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = Convert.ToDecimal(rntbRule75.Text);
                    else
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = 0;

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CHECKDUPLICATE;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_STATUS = 0;

                    DataTable dtCheckDup = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (Convert.ToString(dtCheckDup.Rows[0]["COUNT"]) != string.Empty)
                    {
                        if (Convert.ToInt32(dtCheckDup.Rows[0]["COUNT"]) > 0)
                            BLL.ShowMessage(this, "Educational claim for dependant - " + lblBenName.Text + " was already raised..!");
                        else
                        {
                            if (rntbRule75.Text != string.Empty)
                            {
                                _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Insert;
                                BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                            }
                        }
                    }
                    else
                    {
                        if (rntbRule75.Text != string.Empty)
                        {
                            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Insert;
                            BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                        }
                    }
                }

                Session["mbMsg"] = "ss";

                if (Convert.ToInt32(Session["EMP_ID"]) > 0 && Convert.ToString(Request.QueryString["type"]) == "self")
                    Response.Redirect("~/Selfservice/EduClaimEmp.aspx", false);
                else
                    Response.Redirect("~/EduClaim.aspx", false);
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Cancel click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["EMP_ID"]) > 0 && Convert.ToString(Request.QueryString["type"]) == "self")
                Response.Redirect("~/Selfservice/EduClaimEmp.aspx", false);
            else
                Response.Redirect("~/EduClaim.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To clear all the Controls
    /// </summary>
    protected void ClearControls()
    {
        try
        {
            rcbFinPeriod.Items.Clear();
            rcbFinPeriod.ClearSelection();
            rcbFinPeriod.Text = rntbEduAllScale.Text = string.Empty;

            //// RadServiceProviderName.Items.Clear();
            //// RadServiceProviderName.ClearSelection();
            //// RadServiceProviderName.Text = string.Empty;
            //// 
            //// radExpenditureName.Items.Clear();
            //// radExpenditureName.ClearSelection();
            //// radExpenditureName.Text = string.Empty;
            //// 
            //// rtbBusinesUnit.Text = rtbDirectorate.Text = rtbDepartment.Text = rtbEmpGrade.Text = lblMaxEligibleAmount.Text = lblAvailableAmount.Text = string.Empty;
            //// rdpInvoiceDate.Clear();
            rgEmpDepndnts.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Rule check box changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chk_rule_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadComboBox rcmb_Currency;
            RadNumericTextBox radAmount;
            RadNumericTextBox rntbCurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule75;
            Button btnClaim;
            Label lblBenName;
            Label lblBal;
            CheckBox chk_rule;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                lblBal = rgEmpDepndnts.Items[i].FindControl("lblBal") as Label;
                chk_rule = rgEmpDepndnts.Items[i].FindControl("chk_rule") as CheckBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;

                if (btnClaim.Enabled == true && rntbCurrencyAmt.Text != string.Empty)
                {
                    if (chk_rule.Checked)
                        rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rntbCurrencyAmt.Text) * Convert.ToDecimal(0.75));
                    else
                        rntbRule75.Text = rntbCurrencyAmt.Text;
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    #region CommentedCode
    /*
    /// <summary>
    /// To Load all the Service Provider's Data
    /// </summary>
    protected void LoadServiceProviders()
    {
        try
        {
            //// RadServiceProviderName.Items.Clear();
            //// RadServiceProviderName.ClearSelection();
            //// RadServiceProviderName.Text = string.Empty;
            //// RadServiceProviderName.AppendDataBoundItems = true;
            //// RadServiceProviderName.Enabled = true;

            //// SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();

            //// _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
            //// _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = "medical";
            //// _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            //// DataTable dtSerPrvdrs = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);

            //// if (dtSerPrvdrs.Rows.Count > 0)
            //// {
            ////     RadServiceProviderName.DataSource = dtSerPrvdrs;
            ////     RadServiceProviderName.DataValueField = "SERVICEPROVIDER_ID";
            ////     RadServiceProviderName.DataTextField = "SERVICEPROVIDER_NAME";
            ////     RadServiceProviderName.DataBind();
            //// }
            //// RadServiceProviderName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //// RadServiceProviderName.Items.Add(new RadComboBoxItem("Others", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "UploadInvoice", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// To Load all the Expenditure Name's Data
    /// </summary>
    protected void LoadExpenditureNames()
    {
        try
        {
            //// radExpenditureName.Items.Clear();
            //// radExpenditureName.ClearSelection();
            //// radExpenditureName.Text = string.Empty;
            //// radExpenditureName.AppendDataBoundItems = true;
            //// radExpenditureName.Enabled = true;
            //// 
            //// SMHR_EXPENDITURE _obj_Smhr_MedicalClaim = new SMHR_EXPENDITURE();
            //// 
            //// _obj_Smhr_MedicalClaim.OPERATION = operation.Select;
            //// _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            //// 
            //// DataTable dtExpName = BLL.get_Expenditure(_obj_Smhr_MedicalClaim);
            //// 
            //// if (dtExpName.Rows.Count > 0)
            //// {
            ////     radExpenditureName.DataSource = dtExpName;
            ////     radExpenditureName.DataValueField = "EXPENDITURE_ID";
            ////     radExpenditureName.DataTextField = "EXPENDITURE_NAME";
            ////     radExpenditureName.DataBind();
            //// }
            //// radExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            //// radExpenditureName.Items.Add(new RadComboBoxItem("Others", "-1"));
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Dependent select index changed event
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void rcbDependentName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Claim Amount select index changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rad_ClaimAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On select index changed event for Service Provider
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void RadServiceProviderName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //// if (RadServiceProviderName.SelectedIndex != 0 && RadServiceProviderName.SelectedValue == "-1")
            //// {
            ////     trMedicalSvcPrvdr.Visible = true;
            ////     radMedicalServiceProvider.Focus();
            //// }
            //// else
            ////     trMedicalSvcPrvdr.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// On select index changed event for Expenditure Name
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void radExpenditureName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //// if (radExpenditureName.SelectedValue != "0")
            //// {
            ////     if (rcmb_Employee.SelectedIndex > 0 && grdID > 0 && rcbFinPeriod.SelectedIndex > 0)
            ////     {
            ////         DataTable dtMBData = new DataTable();
            //// 
            ////         if (lblClmBalAmnt.Text != string.Empty)
            ////             dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue), 0, 0,
            ////                                                     Convert.ToDecimal(lblClmBalAmnt.Text));
            ////         else
            ////             dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue), 0, 0, 0);
            //// 
            ////         if (dtMBData.Rows.Count > 0)
            ////         {
            ////             lblMaxEligibleAmount.Text = Convert.ToString(dtMBData.Rows[0]["ELIGIBLE"]);
            ////             lblAvailableAmount.Text = Convert.ToString(dtMBData.Rows[0]["AVL_MNY_USD"]);
            ////         }
            ////     }
            ////     else
            ////     {
            ////         if (rcmb_Employee.SelectedIndex == 0)
            ////         {
            ////             BLL.ShowMessage(this, "Please select Employee before selecting Expenditure Name..!");
            ////             radExpenditureName.SelectedIndex = 0;
            ////             return;
            ////         }
            ////         else if (rcbFinPeriod.SelectedIndex == 0)
            ////         {
            ////             BLL.ShowMessage(this, "Please select Financial Period before selecting Expenditure Name..!");
            ////             radExpenditureName.SelectedIndex = 0;
            ////             return;
            ////         }
            ////         else
            ////         {
            ////             BLL.ShowMessage(this, "There is no Employee's Grade found for this employee..!");
            ////             radExpenditureName.SelectedIndex = 0;
            ////             return;
            ////         }
            //// 
            ////         lblMaxEligibleAmount.Text = lblAvailableAmount.Text = lblClmBalAmnt.Text = lblClmTtlAmnt.Text = string.Empty;
            ////         rcmb_Employee.SelectedIndex = 0;
            ////     }
            //// }
            //// else
            //// {
            ////     lblMaxEligibleAmount.Text = lblAvailableAmount.Text = lblClmBalAmnt.Text = lblClmTtlAmnt.Text = string.Empty;
            //// 
            ////     RadNumericTextBox rntbCurrencyAmt;
            ////     RadNumericTextBox rnt_maxcurramt;
            ////     RadNumericTextBox rntbRule75;
            ////     RadNumericTextBox radAmount;
            ////     RadComboBox rcmb_Currency;
            ////     RadNumericTextBox rntbRecNo;
            //// 
            ////     for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            ////     {
            ////         rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
            ////         rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
            ////         radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
            ////         rntbCurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rntbCurrencyAmt") as RadNumericTextBox;
            ////         rntbRule75 = rgEmpDepndnts.Items[i].FindControl("rntbRule75") as RadNumericTextBox;
            ////         rntbRecNo = rgEmpDepndnts.Items[i].FindControl("rntbRecNo") as RadNumericTextBox;
            //// 
            ////         rcmb_Currency.SelectedIndex = 0;
            ////         rnt_maxcurramt.Text = radAmount.Text = rntbCurrencyAmt.Text = rntbRule75.Text = rntbRecNo.Text = string.Empty;
            ////     }
            //// }
            //// 
            //// if (radExpenditureName.SelectedIndex != 0 && radExpenditureName.SelectedValue == "-1")
            //// {
            ////     trOtherExpndName.Visible = true;
            ////     rtbOtherExpndName.Focus();
            //// }
            //// else
            ////     trOtherExpndName.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "frmEduClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    */
    #endregion
}