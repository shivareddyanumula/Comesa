﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SMHR;
using System.Data;
using Telerik.Web.UI;

public partial class Medical_MedicalBenfitClaimAdd : System.Web.UI.Page
{
    static int grdID = 0;
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
            _obj_Smhr_LoginInfo.LOGIN_PASS_CODE = Convert.ToString("Medical Benifits Claim");

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
                btn_Save.Visible = false;
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
            LoadServiceProviders();
            LoadExpenditureNames();

            if (rcmb_Employee.SelectedIndex == 0)
            {
                LoadBenGrid(0);
                rgEmpDepndnts.DataBind();
            }

            rcmb_Employee.SelectedIndex = 0;

            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
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
    }

    /// <summary>
    /// To Load all Beneficiaries w.r.t Emp ID
    /// </summary>
    /// <param name="empID"></param>
    protected void LoadBenGrid(int empID)
    {
        try
        {
            DataTable dt = new DataTable();

            if (empID > -1)
            {
                dt = BLL.GetFamilyDataMedical(empID);
                rgEmpDepndnts.Visible = true;
            }
            else
                rgEmpDepndnts.Visible = false;

            rgEmpDepndnts.DataSource = dt;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            rcmb_Employee.Text = radMedicalServiceProvider.Text = rtbOtherExpndName.Text = string.Empty;

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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
    /// To Load all the Service Provider's Data
    /// </summary>
    protected void LoadServiceProviders()
    {
        try
        {
            RadServiceProviderName.Items.Clear();
            RadServiceProviderName.ClearSelection();
            RadServiceProviderName.Text = string.Empty;
            RadServiceProviderName.AppendDataBoundItems = true;
            RadServiceProviderName.Enabled = true;

            SMHR_SERVICEPROVIDER _obj_Smhr_ServiceProvider = new SMHR_SERVICEPROVIDER();

            _obj_Smhr_ServiceProvider.OPERATION = operation.Select2;
            _obj_Smhr_ServiceProvider.SERVICEPROVIDER_TYPE = "medical";
            _obj_Smhr_ServiceProvider.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtSerPrvdrs = BLL.get_ServiceProvider(_obj_Smhr_ServiceProvider);

            if (dtSerPrvdrs.Rows.Count > 0)
            {
                RadServiceProviderName.DataSource = dtSerPrvdrs;
                RadServiceProviderName.DataValueField = "SERVICEPROVIDER_ID";
                RadServiceProviderName.DataTextField = "SERVICEPROVIDER_NAME";
                RadServiceProviderName.DataBind();
            }
            RadServiceProviderName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            RadServiceProviderName.Items.Add(new RadComboBoxItem("Others", "-1"));
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
            radExpenditureName.Items.Clear();
            radExpenditureName.ClearSelection();
            radExpenditureName.Text = string.Empty;
            radExpenditureName.AppendDataBoundItems = true;
            radExpenditureName.Enabled = true;

            SMHR_EXPENDITURE _obj_Smhr_MedicalClaim = new SMHR_EXPENDITURE();

            _obj_Smhr_MedicalClaim.OPERATION = operation.Select;
            _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtExpName = BLL.get_Expenditure(_obj_Smhr_MedicalClaim);

            if (dtExpName.Rows.Count > 0)
            {
                radExpenditureName.DataSource = dtExpName;
                radExpenditureName.DataValueField = "EXPENDITURE_ID";
                radExpenditureName.DataTextField = "EXPENDITURE_NAME";
                radExpenditureName.DataBind();
            }
            radExpenditureName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));
            radExpenditureName.Items.Add(new RadComboBoxItem("Others", "-1"));
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
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            if (rcmb_Employee.SelectedIndex > 0)
            {
                LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue));
                rgEmpDepndnts.DataBind();
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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

            if (rdpInvoiceDate.SelectedDate == null)
            {
                rdpInvoiceDate.MinDate = new DateTime((DateTime.Now.AddMonths(-1)).Year, (DateTime.Now.AddMonths(-1)).Month, 26);
                rdpInvoiceDate.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                if (rdpInvoiceDate.MaxDate > DateTime.Now.Date)
                    rdpInvoiceDate.MaxDate = DateTime.Now;
            }

            LoadFinancialPeriod();
            LoadServiceProviders();
            LoadExpenditureNames();

            if (rcmb_Employee.SelectedIndex > 0)
            {
                LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue));
                rgEmpDepndnts.DataBind();

                LoadGridControls();

                DataTable dtEmp = BLL.GetFamilyDataMedical(Convert.ToInt32(rcmb_Employee.SelectedValue));

                if (dtEmp.Rows.Count > 0)
                {
                    rtbBusinesUnit.Text = Convert.ToString(dtEmp.Rows[0]["BUS_CODE"]);
                    rtbDirectorate.Text = Convert.ToString(dtEmp.Rows[0]["DIR_CODE"]);
                    rtbDepartment.Text = Convert.ToString(dtEmp.Rows[0]["DEPT_NAME"]);
                    rtbEmpGrade.Text = Convert.ToString(dtEmp.Rows[0]["GRADE"]);
                    grdID = Convert.ToInt32(dtEmp.Rows[0]["EMP_GRADE"]);
                }
            }
            else
            {
                LoadBenGrid(0);
                rgEmpDepndnts.DataBind();
            }
            chkCnt = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            RadServiceProviderName.SelectedIndex = radExpenditureName.SelectedIndex = 0;
            trMedicalSvcPrvdr.Visible = trOtherExpndName.Visible = false;
            radMedicalServiceProvider.Text = rtbOtherExpndName.Text = lblMaxEligibleAmount.Text = lblAvailableAmount.Text = lblClmBalAmnt.Text = lblClmTtlAmnt.Text = string.Empty;

            if (rcmb_Employee.SelectedIndex == 0)
                LoadBenGrid(0);
            else
                LoadBenGrid(Convert.ToInt32(rcmb_Employee.SelectedValue));

            rgEmpDepndnts.DataBind();
            LoadGridControls();
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            RadNumericTextBox rnt_CurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule80;
            RadNumericTextBox radAmount;
            RadComboBox rcmb_Currency;
            RadTextBox rtbInvoiceID;
            Button btnClaim;
            CheckBox chk;

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
                rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                rtbInvoiceID = rgEmpDepndnts.Items[i].FindControl("rtbInvoiceID") as RadTextBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                {
                    if (chkCnt > 0 && btnClaim.Enabled == false)
                    {
                        chk.Checked = false;
                        BLL.ShowMessage(this, "You are allowed for only one record to enter all the details at once..!");
                        return;
                    }
                    else
                    {
                        //chk.Enabled = false;
                        rcmb_Currency.Enabled = radAmount.Enabled = rtbInvoiceID.Enabled = btnClaim.Enabled = true;
                        chkCnt++;
                    }
                }
                else
                {
                    if (rcmb_Currency.Enabled == true && radAmount.Enabled == true && rtbInvoiceID.Enabled == true && btnClaim.Enabled == true)
                        chkCnt--;

                    if (rcmb_Currency.SelectedIndex == 0 && rnt_maxcurramt.Text == string.Empty && radAmount.Text == string.Empty &&
                           rnt_CurrencyAmt.Text == string.Empty && rntbRule80.Text == string.Empty)
                    {
                        rcmb_Currency.SelectedIndex = 0;
                        rnt_maxcurramt.Text = radAmount.Text = rnt_CurrencyAmt.Text = rntbRule80.Text = rtbInvoiceID.Text = string.Empty;
                        rcmb_Currency.Enabled = radAmount.Enabled = rtbInvoiceID.Enabled = btnClaim.Enabled = false;
                    }
                    else
                    {
                        if ((rcmb_Currency.SelectedIndex > 0 || rnt_maxcurramt.Text != string.Empty || radAmount.Text != string.Empty ||
                           rnt_CurrencyAmt.Text != string.Empty || rntbRule80.Text != string.Empty) && (btnClaim.Enabled == true))
                        {
                            rcmb_Currency.SelectedIndex = 0;
                            rnt_maxcurramt.Text = radAmount.Text = rnt_CurrencyAmt.Text = rntbRule80.Text = rtbInvoiceID.Text = string.Empty;
                            rcmb_Currency.Enabled = radAmount.Enabled = rtbInvoiceID.Enabled = btnClaim.Enabled = false;
                        }
                    }

                    if (rntbRule80.Text != string.Empty)
                        amnt = amnt + Convert.ToDecimal(rntbRule80.Text);

                    if (amnt > 0)
                    {
                        lblClmTtlAmnt.Text = amnt.ToString();
                        lblClmBalAmnt.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - Convert.ToDecimal(lblClmTtlAmnt.Text));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            RadNumericTextBox rnt_CurrencyAmt;
            RadNumericTextBox rntbRule80;
            Label lblBenName;
            CheckBox chk;

            int currCnt = 0;
            decimal ruleAmnt = 0;
            decimal clmAmnt = 0;
            decimal amnt = 0;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                {
                    if (rcmb_Currency.SelectedIndex > 0 && rntbRule80.Text == string.Empty)
                    {
                        if (lblClmBalAmnt.Text != string.Empty && lblClmBalAmnt.Text == "0.00")
                        {
                            rcmb_Currency.SelectedIndex = 0;
                            BLL.ShowMessage(this, "There is no balance available for claiming the Medical benefits for the Beneficiary - " + lblBenName.Text);
                            return;
                        }

                        if (rcmb_Employee.SelectedIndex > 0 && grdID > 0 && rcbFinPeriod.SelectedIndex > 0 && RadServiceProviderName.SelectedIndex > 0 &&
                                radExpenditureName.SelectedIndex > 0)
                        {
                            DataTable dtMBData = new DataTable();

                            if (lblClmBalAmnt.Text != string.Empty)
                                dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                                        Convert.ToInt32(rcmb_Currency.SelectedValue), 0, Convert.ToDecimal(lblClmBalAmnt.Text));
                            else
                                dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                                        Convert.ToInt32(rcmb_Currency.SelectedValue), 0, 0);

                            if (dtMBData.Rows.Count > 0)
                                rnt_maxcurramt.Text = Convert.ToString(dtMBData.Rows[0]["CONV_MNY_CRNCY"]);
                        }
                        else
                        {
                            rcmb_Currency.SelectedIndex = 0;
                            if (rcmb_Employee.SelectedIndex == 0)
                            {
                                BLL.ShowMessage(this, "Please select Employee before selecting Currency..!");
                                return;
                            }
                            else if (rcbFinPeriod.SelectedIndex == 0)
                            {
                                BLL.ShowMessage(this, "Please select Financial Period before selecting Currency..!");
                                return;
                            }
                            else if (RadServiceProviderName.SelectedValue == "0")
                            {
                                BLL.ShowMessage(this, "Please select Service Provider Name before selecting Currency..!");
                                return;
                            }
                            else if (radExpenditureName.SelectedValue == "0")
                            {
                                BLL.ShowMessage(this, "Please select Expenditure Name before selecting Currency..!");
                                return;
                            }
                            else
                            {
                                BLL.ShowMessage(this, "There is no Employee's Grade found for this employee..!");
                                return;
                            }
                        }

                        if (rntbRule80.Text != string.Empty)
                            ruleAmnt = ruleAmnt + Convert.ToDecimal(rntbRule80.Text);
                    }
                    else if (rcmb_Currency.SelectedIndex == 0 && radAmount.Text != string.Empty)
                        radAmount.Text = rnt_maxcurramt.Text = rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                    else if (rcmb_Currency.SelectedIndex == 0 && rnt_maxcurramt.Text != string.Empty)
                        rnt_maxcurramt.Text = string.Empty;
                    else
                    {
                        if (rcmb_Currency.SelectedIndex > 0 && rntbRule80.Text == string.Empty)
                            radAmount.Text = rnt_maxcurramt.Text = rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                    }
                }
                if (radAmount.Text != string.Empty)
                    clmAmnt = clmAmnt + Convert.ToDecimal(radAmount.Text);
            }

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;

                if (rcmb_Currency.SelectedIndex > 0)
                    currCnt++;

                if (rntbRule80.Text != string.Empty)
                    amnt = amnt + Convert.ToDecimal(rntbRule80.Text);
            }

            if (currCnt == 0)
                lblClmTtlAmnt.Text = lblClmBalAmnt.Text = string.Empty;
            else
            {
                if (clmAmnt == 0)
                    lblClmTtlAmnt.Text = lblClmBalAmnt.Text = string.Empty;
                else
                {
                    if (currCnt == 0 && lblClmTtlAmnt.Text == string.Empty)
                        lblClmTtlAmnt.Text = ruleAmnt.ToString();
                    if (lblAvailableAmount.Text != string.Empty && lblClmTtlAmnt.Text != string.Empty)
                        lblClmBalAmnt.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - Convert.ToDecimal(lblClmTtlAmnt.Text));
                }

                if (amnt > 0)
                {
                    lblClmTtlAmnt.Text = amnt.ToString();
                    lblClmBalAmnt.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - amnt);
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            if (RadServiceProviderName.SelectedIndex != 0 && RadServiceProviderName.SelectedValue == "-1")
            {
                trMedicalSvcPrvdr.Visible = true;
                radMedicalServiceProvider.Focus();
            }
            else
                trMedicalSvcPrvdr.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            if (radExpenditureName.SelectedValue != "0")
            {
                if (rcmb_Employee.SelectedIndex > 0 && grdID > 0 && rcbFinPeriod.SelectedIndex > 0)
                {
                    DataTable dtMBData = new DataTable();

                    if (lblClmBalAmnt.Text != string.Empty)
                        dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue), 0, 0,
                                                                Convert.ToDecimal(lblClmBalAmnt.Text));
                    else
                        dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue), 0, 0, 0);

                    if (dtMBData.Rows.Count > 0)
                    {
                        lblMaxEligibleAmount.Text = Convert.ToString(dtMBData.Rows[0]["ELIGIBLE"]);
                        lblAvailableAmount.Text = Convert.ToString(dtMBData.Rows[0]["AVL_MNY_USD"]);
                    }
                }
                else
                {
                    if (rcmb_Employee.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please select Employee before selecting Expenditure Name..!");
                        radExpenditureName.SelectedIndex = 0;
                        return;
                    }
                    else if (rcbFinPeriod.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please select Financial Period before selecting Expenditure Name..!");
                        radExpenditureName.SelectedIndex = 0;
                        return;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "There is no Employee's Grade found for this employee..!");
                        radExpenditureName.SelectedIndex = 0;
                        return;
                    }

                    lblMaxEligibleAmount.Text = lblAvailableAmount.Text = lblClmBalAmnt.Text = lblClmTtlAmnt.Text = string.Empty;
                    rcmb_Employee.SelectedIndex = 0;
                }
            }
            else
            {
                lblMaxEligibleAmount.Text = lblAvailableAmount.Text = lblClmBalAmnt.Text = lblClmTtlAmnt.Text = string.Empty;

                RadNumericTextBox rnt_CurrencyAmt;
                RadNumericTextBox rnt_maxcurramt;
                RadNumericTextBox rntbRule80;
                RadNumericTextBox radAmount;
                RadComboBox rcmb_Currency;
                RadTextBox rtbInvoiceID;

                for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
                {
                    rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                    rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                    radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                    rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                    rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                    rtbInvoiceID = rgEmpDepndnts.Items[i].FindControl("rtbInvoiceID") as RadTextBox;

                    rcmb_Currency.SelectedIndex = 0;
                    rnt_maxcurramt.Text = radAmount.Text = rnt_CurrencyAmt.Text = rntbRule80.Text = rtbInvoiceID.Text = string.Empty;
                }
            }

            if (radExpenditureName.SelectedIndex != 0 && radExpenditureName.SelectedValue == "-1")
            {
                trOtherExpndName.Visible = true;
                rtbOtherExpndName.Focus();
            }
            else
                trOtherExpndName.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            RadNumericTextBox rnt_CurrencyAmt;
            RadNumericTextBox rntbRule80;
            Button btnClaim;
            Label lblBenName;

            decimal amnt = 0;
            decimal ruleAmnt = 0;
            decimal clmBalAmnt = 0;
            decimal clmdAmnt = 0;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;

                if (radAmount.Text != string.Empty)
                {
                    if (rcmb_Currency.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Currency for the Beneficiary - " + lblBenName.Text + "., before entering the Claim Amount..!");
                        radAmount.Text = string.Empty;
                        rcmb_Currency.Focus();
                        return;
                    }
                    if (rcbFinPeriod.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Financial Period before entering the Claim Amount..!");
                        radAmount.Text = string.Empty;
                        rcbFinPeriod.Focus();
                        return;
                    }
                    if (radExpenditureName.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Expenditure Name before entering the Claim Amount..!");
                        radAmount.Text = string.Empty;
                        radExpenditureName.Focus();
                        return;
                    }
                    if (rcmb_Employee.SelectedIndex == 0)
                    {
                        BLL.ShowMessage(this, "Please Select Employee before entering the Claim Amount..!");
                        radAmount.Text = string.Empty;
                        rcmb_Employee.Focus();
                        return;
                    }
                }

                if (radAmount.Text != string.Empty && btnClaim.Enabled == true && rntbRule80.Text != string.Empty)
                    clmdAmnt = clmdAmnt + Convert.ToDecimal(rntbRule80.Text);
            }

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;

                if (radAmount.Text != string.Empty && btnClaim.Enabled == true)
                {
                    if (rcmb_Employee.SelectedIndex > 0 && grdID > 0 && rcbFinPeriod.SelectedIndex > 0)
                    {
                        DataTable dtMBData = new DataTable();

                        /*if (lblClmBalAmnt.Text != string.Empty)
                            dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                                 Convert.ToInt32(rcmb_Currency.SelectedValue), Convert.ToDecimal(radAmount.Text), Convert.ToDecimal(lblClmBalAmnt.Text));
                        else
                            dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                Convert.ToInt32(rcmb_Currency.SelectedValue), Convert.ToDecimal(radAmount.Text), 0);*/
                        if (clmdAmnt > 0 && lblAvailableAmount.Text != string.Empty)
                        {
                            decimal val = Convert.ToDecimal(lblAvailableAmount.Text) - clmdAmnt;
                            dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                Convert.ToInt32(rcmb_Currency.SelectedValue), Convert.ToDecimal(radAmount.Text), val);
                        }
                        else
                            dtMBData = BLL.GetMedicalBenefitData(Convert.ToInt32(rcmb_Employee.SelectedValue), grdID, Convert.ToInt32(rcbFinPeriod.SelectedValue),
                                Convert.ToInt32(rcmb_Currency.SelectedValue), Convert.ToDecimal(radAmount.Text), 0);

                        if (dtMBData.Rows.Count > 0)
                        {
                            rnt_CurrencyAmt.Text = Convert.ToString(dtMBData.Rows[0]["CONV_CLMD_AMNT_USD"]);
                            if (lblClmBalAmnt.Text != string.Empty)
                            {
                                if (Convert.ToDecimal(dtMBData.Rows[0]["RULE_AMNT_USD"]) < Convert.ToDecimal(lblClmBalAmnt.Text))
                                    rntbRule80.Text = Convert.ToString(dtMBData.Rows[0]["RULE_AMNT_USD"]);
                                else
                                {
                                    if (lblClmBalAmnt.Text != "0.00")
                                        rntbRule80.Text = lblClmBalAmnt.Text;
                                }
                            }
                            else
                                rntbRule80.Text = Convert.ToString(dtMBData.Rows[0]["RULE_AMNT_USD"]);
                        }

                        ruleAmnt = ruleAmnt + Convert.ToDecimal(rntbRule80.Text);

                        if (ruleAmnt > Convert.ToDecimal(lblAvailableAmount.Text))
                            rntbRule80.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - clmBalAmnt);
                        else
                            clmBalAmnt = clmBalAmnt + ruleAmnt;
                    }
                    else
                    {
                        if (rcmb_Employee.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select Employee before selecting Currency..!");
                            return;
                        }
                        else if (rcbFinPeriod.SelectedIndex == 0)
                        {
                            BLL.ShowMessage(this, "Please select Financial Period before selecting Currency..!");
                            return;
                        }
                        else
                        {
                            BLL.ShowMessage(this, "There is no Employee's Grade found for this employee..!");
                            return;
                        }
                    }
                }
                else
                {
                    if (rcmb_Currency.SelectedIndex > 0 && rntbRule80.Text == string.Empty)
                        rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                    if (btnClaim.Enabled)
                        rnt_CurrencyAmt.Text = rntbRule80.Text = string.Empty;
                }
            }

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;

                if (rntbRule80.Text != string.Empty)
                    amnt = amnt + Convert.ToDecimal(rntbRule80.Text);
            }

            if (amnt > 0)
            {
                lblClmTtlAmnt.Text = amnt.ToString();
                lblClmBalAmnt.Text = Convert.ToString(Convert.ToDecimal(lblAvailableAmount.Text) - Convert.ToDecimal(lblClmTtlAmnt.Text));
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            RadTextBox rtbInvoiceID;
            Button btnClaim;
            CheckBox chk;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rtbInvoiceID = rgEmpDepndnts.Items[i].FindControl("rtbInvoiceID") as RadTextBox;
                btnClaim = rgEmpDepndnts.Items[i].FindControl("btnClaim") as Button;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (chk.Checked)
                {
                    if (rcmb_Currency.SelectedIndex > 0 && radAmount.Text != string.Empty && rtbInvoiceID.Text != string.Empty && btnClaim.Enabled == true)
                        chk.Checked = rcmb_Currency.Enabled = radAmount.Enabled = rtbInvoiceID.Enabled = btnClaim.Enabled = false;
                    else
                    {
                        if (rcmb_Currency.SelectedIndex == 0 || radAmount.Text == string.Empty || rtbInvoiceID.Text == string.Empty)
                        {
                            BLL.ShowMessage(this, "Please enter all the details before clicking button..!");
                            return;
                        }
                    }
                }
            }
            chkCnt = 0;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// Save click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            int benCnt = 0;
            int checkCnt = 0;

            RadNumericTextBox rnt_CurrencyAmt;
            RadNumericTextBox rnt_maxcurramt;
            RadNumericTextBox rntbRule80;
            RadNumericTextBox radAmount;
            RadComboBox rcmb_Currency;
            RadTextBox rtbInvoiceID;
            Label lblFmlyDtlID;
            Label lblBenName;
            Label lblRelID;
            CheckBox chk;

            for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
            {
                rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                rtbInvoiceID = rgEmpDepndnts.Items[i].FindControl("rtbInvoiceID") as RadTextBox;
                chk = rgEmpDepndnts.Items[i].FindControl("chk") as CheckBox;

                if (rcmb_Currency.SelectedIndex > 0 && rnt_maxcurramt.Text != string.Empty && radAmount.Text != string.Empty && rnt_CurrencyAmt.Text != string.Empty &&
                        rntbRule80.Text != string.Empty && rtbInvoiceID.Text != string.Empty)
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
                SMHR_MedicalClaim _obj_Smhr_MedicalClaim = new SMHR_MedicalClaim();

                if (FBrowse.HasFile)
                {
                    string pdfName = _obj_Smhr_MedicalClaim.EmpID + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                    string strPath = "~/MedicalInvoice/" + pdfName;
                    FBrowse.PostedFile.SaveAs(Server.MapPath("~/MedicalInvoice/") + pdfName);
                    _obj_Smhr_MedicalClaim.InvoiceDocument = strPath;
                }
                else
                {
                    BLL.ShowMessage(this, "Please upload invoice");
                    FBrowse.Focus();
                    return;
                }

                _obj_Smhr_MedicalClaim.OPERATION = operation.Insert;
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _obj_Smhr_MedicalClaim.CliamType = RadClaimType.SelectedItem.Text;
                _obj_Smhr_MedicalClaim.SERVICEPROVIDERID = Convert.ToInt32(RadServiceProviderName.SelectedValue);
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.EmpID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _obj_Smhr_MedicalClaim.ExpenditureID = Convert.ToInt32(radExpenditureName.SelectedValue);
                _obj_Smhr_MedicalClaim.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_Smhr_MedicalClaim.FIN_PRD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_Smhr_MedicalClaim.InvoiceDate = (DateTime)rdpInvoiceDate.SelectedDate;
                _obj_Smhr_MedicalClaim.CREATEDBY = Convert.ToInt32(Session["USER_ID"]);
                _obj_Smhr_MedicalClaim.OTHER_EXPND_NAME = rtbOtherExpndName.Text;
                _obj_Smhr_MedicalClaim.MED_ISRULEID = true;
                
                for (int i = 0; i < rgEmpDepndnts.Items.Count; i++)
                {
                    rcmb_Currency = rgEmpDepndnts.Items[i].FindControl("rcmb_Currency") as RadComboBox;
                    rnt_maxcurramt = rgEmpDepndnts.Items[i].FindControl("rnt_maxcurramt") as RadNumericTextBox;
                    radAmount = rgEmpDepndnts.Items[i].FindControl("radAmount") as RadNumericTextBox;
                    rnt_CurrencyAmt = rgEmpDepndnts.Items[i].FindControl("rnt_CurrencyAmt") as RadNumericTextBox;
                    rntbRule80 = rgEmpDepndnts.Items[i].FindControl("rntbRule80") as RadNumericTextBox;
                    rtbInvoiceID = rgEmpDepndnts.Items[i].FindControl("rtbInvoiceID") as RadTextBox;
                    lblBenName = rgEmpDepndnts.Items[i].FindControl("lblBenName") as Label;
                    lblRelID = rgEmpDepndnts.Items[i].FindControl("lblRelID") as Label;
                    lblFmlyDtlID = rgEmpDepndnts.Items[i].FindControl("lblFmlyDtlID") as Label;

                    if (rcmb_Currency.SelectedIndex > 0 && rnt_maxcurramt.Text != string.Empty && radAmount.Text != string.Empty &&
                        rnt_CurrencyAmt.Text != string.Empty && rntbRule80.Text != string.Empty)
                    {
                        _obj_Smhr_MedicalClaim.BenficiarySerialId = Convert.ToInt32(lblFmlyDtlID.Text);
                        _obj_Smhr_MedicalClaim.BenficiaryName = lblBenName.Text.Trim();
                        _obj_Smhr_MedicalClaim.RelationID = Convert.ToInt32(lblRelID.Text);
                        _obj_Smhr_MedicalClaim.MED_FINAL_AMNT = Convert.ToDouble(rntbRule80.Text);
                        _obj_Smhr_MedicalClaim.Amount = Convert.ToDouble(radAmount.Text);
                        _obj_Smhr_MedicalClaim.MED_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
                        _obj_Smhr_MedicalClaim.MED_CURR_AMT = Convert.ToDecimal(rnt_CurrencyAmt.Text);
                        _obj_Smhr_MedicalClaim.MED_CONVERSION_AMT = Convert.ToDecimal(rnt_maxcurramt.Text);
                        _obj_Smhr_MedicalClaim.InvoiceID = rtbInvoiceID.Text;
                        _obj_Smhr_MedicalClaim.ServiceProviderName = radMedicalServiceProvider.Text;
                        _obj_Smhr_MedicalClaim.OTHER_EXPND_NAME = rtbOtherExpndName.Text;
                    }
                    BLL.set_MedicalClaim(_obj_Smhr_MedicalClaim);
                }

                if (Convert.ToInt32(Session["EMP_ID"]) > 0)
                    Response.Redirect("~/Selfservice/MedicalBenfitClaimEmp.aspx", false);
                else
                    Response.Redirect("~/Medical/MedicalBenfitClaim.aspx", false);

                Session["mbMsg"] = "ss";
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            if (Convert.ToInt32(Session["EMP_ID"]) > 0)
                Response.Redirect("~/Selfservice/MedicalBenfitClaimEmp.aspx", false);
            else
                Response.Redirect("~/Medical/MedicalBenfitClaim.aspx", false);
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
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
            rcbFinPeriod.Text = string.Empty;

            RadServiceProviderName.Items.Clear();
            RadServiceProviderName.ClearSelection();
            RadServiceProviderName.Text = string.Empty;

            radExpenditureName.Items.Clear();
            radExpenditureName.ClearSelection();
            radExpenditureName.Text = string.Empty;

            rtbBusinesUnit.Text = rtbDirectorate.Text = rtbDepartment.Text = rtbEmpGrade.Text = lblMaxEligibleAmount.Text = lblAvailableAmount.Text = string.Empty;
            rdpInvoiceDate.Clear();
            rgEmpDepndnts.Visible = false;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaimAdd", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
}