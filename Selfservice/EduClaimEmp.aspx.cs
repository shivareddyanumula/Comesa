﻿using SMHR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Medical_EduClaimEmp : System.Web.UI.Page
{
    SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
    SMHR_CURRENCY _obj_smhr_Currency;

    static int allowanceID = 0;
    static int eduClmID = 0;
    static int val = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["EMP_ID"]) == 0)
                    Response.Redirect("~/Masters/Default.aspx?ctrl=SS", false);
                else
                {
                    LoadGrid();
                    Rg_Educationdet.DataBind();
                }

                if (Session["mbMsg"] != null)
                {
                    BLL.ShowMessage(this, "Information Saved Successfully for selected record(s)");
                    Session["mbMsg"] = null;
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadGrid()
    {
        try
        {
            //    if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            //        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.load;
            //    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            //    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //    _OBJ_SMHR_EDU_ALLOWANCE.MODE = 1;
            //    Rg_Educationdet.DataSource = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
            // if (Convert.ToInt32(Session["EMP_ID"]) == 0)
            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Empty;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            //_OBJ_SMHR_EDU_ALLOWANCE.MODE = 1;
            Rg_Educationdet.DataSource = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void Rg_Educationdet_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void lnk_View_Command(object sender, CommandEventArgs e)
    {
        try
        {
            rcmb_Currency.Enabled = false;
            //getting previous month for particular date i.e:25th of previous month
            //////var previousDate = DateTime.Now.AddMonths(-1);
            //////var mindate = new DateTime(previousDate.Year, previousDate.Month, 26);

            //////rdpt_ReceiptDate.MinDate = mindate;

            ////////getting current month for particular date i.e:24th of current month
            //////var maxdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);

            //////rdpt_ReceiptDate.MaxDate = maxdate;

            val = 2;
            btn_Submit.Visible = false;

            LoadEmployees();
            LoadBusinessUnits();
            LoadDepartments();
            LoadScales();
            LoadFinancialPeriod();
            LoadToCurrency();   //loading currency
            eduClmID = Convert.ToInt32(e.CommandArgument);
            rcbFinPeriod.Enabled = false;

            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Get;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ID = eduClmID;

            DataTable dtEduClm = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

            if (dtEduClm.Rows.Count > 0)
            {
                var minDate = DateTime.Now;
                var maxDate = DateTime.Now;

                rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMP_ID"]));
                rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_BU_ID"]));
                rcmb_Department.SelectedIndex = rcmb_Department.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_DEPT_ID"]));
                rcbScale.SelectedIndex = rcbScale.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMPLOYEEGRADE_ID"]));
                rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_PERIOD_ID"]));

                if (rcbFinPeriod.SelectedIndex > 0)
                {
                    SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

                    _obj_smhr_period.OPERATION = operation.Select;
                    _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_smhr_period.PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);

                    DataTable dtPrdDtls = BLL.get_PeriodHeaderDetails(_obj_smhr_period);

                    if (dtPrdDtls.Rows.Count > 0)
                    {
                        minDate = Convert.ToDateTime(dtPrdDtls.Rows[0]["PERIOD_STARTDATE"]);
                        maxDate = Convert.ToDateTime(dtPrdDtls.Rows[0]["PERIOD_ENDDATE"]);

                        rdpt_ReceiptDate.MinDate = minDate;
                        rdpt_ReceiptDate.MaxDate = maxDate;

                        if (rdpt_ReceiptDate.MaxDate > DateTime.Now.Date)
                            rdpt_ReceiptDate.MaxDate = DateTime.Now;
                    }
                }

                LoadEmpFamilyDetails();

                _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                rcbDependentName.SelectedIndex = rcbDependentName.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_EMPFMDTL_ID"]));
                rntbEduAllScale.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_ALLOWANCE_DEPENDENT"]);
                rnt_CurrencyAmt.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_CURR_AMT"]);   //currency amount
                rnt_maxcurramt.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_CONVERION_AMT"]);
                rcmb_Currency.SelectedIndex = rcmb_Currency.Items.FindItemIndexByValue(Convert.ToString(dtEduClm.Rows[0]["EDU_CURR_ID"]));   //selected currency 
                if (dtEduClm.Rows[0]["EDU_ISRULEID"] != System.DBNull.Value)
                {
                    chk_rule.Checked = Convert.ToBoolean(dtEduClm.Rows[0]["EDU_ISRULEID"]);
                }
                //rntb_bal.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_BAL_AVL"]);
                //if (dtEmpEduData.Rows.Count > 0)
                //    rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Text) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                //else
                //    rntb_bal.Text = rntbEduAllScale.Text;
                rcbDependentName_SelectedIndexChanged(null, null);
                //rtxt_Expenditure.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_EXPEN_NAME"]);
                rad_ClaimAmount.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_CLAIM_AMT"]);
                rntbReceiptNo.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_RECPT_NO"]);
                rntb_bal.Text = Convert.ToString(Convert.ToDecimal(dtEduClm.Rows[0]["EDU_BAL_AVL"]));

                if (!string.IsNullOrEmpty(dtEduClm.Rows[0]["EDU_RECPT_DATE"].ToString()))
                {
                    //var minDate = (new DateTime((DateTime.Now.AddMonths(-1)).Year, (DateTime.Now.AddMonths(-1)).Month, 25));
                    //var maxDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 24));
                    if (Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) > minDate && Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) > maxDate 
                        || Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) < minDate && Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) < maxDate)
                        //rdpt_ReceiptDate.SelectedDate = null;

                        // if (Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) >= minDate && Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) >= maxDate)
                        //if (Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) <= minDate && Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]) <= maxDate)
                        rdpt_ReceiptDate.SelectedDate = null;
                    else
                        rdpt_ReceiptDate.SelectedDate = Convert.ToDateTime(dtEduClm.Rows[0]["EDU_RECPT_DATE"]);

                }
                rntbRule75.Text = Convert.ToString(dtEduClm.Rows[0]["EDU_FINAL_AMNT"]);
                ViewState["rntbRule75"] = rntbRule75.Text;
                rad_ClaimAmount.Enabled = rcmb_Employee.Enabled = rcbDependentName.Enabled = false;
            }
            Rm_Education_page.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnk_Add_Command(object sender, CommandEventArgs e)
    {
        try
        {
            val = 1;
            btn_Submit.Visible = true;
            clearControls();
            LoadEmployees();
            LoadToCurrency();  //loading currency
            Rm_Education_page.SelectedIndex = 1;
            rcbFinPeriod.Enabled = true;
            rcmb_Employee.SelectedIndex = rcmb_Employee.Items.FindItemIndexByValue(Convert.ToString(Session["EMP_ID"]));
            rcmb_Employee_SelectedIndexChanged(null, null);
            rcbFinPeriod.SelectedIndex = 0;
            rcbDependentName.SelectedIndex = 0;
            btn_Finalize.Visible = false;
            rad_ClaimAmount.Enabled = rcbDependentName.Enabled = true;
            rcmb_Employee.Enabled = false;
            rnt_maxcurramt.Text = string.Empty;
            chk_rule.Checked = true;
            //getting previous month for particular date i.e:25th of previous month
            var previousDate = DateTime.Now.AddMonths(-1);

            var mindate = new DateTime(previousDate.Year, previousDate.Month, 26);

            rdpt_ReceiptDate.MinDate = mindate;

            //getting current month for particular date i.e:24th of current month
            var maxdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);

            rdpt_ReceiptDate.MaxDate = maxdate;
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Employee_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbScale.SelectedIndex = 0;
            rntbEduAllScale.Text = rad_ClaimAmount.Text = rntbRule75.Text = rntb_bal.Text = string.Empty;

            if (rcmb_Employee.SelectedIndex > 0)
            {
                int empID = Convert.ToInt32(rcmb_Employee.SelectedValue);

                SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();
                SMHR_ALLOWANCE _obj_SMHR_ALLOWANCE = new SMHR_ALLOWANCE();

                _obj_smhr_employee.OPERATION = operation.Select;
                _obj_smhr_employee.EMP_ID = empID;
                _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

                DataTable dt_Details = BLL.get_Employee(_obj_smhr_employee);

                if (dt_Details.Rows.Count > 0)
                {
                    LoadBusinessUnits();
                    LoadDepartments();
                    LoadScales();
                    LoadFinancialPeriod();
                    LoadEmpFamilyDetails();

                    rcmb_BusinessUnit.SelectedIndex = rcmb_BusinessUnit.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_BUSINESSUNIT_ID"]));
                    rcmb_Department.SelectedIndex = rcmb_Department.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_DEPARTMENT_ID"]));
                    rcbScale.SelectedIndex = rcbScale.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_GRADE"]));
                    //rcbFinPeriod.SelectedIndex = rcbFinPeriod.Items.FindItemIndexByValue(Convert.ToString(dt_Details.Rows[0]["EMP_PERIOD_ID"]));

                    /*_obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                    _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
                    _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for getting Education allowance
                     
                    DataTable dtEmpFmlyAlwnces = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = empID;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                    DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (dtEmpFmlyAlwnces.Rows.Count > 0)
                        rntbEduAllScale.Text = Convert.ToString(dtEmpFmlyAlwnces.Rows[0]["ALLOWANCE_DEPENDENT"]);
                    else
                        rntbEduAllScale.Text = "0";
                    if (dtEmpEduData.Rows.Count > 0)
                        rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                    else
                        rntb_bal.Text = rntbEduAllScale.Text;*/
                }
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_BusinessUnit_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void rcmb_Department_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void rcbFinPeriod_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            rcbDependentName.SelectedIndex = 0;
            rntb_bal.Text = string.Empty;
            if (rcbFinPeriod.SelectedIndex > 0)
            {
                SMHR_ALLOWANCE _obj_SMHR_ALLOWANCE = new SMHR_ALLOWANCE();

                _obj_SMHR_ALLOWANCE.OPERATION = operation.Check;
                _obj_SMHR_ALLOWANCE.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
                _obj_SMHR_ALLOWANCE.ALLOWANCE_CONFG_ID = 1; //for getting Education allowance
                DataTable dtEmpFmlyAlwnces = BLL.GET_ALLOWANCE(_obj_SMHR_ALLOWANCE);
                if (dtEmpFmlyAlwnces.Rows.Count > 0)
                    rntbEduAllScale.Text = Convert.ToString(dtEmpFmlyAlwnces.Rows[0]["ALLOWANCE_DEPENDENT"]);
                else
                    rntbEduAllScale.Text = "0";
            }
            else
            {
                rntbEduAllScale.Text = string.Empty;
                BLL.ShowMessage(this, "Please select Financial Period");
                rcbFinPeriod.Focus();
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcbDependentName_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            if (rcbFinPeriod.SelectedIndex > 0)
            {

                if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
                {

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.check;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    DataTable dt = new DataTable();
                    dt = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                    if (Convert.ToInt32(dt.Rows[0]["CLAIM"]) == 0)   //for new financial period
                    {
                        rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value));
                    }



                    else

                        ///////////////////////
                        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (dtEmpEduData.Rows.Count > 0)   //for existing financial period
                        rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                    else
                        rntb_bal.Text = rntbEduAllScale.Text;
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");
                    rntb_bal.Text = string.Empty;
                    rcbDependentName.Focus();
                    return;
                }
            }


            else
            {
                BLL.ShowMessage(this, "Please select Financial Period");

                rcbFinPeriod.Focus();
                return;
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// New Add Command Event for Multi Dependant Educational claims
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnk_Add_Command1(object sender, CommandEventArgs e)
    {
        try
        {
            Response.Redirect("~/Selfservice/frmEduClaimAdd.aspx?type=self", false);
            return;
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "MedicalBenfitClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }

    /// <summary>
    /// below event was commented by Eshwar_Dev 20170316 to modify the changes suggested by Joshua...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rad_ClaimAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();

            //for  amount after Conversion in claim amount validation
            if (rnt_maxcurramt.Text == string.Empty && rad_ClaimAmount.Text == string.Empty)
            {
                /*if ((Convert.ToDouble(rad_ClaimAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                {
                    BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Conversion..!");
                    rad_ClaimAmount.Text = string.Empty;
                    return;
                }*/

                if (rad_ClaimAmount.Text == string.Empty)
                {
                    BLL.ShowMessage(this, "Claim Amount should not be empty.!");
                    rad_ClaimAmount.Focus();
                    return;
                }
                else
                {
                    BLL.ShowMessage(this, "Amount After Conversion should not be empty.!");
                    rnt_maxcurramt.Focus();
                    return;
                }
            }

            //for display one currency amount to another currency amount
            rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty

            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

            if (rcmb_Currency.SelectedIndex > 0)
            {
                DataTable dtcurrency = new DataTable();
                dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                if (dtcurrency.Rows.Count > 0)
                {
                    if (rad_ClaimAmount.Text != string.Empty)
                    {
                        double value = 0.0;

                        value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                        rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) / value);
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    rad_ClaimAmount.Text = string.Empty;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Currency Type...!");
                rnt_CurrencyAmt.Text = string.Empty;
                rad_ClaimAmount.Text = string.Empty;
            }

            //if rule checkbox is uncheched
            if (chk_rule.Checked == false)
            {
                if (rcbFinPeriod.SelectedIndex > 0)
                {
                    if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
                    {
                        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                        if (dtEmpEduData.Rows.Count > 0)
                            rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rnt_CurrencyAmt.Value)); //- Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                        else
                            rntbRule75.Text = rntbEduAllScale.Text;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");

                        rntb_bal.Text = string.Empty;
                        rcbDependentName.Focus();
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Financial Period");
                    rcbFinPeriod.Focus();
                    return;
                }
            }

            if (chk_rule.Checked)   //if 75% rule checkbox is checked
            {
                //for  amount after Conversion in claim amount validation
                ////// if (rad_ClaimAmount.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                ////// {
                //////     if ((Convert.ToDouble(rad_ClaimAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                //////     {
                //////         BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Conversion..!");
                //////         rad_ClaimAmount.Text = string.Empty;
                //////         ////chk_rule.checked = false;
                //////     }
                ////// }

                //for display one currency amount to another currency amount
                rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty

                if (rcmb_Currency.SelectedIndex > 0)
                {
                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                    DataTable dtcurrency = new DataTable();
                    dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                    if (dtcurrency.Rows.Count > 0)
                    {
                        if (rad_ClaimAmount.Text != string.Empty)
                        {
                            double value = 0.0;
                            value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                            rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) / value);
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rad_ClaimAmount.Text = string.Empty;
                        ////chk_rule.checked = false;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    rad_ClaimAmount.Text = string.Empty;
                    ////chk_rule.checked = false;
                }

                rntbRule75.Text = string.Empty;

                if (rnt_CurrencyAmt.Text != string.Empty)
                {
                    if (rnt_CurrencyAmt.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rnt_CurrencyAmt.Focus();
                        ////chk_rule.checked = false;
                        return;
                    }

                    if (rntb_bal.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rntb_bal.Text = string.Empty;
                        rntb_bal.Focus();
                        ////chk_rule.checked = false;
                        return;
                    }

                    if (rntbEduAllScale.Text != string.Empty && rntb_bal.Text != string.Empty && rnt_CurrencyAmt.Text != string.Empty)
                    {
                        DataTable dtRule = BLL.GetFinalRuledAmnt(rntbEduAllScale.Text, rntb_bal.Text, rnt_CurrencyAmt.Text, "1"); //value 1 for Edu. Allowance

                        if (dtRule.Rows.Count > 0)
                            rntbRule75.Text = Convert.ToString(dtRule.Rows[0]["RESULT"]);
                        else
                            rntbRule75.Text = "-1";
                    }

                    //below lines are commented by Eshwar_Dev 20170316 due to the changes raised by Joshua at client location
                    /*if (val == 2)
                    {
                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > (Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])))
                            {
                                BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])) + " only which consists of old rule amount and available balance amount");
                                rnt_CurrencyAmt.Text = string.Empty;
                                rnt_CurrencyAmt.Focus();
                                ////chk_rule.checked = false;
                                return;
                            }
                        }
                        else
                        {
                            rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                        }
                    }
                    else if (val == 1)
                    {
                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > Convert.ToDouble(rntb_bal.Text))
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rntb_bal.Text));

                            }
                            else
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                            }
                        }
                    }*/
                }
            }
        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaim", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }

    /*protected void rad_ClaimAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();

            //for  amount after Conversion in claim amount validation

            if ((Convert.ToDouble(rad_ClaimAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
            {
                BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Conversion..!");
                rad_ClaimAmount.Text = string.Empty;
                return;
            }

            //if rule checkbox is uncheched
            if (chk_rule.Checked == false)
            {
                if (rcbFinPeriod.SelectedIndex > 0)
                {

                    if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
                    {

                        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                        if (dtEmpEduData.Rows.Count > 0)
                            rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rnt_CurrencyAmt.Value));// - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));

                        else
                            rntbRule75.Text = rntbEduAllScale.Text;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");
                        rntb_bal.Text = string.Empty;
                        rcbDependentName.Focus();

                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Financial Period");

                    rcbFinPeriod.Focus();

                    return;
                }
            }
            //for display one currency amount to another currency amount
            rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty


            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
            if (rcmb_Currency.SelectedIndex > 0)
            {
                DataTable dtcurrency = new DataTable();
                dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                if (dtcurrency.Rows.Count > 0)
                {
                    if (rad_ClaimAmount.Text != string.Empty)
                    {
                        double value = 0.0;
                        value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                        rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) / value);
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    rad_ClaimAmount.Text = string.Empty;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please Select Currency Type...!");
                rnt_CurrencyAmt.Text = string.Empty;
                rad_ClaimAmount.Text = string.Empty;
            }



            if (chk_rule.Checked == true)   //if 75% rule checkbox is checked
            {
                //for  amount after Conversion in claim amount validation
                if (rad_ClaimAmount.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(rad_ClaimAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                    {
                        BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Conversion..!");
                        rad_ClaimAmount.Text = string.Empty;
                        //chk_rule.checked = false;
                    }
                }

                //for display one currency amount to another currency amount
                rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty
                if (rcmb_Currency.SelectedIndex > 0)
                {

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                    DataTable dtcurrency = new DataTable();
                    dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                    if (dtcurrency.Rows.Count > 0)
                    {
                        if (rad_ClaimAmount.Text != string.Empty)
                        {
                            double value = 0.0;
                            value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                            rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) / value);
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rad_ClaimAmount.Text = string.Empty;
                        //chk_rule.checked = false;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    rad_ClaimAmount.Text = string.Empty;
                    //chk_rule.checked = false;
                }

                rntbRule75.Text = string.Empty;

                if (rnt_CurrencyAmt.Text != string.Empty)
                {
                    if (rnt_CurrencyAmt.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rnt_CurrencyAmt.Focus();
                        //chk_rule.checked = false;
                        return;
                    }
                    if (rntb_bal.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rntb_bal.Text = string.Empty;
                        rntb_bal.Focus();
                        //chk_rule.checked = false;
                        return;
                    }
                    if (val == 2)
                    {
                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > (Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])))
                            {
                                BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])) + " only which consists of old rule amount and available balance amount");
                                rnt_CurrencyAmt.Text = string.Empty;
                                rnt_CurrencyAmt.Focus();
                                //chk_rule.checked = false;
                                return;
                            }
                        }
                        else
                        {
                            rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                        }
                    }
               

                    else if (val == 1)
                    {
                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > Convert.ToDouble(rntb_bal.Text))
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rntb_bal.Text));

                            }
                            else
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                            }
                        }

                    }
                }
            }


        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }*/

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Rm_Education_page.SelectedIndex = 0;
            clearControls();
            LoadGrid();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rcmb_Currency.SelectedValue == string.Empty || rcmb_Currency.SelectedValue == null)
            {
                BLL.ShowMessage(this, "Please Select Currency Type..!");
                rcmb_Currency.Focus();
                return;
            }

            if (rnt_CurrencyAmt.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter currency amount in usd$..!");
                rnt_CurrencyAmt.Focus();
                return;
            }
            if (rnt_maxcurramt.Text == string.Empty)
            {
                BLL.ShowMessage(this, "Please Enter Amount After Conversion..!");
                rnt_maxcurramt.Focus();
                return;
            }

            if (rntb_bal.Text == "0")
            {
                BLL.ShowMessage(this, "You are not having any balance amount to initiate this claim");
                return;
            }

            bool status;

            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_BU_ID = Convert.ToInt32(rcmb_BusinessUnit.SelectedValue);
            if (rcmb_Department.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = Convert.ToInt32(rcmb_Department.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_DEPT_ID = 0;
            if (rcbScale.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = Convert.ToInt32(rcbScale.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPLOYEEGRADE_ID = 0;
            if (rntbEduAllScale.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = Convert.ToInt32(rntbEduAllScale.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_ALLOWANCE_DEPENDENT = 0;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
            if (rntb_bal.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = Convert.ToDecimal(rntb_bal.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_BAL_AVL = 0;
            //_OBJ_SMHR_EDU_ALLOWANCE.EDU_EXPEN_NAME = rtxt_Expenditure.Text;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CLAIM_AMT = Convert.ToDecimal(rad_ClaimAmount.Text);
            if (rntbRule75.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = Convert.ToDecimal(rntbRule75.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_FINAL_AMNT = 0;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_NO = Convert.ToInt32(rntbReceiptNo.Text);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_RECPT_DATE = Convert.ToDateTime(rdpt_ReceiptDate.SelectedDate);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CREATEDBY = Convert.ToInt32(Session["EMP_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_LASTMDFBY = Convert.ToInt32(Session["EMP_ID"]);
            if (rcbFinPeriod.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = 0;

            if (rcmb_Currency.SelectedValue != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = 0;
            if (rnt_CurrencyAmt.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_AMT = Convert.ToDecimal(rnt_CurrencyAmt.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_AMT = 0;

            if (rnt_maxcurramt.Text != string.Empty)
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CONVERION_AMT = Convert.ToDecimal(rnt_maxcurramt.Text);
            else
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_CONVERION_AMT = 0;


            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ISRULEID = Convert.ToBoolean(chk_rule.Checked);

            if (FBrowse.HasFile)
            {
                string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + FBrowse.FileName;
                string strPath = "~/Download/EducationInvoice/" + pdfName;
                FBrowse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_RECPTDOC = strPath;
            }
            if (fu_Browse.HasFile)
            {
                string pdfName = rcmb_Employee.SelectedValue + "_" + Guid.NewGuid().ToString() + "_" + fu_Browse.FileName;
                string strPath = "~/Download/EducationInvoice/" + pdfName;
                FBrowse.PostedFile.SaveAs(Server.MapPath("~/Download/EducationInvoice/") + pdfName);
                _OBJ_SMHR_EDU_ALLOWANCE.EDU_UPLOAD_ATTDCERT = strPath;
            }
            switch (((Button)sender).ID.ToUpper())
            {
                case "BTN_SUBMIT":

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CHECKDUPLICATE;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_STATUS = 0;

                    DataTable dtCheckDup = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (Convert.ToString(dtCheckDup.Rows[0]["COUNT"]) != string.Empty)
                    {
                        if (Convert.ToInt32(dtCheckDup.Rows[0]["COUNT"]) > 0)
                        {
                            Response.Redirect("~/Selfservice/EduClaimEmp.aspx", false);
                            return;
                        }
                    }

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Insert;

                    status = BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Saved successfully");
                    else
                        BLL.ShowMessage(this, "Information not Saved");

                    break;

                case "BTN_UPDATE":

                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Update;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ID = eduClmID;

                    status = BLL.SetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                    if (status == true)
                        BLL.ShowMessage(this, "Information Updated successfully");
                    else
                        BLL.ShowMessage(this, "Information not Updated");

                    break;

                default:
                    break;
            }
            Rm_Education_page.SelectedIndex = 0;
            LoadGrid();
            Rg_Educationdet.DataBind();
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmployees()
    {
        try
        {
            SMHR_EMPLOYEE _obj_smhr_employee = new SMHR_EMPLOYEE();

            _obj_smhr_employee.OPERATION = operation.Select;
            _obj_smhr_employee.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            _obj_smhr_employee.EMP_LOGIN_ID = Convert.ToInt32(Session["USER_ID"]);
            _obj_smhr_employee.EMP_ID = Convert.ToInt32(Session["EMP_ID"]);
            DataTable dtEmp = BLL.get_Employee(_obj_smhr_employee);

            rcmb_Employee.DataSource = dtEmp;
            rcmb_Employee.DataTextField = "EMP_NAME";
            rcmb_Employee.DataValueField = "EMP_ID";
            rcmb_Employee.DataBind();
            rcmb_Employee.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadBusinessUnits()
    {
        try
        {
            SMHR_LOGININFO _obj_SMHR_LOGININFO = new SMHR_LOGININFO();

            _obj_SMHR_LOGININFO.OPERATION = operation.Select;
            _obj_SMHR_LOGININFO.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtBU = BLL.get_Sup_BusinessUnit(_obj_SMHR_LOGININFO);

            rcmb_BusinessUnit.DataSource = dtBU;
            rcmb_BusinessUnit.DataTextField = "BUSINESSUNIT_CODE";
            rcmb_BusinessUnit.DataValueField = "BUSINESSUNIT_ID";
            rcmb_BusinessUnit.DataBind();
            rcmb_BusinessUnit.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadDepartments()
    {
        try
        {
            SMHR_DEPARTMENT _obj_SMHR_Department = new SMHR_DEPARTMENT();

            _obj_SMHR_Department.MODE = 20;
            _obj_SMHR_Department.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtDept = BLL.get_Department(_obj_SMHR_Department);

            rcmb_Department.DataSource = dtDept;
            rcmb_Department.DataTextField = "DEPARTMENT_NAME";
            rcmb_Department.DataValueField = "DEPARTMENT_ID";
            rcmb_Department.DataBind();
            rcmb_Department.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadScales()
    {
        try
        {
            SMHR_EMPLOYEEGRADE _obj_Smhr_EmployeeGrade = new SMHR_EMPLOYEEGRADE();

            _obj_Smhr_EmployeeGrade.OPERATION = operation.EmployeeGrade;
            _obj_Smhr_EmployeeGrade.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);

            DataTable dtEmpGrade = BLL.GetEmployeeGrade(_obj_Smhr_EmployeeGrade);

            rcbScale.DataSource = dtEmpGrade;
            rcbScale.DataTextField = "EMPLOYEEGRADE_CODE";
            rcbScale.DataValueField = "EMPLOYEEGRADE_ID";
            rcbScale.DataBind();
            rcbScale.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadEmpFamilyDetails()
    {
        try
        {
            if (rcmb_Employee.SelectedIndex > 0)
            {
                SMHR_EMPLOYEE _obj_SMHR_EMPLOYEE = new SMHR_EMPLOYEE();

                _obj_SMHR_EMPLOYEE.OPERATION = operation.CheckEmp;
                _obj_SMHR_EMPLOYEE.EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);

                DataTable dtEmpFmlys = BLL.get_EmployeeFamily(_obj_SMHR_EMPLOYEE);

                rcbDependentName.DataSource = dtEmpFmlys;
                rcbDependentName.DataTextField = "EMPFMDTL_NAME";
                rcbDependentName.DataValueField = "EMPFMDTL_ID";
                rcbDependentName.DataBind();
                rcbDependentName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
            }
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void LoadFinancialPeriod()
    {
        try
        {
            SMHR_PERIOD _obj_smhr_period = new SMHR_PERIOD();

            _obj_smhr_period.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dtFinPrd = BLL.GET_FIN_PERIOD(_obj_smhr_period);
            rcbFinPeriod.DataSource = dtFinPrd;
            rcbFinPeriod.DataTextField = "PERIOD_NAME";
            rcbFinPeriod.DataValueField = "PERIOD_ID";
            rcbFinPeriod.DataBind();
            rcbFinPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select"));
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void clearControls()
    {
        try
        {
            rcmb_BusinessUnit.SelectedIndex = 0;
            rcmb_Department.SelectedIndex = 0;
            rcbFinPeriod.Items.Clear();
            rcbFinPeriod.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", ""));
            rcbFinPeriod.SelectedIndex = 0;
            rcbScale.SelectedIndex = 0;
            rcbDependentName.Items.Clear();
            rcbDependentName.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", ""));
            rcbDependentName.SelectedIndex = 0;
            rntbEduAllScale.Text = string.Empty;
            rntb_bal.Text = string.Empty;
            // rtxt_Expenditure.Text = string.Empty;
            rad_ClaimAmount.Text = string.Empty;
            rntbReceiptNo.Text = string.Empty;
            rntbRule75.Text = string.Empty;
            rdpt_ReceiptDate.Clear();
            rcmb_Currency.Items.Clear();
            rcmb_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("", ""));
            rcmb_Currency.SelectedIndex = 0;

            rnt_CurrencyAmt.Text = string.Empty;
            rnt_maxcurramt.Text = "";
        }
        catch (System.Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    private void LoadToCurrency()
    {
        try
        {

            rcmb_Currency.Items.Clear();

            rnt_CurrencyAmt.Text = string.Empty;
            rad_ClaimAmount.Text = string.Empty;
            _obj_smhr_Currency = new SMHR_CURRENCY();
            _obj_smhr_Currency.ORGANISATION_ID = Convert.ToInt32(Session["ORG_ID"]);
            DataTable dt_Details = BLL.get_Currency(_obj_smhr_Currency);
            rcmb_Currency.DataSource = dt_Details;
            rcmb_Currency.DataTextField = "CURR_CODE";
            rcmb_Currency.DataValueField = "CURR_ID";
            rcmb_Currency.DataBind();
            rcmb_Currency.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("Select", "0"));

        }
        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void rcmb_Currency_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            //FOR BALANCE AVAILABLE  CURRENCY CONVERSION 

            if (rcbFinPeriod.SelectedIndex > 0)
            {

                if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
                {
                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.check;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                    DataTable dt = new DataTable();
                    dt = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                    if (Convert.ToInt32(dt.Rows[0]["CLAIM"]) == 0)   //for new financial period
                    {
                        rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value));
                    }

                    else
                    {
                        // SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
                        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);

                        DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                        if (dtEmpEduData.Rows.Count > 0)
                            rntb_bal.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                        else
                            rntb_bal.Text = rntbEduAllScale.Text;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");
                    rntb_bal.Text = string.Empty;
                    rcbDependentName.Focus();
                    return;
                }
            }
            else
            {
                BLL.ShowMessage(this, "Please select Financial Period");

                rcbFinPeriod.Focus();
                return;
            }

            string currvalu = hdf_balamt.Value;
            hdf_balamt.Value = string.Empty;

            //SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
            _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
            _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
            if (rcmb_Currency.SelectedIndex > 0)
            {
                DataTable dtcurrency = new DataTable();
                dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                if (dtcurrency.Rows.Count > 0)
                {
                    if (rntb_bal.Text != string.Empty)
                    {
                        double value = 0.0;
                        value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table

                        rnt_maxcurramt.Text = Convert.ToString(Convert.ToDouble(rntb_bal.Text) * value);
                    }
                    /* if ((Convert.ToDouble(rnt_maxcurramt.Text)) > (Convert.ToDouble(rntb_bal.Text)))
                     {
                         BLL.ShowMessage(this, "Max Currency Amount is exceed than balance avilable..!");
                         rnt_maxcurramt.Text = string.Empty;
                     }*/
                }
                else
                {
                    BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                    rnt_CurrencyAmt.Text = string.Empty;

                }
            }


            /* //divya



             //FOR BALANCE AVAILABLE  CURRENCY CONVERSION 

             // if (hf_Claimamount.Value != string.Empty)
             //{
             string basevalue = hf_Claimamount.Value;

             hf_Claimamount.Value = string.Empty;

       

             //SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
             _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
             _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
             _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);
             if (rcmb_Currency.SelectedIndex > 0)
             {
                 DataTable dtcurrency = new DataTable();
                 dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                 if (dtcurrency.Rows.Count > 0)
                 {
                     if (rad_ClaimAmount.Text != string.Empty)
                     {
                         double value = 0.0;
                         value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                         rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(basevalue) * value);
                      
                     }
                 }
                 else
                 {
                     BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                     rnt_CurrencyAmt.Text = string.Empty;
                   
                 }
             }*/





        }



        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }
    }
    protected void chk_rule_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_rule.Checked == true)   //if 75% checkbox is checked
            {
                //for  amount after Conversion in claim amount validation
                if (rad_ClaimAmount.Text != string.Empty && rnt_maxcurramt.Text != string.Empty)
                {
                    if ((Convert.ToDouble(rad_ClaimAmount.Text)) > (Convert.ToDouble(rnt_maxcurramt.Text)))
                    {
                        BLL.ShowMessage(this, "Claim Amount is exceeded than Amount after Conversion..!");
                        rad_ClaimAmount.Text = string.Empty;
                        //chk_rule.checked = false;
                    }
                }

                //for display one currency amount to another currency amount
                rnt_CurrencyAmt.Text = string.Empty;  //checking for  textbox empty
                if (rcmb_Currency.SelectedIndex > 0)
                {
                    SMHR_EDU_ALLOWANCE _OBJ_SMHR_EDU_ALLOWANCE = new SMHR_EDU_ALLOWANCE();
                    _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.CurrencyRate;
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                    _OBJ_SMHR_EDU_ALLOWANCE.EDU_CURR_ID = Convert.ToInt32(rcmb_Currency.SelectedValue);

                    DataTable dtcurrency = new DataTable();
                    dtcurrency = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);
                    if (dtcurrency.Rows.Count > 0)
                    {
                        if (rad_ClaimAmount.Text != string.Empty)
                        {
                            double value = 0.0;
                            value = Convert.ToDouble(dtcurrency.Rows[0]["CURRENCY_CONVERSION_RATE"]);   //getting Conversion rate from table
                            rnt_CurrencyAmt.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) / value);
                        }
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Selected Currency Type Has No Conversion Rate..!");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rad_ClaimAmount.Text = string.Empty;
                        //chk_rule.checked = false;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please Select Currency Type...!");
                    rnt_CurrencyAmt.Text = string.Empty;
                    rad_ClaimAmount.Text = string.Empty;
                    //chk_rule.checked = false;
                }








                //for max currency amount in claim amount validation


                /* if (rad_ClaimAmount.Text != string.Empty)
                 {
                     if (rad_ClaimAmount.Text == "0")
                     {
                         BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                         rad_ClaimAmount.Text = string.Empty;
                         rad_ClaimAmount.Focus();
                         return;
                     }
                     if (Convert.ToDecimal(rad_ClaimAmount.Text) > Convert.ToDecimal(rntb_bal.Text))
                     {
                         BLL.ShowMessage(this, "Claim amount is exceeding Balance Available amount..");
                         rad_ClaimAmount.Text = string.Empty;
                         rad_ClaimAmount.Focus();
                         return;
                     }
                     rntbRule75.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) * 0.75);
                 }
                 else
                     rntbRule75.Text = string.Empty;*/



                //FOR CHANGE 07092016 rad_ClaimAmount=rnt_CurrencyAmt//

                rntbRule75.Text = string.Empty;

                if (rnt_CurrencyAmt.Text != string.Empty)
                {
                    if (rnt_CurrencyAmt.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rnt_CurrencyAmt.Text = string.Empty;
                        rnt_CurrencyAmt.Focus();
                        //chk_rule.checked = false;
                        return;
                    }
                    if (rntb_bal.Text == "0")
                    {
                        BLL.ShowMessage(this, "You are not supposed to claim any amounts as available balance amount is 0..");
                        rntb_bal.Text = string.Empty;
                        rntb_bal.Focus();
                        //chk_rule.checked = false;
                        return;
                    }
                    if (val == 2)
                    {

                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > (Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])))
                            {
                                BLL.ShowMessage(this, "You can enter amount upto " + Convert.ToString(Convert.ToDouble(rntb_bal.Text) + Convert.ToDouble(ViewState["rntbRule75"])) + " only which consists of old rule amount and available balance amount");
                                rnt_CurrencyAmt.Text = string.Empty;
                                rnt_CurrencyAmt.Focus();
                                //chk_rule.checked = false;
                                return;
                            }
                        }
                        else
                        {
                            rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                        }
                    }
                    /*else if (val == 1)
                    {
                        if ((Convert.ToDouble(rad_ClaimAmount.Text) * 0.75) > Convert.ToDouble(rntb_bal.Text))
                        {
                            BLL.ShowMessage(this, "Claim amount is exceeding Balance Available amount..");
                            rad_ClaimAmount.Text = string.Empty;
                            rad_ClaimAmount.Focus();
                            return;
                        }
                        else
                        {
                            rntbRule75.Text = Convert.ToString(Convert.ToDouble(rad_ClaimAmount.Text) * 0.75);
                        }
                    }*/

                    else if (val == 1)
                    {
                        if (rnt_CurrencyAmt.Text != string.Empty && rntb_bal.Text != string.Empty)
                        {
                            if ((Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75) > Convert.ToDouble(rntb_bal.Text))
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rntb_bal.Text));

                            }
                            else
                            {
                                rntbRule75.Text = Convert.ToString(Convert.ToDouble(rnt_CurrencyAmt.Text) * 0.75);
                            }
                        }

                    }
                }
            }
            else   //if 75% rule checkbox is unchecked
            {
                if (rcbFinPeriod.SelectedIndex > 0)
                {

                    if (rcbDependentName.SelectedIndex > 0 && rcmb_Employee.SelectedIndex > 0)
                    {
                        _OBJ_SMHR_EDU_ALLOWANCE.OPERATION = operation.Count;
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMP_ID = Convert.ToInt32(rcmb_Employee.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_EMPFMDTL_ID = Convert.ToInt32(rcbDependentName.SelectedValue);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_ORG_ID = Convert.ToInt32(Session["ORG_ID"]);
                        _OBJ_SMHR_EDU_ALLOWANCE.EDU_PERIOD_ID = Convert.ToInt32(rcbFinPeriod.SelectedValue);
                        DataTable dtEmpEduData = BLL.GetEduAllowance(_OBJ_SMHR_EDU_ALLOWANCE);

                        if (dtEmpEduData.Rows.Count > 0)
                            //rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rntbEduAllScale.Value) - Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"]));
                            rntbRule75.Text = Convert.ToString(Convert.ToDecimal(rnt_CurrencyAmt.Value)); //- Convert.ToDecimal(dtEmpEduData.Rows[0]["CLAIM"])); 
                        else
                            rntbRule75.Text = rntbEduAllScale.Text;
                    }
                    else
                    {
                        BLL.ShowMessage(this, "Please select Dependent name to get balance available amount");
                        rntb_bal.Text = string.Empty;
                        rcbDependentName.Focus();
                        //chk_rule.checked = false;
                        return;
                    }
                }
                else
                {
                    BLL.ShowMessage(this, "Please select Financial Period");

                    rcbFinPeriod.Focus();
                    //chk_rule.checked = false;
                    return;
                }
            }

        }

        catch (Exception ex)
        {
            SMHR.BLL.Error_Log(Session["USER_ID"].ToString(), ex.TargetSite.ToString(), ex.Message.Replace("'", "''"), "EduClaimEmp", ex.StackTrace, DateTime.Now);
            Response.Redirect("~/Frm_ErrorPage.aspx");
        }

    }
}